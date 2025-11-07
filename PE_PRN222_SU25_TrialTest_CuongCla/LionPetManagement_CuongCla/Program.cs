using LionPetManagement.Service;
using LionPetManagement_CuongCla.Hubs;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSignalR();
builder.Services.AddScoped <ILionProfileService, LionProfileService>();
builder.Services.AddScoped<LionTypeService>();
builder.Services.AddScoped<LionAccountService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        //nếu đề bài yêu cầu thay đổi các path mặc định
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

app.MapHub<LionHub>("/LionHub");
app.Run();
