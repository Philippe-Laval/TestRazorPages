using Microsoft.AspNetCore.Mvc;
using TestRazorPages.Services;

namespace TestRazorPages.ViewComponents;

public class UsersViewComponent : ViewComponent
{
    private readonly IUserService _userService;
    
    public UsersViewComponent(IUserService userService)
    {
        _userService = userService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var users = await _userService.GetUsersAsync();
        return View(users);
    }
}