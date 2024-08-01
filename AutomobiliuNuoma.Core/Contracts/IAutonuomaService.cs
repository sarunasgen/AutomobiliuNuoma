using AutomobiliuNuoma.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Core.Contracts
{
    public interface IAutonuomaService
    {
        void PridetiNaujaAutomobili(Automobilis automobilis);
        List<Automobilis> GautiVisusAutomobilius();
        List<Klientas> GautiVisusKlientus();
        void SukurtiNuoma(string klientoVardas, string klientoPavarde, int autoId, DateTime nuomosPradzia, int dienos);
        List<Elektromobilis> GautiVisusElektromobilius();
        List<NaftosKuroAutomobilis> GautiVisusNaftosKuroAuto();
        void PridetiDarbuotoja(Darbuotojas darbuotojas);
        Darbuotojas GautiDarbuotojaPagalId(int id);
        List<Darbuotojas> GautiVisusDarbuotojus();
        void AtnaujintiAutomobili(Automobilis automobilis);
    }
}
