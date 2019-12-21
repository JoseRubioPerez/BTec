using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Services;

namespace Aplicacion
{
    public partial class Glossary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(EnableSession = true)]
        public static object LlenarTablaMovimientos()
        {
            try
            {
                if (HttpContext.Current.Session["TablaMovimientos"] == null)
                {
                    return null;
                }
                DataTable Tabla = (DataTable)HttpContext.Current.Session["TablaMovimientos"];
                List<Dictionary<string, object>> Response = new List<Dictionary<string, object>>();
                foreach (DataRow Fila in Tabla.Rows)
                {
                    Response.Add(new Dictionary<string, object>
                    {
                        { "IdMovimiento", (int)Fila["IdMovimiento"] },
                        { "NumeroControl", Fila["NumeroControl"].ToString() },
                        { "Nombres", Fila["Nombres"].ToString() },
                        { "Paterno", Fila["Paterno"].ToString() },
                        { "Materno", Fila["Materno"].ToString() },
                        { "Genero", Fila["Genero"].ToString() },
                        { "Area", Fila["Area"].ToString() },
                        { "IdServicio", (int)Fila["IdServicio"] },
                        { "Servicio", Fila["Servicio"].ToString() },
                        { "FechaCreacion", DateTime.Parse(Fila["FechaCreacion"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") }
                    });
                }
                object Json = new { data = Response };
                return Json;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}