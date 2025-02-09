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
    
# 📌 Step 2: Load IMDB Dataset
print("Loading dataset...")
df = pd.read_csv("IMDB Dataset Train.csv")


# Print the initial size of the dataset and the unique labels
print(f"Initial dataset size: {df.shape[0]}")
print(f"Unique labels before mapping: {df['label'].unique()}")

# Check for any unexpected values
print("Checking for any unexpected values in the label column...")
unexpected_values = df['label'][~df['label'].isin(['positive', 'negative'])]
if not unexpected_values.empty:
    print(f"Unexpected label values found: {unexpected_values.unique()}")

# Convert labels to binary
df['label'] = df['label'].map({'positive': 1, 'negative': 0})

# Print unique values after mapping
print(f"Unique labels after mapping: {df['label'].unique()}")

# Check for NaN values in the labels
if df['label'].isnull().any():
    print("Warning: NaN values found in labels. Dropping rows with NaN labels.")
    df = df.dropna(subset=['label'])  # Drop rows where 'label' is NaN

# Print the size of the dataset after dropping NaN labels
print(f"Dataset size after dropping NaN labels: {df.shape[0]}")

# If the dataset is empty, exit or handle the situation
if df.shape[0] == 0:
    print("Error: No valid samples remaining. Exiting.")
    exit()

# 📌 Step 3: Preprocess Text Data
def preprocess_text(text):
    tokens = word_tokenize(text.lower())  # Tokenize & lowercase
    return ' '.join([word for word in tokens if word.isalnum()])  # Remove non-alphanumeric

df['clean_text'] = df['text'].apply(preprocess_text)

# 📌 Step 4: Split Data
X_train, X_test, y_train, y_test = train_test_split(df['clean_text'], df['label'], test_size=0.2, random_state=42)

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
    df_fasttext = df.copy()
    df_fasttext['fasttext_label'] = '__label__' + df_fasttext['label'].astype(str)
    df_fasttext[['fasttext_label', 'clean_text']].to_csv(fasttext_train_file, index=False, sep=' ', header=False)

print("Training FastText model...")
ft_model = fasttext.train_supervised(fasttext_train_file, epoch=25, lr=0.5, wordNgrams=2)

# 📌 Step 8: Predict with FastText Model
def fasttext_predict(texts):
    predictions = [ft_model.predict(text)[0][0] for text in texts]
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
