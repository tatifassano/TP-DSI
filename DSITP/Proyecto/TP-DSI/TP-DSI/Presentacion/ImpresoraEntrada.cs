using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_DSI.Presentacion
{
    public partial class ImpresoraEntrada : Form
    {
        private bool acepta;
        public ImpresoraEntrada()
        {
            InitializeComponent();
        }

      
        public void imprimir(String cadena)
        {
            label2.Text = cadena;
            
        }

        public bool Acepta()
        {
            return acepta;
        }
        private void btn_ok_Click(object sender, EventArgs e)
        {
            acepta = true;
            this.Close();
        }
    }
}
