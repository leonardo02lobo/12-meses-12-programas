using BackendBookMarks.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // Permite cualquier origen (en producci�n, reemplaza con tus dominios)
              .AllowAnyMethod()  // GET, POST, PUT, DELETE, etc.
              .AllowAnyHeader(); // Cabeceras como Content-Type, Authorization
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookMarkContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("DB")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll"); // Despu�s de HTTPS, antes de Auth y Controllers
app.UseAuthorization();
app.MapControllers();

app.Run();
