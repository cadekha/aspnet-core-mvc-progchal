# ASP.NET Core MVC ProgChal

This repository contains a C# application with a RESTful API. 
* The project is an **ASP.NET Core MVC Website** using **.NET 9.0**.
* It connects to an **Azure Microsoft SQL Server** for the back-end database.
* All database operations are to be performed using **Entity Framework Core**, Microsoft's ORM.
* The application itself models a very simple Customers and Accounts relation for a banking application.

---

##  Core Features

*   **MVC Pattern:** Usage of Model-View-Controller pattern for the website - a core requirement of this project was to demonstrate how MVC architecture is used to separate different types of code by logic.
*   **Code-First Models:** Models are created in C# that represent the database schema. These Models also contain Data Annotations to meet the requirements for data validation.
*   **Migrations:** The project contains database migrations, which create the required database schema in the SQL Server (only if the database schema is not already present). This allows the program to seed the database from scratch. Default data is also seeded into the database through this process. 
*   **ASP.NET Core Web API:** A Web API was created for this project (see: Api folder). 

##  Built With

*   **Frontend:** ASP.NET Core MVC, HTML
*   **Backend:** .NET 9.0, ASP.NET Core Web API, Entity Framework Core (EF Core)
*   **DevOps/Tools:** Git, GitHub, Visual Studio 

## How To Run
- Clone repository to local machine
- Using Command Prompt, navigate to aspnet-core-mvc-progchal\Assignment3\Assignment3
- Run command `dotnet run` 
