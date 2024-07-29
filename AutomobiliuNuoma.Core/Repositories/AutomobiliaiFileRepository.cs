using AutomobiliuNuoma.Core.Contracts;
using AutomobiliuNuoma.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Core.Repositories
{
    public class AutomobiliaiFileRepository : IAutomobiliaiRepository
    {
        private readonly string _filePath;
        public AutomobiliaiFileRepository(string autoFilePath)
        {
            _filePath = autoFilePath;
        }
        public void IrasytiAutomobilius()
        {
            throw new NotImplementedException();
        }

        public List<Automobilis> NuskaitytiAutomobilius()
        {
            throw new NotImplementedException();
        }
    }
}
