using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Libreria
{
    public partial class BusquedaPorNombre : Form
    {
        public BusquedaPorNombre()
        {
            InitializeComponent();
            cmbSeleccionCarrito.SelectedIndex = 0;
        }

        private void btnAgregarAlCarrito_Click(object sender, EventArgs e)
        {
            
        }
    }
}