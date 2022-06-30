using Fahrtkostenrechner;

// Erstellt Objekte für das Management und den Rechner
Management management = new Management();
Rechner rechner = new Rechner(management.Settings);

// Start des Fahrtkostenrechners
rechner.Start();