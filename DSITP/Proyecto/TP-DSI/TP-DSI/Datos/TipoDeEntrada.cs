using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TP_DSI.BackEnd;
namespace TP_DSI.Datos
{
    class TipoDeEntrada
    {
        private int id_tipoEntrada;
        private string nombre;

        public int Id_tipoEntrada { get => id_tipoEntrada; set => id_tipoEntrada = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public TipoDeEntrada obtenerTipoEntrada(int idTipoEntrada)
        {
            TipoDeEntrada tipo = new TipoDeEntrada();
            BE_Acceso_Datos be = new BE_Acceso_Datos();
            string consulta = "SELECT * FROM TipoDeEntrada WHERE id_tipoEntrada = '" + idTipoEntrada + "'";
            DataTable tablaTipoEntrada = new DataTable();
            tablaTipoEntrada = be.consultar(consulta);
            tipo.id_tipoEntrada = Convert.ToInt32(tablaTipoEntrada.Rows[0][0]);
            tipo.nombre = (string)tablaTipoEntrada.Rows[0][1];
            return tipo;
        }
        //METODOS
        //mostrarNombre()
    }
}
