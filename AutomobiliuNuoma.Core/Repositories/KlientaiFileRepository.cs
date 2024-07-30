﻿using AutomobiliuNuoma.Core.Contracts;
using AutomobiliuNuoma.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Core.Repositories
{
    public class KlientaiFileRepository : IKlientaiRepository
    {
        private readonly string _filePath;
        public KlientaiFileRepository(string filePath)
        {
            _filePath = filePath;
        }
        public List<Klientas> GautiVisusKlientus()
        {
            List<Klientas> visiKlientai = new List<Klientas>();
            using(StreamReader sr = new StreamReader(_filePath))
            {
                while(!sr.EndOfStream)
                {
                    string eilute = sr.ReadLine();
                    string[] verte = eilute.Split(',');
                    visiKlientai.Add(new Klientas(verte[0], verte[1], DateOnly.Parse(verte[2])));
                }
            }
            return visiKlientai;
        }
    }
}
