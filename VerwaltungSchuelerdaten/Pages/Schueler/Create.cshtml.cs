using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VerwaltungSchuelerdaten.Data;
using VerwaltungSchuelerdaten.Models;

namespace VerwaltungSchuelerdaten.Pages.Schueler
{
    public class CreateModel : PageModel
    {
        private readonly VerwaltungSchuelerdaten.Data.VerwaltungSchuelerdatenContext _context;

        public CreateModel(VerwaltungSchuelerdaten.Data.VerwaltungSchuelerdatenContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SchuelerDaten SchuelerDaten { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SchuelerDaten.Add(SchuelerDaten);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
