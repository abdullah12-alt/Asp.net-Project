

### **Why Use AutoMapper?**
1. **Reduces Redundant Code**: Mapping between domain models and DTOs can often result in repetitive code. AutoMapper simplifies this process, reducing the need to write boilerplate mapping code each time you need to convert between these objects.
   
2. **Improves Readability and Maintainability**: Without AutoMapper, you need to manually write mapping logic in every method where you convert between models. This can clutter your code and make it harder to maintain. With AutoMapper, you can manage all the mappings in one place, improving code organization.

3. **Cleaner Code**: By using AutoMapper, your code will be cleaner and more readable. It reduces the clutter of manually writing mapping logic for every property, which can sometimes be error-prone.

---

<img src= "AutoMapper.png">

---

### **What is AutoMapper?**
AutoMapper is a library that simplifies the mapping of properties between two objects (such as domain models and DTOs). The key features include:
- **Automatic Mapping**: It automatically maps properties that have the same name between two objects.
- **Reverse Mapping**: You can also reverse the mapping direction without manually writing additional mapping logic.
- **Custom Mappings**: If the property names differ or require special handling, AutoMapper lets you define custom mappings explicitly.

---

### **How to Implement AutoMapper?**
Let's go step-by-step:

#### 1. **Install AutoMapper NuGet Package**
   - Open your Visual Studio project.
   - Right-click on **Dependencies** > **Manage NuGet Packages**.
   - Search for `AutoMapper` and install it.
   - AutoMapper helps in reducing the complexity of manual mapping between domain models and DTOs.

#### 2. **Create Mapping Profiles**
   - AutoMapper requires **profiles** where you define how objects should be mapped.
   - A **profile** is a class that inherits from `AutoMapper.Profile` and is used to define the mapping logic.

   Example:
   ```csharp
   public class AutoMapperProfiles : Profile
   {
       public AutoMapperProfiles()
       {
           CreateMap<SourceModel, DestinationModel>(); // Basic mapping between two models.
       }
   }
   ```

#### 3. **Define the Mappings**
   - Inside the profile class, we define mappings using `CreateMap<Source, Destination>()`.
   - **Source** is the object that will be mapped to the **Destination** object.

   Example:
   ```csharp
   CreateMap<UserDTO, UserDomainModel>();
   ```

   - If property names match in both objects, AutoMapper automatically maps them.
   - If property names are different, you need to define **explicit mappings** using `ForMember()`.

#### 4. **Handling Different Property Names**
   - If the source and destination properties have different names, you can explicitly map them using `ForMember()`.

   Example:
   ```csharp
   CreateMap<UserDTO, UserDomainModel>()
       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FullName));
   ```

   - This example maps `FullName` from the `UserDTO` to `Name` in `UserDomainModel`.

#### 5. **Reverse Mapping**
   - AutoMapper allows you to reverse the mapping from `Destination` to `Source` with `.ReverseMap()`.

   Example:
   ```csharp
   CreateMap<UserDTO, UserDomainModel>().ReverseMap();
   ```

   - This will automatically set up both mappings: `UserDTO -> UserDomainModel` and `UserDomainModel -> UserDTO`.

#### 6. **Using AutoMapper in the Controller**
   - After defining mappings in your profile, you can use AutoMapper in the controllers to handle the mapping between models and DTOs.

   Example:
   ```csharp
   var regionDTO = _mapper.Map<RegionDTO>(regionDomainModel);
   ```

   - Here, `_mapper.Map<T>` is used to map `regionDomainModel` to `regionDTO`.

#### 7. **What If Property Names Don’t Match?**
   - If there is a mismatch in property names between the source and destination, you can define the mapping explicitly as shown earlier using `ForMember()`.

---

### **Summary of Key Concepts**

1. **AutoMapper Profiles**: Centralized place where you define your object mappings.
2. **CreateMap()**: Defines how one object maps to another.
3. **ReverseMap()**: Allows reverse mappings between objects.
4. **ForMember()**: Used for custom property mappings when property names differ.
5. **Mapper Configuration**: Involves setting up AutoMapper in `Startup.cs` or the relevant configuration file.

### **Benefits in Real-World Application**
- **Less Code**: AutoMapper eliminates the need for repeated mapping logic in every action method, making the codebase more efficient.
- **Faster Development**: Once you set up AutoMapper, it reduces the time spent writing and maintaining custom mapping logic.
- **Cleaner and Maintainable**: By organizing mappings in a profile, it keeps the application clean and easy to understand.

---

In conclusion, AutoMapper is a powerful tool for mapping between domain models and DTOs. It reduces boilerplate code, making your application easier to maintain and extend.