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
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            TBNumeroControl.Text = string.Empty;
            DDLArea.SelectedIndex = -1;
            DDLEstaActivo.SelectedValue = "1";
        }
        protected void LBGuardar_Click(object sender, EventArgs e)
        {
            TBNumeroControl.Text = TBNumeroControl.Text.Trim();
            TBPaterno.Text = TBPaterno.Text.Trim();
            TBNombres.Text = TBNombres.Text.Trim();
            TBMaterno.Text = TBMaterno.Text.Trim();
            if (string.IsNullOrEmpty(TBNumeroControl.Text))
            {
                GenerarAlerta("¡Ingresa un valor!", Constantes.AlertaBootstrap.Danger, "El número de control no puede ir vacío.");
                return;
            }
            if (string.IsNullOrEmpty(TBNombres.Text))
            {
                GenerarAlerta("¡Ingresa un valor!", Constantes.AlertaBootstrap.Danger, "El nombre no puede ir vacío.");
                return;
            }
            if (string.IsNullOrEmpty(TBPaterno.Text))
            {
                GenerarAlerta("¡Ingresa un valor!", Constantes.AlertaBootstrap.Danger, "El apellido paterno no puede ir vacío.");
                return;
            }
            if (!string.IsNullOrEmpty(TBMaterno.Text))
            {
                if (Validar.ContieneNumeros(TBMaterno.Text))
                {
                    GenerarAlerta("¡Ingresa un valor!", Constantes.AlertaBootstrap.Danger, "El apellido paterno no puede ir vacío.");
                    return;
                }
            }
            if (!byte.TryParse(DDLArea.SelectedValue, out byte IdArea))
            {
                GenerarAlerta("¡Sin área!", Constantes.AlertaBootstrap.Danger, "El área debe ser un valor válido.");
                return;
            }
            if (!byte.TryParse(DDLGenero.SelectedValue, out byte IdGenero))
            {
                GenerarAlerta("¡Sin género!", Constantes.AlertaBootstrap.Danger, "El género debe ser un valor válido.");
                return;
            }
            if (!bool.TryParse(DDLEstaActivo.SelectedValue, out bool EstaActivo))
            {
                GenerarAlerta("¡Sin estado del registro!", Constantes.AlertaBootstrap.Danger, "El estado del registro debe ser un valor válido.");
                return;
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
            if (HttpContext.Current.Session["TablaMovimientos"] == null)
            {
                /*Estructuras.Tarjeta Tarjeta1 = (Estructuras.Tarjeta)HttpContext.Current.Session["Tarjeta"];
                Tarjeta1.TipoConsulta = Constantes.TipoConsulta.Masiva;
                Estructuras.Movimientos Movimiento1 = new Estructuras.Movimientos { IdEstaActivo = true };
                DateTime FechaInicio = DateTime.Parse("01/01/1900"), FechaFin = new DateTime(2099, 1, 1, 23, 59, 59);
                using (Movimientos ObjMovimientos = new Movimientos()) ObjMovimientos.ConsultarCatalogoMovimientos(ref Tarjeta1, ref Movimiento1, FechaInicio, FechaFin, true, true);
                HttpContext.Current.Session["TablaMovimientos"] = Tarjeta1.TablaConsulta;
                HttpContext.Current.Session["ConteoMovimientos"] = Tarjeta1.TablaConsulta?.Rows.Count.ToString();
                GVMovimientos.DataSource = Tarjeta1.TablaConsulta;
                GVMovimientos.DataBind();*/
            }
            else
            {
                /*DataTable Tabla = (DataTable)HttpContext.Current.Session["TablaMovimientos"];
                HttpContext.Current.Session["ConteoMovimientos"] = Tabla?.Rows.Count.ToString();
                GVMovimientos.DataSource = Tabla;
                GVMovimientos.DataBind();*/
            }
        }
        protected void LBVolver_Click(object sender, EventArgs e)
        {
            ActivarConsulta(false);
            MultiView1.SetActiveView(ViewNuevo);
        }
    }
}