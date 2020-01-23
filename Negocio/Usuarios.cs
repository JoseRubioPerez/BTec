using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Usuarios : IDisposable
    {
        public Usuarios()
        {

        }
        ~Usuarios()
        {
            Dispose();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public void ConsultarCatalogoUsuarios(ref Estructuras.Tarjeta Tarjeta1, ref Estructuras.Usuarios Usuario1, DateTime FechaInicio, DateTime FechaFin, bool BuscarRangoFecha = true, bool BuscarTodosLosEstados = false)
        {
            DataTable Tabla = new DataTable();
            Dictionary<string, object> Resultado = new Dictionary<string, object>();
            Tarjeta1.Error = string.Empty;
            try
            {
                if (!BuscarRangoFecha)
                {
                    Validar.ValidarRangoFecha(ref FechaInicio, ref FechaFin);
                }

                switch (Tarjeta1.TipoConsulta)
                {
                    case Constantes.TipoConsulta.Masiva:
                        {
                            Tuple<object, string>[] T1 = Estructuras.GenerarTuplaLeerRegistros(Usuario1, FechaInicio, FechaFin, Tarjeta1.TipoConsulta, BuscarTodosLosEstados);
                            using (Consultar ObjConsultar = new Consultar()) Tabla = ObjConsultar.Consultas(Constantes.Consulta.LeerUsuarios, T1);
                            Tarjeta1.TablaConsulta = Tabla;
                            break;
                        }
                    case Constantes.TipoConsulta.IndividualPorId:
                        {
                            if (Usuario1.IdUsuario <= 0) throw new FormatException();
                            Tuple<object, string, bool>[] T1 = Estructuras.GenerarTuplaLeerRegistros(Usuario1, FechaInicio, FechaFin, Tarjeta1.TipoConsulta, BuscarTodosLosEstados, nameof(Usuario1.IdUsuario));
                            using (Consultar ObjConsultar = new Consultar()) Resultado = ObjConsultar.Consultas(Constantes.Consulta.LeerUsuarios, T1);

                            if (Resultado.Count > 0)
                            {
                                if ((int)Resultado[nameof(Usuario1.IdUsuario)] > 0)
                                {
                                    Usuario1 = (Estructuras.Usuarios)Estructuras.DictionaryEnEstructura(Usuario1, Resultado);
                                    Tarjeta1.Resultado = Constantes.Resultado.Correcto;
                                }
                                else
                                {
                                    Tarjeta1.Resultado = Constantes.Resultado.Incorrecto;
                                }
                            }
                            else
                            {
                                Tarjeta1.Resultado = Constantes.Resultado.Incorrecto;
                            }
                            break;
                        }
                    case Constantes.TipoConsulta.PorParametro:
                        {
                            break;
                        }
                }
            }
            catch (Exception)
            {

            }
        }
        public void GuardarUsuario(ref Estructuras.Tarjeta Tarjeta1, ref Estructuras.Usuarios Usuario1)
        {
            Dictionary<string, object> Resultado = new Dictionary<string, object>();
            Tarjeta1.Error = string.Empty;
            try
            {
                switch (Tarjeta1.Accion)
                {
                    case Constantes.Accion.Insertar:
                        {
                            Tuple<object, string, bool>[] T1 = Estructuras.GenerarTuplaGuardarRegistro(Usuario1, nameof(Usuario1.IdUsuario), nameof(Usuario1.IdGuid), Tarjeta1.Accion);
                            using (Consultar ObjConsultas = new Consultar()) Resultado = ObjConsultas.Consultas(Constantes.Consulta.CrearUsuarios, T1);
                            if (Resultado.Count > 0)
                            {
                                if ((byte)Resultado[nameof(Usuario1.IdUsuario)] > 0)
                                {
                                    Usuario1.IdUsuario = (byte)Resultado[nameof(Usuario1.IdUsuario)];
                                    Usuario1.IdGuid = (Guid)Resultado[nameof(Usuario1.IdGuid)];
                                    Tarjeta1.Resultado = Constantes.Resultado.Correcto;
                                }
                                else
                                {
                                    Tarjeta1.Resultado = Constantes.Resultado.Incorrecto;
                                }
                            }
                            else
                            {
                                Tarjeta1.Resultado = Constantes.Resultado.Incorrecto;
                            }
                            break;
                        }
                    case Constantes.Accion.Actualizar:
                        {
                            if (Usuario1.IdUsuario <= 0) throw new FormatException();
                            Tuple<object, string, bool>[] T1 = Estructuras.GenerarTuplaGuardarRegistro(Usuario1, nameof(Usuario1.IdUsuario), nameof(Usuario1.IdGuid), Tarjeta1.Accion);
                            using (Consultar ObjConsultas = new Consultar()) Resultado = ObjConsultas.Consultas(Constantes.Consulta.ActualizarUsuarios, T1);
                            Tarjeta1.Resultado = Constantes.Resultado.Correcto;
                            break;
                        }
                    case Constantes.Accion.Eliminar:
                        {
                            Usuario1.IdUsuario = 0;
                            Tarjeta1.Resultado = Constantes.Resultado.Incorrecto;
                            Tarjeta1.Error = "Favor de contactarse con el soporte de la página y reportar el siguiente error: CCP-N-03";
                            break;
                        }
                }
            }
            catch (Exception)
            {
                Usuario1.IdUsuario = 0;
                Tarjeta1.Resultado = Constantes.Resultado.Error;
            }
        }
    }
}
