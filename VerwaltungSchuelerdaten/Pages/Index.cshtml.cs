using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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


    public void OnGet()
    {
      SchuelerDaten = _context.SchuelerDaten.ToList();
    }
  }
}
