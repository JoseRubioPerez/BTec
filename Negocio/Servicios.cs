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
    public class Servicios : IDisposable
    {
        public Servicios()
        {

        }
        ~Servicios()
        {
            Dispose();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public void ConsultarCatalogoServicios(ref Estructuras.Tarjeta Tarjeta1, ref Estructuras.Servicios Servicio1, DateTime FechaInicio, DateTime FechaFin, bool BuscarRangoFecha = true, bool BuscarTodosLosEstados = false)
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
                            Tuple<object, string>[] T1 = Estructuras.GenerarTuplaLeerRegistros(Servicio1, FechaInicio, FechaFin, Tarjeta1.TipoConsulta, BuscarTodosLosEstados);
                            using (Consultar ObjConsultar = new Consultar()) Tabla = ObjConsultar.Consultas(Constantes.Consulta.LeerServicios, T1);
                            Tarjeta1.TablaConsulta = Tabla;
                            break;
                        }
                    case Constantes.TipoConsulta.IndividualPorId:
                        {
                            if (Servicio1.IdServicio <= 0) throw new FormatException();
                            Tuple<object, string, bool>[] T1 = Estructuras.GenerarTuplaLeerRegistros(Servicio1, FechaInicio, FechaFin, Tarjeta1.TipoConsulta, BuscarTodosLosEstados, nameof(Servicio1.IdServicio));
                            using (Consultar ObjConsultar = new Consultar()) Resultado = ObjConsultar.Consultas(Constantes.Consulta.LeerServicios, T1);

                            if (Resultado.Count > 0)
                            {
                                if ((int)Resultado[nameof(Servicio1.IdAdminCreacion)] > 0)
                                {
                                    Servicio1 = (Estructuras.Servicios)Estructuras.DictionaryEnEstructura(Servicio1, Resultado);
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
        public void GuardarServicio(ref Estructuras.Tarjeta Tarjeta1, ref Estructuras.Servicios Servicio1)
        {
            Dictionary<string, object> Resultado = new Dictionary<string, object>();
            Tarjeta1.Error = string.Empty;
            try
            {
                switch (Tarjeta1.Accion)
                {
                    case Constantes.Accion.Insertar:
                        {
                            Tuple<object, string, bool>[] T1 = Estructuras.GenerarTuplaGuardarRegistro(Servicio1, nameof(Servicio1.IdServicio), nameof(Servicio1.IdGuid), Tarjeta1.Accion);
                            using (Consultar ObjConsultas = new Consultar()) Resultado = ObjConsultas.Consultas(Constantes.Consulta.CrearServicios, T1);
                            if (Resultado.Count > 0)
                            {
                                if ((byte)Resultado[nameof(Servicio1.IdServicio)] > 0)
                                {
                                    Servicio1.IdServicio = (byte)Resultado[nameof(Servicio1.IdServicio)];
                                    Servicio1.IdGuid = (Guid)Resultado[nameof(Servicio1.IdGuid)];
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
                            if (Servicio1.IdServicio <= 0) throw new FormatException();
                            Tuple<object, string, bool>[] T1 = Estructuras.GenerarTuplaGuardarRegistro(Servicio1, nameof(Servicio1.IdServicio), nameof(Servicio1.IdGuid), Tarjeta1.Accion);
                            using (Consultar ObjConsultas = new Consultar()) Resultado = ObjConsultas.Consultas(Constantes.Consulta.ActualizarServicios, T1);
                            Tarjeta1.Resultado = Constantes.Resultado.Correcto;
                            break;
                        }
                    case Constantes.Accion.Eliminar:
                        {
                            Servicio1.IdServicio = 0;
                            Tarjeta1.Resultado = Constantes.Resultado.Incorrecto;
                            Tarjeta1.Error = "Favor de contactarse con el soporte de la página y reportar el siguiente error: CCP-N-03";
                            break;
                        }
                }
            }
            catch (Exception)
            {
                Servicio1.IdServicio = 0;
                Tarjeta1.Resultado = Constantes.Resultado.Error;
            }
        }
    }
}
