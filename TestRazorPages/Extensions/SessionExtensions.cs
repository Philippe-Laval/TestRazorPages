namespace TestRazorPages.Extensions;

// https://www.learnrazorpages.com/razor-pages/session-state
//
// public void OnGet()
// {
//     HttpContext.Session.SetString("Test String", "1");
//     HttpContext.Session.SetInt32("Test Int", 1);
//     HttpContext.Session.SetBoolean("Test Bool", true);
// }
//
// public void OnPost()
// {
//     ViewData["Test String"] = Name = HttpContext.Session.GetString("Test String");
//     ViewData["Test Int"] = HttpContext.Session.GetInt32("Test Int");
//     ViewData["Test Bool"] = HttpContext.Session.GetBoolean("Test Bool");
// }

public static class SessionExtensions
{
    public static bool? GetBoolean(this ISession session, string key)
    {
        var data = session.Get(key);
        if (data == null)
        {
            return null;
        }
        return BitConverter.ToBoolean(data, 0);
    }
    
    public static void SetBoolean(this ISession session, string key, bool value)
    {
        session.Set(key, BitConverter.GetBytes(value));
    }
}