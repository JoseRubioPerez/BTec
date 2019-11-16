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
                Dictionary<string, object> DicResultado = new Dictionary<string, object>();
                bool Resultado = false;
                using (Consultar ObjConsultar = new Consultar()) DicResultado = ObjConsultar.Consultas(Constantes.Consulta.IniciarSesion, new Tuple<object, string, bool>[]
                {
                    new Tuple<object, string, bool>(Administrador1.Contrasenia, nameof(Administrador1.Contrasenia), false),
                    new Tuple<object, string, bool>(Administrador1.NumeroControl, nameof(Administrador1.NumeroControl), false),
                    new Tuple<object, string, bool>(Resultado, nameof(Resultado), true),
                });

                if (DicResultado.ContainsKey(nameof(Resultado)))
                {
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
