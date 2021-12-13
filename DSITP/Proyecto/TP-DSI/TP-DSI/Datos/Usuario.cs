using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TP_DSI.BackEnd;

namespace TP_DSI.Datos
{
    class Usuario
    {
        private DateTime caducidad;
        private string contraseña;
        private Empleado empleado;
        private int id_usuario;
        private string nombre;

        public DateTime Caducidad { get => caducidad; set => caducidad = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public Empleado Empleado { get => empleado; set => empleado = value; }
        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }


        //METODOS
        public Empleado obtenerEmpleado(string nombre, string clave)
        {
            int idEmpleado;
            Empleado empleado =new Empleado();
            string consultaSql = "SELECT * FROM Usuario WHERE nombre = '" + nombre + "'AND contraseña = '" + clave + "'";
            DataTable tabla = new DataTable();


            BE_Acceso_Datos be = new BE_Acceso_Datos();
            tabla = be.consultar(consultaSql);
            if (tabla.Rows.Count > 0)
            {
                idEmpleado = Convert.ToInt32(tabla.Rows[0][0]);

                string consulta = "SELECT * FROM Empleado WHERE id_empleado = '" + idEmpleado + "'";
                DataTable tablaEmpleado = new DataTable();
                tablaEmpleado = be.consultar(consulta);

                if (tablaEmpleado.Rows.Count > 0)
                {


                    empleado.Id_empleado = Convert.ToInt32(tablaEmpleado.Rows[0][0]);
                    empleado.Apellido = (string)tablaEmpleado.Rows[0][1];
                    empleado.CodigoValidacion = (string)tablaEmpleado.Rows[0][2];
                    empleado.Cuit = (string)tablaEmpleado.Rows[0][3];
                    empleado.Dni = Convert.ToInt32(tablaEmpleado.Rows[0][4]);
                    empleado.Domicilio = (string)tablaEmpleado.Rows[0][5];
                    empleado.FechaIngreso = (DateTime)tablaEmpleado.Rows[0][6];
                    empleado.FechaNacimiento = (DateTime)tablaEmpleado.Rows[0][7];
                    empleado.Mail = (string)tablaEmpleado.Rows[0][8];
                    empleado.Nombre = (string)tablaEmpleado.Rows[0][9];
                    empleado.Sexo = (string)tablaEmpleado.Rows[0][10];
                    empleado.Telefono = (string)tablaEmpleado.Rows[0][11];

                    return empleado;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
           
        }
    }
}
