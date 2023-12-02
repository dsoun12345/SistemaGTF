namespace C_Sharp_MYSQL_Busqueda_CodigoBarras
{
    partial class Actualizar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Actualizar));
            this.label1 = new System.Windows.Forms.Label();
            this.btnactualizar1 = new System.Windows.Forms.Button();
            this.btnguardarcambios = new System.Windows.Forms.Button();
            this.txtTrabajosPen = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(54, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(673, 56);
            this.label1.TabIndex = 26;
            this.label1.Text = "Mostrar Trabajos Pendientes";
            // 
            // btnactualizar1
            // 
            this.btnactualizar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.btnactualizar1.FlatAppearance.BorderSize = 0;
            this.btnactualizar1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(211)))), ((int)(((byte)(6)))));
            this.btnactualizar1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnactualizar1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnactualizar1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnactualizar1.Image = ((System.Drawing.Image)(resources.GetObject("btnactualizar1.Image")));
            this.btnactualizar1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnactualizar1.Location = new System.Drawing.Point(839, 47);
            this.btnactualizar1.Name = "btnactualizar1";
            this.btnactualizar1.Size = new System.Drawing.Size(189, 52);
            this.btnactualizar1.TabIndex = 82;
            this.btnactualizar1.Text = "Listar";
            this.btnactualizar1.UseVisualStyleBackColor = false;
            this.btnactualizar1.Click += new System.EventHandler(this.btnactualizar1_Click);
            // 
            // btnguardarcambios
            // 
            this.btnguardarcambios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.btnguardarcambios.FlatAppearance.BorderSize = 0;
            this.btnguardarcambios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(211)))), ((int)(((byte)(6)))));
            this.btnguardarcambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardarcambios.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnguardarcambios.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnguardarcambios.Image = ((System.Drawing.Image)(resources.GetObject("btnguardarcambios.Image")));
            this.btnguardarcambios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnguardarcambios.Location = new System.Drawing.Point(1164, 47);
            this.btnguardarcambios.Name = "btnguardarcambios";
            this.btnguardarcambios.Size = new System.Drawing.Size(178, 52);
            this.btnguardarcambios.TabIndex = 83;
            this.btnguardarcambios.Text = "Actualizar";
            this.btnguardarcambios.UseVisualStyleBackColor = false;
            this.btnguardarcambios.Click += new System.EventHandler(this.btnguardarcambios_Click);
            // 
            // txtTrabajosPen
            // 
            this.txtTrabajosPen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.txtTrabajosPen.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.txtTrabajosPen.ForeColor = System.Drawing.Color.White;
            this.txtTrabajosPen.Location = new System.Drawing.Point(12, 138);
            this.txtTrabajosPen.Name = "txtTrabajosPen";
            this.txtTrabajosPen.ReadOnly = true;
            this.txtTrabajosPen.Size = new System.Drawing.Size(1330, 686);
            this.txtTrabajosPen.TabIndex = 84;
            this.txtTrabajosPen.Text = "";
            // 
            // Actualizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1354, 846);
            this.Controls.Add(this.txtTrabajosPen);
            this.Controls.Add(this.btnguardarcambios);
            this.Controls.Add(this.btnactualizar1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Actualizar";
            this.Text = "Actualizar";
            this.Load += new System.EventHandler(this.Actualizar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnactualizar1;
        private System.Windows.Forms.Button btnguardarcambios;
        private System.Windows.Forms.RichTextBox txtTrabajosPen;
    }
}