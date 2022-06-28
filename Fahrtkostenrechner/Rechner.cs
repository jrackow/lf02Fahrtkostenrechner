namespace Fahrtkostenrechner;
public class Rechner
{
    public Rechner()
    {
        bool continueWhile = true;
        Console.WriteLine("                Fahrtkostenrechner");
        Console.WriteLine();
        while (continueWhile)
        {
            eingabe:
            Console.WriteLine("Bitte geben Sie die geplante Fahrtzeit in Minuten an:");

            int minuten = Convert.ToInt32(Console.ReadLine());

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
                    goto abfrage;
            }

            double kosten = (minuten * 0.25 + 1);
            continueWhile = false;
            Console.WriteLine("Für eine Fahrt von " + minuten + " zahlen Sie:");
            Console.WriteLine(kosten.ToString("0.00") + " Euro");

            Console.WriteLine();
            Console.WriteLine("Drücken Sie eine Taste, um die Anwendung zu beenden.");
            Console.ReadKey();
        }
    }
}