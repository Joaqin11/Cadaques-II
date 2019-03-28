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
    public partial class CobrarCarrito : Form
    {
        public CobrarCarrito()
        {
            InitializeComponent();
            cmbTipoDePago.SelectedIndex = 0;
            cmbTipoDePago.SelectedIndex = 0;
        }

        private void cmbTipoDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbTipoDePago.SelectedIndex == 0)
            {
                labRecargo.Visible = false;
                labRecargo.Enabled = false;
                labTipoTarjeta.Visible = false;
                labTipoTarjeta.Enabled = false;
                tbxRecargo.Visible = false;
                tbxRecargo.Enabled = false;
                cmbTipoTarjeta.Visible = false;
                cmbTipoTarjeta.Enabled = false;
                labDineroRecibido.Visible = true;
                labDineroRecibido.Enabled = true;
                tbxDineroRecibido.Visible = true;
                tbxDineroRecibido.Enabled = true;
            }
            else if(cmbTipoDePago.SelectedIndex == 1)
            {
                labRecargo.Visible = false;
                labRecargo.Enabled = false;
                labTipoTarjeta.Visible = true;
                labTipoTarjeta.Enabled = true;
                tbxRecargo.Visible = false;
                tbxRecargo.Enabled = false;
                cmbTipoTarjeta.SelectedIndex = 0;
                cmbTipoTarjeta.Visible = true;
                cmbTipoTarjeta.Enabled = true;
                labDineroRecibido.Visible = false;
                labDineroRecibido.Enabled = false;
                tbxDineroRecibido.Visible = false;
                tbxDineroRecibido.Enabled = false;

            }
            else
            {
                labRecargo.Visible = false;
                labRecargo.Enabled = false;
                labTipoTarjeta.Visible = false;
                labTipoTarjeta.Enabled = false;
                tbxRecargo.Visible = false;
                tbxRecargo.Enabled = false;
                cmbTipoTarjeta.Visible = false;
                cmbTipoTarjeta.Enabled = false;
                labDineroRecibido.Visible = true;
                labDineroRecibido.Enabled = true;
                tbxDineroRecibido.Visible = true;
                tbxDineroRecibido.Enabled = true;
            }
        }

        private void cmbTipoTarjeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbTipoTarjeta.SelectedIndex >= 1 && cmbTipoTarjeta.SelectedIndex <= 3)
            {
                labRecargo.Visible = true;
                labRecargo.Enabled = true;
                tbxRecargo.Visible = true;
                tbxRecargo.Enabled = true;
            }
            else
            {
                labRecargo.Visible = false;
                labRecargo.Enabled = false;
                tbxRecargo.Visible = false;
                tbxRecargo.Enabled = false;
            }
        }
    }
}
