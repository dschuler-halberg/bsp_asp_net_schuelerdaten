using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    private readonly ILogger<IndexModel> _logger;

    public IList<SchuelerDaten> SchuelerDaten { get; set; }

    //public IndexModel(ILogger<IndexModel> logger)
    //{
    //  _logger = logger;
    //}
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
      SchuelerDaten = _context.SchuelerDaten.ToList();
      Vornamen = new SelectList(SchuelerDaten.Select(x => x.Vorname).Distinct().ToList());
      if (!string.IsNullOrEmpty(Suche))
      {
        SchuelerDaten = SchuelerDaten.Where(x => x.Nachname.Contains(Suche)).ToList();
      }
      if (!string.IsNullOrEmpty(SucheVorname))
      {
        SchuelerDaten = SchuelerDaten.Where(x => x.Vorname.Contains(SucheVorname)).ToList();
      }
    }
  }
}
