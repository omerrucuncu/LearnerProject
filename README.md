# LearnerProject — ASP.NET MVC e‑Learning Platform

A full-featured e-learning web application built with ASP.NET MVC 5, .NET Framework 4.7.2, and Entity Framework 6. The platform enables course browsing, enrollment, reviews, teacher/course management, and an admin back office.

[![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-5C2D91.svg)](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472)
[![ASP.NET MVC](https://img.shields.io/badge/ASP.NET-MVC%205-5C2D91.svg)](https://www.nuget.org/packages/Microsoft.AspNet.Mvc/)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-6.0-green.svg)](https://www.nuget.org/packages/EntityFramework/)
[![License](https://img.shields.io/badge/License-Unspecified-lightgrey.svg)](#license)

---

## Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Technology Stack](#technology-stack)
- [Solution Structure](#solution-structure)
- [Domain Model](#domain-model)
- [Key Controllers and Views](#key-controllers-and-views)
- [Getting Started](#getting-started)
- [Configuration](#configuration)
- [Database and Migrations](#database-and-migrations)
- [Security Notes](#security-notes)
- [Roadmap and TODOs](#roadmap-and-todos)
- [Contributing](#contributing)
- [License](#license)

---

## Overview
LearnerProject is a classic MVC 5 e-learning application. It provides public catalog browsing, student registrations and enrollments, review and rating capabilities, course video management for teachers, and a multi-section admin panel for managing entities like Courses, Categories, Teachers, Clubs, FAQs, Testimonials, Banners, and more.

The application targets .NET Framework 4.7.2 and uses Entity Framework 6 Code First with SQL Server.

---

## Features
- Public site:
  - Home with featured courses, categories, clubs, testimonials, FAQs
  - Full course list and details pages
- Student area:
  - Registration and login
  - Enroll in courses
  - My courses listing
  - Leave reviews and ratings on courses
- Teacher area:
  - Login
  - Manage assigned courses
  - Manage course videos and content
- Admin area:
  - Dashboard (KPIs such as counts of courses, students, teachers, categories)
  - Manage Courses, Categories, Teachers, Students, Reviews
  - Manage Clubs, FAQs, Testimonials, Social Media, Messages, Contacts, Banners, About content
- General:
  - Soft/active status flags on most entities
  - Basic relational integrity and cascade rules configured in EF

---

## Technology Stack
- Runtime: .NET Framework 4.7.2
- Web Framework: ASP.NET MVC 5.2.9
- ORM: Entity Framework 6
- JSON: Newtonsoft.Json 13.x
- Views: Razor (.cshtml)
- Database: Microsoft SQL Server (Express or full)
- IDE: Visual Studio 2022

---

## Solution Structure
- Controllers/
  - Admin, Teacher, Student, and Public controllers (e.g., DefaultController, AdminCourseController, TeacherLoginController, StudentRegisterController, etc.)
- Models/
  - Entities/ — POCOs representing domain tables (Course, Category, Teacher, Student, Review, CourseVideo, CourseRegister, Admin, etc.)
  - Context/ — `LearnerContext` (DbContext) and fluent configurations
- Views/
  - Razor views grouped by controller (e.g., AdminCourse, FullCourse, StudentReview, TeacherLayout, etc.)
- Web.config
  - Target framework, EF provider, binding redirects, and connection strings

---

## Domain Model
Entity highlights (only key properties shown):
- Course
  - CourseId, CourseName, Description, Price, ImageUrl, Status
  - CategoryId → Category (many-to-one)
  - TeacherId → Teacher (many-to-one)
  - Collections: Reviews, CourseRegisters, CourseVideos
- Category
  - CategoryId, CategoryName, Icon, Status
  - Courses (one-to-many)
- Teacher
  - TeacherId, NameSurname, Title, UserName, Password, Status
  - Courses (one-to-many), CourseVideos (one-to-many)
- Review
  - ReviewId, ReviewValue, Comment, Status
  - CourseId → Course; StudentId → Student
- CourseVideo
  - CourseVideoId, CourseId, TeacherId, VideoNumber, VideoUrl, Status
- CourseRegister
  - CourseRegisterId, StudentId → Student, CourseId → Course
- Admin
  - AdminId, NameSurname, UserName, Password, ImageUrl, Status
- Additional content entities: Student, Club, Testimonial, Message, FAQ, Contact, SocialMedia, Banner, About (all exposed in DbContext)

Entity Framework relationship rules (from `LearnerContext`):
- Course → Teacher: required many-to-one, cascade delete enabled
- CourseVideo → Course: required many-to-one, cascade delete enabled
- CourseVideo → Teacher: required many-to-one, cascade delete disabled (prevents deleting a Teacher from cascading to CourseVideos)

---

## Key Controllers and Views
Examples (non-exhaustive):
- Public
  - DefaultController: Home, featured Courses/Categories/Clubs/FAQs/Testimonials
  - FullCourseController & Views: Course listing and details
- Student
  - StudentRegisterController & StudentLoginController: Auth flows
  - StudentCourseController: My courses
  - StudentReviewController & Views: Add/list reviews
- Teacher
  - TeacherLoginController: Auth
  - TeacherCourseController & Views: Add/Update course content/videos
- Admin
  - AdminLoginController: Admin auth
  - AdminDashboardController: KPIs and stats
  - AdminCourseController, AdminCategoryController, AdminTeacherController, AdminAdminController: CRUD administration

---

## Getting Started

### Prerequisites
- Visual Studio 2022
- .NET Framework 4.7.2 Developer Pack
- SQL Server (Express or full). SQL Server Express LocalDB also works.

### Clone
- HTTPS: https://github.com/omerrucuncu/LearnerProject

### Configure database connection
Edit the connection string in `LearnerProject/Web.config`:
~~~xml
<connectionStrings>
  <add name="LearnerContext"
       connectionString="server=.\SQLEXPRESS;initial catalog=LearnerProjectDb;integrated security=True;trustServerCertificate=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
~~~
- Change server to your SQL instance (e.g., `(localdb)\MSSQLLocalDB` or a remote SQL Server).
- For SQL auth, replace `integrated security=True` with `User ID=...;Password=...`.

### Restore, build, run
1. Open the solution in Visual Studio 2022.
2. Restore NuGet packages if prompted.
3. Build the solution (__Build__).
4. Run the web project (__Start Debugging__ or __Start Without Debugging__).

The application should create the database and required tables on first run if EF Code First initialization is allowed. Otherwise, see [Database and Migrations](#database-and-migrations).

---

## Configuration
Key `Web.config` settings:
- Target framework: 4.7.2
- MVC, WebPages, Optimization, and Newtonsoft.Json binding redirects included
- EF provider: `System.Data.Entity.SqlServer`
- CodeDom: Microsoft.CodeDom.Providers.DotNetCompilerPlatform for C#/VB

App settings:
- `webpages:Version` = 3.0.0.0
- Client validation and unobtrusive JS enabled

---

## Database and Migrations
This project uses Entity Framework 6 with Code First POCOs.

Options to set up the schema:
- Automatic creation (default EF initializer): Run the app to create `LearnerProjectDb` if it doesn’t exist.
- Using EF Migrations (recommended for production):
  1. Open the __Package Manager Console__.
  2. Run `Enable-Migrations` (if not already enabled).
  3. Run `Add-Migration InitialCreate`.
  4. Run `Update-Database`.

If you already have a database, ensure the connection string points to it and the schema matches the models.

---

## Security Notes
- Passwords for Admin/Teacher/Student are stored as plain text properties in the models. For production, implement secure password hashing (e.g., PBKDF2/BCrypt/Argon2) and never store raw passwords.
- `trustServerCertificate=True` is included for development convenience. Avoid this in production; use a valid SQL Server certificate.
- Add authentication/authorization filters to Admin/Teacher/Student areas to protect routes.
- Validate and sanitize all user inputs (reviews, messages, contact forms).

---

## Roadmap and TODOs
- Replace plain-text passwords with hashed and salted credentials
- Add role-based authorization filters and area segmentation
- Introduce EF Migrations with seed data (admin account, sample teachers/courses)
- Add client and server-side validation summaries across forms
- Improve error handling, logging, and telemetry
- Add unit/integration tests
- Optimize queries (explicit Include, pagination in listings)
- Add file storage abstractions for image/video assets
- Internationalization/localization support

---

## Contributing
1. Fork the repository.
2. Create a feature branch.
3. Commit changes with clear messages.
4. Open a Pull Request describing your changes and rationale.

---

## License
No license file is currently provided. Consider adding an open-source license (e.g., MIT) or a proprietary license according to your needs.

---