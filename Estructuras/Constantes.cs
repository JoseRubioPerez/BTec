namespace Entidades
{
    public static class Constantes
    {
        #region Persona
        public enum Genero
        {
            Masculino = 1,
            Femenino = 2
        }
        #endregion

        #region Estados
        public enum Accion
        {
            Insertar = 1,
            Actualizar = 2,
            Eliminar = 3
        }
        public enum TipoConsulta
        {
            SinAsignar = 0,
            Masiva = 1,
            IndividualPorId = 2,
            PorParametro = 3
        }
        public enum EstaActivo
        {
            Activo = 1,
            Inactivo = 0
        }
        public enum Resultado
        {
            Correcto = 1,
            Incorrecto = 2,
            Error = 3
        }
        public enum AlertaBootstrap
        {
            Success,
            Warning,
            Danger
        }
        #endregion

        #region ValorMaximo
        public enum SizeConsulta
        {
            Minimo = 1,
            Maximo = 1000000
        }
        #endregion
        #region Procedimientos Almacenados
        public enum Consulta
        {
            ActualizarAdministradores,
            ActualizarAreas,
            ActualizarContrasenia,
            ActualizarMovimientos,
            ActualizarServicios,
            ActualizarUsuarios,
            CrearAdministradores,
            CrearAreas,
            CrearMovimientos,
            CrearServicios,
            CrearUsuarios,
            GraficaMovimientos,
            IniciarSesion,
            LeerAdministradores,
            LeerAreas,
            LeerMovimientos,
            LeerServicios,
            LeerUsuarios,
            RestaurarContrasenia
        }
        #endregion
    }

}
