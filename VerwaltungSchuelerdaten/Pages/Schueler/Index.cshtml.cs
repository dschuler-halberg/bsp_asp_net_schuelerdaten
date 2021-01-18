using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public IList<SchuelerDaten> SchuelerDaten { get;set; }

        public async Task OnGetAsync()
        {
            SchuelerDaten = await _context.SchuelerDaten.ToListAsync();
        }
    }
}
