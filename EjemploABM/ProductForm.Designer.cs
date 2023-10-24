namespace SalesGamer
{
    partial class ProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.txt_descripcion = new System.Windows.Forms.TextBox();
            this.txt_precio = new System.Windows.Forms.TextBox();
            this.txt_cantidad = new System.Windows.Forms.TextBox();
            this.combox_distribuidor = new System.Windows.Forms.ComboBox();
            this.combox_oferta = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.combox_categoria = new System.Windows.Forms.ComboBox();
            this.btn_agregar = new MaterialSkin.Controls.MaterialButton();
            this.label8 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descripcion:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Precio:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(183, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Cantidad:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(429, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Distribuidor:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(429, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Oferta:";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(254, 119);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.ShortcutsEnabled = false;
            this.txt_nombre.Size = new System.Drawing.Size(130, 20);
            this.txt_nombre.TabIndex = 8;
            this.txt_nombre.TextChanged += new System.EventHandler(this.txt_nombre_TextChanged);
            this.txt_nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_nombre_KeyPress);
            this.txt_nombre.Leave += new System.EventHandler(this.txt_nombre_Leave);
            // 
            // txt_descripcion
            // 
            this.txt_descripcion.Location = new System.Drawing.Point(254, 167);
            this.txt_descripcion.Name = "txt_descripcion";
            this.txt_descripcion.ShortcutsEnabled = false;
            this.txt_descripcion.Size = new System.Drawing.Size(130, 20);
            this.txt_descripcion.TabIndex = 9;
            this.txt_descripcion.Leave += new System.EventHandler(this.txt_descripcion_Leave);
            // 
            // txt_precio
            // 
            this.txt_precio.Location = new System.Drawing.Point(254, 209);
            this.txt_precio.Name = "txt_precio";
            this.txt_precio.ShortcutsEnabled = false;
            this.txt_precio.Size = new System.Drawing.Size(130, 20);
            this.txt_precio.TabIndex = 10;
            this.txt_precio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_precio_KeyPress);
            this.txt_precio.Leave += new System.EventHandler(this.txt_precio_Leave);
            // 
            // txt_cantidad
            // 
            this.txt_cantidad.Location = new System.Drawing.Point(254, 249);
            this.txt_cantidad.Name = "txt_cantidad";
            this.txt_cantidad.ShortcutsEnabled = false;
            this.txt_cantidad.Size = new System.Drawing.Size(130, 20);
            this.txt_cantidad.TabIndex = 11;
            this.txt_cantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cantidad_KeyPress);
            this.txt_cantidad.Leave += new System.EventHandler(this.txt_cantidad_Leave);
            // 
            // combox_distribuidor
            // 
            this.combox_distribuidor.FormattingEnabled = true;
            this.combox_distribuidor.Location = new System.Drawing.Point(500, 164);
            this.combox_distribuidor.Name = "combox_distribuidor";
            this.combox_distribuidor.Size = new System.Drawing.Size(130, 21);
            this.combox_distribuidor.TabIndex = 12;
            this.combox_distribuidor.SelectedIndexChanged += new System.EventHandler(this.combox_distribuidor_SelectedIndexChanged);
            // 
            // combox_oferta
            // 
            this.combox_oferta.FormattingEnabled = true;
            this.combox_oferta.Location = new System.Drawing.Point(500, 211);
            this.combox_oferta.Name = "combox_oferta";
            this.combox_oferta.Size = new System.Drawing.Size(130, 21);
            this.combox_oferta.TabIndex = 13;
            this.combox_oferta.SelectedIndexChanged += new System.EventHandler(this.combox_oferta_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(429, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Categoria:";
            // 
            // combox_categoria
            // 
            this.combox_categoria.FormattingEnabled = true;
            this.combox_categoria.Location = new System.Drawing.Point(500, 119);
            this.combox_categoria.Name = "combox_categoria";
            this.combox_categoria.Size = new System.Drawing.Size(130, 21);
            this.combox_categoria.TabIndex = 18;
            this.combox_categoria.SelectedIndexChanged += new System.EventHandler(this.combox_categoria_SelectedIndexChanged);
            // 
            // btn_agregar
            // 
            this.btn_agregar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_agregar.Depth = 0;
            this.btn_agregar.DrawShadows = true;
            this.btn_agregar.HighEmphasis = true;
            this.btn_agregar.Icon = null;
            this.btn_agregar.Location = new System.Drawing.Point(366, 357);
            this.btn_agregar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_agregar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(67, 36);
            this.btn_agregar.TabIndex = 20;
            this.btn_agregar.Text = "Crear";
            this.btn_agregar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_agregar.UseAccentColor = false;
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Depth = 0;
            this.label8.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label8.Location = new System.Drawing.Point(346, 35);
            this.label8.MouseState = MaterialSkin.MouseState.HOVER;
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 19);
            this.label8.TabIndex = 21;
            this.label8.Text = "Crear Producto";
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.combox_categoria);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.combox_oferta);
            this.Controls.Add(this.combox_distribuidor);
            this.Controls.Add(this.txt_cantidad);
            this.Controls.Add(this.txt_precio);
            this.Controls.Add(this.txt_descripcion);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "ProductForm";
            this.Load += new System.EventHandler(this.ProductForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.TextBox txt_descripcion;
        private System.Windows.Forms.TextBox txt_precio;
        private System.Windows.Forms.TextBox txt_cantidad;
        private System.Windows.Forms.ComboBox combox_distribuidor;
        private System.Windows.Forms.ComboBox combox_oferta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox combox_categoria;
        private MaterialSkin.Controls.MaterialButton btn_agregar;
        private MaterialSkin.Controls.MaterialLabel label8;
    }
}