using Datos;
using Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Movimientos : IDisposable
    {
        public Movimientos()
        {

        }
        ~Movimientos()
        {
            Dispose();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public void CargarGrafica(ref Estructuras.Tarjeta Tarjeta1)
        {
            DataTable Tabla = new DataTable();
            using (Consultar ObjConsultar = new Consultar()) Tabla = ObjConsultar.ConsultaSinParametros(Constantes.Consulta.GraficaMovimientos);
            Tarjeta1.TablaConsulta = Tabla;
        }
        public void ConsultarCatalogoMovimientos(ref Estructuras.Tarjeta Tarjeta1, ref Estructuras.Movimientos Movimiento1, DateTime FechaInicio, DateTime FechaFin, bool BuscarRangoFecha = true, bool BuscarTodosLosEstados = false)
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
                            Tuple<object, string>[] T1 = Estructuras.GenerarTuplaLeerRegistros(Movimiento1, FechaInicio, FechaFin, Tarjeta1.TipoConsulta, BuscarTodosLosEstados);
                            using (Consultar ObjConsultar = new Consultar()) Tabla = ObjConsultar.Consultas(Constantes.Consulta.LeerMovimientos, T1);
                            Tarjeta1.TablaConsulta = Tabla;
                            break;
                        }
                    case Constantes.TipoConsulta.IndividualPorId:
                        {
                            if (Movimiento1.IdMovimiento <= 0) throw new FormatException();
                            Tuple<object, string, bool>[] T1 = Estructuras.GenerarTuplaLeerRegistros(Movimiento1, FechaInicio, FechaFin, Tarjeta1.TipoConsulta, BuscarTodosLosEstados, nameof(Movimiento1.IdMovimiento));
                            using (Consultar ObjConsultar = new Consultar()) Resultado = ObjConsultar.Consultas(Constantes.Consulta.LeerMovimientos, T1);

                            if (Resultado.Count > 0)
                            {
                                if ((int)Resultado[nameof(Movimiento1.IdUsuario)] > 0)
                                {
                                    Movimiento1 = (Estructuras.Movimientos)Estructuras.DictionaryEnEstructura(Movimiento1, Resultado);
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
        public void GuardarMovimiento(ref Estructuras.Tarjeta Tarjeta1, ref Estructuras.Movimientos Movimiento1)
        {
            Dictionary<string, object> Resultado = new Dictionary<string, object>();
            Tarjeta1.Error = string.Empty;
            try
            {
                switch (Tarjeta1.Accion)
                {
                    case Constantes.Accion.Insertar:
                        {
                            Tuple<object, string, bool>[] T1 = Estructuras.GenerarTuplaGuardarRegistro(Movimiento1, nameof(Movimiento1.IdMovimiento), nameof(Movimiento1.IdGuid), Tarjeta1.Accion);
                            using (Consultar ObjConsultas = new Consultar()) Resultado = ObjConsultas.Consultas(Constantes.Consulta.CrearMovimientos, T1);
                            if (Resultado.Count > 0)
                            {
                                if ((byte)Resultado[nameof(Movimiento1.IdMovimiento)] > 0)
                                {
                                    Movimiento1.IdMovimiento = (byte)Resultado[nameof(Movimiento1.IdMovimiento)];
                                    Movimiento1.IdGuid = (Guid)Resultado[nameof(Movimiento1.IdGuid)];
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
                            if (Movimiento1.IdMovimiento <= 0) throw new FormatException();
                            Tuple<object, string, bool>[] T1 = Estructuras.GenerarTuplaGuardarRegistro(Movimiento1, nameof(Movimiento1.IdMovimiento), nameof(Movimiento1.IdGuid), Tarjeta1.Accion);
                            using (Consultar ObjConsultas = new Consultar()) Resultado = ObjConsultas.Consultas(Constantes.Consulta.ActualizarMovimientos, T1);
                            Tarjeta1.Resultado = Constantes.Resultado.Correcto;
                            break;
                        }
                    case Constantes.Accion.Eliminar:
                        {
                            Movimiento1.IdMovimiento = 0;
                            Tarjeta1.Resultado = Constantes.Resultado.Incorrecto;
                            Tarjeta1.Error = "Favor de contactarse con el soporte de la página y reportar el siguiente error: CCP-N-03";
                            break;
                        }
                }
            }
            catch (Exception)
            {
                Movimiento1.IdMovimiento = 0;
                Tarjeta1.Resultado = Constantes.Resultado.Error;
            }
        }

    }
}
