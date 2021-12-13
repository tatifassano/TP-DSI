using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DSI.Datos
{
    class Sesion
    {
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private DateTime horaFin;
        private DateTime horaInicio;
        private Usuario usuario;
        private int id_sesion;

        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public DateTime HoraFin { get => horaFin; set => horaFin = value; }
        public DateTime HoraInicio { get => horaInicio; set => horaInicio = value; }
      
        public int Id_sesion { get => id_sesion; set => id_sesion = value; }
        internal Usuario Usuario { get => usuario; set => usuario = value; }
        public Sesion(){ }
        public Sesion(int id)
        {
            id_sesion = id;


        }

        //METODOS
        // getEmpleadoEnSesion()
    }
}
