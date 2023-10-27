using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Mitarbeiterimport
{
    public string Name { get; set; }
    public int Muell { get; set; }
    public int Kueche { get; set; }
    public List<string> MuellGemacht { get; set; }
    public List<string> KuecheGemacht { get; set; }
    public List<string> Krank { get; set; }
}

class Program2
{
    static void main()
    {
        // Pfad zur CSV-Datei
        string csvFilePath = "mitarbeiter.csv";

        // Liste zur Speicherung der Mitarbeiterdaten
        List<Mitarbeiterimport> mitarbeiterList = new List<Mitarbeiterimport>();

        try
        {
            using (var reader = new StreamReader(csvFilePath))
            {
                // Die erste Zeile enthält die Spaltenüberschriften und wird ignoriert
                //reader.ReadLine();
                
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Array values = line.Split(';');

                    if (values.Length >= 1)
                    {
                        // Erstelle eine neue Mitarbeiterinstanz
                        var mitarbeiter = new Mitarbeiterimport
                        {
                            Name = "",//values,
                            Muell = 0,
                            Kueche = 0,
                            MuellGemacht = new List<string>(),
                            KuecheGemacht = new List<string>(),
                            Krank = new List<string>()
                        };

                        // Füge die Mitarbeiterinstanz zur Liste hinzu
                        mitarbeiterList.Add(mitarbeiter);
                    }

                }
                
            }

            // Konvertiere die Mitarbeiterliste in JSON
            string json = JsonSerializer.Serialize(mitarbeiterList);

            // Pfad zur JSON-Datei, in der die Daten gespeichert werden sollen
            string jsonFilePath = "mitarbeiter.json";

            // Schreibe die JSON-Daten in die Datei
            File.WriteAllText(jsonFilePath, json);

            Console.WriteLine("Mitarbeiterdaten wurden erfolgreich in einer JSON-Datei gespeichert.");
            Console.WriteLine(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Fehler beim Verarbeiten der CSV-Datei: " + ex.Message);
        }
    }
}
