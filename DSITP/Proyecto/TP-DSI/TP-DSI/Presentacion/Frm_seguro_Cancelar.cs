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
    public partial class Frm_seguro_Cancelar : Form
    {
        private bool acepta;
        public Frm_seguro_Cancelar()
        {
            InitializeComponent();
        }

        public bool Acepta { get => acepta; set => acepta = value; }

        private void btn_SI_Click(object sender, EventArgs e)
        {
            acepta = true;
            this.Close();
        }

        private void btn_NO_Click(object sender, EventArgs e)
        {
            acepta = false;
            this.Close();
        }
    }
}
