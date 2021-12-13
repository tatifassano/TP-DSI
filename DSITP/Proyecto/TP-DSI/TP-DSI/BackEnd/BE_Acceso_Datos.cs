using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TP_DSI.BackEnd
{
    class BE_Acceso_Datos
    {
        SqlConnection conexion = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataTable tabla = new DataTable();

        private void conectar()
        {
            conexion.ConnectionString = "Data Source=DESKTOP-J1253JV\\SQLEXPRESS;Initial Catalog=Museo_DB;Integrated Security=True";
            conexion.Open();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.Text;
        }

        private void desconectar()
        {
            conexion.Close();
        }

        public DataTable consultar(string sql)
        {
            conectar();
            cmd.CommandText = sql;
            DataTable tabla = new DataTable();
            tabla.Load(cmd.ExecuteReader());
            desconectar();
            return tabla;
        }


    }
}
