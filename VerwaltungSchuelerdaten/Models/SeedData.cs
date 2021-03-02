using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VerwaltungSchuelerdaten.Data;


namespace VerwaltungSchuelerdaten.Models
{
  public class SeedData
  {

    public static void Initialize(IServiceProvider serviceProvider)
    {
      using (var context = new VerwaltungSchuelerdatenContext(
          serviceProvider.GetRequiredService<
              DbContextOptions<VerwaltungSchuelerdatenContext>>()))
      {
        // Look for any entries.
        if (context.SchuelerDaten.Any())
        {
          return;   // DB has been seeded
        }

        Klasse klasse1 = new Klasse()
        {
          Name = "WI19Z1a",
          Beschreibung = "Oberstufe der HBSWI Anwendungsentwickler"
        };


        Adresse adresseFuerAlle = new Adresse()
        {
          Ort = "Saarbrücken",
          Strasse = "Mainzerstr."
        };

        SchuelerDaten sd_alice = new SchuelerDaten()
        {
          Vorname = "Alice",
          Nachname = "Herrmann",
          Geburtsdatum = DateTime.Now.AddDays(-7000),
          EMail = "a.hermann@email.de",
          Anmeldedatum = DateTime.Now,
          Konfession = "keine",
          Staatsangehoerigkeit = "Deutsch",
          Telefonnummer = "123 456 789",
          Klasse = klasse1,
          Adresse = adresseFuerAlle

        };

        Note noteAlice = new Note()
        {
          Notenwert = 1,
          Beschreibung = "Klassenarbeit Programmierung",
          Schueler = sd_alice
        };


        SchuelerDaten sd_bob = new SchuelerDaten()
        {
          Vorname = "Bob",
          Nachname = "Bauer",
          Geburtsdatum = DateTime.Now.AddDays(-7500),
          EMail = "b.bauer@email.de",
          Anmeldedatum = DateTime.Now,
          Konfession = "evangelisch",
          Staatsangehoerigkeit = "Frankreich",
          Telefonnummer = "1123 456 789",
          Klasse = klasse1,
          Adresse = adresseFuerAlle
        };

        Note noteBob = new Note()
        {
          Notenwert = 2,
          Beschreibung = "Klassenarbeit Programmierung",
          Schueler = sd_bob
        };


        SchuelerDaten sd_carol = new SchuelerDaten()
        {
          Vorname = "Carol",
          Nachname = "Cook",
          Geburtsdatum = DateTime.Now.AddDays(-6000),
          EMail = "c.cook@email.de",
          Anmeldedatum = DateTime.Now,
          Konfession = "evangelisch",
          Staatsangehoerigkeit = "Türkei",
          Telefonnummer = "23894",
          Klasse = klasse1,
          Adresse = adresseFuerAlle
        };

        sd_alice.Noten = new List<Note>();
        sd_alice.Noten.Add(noteAlice);

        context.SchuelerDaten.Add(sd_alice);
        context.SchuelerDaten.Add(sd_bob);
        context.SchuelerDaten.Add(sd_carol);
        // Alternativ:
        // context.AddRange(sd_alice, sd_bob);

        context.SaveChanges();


      }

    }
  }
}
