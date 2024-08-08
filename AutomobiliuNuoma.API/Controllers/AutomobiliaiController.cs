using AutomobiliuNuoma.API.Contracts;
using AutomobiliuNuoma.Core.Contracts;
using AutomobiliuNuoma.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutomobiliuNuoma.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutomobiliaiController : ControllerBase
    {
        private readonly IAutonuomaService _autonuomaService;
        private readonly ICacheService _cache;

        public AutomobiliaiController(IAutonuomaService autonuomaService, ICacheService cacheService)
        {
            _autonuomaService = autonuomaService;
            _cache = cacheService;
        }

        [HttpGet(Name = "GautiVisusElektromobilius")]
        public async Task<IActionResult> Index()
        {
            var visiEv = await _autonuomaService.GautiVisusElektromobilius();
            return Ok(visiEv);
        }

        [HttpGet("GautiElektromobiliPagalId")]
        public async Task<IActionResult> GautiElektromobiliPagalId(int id)
        {
            var ev = _cache.GetElektromobilisByIdFromCache(id);
            if (ev != null)
                return Ok(ev);

            var visiEv = await _autonuomaService.GautiVisusElektromobilius();
            foreach(Elektromobilis e in visiEv)
            {
                _cache.AddElektromobilisToCache(e);
            }
            foreach(Elektromobilis a in visiEv)
            {
                if (a.Id == id)
                    return Ok(a);
            }

            return NotFound();
        }
        [HttpGet("GautiElektromobiliPagalIdBeStatuso")]
        public async Task<Elektromobilis> GautiElektromobiliPagalIdBeStatuso(int id)
        {
            var ev = _cache.GetElektromobilisByIdFromCache(id);
            if (ev != null)
                return ev;

            var visiEv = await _autonuomaService.GautiVisusElektromobilius();
            foreach (Elektromobilis e in visiEv)
            {
                _cache.AddElektromobilisToCache(e);
            }
            foreach (Elektromobilis a in visiEv)
            {
                if (a.Id == id)
                    return a;
            }

            return null;
        }
        [HttpPost("PridetiElektromobili")]
        public IActionResult GautiElektromobiliPagalId(Elektromobilis ev)
        {
            try
            {
                _autonuomaService.PridetiNaujaAutomobili(ev);
                return Ok();
            }
            catch
            {
                return Problem();
            }
            
        }
    }
}
