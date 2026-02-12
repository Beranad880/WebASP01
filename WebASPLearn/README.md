# WebASPLearn - User Management REST API

This project is a simple RESTful API built with ASP.NET Core that allows for managing user data, including name, surname, address, email, and phone number. It uses MongoDB as its database.

## Features

- **Create User:** Add new user records to the database.
- **Read Users:** Retrieve a list of all users or a specific user by ID.
- **Update User:** Modify existing user records.
- **Delete User:** Remove user records from the database.
- **MongoDB Integration:** Persistent storage of user data using MongoDB.

## Technologies Used

-   **.NET 10.0 (ASP.NET Core):** The framework for building the web API.
-   **MongoDB:** NoSQL database used for storing user information.
-   **MongoDB.Driver:** C# driver for interacting with MongoDB.

## Prerequisites

Before running this project, ensure you have the following installed:

-   **.NET SDK 10.0** (or compatible version, e.g., 8.0 if `net10.0` was a placeholder).
-   **MongoDB Instance:** A running MongoDB server, accessible at `mongodb://localhost:27017`.

## Setup

Follow these steps to get the project up and running on your local machine:

1.  **Clone the repository:**
    ```bash
    git clone <repository_url>
    cd WebASPLearn
    ```

2.  **Restore NuGet packages:**
    ```bash
    dotnet restore
    ```

3.  **Ensure MongoDB is running:**
    Start your MongoDB instance. The API expects it to be running on `mongodb://localhost:27017`.

## Configuration

The MongoDB connection settings are configured in `appsettings.json`:

```json
{
  // ... other settings
  "MongoDBSettings": {
    "ConnectionString": "mongodb://localhost:27017/",
    "DatabaseName": "data",
    "UsersCollectionName": "Users"
  }
}
```

-   `ConnectionString`: The connection string for your MongoDB instance.
-   `DatabaseName`: The name of the database to use (currently `data`).
-   `UsersCollectionName`: The name of the collection where user data will be stored (currently `Users`).

You can modify these values if your MongoDB setup is different.

## Running the Application

To start the API, navigate to the `WebASPLearn` directory (where the `.csproj` file is located) and run:

```bash
dotnet run
```

The API will typically run on `https://localhost:70XX` and `http://localhost:50XX` (the specific port numbers will be displayed in the console when you run the application).

## API Endpoints

All API endpoints are prefixed with `/api/Users`.

### 1. Get all Users

-   **URL:** `/api/Users`
-   **Method:** `GET`
-   **Response:** `200 OK`
    ```json
    [
      {
        "id": "60c72b2f9b1e8b001f3e4e5e",
        "name": "John",
        "surname": "Doe",
        "address": "123 Main St",
        "email": "john.doe@example.com",
        "phone": "555-1234"
      },
      // ... more users
    ]
    ```

### 2. Get User by ID

-   **URL:** `/api/Users/{id}`
-   **Method:** `GET`
-   **Parameters:**
    -   `id` (string, path parameter): The unique ID of the user (24-character hexadecimal string).
-   **Response:** `200 OK` (if user found) or `404 Not Found`
    ```json
    {
      "id": "60c72b2f9b1e8b001f3e4e5e",
      "name": "John",
      "surname": "Doe",
      "address": "123 Main St",
      "email": "john.doe@example.com",
      "phone": "555-1234"
    }
    ```

### 3. Create a new User

-   **URL:** `/api/Users`
-   **Method:** `POST`
-   **Request Body (JSON):**
    ```json
    {
      "name": "Jane",
      "surname": "Smith",
      "address": "456 Oak Ave",
      "email": "jane.smith@example.com",
      "phone": "555-5678"
    }
    ```
-   **Response:** `201 Created` with the new user's details and `Location` header.
    ```json
    {
      "id": "60c72b2f9b1e8b001f3e4e5f",
      "name": "Jane",
      "surname": "Smith",
      "address": "456 Oak Ave",
      "email": "jane.smith@example.com",
      "phone": "555-5678"
    }
    ```

### 4. Update an existing User

-   **URL:** `/api/Users/{id}`
-   **Method:** `PUT`
-   **Parameters:**
    -   `id` (string, path parameter): The unique ID of the user to update.
-   **Request Body (JSON):**
    ```json
    {
      "id": "60c72b2f9b1e8b001f3e4e5e",
      "name": "Johnny",
      "surname": "Doe",
      "address": "789 Pine Ln",
      "email": "john.doe@example.com",
      "phone": "555-9999"
    }
    ```
    *(Note: The `id` in the body is optional and will be overridden by the path parameter `id`.)*
-   **Response:** `204 No Content` (if update successful) or `404 Not Found`.

### 5. Delete a User

-   **URL:** `/api/Users/{id}`
-   **Method:** `DELETE`
-   **Parameters:**
    -   `id` (string, path parameter): The unique ID of the user to delete.
-   **Response:** `204 No Content` (if deletion successful) or `404 Not Found`.
