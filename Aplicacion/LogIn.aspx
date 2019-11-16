<%@ Page Title="BTec - Control de Usuarios" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Aplicacion.LogIn" Culture="es-MX" UICulture="es-MX" %>

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
        <div class="row my-5 px-0" style="height: 200px;">
            <div class="col-xs-1 col-sm-1 col-md-2 col-lg-2 col-xl-2 col-xxl-2"></div>
            <div class="col-3 background-app"></div>
            <div class="col-xs-10 col-sm-10 col-md-5 col-lg-5 col-xl-5 col-xxl-5">
                <div class="card justify-content-center border-light text-white bg-dark" style="height: 100%;">
                    <div class="card-body">
                        <h5 class="card-title text-center pt-3">BTec</h5>
                        <p class="card-text text-center mb-5">Control Bibliotecario del Instito Tecnol&oacute;gico de Delicias</p>
                        <div class="row mt-3">
                            <div class="col-12">
                                <div class="input-group mb-3">
                                    <asp:TextBox runat="server" ID="TBUsuario" CssClass="form-control" placeholder="Usuario"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12">
                                <div class="input-group mb-3">
                                    <asp:TextBox runat="server" ID="TBContrasenia" CssClass="form-control" placeholder="Contrase&ntilde;a" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12">
                                <asp:Button runat="server" OnClick="BTIniciarSesion_Click" OnClientClick="javascript:;" CssClass="btn btn-primary btn-block" ID="BTIniciarSesion" Font-Bold="true" Text="Iniciar Sesión" />
                            </div>
                        </div>
                        <div class="row pt-3">
                            <div class="col-12">
                                <div id="AlertaIncorrecto" runat="server" visible="false" class="alert alert-danger alert-dismissible fade show" role="alert">
                                    <strong>Usuario y/o Contrase&ntilde;a Incorrecta</strong>. Intenta de nuevo.
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        window.setTimeout(function () {
            $(".alert").fadeTo(500, 0).slideUp(500, function () {
                $(this).remove();
            });
        }, 5000);
    </script>
</asp:Content>
