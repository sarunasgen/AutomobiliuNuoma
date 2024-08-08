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
        private readonly IDarbuotojaiService _darbuotojaiService;

        private List<Automobilis> VisiAutomobiliai = new List<Automobilis>();
        
        private List<NuomosUzsakymas> VisiUzsakymai = new List<NuomosUzsakymas>();

        public AutonuomosService(IKlientaiService klientaiService, IAutomobiliaiService automobiliaiService, IDarbuotojaiService darbuotojaiService)
        {
            _automobiliaiService = automobiliaiService;
            _klientaiService = klientaiService;
            _darbuotojaiService = darbuotojaiService;
        }

        public async Task<List<Automobilis>> GautiVisusAutomobilius()
        {
            if(VisiAutomobiliai.Count == 0)
                VisiAutomobiliai = await _automobiliaiService.GautiVisusAutomobilius();
            return VisiAutomobiliai;
        }

        public void PridetiNaujaAutomobili(Automobilis automobilis)
        {
            _automobiliaiService.PridetiAutomobili(automobilis);
        }

        public List<Klientas> GautiVisusKlientus()
        {
            return _klientaiService.GautiVisusKlientus();
        }
        public async Task<List<Elektromobilis>> GautiVisusElektromobilius()
        {
            return await _automobiliaiService.GautiVisusElektromobilius();
        }
        public List<NaftosKuroAutomobilis> GautiVisusNaftosKuroAuto()
        {
            return _automobiliaiService.GautiVisusNaftosKuroAuto();
        }
        public void SukurtiNuoma(string klientoVardas, string klientoPavarde, int autoId, DateTime nuomosPradzia, int dienos)
        {
            Klientas klientas = _klientaiService.PaieskaPagalVardaPavarde(klientoVardas, klientoPavarde);

            Automobilis automobilis = new Automobilis();
            
            foreach(Automobilis a in VisiAutomobiliai)
            {
                if (a.Id == autoId)
                    automobilis = a;
            }

            NuomosUzsakymas nuomosUzsakymas = new NuomosUzsakymas
            {
                Uzsakovas = klientas,
                NuomuojamasAuto = automobilis,
                NuomosPradzia = nuomosPradzia,
                DienuKiekis = dienos
            };
            VisiUzsakymai.Add(nuomosUzsakymas);
        }
        public void PridetiDarbuotoja(Darbuotojas darbuotojas)
        {
            _darbuotojaiService.PridetiDarbuotoja(darbuotojas);
        }
        public List<Darbuotojas> GautiVisusDarbuotojus()
        {
            return _darbuotojaiService.GautiDarbuotojus();
        }
        public Darbuotojas GautiDarbuotojaPagalId(int id)
        {
            return _darbuotojaiService.GautiDarbuotojaPagalId(id);
        }

        public void AtnaujintiAutomobili(Automobilis automobilis)
        {
            if (automobilis is Elektromobilis)
                _automobiliaiService.AtnaujintiElektromobili((Elektromobilis)automobilis);
            else
            {
                //NaftosKuro automobilio atnaujinimas
            }

        }

    }
}
