# DVLD (Driving License Management System)

## Project Overview
**DVLD** is a comprehensive Driving License Management System developed as part of **Course 19** on the **Programming Advices** platform.  
The project implements essential driving license services with custom features to streamline the management of driver records, license issuance, renewals, and related processes.



## Features

### Three-Tier Architecture
- Clear separation of concerns: **Data Access Layer (DAL)**, **Business Logic Layer (BL)**, and **Presentation Layer**.
- Modular, maintainable, and scalable design.

### Database
- Built on **SQL Server** with over **14 normalized tables** and established relationships.
- Accessed via **ADO.NET** for efficient database operations.

### Rich User Interface
- Over **30 screens** with **reusable User Controls** to avoid code duplication.
- Consistent UI design across the application.

### Advanced Data Handling
- **Database Views** for professional and user-friendly data presentation.
- **Full CRUD operations** (Create, Read, Update, Delete) with advanced search capabilities on all entities.

### Modular Management
- **User Management**
- **Person Records Management**
- **Driver Records Management**
- **License Services** including:
  - New Local Driving License (multi-stage: eye exam, written test, road test)
  - License Renewal
  - Replacement for Lost or Damaged Licenses
  - Release of Detained Licenses
  - New International License
  - Retake Tests
- Payment processing integrated into each service.
- All services support **full CRUD operations**.

### Security Features
- Secure login with username and password, with optional local credential storage.
- **SQL Injection protection** via advanced input validation and stored procedures.

### Event-Driven Communication
- Use of **Delegates and Events** for smooth communication between forms and components.



## Technologies Used
- **C# .NET Framework**
- **WinForms**
- **SQL Server**
- **ADO.NET**
- **Three-Tier Architecture (DAL / BL / Presentation)**



## System Requirements
- **Visual Studio Community 2022** (or later)
- **SQL Server** (compatible version)



## Installation & Setup
Clone or download the repository.
Restore the provided SQL database (DVLD DB) from the GitHub files to your SQL Server instance.
Update the connection string in the application to match your SQL Server credentials and database settings.

# DVLD (Driving License Management System)

## Usage
1. Launch the application.
2. Login with the following credentials:
   - **Username:** Msaqer77
   - **Password:** 1234
3. Navigate the application to manage licenses, users, and tests etc.



## Project Structure
- Three-tier architecture separating **Data Access**, **Business Logic**, and **User Interface** layers.
- Organized folders and subfolders for maintainability:

##Contact & Support
For questions or support, connect with me on LinkedIn:
[Mustapha Botte](https://www.linkedin.com/in/mustapha-botte-559449327/)

##Acknowledgements
Special thanks to the Programming Advices platform for the original course content and guidance.

This README is intended to provide a clear, concise, and professional overview of the DVLD project to assist developers, users, and contributors.
