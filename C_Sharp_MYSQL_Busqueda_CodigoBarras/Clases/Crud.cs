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
    internal class Crud
    {
        public void mostrar(DataGridView tabla)
        {
            try{

                Conexion objConexion = new Conexion();

                
                tabla.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM cliente", objConexion.establecerConexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tabla.DataSource = dt;
                objConexion.cerrarConexion();


            }
            catch (Exception ex) {
                MessageBox.Show("No se mostraron los datos de la DB" + ex.ToString());
            
            }
        }

        public void guardar(TextBox dni, TextBox ruc, TextBox nombres, TextBox apellidos, TextBox razonSocial, TextBox direccion, TextBox telefono)
        {
            try
            {
                Conexion objConexion = new Conexion();
                string dniText = dni.Text.Trim();
                string rucText = ruc.Text.Trim();

                if (dniText.Length != 8)
                {
                    MessageBox.Show("El DNI debe tener exactamente 8 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (rucText.Length != 11)
                {
                    MessageBox.Show("El RUC debe tener exactamente 11 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string query = "INSERT INTO cliente (dni, ruc, nombres, apellidos, razon_social, direccion, telefono) VALUES (@dni, @ruc, @nombres, @apellidos, @razonSocial, @direccion, @telefono)";
                MySqlCommand MyCommand = new MySqlCommand(query, objConexion.establecerConexion());
                MyCommand.Parameters.AddWithValue("@dni", dniText);
                MyCommand.Parameters.AddWithValue("@ruc", rucText);
                MyCommand.Parameters.AddWithValue("@nombres", nombres.Text);
                MyCommand.Parameters.AddWithValue("@apellidos", apellidos.Text);
                MyCommand.Parameters.AddWithValue("@razonSocial", razonSocial.Text);
                MyCommand.Parameters.AddWithValue("@direccion", direccion.Text);
                MyCommand.Parameters.AddWithValue("@telefono", telefono.Text);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                reader.Close();

                // Añadir registros en la tabla puntos_A
                string puntosQuery = "INSERT INTO puntos_A (dni, ruc) VALUES (@dni, @ruc)";
                MySqlCommand puntosCommand = new MySqlCommand(puntosQuery, objConexion.establecerConexion());
                puntosCommand.Parameters.AddWithValue("@dni", dniText);
                puntosCommand.Parameters.AddWithValue("@ruc", rucText);

                puntosCommand.ExecuteNonQuery();

                MessageBox.Show("Se guardaron los registros correctamente.");
                objConexion.cerrarConexion();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al guardar los registros en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void seleccionar(DataGridView tablaCliente, TextBox id, TextBox dni, TextBox ruc, TextBox nombres, TextBox apellidos, TextBox razonSocial, TextBox direccion, TextBox telefono)
        {
            try
            {
                id.Text = tablaCliente.CurrentRow.Cells["id"].Value.ToString();
                dni.Text = tablaCliente.CurrentRow.Cells["dni"].Value.ToString();
                ruc.Text = tablaCliente.CurrentRow.Cells["ruc"].Value.ToString(); // Agrega esta línea para cargar el campo RUC
                nombres.Text = tablaCliente.CurrentRow.Cells["nombres"].Value.ToString();
                apellidos.Text = tablaCliente.CurrentRow.Cells["apellidos"].Value.ToString();
                razonSocial.Text = tablaCliente.CurrentRow.Cells["razon_social"].Value.ToString(); // Modifica el nombre de la columna
                direccion.Text = tablaCliente.CurrentRow.Cells["direccion"].Value.ToString();
                telefono.Text = tablaCliente.CurrentRow.Cells["telefono"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se logró seleccionar los datos de la DB: " + ex.ToString());
            }
        }



        public void modificar(TextBox id, TextBox dni, TextBox ruc, TextBox nombres, TextBox apellidos, TextBox razonSocial, TextBox direccion, TextBox telefono)
        {
            try
            {
                Conexion objConexion = new Conexion();
                string query = "UPDATE cliente SET dni = @dni, ruc = @ruc, nombres = @nombres, apellidos = @apellidos, razon_social = @razonSocial, direccion = @direccion, telefono = @telefono WHERE id = @id";
                MySqlCommand MyCommand = new MySqlCommand(query, objConexion.establecerConexion());
                MyCommand.Parameters.AddWithValue("@id", id.Text);
                MyCommand.Parameters.AddWithValue("@dni", dni.Text);
                MyCommand.Parameters.AddWithValue("@ruc", ruc.Text);
                MyCommand.Parameters.AddWithValue("@nombres", nombres.Text);
                MyCommand.Parameters.AddWithValue("@apellidos", apellidos.Text);
                MyCommand.Parameters.AddWithValue("@razonSocial", razonSocial.Text);
                MyCommand.Parameters.AddWithValue("@direccion", direccion.Text);
                MyCommand.Parameters.AddWithValue("@telefono", telefono.Text);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                reader.Close();

                // Modificar registros en la tabla puntos_A
                string puntosQuery = "UPDATE puntos_A SET dni = @dni, ruc = @ruc WHERE id = @id";
                MySqlCommand puntosCommand = new MySqlCommand(puntosQuery, objConexion.establecerConexion());
                puntosCommand.Parameters.AddWithValue("@id", id.Text);
                puntosCommand.Parameters.AddWithValue("@dni", dni.Text);
                puntosCommand.Parameters.AddWithValue("@ruc", ruc.Text);

                puntosCommand.ExecuteNonQuery();

                MessageBox.Show("Se modificaron los registros correctamente.");
                objConexion.cerrarConexion();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al modificar los registros en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void eliminar(TextBox id)
        {
            try
            {
                Conexion objConexion = new Conexion();

                // Eliminar el cliente de la tabla cliente por su ID
                string deleteClienteQuery = "DELETE FROM cliente WHERE id = @id";
                MySqlCommand deleteClienteCommand = new MySqlCommand(deleteClienteQuery, objConexion.establecerConexion());
                deleteClienteCommand.Parameters.AddWithValue("@id", id.Text);
                deleteClienteCommand.ExecuteNonQuery();

                // Eliminar el cliente de la tabla puntos_A por su ID
                string deletePuntosQuery = "DELETE FROM puntos_A WHERE id = @id";
                MySqlCommand deletePuntosCommand = new MySqlCommand(deletePuntosQuery, objConexion.establecerConexion());
                deletePuntosCommand.Parameters.AddWithValue("@id", id.Text);
                deletePuntosCommand.ExecuteNonQuery();

                MessageBox.Show("Se eliminó el registro seleccionado en ambas tablas.");

                objConexion.cerrarConexion();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al eliminar el registro en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}