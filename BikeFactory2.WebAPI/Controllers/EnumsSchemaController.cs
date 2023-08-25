using BikeFactory2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeFactory2.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumsSchemaController : ControllerBase
    {
        [HttpGet]
        public ActionResult<EnumSchema> GetEnumSchemas()
        {
            return new EnumSchema();
        }

    }

}

