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
                    MessageBox.Show("Error al cargar los puntos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un valor válido en el campo Código.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Error al cargar el último valor de IGV y puntos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (puntosAplicados <= puntosAcumulados) // Verifica si los puntos aplicados no son mayores que los puntos acumulados
                {
                    // Realiza la resta de puntos acumulados y puntos aplicados
                    int nuevosPuntosAcumulados = puntosAcumulados - puntosAplicados;

                    // Actualiza la tabla puntos_A con los nuevos puntos acumulados
                    try
                    {
                        Conexion objConexion = new Conexion();
                        MySqlConnection conn = objConexion.establecerConexion();

                        string sql = "UPDATE puntos_A SET puntos = @nuevosPuntos WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@nuevosPuntos", nuevosPuntosAcumulados);
                        cmd.Parameters.AddWithValue("@id", idPuntosA);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Actualización exitosa
                            MessageBox.Show("Puntos actualizados en la tabla puntos_A.");

                            // Obtén el valor de txtpuntosvalor y verifica si es válido
                            decimal valorPuntos;
                            if (decimal.TryParse(txtpuntosvalor.Text, out valorPuntos))
                            {
                                // Calcula el valor del descuento
                                decimal descuento = (puntosAplicados * valorPuntos) / 100;
                                txtvalordescu.Text = descuento.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Verifica que el valor de puntos sea válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar los puntos en la tabla puntos_A.");
                        }

                        objConexion.cerrarConexion();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al actualizar los puntos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Los puntos aplicados no pueden ser mayores que los puntos acumulados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Verifica que los valores ingresados sean válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
