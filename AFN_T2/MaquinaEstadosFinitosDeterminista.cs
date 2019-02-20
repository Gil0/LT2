using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AFN_T2
{
    class MaquinaEstadosFinitosDeterminista
    {

        Respuesta respuesta = new Respuesta();


        private readonly List<string> ConjuntoEstados = new List<string>();
        private readonly List<char> Alfabeto = new List<char>();
        private readonly List<Transicion> Transiciones = new List<Transicion>();
        private string Q0;
        private readonly List<string> F = new List<string>();
        private string acumula = "";
        private List<String> acumulador = new List<string>();
        private readonly List<string> Nombres = new List<string>();

        public MaquinaEstadosFinitosDeterminista(IEnumerable<string> conjuntoestados, IEnumerable<char> alfabeto, IEnumerable<Transicion> transiciones, string q0, IEnumerable<string> f, IEnumerable<string> nombres)
        {
            ConjuntoEstados = conjuntoestados.ToList();
            Alfabeto = alfabeto.ToList();
            AddTransitions(transiciones);
            AddInitialState(q0);
            AddFinalStates(f);
            Nombres = nombres.ToList();

        }

        private void AddTransitions(IEnumerable<Transicion> transitions)
        {
            foreach (var transition in transitions.Where(ValidTransition))
            {
                Transiciones.Add(transition);
            }
        }

        private bool ValidTransition(Transicion transicion)
        {
            return ConjuntoEstados.Contains(transicion.EstadoInicial) &&
                   ConjuntoEstados.Contains(transicion.EstadoFinal) &&
                   Alfabeto.Contains(transicion.Simbolo) &&
                   !TransitionAlreadyDefined(transicion);
        }

        private bool TransitionAlreadyDefined(Transicion transicion)
        {
            return Transiciones.Any(t => t.EstadoInicial == transicion.EstadoInicial &&
                                  t.Simbolo == transicion.Simbolo);
        }

        private void AddInitialState(string q0)
        {
            if (q0 != null && ConjuntoEstados.Contains(q0))
            {
                Q0 = q0;
            }
        }

        private void AddFinalStates(IEnumerable<string> finalStates)
        {
            foreach (var finalState in finalStates.Where(finalState => ConjuntoEstados.Contains(finalState)))
            {
                F.Add(finalState);
            }
        }

        public Respuesta Aceptar2(string input)
        {
            var estadoActual = Q0;
            int contadorLinea = 1;
            string toke = "";
            char caracter;
            for (int i = 0; i < input.Length; i++)
            {
                caracter = input[i];
                Regex rexstr = new Regex("[a-zA-Z]");
                Regex rexint = new Regex("[0-9]");

                if(rexstr.IsMatch(caracter.ToString()))
                {
                    caracter = 'l';
                }
                if (rexint.IsMatch(caracter.ToString()))
                {
                    caracter = 'd';
                }

                Transicion normal = Transiciones.Find(t => t.EstadoInicial == estadoActual
                                            && t.Simbolo == caracter);
                Transicion retroceso = Transiciones.Find(t => t.EstadoInicial == estadoActual
                                            && t.Simbolo == 'o');

                if(normal != null)
                {
                    acumula = acumula + input[i];
                    Console.WriteLine("Estado normal "+normal.EstadoFinal);
                    if (F.Contains(normal.EstadoFinal))
                    {
                        toke = EstadoNombre(Convert.ToInt32(normal.EstadoFinal));
                        Console.WriteLine("Lexema encontrado: " + acumula + " en linea: " + contadorLinea + " token: "+toke);
                        estadoActual = Q0;
                        acumula = "";
                    }
                    else if ((i + 1) >= input.Length)
                    {
                        Transicion retroceso2 = Transiciones.Find(t => t.EstadoInicial == normal.EstadoFinal
                                            && t.Simbolo == 'o');
                        toke = EstadoNombre(Convert.ToInt32(retroceso2.EstadoFinal));
                        Console.WriteLine("Lexema encontrado: " + acumula + " en linea: " + contadorLinea + " token: " + toke);
                        estadoActual = Q0;
                        acumula = "";
                    }
                    else
                    {
                        estadoActual = normal.EstadoFinal;
                    }
                }
                else if(retroceso != null)
                {
                    toke = EstadoNombre(Convert.ToInt32(retroceso.EstadoFinal));
                   Console.WriteLine("Estado retroceso "+retroceso.EstadoFinal);
                    Console.WriteLine("Lexema encontrado: " + acumula + " en linea: " + contadorLinea + " token: " + toke);
                    acumula = "";
                    estadoActual = Q0;
                    i = i - 1;
                }
                else
                {

               //     Console.WriteLine("ERROR: Lexema encontrado: " + acumula+" en linea: "+contadorLinea);
                    estadoActual = Q0;
                }
                if (input[i] == '\n')
                {
                    contadorLinea++;
                }
            }  //fin for


            if (F.Contains(estadoActual))
            {
                respuesta.estado = true;
                respuesta.mensaje = "cadena aceptttttada ";
                respuesta.tok = acumulador;
                return respuesta;
            }
            respuesta.estado = false;
            respuesta.mensaje = "Cadena NO aceptada \n Detenido en el estado: " + estadoActual + " el cual no es un estado final";
            return respuesta;
            
        }
       
        public string EstadoNombre(int valor)
        {
            for(int i = 0; i < Nombres.Count; i++)
            {
                int index = Nombres[i].IndexOf(':');
                string izq = Nombres[i].Substring(0, index);
                string der = Nombres[i].Substring(index + 1, (Nombres[i].Length) - (index + 1));

                if (Convert.ToInt32(izq) == valor)
                {
                    return der;
                }
            }
            return "";
        }
        private bool InvalidInputOrFSM(string input)
        {
            if (InputContainsNotDefinedSymbols(input))
            {
                return true;
            }
            if (InitialStateNotSet())
            {
                respuesta.estado = false;
                respuesta.mensaje = "Estado inicial no ha sido establecido";
                return true;
            }
            if (NoFinalStates())
            {
                respuesta.estado = false;
                respuesta.mensaje = "No se han establecido estado Finales validos";
                return true;
            }
            return false;
        }

        private bool InputContainsNotDefinedSymbols(string input)
        {



            foreach (var symbol in input.ToCharArray().Where(symbol => !Alfabeto.Contains(symbol)))
            {
                respuesta.estado = false;
                respuesta.mensaje = "Cadena NO aceptada \n No se puede aceptar el simbolo: "+symbol+ "debido a que no es parte del alfabeto.";
                return true;
            }


            return false;
        }

        private void AFN()
        {
            Console.Out.WriteLine(Transiciones);
        }

        private bool InitialStateNotSet()
        {
            return string.IsNullOrEmpty(Q0);
        }

        private bool NoFinalStates()
        {
            return F.Count == 0;
        }


    }
}
