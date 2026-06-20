# Exercise 1: Ranking and Window Functions

## 1. Core Mechanics of SQL Window Functions

Window functions perform calculations across a set of table rows that are related to the current row. Unlike aggregate functions (`SUM`, `AVG`), window functions do not group rows into a single output row; each row retains its unique identity.

* **`PARTITION BY`**: Divides the query result set into partitions (e.g., grouping by `Category`). The ranking resets to 1 for every new category encountered.
* **`ORDER BY DESC`**: Sorts the items within each partition from highest price to lowest price before applying the rank numbers.

---

## 2. Comparing Ranking Functions (How Ties are Handled)

When multiple products have identical prices, different window functions calculate the position metrics differently:

| Function | Mechanics & Behavior | Example Sequence (with a Tie for 1st) |
| :--- | :--- | :--- |
| **`ROW_NUMBER()`** | Assigns a completely unique, sequential integer to every row. It breaks ties arbitrarily based on processing order. | 1, 2, 3, 4 |
| **`RANK()`** | Assigns identical rank numbers to items that tie. However, it **skips** subsequent ranks to account for the duplicate spaces. | 1, 1, 3, 4 |
| **`DENSE_RANK()`** | Assigns identical rank numbers to items that tie, but leaves **no gaps** in the sequential numbers. The next position number increments by exactly 1. | 1, 1, 2, 3 |

---

## 3. Execution Summary

By wrapping our window ranking calculations inside a Common Table Expression (CTE) named `RankedProducts`, the system efficiently indexes and queries the metrics. Filtering by `WHERE DenseRankNum <= 3` guarantees that a true operational list of the top 3 most expensive product brackets per category is successfully returned, preserving visibility for tied items.