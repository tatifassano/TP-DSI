using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TP_DSI.BackEnd;
namespace TP_DSI.Datos
{
    class TipoVisita
    {
        private int id_tipoVisita;
        private string nombre;

        public int Id_tipoVisita { get => id_tipoVisita; set => id_tipoVisita = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public TipoVisita obtenerTipoVisita(int idTipoVisita)
        {
            TipoVisita tipo = new TipoVisita();
            BE_Acceso_Datos be = new BE_Acceso_Datos();
            string consulta = "SELECT * FROM TipoVisita WHERE id_tipoVisita = '" + idTipoVisita + "'";
            DataTable tablaTipoVisita = new DataTable();
            tablaTipoVisita = be.consultar(consulta);
            tipo.id_tipoVisita = Convert.ToInt32(tablaTipoVisita.Rows[0][0]);
            tipo.nombre = (string)tablaTipoVisita.Rows[0][1];
            return tipo;
        }
        //METODOS
        //mostrarNombre()
    }
}
