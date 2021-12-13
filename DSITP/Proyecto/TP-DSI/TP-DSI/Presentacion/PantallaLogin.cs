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

namespace TP_DSI.Presentacion
{
    public partial class PantallaLogin : Form
    {
        Usuario usuario = new Usuario();

        internal Usuario Usuario { get => usuario; set => usuario = value; }

        public PantallaLogin()
        {
            InitializeComponent();
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            usuario.Nombre = txt_usuario.Text;
            usuario.Contraseña = txt_contraseña.Text;
            Empleado empleado = new Empleado();
            empleado= usuario.obtenerEmpleado(usuario.Nombre, usuario.Contraseña);

            string msj = "";

            if(empleado != null)
            {
                msj = "OK";
                MessageBox.Show(msj, "Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                msj = "Incorrecto";
                MessageBox.Show(msj, "No Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
