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
using SalesGamer.Modelo;

namespace SalesGamer.ControlesDeUsuario
{
    public partial class Carrito_UC : UserControl
    {
        private List<Carrito> carrito;
        public Carrito_UC()
        {
            InitializeComponent();
            cargarProductAlCarrito();
            ActualizarPrecioTotalCarrito();
        }
        private void cargarProductAlCarrito()
        {
            dataGridView1.Rows.Clear();
          
            carrito = Carrito_Controller.obtenerCarrito();
            foreach (Carrito carr in carrito)
            {
                int rowIndex = dataGridView1.Rows.Add();


                dataGridView1.Rows[rowIndex].Cells[0].Value = carr.Id.ToString();
                dataGridView1.Rows[rowIndex].Cells[1].Value = carr.nombre_producto.ToString();
                dataGridView1.Rows[rowIndex].Cells[2].Value = carr.cantidad.ToString();
                dataGridView1.Rows[rowIndex].Cells[3].Value = carr.precio_total.ToString();
                if (carr.Oferta_id == 1)
                {
                    dataGridView1.Rows[rowIndex].Cells[4].Value = "10% descuento";

                }
                else if (carr.Oferta_id == 2)
                {

                    dataGridView1.Rows[rowIndex].Cells[4].Value = "20% descuento";
                }
                else if (carr.Oferta_id == 3)
                {

                    dataGridView1.Rows[rowIndex].Cells[4].Value = "30% descuento";
                }
                else if (carr.Oferta_id == 4)
                {

                    dataGridView1.Rows[rowIndex].Cells[4].Value = "50% descuento";
                }
                else if (carr.Oferta_id == 5)
                {

                    dataGridView1.Rows[rowIndex].Cells[4].Value = "sin descuento";
                }
                dataGridView1.Rows[rowIndex].Cells[5].Value = "Eliminar";
                dataGridView1.Rows[rowIndex].Cells[6].Value = "Agregar";

            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarProductAlCarrito();

            var senderGrid = (DataGridView)sender;


            if (senderGrid.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                //Eliminamos

                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());


                Carrito prod_eliminar = Carrito_Controller.ObtenerCarritoID(id);

                // Confirmar la eliminación con un mensaje de confirmación
                DialogResult result = MessageBox.Show("¿Estás seguro que quieres sacar este producto?", "Confirmar eliminación", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {

                    bool eliminacionExitosa = Carrito_Controller.eliminarCarrito(prod_eliminar);

                    if (eliminacionExitosa)
                    {
                        MessageBox.Show("Producto eliminado exitosamente.");
                        cargarProductAlCarrito();
                        ActualizarPrecioTotalCarrito();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el producto.");
                    }

                }
            }



            if (senderGrid.Columns[e.ColumnIndex].Name == "agregar")
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                Carrito carritoItem = Carrito_Controller.ObtenerCarritoID(id);

                if (carritoItem != null)
                {
                    // Aumentar la cantidad en 1
                    carritoItem.cantidad += 1;

                    bool exito = Carrito_Controller.editarCarrito(carritoItem);

                    if (exito)
                    {
                        MessageBox.Show("Cantidad actualizada en el carrito.");
                        // Vuelve a cargar los productos del carrito para actualizar la vista
                        cargarProductAlCarrito();
                        ActualizarPrecioTotalCarrito();
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar la cantidad en el carrito.");
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo encontrar el producto en el carrito.");
                }

            }
        }
        private double CalcularPrecioTotalCarrito()
        {
            double precioTotalCarrito = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue; // Ignora la fila vacía de nueva entrada

                int cantidad = int.Parse(row.Cells[2].Value.ToString());
                double precioUnitario = double.Parse(row.Cells[3].Value.ToString());
                string ofertaTexto = row.Cells[4].Value.ToString();

                double precioTotal = cantidad * precioUnitario;

                if (ofertaTexto.Contains("10% descuento"))
                {
                    precioTotal *= 0.9; // Aplica un descuento del 10%
                }
                else if (ofertaTexto.Contains("20% descuento"))
                {
                    precioTotal *= 0.8; // Aplica un descuento del 20%
                }
                else if (ofertaTexto.Contains("30% descuento"))
                {
                    precioTotal *= 0.7; // Aplica un descuento del 30%
                }
                else if (ofertaTexto.Contains("50% descuento"))
                {
                    precioTotal *= 0.5; // Aplica un descuento del 50%
                }
                // Puedes agregar más condiciones según tu lógica de descuentos

                precioTotalCarrito += precioTotal;
            }

            return precioTotalCarrito;
        }
        private void ActualizarPrecioTotalCarrito()
        {
            double precioTotalCarrito = CalcularPrecioTotalCarrito();
            txt_Precio.Text = "Precio total: $" + precioTotalCarrito.ToString(); // Actualiza el texto del label
        }


        private void btn_comprar_Click(object sender, EventArgs e)
        {
            Document doc = new Document();

            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, "Comprobante_de_pago.pdf");

                // Crear el archivo PDF
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                // Añadir contenido al PDF
                PdfPTable table = new PdfPTable(4); // Crear una tabla con 5 columnas
                table.WidthPercentage = 100; // Establecer el ancho de la tabla al 100% del tamaño del documento

                // Agregar encabezados
                string[] headers = { "Nombre", "Cantidad", "Precio", "Descuento" };
                foreach (var header in headers)
                {
                    table.AddCell(header);
                }

                // Iterar sobre las filas del DataGridView
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    // Obtener los valores de las celdas necesarias y añadirlos a la tabla
                    string nombre = row.Cells[1].Value?.ToString(); // Columna del nombre
                    string cantidad = row.Cells[2].Value?.ToString(); // Columna de la cantidad
                    string precio = row.Cells[3].Value?.ToString(); // Columna del precio
                    string descuento = row.Cells[4].Value?.ToString(); // Columna del descuento

                    table.AddCell(nombre);
                    table.AddCell(cantidad);
                    table.AddCell(precio);
                    table.AddCell(descuento);
                }

                // Agregar el total al PDF
                PdfPCell cellTotal = new PdfPCell(new Phrase($"{txt_Precio.Text}"));
                cellTotal.Colspan = 4; // Fusionar la celda para abarcar las 4 columnas
                table.AddCell(cellTotal);

                // Agregar la tabla al documento
                doc.Add(table);

                // Cerrar el documento
                doc.Close();
                MessageBox.Show("PDF generado exitosamente en el escritorio.");
                Carrito_Controller.VaciarCarrito();
                Index parentForm = this.ParentForm as Index;
                if (parentForm != null)
                {
                    Productos_UC productosUC = new Productos_UC();
                    parentForm.addUserControl(productosUC);
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message);
            }

        }

        private void btn_agregarOtro_Click(object sender, EventArgs e)
        {
            Index parentForm = this.ParentForm as Index;
            if (parentForm != null)
            {
                Productos_UC productosUC = new Productos_UC();
                parentForm.addUserControl(productosUC);
            }
        }
    }
}
