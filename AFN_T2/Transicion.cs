using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFN_T2
{
    class Transicion
    {

        public string EstadoInicial { get; private set; }
        public char Simbolo { get; private set; }
        public string EstadoFinal { get; private set; }

        public Transicion(string estadoInicial, char simbolo, string estadoFinal)
        {
            EstadoInicial = estadoInicial;
            Simbolo = simbolo;
            EstadoFinal = estadoFinal;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}) -> {2}", EstadoInicial, Simbolo, EstadoFinal);
        }

    }
}
