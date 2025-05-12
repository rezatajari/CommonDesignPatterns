# Singleton Design Pattern

## Core Concept of Singleton
The Singleton pattern ensures:
- A class has only one instance throughout the application
- Provides global access to that single instance
- Controls shared resources effectively

## PrinterSpooler as a Singleton
Our PrinterSpooler demonstrates these key Singleton characteristics:

### 1. Controlled Instance Creation
- The constructor is private, preventing external instantiation
- Instance creation is managed internally by the class itself

### 2. Thread-Safe Access
- Uses lazy initialization to create the instance only when first needed
- The Lazy<T> wrapper ensures thread safety during creation

### 3. Global Access Point
- Provides a static Instance property as the single access point
- All code interacts with the same instance through this property

### 4. Centralized Resource Management
- Maintains an internal queue of print jobs
- Exposes controlled methods for adding and processing jobs

## Practical Implications
- Ensures all print jobs go through a single spooler
- Prevents conflicting print requests from different parts of the system
- Maintains consistent state of the print queue

## When to Use This Pattern
- When exactly one instance of a class is needed
- When that instance needs global access
- When you need to control shared resources (like a printer)

## Considerations
- Be mindful of thread safety for the internal job queue
- Consider testability implications
- Evaluate whether dependency injection might be a better approach for my specific use case

This implementation shows how Singleton provides controlled access to a shared resource while maintaining a simple and clean interface for clients.