using customerApp.DAL;
using customerApp.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
IServiceCollection serviceCollection = builder.Services.AddDbContext<CustomerDB>(options => options.UseSqlite("Data source=Customer.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
    DBInit.Initialize(app); // This must be removed if we want to keep the data in the database and not intitialize for each run.
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapGet("/", () => "Hello!");

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();