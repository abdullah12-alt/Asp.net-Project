
1. **Groundwork Recap**: The lecture builds on previous work setting up Entity Framework Core.

2. **Migrations Overview**:
   - Migrations in Entity Framework Core help translate C# models into SQL tables and relationships in the database.

3. **Opening Package Manager Console**:
   - Navigate to **Tools > NuGet Package Manager > Package Manager Console** in Visual Studio.

4. **Add-Migration Command**:
   - Run `Add-Migration "InitialMigration"` in the console.
   - This generates a `Migrations` folder containing the migration file, with `Up` and `Down` methods defining the schema changes.

5. **Update-Database Command**:
   - Execute `Update-Database` to apply the migration, creating the database and its schema.
   - The command connects to the database, checks for missing elements, and creates tables, columns, and relationships based on the migration file.

6. **Confirmation in SQL Server**:
   - Refresh the SQL Server database to verify the new database (`NZ Walks DB`) and its tables.

7. **DB Context Mapping**:
   - The DB context class maps domain models to SQL tables, enabling CRUD operations.

8. **Next Steps**:
   - Implement a controller and action methods for performing operations like retrieving or adding walks.

