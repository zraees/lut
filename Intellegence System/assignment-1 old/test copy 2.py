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

import os
import fasttext
import numpy as np

# 📌 Step 7: Train FastText Model
fasttext_train_file = "fasttext_train.txt"

if not os.path.exists(fasttext_train_file):
    print("Formatting data for FastText...")
    df_fasttext = train_df.copy()
    df_fasttext['fasttext_label'] = '__label__' + df_fasttext['label'].astype(str)
    df_fasttext[['fasttext_label', 'clean_text']].to_csv(
        fasttext_train_file, 
        index=False, 
        sep=' ', 
        header=False, 
        quoting=3  # QUOTE_NONE to prevent quotes
        # escapechar=' '  # Replace problematic characters
    )

# Verify dataset format
with open(fasttext_train_file, "r", encoding="utf-8") as f:
    for i, line in enumerate(f):
        print(f"Line {i}: {line.strip()}")
        if i == 10:
            break  # Only print first 10 lines

# Train FastText model
ft_model = fasttext.train_supervised(
    input=fasttext_train_file, 
    lr=0.05,    # Lower learning rate
    epoch=30,   # Increase epochs for stability
    wordNgrams=2
)

# Save trained model
ft_model.save_model("fasttext_model.bin")

# Load trained model
ft_model = fasttext.load_model("fasttext_model.bin")

def fasttext_predict(texts):
    predictions = [ft_model.predict(text) for text in texts]
    
    # Extract labels and probabilities properly
    labels = [pred[0][0] for pred in predictions]
    probs = [pred[1][0] for pred in predictions]

    # Convert labels to 0/1 and use np.asarray() to avoid the NumPy error
    return np.asarray([1 if label == '__label__1' else 0 for label in labels], dtype=int)

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
evaluate_model(y_test, y_pred_ft, "Fine-Tuned FastText Model")

print("\n✅ Sentiment Analysis Completed Successfully!")
