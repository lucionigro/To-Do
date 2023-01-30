using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_tareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : Controller
    {

        [HttpGet]
        public string Get()
        {
            return "aplicacion corriendo...";
        }       
    }
}
