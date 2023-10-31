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
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using static System.Net.WebRequestMethods;
using System.Diagnostics;
using EjemploABM;

namespace SalesGamer.ControlesDeUsuario
{
    public partial class Carrito_UC : UserControl
    {
        Carrito_Controller carritoController;

        public Carrito_UC(Carrito_Controller carritoController)
        {
            InitializeComponent();
            this.carritoController = carritoController;
            CargarProductosEnCarrito();
        }

        private void CargarProductosEnCarrito()
        {

            foreach (Producto producto in carritoController.carrito.productosEnCarrito)
            {
                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells[0].Value = producto.Id.ToString();
                dataGridView1.Rows[rowIndex].Cells[1].Value = producto.Nombre_producto.ToString();
                dataGridView1.Rows[rowIndex].Cells[2].Value = producto.Cantidad.ToString();
                dataGridView1.Rows[rowIndex].Cells[3].Value = producto.Precio.ToString();
                dataGridView1.Rows[rowIndex].Cells[4].Value = "Editar";
                dataGridView1.Rows[rowIndex].Cells[4].Value = "Eliminar";


            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Eliminar" && e.RowIndex >= 0)
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                Producto producto = Producto_Controller.ObtenerProductoID(id);

                Producto_Controller.RemoverProductoDelCarrito(producto, carritoController.carrito);
                CargarProductosEnCarrito();
                MessageBox.Show("Producto eliminado del carrito de compras.");
            }

        }

        private void btn_comprar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gracias por su compra");
            MostrarVistaProductos();

        }
        private void MostrarVistaProductos()
        {
            // Código para mostrar la vista de productos, por ejemplo:
            Productos_UC volver = new Productos_UC(carritoController);
            volver.Show();
            this.Hide();// Oculta el formulario actual si es necesario
        }
    }
}
