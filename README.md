# EshopApi
EshopApi is a .NET Core API sample project that provides a RESTful API for an e-commerce platform. There is implemented just Product entity for the purpose of demonstration.

## Getting Started
### Prerequisites
- Target framework .NET 8.0 or later
- Visual Studio 2019 or later (optional)

### Building and Running the Project
1. Open the solution in Visual Studio (or your preferred IDE).
2. Restore NuGet packages by running **``dotnet restore``** in the terminal.
3. Build the project by running **``dotnet build``**.
4. Run the project by running **``dotnet run``**.

### Database Migrations
To run database migrations, open the Package Manager Console (PMC) in Visual Studio and run the following commands:

- ``Enable-Migrations -StartupProject EshopApi.Presentation -Project EshopApi.Infrastructure``
- ``Add-Migration InitialCreate -StartupProject EshopApi.Presentation -Project EshopApi.Infrastructure``
- ``Update-Database -StartupProject EshopApi.Presentation -Project EshopApi.Infrastructure``

## Swagger Documentation
The API is documented using Swagger, which provides a interactive API documentation and testing tool. To access the Swagger documentation, navigate to **`https://localhost:5001/swagger`** in your browser.

### API Endpoints
The Swagger documentation provides a list of available API endpoints, including:

Products: GET /api/products - Retrieve a list of products
Orders: POST /api/orders - Create a new order
Customers: GET /api/customers - Retrieve a list of customers

### API Authentication
The API uses JWT authentication. To authenticate, send a POST request to https://localhost:5001/api/auth/login with a valid username and password. The response will include a JWT token, which can be used to authenticate subsequent requests.

## Project Structure
The project is Clean Architecture solution structure:

### EshopApi.Presentation
The presentation layer is responsible for handling HTTP requests \/ responses and input validation.

- Controllers: API controllers that handle HTTP requests.
- Models: Data transfer objects (DTOs) used for API requests and responses.
- Program.cs: Configuration and startup logic for the API.

### EshopApi.Infrastructure
The infrastructure layer is responsible for database access and other external services.

- Data: Database models and Entity Framework Core configuration with dbContext.
- Services: Business logic and services used by the API.
- Migrations: Database migrations and schema changes.
- Repositories: CRUD operations of Database entities using EF.

### EshopApi.Application
The application layer of the API, responsible for business logic, and other core functionality.

- Services: Business logic and services used by the API.
- Reposities: Repository interfaces of domains.

### EshopApi.Domain
The infrastructure layer is responsible for domain entity models and other domain related functionality.

## Contributing
Contributions are welcome! If you'd like to contribute to the project, please fork the repository and submit a pull request.

## License
This project is licensed under the MIT License. See LICENSE for details.

## Contact
If you have any questions or need help with the project, please don't hesitate to reach out at martinburza22@gmail.com.