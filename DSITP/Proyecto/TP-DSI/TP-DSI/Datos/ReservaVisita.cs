using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TP_DSI.BackEnd;
namespace TP_DSI.Datos
{
    class ReservaVisita
    {
        private int cantidadAlumnos;
        private int cantidadAlumnosConfirmada;
        private DateTime duracionEstimada;
        private DateTime fechaHoraCreacion;
        private DateTime fechaHoraReserva;
        private DateTime horaFinReal;
        private DateTime horarioReal;
        private Empleado empleado;
        private Exposicion exposicion;
        private int id_reservaVisita;

        public int CantidadAlumnos { get => cantidadAlumnos; set => cantidadAlumnos = value; }
        public int CantidadAlumnosConfirmada { get => cantidadAlumnosConfirmada; set => cantidadAlumnosConfirmada = value; }
        public DateTime DuracionEstimada { get => duracionEstimada; set => duracionEstimada = value; }
        public DateTime FechaHoraCreacion { get => fechaHoraCreacion; set => fechaHoraCreacion = value; }
        public DateTime FechaHoraReserva { get => fechaHoraReserva; set => fechaHoraReserva = value; }
        public DateTime HoraFinReal { get => horaFinReal; set => horaFinReal = value; }
        public DateTime HorarioReal { get => horarioReal; set => horarioReal = value; }

        public int Id_reservaVisita { get => id_reservaVisita; set => id_reservaVisita = value; }
        internal Empleado Empleado { get => empleado; set => empleado = value; }
        internal Exposicion Exposicion { get => exposicion; set => exposicion = value; }

        public int sonParaFechaHoraYSede(DateTime actual, int idSede)
        {
            int cantidad = 0;
            ReservaVisita reserva = new ReservaVisita();
            DateTime fecha = new DateTime();
            BE_Acceso_Datos be = new BE_Acceso_Datos();
            string consulta = "SELECT r.cantidadAlumnos,r.cantidadAlumnosConfirmada, r.fechaHoraReserva FROM ReservaVisita r, Sede s, Exposicion e WHERE r.id_exposicion=e.id_exposicion AND s.id_sede= '" + idSede + "'";
            DataTable tablaReservas = new DataTable();
            tablaReservas = be.consultar(consulta);
            for (int i = 0; i < tablaReservas.Rows.Count; i++)
            {
                fecha = (DateTime)tablaReservas.Rows[i][2];
                if (actual.ToLongDateString() == fecha.ToLongDateString())
                {
                    reserva.CantidadAlumnos = Convert.ToInt32(tablaReservas.Rows[i][0]);
                    reserva.cantidadAlumnosConfirmada = Convert.ToInt32(tablaReservas.Rows[i][1]);
                    reserva.fechaHoraReserva = (DateTime)tablaReservas.Rows[i][2];
                    cantidad += reserva.cantidadAlumnosConfirmada;
                }

            }
            return cantidad;

            //METODOS
            //sonParaFechaHoraYSede()
        }
    }
}
