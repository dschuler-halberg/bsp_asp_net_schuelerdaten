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
    public class EditModel : PageModel
    {
        private readonly VerwaltungSchuelerdaten.Data.VerwaltungSchuelerdatenContext _context;

        public EditModel(VerwaltungSchuelerdaten.Data.VerwaltungSchuelerdatenContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SchuelerDaten).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchuelerDatenExists(SchuelerDaten.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SchuelerDatenExists(int id)
        {
            return _context.SchuelerDaten.Any(e => e.ID == id);
        }
    }
}
