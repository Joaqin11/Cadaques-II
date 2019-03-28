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
    public partial class Form1 : Form
    {
        CargaDeDatos carga;
        Cajero unCajero;
        Venta unaVenta;
        Carrito unCarrito1, unCarrito2, unCarrito3;
        Caja unaCaja;
        Articulo unArticulo;

        AutoCompleteStringCollection autoComplteCodigo;
        AutoCompleteStringCollection autoCompleteNombre;

        string desArticulo;
        int codSeleccionado;
        bool carrito1 = false, carrito2 = false, carrito3 = false, imprimirPD = false, vendido1 = false, vendido2 = false, vendido3 = false;

        string textoActual;    // línea que se está imprimiendo
        string textoRemanente; // Excedente de la línea actual
        Brush relleno;         // Relleno con el que se pintarán las letras
        Pen borde;             // Borde con el que se dibujará el marco de página
        int lineaActual;       // Número de línea del textBox que se está imprimiendo.

        ListViewItem item;

        public Form1()
        {
            InitializeComponent();

            carga = new CargaDeDatos();

            autoComplteCodigo = new AutoCompleteStringCollection();
            autoCompleteNombre = new AutoCompleteStringCollection();

            desArticulo = "";
            codSeleccionado = -1;

            unCarrito1 = new Carrito();
            unCarrito2 = new Carrito();
            unCarrito3 = new Carrito();
            
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Cargar Excel Delimitado por comas";
            openFileDialog1.Filter = "Excel(*.csv) | *.CSV | Hoja de calculo(*.xls) | *.XLS | Culaquier Formato(*.*) | *.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ListaArticulos.Clear();
                if (carga != null)
                {
                    carga.AbrirCSV(openFileDialog1.FileName);
                    carga.ObtenerNombresColumnas();
                    carga.Mostrar(ListaArticulos);
                    MessageBox.Show("La lista de precios fue cargada exitosamente!");
                }
            }
            cerrarCajaToolStripMenuItem.Enabled = true;
            
            buscarToolStripMenuItem.Enabled = true;
            tbxBuscarToolStripMenu.Enabled = true;

            gbCarritoDeCompras1.Enabled = true;
            btnEliminarItemsDelCarrito1.Enabled = false;
            btnVenderItemsDelCarrito1.Enabled = false;
            btnImprmirCarrito1.Enabled = false;
            btnFinalizarCarrito1.Enabled = false;

            gbCarritoDeCompras2.Enabled = true;
            btnEliminarItemsDelCarrito2.Enabled = false;
            btnVenderItemsDelCarrito2.Enabled = false;
            btnImprimirCarrito2.Enabled = false;
            btnFinalizarCarrito2.Enabled = false;

            gbCarritoDeCompras3.Enabled = true;
            btnEliminarItemsDelCarrito3.Enabled = false;
            btnVenderItemsDelCarrito3.Enabled = false;
            btnImprimirCarrito3.Enabled = false;
            btnFinalizarCarrito3.Enabled = false;
        }

        private void ListaArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAgregarACarrito1_Click(object sender, EventArgs e)
        {
            if (codSeleccionado != -1 && desArticulo != "")
            {
                if (unArticulo != null)
                {
                    if (cbxCantArticulos1.Checked)
                    {
                        unCarrito1.Cantidad = 1;
                        unCarrito1.Agregar(unArticulo);
                        lstCarrito1.Items.Add(unArticulo);
                        //Botones Activados
                        btnEliminarItemsDelCarrito1.Enabled = true;
                        btnVenderItemsDelCarrito1.Enabled = true;
                    }
                    else
                    {
                        CantidadDeArticulos vc = new CantidadDeArticulos();
                        if(vc.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                unArticulo.CantidadPedida = Convert.ToInt32(vc.tbxCantidad.Text);
                                unCarrito1.Cantidad = Convert.ToInt32(vc.tbxCantidad.Text);
                                unCarrito1.Agregar(unArticulo);
                                lstCarrito1.Items.Add(unArticulo);
                                //Botones Activados
                                btnEliminarItemsDelCarrito1.Enabled = true;
                                btnVenderItemsDelCarrito1.Enabled = true;
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        vc.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("Error\r\n" + unCarrito1.MensajeErrorCargaArticulo());
                }
            }
        }

        private void tbxBuscarToolStripMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbxBuscarToolStripMenu.Text != "")
                {
                    SeleccionarCarrito vc = new SeleccionarCarrito();
                    foreach (Articulo art in carga.getListaArticulos())
                    {
                        if (tbxBuscarToolStripMenu.Text == art.BuscarCodigo(tbxBuscarToolStripMenu.Text))
                        {
                            vc.labArticulo.Text = art.Descripcion + "\r\n" + art.PrecioConUtilidad.ToString();
                            //unArticulo = art;
                            //desArticulo = art.ToString();
                            break;
                        }
                    }
                    if (vc.ShowDialog() == DialogResult.OK)
                    {
                        if (vc.cbCantidad.Checked)
                        {
                            if (vc.cmbCarritos.SelectedIndex == 0)
                            {
                                foreach (Articulo art in carga.getListaArticulos())
                                {
                                    if (tbxBuscarToolStripMenu.Text == art.BuscarCodigo(tbxBuscarToolStripMenu.Text))
                                    {
                                        if (!vendido1)
                                        {
                                            unCarrito1.Cantidad = 1;
                                            unCarrito1.Agregar(art);
                                            lstCarrito1.Items.Add(art);
                                            //Botones Activados
                                            btnEliminarItemsDelCarrito1.Enabled = true;
                                            btnVenderItemsDelCarrito1.Enabled = true;
                                            //unArticulo = art;
                                            //desArticulo = art.ToString();
                                            break;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Carrito vendido! No se puede agregar o eliminar articulos! Finalice la venta.");
                                        }
                                    }
                                }
                            }
                            else if (vc.cmbCarritos.SelectedIndex == 1)
                            {
                                foreach (Articulo art in carga.getListaArticulos())
                                {
                                    if (tbxBuscarToolStripMenu.Text == art.BuscarCodigo(tbxBuscarToolStripMenu.Text))
                                    {
                                        if (!vendido2)
                                        {
                                            unCarrito2.Cantidad = 1;
                                            unCarrito2.Agregar(art);
                                            lstCarrito2.Items.Add(art);
                                            //Botones Activados
                                            btnEliminarItemsDelCarrito2.Enabled = true;
                                            btnVenderItemsDelCarrito2.Enabled = true;
                                            //unArticulo = art;
                                            //desArticulo = art.ToString();
                                            break;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Carrito vendido! No se puede agregar o eliminar articulos! Finalice la venta.");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                foreach (Articulo art in carga.getListaArticulos())
                                {
                                    if (tbxBuscarToolStripMenu.Text == art.BuscarCodigo(tbxBuscarToolStripMenu.Text))
                                    {
                                        if (!vendido3)
                                        {
                                            unCarrito3.Cantidad = 1;
                                            unCarrito3.Agregar(art);
                                            lstCarrito3.Items.Add(art);
                                            //Botones Activados
                                            btnEliminarItemsDelCarrito3.Enabled = true;
                                            btnVenderItemsDelCarrito3.Enabled = true;
                                            //unArticulo = art;
                                            //desArticulo = art.ToString();
                                            break;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Carrito vendido! No se puede agregar o eliminar articulos! Finalice la venta.");
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            CantidadDeArticulos vc1 = new CantidadDeArticulos();

                            if (vc1.ShowDialog() == DialogResult.OK)
                            {
                                if (vc1.tbxCantidad.Text != "")
                                {
                                    if (vc.cmbCarritos.SelectedIndex == 0)
                                    {
                                        foreach (Articulo art in carga.getListaArticulos())
                                        {
                                            if (tbxBuscarToolStripMenu.Text == art.BuscarCodigo(tbxBuscarToolStripMenu.Text))
                                            {
                                                try
                                                {
                                                    if (!vendido1)
                                                    {
                                                        art.CantidadPedida = Convert.ToInt32(vc1.tbxCantidad.Text);
                                                        unCarrito1.Cantidad = Convert.ToInt32(vc1.tbxCantidad.Text);
                                                        unCarrito1.Agregar(art);
                                                        lstCarrito1.Items.Add(art);
                                                        //Botones Activados
                                                        btnEliminarItemsDelCarrito1.Enabled = true;
                                                        btnVenderItemsDelCarrito1.Enabled = true;
                                                        //unArticulo = art;
                                                        //desArticulo = art.ToString();
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Carrito vendido! No se puede agregar o eliminar articulos! Finalice la venta.");
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    MessageBox.Show(ex.Message + "\r\nNo se pudo cargar articulo.");
                                                }
                                            }
                                        }
                                    }
                                    else if (vc.cmbCarritos.SelectedIndex == 1)
                                    {
                                        foreach (Articulo art in carga.getListaArticulos())
                                        {
                                            if (tbxBuscarToolStripMenu.Text == art.BuscarCodigo(tbxBuscarToolStripMenu.Text))
                                            {
                                                try
                                                {
                                                    if (!vendido2)
                                                    {
                                                        art.CantidadPedida = Convert.ToInt32(vc1.tbxCantidad.Text);
                                                        unCarrito2.Cantidad = Convert.ToInt32(vc1.tbxCantidad.Text);
                                                        unCarrito2.Agregar(art);
                                                        lstCarrito2.Items.Add(art);
                                                        //Botones Activados
                                                        btnEliminarItemsDelCarrito2.Enabled = true;
                                                        btnVenderItemsDelCarrito2.Enabled = true;
                                                        //unArticulo = art;
                                                        //desArticulo = art.ToString();
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Carrito vendido! No se puede agregar o eliminar articulos! Finalice la venta.");
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    MessageBox.Show(ex.Message + "\r\nNo se pudo cargar articulo.");
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        foreach (Articulo art in carga.getListaArticulos())
                                        {
                                            if (tbxBuscarToolStripMenu.Text == art.BuscarCodigo(tbxBuscarToolStripMenu.Text))
                                            {
                                                try
                                                {
                                                    if (!vendido3)
                                                    {
                                                        art.CantidadPedida = Convert.ToInt32(vc1.tbxCantidad.Text);
                                                        unCarrito3.Cantidad = Convert.ToInt32(vc1.tbxCantidad.Text);
                                                        unCarrito3.Agregar(art);
                                                        lstCarrito3.Items.Add(art);
                                                        //Botones Activados
                                                        btnEliminarItemsDelCarrito3.Enabled = true;
                                                        btnVenderItemsDelCarrito3.Enabled = true;
                                                        //unArticulo = art;
                                                        //desArticulo = art.ToString();
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Carrito vendido! No se puede agregar o eliminar articulos! Finalice la venta.");
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    MessageBox.Show(ex.Message + "\r\nNo se pudo cargar articulo.");
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo cargar articulo.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Se cancelo la carga del articulo.");
                            }
                            vc1.Dispose();
                        }
                    }
                    vc.Dispose();
                    tbxBuscarToolStripMenu.Clear();
                }
                else
                {
                    MessageBox.Show("No se encontro articulo.");
                    tbxBuscarToolStripMenu.Clear();
                }

            }
        }

        private void ListaArticulos_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //Evento ItemSelectionChanged del Listview
            if (e.IsSelected)
            {
                codSeleccionado = Convert.ToInt32(e.Item.Text);

                foreach (Articulo art in carga.getListaArticulos())
                {
                    if (codSeleccionado == art.Codigo)
                    {
                        unArticulo = art;
                        desArticulo = art.ToString();
                        break;
                    }
                }
            }
            else
            {
                codSeleccionado = -1;
                desArticulo = "";
            }
        }

        private void btnImprmirCarrito1_Click(object sender, EventArgs e)
        {
            if (lstCarrito1.Items.Count > 0 && unCarrito1.CountCarrito > 0 && vendido1)
            {
                carrito1 = true;
                carrito2 = false;
                carrito3 = false;
                pageSetupDialog1.ShowDialog();
                printPreviewDialog1.ShowDialog();
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
                tbxTexto.Clear();
                string[] vector = new string[2];
                vector[0] = "Detalle de su Compra";
                vector[1] = "No valido como factura";
                for (int i = 0; i < vector.Length; i++)
                {
                    if (i == 0)
                    {
                        tbxTexto.Text += "\r" + vector[i];
                    }
                    else
                    {
                        tbxTexto.Text += "\r\n" + vector[i];
                        tbxTexto.Text += "\r\nRazon social: " + unCajero.RazonSocial;
                        tbxTexto.Text += "\r\nSucursal: " + unCajero.Sucursal.ToString();
                        tbxTexto.Text += "\r\nDirección: " + unCajero.Direccion;
                        tbxTexto.Text += "\r\nTelefono: " + unCajero.Telefono;
                        tbxTexto.Text += "\r\nCaja Nº: " + unCajero.NumeroDeCaja.ToString();
                        tbxTexto.Text += "\r\nCajero: " + unCajero.Nombre + " " + unCajero.Apellido;
                    }
                }
                carrito1 = false;
            }
            else
            {
                MessageBox.Show("El carrito esta vacio. No se puede realizar una impresion de un carrito sin articulos y sobre todo sin vender.\r\nCargue al menos un articulo, realice su venta apretando en vender y vuelva a intentar.");
            }
            vendido1 = false;
        }

        private void btnEliminarItemsDelCarrito1_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstCarrito1.SelectedIndex != -1)
                {
                    unCarrito1.Eliminar(lstCarrito1.SelectedIndex);
                    lstCarrito1.Items.Remove(lstCarrito1.SelectedItem);
                }
                else
                {
                    MessageBox.Show("No selecciono ningun articulo del Carrito 1. \r\nPor favor seleccione el articulo a eliminar.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\nNo selecciono ningun articulo del Carrito 1. \r\nPor favor seleccione al menos un articulo.");
            }
        }

        private void btnVenderItemsDelCarrito1_Click(object sender, EventArgs e)
        {
            CobrarCarrito vc = new CobrarCarrito();
            if (lstCarrito1.Items.Count > 0 && unCarrito1.CountCarrito > 0)
            {
                vc.labTotal.Text = unCarrito1.Total().ToString();
            }
            if(lstCarrito1.Items.Count > 0 && unCarrito1.CountCarrito > 0)
            {
                if(vc.ShowDialog() == DialogResult.OK)
                {
                    if(vc.cmbTipoDePago.SelectedIndex == 0)
                    {
                        try
                        {
                            unaVenta = new Venta(unCarrito1, Venta.TipoDePago.EFECTIVO);
                            if (unaVenta.Total <= Convert.ToDouble(vc.tbxDineroRecibido.Text))
                            {
                                unaCaja.RegistrarVentaEnEfectivo(unaVenta, Convert.ToDouble(vc.tbxDineroRecibido.Text));
                                MessageBox.Show("Se registro con exito la venta.\r\nEl vuelto del Cliente es de " + unaVenta.SuVuelto);
                                tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                                tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                                lstCarrito1.Items.Add("Total a pagar: " + vc.labTotal.Text);
                                lstCarrito1.Items.Add("Gracias por elegirnos, vuelva pronto!");
                                retirarPDToolStripMenuItem.Enabled = true;
                                vendido1 = true;
                                //Botones Activados
                                btnImprmirCarrito1.Enabled = true;
                                btnFinalizarCarrito1.Enabled = true;
                                //Botones Desactivados
                                btnAgregarACarrito1.Enabled = false;
                                cbxCantArticulos1.Enabled = false;
                                btnEliminarItemsDelCarrito1.Enabled = false;
                                btnVenderItemsDelCarrito1.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("El dinero ingrsado tiene que ser mayor o igual al monto a pagar.");
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if(vc.cmbTipoDePago.SelectedIndex == 1)
                    {
                        if (vc.cmbTipoTarjeta.SelectedIndex == 0)
                        {
                            unaVenta = new Venta(unCarrito1, Venta.TipoDePago.DEBITO);
                            unaCaja.RegistrarVentaEnTarjetaMaestro(unaVenta);
                            MessageBox.Show("Se registro con exito la venta.");
                            tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                            tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                            lstCarrito1.Items.Add("Total a pagar: " + vc.labTotal.Text);
                            lstCarrito1.Items.Add("Gracias por elegirnos, vuelva pronto!");
                            retirarPDToolStripMenuItem.Enabled = true;
                            vendido1 = true;
                            //Botones Activados
                            btnImprmirCarrito1.Enabled = true;
                            btnFinalizarCarrito1.Enabled = true;
                            //Botones Desactivados
                            btnAgregarACarrito1.Enabled = false;
                            cbxCantArticulos1.Enabled = false;
                            btnEliminarItemsDelCarrito1.Enabled = false;
                            btnVenderItemsDelCarrito1.Enabled = false;
                        }
                        else if (vc.cmbTipoTarjeta.SelectedIndex == 1)
                        {
                            try
                            {
                                unaVenta = new Venta(unCarrito1, Venta.TipoDePago.CREDITO);
                                unaCaja.RegistrarVentaEnTarjetaVisa(unaVenta, Convert.ToDouble(vc.tbxRecargo.Text));
                                MessageBox.Show("Se registro con exito la venta.");
                                tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                                tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                                lstCarrito1.Items.Add("Total a pagar: " + vc.labTotal.Text);
                                lstCarrito1.Items.Add("Gracias por elegirnos, vuelva pronto!");
                                retirarPDToolStripMenuItem.Enabled = true;
                                vendido1 = true;
                                //Botones Activados
                                btnImprmirCarrito1.Enabled = true;
                                btnFinalizarCarrito1.Enabled = true;
                                //Botones Desactivados
                                btnAgregarACarrito1.Enabled = false;
                                cbxCantArticulos1.Enabled = false;
                                btnEliminarItemsDelCarrito1.Enabled = false;
                                btnVenderItemsDelCarrito1.Enabled = false;
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else if (vc.cmbTipoTarjeta.SelectedIndex == 2)
                        {
                            try
                            {
                                unaVenta = new Venta(unCarrito1, Venta.TipoDePago.CREDITO);
                                unaCaja.RegistrarVentaEnTarjetaMasterCard(unaVenta, Convert.ToDouble(vc.tbxRecargo.Text));
                                MessageBox.Show("Se registro con exito la venta.");
                                tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                                tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                                lstCarrito1.Items.Add("Total a pagar: " + vc.labTotal.Text);
                                lstCarrito1.Items.Add("Gracias por elegirnos, vuelva pronto!");
                                retirarPDToolStripMenuItem.Enabled = true;
                                vendido1 = true;
                                //Botones Activados
                                btnImprmirCarrito1.Enabled = true;
                                btnFinalizarCarrito1.Enabled = true;
                                //Botones Desactivados
                                btnAgregarACarrito1.Enabled = false;
                                cbxCantArticulos1.Enabled = false;
                                btnEliminarItemsDelCarrito1.Enabled = false;
                                btnVenderItemsDelCarrito1.Enabled = false;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else if (vc.cmbTipoTarjeta.SelectedIndex == 3)
                        {
                            try
                            {
                                unaVenta = new Venta(unCarrito1, Venta.TipoDePago.CREDITO);
                                unaCaja.RegistrarVentaEnTarjetaCabal(unaVenta, Convert.ToDouble(vc.tbxRecargo.Text));
                                MessageBox.Show("Se registro con exito la venta.");
                                tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                                tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                                lstCarrito1.Items.Add("Total a pagar: " + vc.labTotal.Text);
                                lstCarrito1.Items.Add("Gracias por elegirnos, vuelva pronto!");
                                retirarPDToolStripMenuItem.Enabled = true;
                                vendido1 = true;
                                //Botones Activados
                                btnImprmirCarrito1.Enabled = true;
                                btnFinalizarCarrito1.Enabled = true;
                                //Botones Desactivados
                                btnAgregarACarrito1.Enabled = false;
                                cbxCantArticulos1.Enabled = false;
                                btnEliminarItemsDelCarrito1.Enabled = false;
                                btnVenderItemsDelCarrito1.Enabled = false;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else if (vc.cmbTipoTarjeta.SelectedIndex == 4)
                        {
                            unaVenta = new Venta(unCarrito1, Venta.TipoDePago.CREDITO);
                            unaCaja.RegistrarVentaEnTarjetaNaranja(unaVenta);
                            MessageBox.Show("Se registro con exito la venta.");
                            tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                            tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                            lstCarrito1.Items.Add("Total a pagar: " + vc.labTotal.Text);
                            lstCarrito1.Items.Add("Gracias por elegirnos, vuelva pronto!");
                            retirarPDToolStripMenuItem.Enabled = true;
                            vendido1 = true;
                            //Botones Activados
                            btnImprmirCarrito1.Enabled = true;
                            btnFinalizarCarrito1.Enabled = true;
                            //Botones Desactivados
                            btnAgregarACarrito1.Enabled = false;
                            cbxCantArticulos1.Enabled = false;
                            btnEliminarItemsDelCarrito1.Enabled = false;
                            btnVenderItemsDelCarrito1.Enabled = false;
                        }
                        else if (vc.cmbTipoTarjeta.SelectedIndex == 5)
                        {
                            unaVenta = new Venta(unCarrito1, Venta.TipoDePago.CREDITO);
                            unaCaja.RegistrarVentaEnTarjetaSideCreer(unaVenta);
                            MessageBox.Show("Se registro con exito la venta.");
                            tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                            tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                            lstCarrito1.Items.Add("Total a pagar: " + vc.labTotal.Text);
                            lstCarrito1.Items.Add("Gracias por elegirnos, vuelva pronto!");
                            retirarPDToolStripMenuItem.Enabled = true;
                            vendido1 = true;
                            //Botones Activados
                            btnImprmirCarrito1.Enabled = true;
                            btnFinalizarCarrito1.Enabled = true;
                            //Botones Desactivados
                            btnAgregarACarrito1.Enabled = false;
                            cbxCantArticulos1.Enabled = false;
                            btnEliminarItemsDelCarrito1.Enabled = false;
                            btnVenderItemsDelCarrito1.Enabled = false;
                        }
                        else
                        {
                            unaVenta = new Venta(unCarrito1, Venta.TipoDePago.CREDITO);
                            unaCaja.RegistrarVentaEnTarjetaConsuMax(unaVenta);
                            MessageBox.Show("Se registro con exito la venta.");
                            tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                            tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                            lstCarrito1.Items.Add("Total a pagar: " + vc.labTotal.Text);
                            lstCarrito1.Items.Add("Gracias por elegirnos, vuelva pronto!");
                            retirarPDToolStripMenuItem.Enabled = true;
                            vendido1 = true;
                            //Botones Activados
                            btnImprmirCarrito1.Enabled = true;
                            btnFinalizarCarrito1.Enabled = true;
                            //Botones Desactivados
                            btnAgregarACarrito1.Enabled = false;
                            cbxCantArticulos1.Enabled = false;
                            btnEliminarItemsDelCarrito1.Enabled = false;
                            btnVenderItemsDelCarrito1.Enabled = false;
                        }
                    }
                    else
                    {
                        try
                        {
                            unaVenta = new Venta(unCarrito1, Venta.TipoDePago.CHEQUE);
                            vc.tbxDineroRecibido.Text = unaVenta.Total.ToString();
                            if (unaVenta.Total <= Convert.ToDouble(vc.tbxDineroRecibido.Text))
                            {
                                unaCaja.RegistrarVentaEnCheques(unaVenta);
                                MessageBox.Show("Se registro con exito la venta.\r\nEl vuelto del Cliente es de " + unaVenta.SuVuelto);
                                tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                                tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                                lstCarrito1.Items.Add("Total a pagar: " + vc.labTotal.Text);
                                lstCarrito1.Items.Add("Gracias por elegirnos, vuelva pronto!");
                                retirarPDToolStripMenuItem.Enabled = true;
                                vendido1 = true;
                                //Botones Activados
                                btnImprmirCarrito1.Enabled = true;
                                btnFinalizarCarrito1.Enabled = true;
                                //Botones Desactivados
                                btnAgregarACarrito1.Enabled = false;
                                cbxCantArticulos1.Enabled = false;
                                btnEliminarItemsDelCarrito1.Enabled = false;
                                btnVenderItemsDelCarrito1.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("El dinero ingrsado tiene que ser igual al monto a pagar.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("El carrito esta vacio. No se puede realizar una venta sin articulos.\r\nCargue al menos un articulo y vuelva a intentar.");
            }
            vc.Dispose();
        }

        private void btnAgregarACarrito2_Click(object sender, EventArgs e)
        {
            if (codSeleccionado != -1 && desArticulo != "")
            {
                if (unArticulo != null)
                {
                    if (cbxCantArticulos2.Checked)
                    {
                        unCarrito2.Cantidad = 1;
                        unCarrito2.Agregar(unArticulo);
                        lstCarrito2.Items.Add(unArticulo);
                        //Botones Activados
                        btnEliminarItemsDelCarrito2.Enabled = true;
                        btnVenderItemsDelCarrito2.Enabled = true;
                    }
                    else
                    {
                        CantidadDeArticulos vc = new CantidadDeArticulos();
                        if (vc.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                unArticulo.CantidadPedida = Convert.ToInt32(vc.tbxCantidad.Text);
                                unCarrito2.Cantidad = Convert.ToInt32(vc.tbxCantidad.Text);
                                unCarrito2.Agregar(unArticulo);
                                lstCarrito2.Items.Add(unArticulo);
                                //Botones Activados
                                btnEliminarItemsDelCarrito2.Enabled = true;
                                btnVenderItemsDelCarrito2.Enabled = true;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        vc.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("Error\r\n" + unCarrito2.MensajeErrorCargaArticulo());
                }
            }
        }

        private void btnEliminarItemsDelCarrito2_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstCarrito2.SelectedIndex != -1)
                {
                    unCarrito2.Eliminar(lstCarrito2.SelectedIndex);
                    lstCarrito2.Items.Remove(lstCarrito2.SelectedItem);
                }
                else
                {
                    MessageBox.Show("No selecciono ningun articulo del Carrito 2. \r\nPor favor seleccione el articulo a eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\nNo selecciono ningun articulo del Carrito 2. \r\nPor favor seleccione al menos un articulo.");
            }
        }

        private void btnVenderItemsDelCarrito2_Click(object sender, EventArgs e)
        {
            CobrarCarrito vc = new CobrarCarrito();
            if (lstCarrito2.Items.Count > 0 && unCarrito2.CountCarrito > 0)
            {
                vc.labTotal.Text = unCarrito2.Total().ToString();
            }
            if (lstCarrito2.Items.Count > 0 && unCarrito2.CountCarrito > 0)
            {
                if (vc.ShowDialog() == DialogResult.OK)
                {
                    if (vc.cmbTipoDePago.SelectedIndex == 0)
                    {
                        try
                        {
                            unaVenta = new Venta(unCarrito2, Venta.TipoDePago.EFECTIVO);
                            if (unaVenta.Total <= Convert.ToDouble(vc.tbxDineroRecibido.Text))
                            {
                                unaCaja.RegistrarVentaEnEfectivo(unaVenta, Convert.ToDouble(vc.tbxDineroRecibido.Text));
                                MessageBox.Show("Se registro con exito la venta.\r\nEl vuelto del Cliente es de " + unaVenta.SuVuelto);
                                tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                                tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                                lstCarrito2.Items.Add("Total a pagar: " + vc.labTotal.Text);
                                lstCarrito2.Items.Add("Gracias por elegirnos, vuelva pronto!");
                                retirarPDToolStripMenuItem.Enabled = true;
                                vendido2 = true;
                                //Botones Activados
                                btnImprimirCarrito2.Enabled = true;
                                btnFinalizarCarrito2.Enabled = true;
                                //Botones Desactivados
                                btnAgregarACarrito2.Enabled = false;
                                cbxCantArticulos2.Enabled = false;
                                btnEliminarItemsDelCarrito2.Enabled = false;
                                btnVenderItemsDelCarrito2.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("El dinero ingrsado tiene que ser mayor o igual al monto a pagar.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (vc.cmbTipoDePago.SelectedIndex == 1)
                    {
                        if (vc.cmbTipoTarjeta.SelectedIndex == 0)
                        {
                            unaVenta = new Venta(unCarrito2, Venta.TipoDePago.DEBITO);
                            unaCaja.RegistrarVentaEnTarjetaMaestro(unaVenta);
                            MessageBox.Show("Se registro con exito la venta.");
                            tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                            tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                            lstCarrito2.Items.Add("Total a pagar: " + vc.labTotal.Text);
                            lstCarrito2.Items.Add("Gracias por elegirnos, vuelva pronto!");
                            retirarPDToolStripMenuItem.Enabled = true;
                            vendido2 = true;
                            //Botones Activados
                            btnImprimirCarrito2.Enabled = true;
                            btnFinalizarCarrito2.Enabled = true;
                            //Botones Desactivados
                            btnAgregarACarrito2.Enabled = false;
                            cbxCantArticulos2.Enabled = false;
                            btnEliminarItemsDelCarrito2.Enabled = false;
                            btnVenderItemsDelCarrito2.Enabled = false;
                        }
                        else if (vc.cmbTipoTarjeta.SelectedIndex == 1)
                        {
                            try
                            {
                                unaVenta = new Venta(unCarrito2, Venta.TipoDePago.CREDITO);
                                unaCaja.RegistrarVentaEnTarjetaVisa(unaVenta, Convert.ToDouble(vc.tbxRecargo.Text));
                                MessageBox.Show("Se registro con exito la venta.");
                                tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                                tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                                lstCarrito2.Items.Add("Total a pagar: " + vc.labTotal.Text);
                                lstCarrito2.Items.Add("Gracias por elegirnos, vuelva pronto!");
                                retirarPDToolStripMenuItem.Enabled = true;
                                vendido2 = true;
                                //Botones Activados
                                btnImprimirCarrito2.Enabled = true;
                                btnFinalizarCarrito2.Enabled = true;
                                //Botones Desactivados
                                btnAgregarACarrito2.Enabled = false;
                                cbxCantArticulos2.Enabled = false;
                                btnEliminarItemsDelCarrito2.Enabled = false;
                                btnVenderItemsDelCarrito2.Enabled = false;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else if (vc.cmbTipoTarjeta.SelectedIndex == 2)
                        {
                            try
                            {
                                unaVenta = new Venta(unCarrito2, Venta.TipoDePago.CREDITO);
                                unaCaja.RegistrarVentaEnTarjetaMasterCard(unaVenta, Convert.ToDouble(vc.tbxRecargo.Text));
                                MessageBox.Show("Se registro con exito la venta.");
                                tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                                tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                                lstCarrito2.Items.Add("Total a pagar: " + vc.labTotal.Text);
                                lstCarrito2.Items.Add("Gracias por elegirnos, vuelva pronto!");
                                retirarPDToolStripMenuItem.Enabled = true;
                                vendido2 = true;
                                //Botones Activados
                                btnImprimirCarrito2.Enabled = true;
                                btnFinalizarCarrito2.Enabled = true;
                                //Botones Desactivados
                                btnAgregarACarrito2.Enabled = false;
                                cbxCantArticulos2.Enabled = false;
                                btnEliminarItemsDelCarrito2.Enabled = false;
                                btnVenderItemsDelCarrito2.Enabled = false;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else if (vc.cmbTipoTarjeta.SelectedIndex == 3)
                        {
                            try
                            {
                                unaVenta = new Venta(unCarrito2, Venta.TipoDePago.CREDITO);
                                unaCaja.RegistrarVentaEnTarjetaCabal(unaVenta, Convert.ToDouble(vc.tbxRecargo.Text));
                                MessageBox.Show("Se registro con exito la venta.");
                                tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                                tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                                lstCarrito2.Items.Add("Total a pagar: " + vc.labTotal.Text);
                                lstCarrito2.Items.Add("Gracias por elegirnos, vuelva pronto!");
                                retirarPDToolStripMenuItem.Enabled = true;
                                vendido2 = true;
                                //Botones Activados
                                btnImprimirCarrito2.Enabled = true;
                                btnFinalizarCarrito2.Enabled = true;
                                //Botones Desactivados
                                btnAgregarACarrito2.Enabled = false;
                                cbxCantArticulos2.Enabled = false;
                                btnEliminarItemsDelCarrito2.Enabled = false;
                                btnVenderItemsDelCarrito2.Enabled = false;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else if (vc.cmbTipoTarjeta.SelectedIndex == 4)
                        {
                            unaVenta = new Venta(unCarrito2, Venta.TipoDePago.CREDITO);
                            unaCaja.RegistrarVentaEnTarjetaNaranja(unaVenta);
                            MessageBox.Show("Se registro con exito la venta.");
                            tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                            tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                            lstCarrito2.Items.Add("Total a pagar: " + vc.labTotal.Text);
                            lstCarrito2.Items.Add("Gracias por elegirnos, vuelva pronto!");
                            retirarPDToolStripMenuItem.Enabled = true;
                            vendido2 = true;
                            //Botones Activados
                            btnImprimirCarrito2.Enabled = true;
                            btnFinalizarCarrito2.Enabled = true;
                            //Botones Desactivados
                            btnAgregarACarrito2.Enabled = false;
                            cbxCantArticulos2.Enabled = false;
                            btnEliminarItemsDelCarrito2.Enabled = false;
                            btnVenderItemsDelCarrito2.Enabled = false;
                        }
                        else if (vc.cmbTipoTarjeta.SelectedIndex == 5)
                        {
                            unaVenta = new Venta(unCarrito2, Venta.TipoDePago.CREDITO);
                            unaCaja.RegistrarVentaEnTarjetaSideCreer(unaVenta);
                            MessageBox.Show("Se registro con exito la venta.");
                            tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                            tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                            lstCarrito2.Items.Add("Total a pagar: " + vc.labTotal.Text);
                            lstCarrito2.Items.Add("Gracias por elegirnos, vuelva pronto!");
                            retirarPDToolStripMenuItem.Enabled = true;
                            vendido2 = true;
                            //Botones Activados
                            btnImprimirCarrito2.Enabled = true;
                            btnFinalizarCarrito2.Enabled = true;
                            //Botones Desactivados
                            btnAgregarACarrito2.Enabled = false;
                            cbxCantArticulos2.Enabled = false;
                            btnEliminarItemsDelCarrito2.Enabled = false;
                            btnVenderItemsDelCarrito2.Enabled = false;
                        }
                        else
                        {
                            unaVenta = new Venta(unCarrito2, Venta.TipoDePago.CREDITO);
                            unaCaja.RegistrarVentaEnTarjetaConsuMax(unaVenta);
                            MessageBox.Show("Se registro con exito la venta.");
                            tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                            tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                            lstCarrito2.Items.Add("Total a pagar: " + vc.labTotal.Text);
                            lstCarrito2.Items.Add("Gracias por elegirnos, vuelva pronto!");
                            retirarPDToolStripMenuItem.Enabled = true;
                            vendido2 = true;
                            //Botones Activados
                            btnImprimirCarrito2.Enabled = true;
                            btnFinalizarCarrito2.Enabled = true;
                            //Botones Desactivados
                            btnAgregarACarrito2.Enabled = false;
                            cbxCantArticulos2.Enabled = false;
                            btnEliminarItemsDelCarrito2.Enabled = false;
                            btnVenderItemsDelCarrito2.Enabled = false;
                        }
                    }
                    else
                    {
                        try
                        {
                            unaVenta = new Venta(unCarrito2, Venta.TipoDePago.CHEQUE);
                            vc.tbxDineroRecibido.Text = unaVenta.Total.ToString();
                            if (unaVenta.Total <= Convert.ToDouble(vc.tbxDineroRecibido.Text))
                            {
                                unaCaja.RegistrarVentaEnCheques(unaVenta);
                                MessageBox.Show("Se registro con exito la venta.\r\nEl vuelto del Cliente es de " + unaVenta.SuVuelto);
                                tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                                tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                                lstCarrito2.Items.Add("Total a pagar: " + vc.labTotal.Text);
                                lstCarrito2.Items.Add("Gracias por elegirnos, vuelva pronto!");
                                retirarPDToolStripMenuItem.Enabled = true;
                                vendido2 = true;
                                //Botones Activados
                                btnImprimirCarrito2.Enabled = true;
                                btnFinalizarCarrito2.Enabled = true;
                                //Botones Desactivados
                                btnAgregarACarrito2.Enabled = false;
                                cbxCantArticulos2.Enabled = false;
                                btnEliminarItemsDelCarrito2.Enabled = false;
                                btnVenderItemsDelCarrito2.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("El dinero ingrsado tiene que ser mayor al monto a pagar.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("El carrito esta vacio. No se puede realizar una venta sin articulos.\r\nCargue al menos un articulo y vuelva a intentar.");
            }
            vc.Dispose();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (lstCarrito1.Items.Count > -1)
            {
                if (MessageBox.Show("El contenido del Carrito 1 va ha ser borrado. Esta informacion puede ser irrecuperable. ¿Desea continuar?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    lstCarrito1.Items.Clear();
                    unCarrito1.VaciarCarrito();
                    //Botones Desctivados
                    btnImprmirCarrito1.Enabled = false;
                    btnFinalizarCarrito1.Enabled = false;
                    btnVenderItemsDelCarrito1.Enabled = false;
                    vendido1 = false;
                    //Botones Activados
                    btnAgregarACarrito1.Enabled = true;
                    cbxCantArticulos1.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Se cancelo el borrado del carrito 1.");
                }
            }
            else
            {
                MessageBox.Show("El Carrito 1 se encuetra vacio!");
            }
        }

        private void btnImprimirCarrito2_Click(object sender, EventArgs e)
        {
            if (lstCarrito2.Items.Count > 0 && unCarrito2.CountCarrito > 0 && vendido2)
            {
                carrito2 = true;
                carrito1 = false;
                carrito3 = false;
                pageSetupDialog1.ShowDialog();
                printPreviewDialog1.ShowDialog();
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
                tbxTexto.Clear();
                string[] vector = new string[2];
                vector[0] = "Detalle de su Compra";
                vector[1] = "No valido como factura";
                for (int i = 0; i < vector.Length; i++)
                {
                    if (i == 0)
                    {
                        tbxTexto.Text += "\r" + vector[i];
                    }
                    else
                    {
                        tbxTexto.Text += "\r\n" + vector[i];
                        tbxTexto.Text += "\r\nRazon social: " + unCajero.RazonSocial;
                        tbxTexto.Text += "\r\nSucursal: " + unCajero.Sucursal.ToString();
                        tbxTexto.Text += "\r\nDirección: " + unCajero.Direccion;
                        tbxTexto.Text += "\r\nTelefono: " + unCajero.Telefono;
                        tbxTexto.Text += "\r\nCaja Nº: " + unCajero.NumeroDeCaja.ToString();
                        tbxTexto.Text += "\r\nCajero: " + unCajero.Nombre + " " + unCajero.Apellido;
                    }
                }
                carrito2 = false;
            }
            else
            {
                MessageBox.Show("El carrito esta vacio. No se puede realizar una venta sin articulos.\r\nCargue al menos un articulo y vuelva a intentar.");
            }
            vendido2 = false;
        }

        private void btnAgregarACarrito3_Click(object sender, EventArgs e)
        {
            if (codSeleccionado != -1 && desArticulo != "")
            {
                if (unArticulo != null)
                {
                    if (cbxCantArticulos3.Checked)
                    {
                        unCarrito3.Cantidad = 1;
                        unCarrito3.Agregar(unArticulo);
                        lstCarrito3.Items.Add(unArticulo);
                        //Botones Activados
                        btnEliminarItemsDelCarrito3.Enabled = true;
                        btnVenderItemsDelCarrito3.Enabled = true;
                    }
                    else
                    {
                        CantidadDeArticulos vc = new CantidadDeArticulos();
                        if (vc.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                unArticulo.CantidadPedida = Convert.ToInt32(vc.tbxCantidad.Text);
                                unCarrito3.Cantidad = Convert.ToInt32(vc.tbxCantidad.Text);
                                unCarrito3.Agregar(unArticulo);
                                lstCarrito3.Items.Add(unArticulo);
                                //Botones Activados
                                btnEliminarItemsDelCarrito3.Enabled = true;
                                btnVenderItemsDelCarrito3.Enabled = true;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        vc.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("Error\r\n" + unCarrito3.MensajeErrorCargaArticulo());
                }
            }
        }

        private void btnEliminarItemsDelCarrito3_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstCarrito3.SelectedIndex != -1)
                {
                    unCarrito3.Eliminar(lstCarrito3.SelectedIndex);
                    lstCarrito3.Items.Remove(lstCarrito3.SelectedItem);
                }
                else
                {
                    MessageBox.Show("No selecciono ningun articulo del Carrito 3. \r\nPor favor seleccione el articulo a eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\nNo selecciono ningun articulo del Carrito 3. \r\nPor favor seleccione al menos un articulo.");
            }
        }

        private void btnVenderItemsDelCarrito3_Click(object sender, EventArgs e)
        {
            CobrarCarrito vc = new CobrarCarrito();
            if (lstCarrito3.Items.Count > 0 && unCarrito3.CountCarrito > -1)
            {
                vc.labTotal.Text = unCarrito3.Total().ToString();
            }
            if (lstCarrito3.Items.Count > 0 && unCarrito3.CountCarrito > 0)
            {
                if (vc.ShowDialog() == DialogResult.OK)
                {
                    if (vc.cmbTipoDePago.SelectedIndex == 0)
                    {
                        try
                        {
                            unaVenta = new Venta(unCarrito3, Venta.TipoDePago.EFECTIVO);
                            if (unaVenta.Total <= Convert.ToDouble(vc.tbxDineroRecibido.Text))
                            {
                                unaCaja.RegistrarVentaEnEfectivo(unaVenta, Convert.ToDouble(vc.tbxDineroRecibido.Text));
                                MessageBox.Show("Se registro con exito la venta.\r\nEl vuelto del Cliente es de " + unaVenta.SuVuelto);
                                tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                                tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                                lstCarrito3.Items.Add("Total a pagar: " + vc.labTotal.Text);
                                lstCarrito3.Items.Add("Gracias por elegirnos, vuelva pronto!");
                                retirarPDToolStripMenuItem.Enabled = true;
                                vendido3 = true;
                                //Botones Activados
                                btnImprimirCarrito3.Enabled = true;
                                btnFinalizarCarrito3.Enabled = true;
                                //Botones Desactivados
                                btnAgregarACarrito3.Enabled = false;
                                cbxCantArticulos3.Enabled = false;
                                btnEliminarItemsDelCarrito3.Enabled = false;
                                btnVenderItemsDelCarrito3.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("El dinero ingrsado tiene que ser mayor o igual al monto a pagar.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (vc.cmbTipoDePago.SelectedIndex == 1)
                    {
                        if (vc.cmbTipoTarjeta.SelectedIndex == 0)
                        {
                            unaVenta = new Venta(unCarrito3, Venta.TipoDePago.DEBITO);
                            unaCaja.RegistrarVentaEnTarjetaMaestro(unaVenta);
                            MessageBox.Show("Se registro con exito la venta.");
                            tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                            tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                            lstCarrito3.Items.Add("Total a pagar: " + vc.labTotal.Text);
                            lstCarrito3.Items.Add("Gracias por elegirnos, vuelva pronto!");
                            retirarPDToolStripMenuItem.Enabled = true;
                            vendido3 = true;
                            //Botones Activados
                            btnImprimirCarrito3.Enabled = true;
                            btnFinalizarCarrito3.Enabled = true;
                            //Botones Desactivados
                            btnAgregarACarrito3.Enabled = false;
                            cbxCantArticulos3.Enabled = false;
                            btnEliminarItemsDelCarrito3.Enabled = false;
                            btnVenderItemsDelCarrito3.Enabled = false;
                        }
                        else if (vc.cmbTipoTarjeta.SelectedIndex == 1)
                        {
                            try
                            {
                                unaVenta = new Venta(unCarrito3, Venta.TipoDePago.CREDITO);
                                unaCaja.RegistrarVentaEnTarjetaVisa(unaVenta, Convert.ToDouble(vc.tbxRecargo.Text));
                                MessageBox.Show("Se registro con exito la venta.");
                                tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                                tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                                lstCarrito3.Items.Add("Total a pagar: " + vc.labTotal.Text);
                                lstCarrito3.Items.Add("Gracias por elegirnos, vuelva pronto!");
                                retirarPDToolStripMenuItem.Enabled = true;
                                vendido3 = true;
                                //Botones Activados
                                btnImprimirCarrito3.Enabled = true;
                                btnFinalizarCarrito3.Enabled = true;
                                //Botones Desactivados
                                btnAgregarACarrito3.Enabled = false;
                                cbxCantArticulos3.Enabled = false;
                                btnEliminarItemsDelCarrito3.Enabled = false;
                                btnVenderItemsDelCarrito3.Enabled = false;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else if (vc.cmbTipoTarjeta.SelectedIndex == 2)
                        {
                            try
                            {
                                unaVenta = new Venta(unCarrito3, Venta.TipoDePago.CREDITO);
                                unaCaja.RegistrarVentaEnTarjetaMasterCard(unaVenta, Convert.ToDouble(vc.tbxRecargo.Text));
                                MessageBox.Show("Se registro con exito la venta.");
                                tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                                tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                                lstCarrito3.Items.Add("Total a pagar: " + vc.labTotal.Text);
                                lstCarrito3.Items.Add("Gracias por elegirnos, vuelva pronto!");
                                retirarPDToolStripMenuItem.Enabled = true;
                                vendido3 = true;
                                //Botones Activados
                                btnImprimirCarrito3.Enabled = true;
                                btnFinalizarCarrito3.Enabled = true;
                                //Botones Desactivados
                                btnAgregarACarrito3.Enabled = false;
                                cbxCantArticulos3.Enabled = false;
                                btnEliminarItemsDelCarrito3.Enabled = false;
                                btnVenderItemsDelCarrito3.Enabled = false;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else if (vc.cmbTipoTarjeta.SelectedIndex == 3)
                        {
                            try
                            {
                                unaVenta = new Venta(unCarrito3, Venta.TipoDePago.CREDITO);
                                unaCaja.RegistrarVentaEnTarjetaCabal(unaVenta, Convert.ToDouble(vc.tbxRecargo.Text));
                                MessageBox.Show("Se registro con exito la venta.");
                                tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                                tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                                lstCarrito3.Items.Add("Total a pagar: " + vc.labTotal.Text);
                                lstCarrito3.Items.Add("Gracias por elegirnos, vuelva pronto!");
                                retirarPDToolStripMenuItem.Enabled = true;
                                vendido3 = true;
                                //Botones Activados
                                btnImprimirCarrito3.Enabled = true;
                                btnFinalizarCarrito3.Enabled = true;
                                //Botones Desactivados
                                btnAgregarACarrito3.Enabled = false;
                                cbxCantArticulos3.Enabled = false;
                                btnEliminarItemsDelCarrito3.Enabled = false;
                                btnVenderItemsDelCarrito3.Enabled = false;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else if (vc.cmbTipoTarjeta.SelectedIndex == 4)
                        {
                            unaVenta = new Venta(unCarrito3, Venta.TipoDePago.CREDITO);
                            unaCaja.RegistrarVentaEnTarjetaNaranja(unaVenta);
                            MessageBox.Show("Se registro con exito la venta.");
                            tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                            tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                            lstCarrito3.Items.Add("Total a pagar: " + vc.labTotal.Text);
                            lstCarrito3.Items.Add("Gracias por elegirnos, vuelva pronto!");
                            retirarPDToolStripMenuItem.Enabled = true;
                            vendido3 = true;
                            //Botones Activados
                            btnImprimirCarrito3.Enabled = true;
                            btnFinalizarCarrito3.Enabled = true;
                            //Botones Desactivados
                            btnAgregarACarrito3.Enabled = false;
                            cbxCantArticulos3.Enabled = false;
                            btnEliminarItemsDelCarrito3.Enabled = false;
                            btnVenderItemsDelCarrito3.Enabled = false;
                        }
                        else if (vc.cmbTipoTarjeta.SelectedIndex == 5)
                        {
                            unaVenta = new Venta(unCarrito3, Venta.TipoDePago.CREDITO);
                            unaCaja.RegistrarVentaEnTarjetaSideCreer(unaVenta);
                            MessageBox.Show("Se registro con exito la venta.");
                            tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                            tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                            lstCarrito3.Items.Add("Total a pagar: " + vc.labTotal.Text);
                            lstCarrito3.Items.Add("Gracias por elegirnos, vuelva pronto!");
                            retirarPDToolStripMenuItem.Enabled = true;
                            vendido3 = true;
                            //Botones Activados
                            btnImprimirCarrito3.Enabled = true;
                            btnFinalizarCarrito3.Enabled = true;
                            //Botones Desactivados
                            btnAgregarACarrito3.Enabled = false;
                            cbxCantArticulos3.Enabled = false;
                            btnEliminarItemsDelCarrito3.Enabled = false;
                            btnVenderItemsDelCarrito3.Enabled = false;
                        }
                        else
                        {
                            unaVenta = new Venta(unCarrito3, Venta.TipoDePago.CREDITO);
                            unaCaja.RegistrarVentaEnTarjetaConsuMax(unaVenta);
                            MessageBox.Show("Se registro con exito la venta.");
                            tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                            tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                            lstCarrito3.Items.Add("Total a pagar: " + vc.labTotal.Text);
                            lstCarrito3.Items.Add("Gracias por elegirnos, vuelva pronto!");
                            retirarPDToolStripMenuItem.Enabled = true;
                            vendido3 = true;
                            //Botones Activados
                            btnImprimirCarrito3.Enabled = true;
                            btnFinalizarCarrito3.Enabled = true;
                            //Botones Desactivados
                            btnAgregarACarrito3.Enabled = false;
                            cbxCantArticulos3.Enabled = false;
                            btnEliminarItemsDelCarrito3.Enabled = false;
                            btnVenderItemsDelCarrito3.Enabled = false;
                        }
                    }
                    else
                    {
                        try
                        {
                            unaVenta = new Venta(unCarrito3, Venta.TipoDePago.CHEQUE);
                            vc.tbxDineroRecibido.Text = unaVenta.Total.ToString();
                            if (unaVenta.Total <= Convert.ToDouble(vc.tbxDineroRecibido.Text))
                            {
                                unaCaja.RegistrarVentaEnCheques(unaVenta);
                                MessageBox.Show("Se registro con exito la venta.\r\nEl vuelto del Cliente es de " + unaVenta.SuVuelto);
                                tbxTexto.Text += "\r\nNº de detalle: " + Venta.NroDeVenta().ToString();
                                tbxTexto.Text += "\r\nFecha: " + unaVenta.Fecha.ToString();
                                lstCarrito3.Items.Add("Total a pagar: " + vc.labTotal.Text);
                                lstCarrito3.Items.Add("Gracias por elegirnos, vuelva pronto!");
                                retirarPDToolStripMenuItem.Enabled = true;
                                vendido3 = true;
                                //Botones Activados
                                btnImprimirCarrito3.Enabled = true;
                                btnFinalizarCarrito3.Enabled = true;
                                //Botones Desactivados
                                btnAgregarACarrito3.Enabled = false;
                                cbxCantArticulos3.Enabled = false;
                                btnEliminarItemsDelCarrito3.Enabled = false;
                                btnVenderItemsDelCarrito3.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("El dinero ingrsado tiene que ser mayor al monto a pagar.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("El carrito esta vacio. No se puede realizar una venta sin articulos.\r\nCargue al menos un articulo y vuelva a intentar.");
            }
            vc.Dispose();
        }

        private void btnImprimirCarrito3_Click(object sender, EventArgs e)
        {
            if (lstCarrito3.Items.Count > 0 && unCarrito3.CountCarrito > 0 && vendido3)
            {
                carrito3 = true;
                carrito1 = false;
                carrito2 = false;
                pageSetupDialog1.ShowDialog();
                printPreviewDialog1.ShowDialog();
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
                tbxTexto.Clear();
                string[] vector = new string[2];
                vector[0] = "Detalle de su Compra";
                vector[1] = "No valido como factura";
                for (int i = 0; i < vector.Length; i++)
                {
                    if (i == 0)
                    {
                        tbxTexto.Text += "\r" + vector[i];
                    }
                    else
                    {
                        tbxTexto.Text += "\r\n" + vector[i];
                        tbxTexto.Text += "\r\nRazon social: " + unCajero.RazonSocial;
                        tbxTexto.Text += "\r\nSucursal: " + unCajero.Sucursal.ToString();
                        tbxTexto.Text += "\r\nDirección: " + unCajero.Direccion;
                        tbxTexto.Text += "\r\nTelefono: " + unCajero.Telefono;
                        tbxTexto.Text += "\r\nCaja Nº: " + unCajero.NumeroDeCaja.ToString();
                        tbxTexto.Text += "\r\nCajero: " + unCajero.Nombre + " " + unCajero.Apellido;
                    }
                }
                carrito3 = false;
            }
            else
            {
                MessageBox.Show("El carrito esta vacio. No se puede realizar una venta sin articulos.\r\nCargue al menos un articulo y vuelva a intentar.");
            }
            vendido3 = false;
        }

        private void btnFinalizarCarrito2_Click(object sender, EventArgs e)
        {
            if (lstCarrito2.Items.Count > -1)
            {
                if (MessageBox.Show("El contenido del Carrito 2 va ha ser borrado. Esta informacion puede ser irrecuperable. ¿Desea continuar?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    lstCarrito2.Items.Clear();
                    unCarrito2.VaciarCarrito();
                    //Botones Desctivados
                    btnImprimirCarrito2.Enabled = false;
                    btnFinalizarCarrito2.Enabled = false;
                    btnVenderItemsDelCarrito2.Enabled = false;
                    vendido2 = false;
                    //Botones Activados
                    btnAgregarACarrito2.Enabled = true;
                    cbxCantArticulos2.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Se cancelo el borrado del carrito 2.");
                }
            }
            else
            {
                MessageBox.Show("El Carrito 2 se encuetra vacio!");
            }
        }

        private void btnFinalizarCarrito3_Click(object sender, EventArgs e)
        {
            if (lstCarrito3.Items.Count > -1)
            {
                if (MessageBox.Show("El contenido del Carrito 3 va ha ser borrado. Esta informacion puede ser irrecuperable. ¿Desea continuar?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    lstCarrito3.Items.Clear();
                    unCarrito3.VaciarCarrito();
                    //Botones Desctivados
                    btnImprimirCarrito3.Enabled = false;
                    btnFinalizarCarrito3.Enabled = false;
                    btnVenderItemsDelCarrito3.Enabled = false;
                    vendido3 = false;
                    //Botones Activados
                    btnAgregarACarrito3.Enabled = true;
                    cbxCantArticulos3.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Se cancelo el borrado del carrito 3.");
                }
            }
            else
            {
                MessageBox.Show("El Carrito 3 se encuetra vacio!");
            }
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cod;
            BuscarPorCodigo vc = new BuscarPorCodigo();
            vc.tbxCodigo.AutoCompleteCustomSource = carga.getAutoCompleteCodigos();
            
            while (vc.ShowDialog() == DialogResult.Retry)
            {
                if (vc.tbxCodigo.Text != "" && vc.cmbSeleccionCarrito.SelectedIndex != -1)
                {
                    try
                    {
                        cod = Convert.ToInt32(vc.tbxCodigo.Text);

                        foreach (Articulo art in carga.getListaArticulos())
                        {
                            if (cod == art.Codigo)
                            {
                                if (vc.cbCantidad.Checked)
                                {
                                    if (vc.cmbSeleccionCarrito.SelectedIndex == 0)
                                    {
                                        if (!vendido1)
                                        {
                                            unCarrito1.Cantidad = 1;
                                            unCarrito1.Agregar(art);
                                            lstCarrito1.Items.Add(art);
                                            vc.lstArticulosParaAgregarAlCarrito.Items.Add(art);
                                            //Botones Activados
                                            btnEliminarItemsDelCarrito1.Enabled = true;
                                            btnVenderItemsDelCarrito1.Enabled = true;
                                            //unArticulo = art;
                                            //desArticulo = art.ToString();
                                            break;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Carrito vendido! No se puede agregar o eliminar articulos! Finalice la venta.");
                                        }
                                    }
                                    else if (vc.cmbSeleccionCarrito.SelectedIndex == 1)
                                    {
                                        if (!vendido2)
                                        {
                                            unCarrito2.Cantidad = 1;
                                            unCarrito2.Agregar(art);
                                            lstCarrito2.Items.Add(art);
                                            vc.lstArticulosParaAgregarAlCarrito.Items.Add(art);
                                            //Botones Activados
                                            btnEliminarItemsDelCarrito2.Enabled = true;
                                            btnVenderItemsDelCarrito2.Enabled = true;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Carrito vendido! No se puede agregar o eliminar articulos! Finalice la venta.");
                                        }
                                    }
                                    else
                                    {
                                        if (!vendido3)
                                        {
                                            unCarrito3.Cantidad = 1;
                                            unCarrito3.Agregar(art);
                                            lstCarrito3.Items.Add(art);
                                            vc.lstArticulosParaAgregarAlCarrito.Items.Add(art);
                                            //Botones Activados
                                            btnEliminarItemsDelCarrito3.Enabled = true;
                                            btnVenderItemsDelCarrito3.Enabled = true;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Carrito vendido! No se puede agregar o eliminar articulos! Finalice la venta.");
                                        }
                                    }
                                }
                                else
                                {
                                    CantidadDeArticulos vc1 = new CantidadDeArticulos();
                                    if (vc1.ShowDialog() == DialogResult.OK)
                                    {
                                        if (vc1.tbxCantidad.Text != "")
                                        {
                                            if (vc.cmbSeleccionCarrito.SelectedIndex == 0)
                                            {
                                                if (!vendido1)
                                                {
                                                    art.CantidadPedida = Convert.ToInt32(vc1.tbxCantidad.Text);
                                                    unCarrito1.Cantidad = Convert.ToInt32(vc1.tbxCantidad.Text);
                                                    unCarrito1.Agregar(art);
                                                    lstCarrito1.Items.Add(art);
                                                    vc.lstArticulosParaAgregarAlCarrito.Items.Add(art);
                                                    //Botones Activados
                                                    btnEliminarItemsDelCarrito1.Enabled = true;
                                                    btnVenderItemsDelCarrito1.Enabled = true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Carrito vendido! No se puede agregar o eliminar articulos! Finalice la venta.");
                                                }
                                            }
                                            else if (vc.cmbSeleccionCarrito.SelectedIndex == 1)
                                            {
                                                if (!vendido2)
                                                {
                                                    art.CantidadPedida = Convert.ToInt32(vc1.tbxCantidad.Text);
                                                    unCarrito2.Cantidad = Convert.ToInt32(vc1.tbxCantidad.Text);
                                                    unCarrito2.Agregar(art);
                                                    lstCarrito2.Items.Add(art);
                                                    vc.lstArticulosParaAgregarAlCarrito.Items.Add(art);
                                                    //Botones Activados
                                                    btnEliminarItemsDelCarrito2.Enabled = true;
                                                    btnVenderItemsDelCarrito2.Enabled = true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Carrito vendido! No se puede agregar o eliminar articulos! Finalice la venta.");
                                                }
                                            }
                                            else
                                            {
                                                if (!vendido3)
                                                {
                                                    art.CantidadPedida = Convert.ToInt32(vc1.tbxCantidad.Text);
                                                    unCarrito3.Cantidad = Convert.ToInt32(vc1.tbxCantidad.Text);
                                                    unCarrito3.Agregar(art);
                                                    lstCarrito3.Items.Add(art);
                                                    vc.lstArticulosParaAgregarAlCarrito.Items.Add(art);
                                                    //Botones Activados
                                                    btnEliminarItemsDelCarrito3.Enabled = true;
                                                    btnVenderItemsDelCarrito3.Enabled = true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Carrito vendido! No se puede agregar o eliminar articulos! Finalice la venta.");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se ingreso la cantidad del articulo buscado.");
                                        }
                                    }
                                    vc1.Dispose();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Error!\r\nNo se ingresado el codigo a buscar o no se ha seleccionado un carrito de compra\r\nComplete todos los campos y vuelva a intentar.");
                }
            }
            /*else
            {
                vc.Close();
            }*/
            vc.Dispose();
        }

        private void porNombreToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BusquedaPorNombre vc = new BusquedaPorNombre();
            vc.tbxNombre.AutoCompleteCustomSource = carga.getAutoCompleteNombres();

            while (vc.ShowDialog() == DialogResult.Retry)
            {
                if (vc.tbxNombre.Text != "" && vc.cmbSeleccionCarrito.SelectedIndex != -1)
                {
                    foreach (Articulo art in carga.getListaArticulos())
                    {
                        if (vc.tbxNombre.Text == art.Descripcion)
                        {
                            if (vc.cbCantidad.Checked)
                            {
                                if (vc.cmbSeleccionCarrito.SelectedIndex == 0)
                                {
                                    if (!vendido1)
                                    {
                                        unCarrito1.Cantidad = 1;
                                        unCarrito1.Agregar(art);
                                        lstCarrito1.Items.Add(art);
                                        vc.lstArticulosParaAgregarAlCarrito.Items.Add(art);
                                        //Botones Activados
                                        btnEliminarItemsDelCarrito1.Enabled = true;
                                        btnVenderItemsDelCarrito1.Enabled = true;
                                        //unArticulo = art;
                                        //desArticulo = art.ToString();
                                        break;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Carrito vendido! No se puede agregar o eliminar articulos! Finalice la venta.");
                                    }
                                }
                                else if (vc.cmbSeleccionCarrito.SelectedIndex == 1)
                                {
                                    if (!vendido2)
                                    {
                                        unCarrito2.Cantidad = 1;
                                        unCarrito2.Agregar(art);
                                        lstCarrito2.Items.Add(art);
                                        vc.lstArticulosParaAgregarAlCarrito.Items.Add(art);
                                        //Botones Activados
                                        btnEliminarItemsDelCarrito2.Enabled = true;
                                        btnVenderItemsDelCarrito2.Enabled = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Carrito vendido! No se puede agregar o eliminar articulos! Finalice la venta.");
                                    }
                                }
                                else
                                {
                                    if (!vendido3)
                                    {
                                        unCarrito3.Cantidad = 1;
                                        unCarrito3.Agregar(art);
                                        lstCarrito3.Items.Add(art);
                                        vc.lstArticulosParaAgregarAlCarrito.Items.Add(art);
                                        //Botones Activados
                                        btnEliminarItemsDelCarrito3.Enabled = true;
                                        btnVenderItemsDelCarrito3.Enabled = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Carrito vendido! No se puede agregar o eliminar articulos! Finalice la venta.");
                                    }
                                }
                            }
                            else
                            {
                                CantidadDeArticulos vc1 = new CantidadDeArticulos();
                                if (vc1.ShowDialog() == DialogResult.OK)
                                {
                                    if (vc1.tbxCantidad.Text != "")
                                    {
                                        try
                                        {

                                            if (vc.cmbSeleccionCarrito.SelectedIndex == 0)
                                            {
                                                if (!vendido1)
                                                {
                                                    art.CantidadPedida = Convert.ToInt32(vc1.tbxCantidad.Text);
                                                    unCarrito1.Cantidad = Convert.ToInt32(vc1.tbxCantidad.Text);
                                                    unCarrito1.Agregar(art);
                                                    lstCarrito1.Items.Add(art);
                                                    vc.lstArticulosParaAgregarAlCarrito.Items.Add(art);
                                                    //Botones Activados
                                                    btnEliminarItemsDelCarrito1.Enabled = true;
                                                    btnVenderItemsDelCarrito1.Enabled = true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Carrito vendido! No se puede agregar o eliminar articulos! Finalice la venta.");
                                                }
                                            }
                                            else if (vc.cmbSeleccionCarrito.SelectedIndex == 1)
                                            {
                                                if (!vendido2)
                                                {
                                                    art.CantidadPedida = Convert.ToInt32(vc1.tbxCantidad.Text);
                                                    unCarrito2.Cantidad = Convert.ToInt32(vc1.tbxCantidad.Text);
                                                    unCarrito2.Agregar(art);
                                                    lstCarrito2.Items.Add(art);
                                                    vc.lstArticulosParaAgregarAlCarrito.Items.Add(art);
                                                    //Botones Activados
                                                    btnEliminarItemsDelCarrito2.Enabled = true;
                                                    btnVenderItemsDelCarrito2.Enabled = true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Carrito vendido! No se puede agregar o eliminar articulos! Finalice la venta.");
                                                }
                                            }
                                            else
                                            {
                                                if (!vendido3)
                                                {
                                                    art.CantidadPedida = Convert.ToInt32(vc1.tbxCantidad.Text);
                                                    unCarrito3.Cantidad = Convert.ToInt32(vc1.tbxCantidad.Text);
                                                    unCarrito3.Agregar(art);
                                                    lstCarrito3.Items.Add(art);
                                                    vc.lstArticulosParaAgregarAlCarrito.Items.Add(art);
                                                    //Botones Activados
                                                    btnEliminarItemsDelCarrito3.Enabled = true;
                                                    btnVenderItemsDelCarrito3.Enabled = true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Carrito vendido! No se puede agregar o eliminar articulos! Finalice la venta.");
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se ingreso la cantidad del articulo buscado.");
                                    }
                                }
                                vc1.Dispose();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error!\r\nNo se ingresado el nombre a buscar o no se ha seleccionado un carrito de compra\r\nComplete todos los campos y vuelva a intentar.");
                }
            }/*
            else
            {
                vc.Close();
            }*/
            vc.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Splash vs = new Splash();
            vs.Opacity = 0;
            vs.timer1.Enabled = true;
            vs.ShowDialog();
            vs.Dispose();
        }

        private void cerrarCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CierreDeCaja vc = new CierreDeCaja();
            if (MessageBox.Show("Antes de proceder al cierre de caja, no olvide retirar su cambio.\r\nEl monto del cambio a retirar es de: " + unaCaja.Cambio.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                vc.labTotalMaestro.Text = unaCaja.TotalMaestro.ToString();
                vc.labTotalVisa.Text = unaCaja.TotalVisa.ToString();
                vc.labTotalMastercard.Text = unaCaja.TotalMasterCard.ToString();
                vc.labTotalCabal.Text = unaCaja.TotalCabal.ToString();
                vc.labTotalNaranja.Text = unaCaja.TotalNaranja.ToString();
                vc.labTotalSidecreer.Text = unaCaja.TotalSideCreer.ToString();
                vc.labTotalConsumax.Text = unaCaja.TotalConsumax.ToString();
                vc.labTotalTarjetas.Text = unaCaja.TotalTarjetas.ToString();
                vc.labTotalRecargoVisa.Text = unaCaja.TotalRecargoVisa.ToString();
                vc.labTotalRecargoMastercard.Text = unaCaja.TotalRecargoMasterCard.ToString();
                vc.labTotalRecargoCabal.Text = unaCaja.TotalRecargoCabal.ToString();
                vc.labTotalRecargos.Text = unaCaja.TotalRecargos.ToString();
                vc.labTotalTarjetasM.Text = unaCaja.TotalTarjetas.ToString();
                vc.labTotalRecargosM.Text = unaCaja.TotalRecargos.ToString();
                vc.labTotalMutuales.Text = unaCaja.TotalMutuales.ToString();
                vc.labTotalPD.Text = unaCaja.TotalPD.ToString();
                vc.labTotalVentas.Text = unaCaja.TotalVentas.ToString();
                vc.labTotalEfectivoEntregadoE.Text = unaCaja.TotalEfectivo.ToString();
                vc.labTotalCheques.Text = unaCaja.TotalCheques.ToString();
                vc.labTotalEfectivoEntregadoR.Text = unaCaja.TotalEfectivo.ToString();
                vc.labTotalChequesR.Text = unaCaja.TotalCheques.ToString();
                vc.labTotalMutualesR.Text = unaCaja.TotalMutuales.ToString();
                vc.labTotalRecuadado.Text = unaCaja.TotalRecaudado.ToString();
                vc.labTotalCaja.Text = unaCaja.TotalRecaudado.ToString();
                vc.ShowDialog();
            }
            vc.Dispose();
            cerrarCajaToolStripMenuItem.Enabled = false;
            retirarPDToolStripMenuItem.Enabled = false;
            buscarToolStripMenuItem.Enabled = false;
            tbxBuscarToolStripMenu.Enabled = false;
            gbCarritoDeCompras1.Enabled = false;
            gbCarritoDeCompras2.Enabled = false;
            gbCarritoDeCompras3.Enabled = false;
            cargarToolStripMenuItem.Enabled = false;
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Acercade vs = new Acercade();
            vs.Opacity = 0;
            vs.timer1.Enabled = true;
            vs.ShowDialog();
            vs.Dispose();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            
            if (Width > 1036 && Height > 766)
            {
                //ListaArticulos.Width = Width - gbCarritoDeCompras1.Width - 75;
                //gbx1
                ListaArticulos.Height = Height - 100;
                gbCarritoDeCompras1.Width = Width - 700;
                lstCarrito1.Width = gbCarritoDeCompras1.Width - 100;
                gbCarritoDeCompras1.Height = Height - 585;
                lstCarrito1.Height = gbCarritoDeCompras1.Height - 40;
                //gbx2
                ListaArticulos.Height = Height - 100;
                gbCarritoDeCompras2.Width = Width - 700;
                lstCarrito2.Width = gbCarritoDeCompras2.Width - 100;
                gbCarritoDeCompras2.Height = Height - 585;
                lstCarrito2.Height = gbCarritoDeCompras2.Height - 20;
                //gbx3
                ListaArticulos.Height = Height - 100;
                gbCarritoDeCompras3.Width = Width - 700;
                lstCarrito3.Width = gbCarritoDeCompras3.Width - 100;
                gbCarritoDeCompras3.Height = Height - 585;
                lstCarrito3.Height = gbCarritoDeCompras3.Height - 20;
            }
            else
            {
                Width = 1036;
                Height = 766;
                ListaArticulos.Height = Height - 100;
                gbCarritoDeCompras1.Width = Width - 700;
                lstCarrito1.Width = gbCarritoDeCompras1.Width - 100;
                gbCarritoDeCompras1.Height = Height - 585;
                lstCarrito1.Height = gbCarritoDeCompras1.Height - 40;
                //gbx2
                ListaArticulos.Height = Height - 100;
                gbCarritoDeCompras2.Width = Width - 700;
                lstCarrito2.Width = gbCarritoDeCompras2.Width - 100;
                gbCarritoDeCompras2.Height = Height - 585;
                lstCarrito2.Height = gbCarritoDeCompras2.Height - 20;
                //gbx3
                ListaArticulos.Height = Height - 100;
                gbCarritoDeCompras3.Width = Width - 700;
                lstCarrito3.Width = gbCarritoDeCompras3.Width - 100;
                gbCarritoDeCompras3.Height = Height - 585;
                lstCarrito3.Height = gbCarritoDeCompras3.Height - 20;
            }
        }

        private void retirarPDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbxRetiroPD.Clear();
            tbxRetiroPD.Text += "\rRetiro de PD";
            tbxRetiroPD.Text += "\r\nEl dia " + DateTime.Now.ToShortDateString() + " " + "a las: " + DateTime.Now.ToShortTimeString() + ".";
            tbxRetiroPD.Text += "\r\nSe produjo un retiro de efectivo, realizado por el cajero " + unCajero.Nombre + " " + unCajero.Apellido + ".";
            tbxRetiroPD.Text += "\r\nEn la caja Nº "+unCajero.NumeroDeCaja.ToString()+", "+"en la sucursal "+unCajero.Sucursal.ToString()+", "+
                "direccion "+ unCajero.Direccion;
            RetirodePD vc = new RetirodePD();
            if (vc.ShowDialog() == DialogResult.OK)
            {
                if (vc.tbxMontoPd.Text != "")
                {
                    try
                    {
                        if (unaCaja.TotalVentas > Convert.ToDouble(vc.tbxMontoPd.Text))
                        {
                            tbxRetiroPD.Text += "\r\nEstado de caja antes del retiro: $" + unaCaja.TotalVentas;
                            unaCaja.RetirarPD(Convert.ToDouble(vc.tbxMontoPd.Text), unCajero);
                            tbxRetiroPD.Text += "\r\nMonto del retiro: $" + vc.tbxMontoPd.Text;
                            tbxRetiroPD.Text += "\r\nEstado actual de la caja: $" + unaCaja.TotalVentas;
                            if (MessageBox.Show("¿Desea Imprimir PD?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                imprimirPD = true;
                                pageSetupDialog1.ShowDialog();
                                printPreviewDialog1.ShowDialog();
                                if (printDialog1.ShowDialog() == DialogResult.OK)
                                {
                                    printDocument1.Print();
                                }
                                imprimirPD = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("El monto a retirar es mas grande que el monto actual del efectivo que posee en caja.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("No se ingreso ningun monto a retirar.");
                }
            }
            vc.Dispose();
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            relleno = new SolidBrush(Color.Black);
            borde = new Pen(Color.Black);
            textoRemanente = "";
            lineaActual = 0;
        }

        private void abrirCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirCaja vc = new AbrirCaja();
            if(vc.ShowDialog() == DialogResult.OK)
            {
                if ((vc.tbxCambioDeCaja.Text != "") && (vc.tbxNumDeCaja.Text != "") && (vc.tbxNombreCajero.Text != "") && (vc.tbxApellidoCajero.Text != "") && (vc.tbxRazonSocial.Text != "") && (vc.tbxSucursal.Text != "") && (vc.tbxDireccion.Text != "") && (vc.tbxTelefono.Text != ""))
                {
                    try
                    {
                        unaCaja = new Caja(Convert.ToDouble(vc.tbxCambioDeCaja.Text));
                        unCajero = new Cajero(vc.tbxNombreCajero.Text, vc.tbxApellidoCajero.Text, Convert.ToInt32(vc.tbxNumDeCaja.Text), vc.tbxRazonSocial.Text, Convert.ToInt32(vc.tbxSucursal.Text), vc.tbxDireccion.Text, vc.tbxTelefono.Text);
                        string[] vector = new string[2];
                        vector[0] = "Detalle de su Compra";
                        vector[1] = "No valido como factura";
                        for(int i = 0; i < vector.Length; i++)
                        {
                            if(i == 0)
                            {
                                tbxTexto.Text += "\r" + vector[i];
                            }
                            else
                            {
                                tbxTexto.Text += "\r\n" + vector[i];
                                tbxTexto.Text += "\r\nRazon social: " + unCajero.RazonSocial;
                                tbxTexto.Text += "\r\nSucursal: " + unCajero.Sucursal.ToString();
                                tbxTexto.Text += "\r\nDirección: " + unCajero.Direccion;
                                tbxTexto.Text += "\r\nTelefono: " + unCajero.Telefono;
                                tbxTexto.Text += "\r\nCaja Nº: " + unCajero.NumeroDeCaja.ToString();
                                tbxTexto.Text += "\r\nCajero: " + unCajero.Nombre + " " + unCajero.Apellido;
                            }
                        }
                        MessageBox.Show("Se abrio la caja con el monto: $" + unaCaja.Cambio + "\r\nProceda a cargar la lista de precios.\r\nAsegurese de la lista ya tenga modificado el margen de ganancia.");
                        cargarToolStripMenuItem.Enabled = true;
                        abrirCajaToolStripMenuItem.Enabled = false;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\r\nEl monto, el numero de caja y la sucursal son valores numericos\r\nEjemplo monto: 500, Sucursal: 2, Numero de Caja: 1");
                    }
                }
                else
                {
                    MessageBox.Show("Faltó llenar un campo");
                }
            }
            vc.Dispose();
        }

        private void printDocument1_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            relleno.Dispose();
            borde.Dispose();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font fuente = tbxTexto.Font;
            SizeF tamañoDeLinea;
            float posY = 0;

            e.Graphics.DrawRectangle(borde, new Rectangle(0, 0, e.MarginBounds.Width, e.MarginBounds.Height));
            if (!imprimirPD)
            {
                while ((lineaActual < tbxTexto.Lines.Count() || (textoRemanente != "")) && (posY + fuente.GetHeight() < e.MarginBounds.Height))
                {
                    if (textoRemanente == "")
                    {
                        textoActual = tbxTexto.Lines[lineaActual];
                    }
                    else
                    {
                        textoActual = textoRemanente;
                        textoRemanente = "";
                    }

                    tamañoDeLinea = e.Graphics.MeasureString(textoActual, fuente);

                    while (e.MarginBounds.Width < tamañoDeLinea.Width)
                    {
                        textoRemanente = textoActual[textoActual.Length - 1] + textoRemanente;
                        textoActual = textoActual.Remove(textoActual.Length - 1, 1);
                        tamañoDeLinea = e.Graphics.MeasureString(textoActual, fuente);
                    }
                    e.Graphics.DrawString(textoActual, fuente, relleno, new PointF(0, posY));
                    posY = posY + tamañoDeLinea.Height;

                    if (textoRemanente == "")
                    {
                        lineaActual++;
                    }
                }
                if ((lineaActual > 0/*listActualizable.Items.Count*/) && (posY + fuente.GetHeight() < e.MarginBounds.Height))
                {
                    int cont = 0;
                    string s = "Lista de Articulos: ";//listActualizable.Items[i].ToString();
                    tamañoDeLinea = e.Graphics.MeasureString(s, fuente);
                    e.Graphics.DrawString(s, fuente, Brushes.Black, e.MarginBounds.Left, posY, new StringFormat());
                    posY = e.MarginBounds.Top + (lineaActual * fuente.GetHeight(e.Graphics));
                    lineaActual++;
                    cont++;
                    if (carrito1 && !carrito2 && !carrito3)
                    {
                        for (int i = 0; i < lstCarrito1.Items.Count; i++)
                        {
                            s = lstCarrito1.Items[i].ToString();
                            tamañoDeLinea = e.Graphics.MeasureString(s, fuente);
                            e.Graphics.DrawString(s, fuente, Brushes.Black, e.MarginBounds.Left, posY, new StringFormat());
                            posY = e.MarginBounds.Top + (lineaActual * fuente.GetHeight(e.Graphics));
                            lineaActual++;
                        }
                    }
                    else if (!carrito1 && carrito2 && !carrito3)
                    {
                        for (int i = 0; i < lstCarrito2.Items.Count; i++)
                        {
                            s = lstCarrito2.Items[i].ToString();
                            tamañoDeLinea = e.Graphics.MeasureString(s, fuente);
                            e.Graphics.DrawString(s, fuente, Brushes.Black, e.MarginBounds.Left, posY, new StringFormat());
                            posY = e.MarginBounds.Top + (lineaActual * fuente.GetHeight(e.Graphics));
                            lineaActual++;
                        }
                    }
                    else
                    {
                        if (!carrito1 && !carrito2 && carrito3)
                        {
                            for (int i = 0; i < lstCarrito3.Items.Count; i++)
                            {
                                s = lstCarrito3.Items[i].ToString();
                                tamañoDeLinea = e.Graphics.MeasureString(s, fuente);
                                e.Graphics.DrawString(s, fuente, Brushes.Black, e.MarginBounds.Left, posY, new StringFormat());
                                posY = e.MarginBounds.Top + (lineaActual * fuente.GetHeight(e.Graphics));
                                lineaActual++;
                            }
                        }
                    }
                }
                e.HasMorePages = ((lineaActual < tbxTexto.Lines.Count()) || (textoRemanente.Length > 0));
            }
            else
            {
                while ((lineaActual < tbxRetiroPD.Lines.Count() || (textoRemanente != "")) && (posY + fuente.GetHeight() < e.MarginBounds.Height))
                {
                    if (textoRemanente == "")
                    {
                        textoActual = tbxRetiroPD.Lines[lineaActual];
                    }
                    else
                    {
                        textoActual = textoRemanente;
                        textoRemanente = "";
                    }

                    tamañoDeLinea = e.Graphics.MeasureString(textoActual, fuente);

                    while (e.MarginBounds.Width < tamañoDeLinea.Width)
                    {
                        textoRemanente = textoActual[textoActual.Length - 1] + textoRemanente;
                        textoActual = textoActual.Remove(textoActual.Length - 1, 1);
                        tamañoDeLinea = e.Graphics.MeasureString(textoActual, fuente);
                    }
                    e.Graphics.DrawString(textoActual, fuente, relleno, new PointF(0, posY));
                    posY = posY + tamañoDeLinea.Height;

                    if (textoRemanente == "")
                    {
                        lineaActual++;
                    }
                }
                e.HasMorePages = ((lineaActual < tbxRetiroPD.Lines.Count()) || (textoRemanente.Length > 0));
            }
        }
    }
}