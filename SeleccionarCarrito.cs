using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Libreria
{
    public partial class SeleccionarCarrito : Form
    {
        public SeleccionarCarrito()
        {
            InitializeComponent();
            cmbCarritos.SelectedIndex = 0;
        }

        private void cmbCarritos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
