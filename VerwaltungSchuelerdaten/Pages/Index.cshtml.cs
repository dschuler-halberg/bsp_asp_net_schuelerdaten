using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VerwaltungSchuelerdaten.Models;



namespace VerwaltungSchuelerdaten.Pages

{
  public class IndexModel : PageModel
  {

    public IList<SchuelerDaten> SchuelerDaten { get; set; }

    private readonly VerwaltungSchuelerdaten.Data.VerwaltungSchuelerdatenContext _context;

    public IndexModel(VerwaltungSchuelerdaten.Data.VerwaltungSchuelerdatenContext context)
    {
      _context = context;
    }


    public void OnGet()
    {
      SchuelerDaten = _context.SchuelerDaten.
        Include(x => x.Klasse).
        Include(x => x.Adresse).
        ToList();

      //Note n  = _context.Note.FirstOrDefault();
      //ViewData["note"] = n.Beschreibung;
    }
  }
}
