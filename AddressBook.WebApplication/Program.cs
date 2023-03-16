using AddressBook.Helpers;
using AddressBook.Infrastructure.DBContext;
using AddressBook.Services.Contacts.Interfaces;
using AddressBook.Services.Contacts.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IContactServices, ContactServices>();

builder.Services.AddAutoMapper(typeof(ContactMapper).Assembly);

builder.Services.AddDbContext<AddressBookDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDBConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contact}/{action=Index}/{id?}");

app.Run();
