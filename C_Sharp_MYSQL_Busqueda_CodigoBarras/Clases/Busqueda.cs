using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Sharp_MYSQL_Busqueda_CodigoBarras.Clases
{
    class Busqueda
    {
        public void buscarCodigo(TextBox txtBoxcodi, TextBox txtBoxDNI, TextBox txtBoxRUC, TextBox txtBoxRazonSocial, TextBox txtBoxDirec, TextBox txtBoxTelef)
        {
            Conexion objeto = new Conexion();
            MySqlConnection conn = objeto.establecerConexion();

            try
            {
                string sql = "SELECT cliente.dni, cliente.ruc, cliente.razon_social, cliente.direccion, cliente.telefono " +
                             "FROM cliente " +
                             "WHERE cliente.id = '" + txtBoxcodi.Text + "'";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    txtBoxDNI.Text = rdr[0].ToString();
                    txtBoxRUC.Text = rdr[1].ToString();
                    txtBoxRazonSocial.Text = rdr[2].ToString();
                    txtBoxDirec.Text = rdr[3].ToString();
                    txtBoxTelef.Text = rdr[4].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se logró realizar la búsqueda, error: " + ex.ToString());
            }
        }
    }
}
