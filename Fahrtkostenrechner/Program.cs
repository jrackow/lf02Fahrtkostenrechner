using Fahrtkostenrechner;

//Größe der Konsole wird festgelegt 
Console.SetWindowSize(55, 30);

// Erstellt Objekte für das Management und den Rechner
Management management = new Management();
Rechner fahrtkostenrechner = new Rechner(management.Settings);

// Start des Fahrtkostenrechners
fahrtkostenrechner.start();