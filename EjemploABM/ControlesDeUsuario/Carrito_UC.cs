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
using iTextSharp.tool.xml;

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
            guardar.FileName = "Factura" + ".pdf";
            guardar.ShowDialog();

            string PaginaHTML_Texto = Properties.Resources.Plantilla.ToString();
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CLIENTE", txtnombres.Text);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DOCUMENTO", txtdocumento.Text);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));

            string filas = string.Empty;
            decimal total = 0;
            foreach (DataGridViewRow row in dgvproductos.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Descripcion"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["PrecioUnitario"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Importe"].Value.ToString() + "</td>";
                filas += "</tr>";
                total += decimal.Parse(row.Cells["Importe"].Value.ToString());
            }
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@TOTAL", total.ToString());



            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    //Creamos un nuevo documento y lo definimos como PDF
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));

                    //Agregamos la imagen del banner al documento
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.shop, System.Drawing.Imaging.ImageFormat.Png);
                    img.ScaleToFit(60, 60);
                    img.Alignment = iTextSharp.text.Image.UNDERLYING;

                    //img.SetAbsolutePosition(10,100);
                    img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                    pdfDoc.Add(img);


                    //pdfDoc.Add(new Phrase("Hola Mundo"));
                    using (StringReader sr = new StringReader(PaginaHTML_Texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();
                }

            }
        }
    
    }
}
