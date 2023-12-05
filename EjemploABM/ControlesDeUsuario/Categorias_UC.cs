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
        private int numeroPagina = 1;
        private int elementosPorPagina = 5;
        public Categorias_UC()
        {
            InitializeComponent();
            cargarCategorias();
            if (Program.logueado.ID_rol != 1)
            {
                btn_crear.Hide();

            }
        }
        private void cargarCategorias()
        {
            categorias = Categoria_Controller.obtenerCategoria(numeroPagina, elementosPorPagina);
            dataGridView1.Rows.Clear();
            foreach (Categoria cat in categorias)
            {
                int rowIndex = dataGridView1.Rows.Add();
                if (Program.logueado.ID_rol != 1)
                {
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[3].Visible = false;


                }
                dataGridView1.Rows[rowIndex].Cells[0].Value = cat.Id.ToString();
                dataGridView1.Rows[rowIndex].Cells[1].Value = cat.Nombre_categoria.ToString();
                dataGridView1.Rows[rowIndex].Cells[2].Value = "Editar";
                dataGridView1.Rows[rowIndex].Cells[3].Value = "Eliminar";
            }
            txt_pagina.Text = $"Página: {numeroPagina}";
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

        private void btn_atras_Click(object sender, EventArgs e)
        {
            if (numeroPagina > 1)
            {
                numeroPagina--; // Disminuir el número de página solo si no es la primera página
                cargarCategorias(); // Volver a cargar los productos con la nueva página
            }
        }

        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            numeroPagina++; // Aumentar el número de página
            cargarCategorias();
        }
    }
}
