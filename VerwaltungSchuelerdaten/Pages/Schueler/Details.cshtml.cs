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
    public class DetailsModel : PageModel
    {
        private readonly VerwaltungSchuelerdaten.Data.VerwaltungSchuelerdatenContext _context;

        public DetailsModel(VerwaltungSchuelerdaten.Data.VerwaltungSchuelerdatenContext context)
        {
            _context = context;
        }

        public SchuelerDaten SchuelerDaten { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SchuelerDaten = await _context.SchuelerDaten.FirstOrDefaultAsync(m => m.ID == id);

            if (SchuelerDaten == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
