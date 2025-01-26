## GUID (Globally Unique Identifier)
In .NET, a GUID (Globally Unique Identifier) is a 128-bit unique ID often used as a primary key in databases to ensure uniqueness across systems. In databases, 
it’s stored as a uniqueidentifier, ideal for distributed systems but slower to index than integers


### Key Concepts of Domain in ASP.NET Core

1. **Domain Models**:
   - Represent the core business entities of your application (e.g., "User", "Product", "Order").
   - They are plain C# classes with properties defining their data structure.

2. **Organizing Domain Models**:
   - Create a dedicated **Models folder** to keep them organized.
   - Inside this folder, you can have subfolders (e.g., `Domain`) to group domain-specific models.

3. **Properties of Domain Models**:
   - Define properties to store data (e.g., `ID`, `Name`, `Description`).
   - Use **data types** like `string`, `int`, `Guid`, and mark properties as nullable (e.g., `string?`) if they can have null values.

4. **Relationships Between Models**:
   - Domain models often relate to each other (e.g., a "Product" belongs to a "Category").
   - Use **IDs** to create relationships (e.g., `CategoryId` in the "Product" model links it to a "Category" model).

5. **Nullable Properties**:
   - Properties that can be null (e.g., optional fields like `ImageURL`) are marked with `?` for flexibility.

6. **Purpose of Domain Models**:
   - Capture and reflect the business logic or real-world entities that your application deals with.
   - Serve as a foundation for data persistence and interaction with the database.

### Why Domain Models Matter:
- They provide **structure** and clarity for your application.
- Simplify database operations by acting as a blueprint for tables.
- Support creating relationships and managing data constraints effectively. 

This organization ensures scalability and maintainability in your ASP.NET Core application.


###  Installing Entity Framework in ASP.NET Core

1. **Purpose of Entity Framework (EF)**:
   - EF allows seamless communication between the application and a **SQL Server database**.
   - It simplifies data manipulation through an **Object-Relational Mapper (ORM)**.

2. **NuGet Packages Installation**:
   - Use **NuGet Package Manager** to install the required packages for Entity Framework.
   - The packages installed:
     - **Microsoft.EntityFrameworkCore.SqlServer**: Enables EF to work with SQL Server databases.
     - **Microsoft.EntityFrameworkCore.Tools**: Provides tools for managing migrations and generating database schemas.

3. **Steps to Install EF Packages**:
   - Right-click on the **Dependencies** folder in your project.
   - Select **Manage NuGet Packages**.
   - In the **Browse** tab, search for the following packages:
     1. **Microsoft.EntityFrameworkCore.SqlServer**
     2. **Microsoft.EntityFrameworkCore.Tools**
   - Select each package and click **Install**.

4. **Verify Installation**:
   - After installation, a green checkmark confirms that the package is installed successfully.

5. **Next Steps**:
   - After installing these packages, the next task is to create a **DbContext** class, which acts as the bridge between your application and the database.

These steps lay the groundwork for database integration using Entity Framework.

