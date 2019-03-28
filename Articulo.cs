using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Libreria
{
    class Articulo
    {
        private int cod;
        private string des;
        private string empaquetado;
        private double precioSinIVA;
        private double precioConIVA;
        private double utilidad;
        private double precioConUtilidad;
        private string codDeBarras;
        private int cantidadPedida;
        private double importe;
        private ArrayList listaCodigos;     

        public Articulo(int cod, string des, string empaquetado, double precioSinIVA, double precioConIVA, double utilidad, double precioConUtilidad, string codDeBarras)
        {
            this.cod = cod;
            this.des = des;
            this.empaquetado = empaquetado;
            this.precioSinIVA = precioSinIVA;
            this.precioConIVA = precioConIVA;
            this.utilidad = utilidad;
            this.precioConUtilidad = precioConUtilidad;
            listaCodigos = new ArrayList();
            this.codDeBarras = codDeBarras;
            this.AgregarCodigosDeBarrasAUnProducto();
            this.cantidadPedida = 1;
        }

        public Articulo()
        {
            //Vacio
        }

        public int Codigo
        {
            set
            {
                this.cod = value;
            }
            get
            {
                return this.cod;
            }
        }

        public string Descripcion
        {
            set
            {
                this.des = value;
            }
            get
            {
                return this.des;
            }
        }

        public string Empaquetado
        {
            set
            {
                this.empaquetado = value;
            }
            get
            {
                return this.empaquetado;
            }
        }

        public double PrecioSinIVA
        {
            set
            {
                this.precioSinIVA = value;
            }
            get
            {
                return this.precioSinIVA;
            }
        }

        public double PrecioConIVA
        {
            set
            {
                this.precioConIVA = value;
            }
            get
            {
                return this.precioConIVA;
            }
        }

        public double Utilidad
        {
            set
            {
                this.utilidad = value;
            }
            get
            {
                return this.utilidad;
            }
        }

        public double PrecioConUtilidad
        {
            set
            {
                this.precioConUtilidad = value;
            }
            get
            {
                return this.precioConUtilidad;
            }
        }

        public string CodigoDeBarras
        {
            set
            {
                this.codDeBarras = value;
            }
            get
            {
                return this.codDeBarras;
            }
        }

        public int CantidadPedida
        {
            set
            {
                this.cantidadPedida = value;
            }
            get
            {
                return this.cantidadPedida;
            }
        }

        public double Importe
        {
            set
            {
                this.importe = value;
            }
            get
            {
                return this.importe;
            }
        }

        private void AgregarCodigosDeBarrasAUnProducto()
        {
            string[] codigos;
            if(this.codDeBarras != "")
            {
                codigos = this.codDeBarras.Split(' ');
                if(codigos.Length > 1)
                {
                    foreach (string codbarras in codigos)
                    {
                        listaCodigos.Add(codbarras);
                    }
                }
            }
        }

        public string BuscarCodigo(string codBuscado)
        {
            string codEncontrado = "";
            if(codBuscado != "")
            {
                foreach(string cod in listaCodigos)
                {
                    if(codBuscado == cod)
                    {
                        codEncontrado = cod;
                    }
                }
            }
            return codEncontrado;
        }
        
        public override string ToString()
        {
            return this.Codigo + " | " + this.Descripcion + " | " + this.CantidadPedida + " * " + this.PrecioConUtilidad + " = " + this.CantidadPedida * this.PrecioConUtilidad;
        }
    }
}