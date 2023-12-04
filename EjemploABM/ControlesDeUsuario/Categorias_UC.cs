using EjemploABM.Modelo;
using SalesGamer;
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

namespace EjemploABM.ControlesDeUsuario
{
    public partial class Categorias_UC : UserControl
    {
        private List<Categoria>categorias;
        public Categorias_UC()
        {
            InitializeComponent();
            cargarCategorias();
        }
        private void cargarCategorias()
        {
            categorias = Categoria_Controller.obtenerCategoria();
            dataGridView1.Rows.Clear();
            foreach (Categoria cat in categorias)
            {
                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells[0].Value = cat.Id.ToString();
                dataGridView1.Rows[rowIndex].Cells[1].Value = cat.Nombre_categoria.ToString();
                dataGridView1.Rows[rowIndex].Cells[2].Value = "Editar";
                dataGridView1.Rows[rowIndex].Cells[3].Value = "Eliminar";
            }
        }
        private void btn_crear_Click_1(object sender, EventArgs e)
        {
            CategoryForm frmCat = new CategoryForm();
            DialogResult dr = frmCat.ShowDialog();

            if (dr == DialogResult.OK)
            {
                Trace.WriteLine("OK");
                //ACTUALIZAR LA LISTA
                cargarCategorias();

            }
        }

       


        private void Categorias_UC_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex].Name == "Editar")
            {
                //EDITAMOS

                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                Trace.WriteLine("el id es: " + id);

                Categoria cat_editar = Categoria_Controller.ObtenerCategoriaID(id);

                CategoryForm frmCat = new CategoryForm(cat_editar);

                DialogResult dr = frmCat.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    Trace.WriteLine("OK");
                    //ACTUALIZAR LA LISTA
                    cargarCategorias();

                }
            }

            if (senderGrid.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                //Eliminamos

                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());


                Categoria cat_eliminar = Categoria_Controller.ObtenerCategoriaID(id);

                // Confirmar la eliminación con un mensaje de confirmación
                DialogResult result = MessageBox.Show("¿Estás seguro que quieres eliminar este producto?", "Confirmar eliminación", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {

                    bool eliminacionExitosa = Categoria_Controller.eliminarCategoria(cat_eliminar);

                    if (eliminacionExitosa)
                    {
                        MessageBox.Show("Producto eliminado exitosamente.");
                        cargarCategorias();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el producto.");
                    }
                }
            }
        }
    }
}
