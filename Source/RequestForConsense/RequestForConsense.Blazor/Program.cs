using Microsoft.AspNetCore.Identity;
using RequestForConsense.BL;
using RequestForConsense.BL.ConfigurationManagement;
using RequestForConsense.BL.DatabaseAccess;
using RequestForConsense.BL.UserAuthentication;

var configPath = ConfigurationFileFinder.FindConfigurationFile(AppContext.BaseDirectory);
var configurationManager = new RequestForConsense.BL.ConfigurationManagement.ConfigurationManager(configPath);
InteractorFactory.SetConnectionString(configurationManager.GetConnectionString());
var connectionString = configurationManager.GetConnectionString();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddIdentity<User, IdentityRole>()
        .AddUserStore<UserStore>()
        .AddDefaultTokenProviders();

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<IRoleStore<IdentityRole>, WeDoNotWantARoleStore>();
builder.Services.AddScoped<IPasswordHasher<User>, BCryptPasswordHasher<User>>();
builder.Services.AddScoped<IUserClaimsPrincipalFactory<User>, CustomUserClaimsPrincipalFactory>();

builder.Services.AddScoped<IDatabaseAccessor>(
    provider =>
    new MySqlDatabaseAccessor(connectionString));

builder.Services.AddScoped<IUserStore<User>, UserStore>();


//builder.Services.AddSingleton<WeatherForecastService>();
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
app.UseAuthentication();
app.UseAuthorization();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
