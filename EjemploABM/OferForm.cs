using EjemploABM.Modelo;
using SalesGamer.Controladores;
using SalesGamer.ControlesDeUsuario;
using SalesGamer.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace SalesGamer
{
    public partial class OferForm : MaterialForm
    {
        string situacion;
        int id_editar;
        public OferForm()
        {
            InitializeComponent();
            situacion = "creacion";

        }
        public OferForm(Oferta oferta)
        {
            InitializeComponent();
            id_editar = oferta.Id;

            text_nombre.Text = oferta.Nombre.ToString();
            text_tipo.Text = oferta.Tipo_oferta.ToString();
            date_inicio.Text = oferta.Fecha_inicio.ToString();
            date_final.Text = oferta.Fecha_final.ToString();
            text_condiciones.Text = oferta.Condiciones.ToString();
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
            string fechaInicioTexto = date_inicio.Text;
            string fechaFinalTexto = date_final.Text;

            if (DateTime.TryParse(fechaInicioTexto, out DateTime fechaInicio) && DateTime.TryParse(fechaFinalTexto, out DateTime fechaFinal))
            {
                if (!Oferta_Controller.VerificarOfertaExistente(text_nombre.Text))
                {
                    Oferta ofer = new Oferta(0, text_nombre.Text, text_tipo.Text, fechaInicio, fechaFinal, text_condiciones.Text);

                    if (text_tipo.Text == "10% descuento" || text_tipo.Text == "20% descuento" ||
                        text_tipo.Text == "30% descuento" || text_tipo.Text == "50% descuento" ||
                        text_tipo.Text == "sin descuento")
                    {
                        DialogResult result = MessageBox.Show("La oferta que se intentó crear ya existe");
                    }
                    else if (Oferta_Controller.CrearOferta(ofer))
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    MessageBox.Show("¡La oferta ya existe en la base de datos!");
                }
            }
            else
            {
                MessageBox.Show("Las fechas ingresadas no son válidas.");
            }
        }

        private void editar()
        {
            string fechaInicioTexto = date_inicio.Text;
            string fechaFinalTexto = date_final.Text;
            if (DateTime.TryParse(fechaInicioTexto, out DateTime fechaInicio) && DateTime.TryParse(fechaFinalTexto, out DateTime fechaFinal))
            {
                Oferta ofer = new Oferta(id_editar, text_nombre.Text, text_tipo.Text, fechaInicio, fechaFinal, text_condiciones.Text);
                if (Oferta_Controller.editarOferta(ofer))
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("Las fechas ingresadas no son válidas.");
            }
        }

        private void OfertaForm_Load(object sender, EventArgs e)
        {

        }

    }
}
