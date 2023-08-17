# Employee Tracker API
This is a .NET 6 Web API project for managing employee data. It provides basic CRUD operations for employees with validation and pagination features.
### Prerequisites

- .NET 6 SDK
### Installation

1. Clone this repository to your local machine.
2. Open the solution in Visual Studio or your preferred IDE.
3. Update the database connection string in `appsettings.json`.
4. Run the migration commands:
    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```
5. Build and run the project:
    ```bash
    dotnet build
    dotnet run


