using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_DSI.Datos;
using TP_DSI.Negocio;


namespace TP_DSI.Presentacion
{
    public partial class PantallaSala : Form,IObservador
    {
        public PantallaSala()
        {
            InitializeComponent();
        }

        public void actualizarCantVisitantes(int cantEntradasAEmitir, int cantMaximaVisitantes) {
            mostrarVisitantesYTotalEnSede(cantEntradasAEmitir, cantMaximaVisitantes);
        }
        public void mostrarVisitantesYTotalEnSede(int cantEntradasAEmitir, int cantMaximaVisitantes)
        {
            label3.Text = cantEntradasAEmitir.ToString();
            label4.Text = cantMaximaVisitantes.ToString();

        }

    }
}
