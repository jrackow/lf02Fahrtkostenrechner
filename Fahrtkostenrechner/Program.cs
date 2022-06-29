using Fahrtkostenrechner;

// Nur auf Windows supported
try
{
    //Größe der Konsole wird festgelegt 
    Console.SetWindowSize(55, 30);
}
catch (System.PlatformNotSupportedException e) {}


// Erstellt Objekte für das Management und den Rechner
Management management = new Management();
Rechner fahrtkostenrechner = new Rechner(management.Settings);

// Start des Fahrtkostenrechners
fahrtkostenrechner.start();