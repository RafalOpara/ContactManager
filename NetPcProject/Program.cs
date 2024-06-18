using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NetPc;
using NetPcProject;
using NetPcProject.Core.Interfacess;
using NetPcProjectDataBase.Enitites;
using NetPcProjectDataBase.Repositories.Interfaces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddTransient<IContactManager, ContactManager>();
builder.Services.AddTransient<IUserManager, UserManager>();




builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<IContactCategoryRepository, ContactCategoryRepository>();
builder.Services.AddTransient<IRoleRepository, RoleRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();


builder.Services.AddTransient<DtoMapper>();
builder.Services.AddTransient<ViewModelMapper>();



var authenticationSettings = new AuthenticationSettings();
builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);

builder.Services.AddSingleton(authenticationSettings);

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true, // W≥πczenie walidacji wydawcy
        ValidateAudience = true, // W≥πczenie walidacji odbiorcy
        ValidIssuer = authenticationSettings.JwtIssuer, // Ustawienie oczekiwanego wydawcy
        ValidAudience = authenticationSettings.JwtIssuer, // Ustawienie oczekiwanego odbiorcy, uøyj odpowiedniego pola, jeúli masz inne dla odbiorcy
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)), // Klucz do podpisu
    };
});
   



builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddDbContext<NetPcDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("NetPcProjectDataBase"));

});


var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var dbContext = serviceProvider.GetRequiredService<NetPcDbContext>();

    // Sprawdü, czy tabela kategorii jest pusta
    if (!dbContext.ContactCategory.Any())
    {
        // Dodaj przyk≥adowe kategorie do bazy danych
        dbContext.ContactCategory.AddRange(new[]
        {
        
            new ContactCategory { Name = "S≥uøbowy" },
            new ContactCategory { Name = "Prywatny" },
            new ContactCategory { Name = "Inny" }
        });

       
    }

    if (!dbContext.Roles.Any())
    {
        // Dodaj przyk≥adowe kategorie do bazy danych
        dbContext.Roles.AddRange(new[]
        {

            new Role { Name = "Admin" },
            new Role { Name = "User" },
           
        });

       
    }
    dbContext.SaveChanges();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
