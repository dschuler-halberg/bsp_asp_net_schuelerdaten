using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VerwaltungSchuelerdaten.Models
{
  public class Video 
  {
    public int Id { get; set; }
    public string VideoTitle { get; set; }
    public byte[] VideoData { get; set; }
  }
}
