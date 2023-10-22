namespace SalesGamer.ControlesDeUsuario
{
    partial class Oferta_UC
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
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_Final = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Condiciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_titulo = new System.Windows.Forms.Label();
            this.btn_crear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nombre,
            this.Tipo,
            this.Fecha_inicio,
            this.Fecha_Final,
            this.Condiciones});
            this.dataGridView1.Location = new System.Drawing.Point(31, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(646, 482);
            this.dataGridView1.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            // 
            // Fecha_inicio
            // 
            this.Fecha_inicio.HeaderText = "Fecha Inicio";
            this.Fecha_inicio.Name = "Fecha_inicio";
            // 
            // Fecha_Final
            // 
            this.Fecha_Final.HeaderText = "Fecha Final";
            this.Fecha_Final.Name = "Fecha_Final";
            // 
            // Condiciones
            // 
            this.Condiciones.HeaderText = "Condiciones";
            this.Condiciones.Name = "Condiciones";
            // 
            // btn_titulo
            // 
            this.btn_titulo.AutoSize = true;
            this.btn_titulo.Location = new System.Drawing.Point(28, 24);
            this.btn_titulo.Name = "btn_titulo";
            this.btn_titulo.Size = new System.Drawing.Size(44, 13);
            this.btn_titulo.TabIndex = 1;
            this.btn_titulo.Text = "Ofertas:";
            // 
            // btn_crear
            // 
            this.btn_crear.Location = new System.Drawing.Point(315, 16);
            this.btn_crear.Name = "btn_crear";
            this.btn_crear.Size = new System.Drawing.Size(66, 29);
            this.btn_crear.TabIndex = 2;
            this.btn_crear.Text = "Crear";
            this.btn_crear.UseVisualStyleBackColor = true;
            // 
            // Oferta_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_crear);
            this.Controls.Add(this.btn_titulo);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Oferta_UC";
            this.Size = new System.Drawing.Size(713, 583);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Final;
        private System.Windows.Forms.DataGridViewTextBoxColumn Condiciones;
        private System.Windows.Forms.Label btn_titulo;
        private System.Windows.Forms.Button btn_crear;
    }
}
