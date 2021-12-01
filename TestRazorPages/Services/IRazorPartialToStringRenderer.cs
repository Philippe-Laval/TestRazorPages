namespace TestRazorPages.Services;

public interface IRazorPartialToStringRenderer
{
    Task<string> RenderPartialToStringAsync<TModel>(string partialName, TModel model);
}