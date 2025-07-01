using Proyecto_GO2inkas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_GO2inkas
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Go2inkasEntities db = new Go2inkasEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
            }
        }

        private void CargarClientes()
        {
            gvClientes.DataSource = db.Cliente.ToList();
            gvClientes.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int codigo = string.IsNullOrEmpty(hfCodigoCliente.Value) ? 0 : int.Parse(hfCodigoCliente.Value);
            if (codigo == 0)
            {
                // Nuevo
                Cliente nuevo = new Cliente()
                {
                    nombre = txtNombre.Text,
                    apellido = txtApellido.Text,
                    email = txtEmail.Text,
                    telefono = txtTelefono.Text,
                    n_de_Ruc = txtRuc.Text,
                    fecha_de_nacimiento = string.IsNullOrEmpty(txtFechaNacimiento.Text) ? (DateTime?)null : DateTime.Parse(txtFechaNacimiento.Text)
                };
                db.Cliente.Add(nuevo);
            }
            else
            {
                // Actualizar
                var cliente = db.Cliente.Find(codigo);
                if (cliente != null)
                {
                    cliente.nombre = txtNombre.Text;
                    cliente.apellido = txtApellido.Text;
                    cliente.email = txtEmail.Text;
                    cliente.telefono = txtTelefono.Text;
                    cliente.n_de_Ruc = txtRuc.Text;
                    cliente.fecha_de_nacimiento = string.IsNullOrEmpty(txtFechaNacimiento.Text) ? (DateTime?)null : DateTime.Parse(txtFechaNacimiento.Text);
                }
            }

            db.SaveChanges();
            LimpiarFormulario();
            CargarClientes();
        }

        protected void gvClientes_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int codigoCliente = Convert.ToInt32(gvClientes.DataKeys[index].Value);

            if (e.CommandName == "Editar")
            {
                var cliente = db.Cliente.Find(codigoCliente);
                if (cliente != null)
                {
                    hfCodigoCliente.Value = cliente.CODIGOCLIENTE.ToString();
                    txtNombre.Text = cliente.nombre;
                    txtApellido.Text = cliente.apellido;
                    txtEmail.Text = cliente.email;
                    txtTelefono.Text = cliente.telefono;
                    txtRuc.Text = cliente.n_de_Ruc;
                    txtFechaNacimiento.Text = cliente.fecha_de_nacimiento?.ToString("yyyy-MM-dd");
                }
            }
            else if (e.CommandName == "Eliminar")
            {
                var cliente = db.Cliente.Find(codigoCliente);
                if (cliente != null)
                {
                    db.Cliente.Remove(cliente);
                    db.SaveChanges();
                    CargarClientes();
                }
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            hfCodigoCliente.Value = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtRuc.Text = "";
            txtFechaNacimiento.Text = "";
        }
    }
}