using MagicVilla.Aplicacion.DTO;
using MagicVilla.Dominio.Entidades;

namespace MagicVilla.Dominio.Interface
{
    public interface IServicioPersona
    {
        List<Persona> ObtenerPersonas();
        Persona BuscarPersona(int id);
        Persona AddPersona(Persona nuevaPersona);

    }
}