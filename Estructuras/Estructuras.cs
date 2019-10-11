using System;
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
            private string PSPrimerNombre { get; set; }
            public string PrimerNombre { get { return PSPrimerNombre; } set { PSPrimerNombre = value ?? string.Empty; } }
            private string PSSegundoNombre { get; set; }
            public string SegundoNombre { get { return PSSegundoNombre; } set { PSSegundoNombre = value ?? string.Empty; } }
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
            private int PIIdUsuario { get; set; }
            public int IdUsuario { get { return PIIdUsuario; } set { PIIdUsuario = value; } }
            private byte PBIdServicio { get; set; }
            public byte IdServicio { get { return PBIdServicio; } set { PBIdServicio = value; } }
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
            public Constantes.Consulta Consulta { get; set; }
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
            public string NumeroControl { get { return NumeroControl; } set { NumeroControl = value ?? string.Empty; } }
            private string PSPrimerNombre { get; set; }
            public string PrimerNombre { get { return PSPrimerNombre; } set { PSPrimerNombre = value ?? string.Empty; } }
            private string PSSegundoNombre { get; set; }
            public string SegundoNombre { get { return PSSegundoNombre; } set { PSSegundoNombre = value ?? string.Empty; } }
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
        public static Tuple<object, string>[] GenerarTupla(object Estructura)
        {
            int Index = 0;
            PropertyInfo[] Propiedades = Estructura.GetType().GetProperties();
            Tuple<object, string>[] TuplaFinal = new Tuple<object, string>[Propiedades.Length];
            try
            {
                foreach (PropertyInfo Propiedad in Propiedades)
                {
                    object Valor = Propiedad.GetValue(Estructura, null);

                    switch (Type.GetTypeCode(Valor.GetType()))
                    {
                        case TypeCode.DateTime:
                            {
                                if ((DateTime)Valor == DateTime.Parse("01/01/0001"))
                                {
                                    Valor = DateTime.Parse("01/01/1900");
                                }
                                break;
                            }
                        case TypeCode.String:
                            {
                                if (Valor == null)
                                {
                                    Valor = string.Empty;
                                }
                                break;
                            }
                        case TypeCode.Char:
                            {
                                if (Valor == null)
                                {
                                    Valor = '\0';
                                }
                                break;
                            }
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
        public static Tuple<object, string, bool>[] GenerarTupla(object Estructura, params string[] Omitir)
        {
            int Index = 0;
            PropertyInfo[] Propiedades = Estructura.GetType().GetProperties();
            Tuple<object, string, bool>[] TuplaFinal = new Tuple<object, string, bool>[Propiedades.Length];
            try
            {
                foreach (PropertyInfo Propiedad in Propiedades)
                {
                    object Valor = Propiedad.GetValue(Estructura, null);

                    switch (Type.GetTypeCode(Valor.GetType()))
                    {
                        case TypeCode.DateTime:
                            {
                                if ((DateTime)Valor == DateTime.Parse("01/01/0001"))
                                {
                                    Valor = DateTime.Parse("01/01/1900");
                                }
                                break;
                            }
                        case TypeCode.String:
                            {
                                if (Valor == null)
                                {
                                    Valor = string.Empty;
                                }
                                break;
                            }
                        case TypeCode.Char:
                            {
                                if (Valor == null)
                                {
                                    Valor = '\0';
                                }
                                break;
                            }
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
    }
}
