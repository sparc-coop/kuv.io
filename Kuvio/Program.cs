using Sparc.Ibis;
using Sparc.Notifications.Twilio;
using System.Globalization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


builder.Services
    .AddIbis();
    //.AddTwilio(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var supportedCultures = CultureInfo.GetCultures(CultureTypes.AllCultures)
    .Select(x => x.Name)
    .ToArray();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRequestLocalization(options => options
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures));

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
