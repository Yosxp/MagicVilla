using MagicVilla.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicVilla.Dominio.Interface
{
    public interface IServicioEstudiante
    {
        List<Estudiante> ObtenerEstudiantes();
    }
}
