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
                while (mitarbeiterList[index2].Name != buffer)
                {
                    index2 = zufall.Next(0, mitarbeiterList.Count);
                }
                
                // Die beiden Ausgaben aus der Liste anzeigen
                Mitarbeiter mull1 = mitarbeiterList[index2];


                Gemacht(mitarbeiterList[index2], "Müll");
                Console.WriteLine("Müller - 1: " + mull1.Name + " current Stand " + mull1.Muell);
                i++;
            }

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
