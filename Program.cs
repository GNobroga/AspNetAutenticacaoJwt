using System.Runtime.CompilerServices;
using System.Text;
using AspNetAutenticacaoJwt.Auth;
using AspNetAutenticacaoJwt.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<TokenService>();
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new() 
        {   
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateActor = false,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("gabrielcardosogirarde12345678913465555555dddddddddddddddddddddddddddddddddddddddd5555")),
            ValidAlgorithms = new[] { "HS256" }
        };
    });

builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlite("Data source=app.db");
});

builder.Services
    .AddIdentity<IdentityUser, IdentityRole>(options => {
        options.Password = new PasswordOptions() {
            RequireDigit = false,
            RequiredLength = 0,
            RequireLowercase = false,
            RequireUppercase = false,
            RequiredUniqueChars = 0,
            RequireNonAlphanumeric = false
        };
    })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.Run();


