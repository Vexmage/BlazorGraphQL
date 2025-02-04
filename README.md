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

- Sorting and Filtering with GraphQL

- CORS Configured for External API Calls
