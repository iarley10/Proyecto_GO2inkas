<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="Proyecto_GO2inkas.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Gestión de Clientes - GO2inkas</title>
    <style>
        body { font-family: Arial; margin: 20px; background-color: #f2f2f2; }
        .form-container { margin-bottom: 20px; background-color: #ffffff; padding: 20px; border-radius: 8px; width: 600px; }
        .form-container h2 { margin-bottom: 10px; }
        label { display: block; margin-top: 10px; }
        input[type=text], input[type=email], input[type=date] {
            width: 100%; padding: 8px; border: 1px solid #ccc; border-radius: 4px;
        }
        .btn { margin-top: 10px; padding: 10px 20px; border: none; border-radius: 4px; }
        .btn-save { background-color: #28a745; color: white; }
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

        <!-- FORMULARIO DE CLIENTE -->
        <div class="form-container">
            <h2>Formulario de Cliente</h2>
            <asp:HiddenField ID="hfCodigoCliente" runat="server" />
            <label>Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" />
            <label>Apellido</label>
            <asp:TextBox ID="txtApellido" runat="server" />
            <label>Email</label>
            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" />
            <label>Teléfono</label>
            <asp:TextBox ID="txtTelefono" runat="server" />
            <label>RUC</label>
            <asp:TextBox ID="txtRuc" runat="server" />
            <label>Fecha de Nacimiento</label>
            <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date" />
            <br />
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-save" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-clear" OnClick="btnLimpiar_Click" />
        </div>

        <!-- TABLA DE CLIENTES -->
        <div class="grid-container">
            <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" OnRowCommand="gvClientes_RowCommand" DataKeyNames="CODIGOCLIENTE">
                <Columns>
                    <asp:BoundField DataField="CODIGOCLIENTE" HeaderText="Código" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
                    <asp:BoundField DataField="n_de_Ruc" HeaderText="RUC" />
                    <asp:BoundField DataField="fecha_de_nacimiento" HeaderText="Nacimiento" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:ButtonField Text="Editar" CommandName="Editar" ButtonType="Button" />
                    <asp:ButtonField Text="Eliminar" CommandName="Eliminar" ButtonType="Button" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>

