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
            Console.WriteLine("Bitte geben Sie die geplante Fahrtzeit in Minuten an:");

            int minuten = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Sie wollen " + minuten + " Minuten fahren, korrekt?");
            Console.WriteLine();
            Console.WriteLine("Drücken sie 'J' für Ja oder 'N' für Nein");

            var answer = Console.ReadLine();
            if (answer == "n")
            {
                Console.Write("Sie haben 'Nein' gedrückt. Drücken sie eine Taste um eine Erneute Eingabe zu tätigen.");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
            else if (answer == "j")
            {
                double kosten = (minuten * 0.25 + 1);
                continueWhile = false;
                Console.WriteLine("Für eine Fahrt von " + minuten + " zahlen Sie:");
                Console.WriteLine(kosten.ToString("0.00") + " Euro");
            }
            Console.WriteLine();
            Console.WriteLine("Drücken Sie eine Taste, um die Anwendung zu beenden.");
            Console.ReadKey();
        }
    }
}