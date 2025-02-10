import os
import nltk
import pandas as pd
import numpy as np
import fasttext
from sklearn.feature_extraction.text import TfidfVectorizer
from sklearn.linear_model import LogisticRegression
from sklearn.metrics import accuracy_score, precision_score, recall_score, f1_score
from nltk.tokenize import word_tokenize

# Initial setup: Download necessary NLTK data (if not already downloaded)
try:
    nltk.data.find('tokenizers/punkt')
except LookupError: 
    nltk.download('punkt')

try:
    nltk.data.find('tokenizers/punkt_tab')
except LookupError: 
    nltk.download('punkt_tab')
        
# nltk.download('punkt')
# nltk.download('punkt_tab')

# Step to Load Train and Test Datasets
print("Loading training and testing datasets...")
imdb_train_df = pd.read_csv("IMDB Dataset Train.csv")
imdb_test_df = pd.read_csv("IMDB Dataset Test.csv")

# Step to Preprocess Text Data (1- Tokenize & lowercase, 2- Remove non-alphanumeric)
def preprocess_text(text):
    tokens = word_tokenize(text.lower())  
    return ' '.join([word for word in tokens if word.isalnum()])

imdb_train_df['clean_text'] = imdb_train_df['text'].apply(preprocess_text)
imdb_test_df['clean_text'] = imdb_test_df['text'].apply(preprocess_text)

# Step to Split Data in varaibles
X__train = imdb_train_df['clean_text']
y__train = imdb_train_df['label']
X__test = imdb_test_df['clean_text']
y__test = imdb_test_df['label']

# Step to Feature Extraction with TF-IDF (suggested in excercise class)
vectorizer__raw = TfidfVectorizer()
vectorizer__stop = TfidfVectorizer(stop_words="english")

X__train_tfidf = vectorizer__raw.fit_transform(X__train)
X__test_tfidf = vectorizer__raw.transform(X__test)

X__train_tfidf_stop = vectorizer__stop.fit_transform(X__train)
X__test_tfidf_stop = vectorizer__stop.transform(X__test)

# Important Step; Train Logistic Regression Models ( approach 1 & 2 )
log__reg = LogisticRegression(max_iter=1000)
log__reg.fit(X__train_tfidf, y__train)
y__pred_tfidf = log__reg.predict(X__test_tfidf)

log__reg_stop = LogisticRegression(max_iter=1000)
log__reg_stop.fit(X__train_tfidf_stop, y__train)
y__pred_tfidf_stop = log__reg_stop.predict(X__test_tfidf_stop)

# 3rd approach Step: Train FastText Model from File
fasttext_train_txt_file = "fasttext_train.txt"

if not os.path.exists(fasttext_train_txt_file):
    print("Generating data for FastText ...")
    
    imdb_train_df['fasttext_label'] = '__label__' + imdb_train_df['label'].astype(str)
    imdb_train_df[['fasttext_label', 'clean_text']].to_csv(
        fasttext_train_txt_file,
        index=False,
        header=False,
        sep=' ',            # Use space as separator
        quoting=3,          # QUOTE_NONE (3) prevents unnecessary quotes
        escapechar='\\'     # Specify escape character to handle special characters
    )

# Step to Train FastText Model (fine-tuning) but unfortunately didnt get good results
ft_model = fasttext.train_supervised(
    input=fasttext_train_txt_file,
    lr=0.01,         # set learning rate for better convergence
    epoch=150,       # Inc epochs for better training
    wordNgrams=3,    # Use 3-grams for capturing more context
    dim=500,         # Inc dimension for richer word vectors
    loss='softmax',  # loss function for better results in text classification
    bucket=2000000,  # Inc the bucket size for better handling of larger vocab
    minCount=5       # only words with frequency higher than 5
)

# sample_text = "__label__1 This is a sample review."

# try:
#     labels, probs = ft_model.predict(sample_text)
# except ValueError as e:
#     print("Caught ValueError:", e)
#     # Handle the probabilities manually using np.asarray instead of np.array
#     labels, probs = ft_model.predict(sample_text)
#     probs = np.asarray(probs)  # Convert probs to an array safely
#     print(f"Sample Prediction: {labels}, Probs: {probs}")

# print(f"Sample Prediction: {labels}, Probabilities: {probs}")

# Step to Predict using FastText Model
def predict_with_fasttext(model, texts):
    predictions = []
    for text in texts:
        try:
            # Ensure the text is a single line by removing any newlines
            text = text.replace('\n', ' ').strip()
            labels, probs = model.predict(list(text))
            
            if len(labels[0]) > 0:
                #print(labels)
                lbl = str(labels[0]) 
                label = int(eval(lbl.replace('__label__', ''))[0])
                predictions.append(label)
            else:
                predictions.append(-1)  # Handle case of no prediction
        except ValueError as e:
            print(f"Prediction error: {e}")
            predictions.append(-1)  # Append a default value on error
    return predictions

# Predict on test data
y__pred_ft = predict_with_fasttext(ft_model, X__test)

# Print predictions
#print("FastText Predictions:", y__pred_ft[:10])  # Displaying the first 10 predictions

# Final Step to Evaluate All Models
def evaluate_model(y_true, y_pred, model_name):
    try:
        print(f"\n🔹 {model_name} Performance:")
        print(f"Accuracy: {accuracy_score(y_true, y_pred):.4f}")
        print(f"Precision: {precision_score(y_true, y_pred, average='weighted', zero_division=0):.4f}")
        print(f"Recall: {recall_score(y_true, y_pred, average='weighted', zero_division=0):.4f}")
        print(f"F1 Score: {f1_score(y_true, y_pred, average='weighted', zero_division=0):.4f}")
    except ValueError as e:
        print(f"Error in {model_name} evaluation: {e}")

evaluate_model(y__test, y__pred_tfidf, "Logistic Regression (TF-IDF) Model")
evaluate_model(y__test, y__pred_tfidf_stop, "Logistic Regression (TF-IDF & Stopword Filtering) Model")
evaluate_model(y__test, y__pred_ft, "FastText Model")

print("\n Sentiment Analysis on IMDb Done Successfully!")