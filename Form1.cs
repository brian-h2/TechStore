using System;
using System.Collections;
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
            if (!string.IsNullOrWhiteSpace(txtCodigo.Text) && //Si es null devuelve true
                !string.IsNullOrWhiteSpace(txtDescripcion.Text) &&
                !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(txtPrecio.Text) &&
                !string.IsNullOrWhiteSpace(txtStock.Text))
            {
                try
                {
                    nodo.id = Convert.ToInt32(txtCodigo.Text);
                    nodo.nombre = txtNombre.Text.Trim();
                    nodo.descripcion = txtDescripcion.Text.Trim();
                    

                    if (int.TryParse(txtPrecio.Text, out int precio) && int.TryParse(txtStock.Text, out int stock))
                    {
                        nodo.precio = precio;
                        nodo.stock = stock;
                    }
                    else
                    {
                        MessageBox.Show("Precio y Stock deben ser números válidos.");
                        return;
                    }

                    administrarStore.agregarDatos(nodo);
                    MessageBox.Show("Datos agregados correctamente");

                    txtCodigo.Text = "";
                    txtDescripcion.Text = "";
                    txtNombre.Text = "";
                    txtPrecio.Text = "";
                    txtStock.Text = "";
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Error en el formato de los datos: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se produjo un error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Faltan datos de ingresar");
            }

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            administrarStore.mostrarProductos(dgvDatos);
        }

        private void btnListarDesc_Click(object sender, EventArgs e)
        {
            administrarStore.mostrarProductosDesc(dgvDatos);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrWhiteSpace(txtCodigoBuscar.Text))
            {
                try
                {
                    if(int.TryParse(txtCodigoBuscar.Text, out int cod))
                    {
                        administrarStore.buscarCodigo(cod);
                        lblNombre.Text = administrarStore.Nombre;
                        lblPrecio.Text = administrarStore.Precio.ToString();
                        lblStock.Text = administrarStore.Stock.ToString();
                    } else
                    {
                        MessageBox.Show("El codigo a buscar debe ser valido");
                        return;
                    }
               
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Error en el formato de los datos: " + ex.Message);
                }
            } 
            else 
            {
                MessageBox.Show("Ingrese dato a buscar");
            } 
           
           
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                administrarStore.mostrarProductos(saveFileDialog.FileName);
                MessageBox.Show("Datos exportados con éxito");
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            administrarStore.mostrarProductos(cmbDatos);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cmbDatos.SelectedItem != null || cmbDatos.Text.Length < 0)
            {
                int elemento = Convert.ToInt32(cmbDatos.SelectedItem);

                administrarStore.eliminarDato(elemento);
                administrarStore.mostrarProductos(dgvDatos);
                cmbDatos.Text = "";

            }
            else
            {
                MessageBox.Show("Selecciona un elemento del combobox");
                cmbDatos.Text = "";

            }

        }

    }
}
