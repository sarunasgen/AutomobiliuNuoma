using AutomobiliuNuoma.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using AutomobiliuNuoma.Core.Contracts;

namespace AutomobiliuNuoma.Core.Repositories
{
    public class MongoDbCacheRepository : IMongoDbCacheRepository
    {
        private IMongoCollection<Darbuotojas> _darbuotojaiCache;

        public MongoDbCacheRepository(IMongoClient mongoClient)
        {
            _darbuotojaiCache = mongoClient.GetDatabase("darbuotojai").GetCollection<Darbuotojas>("darbuotojai_cache");
        }
        public async Task PridetiDarbuotoja(Darbuotojas darbuotojas)
        {
            await _darbuotojaiCache.InsertOneAsync(darbuotojas);
        }
        public async Task<Darbuotojas> GautiDarbuotojaPagalId(int id)
        {
            try
            {
                return (await _darbuotojaiCache.FindAsync<Darbuotojas>(x => x.Id == id)).First();
            }
            catch
            {
                return null;
            }
        }
    }
}
