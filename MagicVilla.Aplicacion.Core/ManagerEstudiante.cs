using MagicVilla.Aplicacion.DTO;
using MagicVilla.Aplicacion.Interface;
using MagicVilla.Dominio.Entidades;
using MagicVilla.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicVilla.Aplicacion.Core
{
    public class ManagerEstudiante : IManagerEstudiante
    {
        private readonly IServicioEstudiante _servicioEstudiantes;

        public ManagerEstudiante(IServicioEstudiante servicioEstudiantes)
        {
            _servicioEstudiantes = servicioEstudiantes;
            
        }

        public EstudianteDto[] ObtenerEstudiante()
        {
            List<Estudiante> estudiantes = _servicioEstudiantes.ObtenerEstudiantes();
            return estudiantes.Select(x => new EstudianteDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Sexo = x.Sexo,
                Grado = x.Grado
            }).ToArray();

        }
    }
}
