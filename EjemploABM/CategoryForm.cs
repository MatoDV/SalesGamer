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
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using MaterialSkin;
using MaterialSkin.Controls;

namespace SalesGamer
{
    public partial class CategoryForm : MaterialForm
    {
        string situacion;
        int id_editar;
        public CategoryForm()
        {
            InitializeComponent();
            combox_activo.Items.Add("Activo");
            combox_activo.Items.Add("Desactivado");
            situacion = "creacion";

        }
        public CategoryForm(Categoria categoria)
        {
            InitializeComponent();
            id_editar = categoria.Id;

            txt_nombre.Text = categoria.Nombre_categoria.ToString();
            combox_activo.Items.Add("Activo");
            combox_activo.Items.Add("Desactivado");

            situacion = "edicion";
            label_titulo.Text = "Editar Categoria";
            btn_crear.Text = "Editar";

        }

        private void btn_crear_Click_1(object sender, EventArgs e)
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
            if(Validaciones.textVacios(txt_nombre) == false)
            {
                int activo = 0;
                if (combox_activo.SelectedItem.ToString() == "Activo")
                {
                    activo = 1;
                }
                else
                {
                    activo = 2;
                }
                Categoria cat = new Categoria(0, txt_nombre.Text, activo);
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
        }
        private void editar()
        {
            int activo = 0;
            if (combox_activo.SelectedItem.ToString() == "Activo")
            {
                activo = 1;
            }
            else
            {
                activo = 2;
            }
            if (Validaciones.textVacios(txt_nombre) == false) 
            { 
                Categoria cat = new Categoria(id_editar, txt_nombre.Text, activo);
                if (Categoria_Controller.editarCategoria(cat))
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {

        }

        private void txt_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Dato inválido, sólo números", "Alerta", (MessageBoxButtons)MessageBoxButton.OK, (MessageBoxIcon)(MessageBoxImage)MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txt_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Dato inválido, sólo letras", "Alerta", (MessageBoxButtons)MessageBoxButton.OK, (MessageBoxIcon)(MessageBoxImage)MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        ErrorProvider errorP = new ErrorProvider();
        private void txt_nombre_Leave(object sender, EventArgs e)
        {
            if (Validaciones.textVacios(txt_nombre))
                errorP.SetError(txt_nombre, "No puede dejar vacio");
            else
                errorP.Clear();
        }

        private void txt_id_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
