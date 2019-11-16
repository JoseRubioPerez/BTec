using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Entidades
{
    public static class Estructuras
    {
        [Serializable]
        public struct Administradores
        {
            private byte PBIdAdministrador { get; set; }
            public byte IdAdministrador { get { return PBIdAdministrador; } set { PBIdAdministrador = value; } }
            private Guid PGIdGuid { get; set; }
            public Guid IdGuid { get { return PGIdGuid; } set { PGIdGuid = value; } }
            private string PSNumeroControl { get; set; }
            public string NumeroControl { get { return PSNumeroControl; } set { PSNumeroControl = value ?? string.Empty; } }
            private string PSNombres { get; set; }
            public string Nombres { get { return PSNombres; } set { PSNombres = value ?? string.Empty; } }
            private string PSPaterno { get; set; }
            public string Paterno { get { return PSPaterno; } set { PSPaterno = value ?? string.Empty; } }
            private string PSMaterno { get; set; }
            public string Materno { get { return PSMaterno; } set { PSMaterno = value ?? string.Empty; } }
            private string PSContrasenia { get; set; }
            public string Contrasenia { get { return PSContrasenia; } set { PSContrasenia = value ?? string.Empty; } }
            private string PSUrlFoto { get; set; }
            public string UrlFoto { get { return PSUrlFoto; } set { PSUrlFoto = value ?? string.Empty; } }
            private byte PBIdGenero { get; set; }
            public byte IdGenero { get { return PBIdGenero; } set { PBIdGenero = value; } }
            private bool PBIdEditable { get; set; }
            public bool IdEditable { get { return PBIdEditable; } set { PBIdEditable = value; } }
            private bool PBIdEstaActivo { get; set; }
            public bool IdEstaActivo { get { return PBIdEstaActivo; } set { PBIdEstaActivo = value; } }
            private DateTime PDFechaCreacion { get; set; }
            public DateTime FechaCreacion { get { return PDFechaCreacion; } set { PDFechaCreacion = value == DateTime.MinValue ? new DateTime(1900, 01, 01) : value; } }
            private DateTime PDFechaActualizacion { get; set; }
            public DateTime FechaActualizacion { get { return PDFechaActualizacion; } set { PDFechaActualizacion = value == DateTime.MinValue ? new DateTime(1900, 01, 01) : value; } }
        }
        [Serializable]
        public struct Areas
        {
            private byte PBIdArea { get; set; }
            public byte IdArea { get { return PBIdArea; } set { PBIdArea = value; } }
            private Guid PGIdGuid { get; set; }
            public Guid IdGuid { get { return PGIdGuid; } set { PGIdGuid = value; } }
            private string PSArea { get; set; }
            public string Area { get { return PSArea; } set { PSArea = value ?? string.Empty; } }
            private bool PBIdEstaActivo { get; set; }
            public bool IdEstaActivo { get { return PBIdEstaActivo; } set { PBIdEstaActivo = value; } }
            private byte PBIdAdminCreacion { get; set; }
            public byte IdAdminCreacion { get { return PBIdAdminCreacion; } set { PBIdAdminCreacion = value; } }
            private DateTime PDFechaCreacion { get; set; }
            public DateTime FechaCreacion { get { return PDFechaCreacion; } set { PDFechaCreacion = value == DateTime.MinValue ? new DateTime(1900, 01, 01) : value; } }
            private byte PBIdAdminActualizacion { get; set; }
            public byte IdAdminActualizacion { get { return PBIdAdminActualizacion; } set { PBIdAdminActualizacion = value; } }
            private DateTime PDFechaActualizacion { get; set; }
            public DateTime FechaActualizacion { get { return PDFechaActualizacion; } set { PDFechaActualizacion = value == DateTime.MinValue ? new DateTime(1900, 01, 01) : value; } }
        }
        [Serializable]
        public struct Movimientos
        {
            private int PIIdMovimiento { get; set; }
            public int IdMovimiento { get { return PIIdMovimiento; } set { PIIdMovimiento = value; } }
            private Guid PGIdGuid { get; set; }
            public Guid IdGuid { get { return PGIdGuid; } set { PGIdGuid = value; } }
            private int PIIdUsuario { get; set; }
            public int IdUsuario { get { return PIIdUsuario; } set { PIIdUsuario = value; } }
            private byte PBIdServicio { get; set; }
            public byte IdServicio { get { return PBIdServicio; } set { PBIdServicio = value; } }
            private bool PBIdEstaActivo { get; set; }
            public bool IdEstaActivo { get { return PBIdEstaActivo; } set { PBIdEstaActivo = value; } }
            private byte PBIdAdminCreacion { get; set; }
            public byte IdAdminCreacion { get { return PBIdAdminCreacion; } set { PBIdAdminCreacion = value; } }
            private string PSNumeroControlCreacion { get; set; }
            public string NumeroControlCreacion { get { return PSNumeroControlCreacion; } set { PSNumeroControlCreacion = value ?? string.Empty; } }
            private DateTime PDFechaCreacion { get; set; }
            public DateTime FechaCreacion { get { return PDFechaCreacion; } set { PDFechaCreacion = value == DateTime.MinValue ? new DateTime(1900, 01, 01) : value; } }
            private byte PBIdAdminActualizacion { get; set; }
            public byte IdAdminActualizacion { get { return PBIdAdminActualizacion; } set { PBIdAdminActualizacion = value; } }
            private string PSNumeroControlActualizacion { get; set; }
            public string NumeroControlActualizacion { get { return PSNumeroControlActualizacion; } set { PSNumeroControlActualizacion = value ?? string.Empty; } }
            private DateTime PDFechaActualizacion { get; set; }
            public DateTime FechaActualizacion { get { return PDFechaActualizacion; } set { PDFechaActualizacion = value == DateTime.MinValue ? new DateTime(1900, 01, 01) : value; } }
        }
        [Serializable]
        public struct Servicios
        {
            private byte PBIdServicio { get; set; }
            public byte IdServicio { get { return PBIdServicio; } set { PBIdServicio = value; } }
            private Guid PGIdGuid { get; set; }
            public Guid IdGuid { get { return PGIdGuid; } set { PGIdGuid = value; } }
            private string PSServicio { get; set; }
            public string Servicio { get { return PSServicio; } set { PSServicio = value ?? string.Empty; } }
            private bool PBIdEstaActivo { get; set; }
            public bool IdEstaActivo { get { return PBIdEstaActivo; } set { PBIdEstaActivo = value; } }
            private byte PBIdAdminCreacion { get; set; }
            public byte IdAdminCreacion { get { return PBIdAdminCreacion; } set { PBIdAdminCreacion = value; } }
            private DateTime PDFechaCreacion { get; set; }
            public DateTime FechaCreacion { get { return PDFechaCreacion; } set { PDFechaCreacion = value == DateTime.MinValue ? new DateTime(1900, 01, 01) : value; } }
            private byte PBIdAdminActualizacion { get; set; }
            public byte IdAdminActualizacion { get { return PBIdAdminActualizacion; } set { PBIdAdminActualizacion = value; } }
            private DateTime PDFechaActualizacion { get; set; }
            public DateTime FechaActualizacion { get { return PDFechaActualizacion; } set { PDFechaActualizacion = value == DateTime.MinValue ? new DateTime(1900, 01, 01) : value; } }
        }
        public struct Tarjeta
        {
            public string Error { get; set; }
            public Administradores Administrador { get; set; }
            public Constantes.TipoConsulta TipoConsulta { get; set; }
            public Constantes.Resultado Resultado { get; set; }
            public Constantes.Accion Accion { get; set; }
            public DataTable TablaConsulta { get; set; }
        }
        [Serializable]
        public struct Usuarios
        {
            private int PIIdUsuario { get; set; }
            public int IdUsuario { get { return PIIdUsuario; } set { PIIdUsuario = value; } }
            private Guid PGIdGuid { get; set; }
            public Guid IdGuid { get { return PGIdGuid; } set { PGIdGuid = value; } }
            private string PSNumeroControl { get; set; }
            public string NumeroControl { get { return PSNumeroControl; } set { PSNumeroControl = value ?? string.Empty; } }
            private string PSNombres { get; set; }
            public string Nombres { get { return PSNombres; } set { PSNombres = value ?? string.Empty; } }
            private string PSPaterno { get; set; }
            public string Paterno { get { return PSPaterno; } set { PSPaterno = value ?? string.Empty; } }
            private string PSMaterno { get; set; }
            public string Materno { get { return PSMaterno; } set { PSMaterno = value ?? string.Empty; } }
            private byte PBIdArea { get; set; }
            public byte IdArea { get { return PBIdArea; } set { PBIdArea = value; } }
            private string PSUrlFoto { get; set; }
            public string UrlFoto { get { return PSUrlFoto; } set { PSUrlFoto = value ?? string.Empty; } }
            private byte PBIdGenero { get; set; }
            public byte IdGenero { get { return PBIdGenero; } set { PBIdGenero = value; } }
            private bool PBIdEstaActivo { get; set; }
            public bool IdEstaActivo { get { return PBIdEstaActivo; } set { PBIdEstaActivo = value; } }
            private byte PBIdAdminCreacion { get; set; }
            public byte IdAdminCreacion { get { return PBIdAdminCreacion; } set { PBIdAdminCreacion = value; } }
            private DateTime PDFechaCreacion { get; set; }
            public DateTime FechaCreacion { get { return PDFechaCreacion; } set { PDFechaCreacion = value == DateTime.MinValue ? new DateTime(1900, 01, 01) : value; } }
            private byte PBIdAdminActualizacion { get; set; }
            public byte IdAdminActualizacion { get { return PBIdAdminActualizacion; } set { PBIdAdminActualizacion = value; } }
            private DateTime PDFechaActualizacion { get; set; }
            public DateTime FechaActualizacion { get { return PDFechaActualizacion; } set { PDFechaActualizacion = value == DateTime.MinValue ? new DateTime(1900, 01, 01) : value; } }
        }
        public static Tuple<object, string>[] GenerarTupla(object Estructura, DateTime FechaInicio, DateTime FechaFin, Constantes.TipoConsulta Consulta1, bool BuscarTodosLosEstados = false)
        {
            PropertyInfo[] Propiedades = Estructura.GetType().GetProperties();
            Tuple<object, string>[] TuplaFinal = new Tuple<object, string>[Propiedades.Length + 4];
            try
            {
                TuplaFinal[0] = new Tuple<object, string>((int)Consulta1, "Consulta");
                TuplaFinal[1] = new Tuple<object, string>(BuscarTodosLosEstados, nameof(BuscarTodosLosEstados));
                TuplaFinal[2] = new Tuple<object, string>(FechaInicio, nameof(FechaInicio));
                TuplaFinal[3] = new Tuple<object, string>(FechaFin, nameof(FechaFin));
                int Index = 4;
                foreach (PropertyInfo Propiedad in Propiedades)
                {
                    object Valor = Propiedad.GetValue(Estructura, null);

                    if (Valor == null)
                    {
                        Valor = string.Empty;
                    }
                    else if (Valor.GetType() == typeof(DateTime))
                    {
                        if ((DateTime)Valor == DateTime.Parse("01/01/0001"))
                        {
                            Valor = DateTime.Parse("01/01/1900");
                        }
                    }
                    else if (Propiedad.PropertyType.FullName == "System.Char")
                    {
                        Valor = '\0';
                    }
                    TuplaFinal[Index] = new Tuple<object, string>(Valor, Propiedad.Name);
                    Index++;
                }
                return TuplaFinal;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static Tuple<object, string, bool>[] GenerarTupla(object Estructura, DateTime FechaInicio, DateTime FechaFin, Constantes.TipoConsulta Consulta1, bool BuscarTodosLosEstados, params string[] Omitir)
        {
            PropertyInfo[] Propiedades = Estructura.GetType().GetProperties();
            Tuple<object, string, bool>[] TuplaFinal = new Tuple<object, string, bool>[Propiedades.Length + 4];
            try
            {
                TuplaFinal[0] = new Tuple<object, string, bool>((int)Consulta1, "Consulta", false);
                TuplaFinal[1] = new Tuple<object, string, bool>(BuscarTodosLosEstados, nameof(BuscarTodosLosEstados), false);
                TuplaFinal[2] = new Tuple<object, string, bool>(FechaInicio, nameof(FechaInicio), false);
                TuplaFinal[3] = new Tuple<object, string, bool>(FechaFin, nameof(FechaFin), false);
                int Index = 4;
                foreach (PropertyInfo Propiedad in Propiedades)
                {
                    object Valor = Propiedad.GetValue(Estructura, null);

                    if (Valor == null)
                    {
                        Valor = string.Empty;
                    }
                    else if (Valor.GetType() == typeof(DateTime))
                    {
                        if ((DateTime)Valor == DateTime.Parse("01/01/0001"))
                        {
                            Valor = DateTime.Parse("01/01/1900");
                        }
                    }
                    else if (Propiedad.PropertyType.FullName == "System.Char")
                    {
                        Valor = '\0';
                    }
                    TuplaFinal[Index] = new Tuple<object, string, bool>(Valor, Propiedad.Name, !(Omitir.Contains<string>(Propiedad.Name) || Valor.GetType() == typeof(Guid)));
                    Index++;
                }
                return TuplaFinal;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static Tuple<object, string, bool>[] GenerarTupla(object Estructura, string IdPrincipal, string IdGuid)
        {
            PropertyInfo[] Propiedades = Estructura.GetType().GetProperties();

            Tuple<object, string, bool>[] TuplaFinal = new Tuple<object, string, bool>[Propiedades.Length];

            int Index = 0;

            try
            {
                foreach (PropertyInfo Propiedad in Propiedades)
                {
                    var Valor = Propiedad.GetValue(Estructura, null);

                    if (Valor == null)
                    {
                        Valor = string.Empty;
                    }
                    else if (Valor.GetType() == typeof(DateTime))
                    {
                        if ((DateTime)Valor == DateTime.Parse("01/01/0001"))
                        {
                            Valor = DateTime.Parse("01/01/1900");
                        }
                    }
                    else if (Propiedad.PropertyType.FullName == "System.Char")
                    {
                        Valor = '\0';
                    }

                    TuplaFinal[Index] = new Tuple<object, string, bool>(Valor, Propiedad.Name, !(Propiedad.Name == IdPrincipal || Propiedad.Name == IdGuid));
                    Index++;
                }

                return TuplaFinal;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static Tuple<object, string>[] UnirDosTuplas(Tuple<object, string>[] T1, Tuple<object, string>[] T2)
        {
            Tuple<object, string>[] T3 = new Tuple<object, string>[T1.Length + T2.Length];
            int i = 0;

            for (; i < T1.Length; i++) T3[i] = T1[i];
            for (int j = 0; j < T2.Length; j++)
            {
                T3[i] = T2[j];
                i++;
            }
            return T3;
        }
        public static Tuple<object, string, bool>[] OmitirPropiedadesEnTupla(Tuple<object, string, bool>[] T1, params string[] Propiedades)
        {
            int contador = 0;
            try
            {
                Tuple<object, string, bool>[] T2 = new Tuple<object, string, bool>[T1.Length - Propiedades.Length];
                foreach (Tuple<object, string, bool> Tupla in T1)
                {
                    if (!Propiedades.Contains(Tupla.Item2))
                    {
                        T2[contador] = Tupla;
                        contador++;
                    }
                }
                return T2;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static Tuple<object, string>[] OmitirPropiedadesEnTupla(Tuple<object, string>[] T1, params string[] Propiedades)
        {
            int contador = 0;
            try
            {
                Tuple<object, string>[] T2 = new Tuple<object, string>[T1.Length - Propiedades.Length];
                foreach (Tuple<object, string> Tupla in T1)
                {
                    if (!Propiedades.Contains(Tupla.Item2))
                    {
                        T2[contador] = Tupla;
                        contador++;
                    }
                }
                return T2;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static Tuple<object, string, bool>[] UnirDosTuplas(Tuple<object, string, bool>[] T1, Tuple<object, string, bool>[] T2)
        {
            Tuple<object, string, bool>[] T3 = new Tuple<object, string, bool>[T1.Length + T2.Length];
            int i = 0;

            for (; i < T1.Length; i++) T3[i] = T1[i];
            for (int j = 0; j < T2.Length; j++)
            {
                T3[i] = T2[j];
                i++;
            }
            return T3;
        }
        public static object DictionaryEnEstructura(object Estructura, Dictionary<string, object> Dictionary1)
        {
            PropertyInfo[] Propiedades = Estructura.GetType().GetProperties();
            Tuple<object, string>[] TuplaFinal = new Tuple<object, string>[Propiedades.Length];

            Propiedades = Propiedades.ToList().Select(x =>
            {
                string NombrePropiedad = x.Name;
                if (Dictionary1.ContainsKey(NombrePropiedad)) x.SetValue(Estructura, Dictionary1[NombrePropiedad], null);
                return x;
            }).ToArray();
            return Estructura;
        }
    }
}
