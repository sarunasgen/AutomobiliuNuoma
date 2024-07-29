using AutomobiliuNuoma.Core.Contracts;
using AutomobiliuNuoma.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Core.Services
{
    public class AutonuomosService : IAutonuomaService
    {
        private readonly IKlientaiService _klientaiService;
        private readonly IAutomobiliaiService _automobiliaiService;

        private List<Automobilis> VisiAutomobiliai = new List<Automobilis>();

        public AutonuomosService(IKlientaiService klientaiService, IAutomobiliaiService automobiliaiService)
        {
            _automobiliaiService = automobiliaiService;
            _klientaiService = klientaiService;
        }

        public List<Automobilis> GautiVisusAutomobilius()
        {
            return _automobiliaiService.GautiVisusAutomobilius();
        }

        public void PridetiNaujaAutomobili(Automobilis automobilis)
        {
            _automobiliaiService.PridetiAutomobili(automobilis);
        }

    }
}
