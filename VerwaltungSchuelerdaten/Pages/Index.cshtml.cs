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

    [BindProperty(SupportsGet = true)]
    public string Suche { get; set; }

    [BindProperty(SupportsGet = true)]
    public string SucheVorname { get; set; }

    public SelectList Vornamen { get; set; }


    public void OnGet()
    {
      SchuelerDaten = _context.SchuelerDaten.Include(x => x.Klasse).ToList();
    }
  }
}
