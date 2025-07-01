<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cotizacion.aspx.cs" Inherits="Proyecto_GO2inkas.Cotizacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Gestión de Cotizaciones - GO2inkas</title>
    <style>
        body { font-family: Arial; margin: 20px; background-color: #f2f2f2; }
        .form-container { margin-bottom: 20px; background-color: #ffffff; padding: 20px; border-radius: 10px; width: 700px; }
        label { display: block; margin-top: 10px; }
        input, select { width: 100%; padding: 8px; border-radius: 5px; border: 1px solid #ccc; }
        .btn { margin-top: 15px; padding: 10px 20px; border: none; border-radius: 5px; }
        .btn-save { background-color: #007bff; color: white; }
        .btn-clear { background-color: #6c757d; color: white; margin-left: 10px; }
        .grid-container { margin-top: 20px; }
        .menu-bar {
            background-color: #333;
            padding: 10px 20px;
            margin-bottom: 20px;
            border-radius: 5px;
        }
        .menu-bar a {
            color: white;
            margin-right: 20px;
            text-decoration: none;
            font-weight: bold;
            font-size: 16px;
        }
        .menu-bar a:hover {
            color: #ffc107;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
        <!-- MENÚ DE NAVEGACIÓN -->
        <div class="menu-bar">
            <a href="Cliente.aspx">Clientes</a>
            <a href="Cotizacion.aspx">Cotizaciones</a>
        </div>

        <!-- FORMULARIO DE COTIZACIÓN -->
        <div class="form-container">
            <h2>Formulario de Cotización</h2>
            <asp:HiddenField ID="hfNumeroCotizacion" runat="server" />

            <label>Cliente</label>
            <asp:DropDownList ID="ddlClientes" runat="server" />

            <label>Nombre del Cliente</label>
            <asp:TextBox ID="txtNombreCliente" runat="server" />

            <label>Identificación</label>
            <asp:TextBox ID="txtIdentificacion" runat="server" />

            <label>Tipo de Tour</label>
            <asp:TextBox ID="txtTipoTour" runat="server" />

            <label>Cantidad de Pasajeros</label>
            <asp:TextBox ID="txtCantidadPasajeros" runat="server" />

            <label>Agregados</label>
            <asp:TextBox ID="txtAgregados" runat="server" />

            <label>Costo</label>
            <asp:TextBox ID="txtCosto" runat="server" />

            <label>Fecha de Tour</label>
            <asp:TextBox ID="txtFechaTour" runat="server" TextMode="Date" />

            <label>Tipo de Bicicleta</label>
            <asp:TextBox ID="txtTipoBicicleta" runat="server" />

            <label>Fecha de Cotización</label>
            <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" />

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-save" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-clear" OnClick="btnLimpiar_Click" />
        </div>

        <!-- TABLA DE COTIZACIONES -->
        <div class="grid-container">
            <asp:GridView ID="gvCotizaciones" runat="server" AutoGenerateColumns="False" DataKeyNames="NUMEROCOTIZACION" OnRowCommand="gvCotizaciones_RowCommand">
                <Columns>
                    <asp:BoundField DataField="NUMEROCOTIZACION" HeaderText="N° Cotización" />
                    <asp:BoundField DataField="nombrecliente" HeaderText="Nombre Cliente" />
                    <asp:BoundField DataField="tipo_de_tour" HeaderText="Tour" />
                    <asp:BoundField DataField="costo" HeaderText="Costo" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="fecha_de_tour" HeaderText="Fecha Tour" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:ButtonField Text="Editar" CommandName="Editar" ButtonType="Button" />
                    <asp:ButtonField Text="Eliminar" CommandName="Eliminar" ButtonType="Button" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
