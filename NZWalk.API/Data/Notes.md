

1. **What is DbContext?**
   - A class representing a session with the database.
   - Responsible for:
     - Database connection maintenance.
     - Tracking data changes.
     - Performing CRUD operations.
     - Defining database schema through entity/domain classes (which map to database tables).
   - Acts as a bridge between domain models and the database.

2. **How it works in the application architecture:**
   - The controller communicates with the DbContext to interact with the database.

3. **Steps to create a DbContext:**
   - Create a folder (e.g., `Data`).
   - Add a new class (e.g., `NzVoxDbContext`).
   - Inherit the `DbContext` class.
   - Import the `Microsoft.EntityFrameworkCore` namespace.
   - Create a constructor that accepts `DbContextOptions` for later injecting connection strings via `Program.cs`.

4. **Define `DbSet` properties:**
   - `DbSet` represents a collection of entities in the database.
   - For example:
     - `DbSet<Difficulty> Difficulties`
     - `DbSet<Region> Regions`
     - `DbSet<Walk> Walks`
   - These properties will create tables in the database after migrations.

## NzVoxDbContext class, 
which inherits from DbContext (used in Entity Framework Core for database operations).

Here’s what it does:

NzVoxDbContext(DbContextOptions<NzVoxDbContext> dbContextOptions): It takes an options parameter that provides configuration for the database (like the connection string, provider type, etc.).
: base(dbContextOptions): It passes the received options to the base DbContext class, so Entity Framework Core knows how to connect and interact with the database.
In simple terms: This constructor is like passing the "instructions" (how to connect to the database) to your NzVoxDbContext




## Next steps:
1. **Define the Connection String in `appsettings.json`**:
   - Open the `appsettings.json` file and create an object named `ConnectionStrings`.
   - Add a key-value pair for the connection string, e.g., `"NZWalksConnectionString"`.

2. **Structure of the Connection String**:
   - **Server**: Specify the name of the SQL Server instance. You can find it by opening SQL Server Management Studio (SSMS).
   - **Database**: Specify the name of the database to be used. If the database does not exist, it will be created during Entity Framework migrations.
   - Additional fields include:
     - `Trusted_Connection=True` (for Windows Authentication).
     - `TrustServerCertificate=True` (required for .NET 6 and 7 to trust the local server).

3. **Steps to Retrieve Server Name**:
   - Open SSMS and copy the server name of your local SQL Server instance.
   - Test the connection to ensure it works properly.

4. **Example Connection String**:
   ```json
   "ConnectionStrings": {
       "NZWalksConnectionString": "Server=YOUR_SERVER_NAME;Database=NZWalksDB;Trusted_Connection=True;TrustServerCertificate=True"
   }
   ```

5. **Next Steps**:
   - The connection string will be used in the next lecture for injecting the `DbContext` into the application.
   - The `DbContext` will leverage this connection string to interact with the database.

This approach ensures that the application is properly configured to connect to the SQL Server database and sets the stage for further database operations using Entity Framework Core.