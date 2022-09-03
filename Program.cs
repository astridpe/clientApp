using customerApp.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
IServiceCollection serviceCollection = builder.Services.AddDbContext<CustomerDB>(options => options.UseSqlite("Data source=Customer.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapGet("/", () => "Hello!");

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();