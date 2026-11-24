🦷 Dental Clinic Management System

A desktop application developed using C# Windows Forms to manage dental clinic operations and organize the interaction between patients, dentists, appointments, and visits.

The system provides an integrated environment for managing patient records, scheduling appointments, documenting dental treatments, handling prescriptions, generating invoices, and tracking payments.

---

✨ Features

👤 Patients & Dentists Management

- Add, update, delete, and search patient records.
- Manage dentists and their information.
- View and organize patient details.
- Manage treatment types and their default prices.

📅 Appointments & Visits Management

- Schedule and manage patient appointments.
- Assign dentists to appointments.
- Track appointment statuses (Scheduled, Cancelled, Completed).
- Create and manage patient visits.
- Record patient complaints and clinical notes.
- Connect appointments, patients, dentists, and visits.

🦷 Visit Workflow

- Manage performed dental treatments.
- Select treatment types and record treatment dates.
- View treatment descriptions and default prices.
- Manage prescriptions associated with visits.
- Organize treatment and prescription information within the visit workflow.

🧾 Invoices & Payments

- Generate invoices based on performed treatments.
- Automatically create invoice items when issuing an invoice.
- Preserve treatment prices in invoice items.
- Manage patient payments.
- Automatically calculate total paid and remaining amounts.
- Automatically update invoice status:
  - Unpaid
  - Partially Paid
  - Paid
- Prevent deleting invoices that have associated payments.

🖥️ User Interface

- Windows Forms desktop interface.
- Organized navigation between system modules.
- DataGridView for displaying and managing records.
- ComboBox controls for selecting related records.
- Add, update, delete, and search operations.
- Event-driven interaction between forms.

---

🏗️ Software Architecture & Design

The project follows Three-Tier Architecture, separating responsibilities into three main layers:

- Presentation Layer: Handles the user interface, forms, and user interactions.
- Business Layer: Contains business logic, validation, and application operations.
- Data Access Layer: Handles database connections, SQL queries, and data operations using ADO.NET.

The project also focuses on:

- Separation of Concerns (SoC).
- Object-Oriented Programming (OOP).
- Encapsulation.
- Code Reusability.
- Maintainability.
- Organized database relationships.
- Business logic separation from the user interface.

---

🛠️ Technologies Used

- C#
- .NET Framework
- Windows Forms
- SQL Server
- ADO.NET
- Visual Studio
- Guna UI2
- DataTable
- DataGridView

---

🎯 Learning Objectives

This project helped me gain practical experience in:

- Building a multi-layered desktop application.
- Applying Three-Tier Architecture.
- Understanding Object-Oriented Programming concepts.
- Designing relational databases using SQL Server.
- Implementing CRUD operations.
- Working with ADO.NET.
- Using DataTable and DataGridView.
- Handling relationships between database tables.
- Implementing business logic and validation.
- Managing invoices and payment calculations.
- Building event-driven Windows Forms applications.

---

📸 Screenshots

🔐 Login Form

"Login Screen" (Screen-Shots/Screenshot%202026-11-24%20230650.png)

🖥️ Main Dashboard

"Main Form" (Screen-Shots/Screenshot%202026-11-24%20230640.png)

---

🚀 How to Run

1. Clone the repository:

git clone https://github.com/moe-stack24x/Dental-Clinic-Desktop-App.git

2. Open the solution file ("DentalClinic.sln") using Visual Studio.

3. Configure the SQL Server connection string in the application settings.

4. Create and configure the database using the SQL database script, if provided.

5. Build and run the project.

---

👨‍💻 Author

Mohamed Idris

- GitHub: "moe-stack24x" (https://github.com/moe-stack24x)

---

Developed with dedication, continuous learning, and a passion for software engineering.
