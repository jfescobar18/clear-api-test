# Movie API

This is a simple ASP.NET Core Web API project for managing movies, actors, and their relationships.

## Introduction

The Movie API is a RESTful web service built using ASP.NET Core. It allows you to manage information about movies, actors, and their relationships.

## Features

- CRUD operations for Movies, Actors, and MovieActor relationships.
- Search functionality to find movies by title or actors.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)
- [Visual Studio Code](https://code.visualstudio.com/) (optional, but recommended) or any other preferred IDE.
- SQL Server or Docker installed for database storage.
- Docker (version 4.26.1 or later)

## Getting Started

1. Clone the repository:

```bash
git clone https://github.com/jfescobar18/clear-api-test.git
clear-api-test
```

2. Start MSSQL Server Container (Ignore if you already have MSSQL on your local)
```bash
docker-compose up -d
```
3. Make sure to update the database connection string in appsettings.json with the correct values.

```json
{
  "ConnectionStrings": {
    "MoviesConnection": "Server=localhost;Database=MoviesDB;User Id=your_username;Password=your_password;"
  }
}
```

4. Start project
```bash
dotnet run
```

5. Open browser on [Localhost](http://localhost:7172)

## ToDo

- Add Tests