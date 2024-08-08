using AutomobiliuNuoma.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AutomobiliuNuoma.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DarbuotojaiController : ControllerBase
    {
        private readonly IDarbuotojaiService _darbuotojaiService;
        public DarbuotojaiController(IDarbuotojaiService darbuotojaiService)
        {
            _darbuotojaiService = darbuotojaiService;
        }
        [HttpGet("GautiDarbuotojaPagalId")]
        public IActionResult GautiDarbuotojaPagalId(int id)
        {
            return Ok(_darbuotojaiService.GautiDarbuotojaPagalId(id));
        }
    }
}
