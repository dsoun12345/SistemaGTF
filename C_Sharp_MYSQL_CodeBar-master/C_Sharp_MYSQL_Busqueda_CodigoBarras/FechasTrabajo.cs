﻿using C_Sharp_MYSQL_Busqueda_CodigoBarras.Clases;
using Microsoft.Win32;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace C_Sharp_MYSQL_Busqueda_CodigoBarras
{
    public partial class FechasTrabajo : Form
    {
        // Agrega tu cadena de conexión a MySQL
        private MySqlConnection conexion;
        private string cadenaConexion = "server=localhost;database=metaldb;user=root;password=user;port=3306;";

        public FechasTrabajo()
        {
            InitializeComponent();
            // Inicializa tu conexión a la base de datos
            conexion = new MySqlConnection(cadenaConexion);
            try
            {
                conexion.Open();
                // Maneja la conexión a la base de datos
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
            }
        }

        private void ObtenerDescripcionesDesdeDB()
        {
            // Limpiar el cuadro de texto
            txtDescripcion1.Clear();

            string codigoDni = txtCodDni.Text;
            DateTime fechaInicio, fechaFin;

            if (!DateTime.TryParseExact(txtFecIni.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaInicio) ||
                !DateTime.TryParseExact(txtFecFin.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaFin))
            {
                MessageBox.Show("Por favor, ingrese fechas válidas en los campos de inicio y fin en el formato día/mes/año (por ejemplo, 22/10/2023).");
                return;
            }

            string fechaInicioBD = fechaInicio.ToString("yyyy-MM-dd");
            string fechaFinBD = fechaFin.ToString("yyyy-MM-dd");

            string consultaSQL = "SELECT fecha_entrega, descripcion FROM gestion_ventas " +
                      "WHERE (codigotarjeta = @codigoDni OR DNI = @codigoDni) " +
                      "AND fecha_entrega >= @fechaInicio AND fecha_entrega <= @fechaFin " +
                      "ORDER BY fecha_entrega ASC";

            MySqlCommand cmd = new MySqlCommand(consultaSQL, conexion);
            cmd.Parameters.AddWithValue("@codigoDni", codigoDni);
            cmd.Parameters.AddWithValue("@fechaInicio", fechaInicioBD);
            cmd.Parameters.AddWithValue("@fechaFin", fechaFinBD);

            try
            {
                List<string> registrosEncontrados = new List<string>();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime fechaEntrega = reader.GetDateTime("fecha_entrega");
                        string descripcionSinFormato = reader["descripcion"].ToString();

                        string[] descripciones = descripcionSinFormato.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string desc in descripciones)
                        {
                            string[] datos = desc.Split(',');
                            if (datos.Length >= 6)
                            {
                                // Construir el registro y agregarlo a la lista
                                string registro = $"{fechaEntrega.ToShortDateString()},{datos[0].Trim()},{datos[1].Trim()},{datos[2].Trim()},{datos[3].Trim()},{datos[4].Trim()},{datos[5].Trim()}";
                                registrosEncontrados.Add(registro);
                            }
                        }
                    }
                }

                // Mostrar los resultados en el RichTextBox
                FormatearRichTextBox(registrosEncontrados.ToArray());
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al obtener descripciones desde la base de datos: " + ex.Message);
            }
        }

        private void FormatearRichTextBox(string[] registros)
        {
            // Configurar el formato del contenido antes del bucle
            txtDescripcion1.SelectionFont = new Font("Courier New", 12, FontStyle.Regular);

            int numeroRegistro = 1; // Inicializar el número de registro

            foreach (var registro in registros)
            {
                string[] campos = registro.Split(',');
                if (campos.Length >= 6)
                {
                    // Agregar título del registro
                    txtDescripcion1.SelectionFont = new Font("Century Gothic", 14, FontStyle.Bold);
                    txtDescripcion1.AppendText($"Registro {numeroRegistro}:\n");
                    numeroRegistro++;

                    // Configurar el formato del contenido
                    txtDescripcion1.SelectionFont = new Font("Courier New", 12, FontStyle.Regular);

                    txtDescripcion1.AppendText($"Fecha de Entrega: {campos[0].Trim()}\n");
                    txtDescripcion1.AppendText($"Cantidad: {campos[1].Trim()}\n");
                    txtDescripcion1.AppendText($"Descripción: {campos[2].Trim()}\n");
                    txtDescripcion1.AppendText($"Tamaño de Corte: {campos[3].Trim()}\n");
                    txtDescripcion1.AppendText($"Tipo de Corte: {campos[4].Trim()}\n");
                    txtDescripcion1.AppendText($"Material: {campos[5].Trim()}\n");
                    txtDescripcion1.AppendText($"Precio: {campos[6].Trim()}\n");
                    txtDescripcion1.AppendText("\n\n");
                }
            }
        }

        private void FechasTrabajo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conexion != null && conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }

        private void FechasTrabajo_Load(object sender, EventArgs e)
        {

        }

        private void btnguardar0_Click(object sender, EventArgs e)
        {
            ObtenerDescripcionesDesdeDB();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
