using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechStore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        clsAdministrarStore administrarStore = new clsAdministrarStore();
        clsNodo nodo = new clsNodo();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Si declaramos el objeto de la clase nodo aca adentro
            //Permitimos actulizarlo unicamente cuando se llama el metodo
            //Se realiza encapsulacion
            clsNodo nodo = new clsNodo();
            if(txtCodigo.Text != "" || txtDescripcion.Text != "" || txtNombre.Text != "" || txtPrecio.Text != "" || txtStock.Text != "")
            {
                nodo.id = Convert.ToInt32(txtCodigo.Text);
                nodo.nombre = txtNombre.Text;
                nodo.descripcion = txtDescripcion.Text;
                nodo.precio = Convert.ToInt32(txtPrecio.Text);
                nodo.stock = Convert.ToInt32(txtStock.Text);
                administrarStore.agregarDatos(nodo);
                administrarStore.recorrerListaAsc(dgvDatos);
                administrarStore.rellenarCMB(cmbDatos);
                MessageBox.Show("Datos agregados correctamente");
                txtCodigo.Text = "";
                txtDescripcion.Text = "";
                txtNombre.Text = "";
                txtPrecio.Text = "";
                txtStock.Text = "";
            } else
            {
                MessageBox.Show("Faltan datos de ingresar");
            }
            
        }

     

        private void btnListar_Click(object sender, EventArgs e)
        {
            administrarStore.recorrerLista(dgvDatos);
        }

        private void btnListarDesc_Click(object sender, EventArgs e)
        {
            administrarStore.recorrerListaDesc(dgvDatos);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int elemento = Convert.ToInt32(cmbDatos.SelectedItem);

            administrarStore.eliminarDato(elemento);
            administrarStore.recorrerLista(dgvDatos);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int cod = Convert.ToInt32(txtCodigoBuscar.Text);
           
            administrarStore.buscarCodigo(cod);
            lblNombre.Text = administrarStore.Nombre;
            lblPrecio.Text = administrarStore.Precio.ToString();
            lblStock.Text = administrarStore.Stock.ToString();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            administrarStore.imprimirDatos(dgvDatos);

        }

        private void prtDocumento_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //administrarStore.imprimirDatos(e,dgvDatos);
        }

        //Aplicar funcionalidad de imprimir lista
        //Controles a los textBox
        //Grabar video
    }
}
