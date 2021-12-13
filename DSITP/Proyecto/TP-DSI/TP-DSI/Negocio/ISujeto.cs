using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DSI.Negocio
{
    interface ISujeto
    {
        void notificar();
        void quitar(IObservador observador);
        void suscribir(IObservador observador); 
    }
}
