using Microsoft.EntityFrameworkCore;

using VirtualPetAdoption.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();

builder.Services.AddDbContext<PetAdoptionContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("PetAdoptionContext")));

var app = builder.Build();

// This starts the service in the application container and then ensures the database is created when the service started

// and it runs

using (var scope = app.Services.CreateScope())

{

    var context = scope.ServiceProvider.GetRequiredService<PetAdoptionContext>();

    // Use the database context to create the Pets database

    context.Database.EnsureCreated();

}

// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())

{

    app.UseExceptionHandler("/Error");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

    app.UseHsts();

}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapRazorPages()

   .WithStaticAssets();

app.Run();