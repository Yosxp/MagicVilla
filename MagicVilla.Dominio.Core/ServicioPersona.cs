using MagicVilla.Aplicacion.DTO;
using MagicVilla.Dominio.Entidades;
using MagicVilla.Dominio.Interface;
using MagicVilla.Infraestructura.Interface;

namespace MagicVilla.Dominio.Core
{
    public class ServicioPersona : IServicioPersona
    {
        private readonly IRepositorio<Persona> _repositorioPersonas;

        public ServicioPersona(IRepositorio<Persona> repositorioPersonas)
        {
            _repositorioPersonas = repositorioPersonas;
        }
        public List<Persona> ObtenerPersonas()
        {
            //return _repositorioPersonas.GetAll().Select(x => x.Nombre).ToList();

            //return _repositorioPersonas.GetAll().Where(x => x.Sexo == "F").ToList();

            return _repositorioPersonas.GetAll().ToList();

        }

        public Persona BuscarPersona(int id)
        {
            return _repositorioPersonas.GetById(id);
        }

        public Persona AddPersona(Persona nuevaPersona)
        {
           return _repositorioPersonas.Add(nuevaPersona);
        }
    }
}