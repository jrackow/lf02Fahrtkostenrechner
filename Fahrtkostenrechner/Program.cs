static void main(string[] args)
{ 
    bool temp = false;

    Console.WriteLine("                FahrtKostenrechner");
    Console.WriteLine();
    while (!temp)
    {
        Console.WriteLine("Bitte geben Sie die geplante Fahrtzeit in Minuten an:");

        int minuten = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Sie wollen " + minuten + " Minuten fahren, korrekt?");
        Console.WriteLine();
        Console.WriteLine("Drücken sie 'J' für Ja oder 'N' für Nein");

        var answer = Console.ReadLine();
        if (answer == "n")
        {
            Console.Write("Nein");
        }
        else if (answer == "j")
        {
            temp = true;
            Console.WriteLine("Ja Mann");
        }

        Console.ReadKey();
    }