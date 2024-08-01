using AutomobiliuNuoma.Core.Contracts;
using AutomobiliuNuoma.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Core.Services
{
    public class DarbuotojaiService : IDarbuotojaiService
    {
        private readonly IDarbuotojaiRepository _darbuotojaiRepository;
        public DarbuotojaiService(IDarbuotojaiRepository darbuotojaiRepository)
        {
            _darbuotojaiRepository = darbuotojaiRepository;
        }

        public Darbuotojas GautiDarbuotojaPagalId(int darbuotojoId)
        {
            return _darbuotojaiRepository.GautiDarbuotojaPagalId(darbuotojoId);
        }

        public List<Darbuotojas> GautiDarbuotojus()
        {
            return _darbuotojaiRepository.GautiDarbuotojus();
        }

        public void PridetiDarbuotoja(Darbuotojas darbuotojas)
        {
            _darbuotojaiRepository.PridetiDarbuotoja(darbuotojas);
        }
    }
}
