using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplicacion
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BTIniciarSesion_Click(object sender, EventArgs e)
        {
            FormsAuthentication.RedirectFromLoginPage(TBUsuario.Text, false);

            FormsAuthenticationTicket TicketAutenticacion1 = new FormsAuthenticationTicket(TBUsuario.Text, false, 30);
            string CadenaDeCookies1 = FormsAuthentication.Encrypt(TicketAutenticacion1);
            HttpCookie Cookies1 = new HttpCookie(FormsAuthentication.FormsCookieName, CadenaDeCookies1) { Expires = TicketAutenticacion1.Expiration, Path = FormsAuthentication.FormsCookiePath };
            Response.Cookies.Add(Cookies1);

            string strRedirect = Request["ReturnUrl"];
            if (strRedirect == null) strRedirect = "Index.aspx";
            Response.Redirect(strRedirect, true);
        }
    }
}