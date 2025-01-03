## Clean Architecture .NET Template

## Table of Contents
- [Introduction](#introduction)
- [Why Clean Architecture](#why-clean-architecture)
- [Why This Template](#why-this-template)
- [Project Structure](#project-structure)
- [Features](#features)
- [Installation](#installation)
- [Documentation](#documentation)
  - [Core Layer](#core-layer)
  - [Application Layer](#application-layer)
  - [Infrastructure Layer](#infrastructure-layer)
  - [API Layer](#api-layer)

## Introduction
This repository provides a Clean Architecture template for .NET applications, designed to help developers understand and implement Clean Architecture principles.

## Why Clean Architecture
Clean Architecture separates an application into layers, each with specific responsibilities, enhancing maintainability, testability, and scalability.

## Why This Template
This template offers a solid foundation to beginners to help them understand the best practices and common patterns, suitable for production-level applications.

## Project Structure
The project is structured into four main layers: Core, Application, Infrastructure, and API.
![Clean Architecture Diagram](https://i.imgur.com/zfV7mEM.png)

## Features
- .NET Core Identity with JWT tokens
- BaseApiController
- Mediator pattern
- Fluent Validation
- Global exception handling middleware
- Logging with Serilog
- User-secrets for configuration
- Uniform API response classes

## Installation

### Cloning the Repository
```bash
git clone https://github.com/Ahmed0Tawfik/CleanArchitectureTemplate.git
cd repository
```
### Setting Up User Secrets
```bash
dotnet user-secrets init
dotnet user-secrets set "Jwt:Secret" "YourJwtKey"
```
### Configuring Connection Strings and JWT Settings
Update the appsettings.json file with your connection strings and JWT configuration.

### Running Migrations
```bash
dotnet ef database update
```
## Documentation
Detailed documentation about each layer in the architecture.

### Core Layer
The Core layer is the heart of the application, containing the domain models and business logic. It is designed to be independent of external dependencies and frameworks, ensuring that the business rules are encapsulated and can be tested in isolation.

#### Folders and Classes

1. **Entities**
   - **BaseEntity.cs** : A base class for all entities, providing common properties like ID.
   This folder has entites along with its Events, Specification, Enums used in that entity
     
2. **Enums**
   -  Enums that are used in all entities (Something global),Contains enumerations used within the domain           to represent specific states or options.

3. **Events**
   - Contains domain events that are raised when significant domain-related actions occur.

4. **EventsHandlers**
   - Handlers that process the domain events, ensuring that side effects are managed appropriately.

5. **Specifications**
   - Implements the Specification pattern for defining and reusing complex queries on entities.

7. **Exceptions**
   This Folder Contains userdefined exception ex: 
   - **NotFoundException.cs** : A custom exception thrown when an entity is not found.

8. **Interfaces**
   - **IGenericRepository.cs**: Defines the contract for a generic repository pattern.
   - **IUnitOfWork.cs** : Interface for the Unit of Work pattern, managing transactions and data                     persistence.

#### Patterns and Concepts
- **Repository Pattern** : Abstracts data access, providing a clean interface for CRUD operations.
- **Unit of Work** : Manages database transactions, ensuring consistency across operations.
- **Specification Pattern** : Allows for complex queries to be defined and reused.
- **Event-Driven Architecture** : Domain events are published and handled to manage side effects.

#### Best Practices
- Keep the Core layer free from dependencies on other layers or external libraries.
- Ensure that business logic is encapsulated within the domain models.
- Use interfaces to define contracts that are implemented in other layers, such as Infrastructure.

#### Interaction with Other Layers
- The Core layer is depended upon by the Application and Infrastructure layers.
- The Application layer uses the interfaces defined here to interact with the domain logic.
- The Infrastructure layer implements the interfaces to provide concrete data access and other services.

#### Conclusion
The Core layer is crucial for maintaining a clean and testable architecture. By documenting each folder and class, we ensure that developers, especially beginners, can understand the role of each component and how they contribute to the overall application. This documentation should be expanded with code snippets and examples as part of the full project documentation.

### Application Layer
The Application layer is responsible for handling the business logic and orchestrating the flow of data between the Core and Infrastructure layers. It serves as an intermediary, ensuring that the application's functionality is exposed through well-defined interfaces and commands. Below is a detailed documentation of the folders and classes within this layer.

#### Folders and Classes

1. **APIResponse**
   - **APIResponse.cs** : Defines a standard format for API responses, ensuring consistency across all                 endpoints.
   - **APIResponseHandler.cs** : Handles the creation and formatting of API responses, encapsulating               common response logic.

2. **Behaviors**
   - **PipelineValidationBehavior.cs**: A custom behavior for the MediatR pipeline, responsible for                 validating requests before they reach the handlers.

3. **CORS**
   - This folder appears to be misplaced or a typo. CORS policies are typically configured in the API               layer rather than the Application layer. It may need to be reviewed or relocated.

4. **Authentication**
   - **Login**
      - **LoginUserCommand.cs**: Represents the command for user login, containing the necessary data                 (e.g., username, password).
      - **LoginUserCommandHandler.cs** : Handles the login process, validating credentials and generating             tokens.

   - **RegisterUser**
      - **RegisterUserCommand.cs** : Represents the command for user registration, containing user details.
      -**RegisterUserCommandHandler.cs** : Handles the registration process, creating a new user in the               system.

5. **Entity**
   - Currently empty; may be a placeholder for future entity-related application services.

6. **Extensions**
   - **DependencyInjection.cs** : Contains extension methods for registering application services with the             dependency injection container, simplifying DI configuration.

7. **Interfaces**
   - **ITokenService.cs** : Defines the contract for token generation services.
   - **IDateTimeProvider.cs** : Provides a standardized way to access datetime operations, ensuring                   testability.
   - **IUserService.cs** : Defines user-related functionalities, such as user retrieval or updates.

8. **Services**
   - **AuthenticationResponse.cs** : Represents the response model for authentication operations.
   - **AuthenticationService.cs** : Implements authentication logic, such as token generation and user               validation.

#### Patterns and Best Practices
- **MediatR Pattern** : Utilizes MediatR for handling commands and queries, promoting a decoupled architecture.
- **CQRS (Command Query Responsibility Segregation)** : Separates read and write operations, enhancing               scalability and maintainability.
- **Dependency Inversion Principle** : Services depend on abstractions (interfaces), not concretions,                facilitating easier testing and maintenance.

#### Interaction with Other Layers
- **Core Layer** : The Application layer uses domain models and specifications from the Core layer,                 ensuring business logic is encapsulated within the domain.

- **Infrastructure Layer**: Interacts with infrastructure services (e.g., data access, token generation)            through interfaces, maintaining loose coupling.

#### Conclusion
The Application layer is crucial for orchestrating business logic and ensuring that the application's functionality is exposed in a clean and maintainable way. By documenting each folder and class, we provide clarity on their roles and how they contribute to the overall architecture. This documentation should be expanded with code snippets and examples as part of the full project documentation.


### Infrastructure Layer
The Infrastructure layer is responsible for handling external interactions, such as database access, logging, and authentication services, ensuring that these concerns are decoupled from the core business logic.

#### Folders and Classes
1. **Extensions**
   - **DependencyInjection.cs** : Contains extension methods for setting up dependency injection in the           infrastructure layer.
   - **JWTExtension.cs**: Adds JWT-related services to the application.

2. **ExternalServices**
   - A Folder for external services like emailsender, etc...

3. **Identity**
   - **ApplicationUser.cs** : Custom user class for .NET Core Identity.

4. **Logging**
   - **SerilogBehavior.cs**: Configures logging behavior using Serilog.
   - **Logs** : Contains log files, e.g., "log-20250103.txt".

5. **Persistence**
   - **Config** : Configuration settings for data persistence.
   - **Migrations** : Holds migration scripts for database schema changes.
   - **ApplicationDbContext.cs** : The database context class for Entity Framework Core.
   - **SeedData.cs** : Contains methods for seeding the database with initial data.
     
6. **Services**
   - **Authentication**
      -  **JWTSettings.cs** : Configuration settings for JWT authentication.
      -  **TokenService.cs** : Handles JWT token generation and validation.
   - **DateTimeProvider**
      - **DateTimeProvider.cs** : Provides a consistent interface for accessing date and time, useful for             testing.
   - **UserServices**
      - **UserService.cs** : Implements user-related operations.
      - **GenericRepository.cs** : Generic repository pattern for data access.
      - **UnitOfWork.cs** : Manages database transactions and unit of work pattern.

#### Patterns and Best Practices 
- **Dependency Injection** : Utilized for managing service lifetimes and dependencies.
- **Repository Pattern** : Implemented through GenericRepository.cs for abstracting data access.
- **Unit of Work Pattern** : Managed by UnitOfWork.cs to ensure database transactions are handled               correctly.
- **Entity Framework Core Migrations** : Used for database schema management.

#### Interaction with Other Layers
- **Core Layer** : Provides implementations for interfaces defined in the Core layer, such as repositories       and services.

- **Application Layer**: Supplies the necessary services and configurations for business logic execution.

#### Conclusion
The Infrastructure layer effectively handles external interactions, ensuring that the core business logic remains clean and decoupled. By documenting each component, we provide clarity on their roles and how they contribute to the overall architecture. This documentation should be expanded with code snippets and examples as part of the full project documentation.


### API Layer
The API layer serves as the entry point for clients interacting with the application. It is responsible for handling HTTP requests and responses, and it orchestrates the application's business logic through the Application and Core layers. Below is a detailed documentation of the folders and classes within this layer.

#### Folders and Files

1. **Connected Services**
   - This folder is typically used to manage third-party API connections or services. If no services are         connected, it might be a placeholder and can be reviewed for necessity.

2. **Dependencies**
   - (Assuming "eRepependencies" is a typo) This folder likely holds dependencies specific to the API             layer, such as extensions or helper classes.

3. **Properties**
   - Contains settings and resources specific to the API project, such as application settings or resource       files.

4. **Controllers**
   - AuthController.cs: Handles authentication-related endpoints, such as login and registration.
   
5. **Extensions**
   - **GlobalExceptionHandlerMiddleware.cs**: Manages global exception logging and handling, ensuring             consistent error responses.
   - **MediatRServiceExtensions.cs**: Provides extensions for setting up MediatR services within the API          layer.
     
6. **Filters**
   - Contains action filters or other filters used to modify the behavior of MVC controllers and actions.

7. **appsetting.json**
   - Holds configuration settings for the application, including environment-specific settings.

9. **BaseApiController**
   - (Corrected from "BaseAPlController.cs") Serves as the base class for API controllers, providing             common functionality and response formatting.

10. **ExceptionLogger**  
  - just an empty class to pass the generic ILogger<T> class

#### Interaction with Other Layers
- **Application Layer** : The API layer interacts with the Application layer through MediatR requests and responses, encapsulating business logic.

- **Core Layer** : Indirectly interacts with the Core layer via the Application layer, ensuring separation of concerns.

- **Infrastructure Layer** : Should not directly depend on the Infrastructure layer, promoting a clean architecture.

#### Best Practices and Patterns
- **Dependency Injection** : Utilized for managing service lifetimes and dependencies.

- **Middleware** : Used for global exception handling and other cross-cutting concerns.

- **Base Controller**: Provides a common base class for API controllers, promoting code reuse and               consistency.

#### Conclusion
The API layer is designed to be a thin layer that primarily handles HTTP requests and delegates business logic to the Application and Core layers. By documenting each component, we ensure clarity on their roles and how they contribute to the overall architecture. This documentation should be expanded with code snippets and examples as part of the full project documentation.
