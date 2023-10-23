
namespace EjemploABM
{
    partial class Index
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
            this.btn_prods = new System.Windows.Forms.Button();
            this.btn_cats = new System.Windows.Forms.Button();
            this.btn_users = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_ofertas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_prods
            // 
            this.btn_prods.Location = new System.Drawing.Point(9, 5);
            this.btn_prods.Name = "btn_prods";
            this.btn_prods.Size = new System.Drawing.Size(75, 23);
            this.btn_prods.TabIndex = 0;
            this.btn_prods.Text = "Productos";
            this.btn_prods.UseVisualStyleBackColor = true;
            this.btn_prods.Click += new System.EventHandler(this.btn_prods_Click);
            // 
            // btn_cats
            // 
            this.btn_cats.Location = new System.Drawing.Point(1193, 5);
            this.btn_cats.Name = "btn_cats";
            this.btn_cats.Size = new System.Drawing.Size(75, 23);
            this.btn_cats.TabIndex = 1;
            this.btn_cats.Text = "Categorias";
            this.btn_cats.UseVisualStyleBackColor = true;
            this.btn_cats.Click += new System.EventHandler(this.btn_cats_Click);
            // 
            // btn_users
            // 
            this.btn_users.Location = new System.Drawing.Point(1112, 5);
            this.btn_users.Name = "btn_users";
            this.btn_users.Size = new System.Drawing.Size(75, 23);
            this.btn_users.TabIndex = 3;
            this.btn_users.Text = "Usuarios";
            this.btn_users.UseVisualStyleBackColor = true;
            this.btn_users.Click += new System.EventHandler(this.btn_users_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(1, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1276, 652);
            this.panel1.TabIndex = 4;
            // 
            // btn_ofertas
            // 
            this.btn_ofertas.Location = new System.Drawing.Point(90, 5);
            this.btn_ofertas.Name = "btn_ofertas";
            this.btn_ofertas.Size = new System.Drawing.Size(75, 23);
            this.btn_ofertas.TabIndex = 5;
            this.btn_ofertas.Text = "Ofertas";
            this.btn_ofertas.UseVisualStyleBackColor = true;
            this.btn_ofertas.Click += new System.EventHandler(this.btn_ofertas_Click);
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 709);
            this.Controls.Add(this.btn_ofertas);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_users);
            this.Controls.Add(this.btn_cats);
            this.Controls.Add(this.btn_prods);
            this.Name = "Index";
            this.Text = "Index";
            this.Load += new System.EventHandler(this.Index_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_prods;
        private System.Windows.Forms.Button btn_cats;
        private System.Windows.Forms.Button btn_users;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_ofertas;
    }
}