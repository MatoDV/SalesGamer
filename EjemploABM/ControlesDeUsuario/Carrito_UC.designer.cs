namespace SalesGamer.ControlesDeUsuario
{
    partial class Carrito_UC
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btn_comprar = new MaterialSkin.Controls.MaterialButton();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oferta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.agregar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btn_agregarOtro = new MaterialSkin.Controls.MaterialButton();
            this.txt_Precio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Nombre,
            this.Cantidad,
            this.Precio,
            this.oferta,
            this.Eliminar,
            this.agregar});
            this.dataGridView1.Location = new System.Drawing.Point(62, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(754, 404);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(390, 19);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(48, 19);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "Carrito";
            // 
            // btn_comprar
            // 
            this.btn_comprar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_comprar.Depth = 0;
            this.btn_comprar.DrawShadows = true;
            this.btn_comprar.HighEmphasis = true;
            this.btn_comprar.Icon = null;
            this.btn_comprar.Location = new System.Drawing.Point(366, 477);
            this.btn_comprar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_comprar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_comprar.Name = "btn_comprar";
            this.btn_comprar.Size = new System.Drawing.Size(91, 36);
            this.btn_comprar.TabIndex = 2;
            this.btn_comprar.Text = "Comprar";
            this.btn_comprar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_comprar.UseAccentColor = false;
            this.btn_comprar.UseVisualStyleBackColor = true;
            this.btn_comprar.Click += new System.EventHandler(this.btn_comprar_Click);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio Unitario";
            this.Precio.Name = "Precio";
            // 
            // oferta
            // 
            this.oferta.HeaderText = "Descuento";
            this.oferta.Name = "oferta";
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Eliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // agregar
            // 
            this.agregar.HeaderText = "Agregar";
            this.agregar.Name = "agregar";
            // 
            // btn_agregarOtro
            // 
            this.btn_agregarOtro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_agregarOtro.Depth = 0;
            this.btn_agregarOtro.DrawShadows = true;
            this.btn_agregarOtro.HighEmphasis = true;
            this.btn_agregarOtro.Icon = null;
            this.btn_agregarOtro.Location = new System.Drawing.Point(647, 477);
            this.btn_agregarOtro.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_agregarOtro.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_agregarOtro.Name = "btn_agregarOtro";
            this.btn_agregarOtro.Size = new System.Drawing.Size(130, 36);
            this.btn_agregarOtro.TabIndex = 3;
            this.btn_agregarOtro.Text = "Agregar otro";
            this.btn_agregarOtro.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_agregarOtro.UseAccentColor = false;
            this.btn_agregarOtro.UseVisualStyleBackColor = true;
            this.btn_agregarOtro.Click += new System.EventHandler(this.btn_agregarOtro_Click);
            // 
            // txt_Precio
            // 
            this.txt_Precio.AutoSize = true;
            this.txt_Precio.Location = new System.Drawing.Point(59, 489);
            this.txt_Precio.Name = "txt_Precio";
            this.txt_Precio.Size = new System.Drawing.Size(63, 13);
            this.txt_Precio.TabIndex = 4;
            this.txt_Precio.Text = "Precio total:";
            // 
            // Carrito_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_Precio);
            this.Controls.Add(this.btn_agregarOtro);
            this.Controls.Add(this.btn_comprar);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Carrito_UC";
            this.Size = new System.Drawing.Size(857, 553);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialButton btn_comprar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn oferta;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
        private System.Windows.Forms.DataGridViewButtonColumn agregar;
        private MaterialSkin.Controls.MaterialButton btn_agregarOtro;
        private System.Windows.Forms.Label txt_Precio;
    }
}
