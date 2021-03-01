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

    public SelectList FirstNames { get; set; }

    public IndexModel(VerwaltungSchuelerdaten.Data.VerwaltungSchuelerdatenContext context)
    {
      _context = context;

      FirstNames = new SelectList(_context.SchuelerDaten.Select(x => x.Vorname).Distinct().ToList());
    }

    public IList<SchuelerDaten> SchuelerDaten { get; set; }

    [BindProperty(SupportsGet = true)]
    public string SearchString { get; set; }


    [BindProperty(SupportsGet = true)]
    public string SearchStringFirstname { get; set; }

    public async Task OnGetAsync()
    {
      SchuelerDaten = await _context.SchuelerDaten.Include(x=>x.Klasse).ToListAsync();
      string s = SchuelerDaten.First().Klasse.Name;
      if (!string.IsNullOrEmpty(SearchString))
      {
        SchuelerDaten = SchuelerDaten.Where(x => x.Nachname.Contains(SearchString)).ToList();
      }

      if (!string.IsNullOrEmpty(SearchStringFirstname))
      {
        SchuelerDaten = SchuelerDaten.Where(x => x.Vorname.Contains(SearchStringFirstname)).ToList();
      }

    }
  }
}
