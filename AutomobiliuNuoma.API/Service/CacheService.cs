using AutomobiliuNuoma.API.Contracts;
using AutomobiliuNuoma.Core.Models;

namespace AutomobiliuNuoma.API.Service
{
    public class CacheService : ICacheService
    {
        public List<Elektromobilis> Elektromobiliai = new List<Elektromobilis>();

        public void AddElektromobilisToCache(Elektromobilis ev)
        {
            Elektromobiliai.Add(ev);
        }
        public Elektromobilis GetElektromobilisByIdFromCache(int id)
        {
            foreach(Elektromobilis ev in Elektromobiliai)
            {
                if (ev.Id == id)
                    return ev;
            }
            return null;
        }
    }
}
