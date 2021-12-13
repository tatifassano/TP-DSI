using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TP_DSI.BackEnd;

namespace TP_DSI.Datos
{
    class Entrada
    {
        private DateTime fechaVenta;
        private TimeSpan horaVenta;
        private Sede sede;
        private Tarifa tarifa;
        private float monto;
        private int numero;
        
        public Entrada(int numero,DateTime fechaVenta,TimeSpan horaVenta,Sede sede,Tarifa tarifa, float monto)
        {
            
            this.numero = numero;
            this.fechaVenta = fechaVenta;
            this.horaVenta = horaVenta;
            this.Sede = sede;
            this.tarifa = tarifa;
            this.monto = monto;

        }
        public Entrada() { }
        public DateTime FechaVenta { get => fechaVenta; set => fechaVenta = value; }
        public TimeSpan HoraVenta { get => horaVenta; set => horaVenta = value; }
        
        public Tarifa Tarifa { get => tarifa; set => tarifa = value; }
        public float Monto { get => monto; set => monto = value; }
        public int Numero { get => numero; set => numero = value; }
        internal Sede Sede { get => sede; set => sede = value; }

        public int sonDeFechaHoraYSede(DateTime actual, int idSede)
        {
           
            BE_Acceso_Datos be = new BE_Acceso_Datos();
            string consulta = "SELECT e.fechaVenta,e.horaVenta FROM Entrada e  WHERE e.id_sede = '"+idSede+"'" ;
            DataTable tablaEntrada = new DataTable();
            tablaEntrada = be.consultar(consulta);
            
            int contador = 0;
           
                for (int i = 0; i < tablaEntrada.Rows.Count; i++)
                {
                    Entrada entrada = new Entrada();
                    entrada.fechaVenta = (DateTime)tablaEntrada.Rows[i][0];
                    if (entrada.fechaVenta.Date==actual.Date)
                    {
                    contador += 1;
                    }
                }
            return contador;
            
        }
        override
        public string ToString()
        {
            
            string cadena = "Entrada:\n";
            cadena += "Número:" + numero + " \n";
            cadena += "Fecha Venta: " + fechaVenta + " \n" ;
            cadena +="Sede: " + sede.Nombre + "\n";
            cadena += "Tarifa: " + tarifa.Id_tarifa + "\n";
            cadena += "Monto: " + monto+"\n";


            return cadena;
        }
        public int buscarUltima()
        {
            List<Entrada> listaEntradas = new List<Entrada>();
            Sede sede = new Sede();
            Tarifa tarifa = new Tarifa();
            BE_Acceso_Datos be = new BE_Acceso_Datos();
            string consulta = "SELECT e.numero FROM Entrada e ";
            DataTable tablaEntrada = new DataTable();
            tablaEntrada = be.consultar(consulta);
            int [] numero = new int [tablaEntrada.Rows.Count];
            int contador = 0;

            for (int i = 0; i < tablaEntrada.Rows.Count; i++)
            {
                numero[i] = Convert.ToInt32(tablaEntrada.Rows[i][0]);
            }
            contador = numero[(tablaEntrada.Rows.Count) - 1];
            return contador;
        }
        

        //METODOS
        //getNro()
        //new()
        //sonDeFechaHoraYSede()
    }
}
