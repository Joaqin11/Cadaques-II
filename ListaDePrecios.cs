using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Libreria
{
    class ListaDePrecios
    {
        private ArrayList listaDeArticulos;
        private Articulo unArticulo;
        private string[] nombresColumnas;

        public ListaDePrecios()
        {
            this.listaDeArticulos = new ArrayList();
        }

        public void AgregarArticulo(Articulo unArticulo)
        {
            listaDeArticulos.Add(unArticulo);
        }

        public ListView CargarListView(ListView unListView1)
        {
            int cont = 0;
            if(this.listaDeArticulos.Count != 0)
            {
                unListView1.View = System.Windows.Forms.View.Details;
                unListView1.GridLines = true;
                unListView1.FullRowSelect = true;

                unListView1.Columns.Clear();
                unListView1.Items.Clear();

                if(this.nombresColumnas != null && this.nombresColumnas.Length != 0)
                {
                    foreach(string col in nombresColumnas)
                    {
                        if (cont <= 7)
                        {
                            unListView1.Columns.Add(col, 100);
                        }
                        else
                        {
                            break;
                        }
                        cont++;
                    }
                    unListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }

                foreach (Articulo art in this.listaDeArticulos)
                {
                    ListViewItem listViewItem = new ListViewItem(art.Codigo.ToString());

                    listViewItem.SubItems.Add(art.Descripcion);
                    listViewItem.SubItems.Add(art.Empaquetado);
                    listViewItem.SubItems.Add(art.PrecioSinIVA.ToString());
                    listViewItem.SubItems.Add(art.PrecioConIVA.ToString());
                    listViewItem.SubItems.Add(art.Utilidad.ToString());
                    listViewItem.SubItems.Add(art.PrecioConUtilidad.ToString());

                    listViewItem.SubItems.Add(art.CodigoDeBarras);

                    unListView1.Items.Add(listViewItem);
                }
            }
            return unListView1;
        }

        public void CargarNombresColumnas(string[] col)
        {
            this.nombresColumnas = col;
        }

        public ArrayList getListaArticulos()
        {
            return this.listaDeArticulos;
        }

        public string[] getNombresColumnas()
        {
            return this.nombresColumnas;
        }
    }
}
