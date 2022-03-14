using Microsoft.AspNetCore.Mvc;

namespace Importify.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImportifyController : Controller
    {
        public IActionResult Index()
        {
            return null;
        }
    }
}
