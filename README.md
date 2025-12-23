# 📦 PureStack .NET Challenge: Enterprise Logistics

**PureStack.es - Engineering Validation Protocol.**
> *"We don't just want code that compiles. We want code that scales."*

> [!TIP]
> **HOW TO START THIS CHALLENGE**
> 1. Click the green **"Use this template"** button (top right) -> **"Create a new repository"**.
> 2. Select **"Private"** visibility (Crucial to prevent spoilers).
> 3. Clone your new private repository to your machine.
> 4. Once finished, invite user **[JLMoraCastilla](https://github.com/JLMoraCastilla)** as a collaborator to review.
>
> ⚠️ **DO NOT FORK** this repository directly, as it will force your solution to be public.

---

### 📋 Context & Mission
Welcome to the PureStack Technical Validation Protocol for .NET Engineering.

**The Scenario:** You are building the core of an **Inventory Microservice** for a high-volume warehouse. The basic structure is set up, but the logic is missing.
**The Mission:** Implement the `InventoryService` class to handle product creation and retrieval, adhering to **SOLID principles**.

### 🚦 Certification Levels (Choose your Difficulty)
State your target level in your Pull Request (or commit message).

#### 🥉 Level 3: Essential / Mid-Level
* **Focus:** Logic, LINQ & EF Core.
* **Requirement:** Pass the provided Unit Tests (`dotnet test`).
* **Tasks:**
    1.  **Implement `AddProduct`:**
        * Must validate inputs (Price > 0, Name not empty).
        * Must save to the In-Memory Database.
    2.  **Implement `GetStock`:**
        * Retrieve products using **LINQ**.
        * If `category` filter is provided, apply it.
    3.  **Business Logic:** Automatically set the `IsHazardous` flag to `true` if the product name contains "Chemical" or "Acid".
* **Deliverable:** A functional service. The tests must pass (Green Light).

#### 🥈 Level 2: Pro / Senior
* **Focus:** Clean Architecture & Pattern Usage.
* **Requirement:** Everything in Level 3 + **Repository Pattern**.
* **Extra Tasks:**
    1.  **Decoupling:** Refactor the service so it does NOT depend on `AppDbContext` directly. Create an `IProductRepository`.
    2.  **DTOs:** The service should return `ProductDto` objects, not the raw Entity.
    3.  **Dependency Injection:** Remember to register your new Repository in `Program.cs`.
* **Deliverable:** A decoupled architecture where the Domain is protected from Infrastructure.

#### 🥇 Level 1: Elite / Architect
* **Focus:** Concurrency & Async/Await.
* **Requirement:** Everything above + **Thread Safety**.
* **Extra Tasks:**
    1.  **Async All The Way:** Refactor all methods to use `Task<T>`, `await`, and `SaveChangesAsync`.
    2.  **Concurrency Control:** Handle **Race Conditions**. Implement logic to prevent two users from modifying the same stock simultaneously (Optimistic Locking).
* **Deliverable:** A high-performance, thread-safe service.

---

### 🛠️ Tech Stack & Constraints
* **Framework:** .NET 8.0 (Core).
* **Data:** Entity Framework Core (configured with In-Memory Provider).
* **Testing:** xUnit + FluentAssertions.
* **Contract:** You MUST implement the `IInventoryService` interface methods as defined.

---

### 🚀 Execution Instructions

1.  **Use the Template:** Create your **Private Repository** using the instructions at the top of this file.
2.  Restore dependencies:
    ```bash
    dotnet restore
    ```
3.  **Implement your solution** in `src/PureStackLogistics/Services/InventoryService.cs`.
4.  Run the validation suite:
    ```bash
    dotnet test
    ```
5.  **Submit:** Push your changes to your private repo and invite the reviewer.

> **Note:** You will see a ❌ (**Red Cross**) initially because the methods throw `NotImplementedException`. Your goal is to turn it ✅ (**Green**).

---

### 📝 Audit & Validation Rules (Strict)

Our automated auditor (`audit.yml`) enforces the following rules. Please check this before pushing your code to avoid immediate rejection:

1.  **Anti-Pattern Ban:** The auditor scans for synchronous blocking calls.
    * ❌ **Forbidden:** `.Result`, `.Wait()`, `Thread.Sleep()`.
    * ✅ **Required:** Use `await`, `Task.Delay()`.
2.  **Structure Integrity:** Do not rename or move `InventoryService.cs` or the Test project.
3.  **Tests:** You must pass the provided Unit Tests. You may add new tests, but **do not modify or delete** the existing validation logic.

---

### 🧪 Evaluation Criteria (PureStack Audit)

> **How we grade:** The **Automated Auditor** validates correctness (Pass/Fail). If you pass the automated gate, a **PureStack Engineer** will review your code for Architecture and Style (Levels 2 & 1).

| Criteria | Weight | Audit Focus |
| :--- | :--- | :--- |
| **Correctness** | 30% | Do tests pass? Is the logic sound? (Automated) |
| **LINQ Mastery** | 25% | Efficient use of `.Where()`, `.Select()` vs `.ToList()` (Materialization). |
| **Architecture** | 30% | Proper use of Dependency Injection and Separation of Concerns. |
| **Code Style** | 15% | Naming conventions, null checks, and exception handling. |

---

### 🚨 Project Structure
To ensure our Automated Auditor works, keep the base structure.
*(Note: If attempting Level 2, you are encouraged to add new folders like `/Repositories` or `/DTOs`)*.

```text
/
├── .github/workflows/              # PureStack Audit System
├── src/
│   └── PureStackLogistics/
│       ├── Data/                   # DbContext
│       ├── Models/                 # Entities (Product.cs)
│       ├── Services/
│       │   └── InventoryService.cs # <--- YOUR CODE HERE
│       └── Program.cs              # DI Configuration
├── tests/
│   └── PureStackLogistics.Tests/   # xUnit Tests
├── PureStackLogistics.sln          # Solution File
└── README.md
```
---
## ⚖️ License & Legal Notice

**© 2025 PureStack.es. All Rights Reserved.**

This repository is "Source Available" for **evaluation purposes only**.

* **Public viewing:** Allowed.
* **Commercial use:** ❌ Strictly Prohibited.
* **Redistribution:** ❌ Strictly Prohibited.

By accessing this material, you agree to the terms in `LICENSE.md`.

> **🚫 Publishing solutions to public repositories is a violation of these terms.**
