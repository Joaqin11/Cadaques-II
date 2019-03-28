using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Libreria
{
    class Carrito
    {
        private int nroCarrito;
        private Articulo unArticulo;
        private int cantidad;
        private double subtotal;
        private ArrayList listaDelCarrito;

        public Carrito()
        {
            listaDelCarrito = new ArrayList();
        }

        public void Agregar(Articulo otroArticulo)//realizar el SET UnArticulo = Articulo antes de llamar al metodo
        {
            if (otroArticulo != null)
            {
                if (Cantidad == 1)
                {
                    otroArticulo.Importe = otroArticulo.PrecioConUtilidad * Cantidad;
                    SubTotal += otroArticulo.PrecioConUtilidad;
                    listaDelCarrito.Add(otroArticulo);
                }
                else
                {
                    otroArticulo.CantidadPedida = Cantidad;
                    otroArticulo.Importe = otroArticulo.PrecioConUtilidad * Cantidad;
                    SubTotal += otroArticulo.PrecioConUtilidad * Cantidad;
                    listaDelCarrito.Add(otroArticulo);
                }
            }
        }

        public void Eliminar(int cod)
        {
            int indice = 0, i = 0;
            if (listaDelCarrito != null && listaDelCarrito.Count > -1)
            {
                foreach (Articulo art in listaDelCarrito)
                {
                    if (art.Codigo == cod)
                    {
                        SubTotal -= art.PrecioConUtilidad;
                        i = indice;
                        break;
                    }
                    indice++;
                }
            }
            listaDelCarrito.RemoveAt(i);
        }

        public void MostrarDetalle(ListBox detalle)
        {
            if (listaDelCarrito != null && listaDelCarrito.Count > -1)
            {
                detalle.Items.Clear();
                foreach(Articulo art in listaDelCarrito)
                {
                    detalle.Items.Add(art.ToString());
                }
            }
            else
            {
                MensajeErrorMostrarDetalle();
            }
        }

        public double Total()
        {
            double total = 0;
            if (listaDelCarrito != null && listaDelCarrito.Count > -1)
            {
                foreach (Articulo art in listaDelCarrito)
                {
                    total += art.Importe;
                }
            }
            return total;
        }

        public Articulo UnArticulo
        {
            set
            {
                this.unArticulo = value;
            }
            get
            {
                return this.unArticulo;
            }
        }

        public int Cantidad
        {
            set
            {
                this.cantidad = value;
            }
            get
            {
                return this.cantidad;
            }
        }

        public double SubTotal
        {
            set
            {
                this.subtotal = value;
            }
            get
            {
                return this.subtotal;
            }
        }

        public int NroCarrito
        {
            set
            {
                this.nroCarrito = value;
            }
            get
            {
                return this.nroCarrito;
            }
        }

        public string MensajeErrorCargaArticulo()
        {
            return "No se pudo cargar el articulo al carrito, por favor intente de nuevo o vea si la informacion de dicho articulo es correcta";
        }

        public string MensajeErrorMostrarDetalle()
        {
            return "No se pudo mostrar el detalle del carrito, por favor intente de nuevo o vea si la informacion de dicho carrito es correcta";
        }

        public void VaciarCarrito()
        {
            listaDelCarrito.Clear();
        }

        public int CountCarrito
        {
            get
            {
                return this.listaDelCarrito.Count;
            }
        }
    }
}
