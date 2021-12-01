namespace TestRazorPages.Services;

public interface IEmailService
{
    Task SendAsync(string email, string name, string subject, string body);
}