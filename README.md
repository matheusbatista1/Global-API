# Global-API
Global API is a flexible and scalable backend framework built with ASP.NET Core. It provides core features like JWT authentication, Swagger documentation, centralized exception handling, and MediatR for clean command/query handling. It serves as a foundation for creating various web applications.

# Global API

The **Global API** is a generic backend framework designed to serve as a foundational platform for building various web applications. This project is structured to be flexible and scalable, offering core functionalities that can be easily adapted for different use cases.

The API is built using **ASP.NET Core** and follows modern software development principles, incorporating industry-standard practices such as **JWT authentication** for secure access and **Swagger** for API documentation.

## Features
- **JWT Authentication**: Secure API access using JSON Web Tokens for authentication and authorization.
- **Swagger Integration**: Easily interact with the API through the generated documentation, making testing and debugging simpler.
- **Exception Handling Middleware**: Centralized error handling that provides detailed responses based on the environment (development or production).
- **CORS Support**: Configurable Cross-Origin Resource Sharing (CORS) settings to allow or restrict client applications from different origins.
- **MediatR Integration**: Uses the MediatR pattern for clean separation of concerns and handling commands and queries.

## Purpose
This API serves as a base for other projects. By starting with this foundation, developers can quickly launch new applications without having to reimplement common features such as user authentication, error handling, and API documentation. The project is designed to be extended and customized, providing a reliable starting point for creating scalable and maintainable web services.

## Technologies Used
- **ASP.NET Core**
- **JWT (JSON Web Token)**
- **Swagger**
- **MediatR**
- **SQL Server** (via Entity Framework)

## Setup
1. Clone the repository to your local machine.
2. Install the necessary dependencies.
3. Configure the project settings, including JWT secrets and database connection strings.
4. Run the application and access the API through Swagger or any HTTP client.

## Future Enhancements
- Add more customizable templates for various project requirements.
- Improve error handling and response structure.
- Support additional authentication strategies (e.g., OAuth, OpenID).

Feel free to use and contribute to this project!
