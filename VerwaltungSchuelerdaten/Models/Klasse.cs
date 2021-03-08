using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VerwaltungSchuelerdaten.Models
{
  [Table("Klassen")]
  public class Klasse
  {

    public int ID { get; set; }

    public string Name { get; set; }

    public string Beschreibung { get; set; }

    public virtual SchuelerDaten KlassenSprecherIn { get; set; }

    public virtual ICollection<SchuelerDaten> Schueler {get; set;}

  }
}
