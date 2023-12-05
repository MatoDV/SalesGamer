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
        private List<Oferta> oferta;

        private void cargarProductAlCarrito()
        {
            oferta = Oferta_Controller.obtenerOferta(999, 999);
            foreach (Oferta oferr in oferta)
            {
                int rowIndex = dataGridView1.Rows.Add();

                dataGridView1.Rows[rowIndex].Cells[4].Value = oferr.Tipo_oferta.ToString();

            }
            carrito = Carrito_Controller.obtenerCarrito();
            foreach (Carrito carr in carrito)
            {
                int rowIndex = dataGridView1.Rows.Add();


                dataGridView1.Rows[rowIndex].Cells[0].Value = carr.Id.ToString();
                dataGridView1.Rows[rowIndex].Cells[1].Value = carr.nombre_producto.ToString();
                dataGridView1.Rows[rowIndex].Cells[2].Value = carr.cantidad.ToString();
                dataGridView1.Rows[rowIndex].Cells[3].Value = carr.precio_total.ToString();
                dataGridView1.Rows[rowIndex].Cells[5].Value = "Eliminar";
                dataGridView1.Rows[rowIndex].Cells[6].Value = "Agregar";

            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
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
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el producto.");
                    }
                }
            }



            if (senderGrid.Columns[e.ColumnIndex].Name == "Agregar")
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

        private void btn_comprar_Click(object sender, EventArgs e)
        {

        }
    }
}
