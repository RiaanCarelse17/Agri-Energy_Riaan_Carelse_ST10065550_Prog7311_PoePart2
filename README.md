Agri-Energy Web Application
Project Title:
Agri-Energy

Project Description:
Agri-Energy is a web application designed to bridge the gap between farmers and employees in the agricultural sector. It provides functionalities for managing product listings, adding farmers, viewing products, and ensuring easy login and secure access for different users. The platform allows farmers to list their products, and employees to manage these listings, add new farmers, and perform administrative tasks efficiently.

Installation Instructions:
Prerequisites:
Before setting up the project, ensure you have the following installed on your system:

.NET 6.0 SDK or higher

Visual Studio 2022 or another IDE supporting ASP.NET Core applications

SQLite (The project uses SQLite as the database)

Steps to Run the Project:
Clone the Repository:
Clone the repository from GitHub to your local machine using the following command: git clone (https://github.com/RiaanCarelse17/Agri-Energy_Riaan_Carelse_ST10065550_Prog7311_PoePart2.git)


Open the Project:
Open the project in Visual Studio (or another IDE that supports ASP.NET Core).

Once you get the database running, Run the migrations to create the database structure. In the Package Manager Console, type: Update-Database

Run the Application:
Press F5 or click on the Run button in Visual Studio to start the application. The application will be hosted locally.

Configure the Application:
The application is designed to work with user login functionality. Ensure that the correct user credentials for the farmer and employee are added to the database for testing purposes.


Features:
Login/Logout System:

Secure login page for both Farmers and Employees.

Password validation and error handling.

Role-based redirection upon login (Farmer Dashboard or Employee Dashboard).

Farmer Dashboard:

Allows farmers to add products, manage their listings, and view all listed products.

Employee Dashboard:

Provides administrative controls to manage farmers and products.

Filters for viewing products by year and month.

Navigation Bar:

Dynamic navigation bar that adapts based on user role.

Includes links to the Dashboard, Add Products, View Products, and Logout options.

Technologies Used:
ASP.NET Core for the backend.

SQLite for the database (local file-based database).

Bootstrap 5 for front-end design and responsiveness.

HTML/CSS for page layouts and custom styles.
