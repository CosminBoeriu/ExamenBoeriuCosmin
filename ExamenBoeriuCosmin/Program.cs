using ExamenBoeriuCosmin.Data;
using ExamenBoeriuCosmin.Entities;
using ExamenBoeriuCosmin.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(
    opt => opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<ProfesoriRepository>();
builder.Services.AddScoped<MateriiRepository>();
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(policyBuilder =>  policyBuilder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();