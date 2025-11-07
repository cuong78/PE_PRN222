using Microsoft.AspNetCore.Authentication.Cookies;
using SupermarketparkingManagement_CuongCla.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped <IParkingRecordService, ParkingRecordService>();
builder.Services.AddScoped<VehicleTypeService>();
builder.Services.AddScoped<SystemAccountService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        //n?u ?? bài yêu c?u thay ??i các path m?c ??nh
        options.LoginPath = "/Login";

        options.AccessDeniedPath = "/Account/Forbidden";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
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

app.UseAuthorization();

app.MapRazorPages().RequireAuthorization();

app.Run();
