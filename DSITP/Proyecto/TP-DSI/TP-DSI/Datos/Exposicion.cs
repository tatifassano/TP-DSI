using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TP_DSI.BackEnd;

namespace TP_DSI.Datos
{
    class Exposicion
    {
        private DateTime fechaFin;
        private DateTime fechaFinReplanificada;
        private DateTime fechaInicio;
        private DateTime fechaInicioReplanificada;
        private string horaApertura;
        private string horaCierre;
        private List<DetalleExposicion> detalleExpo;
        private int id_exposicion;
        private Sesion sesion;
        private string nombre;

        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public DateTime FechaFinReplanificada { get => fechaFinReplanificada; set => fechaFinReplanificada = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaInicioReplanificada { get => fechaInicioReplanificada; set => fechaInicioReplanificada = value; }
     
        
       
        public Sesion Sesion { get => sesion; set => sesion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Id_exposicion { get => id_exposicion; set => id_exposicion = value; }
        public string HoraApertura { get => horaApertura; set => horaApertura = value; }
        public string HoraCierre { get => horaCierre; set => horaCierre = value; }

        internal List<DetalleExposicion> GetDetalleExpo(int idExposicion)
        {
            detalleExpo = new List<DetalleExposicion>();
            BE_Acceso_Datos be = new BE_Acceso_Datos();
            string consulta = "SELECT d.id_detalleExpo,d.lugarAsignado,d.id_obra FROM  Exposicion e , DetalleExposicion d WHERE e.id_detalleExpo = d.id_detalleExpo AND e.id_detalleExpo = '"+idExposicion+"'";
            DataTable tablaDetalle = new DataTable();
            tablaDetalle = be.consultar(consulta);
            for (int i = 0; i < tablaDetalle.Rows.Count; i++)
            {
                DetalleExposicion detalle = new DetalleExposicion();
                detalle.Id_detalleExpo = Convert.ToInt32(tablaDetalle.Rows[i][0]);
                detalle.LugarAsignado = tablaDetalle.Rows[i][1].ToString();
                detalle.GetObra(Convert.ToInt32(tablaDetalle.Rows[i][0]));
                detalleExpo.Add(detalle);
                    }
            return detalleExpo;
        }

        internal void SetDetalleExpo(List<DetalleExposicion> value)
        {
            detalleExpo = value;
        }

        public bool esVigente()
        {
            if(fechaFin>DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public TimeSpan calcularDuracionObrasExpuestas()
        {
            int n=0;
            TimeSpan duracionTotal = new TimeSpan();
                while (n < detalleExpo.Count)
            {
                duracionTotal += detalleExpo[n].buscarDuracionObras(detalleExpo[n].Id_detalleExpo);

                n++;
            }
            return duracionTotal;
        }



        //METODOS
        //calcularDuracionObrasExpuestas()
        //esVigente()
    }
}
