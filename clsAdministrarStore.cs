﻿using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace TechStore
{
    internal class clsAdministrarStore
    {
        public clsNodo primero;
        public clsNodo ultimo;

        public void agregarDatos(clsNodo nuevo)
        {
            if(primero == null || ultimo == null)
            {
                primero = nuevo; 
                ultimo = nuevo;
                
            } else
            {
                if (nuevo.id < primero.id) {
                    primero.Anterior = nuevo;
                    nuevo.Siguiente = primero;
                    primero = nuevo;
                } 
                else
                {
                    if(nuevo.id > primero.id)
                    {
                        ultimo.Siguiente = nuevo;
                        nuevo.Anterior = ultimo;
                        ultimo = nuevo;
                    
                    } else
                    {
                        clsNodo aux1 = primero;
                        clsNodo ant = primero;
                            while(aux1.id < nuevo.id)
                            {
                                ant = aux1;
                                aux1 = aux1.Siguiente;
                            }
                        
                        ant.Siguiente = nuevo;
                        nuevo.Siguiente = aux1;
                        aux1.Anterior = nuevo;
                        nuevo.Anterior = ant;
                    }
                }
            }
        }

        public void eliminarDato(Int32 cod)
        {
            if(primero.id == cod)
            {
                primero = primero.Siguiente;
                primero.Anterior = null;
            } else
            {
                if(ultimo.id == cod)
                {
                    ultimo = ultimo.Anterior;
                    ultimo.Siguiente = null;
                }
                else
                {
                    clsNodo aux1 = primero;
                    while (aux1.Siguiente.id < cod)
                    {
                        aux1 = aux1.Siguiente;
                    }
                    aux1.Siguiente = aux1.Siguiente.Siguiente;
                    aux1.Siguiente.Anterior = aux1;
                }
            }
        } 

        public void recorrerLista(DataGridView datos)
        {
            clsNodo aux1 = primero;
            datos.Rows.Clear();
            while (aux1 != null) 
            {
                datos.Rows.Add(aux1.id, aux1.nombre, aux1.descripcion, aux1.stock, aux1.precio);
                aux1 = aux1.Siguiente;
            }

            //Sobrecarga de tres metodos (Basicamente seria color un switch con cada metodo
            //y desde el form al darle click llamaria a ese metodo dentro del switch
        }

        public void recorrerListaAsc(DataGridView datos)
        {
            recorrerLista(datos);
        }

        public void recorrerListaDesc(DataGridView datos)
        {
            clsNodo aux1 = ultimo;
            datos.Rows.Clear();
            while (aux1 != null)
            {
                datos.Rows.Add(aux1.id, aux1.nombre, aux1.descripcion, aux1.stock, aux1.precio);
                aux1 = aux1.Anterior;
            }
        }

        public void rellenarCMB(ComboBox cmb)
        {
            clsNodo aux1 = primero;
            cmb.Items.Clear();
            while (aux1 != null)
            {
                cmb.Items.Add(aux1.id);
                aux1 = aux1.Siguiente;
            }
        }

        public string Nombre { get; set; }
        public int Precio {  get; set; }    
        public int Stock {  get; set; }

        public void buscarCodigo(Int32 cod)
        { 

          clsNodo aux1 = primero;
          while(aux1 != null && aux1.id != cod)
            {
               aux1 = aux1.Siguiente;
            }
            if (aux1 != null)
            {
                Nombre = aux1.nombre;
                Precio = aux1.precio;
                Stock = aux1.stock; 
            }
            else
            {
                MessageBox.Show("Valor no encontrado");
            }

        }

        public void imprimirDatos(DataGridView datos)
        {
          foreach(DataGridViewRow row in datos.Rows)
            {
                foreach (DataGridViewCell column in row.Cells)
                {
                    
                }
            }

            
        }
    }
}