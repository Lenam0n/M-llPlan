using System;
using System.Collections.Generic;
using System.Diagnostics;

class Mitarbeiter
{
    public string Name { get; set; }
    public int Muell { get; set; }
    public int Kueche { get; set; }
    public Dictionary<string, DateTime> MuellGemacht { get; set; }
    public Dictionary<string, DateTime> KücheGemacht { get; set; }
    public Dictionary<string, DateTime> Krank { get; set; }
}

class Program
{
    //Importer von text/json datei
    //Exporter von text/json datei

    public static List<Mitarbeiter> mitarbeiterList = new List<Mitarbeiter>
        {
            new Mitarbeiter
            {
                Name = "Julian Kugler",
                Muell = 0,
                Kueche = 0,
                MuellGemacht = new Dictionary<string, DateTime>
                {
                    { "Tag", DateTime.Now }
                },
                KücheGemacht = new Dictionary<string, DateTime>
                {
                    { "Tag", DateTime.Now }
                },
                Krank = new Dictionary<string, DateTime>
                {
                    { "Tag", DateTime.Now }
                }
            },
            new Mitarbeiter
            {
                Name = "Deniz Wagner",
                Muell = 0,
                Kueche = 0,
                MuellGemacht = new Dictionary<string, DateTime>
                {
                    { "Tag", DateTime.Now }
                },
                Krank = new Dictionary<string, DateTime>
                {
                    { "Tag", DateTime.Now }
                }
            },
            new Mitarbeiter
            {
                Name = "Michelle Pfeifer",
                Muell = 0,
                Kueche = 0,
                MuellGemacht = new Dictionary<string, DateTime>
                {
                    { "Tag", DateTime.Now }
                },
                Krank = new Dictionary<string, DateTime>
                {
                    { "Tag", DateTime.Now }
                }
            },
            new Mitarbeiter
            {
                Name = "Pierre Fuchs",
                Muell = 1,
                Kueche = 0,
                MuellGemacht = new Dictionary<string, DateTime>
                {
                    { "Tag", DateTime.Now }
                },
                Krank = new Dictionary<string, DateTime>
                {
                    { "Tag", DateTime.Now }
                }
            },
            // Füge hier die anderen Mitarbeiter hinzu
        };

    static void Main()
    {
        Random zufall;
        int index1;
        int index2; //für 2.Person
        string buffer ="";
        string buffer2 = "";

        var mitarbeiterMitMuellWert = mitarbeiterList;

        for (int i = 0; i <= 2; i++)
        {
            mitarbeiterMitMuellWert = mitarbeiterList.Where(m => m.Muell != 0).ToList();
            if (mitarbeiterMitMuellWert.Any())
            {
                zufall = new Random();

                // Zwei zufällige Indizes auswählen, die nicht gleich sind
                index1 = zufall.Next(0, mitarbeiterMitMuellWert.Count);
                // Die beiden Ausgaben aus der Liste anzeigen
                Mitarbeiter mull1 = mitarbeiterMitMuellWert[index1];


                Gemacht(mitarbeiterMitMuellWert[index1], "Müll");
                Console.WriteLine("Müller - 1: " + mull1.Name + " current Stand " + mull1.Muell);
                buffer = mull1.Name;
                i++;

            }
            else
            {
                zufall = new Random();
                // Zwei zufällige Indizes auswählen, die nicht gleich sind

                do
                {
                    index2 = zufall.Next(0, mitarbeiterList.Count);
                } while (mitarbeiterList[index2].Name == buffer);

                    // Die beiden Ausgaben aus der Liste anzeigen
                    Mitarbeiter mull1 = mitarbeiterList[index2];
                if (string.IsNullOrEmpty(buffer)) {
                    buffer = mull1.Name;
                }
                else { buffer2 = mull1.Name; }


                Gemacht(mitarbeiterList[index2], "Müll");
                Console.WriteLine("Müller - 1: " + mull1.Name + " current Stand " + mull1.Muell);
                i++;
            }

        }
        while (true) {
            Console.WriteLine("Müll macht " + buffer);
            Console.WriteLine("Müll macht " + buffer2);
            Console.WriteLine("Sind beide da?");
            Console.WriteLine("Bitte geben sie ein 1 für JA oder 2 für Nein");
            string isDa = Console.ReadLine();
            if (isDa == "1")
            {
                break;
            }else if (isDa == "2")
            {
                while (true)
                {
                    Console.WriteLine("Wer fehlt");
                    Console.WriteLine("Bitte geben sie ein 1 für " + buffer + " oder 2 für " + buffer2);
                    string werFehlt = Console.ReadLine();

                    if (werFehlt == "1")
                    {
                        //NichtDa(); //buffer darf nicht name sein es muss die ganze klasseninstanz sein
                        break;
                    }
                    else if (werFehlt == "2") {
                        //NichtDa();
                        break; 
                    }
                    else { Console.WriteLine("Vehler versuche es erneut"); }
                }
            }
            else { continue; }
            
        }
        
        
         


    }

    static void NichtDa(Mitarbeiter m,string e)
    {
        switch (e) {
            case "Küche":
                m.Kueche += 1;
                break;
            case "Müll":
                m.Muell += 1;
                break;
        } 
    }
    static void Gemacht(Mitarbeiter m, string e)
    {
        switch (e)
        {
            case "Küche":
                m.Kueche -= 1;
                break;
            case "Müll":
                m.Muell -= 1;
                break;
        }
    }
}
