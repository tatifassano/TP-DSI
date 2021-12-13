using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DSI.Negocio
{
    interface IObservador
    {
        void actualizarCantVisitantes(int cantEntradasAEmitir, int cantMaximaVisitantes);
        void mostrarVisitantesYTotalEnSede(int cantEntradasAEmitir, int cantMaximaVisitantes);
    }
}
