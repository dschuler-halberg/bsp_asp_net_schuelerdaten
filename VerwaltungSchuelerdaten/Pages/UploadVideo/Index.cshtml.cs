using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VerwaltungSchuelerdaten.Models;

namespace VerwaltungSchuelerdaten.Pages.UploadVideo
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

        // Upload the file if less than ~20 MB
        if (memoryStream.Length < (long) (2 * Math.Pow(10,7)))
        {
          var video = new Video()
          {
            VideoData = memoryStream.ToArray(),
            VideoTitle = Upload.FileName
          };

          _context.Videos.Add(video);

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
