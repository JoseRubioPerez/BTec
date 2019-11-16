using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplicacion.Administrador
{
    public partial class PanelGeneral1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Tarjeta"] == null)
            {
                Page.Response.Redirect("~/LogIn.aspx", false);
                return;
            }
        }
        [WebMethod(EnableSession = true)]
        public static object CargarGrafica()
        {
            if (HttpContext.Current.Session["Tarjeta"] == null)
            {
                return null;
            }
            Estructuras.Tarjeta Tarjeta1 = (Estructuras.Tarjeta)HttpContext.Current.Session["Tarjeta"];
            using (Movimientos ObjMovimientos = new Movimientos()) ObjMovimientos.CargarGrafica(ref Tarjeta1);
            Dictionary<string, object> Response = new Dictionary<string, object>();
            List<byte> IdServicioLista = new List<byte>();
            List<string> ServicioLista = new List<string>();
            List<int> TotalLista = new List<int>();
            foreach (DataRow Fila in Tarjeta1.TablaConsulta?.Rows)
            {
                IdServicioLista.Add((byte)Fila["IdServicio"]);
                ServicioLista.Add(Fila["Servicio"].ToString());
                TotalLista.Add((int)Fila["Total"]);
            }

            Response.Add("IdServicio", IdServicioLista);
            Response.Add("Servicio", ServicioLista);
            Response.Add("Total", TotalLista);

            object Json = new { data = Response };
            return Json;
        }
    }
}