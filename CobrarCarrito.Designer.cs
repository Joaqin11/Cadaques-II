namespace Libreria
{
    partial class CobrarCarrito
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTipoDePago = new System.Windows.Forms.ComboBox();
            this.labTipoDePago = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbxDineroRecibido = new System.Windows.Forms.TextBox();
            this.labDineroRecibido = new System.Windows.Forms.Label();
            this.tbxRecargo = new System.Windows.Forms.TextBox();
            this.labRecargo = new System.Windows.Forms.Label();
            this.cmbTipoTarjeta = new System.Windows.Forms.ComboBox();
            this.labTipoTarjeta = new System.Windows.Forms.Label();
            this.labTotal = new System.Windows.Forms.Label();
            this.labTotalACobrar = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTipoDePago);
            this.groupBox1.Controls.Add(this.labTipoDePago);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 96);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar la forma de pago";
            // 
            // cmbTipoDePago
            // 
            this.cmbTipoDePago.FormattingEnabled = true;
            this.cmbTipoDePago.Items.AddRange(new object[] {
            "Efectivo",
            "Credito/Debito",
            "Cheque"});
            this.cmbTipoDePago.Location = new System.Drawing.Point(97, 43);
            this.cmbTipoDePago.Name = "cmbTipoDePago";
            this.cmbTipoDePago.Size = new System.Drawing.Size(100, 21);
            this.cmbTipoDePago.TabIndex = 1;
            this.cmbTipoDePago.SelectedIndexChanged += new System.EventHandler(this.cmbTipoDePago_SelectedIndexChanged);
            // 
            // labTipoDePago
            // 
            this.labTipoDePago.AutoSize = true;
            this.labTipoDePago.Location = new System.Drawing.Point(6, 43);
            this.labTipoDePago.Name = "labTipoDePago";
            this.labTipoDePago.Size = new System.Drawing.Size(76, 13);
            this.labTipoDePago.TabIndex = 0;
            this.labTipoDePago.Text = "Tipo de pago: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbxDineroRecibido);
            this.groupBox2.Controls.Add(this.labDineroRecibido);
            this.groupBox2.Controls.Add(this.tbxRecargo);
            this.groupBox2.Controls.Add(this.labRecargo);
            this.groupBox2.Controls.Add(this.cmbTipoTarjeta);
            this.groupBox2.Controls.Add(this.labTipoTarjeta);
            this.groupBox2.Controls.Add(this.labTotal);
            this.groupBox2.Controls.Add(this.labTotalACobrar);
            this.groupBox2.Location = new System.Drawing.Point(12, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 145);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Registrar Venta";
            // 
            // tbxDineroRecibido
            // 
            this.tbxDineroRecibido.Enabled = false;
            this.tbxDineroRecibido.Location = new System.Drawing.Point(97, 96);
            this.tbxDineroRecibido.Name = "tbxDineroRecibido";
            this.tbxDineroRecibido.Size = new System.Drawing.Size(100, 20);
            this.tbxDineroRecibido.TabIndex = 7;
            this.tbxDineroRecibido.Visible = false;
            // 
            // labDineroRecibido
            // 
            this.labDineroRecibido.AutoSize = true;
            this.labDineroRecibido.Enabled = false;
            this.labDineroRecibido.Location = new System.Drawing.Point(7, 99);
            this.labDineroRecibido.Name = "labDineroRecibido";
            this.labDineroRecibido.Size = new System.Drawing.Size(84, 13);
            this.labDineroRecibido.TabIndex = 6;
            this.labDineroRecibido.Text = "Dinero recibido: ";
            this.labDineroRecibido.Visible = false;
            // 
            // tbxRecargo
            // 
            this.tbxRecargo.Enabled = false;
            this.tbxRecargo.Location = new System.Drawing.Point(97, 70);
            this.tbxRecargo.Name = "tbxRecargo";
            this.tbxRecargo.Size = new System.Drawing.Size(100, 20);
            this.tbxRecargo.TabIndex = 5;
            this.tbxRecargo.Visible = false;
            // 
            // labRecargo
            // 
            this.labRecargo.AutoSize = true;
            this.labRecargo.Enabled = false;
            this.labRecargo.Location = new System.Drawing.Point(7, 73);
            this.labRecargo.Name = "labRecargo";
            this.labRecargo.Size = new System.Drawing.Size(54, 13);
            this.labRecargo.TabIndex = 4;
            this.labRecargo.Text = "Recargo: ";
            this.labRecargo.Visible = false;
            // 
            // cmbTipoTarjeta
            // 
            this.cmbTipoTarjeta.Enabled = false;
            this.cmbTipoTarjeta.FormattingEnabled = true;
            this.cmbTipoTarjeta.Items.AddRange(new object[] {
            "Maestro",
            "Visa",
            "Mastercard",
            "Cabal",
            "Naranja",
            "Sidecreer",
            "Consumax"});
            this.cmbTipoTarjeta.Location = new System.Drawing.Point(97, 43);
            this.cmbTipoTarjeta.Name = "cmbTipoTarjeta";
            this.cmbTipoTarjeta.Size = new System.Drawing.Size(100, 21);
            this.cmbTipoTarjeta.TabIndex = 3;
            this.cmbTipoTarjeta.Visible = false;
            this.cmbTipoTarjeta.SelectedIndexChanged += new System.EventHandler(this.cmbTipoTarjeta_SelectedIndexChanged);
            // 
            // labTipoTarjeta
            // 
            this.labTipoTarjeta.AutoSize = true;
            this.labTipoTarjeta.Enabled = false;
            this.labTipoTarjeta.Location = new System.Drawing.Point(6, 46);
            this.labTipoTarjeta.Name = "labTipoTarjeta";
            this.labTipoTarjeta.Size = new System.Drawing.Size(81, 13);
            this.labTipoTarjeta.TabIndex = 2;
            this.labTipoTarjeta.Text = "Tipo de tarjeta: ";
            this.labTipoTarjeta.Visible = false;
            // 
            // labTotal
            // 
            this.labTotal.AutoSize = true;
            this.labTotal.Location = new System.Drawing.Point(124, 27);
            this.labTotal.Name = "labTotal";
            this.labTotal.Size = new System.Drawing.Size(0, 13);
            this.labTotal.TabIndex = 1;
            // 
            // labTotalACobrar
            // 
            this.labTotalACobrar.AutoSize = true;
            this.labTotalACobrar.Location = new System.Drawing.Point(7, 27);
            this.labTotalACobrar.Name = "labTotalACobrar";
            this.labTotalACobrar.Size = new System.Drawing.Size(79, 13);
            this.labTotalACobrar.TabIndex = 0;
            this.labTotalACobrar.Text = "Total a cobrar: ";
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(12, 277);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(153, 277);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // CobrarCarrito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 312);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CobrarCarrito";
            this.Text = "Cobrar Carrito";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ComboBox cmbTipoDePago;
        public System.Windows.Forms.Label labTipoDePago;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox tbxDineroRecibido;
        public System.Windows.Forms.Label labDineroRecibido;
        public System.Windows.Forms.TextBox tbxRecargo;
        public System.Windows.Forms.Label labRecargo;
        public System.Windows.Forms.ComboBox cmbTipoTarjeta;
        public System.Windows.Forms.Label labTipoTarjeta;
        public System.Windows.Forms.Label labTotal;
        public System.Windows.Forms.Label labTotalACobrar;
        public System.Windows.Forms.Button btnAceptar;
        public System.Windows.Forms.Button btnCancelar;
    }
}