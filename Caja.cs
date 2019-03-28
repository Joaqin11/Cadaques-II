using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Libreria
{
    class Caja
    {
        private double cambio;
        private double pd;
        private double totalpd;
        private Efectivo dineroEfecivo;
        private Tarjetas creditoTarjetas;
        //private Venta registrarEnCaja;
        //private double totalCaja;

        public Caja(double cambio)
        {
            this.cambio = cambio;
            this.dineroEfecivo = new Efectivo();
            this.creditoTarjetas = new Tarjetas();
        }

        public void RegistrarVentaEnEfectivo(Venta unaVenta, double dineroRecibido)
        {
            //this.registrarEnCaja = unaVenta;
            if (unaVenta != null)
            {
                if (unaVenta.Tipo == Venta.TipoDePago.EFECTIVO)
                {
                    if (unaVenta.Total == dineroRecibido)
                    {
                        this.dineroEfecivo.TotalVentas += dineroRecibido;
                        this.dineroEfecivo.TotalEfectivo += dineroRecibido;
                        unaVenta.SuVuelto = 0;
                    }
                    else
                    {
                        if (unaVenta.Total < dineroRecibido)
                        {
                            this.dineroEfecivo.TotalVentas += dineroRecibido;

                            unaVenta.SuVuelto = dineroRecibido - unaVenta.Total;

                            this.dineroEfecivo.TotalVentas -= unaVenta.SuVuelto;
                            this.dineroEfecivo.TotalEfectivo += dineroRecibido - unaVenta.SuVuelto;
                        }
                        else
                        {
                            ErrorDeRegistroDeVenta();
                        }
                    }
                }
            }
        }

        public void RegistrarVentaEnTarjetaMaestro(Venta unaVenta)
        {
            if (unaVenta != null)
            {
                if ((unaVenta.Tipo == Venta.TipoDePago.CREDITO) | (unaVenta.Tipo == Venta.TipoDePago.DEBITO))
                {
                    this.creditoTarjetas.SumarTarjetaMaestro(unaVenta.Total);
                }
            }
        }

        public void RegistrarVentaEnTarjetaVisa(Venta unaVenta, double recargo)
        {
            if (unaVenta != null)
            {
                if ((unaVenta.Tipo == Venta.TipoDePago.CREDITO) | (unaVenta.Tipo == Venta.TipoDePago.DEBITO))
                {
                    this.creditoTarjetas.SumarTarjetaVisa(unaVenta.Total, recargo);
                }
            }
        }

        public void RegistrarVentaEnTarjetaMasterCard(Venta unaVenta, double recargo)
        {
            if (unaVenta != null)
            {
                if ((unaVenta.Tipo == Venta.TipoDePago.CREDITO) | (unaVenta.Tipo == Venta.TipoDePago.DEBITO))
                {
                    this.creditoTarjetas.SumarTarjetaMasterCard(unaVenta.Total, recargo);
                }
            }
        }

        public void RegistrarVentaEnTarjetaCabal(Venta unaVenta, double recargo)
        {
            if (unaVenta != null)
            {
                if ((unaVenta.Tipo == Venta.TipoDePago.CREDITO) | (unaVenta.Tipo == Venta.TipoDePago.DEBITO))
                {
                    this.creditoTarjetas.SumarTarjetaCabal(unaVenta.Total, recargo);
                }
            }
        }

        public void RegistrarVentaEnTarjetaNaranja(Venta unaVenta)
        {
            if (unaVenta != null)
            {
                if ((unaVenta.Tipo == Venta.TipoDePago.CREDITO) | (unaVenta.Tipo == Venta.TipoDePago.DEBITO))
                {
                    this.creditoTarjetas.SumarTarjetaNaranja(unaVenta.Total);
                }
            }
        }

        public void RegistrarVentaEnTarjetaSideCreer(Venta unaVenta)
        {
            if (unaVenta != null)
            {
                if ((unaVenta.Tipo == Venta.TipoDePago.CREDITO) | (unaVenta.Tipo == Venta.TipoDePago.DEBITO))
                {
                    this.creditoTarjetas.SumarTarjetaSidecreer(unaVenta.Total);
                }
            }
        }

        public void RegistrarVentaEnTarjetaConsuMax(Venta unaVenta)
        {
            if (unaVenta != null)
            {
                if ((unaVenta.Tipo == Venta.TipoDePago.CREDITO) | (unaVenta.Tipo == Venta.TipoDePago.DEBITO))
                {
                    this.creditoTarjetas.SumarTarjetaConsuMax(unaVenta.Total);
                }
            }
        }

        public void RegistrarVentaEnCheques(Venta unaVenta)
        {
            if (unaVenta != null)
            {
                if (unaVenta.Tipo == Venta.TipoDePago.CHEQUE)
                {

                    this.dineroEfecivo.ImporteTotalDeCheques += unaVenta.Total;
                }
            }
        }

        public void RetirarPD(double totalEfectivoRetirado, Cajero unCajero)
        {
            if (this.dineroEfecivo.TotalVentas >= totalEfectivoRetirado)
            {
                this.dineroEfecivo.TotalVentas -= totalEfectivoRetirado;
                //this.dineroEfecivo.TotalEfectivo -= totalEfectivoRetirado;
                this.pd = totalEfectivoRetirado;
                this.totalpd += totalEfectivoRetirado;
                //GenerarInforme

            }
            else
            {
                ErrorDeRetiroDePD();
            }
        }

        public string ErrorDeRegistroDeVenta()
        {
            return "No se puedo registrar la venta en la caja! Verifique el monto del dinero percibido por el cliente";
        }

        public string ErrorDeRetiroDePD()
        {
            return "El monto es mayor al dinero disponible";
        }

        public double Cambio
        {
            set
            {
                this.cambio = value;
            }
            get
            {
                return this.cambio;
            }
        }

        public double TotalRecaudado
        {
            get
            {
                return TotalVentas + TotalMutuales + TotalPD;
            }
        }

        public double TotalEfectivo
        {
            get
            {
                return this.dineroEfecivo.TotalEfectivo;
            }
        }

        public double TotalTarjetas
        {
            get
            {
                return this.creditoTarjetas.TotalTarjetas;
            }
        }

        public double TotalPD
        {
            get
            {
                return this.totalpd;
            }
        }

        public double PD
        {
            get
            {
                return this.pd;
            }
        }

        public double TotalVentas
        {
            get
            {
                return this.dineroEfecivo.TotalVentas;
            }
        }

        public void CargarMonedas(double totalM)
        {
            this.dineroEfecivo.TotalDeMonedas = totalM;
        }

        public void CargarBilletesDe2(int cant)
        {
            this.dineroEfecivo.CantidadDeBilletesDe2 = cant;
        }

        public void CargarBilletesDe5(int cant)
        {
            this.dineroEfecivo.CantidadDeBilletesDe5 = cant;
        }

        public void CargarBilletesDe10(int cant)
        {
            this.dineroEfecivo.CantidadDeBilletesDe10 = cant;
        }

        public void CargarBilletesDe20(int cant)
        {
            this.dineroEfecivo.CantidadDeBilletesDe20 = cant;
        }

        public void CargarBilletesDe50(int cant)
        {
            this.dineroEfecivo.CantidadDeBilletesDe50 = cant;
        }

        public void CargarBilletesDe100(int cant)
        {
            this.dineroEfecivo.CantidadDeBilletesDe100 = cant;
        }

        public void CargarBilletesDe200(int cant)
        {
            this.dineroEfecivo.CantidadDeBilletesDe200 = cant;
        }

        public void CargarBilletesDe500(int cant)
        {
            this.dineroEfecivo.CantidadDeBilletesDe500 = cant;
        }

        public double TotalMaestro
        {
            get
            {
                return this.creditoTarjetas.MontoTarjetaMaestro;
            }
        }

        public double TotalVisa
        {
            get
            {
                return this.creditoTarjetas.MontoTarjetaVisa;
            }
        }

        public double TotalMasterCard
        {
            get
            {
                return this.creditoTarjetas.MontoTarjetaMastercard;
            }
        }

        public double TotalCabal
        {
            get
            {
                return this.creditoTarjetas.MontoTarjetaCabal;
            }
        }

        public double TotalNaranja
        {
            get
            {
                return this.creditoTarjetas.MontoTarjetaNaranja;
            }
        }

        public double TotalSideCreer
        {
            get
            {
                return this.creditoTarjetas.MontoTarjetaSidecreer;
            }
        }

        public double TotalConsumax
        {
            get
            {
                return this.creditoTarjetas.MontoTarjetaConsumax;
            }
        }

        public double TotalRecargoVisa
        {
            get
            {
                return this.creditoTarjetas.RecargoVisa;
            }
        }

        public double TotalRecargoMasterCard
        {
            get
            {
                return this.creditoTarjetas.RecargoMastercard;
            }
        }

        public double TotalRecargoCabal
        {
            get
            {
                return this.creditoTarjetas.RecargoCabal;
            }
        }

        public double TotalRecargos
        {
            get
            {
                return TotalRecargoVisa + TotalRecargoMasterCard + TotalRecargoCabal;
            }
        }

        public double TotalMutuales
        {
            get
            {
                return TotalTarjetas - TotalRecargos;
            }
        }

        public double TotalCheques
        {
            get
            {
                return this.dineroEfecivo.ImporteTotalDeCheques;
            }
        }
    }
}
