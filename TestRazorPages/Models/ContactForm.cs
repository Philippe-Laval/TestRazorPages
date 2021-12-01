namespace TestRazorPages.Models;

public class ContactForm
{
    public string Email { get; set; }
    public string Message { get; set; }
    public string Name { get; set; }
    public string Subject { get; set; }
    public Priority Priority { get; set; }
}
public enum Priority
{
    Low, Medium, High
}