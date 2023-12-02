using C_Sharp_MYSQL_Busqueda_CodigoBarras.Clases;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Text.RegularExpressions;

namespace C_Sharp_MYSQL_Busqueda_CodigoBarras
{
    public partial class Facts : Form
    {
        public Facts()
        {

            InitializeComponent();
            cboFtPr.SelectedIndexChanged += cboFtPr_SelectedIndexChanged;

            Conexion objConexion = new Conexion();

            
            // Agregar las opciones al ComboBox tipo 
            cbotipop.Items.Add("-------------------");
            cbotipop.Items.Add("Con Tarjeta Cliente");
            cbotipop.Items.Add("Sin Tarjeta Cliente");


            // Agregar las opciones al ComboBox tipos
            cboFtPr.Items.Add("Proforma");
            cboFtPr.Items.Add("Venta");

            // Agregar las opciones al ComboBox tipos
            cbotipago1.Items.Add("-------------");
            cbotipago1.Items.Add("Efectivo");
            cbotipago1.Items.Add("Tarjeta");
            cbotipago1.Items.Add("Cheque");
            cbotipago1.Items.Add("Transferencia");

            

            // Agregar las opciones al ComboBox grados
            cbocorte.Items.Add("30°");
            cbocorte.Items.Add("45°");
            cbocorte.Items.Add("60°");
            cbocorte.Items.Add("90°");
            cbocorte.Items.Add("180°");
            cbocorte.Items.Add("270°");
            cbocorte.Items.Add("Personalizado");

            // Agregar las opciones al ComboBox grados
            cbocorte1.Items.Add("30°");
            cbocorte1.Items.Add("45°");
            cbocorte1.Items.Add("60°");
            cbocorte1.Items.Add("90°");
            cbocorte1.Items.Add("180°");
            cbocorte1.Items.Add("270°");
            cbocorte1.Items.Add("Personalizado");

            // Agregar las opciones al ComboBox grados
            cbocorte2.Items.Add("30°");
            cbocorte2.Items.Add("45°");
            cbocorte2.Items.Add("60°");
            cbocorte2.Items.Add("90°");
            cbocorte2.Items.Add("180°");
            cbocorte2.Items.Add("270°");
            cbocorte2.Items.Add("Personalizado");

            // Agregar las opciones al ComboBox grados
            cbocorte3.Items.Add("30°");
            cbocorte3.Items.Add("45°");
            cbocorte3.Items.Add("60°");
            cbocorte3.Items.Add("90°");
            cbocorte3.Items.Add("180°");
            cbocorte3.Items.Add("270°");
            cbocorte3.Items.Add("Personalizado");

            // Agregar las opciones al ComboBox grados
            cbocorte4.Items.Add("30°");
            cbocorte4.Items.Add("45°");
            cbocorte4.Items.Add("60°");
            cbocorte4.Items.Add("90°");
            cbocorte4.Items.Add("180°");
            cbocorte4.Items.Add("270°");
            cbocorte4.Items.Add("Personalizado");

            // Agregar las opciones al ComboBox grados
            cbocorte5.Items.Add("30°");
            cbocorte5.Items.Add("45°");
            cbocorte5.Items.Add("60°");
            cbocorte5.Items.Add("90°");
            cbocorte5.Items.Add("180°");
            cbocorte5.Items.Add("270°");
            cbocorte5.Items.Add("Personalizado");

            // Agregar las opciones al ComboBox grados
            cbocorte6.Items.Add("30°");
            cbocorte6.Items.Add("45°");
            cbocorte6.Items.Add("60°");
            cbocorte6.Items.Add("90°");
            cbocorte6.Items.Add("180°");
            cbocorte6.Items.Add("270°");
            cbocorte6.Items.Add("Personalizado");

            // Agregar las opciones al ComboBox grados
            cbocorte7.Items.Add("30°");
            cbocorte7.Items.Add("45°");
            cbocorte7.Items.Add("60°");
            cbocorte7.Items.Add("90°");
            cbocorte7.Items.Add("180°");
            cbocorte7.Items.Add("270°");
            cbocorte7.Items.Add("Personalizado");

            // Agregar las opciones al ComboBox grados
            cbocorte8.Items.Add("30°");
            cbocorte8.Items.Add("45°");
            cbocorte8.Items.Add("60°");
            cbocorte8.Items.Add("90°");
            cbocorte8.Items.Add("180°");
            cbocorte8.Items.Add("270°");
            cbocorte8.Items.Add("Personalizado");

            // Agregar las opciones al ComboBox grados
            cbocorte9.Items.Add("30°");
            cbocorte9.Items.Add("30°");
            cbocorte9.Items.Add("45°");
            cbocorte9.Items.Add("60°");
            cbocorte9.Items.Add("90°");
            cbocorte9.Items.Add("180°");
            cbocorte9.Items.Add("270°");
            cbocorte9.Items.Add("Personalizado");


            // Agregar las opciones al ComboBox material
            cbomaterial.Items.Add("Acero");
            cbomaterial.Items.Add("Metal");
            cbomaterial.Items.Add("Cobre");
            cbomaterial.Items.Add("Personalizado");

            // Agregar las opciones al ComboBox material
            cbomaterial1.Items.Add("Acero");
            cbomaterial1.Items.Add("Metal");
            cbomaterial1.Items.Add("Cobre");
            cbomaterial1.Items.Add("Personalizado");

            // Agregar las opciones al ComboBox material
            cbomaterial2.Items.Add("Acero");
            cbomaterial2.Items.Add("Metal");
            cbomaterial2.Items.Add("Cobre");
            cbomaterial2.Items.Add("Personalizado");

            // Agregar las opciones al ComboBox material
            cbomaterial3.Items.Add("Acero");
            cbomaterial3.Items.Add("Metal");
            cbomaterial3.Items.Add("Cobre");
            cbomaterial3.Items.Add("Personalizado");

            // Agregar las opciones al ComboBox material
            cbomaterial4.Items.Add("Acero");
            cbomaterial4.Items.Add("Metal");
            cbomaterial4.Items.Add("Cobre");
            cbomaterial4.Items.Add("Personalizado");

            // Agregar las opciones al ComboBox material
            cbomaterial5.Items.Add("Acero");
            cbomaterial5.Items.Add("Metal");
            cbomaterial5.Items.Add("Cobre");
            cbomaterial5.Items.Add("Personalizado");

            // Agregar las opciones al ComboBox material
            cbomaterial6.Items.Add("Acero");
            cbomaterial6.Items.Add("Metal");
            cbomaterial6.Items.Add("Cobre");
            cbomaterial6.Items.Add("Personalizado");

            // Agregar las opciones al ComboBox material
            cbomaterial7.Items.Add("Acero");
            cbomaterial7.Items.Add("Metal");
            cbomaterial7.Items.Add("Cobre");
            cbomaterial7.Items.Add("Personalizado");

            // Agregar las opciones al ComboBox material
            cbomaterial8.Items.Add("Acero");
            cbomaterial8.Items.Add("Metal");
            cbomaterial8.Items.Add("Cobre");
            cbomaterial8.Items.Add("Personalizado");

            // Agregar las opciones al ComboBox material
            cbomaterial9.Items.Add("Acero");
            cbomaterial9.Items.Add("Metal");
            cbomaterial9.Items.Add("Cobre");
            cbomaterial9.Items.Add("Personalizado");

            cbocorte.SelectedIndexChanged += cbocorte_SelectedIndexChanged;
            cbotipago1.SelectedIndexChanged += cbotipago1_SelectedIndexChanged;


            for (int i = 0; i <= 9; i++)
            {
                System.Windows.Forms.TextBox txtBoxCantidad = Controls.Find("txtBoxcant" + i, true).FirstOrDefault() as System.Windows.Forms.TextBox;
                System.Windows.Forms.TextBox txtBoxPrecio = Controls.Find("txtBoxprecio" + i, true).FirstOrDefault() as System.Windows.Forms.TextBox;

                if (txtBoxCantidad != null && txtBoxPrecio != null)
                {
                    txtBoxCantidad.TextChanged += CalcularTotal;
                    txtBoxPrecio.TextChanged += CalcularTotal;
                }
            }
        }

        private void cbotipop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion = cbotipop.SelectedItem.ToString(); // Obtener la opción seleccionada

            // Ocultar todos los controles
            label2.Visible = false;
            txtBoxcodi.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label3.Visible = false;
            txtBoxNoCom.Visible = false;
            label6.Visible = false;
            txtBoxDirec.Visible = false;
            label5.Visible = false;
            txtBoxDNI.Visible = false;
            label15.Visible = false;
            txtBoxdescu.Visible = false;
            label7.Visible = false;
            txtBoxRUC.Visible = false;
            label14.Visible = false;
            txtBoxfeent.Visible = false;
            label19.Visible = false;
            cbotipago1.Visible = false;
            label4.Visible = false;
            txtBoxTelef.Visible = false;
            cboFtPr.Visible = false;
            label27.Visible = false;
            txtpuntos.Visible = false;
            label24.Visible = false;
            txtpuntosacu.Visible = false;


            // Cambiar los TextBox a solo lectura según la opción seleccionada
            bool habilitarEscritura = (seleccion == "Sin Tarjeta Cliente");
            txtBoxNoCom.ReadOnly = !habilitarEscritura;
            txtBoxDNI.ReadOnly = !habilitarEscritura;
            txtBoxRUC.ReadOnly = !habilitarEscritura;
            txtBoxTelef.ReadOnly = !habilitarEscritura;
            txtBoxDirec.ReadOnly = !habilitarEscritura;

            // Mostrar los controles según la opción seleccionada
            if (seleccion == "Con Tarjeta Cliente")
            {
                label2.Visible = true;
                txtBoxcodi.Visible = true;
                label3.Visible = true;
                txtBoxNoCom.Visible = true;
                label6.Visible = true;
                txtBoxDirec.Visible = true;
                label5.Visible = true;
                txtBoxDNI.Visible = true;
                label15.Visible = true;
                txtBoxdescu.Visible = true;
                label7.Visible = true;
                txtBoxRUC.Visible = true;
                label14.Visible = true;
                txtBoxfeent.Visible = true;
                label19.Visible = true;
                cbotipago1.Visible = true;
                label4.Visible = true;
                txtBoxTelef.Visible = true;
                cboFtPr.Visible = true;
                label27.Visible = true;
                txtpuntos.Visible = true;
                label24.Visible = true;
                txtpuntosacu.Visible = true;


                // Ocultar label21 y label22
                label21.Visible = false;
                label22.Visible = false;

                if (seleccion == "Con Tarjeta Cliente" && cboFtPr.Text == "Proforma")
                {
                    // Ocultar los controles
                    label15.Visible = false;
                    txtBoxdescu.Visible = false;
                    label27.Visible = false;
                    txtpuntos.Visible = false;
                    label24.Visible = false;
                    txtpuntosacu.Visible = false;
                }
                txtBoxcodi.Focus();
            }
            else if (seleccion == "Sin Tarjeta Cliente")
            {
                label21.Visible = true;
                label3.Visible = true;
                txtBoxNoCom.Visible = true;
                label6.Visible = true;
                txtBoxDirec.Visible = true;
                label5.Visible = true;
                txtBoxDNI.Visible = true;
                label15.Visible = false;
                txtBoxdescu.Visible = false;
                label7.Visible = true;
                txtBoxRUC.Visible = true;
                label14.Visible = true;
                txtBoxfeent.Visible = true;
                label19.Visible = true;
                cbotipago1.Visible = true;
                label4.Visible = true;
                txtBoxTelef.Visible = true;
                cboFtPr.Visible = true;
                label27.Visible = false;
                txtpuntos.Visible = false;
                label24.Visible = false;
                txtpuntosacu.Visible = false;


                // Ocultar label2, label22 y label21 (según corresponda)
                label2.Visible = false;
                txtBoxcodi.Visible = false;
                label22.Visible = false;

                // Verificar si cbotipop es "Sin Tarjeta Cliente" y cboFtPr es "Venta"
                if (seleccion == "Sin Tarjeta Cliente" && cboFtPr.Text == "Venta")
                {
                    // Ocultar los controles
                    label15.Visible = false;
                    txtBoxdescu.Visible = false;
                    label27.Visible = false;
                    txtpuntos.Visible = false;
                    label24.Visible = false;
                    txtpuntosacu.Visible = false;
                }
                else
                {
                    // Mostrar los controles si no se cumple la condición
                    label15.Visible = false;
                    txtBoxdescu.Visible = false;
                    label27.Visible = false;
                    txtpuntos.Visible = false;
                    label24.Visible = false;
                    txtpuntosacu.Visible = false;
                }

               
            }

