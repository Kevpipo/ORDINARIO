using ORDINARIO.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ORDINARIO
{
    public partial class Login : System.Web.UI.Page
    {
        ControllerUsuario controller = new ControllerUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // Método que maneja el evento de login
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Verificar el usuario y la contraseña
            bool loginExitoso = controller.VerificarUsuario(username, password);

            if (loginExitoso)
            {
                // Redirigir a una página segura si el login es exitoso
                Session["username"] = username;
                Response.Redirect("Index.aspx");
            }
            else
            {
                // Mostrar mensaje de error si el login falla
                Response.Write("<script>alert('Usuario o contraseña incorrectos');</script>");
            }
        }
    }
}