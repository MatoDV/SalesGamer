namespace SalesGamer
{
    partial class CategoryForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.btn_crear = new MaterialSkin.Controls.MaterialButton();
            this.label_titulo = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(312, 175);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.ShortcutsEnabled = false;
            this.txt_nombre.Size = new System.Drawing.Size(146, 20);
            this.txt_nombre.TabIndex = 2;
            this.txt_nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_nombre_KeyPress);
            this.txt_nombre.Leave += new System.EventHandler(this.txt_nombre_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "ID:";
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(312, 145);
            this.txt_id.Name = "txt_id";
            this.txt_id.ShortcutsEnabled = false;
            this.txt_id.Size = new System.Drawing.Size(146, 20);
            this.txt_id.TabIndex = 5;
            this.txt_id.TextChanged += new System.EventHandler(this.txt_id_TextChanged);
            this.txt_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_id_KeyPress);
            this.txt_id.Leave += new System.EventHandler(this.txt_id_Leave);
            // 
            // btn_crear
            // 
            this.btn_crear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_crear.Depth = 0;
            this.btn_crear.DrawShadows = true;
            this.btn_crear.HighEmphasis = true;
            this.btn_crear.Icon = null;
            this.btn_crear.Location = new System.Drawing.Point(341, 252);
            this.btn_crear.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_crear.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_crear.Name = "btn_crear";
            this.btn_crear.Size = new System.Drawing.Size(67, 36);
            this.btn_crear.TabIndex = 8;
            this.btn_crear.Text = "Crear";
            this.btn_crear.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_crear.UseAccentColor = false;
            this.btn_crear.UseVisualStyleBackColor = true;
            this.btn_crear.Click += new System.EventHandler(this.btn_crear_Click_1);
            // 
            // label_titulo
            // 
            this.label_titulo.AutoSize = true;
            this.label_titulo.Depth = 0;
            this.label_titulo.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label_titulo.Location = new System.Drawing.Point(329, 35);
            this.label_titulo.MouseState = MaterialSkin.MouseState.HOVER;
            this.label_titulo.Name = "label_titulo";
            this.label_titulo.Size = new System.Drawing.Size(110, 19);
            this.label_titulo.TabIndex = 9;
            this.label_titulo.Text = "Crear Categoria";
            // 
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_titulo);
            this.Controls.Add(this.btn_crear);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.label1);
            this.Name = "CategoryForm";
            this.Load += new System.EventHandler(this.CategoryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_id;
        private MaterialSkin.Controls.MaterialButton btn_crear;
        private MaterialSkin.Controls.MaterialLabel label_titulo;
    }
}