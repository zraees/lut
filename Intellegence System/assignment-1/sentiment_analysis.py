import os
import nltk
import pandas as pd
import numpy as np
import fasttext
from sklearn.feature_extraction.text import TfidfVectorizer
from sklearn.linear_model import LogisticRegression
from sklearn.metrics import accuracy_score, precision_score, recall_score, f1_score
from nltk.tokenize import word_tokenize

# 📌 Step 1: Download necessary NLTK data
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
        
# nltk.download('punkt')
# nltk.download('punkt_tab')

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

# 📌 Step 4: Split Data
X_train = train_df['clean_text']
y_train = train_df['label']
X_test = test_df['clean_text']
y_test = test_df['label']

# 📌 Step 5: Feature Extraction with TF-IDF
vectorizer_raw = TfidfVectorizer()
vectorizer_stop = TfidfVectorizer(stop_words="english")  

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


# 📌 Step 7: Train FastText Model from File
# import fasttext
# import os
# import numpy as np

# 📌 Step 7: Train FastText Model from File
fasttext_train_file = "fasttext_train.txt"

if not os.path.exists(fasttext_train_file):
    print("Formatting data for FastText...")
    
    train_df['fasttext_label'] = '__label__' + train_df['label'].astype(str)
    train_df[['fasttext_label', 'clean_text']].to_csv(
        fasttext_train_file,
        index=False,
        sep=' ',  # Use space as separator
        header=False,
        quoting=3,  # QUOTE_NONE (3) prevents unnecessary quotes
        escapechar='\\'  # Specify escape character to handle special characters
    )

# 📌 Step 8: Train FastText Model
# ft_model = fasttext.train_supervised(
#     input=fasttext_train_file, 
#     lr=0.01,  # Adjust learning rate for fine-tuning
#     epoch=90,  # Increase epochs for better training
#     wordNgrams=2,
#     dim=300  # Dimension of the embeddings
# )

ft_model = fasttext.train_supervised(
    input=fasttext_train_file,
    lr=0.01,         # Adjust learning rate for better convergence
    epoch=150,       # Increase epochs for better training
    wordNgrams=3,    # Use 3-grams for capturing more context
    dim=500,         # Increase dimension for richer word vectors
    loss='softmax',  # Change loss function for better results in text classification
    bucket=2000000,  # Increase the bucket size for better handling of larger vocab
    minCount=3       # Consider only words with frequency higher than 5
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

# 📌 Step 9: Predict with FastText Model
def predict_with_fasttext(model, texts):
    predictions = []
    for text in texts:
        try:
            # Ensure the text is a single line by removing any newlines
            text = text.replace('\n', ' ').strip()  # Remove newline and strip leading/trailing spaces
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
y_pred_ft = predict_with_fasttext(ft_model, X_test)

# Print predictions
#print("FastText Predictions:", y_pred_ft[:10])  # Displaying the first 10 predictions

# 📌 Step 10: Evaluate All Models
def evaluate_model(y_true, y_pred, model_name):
    try:
        print(f"\n🔹 {model_name} Performance:")
        print(f"Accuracy: {accuracy_score(y_true, y_pred):.4f}")
        print(f"Precision: {precision_score(y_true, y_pred, average='weighted', zero_division=0):.4f}")
        print(f"Recall: {recall_score(y_true, y_pred, average='weighted', zero_division=0):.4f}")
        print(f"F1 Score: {f1_score(y_true, y_pred, average='weighted', zero_division=0):.4f}")
    except ValueError as e:
        print(f"Error in {model_name} evaluation: {e}")

evaluate_model(y_test, y_pred_tfidf, "Logistic Regression (TF-IDF)")
evaluate_model(y_test, y_pred_tfidf_stop, "Logistic Regression (TF-IDF + Stopword Filtering)")
evaluate_model(y_test, y_pred_ft, "FastText Model")

print("\n✅ Sentiment Analysis Completed Successfully!")