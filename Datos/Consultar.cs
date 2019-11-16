using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using Entidades;

namespace Datos
{
    public class Consultar : IDisposable
    {
        public Consultar()
        {

        }

        ~Consultar()
        {
            Dispose();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        private protected readonly Dictionary<Constantes.Consulta, string> ObtenerProcedimiento = new Dictionary<Constantes.Consulta, string>
        {
            { Constantes.Consulta.ActualizarAdministradores, "dbo.ActualizarAdministradores" },
            { Constantes.Consulta.ActualizarAreas, "dbo.ActualizarAreas" },
            { Constantes.Consulta.ActualizarContrasenia, "dbo.ActualizarContrasenia" },
            { Constantes.Consulta.ActualizarMovimientos, "dbo.ActualizarMovimientos" },
            { Constantes.Consulta.ActualizarServicios, "dbo.ActualizarServicios" },
            { Constantes.Consulta.ActualizarUsuarios, "dbo.ActualizarUsuarios" },

            { Constantes.Consulta.CrearAdministradores, "dbo.CrearAdministradores" },
            { Constantes.Consulta.CrearAreas, "dbo.CrearAreas" },
            { Constantes.Consulta.CrearMovimientos, "dbo.CrearMovimientos" },
            { Constantes.Consulta.CrearServicios, "dbo.CrearServicios" },
            { Constantes.Consulta.CrearUsuarios, "dbo.ActualizarAdministradores" },

            { Constantes.Consulta.GraficaMovimientos, "dbo.GraficaMovimientos" },

            { Constantes.Consulta.IniciarSesion, "dbo.IniciarSesion" },

            { Constantes.Consulta.LeerAdministradores, "dbo.LeerAdministradores" },
            { Constantes.Consulta.LeerAreas, "dbo.LeerAreas" },
            { Constantes.Consulta.LeerMovimientos, "dbo.LeerMovimientos" },
            { Constantes.Consulta.LeerServicios, "dbo.LeerServicios" },
            { Constantes.Consulta.LeerUsuarios, "dbo.LeerUsuarios" },

            { Constantes.Consulta.RestaurarContrasenia, "dbo.RestaurarContrasenia" }
        };
        public Dictionary<string, object> Consultas(Constantes.Consulta Consulta1, Tuple<object, string, bool>[] Valores)
        {
            string ProcedimientoAlmacenado = string.Empty;
            try
            {
                ProcedimientoAlmacenado = ObtenerProcedimiento[Consulta1];
            }
            catch (Exception)
            {

            }
            Dictionary<string, object> Resultado = new Dictionary<string, object>();
            SqlTransaction Transaccion = null;
            string CadenaConexion = ConfigurationManager.ConnectionStrings["ConnectionDataBase"].ConnectionString;
            using (SqlConnection Conexion = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand Comando = new SqlCommand(ProcedimientoAlmacenado, Conexion, Transaccion) { CommandType = CommandType.StoredProcedure, CommandTimeout = 180 })
                {
                    Comando.Parameters.Clear();
                    if (Valores.Length > 0)
                    {
                        foreach (var Valor in Valores)
                        {
                            if (Valor.Item1 == null)
                            {
                                Comando.Parameters.Add(new SqlParameter("@" + Valor.Item2, string.Empty));
                                Comando.Parameters["@" + Valor.Item2].Size = (int)Constantes.SizeConsulta.Maximo;
                            }
                            else if (Valor.Item1.GetType() == typeof(char))
                            {
                                Comando.Parameters.Add(new SqlParameter("@" + Valor.Item2, Valor.Item1)).SqlDbType = SqlDbType.Char;
                            }
                            else if (Valor.Item1.GetType() == typeof(string))
                            {
                                Comando.Parameters.Add(new SqlParameter("@" + Valor.Item2, Valor.Item1)).SqlDbType = SqlDbType.VarChar;
                                Comando.Parameters["@" + Valor.Item2].Size = (int)Constantes.SizeConsulta.Maximo;
                            }
                            else if (Valor.Item1.GetType() == typeof(bool))
                            {
                                Comando.Parameters.Add(new SqlParameter("@" + Valor.Item2, Valor.Item1)).SqlDbType = SqlDbType.Bit;
                            }
                            else if (Valor.Item1.GetType() == typeof(Guid))
                            {
                                Comando.Parameters.Add(new SqlParameter("@" + Valor.Item2, Valor.Item1)).SqlDbType = SqlDbType.UniqueIdentifier;
                            }
                            else if (Valor.Item1.GetType() == typeof(decimal) || Valor.Item1.GetType() == typeof(float) || Valor.Item1.GetType() == typeof(double))
                            {
                                Comando.Parameters.Add(new SqlParameter("@" + Valor.Item2, Valor.Item1)).Precision = 18;
                                Comando.Parameters["@" + Valor.Item2].Scale = 4;
                            }
                            else
                            {
                                Comando.Parameters.Add(new SqlParameter("@" + Valor.Item2, Valor.Item1));
                            }

                            if (Valor.Item3) Comando.Parameters["@" + Valor.Item2].Direction = ParameterDirection.InputOutput;
                        }
                        Conexion.Open();
                        Transaccion = Conexion.BeginTransaction();
                        Comando.Prepare();
                        Comando.Transaction = Transaccion;
                        int Respuesta = Comando.ExecuteNonQuery();
                        if (Respuesta <= 0)
                        {
                            Transaccion.Rollback();
                        }
                        else if (Respuesta > 0)
                        {
                            Transaccion.Commit();
                        }
                        Conexion.Close();
                        foreach (var Valor in Valores)
                        {
                            if (Valor.Item3)
                            {
                                Resultado.Add(Valor.Item2, Comando.Parameters["@" + Valor.Item2].Value);
                            }
                        }
                        Transaccion.Dispose();
                    }
                }
            }
            return Resultado;
        }
        public DataTable Consultas(Constantes.Consulta Consulta1, Tuple<object, string>[] Valores)
        {
            string ProcedimientoAlmacenado = string.Empty;
            try
            {
                ProcedimientoAlmacenado = ObtenerProcedimiento[Consulta1];
            }
            catch (Exception)
            {

            }
            DataTable Tabla = new DataTable();
            using (SqlConnection Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionDataBase"].ConnectionString))
            {
                using (SqlCommand Comando = new SqlCommand(ProcedimientoAlmacenado, Conexion) { CommandType = CommandType.StoredProcedure, CommandTimeout = 180 })
                {
                    Comando.Parameters.Clear();
                    if (Valores.Length > 0)
                    {
                        foreach (var Valor in Valores)
                        {
                            if (Valor.Item1 == null)
                            {
                                Comando.Parameters.Add(new SqlParameter("@" + Valor.Item2, string.Empty));
                                Comando.Parameters["@" + Valor.Item2].Size = (int)Constantes.SizeConsulta.Maximo;
                            }
                            else if (Valor.Item1.GetType() == typeof(char))
                            {
                                Comando.Parameters.Add(new SqlParameter("@" + Valor.Item2, Valor.Item1)).SqlDbType = SqlDbType.Char;
                            }
                            else if (Valor.Item1.GetType() == typeof(string))
                            {
                                Comando.Parameters.Add(new SqlParameter("@" + Valor.Item2, Valor.Item1)).SqlDbType = SqlDbType.VarChar;
                                Comando.Parameters["@" + Valor.Item2].Size = (int)Constantes.SizeConsulta.Maximo;
                            }
                            else if (Valor.Item1.GetType() == typeof(bool))
                            {
                                Comando.Parameters.Add(new SqlParameter("@" + Valor.Item2, Valor.Item1)).SqlDbType = SqlDbType.Bit;
                            }
                            else if (Valor.Item1.GetType() == typeof(Guid))
                            {
                                Comando.Parameters.Add(new SqlParameter("@" + Valor.Item2, Valor.Item1)).SqlDbType = SqlDbType.UniqueIdentifier;
                            }
                            else if (Valor.Item1.GetType() == typeof(decimal) || Valor.Item1.GetType() == typeof(float) || Valor.Item1.GetType() == typeof(double))
                            {
                                Comando.Parameters.Add(new SqlParameter("@" + Valor.Item2, Valor.Item1)).Precision = 18;
                                Comando.Parameters["@" + Valor.Item2].Scale = 4;
                            }
                            else
                            {
                                Comando.Parameters.Add(new SqlParameter("@" + Valor.Item2, Valor.Item1));
                            }
                        }
                        Conexion.Open();
                        Comando.Prepare();
                        using (SqlDataReader LeerFilas = Comando.ExecuteReader()) Tabla.Load(LeerFilas);
                        Conexion.Close();
                    }
                }
            }
            return Tabla;
        }
        public DataTable ConsultaSinParametros(Constantes.Consulta Consulta1)
        {
            string ProcedimientoAlmacenado = ObtenerProcedimiento[Consulta1];
            DataTable Tabla1 = new DataTable();
            using (SqlConnection Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionDataBase"].ConnectionString))
            {
                using (SqlCommand Comando = new SqlCommand(ProcedimientoAlmacenado, Conexion) { CommandType = CommandType.StoredProcedure, CommandTimeout = 180 })
                {
                    Comando.Parameters.Clear();
                    Conexion.Open();
                    Comando.Prepare();
                    using (SqlDataReader LeerFilas = Comando.ExecuteReader()) Tabla1.Load(LeerFilas);
                }
            }
            return Tabla1;
        }
    }
}
