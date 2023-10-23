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

namespace SalesGamer
{
    public partial class CategoryForm : Form
    {
        string situacion;
        int id_editar;
        public CategoryForm()
        {
            InitializeComponent();
            situacion = "creacion";

        }
        public CategoryForm(Categoria categoria)
        {
            InitializeComponent();
            id_editar = categoria.Id;

            txt_nombre.Text = categoria.Nombre_categoria.ToString();

            situacion = "edicion";
            label_titulo.Text = "Editar Categoria";
            btn_crear.Text = "Editar";

        }

        private void btn_crear_Click(object sender, EventArgs e)
        {
            if (situacion == "creacion")
            {
                crear();
            }
            if (situacion == "edicion")
            {
                editar();
            }
        }

        private void crear()
        {
            Categoria cat = new Categoria(0, txt_nombre.Text);
            if (txt_nombre.SelectedText.ToString() == "Placas de video" && txt_nombre.SelectedText.ToString() == "Procesador" 
                && txt_nombre.SelectedText.ToString() == "Memoria Ram" && txt_nombre.SelectedText.ToString() == "Placa Madre" 
                && txt_nombre.SelectedText.ToString() == "Fuente" && txt_nombre.SelectedText.ToString() == "Disco Rigido"
                && txt_nombre.SelectedText.ToString() == "Disco Solido" && txt_nombre.SelectedText.ToString() == "Mouse" 
                && txt_nombre.SelectedText.ToString() == "Teclado" && txt_nombre.SelectedText.ToString() == "Monitor" 
                && txt_nombre.SelectedText.ToString() == "Auricular" && txt_nombre.SelectedText.ToString() == "Microfono" 
                && txt_nombre.SelectedText.ToString() == "Gabinete")
            {
                DialogResult result = MessageBox.Show("La categoria que se intento crear ya esta creada");
            }
            else if (Categoria_Controller.CrearCategoria(cat))
            {
                this.DialogResult = DialogResult.OK;
            }
        }
        private void editar()
        {
            Categoria cat = new Categoria(id_editar, txt_nombre.Text);
            if (Categoria_Controller.editarCategoria(cat))
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
