using EjemploABM.Modelo;
using SalesGamer.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesGamer
{
    public partial class CarritoForm : Form
    {
        private Carrito_Controller carrito_Controller;
        public CarritoForm(Carrito_Controller carrito_Controller)
        {
            InitializeComponent();
            this.carrito_Controller = carrito_Controller;
            List<Producto> productosEnCarrito = carrito_Controller.ObtenerProductosEnCarrito();
            dataGridView1.DataSource = productosEnCarrito;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void btn_comprar_Click(object sender, EventArgs e)
        {
          
        }

        private void CarritoForm_Load(object sender, EventArgs e)
        {

        }


    }
}
