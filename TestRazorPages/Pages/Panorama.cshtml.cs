using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestRazorPages.Pages;

public class Panorama : PageModel
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private const string DefaultPanoramaCity = "Monaco";
    private const string DefaultPanoramaName = "Monaco04_6000";
   
    /// <summary>
    /// The city of the panorama like "Monaco"
    /// </summary>
    public string PanoramaCity { get; private set; } = DefaultPanoramaCity;
    
    /// <summary>
    /// The name of the panorama like "Monaco04_6000"
    /// </summary>
    public string PanoramaName { get; private set; } = DefaultPanoramaName;

    
    /// <summary>
    /// The path to the panorama like "/Images/Panorama/Monaco/Monaco04_6000.jpg"
    /// </summary>
    public string PanoramaPath { get; private set; } = string.Empty;
    
    public string Title { get; private set; } = default!;
    
    
    public Panorama(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }
    
    public IActionResult OnGet(string? city, string? name)
    {
        if (string.IsNullOrWhiteSpace(city) && string.IsNullOrWhiteSpace(name))
        {
            ViewData["Layout"] = "_Layout";
            PanoramaPath = string.Empty;
            
            return Page();
        }

        if (string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(name))
        {
            return NotFound();
        }
        
        // city ??= DefaultPanoramaCity;
        // name ??= DefaultPanoramaName;

        ViewData["Layout"] = null;
        
        PanoramaPath = $"/Images/Panorama/{city}/{name}.jpg";
        Title = $"Panorama {name} de la ville {city}";
        
        string rootPath = _webHostEnvironment.WebRootPath;
        string filePath = Path.Combine(rootPath, $"Images/Panorama/{city}/{name}.jpg");
        if (!System.IO.File.Exists(filePath))
        {
            return NotFound();
            //string location = $"/Panorama/{DefaultPanoramaCity}/{DefaultPanoramaName}.jpg";
            //this.Response.Redirect(location, false);
            
         //   return RedirectToPage("Panorama", null, 
         //       new { city = DefaultPanoramaCity, name = DefaultPanoramaName });
        }

        return Page();
    }
}