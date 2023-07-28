using MagicVilla.Aplicacion.Core;
using MagicVilla.Aplicacion.Interface;
using MagicVilla.Dominio.Core;
using MagicVilla.Dominio.Interface;
using MagicVilla.Infraestructura.Core;
using MagicVilla.Infraestructura.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IContextoDB, ContextoDB>();
builder.Services.AddScoped<IManagerPersona, ManagerPersona>();  //Yosva
builder.Services.AddScoped<IServicioPersona, ServicioPersona>();  //yosva
builder.Services.AddScoped<IManagerEstudiante, ManagerEstudiante>();  //Yosva
builder.Services.AddScoped<IServicioEstudiante, ServicioEstudiante>();  //yosva
builder.Services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
