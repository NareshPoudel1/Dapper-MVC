This is a CRUD application built using ASP.NET Core MVC with Dapper as the ORM for database operations. It demonstrates creating, reading, updating, and deleting (CRUD) operations with clean architecture and repository patterns.

Project Structure
DapperMVC.Data:

DataAccess:
ISqlDataAccess.cs: Interface for SQL operations (generic methods like QueryAsync, ExecuteAsync).
SqlDataAccess.cs: Implements the interface to interact with the database.
Models:
Domain: Contains the Person model representing the database table schema.
Repository:
IPersonRepository.cs: Interface defining CRUD methods for Person.
PersonRepository.cs: Implements the interface using Dapper.
DapperMVC.UI:

Controllers:
PersonController.cs: Handles HTTP requests for CRUD operations on Person.
HomeController.cs: Default controller for the home page.
Models:
ErrorViewModel.cs: Handles error views.
Views:
Person:
Add.cshtml: View for adding a new person.
Edit.cshtml: View for updating an existing person.
DisplayAll.cshtml: View for listing all persons.
How It Works
Add a Record:

Navigate to /Person/Add.
Fill in the form and submit to insert a new record into the database.
View All Records:

Navigate to /Person/DisplayAll.
Displays all records retrieved using the GetAllAsync method.
Update a Record:

Navigate to /Person/Edit/{id}.
Fetches the person by ID and allows updating their details.
Delete a Record:

Navigate to /Person/Delete/{id}.
Deletes the record from the database.
