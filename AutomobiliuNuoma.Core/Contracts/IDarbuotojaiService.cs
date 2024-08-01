using AutomobiliuNuoma.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Core.Contracts
{
    public interface IDarbuotojaiService
    {
        void PridetiDarbuotoja(Darbuotojas darbuotojas);
        List<Darbuotojas> GautiDarbuotojus();
        Darbuotojas GautiDarbuotojaPagalId(int darbuotojoId);
    }
}
