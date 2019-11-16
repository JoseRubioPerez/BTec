using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class Validar
    {
        public static void ValidarRangoFecha(ref DateTime FechaInicio, ref DateTime FechaFin)
        {
            if (FechaInicio.CompareTo(DateTime.Parse("01/01/1900")) <= 0) FechaInicio = DateTime.Parse("01/01/1900");
            if (FechaFin.CompareTo(DateTime.Parse("01/01/1900")) <= 0) FechaFin = new DateTime(2099, 12, 31, 23, 59, 59);
        }
    }
}
