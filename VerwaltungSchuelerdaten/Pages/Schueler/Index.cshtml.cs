using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VerwaltungSchuelerdaten.Data;
using VerwaltungSchuelerdaten.Models;

namespace VerwaltungSchuelerdaten.Pages.Schueler
{
  public class IndexModel : PageModel
  {
    private readonly VerwaltungSchuelerdaten.Data.VerwaltungSchuelerdatenContext _context;

    public IndexModel(VerwaltungSchuelerdaten.Data.VerwaltungSchuelerdatenContext context)
    {
      _context = context;
    }

    public IList<SchuelerDaten> SchuelerDaten { get; set; }

    [BindProperty(SupportsGet = true)]
    public string Suche { get; set; }

    [BindProperty(SupportsGet = true)]
    public string SucheKonfession { get; set; }

    public SelectList Konfessionen { get; set; }


    public async Task OnGetAsync()
    {
      SchuelerDaten = await _context.SchuelerDaten.ToListAsync();
  
      Konfessionen = new SelectList(SchuelerDaten.Select(x => x.Konfession).Distinct().ToList());
      if (!string.IsNullOrEmpty(Suche))
      {
        SchuelerDaten = SchuelerDaten.Where(x =>
        x.Vorname.ToLower().Contains(Suche.ToLower()) ||
        x.Nachname.ToLower().Contains(Suche.ToLower()) ||
        x.EMail.ToLower().Contains(Suche.ToLower()) ||
        x.Telefonnummer.ToLower().Contains(Suche.ToLower())
        ).ToList();

      }

      if (!string.IsNullOrEmpty(SucheKonfession))
      {
        SchuelerDaten = SchuelerDaten.Where(x => x.Konfession.ToLower().Contains(SucheKonfession.ToLower())).ToList();
      }
    }
  }
}
