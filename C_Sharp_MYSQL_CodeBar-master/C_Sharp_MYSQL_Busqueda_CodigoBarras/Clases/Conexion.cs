using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Sharp_MYSQL_Busqueda_CodigoBarras.Clases
{
    class Conexion
    {
        MySqlConnection conex = new MySqlConnection();

        static string servidor = "localhost";
        static string bd = "metaldb";
        static string usuario = "root";
        static string password = "user";
        static string puerto = "3306";

        string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";


        public MySqlConnection establecerConexion() {

            try
            {
                if (conex.State == ConnectionState.Closed)
                {
                    conex.ConnectionString = cadenaConexion;
                    conex.Open();
                    
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("No se logró conectar a la base de datos, error: " + e.ToString());
            }

            return conex;

        }

        public void cerrarConexion(){
            conex.Close();

        }
}
}