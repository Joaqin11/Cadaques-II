namespace Libreria
{
    partial class BusquedaPorNombre
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
            this.lbSeleccioneCarrito = new System.Windows.Forms.Label();
            this.btnAgregarAlCarrito = new System.Windows.Forms.Button();
            this.cmbSeleccionCarrito = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lstArticulosParaAgregarAlCarrito = new System.Windows.Forms.ListBox();
            this.tbxNombre = new System.Windows.Forms.TextBox();
            this.lbIngrese = new System.Windows.Forms.Label();
            this.cbCantidad = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lbSeleccioneCarrito
            // 
            this.lbSeleccioneCarrito.AutoSize = true;
            this.lbSeleccioneCarrito.Location = new System.Drawing.Point(12, 45);
            this.lbSeleccioneCarrito.Name = "lbSeleccioneCarrito";
            this.lbSeleccioneCarrito.Size = new System.Drawing.Size(172, 13);
            this.lbSeleccioneCarrito.TabIndex = 15;
            this.lbSeleccioneCarrito.Text = "Seleccione la cantidad y el carrito: ";
            // 
            // btnAgregarAlCarrito
            // 
            this.btnAgregarAlCarrito.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnAgregarAlCarrito.Location = new System.Drawing.Point(306, 87);
            this.btnAgregarAlCarrito.Name = "btnAgregarAlCarrito";
            this.btnAgregarAlCarrito.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarAlCarrito.TabIndex = 14;
            this.btnAgregarAlCarrito.Text = "&Agregar";
            this.btnAgregarAlCarrito.UseVisualStyleBackColor = true;
            this.btnAgregarAlCarrito.Click += new System.EventHandler(this.btnAgregarAlCarrito_Click);
            // 
            // cmbSeleccionCarrito
            // 
            this.cmbSeleccionCarrito.DisplayMember = "0";
            this.cmbSeleccionCarrito.FormattingEnabled = true;
            this.cmbSeleccionCarrito.Items.AddRange(new object[] {
            "1er Carrito",
            "2do Carrito",
            "3er Carrito"});
            this.cmbSeleccionCarrito.Location = new System.Drawing.Point(266, 42);
            this.cmbSeleccionCarrito.Name = "cmbSeleccionCarrito";
            this.cmbSeleccionCarrito.Size = new System.Drawing.Size(115, 21);
            this.cmbSeleccionCarrito.TabIndex = 13;
            this.cmbSeleccionCarrito.ValueMember = "0";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(306, 349);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(15, 349);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 11;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // lstArticulosParaAgregarAlCarrito
            // 
            this.lstArticulosParaAgregarAlCarrito.FormattingEnabled = true;
            this.lstArticulosParaAgregarAlCarrito.Location = new System.Drawing.Point(15, 116);
            this.lstArticulosParaAgregarAlCarrito.Name = "lstArticulosParaAgregarAlCarrito";
            this.lstArticulosParaAgregarAlCarrito.Size = new System.Drawing.Size(366, 212);
            this.lstArticulosParaAgregarAlCarrito.TabIndex = 10;
            // 
            // tbxNombre
            // 
            this.tbxNombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbxNombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbxNombre.Location = new System.Drawing.Point(156, 17);
            this.tbxNombre.Name = "tbxNombre";
            this.tbxNombre.Size = new System.Drawing.Size(225, 20);
            this.tbxNombre.TabIndex = 9;
            // 
            // lbIngrese
            // 
            this.lbIngrese.AutoSize = true;
            this.lbIngrese.Location = new System.Drawing.Point(12, 20);
            this.lbIngrese.Name = "lbIngrese";
            this.lbIngrese.Size = new System.Drawing.Size(141, 13);
            this.lbIngrese.TabIndex = 8;
            this.lbIngrese.Text = "Ingrese el nombre a buscar: ";
            // 
            // cbCantidad
            // 
            this.cbCantidad.AutoSize = true;
            this.cbCantidad.Checked = true;
            this.cbCantidad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCantidad.Location = new System.Drawing.Point(190, 44);
            this.cbCantidad.Name = "cbCantidad";
            this.cbCantidad.Size = new System.Drawing.Size(70, 17);
            this.cbCantidad.TabIndex = 16;
            this.cbCantidad.Text = "1 Articulo";
            this.cbCantidad.UseVisualStyleBackColor = true;
            // 
            // BusquedaPorNombre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 384);
            this.Controls.Add(this.cbCantidad);
            this.Controls.Add(this.lbSeleccioneCarrito);
            this.Controls.Add(this.btnAgregarAlCarrito);
            this.Controls.Add(this.cmbSeleccionCarrito);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lstArticulosParaAgregarAlCarrito);
            this.Controls.Add(this.tbxNombre);
            this.Controls.Add(this.lbIngrese);
            this.Name = "BusquedaPorNombre";
            this.Text = "Busqueda Por Nombre";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbSeleccioneCarrito;
        public System.Windows.Forms.Button btnAgregarAlCarrito;
        public System.Windows.Forms.ComboBox cmbSeleccionCarrito;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnAceptar;
        public System.Windows.Forms.ListBox lstArticulosParaAgregarAlCarrito;
        public System.Windows.Forms.TextBox tbxNombre;
        public System.Windows.Forms.Label lbIngrese;
        public System.Windows.Forms.CheckBox cbCantidad;
    }
}