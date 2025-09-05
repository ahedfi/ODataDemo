# ODataDemo

![.NET](https://img.shields.io/badge/.NET-9.0-blueviolet?logo=dotnet)
![License](https://img.shields.io/github/license/TNOSC/OtripleS.Api?color=green)


This repository is a **playground project** I created to explore and get hands-on experience with **OData** in .NET.  
It’s not a production-ready app, but a space to learn, test, and experiment with how OData works in practice.

## 🎯 Goals
- Understand how OData integrates with **ASP.NET Core** and **EF Core**  
- Experiment with query options like `$filter`, `$select`, `$expand`, `$orderby`, `$top`, `$skip`, `$count`, and `$compute`  
- See how OData translates client queries into **LINQ expressions** and then into optimized **SQL queries**  
- Try out real scenarios with **Products, Categories, Orders, and OrderLines**  

## 🛠️ Tech Stack
- .NET 9  
- ASP.NET Core OData  
- EF Core  
- SQL Server  

## 📚 Running the Project

To run the project locally:

```bash
git clone https://github.com/ahedfi/ODataDemo.git
cd ODataDemo
dotnet restore
dotnet run
```

Alternatively, you can run the project using Docker Compose:

```bash
git clone https://github.com/ahedfi/ODataDemo.git
cd ODataDemo
docker-compose -f docker-compose.yml -p odata-demo up -d
```
Once the application is running, you can explore and test all available endpoints via Swagger at:
```bash
http://localhost:5000
```

## 📌 Example Queries


```bash
### Get all products
GET http://localhost:5000/api/Products

### Get product by ID
GET http://localhost:5000/api/Products(1)

### Filter products by category
GET http://localhost:5000/api/Products?$filter=CategoryId eq 2

### Select specific fields
GET http://localhost:5000/api/Products?$select=Id,Name,Price

### Expand related entities (OrderLines of a product)
GET http://localhost:5000/api/Products?$expand=OrderLines

### Order by price descending
GET http://localhost:5000/api/Products?$orderby=Price desc

### Combine filter, select, expand
GET http://localhost:5000/api/Products?$filter=Price gt 20&$select=Name,Price&$expand=OrderLines

### Get all orders
GET http://localhost:5000/api/Orders

### Get a specific order by ID
GET http://localhost:5000/api/Orders(1)

### Expand OrderLines with Products
GET http://localhost:5000/api/Orders?$expand=OrderLines($expand=Product)

### Filter orders after Feb 1, 2025
GET http://localhost:5000/api/Orders?$filter=OrderDate gt 2025-02-01

### Select only OrderDate field
GET http://localhost:5000/api/Orders?$select=Id,OrderDate

### Order by OrderDate descending
GET http://localhost:5000/api/Orders?$orderby=OrderDate desc
```

