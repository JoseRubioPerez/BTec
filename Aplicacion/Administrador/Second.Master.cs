using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplicacion.Administrador
{
    public partial class Second : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Tarjeta"] == null)
            {
                Page.Response.Redirect("~/LogIn.aspx", false);
                return;
            }
        }
        protected void LBUsuarios_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Tarjeta"] == null)
            {
                Page.Response.Redirect("~/LogIn.aspx", false);
                return;
            }
        }
        protected void LBMovimientos_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Tarjeta"] == null)
            {
                Page.Response.Redirect("~/LogIn.aspx", false);
                return;
            }
            Page.Response.Redirect("~/Administrador/Movimientos.aspx", false);
        }
        protected void LBServicios_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Tarjeta"] == null)
            {
                Page.Response.Redirect("~/LogIn.aspx", false);
                return;
            }
        }
        protected void LBAreas_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Tarjeta"] == null)
            {
                Page.Response.Redirect("~/LogIn.aspx", false);
                return;
            }
        }
        protected void LBCerrarSession_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Cookies.Clear();
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Response.Redirect("~/LogIn.aspx", false);
        }

        protected void LBTextoInicio_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Tarjeta"] == null)
            {
                Page.Response.Redirect("~/LogIn.aspx", false);
                return;
            }
            Page.Response.Redirect("~/Administrador/PanelGeneral.aspx", false);
        }
        protected void LBAdministradores_Click(object sender, EventArgs e)
        {

        }
    }
}