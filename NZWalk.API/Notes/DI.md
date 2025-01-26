
### **Key Concepts of Dependency Injection (DI):**
1. **Definition:**
   - DI is a design pattern that increases **maintainability** and **testability** by reducing tight coupling between components.
   - Instead of creating objects directly inside a class, the required dependencies are passed as parameters (to constructors or methods).

2. **Benefits:**
   - Enhances **flexibility** in object creation and management.
   - Simplifies testing by allowing easy replacement of dependencies with mock implementations.
   - Encourages adherence to the **D** in **SOLID** principles (Dependency Inversion Principle).

3. **Built-in DI in ASP.NET Core:**
   - ASP.NET Core provides a built-in **dependency injection container** to manage service lifetimes and resolve dependencies at runtime.
   - Services are registered in the `Program.cs` file, and their lifetimes (e.g., `Singleton`, `Scoped`, `Transient`) are defined during registration.

---

### **Without DI vs. With DI:**
1. **Without DI:**
   - Dependencies (e.g., a service class) are instantiated directly in controllers or classes.
   - Changes to the dependency (e.g., renaming or updating the implementation) require modifications in multiple places.

2. **With DI:**
   - The dependency is registered in the `Program.cs` file.
   - Controllers or classes receive the dependency through **constructor injection** or **method injection**.
   - Changing the implementation is straightforward—update the registration in one place, and the entire application adapts.

---

### **Example of Registering and Using DbContext with DI:**
1. **Injecting `DbContext` in ASP.NET Core:**
   - In `Program.cs`, use the `AddDbContext` method to register the `DbContext` class with the DI container.

   ```csharp
   builder.Services.AddDbContext<NzWalksDbContext>(options =>
   {
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
   });
   ```

2. **Steps Explained:**
   - **Registering `NzWalksDbContext`:**
     - The `AddDbContext` method accepts the type of the `DbContext` to be registered.
     - Options are configured using the `options.UseSqlServer` method.
   - **Using Connection Strings:**
     - The connection string is fetched from the `appsettings.json` file via `builder.Configuration.GetConnectionString`.

3. **Advantages:**
   - All instances of `NzWalksDbContext` are managed by the DI container.
   - If the database or connection string changes, updates can be made in the configuration without modifying the controllers or repositories.

---

### **Usage in Controllers:**
- After registration, the `DbContext` can be injected into controllers or services using **constructor injection**:

   ```csharp
   public class WalksController : ControllerBase
   {
       private readonly NzWalksDbContext _context;

       public WalksController(NzWalksDbContext context)
       {
           _context = context;
       }

       // Actions that use _context
   }
   ```
