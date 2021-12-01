using System.Text.Json;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace TestRazorPages.Extensions;

// https://www.learnrazorpages.com/razor-pages/tempdata
//
// var contact = new Contact { FirstName = "Mike", Domain = "learnrazorpages.com" };
// TempData.Set("Mike", contact);
// var mike = TempData.Get<Contact>("Mike");

public static class TempDataExtensions
{
    public static void Set<T>(this ITempDataDictionary tempData, string key, T value) where T : class
    {
        //tempData[key] = JsonConvert.SerializeObject(value);
        tempData[key] = JsonSerializer.Serialize(value);
    }
    public static T? Get<T>(this ITempDataDictionary tempData, string key) where T : class
    {
        tempData.TryGetValue(key, out object? o);
        //return o == null ? null : JsonConvert.DeserializeObject<T>((string)o);
        return o == null ? null : JsonSerializer.Deserialize<T>((string)o);
    }
}