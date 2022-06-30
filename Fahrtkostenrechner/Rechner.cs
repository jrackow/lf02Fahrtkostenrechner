using Fahrtkostenrechner.Model;

namespace Fahrtkostenrechner;
public class Rechner
{
    private readonly Settings _settings;
    public Rechner(Settings settings)
    {
        _settings = settings;
    }
    // Startet den Fahrtkostenrechner und fragt die Fahrtzeit ab.
    public void start()
    {
        Console.WriteLine();
        Console.WriteLine();
        string s = "[Fahrtkostenrechner]";
        Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
        Console.WriteLine(s);
        Console.WriteLine();

        Console.WriteLine("Der Preis setzt sich aus einem Euro Entsperrungskosten + 0.25 Euro pro angebrochener Minute zusammen.");
    eingabe:
        Console.WriteLine("Bitte geben Sie die geplante Fahrtzeit in Minuten an. Beachten sie die maximale Nutzungsdauer von 200 Minuten:");
        int minuten;
        //Prüfung, ob eine Ganzzahl eingegeben wurde.
        try
        {
            minuten = Convert.ToInt32(Console.ReadLine());
        }
        //Fehlermeldung, falls keine Ganzzahl.
        catch (FormatException e)
        {
            Console.WriteLine("[Fehler] Geben Sie eine Zahl ein um fortzufahren!");
            Console.WriteLine("");
            goto eingabe;
        }
        //Prüfung, ob eine positive Fahrtzeit angegeben wurde.
        if (minuten < 1)
        {
            Console.WriteLine("Bitte geben Sie eine Fahrzeit über 0 ein.");
            goto eingabe;
        }
        //Ausgabe für den Fall, dass eine Eins eingegeben wurde. 
        else if (minuten == 1)
        {
            Console.WriteLine("Sie wollen " + minuten + " Minute fahren, korrekt?");
        }
        //Prüfung, ob die max. Nutzungsdauer erreicht wurde.
        else if (minuten > 200)
        {
            Console.WriteLine("Ihre Nutzungsdauer darf 200 Minuten nicht überschreiten.");
            goto eingabe;
        }
        //Ausgabe für die restlichen positiven Ganzzahlen.
        else
        {
            Console.WriteLine("Sie wollen " + minuten + " Minuten fahren, korrekt?");
        }
        Console.WriteLine();
        Console.WriteLine("Drücken sie 'J' für Ja oder 'N' für Nein");

        var answer = Console.ReadLine();

        //Prüfung der Antwortmöglichkeiten. 
        switch (answer.ToLower())
        {
            //Bei "N" kann der Benutzer eine erneute Eingabe tätigen.
            case "n":
                Console.WriteLine("Sie haben 'Nein' gedrückt. Bitte geben sie eine neue Eingabe ein.");
                goto eingabe;
            //Bei "J" wird der Berechnungsvorgang fortgefahren. 
            case "j":
                break;
            //Falls nicht "N" oder "J" eingegeben wird = Fehlermeldung. 
            default:
                Console.WriteLine("Eingabe unbekannt");
                goto eingabe;
        }
        BerechneFahrpreis(minuten);

        Console.WriteLine();
        Console.WriteLine("Drücken Sie eine Taste, um die Anwendung zu beenden.");
        Console.ReadKey();
    }

    // Berechnet des Fahrpreis mithilfe der gefahrenen Zeit.
    private void BerechneFahrpreis(int fahrzeit)
    {
        double kosten = (fahrzeit * _settings.FahrtpreisProMinute + _settings.Entsperrungskosten);
        Console.WriteLine("Für eine Fahrt von " + fahrzeit + " Minuten zahlen Sie:");
        Console.WriteLine(kosten.ToString("0.00") + " Euro");
    }

}