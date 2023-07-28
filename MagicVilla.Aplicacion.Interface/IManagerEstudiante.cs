using MagicVilla.Aplicacion.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicVilla.Aplicacion.Interface
{
    public interface IManagerEstudiante
    {
        public EstudianteDto[] ObtenerEstudiante();

    }
}
