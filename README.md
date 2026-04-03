# 🧠 Online Quiz System

A full-stack web application built using **ASP.NET Core MVC + SQLite** that allows teachers to create quizzes and students to attempt them.

---

## 🚀 Features

### 👨‍🏫 Teacher
- Create quizzes
- Add multiple questions
- Edit questions
- Delete questions
- View all created quizzes

### 👨‍🎓 Student
- View available quizzes
- Attempt quiz (only once per submission)
- Get instant score

### 🌐 General
- Login & Register system
- Role-based dashboard (Teacher / Student)
- Clean modern UI (Glassmorphism + Bootstrap)
- Responsive design

---

## 🛠️ Tech Stack

- **Backend:** ASP.NET Core MVC (C#)
- **Frontend:** HTML, CSS, Bootstrap
- **Database:** SQLite
- **ORM:** Entity Framework Core

---

## 📂 Project Structure


QuizSystem/
│
├── Controllers/ # MVC Controllers
├── Models/ # Database Models
├── Views/ # Razor Views (UI)
├── Data/ # DbContext
├── wwwroot/ # Static files (CSS, images)
└── Program.cs # App entry point


---
## ⚙️ Setup & Installation

### 1️⃣ Clone the Repository
```bash
git clone https://github.com/your-username/quiz-system.git
cd quiz-system
```
### 2️⃣ Restore Dependencies
```bash
dotnet restore
```
### 3️⃣ Install EF Core Tool (if not installed)
```bash
dotnet tool install --global dotnet-ef
```
### 4️⃣ Apply Database Migrations
```bash
dotnet ef database update
```
### 5️⃣ Run the Application
```bash
dotnet run
```
---
⭐ If you like this project

Give it a ⭐ on GitHub!
