using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VerwaltungSchuelerdaten.Models;

namespace VerwaltungSchuelerdaten.Pages.Upload
{
  public class ViewImagesModel : PageModel
  {
    private readonly VerwaltungSchuelerdaten.Data.VerwaltungSchuelerdatenContext _context;

    public ViewImagesModel(VerwaltungSchuelerdaten.Data.VerwaltungSchuelerdatenContext context)
    {
      _context = context;
    }

    public string ImageDataBase64 { get; set; }
    
    public Image Image { get; set; }
    public void OnGet()
    {
      Image img = _context.Images.FirstOrDefault();
      Image = img;
      string imageBase64Data = Convert.ToBase64String(img.ImageData);
      string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
      ImageDataBase64 = imageDataURL;
    }
  }
}
