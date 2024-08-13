using AutomobiliuNuoma.Core.Contracts;
using AutomobiliuNuoma.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomobiliuNuoma.FrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IAutonuomaService _autonuomaService;
        public int RandomNumber;
        public List<Elektromobilis> Elektromobiliai;
        public IndexModel(IAutonuomaService autonuomaService)
        {
            _autonuomaService = autonuomaService;
        }

        public void OnGet()
        {
            Random r = new Random();
            RandomNumber = r.Next(1, 99999);
            Elektromobiliai = _autonuomaService.GautiVisusElektromobilius().Result;
        }
    }
}
