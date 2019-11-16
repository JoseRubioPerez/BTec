using System;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Aplicacion
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["UserSession"] = null;
            }
        }
        protected void BTIniciarSesion_Click(object sender, EventArgs e)
        {
            Seguridad.Autenticar ObjAutenticar = new Seguridad.Autenticar();
            TBUsuario.Text = TBUsuario.Text.Trim();
            Entidades.Estructuras.Tarjeta Tarjeta1 = new Entidades.Estructuras.Tarjeta
            {
                Administrador = new Entidades.Estructuras.Administradores
                {
                    NumeroControl = TBUsuario.Text.Trim(),
                    Contrasenia = TBContrasenia.Text.Trim()
                }
            };

            if (ObjAutenticar.IniciarSesion(ref Tarjeta1))
            {
                HttpContext.Current.Session["Tarjeta"] = Tarjeta1;
                Page.Response.Redirect("~/Administrador/PanelGeneral.aspx", false);
            }
            else
            {
                AlertaIncorrecto.Visible = true;
            }
        }
    }
}