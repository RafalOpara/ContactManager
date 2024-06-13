using Microsoft.EntityFrameworkCore;
using NetPc;
using NetPcProject;
using NetPcProject.Core.ContactCat;
using NetPcProjectDataBase.Enitites;
using YourAppName.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<IContactManager, ContactManager>();
builder.Services.AddTransient<IContactCategoryService, ContactCategoryService>();

builder.Services.AddTransient<DtoMapper>();
builder.Services.AddTransient<ViewModelMapper>();


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

        dbContext.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
