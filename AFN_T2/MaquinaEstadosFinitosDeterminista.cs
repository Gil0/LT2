using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public MaquinaEstadosFinitosDeterminista(IEnumerable<string> conjuntoestados, IEnumerable<char> alfabeto, IEnumerable<Transicion> transiciones, string q0, IEnumerable<string> f)
        {
            ConjuntoEstados = conjuntoestados.ToList();
            Alfabeto = alfabeto.ToList();
            AddTransitions(transiciones);
            AddInitialState(q0);
            AddFinalStates(f);
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

        public Respuesta Aceptar(string input)
        {
            //Console.Out.WriteLine("Analizando: " + input + " ...");
            //ConsoleWriter.Success();
            if (InvalidInputOrFSM(input))
            {
                respuesta.estado = false;
                respuesta.mensaje = "Caracter no valido";
                return respuesta;
            }
            var currentState = Q0;
            var steps = new StringBuilder();
            foreach (var symbol in input.ToCharArray())
            {
                var transition = Transiciones.Find(t => t.EstadoInicial == currentState &&
                                                 t.Simbolo == symbol);
                if (transition == null)
                {
                    respuesta.estado = false;
                    respuesta.mensaje = "No hay transiciones para el estado actual y simbolo";
                    return respuesta;
                    //Console.Out.WriteLine("No transitions for current state and symbol");
                    //Console.Out.WriteLine(steps.ToString());
                    //ConsoleWriter.Failure("No transitions for current state and symbol");
                    //ConsoleWriter.Failure(steps.ToString());
                    //return;
                }
                currentState = transition.EstadoFinal;
                steps.Append(transition + "\n");
            }
            if (F.Contains(currentState))
            {
                respuesta.estado = true;
                respuesta.mensaje = "cadena aceptada";
                return respuesta;
                //Console.Out.WriteLine("Cadena aceptada ");
                //Console.Out.WriteLine("Con transiciones:\n" + steps);
                //Console.Out.WriteLine("Accepted the input with steps:\n" + steps);
                //ConsoleWriter.Success("Accepted the input with steps:\n" + steps);
                //return;
            }
            respuesta.estado = false;
            respuesta.mensaje = "Cadena NO aceptada \n Detenido en el estado: "+currentState+" el cual no es un estado final";
            return respuesta;

            //Console.Out.WriteLine("Stopped in state " + currentState + " which is not a final state.");
            //Console.Out.WriteLine(steps.ToString());
            //ConsoleWriter.Failure("Stopped in state " + currentState +" which is not a final state.");
            //ConsoleWriter.Failure(steps.ToString());
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
                //return respuesta;
                //Console.Out.WriteLine("Estado inicial no ha sido establecido");
                //ConsoleWriter.Failure("No initial state has been set");
                return true;
            }
            if (NoFinalStates())
            {
                respuesta.estado = false;
                respuesta.mensaje = "No se han establecido estado Finales validos";
                //Console.Out.WriteLine("No se han establecido estado Finales validos");
                //ConsoleWriter.Failure("No final states have been set");
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
                //Console.Out.WriteLine("Cadena NO aceptada ");
                //Console.Out.WriteLine("No se puede aceptar el simbolo: " + symbol + " debido a que no es parte del alfabeto.");
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
