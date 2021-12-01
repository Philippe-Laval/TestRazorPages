using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestRazorPages.Models;
using TestRazorPages.Services;

namespace TestRazorPages.Pages;

public class Contact : PageModel
{
    private readonly IRazorPartialToStringRenderer _renderer;
    private readonly IEmailService _emailer;

    public Contact(IRazorPartialToStringRenderer renderer, IEmailService emailer)
    {
        _renderer = renderer;
        _emailer = emailer;
    }

    [BindProperty] public ContactForm ContactForm { get; set; }

    [TempData] public string? PostResult { get; set; }

    public IActionResult OnGet()
    {
        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        var body = await _renderer.RenderPartialToStringAsync("_ContactEmailPartial", ContactForm);
        await _emailer.SendAsync(ContactForm.Email, ContactForm.Name, ContactForm.Subject, body);
        PostResult = "Check your specified pickup directory";
        return RedirectToPage();
    }
}