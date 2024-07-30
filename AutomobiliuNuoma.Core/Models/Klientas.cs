﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Core.Models
{
    public class Klientas
    {
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public DateOnly GimimoMetai { get; set; }
        public Klientas() { }
        public Klientas(string vardas, string pavarde, DateOnly gimimoMetai)
        {
            Vardas = vardas;
            Pavarde = pavarde;
            GimimoMetai = gimimoMetai;
        }
        public override string ToString()
        {
            return $"Vardas: {Vardas} Pavarde: {Pavarde} Gimimo Metai:{GimimoMetai.ToString("yyyy")} Menesis: {GimimoMetai.ToString("MM")}";
        }
    }
}
