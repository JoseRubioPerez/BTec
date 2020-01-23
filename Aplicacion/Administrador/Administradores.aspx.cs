using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplicacion.Administrador
{
    public partial class Administradores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Tarjeta"] == null)
            {
                Page.Response.Redirect("~/LogIn.aspx", false);
                return;
            }
            if (!Page.IsPostBack)
            {
                MultiView1.SetActiveView(ViewNuevo);
            }
        }
        private void GenerarAlerta(string TextoNegritas, Constantes.AlertaBootstrap AlertaBootstrap1, string Texto = "Revisa el campo, por favor.")
        {
            if (HttpContext.Current.Session["Tarjeta"] == null)
            {
                Page.Response.Redirect("~/LogIn.aspx", false);
                return;
            }
            Alerta1.Attributes.Remove("class");
            AlertaTextoNegritas1.InnerText = TextoNegritas;
            AlertaTexto1.InnerText = Texto;
            Alerta1.Visible = true;
            switch (AlertaBootstrap1)
            {
                case Constantes.AlertaBootstrap.Success:
                    {
                        Alerta1.Attributes.Add("class", "alert alert-success alert-dismissible fade show");
                        break;
                    }
                case Constantes.AlertaBootstrap.Warning:
                    {
                        Alerta1.Attributes.Add("class", "alert alert-warning alert-dismissible fade show");
                        break;
                    }
                case Constantes.AlertaBootstrap.Danger:
                    {
                        Alerta1.Attributes.Add("class", "alert alert-danger alert-dismissible fade show");
                        break;
                    }
            }
        }
        private void ActivarConsulta(bool Bandera)
        {
            LBVolver.Visible = Bandera;
            LBConsultar.Visible = !Bandera;
            LBNuevo.Visible = !Bandera;
            LBGuardar.Visible = !Bandera;
        }
        protected void LBNuevo_Click(object sender, EventArgs e)
        {
            TBcodigo.Text = string.Empty;
            TBServicio.Text = string.Empty;
            DDLEstaActivo.SelectedValue = "1";
        }
        protected void LBGuardar_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Tarjeta"] == null)
            {
                Page.Response.Redirect("~/LogIn.aspx", false);
                return;
            }

            TBServicio.Text = TBServicio.Text.Trim();
            if (string.IsNullOrEmpty(TBServicio.Text))
            {
                GenerarAlerta("¡Ingresa un valor!", Constantes.AlertaBootstrap.Danger, "El servicio no puede ir vacía.");
                return;
            }

            if (int.Parse(DDLEstaActivo.SelectedValue) < 0)
            {
                GenerarAlerta("¡Sin estado del registro!", Constantes.AlertaBootstrap.Danger, "El estado del registro debe ser un valor válido.");
                return;
            }

            Estructuras.Tarjeta Tarjeta1 = (Estructuras.Tarjeta)HttpContext.Current.Session["Tarjeta"];
            Tarjeta1.Accion = Constantes.Accion.Insertar;
            DateTime Fecha = DateTime.Now;
            Estructuras.Servicios Servicio1 = new Estructuras.Servicios
            {
                Servicio = TBServicio.Text,
                FechaCreacion = Fecha,
                FechaActualizacion = Fecha,
                IdEstaActivo = Convert.ToBoolean(int.Parse(DDLEstaActivo.SelectedValue)),
                IdAdminCreacion = Tarjeta1.Administrador.IdAdministrador,
                IdAdminActualizacion = Tarjeta1.Administrador.IdAdministrador
            };
            using (Negocio.Servicios ObjServicios = new Negocio.Servicios())
            {
                ObjServicios.GuardarServicio(ref Tarjeta1, ref Servicio1);

                if (Tarjeta1.Resultado == Constantes.Resultado.Correcto)
                {
                    GenerarAlerta("¡Guardado!", Constantes.AlertaBootstrap.Success, "El registro se guardo correctamente.");
                }
                else
                {
                    GenerarAlerta("¡Ocurrió un error!", Constantes.AlertaBootstrap.Danger, "El registro no se pudo guardar correctamente.");
                }
            }
        }
        protected void LBConsultar_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Tarjeta"] == null)
            {
                Page.Response.Redirect("~/LogIn.aspx", false);
                return;
            }
            ActivarConsulta(true);
            MultiView1.SetActiveView(ViewConsultar);
            Estructuras.Tarjeta Tarjeta1 = (Estructuras.Tarjeta)HttpContext.Current.Session["Tarjeta"];
            Tarjeta1.TipoConsulta = Constantes.TipoConsulta.Masiva;
            Estructuras.Servicios Movimiento1 = new Estructuras.Servicios { IdEstaActivo = true };
            DateTime FechaInicio = DateTime.Parse("01/01/1900"), FechaFin = new DateTime(2099, 1, 1, 23, 59, 59);
            using (Negocio.Servicios ObjServicios = new Negocio.Servicios()) ObjServicios.ConsultarCatalogoServicios(ref Tarjeta1, ref Movimiento1, FechaInicio, FechaFin, true, true);
            HttpContext.Current.Session["TablaServicios"] = Tarjeta1.TablaConsulta;
            HttpContext.Current.Session["ConteoServicios"] = Tarjeta1.TablaConsulta?.Rows.Count.ToString();
            GVMovimientos.DataSource = Tarjeta1.TablaConsulta;
            GVMovimientos.DataBind();
        }
        protected void LBVolver_Click(object sender, EventArgs e)
        {
            ActivarConsulta(false);
            MultiView1.SetActiveView(ViewNuevo);
        }
    }
}