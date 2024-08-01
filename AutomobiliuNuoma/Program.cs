using AutomobiliuNuoma.Core.Contracts;
using AutomobiliuNuoma.Core.Enums;
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
            Console.WriteLine("3. Rodyti visus elektromobilius");
            Console.WriteLine("4. Rodyti visus elektromobilius");
            Console.WriteLine("5. Formuoti nuomos uzsakyma");
            Console.WriteLine("6. Prideti automobili");
            Console.WriteLine("7. Prideti darbuotoja");
            Console.WriteLine("8. Rodyti visus darbuotojus");
            Console.WriteLine("9. Atnaujinti automobili");

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
                    List<Elektromobilis> elektromobiliai = autonuomaService.GautiVisusElektromobilius();
                    foreach (Elektromobilis ev in elektromobiliai)
                    {
                        Console.WriteLine(ev);
                    }
                    break;
                case "4":
                    List<NaftosKuroAutomobilis> naftosKuroAutomobiliai = autonuomaService.GautiVisusNaftosKuroAuto();
                    foreach (NaftosKuroAutomobilis v in naftosKuroAutomobiliai)
                    {
                        Console.WriteLine(v);
                    }
                    break;
                case "5":
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
                case "6":
                    Automobilis naujasAuto = new Automobilis();
                    int ikrovimoLaikas= 0;
                    int baterijosTalpa = 0;
                    Console.WriteLine("Elektromobilis - 1  Naftos Kuro Auto - 2: ");
                    string tipas = Console.ReadLine();
                    switch(tipas)
                    {
                        case "1":
                            Console.WriteLine("Iveskite Ikrovimo laika");
                            ikrovimoLaikas = int.Parse(Console.ReadLine());
                            Console.WriteLine("Iveskite Baterijos talpa");
                            baterijosTalpa = int.Parse(Console.ReadLine());
                            break;
                        case "2":
                            //NaftosKuro
                            break;
                    }
                    Console.WriteLine("Iveskite marke");
                    string marke = Console.ReadLine();
                    Console.WriteLine("Iveskite modeli");
                    string modelis = Console.ReadLine();
                    Console.WriteLine("Iveskite nuomos kaina");
                    decimal nuomosKaina = decimal.Parse(Console.ReadLine());
                    switch (tipas)
                    {
                        case "1":
                            naujasAuto = new Elektromobilis(marke, modelis, nuomosKaina, baterijosTalpa, ikrovimoLaikas);
                            break;
                        case "2":
                            //NaftosKuro
                            break;
                    }
                    autonuomaService.PridetiNaujaAutomobili(naujasAuto);

                    break;
                case "7":

                    Console.WriteLine("Iveskite varda");
                    string darbuotojoVardas = Console.ReadLine();
                    Console.WriteLine("Iveskite pavarde");
                    string darbuotojoPavarde = Console.ReadLine();
                    Console.WriteLine("Pasirinkite pareigas: 2 - vadybininkas, 1 - direktorius, 3 - mechanikas");

                    DarbuotojasPareigos darbuotojasPareigos = (DarbuotojasPareigos)int.Parse(Console.ReadLine());

                    Darbuotojas naujasDarbuotojas = new Darbuotojas
                    {
                        Vardas = darbuotojoVardas,
                        Pavarde = darbuotojoPavarde,
                        Pareigos = darbuotojasPareigos
                    };

                    autonuomaService.PridetiDarbuotoja(naujasDarbuotojas);

                    break;
                case "8":
                    List<Darbuotojas> darbuotojai = autonuomaService.GautiVisusDarbuotojus();
                    foreach (Darbuotojas d in darbuotojai)
                    {
                        Console.WriteLine(d);
                    }
                    break;
                case "9":
                    Console.WriteLine("Pasirinkite automobilio id");
                    int pasirinktasId = int.Parse(Console.ReadLine());
                    Automobilis automobilis = autonuomaService.GautiVisusElektromobilius().Find(x => x.Id == pasirinktasId); 
                    int naujasIkrovimoLaikas = 0;
                    int naujaBaterijosTalpa = 0;
                    Console.WriteLine("Elektromobilis - 1  Naftos Kuro Auto - 2: ");
                    string autoTipas = Console.ReadLine();
                    switch (autoTipas)
                    {
                        case "1":
                            Console.WriteLine("Iveskite Ikrovimo laika");
                            naujasIkrovimoLaikas = int.Parse(Console.ReadLine());
                            Console.WriteLine("Iveskite Baterijos talpa");
                            naujaBaterijosTalpa = int.Parse(Console.ReadLine());
                            break;
                        case "2":
                            //NaftosKuro
                            break;
                    }
                    Console.WriteLine("Iveskite marke");
                    string naujaMarke = Console.ReadLine();
                    Console.WriteLine("Iveskite modeli");
                    string naujasModelis = Console.ReadLine();
                    Console.WriteLine("Iveskite nuomos kaina");
                    decimal naujaNuomosKaina = decimal.Parse(Console.ReadLine());
                    switch (autoTipas)
                    {
                        case "1":
                            automobilis.Marke = naujaMarke;
                            automobilis.Modelis = naujasModelis;
                            automobilis.NuomosKaina = naujaNuomosKaina;
                            ((Elektromobilis)automobilis).BaterijosTalpa = naujaBaterijosTalpa;
                            ((Elektromobilis)automobilis).IkrovimoLaikas = naujasIkrovimoLaikas;

                            break;
                        case "2":
                            //NaftosKuro
                            break;
                    }
                    autonuomaService.AtnaujintiAutomobili(automobilis);

                    break;
            }


        }
    }
    public static IAutonuomaService SetupDependencies()
    {
        IKlientaiRepository klientaiRepository = new KlientaiFileRepository("Klientai.csv");
        //IAutomobiliaiRepository automobiliaiRepository = new AutomobiliaiFileRepository("Auto.csv");
        IAutomobiliaiRepository automobiliaiRepository = new AutomobiliaiDbRepository("Server=localhost\\MSSQLSERVER01;Database=autonuoma;Trusted_Connection=True;");
        IKlientaiService klientaiService = new KlientaiService(klientaiRepository);
        IAutomobiliaiService automobiliaiService = new AutomobiliaiService(automobiliaiRepository);
        IDarbuotojaiRepository darbuotojaiRepository = new DarbuotojaiDbRepository("Server=localhost\\MSSQLSERVER01;Database=autonuoma;Trusted_Connection=True;");
        IDarbuotojaiService darbuotojaiService = new DarbuotojaiService(darbuotojaiRepository);
        return new AutonuomosService(klientaiService, automobiliaiService, darbuotojaiService);
    }
}