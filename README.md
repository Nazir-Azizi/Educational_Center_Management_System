# Educational Center Management System

A **desktop application** built with **C# WPF** using the **MVVM design pattern**, designed for educational centers to manage courses, teachers, and students efficiently.

## Features

- **Role-Based Access**: Supports Manager, Teacher, and Student roles
- **Modern WPF Interface** with multi-page navigation
- **CRUD operations** for managing classes, students, and teachers
- **MVVM Architecture** for clean separation of concerns
- **Database integration** for data persistence

## Screenshots

<!-- Add screenshots here -->
![Login Page](screenshots/loginPage.png)
![Manager Dashboard](screenshots/managerDashboard.png)
![Teacher Dashboard](screenshots/teacherDashboard.png)
![Student Dashboard](screenshots/studentDashboard.png)
![Add Page](screenshots/addPage.png)

## Tech Stack

- **Language**: C# (.NET)
- **UI Framework**: WPF (Windows Presentation Foundation)
- **Architecture**: MVVM (Model-View-ViewModel)
- **Database**: Microsoft SQL Server 2017

## Folder Structure
```
├── Converters
├── DataAccessLayer
├── Database schema
├── Enums
├── Helpers
├── Models
├── Services
├── ViewModels
├── Views
```

## Getting Started

### Prerequisites

- Visual Studio 2022 or later
- .NET SDK (e.g., .NET 6 / .NET Framework 4.8)
- Microsoft SQL Server 2017

### Running the Application

1. Clone the repository
2. Open the solution (.sln) file in Visual Studio.
3. Restore NuGet packages (Visual Studio does this automatically or via Tools -> NuGet Package Manager).
4. Update the database connection string if necessary.
5. Build and run the project

### Future Improvements
- Implement secure authentication
- Improve UI with custom styles and themes
- Add reporting features (e.g., student progress reports)
- Add Admin access layer
