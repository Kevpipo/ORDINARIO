<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ORDINARIO.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gestión de Comidas</title>
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
            <h1>Gestión de Comidas</h1>

            <!-- Tabla para mostrar las comidas -->
            <asp:GridView ID="gvComidas" runat="server" AutoGenerateColumns="true" CssClass="table">
            </asp:GridView>

            <hr class="hr-line" />

            <!-- Formulario para agregar comida -->
            <h2>Agregar Comida</h2>
            <label for="txtComidaNombre">Nombre:</label>
            <asp:TextBox ID="txtComidaNombre" runat="server" MaxLength="50" CssClass="input-field"></asp:TextBox>
            <br />
            <label for="txtCategoria">Categoria:</label>
            <asp:TextBox ID="txtCategoria" runat="server" MaxLength="50" CssClass="input-field"></asp:TextBox>
            <br />
            <label for="txtIngredientes">Ingredientes:</label>
            <asp:TextBox ID="txtIngredientes" runat="server" MaxLength="50" CssClass="input-field"></asp:TextBox>
            <br />
            <label for="txtCalorias">Calorias:</label>
            <asp:TextBox ID="txtCalorias" runat="server" MaxLength="50" CssClass="input-field"></asp:TextBox>
            <br />
            <label for="txtTamaño">Tamaño:</label>
            <asp:TextBox ID="txtTamaño" runat="server" MaxLength="50" CssClass="input-field"></asp:TextBox>
            <br />
            <label for="txtCantidad_Disponible">Cantidad Disponible:</label>
            <asp:TextBox ID="txtCantidad_Disponible" runat="server" MaxLength="50" CssClass="input-field"></asp:TextBox>
            <br />
            <label for="txtComidaPrecio">Precio:</label>
            <asp:TextBox ID="txtComidaPrecio" runat="server" CssClass="input-field"></asp:TextBox>
            <br />
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CssClass="button" />

            <hr class="hr-line" />

            <!-- Formulario para actualizar comida -->
            <h2>Actualizar Comida</h2>
            <label for="txtComidaActualizarId">ID:</label>
            <asp:TextBox ID="txtComidaActualizarId" runat="server" CssClass="input-field"></asp:TextBox>
            <br />
            <label for="txtComidaNuevoNombre">Nuevo Nombre:</label>
            <asp:TextBox ID="txtComidaNuevoNombre" runat="server" MaxLength="50" CssClass="input-field"></asp:TextBox>
            <br />
            <label for="txtComidaNuevoPrecio">Nuevo Precio:</label>
            <asp:TextBox ID="txtComidaNuevoPrecio" runat="server" CssClass="input-field"></asp:TextBox>
            <br />
            <label for="txtCategoriaNuevo">Nuevo Categoria:</label>
            <asp:TextBox ID="txtCategoriaNuevo" runat="server" MaxLength="50" CssClass="input-field"></asp:TextBox>
            <br />
            <label for="txtIngredientesNuevo">Nuevo Ingredientes:</label>
            <asp:TextBox ID="txtIngredientesNuevo" runat="server" MaxLength="50" CssClass="input-field"></asp:TextBox>
            <br />
            <label for="txtCaloriasNuevo">Nuevo Calorias:</label>
            <asp:TextBox ID="txtCaloriasNuevo" runat="server" MaxLength="50" CssClass="input-field"></asp:TextBox>
            <br />
            <label for="txtTamañoNuevo">Nuevo Tamaño:</label>
            <asp:TextBox ID="txtTamañoNuevo" runat="server" MaxLength="50" CssClass="input-field"></asp:TextBox>
            <br />
            <label for="txtCantidad_DisponibleNuevo">Nuevo Cantidad Disponible:</label>
            <asp:TextBox ID="txtCantidad_DisponibleNuevo" runat="server" MaxLength="50" CssClass="input-field"></asp:TextBox>
            <br />
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" CssClass="button" />

            <hr class="hr-line" />

            <!-- Formulario para eliminar comida -->
            <h2>Eliminar Comida</h2>
            <label for="txtComidaEliminarId">ID:</label>
            <asp:TextBox ID="txtComidaEliminarId" runat="server" CssClass="input-field"></asp:TextBox>
            <br />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CssClass="button" />
        </div>
    </form>
</body>
</html>
