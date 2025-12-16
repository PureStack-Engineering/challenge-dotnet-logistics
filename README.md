# 📦 PureStack .NET Challenge: Enterprise Logistics, Clean Architecture & LINQ

**PureStack.es - Engineering Validation Protocol.**
> *"We don't just want code that compiles. We want code that scales."*

---

### 📋 Context & Mission
Welcome to the PureStack Technical Validation Protocol for .NET Engineering.
In enterprise logistics, data integrity, efficient querying, and architecture are paramount.

**The Mission:** You are building the core of an **Inventory Microservice**.
Your task is to implement the `InventoryService` to handle products in a high-volume warehouse context. We expect adherence to **SOLID principles** and modern C# features.

### 🚦 Certification Levels (Choose your Difficulty)
This challenge is scalable. Your seniority level will be determined by the architectural depth of your solution. Please state in your Pull Request which level you are aiming for.

#### 🥉 Level 3: Essential / Mid-Level
* **Focus:** Logic & LINQ Proficiency.
* **Requirement:** Implement `InventoryService` to pass the basic unit tests.
* **Tasks:**
    1.  **Add Product:** Validate inputs (Price > 0, Name not empty) and save to DB using EF Core.
    2.  **Get Stock:** Retrieve products using **LINQ**. Implement filtering by 'Category'.
    3.  **Business Logic:** Apply a "Hazardous" flag if the name contains specific keywords (e.g., "Chemical").
* **Deliverable:** Working `InventoryService.cs` that passes all tests (Green Light).

#### 🥈 Level 2: Pro / Senior
* **Focus:** Decoupling & Pattern Usage.
* **Requirement:** Everything in Level 3 + **DTOs & Repository Pattern**.
* **Extra Tasks:**
    1.  **No Leaky Abstractions:** Do NOT return Entity Framework entities (`Product`) directly from the Service. Create and return **DTOs** (Data Transfer Objects).
    2.  **Repository Pattern:** Abstract the EF Core context behind an `IProductRepository`. The Service should not depend directly on `AppDbContext`.
    3.  **Custom Exceptions:** Implement specific domain exceptions (e.g., `ProductNotFoundException`) instead of generic errors.
* **Deliverable:** A Clean Architecture approach where the Domain is protected from the Infrastructure.

#### 🥇 Level 1: Elite / Architect
* **Focus:** Concurrency, Async/Await & Robustness.
* **Requirement:** Everything above + **Optimistic Concurrency & Asynchrony**.
* **Extra Tasks:**
    1.  **Async/Await:** Ensure the entire pipeline (Controller -> Service -> Repo -> DB) is fully asynchronous (`Task<T>`, `await`, `CancellationToken`).
    2.  **Concurrency Control:** Handle **Race Conditions**. Implement **Optimistic Locking** (using a Version/Timestamp field) to prevent two users from updating the stock of the same product simultaneously.
    3.  **Extension Methods:** Create a custom LINQ extension method for complex filtering logic to keep the Service clean.
* **Deliverable:** A high-performance, thread-safe service ready for high-load scenarios.

---

### 🛠️ Tech Stack Requirements
* **Framework:** .NET 8.0 (Core).
* **ORM:** Entity Framework Core (In-Memory Database for testing).
* **Testing:** xUnit + FluentAssertions.
* **Paradigm:** Dependency Injection (DI) is mandatory.

---

### 🚀 Execution Instructions

1.  **Use this template** (Fork the repo).
2.  Restore packages: `dotnet restore`.
3.  Implement your solution in `src/PureStackLogistics/Services/InventoryService.cs` (and create new files for DTOs/Repos if aiming for Level 2/1).
4.  Run tests: `dotnet test`.
5.  Submit via **Pull Request** stating your target Level.

### 🧪 Evaluation Criteria (PureStack Audit)

| Criteria | Weight | Audit Focus |
| :--- | :--- | :--- |
| **Correctness** | 30% | Do tests pass? Is the logic sound? |
| **LINQ Mastery** | 25% | Efficient use of `.Where()`, `.Select()`, and deferred execution. |
| **Architecture** | 30% | Dependency Injection usage. Separation of Concerns (Entities vs DTOs). |
| **Modern C#** | 15% | Usage of Records, Pattern Matching, and Async/Await best practices. |

---

### 🚨 Project Structure (Guideline)
To ensure our **Automated Auditor** works, keep the core solution structure intact:

```text
/
├── .github/
│   └── workflows/
│       └── audit.yml               # Automated CI Pipeline (Runs tests on every Push)
├── src/
│   └── PureStackLogistics/
│       ├── Data/                   # Database Context (EF Core Configuration)
│       ├── Models/                 # Domain Entities (Database Schema / Business Objects)
│       ├── Services/               # Business Logic Layer (The Core Implementation)
│       ├── Program.cs              # Application Entry Point & Dependency Injection Setup
│       └── PureStackLogistics.csproj # Main Project Configuration & Nuget Dependencies
├── tests/
│   └── PureStackLogistics.Tests/
│       ├── InventoryTests.cs       # Unit Tests (xUnit) to validate the Services
│       └── PureStackLogistics.Tests.csproj # Test Project Configuration
├── .gitignore                      # Files to exclude from Git (bin, obj, user prefs)
├── LICENSE                         # Repository License
├── PureStackLogistics.sln          # Solution File (Links Source and Tests together - CRITICAL)
└── README.md                       # Challenge Instructions & Evaluation Criteria
