using AutomobiliuNuoma.Core.Contracts;
using AutomobiliuNuoma.Core.Models;
using AutomobiliuNuoma.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Core.Services
{
    public class AutomobiliaiService : IAutomobiliaiService
    {
        private readonly IAutomobiliaiRepository _automobiliaiRepository;
        public AutomobiliaiService(IAutomobiliaiRepository automobiliaiRepository)
        {
            _automobiliaiRepository = automobiliaiRepository;
        }

        public void AtnaujintiElektromobili(Elektromobilis elektromobilis)
        {
            _automobiliaiRepository.AtnaujintiElektromobili(elektromobilis);
        }

        public async Task<List<Automobilis>> GautiVisusAutomobilius()
        {
            List<Automobilis> visiAutomobiliai = new List<Automobilis>();
            var elektriniai = _automobiliaiRepository.GautiVisusElektromobilius();
            var naftoskuro = _automobiliaiRepository.GautiVisusNaftosKuroAutomobilius();
            await Task.WhenAll(elektriniai, naftoskuro);
            ///
            
            return null;
            //..
        }
        public async Task<List<Elektromobilis>> GautiVisusElektromobilius()
        {
            return await _automobiliaiRepository.GautiVisusElektromobilius();
        }
        public List<NaftosKuroAutomobilis> GautiVisusNaftosKuroAuto()
        {
            return _automobiliaiRepository.GautiVisusNaftosKuroAutomobilius().Result;
        }

        public void IrasytiIFaila()
        {
            throw new NotImplementedException();
        }

        public void NuskaitytiIsFailo()
        {
            throw new NotImplementedException();
        }

        public List<Automobilis> PaieskaPagalMarke(string marke)
        {
            List<Automobilis> paieskosRezultatai = new List<Automobilis>();
            List<Automobilis> automobiliai = _automobiliaiRepository.NuskaitytiAutomobilius();
            foreach(Automobilis a in automobiliai)
            {
                if (a.Marke == marke)
                    paieskosRezultatai.Add(a);
            }
            return paieskosRezultatai;
        }

        public void PridetiAutomobili(Automobilis automobilis)
        {
            if (automobilis is Elektromobilis)
                _automobiliaiRepository.IrasytiElektromobili((Elektromobilis)automobilis);
            else
                _automobiliaiRepository.IrasytiNaftosKuroAutomobilis((NaftosKuroAutomobilis)automobilis);
        }
    }
}
