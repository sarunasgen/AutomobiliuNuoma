using AutomobiliuNuoma.Core.Models;

namespace AutomobiliuNuoma.Core.Contracts
{
    public interface IMongoDbCacheRepository
    {
        Task PridetiDarbuotoja(Darbuotojas darbuotojas);
        Task<Darbuotojas> GautiDarbuotojaPagalId(int id);
    }
}