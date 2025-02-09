import os
import nltk
import pandas as pd
import numpy as np
import fasttext
import fasttext.util
from sklearn.feature_extraction.text import TfidfVectorizer
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LogisticRegression
from sklearn.metrics import accuracy_score, precision_score, recall_score, f1_score
from nltk.tokenize import word_tokenize

# 📌 Step 1: Automatically Download NLTK Tokenizer If Missing
try:
    nltk.data.find('tokenizers/punkt')
except LookupError:
    print("Downloading NLTK tokenizer...")
    nltk.download('punkt')

try:
    nltk.data.find('tokenizers/punkt_tab')
except LookupError:
    print("Downloading NLTK tokenizer...")
    nltk.download('punkt_tab')

# 📌 Step 2: Load Train and Test Datasets
print("Loading training and testing datasets...")
train_df = pd.read_csv("IMDB Dataset Train.csv")
test_df = pd.read_csv("IMDB Dataset Test.csv")

# # Convert labels to binary (assuming labels are in 'label' column as 'positive' or 'negative')
# train_df['label'] = train_df['label'].map({'positive': 1, 'negative': 0})
# test_df['label'] = test_df['label'].map({'positive': 1, 'negative': 0})

# 📌 Step 3: Preprocess Text Data
def preprocess_text(text):
    tokens = word_tokenize(text.lower())  # Tokenize & lowercase
    return ' '.join([word for word in tokens if word.isalnum()])  # Remove non-alphanumeric

train_df['clean_text'] = train_df['text'].apply(preprocess_text)
test_df['clean_text'] = test_df['text'].apply(preprocess_text)

# 📌 Step 4: Split Training Data
X_train = train_df['clean_text']
y_train = train_df['label']
X_test = test_df['clean_text']
y_test = test_df['label']

# 📌 Step 5: Feature Extraction with TF-IDF
vectorizer_raw = TfidfVectorizer()
vectorizer_stop = TfidfVectorizer(stop_words="english")  # Stopword filtering

X_train_tfidf = vectorizer_raw.fit_transform(X_train)
X_test_tfidf = vectorizer_raw.transform(X_test)

X_train_tfidf_stop = vectorizer_stop.fit_transform(X_train)
X_test_tfidf_stop = vectorizer_stop.transform(X_test)

# 📌 Step 6: Train Logistic Regression Models
log_reg = LogisticRegression(max_iter=1000)
log_reg.fit(X_train_tfidf, y_train)
y_pred_tfidf = log_reg.predict(X_test_tfidf)

log_reg_stop = LogisticRegression(max_iter=1000)
log_reg_stop.fit(X_train_tfidf_stop, y_train)
y_pred_tfidf_stop = log_reg_stop.predict(X_test_tfidf_stop)

# 📌 Step 7: Approach 3 - Train FastText Model
fasttext_train_file = "fasttext_train.txt"
if not os.path.exists(fasttext_train_file):
    print("Formatting data for FastText...")
    df_fasttext = train_df.copy()
    df_fasttext['fasttext_label'] = '__label__' + df_fasttext['label'].astype(str)
    df_fasttext[['fasttext_label', 'clean_text']].to_csv(fasttext_train_file, index=False, sep=' ', header=False)

print("Training FastText model...")
ft_model = fasttext.train_supervised(fasttext_train_file, epoch=25, lr=0.5, wordNgrams=2)

# 📌 Step 8: Predict with FastText Model
import numpy as np

def fasttext_predict(texts):
    predictions = []
    for text in texts:
        try:
            pred = ft_model.predict(text)[0][0]
            predictions.append(pred)
        except ValueError as e:
            print(f"Error predicting text: {text} -> {e}")
            predictions.append('__label__0')  # Default class for error handling
    predictions = np.asarray(predictions)  # Use np.asarray instead of np.array
    return [1 if label == '__label__1' else 0 for label in predictions]

y_pred_ft = fasttext_predict(X_test)

# 📌 Step 9: Evaluate All Models
def evaluate_model(y_true, y_pred, model_name):
    print(f"\n🔹 {model_name} Performance:")
    print(f"Accuracy: {accuracy_score(y_true, y_pred):.4f}")
    print(f"Precision: {precision_score(y_true, y_pred):.4f}")
    print(f"Recall: {recall_score(y_true, y_pred):.4f}")
    print(f"F1 Score: {f1_score(y_true, y_pred):.4f}")

evaluate_model(y_test, y_pred_tfidf, "Logistic Regression (TF-IDF)")
evaluate_model(y_test, y_pred_tfidf_stop, "Logistic Regression (TF-IDF + Stopword Filtering)")
evaluate_model(y_test, y_pred_ft, "FastText Model")

print("\n✅ Sentiment Analysis Completed Successfully!")
