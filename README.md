# BlazorGraphQL Book Catalog & Anti-Library

A .NET 9 Blazor Server application for managing a personal book catalog and “anti-library” — the books already read, currently being read, and still waiting to be explored.

The project is designed as a practical .NET portfolio piece demonstrating Blazor Server, GraphQL with Hot Chocolate, Entity Framework Core, SQLite persistence, layered architecture, and full CRUD workflows.

## Features

* Add books with title, author, category, status, year, progress, and reflection notes
* View books in a responsive card-based Blazor UI
* Update reading status and progress inline
* Delete books with confirmation
* Track reading progress as normalized values stored in the database and displayed as percentages
* Query and mutate book data through a GraphQL API
* Persist data locally with EF Core and SQLite

## Tech Stack

* .NET 9
* Blazor Server
* Hot Chocolate GraphQL
* Entity Framework Core 9
* SQLite
* Bootstrap / BootstrapBlazor
* C#

## Architecture

The project uses a layered structure inspired by Clean Architecture principles:

```text
BlazorGraphQL/
├── Domain/
│   └── Entities/
│       ├── Book.cs
│       ├── Author.cs
│       ├── Category.cs
│       └── Loan.cs
│
├── Application/
│   └── Services/
│       └── BookService.cs
│
├── Infrastructure/
│   └── Data/
│       └── AppDbContext.cs
│
├── GraphQL/
│   ├── Queries/
│   │   └── BookQuery.cs
│   └── Mutations/
│       └── BookMutation.cs
│
├── Pages/
│   └── FetchBooks.razor
│
└── Shared/
```

The current data flow is:

```text
Blazor UI → GraphQL Query/Mutation → BookService → AppDbContext → SQLite
```

## Project Goals

This project began as a personal library tracker, but it also explores Nassim Nicholas Taleb’s idea of the anti-library: unread books as a visible reminder of future learning.

From a technical perspective, the goal is to demonstrate that a small application can still be structured professionally, with clear boundaries between UI, API, application logic, domain entities, and persistence.

## Current Status

The app currently supports full CRUD operations for books:

* Create books
* Read book records
* Update status and reading progress inline
* Delete books with confirmation

The project has also been refactored from a flatter early structure into a more maintainable layered layout.

## Getting Started

### Prerequisites

Install the .NET 9 SDK.

You may also need the EF Core CLI tools:

```bash
dotnet tool install --global dotnet-ef
```

### Restore dependencies

```bash
dotnet restore
```

### Build the project

```bash
dotnet build
```

### Apply database migrations

```bash
dotnet ef database update
```

### Run the app

```bash
dotnet run
```

Then open the local URL shown in the terminal. The books page is usually available at:

```text
http://localhost:5206/books
```

The GraphQL endpoint is available at:

```text
http://localhost:5206/graphql
```

## Development Notes

Local development artifacts such as `.vs/`, `bin/`, `obj/`, and `books.db` should not be committed.

If Git tries to stage generated files, use targeted staging:

```bash
git add Application/
git add Domain/
git add Infrastructure/
git add GraphQL/
git add Pages/
git add Shared/
git add Program.cs
git add BlazorGraphQL.csproj
git add README.md
```

## Roadmap

Possible next improvements:

* Add filtering by reading status
* Add dashboard metrics for read vs unread books
* Normalize authors and categories into richer relational entities
* Add import support for CSV or JSON book data
* Add tests for `BookService`
* Deploy a live demo
* Extend `Loan.cs` into a lending workflow

## Portfolio Value

This project demonstrates:

* Building a full-stack .NET application
* Working with Blazor Server and event-bound UI state
* Creating GraphQL queries and mutations with Hot Chocolate
* Using EF Core with SQLite
* Refactoring toward layered architecture
* Debugging package, DI, UI-binding, and data consistency issues
