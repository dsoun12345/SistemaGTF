namespace C_Sharp_MYSQL_Busqueda_CodigoBarras
{
    partial class GestorTrabajo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestorTrabajo));
            this.txtboxDNI1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.picturecodigo = new System.Windows.Forms.PictureBox();
            this.btnguardar = new System.Windows.Forms.Button();
            this.btngenerarcodigo = new System.Windows.Forms.Button();
            this.cbotipo = new System.Windows.Forms.ComboBox();
            this.txtcodigo1 = new System.Windows.Forms.TextBox();
            this.txttitulo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFechaEntrega = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtboxRUC1 = new System.Windows.Forms.TextBox();
            this.btnguardardatos1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.picturecodigo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtboxDNI1
            // 
            this.txtboxDNI1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.txtboxDNI1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxDNI1.ForeColor = System.Drawing.Color.White;
            this.txtboxDNI1.Location = new System.Drawing.Point(326, 142);
            this.txtboxDNI1.Name = "txtboxDNI1";
            this.txtboxDNI1.ReadOnly = true;
            this.txtboxDNI1.Size = new System.Drawing.Size(162, 33);
            this.txtboxDNI1.TabIndex = 40;
            this.txtboxDNI1.TextChanged += new System.EventHandler(this.txtboxDNI1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(48, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 28);
            this.label5.TabIndex = 39;
            this.label5.Text = "DNI:";
            // 
            // picturecodigo
            // 
            this.picturecodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picturecodigo.Location = new System.Drawing.Point(81, 347);
            this.picturecodigo.Name = "picturecodigo";
            this.picturecodigo.Size = new System.Drawing.Size(300, 125);
            this.picturecodigo.TabIndex = 38;
            this.picturecodigo.TabStop = false;
            // 
            // btnguardar
            // 
            this.btnguardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.btnguardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnguardar.FlatAppearance.BorderSize = 0;
            this.btnguardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(211)))), ((int)(((byte)(6)))));
            this.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardar.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnguardar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnguardar.Image = ((System.Drawing.Image)(resources.GetObject("btnguardar.Image")));
            this.btnguardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnguardar.Location = new System.Drawing.Point(81, 474);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(300, 71);
            this.btnguardar.TabIndex = 37;
            this.btnguardar.Text = "Guardar Codigo";
            this.btnguardar.UseVisualStyleBackColor = false;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // btngenerarcodigo
            // 
            this.btngenerarcodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.btngenerarcodigo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btngenerarcodigo.FlatAppearance.BorderSize = 0;
            this.btngenerarcodigo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(132)))), ((int)(((byte)(41)))));
            this.btngenerarcodigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngenerarcodigo.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngenerarcodigo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btngenerarcodigo.Image = ((System.Drawing.Image)(resources.GetObject("btngenerarcodigo.Image")));
            this.btngenerarcodigo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btngenerarcodigo.Location = new System.Drawing.Point(81, 250);
            this.btngenerarcodigo.Name = "btngenerarcodigo";
            this.btngenerarcodigo.Size = new System.Drawing.Size(300, 91);
            this.btngenerarcodigo.TabIndex = 36;
            this.btngenerarcodigo.Text = "Generar Codigo";
            this.btngenerarcodigo.UseVisualStyleBackColor = false;
            this.btngenerarcodigo.Click += new System.EventHandler(this.btngenerarcodigo_Click);
            // 
            // cbotipo
            // 
            this.cbotipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbotipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbotipo.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbotipo.FormattingEnabled = true;
            this.cbotipo.Location = new System.Drawing.Point(81, 246);
            this.cbotipo.Name = "cbotipo";
            this.cbotipo.Size = new System.Drawing.Size(300, 32);
            this.cbotipo.TabIndex = 35;
            this.cbotipo.Visible = false;
            // 
            // txtcodigo1
            // 
            this.txtcodigo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.txtcodigo1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcodigo1.ForeColor = System.Drawing.Color.White;
            this.txtcodigo1.Location = new System.Drawing.Point(81, 200);
            this.txtcodigo1.Name = "txtcodigo1";
            this.txtcodigo1.ReadOnly = true;
            this.txtcodigo1.Size = new System.Drawing.Size(300, 33);
            this.txtcodigo1.TabIndex = 34;
            this.txtcodigo1.TextChanged += new System.EventHandler(this.txtcodigo1_TextChanged);
            // 
            // txttitulo
            // 
            this.txttitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.txttitulo.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttitulo.ForeColor = System.Drawing.Color.White;
            this.txttitulo.Location = new System.Drawing.Point(81, 105);
            this.txttitulo.Name = "txttitulo";
            this.txttitulo.ReadOnly = true;
            this.txttitulo.Size = new System.Drawing.Size(300, 33);
            this.txttitulo.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(76, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 28);
            this.label3.TabIndex = 32;
            this.label3.Text = "Tipo:";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(76, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 28);
            this.label2.TabIndex = 31;
            this.label2.Text = "Código:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(76, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 28);
            this.label1.TabIndex = 30;
            this.label1.Text = "Cliente:";
            // 
            // txtFechaEntrega
            // 
            this.txtFechaEntrega.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.txtFechaEntrega.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaEntrega.ForeColor = System.Drawing.Color.White;
            this.txtFechaEntrega.Location = new System.Drawing.Point(326, 83);
            this.txtFechaEntrega.Name = "txtFechaEntrega";
            this.txtFechaEntrega.ReadOnly = true;
            this.txtFechaEntrega.Size = new System.Drawing.Size(162, 33);
            this.txtFechaEntrega.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(48, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 28);
            this.label4.TabIndex = 42;
            this.label4.Text = "Fecha de Entrega:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(48, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 28);
            this.label6.TabIndex = 43;
            this.label6.Text = "RUC:";
            // 
            // txtboxRUC1
            // 
            this.txtboxRUC1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.txtboxRUC1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxRUC1.ForeColor = System.Drawing.Color.White;
            this.txtboxRUC1.Location = new System.Drawing.Point(326, 209);
            this.txtboxRUC1.Name = "txtboxRUC1";
            this.txtboxRUC1.ReadOnly = true;
            this.txtboxRUC1.Size = new System.Drawing.Size(162, 33);
            this.txtboxRUC1.TabIndex = 44;
            // 
            // btnguardardatos1
            // 
            this.btnguardardatos1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.btnguardardatos1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnguardardatos1.FlatAppearance.BorderSize = 0;
            this.btnguardardatos1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(132)))), ((int)(((byte)(41)))));
            this.btnguardardatos1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardardatos1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnguardardatos1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnguardardatos1.Image = ((System.Drawing.Image)(resources.GetObject("btnguardardatos1.Image")));
            this.btnguardardatos1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnguardardatos1.Location = new System.Drawing.Point(53, 296);
            this.btnguardardatos1.Name = "btnguardardatos1";
            this.btnguardardatos1.Size = new System.Drawing.Size(435, 63);
            this.btnguardardatos1.TabIndex = 45;
            this.btnguardardatos1.Text = "Guardar Datos";
            this.btnguardardatos1.UseVisualStyleBackColor = false;
            this.btnguardardatos1.Click += new System.EventHandler(this.btnguardardatos1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(330, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(441, 38);
            this.label7.TabIndex = 46;
            this.label7.Text = "Generar Código de Trabajo";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txttitulo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtcodigo1);
            this.groupBox1.Controls.Add(this.cbotipo);
            this.groupBox1.Controls.Add(this.btngenerarcodigo);
            this.groupBox1.Controls.Add(this.btnguardar);
            this.groupBox1.Controls.Add(this.picturecodigo);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(29, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 587);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generar";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFechaEntrega);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtboxDNI1);
            this.groupBox2.Controls.Add(this.btnguardardatos1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtboxRUC1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(549, 207);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(522, 416);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos";
            // 
            // GestorTrabajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1100, 728);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GestorTrabajo";
            this.Text = "GestorTrabajo";
            this.Load += new System.EventHandler(this.GestorTrabajo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picturecodigo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtboxDNI1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picturecodigo;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.Button btngenerarcodigo;
        private System.Windows.Forms.ComboBox cbotipo;
        private System.Windows.Forms.TextBox txtcodigo1;
        private System.Windows.Forms.TextBox txttitulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFechaEntrega;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtboxRUC1;
        private System.Windows.Forms.Button btnguardardatos1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}