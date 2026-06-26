# 📚 BlazorGraphQL Book Catalog & Anti-Library Dashboard

A **Blazor Server** application designed around Nassim Taleb's philosophical concept of the **Anti-Library**—the idea that a collection of unread books holds far more intellectual potential, curiosity, and humility than those we have already consumed. 

This project couples a responsive frontend with a type-safe **GraphQL API backend** powered by **HotChocolate**, using **Entity Framework Core** and a **SQLite** database to seamlessly manage, filter, and track a personal catalog of volumes, reading metrics, and reflection entries.

---
## Why This Project?


This project began as a way to track my own reading, but it also became a vehicle for exploring modern .NET application architecture. As the feature set grew, I intentionally refactored the codebase to introduce clearer boundaries, stronger validation, automated tests, and a more maintainable design.

---

## 🏗️ Multi-Project Architecture Overview

The solution adheres to a **Clean Architecture / Domain-Driven Design (DDD)-lite** blueprint, split into an independent core application layer and a isolated, high-coverage automated testing tier.

```text
📁 BlazorGraphQL (Root Solution)
│
├── 📁 Domain                 # Enterprise core rules, pure business logic, and entity definitions
│   └── 📁 Entities           # Book.cs (Contains NotMapped UI helpers like ProgressDisplay)
│
├── 📁 Application            # Application-specific business rules and orchestration orchestration
│   └── 📁 Services           # BookService.cs (Handles asynchronous CRUD operations)
│
├── 📁 Infrastructure         # Data access mapping, persistence mechanisms, and local storage
│   └── 📁 Data               # AppDbContext.cs (EF Core infrastructure context wired to SQLite)
│
├── 📁 GraphQL                # Declarative API exposure tier decoupled from standard HTTP controllers
│   ├── 📁 Models             # Data Transfer Objects (AddBookInput, UpdateBookInput records)
│   ├── 📁 Mutations          # BookMutation.cs (Handles DTO conversions and validation triggers)
│   ├── 📁 Queries            # BookQuery.cs (High-efficiency flat primitive IQueryable exposure points)
│   └── 📁 Validators         # BookInputValidators.cs (FluentValidation rules engine)
│
├── 📁 Pages & Shared         # Frontend Single-Page App (SPA) UI components written in Blazor Server
│   ├── FetchBooks.razor      # Reactive form entry grid with bidirectional data bindings (@bind)
│   └── NavMenu.razor         # Layout navigation component
│
└── 📁 BlazorGraphQL.Tests    # Isolated Automated xUnit Testing Suite
    └── BookInputValidationTests.cs  # Data contract, field constraint, and timeline validation rules

    ⚡ Tech Stack & Ecosystem Matrix

    Frontend Interface: Blazor Server (.NET 9.0) with Bootstrap styling.

    API Framework: GraphQL Engine using HotChocolate v14.2+ (pure, attribute-free parameter context injection).

    Validation Engine: FluentValidation v12.1.1 (Decoupled payload sanitation).

    Object-Relational Mapper: Entity Framework Core 9.0.4.

    Database Engine: SQLite (Lightweight, local file-isolated thread tracking).

    Testing Framework: xUnit v2.9.2 paired with FluentAssertions v6.12.2.

🔧 Core Engineering Implementations
1. Robust Type-Safe Input Sanitation (DTO Layer)

    Decoupling: Swapped out direct entity binding inside frontend views. Introduced explicit AddBookInput and UpdateBookInput record contracts to prevent structural database details from leaking directly into client components.

    Fluent Validation: Built a strict validation matrix (AddBookInputValidator) to evaluate field constraints on the API gateway before executing data commands. This catches invalid data, title lengths, and impossible publication timelines (e.g., dates in the future) and throws clean errors back to the caller.

2. Thread-Safe HotChocolate v14 Pipeline

    Purged all deprecated HotChocolate thread attributes ([UseDbContext], [ScopedService]). Context scopes are now injected cleanly as raw method signatures (AppDbContext context), enabling HotChocolate to handle underlying asynchronous task sequencing implicitly.

    Eliminated redundant .Include() relational eager-loading calls inside BookQuery.cs to solve runtime tracking crashes. The model tracks parameters (Author, Category) as flat, optimized internal table primitives rather than secondary joined relational graphs.

3. Isolated Automated Test Workspace

    Constructed a standalone testing project assembly (BlazorGraphQL.Tests) configured to prevent structural duplicate assembly attribute overlaps (error CS0579) within the main application via tailored directory compilation exclusions.

    Implemented comprehensive data verification checks (BookInputValidationTests) utilizing expressive fluent extension syntax patterns to verify validation rules and boundary conditions, required fields, and data mismatches.

🚀 Getting Started
📋 Prerequisites

Ensure you have the native .NET 9 SDK installed on your developer workspace machine.
1️⃣ Restore and Compile the Target Solution

From the repository root path directory, clear out local build caches and execute a full compilation pass to verify all dependencies cross-reference perfectly:
Bash

dotnet clean
dotnet restore
dotnet build

2️⃣ Run the Automated Test Suite

Ensure the code sanitation rules engine and business constraints pass validation across all testing boundaries:
Bash

dotnet test

3️⃣ Launch the Development Engine

Launch the web server pipeline locally:
Bash

dotnet run

Open your browser window and navigate to the endpoint address logged in your terminal console (e.g., http://localhost:5206/books) to manage your reading horizons.


---

### 💾 Step 2: Push the Updated README to GitHub

Now let's stage and push just this file so your GitHub page is completely up to date. Run these commands in your PowerShell console:

```bash
# 1. Stage the populated file
git add README.md

# 2. Commit the documentation update
git commit -m "docs: repopulate README with complete multi-project architecture and validation pipelines"

# 3. Push live to GitHub
git push origin main
