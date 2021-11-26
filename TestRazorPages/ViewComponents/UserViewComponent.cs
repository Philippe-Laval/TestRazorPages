using Microsoft.AspNetCore.Mvc;
using TestRazorPages.Services;

namespace TestRazorPages.ViewComponents;

public class UserViewComponent : ViewComponent
{
    private IUserService _userService;
    public UserViewComponent(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<IViewComponentResult> InvokeAsync(int id)
    {
        var user = await _userService.GetUserAsync(id);
        return View(user);
    }
}