using C_Sharp_MYSQL_Busqueda_CodigoBarras.Clases;
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
    public partial class Descuentos : Form
    {
        private decimal descuentoTotal = 0;

        public Descuentos()
        {
            InitializeComponent();

        }

        public string Codigo2
        {
            get { return txtcodigo2.Text; }
            set { txtcodigo2.Text = value; }
        }

        public string ValorDescuento
        {
            get { return txtvalordescu.Text; }
        }

        private void MostrarPuntos()
        {
            // Obtén el ID de txtcodigo1
            int idPuntosA;
            if (int.TryParse(txtcodigo2.Text, out idPuntosA))
            {
                try
                {
                    Conexion objConexion = new Conexion();
                    MySqlConnection conn = objConexion.establecerConexion();

                    string sql = "SELECT puntos FROM puntos_A WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", idPuntosA);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        txtpuntosacumulados01.Text = result.ToString();
                    }
                    else
                    {
                        // El ID no existe en la tabla
                        txtpuntosacumulados01.Text = "No encontrado";
                    }

                    objConexion.cerrarConexion();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se produjo un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un código válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarUltimoValores()
        {
            try
            {
                Conexion objConexion = new Conexion();
                MySqlConnection conn = objConexion.establecerConexion();

                string sql = "SELECT valor_puntos FROM configuracion ORDER BY id DESC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtpuntosvalor.Text = reader["valor_puntos"].ToString();
                }
                else
                {
                    txtpuntosvalor.Text = ""; // También establece el campo de puntos en blanco si no hay registros
                }

                reader.Close();
                objConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Descuentos_Load(object sender, EventArgs e)
        {
            MostrarPuntos();
            CargarUltimoValores();
        }

        private void txtpuntosacumulados01_TextChanged(object sender, EventArgs e)
        {
            MostrarPuntos();
        }

        private void btnguardardatos1_Click(object sender, EventArgs e)
        {

        }

        private void btnAplicarDescuento_Click(object sender, EventArgs e)
        {
            // Obtén los valores de los TextBox
            int idPuntosA;
            int puntosAcumulados;
            int puntosAplicados;

            if (int.TryParse(txtcodigo2.Text, out idPuntosA) &&
                int.TryParse(txtpuntosacumulados01.Text, out puntosAcumulados) &&
                int.TryParse(txtpuntosapli.Text, out puntosAplicados))
            {
                if (puntosAplicados <= puntosAcumulados)
                {
                    // Actualiza la tabla puntos_A con los nuevos puntos acumulados
                    try
                    {
                        Conexion objConexion = new Conexion();
                        MySqlConnection conn = objConexion.establecerConexion();

                        // Resta los puntos aplicados de los puntos acumulados
                        int nuevosPuntosAcumulados = puntosAcumulados - puntosAplicados;

                        // Obtiene el valor de txtpuntosvalor y verifica si es válido
                        decimal valorPuntos;
                        if (decimal.TryParse(txtpuntosvalor.Text, out valorPuntos))
                        {
                            // Calcula el valor del descuento y actualiza el descuento total
                            decimal descuento = (puntosAplicados * valorPuntos) / 100;
                            descuentoTotal += descuento;

                            // Actualiza el TextBox con el valor total del descuento
                            txtvalordescu.Text = descuentoTotal.ToString();

                            // Actualiza la tabla puntos_A con los nuevos puntos acumulados
                            string sqlUpdatePuntos = "UPDATE puntos_A SET puntos = @nuevosPuntos WHERE id = @id";
                            MySqlCommand cmdUpdatePuntos = new MySqlCommand(sqlUpdatePuntos, conn);
                            cmdUpdatePuntos.Parameters.AddWithValue("@nuevosPuntos", nuevosPuntosAcumulados);
                            cmdUpdatePuntos.Parameters.AddWithValue("@id", idPuntosA);

                            int rowsAffected = cmdUpdatePuntos.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Actualización exitosa
                                MessageBox.Show("Descuento aplicado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Se produjo un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Verifica que el valor de puntos sea válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        objConexion.cerrarConexion();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Se produjo un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Los puntos aplicados no pueden ser mayores que los puntos acumulados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Verifica que los valores ingresados sean válidos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            MostrarPuntos();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Descuentos_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Conexion objConexion = new Conexion();
                MySqlConnection conn = objConexion.establecerConexion();
                string sql = "UPDATE configuracion SET valor_puntos = @valorPuntos WHERE id = (SELECT MAX(id) FROM configuracion)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@valorPuntos", decimal.Parse(txtpuntosvalor.Text));

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                }
                else
                {
                    MessageBox.Show("Se produjo un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                objConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
