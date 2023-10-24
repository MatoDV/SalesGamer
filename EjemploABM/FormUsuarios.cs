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
using EjemploABM.Controladores;
using EjemploABM.Modelo;
using SalesGamer;
using MessageBox = System.Windows.MessageBox;

namespace EjemploABM
{
    public partial class FormUsuarios : Form
    {
        string situacion;
        int id_editar;

        public FormUsuarios()
        {
            InitializeComponent();

            combo_tipo.Items.Clear();

            combo_tipo.Items.Add("Admin");
            combo_tipo.Items.Add("Vendedor");

            situacion = "creacion";
        }


        // SOBRECARGAR EL CONSTRUCTOR PARA INICIAR EL FORM CON LA INFO CARGADA, PARA EDITAR
        public FormUsuarios(Usuario usr)
        {
            InitializeComponent();

            id_editar = usr.Id;

            txt_usuario.Text = usr.usuario.ToString();
            txt_mail.Text = usr.Mail.ToString();
            txt_contraseña.Text = usr.Contraseña.ToString();
            txt_nombre.Text = usr.Nombre.ToString();
            txt_apellido.Text = usr.Apellido.ToString();
            txt_telefono.Text = $"{usr.Telefono}";
            txt_direccion.Text = usr.Direccion.ToString();


            combo_tipo.Items.Clear();
            combo_tipo.Items.Add("Admin");
            combo_tipo.Items.Add("Vendedor");

            if (usr.ID_rol == 1)
            {
                combo_tipo.SelectedIndex = 0;
            }
            else
            {
                combo_tipo.SelectedIndex = 1;
            }

            situacion = "edicion";

            label2.Text = "Editar Usuario";
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
            int tipo = 2;
            if (combo_tipo.SelectedItem.ToString() == "Admin")
            {
                tipo = 1;
            }

            Usuario usr = new Usuario(0, txt_usuario.Text, txt_mail.Text, txt_contraseña.Text, txt_nombre.Text, txt_apellido.Text,11, txt_direccion.Text,tipo);

            if (Usuario_Controller.crearUsuario(usr))
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void editar()
        {
            int tipo = 2;
            if (combo_tipo.SelectedItem.ToString() == "Admin")
            {
                tipo = 1;
            }

            Usuario usr = new Usuario(id_editar, txt_usuario.Text, txt_mail.Text, txt_contraseña.Text, txt_nombre.Text, txt_apellido.Text, 11, txt_direccion.Text, tipo);

            if (Usuario_Controller.editarUsuario(usr))
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txt_nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64 ) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255)){
                MessageBox.Show("Dato inválido, sólo letras", "Alerta", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txt_apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Dato inválido, sólo letras", "Alerta", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txt_usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Dato inválido, sólo letras", "Alerta", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void txt_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255) )
            {
                MessageBox.Show("Dato inválido, sólo números", "Alerta", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Exclamation);
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

        private void txt_apellido_Leave(object sender, EventArgs e)
        {
            if (Validaciones.textVacios(txt_apellido))
                errorP.SetError(txt_apellido, "No puede dejar vacio");
            else
                errorP.Clear();
        }

        private void txt_mail_Leave(object sender, EventArgs e)
        {
            if (Validaciones.textVacios(txt_mail))
                errorP.SetError(txt_mail, "No puede dejar vacio");
            else
                errorP.Clear();
        }

        private void txt_usuario_Leave(object sender, EventArgs e)
        {
            if (Validaciones.textVacios(txt_usuario))
                errorP.SetError(txt_usuario, "No puede dejar vacio");
            else
                errorP.Clear();
        }

        private void txt_contraseña_Leave(object sender, EventArgs e)
        {
            if (Validaciones.textVacios(txt_contraseña))
                errorP.SetError(txt_contraseña, "No puede dejar vacio");
            else
                errorP.Clear();
        }

        private void txt_telefono_Leave(object sender, EventArgs e)
        {
            if (Validaciones.textVacios(txt_telefono))
                errorP.SetError(txt_telefono, "No puede dejar vacio");
            else
                errorP.Clear();
        }

        private void txt_direccion_Leave(object sender, EventArgs e)
        {
            if (Validaciones.textVacios(txt_direccion))
                errorP.SetError(txt_direccion, "No puede dejar vacio");
            else
                errorP.Clear();
        }
    }
}
