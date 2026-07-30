/*
=======================================================================
  LibraryManagement - Manual Table Setup
=======================================================================
  The Books, BorrowRecords, and Publications tables are managed by
  Entity Framework Core migrations (Add-Migration / Update-Database).

  The Students, Librarians, and logintab tables are accessed directly
  via ADO.NET (SqlConnection/SqlCommand) in StudentController and
  LibrarianController, so EF does NOT create them. Run this script
  once against your LibraryManagementDB database (the same database
  named in your connection string) before using the Students,
  Librarians, or database-backed Login pages.

  How to run:
    1. Open SQL Server Management Studio (or the SQL Server Object
       Explorer in Visual Studio).
    2. Connect to (localdb)\MSSQLLocalDB (or your SQL Server instance).
    3. Make sure the LibraryManagementDB database already exists
       (it will after you run Add-Migration + Update-Database once).
    4. Open this file, point it at LibraryManagementDB, and execute.
=======================================================================
*/

USE LibraryManagementSystemDB;
GO

-- =======================================================================
-- Students table
-- =======================================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Students')
BEGIN
    CREATE TABLE Students
    (
        StudentId     INT IDENTITY(1,1) PRIMARY KEY,
        Student_Name  NVARCHAR(100) NOT NULL,
        Email         NVARCHAR(100) NOT NULL,
        Phone_Number  NVARCHAR(20)  NOT NULL
    );
END
GO

IF NOT EXISTS (SELECT * FROM Students)
BEGIN
    INSERT INTO Students (Student_Name, Email, Phone_Number)
    VALUES
        ('Alice Johnson', 'alice.j@email.com', '555-0101'),
        ('Bob Smith',      'bob.smith@email.com', '555-0102'),
        ('Charlie Brown',  'charlie.b@email.com', '555-0103'),
        ('Diana Prince',   'diana.p@email.com', '555-0104'),
        ('Evan Wright',    'evan.w@email.com', '555-0105');
END
GO

-- =======================================================================
-- Librarians table
-- =======================================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Librarians')
BEGIN
    CREATE TABLE Librarians
    (
        LibrarianId INT IDENTITY(1,1) PRIMARY KEY,
        Name        NVARCHAR(100) NOT NULL,
        Age         INT NOT NULL,
        Phone       NVARCHAR(20) NOT NULL
    );
END
GO

IF NOT EXISTS (SELECT * FROM Librarians)
BEGIN
    INSERT INTO Librarians (Name, Age, Phone)
    VALUES
        ('Sarah Connor',  34, '555-0201'),
        ('John Doe',      28, '555-0202'),
        ('Michael Scott', 45, '555-0203'),
        ('Ellen Ripley',  39, '555-0204'),
        ('James Bond',    40, '555-0205');
END
GO

-- =======================================================================
-- logintab table (optional - reference table for real login credentials;
-- the demo LoginController currently checks an in-memory list instead,
-- but this table is here if you want to switch to a DB-backed login)
-- =======================================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'logintab')
BEGIN
    CREATE TABLE logintab
    (
        Id       INT IDENTITY(1,1) PRIMARY KEY,
        Username NVARCHAR(50),
        Password NVARCHAR(50)
    );
END
GO

IF NOT EXISTS (SELECT * FROM logintab)
BEGIN
    INSERT INTO logintab (Username, Password) VALUES ('admin', '12345');
    INSERT INTO logintab (Username, Password) VALUES ('mycodingproject', 'myc546');
    INSERT INTO logintab (Username, Password) VALUES ('my', 'myc');
END
GO

-- =======================================================================
-- Verification queries
-- =======================================================================
SELECT * FROM Students;
SELECT * FROM Librarians;
SELECT * FROM logintab;
