using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TP_DSI.BackEnd;
namespace TP_DSI.Datos
{
    class Sede
    {
        private int cantMaximaVisitantes;
        private int cantMaxPorGuia;
        private int id_empleado;
        private int id_sede;
        private int id_tarifa;
        private string nombre;
        private List<Exposicion> exposicion;

        public int GetCantMaximaVisitantes()
        {
            return cantMaximaVisitantes;
        }

        public void SetCantMaximaVisitantes(int value)
        {
            cantMaximaVisitantes = value;
        }

        public int CantMaxPorGuia { get => cantMaxPorGuia; set => cantMaxPorGuia = value; }
        public int Id_empleado { get => id_empleado; set => id_empleado = value; }
        public int Id_sede { get => id_sede; set => id_sede = value; }
        public int Id_tarifa { get => id_tarifa; set => id_tarifa = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        internal List<Exposicion> GetExposicion()
        {
            BE_Acceso_Datos be = new BE_Acceso_Datos();
            string consulta = "SELECT * FROM Exposicion";
            DataTable tablaExpo = new DataTable();
            tablaExpo = be.consultar(consulta);
            exposicion = new List<Exposicion>();
            Exposicion expo = new Exposicion();
            if (tablaExpo.Rows.Count > 0)
            {
                for (int i = 1 ; i < tablaExpo.Rows.Count; i++)

                {
                    expo.Id_exposicion = Convert.ToInt32(tablaExpo.Rows[i][0]);
                    expo.FechaFin = (DateTime)tablaExpo.Rows[i][1];
                    expo.FechaInicio = (DateTime)tablaExpo.Rows[i][3];
                    expo.HoraApertura = tablaExpo.Rows[i][5].ToString();
                    expo.HoraCierre = tablaExpo.Rows[i][6].ToString();
                    expo.GetDetalleExpo(Convert.ToInt32(tablaExpo.Rows[i][0]));
                    expo.Sesion = new Sesion(Convert.ToInt32(tablaExpo.Rows[i][8]));
                    exposicion.Add(expo);
                    
                }   
                return exposicion;
            }
            else
            {
                return null;
            }
        }

        internal void SetExposicion(List<Exposicion> value)
        {
            exposicion = value;
        }

        public List<Tarifa> obtenerTarifasVigentes()
        {
           
            BE_Acceso_Datos be = new BE_Acceso_Datos();
            string consulta = "SELECT t.id_tarifa,t.fechaFinVigencia,t.fechaInicioVigencia,t.monto,t.montoTipoEntrada,t.id_tipoEntrada,t.id_tipoVisita FROM TarifasXSede tf, Tarifa t where tf.id_Tarifa=t.id_tarifa and id_Sede= '" + id_sede + "'";
            DataTable tablaTarifa = new DataTable();
            tablaTarifa = be.consultar(consulta);

            if (tablaTarifa.Rows.Count > 0)
            {
                List<Tarifa> tarifalist = new List<Tarifa>();
                Tarifa [] tarifa = new Tarifa[tablaTarifa.Rows.Count];
                TipoDeEntrada tipoDeEntrada= new TipoDeEntrada();
                TipoVisita tipoVisita = new TipoVisita();
                for (int i = 0; i < tablaTarifa.Rows.Count; i++)
                {
                    tarifa[i] = new Tarifa();
                    int id=(int)Convert.ToInt32(tablaTarifa.Rows[i][0]);
                    tarifa[i].Id_tarifa = id;
                    tarifa[i].FechaFinVigencia = (DateTime)tablaTarifa.Rows[i][1];
                    tarifa[i].FechaInicioVigencia = (DateTime)tablaTarifa.Rows[i][2];
                    tarifa[i].Monto = (float)Convert.ToDouble(tablaTarifa.Rows[i][3]);
                    tarifa[i].MontoTipoEntrada = (float)Convert.ToDouble(tablaTarifa.Rows[i][4]);
                    tarifa[i].TipoEntrada=tipoDeEntrada.obtenerTipoEntrada(Convert.ToInt32(tablaTarifa.Rows[i][5]));
                    tarifa[i].TipoVisita = tipoVisita.obtenerTipoVisita(Convert.ToInt32(tablaTarifa.Rows[i][6]));
                    if (tarifa[i].FechaFinVigencia > DateTime.Now)
                    {
                        if (tarifa[i].FechaInicioVigencia <= DateTime.Now)
                        {
                            tarifalist.Add(tarifa[i]);
                        }
                    }
                }

                return tarifalist;
            }
            else
            {
                return null;
            }
            
        }
        
        public List<Exposicion> calcularDuracionAExposicionesVigentes()
        {
            int n=0;
            while (n < GetExposicion().Count)
            {
                exposicion[n].esVigente();
                exposicion[n].calcularDuracionObrasExpuestas();
                n++;
            }
            return exposicion;
        }
        public Sede obtenerSede(int id)
        {
            Sede sede = new Sede();
            BE_Acceso_Datos be = new BE_Acceso_Datos();
            string consulta = "SELECT * FROM Sede WHERE id_sede= '" + id + "' ";
            DataTable tablaEntrada = new DataTable();
            tablaEntrada = be.consultar(consulta);
            if (tablaEntrada.Rows.Count > 0)
            {
                sede.Id_sede = Convert.ToInt32(tablaEntrada.Rows[0][0]);
                sede.cantMaximaVisitantes = Convert.ToInt32(tablaEntrada.Rows[0][1]);
                sede.cantMaxPorGuia = Convert.ToInt32(tablaEntrada.Rows[0][2]);
                sede.nombre = tablaEntrada.Rows[0][3].ToString();
              

            }
            return sede;
        }
        //METODOS
        //calcularDuracionAExposicionesVigentes()
        //mostrarCantidadMaximaVisitantes()
        //obtenerTarifasVigentes()
    }
}
