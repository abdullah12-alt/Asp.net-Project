#### **What are DTOs?**  
- DTOs are objects used to transfer data between layers of an application.  
- They are simplified versions of domain models containing only necessary properties.  
- Commonly used for transferring data over networks or between application layers.  

#### **Why use DTOs?**  
1. **Separation of Concerns**  
   - Domain objects are tightly coupled with the database schema.  
   - DTOs provide an abstraction, matching business requirements rather than internal data models.  

2. **Performance**  
   - Send only the required data to improve application efficiency.  
   - Example: Instead of sending all region data, only send the region name if needed.  

3. **Security**  
   - Reduces the risk of exposing sensitive data by limiting client-facing information.  

4. **Versioning**  
   - Enables independent versioning of the API and the domain model.  
   - Prevents breaking changes for existing clients when domain models evolve.  

#### **How are DTOs used in applications?**  
- Domain models are fetched using tools like **Entity Framework Core**, which maps database tables to domain objects.  
- These domain models are then **mapped** to DTOs to expose only the required information to clients.  
- When receiving data from the client, DTOs are mapped back into domain models for database operations.  

#### **Benefits Recap**  
- Promotes **separation of concerns** between layers.  
- Enhances **performance** by minimizing unnecessary data transfer.  
- Improves **security** by reducing exposed sensitive data.  
- Facilitates **API versioning** without breaking client integrations.  


### **DTO (Data Transfer Object) in ASP.NET Core**
#### **1. Importance of DTOs**
- DTOs help in decoupling the domain model from the API's view layer.
- Directly returning domain models from the API is a bad practice because it tightly couples internal models with the API response.
- Instead, convert domain models to DTOs before returning them to the client.

#### **2. Steps to Implement DTOs**
1. **Retrieve Data from Database**
   - Fetch data as domain models.
   
2. **Convert Domain Models to DTOs**
   - Create a DTO folder in the project.
   - Define a DTO class that includes only the necessary properties.
   - Copy relevant properties from the domain model to the DTO.

3. **Return DTOs to the Client**
   - Instead of returning domain models, return the transformed DTOs.
   - This ensures better security, flexibility, and maintainability.

---

### **3. Creating a DTO in ASP.NET Core**
#### **Step 1: Create a DTO Class**
- Inside the **Models** folder, create a **DTOs** subfolder.
- Add a new class `RegionDTO.cs` with the required properties.

```csharp
public class RegionDTO
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string RegionImageUrl { get; set; }
}
```

---

#### **Step 2: Modify Controller to Use DTOs**
- Convert the domain model into a DTO before sending a response.

```csharp
[HttpGet]
public IActionResult GetAllRegions()
{
    // Get data from database
    var regionsDomain = _dbContext.Regions.ToList();

    // Convert domain models to DTOs
    var regionsDTO = regionsDomain.Select(region => new RegionDTO
    {
        Id = region.Id,
        Code = region.Code,
        Name = region.Name,
        RegionImageUrl = region.RegionImageUrl
    }).ToList();

    // Return DTOs to client
    return Ok(regionsDTO);
}
```

---

#### **Step 3: Apply DTOs to GetById Method**
- Ensure single-object retrieval also follows DTO conversion.

```csharp
[HttpGet("{id}")]
public IActionResult GetRegionById(Guid id)
{
    var regionDomain = _dbContext.Regions.FirstOrDefault(r => r.Id == id);

    if (regionDomain == null)
        return NotFound();

    var regionDTO = new RegionDTO
    {
        Id = regionDomain.Id,
        Code = regionDomain.Code,
        Name = regionDomain.Name,
        RegionImageUrl = regionDomain.RegionImageUrl
    };

    return Ok(regionDTO);
}
```

---

### **4. Benefits of Using DTOs**
✅ **Decouples API from internal models** – Prevents exposing unnecessary data.  
✅ **Security** – Hides sensitive domain model properties from API responses.  
✅ **Flexibility** – Allows modification of API responses without affecting domain models.  
✅ **Separation of Concerns** – Keeps domain logic separate from API response handling.  


### **Creating a New Action Method to Add a Region in the Database**  

#### **1. Introduction**  
- The goal is to create a new action method to add a region to the database using `DbContext`.  
- The method will be a **POST** request, as POST is typically used for resource creation.  

#### **2. Creating the Action Method**  
- Define a new action method:  
  ```csharp
  public IActionResult Create() { }
  ```  
- Annotate it with `[HttpPost]` to specify it's a POST request.  
- The method will receive data from the client in JSON format (via Swagger or another API client).  

#### **3. Using DTO for Data Transfer**  
- Instead of directly using the domain model, a **Data Transfer Object (DTO)** will be created.  
- The DTO will include:  
  - `Code`  
  - `Name`  
  - `RegionImageUrl`  
