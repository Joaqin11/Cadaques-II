using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Libreria
{
    class Tarjetas
    {
        public enum tipoDeTarjeta { MAESTRO, VISA, MASTERCARD, CABAL, NARANJA, SIDECREER, CONSUMAX }
        //private tipoDeTarjeta tipo;
        private double maestro;
        private double visa;
        private double mastercard;
        private double cabal;
        private double naranja;
        private double sidecreer;
        private double consumax;
        private double recargoVisa;
        private double recargoMastercard;
        private double recargoCabal;
        private double totaltarjetas;

        public Tarjetas()
        {
            this.maestro = 0;
            this.visa = 0;
            this.mastercard = 0;
            this.cabal = 0;
            this.naranja = 0;
            this.sidecreer = 0;
            this.consumax = 0;
        }

        public double MontoTarjetaMaestro
        {
            get
            {
                return this.maestro;
            }
        }

        public double MontoTarjetaVisa
        {
            get
            {
                return this.visa;
            }
        }

        public double MontoTarjetaMastercard
        {
            get
            {
                return this.mastercard;
            }
        }

        public double MontoTarjetaCabal
        {
            get
            {
                return this.cabal;
            }
        }

        public double MontoTarjetaNaranja
        {
            get
            {
                return this.naranja;
            }
        }

        public double MontoTarjetaSidecreer
        {
            get
            {
                return this.sidecreer;
            }
        }

        public double MontoTarjetaConsumax
        {
            get
            {
                return this.consumax;
            }
        }

        public double RecargoVisa
        {
            set
            {
                this.recargoVisa = value;
            }

            get
            {
                return this.recargoVisa;
            }
        }

        public double RecargoMastercard
        {
            set
            {
                this.recargoMastercard = value;
            }

            get
            {
                return this.recargoMastercard;
            }
        }

        public double RecargoCabal
        {
            set
            {
                this.recargoCabal = value;
            }
            get
            {
                return this.recargoCabal;
            }
        }

        public void SumarTarjetaMaestro(double monto)
        {
            //no es necesario hacer la verificacion!
            this.maestro += monto;
            TotalTarjetas += MontoTarjetaMaestro;
        }

        public void SumarTarjetaVisa(double monto, double recargo)
        {
            //aplicar recargo
            if (recargo > 0 && recargo < 1)
            {
                RecargoVisa += recargo * monto;
            }
            else
            {
                recargo /= 100;
                RecargoVisa += recargo * monto;
            }
            this.visa += monto;
            TotalTarjetas += monto;//MontoTarjetaVisa;            
        }

        public void SumarTarjetaMasterCard(double monto, double recargo)
        {
            //aplicar recargo
            if (recargo > 0 && recargo < 1)
            {
                RecargoMastercard += recargo * monto;
            }
            else
            {
                recargo /= 100;
                RecargoMastercard += recargo * monto;
            }
            this.mastercard += monto;
            TotalTarjetas += MontoTarjetaMastercard;
        }

        public void SumarTarjetaCabal(double monto, double recargo)
        {
            //aplicar recargo
            if (recargo > 0 && recargo < 1)
            {
                RecargoCabal += recargo * monto;
            }
            else
            {
                recargo /= 100;
                RecargoCabal += recargo * monto;
            }
            this.cabal += monto;
            TotalTarjetas += MontoTarjetaCabal;

        }

        public void SumarTarjetaNaranja(double monto)
        {
            this.naranja += monto;
            TotalTarjetas += MontoTarjetaNaranja;
        }

        public void SumarTarjetaSidecreer(double monto)
        {
            this.sidecreer += monto;
            TotalTarjetas += MontoTarjetaSidecreer;
        }

        public void SumarTarjetaConsuMax(double monto)
        {
            this.consumax += monto;
            TotalTarjetas += MontoTarjetaConsumax;
        }

        public double TotalTarjetas
        {
            set
            {
                this.totaltarjetas = value;
            }
            get
            {
                return this.totaltarjetas;//arreglado
            }
        }
    }
}