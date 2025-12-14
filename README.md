# 📦 PureStack .NET Challenge: Enterprise Logistics, Clean Architecture &amp; LINQ.

PureStack.es - Engineering. Validated by Code.

### Context
Welcome to the **PureStack Technical Validation Protocol** for .NET Engineering.
In enterprise logistics, data integrity and efficient querying are paramount. We don't just want code that works; we want code that scales and follows **SOLID principles**.

**⚠️ The Standard:** Use **Dependency Injection**, **Entity Framework Core**, and **LINQ**.

---

### 🎯 The Objective
You are building the Inventory Microservice.
Your mission is to implement the `InventoryService` to handle products in a warehouse.

1.  **The Stack:** .NET 8, EF Core (In-Memory), xUnit.
2.  **The Features:**
    * **Add Product:** Validate inputs (Price > 0) and save to DB.
    * **Get Stock:** Retrieve products filtering by Category (optional) and perform a stock check.
    * **Business Logic:** If a product name contains "Hazardous", it requires a special flag.

### 🛠️ Tech Stack Requirements
* **Framework:** .NET 8.0 (Core).
* **ORM:** Entity Framework Core (In-Memory Database).
* **Testing:** xUnit + FluentAssertions (optional).

## 🧪 Evaluation Criteria (How we Audit You)

We will run `dotnet test`. We look for:

* **Green Lights:** All unit tests **must** pass.
* **LINQ Usage:** Did you use `.Where()` and `.Select()` efficiently?
* **DI Registration:** Did you register your Service in `Program.cs` correctly?

---

## 🚀 Getting Started

1.  Use this **template**.
2.  Restore packages: `dotnet restore`.
3.  Implement `src/PureStackLogistics/Services/InventoryService.cs`.
4.  Run tests: `dotnet test`.
5.  Submit via **Pull Request**.

---

### 🚨 CRITICAL: Project Structure
To ensure our **Automated Auditor** works, keep this solution structure:

```text
src/
└── PureStackLogistics/
    ├── Data/
    │   └── AppDbContext.cs   <-- (El código de arriba)
    ├── Models/
    │   └── Product.cs        <-- (El código de arriba)
    ├── Services/
    │   └── InventoryService.cs
    ├── Controllers/          (Puede estar vacío)
    ├── Program.cs
    └── PureStackLogistics.csproj
