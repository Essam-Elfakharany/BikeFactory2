*** HOW TO CREATE A VERSION DEFINITION IN A .NET 6 WEB API PROJECT ***
 
Install the Microsoft.AspNetCore.Mvc.Versioning NuGet package in your Web API project
In the Program.cs file, create a WebHostBuilder object and configure the services and middleware for API versioning, like so:
    
    using Microsoft.AspNetCore.Mvc.Versioning;
    
    //...
    
    builder.Services.AddApiVersioning(options =>
    {
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.ApiVersionReader = new HeaderApiVersionReader("X-Version");
    });
 
Organize your controllers into subfolders and namespaces that reflect the versions. This can help keep your code organized and make it easier to maintain as your API grows and changes over time.
    
    Controllers/
        v1/
            MyController.cs
        v2/
            MyController.cs
 
Decorate your controllers and actions with the ApiVersion attribute to indicate the version that they support. In this example, Controllers/v1/MyController.cs supports version 1.0 of the API:
 
    using Microsoft.AspNetCore.Mvc.Versioning;
    
    //...
    
    namespace MyApi.Controllers.v1;
    
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MyController : ControllerBase
    {
        // implementation for version 1
    }
 
In this example, Controllers/v1/MyController.cs supports version 2.0 of the API:
 
    using Microsoft.AspNetCore.Mvc.Versioning;
    
    //...
    
    namespace MyApi.Controllers.v2;
    
    [ApiController]
    [Route("api/v2/[controller]")]
    public class MyController : ControllerBase
    {
        // implementation for version 1
    }