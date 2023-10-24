namespace SalesGamer
{
    partial class CarritoForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label_titulo = new MaterialSkin.Controls.MaterialLabel();
            this.btn_comprar = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(138, 80);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(543, 464);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label_titulo
            // 
            this.label_titulo.AutoSize = true;
            this.label_titulo.BackColor = System.Drawing.SystemColors.Control;
            this.label_titulo.Depth = 0;
            this.label_titulo.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label_titulo.Location = new System.Drawing.Point(372, 33);
            this.label_titulo.MouseState = MaterialSkin.MouseState.HOVER;
            this.label_titulo.Name = "label_titulo";
            this.label_titulo.Size = new System.Drawing.Size(48, 19);
            this.label_titulo.TabIndex = 3;
            this.label_titulo.Text = "Carrito";
            // 
            // btn_comprar
            // 
            this.btn_comprar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_comprar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_comprar.Depth = 0;
            this.btn_comprar.DrawShadows = true;
            this.btn_comprar.HighEmphasis = true;
            this.btn_comprar.Icon = null;
            this.btn_comprar.Location = new System.Drawing.Point(359, 553);
            this.btn_comprar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_comprar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_comprar.Name = "btn_comprar";
            this.btn_comprar.Size = new System.Drawing.Size(91, 36);
            this.btn_comprar.TabIndex = 4;
            this.btn_comprar.Text = "Comprar";
            this.btn_comprar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_comprar.UseAccentColor = false;
            this.btn_comprar.UseVisualStyleBackColor = false;
            this.btn_comprar.Click += new System.EventHandler(this.btn_comprar_Click_1);
            // 
            // CarritoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(834, 604);
            this.Controls.Add(this.btn_comprar);
            this.Controls.Add(this.label_titulo);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CarritoForm";
            this.Load += new System.EventHandler(this.CarritoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private MaterialSkin.Controls.MaterialLabel label_titulo;
        private MaterialSkin.Controls.MaterialButton btn_comprar;
    }
}