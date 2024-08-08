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
        private readonly IMongoDbCacheRepository _mongoCache;
        public DarbuotojaiService(IDarbuotojaiRepository darbuotojaiRepository, IMongoDbCacheRepository mongoDbCache)
        {
            _darbuotojaiRepository = darbuotojaiRepository;
            _mongoCache = mongoDbCache;
        }

        public Darbuotojas GautiDarbuotojaPagalId(int darbuotojoId)
        {
            Darbuotojas result;
            if ((result = _mongoCache.GautiDarbuotojaPagalId(darbuotojoId).Result) != null)
                return result;
            result = _darbuotojaiRepository.GautiDarbuotojaPagalId(darbuotojoId);
            _mongoCache.PridetiDarbuotoja(result);
            return result;
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
