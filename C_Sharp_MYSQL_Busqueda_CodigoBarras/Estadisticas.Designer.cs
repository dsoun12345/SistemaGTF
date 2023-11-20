namespace C_Sharp_MYSQL_Busqueda_CodigoBarras
{
    partial class Estadisticas
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Estadisticas));
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TotalMes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TotalAño = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btndia = new System.Windows.Forms.Button();
            this.btnmes = new System.Windows.Forms.Button();
            this.btnaño = new System.Windows.Forms.Button();
            this.TotalDias = new System.Windows.Forms.RichTextBox();
            this.Totalventasdeldia = new System.Windows.Forms.RichTextBox();
            this.btnclientes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalAño)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(515, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 56);
            this.label1.TabIndex = 27;
            this.label1.Text = "Estadisticas";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(48, 115);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1294, 587);
            this.chart1.TabIndex = 28;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            // 
            // TotalMes
            // 
            chartArea2.Name = "ChartArea1";
            this.TotalMes.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.TotalMes.Legends.Add(legend2);
            this.TotalMes.Location = new System.Drawing.Point(48, 115);
            this.TotalMes.Name = "TotalMes";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.TotalMes.Series.Add(series2);
            this.TotalMes.Size = new System.Drawing.Size(1294, 587);
            this.TotalMes.TabIndex = 30;
            this.TotalMes.Text = "chart2";
            this.TotalMes.Visible = false;
            // 
            // TotalAño
            // 
            chartArea3.Name = "ChartArea1";
            this.TotalAño.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.TotalAño.Legends.Add(legend3);
            this.TotalAño.Location = new System.Drawing.Point(48, 115);
            this.TotalAño.Name = "TotalAño";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.TotalAño.Series.Add(series3);
            this.TotalAño.Size = new System.Drawing.Size(1294, 587);
            this.TotalAño.TabIndex = 31;
            this.TotalAño.Text = "chart3";
            this.TotalAño.Visible = false;
            // 
            // btndia
            // 
            this.btndia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.btndia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndia.FlatAppearance.BorderSize = 0;
            this.btndia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(132)))), ((int)(((byte)(41)))));
            this.btndia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndia.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndia.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btndia.Image = ((System.Drawing.Image)(resources.GetObject("btndia.Image")));
            this.btndia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndia.Location = new System.Drawing.Point(418, 731);
            this.btndia.Name = "btndia";
            this.btndia.Size = new System.Drawing.Size(237, 74);
            this.btndia.TabIndex = 51;
            this.btndia.Text = "Ventas del Dia";
            this.btndia.UseVisualStyleBackColor = false;
            this.btndia.Click += new System.EventHandler(this.btndia_Click);
            // 
            // btnmes
            // 
            this.btnmes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.btnmes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnmes.FlatAppearance.BorderSize = 0;
            this.btnmes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(132)))), ((int)(((byte)(41)))));
            this.btnmes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmes.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnmes.Image = ((System.Drawing.Image)(resources.GetObject("btnmes.Image")));
            this.btnmes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnmes.Location = new System.Drawing.Point(694, 731);
            this.btnmes.Name = "btnmes";
            this.btnmes.Size = new System.Drawing.Size(237, 74);
            this.btnmes.TabIndex = 52;
            this.btnmes.Text = "Ventas del Mes";
            this.btnmes.UseVisualStyleBackColor = false;
            this.btnmes.Click += new System.EventHandler(this.btnmes_Click);
            // 
            // btnaño
            // 
            this.btnaño.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.btnaño.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnaño.FlatAppearance.BorderSize = 0;
            this.btnaño.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(132)))), ((int)(((byte)(41)))));
            this.btnaño.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaño.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaño.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnaño.Image = ((System.Drawing.Image)(resources.GetObject("btnaño.Image")));
            this.btnaño.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnaño.Location = new System.Drawing.Point(970, 731);
            this.btnaño.Name = "btnaño";
            this.btnaño.Size = new System.Drawing.Size(237, 74);
            this.btnaño.TabIndex = 53;
            this.btnaño.Text = "Ventas del Año";
            this.btnaño.UseVisualStyleBackColor = false;
            this.btnaño.Click += new System.EventHandler(this.btnaño_Click);
            // 
            // TotalDias
            // 
            this.TotalDias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.TotalDias.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalDias.ForeColor = System.Drawing.Color.White;
            this.TotalDias.Location = new System.Drawing.Point(441, 267);
            this.TotalDias.Name = "TotalDias";
            this.TotalDias.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.TotalDias.Size = new System.Drawing.Size(472, 228);
            this.TotalDias.TabIndex = 54;
            this.TotalDias.Text = "";
            this.TotalDias.Visible = false;
            // 
            // Totalventasdeldia
            // 
            this.Totalventasdeldia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.Totalventasdeldia.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Totalventasdeldia.ForeColor = System.Drawing.Color.White;
            this.Totalventasdeldia.Location = new System.Drawing.Point(441, 491);
            this.Totalventasdeldia.Name = "Totalventasdeldia";
            this.Totalventasdeldia.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.Totalventasdeldia.Size = new System.Drawing.Size(472, 41);
            this.Totalventasdeldia.TabIndex = 55;
            this.Totalventasdeldia.Text = "";
            this.Totalventasdeldia.Visible = false;
            // 
            // btnclientes
            // 
            this.btnclientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.btnclientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclientes.FlatAppearance.BorderSize = 0;
            this.btnclientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(132)))), ((int)(((byte)(41)))));
            this.btnclientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclientes.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclientes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnclientes.Image = ((System.Drawing.Image)(resources.GetObject("btnclientes.Image")));
            this.btnclientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnclientes.Location = new System.Drawing.Point(143, 731);
            this.btnclientes.Name = "btnclientes";
            this.btnclientes.Size = new System.Drawing.Size(237, 74);
            this.btnclientes.TabIndex = 56;
            this.btnclientes.Text = "Puntos Totales";
            this.btnclientes.UseVisualStyleBackColor = false;
            this.btnclientes.Click += new System.EventHandler(this.btnclientes_Click);
            // 
            // Estadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1354, 846);
            this.Controls.Add(this.btnclientes);
            this.Controls.Add(this.Totalventasdeldia);
            this.Controls.Add(this.TotalDias);
            this.Controls.Add(this.btnaño);
            this.Controls.Add(this.btnmes);
            this.Controls.Add(this.btndia);
            this.Controls.Add(this.TotalAño);
            this.Controls.Add(this.TotalMes);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Estadisticas";
            this.Text = "Estadisticas";
            this.Load += new System.EventHandler(this.Estadisticas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalAño)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart TotalMes;
        private System.Windows.Forms.DataVisualization.Charting.Chart TotalAño;
        private System.Windows.Forms.Button btndia;
        private System.Windows.Forms.Button btnmes;
        private System.Windows.Forms.Button btnaño;
        private System.Windows.Forms.RichTextBox TotalDias;
        private System.Windows.Forms.RichTextBox Totalventasdeldia;
        private System.Windows.Forms.Button btnclientes;
    }
}