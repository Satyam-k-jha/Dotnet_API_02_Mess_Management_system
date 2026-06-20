🍽️ Mess Management System API

A RESTful backend API built using ASP.NET Core 8 and Entity Framework Core for managing a college mess system. The project demonstrates backend development fundamentals, including CRUD operations, Entity Framework Core Code-First development, DTOs, AutoMapper, Repository Pattern, and relational database design.

«Project Status: 🚧 Under Development»

---

📌 Features

👨‍🎓 Student Management

- Create Student
- Retrieve Student Details
- Update Student Information
- Delete Student

📅 Attendance Management

- Mark Student Attendance
- Retrieve Attendance Records
- Update Attendance
- Delete Attendance

🍛 Food Management

- Add Food Items
- View Food List
- Update Food Details
- Delete Food Items

📋 Menu Management

- Create Daily Menu
- View Menu
- Update Menu
- Delete Menu

---

🛠️ Tech Stack

- ASP.NET Core 8 Web API
- C#
- Entity Framework Core
- SQL Server
- AutoMapper
- Repository Pattern
- Swagger / OpenAPI

---

🏗️ Architecture

Client
   │
   ▼
Controllers
   │
   ▼
Repositories
   │
   ▼
Entity Framework Core
   │
   ▼
SQL Server

---

📁 Project Structure

MessManagementSystem
│
├── Controllers
├── Data
├── Mappings
├── Migrations
├── Models
│   ├── Domain
│   └── DTO
├── Repositories
│   ├── Interface
│   └── Implementation
├── Properties
├── appsettings.json
├── Program.cs
└── README.md

---

🗄️ Database Design

Student

Property| Description
Id| Primary Key
Name| Student Name
Email| Student Email
RollNumber| Unique Roll Number

Relationship

- One Student can have multiple Attendance records.

---

Attendance

Property| Description
Id| Primary Key
StudentId| Foreign Key
Date| Attendance Date

Relationship

- Each Attendance belongs to one Student.

---

Food

Property| Description
Id| Primary Key
Name| Food Name
Description| Food Description

---

Menu

Property| Description
Id| Primary Key
Date| Menu Date

---

🚀 API Endpoints

Student APIs

Method| Endpoint
GET| "/api/student"
GET| "/api/student/{id}"
POST| "/api/student"
PUT| "/api/student/{id}"
DELETE| "/api/student/{id}"

---

Attendance APIs

Method| Endpoint
GET| "/api/attendance"
GET| "/api/attendance/{id}"
POST| "/api/attendance"
PUT| "/api/attendance/{id}"
DELETE| "/api/attendance/{id}"

---

Food APIs

Method| Endpoint
GET| "/api/food"
GET| "/api/food/{id}"
POST| "/api/food"
PUT| "/api/food/{id}"
DELETE| "/api/food/{id}"

---

Menu APIs

Method| Endpoint
GET| "/api/menu"
GET| "/api/menu/{id}"
POST| "/api/menu"
PUT| "/api/menu/{id}"
DELETE| "/api/menu/{id}"

---

💡 Concepts Implemented

- RESTful API Development
- CRUD Operations
- Entity Framework Core
- Code-First Development
- SQL Server Integration
- Database Migrations
- Dependency Injection
- Repository Pattern
- DTO (Data Transfer Objects)
- AutoMapper
- Foreign Keys
- Navigation Properties
- One-to-Many Relationships
- Eager Loading using "Include()"
- Swagger API Documentation

---

▶️ Getting Started

Clone the Repository

git clone https://github.com/your-username/MessManagementSystem.git

Navigate to the Project

cd MessManagementSystem

Configure Database

Update the SQL Server connection string inside:

appsettings.json

Apply Migrations

dotnet ef database update

Run the Application

dotnet run

Open Swagger in your browser:

https://localhost:<port>/swagger

---

📚 What I Learned

While building this project, I gained hands-on experience with:

- Designing REST APIs using ASP.NET Core
- Entity Framework Core Code-First Approach
- SQL Server Integration
- Creating and Applying Migrations
- Repository Pattern
- DTOs and AutoMapper
- Dependency Injection
- Foreign Key Relationships
- Navigation Properties
- Eager Loading using Include()
- Building maintainable backend applications

---

🔄 Future Improvements

- Service Layer
- JWT Authentication & Authorization
- Global Exception Handling Middleware
- Logging using ILogger
- Pagination
- Filtering
- Sorting
- FluentValidation
- Unit Testing
- Angular Frontend
- Docker Support
- Azure Deployment

---

👨‍💻 Author

Satyam Kumar Jha

Software Engineer | Backend Developer

Skills: C# • ASP.NET Core • Entity Framework Core • SQL Server • REST APIs
