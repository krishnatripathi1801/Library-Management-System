# 📚 Library Management System

A modern **Library Management System** built using **ASP.NET Core MVC (.NET 8)** and **Microsoft SQL Server**. The application automates library operations such as managing books, newspapers, magazines, students, librarians, and book borrowing/returning.

---

## 🚀 Features

### 🔐 Authentication
- Login system
- Session-based authentication
- Admin, Student and Librarian roles
- Logout functionality

### 📖 Book Management
- Add new books
- Edit book details
- Delete books
- Search books
- Pagination
- Availability status

### 📰 Publications Management
- Newspaper Management
- Magazine Management
- CRUD Operations
- Search & Pagination

### 👨‍🎓 Student Management
- Add Student
- Edit Student
- Delete Student
- Search Student
- Pagination

### 👨‍💼 Librarian Management
- Add Librarian
- Edit Librarian
- Delete Librarian
- Search Librarian
- Pagination

### 📚 Borrow & Return System
- Borrow available books
- Return books
- Automatic availability update
- Borrow history

### 📊 Dashboard
Displays

- Total Books
- Total Students
- Total Librarians
- Total Publications
- Total Borrow Records

---

# 🛠 Tech Stack

| Technology | Description |
|------------|-------------|
| ASP.NET Core MVC | Backend Framework |
| .NET 8 | Runtime |
| C# | Programming Language |
| SQL Server | Database |
| Entity Framework Core | ORM |
| ADO.NET | Direct Database Access |
| Bootstrap 5 | Frontend |
| Razor Views | UI |
| HTML/CSS | Frontend |
| JavaScript | Client-side |

---

# 📂 Project Structure

```
LibraryManagementSystem
│
├── Controllers
├── Models
├── ViewModels
├── Views
├── Database
│   └── setup.sql
├── Migrations
├── wwwroot
├── Program.cs
├── appsettings.json
└── LibraryManagement2.csproj
```

---

# 🗄 Database

Database Name

```
LibraryManagementSystemDB
```

Tables

```
Books
BorrowRecords
Publications
Students
Librarians
logintab
```

---

# ⚙ Installation

## Clone Repository

```bash
git clone git clone https://github.com/krishnatripathi1801/Library-Management-System.git
```

---

## Open Project

```bash
cd LibraryManagementSystem
```

---

## Restore Packages

```bash
dotnet restore
```

---

## Create Database

Run Entity Framework migrations

```bash
dotnet ef database update
```

---

## Seed Database

Run

```
Database/setup.sql
```

using SQL Server.

---

## Run Project

```bash
dotnet run
```

Open

```
https://localhost:5001
```

or

```
http://localhost:5000
```

---

# 🔑 Demo Login

| Username | Password | Role |
|----------|----------|------|
| admin | 12345 | Admin |

---

# 📸 Screenshots

- Login Page
- Dashboard
- Books Module
- Borrow Module
- Student Module
- Librarian Module
- Newspaper Module
- Magazine Module

---

# 📈 Future Improvements

- Password Hashing
- Database Authentication
- Barcode Integration
- RFID Support
- Fine Calculation
- Email Notifications
- Book Cover Upload
- Role-based Authorization

---

# 👨‍💻 Author

**Krishna Tripathi**

B.Tech Computer Science & Engineering

VIT Bhopal University

Email:
krishnatripathi1801@gmail.com

GitHub:
https://github.com/krishnatripathi1801

---

# 📜 License

This project is developed for academic and educational purposes.
