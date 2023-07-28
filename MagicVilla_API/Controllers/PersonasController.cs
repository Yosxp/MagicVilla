using MagicVilla.Aplicacion.DTO;
using MagicVilla.Aplicacion.Interface;
using MagicVilla.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MagicVilla_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly IManagerPersona _managerPersonas;
        public PersonasController(IManagerPersona managerPersonas)
        {
            _managerPersonas = managerPersonas;
        }

        [HttpGet("Obtener Lista de Personas")]
        public async Task<ActionResult<PersonaDto[]>> GetPersonas()
        {
            return Ok(_managerPersonas.ObtenerPersona());

        }

        [HttpGet("Obtener Persona por el Id")]
        public async Task<ActionResult<PersonaDto>> GetPersonaId(int id)
        {
            var persona = _managerPersonas.BuscarPersona(id);
            
            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }

        [HttpPost("Adicionar Nueva Persona")]
        public async Task<ActionResult<AddPersonaDto>> AdcionarPersona(AddPersonaDto PersonaDto)
        {
            var nuevaPersona = new Persona
            {
                //Id = PersonaDto.Id,
                Nombre = PersonaDto.Nombre,
                Apellidos = PersonaDto.Apellidos,
                Sexo = PersonaDto.Sexo
            };

            _managerPersonas.AddPersona(nuevaPersona);
          
            return Ok(nuevaPersona);
               

        }


    }
}