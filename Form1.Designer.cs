namespace Libreria
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirCajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retirarPDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarCajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cargarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.articulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porNombreToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbxBuscarToolStripMenu = new System.Windows.Forms.ToolStripTextBox();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListaArticulos = new System.Windows.Forms.ListView();
            this.lstCarrito1 = new System.Windows.Forms.ListBox();
            this.lstCarrito2 = new System.Windows.Forms.ListBox();
            this.lstCarrito3 = new System.Windows.Forms.ListBox();
            this.btnAgregarACarrito1 = new System.Windows.Forms.Button();
            this.btnEliminarItemsDelCarrito1 = new System.Windows.Forms.Button();
            this.btnVenderItemsDelCarrito1 = new System.Windows.Forms.Button();
            this.btnAgregarACarrito2 = new System.Windows.Forms.Button();
            this.btnEliminarItemsDelCarrito2 = new System.Windows.Forms.Button();
            this.btnVenderItemsDelCarrito2 = new System.Windows.Forms.Button();
            this.btnAgregarACarrito3 = new System.Windows.Forms.Button();
            this.btnEliminarItemsDelCarrito3 = new System.Windows.Forms.Button();
            this.btnVenderItemsDelCarrito3 = new System.Windows.Forms.Button();
            this.gbCarritoDeCompras1 = new System.Windows.Forms.GroupBox();
            this.btnFinalizarCarrito1 = new System.Windows.Forms.Button();
            this.cbxCantArticulos1 = new System.Windows.Forms.CheckBox();
            this.btnImprmirCarrito1 = new System.Windows.Forms.Button();
            this.gbCarritoDeCompras2 = new System.Windows.Forms.GroupBox();
            this.btnFinalizarCarrito2 = new System.Windows.Forms.Button();
            this.cbxCantArticulos2 = new System.Windows.Forms.CheckBox();
            this.btnImprimirCarrito2 = new System.Windows.Forms.Button();
            this.gbCarritoDeCompras3 = new System.Windows.Forms.GroupBox();
            this.btnFinalizarCarrito3 = new System.Windows.Forms.Button();
            this.cbxCantArticulos3 = new System.Windows.Forms.CheckBox();
            this.btnImprimirCarrito3 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.tbxTexto = new System.Windows.Forms.TextBox();
            this.tbxRetiroPD = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.gbCarritoDeCompras1.SuspendLayout();
            this.gbCarritoDeCompras2.SuspendLayout();
            this.gbCarritoDeCompras3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.buscarToolStripMenuItem,
            this.tbxBuscarToolStripMenu,
            this.acercaDeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1020, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirCajaToolStripMenuItem,
            this.retirarPDToolStripMenuItem,
            this.cerrarCajaToolStripMenuItem,
            this.toolStripSeparator1,
            this.cargarToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 23);
            this.archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // abrirCajaToolStripMenuItem
            // 
            this.abrirCajaToolStripMenuItem.Name = "abrirCajaToolStripMenuItem";
            this.abrirCajaToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.abrirCajaToolStripMenuItem.Text = "&Abrir caja";
            this.abrirCajaToolStripMenuItem.Click += new System.EventHandler(this.abrirCajaToolStripMenuItem_Click);
            // 
            // retirarPDToolStripMenuItem
            // 
            this.retirarPDToolStripMenuItem.Enabled = false;
            this.retirarPDToolStripMenuItem.Name = "retirarPDToolStripMenuItem";
            this.retirarPDToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.retirarPDToolStripMenuItem.Text = "&Retirar pd";
            this.retirarPDToolStripMenuItem.Click += new System.EventHandler(this.retirarPDToolStripMenuItem_Click);
            // 
            // cerrarCajaToolStripMenuItem
            // 
            this.cerrarCajaToolStripMenuItem.Enabled = false;
            this.cerrarCajaToolStripMenuItem.Name = "cerrarCajaToolStripMenuItem";
            this.cerrarCajaToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.cerrarCajaToolStripMenuItem.Text = "&Cerrar caja";
            this.cerrarCajaToolStripMenuItem.Click += new System.EventHandler(this.cerrarCajaToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(187, 6);
            // 
            // cargarToolStripMenuItem
            // 
            this.cargarToolStripMenuItem.Enabled = false;
            this.cargarToolStripMenuItem.Name = "cargarToolStripMenuItem";
            this.cargarToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.cargarToolStripMenuItem.Text = "Car&gar lista de Precios";
            this.cargarToolStripMenuItem.Click += new System.EventHandler(this.cargarToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.salirToolStripMenuItem.Text = "&Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // buscarToolStripMenuItem
            // 
            this.buscarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.articulosToolStripMenuItem,
            this.porNombreToolStripMenuItem1});
            this.buscarToolStripMenuItem.Enabled = false;
            this.buscarToolStripMenuItem.Name = "buscarToolStripMenuItem";
            this.buscarToolStripMenuItem.Size = new System.Drawing.Size(54, 23);
            this.buscarToolStripMenuItem.Text = "&Buscar";
            // 
            // articulosToolStripMenuItem
            // 
            this.articulosToolStripMenuItem.Name = "articulosToolStripMenuItem";
            this.articulosToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.articulosToolStripMenuItem.Text = "Por &Codigo";
            this.articulosToolStripMenuItem.Click += new System.EventHandler(this.articulosToolStripMenuItem_Click);
            // 
            // porNombreToolStripMenuItem1
            // 
            this.porNombreToolStripMenuItem1.Name = "porNombreToolStripMenuItem1";
            this.porNombreToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.porNombreToolStripMenuItem1.Text = "Por &Nombre";
            this.porNombreToolStripMenuItem1.Click += new System.EventHandler(this.porNombreToolStripMenuItem1_Click);
            // 
            // tbxBuscarToolStripMenu
            // 
            this.tbxBuscarToolStripMenu.Enabled = false;
            this.tbxBuscarToolStripMenu.Name = "tbxBuscarToolStripMenu";
            this.tbxBuscarToolStripMenu.Size = new System.Drawing.Size(150, 23);
            this.tbxBuscarToolStripMenu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxBuscarToolStripMenu_KeyDown);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(80, 23);
            this.acercaDeToolStripMenuItem.Text = "A&cerca de...";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // ListaArticulos
            // 
            this.ListaArticulos.HideSelection = false;
            this.ListaArticulos.Location = new System.Drawing.Point(12, 36);
            this.ListaArticulos.MultiSelect = false;
            this.ListaArticulos.Name = "ListaArticulos";
            this.ListaArticulos.Size = new System.Drawing.Size(635, 679);
            this.ListaArticulos.TabIndex = 1;
            this.ListaArticulos.UseCompatibleStateImageBehavior = false;
            this.ListaArticulos.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListaArticulos_ItemSelectionChanged);
            this.ListaArticulos.SelectedIndexChanged += new System.EventHandler(this.ListaArticulos_SelectedIndexChanged);
            // 
            // lstCarrito1
            // 
            this.lstCarrito1.FormattingEnabled = true;
            this.lstCarrito1.HorizontalScrollbar = true;
            this.lstCarrito1.Location = new System.Drawing.Point(87, 19);
            this.lstCarrito1.Name = "lstCarrito1";
            this.lstCarrito1.Size = new System.Drawing.Size(262, 160);
            this.lstCarrito1.TabIndex = 2;
            // 
            // lstCarrito2
            // 
            this.lstCarrito2.FormattingEnabled = true;
            this.lstCarrito2.Location = new System.Drawing.Point(87, 19);
            this.lstCarrito2.Name = "lstCarrito2";
            this.lstCarrito2.Size = new System.Drawing.Size(262, 160);
            this.lstCarrito2.TabIndex = 3;
            // 
            // lstCarrito3
            // 
            this.lstCarrito3.FormattingEnabled = true;
            this.lstCarrito3.Location = new System.Drawing.Point(87, 19);
            this.lstCarrito3.Name = "lstCarrito3";
            this.lstCarrito3.Size = new System.Drawing.Size(262, 160);
            this.lstCarrito3.TabIndex = 4;
            // 
            // btnAgregarACarrito1
            // 
            this.btnAgregarACarrito1.Location = new System.Drawing.Point(6, 19);
            this.btnAgregarACarrito1.Name = "btnAgregarACarrito1";
            this.btnAgregarACarrito1.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarACarrito1.TabIndex = 5;
            this.btnAgregarACarrito1.Text = "&Agregar";
            this.btnAgregarACarrito1.UseVisualStyleBackColor = true;
            this.btnAgregarACarrito1.Click += new System.EventHandler(this.btnAgregarACarrito1_Click);
            // 
            // btnEliminarItemsDelCarrito1
            // 
            this.btnEliminarItemsDelCarrito1.Location = new System.Drawing.Point(6, 71);
            this.btnEliminarItemsDelCarrito1.Name = "btnEliminarItemsDelCarrito1";
            this.btnEliminarItemsDelCarrito1.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarItemsDelCarrito1.TabIndex = 6;
            this.btnEliminarItemsDelCarrito1.Text = "&Eliminar";
            this.btnEliminarItemsDelCarrito1.UseVisualStyleBackColor = true;
            this.btnEliminarItemsDelCarrito1.Click += new System.EventHandler(this.btnEliminarItemsDelCarrito1_Click);
            // 
            // btnVenderItemsDelCarrito1
            // 
            this.btnVenderItemsDelCarrito1.Location = new System.Drawing.Point(6, 100);
            this.btnVenderItemsDelCarrito1.Name = "btnVenderItemsDelCarrito1";
            this.btnVenderItemsDelCarrito1.Size = new System.Drawing.Size(75, 23);
            this.btnVenderItemsDelCarrito1.TabIndex = 7;
            this.btnVenderItemsDelCarrito1.Text = "&Vender";
            this.btnVenderItemsDelCarrito1.UseVisualStyleBackColor = true;
            this.btnVenderItemsDelCarrito1.Click += new System.EventHandler(this.btnVenderItemsDelCarrito1_Click);
            // 
            // btnAgregarACarrito2
            // 
            this.btnAgregarACarrito2.Location = new System.Drawing.Point(6, 19);
            this.btnAgregarACarrito2.Name = "btnAgregarACarrito2";
            this.btnAgregarACarrito2.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarACarrito2.TabIndex = 8;
            this.btnAgregarACarrito2.Text = "&Agregar";
            this.btnAgregarACarrito2.UseVisualStyleBackColor = true;
            this.btnAgregarACarrito2.Click += new System.EventHandler(this.btnAgregarACarrito2_Click);
            // 
            // btnEliminarItemsDelCarrito2
            // 
            this.btnEliminarItemsDelCarrito2.Location = new System.Drawing.Point(6, 71);
            this.btnEliminarItemsDelCarrito2.Name = "btnEliminarItemsDelCarrito2";
            this.btnEliminarItemsDelCarrito2.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarItemsDelCarrito2.TabIndex = 9;
            this.btnEliminarItemsDelCarrito2.Text = "&Eliminar";
            this.btnEliminarItemsDelCarrito2.UseVisualStyleBackColor = true;
            this.btnEliminarItemsDelCarrito2.Click += new System.EventHandler(this.btnEliminarItemsDelCarrito2_Click);
            // 
            // btnVenderItemsDelCarrito2
            // 
            this.btnVenderItemsDelCarrito2.Location = new System.Drawing.Point(6, 100);
            this.btnVenderItemsDelCarrito2.Name = "btnVenderItemsDelCarrito2";
            this.btnVenderItemsDelCarrito2.Size = new System.Drawing.Size(75, 23);
            this.btnVenderItemsDelCarrito2.TabIndex = 10;
            this.btnVenderItemsDelCarrito2.Text = "&Vender";
            this.btnVenderItemsDelCarrito2.UseVisualStyleBackColor = true;
            this.btnVenderItemsDelCarrito2.Click += new System.EventHandler(this.btnVenderItemsDelCarrito2_Click);
            // 
            // btnAgregarACarrito3
            // 
            this.btnAgregarACarrito3.Location = new System.Drawing.Point(6, 19);
            this.btnAgregarACarrito3.Name = "btnAgregarACarrito3";
            this.btnAgregarACarrito3.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarACarrito3.TabIndex = 11;
            this.btnAgregarACarrito3.Text = "&Agregar";
            this.btnAgregarACarrito3.UseVisualStyleBackColor = true;
            this.btnAgregarACarrito3.Click += new System.EventHandler(this.btnAgregarACarrito3_Click);
            // 
            // btnEliminarItemsDelCarrito3
            // 
            this.btnEliminarItemsDelCarrito3.Location = new System.Drawing.Point(6, 71);
            this.btnEliminarItemsDelCarrito3.Name = "btnEliminarItemsDelCarrito3";
            this.btnEliminarItemsDelCarrito3.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarItemsDelCarrito3.TabIndex = 12;
            this.btnEliminarItemsDelCarrito3.Text = "&Eliminar";
            this.btnEliminarItemsDelCarrito3.UseVisualStyleBackColor = true;
            this.btnEliminarItemsDelCarrito3.Click += new System.EventHandler(this.btnEliminarItemsDelCarrito3_Click);
            // 
            // btnVenderItemsDelCarrito3
            // 
            this.btnVenderItemsDelCarrito3.Location = new System.Drawing.Point(6, 100);
            this.btnVenderItemsDelCarrito3.Name = "btnVenderItemsDelCarrito3";
            this.btnVenderItemsDelCarrito3.Size = new System.Drawing.Size(75, 23);
            this.btnVenderItemsDelCarrito3.TabIndex = 13;
            this.btnVenderItemsDelCarrito3.Text = "&Vender";
            this.btnVenderItemsDelCarrito3.UseVisualStyleBackColor = true;
            this.btnVenderItemsDelCarrito3.Click += new System.EventHandler(this.btnVenderItemsDelCarrito3_Click);
            // 
            // gbCarritoDeCompras1
            // 
            this.gbCarritoDeCompras1.Controls.Add(this.btnFinalizarCarrito1);
            this.gbCarritoDeCompras1.Controls.Add(this.cbxCantArticulos1);
            this.gbCarritoDeCompras1.Controls.Add(this.btnImprmirCarrito1);
            this.gbCarritoDeCompras1.Controls.Add(this.lstCarrito1);
            this.gbCarritoDeCompras1.Controls.Add(this.btnAgregarACarrito1);
            this.gbCarritoDeCompras1.Controls.Add(this.btnEliminarItemsDelCarrito1);
            this.gbCarritoDeCompras1.Controls.Add(this.btnVenderItemsDelCarrito1);
            this.gbCarritoDeCompras1.Enabled = false;
            this.gbCarritoDeCompras1.Location = new System.Drawing.Point(653, 36);
            this.gbCarritoDeCompras1.Name = "gbCarritoDeCompras1";
            this.gbCarritoDeCompras1.Size = new System.Drawing.Size(355, 195);
            this.gbCarritoDeCompras1.TabIndex = 14;
            this.gbCarritoDeCompras1.TabStop = false;
            this.gbCarritoDeCompras1.Text = "1º Carrito De Compras";
            // 
            // btnFinalizarCarrito1
            // 
            this.btnFinalizarCarrito1.Location = new System.Drawing.Point(6, 156);
            this.btnFinalizarCarrito1.Name = "btnFinalizarCarrito1";
            this.btnFinalizarCarrito1.Size = new System.Drawing.Size(75, 23);
            this.btnFinalizarCarrito1.TabIndex = 10;
            this.btnFinalizarCarrito1.Text = "&Finalizar";
            this.btnFinalizarCarrito1.UseVisualStyleBackColor = true;
            this.btnFinalizarCarrito1.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // cbxCantArticulos1
            // 
            this.cbxCantArticulos1.AutoSize = true;
            this.cbxCantArticulos1.Checked = true;
            this.cbxCantArticulos1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxCantArticulos1.Location = new System.Drawing.Point(6, 48);
            this.cbxCantArticulos1.Name = "cbxCantArticulos1";
            this.cbxCantArticulos1.Size = new System.Drawing.Size(70, 17);
            this.cbxCantArticulos1.TabIndex = 9;
            this.cbxCantArticulos1.Text = "1 Articulo";
            this.cbxCantArticulos1.UseVisualStyleBackColor = true;
            // 
            // btnImprmirCarrito1
            // 
            this.btnImprmirCarrito1.Location = new System.Drawing.Point(6, 129);
            this.btnImprmirCarrito1.Name = "btnImprmirCarrito1";
            this.btnImprmirCarrito1.Size = new System.Drawing.Size(75, 23);
            this.btnImprmirCarrito1.TabIndex = 8;
            this.btnImprmirCarrito1.Text = "&Imprimir";
            this.btnImprmirCarrito1.UseVisualStyleBackColor = true;
            this.btnImprmirCarrito1.Click += new System.EventHandler(this.btnImprmirCarrito1_Click);
            // 
            // gbCarritoDeCompras2
            // 
            this.gbCarritoDeCompras2.Controls.Add(this.btnFinalizarCarrito2);
            this.gbCarritoDeCompras2.Controls.Add(this.cbxCantArticulos2);
            this.gbCarritoDeCompras2.Controls.Add(this.btnImprimirCarrito2);
            this.gbCarritoDeCompras2.Controls.Add(this.lstCarrito2);
            this.gbCarritoDeCompras2.Controls.Add(this.btnAgregarACarrito2);
            this.gbCarritoDeCompras2.Controls.Add(this.btnEliminarItemsDelCarrito2);
            this.gbCarritoDeCompras2.Controls.Add(this.btnVenderItemsDelCarrito2);
            this.gbCarritoDeCompras2.Enabled = false;
            this.gbCarritoDeCompras2.Location = new System.Drawing.Point(653, 276);
            this.gbCarritoDeCompras2.Name = "gbCarritoDeCompras2";
            this.gbCarritoDeCompras2.Size = new System.Drawing.Size(355, 195);
            this.gbCarritoDeCompras2.TabIndex = 15;
            this.gbCarritoDeCompras2.TabStop = false;
            this.gbCarritoDeCompras2.Text = "2º Carrito De Compras";
            // 
            // btnFinalizarCarrito2
            // 
            this.btnFinalizarCarrito2.Location = new System.Drawing.Point(6, 156);
            this.btnFinalizarCarrito2.Name = "btnFinalizarCarrito2";
            this.btnFinalizarCarrito2.Size = new System.Drawing.Size(75, 23);
            this.btnFinalizarCarrito2.TabIndex = 12;
            this.btnFinalizarCarrito2.Text = "&Finalizar";
            this.btnFinalizarCarrito2.UseVisualStyleBackColor = true;
            this.btnFinalizarCarrito2.Click += new System.EventHandler(this.btnFinalizarCarrito2_Click);
            // 
            // cbxCantArticulos2
            // 
            this.cbxCantArticulos2.AutoSize = true;
            this.cbxCantArticulos2.Checked = true;
            this.cbxCantArticulos2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxCantArticulos2.Location = new System.Drawing.Point(6, 48);
            this.cbxCantArticulos2.Name = "cbxCantArticulos2";
            this.cbxCantArticulos2.Size = new System.Drawing.Size(70, 17);
            this.cbxCantArticulos2.TabIndex = 11;
            this.cbxCantArticulos2.Text = "1 Articulo";
            this.cbxCantArticulos2.UseVisualStyleBackColor = true;
            // 
            // btnImprimirCarrito2
            // 
            this.btnImprimirCarrito2.Location = new System.Drawing.Point(6, 129);
            this.btnImprimirCarrito2.Name = "btnImprimirCarrito2";
            this.btnImprimirCarrito2.Size = new System.Drawing.Size(75, 23);
            this.btnImprimirCarrito2.TabIndex = 8;
            this.btnImprimirCarrito2.Text = "&Imprimir";
            this.btnImprimirCarrito2.UseVisualStyleBackColor = true;
            this.btnImprimirCarrito2.Click += new System.EventHandler(this.btnImprimirCarrito2_Click);
            // 
            // gbCarritoDeCompras3
            // 
            this.gbCarritoDeCompras3.Controls.Add(this.btnFinalizarCarrito3);
            this.gbCarritoDeCompras3.Controls.Add(this.cbxCantArticulos3);
            this.gbCarritoDeCompras3.Controls.Add(this.btnImprimirCarrito3);
            this.gbCarritoDeCompras3.Controls.Add(this.lstCarrito3);
            this.gbCarritoDeCompras3.Controls.Add(this.btnAgregarACarrito3);
            this.gbCarritoDeCompras3.Controls.Add(this.btnEliminarItemsDelCarrito3);
            this.gbCarritoDeCompras3.Controls.Add(this.btnVenderItemsDelCarrito3);
            this.gbCarritoDeCompras3.Enabled = false;
            this.gbCarritoDeCompras3.Location = new System.Drawing.Point(653, 520);
            this.gbCarritoDeCompras3.Name = "gbCarritoDeCompras3";
            this.gbCarritoDeCompras3.Size = new System.Drawing.Size(355, 195);
            this.gbCarritoDeCompras3.TabIndex = 16;
            this.gbCarritoDeCompras3.TabStop = false;
            this.gbCarritoDeCompras3.Text = "3º Carrito De Compras";
            // 
            // btnFinalizarCarrito3
            // 
            this.btnFinalizarCarrito3.Location = new System.Drawing.Point(6, 156);
            this.btnFinalizarCarrito3.Name = "btnFinalizarCarrito3";
            this.btnFinalizarCarrito3.Size = new System.Drawing.Size(75, 23);
            this.btnFinalizarCarrito3.TabIndex = 15;
            this.btnFinalizarCarrito3.Text = "&Finalizar";
            this.btnFinalizarCarrito3.UseVisualStyleBackColor = true;
            this.btnFinalizarCarrito3.Click += new System.EventHandler(this.btnFinalizarCarrito3_Click);
            // 
            // cbxCantArticulos3
            // 
            this.cbxCantArticulos3.AutoSize = true;
            this.cbxCantArticulos3.Checked = true;
            this.cbxCantArticulos3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxCantArticulos3.Location = new System.Drawing.Point(6, 48);
            this.cbxCantArticulos3.Name = "cbxCantArticulos3";
            this.cbxCantArticulos3.Size = new System.Drawing.Size(70, 17);
            this.cbxCantArticulos3.TabIndex = 14;
            this.cbxCantArticulos3.Text = "1 Articulo";
            this.cbxCantArticulos3.UseVisualStyleBackColor = true;
            // 
            // btnImprimirCarrito3
            // 
            this.btnImprimirCarrito3.Location = new System.Drawing.Point(6, 129);
            this.btnImprimirCarrito3.Name = "btnImprimirCarrito3";
            this.btnImprimirCarrito3.Size = new System.Drawing.Size(75, 23);
            this.btnImprimirCarrito3.TabIndex = 9;
            this.btnImprimirCarrito3.Text = "&Imprimir";
            this.btnImprimirCarrito3.UseVisualStyleBackColor = true;
            this.btnImprimirCarrito3.Click += new System.EventHandler(this.btnImprimirCarrito3_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.Document = this.printDocument1;
            // 
            // printDocument1
            // 
            this.printDocument1.OriginAtMargins = true;
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_EndPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.UseAntiAlias = true;
            this.printPreviewDialog1.Visible = false;
            // 
            // tbxTexto
            // 
            this.tbxTexto.Enabled = false;
            this.tbxTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxTexto.Location = new System.Drawing.Point(12, 663);
            this.tbxTexto.Multiline = true;
            this.tbxTexto.Name = "tbxTexto";
            this.tbxTexto.Size = new System.Drawing.Size(148, 52);
            this.tbxTexto.TabIndex = 17;
            this.tbxTexto.Visible = false;
            // 
            // tbxRetiroPD
            // 
            this.tbxRetiroPD.Enabled = false;
            this.tbxRetiroPD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRetiroPD.Location = new System.Drawing.Point(499, 663);
            this.tbxRetiroPD.Multiline = true;
            this.tbxRetiroPD.Name = "tbxRetiroPD";
            this.tbxRetiroPD.Size = new System.Drawing.Size(148, 52);
            this.tbxRetiroPD.TabIndex = 18;
            this.tbxRetiroPD.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 727);
            this.Controls.Add(this.tbxRetiroPD);
            this.Controls.Add(this.tbxTexto);
            this.Controls.Add(this.gbCarritoDeCompras3);
            this.Controls.Add(this.gbCarritoDeCompras2);
            this.Controls.Add(this.gbCarritoDeCompras1);
            this.Controls.Add(this.ListaArticulos);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Sistema Libreria Cadaques";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbCarritoDeCompras1.ResumeLayout(false);
            this.gbCarritoDeCompras1.PerformLayout();
            this.gbCarritoDeCompras2.ResumeLayout(false);
            this.gbCarritoDeCompras2.PerformLayout();
            this.gbCarritoDeCompras3.ResumeLayout(false);
            this.gbCarritoDeCompras3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ListView ListaArticulos;
        private System.Windows.Forms.ListBox lstCarrito1;
        private System.Windows.Forms.ListBox lstCarrito2;
        private System.Windows.Forms.ListBox lstCarrito3;
        private System.Windows.Forms.Button btnAgregarACarrito1;
        private System.Windows.Forms.Button btnEliminarItemsDelCarrito1;
        private System.Windows.Forms.Button btnVenderItemsDelCarrito1;
        private System.Windows.Forms.Button btnAgregarACarrito2;
        private System.Windows.Forms.Button btnEliminarItemsDelCarrito2;
        private System.Windows.Forms.Button btnVenderItemsDelCarrito2;
        private System.Windows.Forms.Button btnAgregarACarrito3;
        private System.Windows.Forms.Button btnEliminarItemsDelCarrito3;
        private System.Windows.Forms.Button btnVenderItemsDelCarrito3;
        private System.Windows.Forms.GroupBox gbCarritoDeCompras1;
        private System.Windows.Forms.GroupBox gbCarritoDeCompras2;
        private System.Windows.Forms.GroupBox gbCarritoDeCompras3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tbxBuscarToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button btnImprmirCarrito1;
        private System.Windows.Forms.Button btnImprimirCarrito2;
        private System.Windows.Forms.Button btnImprimirCarrito3;
        private System.Windows.Forms.TextBox tbxTexto;
        private System.Windows.Forms.ToolStripMenuItem abrirCajaToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbxCantArticulos1;
        private System.Windows.Forms.CheckBox cbxCantArticulos2;
        private System.Windows.Forms.CheckBox cbxCantArticulos3;
        private System.Windows.Forms.Button btnFinalizarCarrito1;
        private System.Windows.Forms.Button btnFinalizarCarrito2;
        private System.Windows.Forms.Button btnFinalizarCarrito3;
        private System.Windows.Forms.ToolStripMenuItem articulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porNombreToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem retirarPDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarCajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TextBox tbxRetiroPD;
    }
}

