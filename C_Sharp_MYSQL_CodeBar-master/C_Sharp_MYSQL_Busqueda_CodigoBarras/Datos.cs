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
    public partial class Datos : Form
    {
        public Datos()
        {
            InitializeComponent();
            Clases.Crud objtabla = new Clases.Crud();
            objtabla.mostrar(dataGridView1);
            // Bloquear el TextBox (puedes elegir mantener o quitar una de estas líneas)
            txtID1.ReadOnly = true;
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
        }
        
        private void Datos_Load(object sender, EventArgs e)
        {
            txtID1.ForeColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clases.Crud objtabla = new Clases.Crud();

            // Verificar si el campo ID no está vacío
            if (!string.IsNullOrWhiteSpace(txtID1.Text))
            {
                MessageBox.Show("Por favor, deja el campo ID vacío al agregar un nuevo registro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir de la función sin ejecutar la inserción
            }

            // Verificar si algún campo de entrada está vacío
            if (string.IsNullOrWhiteSpace(txtdni2.Text) || string.IsNullOrWhiteSpace(txtruc1.Text) ||
                string.IsNullOrWhiteSpace(txtNombreC1.Text) || string.IsNullOrWhiteSpace(txtApellidoC1.Text) /* Agrega más campos aquí */)
            {
                MessageBox.Show("Por favor, ingresa datos en todos los campos antes de agregar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir de la función sin ejecutar la inserción
            }

            // Validar que solo se ingresen letras y espacios en los campos de nombres y apellidos
            if (!ValidarTexto(txtNombreC1.Text) || !ValidarTexto(txtApellidoC1.Text))
            {
                MessageBox.Show("Por favor, ingrese caracteres válidos en los campos de nombres y apellidos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            objtabla.guardar(txtdni2, txtruc1, txtNombreC1, txtApellidoC1, txtRazonSocialC1, txtDireccionC1, txtTelefonoC1);
            objtabla.mostrar(dataGridView1);
            txtID1.Clear();
            txtdni2.Clear();
            txtruc1.Clear();
            txtNombreC1.Clear();
            txtApellidoC1.Clear();
            txtDireccionC1.Clear();
            txtTelefonoC1.Clear();
            txtRazonSocialC1.Clear();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Clases.Crud objtabla = new Clases.Crud();
            objtabla.seleccionar(dataGridView1, txtID1, txtdni2, txtruc1, txtNombreC1, txtApellidoC1, txtRazonSocialC1, txtDireccionC1, txtTelefonoC1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clases.Crud objtabla = new Clases.Crud();

            // Verificar si algún campo de entrada está vacío
            if (string.IsNullOrWhiteSpace(txtID1.Text) || string.IsNullOrWhiteSpace(txtdni2.Text) ||
                string.IsNullOrWhiteSpace(txtNombreC1.Text) || string.IsNullOrWhiteSpace(txtApellidoC1.Text) /* Agrega más campos aquí */)
            {
                MessageBox.Show("Por favor, selecciona un usuario antes de intentar modificarlo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir de la función sin ejecutar la modificación
            }

            // Validar que solo se ingresen letras y espacios en los campos de nombres y apellidos
            if (!ValidarTexto(txtNombreC1.Text) || !ValidarTexto(txtApellidoC1.Text))
            {
                MessageBox.Show("Por favor, ingrese caracteres válidos en los campos de nombres y apellidos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            objtabla.modificar(txtID1, txtdni2, txtruc1, txtNombreC1, txtApellidoC1, txtRazonSocialC1, txtDireccionC1, txtTelefonoC1);
            objtabla.mostrar(dataGridView1);
            txtID1.Clear();
            txtdni2.Clear();
            txtruc1.Clear();
            txtNombreC1.Clear();
            txtApellidoC1.Clear();
            txtDireccionC1.Clear();
            txtTelefonoC1.Clear();
            txtRazonSocialC1.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clases.Crud objtabla = new Clases.Crud();

            // Verificar si el campo ID está vacío
            if (string.IsNullOrWhiteSpace(txtID1.Text))
            {
                MessageBox.Show("Por favor, selecciona un usuario antes de intentar eliminarlo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir de la función sin ejecutar la eliminación
            }

            objtabla.eliminar(txtID1);
            objtabla.mostrar(dataGridView1);
            txtID1.Clear();
            txtdni2.Clear();
            txtruc1.Clear();
            txtNombreC1.Clear();
            txtApellidoC1.Clear();
            txtDireccionC1.Clear();
            txtTelefonoC1.Clear();
            txtRazonSocialC1.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtID1.Clear();
            txtdni2.Clear();
            txtruc1.Clear();
            txtNombreC1.Clear();
            txtApellidoC1.Clear();
            txtDireccionC1.Clear();
            txtTelefonoC1.Clear();
            txtRazonSocialC1.Clear();
        }


        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.HeaderCell != null)
                {
                    string headerText = column.HeaderText.ToLower(); // Convertir el encabezado a minúsculas

                    // Cambiar el encabezado de la columna a mayúsculas
                    column.HeaderCell.Value = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(headerText);

                    // Establecer el ancho deseado para todas las columnas en píxeles
                    
                    if (column.Name == "id")
                    {
                        column.Width = 55; // Ancho deseado para la columna "ID" en píxeles
                    }
                    else if (column.Name == "dni")
                    {
                        column.Width = 85; // Ancho deseado para la columna "DNI" en píxeles
                    }
                    else if (column.Name == "ruc")
                    {
                        column.Width = 110; // Ancho deseado para la columna "DNI" en píxeles
                    }
                    else if (column.Name == "nombres")
                    {
                        column.Width = 205; // Ancho deseado para la columna "RUC" en píxeles
                    }
                    else if (column.Name == "apellidos")
                    {
                        column.Width = 200; // Ancho deseado para la columna "RUC" en píxeles
                    }
                    else if (column.Name == "telefono")
                    {
                        column.Width = 90; // Ancho deseado para la columna "RUC" en píxeles
                    }
                    else if (column.Name == "razon_social")
                    {
                        column.Width = 290; // Ancho deseado para la columna "RUC" en píxeles
                    }
                    else if (column.Name == "direccion")
                    {
                        column.Width = 290; // Ancho deseado para la columna "direccion" en píxeles
                    }
                    else
                    {
                        column.Width = 200; // Ancho deseado para otras columnas en píxeles
                    }
                }
            }

            // Ajusta las columnas "ID", "DNI" y "RUC" a mayúsculas
            dataGridView1.Columns["ID"].HeaderText = "ID";
            dataGridView1.Columns["DNI"].HeaderText = "DNI";
            dataGridView1.Columns["RUC"].HeaderText = "RUC";
        }

        private bool ValidarTexto(string texto)
        {
            // Verificar que el texto solo contenga letras y espacios
            return texto.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1 && e.Value != null)
            {
                // Verificar si estamos formateando la fila de encabezados (-1) y el valor no es nulo
                e.Value = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(e.Value.ToString().ToLower());
                e.FormattingApplied = true;
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtID1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
