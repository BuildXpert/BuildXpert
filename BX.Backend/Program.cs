using BX.Business.Managers;
using BX.Data.Repositories;
using BX.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using BX.Services;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);


#region Services Implementation
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAuthService, UserService>();
builder.Services.AddScoped<IPropertyManager, PropertyManager>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
#endregion


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<BuildXpertContext>()
    .AddDefaultTokenProviders();

#region SQL Server Connection
//Run this string as your secret in the local terminal
//dotnet user-secrets set "ConnectionStrings:userSecretDB" "<connection-string>"
var connectionString = builder.Configuration.GetConnectionString("userSecretDB");
if (connectionString.IsNullOrEmpty())
{
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); 
}

builder.Services.AddDbContext<BuildXpertContext>(options =>
{
    options.UseSqlServer(connectionString,
    sqlOptions => sqlOptions.MigrationsAssembly("BX.Backend"));
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string[] roles = { "Admin", "Cliente", "MOBS", "Bancario" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHttpsRedirection();

#region Database Migrations
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BuildXpertContext>();
    try
    {
        // Apply pending migrations. This ensures the database is up-to-date.
        dbContext.Database.Migrate();
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred while migrating the database:");
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex);
    }
}
#endregion

app.Run();
