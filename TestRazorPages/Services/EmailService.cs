using System.Net.Mail;

namespace TestRazorPages.Services;

// https://www.learnrazorpages.com/advanced/render-partial-to-string

public class EmailService : IEmailService
{
    private const string ContactDomainCom = "contact@domain.com";

    public async Task SendAsync(string email, string name, string subject, string body)
    {
        using (var smtp = new SmtpClient())
        {
            smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            smtp.PickupDirectoryLocation = @"c:\maildump";
            var message = new MailMessage
            {
                Body = body,
                Subject = subject,
                From = new MailAddress(email, name),
                IsBodyHtml = true
            };
            
            message.To.Add(ContactDomainCom);
            
            await smtp.SendMailAsync(message);
        }
    }
}