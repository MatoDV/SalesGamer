using EjemploABM.Modelo;
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

            combox_distribuidor.Items.Add("Admin");
            combox_oferta.Items.Add("Vendedor");
            combox_categoria.Items.Add("Placas de video");
            combox_categoria.Items.Add("Procesador");
            combox_categoria.Items.Add("Memoria Ram");
            combox_categoria.Items.Add("Placa Madre");
            combox_categoria.Items.Add("Fuente");
            combox_categoria.Items.Add("Disco Rigido");
            combox_categoria.Items.Add("Disco Solido");




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
            

            situacion = "edicion";

            label8.Text = "Editar Producto";
            btn_agregar.Text = "Editar";


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

        private void btn_agregar_Click(object sender, EventArgs e)
        {

        }
    }
}
