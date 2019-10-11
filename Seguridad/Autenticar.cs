using Entidades;
using Datos;
using System;
using System.Collections;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Seguridad
{
    public class Autenticar : IDisposable
    {
        private readonly string TipoEncriptacion = string.Empty;
        public Autenticar()
        {
            TipoEncriptacion = ConfigurationManager.AppSettings["encryption"].ToString();
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
        public bool CambiarContrasenia(ref Estructuras.Tarjeta Tarjeta1)
        {
            Estructuras.Administradores Administrador1 = Tarjeta1.Administrador;
            try
            {
                if (string.IsNullOrEmpty(Tarjeta1.Administrador.Contrasenia) || Administrador1.IdAdministrador <= 0) throw new Exception();
                Administrador1.IdAdministrador = Tarjeta1.Administrador.IdAdministrador;
                Administrador1.Contrasenia = ObtenerHash(Administrador1.Contrasenia);
                Tuple<object, string, bool>[]  TuplaLeer = Estructuras.GenerarTupla(Administrador1, nameof(Administrador1.IdAdministrador));
                Hashtable Resultado = new Hashtable();
                using (Consultar ObjConsultar = new Consultar()) Resultado = ObjConsultar.Consultas("dbo.Actualizar_Contrasenia_Usuario", TuplaLeer);
                Tarjeta1.Administrador = Administrador1;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool RecuperarContrasenia(ref Estructuras.Tarjeta Tarjeta1)
        {
            Estructuras.Administradores Administrador1 = Tarjeta1.Administrador;
            try
            {
                if (Administrador1.IdAdministrador <= 0) throw new Exception();
                Tuple<object, string, bool>[] TuplaLeer = Estructuras.GenerarTupla(Administrador1, nameof(Administrador1.IdAdministrador));
                Hashtable Resultado = new Hashtable();
                using (Consultar ObjConsultar = new Consultar()) Resultado = ObjConsultar.Consultas("dbo.Recuperar_Contrasenia_Usuario", TuplaLeer);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
