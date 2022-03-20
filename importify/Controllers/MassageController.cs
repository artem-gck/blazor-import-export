using Importify.Service;
using Importify.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace Importify.Controllers
{
    [Route("api/massage")]
    [ApiController]
    public class MassageController : Controller
    {
        private readonly IMassageUsing _massageUsing;

        public MassageController(IMassageUsing massageService)
            => _massageUsing = massageService;

        [HttpGet]
        public async Task<ActionResult<List<Massage>>> GetMassagesAsync()
            => await _massageUsing.GetMassagesAsync();

        [HttpPost]
        public async Task<ActionResult<int>> AddMassageAsync(Massage massage)
            => await _massageUsing.AddMassageAsync(massage);

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteMassageAsync(Massage massage)
            => await _massageUsing.DeleteMassageAsync(massage);
    }
}
