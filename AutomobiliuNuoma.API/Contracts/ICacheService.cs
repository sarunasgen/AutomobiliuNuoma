using AutomobiliuNuoma.Core.Models;

namespace AutomobiliuNuoma.API.Contracts
{
    public interface ICacheService
    {
        void AddElektromobilisToCache(Elektromobilis ev);
        Elektromobilis GetElektromobilisByIdFromCache(int id);
    }
}
