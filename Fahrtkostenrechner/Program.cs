using Fahrtkostenrechner;

// Erstellt Objekte für das Management und den Rechner
Verwaltung verwaltung = new Verwaltung();
Rechner rechner = new Rechner(verwaltung.einstellungen);

// Start des Fahrtkostenrechners
rechner.Start();