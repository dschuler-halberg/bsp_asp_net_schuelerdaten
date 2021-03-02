using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VerwaltungSchuelerdaten.Models
{
  public class SchuelerDaten
  {

    public int ID { get; set; }

    [Required]
    public string Vorname { get; set; }

    [Required(ErrorMessage = "Bitte geben Sie einen Nachnamen an")]
    public string Nachname { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Bitte geben Sie ein Geburtsdatum an")]
    public DateTime Geburtsdatum { get; set; }


    [Display(Name = "E-Mail Adresse")]
    [EmailAddress(ErrorMessage = "Geben Sie bitte eine gültige E-Mail-Adresse ein.")]
    public string EMail { get; set; }
    public string Telefonnummer { get; set; }
    public string Konfession { get; set; }

    [Display(Name = "Staatsangehörigkeit")]
    public string Staatsangehoerigkeit { get; set; }


    [DisplayName("Zweite Staatsangehörigkeit")]
    public string ZweiteStaatsangehoerigkeit { get; set; }

    [DataType(DataType.Date)]
    public DateTime Anmeldedatum { get; set; } 
    public string Kommentar { get; set; }

    public virtual Klasse Klasse { get; set; }

    public virtual List<Note> Noten { get; set; } 

    public Adresse Adresse { get; set; }

    public static List<string> Konfessionen { get; set; } =
      new List<string> { "katholisch", "evangelisch", "islam", "keine" };
    public static List<string> Laender { get; set; } = ReadCountries();
    //new List<string> { "Deutschland", "Frankreich", "Schweiz", "Luxemburg" };

    public static List<string> LaenderZweiteStaatsangehoerigkeit { get; set; }

    static SchuelerDaten()
    {
      LaenderZweiteStaatsangehoerigkeit = ReadCountries();
      LaenderZweiteStaatsangehoerigkeit.Insert(0, "keine");
    }

    public static List<string> ReadCountries()
    {
      List<string> countries = new List<string>();
      string[] lines = File.ReadAllLines("world.csv");
      foreach (string l in lines)
      {
        string[] zeile = l.Split(',');
        string country = zeile[1];
        country = country.Trim('"');
        countries.Add(country);
      }
      countries.RemoveAt(0);
      return countries;
    }

  }
}
