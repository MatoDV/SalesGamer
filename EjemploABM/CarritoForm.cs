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
using MaterialSkin;
using MaterialSkin.Controls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;

namespace SalesGamer
{
    public partial class CarritoForm : MaterialForm
    {
        private Carrito_Controller carrito_Controller;
        public CarritoForm(Carrito_Controller carrito_Controller)
        {
            InitializeComponent();
            this.carrito_Controller = carrito_Controller;
            ActualizarProductosEnCarrito();
        }
        private void ActualizarProductosEnCarrito()
        {
            List<Producto> productosEnCarrito = carrito_Controller.ObtenerProductosEnCarrito();
            dataGridView1.DataSource = productosEnCarrito;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void CarritoForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_comprar_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = "RECIBO_DE_COMPRA"+".pdf";
            guardar.ShowDialog();
        }
    }
}
