﻿using EjemploABM;
using EjemploABM.Modelo;
using SalesGamer.Controladores;
using SalesGamer.Modelo;
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

namespace SalesGamer.ControlesDeUsuario
{
    public partial class Oferta_UC : UserControl
    {
        private List<Oferta> ofertas;
        private int numeroPagina = 1;
        private int elementosPorPagina = 5;
        public Oferta_UC()
        {
            InitializeComponent();
            cargarOfertas();
            if (Program.logueado.ID_rol != 1)
            {
                btn_crear.Hide();
            }
        }
        private void cargarOfertas()
        {
            ofertas = Oferta_Controller.obtenerOferta(numeroPagina, elementosPorPagina);
            dataGridView1.Rows.Clear();
            foreach (Oferta ofer in ofertas)
            {
                int rowIndex = dataGridView1.Rows.Add();
                if (Program.logueado.ID_rol != 1)
                {
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[7].Visible = false;


                }
                dataGridView1.Rows[rowIndex].Cells[0].Value = ofer.Id.ToString();
                dataGridView1.Rows[rowIndex].Cells[1].Value = ofer.Nombre.ToString();
                dataGridView1.Rows[rowIndex].Cells[2].Value = ofer.Tipo_oferta.ToString();
                dataGridView1.Rows[rowIndex].Cells[3].Value = ofer.Fecha_inicio.ToString();
                dataGridView1.Rows[rowIndex].Cells[4].Value = ofer.Fecha_final.ToString();
                dataGridView1.Rows[rowIndex].Cells[5].Value = ofer.Condiciones.ToString();
                dataGridView1.Rows[rowIndex].Cells[6].Value = "Editar";
                dataGridView1.Rows[rowIndex].Cells[7].Value = "Eliminar";
            }
            txt_pagina.Text = $"Página: {numeroPagina}";
        }
        private void Oferta_UC_Load(object sender, EventArgs e)
        {

        }

        private void btn_crear_Click(object sender, EventArgs e)
        {
            OferForm frmOfer = new OferForm();
            DialogResult dr = frmOfer.ShowDialog();

            if (dr == DialogResult.OK)
            {
                Trace.WriteLine("OK");
                //ACTUALIZAR LA LISTA
                cargarOfertas();

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

                Oferta ofer_editar = Oferta_Controller.ObtenerOfertaID(id);

                OferForm frmOfer = new OferForm(ofer_editar);

                DialogResult dr = frmOfer.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    Trace.WriteLine("OK");
                    //ACTUALIZAR LA LISTA
                    cargarOfertas();

                }
            }

            if (senderGrid.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                //Eliminamos

                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());


                Oferta ofer_eliminar = Oferta_Controller.ObtenerOfertaID(id);

                // Confirmar la eliminación con un mensaje de confirmación
                DialogResult result = MessageBox.Show("¿Estás seguro que quieres eliminar este producto?", "Confirmar eliminación", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {

                    bool eliminacionExitosa = Oferta_Controller.eliminarOferta(ofer_eliminar);

                    if (eliminacionExitosa)
                    {
                        MessageBox.Show("Producto eliminado exitosamente.");
                        cargarOfertas();
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
                cargarOfertas(); // Volver a cargar los productos con la nueva página
            }

        }

        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            numeroPagina++; // Aumentar el número de página
            cargarOfertas();
        }
    }
}

