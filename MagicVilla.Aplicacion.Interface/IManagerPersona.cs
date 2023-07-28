using MagicVilla.Aplicacion.DTO;
using MagicVilla.Dominio.Entidades;

namespace MagicVilla.Aplicacion.Interface
{
    public interface IManagerPersona
    {
        public PersonaDto[] ObtenerPersona();
        public PersonaDto BuscarPersona(int id);
        public Persona AddPersona(Persona nuevaPersona);


    }
}