using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
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
        private string ObtenerProcedimientoAlmacenado(Constantes.Consulta Consulta1)
        {
            string Resultado;
            switch (Consulta1)
            {
                case Constantes.Consulta.Masiva:
                    {
                        Resultado = "dbo.cre_ExiPro";
                        break;
                    }
                default:
                    {
                        Resultado = string.Empty;
                        break;
                    }
            }
            return Resultado;
        }

        public Hashtable Consultas(string ProcedimientoAlmacenado, Tuple<object, string, bool>[] Valores)
        {
            Hashtable Resultado = new Hashtable();
            SqlTransaction Transaccion = null;
            string CadenaConexion = ConfigurationManager.ConnectionStrings["SysetiCotizador"].ConnectionString;
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
                            Resultado.Add("ResultadoConsulta", Respuesta);
                            Transaccion.Rollback();
                        }
                        else if (Respuesta > 0)
                        {
                            Transaccion.Commit();
                        }
                        Conexion.Close();
                        foreach (var Valor in Valores)
                        {
                            if (Valor.Item3) Resultado.Add(Valor.Item2, Comando.Parameters["@" + Valor.Item2].Value);
                        }
                        Transaccion.Dispose();
                    }
                }
            }
            return Resultado;
        }
        public DataTable Consultas(string ProcedimientoAlmacenado, Tuple<object, string>[] Valores)
        {
            DataTable Tabla = new DataTable();
            using (SqlConnection Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SysetiCotizador"].ConnectionString))
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
    }
}
