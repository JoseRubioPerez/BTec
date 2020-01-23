<%@ Page Title="BTec - Servicios" Language="C#" MasterPageFile="~/Administrador/Second.Master" AutoEventWireup="true" CodeBehind="Administradores.aspx.cs" Inherits="Aplicacion.Administrador.Administradores" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/v/bs4/dt-1.10.20/af-2.3.4/b-1.6.1/cr-1.5.2/fc-3.3.0/fh-3.1.6/kt-2.5.1/r-2.2.3/rg-1.1.1/rr-1.2.6/sc-2.0.1/sl-1.3.1/datatables.min.css" />
    <nav class="navbar navbar-expand-lg navbar-dark bg-secondary">
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
            <div class="navbar-nav">
                <asp:LinkButton runat="server" OnClick="LBVolver_Click" ID="LBVolver" CssClass="nav-item nav-link px-3 font-weight-bold" Visible="false"><i class="fas fa-arrow-circle-left"></i>&emsp;Volver Atr&aacute;s</asp:LinkButton>
                <asp:LinkButton runat="server" OnClick="LBNuevo_Click" ID="LBNuevo" CssClass="nav-item nav-link px-3 font-weight-bold"><i class="fas fa-plus-circle"></i>&emsp;Nuevo</asp:LinkButton>
                <asp:LinkButton runat="server" OnClick="LBGuardar_Click" ID="LBGuardar" CssClass="nav-item nav-link px-3 font-weight-bold"><i class="fas fa-save"></i>&emsp;Guardar</asp:LinkButton>
                <asp:LinkButton runat="server" OnClick="LBConsultar_Click" ID="LBConsultar" CssClass="nav-item nav-link px-3 font-weight-bold"><i class="fas fa-search"></i>&emsp;Consultar</asp:LinkButton>
            </div>
        </div>
    </nav>
    <div class="container-fluid py-5 px-5">
        <div class="row">
            <div class="col-5">
                <h2>Administradores</h2>
                <small class="form-text text-muted">Los campos con asteriscos (<span style="color: red;">*</span>), son campos obligatorios.</small>
                <br />
            </div>
        </div>
        <asp:MultiView runat="server" ID="MultiView1">
            <asp:View runat="server" ID="ViewNuevo">
                <div class="row">
                    <div class="col-xxl-3 col-xl-3 col-lg-3 col-md-3 col-sm-12">
                        <div class="input-group my-3">
                            <label for="code">C&oacute;digo</label>
                            <asp:TextBox runat="server" ID="TBcodigo" Enabled="false" for="code"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xxl-3 col-xl-3 col-lg-3 col-md-3 col-sm-12">
                        <div class="input-group my-3">
                            <label for="numerocontrol">N&uacute;mero de Control</label>
                            <asp:TextBox runat="server" ID="TBNumeroControl" MaxLength="9" for="numerocontrol"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xxl-3 col-xl-3 col-lg-3 col-md-3 col-sm-12">
                        <div class="input-group my-3">
                            <label for="nombres">Nombres</label>
                            <asp:TextBox runat="server" ID="TBNombres" MaxLength="9" for="nombres"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xxl-3 col-xl-3 col-lg-3 col-md-3 col-sm-12">
                        <div class="input-group my-3">
                            <label for="paterno">Apellido paterno</label>
                            <asp:TextBox runat="server" ID="TBPaterno" MaxLength="9" for="paterno"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xxl-3 col-xl-3 col-lg-3 col-md-3 col-sm-12">
                        <div class="input-group my-3">
                            <label for="materno">Apellido materno</label>
                            <asp:TextBox runat="server" ID="TBMaterno" MaxLength="9" for="materno"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xxl-3 col-xl-3 col-lg-3 col-md-3 col-sm-12">
                        <div class="input-group my-3">
                            <label for="foto">Url de Foto del usuario</label>
                            <asp:TextBox runat="server" ID="TBUrl" MaxLength="9" for="foto"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xxl-3 col-xl-3 col-lg-3 col-md-3 col-sm-12">
                        <div class="input-group-prepend">
                            <span class="font-weight-bold mb-2">&Aacute;rea o Departamento <span class="text-danger">*</span></span>
                        </div>
                        <span class="custom-dropdown">
                            <asp:DropDownList runat="server" ID="DDLArea">
                                <asp:ListItem Selected="True" Text="ACTIVO" Value="1"></asp:ListItem>
                                <asp:ListItem Text="INACTIVO" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </span>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xxl-3 col-xl-3 col-lg-3 col-md-3 col-sm-12">
                        <div class="input-group-prepend">
                            <span class="font-weight-bold mb-2">G&eacute;nero <span class="text-danger">*</span></span>
                        </div>
                        <span class="custom-dropdown">
                            <asp:DropDownList runat="server" ID="DDLGenero">
                                <asp:ListItem Selected="True" Text="Masculino" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Femenino" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </span>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xxl-3 col-xl-3 col-lg-3 col-md-3 col-sm-12">
                        <div class="input-group-prepend">
                            <span class="font-weight-bold mb-2">Estado del Registro <span class="text-danger">*</span></span>
                        </div>
                        <span class="custom-dropdown">
                            <asp:DropDownList runat="server" ID="DDLEstaActivo">
                                <asp:ListItem Selected="True" Text="ACTIVO" Value="1"></asp:ListItem>
                                <asp:ListItem Text="INACTIVO" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </span>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xxl-3 col-xl-3 col-lg-3 col-md-3 col-sm-12">
                        <div id="Alerta1" runat="server" visible="false" class="alert alert-danger alert-dismissible fade show" role="alert">
                            <span class="font-weight-bold" runat="server" id="AlertaTextoNegritas1"></span>&nbsp;<span runat="server" id="AlertaTexto1"></span>
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                    </div>
                </div>
            </asp:View>
            <asp:View runat="server" ID="ViewConsultar">
                <div class="row">
                    <div class="col-12">
                        <div class="card">
                            <div class="card-header">
                                <h3>Lista de Usuarios <span class="badge badge-secondary"><%=HttpContext.Current.Session["ConteoAdministradores"] ?? "0" %></span></h3>
                            </div>
                            <div class="card-body">
                                <asp:GridView runat="server" Visible="true" ID="GVMovimientos" AutoGenerateColumns="false" CssClass="table table-bordered" Width="100%">
                                    <HeaderStyle CssClass="thead-dark" />
                                    <RowStyle CssClass="table-light" />
                                    <Columns>
                                        <asp:CommandField ButtonType="Link" ShowSelectButton="true" HeaderText="Detalles" />
                                        <asp:BoundField DataField="IdUsuario" HeaderText="ID Usuario" />
                                        <asp:BoundField DataField="NumeroControl" HeaderText="Número de Control" />
                                        <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
                                        <asp:BoundField DataField="Paterno" HeaderText="Paterno" />
                                        <asp:BoundField DataField="Materno" HeaderText="Materno" />
                                        <asp:BoundField DataField="Genero" HeaderText="Genero" />
                                        <asp:BoundField DataField="Area" HeaderText="Area / Departamento" />
                                        <asp:BoundField DataField="IdServicio" HeaderText="ID de Servicio" />
                                        <asp:BoundField DataField="Servicio" HeaderText="Servicio" />
                                        <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de Creación" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:View>
        </asp:MultiView>
    </div>
    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/v/bs4/dt-1.10.20/rg-1.1.1/rr-1.2.6/datatables.min.js"></script>
</asp:Content>
