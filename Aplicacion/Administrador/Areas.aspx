<%@ Page Title="BTec - Áreas" Language="C#" MasterPageFile="~/Administrador/Second.Master" AutoEventWireup="true" CodeBehind="Areas.aspx.cs" Inherits="Aplicacion.Administrador.Areas" Culture="es-MX" UICulture="es-MX" %>

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
                <h2>Usuarios</h2>
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
                            <label for="area">&Aacute;rea</label>
                            <asp:TextBox runat="server" ID="TBArea" MaxLength="9" for="area"></asp:TextBox>
                        </div>
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
                                        <asp:BoundField DataField="IdArea" HeaderText="ID Área" />
                                        <asp:BoundField DataField="Area" HeaderText="Área" />
                                        <asp:BoundField DataField="EstaActivo" HeaderText="Esta Activo" />
                                        <asp:BoundField DataField="UsuarioCreacion" HeaderText="Usuario de Creación" />
                                        <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de Creación" />
                                        <asp:BoundField DataField="UsuarioActualizacion" HeaderText="Usuario de Actualización" />
                                        <asp:BoundField DataField="FechaActualizacion" HeaderText="Fecha de Actualización" />
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
        var group = document.getElementsByClassName('input-group');
        for (var i = 0; i < group.length; i++) {
            group[i].onclick = addLabelActiveClass;// group listenere ends
            var input = group[i].getElementsByTagName('input')[0];
            input.onblur = removeLabelActiveClass;

            input.onfocus = callLabelActiveClass;


        }//end for loop
        function callLabelActiveClass() {
            addLabelActiveClass.call(this.parentNode);
        }
        function addLabelActiveClass() {
            var label = this.getElementsByTagName('label')[0];
            var input = this.getElementsByTagName('input')[0];
            if (!label.classList.contains('active') && !input.disabled) {
                label.classList.add('active');
                input.focus();
            }
        }

        function removeLabelActiveClass() {
            //only move label back if input is empty

            if (this.value === "") {
                var label = this.parentNode.children[0];
                if (label.classList.contains('active')) {
                    label.classList.remove('active');
                }
            }
        }

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
                    url: "../Glossary.aspx/LlenarTablaAreas",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    cache: true,
                    data: function (json) {
                        return JSON.stringify(json);
                    },
                    dataSrc: "d.data"
                },
                rowId: 'IdArea',
                select: "single",
                columns: [
                    {
                        class: "details-control text-center",
                        orderable: false,
                        data: null,
                        defaultContent: "<a href='#'><b>Seleccionar</b></a>"
                    },
                    {
                        data: "IdArea",
                        class: "text-center"
                    },
                    {
                        data: "Area",
                        class: "text-center"
                    },
                    {
                        data: "EstaActivo",
                        class: "text-center"
                    },
                    {
                        data: "FechaCreacion",
                        class: "text-center"
                    },
                    {
                        data: "UsuarioCreacion",
                        class: "text-center"
                    },
                    {
                        data: "FechaActualizacion",
                        class: "text-center"
                    },
                    {
                        data: "UsuarioActualizacion",
                        class: "text-center"
                    },
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