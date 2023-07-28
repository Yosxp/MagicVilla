using MagicVilla.Aplicacion.DTO;
using MagicVilla.Aplicacion.Interface;
using MagicVilla.Dominio.Entidades;
using MagicVilla.Dominio.Interface;
using MagicVilla.Infraestructura.Interface;

namespace MagicVilla.Aplicacion.Core
{
    public class ManagerPersona : IManagerPersona
    {
        private readonly IServicioPersona _servicioPersonas;
        private readonly IUnitOfWork _unitOfWork;

        public ManagerPersona(IServicioPersona servicioPersonas, IUnitOfWork unitOfWork)
        {
            _servicioPersonas = servicioPersonas;
            _unitOfWork = unitOfWork;
        }
        
        public PersonaDto[] ObtenerPersona()
        {
            //Devolver listado de todas las personas mediante el tipo lista de tipo PersonaDto

            List<Persona> personas = _servicioPersonas.ObtenerPersonas();
            return personas.Select(x => new PersonaDto 
            {
                Id = x.Id,
                NombreApellidos = x.Nombre + " " + x.Apellidos,
                Sexo = x.Sexo 
            }).ToArray();

        }

        
        public PersonaDto BuscarPersona(int id)
        {
            Persona persona = _servicioPersonas.BuscarPersona(id);
            
            var personaDto = new PersonaDto
            {
                Id = persona.Id,
                NombreApellidos = persona.Nombre + " " + persona.Apellidos,
                Sexo = persona.Sexo
            };

            return personaDto;
        }
        
        public Persona AddPersona(Persona nuevaPersona)
        {
            var persona = new Persona
            {
                Id = nuevaPersona.Id,
                Nombre = nuevaPersona.Nombre,
                Apellidos = nuevaPersona.Apellidos,
                Sexo = nuevaPersona.Sexo
            };
            _unitOfWork.Commit();

          return _servicioPersonas.AddPersona(persona);
            
           
           
           
        }
      



    }
}
