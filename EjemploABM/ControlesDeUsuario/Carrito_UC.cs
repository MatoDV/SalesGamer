using EjemploABM.Modelo;
using iTextSharp.text.pdf;
using iTextSharp.text;
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
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;

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

                Cantidad.Items.Add(1);
                Cantidad.Items.Add(2);
                Cantidad.Items.Add(3);
                Cantidad.Items.Add(4);
                Cantidad.Items.Add(5);
                dataGridView1.Rows[rowIndex].Cells[0].Value = producto.Id.ToString();
                dataGridView1.Rows[rowIndex].Cells[1].Value = producto.Nombre_producto.ToString();
                dataGridView1.Rows[rowIndex].Cells[3].Value = producto.Precio.ToString();
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
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.ShowDialog();
            string filePath = "output.pdf";
            PdfWriter pdfWriter = new PdfWriter(filePath);
            PdfDocument pdf = new PdfDocument(pdfWriter);
            Document document = new Document(pdf);

            // Agrega contenido al PDF
            document.Add(new Paragraph("¡Hola, este es mi PDF generado desde una aplicación de Windows Forms!"));

            // Cierra el documento
            document.Close();

            // Muestra un mensaje de éxito
            MessageBox.Show("PDF generado correctamente y guardado en el archivo 'output.pdf'");
        }
    }
    }
}
