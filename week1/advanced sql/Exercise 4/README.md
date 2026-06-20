# Employee Management System - Stored Procedures

## 1. Core Mechanics of Stored Procedures

A **Stored Procedure** is a prepared collection of SQL statements compiled and saved directly on the database server. Instead of client applications writing raw queries over the network repeatedly, they simply call the procedure by name.

### Benefits of Stored Procedures:
* **Performance Optimization:** Procedures are compiled once and cached by the database server. Subsequent executions bypass syntax checking and query planning, leading to faster execution times.
* **Network Traffic Reduction:** Applications only need to send small execution statement commands (e.g., `EXEC sp_GetEmployeesByDepartment @DepartmentID = 3`) rather than transmitting large multiline string blocks over the network.
* **Security & Parameterization:** By restricting direct table access and routing inputs through defined parameters, stored procedures natively mitigate **SQL Injection vulnerabilities**.

---

## 2. Implementation Overview

The solution implements two distinct enterprise-level stored routines:

1. **`sp_GetEmployeesByDepartment`**: Filters the central `Employees` transactional data space using a target input parameter `@DepartmentID` to cleanly separate workforce data by business unit.
2. **`sp_InsertEmployee`**: Handles transactional creation logic by receiving all entity inputs safely as strongly typed variables and committing them cleanly into the underlying tables.