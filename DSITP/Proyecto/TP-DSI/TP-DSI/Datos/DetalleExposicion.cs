using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TP_DSI.BackEnd;

namespace TP_DSI.Datos
{
    class DetalleExposicion
    {
        private int id_detalleExpo;
        private List<Obra> obra;
        private string lugarAsignado;

        public int Id_detalleExpo { get => id_detalleExpo; set => id_detalleExpo = value; }

        public List<Obra> GetObra(int idDetalle)
        {
            obra = new List<Obra>();
            BE_Acceso_Datos be = new BE_Acceso_Datos();
            string consulta = "SELECT o.id_obra,o.alto,o.ancho,o.codigoSensor,o.descripcion,o.duracionExtendida,o.duracionResumida,o.fechaCreacion,o.fechaPrimerIngreso,o.id_sesion,o.nombreObra,o.peso,o.valuacion FROM  Obra o, DetalleExposicion d WHERE o.id_obra=d.id_obra and d.id_detalleExpo = '" + idDetalle +"'";
            DataTable tablaObra = new DataTable();
            tablaObra = be.consultar(consulta);
            for (int i = 0; i < tablaObra.Rows.Count; i++)
            {
                Obra nueva = new Obra();
                nueva.Id_obra = Convert.ToInt32(tablaObra.Rows[i][0]);
                nueva.Alto = (float)Convert.ToDouble(tablaObra.Rows[i][1]);
                nueva.Ancho = (float)Convert.ToDouble(tablaObra.Rows[i][2]);
                nueva.CodigoSensor=tablaObra.Rows[i][3].ToString();
                nueva.Descripcion = tablaObra.Rows[i][4].ToString();
                nueva.DuracionExtendida = (TimeSpan)tablaObra.Rows[i][5];
                nueva.SetDuracionResumida ( (TimeSpan)tablaObra.Rows[i][6]);
                nueva.FechaCreacion = (DateTime)tablaObra.Rows[i][7];
                nueva.FechaPrimerIngreso = (DateTime)tablaObra.Rows[i][8];
                nueva.NombreObra = tablaObra.Rows[i][10].ToString();
                nueva.Peso = (float)Convert.ToDouble(tablaObra.Rows[i][11]);
                nueva.Valuacion = (float)Convert.ToDouble(tablaObra.Rows[i][12]);
                obra.Add(nueva);
            }
            return obra;
        }

        public void SetObra(List<Obra> value)
        {
            obra = value;
        }

        public string LugarAsignado { get => lugarAsignado; set => lugarAsignado = value; }

        public TimeSpan buscarDuracionObras(int idDetalle)
        {
            TimeSpan duraciones= new TimeSpan();
            for (int i = 0; i < GetObra(idDetalle).Count ; i++ )
            {
                 duraciones+=GetObra(idDetalle)[i].GetDuracionResumida();
            }
            return duraciones;
        }
        //METODOS
        //buscarDuracionObras()
    }
}
