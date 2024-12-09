using ORDINARIO.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ORDINARIO.Views
{
    public partial class Register : System.Web.UI.Page
    {
        ControllerUsuario controller = new ControllerUsuario();
        AESCryptography aesCrypto = new AESCryptography();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string email = txtEmail.Text;
                string password = txtPassword.Text;

                // Validaciones básicas
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    Response.Write("<script>alert('Por favor, complete todos los campos.');</script>");
                    return;
                }

                // Encriptar la contraseña
                string passwordEncrypted = aesCrypto.Encrypt(password);

                // Llamar al controlador para registrar el usuario
                bool registroExitoso = controller.RegistrarUsuario(username, email, passwordEncrypted);

                if (registroExitoso)
                {
                    Response.Write("<script>alert('Usuario registrado exitosamente.'); window.location='Login.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Error: El nombre de usuario ya existe.');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error al registrar el usuario: {ex.Message}');</script>");
            }
        }
    }
}