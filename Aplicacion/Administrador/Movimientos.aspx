<%@ Page Title="BTec - Total de Movimientos" Language="C#" MasterPageFile="~/Administrador/Second.Master" AutoEventWireup="true" CodeBehind="Movimientos.aspx.cs" Inherits="Aplicacion.Administrador.PanelGeneral" Culture="es-MX" UICulture="es-MX" %>

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
        <div class="row pl-5">
            <div class="col-5">
                <h2>Movimientos</h2>
                <small class="form-text text-muted">Los campos con asteriscos (<span style="color: red;">*</span>), son campos obligatorios.</small>
                <br />
            </div>
        </div>
        <asp:MultiView runat="server" ID="MultiView1">
            <asp:View runat="server" ID="ViewNuevo">
                <div class="row pl-5">
                    <div class="col-5">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend"><span class="input-group-text">C&oacute;digo</span></div>
                            <asp:TextBox runat="server" ID="TBcodigo" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row pl-5">
                    <div class="col-5">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend"><span class="input-group-text">N&uacute;mero de Control</span></div>
                            <asp:TextBox runat="server" ID="TBNumeroControl" MaxLength="9" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row pl-5">
                    <div class="col-5">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend"><span class="input-group-text">Servicio<span style="color: red;">*</span></span></div>
                            <asp:DropDownList runat="server" ID="DDLServicio" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row pl-5">
                    <div class="col-5">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend"><span class="input-group-text">Estado del Registro&emsp;<span style="color: red;">*</span></span></div>
                            <asp:DropDownList runat="server" ID="DDLEstaActivo" CssClass="form-control">
                                <asp:ListItem Selected="True" Text="ACTIVO" Value="1"></asp:ListItem>
                                <asp:ListItem Text="INACTIVO" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row pl-5">
                    <div class="col-5">
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
                                <h3>Tabla de Movimientos <span class="badge badge-secondary"><%=HttpContext.Current.Session["ConteoMovimientos"] ?? "0" %></span></h3>
                            </div>
                            <div class="card-body">
                                <h5 class="card-title">Control de Movimientos Realizados</h5>
                                <br />
                                <asp:GridView runat="server" Visible="true" ID="GVMovimientos" AutoGenerateColumns="false" CssClass="table table-bordered" Width="100%">
                                    <HeaderStyle CssClass="thead-dark" />
                                    <RowStyle CssClass="table-light" />
                                    <Columns>
                                        <asp:CommandField ButtonType="Link" ShowSelectButton="true" HeaderText="Detalles" />
                                        <asp:BoundField DataField="IdMovimiento" HeaderText="Movimiento" />
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
    <script type="text/javascript">
        window.setTimeout(function () {
            $("#<%=Alerta1.ClientID%>").fadeTo(500, 0).slideUp(500, function () {
                $(this).remove();
            });
        }, 5000);

        function format(Row) {
            return '';
        }
        $(document).ready(function () {
            var dt = $('#<%=GVMovimientos.ClientID%>').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                destroy: true,
                autoWidth: false,
                language: {
                    url: "https://cdn.datatables.net/plug-ins/1.10.20/i18n/Spanish.json",
                    select: {
                        rows: {
                            _: " <b>%d</b> Filas Seleccionadas",
                            1: " <b>Una</b> Fila Seleccionada"
                        }
                    }
                },
                responsive: false,
                autoFill: true,
                select: true,
                ajax: {
                    type: "POST",
                    url: "../Glossary.aspx/LlenarTabla",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    cache: true,
                    data: function (json) {
                        return JSON.stringify(json);
                    },
                    dataSrc: "d.data"
                },
                rowId: 'IdMovimiento',
                select: "single",
                columns: [
                    {
                        class: "details-control text-center",
                        orderable: false,
                        data: null,
                        defaultContent: "<a href='#'><b>Seleccionar</b></a>"
                    },
                    {
                        data: "IdMovimiento",
                        class: "text-center"
                    },
                    {
                        data: "NumeroControl",
                        class: "text-center"
                    },
                    {
                        data: "Nombres",
                        class: "text-center"
                    },
                    {
                        data: "Paterno",
                        class: "text-center"
                    },
                    {
                        data: "Materno",
                        class: "text-center"
                    },
                    {
                        data: "Genero",
                        class: "text-center"
                    },
                    {
                        data: "Area",
                        class: "text-center"
                    },
                    {
                        data: "IdServicio",
                        class: "text-center"
                    },
                    {
                        data: "Servicio",
                        class: "text-center"
                    },
                    {
                        data: "FechaCreacion",
                        class: "text-center"
                    }
                ]
            });

            // Array to track the ids of the details displayed rows
            var detailRows = [];

            $('#<%=GVMovimientos.ClientID%> tbody').on('click', 'tr td.details-control', function () {
                var tr = $(this).closest('tr');
                var row = dt.row(tr);
                var idx = $.inArray(tr.attr('id'), detailRows);

                if (row.child.isShown()) {
                    tr.removeClass('details');
                    row.child.hide();

                    // Remove from the 'open' array
                    detailRows.splice(idx, 1);
                }
                else {
                    tr.addClass('details');
                    row.child(format(row.data())).show();

                    // Add to the 'open' array
                    if (idx === -1) {
                        detailRows.push(tr.attr('id'));
                    }
                }
            });

            // On each draw, loop over the `detailRows` array and show any child rows
            dt.on('draw', function () {
                $.each(detailRows, function (i, id) {
                    $('#' + id + ' td.details-control').trigger('click');
                });
            });
        });
    </script>
</asp:Content>
