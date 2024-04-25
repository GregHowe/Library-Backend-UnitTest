using LibraryBackend;
using Microsoft.EntityFrameworkCore;
using LibraryBackend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using LibraryBackend.Repository;
using LibraryBackend.Services;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container. ----------------------------------------------------
builder.Services.AddControllers();

builder.Services.AddDbContext<BooksContext>(opt =>opt.UseInMemoryDatabase("InMemoryDB"));

builder.Services.AddScoped<IBookContext, BooksContext>();
builder.Services.AddScoped<ILibraryRepository, LibraryRepository> ();
builder.Services.AddScoped<ILibraryService, LibraryService>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options => {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = config["Jwt:Issuer"],
                     ValidAudience = config["Jwt:Audience"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))
                 };
             });

builder.Services.AddCors(opt => opt.AddPolicy("AllowWebApp", build => build.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline. --------------------------------------------------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowWebApp");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
