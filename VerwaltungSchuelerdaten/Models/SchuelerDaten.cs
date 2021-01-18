using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VerwaltungSchuelerdaten.Models
{
  public class SchuelerDaten
  {

    public int ID { get; set; }

    public string Vorname { get; set; }
    public string Nachname { get; set; }

    [DataType(DataType.Date)]
    public DateTime Geburtsdatum { get; set; }
    public string EMail { get; set; }
    public string Telefonnummer { get; set; }
    public string Konfession { get; set; }
    public string Staatsangehoerigkeit { get; set; }
    public string ZweiteStaatsangehoerigkeit { get; set; }

    [DataType(DataType.Date)]
    public DateTime Anmeldedatum { get; set; }
    public string Kommentar { get; set; }


    public static List<string> Konfessionen { get; set; } = 
      new List<string> { "katholisch", "evangelisch", "islam", "keine" };


  }
}
