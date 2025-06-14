<p align="center">
  <img src="wwwroot/images/bookend-logo.png" alt="BlazorGraphQL Logo" width="120" />
</p>

# 📚 BlazorGraphQL Book Catalog

A Blazor Server app that explores the idea of a **Library** and **Anti-Library** — inspired by Nassim Taleb's concept that unread books hold more potential than read ones.

This project uses a **GraphQL API** with **EF Core + SQLite** to store and manage a personal catalog of books, along with reading progress and reflections. It demonstrates full-stack Blazor development with a strong architectural foundation.

---

## 🚀 Overview

BlazorGraphQL integrates **GraphQL** using HotChocolate, providing an efficient and flexible API for fetching, adding, and deleting books. It complements REST with a single declarative endpoint for structured queries.

### 🔥 Why GraphQL?

- **Efficient Data Fetching** – Only request the fields you need  
- **Single Endpoint** – Handles queries & mutations in one place  
- **Strongly Typed Schema** – Ensures clarity and safety  
- **Flexible Filtering & Sorting** – Integrated into query structure  
- **Declarative Requests** – Clients ask for the shape of data they want

---

## 🛠️ Tech Stack

- **Blazor Server** – Frontend SPA framework using .NET  
- **GraphQL with HotChocolate** – Type-safe API backend  
- **EF Core + SQLite** – Lightweight persistent storage  
- **Bootstrap** – UI styling  
- **.NET 9.0**

---

## 📌 Features

- 🔍 GraphQL Queries & Mutations  
- ✨ Clean Blazor UI for viewing and adding books  
- 🧠 “Library” and “Anti-Library” perspective  
- 💾 SQLite data persistence  
- 🔐 Future plans: Auth, tagging, user-specific views

---

## ⚡ Getting Started

### 1️⃣ Clone the Repo

```bash
git clone https://github.com/your-username/BlazorGraphQL.git
cd BlazorGraphQL

### 2️⃣ Restore Dependencies

```bash
dotnet restore

### 3️⃣ Run Migrations

```bash
dotnet ef database update

### 4️⃣ Run the App

```bash
dotnet run

### 📜 Sample GraphQL Queries

#### 📚 Fetch Books

query {
  books {
    id
    title
    author
    category
    status
    progress
  }
}

#### ➕ Add a New Book

mutation {
  addBook(
    title: "The Pragmatic Programmer",
    author: "Andy Hunt",
    genre: "Tech",
    category: "Programming",
    status: "Wishlist",
    progress: 0.2,
    yearPublished: 1999,
    reflectionNotes: "Looking forward to this one!"
  ) {
    id
    title
  }
}


## 📖 About the Creator

Built by Joel Southall — software developer & philosophy graduate. This project draws on themes of lifelong learning, digital literacy, and classical aesthetics.
