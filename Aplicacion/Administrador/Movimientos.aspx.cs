﻿using Entidades;
using Negocio;
using System;
using System.Data;
using System.Web;
using System.Web.UI;

namespace Aplicacion.Administrador
{
    public partial class PanelGeneral : System.Web.UI.Page
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
            TBNumeroControl.Text = string.Empty;
            DDLServicio.SelectedIndex = -1;
            DDLEstaActivo.SelectedValue = "1";
        }
        protected void LBGuardar_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Tarjeta"] == null)
            {
                Page.Response.Redirect("~/LogIn.aspx", false);
                return;
            }

            TBNumeroControl.Text = TBNumeroControl.Text.Trim();
            if (string.IsNullOrEmpty(TBNumeroControl.Text))
            {
                GenerarAlerta("¡Ingresa un valor!", Constantes.AlertaBootstrap.Danger, "El servicio no puede ir vacía.");
                return;
            }

            if (int.Parse(DDLServicio.SelectedValue) > 0)
            {
                GenerarAlerta("¡Ingresa un valor!", Constantes.AlertaBootstrap.Danger, "El servicio no puede ir vacía.");
                return;
            }

            if (int.Parse(DDLEstaActivo.SelectedValue) < 0)
            {
                GenerarAlerta("¡Ingresa un valor!", Constantes.AlertaBootstrap.Danger, "El servicio no puede ir vacía.");
                return;
            }

            Estructuras.Tarjeta Tarjeta1 = (Estructuras.Tarjeta)HttpContext.Current.Session["Tarjeta"];
            Tarjeta1.Accion = Constantes.Accion.Insertar;
            DateTime Fecha = DateTime.Now;
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
                Estructuras.Tarjeta Tarjeta1 = (Estructuras.Tarjeta)HttpContext.Current.Session["Tarjeta"];
                Tarjeta1.TipoConsulta = Constantes.TipoConsulta.Masiva;
                Estructuras.Movimientos Movimiento1 = new Estructuras.Movimientos { IdEstaActivo = true };
                DateTime FechaInicio = DateTime.Parse("01/01/1900"), FechaFin = new DateTime(2099, 1, 1, 23, 59, 59);
                using (Movimientos ObjMovimientos = new Movimientos()) ObjMovimientos.ConsultarCatalogoMovimientos(ref Tarjeta1, ref Movimiento1, FechaInicio, FechaFin, true, true);
                HttpContext.Current.Session["TablaMovimientos"] = Tarjeta1.TablaConsulta;
                HttpContext.Current.Session["ConteoMovimientos"] = Tarjeta1.TablaConsulta?.Rows.Count.ToString();
                GVMovimientos.DataSource = Tarjeta1.TablaConsulta;
                GVMovimientos.DataBind();
            }
            else
            {
                DataTable Tabla = (DataTable)HttpContext.Current.Session["TablaMovimientos"];
                HttpContext.Current.Session["ConteoMovimientos"] = Tabla?.Rows.Count.ToString();
                GVMovimientos.DataSource = Tabla;
                GVMovimientos.DataBind();
            }
        }
        protected void LBVolver_Click(object sender, EventArgs e)
        {
            ActivarConsulta(false);
            MultiView1.SetActiveView(ViewNuevo);
        }
    }
}