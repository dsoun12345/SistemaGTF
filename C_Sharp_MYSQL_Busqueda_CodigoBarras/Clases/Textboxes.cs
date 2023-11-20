using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace C_Sharp_MYSQL_Busqueda_CodigoBarras.Clases
{
    internal class Textboxes : TextBox
    {
        public Textboxes()
        {
            this.BorderStyle = BorderStyle.None; // Elimina el borde predeterminado
            this.ForeColor = Color.Black; // Cambia el color del texto si lo deseas
            this.Padding = new Padding(2); // Añade un relleno para controlar el espacio entre el texto y el borde
        }

        // Puedes personalizar aún más el aspecto en el evento OnPaint
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Dibuja el borde personalizado
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.Red, ButtonBorderStyle.Solid);
        }
    }
}
