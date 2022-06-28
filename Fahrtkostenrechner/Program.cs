using Fahrtkostenrechner;
using Fahrtkostenrechner.Model;

Management management = new Management();
Rechner fahrtkostenrechner = new Rechner(management.Settings);
fahrtkostenrechner.start();
