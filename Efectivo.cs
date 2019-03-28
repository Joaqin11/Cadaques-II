using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Libreria
{
    class Efectivo
    {
        //public enum TipoDeEfectivo { MONEDAS, BILLETESDE2, BILLETESDE5, BILLETESDE10, BILLETESDE20, BILLETESDE50, BILLETESDE100, BILLETESDE200, BILLETESDE500 };
        private int cantMonedas;
        private double totaldeMonedas;
        private int cantbilletesde2;
        private int cantbilletesde5;
        private int cantbilletesde10;
        private int cantbilletesde20;
        private int cantbilletesde50;
        private int cantbilletesde100;
        private int cantbilletesde200;
        private int cantbilletesde500;
        private static int cantcheques;
        private double importecheques;
        private double totalEfectivo;
        private double totalVentas;

        public Efectivo(int cantMonedas, double totaldeMonedas, int cantbilletesde2, int cantbilletesde5, int cantbilletesde10, int cantbilletesde20, int cantbilletesde50, int cantbilletesde100, int cantbilletesde200, int cantbilletesde500)
        {
            this.cantMonedas = cantMonedas;
            this.totaldeMonedas = totaldeMonedas;
            this.cantbilletesde2 = cantbilletesde2;
            this.cantbilletesde5 = cantbilletesde5;
            this.cantbilletesde10 = cantbilletesde10;
            this.cantbilletesde20 = cantbilletesde20;
            this.cantbilletesde50 = cantbilletesde50;
            this.cantbilletesde100 = cantbilletesde100;
            this.cantbilletesde200 = cantbilletesde200;
            this.cantbilletesde500 = cantbilletesde500;
        }

        public Efectivo()
        {
            //vacio
        }

        public int CantidadDeMonedas
        {
            set
            {
                this.cantMonedas = value;
            }
            get
            {
                return this.cantMonedas;
            }
        }

        public double TotalDeMonedas
        {
            set
            {
                this.totaldeMonedas = value;
            }
            get
            {
                return this.totaldeMonedas;
            }
        }

        public int CantidadDeBilletesDe2
        {
            set
            {
                this.cantbilletesde2 = value;
            }
            get
            {
                return this.cantbilletesde2;
            }
        }

        public int ImporteDeBilletes2
        {

            get
            {
                return this.CantidadDeBilletesDe2 * 2;
            }
        }

        public int CantidadDeBilletesDe5
        {
            set
            {
                this.cantbilletesde5 = value;
            }
            get
            {
                return this.cantbilletesde5;
            }
        }

        public int ImporteDeBilletes5
        {

            get
            {
                return this.CantidadDeBilletesDe5 * 5;
            }
        }

        public int CantidadDeBilletesDe10
        {
            set
            {
                this.cantbilletesde10 = value;
            }
            get
            {
                return this.cantbilletesde10;
            }
        }

        public int ImporteDeBilletes10
        {

            get
            {
                return this.CantidadDeBilletesDe10 * 10;
            }
        }

        public int CantidadDeBilletesDe20
        {
            set
            {
                this.cantbilletesde20 = value;
            }
            get
            {
                return this.cantbilletesde20;
            }
        }

        public int ImporteDeBilletes20
        {

            get
            {
                return this.CantidadDeBilletesDe20 * 20;
            }
        }

        public int CantidadDeBilletesDe50
        {
            set
            {
                this.cantbilletesde50 = value;
            }
            get
            {
                return this.cantbilletesde50;
            }
        }

        public int ImporteDeBilletes50
        {

            get
            {
                return this.CantidadDeBilletesDe50 * 50;
            }
        }

        public int CantidadDeBilletesDe100
        {
            set
            {
                this.cantbilletesde100 = value;
            }
            get
            {
                return this.cantbilletesde100;
            }
        }

        public int ImporteDeBilletes100
        {

            get
            {
                return this.CantidadDeBilletesDe100 * 100;
            }
        }

        public int CantidadDeBilletesDe200
        {
            set
            {
                this.cantbilletesde200 = value;
            }
            get
            {
                return this.cantbilletesde200;
            }
        }

        public int ImporteDeBilletes200
        {

            get
            {
                return this.CantidadDeBilletesDe200 * 200;
            }
        }

        public int CantidadDeBilletesDe500
        {
            set
            {
                this.cantbilletesde500 = value;
            }
            get
            {
                return this.cantbilletesde500;
            }
        }

        public int ImporteDeBilletes500
        {

            get
            {
                return this.CantidadDeBilletesDe500 * 500;
            }
        }

        public static int CantidadDeCheques
        {
            get
            {
                return cantcheques;
            }
        }

        public double ImporteTotalDeCheques
        {
            set
            {
                this.importecheques = value;
                cantcheques++;
            }
            get
            {
                return this.importecheques;
            }
        }

        public double TotalVentas
        {
            set
            {
                this.totalVentas = value;
            }
            get
            {
                return this.totalVentas;
            }
        }

        public double TotalEfectivoBilletes
        {
            get
            {
                return TotalDeMonedas + ImporteDeBilletes2 + ImporteDeBilletes5 + ImporteDeBilletes10 + ImporteDeBilletes20 + ImporteDeBilletes50 + ImporteDeBilletes100 + ImporteDeBilletes200 + ImporteDeBilletes500;
            }
        }

        public double TotalEfectivo
        {
            set
            {
                this.totalEfectivo = value;
            }
            get
            {
                return this.totalEfectivo;
            }
        }
    }
}