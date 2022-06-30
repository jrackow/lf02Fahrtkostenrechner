using Fahrtkostenrechner.Model;
using Newtonsoft.Json;

namespace Fahrtkostenrechner;

public class Verwaltung
{
    public Einstellungen Einstellungen;
    public Verwaltung()
    {
        // Überprüft ob die Settings.json schon existiert
        if(File.Exists(@"Settings.json"))
        {
            //Läd die Settings.json in das Settings Objekt
            LoadJSON();
            Console.WriteLine("Einstellungen wurden geladen");
        }
        else
        {
            // Setzt Default Werte
            Einstellungen = new Einstellungen();
            Einstellungen.Entsperrungskosten = 1.0;
            Einstellungen.FahrtpreisProMinute = 0.25;
                
            //Erstellt die Settings.json
            CreateJSON();  
        }
    }
    // Erstellt eine Settings.json Datei aus dem Settings Objekt der Klasse
    private void CreateJSON()
    {
        JsonSerializer serializer = new JsonSerializer();
        serializer.NullValueHandling = NullValueHandling.Ignore;

        StreamWriter sw = new StreamWriter(@"Settings.json");
        JsonWriter writer = new JsonTextWriter(sw); 
        
        serializer.Serialize(writer, Einstellungen);
    }
    // Lädt das Settings Objekt aus der Settings.json Datei
    // Überschreibt das Settings Objekt der Klasse (Management)
    private void LoadJSON()
    {
        StreamReader file = File.OpenText(@"Settings.json");
        JsonSerializer serializer = new JsonSerializer(); 
        Einstellungen = (Einstellungen)serializer.Deserialize(file, typeof(Einstellungen));
    }
}