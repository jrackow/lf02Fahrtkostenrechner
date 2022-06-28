using Fahrtkostenrechner.Model;
using Newtonsoft.Json;

namespace Fahrtkostenrechner;

public class Management
{
    public Settings Settings;
    public Management()
    {
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
            Settings.FahrtpreisProKilometer = 0.25;
                
            //Erstellt die Settings.json
            createJSON(Settings);  
        }
    }

    void createJSON(Model.Settings settings)
    {
        JsonSerializer serializer = new JsonSerializer();
        serializer.NullValueHandling = NullValueHandling.Ignore;

        using (StreamWriter sw = new StreamWriter(@"Settings.json"))
        using (JsonWriter writer = new JsonTextWriter(sw))
        {
            serializer.Serialize(writer, Settings);
        }
    }

    void loadJSON()
    {
        using (StreamReader file = File.OpenText(@"Settings.json"))
        {
            JsonSerializer serializer = new JsonSerializer();
            Model.Settings output = (Model.Settings)serializer.Deserialize(file, typeof(Model.Settings));
            Settings = output;
        }
    }
}