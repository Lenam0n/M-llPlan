using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;

class Mitarbeiter
{
    public string Name { get; set; }
    public int Muell { get; set; }
    public int Kueche { get; set; }
    public ArrayList MuellGemacht { get; set; }
    public ArrayList KuecheGemacht { get; set; }
    public ArrayList Krank { get; set; }
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
                MuellGemacht = new ArrayList(),
                KuecheGemacht = new ArrayList(),
                Krank = new ArrayList()
            },
            new Mitarbeiter
            {
                Name = "Deniz Wagner",
                Muell = 0,
                Kueche = 0,
                MuellGemacht = new ArrayList(),
                KuecheGemacht = new ArrayList(),
                Krank = new ArrayList(),
            },
            new Mitarbeiter
            {
                Name = "Michelle Pfeifer",
                Muell = 0,
                Kueche = 0,
                MuellGemacht = new ArrayList(),
                KuecheGemacht = new ArrayList(),
                Krank = new ArrayList(),
            },
            new Mitarbeiter
            {
                Name = "Pierre Fuchs",
                Muell = 0,
                Kueche = 0,
                MuellGemacht = new ArrayList(),
                KuecheGemacht = new ArrayList(),
                Krank = new ArrayList()
            },
            // Füge hier die anderen Mitarbeiter hinzu
        };

    static void Main()
    {
        Mitarbeiter m_buff = null;
        Mitarbeiter m_buff2 = null;
        AuswahlScript(m_buff, m_buff2,"Müll");
        AuswahlScript(m_buff, m_buff2, "Küche");

        JsonExporter(mitarbeiterList);



    }

    static Array AuswahlScript(Mitarbeiter m_buff,Mitarbeiter m_buff2,string type)
    {
        Random zufall;
        int index1;
        int index2; //für 2.Person

        var mitarbeiterMitlWert = mitarbeiterList;

        for (int i = 0; i < 2; i++)
        {
            switch (type)
            {
                case "Müll":
                    mitarbeiterMitlWert = mitarbeiterList.Where(m => m.Muell > 0).ToList();
                    break;
                case "Küche":
                    mitarbeiterMitlWert = mitarbeiterList.Where(m => m.Kueche > 0).ToList();
                    break;
            }
            
            if (mitarbeiterMitlWert.Any())
            {
                zufall = new Random();

                // Zwei zufällige Indizes auswählen, die nicht gleich sind
                index1 = zufall.Next(0, mitarbeiterMitlWert.Count);
                // Die beiden Ausgaben aus der Liste anzeigen
                Mitarbeiter mull1 = mitarbeiterMitlWert[index1];


                Gemacht(mitarbeiterMitlWert[index1], type);
                m_buff = mull1;

            }
            else
            {
                zufall = new Random();
                // Zwei zufällige Indizes auswählen, die nicht gleich sind

                do
                {
                    index2 = zufall.Next(0, mitarbeiterList.Count);
                } while (m_buff != null && mitarbeiterList[index2].Name == m_buff.Name);

                // Die beiden Ausgaben aus der Liste anzeigen
                Mitarbeiter mull1 = mitarbeiterList[index2];
                if (m_buff == null)
                {
                    m_buff = mull1;
                }
                else { m_buff2 = mull1; }


                Gemacht(mitarbeiterList[index2], type);

            }

        }
        while (true)
        {
            Console.WriteLine(type +" macht " + m_buff.Name);
            Console.WriteLine(type + " macht " + m_buff2.Name);
            Console.WriteLine("Sind beide da?");
            Console.WriteLine("Bitte geben sie ein 1 für JA oder 2 für Nein");
            string isDa = Console.ReadLine();
            if (isDa == "1")
            {
                return new Mitarbeiter[] { m_buff, m_buff2 };
            }
            else if (isDa == "2")
            {
                while (true)
                {
                    Console.WriteLine("Wer fehlt");
                    Console.WriteLine("Bitte geben sie ein 1 für " + m_buff.Name + " oder 2 für " + m_buff2.Name);
                    string werFehlt = Console.ReadLine();

                    if (werFehlt == "1")
                    {
                        NichtDa(m_buff, type);
                        Console.WriteLine(m_buff.Muell);
                        break;
                    }
                    else if (werFehlt == "2")
                    {
                        NichtDa(m_buff2, type);
                        Console.WriteLine(m_buff2.Muell);
                        break;
                    }
                    else { Console.WriteLine("Fehler versuche es erneut"); }
                }
                return new Mitarbeiter[] { m_buff, m_buff2 };


            }
            else { continue; }

        }
    }

    static void NichtDa(Mitarbeiter m,string e)
    {
        switch (e) {
            case "Küche":
                m.Kueche += 1;
                m.Krank.Add(DateTime.Now);
                break;
            case "Müll":
                m.Muell += 1;
                m.Krank.Add(DateTime.Now);
                break;
        } 
    }
    static void Gemacht(Mitarbeiter m, string e)
    {
        switch (e)
        {
            case "Küche":
                m.Kueche -= 1;
                m.KuecheGemacht.Add(DateTime.Now);
                break;
            case "Müll":
                m.MuellGemacht.Add(DateTime.Now);
                m.Muell -= 1;
                break;
        }
    }
    static void JsonExporter(List<Mitarbeiter> l_m)
    {
       /*foreach (var m in l_m)
        {
            
        }*/

        // Daten in JSON serialisieren
        string json = JsonSerializer.Serialize(l_m);

        // JSON in eine Datei schreiben
        File.WriteAllText("mitarbeiter.json", json);

        //Console.WriteLine(json);
        Console.WriteLine("JSON exportiert.");
    }
    static List<Mitarbeiter> JsonImporter()
    {
        // JSON aus der Datei lesen
        string json = File.ReadAllText("mitarbeiter.json");

        // JSON in ein Mitarbeiter-Objekt deserialisieren
        List<Mitarbeiter> mitarbeiterListe = JsonSerializer.Deserialize<List<Mitarbeiter>>(json);

        foreach (var item in mitarbeiterListe)
        {
            Console.WriteLine($"{item}");
        }

        return mitarbeiterListe;
    }
}
