# BlazorGraphQL: A Blazor App with GraphQL API

## 🚀 Overview

BlazorGraphQL is a Blazor Server application that integrates GraphQL to provide an efficient, flexible API for fetching, adding, updating, and deleting books from a SQLite database. This project demonstrates how GraphQL can serve as an alternative or complement to REST APIs, improving data fetching performance and reducing over-fetching.

## 🔥 Why Use GraphQL?

GraphQL is a query language for APIs that enables clients to request exactly the data they need. Unlike REST, which relies on multiple endpoints, GraphQL exposes a single endpoint that can handle complex queries efficiently.

## Benefits of GraphQL:

## Efficient Data Fetching: Request only the fields you need, reducing unnecessary data transfer.

- Single Endpoint: No need to manage multiple REST routes—GraphQL handles everything from a single endpoint.

- Strongly Typed Schema: Clearly defined types ensure data integrity and improve API documentation.

- Declarative Data Fetching: Clients describe the data they need, and the API responds accordingly.

- Combining REST with GraphQL: Many applications use GraphQL alongside REST, leveraging REST for simple CRUD operations and GraphQL for complex data relationships and efficient querying.

## 🛠️ Tech Stack

- Blazor Server (for the frontend UI)

- GraphQL (via HotChocolate) for the API

- Entity Framework Core (EF Core) with SQLite for data storage

- .NET 9.0 (latest stable release)

## 📌 Features

- GraphQL API with Queries & Mutations

- Blazor UI for Displaying Books

- SQLite Database for Storing Books

## ⚡ Getting Started

- 1️⃣ Clone the Repository

git clone https://github.com/your-username/BlazorGraphQL.git
cd BlazorGraphQL

- 2️⃣ Install Dependencies

dotnet restore

- 3️⃣ Run Database Migrations

Ensure SQLite is set up and apply migrations:

dotnet ef database update

- 4️⃣ Run the Application

dotnet run

## Navigate to http://localhost:5206/ui/playground to explore the GraphQL Playground.

- Sorting and Filtering with GraphQL

- CORS Configured for External API Calls

## 📜 GraphQL API Endpoints

- Query Books

query {
  books {
    id
    title
    author
  }
}

- Add a New Book

mutation {
  addBook(title: "The Pragmatic Programmer", author: "Andy Hunt") {
    id
    title
    author
  }
}
