using AutomobiliuNuoma.Core.Contracts;
using AutomobiliuNuoma.Core.Models;
using AutomobiliuNuoma.Core.Repositories;
using AutomobiliuNuoma.Core.Services;
using System;

namespace AutomobiliuNuomaConsoleApp;

public class Program
{
    public static void Main(string[] args)
    {
        IAutonuomaService autonuomaService = SetupDependencies();
        while(true)
        {
            Console.WriteLine("1. Rodyti visus automobilius");
            string pasirinkimas = Console.ReadLine();
            switch(pasirinkimas)
            {
                case "1":
                    List<Automobilis> auto = autonuomaService.GautiVisusAutomobilius();
                    foreach(Automobilis a in auto)
                    {
                        Console.WriteLine(a);
                    }
                    break;
            }


        }
    }
    public static IAutonuomaService SetupDependencies()
    {
        IKlientaiRepository klientaiRepository = new KlientaiFileRepository();
        IAutomobiliaiRepository automobiliaiRepository = new AutomobiliaiFileRepository("automobiliai.csv");
        IKlientaiService klientaiService = new KlientaiService(klientaiRepository);
        IAutomobiliaiService automobiliaiService = new AutomobiliaiService(automobiliaiRepository);
        return new AutonuomosService(klientaiService, automobiliaiService);
    }
}