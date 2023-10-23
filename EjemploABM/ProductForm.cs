using EjemploABM.Controladores;
using EjemploABM.Modelo;
using SalesGamer.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesGamer
{
    public partial class ProductForm : Form
    {
        string situacion;
        int id_editar;
        public ProductForm()
        {
            InitializeComponent();

            combox_distribuidor.Items.Clear();
            combox_oferta.Items.Clear();
            combox_categoria.Items.Clear();

            combox_distribuidor.Items.Add("GIGABYTE");
            combox_distribuidor.Items.Add("LOGITECH");
            combox_distribuidor.Items.Add("NVIDIA");
            combox_distribuidor.Items.Add("AMD");
            combox_distribuidor.Items.Add("MSI");
            combox_distribuidor.Items.Add("KINGSTON");
            combox_distribuidor.Items.Add("CORSAIR");
            combox_distribuidor.Items.Add("INTEL");
            combox_oferta.Items.Add("10% descuento");
            combox_oferta.Items.Add("20% descuento");
            combox_oferta.Items.Add("30% descuento");
            combox_oferta.Items.Add("50% descuento");
            combox_oferta.Items.Add("sin descuento");
            combox_categoria.Items.Add("Placas de video");
            combox_categoria.Items.Add("Procesador");
            combox_categoria.Items.Add("Memoria Ram");
            combox_categoria.Items.Add("Placa Madre");
            combox_categoria.Items.Add("Fuente");
            combox_categoria.Items.Add("Disco Rigido");
            combox_categoria.Items.Add("Disco Solido");
            combox_categoria.Items.Add("Mouse");
            combox_categoria.Items.Add("Teclado");
            combox_categoria.Items.Add("Monitor");
            combox_categoria.Items.Add("Auricular");
            combox_categoria.Items.Add("Microfono");
            combox_categoria.Items.Add("Gabinete");



            situacion = "creacion";
        }

        // SOBRECARGAR EL CONSTRUCTOR PARA INICIAR EL FORM CON LA INFO CARGADA, PARA EDITAR
        public ProductForm(Producto producto)
        {
            InitializeComponent();

            id_editar = producto.Id;

            txt_nombre.Text = producto.Nombre_producto.ToString();
            txt_descripcion.Text = producto.Descripcion.ToString();
            txt_precio.Text = producto.Precio.ToString();
            txt_cantidad.Text = producto.Cantidad.ToString();

            combox_distribuidor.Items.Add("GIGABYTE");
            combox_distribuidor.Items.Add("LOGITECH");
            combox_distribuidor.Items.Add("NVIDIA");
            combox_distribuidor.Items.Add("AMD");
            combox_distribuidor.Items.Add("MSI");
            combox_distribuidor.Items.Add("KINGSTON");
            combox_distribuidor.Items.Add("CORSAIR");
            combox_distribuidor.Items.Add("INTEL");
            combox_oferta.Items.Add("10% descuento");
            combox_oferta.Items.Add("20% descuento");
            combox_oferta.Items.Add("30% descuento");
            combox_oferta.Items.Add("50% descuento");
            combox_oferta.Items.Add("sin descuento");
            combox_categoria.Items.Add("Placas de video");
            combox_categoria.Items.Add("Procesador");
            combox_categoria.Items.Add("Memoria Ram");
            combox_categoria.Items.Add("Placa Madre");
            combox_categoria.Items.Add("Fuente");
            combox_categoria.Items.Add("Disco Rigido");
            combox_categoria.Items.Add("Disco Solido");
            combox_categoria.Items.Add("Mouse");
            combox_categoria.Items.Add("Teclado");
            combox_categoria.Items.Add("Monitor");
            combox_categoria.Items.Add("Auricular");
            combox_categoria.Items.Add("Microfono");
            combox_categoria.Items.Add("Gabinete");

            situacion = "edicion";

            label8.Text = "Editar Producto";
            btn_agregar.Text = "Editar";


        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (situacion == "creacion")
            {
                crear();
            }
            if (situacion == "edicion")
            {
                editar();
            }
        }

        private void crear()
        {
            int distribuidor = 0;
            if (combox_distribuidor.SelectedItem.ToString() == "GIGABYTE")
            {
                distribuidor = 1;
            }
            else if (combox_distribuidor.SelectedItem.ToString() == "LOGITECH")
            {
                distribuidor = 2;
            }
            else if (combox_distribuidor.SelectedItem.ToString() == "NVIDIA")
            {
                distribuidor = 3;
            }
            else if (combox_distribuidor.SelectedItem.ToString() == "AMD")
            {
                distribuidor = 4;
            }
            else if (combox_distribuidor.SelectedItem.ToString() == "MSI")
            {
                distribuidor = 5;
            }
            else if (combox_distribuidor.SelectedItem.ToString() == "KINGSTON")
            {
                distribuidor = 6;
            }
            else if (combox_distribuidor.SelectedItem.ToString() == "CORSAIR")
            {
                distribuidor = 7;
            }
            else if (combox_distribuidor.SelectedItem.ToString() == "INTEL")
            {
                distribuidor = 8;
            }

            int categoria = 0;
            if (combox_categoria.SelectedItem.ToString() == "Placas de video")
            {
                categoria = 1;
            }
            else if (combox_categoria.SelectedItem.ToString() == "Procesador")
            {
                categoria = 2;
            }
            else if (combox_categoria.SelectedItem.ToString() == "Memoria Ram")
            {
                categoria = 3;
            }
            else if (combox_categoria.SelectedItem.ToString() == "Placa Madre")
            {
                categoria = 4;
            }
            else if (combox_categoria.SelectedItem.ToString() == "Fuente")
            {
                categoria = 5;
            }
            else if (combox_categoria.SelectedItem.ToString() == "Disco Rigido")
            {
                categoria = 6;
            }
            else if (combox_categoria.SelectedItem.ToString() == "Disco Solido")
            {
                categoria = 7;
            }
            else if (combox_categoria.SelectedItem.ToString() == "Mouse")
            {
                categoria = 8;
            }
            else if (combox_categoria.SelectedItem.ToString() == "Teclado")
            {
                categoria = 9;
            }
            else if (combox_categoria.SelectedItem.ToString() == "Monitor")
            {
                categoria = 10;
            }
            else if (combox_categoria.SelectedItem.ToString() == "Auricular")
            {
                categoria = 11;
            }
            else if (combox_categoria.SelectedItem.ToString() == "Microfono")
            {
                categoria = 12;
            }
            else if (combox_categoria.SelectedItem.ToString() == "Gabinete")
            {
                categoria = 13;
            }

            int oferta = 0;
            if (combox_oferta.SelectedItem.ToString() == "10% descuento")
            {
                oferta = 1;
            }
            else if (combox_oferta.SelectedItem.ToString() == "20% descuento")
            {
                oferta = 2;
            }
            else if (combox_oferta.SelectedItem.ToString() == "30% descuento")
            {
                oferta = 3;
            }
            else if (combox_oferta.SelectedItem.ToString() == "50% descuento")
            {
                oferta = 4;
            }
            else if (combox_oferta.SelectedItem.ToString() == "sin descuento")
            {
                oferta = 5;
            }


            int precio;
            int cantidad;
            if (int.TryParse(txt_precio.Text, out precio) && int.TryParse(txt_cantidad.Text, out cantidad))
            {
                Producto prod = new Producto(0, txt_nombre.Text, txt_descripcion.Text, precio, cantidad, categoria, distribuidor, oferta);
                if (Producto_Controller.CrearProducto(prod))
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            
        }

        private void editar()
        {
            int distribuidor = 0;
            if (combox_distribuidor.SelectedItem.ToString() == "GIGABYTE")
            {
                distribuidor = 1;
            }
            else if (combox_distribuidor.SelectedItem.ToString() == "LOGITECH")
            {
                distribuidor = 2;
            }
            else if (combox_distribuidor.SelectedItem.ToString() == "NVIDIA")
            {
                distribuidor = 3;
            }
            else if (combox_distribuidor.SelectedItem.ToString() == "AMD")
            {
                distribuidor = 4;
            }
            else if (combox_distribuidor.SelectedItem.ToString() == "MSI")
            {
                distribuidor = 5;
            }
            else if (combox_distribuidor.SelectedItem.ToString() == "KINGSTON")
            {
                distribuidor = 6;
            }
            else if (combox_distribuidor.SelectedItem.ToString() == "CORSAIR")
            {
                distribuidor = 7;
            }
            else if (combox_distribuidor.SelectedItem.ToString() == "INTEL")
            {
                distribuidor = 8;
            }

            int categoria = 0;
            if (combox_categoria.SelectedItem.ToString() == "Placas de video")
            {
                categoria = 1;
            }
            else if (combox_categoria.SelectedItem.ToString() == "Procesador")
            {
                categoria = 2;
            }
            else if (combox_categoria.SelectedItem.ToString() == "Memoria Ram")
            {
                categoria = 3;
            }
            else if (combox_categoria.SelectedItem.ToString() == "Placa Madre")
            {
                categoria = 4;
            }
            else if (combox_categoria.SelectedItem.ToString() == "Fuente")
            {
                categoria = 5;
            }
            else if (combox_categoria.SelectedItem.ToString() == "Disco Rigido")
            {
                categoria = 6;
            }
            else if (combox_categoria.SelectedItem.ToString() == "Disco Solido")
            {
                categoria = 7;
            }
            else if (combox_categoria.SelectedItem.ToString() == "Mouse")
            {
                categoria = 8;
            }
            else if (combox_categoria.SelectedItem.ToString() == "Teclado")
            {
                categoria = 9;
            }
            else if (combox_categoria.SelectedItem.ToString() == "Monitor")
            {
                categoria = 10;
            }
            else if (combox_categoria.SelectedItem.ToString() == "Auricular")
            {
                categoria = 11;
            }
            else if (combox_categoria.SelectedItem.ToString() == "Microfono")
            {
                categoria = 12;
            }
            else if (combox_categoria.SelectedItem.ToString() == "Gabinete")
            {
                categoria = 13;
            }

            int oferta = 0;
            if (combox_oferta.SelectedItem.ToString() == "10% descuento")
            {
                oferta = 1;
            }
            else if (combox_oferta.SelectedItem.ToString() == "20% descuento")
            {
                oferta = 2;
            }
            else if (combox_oferta.SelectedItem.ToString() == "30% descuento")
            {
                oferta = 3;
            }
            else if (combox_oferta.SelectedItem.ToString() == "50% descuento")
            {
                oferta = 4;
            }
            else if (combox_oferta.SelectedItem.ToString() == "sin descuento")
            {
                oferta = 5;
            }

            int precio;
            int cantidad;
            if (int.TryParse(txt_precio.Text, out precio) && int.TryParse(txt_cantidad.Text, out cantidad))
            {
                Producto prod = new Producto(id_editar, txt_nombre.Text, txt_descripcion.Text, precio, cantidad, categoria, distribuidor, oferta);
                if (Producto_Controller.editarProducto(prod))
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void combox_distribuidor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void combox_oferta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void combox_categoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ProductForm_Load(object sender, EventArgs e)
        {

        }
    }
}
