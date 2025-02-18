﻿using EjemploABM.Modelo;
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
            if (!Validaciones.textVacios(txt_nombre))
            {
                string nombreCategoria = txt_nombre.Text;

                if (Categoria_Controller.VerificarCategoriaExistente(nombreCategoria))
                {
                    MessageBox.Show("La categoría que intenta crear ya existe.");
                }
                else
                {
                    Categoria cat = new Categoria(0, nombreCategoria);

                    if (Categoria_Controller.CrearCategoria(cat))
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            else
            {
                MessageBox.Show("El nombre de la categoría no puede estar vacío.");
            }
        }

        private void editar()
        {
            if (Validaciones.textVacios(txt_nombre) == false) 
            { 
                Categoria cat = new Categoria(id_editar, txt_nombre.Text);
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
