using AutomobiliuNuoma.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Core.Services
{
    public class KlientaiService : IKlientaiService
    {
        private readonly IKlientaiRepository _klientaiRepository;
        public KlientaiService(IKlientaiRepository klientaiRepository)
        {
            _klientaiRepository = klientaiRepository;
        }
    }
}
