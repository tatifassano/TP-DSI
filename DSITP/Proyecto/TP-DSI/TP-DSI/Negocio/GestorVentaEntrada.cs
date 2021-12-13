using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DSI.Datos;
using TP_DSI.Presentacion;
using System.Windows.Forms;

namespace TP_DSI.Negocio
{
    class GestorVentaEntrada : ISujeto
    {

        Usuario usuarioActual;
        Empleado empleado = new Empleado();
        Sede sede = new Sede();
        DateTime Actual;
        Entrada entrada;
        ReservaVisita reserva = new ReservaVisita();
        int idTarifa;
        Tarifa tarifa;
        List<Tarifa> listTarifa;
        double monto = 0.0;
        Entrada [] nueva;
        int cantidadMaximaVisitantes;
        int cantidadEntradas;
        float montoEntrada;
        int cantidadVisitantesEnSede;
        int cantidadReservaParaAsistir;
        TimeSpan horaActal;
        List<IObservador> listaObsevadores = new List<IObservador>();
        PantallaEntradaPpal pantallaPpal = new PantallaEntradaPpal();
        PantallaSala pantallaSala = new PantallaSala();
        IObservador[] observadores = new IObservador[2];
        public Empleado ventaEntrada(PantallaLogin login)
        {
            buscarEmpleadoLogueado(login);//busca empleado
            buscarSede();//busca sede del empleado
            return empleado;
        }
        public Empleado buscarEmpleadoLogueado(PantallaLogin login)
        {
            //obtiene el empleado
            usuarioActual = login.Usuario;
            empleado = usuarioActual.obtenerEmpleado(usuarioActual.Nombre, usuarioActual.Contraseña);
            pantallaPpal.StartPosition = FormStartPosition.Manual;
            pantallaPpal.Left = 1000;
            pantallaPpal.Top = 300;
            pantallaSala.StartPosition = FormStartPosition.Manual;
            pantallaSala.Left = 1000;
            pantallaSala.Top = 500;
            
            return empleado;

        }
        public Sede buscarSede()
        {//busca la sede
            sede = empleado.obtenerSede();
            return sede;
        }
        public List<Tarifa> buscarTarifaDeSede() {
            //busca las tarifas de una sede

            listTarifa = sede.obtenerTarifasVigentes();
            
            return listTarifa ;
        }
        public void tomarTarifasSeleccionadas(int idTarifa)
        { 
            //toma la tarifa y busca la Exposicion vigente
            this.idTarifa = idTarifa;
            tarifa = new Tarifa();
            tarifa = tarifa.mostrartarifa(idTarifa);
            buscarExposicionVigente();
        }
        public void buscarExposicionVigente()
        {
            //calcula la duracion de las exposiciones vigentes
            sede.calcularDuracionAExposicionesVigentes();
        }
        public double cantidadEntradasAEmitir(int cantidad)
        {
            buscarCapacidadSede();
            cantidadEntradas = cantidad;
            
           //toma la cantidad de entradas y calcula en total y llamar a validarLimit visitantes
            bool hayLugar = validarLimiteVisitantes();
            if (hayLugar)
            {
               monto= calcTotalVta(cantidad);
            }
            return monto;
        }
        public void buscarCapacidadSede()
        {
            cantidadMaximaVisitantes = sede.GetCantMaximaVisitantes();
            obtenerFechaHoraActual();
            buscarVisitantesEnSede();
            buscarReservasParaAsistir();
            pantallaPpal.mostrarVisitantesYTotalEnSede(cantidadVisitantesEnSede, cantidadMaximaVisitantes);
            pantallaSala.mostrarVisitantesYTotalEnSede(cantidadVisitantesEnSede, cantidadMaximaVisitantes);
            pantallaPpal.Show();
            pantallaSala.Show();
        }
        public void obtenerFechaHoraActual()
        {
            //calcula la Fecha y Hora Actual
            Actual = DateTime.Now;
            horaActal = Actual.TimeOfDay;
            

        }
        public int buscarVisitantesEnSede()
        {
            //obtenemos la fecha y hora actual 
            entrada = new Entrada();
           cantidadVisitantesEnSede= entrada.sonDeFechaHoraYSede(Actual, sede.Id_sede);
            
            return cantidadVisitantesEnSede;//pasamos por parametro la sede y la fecha y hora actual
        }
        public int buscarReservasParaAsistir()
        {
            cantidadReservaParaAsistir = reserva.sonParaFechaHoraYSede(Actual, sede.Id_sede);
             return cantidadReservaParaAsistir;//pasamos hora y fecha y actual y la sede
        }
        public bool validarLimiteVisitantes()
            {
            //valida la cantidad de visitantes limite
            int capacidad=0;
            capacidad = cantidadMaximaVisitantes - cantidadVisitantesEnSede - cantidadReservaParaAsistir;
            if (capacidad != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public double calcTotalVta( int cantidad)
        {
            //calcula el total de la venta
            montoEntrada = tarifa.Monto;
            return (cantidad * montoEntrada);
        }
        public string mostrarDetalleEntrada()
        {
            //muestra el detalle de Entrada antes de confirmar
            obtenerFechaHoraActual();
            string detalleEntrada = "\n";
            detalleEntrada += "Cantidad de entradas: " + cantidadEntradas + "\n";
            detalleEntrada += "Fecha Venta: " + Actual +"\n";
            detalleEntrada += "Sede: "+ sede.Nombre+"\n";
            detalleEntrada += "Tarifa: "+ idTarifa + "\n";
            detalleEntrada += "Monto: " + montoEntrada; //+ 
                //"\n confirme generacion de entrada.....\n";

            
            return detalleEntrada;
        }
        public string tomarConfirmacion()
        {
            //toma la confirmacion genera el numero de entrada crea la entrada y la imprime
            nueva = new Entrada[cantidadEntradas];
            int numEntrada=0;
            
                for (int i = 0; i < cantidadEntradas; i++)
                {
                    if(i==0)
                    {
                        numEntrada = buscarUltimoNumeroEntrada() + 1;
                        nueva[i] = new Entrada(numEntrada, Actual, horaActal, sede, tarifa, montoEntrada);
                    }
                    else
                    {
                        numEntrada++;
                        nueva[i]= new Entrada(numEntrada, Actual, horaActal, sede, tarifa, montoEntrada);
                    }
                }
            
            return imprimirEntrada();
        }
        public int buscarUltimoNumeroEntrada()
        {
            return entrada.buscarUltima();
        }
        public string imprimirEntrada()
        {//imprime la entrada
            String str = "";
            for (int i = 0; i < cantidadEntradas; i++)
            {
                str +="\n"+ nueva[i].ToString();
            }
            ImpresoraEntrada impresor = new ImpresoraEntrada();

            impresor.imprimir(str);
            observadores[0] = pantallaPpal;
            observadores[1] = pantallaSala;

            for (int i = 0; i < observadores.Length; i++)
            {
                suscribir(observadores[i]);
            }
            notificar();
            impresor.ShowDialog();
           

                observadores[0] = pantallaPpal;
            observadores[1] = pantallaSala;
            
            for (int i=0;i<observadores.Length;i++)
            {
                suscribir(observadores[i]);
            }
            notificar();
            
                Frm_FinCU fin = new Frm_FinCU();
                fin.ShowDialog();
                cerrarPantallas();
                
        
            return "Entrada " + str;
        }

        public void actVisitantesEnPantalla()
        {
            int cantidadVisitantesTotal = cantidadVisitantesEnSede + cantidadEntradas;
            for(int i=0; i<listaObsevadores.Count;i++)
            {
                listaObsevadores[i].actualizarCantVisitantes(cantidadVisitantesTotal, cantidadMaximaVisitantes);
            }

        }
        public void notificar()
        {
            actVisitantesEnPantalla();
        }

    public void quitar(IObservador observador)
        {
            listaObsevadores.Remove(observador);
        }

     public void suscribir(IObservador observador)
        {
            listaObsevadores.Add(observador);
            
        }
        public void cerrarPantallas()
        {
            pantallaPpal.Close();
            pantallaSala.Close();
        }

    }
}
