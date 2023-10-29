using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EjemploABM.Controladores;
using SalesGamer;
using MaterialSkin;
using MaterialSkin.Controls;

namespace EjemploABM
{
    public partial class Login : MaterialForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        ErrorProvider errorP = new ErrorProvider();
        private void txt_login_user_Leave(object sender, EventArgs e)
        {
            if (Validaciones.textVacios(txt_login_user))
                errorP.SetError(txt_login_user, "No puede dejar vacio");
            else
                errorP.Clear();
        }

        private void txt_login_pass_Leave(object sender, EventArgs e)
        {
            if (Validaciones.textVacios(txt_login_pass))
                errorP.SetError(txt_login_pass, "No puede dejar vacio");
            else
                errorP.Clear();

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btn_login_Click_1(object sender, EventArgs e)
        {
            if (Validaciones.textVacios(txt_login_user) == false || Validaciones.textVacios(txt_login_pass) == false)
            {
                if (Usuario_Controller.autenticar(txt_login_user.Text, txt_login_pass.Text, true))
                {
                    Index index = new Index();
                    index.Show();
                    this.Hide();
                }
                else
                {
                    // Mostrar un mensaje de error indicando que la autenticación ha fallado
                    MessageBox.Show("Error: Nombre de usuario o contraseña incorrectos", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Mostrar un mensaje de error indicando que los campos están vacíos
                MessageBox.Show("Error: Nombre de usuario y contraseña son obligatorios", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
