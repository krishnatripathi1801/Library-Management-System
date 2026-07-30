# 📚 Library Management System

A modern **Library Management System** developed using **ASP.NET Core MVC (.NET 8)** and **Microsoft SQL Server**. The application automates library operations such as managing books, newspapers, magazines, students, librarians, and book borrowing/returning.

This project was developed as part of the **B.Tech Computer Science & Engineering** curriculum at **VIT Bhopal University**. It demonstrates the implementation of the MVC architecture using **Entity Framework Core**, **ADO.NET**, and **SQL Server**.

---

## 🚀 Features

### 🔐 Authentication
- Login System
- Session-based Authentication
- Admin, Student, and Librarian Roles
- Logout Functionality

### 📖 Book Management
- Add New Books
- Edit Book Details
- Delete Books
- Search Books
- Pagination
- Book Availability Status

### 📰 Publications Management
- Newspaper Management
- Magazine Management
- CRUD Operations
- Search Functionality
- Pagination

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
- Borrow Available Books
- Return Borrowed Books
- Automatic Book Availability Update
- Borrow History

### 📊 Dashboard
Displays:

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
| Razor Views | UI Engine |
| Bootstrap 5 | Frontend Framework |
| HTML5 | Markup |
| CSS3 | Styling |
| JavaScript | Client-side Scripting |

---

# 🏗 Architecture

```
                User
                  │
                  ▼
             Web Browser
                  │
                  ▼
      ASP.NET Core MVC Controllers
                  │
        ┌─────────┴─────────┐
        ▼                   ▼
 Entity Framework Core   ADO.NET
        │                   │
        └─────────┬─────────┘
                  ▼
            SQL Server Database
```

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
├── README.md
└── LibraryManagement2.csproj
```

---

# 🗄 Database

### Database Name

```
LibraryManagementSystemDB
```

### Tables

- Books
- BorrowRecords
- Publications
- Students
- Librarians
- logintab

---

# ⚙ Prerequisites

Before running the project, install:

- .NET 8 SDK
- Microsoft SQL Server 2022
- Visual Studio 2022 or Visual Studio Code
- Git

---

# 🚀 Installation

## 1. Clone Repository

```bash
git clone https://github.com/krishnatripathi1801/Library-Management-System.git
```

## 2. Open Project

```bash
cd Library-Management-System
```

## 3. Restore Packages

```bash
dotnet restore
```

## 4. Configure Database

Update the SQL Server connection string in **appsettings.json**.

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=LibraryManagementSystemDB;User ID=sa;Password=YOUR_SQL_SERVER_PASSWORD;TrustServerCertificate=True;"
}
```

## 5. Apply Entity Framework Migrations

```bash
dotnet ef database update
```

## 6. Execute SQL Script

Run

```
Database/setup.sql
```

using SQL Server Management Studio (SSMS), Azure Data Studio, or sqlcmd.

## 7. Run the Application

```bash
dotnet run
```

Open:

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

> **Note:** Replace the default credentials before deploying the application.

---

# 📸 Screenshots

Create a folder named **Screenshots** and add your project screenshots.

Example:

```
Screenshots/
├── login.png
├── dashboard.png
├── books.png
├── students.png
├── librarians.png
├── borrow.png
├── publications.png
└── database.png
```

Then include them like:

```markdown
## Login Page

![Login](Screenshots/login.png)

## Dashboard

![Dashboard](Screenshots/dashboard.png)

## Books Module

![Books](Screenshots/books.png)

## Student Module

![Students](Screenshots/students.png)

## Borrow Module

![Borrow](Screenshots/borrow.png)
```

---

# 📈 Future Enhancements

- Password Hashing
- Role-Based Authorization
- Email Notifications
- Fine Calculation
- Barcode Integration
- RFID Integration
- Book Cover Image Upload
- Online Book Reservation
- Audit Logging
- Responsive Mobile UI

---

# 🎯 Learning Outcomes

This project demonstrates:

- ASP.NET Core MVC Architecture
- CRUD Operations
- Entity Framework Core
- ADO.NET
- SQL Server Integration
- Session Management
- Model Validation
- Pagination
- Search Functionality
- Database Relationships
- MVC Design Pattern

---

# 🤝 Contributing

Contributions, suggestions, and improvements are welcome.

1. Fork the repository
2. Create a new branch

```bash
git checkout -b feature-name
```

3. Commit changes

```bash
git commit -m "Add new feature"
```

4. Push changes

```bash
git push origin feature-name
```

5. Create a Pull Request

---

# 👨‍💻 Author

**Krishna Tripathi**

B.Tech Computer Science & Engineering

VIT Bhopal University

📧 Email:
krishnatripathi1801@gmail.com

🌐 GitHub:
https://github.com/krishnatripathi1801

---

# 📄 License

This project is developed for **academic and educational purposes**.

---

## ⭐ If you found this project useful, consider giving it a Star on GitHub!
