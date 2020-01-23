using Entidades;
using Datos;
using System;
using System.Collections;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

namespace Seguridad
{
    public class Autenticar : IDisposable
    {
        private readonly string TipoEncriptacion = string.Empty;
        public Autenticar()
        {
            TipoEncriptacion = ConfigurationManager.AppSettings["Encryption"].ToString();
        }
        ~Autenticar()
        {
            Dispose();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public string ObtenerHash(string Entrada)
        {
            byte[] Datos;
            StringBuilder ObjStream = new StringBuilder();
            if (TipoEncriptacion == "SHA2_512")
            {
                using (SHA512 HashMD5 = SHA512.Create())
                {
                    Datos = HashMD5.ComputeHash(Encoding.UTF8.GetBytes(Entrada));
                }
                for (int i = 0; i < Datos.Length; i++)
                {
                    ObjStream.Append(Datos[i].ToString("x2"));
                }
            }
            else
            {
                using (SHA1 HashMD1 = SHA1.Create())
                {
                    Datos = HashMD1.ComputeHash(Encoding.UTF8.GetBytes(Entrada));
                }
                for (int i = 0; i < Datos.Length; i++)
                {
                    ObjStream.Append(Datos[i].ToString("x2"));
                }
            }
            return ObjStream.ToString();
        }
        public bool IniciarSesion(ref Estructuras.Tarjeta Tarjeta1)
        {
            Estructuras.Administradores Administrador1 = Tarjeta1.Administrador;
            try
            {
                if (string.IsNullOrEmpty(Administrador1.Contrasenia) || string.IsNullOrEmpty(Administrador1.NumeroControl))
                {
                    throw new Exception();
                }
                Administrador1.Contrasenia = ObtenerHash(Administrador1.Contrasenia);
                Administrador1.FechaCreacion = new DateTime(1900, 1, 1);
                Administrador1.FechaActualizacion = new DateTime(1900, 1, 1);
                Dictionary<string, object> DicResultado = new Dictionary<string, object>();
                bool Resultado = false;
                Tuple<object, string, bool>[] T1 = new Tuple<object, string, bool>[]
                {
                    new Tuple<object, string, bool>(Administrador1.NumeroControl, nameof(Administrador1.NumeroControl), false),
                    new Tuple<object, string, bool>(Administrador1.Contrasenia, nameof(Administrador1.Contrasenia), false),
                    new Tuple<object, string, bool>(Administrador1.IdAdministrador, nameof(Administrador1.IdAdministrador), true),
                    new Tuple<object, string, bool>(Administrador1.IdGuid, nameof(Administrador1.IdGuid), true),
                    new Tuple<object, string, bool>(Administrador1.Nombres, nameof(Administrador1.Nombres), true),
                    new Tuple<object, string, bool>(Administrador1.Paterno, nameof(Administrador1.Paterno), true),
                    new Tuple<object, string, bool>(Administrador1.Materno, nameof(Administrador1.Materno), true),
                    new Tuple<object, string, bool>(Administrador1.UrlFoto, nameof(Administrador1.UrlFoto), true),
                    new Tuple<object, string, bool>(Administrador1.IdGenero, nameof(Administrador1.IdGenero), true),
                    new Tuple<object, string, bool>(Administrador1.IdEditable, nameof(Administrador1.IdEditable), true),
                    new Tuple<object, string, bool>(Administrador1.IdEstaActivo, nameof(Administrador1.IdEstaActivo), true),
                    new Tuple<object, string, bool>(Administrador1.IdAdminCreacion, nameof(Administrador1.IdAdminCreacion), true),
                    new Tuple<object, string, bool>(Administrador1.FechaCreacion, nameof(Administrador1.FechaCreacion), true),
                    new Tuple<object, string, bool>(Administrador1.IdAdminActualizacion, nameof(Administrador1.IdAdminActualizacion), true),
                    new Tuple<object, string, bool>(Administrador1.FechaActualizacion, nameof(Administrador1.FechaActualizacion), true),
                    new Tuple<object, string, bool>(Resultado, nameof(Resultado), true),
                };
                using (Consultar ObjConsultar = new Consultar()) DicResultado = ObjConsultar.Consultas(Constantes.Consulta.IniciarSesion, T1);

                if (DicResultado.ContainsKey(nameof(Resultado)))
                {
                    Administrador1 = (Estructuras.Administradores)Estructuras.DictionaryEnEstructura(Administrador1, DicResultado);
                    Administrador1.NumeroControl = Tarjeta1.Administrador.NumeroControl;
                    Administrador1.Contrasenia = ObtenerHash(Tarjeta1.Administrador.Contrasenia);
                    Tarjeta1.Administrador = Administrador1;
                    return (bool)DicResultado[nameof(Resultado)];
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
