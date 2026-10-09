# Linear Regression with Normal Equation

A simple implementation of **Linear Regression** from scratch using NumPy, trained via the **Normal Equation** (closed-form solution) instead of gradient descent.

---

## 📌 Overview

This project:
1. Loads a dataset from a CSV file.
2. Extracts only the **numeric columns**.
3. Splits the data into **features (X)** and **target (y)** — the last numeric column is treated as the target.
4. Adds a **bias term** (column of ones) to the feature matrix.
5. Splits the data into **training** and **testing** sets.
6. Computes the optimal weights using the **Normal Equation**.
7. Evaluates the model using **Mean Squared Error (MSE)**.

---

## 🧮 The Normal Equation

Instead of using gradient descent, this project uses the closed-form solution:

$$\theta = (X^T X)^{-1} X^T y$$

Where:
- $X$ — design matrix (with bias column),
- $y$ — target vector,
- $\theta$ — vector of learned weights.

This approach is exact and requires no learning rate or iterations — but it can be expensive for very large datasets because of the matrix inversion.

---

## 📂 Project Structure

```
.
├── main.py          # Main script
├── README.md        # Documentation
└── your_data.csv    # Dataset (provided at runtime)
```

---

## ⚙️ Requirements

- Python 3.8+
- NumPy
- pandas

Install dependencies:

```bash
pip install numpy pandas
```

---

## 🚀 Usage

Run the script:

```bash
python main.py
```

You will be asked to enter the path to your CSV file:

```
Path : ./your_data.csv
```

### Expected output

```
X shape: (n_samples, n_features)
y shape: (n_samples,)
X shape: (n_samples, n_features + 1)
y shape: (n_samples,)
Train size: ...
Test size: ...
Theta (weights):
 [ ... ]
Mean Squared Error (MSE): ...
```

---

## 📊 Dataset Requirements

- The CSV file must contain **numeric columns** (non-numeric columns are ignored).
- The **last numeric column** is assumed to be the **target variable (y)**.
- All other numeric columns are treated as **features (X)**.

Example:

| feature1 | feature2 | target |
|----------|----------|--------|
| 1.2      | 3.4      | 5.6    |
| 2.1      | 4.3      | 7.8    |

---

## 🧩 Code Walkthrough

### 1. Custom Train/Test Split

```python
def train_test_split_np(X, y, test_size=0.2, seed=None, shuffle=True):
    ...
```

A NumPy-based equivalent of `sklearn.model_selection.train_test_split` supporting reproducibility via `seed` and optional shuffling.

### 2. Bias Term

```python
X = np.insert(X, 0, 1, axis=1)
```

Adds a column of ones so the model can learn an **intercept** term.

### 3. Training (Normal Equation)

```python
Theta = np.linalg.inv(X_train.T @ X_train) @ (X_train.T @ y_train)
```

Computes the optimal weights in a single step.

### 4. Prediction

```python
y_pred = X_test @ Theta
```

### 5. Evaluation

```python
mse = np.mean((y_test - y_pred) ** 2)
```

---

## ⚠️ Notes & Limitations

- **Matrix inversion** in the Normal Equation can be numerically unstable if $X^T X$ is singular or nearly singular. In practice, `np.linalg.pinv` or `np.linalg.solve` is preferred.
- Only **numeric** columns are used; categorical features must be encoded manually.
- Works best for **small to medium-sized** datasets. For large-scale problems, use gradient descent or `scikit-learn`.

---

## 🔧 Possible Improvements

- Use `np.linalg.solve(X.T @ X, X.T @ y)` instead of computing the inverse explicitly.
- Add **feature scaling** (standardization / normalization).
- Support **categorical encoding** and **feature selection**.
- Compare results with `sklearn.linear_model.LinearRegression`.
- Add **R² score** and other metrics.

---

## 📜 License

This project is open-source and free to use for educational purposes.