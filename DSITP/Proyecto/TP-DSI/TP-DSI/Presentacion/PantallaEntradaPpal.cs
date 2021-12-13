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
    public partial class PantallaEntradaPpal : Form, IObservador
    {
        public PantallaEntradaPpal()
        {
            InitializeComponent();
        }

        private void PantallaEntradaPpal_Load(object sender, EventArgs e)
        {

        }
       public void actualizarCantVisitantes(int cantVisitantesEnSala, int cantMaximaVisitantes)
        {
            mostrarVisitantesYTotalEnSede(cantVisitantesEnSala, cantMaximaVisitantes);

        }
       public void mostrarVisitantesYTotalEnSede(int cantVisitantesEnSala, int cantMaximaVisitantes)
        {
            label3.Text = cantVisitantesEnSala.ToString();
            label4.Text = cantMaximaVisitantes.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
