using EjemploABM.Controladores;
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
using System.IO;
using SalesGamer.Modelo;

namespace SalesGamer
{
    public partial class ProductForm : MaterialForm
    {
        
        List<Categoria> listaCategorias = Categoria_Controller.obtenerCategoria(1, 999);
        List<Oferta> listaOferta = Oferta_Controller.obtenerOferta(1, 999);
        List<Distribuidor> listaDistribuidor = Distribuidor_Controller.obtenerDistribuidor();
        string situacion;
        int id_editar;
        public ProductForm()
        {
            InitializeComponent();

            combox_distribuidor.Items.Clear();
            combox_oferta.Items.Clear();
            combox_categoria.Items.Clear();

            combox_distribuidor.DataSource = listaDistribuidor;
            combox_distribuidor.DisplayMember = "nombre_empresa";
            combox_oferta.DataSource = listaOferta;
            combox_oferta.DisplayMember = "Tipo_oferta";
            combox_categoria.DataSource = listaCategorias;
            combox_categoria.DisplayMember = "Nombre_categoria";



            situacion = "creacion";
        }

        // SOBRECARGAR EL CONSTRUCTOR PARA INICIAR EL FORM CON LA INFO CARGADA, PARA EDITAR
        public ProductForm(Producto producto)
        {
            InitializeComponent();

            id_editar = producto.Id;

            txt_nombre.Text = producto.Nombre_producto.ToString();
            txt_descripcion.Text = producto.Descripcion.ToString();
            txt_precio.Text = producto.Precio.ToString();
            txt_cantidad.Text = producto.Cantidad.ToString();
            imgbox_producto.ImageLocation = producto.img;

            combox_distribuidor.DataSource = listaDistribuidor;
            combox_distribuidor.DisplayMember = "nombre_empresa";
            combox_oferta.DataSource = listaOferta;
            combox_oferta.DisplayMember = "Tipo_oferta";
            combox_categoria.DataSource = listaCategorias;
            combox_categoria.DisplayMember = "Nombre_categoria";


            situacion = "edicion";

            label8.Text = "Editar Producto";
            btn_agregar.Text = "Editar";


        }

        private void btn_agregar_Click_1(object sender, EventArgs e)
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
        private void btn_añadirIMG_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string rutaImagen = openFileDialog1.FileName; // Obtener la ruta de la imagen seleccionada
                imgbox_producto.Image = new Bitmap(rutaImagen); // Cargar la imagen en el PictureBox

                string nombreArchivo = Path.GetFileName(rutaImagen); // Obtener el nombre del archivo

                string carpetaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // Obtener la carpeta Documentos del usuario

                string rutaCarpetaImg = Path.Combine(carpetaDocumentos, "img"); // Ruta de la carpeta 'img' en Documentos

                if (!Directory.Exists(rutaCarpetaImg))
                {
                    Directory.CreateDirectory(rutaCarpetaImg); // Crear la carpeta 'img' si no existe
                }

                string rutaDestino = Path.Combine(rutaCarpetaImg, nombreArchivo); // Ruta completa de destino

                try
                {
                    File.Copy(rutaImagen, rutaDestino, true); // Copiar la imagen a la carpeta 'img' en Documentos
                    MessageBox.Show("Imagen cargada y guardada en la carpeta 'img' en Documentos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se seleccionó ninguna imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void crear()
        {
            if(Validaciones.textVacios(txt_nombre) == false || Validaciones.textVacios(txt_descripcion) == false || Validaciones.textVacios(txt_cantidad) == false || Validaciones.textVacios(txt_precio) == false)
            {
                Distribuidor distribuidorSeleccionado = (Distribuidor)combox_distribuidor.SelectedItem;
                int distribuidorId = distribuidorSeleccionado.Id;

                Categoria categoriaSeleccionada = (Categoria)combox_categoria.SelectedItem;
                int categoriaId = categoriaSeleccionada.Id;

                Oferta ofertaSeleccionada = (Oferta)combox_oferta.SelectedItem;
                int ofertaId = ofertaSeleccionada.Id;

                int precio;
                int cantidad;
                string rutaImagen = "";
                if (int.TryParse(txt_precio.Text, out precio) && int.TryParse(txt_cantidad.Text, out cantidad))
                {
                    Producto prod = new Producto(0, txt_nombre.Text, txt_descripcion.Text, precio, cantidad, distribuidorId, ofertaId, rutaImagen, categoriaId);
                    if (Producto_Controller.CrearProducto(prod))
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                }
            
            }

        }

        private void editar()
        {
            if (Validaciones.textVacios(txt_nombre) == false || Validaciones.textVacios(txt_descripcion) == false || Validaciones.textVacios(txt_cantidad) == false || Validaciones.textVacios(txt_precio) == false)
            {
                Distribuidor distribuidorSeleccionado = (Distribuidor)combox_distribuidor.SelectedItem;
                int distribuidorId = distribuidorSeleccionado.Id;

                Categoria categoriaSeleccionada = (Categoria)combox_categoria.SelectedItem;
                int categoriaId = categoriaSeleccionada.Id;

                Oferta ofertaSeleccionada = (Oferta)combox_oferta.SelectedItem;
                int ofertaId = ofertaSeleccionada.Id;

                int precio;
                int cantidad;
                string rutaImagen = "";

                if (int.TryParse(txt_precio.Text, out precio) && int.TryParse(txt_cantidad.Text, out cantidad))
                {
                    Producto prod = new Producto(0, txt_nombre.Text, txt_descripcion.Text, precio, cantidad, distribuidorId, ofertaId, rutaImagen, categoriaId);
                    if (Producto_Controller.editarProducto(prod))
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                }
            
            }

        }
        

        private void combox_distribuidor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void combox_oferta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void combox_categoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ProductForm_Load(object sender, EventArgs e)
        {

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

        private void txt_descripcion_Leave(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Dato inválido, sólo letras", "Alerta", (MessageBoxButtons)MessageBoxButton.OK, (MessageBoxIcon)(MessageBoxImage)MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void txt_precio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Dato inválido, sólo números", "Alerta", (MessageBoxButtons)MessageBoxButton.OK, (MessageBoxIcon)(MessageBoxImage)MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Dato inválido, sólo números", "Alerta", (MessageBoxButtons)MessageBoxButton.OK, (MessageBoxIcon)(MessageBoxImage)MessageBoxIcon.Exclamation);
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

        private void txt_descripcion_Leave(object sender, EventArgs e)
        {
            if (Validaciones.textVacios(txt_descripcion))
                errorP.SetError(txt_descripcion, "No puede dejar vacio");
            else
                errorP.Clear();
        }

        private void txt_precio_Leave(object sender, EventArgs e)
        {
            if (Validaciones.textVacios(txt_precio))
                errorP.SetError(txt_precio, "No puede dejar vacio");
            else
                errorP.Clear();
        }

        private void txt_cantidad_Leave(object sender, EventArgs e)
        {
            if (Validaciones.textVacios(txt_cantidad))
                errorP.SetError(txt_cantidad, "No puede dejar vacio");
            else
                errorP.Clear();
        }

        private void txt_nombre_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
