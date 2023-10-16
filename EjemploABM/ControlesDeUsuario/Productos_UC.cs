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
                dataGridView1.Rows[rowIndex].Cells[2].Value = prod.Precio.ToString();
                dataGridView1.Rows[rowIndex].Cells[2].Value = prod.Cantidad.ToString();
                dataGridView1.Rows[rowIndex].Cells[2].Value = prod.Categoria_id.ToString();
                dataGridView1.Rows[rowIndex].Cells[2].Value = prod.Distribuidor_id.ToString();
                dataGridView1.Rows[rowIndex].Cells[3].Value = prod.Oferta_id.ToString();
                dataGridView1.Rows[rowIndex].Cells[5].Value = "Editar";
                dataGridView1.Rows[rowIndex].Cells[6].Value = "Eliminar";

            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            FormUsuarios frmUser = new FormUsuarios();
            DialogResult dr = frmUser.ShowDialog();

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
