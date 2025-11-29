Title : MiniShop – Clean Architecture .NET Web API (Alpha Version)

🛒 MiniShop is an educational Web API project built to practice Clean Architecture, DDD, CQRS, MediatR, and EF Core.

This alpha version currently includes:

Create Product (Command)

Get Product By Id (Query)

Other features like Update/Delete, Categories, Authentication (JWT), and Domain Events are still in development.

📘 Purpose : 

The goal of MiniShop is to provide a clean, modular, and scalable backend foundation that follows:

Clean Architecture principles

Domain-Driven Design

Clear separation of concerns

Command & Query Responsibility Segregation (CQRS)

Application layer isolation via MediatR

EF Core with proper persistence patterns

🧱 Tech Stack

Layer : 	Technologies
API : 	ASP.NET Core 8, Swagger
Application : 	MediatR, CQRS, FluentValidation
Domain : 	Entities, Value Objects, Aggregates
Infrastructure : 	EF Core, SQL Server

🔗 Dependency Rule

Domain  →  Application  →  Infrastructure  →  Api

▶️ How to Run

1) Clone the repository

``` git clone https://github.com/<your-username>/MiniShop.git
cd MiniShop/src ```

2) Apply EF Core migrations

``` dotnet ef database update \
    --project MiniShop.Infrastructure \
    --startup-project MiniShop.Api
 ```
3) Run the API

``` dotnet run --project MiniShop.Api
 ```

⛅ Roadmap (Next Steps)

 Add Category Aggregate

 Update / Delete product

 Get all products

 FluentValidation rules

 JWT Authentication

 Authorization & roles

 Domain Events

 Unit Tests
