using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VerwaltungSchuelerdaten.Models
{
  public class Note
  {

    public int ID { get; set; }

    public int Notenwert { get; set; }

    public string Beschreibung { get; set; }
      
    public virtual SchuelerDaten Schueler { get; set; }


  }
}
