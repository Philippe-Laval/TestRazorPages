using TestRazorPages.Models;

namespace TestRazorPages.Services;

public interface IUserService
{
    Task<List<User?>> GetUsersAsync();
    Task<User?> GetUserAsync(int id);
}