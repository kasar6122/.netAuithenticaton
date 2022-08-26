using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//private const string Secret_Key = "ksaderejkasdiarikabirfjsfsdjfjisadsfsdkfkdfarhanlsflsfkd";
//public static readonly SymmetricSecurityKey Signing_Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Secretkey"));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
}).AddJwtBearer("JwtBearer", jwtOptions =>
{
    jwtOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ksaderejkasdiarikabirfjsfsdjfjisadsfsdkfkdfarhanlsflsfkd")),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = "http://localhost:44315",
        ValidAudience = "http://localhost:44315",
        ValidateLifetime = true,
    };
});
builder.Services.AddDbContext<StudentContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("ERPConnection")));
var app = builder.Build();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
