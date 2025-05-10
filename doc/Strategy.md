## Strategy Design Pattern – Payment Method Example (C#)

### Summary

This example demonstrates the **Strategy Pattern** using a payment system. The goal is to encapsulate payment algorithms (credit card, crypto, etc.) and make them interchangeable without modifying the checkout logic.

---

### Real-World Example

Think of an online store checkout process:
Users can choose between different **payment methods** — each with its own process, but all perform the same task: "complete the payment".

Instead of using `if/else` statements, the **Strategy Pattern** delegates the payment action to interchangeable classes.

---

### 🧱 Components

| Role                                 | Description                                            |
| ------------------------------------ | ------------------------------------------------------ |
| `IPaymentStrategy`                   | Strategy interface – declares the `Pay()` method.      |
| `CreditCardPayment`, `CryptoPayment` | Concrete strategies implementing different algorithms. |
| `CheckoutProcessor`                  | Context – uses a strategy to perform the payment.      |

---

### Benefits

* Open/Closed Principle: add new strategies without touching existing code
* Interchangeable behaviors at runtime
* Decouples algorithm from the context

---

### Pattern Keywords

* **Encapsulation**
* **Interchangeable Behavior**
* **Decoupled Algorithm**
* **Open/Closed Principle**
* **Runtime Flexibility**