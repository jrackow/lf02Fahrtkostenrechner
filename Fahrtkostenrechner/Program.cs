using Fahrtkostenrechner;

// Erstellt Objekte für das Management und den Rechner
Verwaltung verwaltung = new Verwaltung();
Rechner rechner = new Rechner(verwaltung.Einstellungen);

// Start des Fahrtkostenrechners
rechner.Start();