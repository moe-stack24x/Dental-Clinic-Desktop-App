🦷 Dental Clinic Management System

A desktop application developed using C# Windows Forms to manage dental clinic operations and organize the interaction between patients, dentists, appointments, and visits.

---

✨ Features

👤 Patients & Dentists Management

- Add, update, delete, and search patient records.
- Manage dentists and their information.
- View and organize patient details.
- Manage treatment types and prices.

📅 Appointments & Visits Management

- Schedule and manage patient appointments.
- Assign dentists to appointments.
- Track appointment statuses.
- Create and manage patient visits.
- Record patient complaints and clinical notes.

🦷 Visit Workflow

- Manage performed dental treatments.
- Select treatment types and record treatment dates.
- Manage prescriptions associated with visits.
- Organize treatment and prescription information.

🧾 Invoices & Payments

- Generate invoices based on performed treatments.
- Automatically create invoice items when issuing an invoice.
- Preserve treatment prices in invoice items.
- Manage patient payments.
- Calculate total paid and remaining amounts.
- Automatically update invoice status:
  - Unpaid
  - Partially Paid
  - Paid

---

🏗️ Software Architecture

The project follows Three-Tier Architecture, separating the application into three layers:

Layer| Responsibility
Presentation Layer| Handles Windows Forms and user interactions.
Business Layer| Contains business logic and validation.
Data Access Layer| Handles database operations using ADO.NET.

Design Principles

- Object-Oriented Programming (OOP)
- Separation of Concerns
- Encapsulation
- Code Reusability
- Maintainability

---

🛠️ Technologies Used

- C#
- .NET Framework
- Windows Forms
- SQL Server
- ADO.NET
- Visual Studio 2022
- Guna UI2

---

🗄️ Database

The project uses Microsoft SQL Server with a database named "DentalClinicDB".

The database scripts are available in the "Database" folder:

- "DentalClinicDB.sql"
- "DentalClinicDB_Full.sql"

These scripts provide the database creation script and the database objects and data.

---

📸 Screenshots

🔐 Login Form

<p align="center">
  <img src="https://raw.githubusercontent.com/moe-stack24x/Dental-Clinic-Desktop-App-/main/Screen-Shots/login.png" alt="Login Form" width="850">
</p>🖥️ Main Form

<p align="center">
  <img src="https://raw.githubusercontent.com/moe-stack24x/Dental-Clinic-Desktop-App-/main/Screen-Shots/main.png" alt="Main Form" width="850">
</p>---

🚀 How to Run

1. Clone the repository:
   
   git clone https://github.com/moe-stack24x/Dental-Clinic-Desktop-App-.git

2. Open "DentalClinic.sln" using Visual Studio 2022.

3. Open SQL Server Management Studio (SSMS).

4. Create the database using the SQL scripts available in the "Database" folder.

5. Configure the SQL Server connection string in the project according to your SQL Server instance.

6. Build and run the project.

---

👨‍💻 Author

Mohamed Idris

- GitHub: "moe-stack24x" (https://github.com/moe-stack24x)

---

<p align="center">
  Developed with dedication and a passion for software engineering ❤️
</p>