            else if (seleccion == "-------------------")
            {
                // No es necesario hacer nada adicional aquí, ya que todos los controles están ocultos
            }
            txtBoxcodi.Text = string.Empty;

        }







        // Combos 0
        private void cbocorte_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si se seleccionó "Personalizado" en el ComboBox cbocorte
            if (cbocorte.SelectedItem != null && cbocorte.SelectedItem.ToString() == "Personalizado")
            {
                // Si se selecciona "Personalizado", muestra el TextBox txtBoxcorpe0
                txtBoxcorpe0.Visible = true;
            }
            else
            {
                // Si se selecciona cualquier otra opción, oculta el TextBox txtBoxcorpe0
                txtBoxcorpe0.Visible = false;
            }
        }

        private void cbomaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si se seleccionó "Personalizado" en el ComboBox cbomaterial
            if (cbomaterial.SelectedItem != null && cbomaterial.SelectedItem.ToString() == "Personalizado")
            {
                // Si se selecciona "Personalizado", muestra el TextBox txtBoxmate0
                txtBoxmate0.Visible = true;
            }
            else
            {
                // Si se selecciona cualquier otra opción, oculta el TextBox txtBoxmate0
                txtBoxmate0.Visible = false;
                
            }
        }


        // Combos 1
        private void cbocorte1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            // Verifica si se seleccionó "Personalizado" en el ComboBox cbocorte
            if (cbocorte1.SelectedItem != null && cbocorte1.SelectedItem.ToString() == "Personalizado")
            {
                // Si se selecciona "Personalizado", muestra el TextBox txtBoxcorpe0
                txtBoxcorpe1.Visible = true;
                cbocorte1.Visible = false;
            }
            else
            {
                // Si se selecciona cualquier otra opción, oculta el TextBox txtBoxcorpe0
                txtBoxcorpe1.Visible = false;
            }
        }

        private void cbomaterial1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           

            // Verifica si se seleccionó "Personalizado" en el ComboBox cbomaterial
            if (cbomaterial1.SelectedItem != null && cbomaterial1.SelectedItem.ToString() == "Personalizado")
            {
                // Si se selecciona "Personalizado", muestra el TextBox txtBoxmate0
                txtBoxmate1.Visible = true;
                cbomaterial1.Visible = false;

            }
            else
            {
                // Si se selecciona cualquier otra opción, oculta el TextBox txtBoxmate0
                txtBoxmate1.Visible = false;
            }
        }


        // Combos 2
        private void cbocorte2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si se seleccionó "Personalizado" en el ComboBox cbocorte
            if (cbocorte2.SelectedItem != null && cbocorte2.SelectedItem.ToString() == "Personalizado")
            {
                // Si se selecciona "Personalizado", muestra el TextBox txtBoxcorpe0
                txtBoxcorpe2.Visible = true;
                cbocorte2.Visible = false;
            }
            else
            {
                // Si se selecciona cualquier otra opción, oculta el TextBox txtBoxcorpe0
                txtBoxcorpe2.Visible = false;

            }
        }

        private void cbomaterial2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si se seleccionó "Personalizado" en el ComboBox cbomaterial
            if (cbomaterial2.SelectedItem != null && cbomaterial2.SelectedItem.ToString() == "Personalizado")
            {
                // Si se selecciona "Personalizado", muestra el TextBox txtBoxmate0
                txtBoxmate2.Visible = true;
                cbomaterial2.Visible = false;
            }
            else
            {
                // Si se selecciona cualquier otra opción, oculta el TextBox txtBoxmate0
                txtBoxmate2.Visible = false;
            }
        }


        // Combos 3
        private void cbocorte3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si se seleccionó "Personalizado" en el ComboBox cbocorte
            if (cbocorte3.SelectedItem != null && cbocorte3.SelectedItem.ToString() == "Personalizado")
            {
                // Si se selecciona "Personalizado", muestra el TextBox txtBoxcorpe0
                txtBoxcorpe3.Visible = true;
                cbocorte3.Visible = false;
            }
            else
            {
                // Si se selecciona cualquier otra opción, oculta el TextBox txtBoxcorpe0
                txtBoxcorpe3.Visible = false;
            }
        }

        private void cbomaterial3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si se seleccionó "Personalizado" en el ComboBox cbomaterial
            if (cbomaterial3.SelectedItem != null && cbomaterial3.SelectedItem.ToString() == "Personalizado")
            {
                // Si se selecciona "Personalizado", muestra el TextBox txtBoxmate0
                txtBoxmate3.Visible = true;
                cbomaterial3.Visible = false;
            }
            else
            {
                // Si se selecciona cualquier otra opción, oculta el TextBox txtBoxmate0
                txtBoxmate3.Visible = false;
            }
        }


        // Combos 4
        private void cbocorte4_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si se seleccionó "Personalizado" en el ComboBox cbocorte
            if (cbocorte4.SelectedItem != null && cbocorte4.SelectedItem.ToString() == "Personalizado")
            {
                // Si se selecciona "Personalizado", muestra el TextBox txtBoxcorpe0
                txtBoxcorpe4.Visible = true;
                cbocorte4.Visible = false;  
            }
            else
            {
                // Si se selecciona cualquier otra opción, oculta el TextBox txtBoxcorpe0
                txtBoxcorpe4.Visible = false;
            }
        }

        private void cbomaterial4_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si se seleccionó "Personalizado" en el ComboBox cbomaterial
            if (cbomaterial4.SelectedItem != null && cbomaterial4.SelectedItem.ToString() == "Personalizado")
            {
                // Si se selecciona "Personalizado", muestra el TextBox txtBoxmate0
                txtBoxmate4.Visible = true;
                cbomaterial4.Visible = false;
            }
            else
            {
                // Si se selecciona cualquier otra opción, oculta el TextBox txtBoxmate0
                txtBoxmate4.Visible = false;
            }
        }


        // Combos 5
        private void cbocorte5_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si se seleccionó "Personalizado" en el ComboBox cbocorte
            if (cbocorte5.SelectedItem != null && cbocorte5.SelectedItem.ToString() == "Personalizado")
            {
                // Si se selecciona "Personalizado", muestra el TextBox txtBoxcorpe0
                txtBoxcorpe5.Visible = true;
                cbocorte5.Visible = false;
            }
            else
            {
                // Si se selecciona cualquier otra opción, oculta el TextBox txtBoxcorpe0
                txtBoxcorpe5.Visible = false;
            }
        }

        private void cbomaterial5_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si se seleccionó "Personalizado" en el ComboBox cbomaterial
            if (cbomaterial5.SelectedItem != null && cbomaterial5.SelectedItem.ToString() == "Personalizado")
            {
                // Si se selecciona "Personalizado", muestra el TextBox txtBoxmate0
                txtBoxmate5.Visible = true;
                cbomaterial5.Visible = false;
            }
            else
            {
                // Si se selecciona cualquier otra opción, oculta el TextBox txtBoxmate0
                txtBoxmate5.Visible = false;
            }
        }


        // Combos 6
        private void cbocorte6_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si se seleccionó "Personalizado" en el ComboBox cbocorte
            if (cbocorte6.SelectedItem != null && cbocorte6.SelectedItem.ToString() == "Personalizado")
            {
                // Si se selecciona "Personalizado", muestra el TextBox txtBoxcorpe0
                txtBoxcorpe6.Visible = true;
                cbocorte6.Visible = false;
            }
            else
            {
                // Si se selecciona cualquier otra opción, oculta el TextBox txtBoxcorpe0
                txtBoxcorpe6.Visible = false;
            }
        }

        private void cbomaterial6_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si se seleccionó "Personalizado" en el ComboBox cbomaterial
            if (cbomaterial6.SelectedItem != null && cbomaterial6.SelectedItem.ToString() == "Personalizado")
            {
                // Si se selecciona "Personalizado", muestra el TextBox txtBoxmate0
                txtBoxmate6.Visible = true;
                cbomaterial6.Visible = false;
            }
            else
            {
                // Si se selecciona cualquier otra opción, oculta el TextBox txtBoxmate0
                txtBoxmate6.Visible = false;
            }
        }


        // Combos 7
        private void cbocorte7_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si se seleccionó "Personalizado" en el ComboBox cbocorte
            if (cbocorte7.SelectedItem != null && cbocorte7.SelectedItem.ToString() == "Personalizado")
            {
                // Si se selecciona "Personalizado", muestra el TextBox txtBoxcorpe0
                txtBoxcorpe7.Visible = true;
                cbocorte7.Visible = false;
            }
            else
            {
                // Si se selecciona cualquier otra opción, oculta el TextBox txtBoxcorpe0
                txtBoxcorpe7.Visible = false;
            }
        }

        private void cbomaterial7_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si se seleccionó "Personalizado" en el ComboBox cbomaterial
            if (cbomaterial7.SelectedItem != null && cbomaterial7.SelectedItem.ToString() == "Personalizado")
            {
                // Si se selecciona "Personalizado", muestra el TextBox txtBoxmate0
                txtBoxmate7.Visible = true;
                cbomaterial7.Visible = false;
            }
            else
            {
                // Si se selecciona cualquier otra opción, oculta el TextBox txtBoxmate0
                txtBoxmate7.Visible = false;
            }
        }


        // Combos 8
        private void cbocorte8_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si se seleccionó "Personalizado" en el ComboBox cbocorte
            if (cbocorte8.SelectedItem != null && cbocorte8.SelectedItem.ToString() == "Personalizado")
            {
                // Si se selecciona "Personalizado", muestra el TextBox txtBoxcorpe0
                txtBoxcorpe8.Visible = true;
                cbocorte8.Visible = false;
            }
            else
            {
                // Si se selecciona cualquier otra opción, oculta el TextBox txtBoxcorpe0
                txtBoxcorpe8.Visible = false;
            }
        }

        private void cbomaterial8_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si se seleccionó "Personalizado" en el ComboBox cbomaterial
            if (cbomaterial8.SelectedItem != null && cbomaterial8.SelectedItem.ToString() == "Personalizado")
            {
                // Si se selecciona "Personalizado", muestra el TextBox txtBoxmate0
                txtBoxmate8.Visible = true;
                cbomaterial8.Visible = false;
            }
            else
            {
                // Si se selecciona cualquier otra opción, oculta el TextBox txtBoxmate0
                txtBoxmate8.Visible = false;
            }
        }


        // Combos 9
        private void cbocorte9_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si se seleccionó "Personalizado" en el ComboBox cbocorte
            if (cbocorte9.SelectedItem != null && cbocorte9.SelectedItem.ToString() == "Personalizado")
            {
                // Si se selecciona "Personalizado", muestra el TextBox txtBoxcorpe0
                txtBoxcorpe9.Visible = true;
                cbocorte9.Visible = false;
            }
            else
            {
                // Si se selecciona cualquier otra opción, oculta el TextBox txtBoxcorpe0
                txtBoxcorpe9.Visible = false;
            }
        }

        private void cbomaterial9_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si se seleccionó "Personalizado" en el ComboBox cbomaterial
            if (cbomaterial9.SelectedItem != null && cbomaterial9.SelectedItem.ToString() == "Personalizado")
            {
                // Si se selecciona "Personalizado", muestra el TextBox txtBoxmate0
                txtBoxmate9.Visible = true;
                cbomaterial9.Visible = false;
            }
            else
            {
                // Si se selecciona cualquier otra opción, oculta el TextBox txtBoxmate0
                txtBoxmate9.Visible = false;
            }
        }



        private void txtBoxprecio0_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtBoxprecio0.Text))
            {
                // Mostrar los controles relacionados con el producto 1
                txtBoxcant1.Visible = true;
                txtBoxdes1.Visible = true;
                txtBoxtamc1.Visible = true;
                cbocorte1.Visible = true;
                cbomaterial1.Visible = true;
                txtBoxprecio1.Visible = true;

          

            }
            else
            {
                // Ocultar los controles relacionados con el producto 1
                txtBoxcant1.Visible = false;
                txtBoxdes1.Visible = false;
                txtBoxtamc1.Visible = false;
                cbocorte1.Visible = false;
                cbomaterial1.Visible = false;
                txtBoxprecio1.Visible = false;
                txtBoxmate1.Visible = false;
                txtBoxcorpe1.Visible = false;

                //Limpiar
                cbocorte1.SelectedIndex = -1; 
                cbomaterial1.SelectedIndex = -1;
                txtBoxcant1.Text = "";
                txtBoxdes1.Text = "";
                txtBoxtamc1.Text = "";
                txtBoxprecio1.Text = "";
                txtBoxmate1.Text = "";
                txtBoxcorpe1.Text = "";


            }
        }


        private void txtBoxprecio1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxprecio1.Text))
            {
                // Mostrar los controles relacionados con el producto 1
                txtBoxcant2.Visible = true;
                txtBoxdes2.Visible = true;
                txtBoxtamc2.Visible = true;
                cbocorte2.Visible = true;
                cbomaterial2.Visible = true;
                txtBoxprecio2.Visible = true;

            }
            else
            {
                // Ocultar los controles relacionados con el producto 1
                txtBoxcant2.Visible = false;
                txtBoxdes2.Visible = false;
                txtBoxtamc2.Visible = false;
                cbocorte2.Visible = false;
                cbomaterial2.Visible = false;
                txtBoxprecio2.Visible = false;
                txtBoxmate2.Visible = false;
                txtBoxcorpe2.Visible = false;

                //Limpiar
                cbocorte2.SelectedIndex = -1;
                cbomaterial2.SelectedIndex = -1;
                txtBoxcant2.Text = "";
                txtBoxdes2.Text = "";
                txtBoxtamc2.Text = "";
                txtBoxprecio2.Text = "";
                txtBoxmate2.Text = "";
                txtBoxcorpe2.Text = "";

            }
        }

        private void txtBoxprecio2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxprecio2.Text))
            {
                // Mostrar los controles relacionados con el producto 1
                txtBoxcant3.Visible = true;
                txtBoxdes3.Visible = true;
                txtBoxtamc3.Visible = true;
                cbocorte3.Visible = true;
                cbomaterial3.Visible = true;
                txtBoxprecio3.Visible = true;

           
            }
            else
            {
                // Ocultar los controles relacionados con el producto 1
                txtBoxcant3.Visible = false;
                txtBoxdes3.Visible = false;
                txtBoxtamc3.Visible = false;
                cbocorte3.Visible = false;
                cbomaterial3.Visible = false;
                txtBoxprecio3.Visible = false;
                txtBoxmate3.Visible = false;
                txtBoxcorpe3.Visible = false;

                //Limpiar
                cbocorte3.SelectedIndex = -1;
                cbomaterial3.SelectedIndex = -1;
                txtBoxcant3.Text = "";
                txtBoxdes3.Text = "";
                txtBoxtamc3.Text = "";
                txtBoxprecio3.Text = "";
                txtBoxmate3.Text = "";
                txtBoxcorpe3.Text = "";

            }
        }


        private void txtBoxprecio3_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxprecio3.Text))
            {
                // Mostrar los controles relacionados con el producto 1
                txtBoxcant4.Visible = true;
                txtBoxdes4.Visible = true;
                txtBoxtamc4.Visible = true;
                cbocorte4.Visible = true;
                cbomaterial4.Visible = true;
                txtBoxprecio4.Visible = true;

                //Limpiar
               
            }
            else
            {
                // Ocultar los controles relacionados con el producto 1
                txtBoxcant4.Visible = false;
                txtBoxdes4.Visible = false;
                txtBoxtamc4.Visible = false;
                cbocorte4.Visible = false;
                cbomaterial4.Visible = false;
                txtBoxprecio4.Visible = false;
                txtBoxmate4.Visible = false;
                txtBoxcorpe4.Visible = false;

                //Limpiar
                cbocorte4.SelectedIndex = -1;
                cbomaterial4.SelectedIndex = -1;
                txtBoxcant4.Text = "";
                txtBoxdes4.Text = "";
                txtBoxtamc4.Text = "";
                txtBoxprecio4.Text = "";
                txtBoxmate4.Text = "";
                txtBoxcorpe4.Text = "";
            }
        }


        private void txtBoxprecio4_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxprecio4.Text))
            {
                // Mostrar los controles relacionados con el producto 1
                txtBoxcant5.Visible = true;
                txtBoxdes5.Visible = true;
                txtBoxtamc5.Visible = true;
                cbocorte5.Visible = true;
                cbomaterial5.Visible = true;
                txtBoxprecio5.Visible = true;

                //Limpiar
       
          
            }
            else
            {
                // Ocultar los controles relacionados con el producto 1
                txtBoxcant5.Visible = false;
                txtBoxdes5.Visible = false;
                txtBoxtamc5.Visible = false;
                cbocorte5.Visible = false;
                cbomaterial5.Visible = false;
                txtBoxprecio5.Visible = false;
                txtBoxmate5.Visible = false;
                txtBoxcorpe5.Visible = false;

                //Limpiar
                cbocorte5.SelectedIndex = -1;
                cbomaterial5.SelectedIndex = -1;
                txtBoxcant5.Text = "";
                txtBoxdes5.Text = "";
                txtBoxtamc5.Text = "";
                txtBoxprecio5.Text = "";
                txtBoxmate5.Text = "";
                txtBoxcorpe5.Text = "";
            }
        }


        private void txtBoxprecio5_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxprecio5.Text))
            {
                // Mostrar los controles relacionados con el producto 1
                txtBoxcant6.Visible = true;
                txtBoxdes6.Visible = true;
                txtBoxtamc6.Visible = true;
                cbocorte6.Visible = true;
                cbomaterial6.Visible = true;
                txtBoxprecio6.Visible = true;

                //Limpiar
                
            }
            else
            {
                // Ocultar los controles relacionados con el producto 1
                txtBoxcant6.Visible = false;
                txtBoxdes6.Visible = false;
                txtBoxtamc6.Visible = false;
                cbocorte6.Visible = false;
                cbomaterial6.Visible = false;
                txtBoxprecio6.Visible = false;
                txtBoxmate6.Visible = false;
                txtBoxcorpe6.Visible = false;

                //Limpiar
                cbocorte6.SelectedIndex = -1;
                cbomaterial6.SelectedIndex = -1;
                txtBoxcant6.Text = "";
                txtBoxdes6.Text = "";
                txtBoxtamc6.Text = "";
                txtBoxprecio6.Text = "";
                txtBoxmate6.Text = "";
                txtBoxcorpe6.Text = "";
            }
        }


        private void txtBoxprecio6_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxprecio6.Text))
            {
                // Mostrar los controles relacionados con el producto 1
                txtBoxcant7.Visible = true;
                txtBoxdes7.Visible = true;
                txtBoxtamc7.Visible = true;
                cbocorte7.Visible = true;
                cbomaterial7.Visible = true;
                txtBoxprecio7.Visible = true;

                //Limpiar
       
            }
            else
            {
                // Ocultar los controles relacionados con el producto 1
                txtBoxcant7.Visible = false;
                txtBoxdes7.Visible = false;
                txtBoxtamc7.Visible = false;
                cbocorte7.Visible = false;
                cbomaterial7.Visible = false;
                txtBoxprecio7.Visible = false;
                txtBoxmate7.Visible = false;
                txtBoxcorpe7.Visible = false;

                //Limpiar
                cbocorte7.SelectedIndex = -1;
                cbomaterial7.SelectedIndex = -1;
                txtBoxcant7.Text = "";
                txtBoxdes7.Text = "";
                txtBoxtamc7.Text = "";
                txtBoxprecio7.Text = "";
                txtBoxmate7.Text = "";
                txtBoxcorpe7.Text = "";
            }
        }


        private void txtBoxprecio7_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxprecio7.Text))
            {
                // Mostrar los controles relacionados con el producto 1
                txtBoxcant8.Visible = true;
                txtBoxdes8.Visible = true;
                txtBoxtamc8.Visible = true;
                cbocorte8.Visible = true;
                cbomaterial8.Visible = true;
                txtBoxprecio8.Visible = true;

                //Limpiar
               
            }
            else
            {
                // Ocultar los controles relacionados con el producto 1
                txtBoxcant8.Visible = false;
                txtBoxdes8.Visible = false;
                txtBoxtamc8.Visible = false;
                cbocorte8.Visible = false;
                cbomaterial8.Visible = false;
                txtBoxprecio8.Visible = false;
                txtBoxmate8.Visible = false;
                txtBoxcorpe8.Visible = false;

                //Limpiar
                cbocorte8.SelectedIndex = -1;
                cbomaterial8.SelectedIndex = -1;
                txtBoxcant8.Text = "";
                txtBoxdes8.Text = "";
                txtBoxtamc8.Text = "";
                txtBoxprecio8.Text = "";
                txtBoxmate8.Text = "";
                txtBoxcorpe8.Text = "";
            }
        }


        private void txtBoxprecio8_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxprecio8.Text))
            {
                // Mostrar los controles relacionados con el producto 1
                txtBoxcant9.Visible = true;
                txtBoxdes9.Visible = true;
                txtBoxtamc9.Visible = true;
                cbocorte9.Visible = true;
                cbomaterial9.Visible = true;
                txtBoxprecio9.Visible = true;

                //Limpiar
               
            }
            else
            {
                // Ocultar los controles relacionados con el producto 1
                txtBoxcant9.Visible = false;
                txtBoxdes9.Visible = false;
                txtBoxtamc9.Visible = false;
                cbocorte9.Visible = false;
                cbomaterial9.Visible = false;
                txtBoxprecio9.Visible = false;
                txtBoxmate9.Visible = false;
                txtBoxcorpe9.Visible = false;

                //Limpiar
                cbocorte9.SelectedIndex = -1;
                cbomaterial9.SelectedIndex = -1;
                txtBoxcant9.Text = "";
                txtBoxdes9.Text = "";
                txtBoxtamc9.Text = "";
                txtBoxprecio9.Text = "";
                txtBoxmate9.Text = "";
                txtBoxcorpe9.Text = "";
            }

        }




        private void txtBoxcodi_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                Clases.Busqueda objetoBusqueda = new Clases.Busqueda();
                objetoBusqueda.buscarCodigo(txtBoxcodi, txtBoxDNI, txtBoxRUC, txtBoxNoCom, txtBoxDirec, txtBoxTelef);


            }

            if (!string.IsNullOrEmpty(txtBoxcodi.Text))
            {
                string codigoCliente = txtBoxcodi.Text;
                MostrarPuntosCliente(codigoCliente);
            }
        }


        private void CalcularTotal(object sender, EventArgs e)
        {
            // Inicializamos el total en cero
            decimal total = 0;

            // Realizamos los cálculos para los productos 0 al 9
            for (int i = 0; i <= 9; i++)
            {
                // Obtenemos las cantidades y precios de los TextBox correspondientes
                System.Windows.Forms.TextBox txtBoxCantidad = Controls.Find("txtBoxcant" + i, true).FirstOrDefault() as System.Windows.Forms.TextBox;
                System.Windows.Forms.TextBox txtBoxPrecio = Controls.Find("txtBoxprecio" + i, true).FirstOrDefault() as System.Windows.Forms.TextBox;

                if (txtBoxCantidad != null && txtBoxPrecio != null)
                {
                    // Intentamos convertir los valores de cantidad y precio a números decimales
                    if (decimal.TryParse(txtBoxCantidad.Text, out decimal cantidad) && decimal.TryParse(txtBoxPrecio.Text, out decimal precio))
                    {
                        // Calculamos el subtotal para el producto i
                        decimal subtotal = cantidad * precio;
                        total += subtotal;
                    }
                
                }
               

            }

            // Formateamos el total como moneda peruana (Nuevo Sol o Sol)
            CultureInfo culture = new CultureInfo("es-PE"); // Establecer cultura peruana
            txtBoxtotalc0.Text = total.ToString("C", culture); // Formateamos el total como moneda peruana
       

        }
        

        private void cboFtPr_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboFtPr.SelectedItem.ToString() == "Proforma")
            {
                // Ocultar controles relacionados con Proforma
                txtBoxdescu.Visible = false;
                txtpuntos.Visible = false;
                txtpuntosacu.Visible = false;
                txtBoxRecibido.Visible = false;
                txtBoxCambio.Visible = false;
                label15.Visible = false;
                label27.Visible = false;
                label24.Visible = false;
                label26.Visible = false;
                label25.Visible = false;
                txtBoxRecibido.Text = "0";
            }

            else if (cboFtPr.SelectedItem.ToString() == "Venta")
            {
                // Mostrar controles relacionados con Venta
                txtBoxdescu.Visible = true;
                txtpuntos.Visible = true;
                txtpuntosacu.Visible = true;
                txtBoxRecibido.Visible = true;
                txtBoxCambio.Visible = true;
                label15.Visible = true;
                label27.Visible = true;
                label24.Visible = true;
                label26.Visible = true;
                label25.Visible = true;

                // Verificar si cbotipop es "Sin Tarjeta Cliente" y cboFtPr es "Venta"
                if (cbotipop.SelectedItem.ToString() == "Sin Tarjeta Cliente" && cboFtPr.Text == "Venta")
                {
                    // Ocultar los controles
                    label15.Visible = false;
                    txtBoxdescu.Visible = false;
                    label27.Visible = false;
                    txtpuntos.Visible = false;
                    label24.Visible = false;
                    txtpuntosacu.Visible = false;
                }
                else
                {
                    // Mostrar los controles si no se cumple la condición
                    label15.Visible = true;
                    txtBoxdescu.Visible = true;
                    label27.Visible = true;
                    txtpuntos.Visible = true;
                    label24.Visible = true;
                    txtpuntosacu.Visible = true;
                }
            }


            if (cboFtPr.SelectedItem.ToString() == "Proforma")
            {
                // Si es una proforma, establecer la fecha actual en txtBoxfeent
                txtBoxfeent.Text = DateTime.Now.ToString("dd/MM/yyyy");

                // Establecer el tipo de pago por defecto en "Efectivo"
                cbotipago1.SelectedItem = "Efectivo";


                txtBoxfeent.Enabled = false;
                cbotipago1.Enabled = false;

            }
            if (cboFtPr.SelectedItem.ToString() == "Venta")
            {

                txtBoxfeent.Enabled = true;
                cbotipago1.Enabled = true;

            }

        }



        private void btnguardar0_Click(object sender, EventArgs e)
        {
            try
            {
                

                DateTime fechaFacturacion = DateTime.ParseExact(txtBoxfefac.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime fechaPago = DateTime.ParseExact(txtBoxfepago.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); // Obtener la fecha de pago de txtBoxfepago
            string tipoPago = cbotipago1.SelectedItem.ToString(); // Obtener el tipo de pago de cbotipago1
            string ruc = txtBoxRUC.Text;
            DateTime fechaEntrega = DateTime.ParseExact(txtBoxfeent.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            string valorTotalConSimbolo = txtBoxtotalc0.Text.Trim();
            decimal valor = decimal.Parse(valorTotalConSimbolo.Replace("S/", "").Trim(), CultureInfo.GetCultureInfo("es-PE"));

            // Obtener el valor del cambio en moneda peruana y quitar el símbolo "S/"
            string cambioConSimbolo = txtBoxCambio.Text.Trim();
            decimal cambio = decimal.Parse(cambioConSimbolo.Replace("S/", "").Trim(), CultureInfo.GetCultureInfo("es-PE"));

           


            // Verificar si al menos los campos del primer grupo están llenos
            if (!string.IsNullOrEmpty(txtBoxcant0.Text) &&
                !string.IsNullOrEmpty(txtBoxdes0.Text) &&
                !string.IsNullOrEmpty(txtBoxtamc0.Text))
            {
                // Crear variables para las filas
                string fila1 = $"{txtBoxcant0.Text}, {txtBoxdes0.Text}, {txtBoxtamc0.Text}";
                string fila2 = "";
                string fila3 = "";
                string fila4 = "";
                string fila5 = "";
                string fila6 = "";
                string fila7 = "";
                string fila8 = "";
                string fila9 = ""; 
                string fila10 = ""; 

                // Verificar si se seleccionó "Personalizado" en el ComboBox cbocorte
                if (cbocorte.SelectedIndex != -1 && cbocorte.SelectedItem.ToString() == "Personalizado")
                {
                    fila1 += $", {txtBoxcorpe0.Text}";
                }
                else
                {
                    fila1 += $", {cbocorte.Text}";
                }

                // Verificar si se seleccionó "Personalizado" en el ComboBox cbomaterial
                if (cbomaterial.SelectedIndex != -1 && cbomaterial.SelectedItem.ToString() == "Personalizado")
                {
                    fila1 += $", {txtBoxmate0.Text}";
                }
                else
                {
                    fila1 += $", {cbomaterial.Text}";
                }

                fila1 += $", {txtBoxprecio0.Text}";

                // Verificar si los campos del segundo grupo están llenos
                if (!string.IsNullOrEmpty(txtBoxcant1.Text) &&
                    !string.IsNullOrEmpty(txtBoxdes1.Text) &&
                    !string.IsNullOrEmpty(txtBoxtamc1.Text))
                {
                    // Concatenar los valores del segundo grupo a la segunda fila
                    fila2 = $"{txtBoxcant1.Text}, {txtBoxdes1.Text}, {txtBoxtamc1.Text}";

                    // Verificar si se seleccionó "Personalizado" en el ComboBox cbocorte1
                    if (cbocorte1.SelectedIndex != -1 && cbocorte1.SelectedItem.ToString() == "Personalizado")
                    {
                        fila2 += $", {txtBoxcorpe1.Text}";
                    }
                    else
                    {
                        fila2 += $", {cbocorte1.Text}";
                    }

                    // Verificar si se seleccionó "Personalizado" en el ComboBox cbomaterial1
                    if (cbomaterial1.SelectedIndex != -1 && cbomaterial1.SelectedItem.ToString() == "Personalizado")
                    {
                        fila2 += $", {txtBoxmate1.Text}";
                    }
                    else
                    {
                        fila2 += $", {cbomaterial1.Text}";
                    }

                    fila2 += $", {txtBoxprecio1.Text}";
                }

                // Agregar lógica para la tercera fila
                if (!string.IsNullOrEmpty(txtBoxcant2.Text) &&
                    !string.IsNullOrEmpty(txtBoxdes2.Text) &&
                    !string.IsNullOrEmpty(txtBoxtamc2.Text))
                {
                    // Concatenar los valores del tercer grupo a la tercera fila
                    fila3 = $"{txtBoxcant2.Text}, {txtBoxdes2.Text}, {txtBoxtamc2.Text}";

                    // Verificar si se seleccionó "Personalizado" en el ComboBox cbocorte2
                    if (cbocorte2.SelectedIndex != -1 && cbocorte2.SelectedItem.ToString() == "Personalizado")
                    {
                        fila3 += $", {txtBoxcorpe2.Text}";
                    }
                    else
                    {
                        fila3 += $", {cbocorte2.Text}";
                    }

                    // Verificar si se seleccionó "Personalizado" en el ComboBox cbomaterial2
                    if (cbomaterial2.SelectedIndex != -1 && cbomaterial2.SelectedItem.ToString() == "Personalizado")
                    {
                        fila3 += $", {txtBoxmate2.Text}";
                    }
                    else
                    {
                        fila3 += $", {cbomaterial2.Text}";
                    }

                    fila3 += $", {txtBoxprecio2.Text}";
                }

                // Agregar lógica para la cuarta fila
                if (!string.IsNullOrEmpty(txtBoxcant3.Text) &&
                    !string.IsNullOrEmpty(txtBoxdes3.Text) &&
                    !string.IsNullOrEmpty(txtBoxtamc3.Text))
                {
                    // Concatenar los valores del cuarto grupo a la cuarta fila
                    fila4 = $"{txtBoxcant3.Text}, {txtBoxdes3.Text}, {txtBoxtamc3.Text}";

                    // Verificar si se seleccionó "Personalizado" en el ComboBox cbocorte3
                    if (cbocorte3.SelectedIndex != -1 && cbocorte3.SelectedItem.ToString() == "Personalizado")
                    {
                        fila4 += $", {txtBoxcorpe3.Text}";
                    }
                    else
                    {
                        fila4 += $", {cbocorte3.Text}";
                    }

                    // Verificar si se seleccionó "Personalizado" en el ComboBox cbomaterial3
                    if (cbomaterial3.SelectedIndex != -1 && cbomaterial3.SelectedItem.ToString() == "Personalizado")
                    {
                        fila4 += $", {txtBoxmate3.Text}";
                    }
                    else
                    {
                        fila4 += $", {cbomaterial3.Text}";
                    }

                    fila4 += $", {txtBoxprecio3.Text}";
                }

                // Agregar lógica para la quinta fila
                if (!string.IsNullOrEmpty(txtBoxcant4.Text) &&
                    !string.IsNullOrEmpty(txtBoxdes4.Text) &&
                    !string.IsNullOrEmpty(txtBoxtamc4.Text))
                {
                    // Concatenar los valores del quinto grupo a la quinta fila
                    fila5 = $"{txtBoxcant4.Text}, {txtBoxdes4.Text}, {txtBoxtamc4.Text}";

                    // Verificar si se seleccionó "Personalizado" en el ComboBox cbocorte4
                    if (cbocorte4.SelectedIndex != -1 && cbocorte4.SelectedItem.ToString() == "Personalizado")
                    {
                        fila5 += $", {txtBoxcorpe4.Text}";
                    }
                    else
                    {
                        fila5 += $", {cbocorte4.Text}";
                    }

                    // Verificar si se seleccionó "Personalizado" en el ComboBox cbomaterial4
                    if (cbomaterial4.SelectedIndex != -1 && cbomaterial4.SelectedItem.ToString() == "Personalizado")
                    {
                        fila5 += $", {txtBoxmate4.Text}";
                    }
                    else
                    {
                        fila5 += $", {cbomaterial4.Text}";
                    }

                    fila5 += $", {txtBoxprecio4.Text}";
                }

                // Agregar lógica para la sexta fila
                if (!string.IsNullOrEmpty(txtBoxcant5.Text) &&
                    !string.IsNullOrEmpty(txtBoxdes5.Text) &&
                    !string.IsNullOrEmpty(txtBoxtamc5.Text))
                {
                    // Concatenar los valores del sexto grupo a la sexta fila
                    fila6 = $"{txtBoxcant5.Text}, {txtBoxdes5.Text}, {txtBoxtamc5.Text}";

                    // Verificar si se seleccionó "Personalizado" en el ComboBox cbocorte5
                    if (cbocorte5.SelectedIndex != -1 && cbocorte5.SelectedItem.ToString() == "Personalizado")
                    {
                        fila6 += $", {txtBoxcorpe5.Text}";
                    }
                    else
                    {
                        fila6 += $", {cbocorte5.Text}";
                    }

                    // Verificar si se seleccionó "Personalizado" en el ComboBox cbomaterial5
                    if (cbomaterial5.SelectedIndex != -1 && cbomaterial5.SelectedItem.ToString() == "Personalizado")
                    {
                        fila6 += $", {txtBoxmate5.Text}";
                    }
                    else
                    {
                        fila6 += $", {cbomaterial5.Text}";
                    }

                    fila6 += $", {txtBoxprecio5.Text}";
                }

                // Agregar lógica para la séptima fila
                if (!string.IsNullOrEmpty(txtBoxcant6.Text) &&
                    !string.IsNullOrEmpty(txtBoxdes6.Text) &&
                    !string.IsNullOrEmpty(txtBoxtamc6.Text))
                {
                    // Concatenar los valores del séptimo grupo a la séptima fila
                    fila7 = $"{txtBoxcant6.Text}, {txtBoxdes6.Text}, {txtBoxtamc6.Text}";

                    // Verificar si se seleccionó "Personalizado" en el ComboBox cbocorte6
                    if (cbocorte6.SelectedIndex != -1 && cbocorte6.SelectedItem.ToString() == "Personalizado")
                    {
                        fila7 += $", {txtBoxcorpe6.Text}";
                    }
                    else
                    {
                        fila7 += $", {cbocorte6.Text}";
                    }

                    // Verificar si se seleccionó "Personalizado" en el ComboBox cbomaterial6
                    if (cbomaterial6.SelectedIndex != -1 && cbomaterial6.SelectedItem.ToString() == "Personalizado")
                    {
                        fila7 += $", {txtBoxmate6.Text}";
                    }
                    else
                    {
                        fila7 += $", {cbomaterial6.Text}";
                    }

                    fila7 += $", {txtBoxprecio6.Text}";
                }

                // Agregar lógica para la octava fila
                if (!string.IsNullOrEmpty(txtBoxcant7.Text) &&
                    !string.IsNullOrEmpty(txtBoxdes7.Text) &&
                    !string.IsNullOrEmpty(txtBoxtamc7.Text))
                {
                    // Concatenar los valores del octavo grupo a la octava fila
                    fila8 = $"{txtBoxcant7.Text}, {txtBoxdes7.Text}, {txtBoxtamc7.Text}";

                    // Verificar si se seleccionó "Personalizado" en el ComboBox cbocorte7
                    if (cbocorte7.SelectedIndex != -1 && cbocorte7.SelectedItem.ToString() == "Personalizado")
                    {
                        fila8 += $", {txtBoxcorpe7.Text}";
                    }
                    else
                    {
                        fila8 += $", {cbocorte7.Text}";
                    }

                    // Verificar si se seleccionó "Personalizado" en el ComboBox cbomaterial7
                    if (cbomaterial7.SelectedIndex != -1 && cbomaterial7.SelectedItem.ToString() == "Personalizado")
                    {
                        fila8 += $", {txtBoxmate7.Text}";
                    }
                    else
                    {
                        fila8 += $", {cbomaterial7.Text}";
                    }

                    fila8 += $", {txtBoxprecio7.Text}";
                }

                // Agregar lógica para la novena fila
                if (!string.IsNullOrEmpty(txtBoxcant8.Text) &&
                    !string.IsNullOrEmpty(txtBoxdes8.Text) &&
                    !string.IsNullOrEmpty(txtBoxtamc8.Text))
                {
                    // Concatenar los valores del noveno grupo a la novena fila
                    fila9 = $"{txtBoxcant8.Text}, {txtBoxdes8.Text}, {txtBoxtamc8.Text}";

                    // Verificar si se seleccionó "Personalizado" en el ComboBox cbocorte8
                    if (cbocorte8.SelectedIndex != -1 && cbocorte8.SelectedItem.ToString() == "Personalizado")
                    {
                        fila9 += $", {txtBoxcorpe8.Text}";
                    }
                    else
                    {
                        fila9 += $", {cbocorte8.Text}";
                    }

                    // Verificar si se seleccionó "Personalizado" en el ComboBox cbomaterial8
                    if (cbomaterial8.SelectedIndex != -1 && cbomaterial8.SelectedItem.ToString() == "Personalizado")
                    {
                        fila9 += $", {txtBoxmate8.Text}";
                    }
                    else
                    {
                        fila9 += $", {cbomaterial8.Text}";
                    }

                    fila9 += $", {txtBoxprecio8.Text}";
                }

                // Agregar lógica para la décima fila
                if (!string.IsNullOrEmpty(txtBoxcant9.Text) &&
                    !string.IsNullOrEmpty(txtBoxdes9.Text) &&
                    !string.IsNullOrEmpty(txtBoxtamc9.Text))
                {
                    // Concatenar los valores del décimo grupo a la décima fila
                    fila10 = $"{txtBoxcant9.Text}, {txtBoxdes9.Text}, {txtBoxtamc9.Text}";

                    // Verificar si se seleccionó "Personalizado" en el ComboBox cbocorte9
                    if (cbocorte9.SelectedIndex != -1 && cbocorte9.SelectedItem.ToString() == "Personalizado")
                    {
                        fila10 += $", {txtBoxcorpe9.Text}";
                    }
                    else
                    {
                        fila10 += $", {cbocorte9.Text}";
                    }

                    // Verificar si se seleccionó "Personalizado" en el ComboBox cbomaterial9
                    if (cbomaterial9.SelectedIndex != -1 && cbomaterial9.SelectedItem.ToString() == "Personalizado")
                    {
                        fila10 += $", {txtBoxmate9.Text}";
                    }
                    else
                    {
                        fila10 += $", {cbomaterial9.Text}";
                    }

                    fila10 += $", {txtBoxprecio9.Text}";
                }

                // Concatenar todas las filas con saltos de línea
                string filaConcatenada = fila1 + Environment.NewLine + fila2 + Environment.NewLine + fila3 + Environment.NewLine + fila4 + Environment.NewLine + fila5 + Environment.NewLine + fila6 + Environment.NewLine + fila7 + Environment.NewLine + fila8 + Environment.NewLine + fila9 + Environment.NewLine + fila10;

                // Determinar la tabla en la que se va a insertar según la selección del ComboBox cboFtPr
                string tabla = cboFtPr.SelectedItem.ToString() == "Proforma" ? "proforma" : "gestion_ventas";

                // Verificar la selección del ComboBox y guardar en la tabla correspondiente
                if (tabla == "proforma")
                {
                    
                    // Insertar la fila resultante en la tabla "proforma" en la base de datos
                    InsertarFilaEnProforma(filaConcatenada, valor, tabla, fechaFacturacion, ruc);
                }
                else if (tabla == "gestion_ventas")
                {
                        // Verificar que se ingresen el nombre y la dirección
                        if (string.IsNullOrEmpty(txtBoxNoCom.Text) || string.IsNullOrEmpty(txtBoxDirec.Text))
                        {
                            MessageBox.Show("Asegúrate de completar todos los datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (string.IsNullOrEmpty(txtBoxTelef.Text))
                        {
                            MessageBox.Show("El formato del número de teléfono no es válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Sale del método si el número de teléfono no es válido
                        }
                        // Validar el formato del DNI
                        if (!Regex.IsMatch(txtBoxDNI.Text, @"^\d{8}$"))
                        {
                            MessageBox.Show("El formato del DNI no es válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Validar el formato del RUC
                        if (!Regex.IsMatch(ruc, @"^\d{11}$"))
                        {
                            MessageBox.Show("El formato del RUC no es válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        // Insertar la fila resultante en la tabla "factura" en la base de datos
                        InsertarFilaEnFactura(filaConcatenada, valor, tabla, fechaFacturacion, fechaPago, tipoPago, ruc, fechaEntrega, cambio);
                    if (!string.IsNullOrEmpty(txtBoxcodi.Text))
                    {
                        string codigoCliente = txtBoxcodi.Text;
                        int puntos = int.Parse(txtpuntos.Text);
                        ActualizarPuntosEnTabla(codigoCliente, puntos);
                    }
                        // Obtener el valor de txtBoxcodi
                        string valorParaTransferir = txtBoxcodi.Text;

                        // Crear una instancia del formulario GestorTrabajo
                        GestorTrabajo formularioEmergente = new GestorTrabajo();

                        // Configurar el valor de Codigo1 en el formulario GestorTrabajo
                        formularioEmergente.Codigo1 = valorParaTransferir;

                        // Mostrar el formulario GestorTrabajo
                        formularioEmergente.ShowDialog();
                    }
            }
            else
            {
                // Mostrar un mensaje de error si los campos del primer grupo no están llenos
                MessageBox.Show("Asegúrate de completar todos los datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 

            }
            catch (FormatException)
            {
                // Captura la excepción de formato y muestra un MessageBox de advertencia
                MessageBox.Show("Verifica los datos ingresados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Maneja otras excepciones de manera similar si es necesario
                MessageBox.Show("Se produjo un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
            limpiartodo();
        }


        private void InsertarFilaEnProforma(string filaConcatenada, decimal valor, string tabla, DateTime fechaFacturacion, string ruc)
        {
            try
            {
                Conexion objetoConexion = new Conexion();
                MySqlConnection conn = objetoConexion.establecerConexion();

                // Definir la consulta SQL para insertar en la tabla correspondiente
                string sql = $"INSERT INTO {tabla} (nom_completos, DNI, RUC, descripcion, valor, fecha_facturacion) VALUES (@nom_completos, @DNI, @RUC, @descripcion, @valor, @fecha_facturacion)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nom_completos", txtBoxNoCom.Text);

                // Modificar la conversión del DNI (si se proporciona)
                if (!string.IsNullOrWhiteSpace(txtBoxDNI.Text))
                {
                    if (int.TryParse(txtBoxDNI.Text, out int dni))
                    {
                        cmd.Parameters.AddWithValue("@DNI", dni);
                    }
                    else
                    {
                        // Manejar la situación cuando el DNI no es un número válido
                        throw new FormatException("El formato del DNI no es válido.");
                    }
                }
                else
                {
                    // Si no se proporciona el DNI, asignar un valor nulo a la base de datos
                    cmd.Parameters.AddWithValue("@DNI", DBNull.Value);
                }

                // Modificar la conversión del RUC (si se proporciona)
                if (!string.IsNullOrWhiteSpace(txtBoxRUC.Text))
                {
                    if (long.TryParse(txtBoxRUC.Text, out long rucNumero))
                    {
                        cmd.Parameters.AddWithValue("@RUC", rucNumero);
                    }
                    else
                    {
                        // Manejar la situación cuando el RUC no es un número válido
                        throw new FormatException("El formato del RUC no es válido.");
                    }
                }
                else
                {
                    // Si no se proporciona el RUC, asignar un valor nulo a la base de datos
                    cmd.Parameters.AddWithValue("@RUC", DBNull.Value);
                }

                cmd.Parameters.AddWithValue("@descripcion", filaConcatenada);
                cmd.Parameters.AddWithValue("@valor", valor);
                cmd.Parameters.AddWithValue("@fecha_facturacion", fechaFacturacion);

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Registró exitoso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException ex)
            {
                // Manejar la excepción específica del DNI o RUC
                MessageBox.Show(ex.Message, "Se produjo un error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error inesperado: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertarFilaEnFactura(string filaConcatenada, decimal valor, string tabla, DateTime fechaFacturacion, DateTime fechaPago, string tipoPago, string ruc, DateTime fechaEntrega, decimal cambio)
        {
            try
            {

                Conexion objetoConexion = new Conexion();
                MySqlConnection conn = objetoConexion.establecerConexion();

                // Obtener el valor total en moneda peruana y quitar el símbolo "S/"
                string valorTotalConSimbolo = txtBoxtotalc0.Text.Trim();
                decimal valorTotal = decimal.Parse(valorTotalConSimbolo.Replace("S/", "").Trim(), CultureInfo.GetCultureInfo("es-PE"));

                // Obtener el valor del IGV en moneda peruana y quitar el símbolo "S/"
                string igvConSimbolo = txtBoxIGV1.Text.Trim();
                decimal igv = decimal.Parse(igvConSimbolo.Replace("S/", "").Trim(), CultureInfo.GetCultureInfo("es-PE"));

                // Obtener el valor del total completo en moneda peruana y quitar el símbolo "S/"
                string totalCompletoConSimbolo = txtBoxtotalcompleto1.Text.Trim();
                decimal totalCompleto = decimal.Parse(totalCompletoConSimbolo.Replace("S/", "").Trim(), CultureInfo.GetCultureInfo("es-PE"));

                // Obtener el valor de txtBoxcodi
                string codigoTarjeta = txtBoxcodi.Text;

                // Definir la consulta SQL para insertar en la tabla "gestion_ventas" con fecha de pago, tipo de pago, tipo de cliente, IGV y total
                string sql = $"INSERT INTO {tabla} (nom_completos, DNI, RUC, telefono, descripcion, valor, fecha_facturacion, fecha_pago, tipo_pago, igv, total, fecha_entrega, cambio, codigotarjeta) " +
                    "VALUES (@nom_completos, @DNI, @RUC, @telefono, @descripcion, @valor, @fecha_facturacion, @fecha_pago, @tipo_pago, @igv, @total, @fecha_entrega, @cambio, @codigotarjeta)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nom_completos", txtBoxNoCom.Text);
                cmd.Parameters.AddWithValue("@DNI", Convert.ToInt32(txtBoxDNI.Text));
                cmd.Parameters.AddWithValue("@RUC", ruc);
                cmd.Parameters.AddWithValue("@telefono", Convert.ToInt32(txtBoxTelef.Text));  // Agregar el valor del teléfono
                cmd.Parameters.AddWithValue("@descripcion", filaConcatenada);
                cmd.Parameters.AddWithValue("@valor", valor);
                cmd.Parameters.AddWithValue("@fecha_facturacion", fechaFacturacion);
                cmd.Parameters.AddWithValue("@fecha_pago", fechaPago);
                cmd.Parameters.AddWithValue("@tipo_pago", tipoPago);
                cmd.Parameters.AddWithValue("@igv", igv);
                cmd.Parameters.AddWithValue("@total", totalCompleto);
                cmd.Parameters.AddWithValue("@fecha_entrega", fechaEntrega);
                cmd.Parameters.AddWithValue("@cambio", cambio);
                cmd.Parameters.AddWithValue("@codigotarjeta", string.IsNullOrEmpty(codigoTarjeta) ? (object)DBNull.Value : codigoTarjeta);

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Registro exitoso. Continúa con el procedimiento en la siguiente pestaña.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Se produjo un error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void limpiartodo()
        {
            //Limpiar
            cbotipago1.SelectedIndex = 0;
            cbotipop.SelectedIndex = 0; 
            cbocorte.SelectedIndex = -1;
            cbomaterial.SelectedIndex = -1;
            txtBoxcodi.Text = "";
            txtBoxNoCom.Text = "";
            txtBoxDirec.Text = "";
            txtBoxDNI.Text = "";
            txtBoxdescu.Text = "";
            txtBoxRUC.Text = "";
            txtBoxfeent.Text = "";
            txtBoxcant0.Text = "";
            txtBoxdes0.Text = "";
            txtBoxtamc0.Text = "";
            txtBoxprecio0.Text = "";
            txtBoxmate0.Text = "";
            txtBoxcorpe0.Text = "";
            txtBoxTelef.Text = "";
            txtpuntosacu.Text = "";
            txtBoxtotalc0.Text = "S/ 0.00";
            txtBoxIGV1.Text = "S/ 0.00";
            txtBoxRecibido.Text = "";
            txtBoxtotalcompleto1.Text = "S/ 0.00";
            txtBoxCambio.Text = "";
            txtBoxfepago.Text = "";


            txtBoxprecio1.Text = "";
            txtBoxprecio2.Text = "";
            txtBoxprecio3.Text = "";
            txtBoxprecio4.Text = "";
            txtBoxprecio5.Text = "";
            txtBoxprecio6.Text = "";
            txtBoxprecio7.Text = "";
            txtBoxprecio8.Text = "";
            txtBoxprecio9.Text = "";
        }



        private void MostrarFechaActual()
        {
            // Obtener la fecha y hora actual
            DateTime fechaActual = DateTime.Now;

            // Mostrar la fecha actual en el formato deseado en el TextBox
            txtBoxfefac.Text = fechaActual.ToString("dd/MM/yyyy"); // Cambia el formato según tus preferencias
        }

        private void MostrarFechaPagoActual()
        {
            // Obtener la fecha y hora actual
            DateTime fechaActual = DateTime.Now;

            // Verificar si cbotipago1 tiene un elemento seleccionado
            if (cbotipago1.SelectedItem != null)
            {
                string formaPago = cbotipago1.SelectedItem.ToString();

                // Establecer una variable para la fecha de pago
                DateTime fechaPago;

                // Verificar la forma de pago y calcular la fecha de pago en consecuencia
                if (formaPago == "Efectivo" || formaPago == "Tarjeta")
                {
                    // Fecha de hoy para Efectivo o Tarjeta
                    fechaPago = fechaActual;
                }
                else if (formaPago == "Cheque" || formaPago == "Transferencia")
                {
                    // Fecha de hoy + 5 días para Cheque o Transferencia
                    fechaPago = fechaActual.AddDays(5);
                }
                else if (formaPago == "-------------")
                {
                    // Si la forma de pago es "-------------", dejar la fecha de pago en blanco
                    fechaPago = DateTime.MinValue;
                }
                else
                {
                    // Por defecto, usar la fecha de hoy
                    fechaPago = fechaActual;
                }

                // Mostrar la fecha de pago en el formato deseado en el TextBox
                txtBoxfepago.Text = (fechaPago != DateTime.MinValue) ? fechaPago.ToString("dd/MM/yyyy") : "";
            }
        }

        private void cbotipago1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarFechaPagoActual();

        }

        private void ObtenerYMostrarIGV()
        {
            try
            {
                Conexion objetoConexion = new Conexion();
                MySqlConnection conn = objetoConexion.establecerConexion();

                // Modificar la consulta SQL para seleccionar el último registro de la tabla configuracion
                string sql = "SELECT igv FROM configuracion ORDER BY id DESC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                decimal igv = 0;

                if (reader.Read())
                {
                    // Verificar si el valor de "igv" es numérico antes de intentar convertirlo
                    if (reader["igv"] != DBNull.Value)
                    {
                        string igvString = reader["igv"].ToString();

                        // Verificar si el valor es numérico
                        if (decimal.TryParse(igvString,
                            NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands,
                            CultureInfo.InvariantCulture,
                            out igv))
                        {
                            // Obtener el valor total en moneda peruana y quitar el símbolo "S/"
                            string valorTotalConSimbolo = txtBoxtotalc0.Text.Trim();
                            decimal valorTotal = decimal.Parse(valorTotalConSimbolo.Replace("S/", "").Trim(), CultureInfo.GetCultureInfo("es-PE"));

                            // Calcular el IGV
                            decimal porcentajeIGV = igv / 100; // Convertir el porcentaje a decimal
                            decimal totalIGV = valorTotal * porcentajeIGV;

                            // Mostrar el resultado en txtBoxIGV1 con formato de moneda peruana
                            CultureInfo culture = new CultureInfo("es-PE");
                            txtBoxIGV1.Text = totalIGV.ToString("C", culture);
                        }
                    }
                }

                conn.Close();
            }
            catch (Exception)
            {
            }
        }

        private void MostrarTotalCompleto()
        {
            try
            {
                // Obtener el valor total en moneda peruana y quitar el símbolo "S/"
                string valorTotalConSimbolo = txtBoxtotalc0.Text.Trim();
                decimal valorTotal = decimal.Parse(valorTotalConSimbolo.Replace("S/", "").Trim(), CultureInfo.GetCultureInfo("es-PE"));

                // Obtener el valor del IGV en moneda peruana y quitar el símbolo "S/"
                string igvConSimbolo = txtBoxIGV1.Text.Trim();
                decimal igv = decimal.Parse(igvConSimbolo.Replace("S/", "").Trim(), CultureInfo.GetCultureInfo("es-PE"));

                // Calcular el total completo sin descuento
                decimal totalCompleto = valorTotal + igv;

                // Verificar si hay un descuento ingresado en txtBoxdescu
                if (decimal.TryParse(txtBoxdescu.Text, out decimal descuento))
                {
                    // Calcular el nuevo total teniendo en cuenta el descuento
                    totalCompleto = totalCompleto - descuento;
                }

                // Mostrar el resultado en txtBoxtotalcompleto1 con formato de moneda peruana
                CultureInfo culture = new CultureInfo("es-PE");
                txtBoxtotalcompleto1.Text = totalCompleto.ToString("C", culture);
            }
            catch (FormatException ex)
            {
                
            }
        }


        private void txtBoxRecibido_TextChanged(object sender, EventArgs e)
        {
            // Verificar si el texto en txtBoxRecibido es "0"
            if (txtBoxRecibido.Text.Trim() == "0")
            {
                // Asignar "0" directamente al txtBoxCambio y salir del evento
                txtBoxCambio.Text = "0";
                return;
            }
            // Verificar si el texto en txtBoxRecibido es un número válido
            if (decimal.TryParse(txtBoxRecibido.Text, out decimal recibido))
            {
                // Obtener el valor total completo en moneda peruana y quitar el símbolo "S/"
                string totalCompletoConSimbolo = txtBoxtotalcompleto1.Text.Trim();
                decimal totalCompleto = decimal.Parse(totalCompletoConSimbolo.Replace("S/", "").Trim(), CultureInfo.GetCultureInfo("es-PE"));

                // Calcular el cambio
                decimal cambio = recibido - totalCompleto;

                // Mostrar el cambio en txtBoxCambio con formato de moneda peruana
                CultureInfo culture = new CultureInfo("es-PE");
                txtBoxCambio.Text = cambio.ToString("C", culture);
            }
            else
            {
                // El texto en txtBoxRecibido no es un número válido, puedes mostrar un mensaje de error o limpiar txtBoxCambio.
                txtBoxCambio.Text = string.Empty;
            }
        }

        private void CalcularPuntos()
        {
            try
            {
                // Obtener el valor de txtBoxtotalcompleto1 en moneda peruana y quitar el símbolo "S/"
                string totalCompletoConSimbolo = txtBoxtotalcompleto1.Text.Trim();
                decimal totalCompleto = decimal.Parse(totalCompletoConSimbolo.Replace("S/", "").Trim(), CultureInfo.GetCultureInfo("es-PE"));

                // Calcular los puntos dividiendo el valor total completo entre 100 y redondear a un número entero
                int puntos = (int)Math.Round(totalCompleto / 100);

                // Mostrar el resultado en txtpuntos como un número entero
                txtpuntos.Text = puntos.ToString();
            }
            catch (FormatException ex)
            {
                // Manejar la excepción de formato aquí, por ejemplo, mostrando un mensaje de error al usuario.
            }
        }

        private void ActualizarPuntosEnTabla(string codigoCliente, int puntos)
        {
            try
            {
                Conexion objetoConexion = new Conexion();
                MySqlConnection conn = objetoConexion.establecerConexion();

                // Verificar si el cliente ya existe en la tabla puntos_A utilizando el código.
                string sqlCheckCustomer = "SELECT id, puntos, puntos_totales FROM puntos_A WHERE id = @codigo";
                MySqlCommand cmdCheckCustomer = new MySqlCommand(sqlCheckCustomer, conn);
                cmdCheckCustomer.Parameters.AddWithValue("@codigo", Convert.ToInt32(codigoCliente));

                int customerID = -1;
                int existingPoints = 0;
                int existingTotalPoints = 0;

                using (MySqlDataReader reader = cmdCheckCustomer.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        customerID = reader.GetInt32("id");
                        if (!reader.IsDBNull(reader.GetOrdinal("puntos")))
                        {
                            existingPoints = reader.GetInt32("puntos");
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("puntos_totales")))
                        {
                            existingTotalPoints = reader.GetInt32("puntos_totales");
                        }
                    }
                }

                // Suma los puntos teniendo en cuenta el valor de txtpuntos y los puntos existentes (que se consideran 0 si es NULL).
                int newPoints = existingPoints + puntos;

                // Actualiza los puntos_totales con los nuevos puntos acumulados
                int newTotalPoints = existingTotalPoints + puntos;

                string sqlUpdatePoints;
                MySqlCommand cmdUpdatePoints;

                if (customerID != -1)
                {
                    // El cliente existe, actualiza los puntos y puntos_totales.
                    sqlUpdatePoints = "UPDATE puntos_A SET puntos = @newPoints, puntos_totales = @newTotalPoints WHERE id = @codigo";
                    cmdUpdatePoints = new MySqlCommand(sqlUpdatePoints, conn);
                    cmdUpdatePoints.Parameters.AddWithValue("@newPoints", newPoints);
                    cmdUpdatePoints.Parameters.AddWithValue("@newTotalPoints", newTotalPoints);
                    cmdUpdatePoints.Parameters.AddWithValue("@codigo", Convert.ToInt32(codigoCliente));
                }
                else
                {
                    // El cliente no existe, inserta un nuevo registro con puntos y puntos_totales.
                    sqlUpdatePoints = "INSERT INTO puntos_A (id, puntos, puntos_totales) VALUES (@codigo, @newPoints, @newTotalPoints)";
                    cmdUpdatePoints = new MySqlCommand(sqlUpdatePoints, conn);
                    cmdUpdatePoints.Parameters.AddWithValue("@codigo", Convert.ToInt32(codigoCliente));
                    cmdUpdatePoints.Parameters.AddWithValue("@newPoints", newPoints);
                    cmdUpdatePoints.Parameters.AddWithValue("@newTotalPoints", newTotalPoints);
                }

                cmdUpdatePoints.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Se produjo un error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void MostrarPuntosCliente(string codigoCliente)
        {
            try
            {
                if (int.TryParse(codigoCliente, out int codigoClienteInt))
                {
                    Conexion objetoConexion = new Conexion();
                    MySqlConnection conn = objetoConexion.establecerConexion();

                    // Realizar una consulta para obtener los puntos del cliente.
                    string sql = "SELECT puntos FROM puntos_A WHERE id = @codigo";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@codigo", codigoClienteInt);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal("puntos")))
                            {
                                int puntos = reader.GetInt32("puntos");
                                txtpuntosacu.Text = puntos.ToString(); // Mostrar los puntos en el TextBox txtpuntosacu
                            }
                            else
                            {
                                txtpuntosacu.Text = "0"; // No se encontraron puntos, muestra 0 en el TextBox txtpuntosacu
                            }
                        }
                        else
                        {
                            txtpuntosacu.Text = "0"; // No se encontró al cliente, muestra 0 en el TextBox txtpuntosacu
                        }
                    }

                    conn.Close();
                }
                else
                {
                    // Mostrar un mensaje de advertencia al usuario
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Se produjo un error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      



        private void txtBoxtotalc0_TextChanged(object sender, EventArgs e)
        {
            ObtenerYMostrarIGV();
            MostrarTotalCompleto();
            CalcularPuntos();
        
        }


        private void txtBoxIGV1_TextChanged(object sender, EventArgs e)
        {
           
            ObtenerYMostrarIGV();
         
        }

        private void Facts_Load(object sender, EventArgs e)
        {

            MostrarFechaActual();
            MostrarFechaPagoActual();

        }

        private void btndescuentos0_Click(object sender, EventArgs e)
        {
            // Verificar si el combo está en "Proforma"
            if (cboFtPr.Text == "Proforma")
            {
                MessageBox.Show("No se pueden aplicar descuentos en una proforma.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método sin realizar más acciones
            }
            // Obtener el valor de txtBoxcodi
            string valorParaTransferir = txtBoxcodi.Text;

            // Verificar si el código es válido antes de abrir el formulario de descuentos
            if (!string.IsNullOrEmpty(valorParaTransferir) && int.TryParse(valorParaTransferir, out _))
            {
                // Crear una instancia del formulario GestorTrabajo
                Descuentos descuentosForm = new Descuentos();

                // Suscribirse al evento FormClosed del formulario Descuentos
                descuentosForm.FormClosed += (s, args) =>
                {
                    // Cuando se cierre el formulario Descuentos, obtener el valor y asignarlo a txtBoxdescu
                    txtBoxdescu.Text = descuentosForm.ValorDescuento;
                };

                // Configurar el valor de Codigo1 en el formulario GestorTrabajo
                descuentosForm.Codigo2 = valorParaTransferir;

                // Mostrar el formulario Descuentos
                descuentosForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ingresa algun código válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void txtBoxdescu_TextChanged(object sender, EventArgs e)
        {

            // Verificar si el texto en txtBoxdescu es un número válido
            if (decimal.TryParse(txtBoxdescu.Text, out decimal descuento))
            {
                // Obtener el valor total en moneda peruana y quitar el símbolo "S/"
                string valorTotalConSimbolo = txtBoxtotalc0.Text.Trim();

                // Validar que el valor total tenga un formato válido antes de intentar convertir
                if (decimal.TryParse(valorTotalConSimbolo.Replace("S/", "").Trim(), out decimal valorTotal))
                {
                    // Calcular el nuevo total restando el descuento
                    decimal nuevoTotal = valorTotal - descuento;

                    // Mostrar el nuevo total en txtBoxtotalc0 con formato de moneda peruana
                    CultureInfo culture = new CultureInfo("es-PE");
                    txtBoxtotalc0.Text = nuevoTotal.ToString("C", culture);
                }
                else
                {
                    // El valor total no es un número decimal válido, puedes mostrar un mensaje de error o tomar alguna acción.
                    txtBoxtotalc0.Text = string.Empty;
                }
            }
            else
            {
                // El texto en txtBoxdescu no es un número decimal válido, puedes mostrar un mensaje de error o limpiar txtBoxtotalc0.
                txtBoxtotalc0.Text = string.Empty;
            }
            ObtenerYMostrarIGV();
            MostrarTotalCompleto();
            CalcularPuntos();
            CalcularTotal(sender, e);
            string codigoCliente = txtBoxcodi.Text;

            // Llamar a MostrarPuntosCliente proporcionando el código del cliente
            MostrarPuntosCliente(codigoCliente);
            txtBoxRecibido_TextChanged(sender, e);

        }

        private void btnGenerarVaucher_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener la información de las tablas proforma y gestion_ventas
                DataTable proformaData = ObtenerInformacionDeTabla("proforma");
                DataTable ventasData = ObtenerInformacionDeTabla("gestion_ventas");

                // Determinar el tipo de transacción seleccionado (Proforma o Venta)
                string tipoTransaccion = (cboFtPr.SelectedItem != null) ? cboFtPr.SelectedItem.ToString() : "";

                // Crear un cuadro de diálogo de Guardar como
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Archivos de texto (*.txt)|*.txt",
                    Title = "Guardar Ticket como",
                    FileName = "ticket.txt"
                };

                // Mostrar el cuadro de diálogo y verificar si el usuario hizo clic en "Guardar"
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obtener la ruta del archivo seleccionado por el usuario
                    string rutaArchivo = saveFileDialog.FileName;

                    // Generar el vaucher combinando la información de ambas tablas
                    GenerarVaucher(proformaData, ventasData, rutaArchivo, tipoTransaccion);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el Ticket: " + ex.Message);
            }
        }

        private void GenerarVaucher(DataTable proformaData, DataTable ventasData, string rutaArchivo, string tipoTransaccion)
        {
            StringBuilder vaucherContent = new StringBuilder();

            vaucherContent.AppendLine("================ TICKET ================");
            vaucherContent.AppendLine();

            if (tipoTransaccion == "Proforma" && proformaData.Rows.Count > 0)
            {
                vaucherContent.AppendLine("====== Información de la Proforma =======");
                AgregarInformacionProformaAlVaucher(proformaData.Rows[proformaData.Rows.Count - 1], vaucherContent);
            }
            else if (tipoTransaccion == "Venta" && ventasData.Rows.Count > 0)
            {
                vaucherContent.AppendLine("======== Información de la Venta ========");
                AgregarInformacionVentasAlVaucher(ventasData.Rows[ventasData.Rows.Count - 1], vaucherContent);
            }
            else
            {
                vaucherContent.AppendLine("Tipo de transacción no reconocido o no hay datos disponibles.");
            }

            // Separator between sections
            vaucherContent.AppendLine("=========================================");

            

            File.WriteAllText(rutaArchivo, vaucherContent.ToString());

            MessageBox.Show("Ticket generado exitosamente: " + rutaArchivo, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void AgregarInformacionProformaAlVaucher(DataRow row, StringBuilder vaucherContent)
        {
            // Añadir información de la tabla ventas al vaucher
            vaucherContent.AppendLine();
            vaucherContent.AppendLine($"Cliente: {row["nom_completos"]}");
            vaucherContent.AppendLine($"DNI: {row["DNI"]}");
            vaucherContent.AppendLine($"RUC: {row["RUC"]}");
            vaucherContent.AppendLine();

            vaucherContent.AppendLine("======== Detalles de la Proforma ========");
            vaucherContent.AppendLine();

            string[] trabajos = row["descripcion"].ToString().Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < trabajos.Length; i++)
            {
                string[] elementos = trabajos[i].Split(',');

                vaucherContent.AppendLine($"Trabajo {i + 1}:");
                vaucherContent.AppendLine($"Cantidad: {elementos[0].Trim()}");
                vaucherContent.AppendLine($"Descripción: {elementos[1].Trim()}");
                vaucherContent.AppendLine($"Tamaño de Corte: {elementos[2].Trim()}");
                vaucherContent.AppendLine($"Tipo de Corte: {elementos[3].Trim()}");
                vaucherContent.AppendLine($"Material: {elementos[4].Trim()}");
                vaucherContent.AppendLine(); // Línea en blanco entre trabajos
            }

            vaucherContent.AppendLine("================ COSTOS =================");
            vaucherContent.AppendLine($"Valor: S/ {row["valor"]:N2}");
            vaucherContent.AppendLine($"Fecha: {((DateTime)row["fecha_facturacion"]).ToString("dd/MM/yyyy")}");
        }

        private void AgregarInformacionVentasAlVaucher(DataRow row, StringBuilder vaucherContent)
        {
            // Añadir información de la tabla ventas al vaucher
            vaucherContent.AppendLine();
            vaucherContent.AppendLine($"Cliente: {row["nom_completos"]}");
            vaucherContent.AppendLine($"DNI: {row["DNI"]}");
            vaucherContent.AppendLine($"RUC: {row["RUC"]}");
            vaucherContent.AppendLine();

            vaucherContent.AppendLine("======== Información del Trabajo ========");
            vaucherContent.AppendLine();
            vaucherContent.AppendLine($"Fecha de Entrega: {((DateTime)row["fecha_entrega"]).ToString("dd/MM/yyyy")}");
            vaucherContent.AppendLine();
           

            string[] trabajos = row["descripcion"].ToString().Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < trabajos.Length; i++)
            {
                string[] elementos = trabajos[i].Split(',');

                vaucherContent.AppendLine($"Trabajo {i + 1}:");
                vaucherContent.AppendLine($"Cantidad: {elementos[0].Trim()}");
                vaucherContent.AppendLine($"Descripción: {elementos[1].Trim()}");
                vaucherContent.AppendLine($"Tamaño de Corte: {elementos[2].Trim()}");
                vaucherContent.AppendLine($"Tipo de Corte: {elementos[3].Trim()}");
                vaucherContent.AppendLine($"Material: {elementos[4].Trim()}");
                vaucherContent.AppendLine(); // Línea en blanco entre trabajos
            }

            vaucherContent.AppendLine("================ COSTOS =================");
            vaucherContent.AppendLine($"Valor: S/ {row["valor"]:N2}");
            vaucherContent.AppendLine($"IGV: S/ {row["igv"]:N2}");
            vaucherContent.AppendLine($"Total: S/ {row["total"]:N2}");
            vaucherContent.AppendLine($"Fecha: {((DateTime)row["fecha_facturacion"]).ToString("dd/MM/yyyy")}");
        }

        private DataTable ObtenerInformacionDeTabla(string tabla)
        {
            // Conexión a la base de datos
            Conexion objetoConexion = new Conexion();
            MySqlConnection conn = objetoConexion.establecerConexion();

            // Consulta SQL para obtener información de la tabla especificada
            string sql = $"SELECT * FROM {tabla}";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            // Adaptador para llenar un DataTable
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            // DataTable para almacenar los resultados de la consulta
            DataTable dataTable = new DataTable();

            // Llenar el DataTable con los resultados de la consulta
            adapter.Fill(dataTable);

            // Cerrar la conexión
            conn.Close();

            return dataTable;
        }

       
        //Combos 0 de "," "."

        private void txtBoxcant0_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla si no es un número ni la tecla de retroceso
            }
        }

        private void txtBoxprecio0_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número, la tecla de retroceso, "." o ","
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true; // Ignorar la tecla si no es un número, la tecla de retroceso, "." ni ","
            }

            // Convertir "." a "," antes de realizar la conversión a decimal
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            // Verificar si ya hay una coma en el texto
            if (e.KeyChar == ',' && (sender as System.Windows.Forms.TextBox).Text.Contains(','))
            {
                e.Handled = true; // Si ya hay una coma, bloquear la entrada de otra coma
            }
        }


        //Combos 1 de "," "."
        private void txtBoxcant1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla si no es un número ni la tecla de retroceso
            }
        }

        private void txtBoxprecio1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número, la tecla de retroceso, "." o ","
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true; // Ignorar la tecla si no es un número, la tecla de retroceso, "." ni ","
            }

            // Convertir "." a "," antes de realizar la conversión a decimal
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            // Verificar si ya hay una coma en el texto
            if (e.KeyChar == ',' && (sender as System.Windows.Forms.TextBox).Text.Contains(','))
            {
                e.Handled = true; // Si ya hay una coma, bloquear la entrada de otra coma
            }
        }

        //Combos 2 de "," "."
        private void txtBoxcant2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla si no es un número ni la tecla de retroceso
            }
        }

        private void txtBoxprecio2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número, la tecla de retroceso, "." o ","
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true; // Ignorar la tecla si no es un número, la tecla de retroceso, "." ni ","
            }

            // Convertir "." a "," antes de realizar la conversión a decimal
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            // Verificar si ya hay una coma en el texto
            if (e.KeyChar == ',' && (sender as System.Windows.Forms.TextBox).Text.Contains(','))
            {
                e.Handled = true; // Si ya hay una coma, bloquear la entrada de otra coma
            }
        }

        //Combos 3 de "," "."
        private void txtBoxcant3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla si no es un número ni la tecla de retroceso
            }
        }

        private void txtBoxprecio3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número, la tecla de retroceso, "." o ","
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true; // Ignorar la tecla si no es un número, la tecla de retroceso, "." ni ","
            }

            // Convertir "." a "," antes de realizar la conversión a decimal
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            // Verificar si ya hay una coma en el texto
            if (e.KeyChar == ',' && (sender as System.Windows.Forms.TextBox).Text.Contains(','))
            {
                e.Handled = true; // Si ya hay una coma, bloquear la entrada de otra coma
            }
        }

        //Combos 4 de "," "."
        private void txtBoxcant4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla si no es un número ni la tecla de retroceso
            }
        }

        private void txtBoxprecio4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número, la tecla de retroceso, "." o ","
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true; // Ignorar la tecla si no es un número, la tecla de retroceso, "." ni ","
            }

            // Convertir "." a "," antes de realizar la conversión a decimal
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            // Verificar si ya hay una coma en el texto
            if (e.KeyChar == ',' && (sender as System.Windows.Forms.TextBox).Text.Contains(','))
            {
                e.Handled = true; // Si ya hay una coma, bloquear la entrada de otra coma
            }
        }

        //Combos 5 de "," "."
        private void txtBoxcant5_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla si no es un número ni la tecla de retroceso
            }
        }

        private void txtBoxprecio5_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número, la tecla de retroceso, "." o ","
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true; // Ignorar la tecla si no es un número, la tecla de retroceso, "." ni ","
            }

            // Convertir "." a "," antes de realizar la conversión a decimal
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            // Verificar si ya hay una coma en el texto
            if (e.KeyChar == ',' && (sender as System.Windows.Forms.TextBox).Text.Contains(','))
            {
                e.Handled = true; // Si ya hay una coma, bloquear la entrada de otra coma
            }
        }

        //Combos 6 de "," "."
        private void txtBoxcant6_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla si no es un número ni la tecla de retroceso
            }
        }

        private void txtBoxprecio6_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número, la tecla de retroceso, "." o ","
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true; // Ignorar la tecla si no es un número, la tecla de retroceso, "." ni ","
            }

            // Convertir "." a "," antes de realizar la conversión a decimal
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            // Verificar si ya hay una coma en el texto
            if (e.KeyChar == ',' && (sender as System.Windows.Forms.TextBox).Text.Contains(','))
            {
                e.Handled = true; // Si ya hay una coma, bloquear la entrada de otra coma
            }
        }

        //Combos 7 de "," "."
        private void txtBoxcant7_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla si no es un número ni la tecla de retroceso
            }
        }

        private void txtBoxprecio7_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número, la tecla de retroceso, "." o ","
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true; // Ignorar la tecla si no es un número, la tecla de retroceso, "." ni ","
            }

            // Convertir "." a "," antes de realizar la conversión a decimal
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            // Verificar si ya hay una coma en el texto
            if (e.KeyChar == ',' && (sender as System.Windows.Forms.TextBox).Text.Contains(','))
            {
                e.Handled = true; // Si ya hay una coma, bloquear la entrada de otra coma
            }
        }

        //Combos 8 de "," "."
        private void txtBoxcant8_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla si no es un número ni la tecla de retroceso
            }
        }

        private void txtBoxprecio8_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número, la tecla de retroceso, "." o ","
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true; // Ignorar la tecla si no es un número, la tecla de retroceso, "." ni ","
            }

            // Convertir "." a "," antes de realizar la conversión a decimal
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            // Verificar si ya hay una coma en el texto
            if (e.KeyChar == ',' && (sender as System.Windows.Forms.TextBox).Text.Contains(','))
            {
                e.Handled = true; // Si ya hay una coma, bloquear la entrada de otra coma
            }
        }

        //Combos 9 de "," "."
        private void txtBoxcant9_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla si no es un número ni la tecla de retroceso
            }
        }

        private void txtBoxprecio9_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número, la tecla de retroceso, "." o ","
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true; // Ignorar la tecla si no es un número, la tecla de retroceso, "." ni ","
            }

            // Convertir "." a "," antes de realizar la conversión a decimal
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            // Verificar si ya hay una coma en el texto
            if (e.KeyChar == ',' && (sender as System.Windows.Forms.TextBox).Text.Contains(','))
            {
                e.Handled = true; // Si ya hay una coma, bloquear la entrada de otra coma
            }
        }


        //Cambios o vuelto
        private void txtBoxRecibido_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número, la tecla de retroceso, "." o ","
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true; // Ignorar la tecla si no es un número, la tecla de retroceso, "." ni ","
            }

            // Convertir "." a "," antes de realizar la conversión a decimal
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            // Verificar si ya hay una coma en el texto
            if (e.KeyChar == ',' && (sender as System.Windows.Forms.TextBox).Text.Contains(','))
            {
                e.Handled = true; // Si ya hay una coma, bloquear la entrada de otra coma
            }
        }

        //Telefono
        private void txtBoxTelef_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla si no es un número ni la tecla de retroceso
            }
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            limpiartodo();
        }

        private void txtBoxprecio0_KeyDown(object sender, KeyEventArgs e)
        {

        }

       

        private void txtBoxprecio9_TextChanged(object sender, EventArgs e)
        {

        }   


       private void txtBoxcodi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxNoCom_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxcorpe5_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxmate6_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxcorpe8_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxmate9_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxfefac_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxcodi_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtBoxcodi_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
    }

}