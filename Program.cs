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


    public Mitarbeiter DeepCopy()
    {
        // Create a new instance and copy values
        Mitarbeiter copy = new Mitarbeiter { 
                                            Name = this.Name, 
                                            Muell = this.Muell, 
                                            Kueche = this.Kueche, 
                                            KuecheGemacht = this.KuecheGemacht, 
                                            MuellGemacht = this.MuellGemacht, 
                                            Krank = this.Krank };
        return copy;
    }

}

class Program
{
    public static List<Mitarbeiter> mitarbeiterList;
    public static List<Mitarbeiter> mitarbeiterList_2;
    public static List<Mitarbeiter> mitarbeiterList_krank;
    /*public static List<Mitarbeiter> mitarbeiterList = new List<Mitarbeiter>
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
        };*/

    static void Main()
    {
        mitarbeiterList = JsonImporter();
        mitarbeiterList_2 = mitarbeiterList;                 // mitarbeiterList_2.DeepCopy(mitarbeiterList);
        mitarbeiterList_krank = new List<Mitarbeiter>();

        Mitarbeiter m_buff = new Mitarbeiter();
        Mitarbeiter m_buff2 = new Mitarbeiter();

        Mitarbeiter k_buff = new Mitarbeiter();
        Mitarbeiter k_buff2 = new Mitarbeiter();

        m_buff = AuswahlScript(m_buff, m_buff2, "Müll");
        m_buff2 = AuswahlScript(m_buff, m_buff2, "Müll");
        check(m_buff, m_buff2, "Müll");

        k_buff = AuswahlScript(m_buff, m_buff2, "Küche");
        k_buff2 = AuswahlScript(m_buff, m_buff2, "Küche");
        check(k_buff, k_buff2, "Küche");

        JsonExporter(mitarbeiterList);



    }

    static Mitarbeiter AuswahlScript(Mitarbeiter m_buff, Mitarbeiter m_buff2, string type)
    {
        Random zufall;
        int index1;
        int index2; //für 2.Person

        var mitarbeiterMitlWert = mitarbeiterList_2;

        switch (type)
        {
            case "Müll":
                mitarbeiterMitlWert = mitarbeiterList_2.Where(m => m.Muell > 0 
                                                                && m_buff != null 
                                                                && m_buff2 != null 
                                                                && m.Name != m_buff.Name 
                                                                && m.Name != m_buff2.Name).ToList();
                break;
            case "Küche":
                mitarbeiterMitlWert = mitarbeiterList_2.Where(m => m.Kueche > 0
                                                                && m_buff != null
                                                                && m_buff2 != null
                                                                && m.Name != m_buff.Name 
                                                                && m.Name != m_buff2.Name).ToList();
                break;
        }

        if (mitarbeiterMitlWert.Any())
        {
            zufall = new Random();

            // Zwei zufällige Indizes auswählen, die nicht gleich sind
            do
            {
                index1 = zufall.Next(0, mitarbeiterMitlWert.Count);
                if (mitarbeiterMitlWert.Count == 0 && mitarbeiterList_2.Count == 0 || mitarbeiterList_krank.Count >= (mitarbeiterList.Count - 1))
                {
                    Console.WriteLine("zuwenige zum Arbeit verteilen"); Environment.Exit(0); 
                }
                
            } while (mitarbeiterMitlWert[index1].Name == m_buff.Name
                    || mitarbeiterMitlWert[index1].Name == m_buff2.Name);

            // Die beiden Ausgaben aus der Liste anzeigen
            Mitarbeiter mull1 = mitarbeiterMitlWert[index1];


            
            m_buff = mull1;
            return m_buff;
        }
        else
        {
            zufall = new Random();
            // Zwei zufällige Indizes auswählen, die nicht gleich sind

            do
            {

                index1 = zufall.Next(0, mitarbeiterList_2.Count);
                if (mitarbeiterList_2.Count == 0 || mitarbeiterList_krank.Count > (mitarbeiterList.Count - 1)) 
                { 
                    Console.WriteLine("zuwenige zum Arbeit verteilen"); Environment.Exit(0); 
                }
                
            } while (mitarbeiterList_2[index1].Name == m_buff.Name
                    || mitarbeiterList_2[index1].Name == m_buff2.Name);

            // Die beiden Ausgaben aus der Liste anzeigen
            Mitarbeiter mull1 = mitarbeiterList_2[index1];
            m_buff = mull1;

            return m_buff;
        }
    }


    static Array check(Mitarbeiter m_buff, Mitarbeiter m_buff2, string type)
    {
        while (true)
        {
            Console.WriteLine(type + " macht " + m_buff.Name);
            Console.WriteLine(type + " macht " + m_buff2.Name);
            Console.WriteLine("Sind beide da?");
            Console.WriteLine("Bitte geben sie ein 1 für JA oder 2 für Nein");
            string isDa = Console.ReadLine();
            if (isDa == "1")
            {
                Gemacht(m_buff, type);
                Gemacht(m_buff2, type);
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
                        mitarbeiterList_krank.Add(m_buff);
                        mitarbeiterList_2.Remove(m_buff);
                        m_buff = AuswahlScript(m_buff, m_buff2, type);
                        break;
                    }
                    else if (werFehlt == "2")
                    {
                        NichtDa(m_buff2, type);
                        mitarbeiterList_krank.Add(m_buff);
                        mitarbeiterList_2.Remove(m_buff2);
                        m_buff2 = AuswahlScript(m_buff, m_buff2,  type);
                        break;
                    }
                    else { Console.WriteLine("Fehler versuche es erneut"); }
                }

            }
            
        }
    }

    static void NichtDa(Mitarbeiter m, string e)
    {
        switch (e)
        {
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

        // Daten in JSON serialisieren
        string json = JsonSerializer.Serialize(l_m);

        // JSON in eine Datei schreiben
        File.WriteAllText("mitarbeiter.json", json);

        Console.WriteLine("JSON exportiert.");
    }
    static List<Mitarbeiter> JsonImporter()
    {
        // JSON aus der Datei lesen
        string json = File.ReadAllText("mitarbeiter.json");

        // JSON in ein Mitarbeiter-Objekt deserialisieren
        List<Mitarbeiter> mitarbeiterListe = JsonSerializer.Deserialize<List<Mitarbeiter>>(json);

       /* foreach (var item in mitarbeiterListe)
        {
            Console.WriteLine($"{item.Name}");
        }*/

        return mitarbeiterListe;
    }

}
