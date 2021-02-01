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
        // Look for any movies.
        if (context.SchuelerDaten.Any())
        {
          return;   // DB has been seeded
        }

        SchuelerDaten sd_alice = new SchuelerDaten()
        {
          Vorname = "Alice",
          Nachname = "Herrmann",
          Geburtsdatum = DateTime.Now.AddDays(-7000),
          EMail = "a.hermann@email.de",
          Anmeldedatum = DateTime.Now,
          Konfession = "keine",
          Staatsangehoerigkeit = "Deutsch",
          Telefonnummer = "123 456 789"
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
          Telefonnummer = "1123 456 789"
        };


        context.SchuelerDaten.Add(sd_alice);
        context.SchuelerDaten.Add(sd_bob);
        // Alternativ:
        // context.AddRange(sd_alice, sd_bob);

        context.SaveChanges();


      }

    }
  }
}