- The **ID** will be generated internally by the application.  

#### **4. Creating the DTO Class**  
- A new DTO class (`AddRegionRequestDTO`) will be created inside the `DTO` folder.  
- The properties from the domain model will be copied into the DTO.  

#### **5. Receiving Data in the Controller**  
- The controller method will receive data from the client using `[FromBody]`:  
  ```csharp
  public IActionResult Create([FromBody] AddRegionRequestDTO request)
  ```  
- `[FromBody]` is used because POST requests send data in the request body.  

#### **6. Mapping DTO to Domain Model**  
- Convert DTO data into the **Domain Model**:  
  ```csharp
  var regionDomainModel = new Region
  {
      Code = request.Code,
      Name = request.Name,
      RegionImageUrl = request.RegionImageUrl
  };
  ```  

#### **7. Adding Data to the Database**  
- Use `DbContext` to add the new region:  
  ```csharp
  _dbContext.Regions.Add(regionDomainModel);
  ```  
- However, this **alone won’t save the data**.  

#### **8. Saving Changes to the Database**  
- Call `SaveChanges()` to persist the data:  
  ```csharp
  _dbContext.SaveChanges();
  ```  
- Without this, the entry won't be created in the database.  

#### **9. Returning a Response**  
- Instead of returning `Ok()` (HTTP 200), return `CreatedAtAction()` (HTTP 201) to follow RESTful conventions:  
  ```csharp
  return CreatedAtAction(nameof(GetRegion), new { id = regionDomainModel.Id }, regionDomainModel);
  ```  
- This response includes the newly created resource and its location.  

### **Summary**  
- Defined a **POST** method for region creation.  
- Used a **DTO** to handle client data.  
- Mapped the **DTO** to the **Domain Model**.  
- Used `DbContext.Add()` to insert data.  
- Called `SaveChanges()` to commit to the database.  
- Returned `CreatedAtAction()` for a proper RESTful response.  

**Updating a Resource in ASP.NET Core**

1. **Progress Recap:**
   - Completed GET and POST functionalities.
   - Now moving on to the PUT (update) operation.

2. **Objective:**
   - Update an existing region in the database using `DbContext`.

3. **Creating the Update Method:**
   - Define an action method for updating a region.
   - Use HTTP PUT for updating.
   - The endpoint will be `/api/regions/{id}`.
   - Extract the region `ID` from the route.
   - Extract new region data from the request body.

4. **Method Definition:**
   - Define a `public IActionResult Update` method.
   - Annotate with `[HttpPut]`.
   - Accept `ID` from the route using `[FromRoute]`.
   - Accept updated region data from the body using `[FromBody]`.

5. **Creating Update DTO:**
   - Define `UpdateRegionRequestDTO`.
   - Only include properties that can be updated.
   - Exclude `ID` since it is immutable.

6. **Validating the Region Exists:**
   - Use `dbContext.Regions.FirstOrDefault(x => x.Id == ID)` to find the region.
   - If the region does not exist, return `NotFound()`.

7. **Updating the Region:**
   - If the region exists, update the properties.
   - Save changes using `dbContext.SaveChanges()`.
   - Return an appropriate response.

8. **Business Logic Considerations:**
   - Ensure type safety by enforcing GUID as the ID type.
   - Only allow modification of specific fields as per business requirements.
   - Return a proper status code indicating success or failure.

**Conclusion:**
   - Successfully implemented the update functionality.
   - Next steps may involve further validation and error handling.


### **Delete Method in ASP.NET Core Web API**  

1. **Purpose**  
   - Implements the DELETE method to remove a region from the database.  

2. **Route & HTTP Verb**  
   - Uses `[HttpDelete("{id}")]` annotation.  
   - The `id` parameter is passed in the URL as a GUID.  

3. **Method Structure**  
   - Defines `public IActionResult Delete(Guid id)`.  
   - Uses `[FromRoute]` to bind the `id`.  

4. **Check if Region Exists**  
   - Queries the database using `FirstOrDefault(x => x.Id == id)`.  
   - If `null`, returns `NotFound()`.  

5. **Delete Operation**  
   - Calls `DbContext.Regions.Remove(region)`.  
   - Saves changes with `DbContext.SaveChanges()`.  

6. **Response**  
   - Returns `Ok()` (empty or with deleted object).  
   - Optionally maps and returns the deleted region as a DTO.  

7. **Testing with Swagger**  
   - Expands the DELETE method in Swagger UI.  
   - Provides an ID from the GET method to delete a region.  
   - Confirms deletion by checking the database.  

8. **Handling Errors**  
   - If the region doesn’t exist, returns `404 Not Found`.  

9. **CRUD Operations Completion**  
   - The DELETE method completes the full CRUD cycle (Create, Read, Update, Delete).  

