using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AFN_T2
{
    public partial class Form1 : Form
    {

        String rutaArchivo;
        String nombre;
        String nombreInterprete = "Automata Mamalon";

        List<string> Q;
        List<char> Alfabeto;
        List<char> EstadoInicial;
        List<string> EstadoFinal;
        List<Transicion> Transiciones;
        List<string> DATA;

        public Form1()
        {
            InitializeComponent();
        }

        private void opciones_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void datos_Enter(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void abrir_Click(object sender, EventArgs e)
        {
            
            rutaArchivo = "";
            nombre = "";
            Stream Flujo;
            OpenFileDialog DialogoAbrirArchivo = new OpenFileDialog();
            DialogoAbrirArchivo.Filter = "(*.lt2)|*.lt2";
            if (DialogoAbrirArchivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((Flujo = DialogoAbrirArchivo.OpenFile()) != null)
                {
                    rutaArchivo = DialogoAbrirArchivo.FileName;
                    nombre = DialogoAbrirArchivo.SafeFileName;



                    int counter = 0;
                    string line;
                    Q = new List<string>();
                    Alfabeto = new List<char>();
                    EstadoInicial = new List<char>();
                    EstadoFinal = new List<string>();
                    Transiciones = new List<Transicion>();
                    DATA = new List<string>();
                    StreamReader file = new System.IO.StreamReader(rutaArchivo);
                    while ((line = file.ReadLine()) != null)
                    {
                        DATA.Add(line);
                        counter++;
                    }
                    file.Close();




                    for (int i = 0; i < DATA.Count - 1; i++)
                    {
                        switch (i)
                        {
                            case 1:
                                foreach (var s in DATA[i].Split(','))
                                {
                                    Q.Add(s);
                                }
                                break;
                            case 3:
                                foreach (var s in DATA[i].Split(','))
                                {
                                    Alfabeto.Add(s[0]);
                                }
                                break;
                            case 5:
                                foreach (var s in DATA[i].Split(','))
                                {
                                    EstadoInicial.Add(s[0]);
                                }
                                break;
                            case 7:
                                foreach (var s in DATA[i].Split(','))
                                {
                                    EstadoFinal.Add(s);
                                }
                                break;
                            default:
                                if (i > 8)
                                {
                                    String[] transicion = new String[3];
                                    int count = 0;
                                    foreach (string s in DATA[i].Split(','))
                                    {
                                        transicion[count] = s;
                                        count++;
                                    }
                                    Transiciones.Add(new Transicion(transicion[0], (transicion[1])[0], transicion[2]));

                                }

                                break;
                        }

                    }

                    
 /*
                    Console.Out.WriteLine("Conjunto estados");
                    for (int i = 0; i < Q.Count; i++){
                       Console.WriteLine(Q[i]);
                    }
                    Console.Out.WriteLine("Alfabeto");
                    for (int i = 0; i < Alfabeto.Count; i++)
                    {
                        Console.WriteLine(Alfabeto[i]);
                    }
                    Console.Out.WriteLine("Estado Inicial");
                    for (int i = 0; i < EstadoInicial.Count; i++)
                    {
                        Console.WriteLine(EstadoInicial[i]);
                    }
                    Console.Out.WriteLine("Estado Final");
                    for (int i = 0; i < EstadoFinal.Count; i++)
                    {
                        Console.WriteLine(EstadoFinal[i]);
                    }

                    for (int i = 0; i < Transiciones.Count; i++)
                    {
                        Console.WriteLine(Transiciones[i]);
                    }
*/
                  



                    //String textoArchivo = File.ReadAllText(rutaArchivo);
                    //textboxDatos.Text = textoArchivo;
                    Form1.ActiveForm.Text = nombre + " - " + nombreInterprete;
                    //Flujo.Close();
                }
                else
                {
                    textboxResultado.Text = "Error abrir Archivo";
                   
                }
            }
            else
            {
                textboxResultado.Text = "No se ha seleccionado un archivo";
            }
        }

        private void resultado_Enter(object sender, EventArgs e)
        {

        }

        private void ejecutar_Click(object sender, EventArgs e)
        {
            int contadorError = 0;
            
            if (DATA == null)
            {
                textboxResultado.Text = "No hay nada que analizar";

            }
            else
            {
                for (int i = 0; i < Transiciones.Count; i++)
                {
                    string inicial = Transiciones[i].EstadoInicial;
                    char simbolo = Transiciones[i].Simbolo;
                    Console.Out.WriteLine(inicial + " " + simbolo);
                    for (int j = i+1; j < Transiciones.Count; j++)
                    {
                        if (inicial == Transiciones[j].EstadoInicial && simbolo == Transiciones[j].Simbolo)
                        {
                            contadorError++;
                        }
                    }

                    Console.Out.WriteLine(contadorError);
                }
                if (contadorError < 1)
                {
                    Console.Out.WriteLine("Conjunto estados");
                    for (int i = 0; i < Q.Count; i++)
                    {
                        Console.WriteLine(Q[i]);
                    }
                    Console.Out.WriteLine("Alfabeto");
                    for (int i = 0; i < Alfabeto.Count; i++)
                    {
                        Console.WriteLine(Alfabeto[i]);
                    }
                    Console.Out.WriteLine("Estado Inicial");
                    for (int i = 0; i < EstadoInicial.Count; i++)
                    {
                        Console.WriteLine(EstadoInicial[i]);
                    }
                    Console.Out.WriteLine("Estado Final");
                    for (int i = 0; i < EstadoFinal.Count; i++)
                    {
                        Console.WriteLine(EstadoFinal[i]);
                    }

                    for (int i = 0; i < Transiciones.Count; i++)
                    {
                        Console.WriteLine(Transiciones[i]);
                    }
                    String aux = EstadoInicial[0] + "";
                    Console.Out.WriteLine(aux);
                    var MEFD = new MaquinaEstadosFinitosDeterminista(Q, Alfabeto, Transiciones, aux, EstadoFinal);
                    Respuesta res = new Respuesta();
                    res = MEFD.Aceptar(cadena.Text);

                    textboxResultado.Text = res.mensaje;
                }
                else
                {
                    textboxResultado.Text = "El automata no es determinista";
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
