using C_Sharp_MYSQL_Busqueda_CodigoBarras.Clases;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace C_Sharp_MYSQL_Busqueda_CodigoBarras
{
    public partial class Estadisticas : Form
    {
        

        public Estadisticas()
        {
            InitializeComponent();
        }

       
        private void MostrarGraficoDePuntos()
        {
            string connectionString = "server=localhost;database=metaldb;user=root;password=user;port=3306;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT pa.id, pa.puntos_totales, c.razon_social " +
                                   "FROM puntos_A pa " +
                                   "RIGHT JOIN cliente c ON pa.id = c.id " +
                                   "ORDER BY pa.puntos_totales DESC";

                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    List<string> razonesSociales = new List<string>();
                    List<int?> puntosTotales = new List<int?>();

                    // Bandera para indicar si hay clientes sin puntos
                    bool hayClientesSinPuntos = false;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.IsDBNull(reader.GetOrdinal("id")) ? 0 : reader.GetInt32("id");
                            int? puntos = reader.IsDBNull(reader.GetOrdinal("puntos_totales")) ? (int?)null : reader.GetInt32("puntos_totales");
                            string razonSocial = reader.IsDBNull(reader.GetOrdinal("razon_social")) ? string.Empty : reader.GetString("razon_social");

                            razonesSociales.Add(razonSocial);
                            puntosTotales.Add(puntos);

                            if (puntos == null)
                            {
                             
                                hayClientesSinPuntos = true;
                            }
                        }
                    }

                    if (razonesSociales.Count == 0)
                    {
                        MessageBox.Show("No hay datos disponibles para mostrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    chart1.Series.Clear();

                    Series series = new Series("Puntos Totales");

                    for (int i = 0; i < razonesSociales.Count; i++)
                    {
                        string razonSocial = razonesSociales[i];
                        int? puntos = puntosTotales[i];

                        series.Points.AddXY(razonSocial, puntos.GetValueOrDefault());
                    }

                    chart1.Series.Add(series);

                    series.ChartType = SeriesChartType.Bar;

                    chart1.ChartAreas[0].AxisX.Title = "Razón Social";
                    chart1.ChartAreas[0].AxisY.Title = "Puntos Totales";

                    // Configurar el gráfico

                    // Configurar el tamaño de letra de la leyenda
                    chart1.Legends[0].Font = new Font("Arial", 8);

                    chart1.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);
                    chart1.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);

                    // Configurar el tamaño de letra de los elementos del eje X e Y
                    chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 12);
                    chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 12);
                    chart1.ChartAreas[0].AxisX.Interval = 1; // Puedes ajustar el valor según tus necesidades


                    // Mostrar MessageBox si hay clientes sin puntos
                    if (hayClientesSinPuntos)
                    {
                        MessageBox.Show("Algunos usuarios no tienen puntos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (SqlNullValueException ex)
            {
                MessageBox.Show("Se produjo un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarGraficoVentasPorDia()
        {
            string connectionString = "server=localhost;database=metaldb;user=root;password=user;port=3306;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Filtrar ventas para el día actual
                    DateTime fechaActual = DateTime.Now.Date;
                    string formattedFechaActual = fechaActual.ToString("yyyy-MM-dd");

                    string query = $"SELECT DATE(fecha_facturacion) AS fecha, " +
                                   $"SUM(total) AS total_ventas, " +
                                   $"COUNT(*) AS cantidad_ventas, " +
                                   $"nom_completos AS comprador_mas_grande " +
                                   $"FROM gestion_ventas " +
                                   $"WHERE DATE(fecha_facturacion) = '{formattedFechaActual}' " +
                                   $"GROUP BY DATE(fecha_facturacion), nom_completos " +
                                   $"ORDER BY total_ventas DESC " +
                                   $"LIMIT 1";

                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        TotalDias.Clear();
                        Totalventasdeldia.Clear();

                        if (reader.Read())
                        {
                            string fecha = reader.GetDateTime(0).ToShortDateString(); // Usar el índice en lugar del nombre de columna
                            decimal? totalVentas = reader.IsDBNull(1) ? (decimal?)null : reader.GetDecimal(1); // Verificar si el valor es Null
                            int cantidadVentas = reader.GetInt32(2);
                            string comprador = reader.GetString(3);

                            // Formato ordenado para mostrar en RichTextBox
                            string estadistica = $"                             Ventas del Día\n\n" +
                                                 $"Fecha: {fecha}\n\n" +
                                                 $"Mejor Comprador del Día: {comprador}\n\n" +
                                                 $"Cantidad de Ventas: {cantidadVentas}\n\n" +
                                                 $"Gasto del Cliente: {(totalVentas.HasValue ? $"S/. {totalVentas:F2}" : "No disponible")}\n\n";

                            // Agregar texto al RichTextBox
                            TotalDias.AppendText(estadistica);

                            // Aplicar negrita a los elementos específicos después de agregar el texto
                            TotalDias.Select(TotalDias.Text.IndexOf("Ventas del Día"), "Ventas del Día".Length);
                            TotalDias.SelectionFont = new Font(TotalDias.Font.FontFamily, 16, FontStyle.Bold);

                            TotalDias.Select(TotalDias.Text.IndexOf("Fecha:"), "Fecha:".Length);
                            TotalDias.SelectionFont = new Font(TotalDias.Font, FontStyle.Bold);

                            TotalDias.Select(TotalDias.Text.IndexOf("Mejor Comprador del Día:"), "Mejor Comprador del Día:".Length);
                            TotalDias.SelectionFont = new Font(TotalDias.Font, FontStyle.Bold);

                            TotalDias.Select(TotalDias.Text.IndexOf("Cantidad de Ventas:"), "Cantidad de Ventas:".Length);
                            TotalDias.SelectionFont = new Font(TotalDias.Font, FontStyle.Bold);

                            TotalDias.Select(TotalDias.Text.IndexOf("Gasto del Cliente:"), "Gasto del Cliente:".Length);
                            TotalDias.SelectionFont = new Font(TotalDias.Font, FontStyle.Bold);

                            TotalDias.AppendText("\n\n");
                        }
                        else
                        {
                            // Mostrar mensaje si no hay datos disponibles
                            TotalDias.AppendText("No hay datos disponibles para mostrar.");
                            MessageBox.Show("No hay datos disponibles para mostrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarSumaTotalVentasPorDia()
        {
            string connectionString = "server=localhost;database=metaldb;user=root;password=user;port=3306;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    DateTime fechaActual = DateTime.Now.Date;
                    string formattedFechaActual = fechaActual.ToString("yyyy-MM-dd");

                    string query = $"SELECT COUNT(*) AS cantidadTotalVentas, " +
                                   $"SUM(total) AS totalVentasDia " +
                                   $"FROM gestion_ventas " +
                                   $"WHERE DATE(fecha_facturacion) = '{formattedFechaActual}'";

                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Totalventasdeldia.Clear();

                        if (reader.Read())
                        {
                            // Verificar si el valor es nulo antes de intentar leerlo
                            decimal totalVentasDia = reader.IsDBNull(reader.GetOrdinal("totalVentasDia")) ? 0 : reader.GetDecimal("totalVentasDia");
                            int cantidadTotalVentas = reader.IsDBNull(reader.GetOrdinal("cantidadTotalVentas")) ? 0 : reader.GetInt32("cantidadTotalVentas");

                            if (cantidadTotalVentas > 0) // Verificar si hay datos antes de mostrarlos
                            {
                                // Mostrar la suma total en el RichTextBox con negrita
                                Totalventasdeldia.AppendText($"\nSuma Total: S/. {totalVentasDia:F2}\n\n");

                                // Mostrar la cantidad total de ventas en el RichTextBox correspondiente con negrita
                                Totalventasdeldia.AppendText($"Cantidad Total de Ventas: {cantidadTotalVentas}\n");

                                // Aplicar negrita a los elementos específicos después de agregar el texto
                                Totalventasdeldia.Select(Totalventasdeldia.Text.IndexOf("Suma Total:"), "Suma Total:".Length);
                                Totalventasdeldia.SelectionFont = new Font(Totalventasdeldia.Font, FontStyle.Bold);

                                Totalventasdeldia.Select(Totalventasdeldia.Text.IndexOf("Cantidad Total de Ventas:"), "Cantidad Total de Ventas:".Length);
                                Totalventasdeldia.SelectionFont = new Font(Totalventasdeldia.Font, FontStyle.Bold);
                            }
                            else
                            {
                                // Mostrar mensaje si no hay datos disponibles
                                Totalventasdeldia.AppendText("No hay datos disponibles para mostrar.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void MostrarGraficoVentasPorMes()
        {
            try
            {
                TotalMes.Series.Clear();
                TotalMes.ChartAreas.Clear();
                TotalMes.Titles.Clear();

                int añoActual = DateTime.Now.Year;
                int mesActual = DateTime.Now.Month;

                string connectionString = "server=localhost;database=metaldb;user=root;password=user;port=3306;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string queryTotalVentas = $@"
                SELECT DAY(fecha_facturacion) AS dia,
                       COUNT(*) AS cantidad_ventas,
                       SUM(total) AS suma_total
                FROM gestion_ventas
                WHERE YEAR(fecha_facturacion) = {añoActual} AND MONTH(fecha_facturacion) = {mesActual}
                GROUP BY dia
                ORDER BY dia
            ";

                    MySqlCommand cmdTotalVentas = new MySqlCommand(queryTotalVentas, connection);

                    List<(int Dia, decimal SumaTotal, int CantidadVentas)> ventasPorDia = new List<(int Dia, decimal SumaTotal, int CantidadVentas)>();

                    using (MySqlDataReader reader = cmdTotalVentas.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int dia = reader.GetInt32("dia");
                            decimal sumaTotal = reader.GetDecimal("suma_total");
                            int cantidadVentas = reader.GetInt32("cantidad_ventas");
                            ventasPorDia.Add((dia, sumaTotal, cantidadVentas));
                        }
                    }

                    // Cerrar el DataReader después de cargar los datos
                    // Esto permite abrir un nuevo DataReader para la siguiente consulta
                    cmdTotalVentas.Dispose();

                    foreach (var venta in ventasPorDia)
                    {
                        int dia = venta.Dia;
                        decimal sumaTotal = venta.SumaTotal;
                        int cantidadVentas = venta.CantidadVentas;

                        if (TotalMes.ChartAreas.Count == 0)
                        {
                            ChartArea chartArea = new ChartArea();
                            TotalMes.ChartAreas.Add(chartArea);
                        }

                        Series seriesSumaTotal = null;
                        Series seriesMejorCliente = null;

                        foreach (Series s in TotalMes.Series)
                        {
                            if (s.Name == "SumaTotal")
                            {
                                seriesSumaTotal = s;
                            }
                            else if (s.Name == "MejorCliente")
                            {
                                seriesMejorCliente = s;
                            }
                        }

                        if (seriesSumaTotal == null)
                        {
                            seriesSumaTotal = new Series("SumaTotal");
                            seriesSumaTotal.ChartType = SeriesChartType.Column;
                            TotalMes.Series.Add(seriesSumaTotal);
                        }

                        if (seriesMejorCliente == null)
                        {
                            seriesMejorCliente = new Series("MejorCliente");
                            seriesMejorCliente.ChartType = SeriesChartType.Column;
                            TotalMes.Series.Add(seriesMejorCliente);
                        }

                        // Obtener el mejor cliente para el día actual
                        string mejorComprador = ObtenerMejorClienteParaDia(connection, añoActual, mesActual, dia);
                        var detalleMejorCliente = ObtenerDetalleMejorCliente(connection, añoActual, mesActual, dia, mejorComprador);

                        //seriesSumaTotal.Color = Color.Blue;
                        seriesSumaTotal.Points.AddXY($"Día {dia}", sumaTotal);

                        //seriesMejorCliente.Color = Color.Yellow;
                        seriesMejorCliente.Points.AddXY($"Día {dia}", detalleMejorCliente.GastoTotal);

                        // Agregar etiquetas de datos personalizadas
                        seriesSumaTotal.Points.Last().Label = $"Suma Total: {sumaTotal}\nCantidad Ventas: {cantidadVentas}";
                        seriesSumaTotal.Points.Last().Font = new Font("Arial", 8);

                        seriesMejorCliente.Points.Last().Label = $"Mejor Cliente: {mejorComprador}\nGasto del Cliente: {detalleMejorCliente.GastoTotal}\nCantidad Ventas: {detalleMejorCliente.CantidadCompras}";
                        seriesMejorCliente.Points.Last().Font = new Font("Arial", 8);
                    }
                }

                // Configurar el gráfico

                // Configurar el tamaño de letra de la leyenda
                TotalMes.Legends[0].Font = new Font("Arial", 7);

                // Ajusta la fuente del título del gráfico
                string nombreMes = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mesActual);
                nombreMes = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombreMes);
                TotalMes.Titles.Add($"Ventas por Dia del Mes ({nombreMes})");
                TotalMes.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);

                // Configura el tamaño de letra del título del eje Y
                TotalMes.ChartAreas[0].AxisY.Title = "Cantidad de Ventas";
                TotalMes.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);

                // Configura el tamaño de letra del título del eje X
                TotalMes.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 12, FontStyle.Bold);
                TotalMes.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
                TotalMes.ChartAreas[0].AxisX.Interval = 1;
                // Ajustar el espacio entre las barras
                TotalMes.Series["SumaTotal"]["PointWidth"] = "0.3";
                TotalMes.Series["MejorCliente"]["PointWidth"] = "0.3";
            }
            catch (SqlException)
            {
                MessageBox.Show($"No hay datos disponibles para mostrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show($"No hay datos disponibles para mostrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private (decimal TotalVentas, int CantidadCompras, decimal GastoTotal) ObtenerDetalleMejorCliente(MySqlConnection connection, int año, int mes, int dia, string mejorComprador)
        {
            try
            {
                string query = $@"
            SELECT SUM(total) AS total_ventas,
                   COUNT(*) AS cantidad_compras,
                   SUM(total) AS gasto_total
            FROM gestion_ventas
            WHERE YEAR(fecha_facturacion) = {año} AND MONTH(fecha_facturacion) = {mes} AND DAY(fecha_facturacion) = {dia}
                  AND nom_completos = @mejorComprador
        ";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@mejorComprador", mejorComprador);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        decimal totalVentas = reader.GetDecimal("total_ventas");
                        int cantidadCompras = reader.GetInt32("cantidad_compras");
                        decimal gastoTotal = reader.GetDecimal("gasto_total");

                        return (totalVentas, cantidadCompras, gastoTotal);
                    }
                }

                // Si no hay datos, devolver valores predeterminados
                return (0, 0, 0);
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Se produjo un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (0, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (0, 0, 0);
            }
        }

        private string ObtenerMejorClienteParaDia(MySqlConnection connection, int año, int mes, int dia)
        {
            try
            {
                string query = $@"
            SELECT nom_completos
            FROM (
                SELECT nom_completos, SUM(total) AS total_ventas
                FROM gestion_ventas
                WHERE YEAR(fecha_facturacion) = {año} AND MONTH(fecha_facturacion) = {mes} AND DAY(fecha_facturacion) = {dia}
                GROUP BY nom_completos
                ORDER BY total_ventas DESC
                LIMIT 1
            ) AS MejorClientePorDia
        ";

                MySqlCommand cmd = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetString("nom_completos");
                    }
                }

                return string.Empty;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Se produjo un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        private void MostrarGraficoVentasPorAño()
        {
            try
            {
                TotalAño.Series.Clear();
                TotalAño.ChartAreas.Clear();
                TotalAño.Titles.Clear();

                int añoActual = DateTime.Now.Year;

                string connectionString = "server=localhost;database=metaldb;user=root;password=user;port=3306;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string queryTotalVentas = $@"
                SELECT MONTH(fecha_facturacion) AS mes,
                       COUNT(*) AS cantidad_ventas,
                       SUM(total) AS suma_total
                FROM gestion_ventas
                WHERE YEAR(fecha_facturacion) = {añoActual}
                GROUP BY mes
                ORDER BY mes
            ";

                    MySqlCommand cmdTotalVentas = new MySqlCommand(queryTotalVentas, connection);

                    List<(int Mes, decimal SumaTotal, int CantidadVentas)> ventasPorMes = new List<(int Mes, decimal SumaTotal, int CantidadVentas)>();

                    using (MySqlDataReader reader = cmdTotalVentas.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int mes = reader.GetInt32("mes");
                            decimal sumaTotal = reader.GetDecimal("suma_total");
                            int cantidadVentas = reader.GetInt32("cantidad_ventas");
                            ventasPorMes.Add((mes, sumaTotal, cantidadVentas));
                        }
                    }

                    // Cerrar el DataReader después de cargar los datos
                    // Esto permite abrir un nuevo DataReader para la siguiente consulta
                    cmdTotalVentas.Dispose();

                    foreach (var venta in ventasPorMes)
                    {

                        int mes = venta.Mes;
                        decimal sumaTotal = venta.SumaTotal;
                        int cantidadVentas = venta.CantidadVentas;

                        if (TotalAño.ChartAreas.Count == 0)
                        {
                            ChartArea chartArea = new ChartArea();
                            TotalAño.ChartAreas.Add(chartArea);
                        }

                        Series seriesSumaTotal = null;
                        Series seriesMejorCliente = null;

                        foreach (Series s in TotalAño.Series)
                        {
                            if (s.Name == "SumaTotal")
                            {
                                seriesSumaTotal = s;
                            }
                            else if (s.Name == "MejorCliente")
                            {
                                seriesMejorCliente = s;
                            }
                        }

                        if (seriesSumaTotal == null)
                        {
                            seriesSumaTotal = new Series("SumaTotal");
                            seriesSumaTotal.ChartType = SeriesChartType.Column;
                            TotalAño.Series.Add(seriesSumaTotal);
                        }

                        if (seriesMejorCliente == null)
                        {
                            seriesMejorCliente = new Series("MejorCliente");
                            seriesMejorCliente.ChartType = SeriesChartType.Column;
                            TotalAño.Series.Add(seriesMejorCliente);
                        }

                        // Obtener el mejor cliente para el mes actual
                        string mejorComprador = ObtenerMejorClienteParaMes(connection, añoActual, mes);
                        var detalleMejorCliente = ObtenerDetalleMejorClientePorMes(connection, añoActual, mes, mejorComprador);

                        // Obtener el nombre del mes en lugar del número
                        string nombreMes = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mes);
                        nombreMes = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombreMes);
                        // Modificar la línea donde se añade el punto al gráfico

                        //seriesSumaTotal.Color = Color.Blue;
                        seriesSumaTotal.Points.AddXY(nombreMes, sumaTotal);

                        //seriesMejorCliente.Color = Color.Yellow;
                        seriesMejorCliente.Points.AddXY(nombreMes, detalleMejorCliente.GastoTotal);

                        // Configurar el tamaño de letra del texto encima de las barras

                        seriesSumaTotal.Points.Last().LabelForeColor = Color.Black; // Puedes ajustar el color del texto si es necesario
                        seriesSumaTotal.Points.Last().Font = new Font("Arial", 8); // Ajusta la fuente del texto encima de las barras

                        seriesMejorCliente.Points.Last().LabelForeColor = Color.Black; // Puedes ajustar el color del texto si es necesario
                        seriesMejorCliente.Points.Last().Font = new Font("Arial", 8); // Ajusta la fuente del texto encima de las barras

                        // Agregar etiquetas de datos personalizadas
                        seriesSumaTotal.Points.Last().Label = $"Suma Total: {sumaTotal}\nCantidad Ventas: {cantidadVentas}";
                        seriesMejorCliente.Points.Last().Label = $"Mejor Cliente: {mejorComprador}\nGasto del Cliente: {detalleMejorCliente.GastoTotal}\nCantidad Ventas: {detalleMejorCliente.CantidadCompras}";

                        // Ajustar el espacio entre las barras
                        TotalAño.Series["SumaTotal"]["PointWidth"] = "0.6";
                        TotalAño.Series["MejorCliente"]["PointWidth"] = "0.6";
                       
                    }
                }

                // Configurar el gráfico

                // Ajusta la fuente de la leyenda
                TotalAño.Legends[0].Font = new Font("Arial", 8);

                // Ajusta la fuente del título del gráfico
                TotalAño.Titles.Add($"Ventas por Mes del Año {añoActual}");
                TotalAño.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);

                // Configura el tamaño de letra del título del eje Y
                TotalAño.ChartAreas[0].AxisY.Title = "Cantidad de Ventas";
                TotalAño.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);

                // Configura el tamaño de letra del título del eje X
                TotalAño.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 10, FontStyle.Bold);
                TotalAño.ChartAreas[0].AxisX.LabelStyle.Angle = -45; 
                TotalAño.ChartAreas[0].AxisX.Interval = 1;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"No hay datos disponibles para mostrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No hay datos disponibles para mostrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string ObtenerMejorClienteParaMes(MySqlConnection connection, int año, int mes)
        {
            try
            {
                string query = $@"
            SELECT nom_completos
            FROM (
                SELECT nom_completos, SUM(total) AS total_ventas
                FROM gestion_ventas
                WHERE YEAR(fecha_facturacion) = {año} AND MONTH(fecha_facturacion) = {mes}
                GROUP BY nom_completos
                ORDER BY total_ventas DESC
                LIMIT 1
            ) AS MejorClientePorMes
        ";

                MySqlCommand cmd = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetString("nom_completos");
                    }
                }

                return string.Empty;
            }
            catch (MySqlException ex)
            {
                // Manejar excepciones específicas de MySQL
                MessageBox.Show($"Se produjo un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones generales
                MessageBox.Show($"Se produjo un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        private (decimal GastoTotal, int CantidadCompras) ObtenerDetalleMejorClientePorMes(MySqlConnection connection, int año, int mes, string mejorComprador)
        {
            try
            {
                string query = $@"
            SELECT SUM(total) AS gasto_total,
                   COUNT(*) AS cantidad_compras
            FROM gestion_ventas
            WHERE YEAR(fecha_facturacion) = {año} AND MONTH(fecha_facturacion) = {mes}
                  AND nom_completos = @mejorComprador
        ";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@mejorComprador", mejorComprador);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        decimal gastoTotal = reader.GetDecimal("gasto_total");
                        int cantidadCompras = reader.GetInt32("cantidad_compras");

                        return (gastoTotal, cantidadCompras);
                    }
                }

                // Si no hay datos, devolver valores predeterminados
                return (0, 0);
            }
            catch (MySqlException ex)
            {
                // Manejar excepciones específicas de MySQL
                MessageBox.Show($"Se produjo un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (0, 0);
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones generales
                MessageBox.Show($"Se produjo un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (0, 0);
            }
        }

        private void btndia_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            TotalAño.Visible = false;
            TotalDias.Visible = true;
            Totalventasdeldia.Visible = true;
            TotalMes.Visible = false;

            MostrarGraficoVentasPorDia();
            MostrarSumaTotalVentasPorDia();
        }

        private void btnmes_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            TotalAño.Visible = false;
            TotalDias.Visible = false;
            TotalMes.Visible = true;
            Totalventasdeldia.Visible = false;
            MostrarGraficoVentasPorMes();
        }

        private void btnaño_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            TotalAño.Visible = true;
            TotalDias.Visible = false;
            TotalMes.Visible = false;
            Totalventasdeldia.Visible = false;
            MostrarGraficoVentasPorAño();
        }

        private void btnclientes_Click(object sender, EventArgs e)
        {
            chart1.Visible = true;
            TotalAño.Visible = false;
            TotalDias.Visible = false;
            TotalMes.Visible = false;
            Totalventasdeldia.Visible = false;
            MostrarGraficoDePuntos();
        }

        private void Estadisticas_Load(object sender, EventArgs e)
        {

        }

    }
}
