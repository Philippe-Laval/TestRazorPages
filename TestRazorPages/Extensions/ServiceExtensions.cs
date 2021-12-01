using TestRazorPages.Services;

namespace TestRazorPages.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterMyServices(this IServiceCollection services)
    {
        return services
            .AddTransient<ICommentService, CommentService>()
            .AddTransient<IUserService, UserService>()
            .AddTransient<IEmailService, EmailService>()
            .AddTransient<IRazorPartialToStringRenderer, RazorPartialToStringRenderer>();
    }
}