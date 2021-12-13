using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TP_DSI.BackEnd;

namespace TP_DSI.Datos
{
    class Tarifa
    {
        private DateTime fechaFinVigencia;
        private DateTime fechaInicioVigencia;
        private int id_tarifa;
        private TipoDeEntrada tipoEntrada;
        private TipoVisita tipoVisita;
        private float monto;
        private float montoTipoEntrada;

        public DateTime FechaFinVigencia { get => fechaFinVigencia; set => fechaFinVigencia = value; }
        public DateTime FechaInicioVigencia { get => fechaInicioVigencia; set => fechaInicioVigencia = value; }
        public int Id_tarifa { get => id_tarifa; set => id_tarifa = value; }
        public TipoDeEntrada TipoEntrada { get => tipoEntrada; set => tipoEntrada = value; }
        public TipoVisita TipoVisita { get => tipoVisita; set => tipoVisita = value; }
        public float Monto { get => monto; set => monto = value; }
        public float MontoTipoEntrada { get => montoTipoEntrada; set => montoTipoEntrada = value; }
        public Tarifa mostrartarifa(int id)
        {
            Tarifa tarifa = new Tarifa();
            BE_Acceso_Datos be = new BE_Acceso_Datos();
            string consulta = "SELECT * FROM Tarifa WHERE id_tarifa= '" + id + "' ";
            DataTable tablaEntrada = new DataTable();
            tablaEntrada = be.consultar(consulta);
            if (tablaEntrada.Rows.Count > 0)
            {
                tarifa.Id_tarifa = Convert.ToInt32(tablaEntrada.Rows[0][0]);
                tarifa.FechaFinVigencia = (DateTime)tablaEntrada.Rows[0][1];
                tarifa.fechaInicioVigencia = (DateTime)tablaEntrada.Rows[0][2];
                tarifa.monto = (float)Convert.ToDouble(tablaEntrada.Rows[0][3]);
                tarifa.montoTipoEntrada = (float)Convert.ToDouble(tablaEntrada.Rows[0][4]);

                //falta traer tipo entrada
                //tipo visita
            }
            return tarifa;
            //METODOS
            //mostrarMontosVigentes()
        }
    }
}
