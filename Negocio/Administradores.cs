using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Datos;
using Entidades;

namespace Negocio
{
    public class Administradores : IDisposable
    {
        public Administradores()
        {

        }
        ~Administradores()
        {
            Dispose();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public void ConsultarCatalogoAdministradores(ref Estructuras.Tarjeta Tarjeta1, ref Estructuras.Administradores Administradores1, DateTime FechaInicio, DateTime FechaFin, bool BuscarTodosLosEstados = false)
        {
            DataTable Tabla = new DataTable();
            Dictionary<string, object> Resultado = new Dictionary<string, object>();
            Tarjeta1.Error = string.Empty;
            try
            {
                switch (Tarjeta1.TipoConsulta)
                {
                    case Constantes.TipoConsulta.Masiva:
                        {
                            Tuple<object, string>[] T1 = Estructuras.GenerarTuplaLeerRegistros(Administradores1, FechaInicio, FechaFin, Tarjeta1.TipoConsulta);
                            using (Consultar ObjConsulta = new Consultar()) Tabla = ObjConsulta.Consultas(Constantes.Consulta.LeerAdministradores, T1);
                            Tarjeta1.TablaConsulta = Tabla;
                            break;
                        }
                    case Constantes.TipoConsulta.IndividualPorId:
                        {
                            if (Administradores1.IdAdministrador <= 0) throw new FormatException();
                            Tuple<object, string, bool>[] T1 = Estructuras.GenerarTuplaLeerRegistros(Administradores1, FechaInicio, FechaFin, Tarjeta1.TipoConsulta, BuscarTodosLosEstados, nameof(Administradores1.IdAdministrador));
                            using (Consultar ObjConsulta = new Consultar()) Resultado = ObjConsulta.Consultas(Constantes.Consulta.LeerAdministradores, T1);
                            if (Resultado.Count > 0)
                            {
                                if ((int)Resultado["IdUsuarioCreacion"] > 0)
                                {
                                    Administradores1 = (Estructuras.Administradores)Estructuras.DictionaryEnEstructura(Administradores1, Resultado);
                                    Tarjeta1.Resultado = Constantes.Resultado.Correcto;
                                }
                            }
                            break;
                        }
                    default:
                        {
                            Tarjeta1.Error = "Favor de contactarse con el soporte de la página y reportar el siguiente error: CCP-N-01";
                            throw new Exception();
                        }
                }
            }
            catch (FormatException)
            {
                Tarjeta1.Error = "Favor de contactarse con el soporte de la página y reportar el siguiente error: CCP-N-02";
                Tarjeta1.Resultado = Constantes.Resultado.Error;
                Tarjeta1.TablaConsulta = null;
            }
            catch (Exception)
            {
                Tarjeta1.Resultado = Constantes.Resultado.Error;
                Tarjeta1.TablaConsulta = null;
            }
        }
        public void GuardarAdministradores(ref Estructuras.Tarjeta Tarjeta1, ref Estructuras.Administradores Administradores1)
        {
            Dictionary<string, object> Resultado = new Dictionary<string, object>();
            Tarjeta1.Error = string.Empty;
            try
            {
                switch (Tarjeta1.Accion)
                {
                    case Constantes.Accion.Insertar:
                        {
                            Tuple<object, string, bool>[] T1 = Estructuras.GenerarTuplaGuardarRegistro(Administradores1, nameof(Administradores1.IdAdministrador), nameof(Administradores1.IdGuid), Tarjeta1.Accion);
                            using (Consultar ObjConsulta = new Consultar()) Resultado = ObjConsulta.Consultas(Constantes.Consulta.CrearAdministradores, T1);
                            if (Resultado.Count > 0)
                            {
                                if ((byte)Resultado["IdAdministrador"] > 0)
                                {
                                    Administradores1.IdAdministrador = (byte)Resultado["IdAdministrador"];
                                    Administradores1.IdGuid = (Guid)Resultado["IdGuid"];
                                }
                            }
                            Tarjeta1.Resultado = Constantes.Resultado.Correcto;
                            break;
                        }
                    case Constantes.Accion.Actualizar:
                        {
                            if (Administradores1.IdAdministrador <= 0) throw new FormatException();
                            Tuple<object, string, bool>[] T1 = Estructuras.GenerarTuplaGuardarRegistro(Administradores1, nameof(Administradores1.IdAdministrador), nameof(Administradores1.IdGuid), Tarjeta1.Accion);
                            using (Consultar ObjConsulta = new Consultar()) Resultado = ObjConsulta.Consultas(Constantes.Consulta.ActualizarAdministradores, T1);
                            Tarjeta1.Resultado = Constantes.Resultado.Correcto;
                            break;
                        }
                    case Constantes.Accion.Eliminar:
                        {
                            Administradores1.IdAdministrador = 0;
                            Tarjeta1.Resultado = Constantes.Resultado.Incorrecto;
                            Tarjeta1.Error = "Favor de contactarse con el soporte de la página y reportar el siguiente error: CCP-N-03";
                            break;
                        }
                }
            }
            catch (Exception)
            {
                Administradores1.IdAdministrador = 0;
                Tarjeta1.Resultado = Constantes.Resultado.Error;
            }
        }
    }
}
