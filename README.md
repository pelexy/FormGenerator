## Overview

This project demonstrates a generic repository pattern using Azure Cosmos DB. It provides a reusable and scalable approach to interact with Cosmos DB, using C# and .NET, leveraging the following technologies and concepts:
- **Generics** for type-safe operations
- **Refit** for making HTTP requests
- **Minimal APIs** for lightweight, efficient endpoints
- **Polly** for resilience and transient fault handling

## Stack

- **C#**: The primary programming language used in the project.
- **.NET**: The framework used for building and running the application.
- **Azure Cosmos DB**: The database service used for storing and retrieving data.

## Design Pattern

The project follows the **Repository Pattern**, which abstracts the data access layer and provides a flexible way to manage CRUD operations. This pattern helps to achieve:
- Loose coupling between the data access layer and business logic.
- Easy testing and maintenance.
- Enhanced scalability and code reuse.

## Database

Azure Cosmos DB is a globally distributed, multi-model database service. The project uses it for its scalability, low latency, and high availability. The Cosmos DB container is designed to store documents, with each document representing an entity.

## Generics

The use of generics allows the repository to handle different types of entities without repeating the same code. This ensures type safety and reduces redundancy.

```csharp
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    // Implementation details
} 
