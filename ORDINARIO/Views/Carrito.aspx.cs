using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions; // Para validación del correo

namespace ORDINARIO
{
    public partial class Carrito : System.Web.UI.Page
    {
        private ComidaController Controller = new ComidaController();

        private List<Comida> CarritoItems
        {
            get
            {
                if (Session["Carrito"] == null)
                    Session["Carrito"] = new List<Comida>();
                return (List<Comida>)Session["Carrito"];
            }
            set { Session["Carrito"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarComidas();
                MostrarCarrito();
            }
        }

        private void MostrarComidas()
        {
            gvComidas.DataSource = Controller.ObtenerComida();
            gvComidas.DataBind();
        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            int idComida = Convert.ToInt32(btn.CommandArgument);
            string nombre = row.Cells[1].Text;
            decimal precio = Convert.ToDecimal(row.Cells[2].Text.Trim('$'));

            int cantidadDisponible = Convert.ToInt32(row.Cells[3].Text);

            // Validar cantidad ingresada
            TextBox txtCantidad = (TextBox)row.FindControl("txtCantidad");
            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                Response.Write("<script>alert('Por favor, ingresa una cantidad válida mayor a cero.');</script>");
                return;
            }
            // Validar que la cantidad solicitada no exceda la cantidad disponible
            if (cantidad > cantidadDisponible)
            {
                Response.Write("<script>alert('No puedes agregar más unidades de las disponibles en stock.');</script>");
                return;
            }
            // Actualizar la cantidad disponible en el GridView
            cantidadDisponible -= cantidad;
            row.Cells[3].Text = cantidadDisponible.ToString();

            // Agregar la comida al carrito con la cantidad especificada
            Comida item = new Comida(idComida, nombre, "", "", precio, "", "", cantidad);
            CarritoItems.Add(item);

            MostrarCarrito();
        }

        private void MostrarCarrito()
        {
            gvCarrito.DataSource = CarritoItems;
            gvCarrito.DataBind();
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (var item in CarritoItems)
            {
                total += item.Precio * item.Cantidad_Disponible;
            }
            lblTotal.Text = total.ToString("C");
        }

        protected void btnVaciarCarrito_Click(object sender, EventArgs e)
        {
            CarritoItems = new List<Comida>();
            MostrarCarrito();
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            string correoDestino = txtCorreo.Text.Trim();

            // Validar que el carrito no esté vacío
            if (CarritoItems.Count == 0)
            {
                Response.Write("<script>alert('El carrito está vacío. Agrega productos antes de pagar.');</script>");
                return;
            }

            // Validar correo electrónico
            if (string.IsNullOrEmpty(correoDestino) || !EsCorreoValido(correoDestino))
            {
                Response.Write("<script>alert('Por favor, ingresa un correo electrónico válido.');</script>");
                return;
            }

            // Crear el PDF en un MemoryStream
            MemoryStream ms = new MemoryStream();
            byte[] pdfBytes;

            using (PdfWriter writer = new PdfWriter(ms))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);

                    // Título del PDF
                    document.Add(new Paragraph("Detalles del Pedido").SetFontSize(18));

                    // Agregar los detalles del carrito
                    foreach (var item in CarritoItems)
                    {
                        document.Add(new Paragraph($"Producto: {item.Nombre} | Precio: {item.Precio:C} | Cantidad: {item.Cantidad_Disponible} | Total: {item.Precio * item.Cantidad_Disponible:C}"));
                    }

                    // Agregar el total a pagar
                    document.Add(new Paragraph($"Total a pagar: {lblTotal.Text}").SetFontSize(14));
                }

                pdfBytes = ms.ToArray();
            }

            using (MemoryStream pdfStream = new MemoryStream(pdfBytes))
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient smtpServer = new SmtpClient("smtp.office365.com");

                    mail.From = new MailAddress("112233@alumnouninter.mx");
                    mail.To.Add(correoDestino);
                    mail.Subject = "Detalles de tu compra";
                    mail.Body = "Adjunto te enviamos los detalles de tu compra.";

                    mail.Attachments.Add(new Attachment(pdfStream, "DetallesCompra.pdf", "application/pdf"));

                    smtpServer.Port = 587;
                    smtpServer.Credentials = new NetworkCredential("112233@alumnouninter.mx", "916KEVniv");
                    smtpServer.EnableSsl = true;

                    smtpServer.Send(mail);
                    Response.Write("<script>alert('Correo con PDF enviado exitosamente.');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error al enviar el correo: " + ex.Message + "');</script>");
                }
            }
        }

        // Método para validar el formato del correo electrónico
        private bool EsCorreoValido(string correo)
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(correo, patron);
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        

    }
}
