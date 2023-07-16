using MagicVilla.Dominio.Entidades;
using MagicVilla.Infraestructura.Interface;
using Microsoft.AspNetCore.Mvc;


namespace MagicVilla_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRepositorio<Persona> _personas;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRepositorio<Persona> personas)
        {
            _logger = logger;
            _personas = personas;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            List<Persona> personas = _personas.GetAll().ToList();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}