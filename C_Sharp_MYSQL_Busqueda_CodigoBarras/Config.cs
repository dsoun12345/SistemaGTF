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
            string inputValue = txtigv1.Text;
            string puntoValue = txtpunto100.Text;

            // Reemplazar la coma (,) por punto (.) si está presente
            inputValue = inputValue.Replace(',', '.');
            puntoValue = puntoValue.Replace(',', '.');

            if (decimal.TryParse(inputValue, NumberStyles.Any, CultureInfo.InvariantCulture, out igvValue) && decimal.TryParse(puntoValue, NumberStyles.Any, CultureInfo.InvariantCulture, out punto100Value))
            {
                try
                {
                    Conexion objConexion = new Conexion();
                    MySqlConnection conn = objConexion.establecerConexion();

                    // Elimina la fila anterior
                    string deleteSql = "DELETE FROM configuracion";
                    MySqlCommand deleteCmd = new MySqlCommand(deleteSql, conn);
                    int deleteRowsAffected = deleteCmd.ExecuteNonQuery();

                    // Inserta el nuevo valor
                    string insertSql = "INSERT INTO configuracion (igv, valor_puntos) VALUES (@igv, @valorPuntos)";
                    MySqlCommand insertCmd = new MySqlCommand(insertSql, conn);
                    insertCmd.Parameters.AddWithValue("@igv", igvValue);
                    insertCmd.Parameters.AddWithValue("@valorPuntos", punto100Value);

                    int insertRowsAffected = insertCmd.ExecuteNonQuery();
                    if (insertRowsAffected > 0)
                    {
                        MessageBox.Show("El valor del IGV y del punto 100 se han ingresado o actualizado correctamente en la tabla configuracion.");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo ingresar o actualizar el valor del IGV y del punto 100.");
                    }

                    objConexion.cerrarConexion();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al ingresar o actualizar el valor del IGV y del punto 100: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese valores válidos para el IGV y el punto 100.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CargarUltimoValores();

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
                MessageBox.Show("Error al cargar el último valor de IGV y puntos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void txtigv1_TextChanged(object sender, EventArgs e)
        {

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
                    MessageBox.Show("Todas las filas de la tabla configuracion se han eliminado correctamente.");
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar las filas de la tabla configuracion.");
                }

                objConexion.cerrarConexion();

                // Actualiza el TextBox con el valor actualizado o vacío si no hay registros
                CargarUltimoValores();
                txtpunto100.Text = ""; // Restablece el campo de punto 100 después de borrar
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar todas las filas de la tabla configuracion: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }


}
