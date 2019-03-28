using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;

namespace Libreria
{
    class CargaDeDatos
    {
        private string[] nombresColumnas;
        private Articulo unArticulo;
        private ListaDePrecios unaLista;
        private AutoCompleteStringCollection autoCompleteCodigo;
        private AutoCompleteStringCollection autoCompleteNombre;

        public CargaDeDatos()
        {
            unaLista = new ListaDePrecios();
            autoCompleteCodigo = new AutoCompleteStringCollection();
            autoCompleteNombre = new AutoCompleteStringCollection();
        }

        public void AbrirCSV(string csv)
        {
            string des = "", empaquetado = "",codDeBarras = "";
            int cod; 
            double precioSinIVA = 0, precioConIVA = 0, utilidad = 0, precioConUtilidad = 0;

            int cont = 0;
            string linea;
            string[] col;
            StreamReader sr = new StreamReader(csv);
            linea = sr.ReadLine();

            while(linea != null && linea != ";;;;;;;;;;")
            {
                col = linea.Split(';');
                if(cont == 0)
                {
                    nombresColumnas = col;
                }
                if(cont > 0)
                {
                    if (col[0] != "")
                    {
                        cod = Convert.ToInt32(col[0]);
                        autoCompleteCodigo.Add(cod.ToString());
                    }
                    else
                    {
                        cod = -1;
                    }

                    if(col[1] != "")
                    {
                        des = col[1];
                        autoCompleteNombre.Add(des);
                    }
                    else
                    {
                        des = "";
                    }

                    if (col[2] != "")
                    {
                        empaquetado = col[2];
                    }
                    else
                    {
                        empaquetado = "";
                    }


                    if (col[3] != "")
                    {
                        precioSinIVA = Convert.ToDouble(col[3]);
                    }
                    else
                    {
                        precioSinIVA = -1;
                    }

                    if (col[4] != "")
                    {
                        precioConIVA = Convert.ToDouble(col[4]);
                    }
                    else
                    {
                        precioConIVA = -1;
                    }

                    if (col[5] != "")
                    {
                        utilidad = Convert.ToDouble(col[5]);
                    }
                    else
                    {
                        utilidad = -1;
                    }
                    
                    if (col[6] != "")
                    {
                        precioConUtilidad = Convert.ToDouble(col[6]);
                    }
                    else
                    {
                        precioConUtilidad = -1;
                    }

                    if (col[7] != "")
                    {
                        codDeBarras = col[7];
                    }
                    else
                    {
                        codDeBarras = "";
                    }


                    if((this.unaLista != null) && (this.unArticulo == null))
                    {
                        unArticulo = new Articulo(cod, des, empaquetado, precioSinIVA, precioConIVA, utilidad, precioConUtilidad, codDeBarras);
                        if(this.unArticulo != null)
                        {
                            this.unaLista.AgregarArticulo(this.unArticulo);
                            this.unArticulo = null;
                        }
                    }
                }
                cont++;
                linea = sr.ReadLine();
            }
            sr.Close();
        }

        public void ObtenerNombresColumnas()
        {
            unaLista.CargarNombresColumnas(nombresColumnas);
        }

        public ListView Mostrar(ListView listView1)
        {
            return unaLista.CargarListView(listView1);
        }

        public ArrayList getListaArticulos()
        {
            return unaLista.getListaArticulos();
        }

        public string[] getNombresCol()
        {
            return unaLista.getNombresColumnas();
        }

        public AutoCompleteStringCollection getAutoCompleteCodigos()
        {
            return autoCompleteCodigo;
        }

        public AutoCompleteStringCollection getAutoCompleteNombres()
        {
            return autoCompleteNombre;
        }
    }
}
