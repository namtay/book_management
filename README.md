# Project Structure and Commands

This repository contains a .NET solution with multiple C# projects. It follows a modular architecture for clear separation of functionality and scalability.

---

## 📁 Solution Structure
```
MySolution/
│
├── MySolution.sln
├── ProjectA/
│ └── ProjectA.csproj
├── ProjectB/
│ └── ProjectB.csproj
├── Project.Tests/
│ └── Project.Tests.csproj
```

---

## 🛠️ Setup Instructions

### ✅ Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Git](https://git-scm.com/)
- (Optional) Visual Studio or Visual Studio Code

---

### 📦 Commands for running project


```bash build and run code
dotnet restore
dotnet clean
dotnet build

dotnet run --project ProjectB/ProjectB.csproj

dotnet watch

dotnet test Project.Tests/Project.Tests.csproj

```
---

### 📦 Git Commands

#### 📦Cloning code from a repository
```
git clone -b branchname https://github.com/your-username/your-repo-name.git .
```

#### 📦Switch to branch Commands
```
git checkout -b feature/your-branch-name
```

#### 📦Commit code to a branch
```
git add .
git commit -m "Describe your changes"
git push -u origin feature/your-branch-name
```
#### 📦Fetch and pull latest changes from main branch
```
git fetch origin
git checkout main
git pull origin main
```
#### 📦Merge main into feature branch
```
git checkout -b feature/your-branch-name
git push -u origin feature/new-branch-name
git merge main
```

#### 📦Adding dotnet packages to Books module

```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

#### 📦Commands for ef migrations in .Web project

```
dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef
dotnet add package Microsoft.EntityFramework.Design
```

#### 📦Migrations-cmd
```
dotnet ef migrations add Initial -c BookDbContext -p ..\RiverBooks.Books\RiverBooks.Books.csproj -s .\RiverBooks.Web.csproj -o Data/Migrations

dotnet ef database update
```

#### 📦Migrations-bash
```
dotnet ef migrations add Initial -c BookDbContext -p ../RiverBooks.Books/RiverBooks.Books.csproj -s ./RiverBooks.Web.csproj -o Data/Migrations

dotnet ef database update
```

#### 📦Shortcut to run markdown files
- Ctrl + Shift + V