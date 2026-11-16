# GownRental – Rental Shop Management API

A REST API for managing a rental shop: the model catalog, customers, rentals, and appointment scheduling. Built with ASP.NET Core 8 in a layered architecture.

## Features

- Catalog management: create, read, update and delete models, with color, description, sizes, prices and availability
- Appointment scheduling: list all appointments, look one up by ID, filter by date, and find the available slots for a date
- Customers and rentals modeled with Entity Framework Core, including rental and event dates
- Swagger UI for exploring and testing the API in development

## Architecture

The solution is split into layers, each depending only on the one below it:

```
GownRental.sln
├── Server/   # ASP.NET Core Web API: controllers, Swagger, dependency injection
├── Bl/       # Business logic: services and API-facing models
├── Dal/      # Data access: EF Core entities, DbContext and data services
└── Ui/       # Console client (placeholder)
```

Each layer exposes interfaces (`IBl`, `IDal`) that are registered in the dependency injection container, so the controllers never touch the database directly.

## Tech stack

- C# and .NET 8
- ASP.NET Core Web API
- Entity Framework Core 8
- SQL Server (LocalDB)
- Swagger (Swashbuckle)

## API

**Appointments** – `api/Appointment`

| Method | Route | Description |
| --- | --- | --- |
| GET | `/api/Appointment` | All appointments with full details |
| GET | `/api/Appointment/{id}` | One appointment by ID |
| GET | `/api/Appointment/getByDate/{date}` | Appointments on a date |
| GET | `/api/Appointment/getAvailableAppointments/{date}` | Available slots on a date |
| POST | `/api/Appointment` | Create an appointment |
| DELETE | `/api/Appointment/{id}` | Delete an appointment |

**Models** – `GownModel`

| Method | Route | Description |
| --- | --- | --- |
| GET | `/GownModel` | All models |
| GET | `/GownModel/{id}` | One model by ID |
| POST | `/GownModel` | Add a model |
| PUT | `/GownModel/{id}` | Update a model |
| DELETE | `/GownModel/{id}` | Delete a model |

## Getting started

### Prerequisites

- .NET 8 SDK
- SQL Server LocalDB (installed with Visual Studio)

### Run

1. Clone the repository and open `GownRental.sln` in Visual Studio.
2. Update the connection string in `Dal/Models/DataManager.cs` so that it points to the database on your machine.
3. Set `Server` as the startup project and run it.
4. Open the Swagger UI at `/swagger` to try the endpoints.

Or from the command line:

```bash
dotnet run --project Server
```
