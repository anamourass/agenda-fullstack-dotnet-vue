using Microsoft.EntityFrameworkCore;
using AgendaApiNova.Data;
using AgendaApiNova.Interfaces;
using AgendaApiNova.Repositories;
using AgendaApiNova.Services;
using AgendaApiNova.Mappings;
using AgendaApiNova.Validators;
using AgendaApiNova.DTOs;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurações de Banco e Controllers
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("AgendaDb"));

// 2. Injeção de Dependência (As 3 peças principais)
builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
builder.Services.AddScoped<IContatoService, ContatoService>();
builder.Services.AddScoped<IValidator<ContatoDTO>, ContatoDTOValidator>();

// 3. AutoMapper e Swagger
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 4. Configuração do CORS (Para o Vue.js conversar com o C#)
builder.Services.AddCors(opt => opt.AddPolicy("LiberarVue", 
    p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

// 5. Ativando as funcionalidades
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("LiberarVue");
app.MapControllers();

app.Run();