# Factory Method Pattern – Document Editor Example

This example demonstrates the **Factory Method Design Pattern** using a document editor that supports creating different types of documents (Word and Excel).

---

## Purpose

The Factory Method Pattern allows us to:

- Encapsulate object creation logic.
- Hide concrete types from the client.
- Follow the **Open/Closed Principle** by allowing new types without modifying existing logic.
- Use a **common interface (`IDocument`)** to ensure consistency across object behavior.

---

## Real-World Analogy

Imagine a document editor app (like Microsoft Office). Users can choose whether to create a **Word** or an **Excel** document.  
The application shouldn't directly instantiate `WordDocument` or `ExcelDocument`. Instead, it delegates that responsibility to a **DocumentFactory**.

---

## Benefits

- Cleaner and testable code.
- Easy to add support for new document types (e.g., `PdfDocument`).
- Prevents misuse of constructors.
- Centralized control of object creation.

---

## Code Structure

### `IDocument` Interface

```csharp
interface IDocument
{
    void Write();
}
