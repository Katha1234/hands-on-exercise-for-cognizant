# Exercise 7: Financial Forecasting

## 1. Understanding Recursion in Financial Models

### What is Recursion?
Recursion is a programming technique where a method calls itself to solve a larger problem by breaking it down into smaller, manageable sub-problems. Every recursive function requires two essential components:
1. **Base Case:** A strict terminating condition that stops the function from calling itself, preventing infinite loops.
2. **Recursive Case:** The logical step where the function modifies the input data and calls itself again, moving closer to the base case.

### Applying Recursion to Financial Forecasting
Predicting asset values, compounding interest, or modeling population growth over time are inherently sequential processes. The financial health of an investment in Year $N$ depends entirely on the value generated in Year $N-1$. 

Instead of writing complex nested loops, recursion allows us to cleanly calculate future predictions by calculating one fiscal period at a time until the target forecasting window is met.

---

## 2. Implementation Overview

The solution utilizes a recursive algorithm written in C# to calculate the future value of a financial asset subjected to a fixed annual growth rate.

### Algorithmic Mechanics
* **The Base Case:** Checked at the beginning of the execution loop. If the remaining forecast period drops to `0` years, the function stops processing and immediately returns the current accumulated value.
* **The Recursive Case:** If years remain in the forecast, the system calculates the asset's growth for the current period (`currentValue * (1 + growthRate)`) and passes that updated value into a new call of `CalculateFutureValue()`, reducing the remaining years by `1`.

---

## 3. Complexity Analysis

### Time Complexity: $O(n)$
The time complexity scales linearly with the number of periods ($n$) being forecasted. If you predict the future value of an asset for **5 years**, the computer creates a stack of **5 recursive method calls**. If you forecast for **50 years**, it executes **50 operations**.

### Space Complexity: $O(n)$
Unlike a standard `for` loop which uses constant memory ($O(1)$), each recursive call adds a new layer to the system's execution stack memory. Forecasting long-term values requires linear stack space proportional to the number of target periods.

---

## 4. Optimization Strategies

While recursion yields clean, readable mathematical code, calculating thousands of periods can trigger a critical memory failure known as a **StackOverflowException** (running out of system call stack memory). 

To optimize this algorithm for large-scale enterprise financial simulations, we can apply two main strategies:

### A. Tail Call Optimization (TCO)
Tail recursion occurs when the recursive call is the absolute final operation executed inside the method. By structuring the code so no calculations happen *after* the method calls itself, modern compilers can optimize the call stack, recycling the same memory frame and dropping the space complexity from $O(n)$ down to a highly efficient $O(1)$.

### B. Conversion to Iteration (Loops)
If the forecasting horizon spans thousands of monthly or daily intervals, converting the recursive design into an iterative loop (`while` or `for`) guarantees absolute system stability. Loops run purely on the processor without allocating stack memory frames, maximizing processing speed and eliminating the risk of system crashes entirely.