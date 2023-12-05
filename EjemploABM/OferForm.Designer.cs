namespace SalesGamer
{
    partial class OferForm
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
            this.text_nombre = new System.Windows.Forms.TextBox();
            this.text_tipo = new System.Windows.Forms.TextBox();
            this.label_nombre = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.text_condiciones = new System.Windows.Forms.TextBox();
            this.date_inicio = new System.Windows.Forms.DateTimePicker();
            this.date_final = new System.Windows.Forms.DateTimePicker();
            this.btn_crear = new MaterialSkin.Controls.MaterialButton();
            this.label_titulo = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // text_nombre
            // 
            this.text_nombre.Location = new System.Drawing.Point(306, 131);
            this.text_nombre.Name = "text_nombre";
            this.text_nombre.Size = new System.Drawing.Size(169, 20);
            this.text_nombre.TabIndex = 1;
            // 
            // text_tipo
            // 
            this.text_tipo.Location = new System.Drawing.Point(306, 174);
            this.text_tipo.Name = "text_tipo";
            this.text_tipo.Size = new System.Drawing.Size(169, 20);
            this.text_tipo.TabIndex = 3;
            // 
            // label_nombre
            // 
            this.label_nombre.AutoSize = true;
            this.label_nombre.Location = new System.Drawing.Point(226, 134);
            this.label_nombre.Name = "label_nombre";
            this.label_nombre.Size = new System.Drawing.Size(47, 13);
            this.label_nombre.TabIndex = 4;
            this.label_nombre.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tipo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fecha Inicio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(226, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Condiciones:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(226, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fecha Final:";
            // 
            // text_condiciones
            // 
            this.text_condiciones.Location = new System.Drawing.Point(306, 311);
            this.text_condiciones.Name = "text_condiciones";
            this.text_condiciones.Size = new System.Drawing.Size(169, 20);
            this.text_condiciones.TabIndex = 7;
            // 
            // date_inicio
            // 
            this.date_inicio.Location = new System.Drawing.Point(306, 218);
            this.date_inicio.Name = "date_inicio";
            this.date_inicio.Size = new System.Drawing.Size(169, 20);
            this.date_inicio.TabIndex = 12;
            // 
            // date_final
            // 
            this.date_final.Location = new System.Drawing.Point(306, 265);
            this.date_final.Name = "date_final";
            this.date_final.Size = new System.Drawing.Size(169, 20);
            this.date_final.TabIndex = 13;
            // 
            // btn_crear
            // 
            this.btn_crear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_crear.Depth = 0;
            this.btn_crear.DrawShadows = true;
            this.btn_crear.HighEmphasis = true;
            this.btn_crear.Icon = null;
            this.btn_crear.Location = new System.Drawing.Point(348, 380);
            this.btn_crear.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_crear.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_crear.Name = "btn_crear";
            this.btn_crear.Size = new System.Drawing.Size(67, 36);
            this.btn_crear.TabIndex = 14;
            this.btn_crear.Text = "Crear";
            this.btn_crear.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_crear.UseAccentColor = false;
            this.btn_crear.UseVisualStyleBackColor = true;
            this.btn_crear.Click += new System.EventHandler(this.btn_crear_Click);
            // 
            // label_titulo
            // 
            this.label_titulo.AutoSize = true;
            this.label_titulo.Depth = 0;
            this.label_titulo.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label_titulo.Location = new System.Drawing.Point(345, 36);
            this.label_titulo.MouseState = MaterialSkin.MouseState.HOVER;
            this.label_titulo.Name = "label_titulo";
            this.label_titulo.Size = new System.Drawing.Size(86, 19);
            this.label_titulo.TabIndex = 15;
            this.label_titulo.Text = "Crear Oferta";
            // 
            // OferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 548);
            this.Controls.Add(this.label_titulo);
            this.Controls.Add(this.btn_crear);
            this.Controls.Add(this.date_final);
            this.Controls.Add(this.date_inicio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.text_condiciones);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_nombre);
            this.Controls.Add(this.text_tipo);
            this.Controls.Add(this.text_nombre);
            this.Name = "OferForm";
            this.Load += new System.EventHandler(this.OfertaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox text_nombre;
        private System.Windows.Forms.TextBox text_tipo;
        private System.Windows.Forms.Label label_nombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox text_condiciones;
        private System.Windows.Forms.DateTimePicker date_inicio;
        private System.Windows.Forms.DateTimePicker date_final;
        private MaterialSkin.Controls.MaterialButton btn_crear;
        private MaterialSkin.Controls.MaterialLabel label_titulo;
    }
}