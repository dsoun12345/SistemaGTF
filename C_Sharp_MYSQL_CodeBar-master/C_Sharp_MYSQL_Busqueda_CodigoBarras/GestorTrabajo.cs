using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarcodeLib;
using BarcodeStandard;
using C_Sharp_MYSQL_Busqueda_CodigoBarras.Clases;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace C_Sharp_MYSQL_Busqueda_CodigoBarras

{

    public partial class GestorTrabajo : Form
    {
        public string Codigo1
        {
         get { return txtcodigo1.Text; }
        set { txtcodigo1.Text = value; }
        }


        public GestorTrabajo()
        {
            InitializeComponent();

        }


        public class OpcionCombo
        {
            public int Valor { get; set; }
            public string Texto { get; set; }
        }
        

        private void GestorTrabajo_Load(object sender, EventArgs e)
        {
            // Obtiene el último valor de nom_completos
            string ultimoNomCompletos = ObtenerUltimoNomCompletos();

            // Obtiene la última fecha de entrega
            DateTime? ultimaFechaEntrega = ObtenerUltimaFechaEntrega();

            // Obtiene el último valor del campo DNI
            string ultimoDNI = ObtenerUltimoDNI();
            string ultimoRUC = ObtenerUltimoRUC();

            // Muestra la última fecha de entrega en txtFechaEntrega
            if (ultimaFechaEntrega.HasValue)
            {
                txtFechaEntrega.Text = ultimaFechaEntrega.Value.ToShortDateString();
            }
            else
            {
                txtFechaEntrega.Text = string.Empty;
            }

            // Muestra el último valor en txttitulo
            txttitulo.Text = ultimoNomCompletos;
            txtboxDNI1.Text = ultimoDNI;
            txtboxRUC1.Text = ultimoRUC;

            cbotipo.Items.Add(new OpcionCombo() { Valor = (int)BarcodeLib.TYPE.CODE128, Texto = "Code 128" });
            cbotipo.DisplayMember = "Texto";
            cbotipo.ValueMember = "Valor";
            cbotipo.SelectedIndex = 0;
        }


        private void btngenerarcodigo_Click(object sender, EventArgs e)
        {
            string codigoGenerado = string.Empty;

            if (string.IsNullOrWhiteSpace(txtcodigo1.Text))
            {
                if (!string.IsNullOrWhiteSpace(txtboxDNI1.Text))
                {
                    codigoGenerado = txtboxDNI1.Text.Trim();
                }
                else
                {
                    MessageBox.Show("Ingresa algún dato en DNI.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                codigoGenerado = txtcodigo1.Text.Trim();
            }

            Image imagenCodigo;
            int indice = (cbotipo.SelectedItem as OpcionCombo).Valor;
            BarcodeLib.TYPE tipoCodigo = (BarcodeLib.TYPE)indice;

            try
            {
                Barcode codigo = new Barcode();
                codigo.IncludeLabel = true;
                codigo.LabelPosition = LabelPositions.BOTTOMCENTER;
                imagenCodigo = codigo.Encode(tipoCodigo, codigoGenerado, Color.Black, Color.White, 300, 100);

                Bitmap imagenTitulo = convertirTextoImagen(txttitulo.Text.Trim(), 300, Color.White);

                int alto_imagen_nuevo = imagenCodigo.Height + imagenTitulo.Height;

                Bitmap imagenNueva = new Bitmap(300, alto_imagen_nuevo);
                Graphics dibujar = Graphics.FromImage(imagenNueva);

                dibujar.DrawImage(imagenTitulo, new Point(0, 0));
                dibujar.DrawImage(imagenCodigo, new Point(0, imagenTitulo.Height));

                picturecodigo.BackgroundImage = imagenNueva;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el código de barras: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static Bitmap convertirTextoImagen(string texto, int ancho, Color color)
        {
            Bitmap objBitmap = new Bitmap(1, 1);
            int Width = 0;
            int Height = 0;

            //Formatea font
            System.Drawing.Font objFont = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);

            //Crea un objeto Graphics a partir del Bitmap
            Graphics objGraphics = Graphics.FromImage(objBitmap);

            //Establece el tamaño según la longitud del texto
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


        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (picturecodigo.BackgroundImage != null)
            {
                string titulo = txttitulo.Text.Trim();
                string fechaEntrega = txtFechaEntrega.Text.Trim();

                // Reemplaza las barras ("/") con guiones ("-") en la fecha de entrega
                fechaEntrega = fechaEntrega.Replace("/", "-");

                string nombreArchivo = $"{titulo}_Entrega_{fechaEntrega}.jpg";

                string carpetaDestino = @"C:\Users\Jose Moncayo\Desktop\codigos";

                // Verifica si la carpeta de destino existe, si no, crea
                if (!Directory.Exists(carpetaDestino))
                {
                    Directory.CreateDirectory(carpetaDestino);
                }

                string rutaGuardar = Path.Combine(carpetaDestino, nombreArchivo);

                Image imagen_codigo = picturecodigo.BackgroundImage.Clone() as Image;

                try
                {
                    // Guarda la imagen como formato JPEG
                    imagen_codigo.Save(rutaGuardar, ImageFormat.Jpeg);
                    MessageBox.Show("El código ha sido guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el código de barras: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se ha generado el código de barras.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
 

        public string ObtenerUltimoNomCompletos()
        {
            string ultimoNomCompletos = null;

            try
            {
                Conexion objConexion = new Conexion();
                string query = "SELECT nom_completos FROM gestion_ventas ORDER BY id DESC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, objConexion.establecerConexion());

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ultimoNomCompletos = reader["nom_completos"].ToString();
                    }
                }
                objConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ultimoNomCompletos;
        }


        public DateTime? ObtenerUltimaFechaEntrega()
        {
            DateTime? ultimaFechaEntrega = null;

            try
            {
                Conexion objConexion = new Conexion();
                string query = "SELECT fecha_entrega FROM gestion_ventas ORDER BY id DESC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, objConexion.establecerConexion());

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Comprueba si el valor no es nulo antes de convertirlo
                        if (!reader.IsDBNull(reader.GetOrdinal("fecha_entrega")))
                        {
                            ultimaFechaEntrega = reader.GetDateTime("fecha_entrega");
                        }
                    }
                }
                objConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ultimaFechaEntrega;
        }


        public string ObtenerUltimoDNI()
        {
            string ultimoDNI = null;

            try
            {
                Conexion objConexion = new Conexion();
                string query = "SELECT DNI FROM gestion_ventas ORDER BY id DESC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, objConexion.establecerConexion());

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ultimoDNI = reader["DNI"].ToString();
                    }
                }
                objConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ultimoDNI;
        }


        public string ObtenerUltimoRUC()
        {
            string ultimoRUC = null;

            try
            {
                Conexion objConexion = new Conexion();
                string query = "SELECT RUC FROM gestion_ventas ORDER BY id DESC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, objConexion.establecerConexion());

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ultimoRUC = reader["RUC"].ToString();
                    }
                }
                objConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ultimoRUC;
        }
      

        private void btnguardardatos1_Click(object sender, EventArgs e)
        {
            // Obtiene los valores de los campos
            string titulo = txttitulo.Text.Trim();
            string codigo = string.IsNullOrWhiteSpace(txtcodigo1.Text) ? txtboxDNI1.Text.Trim() : txtcodigo1.Text.Trim();
            string dni = txtboxDNI1.Text.Trim();
            string ruc = txtboxRUC1.Text.Trim();
            string fechaEntrega = txtFechaEntrega.Text.Trim();

            // Formata la fecha al formato yyyy-MM-dd
            DateTime fechaEntregaFormateada;
            if (DateTime.TryParseExact(fechaEntrega, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaEntregaFormateada))
            {
                fechaEntrega = fechaEntregaFormateada.ToString("yyyy-MM-dd");
            }
            else
            {
                MessageBox.Show("La fecha de entrega no tiene el formato correcto (dd/MM/yyyy)", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            string cadenaConexion = "server=localhost;port=3306;user id=root;password=user;database=metaldb;";

            MySqlConnection conexion = new MySqlConnection(cadenaConexion);

            try
            {
                conexion.Open();

                // Crea la consulta SQL para insertar los datos
                string consulta = "INSERT INTO gestion_trabajo (nom_completos, id, DNI, RUC, fecha_entrega) VALUES (@titulo, @codigo, @dni, @ruc, @fechaEntrega)";

                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@titulo", titulo);
                comando.Parameters.AddWithValue("@codigo", codigo);
                comando.Parameters.AddWithValue("@dni", dni);
                comando.Parameters.AddWithValue("@ruc", ruc);
                comando.Parameters.AddWithValue("@fechaEntrega", fechaEntrega);

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Registro finalizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Se produjo un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
            BuscarYGuardarEnArchivo();
        }


        private void BuscarYGuardarEnArchivo()
        {
            // Define la ruta del archivo hola.txt
            string rutaArchivo = @"C:\Users\Jose Moncayo\Dropbox\Aplicaciones\proyectoconn\hola.txt";

            // Borra el contenido del archivo si existe
            if (File.Exists(rutaArchivo))
            {
                File.WriteAllText(rutaArchivo, string.Empty);
            }

            // Abre o crear el archivo para escritura
            using (StreamWriter sw = File.AppendText(rutaArchivo))
            {
                // Define la consulta SQL para obtener los registros
                string query = "SELECT id, fecha_entrega, descripcion, nom_completos, codigotarjeta, DNI, telefono, verificacion FROM gestion_ventas " +
            "WHERE fecha_entrega > @fechaActual " +
            "ORDER BY fecha_entrega ASC";

                try
                {
                    Conexion objConexion = new Conexion();

                    MySqlCommand cmd = new MySqlCommand(query, objConexion.establecerConexion());
                    {
                        cmd.Parameters.AddWithValue("@fechaActual", DateTime.Today);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32("id");
                                DateTime fechaEntrega = reader.GetDateTime("fecha_entrega");
                                string descripcionSinFormato = reader["descripcion"].ToString();
                                string nombreCompleto = reader["nom_completos"].ToString();
                                string codigoTarjeta = reader["codigotarjeta"].ToString();
                                string dni = reader["DNI"].ToString();
                                string telefono = reader["telefono"].ToString(); 
                                string verificacion = reader["verificacion"].ToString();

                                string[] descripciones = descripcionSinFormato.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                                StringBuilder descripcionFormateada = new StringBuilder();
                                foreach (string desc in descripciones)
                                {
                                    string[] datos = desc.Split(',');
                                    if (datos.Length >= 6)
                                    {
                                        descripcionFormateada.Append($"ID: {id}, ");
                                        descripcionFormateada.Append($"Fecha de Entrega: {fechaEntrega.ToShortDateString()}, ");

                                        if (!string.IsNullOrEmpty(codigoTarjeta))
                                        {
                                            descripcionFormateada.Append($"Código de Tarjeta: {codigoTarjeta}, ");
                                        }

                                        if (!string.IsNullOrEmpty(dni))
                                        {
                                            descripcionFormateada.Append($"DNI: {dni}, ");
                                        }

                                        descripcionFormateada.Append($"Cantidad: {datos[0].Trim()}, ");
                                        descripcionFormateada.Append($"Descripción: {datos[1].Trim()}, ");
                                        descripcionFormateada.Append($"Tamaño de Corte: {datos[2].Trim()}, ");
                                        descripcionFormateada.Append($"Tipo de Corte: {datos[3].Trim()}, ");
                                        descripcionFormateada.Append($"Material: {datos[4].Trim()}, ");
                                        descripcionFormateada.Append($"Precio: {datos[5].Trim()},");
                                        descripcionFormateada.Append($"Cliente: {nombreCompleto},");
                                        descripcionFormateada.Append($"Teléfono: {telefono}, ");
                                        descripcionFormateada.Append($"Verificación:; {verificacion}\r\n\r\n");
                                    }
                                }

                                // Escribe los datos formateados en el archivo hola.txt
                                sw.WriteLine(descripcionFormateada.ToString());
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Se produjo un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void txtcodigo1_TextChanged(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }


        private void txtboxDNI1_TextChanged(object sender, EventArgs e)
        {


        }
    }
}
