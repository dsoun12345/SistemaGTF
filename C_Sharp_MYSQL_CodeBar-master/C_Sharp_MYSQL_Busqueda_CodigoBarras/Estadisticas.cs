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
using System.Windows.Forms.DataVisualization.Charting;

namespace C_Sharp_MYSQL_Busqueda_CodigoBarras
{
    public partial class Estadisticas : Form
    {
        private string GetMonthName(int monthNumber)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthNumber);
        }

        public Estadisticas()
        {
            InitializeComponent();
        }

        private void Estadisticas_Load(object sender, EventArgs e)
        {
          
        }

        private void MostrarGrafico()
        {
            string connectionString = "server=localhost;database=metaldb;user=root;password=user;port=3306;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT id, puntos_totales FROM puntos_A ORDER BY puntos_totales DESC";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                List<int> ids = new List<int>();
                List<int> puntosTotales = new List<int>();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("id");
                        int puntos = reader.GetInt32("puntos_totales");

                        ids.Add(id);
                        puntosTotales.Add(puntos);
                    }
                }

                chart1.Series.Clear(); // Borra cualquier serie anterior

                // Crea una nueva serie para el gráfico
                Series series = new Series("Puntos Totales");

                for (int i = 0; i < ids.Count; i++)
                {
                    int id = ids[i];
                    int puntos = puntosTotales[i];

                    series.Points.AddXY(id.ToString(), puntos);
                }

                chart1.Series.Add(series);

                // Ajusta el tipo de gráfico (por ejemplo, de barras)
                series.ChartType = SeriesChartType.Bar;

                // Personaliza el gráfico según tus necesidades
                // Por ejemplo, puedes agregar títulos, leyendas, etiquetas, etc.
                chart1.ChartAreas[0].AxisX.Title = "ID";
                chart1.ChartAreas[0].AxisY.Title = "Puntos Totales";
            }
        }

        private void MostrarGraficoVentasPorDia()
        {
            string connectionString = "server=localhost;database=metaldb;user=root;password=user;port=3306;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Filtrar ventas para el día actual
                DateTime fechaActual = DateTime.Now.Date;
                string formattedFechaActual = fechaActual.ToString("yyyy-MM-dd");

                string query = $"SELECT DATE(fecha_facturacion) AS fecha, " +
                               $"SUM(total) AS total_ventas, " +
                               $"nom_completos AS comprador_mas_grande " +
                               $"FROM gestion_ventas " +
                               $"WHERE DATE(fecha_facturacion) = '{formattedFechaActual}' " +
                               $"GROUP BY DATE(fecha_facturacion), nom_completos " +  // Agrupar también por nom_completos
                               $"ORDER BY total_ventas DESC " +
                               $"LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(query, connection);

                List<string> estadisticas = new List<string>();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    TotalDias.Clear();

                    while (reader.Read())
                    {
                        string fecha = reader.GetDateTime("fecha").ToShortDateString();
                        decimal totalVentas = reader.GetDecimal("total_ventas");
                        string comprador = reader.GetString("comprador_mas_grande");

                        // Formato ordenado para mostrar en RichTextBox
                        string estadistica = $"                             Ventas del Día\n\n" +
                                             $"Fecha: {fecha}\n\n" +
                                             $"Mejor Comprador del Día: {comprador}\n\n" +  // Cambiado el símbolo de moneda
                                             $"Gasto del Cliente: S/. {totalVentas:F2}\n\n";  // Modificado

                        // Agregar texto al RichTextBox
                        TotalDias.AppendText(estadistica);

                        // Aplicar negrita a los elementos específicos después de agregar el texto
                        TotalDias.Select(TotalDias.Text.IndexOf("Ventas del Día"), "Ventas del Día".Length);
                        TotalDias.SelectionFont = new Font(TotalDias.Font.FontFamily, 16, FontStyle.Bold);

                        TotalDias.Select(TotalDias.Text.IndexOf("Fecha:"), "Fecha:".Length);
                        TotalDias.SelectionFont = new Font(TotalDias.Font, FontStyle.Bold);

                        TotalDias.Select(TotalDias.Text.IndexOf("Mejor Comprador del Día:"), "Mejor Comprador del Día:".Length);
                        TotalDias.SelectionFont = new Font(TotalDias.Font, FontStyle.Bold);

                        TotalDias.Select(TotalDias.Text.IndexOf("Gasto del Cliente:"), "Gasto del Cliente:".Length);
                        TotalDias.SelectionFont = new Font(TotalDias.Font, FontStyle.Bold);

                        TotalDias.AppendText("\n\n");
                    }
                }
            }
        }

        private void MostrarSumaTotalVentasPorDia()
        {
            string connectionString = "server=localhost;database=metaldb;user=root;password=user;port=3306;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                DateTime fechaActual = DateTime.Now.Date;
                string formattedFechaActual = fechaActual.ToString("yyyy-MM-dd");

                string query = $"SELECT SUM(total) AS totalVentasDia " +
                               $"FROM gestion_ventas " +
                               $"WHERE DATE(fecha_facturacion) = '{formattedFechaActual}'";

                MySqlCommand cmd = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    Totalventasdeldia.Clear();

                    while (reader.Read())
                    {
                        decimal totalVentasDia = reader.GetDecimal("totalVentasDia");

                        // Mostrar la suma total en el RichTextBox
                        Totalventasdeldia.AppendText($"Gasto del Cliente: S/. {totalVentasDia:F2}\n");
                    }
                }
            }
        }


        private void CargarDatosEnGrafico()
        {
            TotalMes.Series.Clear();
            TotalMes.ChartAreas.Clear();
            TotalMes.Titles.Clear();

            int añoActual = DateTime.Now.Year;
            int mesActual = DateTime.Now.Month;  // Declarar la variable mesActual

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

                    seriesSumaTotal.Points.AddXY($"Día {dia}", sumaTotal);
                    seriesMejorCliente.Points.AddXY($"Día {dia}", detalleMejorCliente.GastoTotal);

                    // Agregar etiquetas de datos personalizadas
                    seriesSumaTotal.Points.Last().Label = $"Suma Total: {sumaTotal}\nCantidad Ventas: {cantidadVentas}";
                    seriesMejorCliente.Points.Last().Label = $"Mejor Cliente: {mejorComprador}\nGasto del Cliente: {detalleMejorCliente.GastoTotal}\nCantidad Compras: {detalleMejorCliente.CantidadCompras}";
                }
            }

            // Configurar el gráfico
            TotalMes.Titles.Add($"Ventas por Dia del Mes ({GetMonthName(mesActual)})");
            TotalMes.ChartAreas[0].AxisX.Title = "Día";
            TotalMes.ChartAreas[0].AxisY.Title = "Cantidad de Ventas";
        }

        private (decimal TotalVentas, int CantidadCompras, decimal GastoTotal) ObtenerDetalleMejorCliente(MySqlConnection connection, int año, int mes, int dia, string mejorComprador)
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

        private string ObtenerMejorClienteParaDia(MySqlConnection connection, int año, int mes, int dia)
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

        private void MostrarGraficoVentasPorAño()
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

                    // Modificar la línea donde se añade el punto al gráfico
                    seriesSumaTotal.Points.AddXY(nombreMes, sumaTotal);
                    seriesMejorCliente.Points.AddXY(nombreMes, detalleMejorCliente.GastoTotal);

                    // Agregar etiquetas de datos personalizadas
                    seriesSumaTotal.Points.Last().Label = $"Suma Total: {sumaTotal}\nCantidad Ventas: {cantidadVentas}";
                    seriesMejorCliente.Points.Last().Label = $"Mejor Cliente: {mejorComprador}\nGasto del Cliente: {detalleMejorCliente.GastoTotal}\nCantidad Compras: {detalleMejorCliente.CantidadCompras}";
                }
            }

            // Configurar el gráfico
            TotalAño.Titles.Add($"Ventas por Mes del Año {añoActual}");
            TotalAño.ChartAreas[0].AxisX.Title = "Mes";
            TotalAño.ChartAreas[0].AxisY.Title = "Cantidad de Ventas";
        }

        private string ObtenerMejorClienteParaMes(MySqlConnection connection, int año, int mes)
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

        private (decimal GastoTotal, int CantidadCompras) ObtenerDetalleMejorClientePorMes(MySqlConnection connection, int año, int mes, string mejorComprador)
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
            CargarDatosEnGrafico();
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
            MostrarGrafico();
        }
    }
}
