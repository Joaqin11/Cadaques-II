namespace Libreria
{
    partial class BuscarPorCodigo
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
            this.lbIngrese = new System.Windows.Forms.Label();
            this.tbxCodigo = new System.Windows.Forms.TextBox();
            this.lstArticulosParaAgregarAlCarrito = new System.Windows.Forms.ListBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbSeleccionCarrito = new System.Windows.Forms.ComboBox();
            this.btnAgregarAlCarrito = new System.Windows.Forms.Button();
            this.lbSeleccioneCarrito = new System.Windows.Forms.Label();
            this.cbCantidad = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lbIngrese
            // 
            this.lbIngrese.AutoSize = true;
            this.lbIngrese.Location = new System.Drawing.Point(9, 15);
            this.lbIngrese.Name = "lbIngrese";
            this.lbIngrese.Size = new System.Drawing.Size(138, 13);
            this.lbIngrese.TabIndex = 0;
            this.lbIngrese.Text = "Ingrese el codigo a buscar: ";
            // 
            // tbxCodigo
            // 
            this.tbxCodigo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbxCodigo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbxCodigo.Location = new System.Drawing.Point(153, 12);
            this.tbxCodigo.Name = "tbxCodigo";
            this.tbxCodigo.Size = new System.Drawing.Size(103, 20);
            this.tbxCodigo.TabIndex = 1;
            // 
            // lstArticulosParaAgregarAlCarrito
            // 
            this.lstArticulosParaAgregarAlCarrito.FormattingEnabled = true;
            this.lstArticulosParaAgregarAlCarrito.Location = new System.Drawing.Point(12, 111);
            this.lstArticulosParaAgregarAlCarrito.Name = "lstArticulosParaAgregarAlCarrito";
            this.lstArticulosParaAgregarAlCarrito.Size = new System.Drawing.Size(325, 173);
            this.lstArticulosParaAgregarAlCarrito.TabIndex = 2;
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(12, 298);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(262, 298);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // cmbSeleccionCarrito
            // 
            this.cmbSeleccionCarrito.DisplayMember = "0";
            this.cmbSeleccionCarrito.FormattingEnabled = true;
            this.cmbSeleccionCarrito.Items.AddRange(new object[] {
            "1er Carrito",
            "2do Carrito",
            "3er Carrito"});
            this.cmbSeleccionCarrito.Location = new System.Drawing.Point(222, 37);
            this.cmbSeleccionCarrito.Name = "cmbSeleccionCarrito";
            this.cmbSeleccionCarrito.Size = new System.Drawing.Size(115, 21);
            this.cmbSeleccionCarrito.TabIndex = 5;
            this.cmbSeleccionCarrito.ValueMember = "0";
            // 
            // btnAgregarAlCarrito
            // 
            this.btnAgregarAlCarrito.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnAgregarAlCarrito.Location = new System.Drawing.Point(262, 82);
            this.btnAgregarAlCarrito.Name = "btnAgregarAlCarrito";
            this.btnAgregarAlCarrito.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarAlCarrito.TabIndex = 6;
            this.btnAgregarAlCarrito.Text = "&Agregar";
            this.btnAgregarAlCarrito.UseVisualStyleBackColor = true;
            this.btnAgregarAlCarrito.Click += new System.EventHandler(this.btnAgregarAlCarrito_Click);
            // 
            // lbSeleccioneCarrito
            // 
            this.lbSeleccioneCarrito.AutoSize = true;
            this.lbSeleccioneCarrito.Location = new System.Drawing.Point(9, 41);
            this.lbSeleccioneCarrito.Name = "lbSeleccioneCarrito";
            this.lbSeleccioneCarrito.Size = new System.Drawing.Size(167, 13);
            this.lbSeleccioneCarrito.TabIndex = 7;
            this.lbSeleccioneCarrito.Text = "Seleccione el carrito de compras: ";
            // 
            // cbCantidad
            // 
            this.cbCantidad.AutoSize = true;
            this.cbCantidad.Checked = true;
            this.cbCantidad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCantidad.Location = new System.Drawing.Point(262, 14);
            this.cbCantidad.Name = "cbCantidad";
            this.cbCantidad.Size = new System.Drawing.Size(70, 17);
            this.cbCantidad.TabIndex = 8;
            this.cbCantidad.Text = "1 Articulo";
            this.cbCantidad.UseVisualStyleBackColor = true;
            // 
            // BuscarPorCodigo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 333);
            this.Controls.Add(this.cbCantidad);
            this.Controls.Add(this.lbSeleccioneCarrito);
            this.Controls.Add(this.btnAgregarAlCarrito);
            this.Controls.Add(this.cmbSeleccionCarrito);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lstArticulosParaAgregarAlCarrito);
            this.Controls.Add(this.tbxCodigo);
            this.Controls.Add(this.lbIngrese);
            this.Name = "BuscarPorCodigo";
            this.Text = "Busqueda Por Codigo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbIngrese;
        public System.Windows.Forms.TextBox tbxCodigo;
        public System.Windows.Forms.ListBox lstArticulosParaAgregarAlCarrito;
        public System.Windows.Forms.Button btnAceptar;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.ComboBox cmbSeleccionCarrito;
        public System.Windows.Forms.Button btnAgregarAlCarrito;
        public System.Windows.Forms.Label lbSeleccioneCarrito;
        public System.Windows.Forms.CheckBox cbCantidad;
    }
}