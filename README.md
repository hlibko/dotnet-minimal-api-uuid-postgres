# Minimal API with PostgreSQL and UUID in .NET 8

This is a sample ASP.NET Core Minimal API project using Entity Framework Core, PostgreSQL, and automatic UUID generation (via `gen_random_uuid()` from the `pgcrypto` extension).  
It includes a properly configured migration setup and a complete CRUD implementation for the `User` entity.

## Automatic UUID Generation

This project uses PostgreSQL’s `pgcrypto` extension to automatically generate UUIDs for new records using the `gen_random_uuid()` function. The `pgcrypto` extension is automatically enabled during the first migration, so no manual database setup is required.

### Why is this useful?

- **Eliminates manual ID management:** The application doesn’t need to generate or track unique IDs, reducing code complexity and potential bugs.
- **Ensures global uniqueness:** UUIDs are designed to be universally unique, which prevents collisions even across distributed systems.
- **Improves security and unpredictability:** Unlike sequential integer IDs, UUIDs are difficult to guess or predict, adding an extra layer of security.
- **Supports distributed environments:** UUIDs allow multiple services or instances to create entities independently without ID conflicts.

This approach simplifies backend logic and leverages database-level guarantees for identifier uniqueness and security.

---

## Endpoints

- `POST /users` — create a new user
- `GET /users` — list all users
- `GET /users/{id}` — get user by UUID
