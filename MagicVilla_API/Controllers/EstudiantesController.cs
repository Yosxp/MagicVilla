using MagicVilla.Aplicacion.DTO;
using MagicVilla.Aplicacion.Interface;
using MagicVilla.Dominio.Entidades;
using MagicVilla.Infraestructura.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla.Servicio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly IManagerEstudiante _managerEstudiantes;
        public EstudiantesController(IManagerEstudiante managerEstudiantes)
        {
            _managerEstudiantes = managerEstudiantes;
        }

        [HttpGet]
        public async Task<ActionResult<EstudianteDto[]>> GetEstudiantes()
        {
            return Ok(_managerEstudiantes.ObtenerEstudiante());

        }
    }
}
