using Proyecto_GO2inkas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_GO2inkas
{
    public partial class Cotizacion : System.Web.UI.Page
    {
        Go2inkasEntities db = new Go2inkasEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
                CargarCotizaciones();
            }
        }

        private void CargarClientes()
        {
            ddlClientes.DataSource = db.Cliente.Select(c => new { c.CODIGOCLIENTE, NombreCompleto = c.nombre + " " + c.apellido }).ToList();
            ddlClientes.DataValueField = "CODIGOCLIENTE";
            ddlClientes.DataTextField = "NombreCompleto";
            ddlClientes.DataBind();
        }

        private void CargarCotizaciones()
        {
            gvCotizaciones.DataSource = db.Cotizacion.ToList();
            gvCotizaciones.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int numero = string.IsNullOrEmpty(hfNumeroCotizacion.Value) ? 0 : int.Parse(hfNumeroCotizacion.Value);
            if (numero == 0)
            {
                var nueva = new Models.Cotizacion
                {
                    ClienteID = int.Parse(ddlClientes.SelectedValue),
                    nombrecliente = txtNombreCliente.Text,
                    identificacion_del_cliente = txtIdentificacion.Text,
                    tipo_de_tour = txtTipoTour.Text,
                    cantidad_de_pasajeros = int.TryParse(txtCantidadPasajeros.Text, out int pasajeros) ? pasajeros : (int?)null,
                    agregados = txtAgregados.Text,
                    costo = decimal.TryParse(txtCosto.Text, out decimal costo) ? costo : (decimal?)null,
                    fecha_de_tour = string.IsNullOrEmpty(txtFechaTour.Text) ? (DateTime?)null : DateTime.Parse(txtFechaTour.Text),
                    tipo_de_bicicleta = txtTipoBicicleta.Text,
                    fecha = string.IsNullOrEmpty(txtFecha.Text) ? (DateTime?)null : DateTime.Parse(txtFecha.Text)
                };
                db.Cotizacion.Add(nueva);
            }
            else
            {
                var cot = db.Cotizacion.Find(numero);
                if (cot != null)
                {
                    cot.ClienteID = int.Parse(ddlClientes.SelectedValue);
                    cot.nombrecliente = txtNombreCliente.Text;
                    cot.identificacion_del_cliente = txtIdentificacion.Text;
                    cot.tipo_de_tour = txtTipoTour.Text;
                    cot.cantidad_de_pasajeros = int.TryParse(txtCantidadPasajeros.Text, out int pasajeros) ? pasajeros : (int?)null;
                    cot.agregados = txtAgregados.Text;
                    cot.costo = decimal.TryParse(txtCosto.Text, out decimal costo) ? costo : (decimal?)null;
                    cot.fecha_de_tour = string.IsNullOrEmpty(txtFechaTour.Text) ? (DateTime?)null : DateTime.Parse(txtFechaTour.Text);
                    cot.tipo_de_bicicleta = txtTipoBicicleta.Text;
                    cot.fecha = string.IsNullOrEmpty(txtFecha.Text) ? (DateTime?)null : DateTime.Parse(txtFecha.Text);
                }
            }

            db.SaveChanges();
            Limpiar();
            CargarCotizaciones();
        }

        protected void gvCotizaciones_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int numeroCotizacion = Convert.ToInt32(gvCotizaciones.DataKeys[index].Value);

            if (e.CommandName == "Editar")
            {
                var cot = db.Cotizacion.Find(numeroCotizacion);
                if (cot != null)
                {
                    hfNumeroCotizacion.Value = cot.NUMEROCOTIZACION.ToString();
                    ddlClientes.SelectedValue = cot.ClienteID?.ToString();
                    txtNombreCliente.Text = cot.nombrecliente;
                    txtIdentificacion.Text = cot.identificacion_del_cliente;
                    txtTipoTour.Text = cot.tipo_de_tour;
                    txtCantidadPasajeros.Text = cot.cantidad_de_pasajeros?.ToString();
                    txtAgregados.Text = cot.agregados;
                    txtCosto.Text = cot.costo?.ToString("F2");
                    txtFechaTour.Text = cot.fecha_de_tour?.ToString("yyyy-MM-dd");
                    txtTipoBicicleta.Text = cot.tipo_de_bicicleta;
                    txtFecha.Text = cot.fecha?.ToString("yyyy-MM-dd");
                }
            }
            else if (e.CommandName == "Eliminar")
            {
                var cot = db.Cotizacion.Find(numeroCotizacion);
                if (cot != null)
                {
                    db.Cotizacion.Remove(cot);
                    db.SaveChanges();
                    CargarCotizaciones();
                }
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            hfNumeroCotizacion.Value = "";
            ddlClientes.SelectedIndex = 0;
            txtNombreCliente.Text = "";
            txtIdentificacion.Text = "";
            txtTipoTour.Text = "";
            txtCantidadPasajeros.Text = "";
            txtAgregados.Text = "";
            txtCosto.Text = "";
            txtFechaTour.Text = "";
            txtTipoBicicleta.Text = "";
            txtFecha.Text = "";
        }
    }
}