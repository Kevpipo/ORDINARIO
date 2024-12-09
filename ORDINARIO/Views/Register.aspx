<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ORDINARIO.Views.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f9;
            margin: 0;
            padding: 0;
        }

        .register-container {
            width: 400px;
            margin: 50px auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 8px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
        }

        h2 {
            text-align: center;
            color: #333;
            margin-bottom: 20px;
        }

        label {
            font-size: 14px;
            color: #555;
            margin-bottom: 5px;
            display: block;
        }

        .input-field {
            width: 100%;
            padding: 10px;
            font-size: 14px;
            margin-bottom: 20px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }

        .input-field:focus {
            border-color: #4CAF50;
            outline: none;
        }

        .btn-submit {
            background-color: #4CAF50;
            color: white;
            padding: 12px 20px;
            font-size: 16px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            width: 100%;
        }

        .btn-submit:hover {
            background-color: #45a049;
        }

        .error-message {
            color: red;
            font-size: 14px;
            text-align: center;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="register-container">
            <h2>Registro</h2>

            <label for="username">Username:</label>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="input-field"></asp:TextBox>

            <label for="email">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="input-field"></asp:TextBox>

            <label for="password">Password:</label>
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="input-field"></asp:TextBox>

            <asp:Button ID="btnRegister" Text="Register" OnClick="btnRegister_Click" runat="server" CssClass="btn-submit" />
            
            <!-- Aquí puedes añadir un mensaje de error si es necesario -->
            <asp:Label ID="lblError" runat="server" CssClass="error-message"></asp:Label>
        </div>
    </form>
</body>
</html>
