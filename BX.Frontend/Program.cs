using BX.Frontend.Components;
using BX.Frontend.Components.Account;
using BX.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

#region Services Implementation
// Add services to the container.

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
//builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>(); //Not included yet

builder.Services.AddAuthorizationCore();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
#endregion

#region SQL Server Connection
//Run this string as your secret in the local terminal
//dotnet user-secrets set "ConnectionStrings:userSecretDB" "<connection-string>"
//var connectionString = builder.Configuration.GetConnectionString("userSecretDB");
//if (connectionString.IsNullOrEmpty())
//{
//    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//}

//builder.Services.AddDbContext<BuildXpertContext>(options =>
//{
//    options.UseSqlServer(connectionString, slqOptionsAction => slqOptionsAction.EnableRetryOnFailure());
//});
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseMigrationsEndPoint();
//}
//else
//{
//    app.UseExceptionHandler("/Error", createScopeForErrors: true);
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

app.UseAntiforgery();
app.UseHttpsRedirection();


app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();