using System;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Negocio
{
    public static class Validar
    {
        public static void ValidarRangoFecha(ref DateTime FechaInicio, ref DateTime FechaFin)
        {
            if (FechaInicio.CompareTo(DateTime.Parse("01/01/1900")) <= 0) FechaInicio = DateTime.Parse("01/01/1900");
            if (FechaFin.CompareTo(DateTime.Parse("01/01/1900")) <= 0) FechaFin = new DateTime(2099, 12, 31, 23, 59, 59);
        }
        public static bool ValidarNumeroControl(string num) => Regex.IsMatch(num, @"^[CBcb]?\d{8}$");
        public static bool ContieneNumeros(string str) => Regex.IsMatch(str, @"\d+");
        public static string RemoverEspaciosDobles(string str) => Regex.Replace(str.Trim(), @"\s{2,}", " ");
        /// <summary>
        /// Convertir palabras como "hola" en "Hola", es decir, volver la primera letra de cada palabra en mayúsculas
        /// </summary>
        /// <param name="str">Texto a capitalizar</param>
        /// <param name="CapitalizarAcronimos">Ejemplo: Verdadero para convertir CURP en Curp. Falso para mantener el acrónimo en mayúsculas</param>
        /// <returns></returns>
        public static string CapitalizarTexto(string str, bool CapitalizarAcronimos = false)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return CapitalizarAcronimos ? CultureInfo.CreateSpecificCulture("es-MX").TextInfo.ToTitleCase(RemoverEspaciosDobles(str).ToLower()) : CultureInfo.InvariantCulture.TextInfo.ToTitleCase(str);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
