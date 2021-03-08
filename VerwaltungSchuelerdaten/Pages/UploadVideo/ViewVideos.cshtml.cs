using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VerwaltungSchuelerdaten.Models;

namespace VerwaltungSchuelerdaten.Pages.UploadVideo
{
  public class ViewVideosModel : PageModel
  {
    private readonly VerwaltungSchuelerdaten.Data.VerwaltungSchuelerdatenContext _context;

    public ViewVideosModel(VerwaltungSchuelerdaten.Data.VerwaltungSchuelerdatenContext context)
    {
      _context = context;
    }

    public List<string> VideoDataBase64 { get; set; } = new List<string>();
    
    public List<Video> Videos { get; set; }
    public void OnGet()
    {
      Videos = _context.Videos.ToList();
      foreach (Video v in Videos)
      {
        string VideoBase64Data = Convert.ToBase64String(v.VideoData);
        string VideoDataURL = string.Format("data:Video/webm;base64,{0}", VideoBase64Data);
        VideoDataBase64.Add(VideoDataURL);
      }
    }
  }
}
