using System;
using System.IO;
using Fahrtkostenrechner.Model;
using Newtonsoft.Json;

namespace Fahrtkostenrechner;

public class Management
{
    public Settings Settings;
    public Management()
    {
        // Überprüft ob die Settings.json schon existiert
        if(File.Exists("Settings.json"))
        {
            //Läd die Settings.json in das Settings Objekt
            loadJSON();
            Console.WriteLine("Einstellungen wurden geladen");
        }
        else
        {
            // Setzt Default Werte
            Settings = new Settings();
            Settings.Entsperrungskosten = 1.0;
            Settings.FahrtpreisProMinute = 0.25;
                
            //Erstellt die Settings.json
            createJSON(Settings);  
        }
    }
    // Erstellt eine Settings.json Datei aus dem mitgegebenen Settings Objekt
    private void createJSON(Model.Settings settings)
    {
        JsonSerializer serializer = new JsonSerializer();
        serializer.NullValueHandling = NullValueHandling.Ignore;

        using (StreamWriter sw = new StreamWriter(@"Settings.json"))
        using (JsonWriter writer = new JsonTextWriter(sw))
        {
            serializer.Serialize(writer, Settings);
        }
    }
    // Läd das Settings Objekt aus der Settings.json Datei
    // Überschreibt das Settings Objekt der Klasse (Management)
    private void loadJSON()
    {
        using (StreamReader file = File.OpenText(@"Settings.json"))
        {
            JsonSerializer serializer = new JsonSerializer();
            Model.Settings output = (Model.Settings)serializer.Deserialize(file, typeof(Model.Settings));
            Settings = output;
        }
    }
}