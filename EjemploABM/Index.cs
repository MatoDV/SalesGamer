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

namespace EjemploABM
{
    public partial class Index : MaterialForm
    {
        public Index()
        {
            InitializeComponent();


            Productos_UC prodsUC = new Productos_UC();
            addUserControl(prodsUC);

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
            Productos_UC prodsUC = new Productos_UC();
            addUserControl(prodsUC);
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
    }
}
