using System.Net.Mail;
using System.Runtime.InteropServices;

namespace TestRazorPages.Services;

// https://www.learnrazorpages.com/advanced/render-partial-to-string

// https://stackoverflow.com/questions/38790802/determine-operating-system-in-net-core

public class EmailService : IEmailService
{
    private const string ContactDomainCom = "philippe.laval.1968@laposte.net";

    public async Task SendAsync(string email, string name, string subject, string body)
    {
        using (var smtp = new SmtpClient())
        {
            smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            
            var osNameAndVersion = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            bool isWindows = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            if (isWindows)
            {
                smtp.PickupDirectoryLocation = @"c:\maildump";
            }
            bool isOSX = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
            if (isOSX)
            {
                smtp.PickupDirectoryLocation = @"/Users/philippe/maildump";
            }

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