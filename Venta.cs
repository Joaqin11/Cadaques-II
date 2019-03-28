using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace Libreria
{
    class Venta
    {
        private static int nroDeVenta;
        private DateTime fecha;
        //private DateTime hora;
        private double total;
        public enum TipoDePago { EFECTIVO, CREDITO, DEBITO, CHEQUE };
        private double suVuelto;
        private Carrito unCarrito;
        private TipoDePago tipo;
     

        public Venta(Carrito unCarrito, TipoDePago tipo)
        {
            nroDeVenta++;
            this.unCarrito = unCarrito;
            this.fecha = DateTime.Now;
            this.tipo = tipo;
            this.total = this.unCarrito.Total();
        }

        public static int NroDeVenta()
        {
            return nroDeVenta;
        }

        public DateTime Fecha
        {
            get
            {
                return this.fecha;
            }
        }

        public double Total
        {
            get
            {
                return this.total;
            }
        }

        public TipoDePago Tipo
        {
            get
            {
                return this.tipo;
            }
        }

        public double SuVuelto
        {
            set
            {
                this.suVuelto = value;
            }
            get
            {
                return this.suVuelto;
            }
        }

        public Carrito UnCarrito
        {
            get
            {
                return this.unCarrito;
            }
        }
    }
}