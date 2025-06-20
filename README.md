
# 💱 Currency Converter (WPF)

A simple desktop app to convert between currencies, built using **C# and WPF**.

---

## 🛠 Features

- Convert currency using predefined rates
- Easy-to-use interface
- Input validation
- Example: EUR → BDT

---

## 🔍 How It Works

The formula used:
```
ConvertedValue = (FromCurrencyRate × Amount) / ToCurrencyRate
```

Example:
- From: EUR (1.0)
- To: BDT (127.50)
- Amount: 10

Result: `10 × 127.50 = 1275.00 BDT`

---

## 🖥 UI Components

- `TextBox` – Enter amount
- `ComboBox` – Choose From/To currencies
- `Button` – Convert
- `Label` – Shows result

---

## ▶️ Run the App

1. Open the project in **Visual Studio**
2. Press `F5` or click **Start**
3. Try converting an amount!

---

## ✅ Example

```
10 EUR → BDT = 1275.00
```

---

## 📌 Notes

- Rates are hardcoded (you can add API support later)
- Built for learning and practice

---

## 📄 License

Free to use. MIT License.
