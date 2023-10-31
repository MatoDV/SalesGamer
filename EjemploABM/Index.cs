using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EjemploABM.ControlesDeUsuario;
using SalesGamer.ControlesDeUsuario;
using MaterialSkin;
using MaterialSkin.Controls;
using SalesGamer.Controladores;

namespace EjemploABM
{
    public partial class Index : MaterialForm
    {
        Carrito_Controller carritoController = new Carrito_Controller();
        public Index()
        {
            InitializeComponent();


            Productos_UC productosUC = new Productos_UC(carritoController);
            addUserControl(productosUC);

            if(Program.logueado.ID_rol != 1)
            {
                btn_users.Hide();
                btn_cats.Hide();
            }
        }

        private void addUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(uc);
            uc.BringToFront();
        }

        private void Index_Load(object sender, EventArgs e)
        {

        }

        private void btn_prods_Click_1(object sender, EventArgs e)
        {
            Productos_UC productosUC = new Productos_UC(carritoController);
            addUserControl(productosUC);
        }

        private void btn_ofertas_Click_1(object sender, EventArgs e)
        {
            Oferta_UC ofertaUC = new Oferta_UC();
            addUserControl(ofertaUC);
        }

        private void btn_users_Click_1(object sender, EventArgs e)
        {
            Usuarios_UC userUC = new Usuarios_UC();
            addUserControl(userUC);
        }

        private void btn_cats_Click_1(object sender, EventArgs e)
        {
            Categorias_UC catsUC = new Categorias_UC();
            addUserControl(catsUC);
        }

        private void btn_cerrarSesion_Click(object sender, EventArgs e)
        {
            Login formLogin = new Login();
            formLogin.Show();
            this.Hide();
        }

        private void btn_carrito_Click(object sender, EventArgs e)
        {
            Carrito_UC carritoUC = new Carrito_UC(carritoController);
            addUserControl(carritoUC);
        }
    }
}
