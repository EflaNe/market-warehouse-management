# Entity Framework Product Management (WinForms)

A simple C# Windows Forms application that uses **Entity Framework 6** to manage products in a SQL database with full **CRUD** operations and search.

> This project is based on a classic “Products” table example and is mainly for learning and practicing **Entity Framework + WinForms**.

---

## 📌 Overview

The application allows you to:

- List all products in a grid
- Add new products
- Update existing products
- Delete products
- Get a product by Id
- Search products by name as you type

All data access logic is implemented using **Entity Framework 6** with a `DbContext` and a simple repository-style `ProductDal` class.

---

## 🧱 Tech Stack

- **Language:** C#
- **Framework:** .NET Framework (Windows Forms)
- **ORM:** Entity Framework 6 (Code First / DbContext)
- **Database:** SQL Server / LocalDB (configurable via `App.config`)

---

## 🗂 Project Structure

```text
EntityFrameworkDemo/
  App.config              # Connection string for Entity Framework / SQL Server
  ETradeContext.cs        # DbContext with DbSet<Product>
  Product.cs              # Product entity (Id, Name, UnitPrice, StockAmount)
  ProductDal.cs           # Data access layer (CRUD + query methods)
  Form1.cs                # Form logic (event handlers, calls to ProductDal)
  Form1.Designer.cs       # WinForms designer code
  Form1.resx              # Form resources
  Program.cs              # Application entry point
