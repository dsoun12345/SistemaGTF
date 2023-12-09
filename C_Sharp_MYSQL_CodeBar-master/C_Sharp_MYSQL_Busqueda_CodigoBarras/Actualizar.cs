using C_Sharp_MYSQL_Busqueda_CodigoBarras.Clases;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Sharp_MYSQL_Busqueda_CodigoBarras
{
    public partial class Actualizar : Form
    {
        // Conexión a MySQL
        private MySqlConnection conexion;
        private string cadenaConexion = "server=localhost;database=metaldb;user=root;password=user;port=3306;";
        public Actualizar()
        {
            InitializeComponent();
            conexion = new MySqlConnection(cadenaConexion);
            try
            {
                conexion.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnactualizar1_Click(object sender, EventArgs e)
        {
            string rutaArchivo = @"C:\Users\Jose Moncayo\Dropbox\Aplicaciones\proyectoconn\hola.txt";

            try
            {
                string contenido = System.IO.File.ReadAllText(rutaArchivo);
               
                txtTrabajosPen.Clear();

                Font font = new Font("Courier New", 12);

                // Divide el contenido en registros
                string[] registros = contenido.Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < registros.Length - 1; i++)
                {
                    string registro = registros[i];

                    // Divide el registro en campos utilizando la coma como separador
                    string[] campos = registro.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    // Agrega formatos
                    txtTrabajosPen.SelectionFont = new Font(txtTrabajosPen.Font.FontFamily, 14, FontStyle.Bold);
                    txtTrabajosPen.AppendText($"REGISTRO {i + 1}:\n\n");

                    foreach (string campo in campos)
                    {
                        // Formatea RichTextBox
                        string[] parts = campo.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                        if (parts.Length == 2)
                        {
                            txtTrabajosPen.SelectionFont = font;
                            txtTrabajosPen.AppendText($"{parts[0].Trim().PadRight(20)}: {parts[1].Trim()}\n");
                        }
                        else
                        {
                            txtTrabajosPen.SelectionFont = font;
                            txtTrabajosPen.AppendText($"{campo.Trim()}\n");
                        }
                    }

                    txtTrabajosPen.AppendText("\n\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            

        private void btnguardarcambios_Click(object sender, EventArgs e)
        {
            // Ruta del archivo txt
            string rutaArchivo = @"C:\Users\Jose Moncayo\Dropbox\Aplicaciones\proyectoconn\hola.txt";

            try
            {
                string contenido = System.IO.File.ReadAllText(rutaArchivo);
                string[] registros = contenido.Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    foreach (string registro in registros)
                    {
                        // Divide el registro en campos utilizando la coma como separador
                        string[] campos = registro.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        // Inicializa la ID y la verificación
                        int id = -1;
                        string verificacion = "";

                        foreach (string campo in campos)
                        {
                            // Divide cada campo en clave y valor
                            string[] parts = campo.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                            if (parts.Length == 2)
                            {
                                // Obtiene la clave y el valor
                                string clave = parts[0].Trim();
                                string valor = parts[1].Trim();

                                if (clave == "ID")
                                {
                                    // Obtiene la ID del registro
                                    id = int.Parse(valor);
                                }
                                else if (clave == "Verificación")
                                {
                                    // Obtiene el valor de la verificación
                                    verificacion = valor.Trim().TrimEnd(';');
                                }
                            }
                        }

                        // Actualiza con la verificación obtenida
                        ActualizarVerificacion(id, verificacion, conexion);
                    }
                }

                MessageBox.Show("Actualización realizada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ActualizarVerificacion(int id, string verificacion, MySqlConnection conexion)
        {
            // Realiza la actualización
            string consulta = "UPDATE gestion_ventas SET verificacion = @verificacion WHERE id = @id";

            using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@verificacion", verificacion);
                comando.Parameters.AddWithValue("@id", id);

                comando.ExecuteNonQuery();
            }
        }

        private void GuardarYBorrarEnArchivo()
        {
            string contenido = txtTrabajosPen.Text;

            string rutaArchivo = @"C:\Users\Jose Moncayo\Dropbox\Aplicaciones\proyectoconn\hola.txt";

            try
            {
                System.IO.File.WriteAllText(rutaArchivo, contenido);

                MessageBox.Show("Contenido guardado en 'hola.txt'.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Actualizar_Load(object sender, EventArgs e)
        {

        }

        private void txtTrabajosPen_TextChanged(object sender, EventArgs e)
        {
        }

    }
}