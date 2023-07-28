using MagicVilla.Dominio.Entidades;
using MagicVilla.Dominio.Interface;
using MagicVilla.Infraestructura.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicVilla.Dominio.Core
{
    public class ServicioEstudiante : IServicioEstudiante
    {
        private readonly IRepositorio<Estudiante> _repositorioEstudiantes;

        public ServicioEstudiante(IRepositorio<Estudiante> repositorioEstudiantes)
        {
            _repositorioEstudiantes = repositorioEstudiantes;
            
        }
        public List<Estudiante> ObtenerEstudiantes()
        {
            return _repositorioEstudiantes.GetAll().ToList();

        }
    }


}
