using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ORDINARIO
{
    public partial class Index : System.Web.UI.Page
    {
        private ComidaController comidaController = new ComidaController();

        protected void Page_Init(object sender, EventArgs e)
        {
            CargarComidas();
        }

        private void CargarComidas()
        {
            List<Comida> listaComidas = comidaController.ObtenerComida();
            gvComidas.DataSource = listaComidas;
            gvComidas.DataBind();
        }

        // Evento para agregar una comida
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtComidaNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtCategoria.Text) ||
                    string.IsNullOrWhiteSpace(txtIngredientes.Text) ||
                    string.IsNullOrWhiteSpace(txtComidaPrecio.Text) ||
                    string.IsNullOrWhiteSpace(txtCalorias.Text) ||
                    string.IsNullOrWhiteSpace(txtTamaño.Text) ||
                    string.IsNullOrWhiteSpace(txtCantidad_Disponible.Text))
                {
                    Response.Write("<script>alert('Todos los campos son obligatorios.');</script>");
                    return;
                }

                if (!decimal.TryParse(txtComidaPrecio.Text, out decimal precio) || precio <= 0)
                {
                    Response.Write("<script>alert('El precio debe ser un número positivo.');</script>");
                    return;
                }

                if (!int.TryParse(txtCantidad_Disponible.Text, out int cantidadDisponible) || cantidadDisponible < 0)
                {
                    Response.Write("<script>alert('La cantidad disponible debe ser un número entero positivo.');</script>");
                    return;
                }

                string nombre = txtComidaNombre.Text;
                string categoria = txtCategoria.Text;
                string ingredientes = txtIngredientes.Text;
                string calorias = txtCalorias.Text;
                string tamaño = txtTamaño.Text;

                comidaController.AgregarComida(nombre, categoria, ingredientes, precio, calorias, tamaño, cantidadDisponible);
                CargarComidas();
                LimpiarCamposAgregar();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error al agregar la comida: {ex.Message}');</script>");
            }
        }

        private void LimpiarCamposAgregar()
        {
            txtComidaNombre.Text = "";
            txtCategoria.Text = "";
            txtIngredientes.Text = "";
            txtComidaPrecio.Text = "";
            txtCalorias.Text = "";
            txtTamaño.Text = "";
            txtCantidad_Disponible.Text = "";
        }

        // Evento para actualizar una comida
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtComidaActualizarId.Text) ||
                    string.IsNullOrWhiteSpace(txtComidaNuevoNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtCategoriaNuevo.Text) ||
                    string.IsNullOrWhiteSpace(txtIngredientesNuevo.Text) ||
                    string.IsNullOrWhiteSpace(txtComidaNuevoPrecio.Text) ||
                    string.IsNullOrWhiteSpace(txtCaloriasNuevo.Text) ||
                    string.IsNullOrWhiteSpace(txtTamañoNuevo.Text) ||
                    string.IsNullOrWhiteSpace(txtCantidad_DisponibleNuevo.Text))
                {
                    Response.Write("<script>alert('Todos los campos son obligatorios para actualizar.');</script>");
                    return;
                }

                if (!int.TryParse(txtComidaActualizarId.Text, out int idComida))
                {
                    Response.Write("<script>alert('El ID debe ser un número entero válido.');</script>");
                    return;
                }

                if (!decimal.TryParse(txtComidaNuevoPrecio.Text, out decimal nuevoPrecio) || nuevoPrecio <= 0)
                {
                    Response.Write("<script>alert('El nuevo precio debe ser un número positivo.');</script>");
                    return;
                }

                if (!int.TryParse(txtCantidad_DisponibleNuevo.Text, out int nuevaCantidad) || nuevaCantidad < 0)
                {
                    Response.Write("<script>alert('La cantidad disponible debe ser un número entero positivo.');</script>");
                    return;
                }

                string nuevoNombre = txtComidaNuevoNombre.Text;
                string nuevaCategoria = txtCategoriaNuevo.Text;
                string nuevosIngredientes = txtIngredientesNuevo.Text;
                string nuevasCalorias = txtCaloriasNuevo.Text;
                string nuevoTamaño = txtTamañoNuevo.Text;

                comidaController.ActualizarComida(idComida, nuevoNombre, nuevaCategoria, nuevosIngredientes, nuevoPrecio, nuevasCalorias, nuevoTamaño, nuevaCantidad);
                CargarComidas();
                LimpiarCamposActualizar();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error al actualizar la comida: {ex.Message}');</script>");
            }
        }

        private void LimpiarCamposActualizar()
        {
            txtComidaActualizarId.Text = "";
            txtComidaNuevoNombre.Text = "";
            txtCategoriaNuevo.Text = "";
            txtIngredientesNuevo.Text = "";
            txtComidaNuevoPrecio.Text = "";
            txtCaloriasNuevo.Text = "";
            txtTamañoNuevo.Text = "";
            txtCantidad_DisponibleNuevo.Text = "";
        }

        // Evento para eliminar una comida
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtComidaEliminarId.Text))
                {
                    Response.Write("<script>alert('Debe ingresar un ID para eliminar.');</script>");
                    return;
                }

                if (!int.TryParse(txtComidaEliminarId.Text, out int idComida))
                {
                    Response.Write("<script>alert('El ID debe ser un número entero válido.');</script>");
                    return;
                }

                comidaController.EliminarComida(idComida);
                CargarComidas();
                txtComidaEliminarId.Text = "";
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error al eliminar la comida: {ex.Message}');</script>");
            }
        }
    }

}