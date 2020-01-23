using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplicacion.Administrador
{
    public partial class Areas : System.Web.UI.Page
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
            TBArea.Text = string.Empty;
            DDLEstaActivo.SelectedValue = "1";
        }
        protected void LBGuardar_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Tarjeta"] == null)
            {
                Page.Response.Redirect("~/LogIn.aspx", false);
                return;
            }
            TBArea.Text = TBArea.Text.Trim();
            if (string.IsNullOrEmpty(TBArea.Text))
            {
                GenerarAlerta("¡Ingresa un valor!", Constantes.AlertaBootstrap.Danger, "El area no puede ir vacía.");
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
            Estructuras.Areas Area1 = new Estructuras.Areas
            {
                Area = TBArea.Text,
                FechaCreacion = Fecha,
                FechaActualizacion = Fecha,
                IdEstaActivo = Convert.ToBoolean(int.Parse(DDLEstaActivo.SelectedValue)),
                IdAdminCreacion = Tarjeta1.Administrador.IdAdministrador,
                IdAdminActualizacion = Tarjeta1.Administrador.IdAdministrador
            };
            using (Negocio.Areas ObjAreas = new Negocio.Areas())
            {
                ObjAreas.GuardarArea(ref Tarjeta1, ref Area1);

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
            Estructuras.Areas Area1 = new Estructuras.Areas { IdEstaActivo = true };
            DateTime FechaInicio = DateTime.Parse("01/01/1900"), FechaFin = new DateTime(2099, 1, 1, 23, 59, 59);
            using (Negocio.Areas ObjAreas = new Negocio.Areas()) ObjAreas.ConsultarCatalogoAreas(ref Tarjeta1, ref Area1, FechaInicio, FechaFin, true, true);
            HttpContext.Current.Session["TablaAreas"] = Tarjeta1.TablaConsulta;
            HttpContext.Current.Session["ConteoAreas"] = Tarjeta1.TablaConsulta?.Rows.Count.ToString();
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