using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ProyectoCodigo;

namespace C_Sharp_MYSQL_Busqueda_CodigoBarras
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

       
        private void AbrirFormHijo(object formhijo)
        {
            if (this.panel2.Controls.Count > 0)
                this.panel2.Controls.RemoveAt(0);
            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(fh);
            this.panel2.Tag = fh;
            fh.Show();
        }
  

        private void btndatos_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            AbrirFormHijo(new Datos());
        }


        private void btnimpresion_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            AbrirFormHijo(new Impresion());
        }


        private void btnajustes_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            AbrirFormHijo(new Config());
        }


        private void btnfacts_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            AbrirFormHijo(new Facts());
        }


        private void btnTrabajo_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            AbrirFormHijo(new Actualizar());
        }


        private void btnfechas_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            AbrirFormHijo(new FechasTrabajo());
        }


        private void btnestadisticas_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            AbrirFormHijo(new Estadisticas());
        }
   

        private void cerrarbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        int LX,LY;
        private void maximizarbtn_Click(object sender, EventArgs e)
        {
            LX = this.Location.X;
            LY = this.Location.Y;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;  
            //this.WindowState = FormWindowState.Maximized;
            maximizarbtn.Visible= false;
            restbtn.Visible= true;
        }


        private void restbtn_Click(object sender, EventArgs e)
        {
            //this.WindowState= FormWindowState.Normal;
            this.Size = new Size(1400, 860);
            this.Location = new Point(LX,LY);
            restbtn.Visible= false;
            maximizarbtn.Visible = true;
        }


        private void minimizarbtn_Click(object sender, EventArgs e)
        {
            this.WindowState =FormWindowState.Minimized;
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void horafecha_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToLongDateString();
        }


        private void apagadobtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
      
        }


        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }


        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

      
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lblhora_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }
    }
}