using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//AÑADIR LA REFERENCIA BARCODELIB
using BarcodeLib;
using BarcodeStandard;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoCodigo
{
    public partial class Impresion : Form
    {
        public Impresion()
        {
            InitializeComponent();
        }

        //1.- CREAR UNA CLASE PARA RELLENAR LOS ITEMS DEL COMBO BOX
        public class OpcionCombo
        {
            public int Valor { get; set; }
            public string Texto { get; set; }
        }

        private void Impresion_Load(object sender, EventArgs e)
        {
            //2.- CARGAR EL COMBO CON LOS TIPO DE BARCODE


            cbotipo.Items.Add(new OpcionCombo() { Valor = (int)BarcodeLib.TYPE.CODE128, Texto = "Code 128" });


            cbotipo.DisplayMember = "Texto";
            cbotipo.ValueMember = "Valor";
            cbotipo.SelectedIndex = 0;
        }


        private void btngenerarcodigo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcodigo.Text))
            {
                MessageBox.Show("Por favor, ingrese algún dato.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Image imagenCodigo;
            int indice = (cbotipo.SelectedItem as OpcionCombo).Valor;
            BarcodeLib.TYPE tipoCodigo = (BarcodeLib.TYPE)indice;

            try
            {
                Barcode codigo = new Barcode();
                codigo.IncludeLabel = true;
                codigo.LabelPosition = LabelPositions.BOTTOMCENTER;
                imagenCodigo = codigo.Encode(tipoCodigo, txtcodigo.Text.Trim(), Color.Black, Color.White, 300, 100);

                //EXTRA Y AL ULTIMO
                Bitmap imagenTitulo = convertirTextoImagen(txttitulo.Text.Trim(), 300, Color.White);

                int alto_imagen_nuevo = imagenCodigo.Height + imagenTitulo.Height;

                Bitmap imagenNueva = new Bitmap(300, alto_imagen_nuevo);
                Graphics dibujar = Graphics.FromImage(imagenNueva);

                dibujar.DrawImage(imagenTitulo, new Point(0, 0));
                dibujar.DrawImage(imagenCodigo, new Point(0, imagenTitulo.Height));

                // picturecodigo.BackgroundImage = imagenCodigo;
                picturecodigo.BackgroundImage = imagenNueva;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el código de barras: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public static Bitmap convertirTextoImagen(string texto, int ancho, Color color)
        {
            //creamos el objeto imagen Bitmap
            Bitmap objBitmap = new Bitmap(1, 1);
            int Width = 0;
            int Height = 0;
            //formateamos la fuente (tipo de letra, tamaño)
            System.Drawing.Font objFont = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);

            //creamos un objeto Graphics a partir del Bitmap
            Graphics objGraphics = Graphics.FromImage(objBitmap);

            //establecemos el tamaño según la longitud del texto
            Width = ancho;
            Height = (int)objGraphics.MeasureString(texto, objFont).Height + 5;
            objBitmap = new Bitmap(objBitmap, new Size(Width, Height));

            objGraphics = Graphics.FromImage(objBitmap);

            objGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            objGraphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            objGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            objGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            StringFormat drawFormat = new StringFormat();
            objGraphics.Clear(color);

            drawFormat.Alignment = StringAlignment.Center;
            objGraphics.DrawString(texto, objFont, new SolidBrush(Color.Black), new RectangleF(0, (objBitmap.Height / 2) - (objBitmap.Height - 10), objBitmap.Width, objBitmap.Height), drawFormat);
            objGraphics.Flush();


            return objBitmap;
        }

        private void btnguardar_Click_1(object sender, EventArgs e)
        {
            if (picturecodigo.BackgroundImage != null)
            {
                Image imagen_codigo = picturecodigo.BackgroundImage.Clone() as Image;

                SaveFileDialog ventana_dialogo = new SaveFileDialog();
                ventana_dialogo.FileName = string.Format("{0}.png", txtcodigo.Text.Trim());
                ventana_dialogo.Filter = "Imagen|*.png";

                if (ventana_dialogo.ShowDialog() == DialogResult.OK)
                {
                    imagen_codigo.Save(ventana_dialogo.FileName, ImageFormat.Png);
                    MessageBox.Show("Código guardado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No se ha generado un código de barras para guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtboxDNI1_TextChanged_1(object sender, EventArgs e)
        {
            // Obtener la cadena de conexión a la base de datos
            string connectionString = "server=localhost;port=3306;user id=root;password=user;database=metaldb;";

            // Crear una conexión a la base de datos
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();
                string query = "SELECT id, nombres, apellidos FROM cliente WHERE dni = @dni OR ruc = @ruc";

                // Crear un comando SQL con parámetros
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dni", txtboxDNI1.Text);
                cmd.Parameters.AddWithValue("@ruc", txtboxDNI1.Text);

                // Ejecutar la consulta SQL y obtener el resultado
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Si se encontró un registro relacionado, asignamos los valores a los TextBox
                    string nombres = reader["nombres"].ToString();
                    string apellidos = reader["apellidos"].ToString();
                    txttitulo.Text = $"{nombres} {apellidos}";
                    txtcodigo.Text = reader["id"].ToString();
                }
                else
                {
                    // Si no se encontró un registro relacionado, puedes limpiar los TextBox o mostrar un mensaje de error.
                    txttitulo.Text = string.Empty;
                    txtcodigo.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                // Maneja cualquier error de conexión o consulta aquí
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                conn.Close();
            }
        }

        private void btnrecargar_Click(object sender, EventArgs e)
        {
            txtboxDNI1.Text = string.Empty;
            txttitulo.Text = string.Empty;
            txtcodigo.Text = string.Empty;
            picturecodigo.BackgroundImage = null;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void cbotipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cbotipo_TextChanged(object sender, EventArgs e)
        {

        }

          }
}
