using Microsoft.EntityFrameworkCore;
using VueTodoBackEnd.Models;
using VueTodoBackEnd.Services;
using VueTodoBackEnd.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(p => p.AddDefaultPolicy(build =>
{
    build.WithOrigins("http://localhost:4000");
    build.AllowAnyMethod();
    build.AllowAnyHeader();
}));

builder.Services.AddCors(p => p.AddPolicy("policy1", build =>
{
    build.WithOrigins("http://localhost:4000");
    build.AllowAnyMethod();
    build.AllowAnyHeader();
}));

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TodoDbContext>(opt =>
    opt.UseSqlServer(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITodo, EFTodoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
