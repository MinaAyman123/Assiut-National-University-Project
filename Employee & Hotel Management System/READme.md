# Employee Management System

A desktop application built with **C# Windows Forms** for managing employees with a multi-role login system (Admin / Manager / Worker).

---

## 📋 Overview

A Windows Forms application that allows employees to log in based on their credentials stored in the database, then redirects them to the appropriate page based on their role:

- **Admin** → Admin Home Page
- **Manager** → Manager Home Page
- **Worker** → Worker Home Page

---

## 🛠️ Technologies Used

| Technology | Description |
|------------|-------------|
| **C#** | Core programming language |
| **Windows Forms** | Graphical User Interface |
| **Entity Framework Core** | Database access (ORM) |
| **SQL Server** | Database |
| **.NET 6/7/8** | Framework |

---

## 📁 Project Structure

```
WinFormsApp2/
│
├── Form1.cs                    # Login page (logic code)
├── Form1.Designer.cs           # Login page (UI design)
│
├── Models/
│   ├── MyDbContext.cs          # Database context class
│   └── Employee.cs             # Employee model
│
├── AdminPage/
│   └── AdminHomePage.cs        # Admin home page
│
├── ManagerPage/
│   └── ManagerHomePage.cs      # Manager home page
│
├── WorkerPage/
│   └── WorkerHomePage.cs       # Worker home page
│
└── README.md
```

---

## 🚀 Prerequisites

Before running the project, make sure you have:

- ✅ **Visual Studio 2022** or later
- ✅ **.NET SDK 6.0** or later
- ✅ **SQL Server** (LocalDB or Full Server)
- ✅ **Entity Framework Core Tools**

---

## ⚙️ Installation & Setup

### 1️⃣ Clone the repository
```bash
git clone [https://github.com/your-username/WinFormsApp2.git](https://github.com/your-username/WinFormsApp2.git)
cd WinFormsApp2
```

### 2️⃣ Install required NuGet packages
```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.IdentityModel.Tokens
```

### 3️⃣ Configure the database

Edit the connection string in `MyDbContext.cs`:

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlServer(@"Server=.;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True;");
}
```

### 4️⃣ Run Migrations
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 5️⃣ Run the project
Press **F5** in Visual Studio, or use:
```bash
dotnet run
```

---

## 🗄️ Database Schema

### `Employees` Table

| Column | Type | Description |
|--------|------|-------------|
| `Id` | int | Primary Key |
| `Name` | nvarchar | Employee name |
| `Email` | nvarchar | Email (unique) |
| `Password` | nvarchar | Password |
| `Role` | nvarchar | Role (admin / manager / worker) |

### Sample Seed Data:
```sql
INSERT INTO Employees (Name, Email, Password, Role) 
VALUES 
('Ahmed Admin', 'admin@test.com', '123456', 'admin'),
('Sara Manager', 'manager@test.com', '123456', 'manager'),
('Ali Worker', 'worker@test.com', '123456', 'worker');
```

---

## 🔐 How to Log In

1. Open the application
2. Enter your **Email** and **Password**
3. Click the **Login** button
4. You will be redirected automatically based on your role:

| Role | Page |
|------|------|
| admin | `AdminHomePage` |
| manager | `ManagerHomePage` |
| worker | `WorkerHomePage` |

---

## 📸 Screenshots

> *Add screenshots here after running the application*

---

## 🐛 Troubleshooting

| Issue | Solution |
|-------|----------|
| `MyDbContext` not found | Make sure the file exists in the `Models` folder |
| Database connection error | Check your Connection String |
| `AdminHomePage` not found | Make sure it's created in the `AdminPage` folder |
| Placeholder not showing | Make sure you're using .NET 6+ |

---

## 🔮 Future Improvements

- [ ] Password hashing (secure storage)
- [ ] JWT-based authentication
- [ ] "Forgot Password" feature
- [ ] Activity logging
- [ ] Multi-language support (Arabic / English)
- [ ] Enhanced UI/UX

---

## 👨‍💻 Author

**Your Name**
- GitHub: [@your-username](https://github.com/your-username)
- Email: your.email@example.com

---

## 📄 License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.

---

## ⭐ Support

If you like this project, don't forget to give it a ⭐ on GitHub!

```
Made with ❤️ using C# & WinForms
```
