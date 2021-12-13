using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TP_DSI.BackEnd;

namespace TP_DSI.Datos
{
    class Obra
    {
        private float ancho;
        private float alto;
        private string descripcion;
        private string codigoSensor;
        private TimeSpan duracionExtendida;
        private TimeSpan duracionResumida;
        private DateTime fechaCreacion;
        private DateTime fechaPrimerIngreso;
        private int id_obra;
        private Sesion sesion;
        private string nombreObra;
        private float peso;
        private float valuacion;


        //getters and setters
        public float Ancho { get => ancho; set => ancho = value; }
        public float Alto { get => alto; set => alto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string CodigoSensor { get => codigoSensor; set => codigoSensor = value; }
        public TimeSpan DuracionExtendida { get => duracionExtendida; set => duracionExtendida = value; }

        public TimeSpan GetDuracionResumida()
        {
           
            return duracionResumida;
        }

        public void SetDuracionResumida(TimeSpan value)
        {
            duracionResumida = value;
        }

        public DateTime FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
        public DateTime FechaPrimerIngreso { get => fechaPrimerIngreso; set => fechaPrimerIngreso = value; }
        
        public Sesion Sesion { get => sesion; set => sesion = value; }
        public string NombreObra { get => nombreObra; set => nombreObra = value; }
        public float Peso { get => peso; set => peso = value; }
        public float Valuacion { get => valuacion; set => valuacion = value; }
        public int Id_obra { get => id_obra; set => id_obra = value; }
        

       
        //Metodos
        //getDuracionResumida()

    }
}
