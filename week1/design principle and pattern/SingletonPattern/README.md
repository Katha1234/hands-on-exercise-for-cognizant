# Exercise 1: Implementing the Singleton Pattern

## 1. Understanding the Singleton Pattern

### What is the Singleton Pattern?
The Singleton Design Pattern is a creational pattern that ensures a class has **only one instance** throughout the entire application lifecycle and provides a single, global point of access to that instance. 

### Why Use a Singleton for Logging?
A logging utility writes system logs to centralized outputs (such as a database or a shared text file). If multiple parts of the application create separate instances of the logger simultaneously, it can lead to file access lockups, duplicated resource allocation, and out-of-order log entries. A Singleton ensures all modules share a single, coordinated access point.

### Structural Blueprint Rules:
1. **Private Constructor:** Prevents external classes from creating duplicate instances using the `new` keyword.
2. **Private Static Field:** Holds the sole initialized reference instance of the class.
3. **Public Static Accessor:** Provides a controlled gateway (`Instance` property) to retrieve the unique instance, handling lazy loading when first accessed.

---

## 2. Implementation Overview

The solution uses modern C# guidelines to build a high-performance, thread-safe Singleton model.

### Advanced Thread-Safety Strategy (`Lazy<T>`)
Instead of using manual lock wrappers (`lock(syncRoot)`), this implementation utilizes C#'s native **`Lazy<Logger>`** wrapper. 
* **Lazy Initialization:** The instance is not generated when the application loads; it initializes only when `Logger.Instance` is called for the first time.
* **Built-in Thread Safety:** `Lazy<T>` automatically protects execution across multi-threaded operations, blocking race conditions without introducing performance lag.

---

## 3. Testing and Verification

To guarantee structural integrity, the `Main` application executes the following verification checks:
1. Requests references through two separate variable allocations (`logger1` and `logger2`).
2. Evaluates internal system memory reference addresses utilizing unique object hashcodes.
3. Confirms identity parity using `ReferenceEquals(logger1, logger2)`.

### Expected Console Output
When executed via `dotnet run`, the program outputs verification confirming a single instance:
```text
--- Starting C# Singleton Pattern Test ---
System Alert: Logger utility instance initialized.
[LOG - 2026-06-20 21:24:15]: User 'Katha1234' logged in successfully.
[LOG - 2026-06-20 21:24:15]: Database entry synchronized securely.

--- Verification Checking ---
Memory Reference Logger 1: 58225482
Memory Reference Logger 2: 58225482

SUCCESS: Both variables point to the identical instance. Singleton pattern works perfectly in C#!