using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VerwaltungSchuelerdaten.Models;

namespace VerwaltungSchuelerdaten.Pages.Upload
{
  public class IndexModel : PageModel
  {
    private readonly VerwaltungSchuelerdaten.Data.VerwaltungSchuelerdatenContext _context;

    public IndexModel(VerwaltungSchuelerdaten.Data.VerwaltungSchuelerdatenContext context)
    {
      _context = context;
    }


    public void OnGet()
    {
    }

    [BindProperty]
    public IFormFile Upload { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
      using (var memoryStream = new MemoryStream())
      {
        await Upload.CopyToAsync(memoryStream);

        // Upload the file if less than 2 MB
        if (memoryStream.Length < 2097152)
        {
          var image = new Image()
          {
            ImageData = memoryStream.ToArray(),
            ImageTitle = Upload.FileName
          };

          _context.Images.Add(image);

          await _context.SaveChangesAsync();
        }
        else
        {
          ModelState.AddModelError("File", "The file is too large.");
        }
      }

      return Page();
    }
  }
}
