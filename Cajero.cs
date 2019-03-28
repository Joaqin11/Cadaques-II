using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Libreria
{
    class Cajero
    {
        private string nom;
        private string ap;
        private int numeroDeCaja;
        private string razonSocial;
        private int sucursal;
        private string direccion;
        private string tel;

        public Cajero(string nom, string ap, int numeroDeCaja, string razonSocial, int sucursal, string direccion, string tel)
        {
            this.nom = nom;
            this.ap = ap;
            this.numeroDeCaja = numeroDeCaja;
            this.razonSocial = razonSocial;
            this.sucursal = sucursal;
            this.direccion = direccion;
            this.tel = tel;
        }

        public string Nombre
        {
            set
            {
                this.nom = value;
            }
            get
            {
                return this.nom;
            }
        }

        public string Apellido
        {
            set
            {
                this.ap = value;
            }
            get
            {
                return this.ap;
            }
        }

        public int NumeroDeCaja
        {
            set
            {
                this.numeroDeCaja = value;
            }
            get
            {
                return this.numeroDeCaja;
            }
        }

        public string RazonSocial
        {
            set
            {
                this.razonSocial = value;
            }
            get
            {
                return this.razonSocial;
            }
        }

        public int Sucursal
        {
            set
            {
                this.sucursal = value;
            }
            get
            {
                return this.sucursal;
            }
        }

        public string Direccion
        {
            set
            {
                this.direccion = value;
            }
            get
            {
                return this.direccion;
            }
        }

        public string Telefono
        {
            set
            {
                this.tel = value;
            }
            get
            {
                return this.tel;
            }
        }
    }
}
