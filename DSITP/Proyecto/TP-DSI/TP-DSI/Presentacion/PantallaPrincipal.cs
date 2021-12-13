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
    public partial class PantallaPrincipal : Form
    {
        GestorVentaEntrada gestor =new GestorVentaEntrada();
        List<Tarifa> tarifas;
       public PantallaPrincipal()
        {
            InitializeComponent();
            btnConfirmar.Enabled = false;
            txtEntradas.Enabled = false;
            cmbGuia.Enabled = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            
            
        }

        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {
            
            PantallaLogin login = new PantallaLogin();
            login.ShowDialog();
            lblUsuario.Text = gestor.ventaEntrada(login).Nombre;//comienzo caso de uso
            lblSede.Text = "Sede: " + gestor.buscarSede().Nombre;
            tarifas = gestor.buscarTarifaDeSede();// busca la tarifas de una sede
            if (tarifas.Count != 0)
            {
                MostrarTarifaVigente();
                lblIsntrucciones.Text ="Seleccione Una Tarifa: ";
                dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
                dataGridView1.MultiSelect = false;
                lblEstado.Text = "Esperando Selección de Tarifa....";

            }
            else {
                lblIsntrucciones.Text = "No Hay Tarifas Vigentes! ";
                btnConfirmar.Enabled = false;
                
            }
           
            
        }
        public void MostrarTarifaVigente()
        {//muestra las tarifas de la sede en una grilla
            for (int i = 0; i < tarifas.Count; i++)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = tarifas[i].Id_tarifa;
                dataGridView1.Rows[n].Cells[1].Value = tarifas[i].Monto;
                dataGridView1.Rows[n].Cells[2].Value = tarifas[i].TipoEntrada.Nombre;
                dataGridView1.Rows[n].Cells[3].Value = tarifas[i].TipoVisita.Nombre;
                
            }
            

        }

      

        

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            Frm_Seguro seguro = new Frm_Seguro();
            seguro.ShowDialog();
            if (seguro.Acepta)
            {
                lblEstado.Text = "Entradas Impresas...";
                gestor.tomarConfirmacion();//toma confirmacion para generar entrada
                this.Close();
                
            }
            
           
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Frm_seguro_Cancelar seguro = new Frm_seguro_Cancelar();
            seguro.ShowDialog();
            if (seguro.Acepta)
            {
                this.Close();//cancela el caso de uso 
            }
        }

       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            _ = e.RowIndex;

            int idTarifa = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            
            gestor.tomarTarifasSeleccionadas(idTarifa);//pasa la seleccion de tarifa al gestor

            lblIsntrucciones.Text = "Seleccione Si Prefiere Guía ...";
            lblEstado.Text = "Esperando Selección de Guía...";
            cmbGuia.Enabled = true;
        }


        private void txtEntradas_KeyPress(object sender, KeyPressEventArgs e)
        {
        
        
    }

        private void cmbGuia_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cmbGuia_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblIsntrucciones.Text = "Ingrese Cantidad de Entradas ...";//solicita seleccion de cantidad de entradas
            lblEstado.Text = "Esperando Ingreso de Cantidad de Entradas....";
            txtEntradas.Enabled = true;
        }

        private void txtEntradas_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txtEntradas.Text != "")
                {

                    if ((Convert.ToInt32(txtEntradas.Text) > 0) && (Convert.ToInt32(txtEntradas.Text) < 6))
                    {

                        btnConfirmar.Enabled = true;
                        int cantidadEntradas = Convert.ToInt32(txtEntradas.Text.ToString());
                        cantidadEntradas.ToString();
                        double monto = gestor.cantidadEntradasAEmitir(cantidadEntradas);//pasa la cantidad de entradas al gestor
                        lblMonto.Text = "Total: " + monto.ToString(); //muestra el monto total
                        lblDetalle.Text = gestor.mostrarDetalleEntrada();// muestra el detalle de la entrada
                        lblIsntrucciones.Text = "Confirme la Cantidad de Entradas..";
                        lblEstado.Text = "Esperando Confirmación de Generación de Entrada";//Solicita
                    }
                    else
                    {
                        lblIsntrucciones.Text = "Ingrese Una Cantidad Entre 1 y 5 !... ";
                    }
                }
                else
                {
                    lblIsntrucciones.Text = "No Ha Ingresado Cantidad de Entradas ";
                }
            }
        }
    }
}
