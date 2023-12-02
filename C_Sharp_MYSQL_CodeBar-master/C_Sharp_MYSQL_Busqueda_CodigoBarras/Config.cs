using C_Sharp_MYSQL_Busqueda_CodigoBarras.Clases;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Sharp_MYSQL_Busqueda_CodigoBarras
{
    public partial class Config : Form
    {
        private Conexion objetoConexion;

        public Config()
        {
            InitializeComponent();
            objetoConexion = new Conexion();


        }

        private void Config_Load(object sender, EventArgs e)
        {
            CargarUltimoValores();

        }

        private void btnguard1_Click(object sender, EventArgs e)
        {
            // Obtener el valor del IGV desde el TextBox
            decimal igvValue;
            decimal punto100Value;
            string inputValueIGV = txtigv1.Text;
            string inputValuePunto = txtpunto100.Text;

            // Reemplazar la coma (,) por punto (.) si está presente
            inputValueIGV = inputValueIGV.Replace(',', '.');
            inputValuePunto = inputValuePunto.Replace(',', '.');

            try
            {
                Conexion objConexion = new Conexion();
                MySqlConnection conn = objConexion.establecerConexion();

                // Verificar si al menos uno de los cuadros de texto tiene un valor numérico válido
                if (!decimal.TryParse(inputValueIGV, NumberStyles.Any, CultureInfo.InvariantCulture, out igvValue) &&
                    !decimal.TryParse(inputValuePunto, NumberStyles.Any, CultureInfo.InvariantCulture, out punto100Value))
                {
                    MessageBox.Show("Por favor, ingresa caracteres válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    objConexion.cerrarConexion();
                    return; // Salir del método si ambas entradas no son válidas
                }

                // Obtén el valor actual de la configuración
                decimal igvActual = 0;
                decimal punto100Actual = 0;

                string selectSql = "SELECT igv, valor_puntos FROM configuracion ORDER BY id DESC LIMIT 1";
                MySqlCommand selectCmd = new MySqlCommand(selectSql, conn);
                MySqlDataReader selectReader = selectCmd.ExecuteReader();

                if (selectReader.Read())
                {
                    igvActual = Convert.ToDecimal(selectReader["igv"]);
                    punto100Actual = Convert.ToDecimal(selectReader["valor_puntos"]);
                }

                selectReader.Close();

                // Elimina la fila anterior
                string deleteSql = "DELETE FROM configuracion";
                MySqlCommand deleteCmd = new MySqlCommand(deleteSql, conn);
                int deleteRowsAffected = deleteCmd.ExecuteNonQuery();

                // Inserta el nuevo valor
                string insertSql = "INSERT INTO configuracion (igv, valor_puntos) VALUES (@igv, @valorPuntos)";
                MySqlCommand insertCmd = new MySqlCommand(insertSql, conn);

                if (decimal.TryParse(inputValueIGV, NumberStyles.Any, CultureInfo.InvariantCulture, out igvValue))
                {
                    insertCmd.Parameters.AddWithValue("@igv", igvValue);
                }
                else
                {
                    insertCmd.Parameters.AddWithValue("@igv", igvActual); // Mantén el valor actual si no se proporciona uno nuevo
                }

                if (decimal.TryParse(inputValuePunto, NumberStyles.Any, CultureInfo.InvariantCulture, out punto100Value))
                {
                    insertCmd.Parameters.AddWithValue("@valorPuntos", punto100Value);
                }
                else
                {
                    insertCmd.Parameters.AddWithValue("@valorPuntos", punto100Actual); // Mantén el valor actual si no se proporciona uno nuevo
                }

                int insertRowsAffected = insertCmd.ExecuteNonQuery();
                if (insertRowsAffected > 0)
                {
                    MessageBox.Show("La configuración se actualizó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo aplicar los cambios. Asegúrate de ingresar valores o caracteres válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                objConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CargarUltimoValores();
            txtpunto100.Clear();
            txtigv1.Clear();
        }


        private void CargarUltimoValores()
        {
            try
            {
                Conexion objConexion = new Conexion();
                MySqlConnection conn = objConexion.establecerConexion();

                string sql = "SELECT igv, valor_puntos FROM configuracion ORDER BY id DESC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtigvbd.Text = reader["igv"].ToString();
                    txtpuntosvalor.Text = reader["valor_puntos"].ToString();
                }
                else
                {
                    txtigvbd.Text = ""; // Si no hay registros en la tabla configuracion
                    txtpuntosvalor.Text = ""; // También establece el campo de puntos en blanco si no hay registros
                }

                reader.Close();
                objConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar configuración: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void btnborrar1_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion objConexion = new Conexion();
                MySqlConnection conn = objConexion.establecerConexion();

                // Define la consulta SQL para eliminar todas las filas de la tabla configuracion
                string sql = "DELETE FROM configuracion";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("La configuración ha sido eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se encontraron configuraciones.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                objConexion.cerrarConexion();

                // Actualiza el TextBox con el valor actualizado o vacío si no hay registros
                CargarUltimoValores();
                txtpunto100.Clear();
                txtigv1.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al intentar eliminar la configuración: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtigv1_TextChanged(object sender, EventArgs e)
        {

        }

    }


}
