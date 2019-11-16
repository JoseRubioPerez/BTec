<%@ Page Title="BTec - Control de Usuarios" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Aplicacion.Index" Culture="es-MX" UICulture="es-MX" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        body {
            height: auto !important;
        }

        .iconos-blue {
            width: 80px;
        }

        .iconos-card {
            width: 80px;
        }

        .linea-card {
            width: 100%;
            border-bottom: solid 2px #21db81;
        }

        .texto-card {
            font-size: 13px;
            color: #717070;
        }

        .card-group {
            height: auto;
            border-radius: 16px;
        }
    </style>
    <div class="container body-content">
        <div class="row mt-5 text-center">
            <div class="col-12 py-4" style="background-color: slategray;">
                <h2>Control de Usuarios del Centro de Informaci&oacute;n del Instituto Tecnol&oacute;gico de Delicias</h2>
                <h4 class="text-light">Por favor, inicia sesi&oacute;n</h4>
            </div>
        </div>
        <div></div>
    </div>
</asp:Content>
