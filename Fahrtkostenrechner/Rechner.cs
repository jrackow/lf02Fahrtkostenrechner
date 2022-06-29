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
        Console.WriteLine("                [Fahrtkostenrechner]");
        Console.WriteLine();

    eingabe:
        Console.WriteLine("Bitte geben Sie die geplante Fahrtzeit in Minuten an:");
        int minuten;
        try
        {
            minuten = Convert.ToInt32(Console.ReadLine());
        }
        catch (System.FormatException e)
        {  
            Console.WriteLine("[Fehler] Geben Sie eine Zahl ein um fortzufahren!");
            Console.WriteLine("");
            goto eingabe;
        }
        

    abfrage:
        Console.WriteLine("Sie wollen " + minuten + " Minuten fahren, korrekt?");
        Console.WriteLine();
        Console.WriteLine("Drücken sie 'J' für Ja oder 'N' für Nein");

        var answer = Console.ReadLine();

        switch (answer)
        {
            case "n":
                Console.WriteLine("Sie haben 'Nein' gedrückt. Bitte geben sie eine neue Eingabe ein.");
                goto eingabe;
            case "j":
                break;
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
    private void BerechneFahrpreis(int time)
    {
        double kosten = (time * _settings.FahrtpreisProMinute + _settings.Entsperrungskosten);
        Console.WriteLine("Für eine Fahrt von " + time + " zahlen Sie:");
        Console.WriteLine(kosten.ToString("0.00") + " Euro");
    }

}