using Microsoft.EntityFrameworkCore;
using Assignment3.Data;
using Assignment3.Services;

// FOR API
using System.Net.Http.Headers; 
using System.Net.Mime; 
using Assignment3.Models.Repository; 
using Assignment3.Models.DataManager; 

var builder = WebApplication.CreateBuilder(args);

// Configure api client.
builder.Services.AddHttpClient("api", client =>
{
    client.BaseAddress = new Uri("http://localhost:5198"); // API's Port 
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
});

// Add DbContext to connect to database
builder.Services.AddDbContext<AssignmentDbContext>(options =>
{
    // Requires EFCore SqlServer installed
    options.UseSqlServer(builder.Configuration.GetConnectionString("AssignmentDbContext") ?? throw new InvalidOperationException("Connection string to database not found."));
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<DataSeeder>(); // Seeds default data
builder.Services.AddScoped<IStudentRepository, StudentManager>(); // For API

var app = builder.Build();

// Seed data if needed
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    await seeder.SeedAsync();
    Console.WriteLine("Database ready.");
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
