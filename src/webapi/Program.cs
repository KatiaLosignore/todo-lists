//using webapi.Domain.Infrastructure.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using shared.Domain.Entities;
using webapi.Features.Infrastructure.Data;
using shared.Models.ToDoLists;
using System.Reflection;


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("https://localhost:7251").AllowAnyHeader().AllowAnyMethod();
        });
});



builder.Services.AddFastEndpoints().SwaggerDocument();


builder.Services.AddDbContext<ApplicationDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseInMemoryDatabase(nameof(Todolist));
});

// Registrazione AutoMapper
builder.Services.AddAutoMapper(typeof(ResponseProfile).Assembly);

// Aggiunta altri servizi
builder.Services.AddControllers();


////utilizzo di automapper
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

app.UseFastEndpoints().UseSwaggerGen();

app.MapGet("/", () => "Hello World!");


app.Run();









