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

namespace EjemploABM
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (Usuario_Controller.autenticar(txt_login_user.Text, txt_login_pass.Text, true))
            {
                /*if (MantenerSesion.Checked)
                {
                    Usuario_Controlador.persistirUsuario(Program.logueado);
                }*/

                Index index = new Index();
                index.Show();
                this.Hide();
            }

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
    }
}
