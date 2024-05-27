//using webapi.Domain.Infrastructure.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using FastEndpoints;
using FastEndpoints.Swagger;
using System.Reflection;
using webapi.Features.TodoList.GetAll;
using shared.Domain.Entities;
using webapi.Features.Infrastructure.Data;
using shared.Models.ToDoLists;

var builder = WebApplication.CreateBuilder(args);

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

var app = builder.Build();


app.MapGet("/", () => "Hello World!");



app.UseFastEndpoints().UseSwaggerGen();

app.Run();









