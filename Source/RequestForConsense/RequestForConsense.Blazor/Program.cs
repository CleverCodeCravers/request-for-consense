using RequestForConsense.BL;
using RequestForConsense.BL.ConfigurationManagement;
using RequestForConsense.Blazor.Data;

var configPath = ConfigurationFileFinder.FindConfigurationFile(AppContext.BaseDirectory);
var configurationManager = new RequestForConsense.BL.ConfigurationManagement.ConfigurationManager(configPath);
InteractorFactory.SetConnectionString(configurationManager.GetConnectionString());

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

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

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
