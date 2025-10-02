# Campus Management System

A web-based **Campus Management System** built with **ASP.NET Core MVC** and **Entity Framework Core** as part of a college curriculum project.  
The system is modular and consists of multiple portals for administrators, instructors, and students, with shared core and data layers.

---

## 🎯 Purpose

The purpose of this project was to design and implement a scalable and maintainable system to manage campus activities.  
The system enables administrators, instructors, and students to interact with the campus digitally through dedicated portals.

---

## ⚙️ Features

- **Admin Portal**
  - Manage courses, departments, and users.
  - Assign instructors to courses.
  - Oversee system-wide operations.

- **Instructor Portal**
  - View and manage assigned students.
  - Access teaching schedules and course details.
  - Input grades and feedback.

- **Student Portal**
  - Register and manage course enrollments.
  - View grades and academic progress.
  - Access personal schedules and announcements.

- **Data Layer**
  - Database migrations and context.
  - Entity models for users, courses, enrollments, etc.

- **Core Library**
  - Shared business logic and utilities.
 
---

## 🚀 Deployment

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/) (or another supported database)
- Visual Studio / VS Code

### Steps
1. Clone the repository:
    ```bash
    git clone https://github.com/zwepener/netgen-wil.git
    cd netgen-wil/codecraft_web
    ```
2. Apply database migrations:
    ```bash
    cd CodeCraft.Data
    dotnet ef database update
    ```
3. Run the portals:
    ```bash
    cd ../CodeCraft.Web.AdminPortal
    dotnet run
    # Repeat for InstructorPortal and StudentPortal
    ```
4. Open the apps in your browser:
    * Admin Portal: `https://localhost:5001/`
    * Instructor Portal: `https://localhost:5002/`
    * Student Portal: `https://localhost:5003/`

---

## 🛠️ Tech Stack

* **Backend**: ASP.NET Core MVC, Entity Framework Core
* **Database**: Microsoft SQL Server
* **Frontend**: Razor Views, Bootstrap
* **Other**: Identity for authentication & authorization

---

## 👥 [Contributors](CONTRIBUTORS.md)

This project was built by a team of 5 students:

* Backend Team
    * [Zandré Wepener](https://github.com/zwepener)
    * [Mzwakhe Khumalo](https://github.com/MZ-Bale)
* Frontend Team
    * [Mmokgo Radebe](https://github.com/mmokgoradebe)
    * [Ikaneng Khaile](https://github.com/LightWay21)
    * [Bryslon Van Rooyen](https://github.com/bryslon-vr)
 
---

## ⚠️ Disclaimer
This project was created **for educational purposes** as part of a college curriculum.\
It is **not intended for production use** without additional security, scalability, and performance improvements.

---

## 📄 License
This project is licensed under the MIT License.
