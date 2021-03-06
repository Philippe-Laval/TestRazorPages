// Learn Razor Pages
// https://www.learnrazorpages.com/
//
// View Components in Razor Pages
// https://www.learnrazorpages.com/razor-pages/view-components

using TestRazorPages.Extensions;
using TestRazorPages.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterMyServices();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseStatusCodePagesWithReExecute("/Error", "?code={0}");

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();