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
                            Tuple<object, string>[] T1 = Estructuras.GenerarTupla(Administradores1, FechaInicio, FechaFin, Tarjeta1.TipoConsulta);
                            using (Consultar ObjConsulta = new Consultar()) Tabla = ObjConsulta.Consultas(Constantes.Consulta.LeerAdministradores, T1);
                            Tarjeta1.TablaConsulta = Tabla;
                            break;
                        }
                    case Constantes.TipoConsulta.IndividualPorId:
                        {
                            if (Administradores1.IdAdministrador <= 0) throw new FormatException();
                            Tuple<object, string, bool>[] T1 = Estructuras.GenerarTupla(Administradores1, FechaInicio, FechaFin, Tarjeta1.TipoConsulta, BuscarTodosLosEstados, nameof(Administradores1.IdAdministrador));
                            using (Consultar ObjConsulta = new Consultar()) Resultado = ObjConsulta.Consultas(Constantes.Consulta.LeerAdministradores, T1);
                            if (Resultado.Count > 0)
                            {
                                if ((int)Resultado["IdUsuarioCreacion"] > 0)
                                {
                                    Administradores1.IdGuid = (Guid)Resultado[nameof(Administradores1.IdGuid)];
                                    Administradores1.NumeroControl = Resultado[nameof(Administradores1.NumeroControl)].ToString();
                                    Administradores1.Nombres = Resultado[nameof(Administradores1.Nombres)].ToString();
                                    Administradores1.Paterno = Resultado[nameof(Administradores1.Paterno)].ToString();
                                    Administradores1.Materno = Resultado[nameof(Administradores1.Materno)].ToString();
                                    Administradores1.Contrasenia = string.Empty;
                                    Administradores1.Contrasenia = Resultado[nameof(Administradores1.Contrasenia)].ToString();
                                    Administradores1.UrlFoto = Resultado[nameof(Administradores1.UrlFoto)].ToString();
                                    Administradores1.IdGenero = (byte)Resultado[nameof(Administradores1.IdGenero)];
                                    Administradores1.IdEditable = (bool)Resultado[nameof(Administradores1.IdEditable)];
                                    Administradores1.IdEstaActivo = (bool)Resultado[nameof(Administradores1.IdEstaActivo)];
                                    Administradores1.FechaCreacion = (DateTime)Resultado[nameof(Administradores1.IdEditable)];
                                    Administradores1.FechaActualizacion = (DateTime)Resultado[nameof(Administradores1.IdEditable)];
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
                            Tuple<object, string, bool>[] T1 = Estructuras.GenerarTupla(Administradores1, nameof(Administradores1.IdAdministrador), nameof(Administradores1.IdGuid));
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
                            Tuple<object, string, bool>[] T1 = Estructuras.GenerarTupla(Administradores1, nameof(Administradores1.IdAdministrador), nameof(Administradores1.IdGuid));
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
