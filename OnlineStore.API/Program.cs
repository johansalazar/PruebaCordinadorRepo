using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using OnlineStore.Application.Handlers;
using OnlineStore.Application.Mappings;
using OnlineStore.Domain.Interfaces;
using OnlineStore.Infrastructure.Data;
using OnlineStore.Infrastructure.Messaging;
using OnlineStore.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Leer configuración de RabbitMQ desde appsettings.json
var rabbitMQSettings = builder.Configuration.GetSection("RabbitMQ").Get<RabbitMQSettings>();

// Registrar RabbitMQSettings en el contenedor de servicios
builder.Services.AddSingleton(rabbitMQSettings);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Agregar servicios al contenedor
builder.Services.AddControllers();

// Configurar DbContext para SQL Server
builder.Services.AddDbContext<OnlineStoreDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile)); // Registrar AutoMapper

// Agregar MediatR
builder.Services.AddMediatR(typeof(GetAllPedidosQueryHandler).Assembly); // Registrar todos los handlers
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());



// Configurar inyección de dependencias
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();

//builder.Services.AddSingleton<IMessageProducer, RabbitMQProducer>();
builder.Services.AddSingleton<IMessageProducer>(sp => new RabbitMQProducer(rabbitMQSettings));
builder.Services.AddHostedService<RabbitMQConsumer>();


builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "OnlineStore API", Version = "v1" });
});

var app = builder.Build();

// Configurar el pipeline HTTP
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnlineStore API v1");
});

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();