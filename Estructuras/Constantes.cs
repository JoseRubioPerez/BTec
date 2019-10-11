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
        public enum Consulta
        {
            SinAsignar = 0,
            Masiva = 1,
            IndividualPorId = 2,
            ParaCatalogo = 3,
            PorParametro = 4
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
        #endregion

        #region ValorMaximo
        public enum SizeConsulta
        {
            Minimo = 1,
            Maximo = 1000000
        }
        #endregion
        #region Procedimientos Almacenados
        public enum Procedimiento
        {

        }
        #endregion
    }

}
