using FluentValidation.AspNetCore;
using TWYLisans.Application.Validators.Products;
using TWYLisans.Persistence;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPersistenceServices();

builder.Services.AddControllersWithViews()
    .AddFluentValidation(configuration=> configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>());


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
   
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
