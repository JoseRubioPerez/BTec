using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace Negocio
{
    public class Areas : IDisposable
    {
        public Areas()
        {

        }
        ~Areas()
        {
            Dispose();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public void ConsultarCatalogoAreas(ref Estructuras.Tarjeta Tarjeta1, ref Estructuras.Areas Area1, DateTime FechaInicio, DateTime FechaFin, bool BuscarRangoFecha = true, bool BuscarTodosLosEstados = false)
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
                            Tuple<object, string>[] T1 = Estructuras.GenerarTuplaLeerRegistros(Area1, FechaInicio, FechaFin, Tarjeta1.TipoConsulta, BuscarTodosLosEstados);
                            using (Consultar ObjConsultar = new Consultar()) Tabla = ObjConsultar.Consultas(Constantes.Consulta.LeerAreas, T1);
                            Tarjeta1.TablaConsulta = Tabla;
                            break;
                        }
                    case Constantes.TipoConsulta.IndividualPorId:
                        {
                            if (Area1.IdArea <= 0) throw new FormatException();
                            Tuple<object, string, bool>[] T1 = Estructuras.GenerarTuplaLeerRegistros(Area1, FechaInicio, FechaFin, Tarjeta1.TipoConsulta, BuscarTodosLosEstados, nameof(Area1.IdArea));
                            using (Consultar ObjConsultar = new Consultar()) Resultado = ObjConsultar.Consultas(Constantes.Consulta.LeerAreas, T1);

                            if (Resultado.Count > 0)
                            {
                                if ((int)Resultado[nameof(Area1.IdArea)] > 0)
                                {
                                    Area1 = (Estructuras.Areas)Estructuras.DictionaryEnEstructura(Area1, Resultado);
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
        public void GuardarArea(ref Estructuras.Tarjeta Tarjeta1, ref Estructuras.Areas Area1)
        {
            Dictionary<string, object> Resultado = new Dictionary<string, object>();
            Tarjeta1.Error = string.Empty;
            try
            {
                switch (Tarjeta1.Accion)
                {
                    case Constantes.Accion.Insertar:
                        {
                            Tuple<object, string, bool>[] T1 = Estructuras.GenerarTuplaGuardarRegistro(Area1, nameof(Area1.IdArea), nameof(Area1.IdGuid), Tarjeta1.Accion);
                            using (Consultar ObjConsultas = new Consultar()) Resultado = ObjConsultas.Consultas(Constantes.Consulta.CrearAreas, T1);
                            if (Resultado.Count > 0)
                            {
                                if ((byte)Resultado[nameof(Area1.IdArea)] > 0)
                                {
                                    Area1.IdArea = (byte)Resultado[nameof(Area1.IdArea)];
                                    Area1.IdGuid = (Guid)Resultado[nameof(Area1.IdGuid)];
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
                            if (Area1.IdArea <= 0) throw new FormatException();
                            Tuple<object, string, bool>[] T1 = Estructuras.GenerarTuplaGuardarRegistro(Area1, nameof(Area1.IdArea), nameof(Area1.IdGuid), Tarjeta1.Accion);
                            using (Consultar ObjConsultas = new Consultar()) Resultado = ObjConsultas.Consultas(Constantes.Consulta.ActualizarAreas, T1);
                            Tarjeta1.Resultado = Constantes.Resultado.Correcto;
                            break;
                        }
                    case Constantes.Accion.Eliminar:
                        {
                            Area1.IdArea = 0;
                            Tarjeta1.Resultado = Constantes.Resultado.Incorrecto;
                            Tarjeta1.Error = "Favor de contactarse con el soporte de la página y reportar el siguiente error: CCP-N-03";
                            break;
                        }
                }
            }
            catch (Exception)
            {
                Area1.IdArea = 0;
                Tarjeta1.Resultado = Constantes.Resultado.Error;
            }
        }
    }
}
