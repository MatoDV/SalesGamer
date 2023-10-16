using EjemploABM.Controladores;
using EjemploABM.Modelo;
using EjemploABM;
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
using SalesGamer.Controladores;

namespace SalesGamer.ControlesDeUsuario
{
    public partial class Productos_UC : UserControl
    {
        private List<Producto> prods;

        public Productos_UC()
        {
            InitializeComponent();
            cargarProductos();
        }
        private void cargarProductos()
        {
            prods = Producto_Controller.obtenerProductos();
            dataGridView1.Rows.Clear();
            foreach (Producto prod in prods)
            {
                int rowIndex = dataGridView1.Rows.Add();

                dataGridView1.Rows[rowIndex].Cells[0].Value = prod.Id.ToString();
                dataGridView1.Rows[rowIndex].Cells[1].Value = prod.Nombre_producto.ToString();
                dataGridView1.Rows[rowIndex].Cells[2].Value = prod.Descripcion.ToString();
                dataGridView1.Rows[rowIndex].Cells[3].Value = prod.Precio.ToString();
                dataGridView1.Rows[rowIndex].Cells[4].Value = prod.Cantidad.ToString();
                if (prod.Categoria_id == 1)
                {
                    dataGridView1.Rows[rowIndex].Cells[5].Value = "Placas de video";

                }
                else if (prod.Categoria_id == 2)
                {

                    dataGridView1.Rows[rowIndex].Cells[5].Value = "Procesador";
                }
                else if (prod.Categoria_id == 3)
                {

                    dataGridView1.Rows[rowIndex].Cells[5].Value = "Memoria Ram";
                }
                else if (prod.Categoria_id == 4)
                {

                    dataGridView1.Rows[rowIndex].Cells[5].Value = "Placa Madre";
                }
                else if (prod.Categoria_id == 5)
                {

                    dataGridView1.Rows[rowIndex].Cells[5].Value = "Fuente";
                }
                else if (prod.Categoria_id == 6)
                {

                    dataGridView1.Rows[rowIndex].Cells[5].Value = "Disco Rigido";
                }
                else if (prod.Categoria_id == 7)
                {

                    dataGridView1.Rows[rowIndex].Cells[5].Value = "Disco Solido";
                }
                else if (prod.Categoria_id == 8)
                {

                    dataGridView1.Rows[rowIndex].Cells[5].Value = "Mouse";
                }
                else if (prod.Categoria_id == 9)
                {

                    dataGridView1.Rows[rowIndex].Cells[5].Value = "Teclado";
                }
                else if (prod.Categoria_id == 10)
                {

                    dataGridView1.Rows[rowIndex].Cells[5].Value = "Monitor";
                }
                else if (prod.Categoria_id == 11)
                {

                    dataGridView1.Rows[rowIndex].Cells[5].Value = "Auricular";
                }
                else if (prod.Categoria_id == 12)
                {

                    dataGridView1.Rows[rowIndex].Cells[5].Value = "Microfono";
                }
                else if (prod.Categoria_id == 13)
                {

                    dataGridView1.Rows[rowIndex].Cells[5].Value = "Gabinete";
                }
                if (prod.Distribuidor_id == 1)
                {
                    dataGridView1.Rows[rowIndex].Cells[6].Value = "GIGABYTE";

                }
                else if (prod.Categoria_id == 2)
                {

                    dataGridView1.Rows[rowIndex].Cells[6].Value = "ASUS";
                }
                else if (prod.Categoria_id == 3)
                {

                    dataGridView1.Rows[rowIndex].Cells[6].Value = "NVIDIA";
                }
                else if (prod.Categoria_id == 4)
                {

                    dataGridView1.Rows[rowIndex].Cells[6].Value = "AMD";
                }
                else if (prod.Categoria_id == 5)
                {

                    dataGridView1.Rows[rowIndex].Cells[6].Value = "MSI";
                }
                else if (prod.Categoria_id == 6)
                {

                    dataGridView1.Rows[rowIndex].Cells[6].Value = "EVGA";
                }
                else if (prod.Categoria_id == 7)
                {

                    dataGridView1.Rows[rowIndex].Cells[6].Value = "ZOTAC";
                }

                if (prod.Oferta_id == 1)
                {
                    dataGridView1.Rows[rowIndex].Cells[7].Value = "10% descuento";

                }
                else if (prod.Categoria_id == 2)
                {

                    dataGridView1.Rows[rowIndex].Cells[7].Value = "20% descuento";
                }
                else if (prod.Categoria_id == 3)
                {

                    dataGridView1.Rows[rowIndex].Cells[7].Value = "30% descuento";
                }
                else if (prod.Categoria_id == 4)
                {

                    dataGridView1.Rows[rowIndex].Cells[7].Value = "50% descuento";
                }
                dataGridView1.Rows[rowIndex].Cells[8].Value = "Editar";
                dataGridView1.Rows[rowIndex].Cells[9].Value = "Eliminar";

            }
        }

        
        private void btn_crear_Click(object sender, EventArgs e)
        {
            ProductForm frmProd = new ProductForm();
            DialogResult dr = frmProd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                Trace.WriteLine("OK");
                //ACTUALIZAR LA LISTA
                cargarProductos();

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex].Name == "Editar")
            {
                //EDITAMOS

                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                Trace.WriteLine("el id es: " + id);

                Producto prod_editar = Producto_Controller.ObtenerProductoID(id);

                ProductForm frmProd = new ProductForm(prod_editar);

                DialogResult dr = frmProd.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    Trace.WriteLine("OK");
                    //ACTUALIZAR LA LISTA
                    cargarProductos();

                }
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Productos_UC_Load(object sender, EventArgs e)
        {

        }

    }
}
