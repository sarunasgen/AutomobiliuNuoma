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
            Console.WriteLine("2. Rodyti visus klientus");
            Console.WriteLine("3. Formuoti nuomos uzsakyma");
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
                case "2":
                    List<Klientas> klientai = autonuomaService.GautiVisusKlientus();
                    foreach (Klientas k in klientai)
                    {
                        Console.WriteLine(k);
                    }
                    break;
                case "3":
                    Console.WriteLine("Nuomos uzsakymas: ");
                    foreach (Klientas k in autonuomaService.GautiVisusKlientus())
                    {
                        Console.WriteLine(k);
                    }

                    Console.WriteLine("Iveskite norimo kliento varda");
                    string vardas = Console.ReadLine();
                    Console.WriteLine("Iveskite norimo kliento pavarde");
                    string pavarde = Console.ReadLine();

                    foreach (Automobilis a in autonuomaService.GautiVisusAutomobilius())
                    {
                        Console.WriteLine(a);
                    }

                    Console.WriteLine("Pasirinkite automobili pagal Id sarase: ");
                    int autoId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Iveskite kiek dienu autommobilis yra isnuomojamas: ");
                    int dienos = int.Parse(Console.ReadLine());

                    autonuomaService.SukurtiNuoma(vardas, pavarde, autoId, DateTime.Now, dienos);

                    break;
            }


        }
    }
    public static IAutonuomaService SetupDependencies()
    {
        IKlientaiRepository klientaiRepository = new KlientaiFileRepository("Klientai.csv");
        IAutomobiliaiRepository automobiliaiRepository = new AutomobiliaiFileRepository("Auto.csv");
        IKlientaiService klientaiService = new KlientaiService(klientaiRepository);
        IAutomobiliaiService automobiliaiService = new AutomobiliaiService(automobiliaiRepository);
        return new AutonuomosService(klientaiService, automobiliaiService);
    }
}