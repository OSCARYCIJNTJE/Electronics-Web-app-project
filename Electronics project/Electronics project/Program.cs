using Electronics.Infracstructure.ProductsRepo;
using Electronics.Infracstructure.UsersRepo;
using Electronics.Logic.InterfaceServicesFolder;
using Electronics.Logic.ProductsServicesFolder;
using Electronics.Logic.UserServicesFolder;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<ComputerServices>();
builder.Services.AddScoped<IComputer, ComputerRepo>();
builder.Services.AddScoped<PhoneServices>();
builder.Services.AddScoped<IPhone, PhoneRepo>();
builder.Services.AddScoped<CustomerServices>();
builder.Services.AddScoped<ICustomer, CustomerRepo>();
builder.Services.AddScoped<IOrder, OrderRepo>();
builder.Services.AddScoped<OrderServices>();
builder.Services.AddScoped<ElectronicServices>();
builder.Services.AddScoped<IElectronic, ElectronicRepo>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = new PathString("/Login");
    options.AccessDeniedPath = new PathString("/AccessDenied");
}
);

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
