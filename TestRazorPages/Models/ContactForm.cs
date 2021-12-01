namespace TestRazorPages.Models;

public class ContactForm
{
    public string Email { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public Priority Priority { get; set; } = Priority.Low;
}

public enum Priority
{
    Low, Medium, High
}