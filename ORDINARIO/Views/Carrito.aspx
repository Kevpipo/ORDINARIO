<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="ORDINARIO.Carrito" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Carrito de Compras</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f9;
        }

        h1, h2 {
            color: #333;
        }

        .container {
            width: 80%;
            margin: 0 auto;
            padding: 20px;
        }

        .table {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
            background-color: #fff;
            border-radius: 8px;
            overflow: hidden;
        }

        .table th, .table td {
            border: 1px solid #ddd;
            padding: 10px;
            text-align: center;
        }

        .table th {
            background-color: #f2f2f2;
        }

        .table td {
            background-color: #fafafa;
        }

        .total-container {
            font-size: 20px;
            font-weight: bold;
            margin-top: 20px;
            text-align: right;
        }

        .input-field {
            padding: 8px;
            font-size: 14px;
            width: 300px;
            margin: 10px 0;
            border: 1px solid #ccc;
            border-radius: 4px;
            display: inline-block;
        }

        .button {
            background-color: #4CAF50;
            color: white;
            padding: 10px 20px;
            font-size: 16px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            text-align: center;
            display: inline-block;
            margin: 10px 5px;
        }

        .button:hover {
            background-color: #45a049;
        }

        .hr-line {
            margin: 20px 0;
            border: 0;
            border-top: 1px solid #ddd;
        }

        .form-container {
            margin-top: 30px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <!-- Botón para redirigir a Login.aspx -->
<asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="button" OnClick="btnLogin_Click" />
            <h1>Carrito de Comida Rápida</h1>
            

            

            <!-- Tabla para mostrar las comidas disponibles -->
            <asp:GridView ID="gvComidas" runat="server" AutoGenerateColumns="false" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="ID_Comida" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="Cantidad_Disponible" HeaderText="Cantidad Disponible" />
                    <asp:TemplateField HeaderText="Cantidad a Comprar">
                        <ItemTemplate>
                            <asp:TextBox ID="txtCantidad" runat="server" Width="50px" Text="1"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnAgregarCarrito" runat="server" Text="Agregar al Carrito" OnClick="btnAgregarCarrito_Click" CommandArgument='<%# Eval("ID_Comida") %>' CssClass="button" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <hr class="hr-line" />


            <!-- Mostrar productos en el carrito -->
            <h2>Carrito</h2>
            <asp:GridView ID="gvCarrito" runat="server" AutoGenerateColumns="false" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="ID_Comida" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="Cantidad_Disponible" HeaderText="Cantidad Disponible" />
                </Columns>
            </asp:GridView>

            <!-- Total a pagar -->
            <div class="total-container">
                Total: <asp:Label ID="lblTotal" runat="server" Text="$0.00"></asp:Label>
            </div>

            <asp:Button ID="btnVaciarCarrito" runat="server" Text="Vaciar Carrito" OnClick="btnVaciarCarrito_Click" CssClass="button" />

            <h2>Pagar</h2>
            <label for="txtCorreo">Correo Electrónico:</label>
            <asp:TextBox ID="txtCorreo" runat="server" CssClass="input-field" Width="300px"></asp:TextBox>
            <br /><br />
            
            <asp:Button ID="btnPagar" runat="server" Text="Pagar" OnClick="btnPagar_Click" CssClass="button" />


        </div>
    </form>
</body>
</html>
