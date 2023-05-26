using PhoneBook.Apllication.Interfaces;
using PhoneBook.Persistence.Repository;
using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PhoneBook.Apllication.Interfaces;
using PhoneBook.JWTAuthentication;
using PhoneBook.JWTAuthentication.AuthInterfaces;
using PhoneBook.Persistence;
using PhoneBook.Persistence.AuthRepositories;
using PhoneBook.Persistence.Repository;
using System.Configuration;
using System.Reflection;
using System.Text;
using PhoneBook.Apllication.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddControllers();
builder.Services.AddMediatR(typeof(IAsyncRepository).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAsyncRepository, AsyncRepository>();


//JWT Sitting

builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
//Connection string
builder.Services.AddScoped<IAuthService, AuthService>();
//builder.Services.AddScoped<IAsyncRepository, AsyncRepository>();
builder.Services.AddScoped(typeof(IAsyncRepository), typeof(AsyncRepository));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDBContext>();
builder.Services.AddDbContext<ApplicationDBContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));


//AddAuthentication JWT Setting
//builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
//   .AddNegotiate();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
               .AddJwtBearer(o =>
               {
                   o.RequireHttpsMetadata = false;
                   o.SaveToken = false;
                   o.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidIssuer = builder.Configuration["JWT:Issuer"],
                       ValidAudience = builder.Configuration["JWT:Audience"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                   };
               });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
