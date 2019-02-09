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
            Stream Flujo;
            OpenFileDialog DialogoAbrirArchivo = new OpenFileDialog();
            DialogoAbrirArchivo.Filter = "(*.lt2)|*.lt2";
            if (DialogoAbrirArchivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((Flujo = DialogoAbrirArchivo.OpenFile()) != null)
                {
                    rutaArchivo = DialogoAbrirArchivo.FileName;
                    nombre = DialogoAbrirArchivo.SafeFileName;
                    String textoArchivo = File.ReadAllText(rutaArchivo);
                    textboxDatos.Text = textoArchivo;
                    Form1.ActiveForm.Text = nombre + " - " + nombreInterprete;
                    Flujo.Close();
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
            if ((textboxDatos.Text).Length == 0)
            {
                textboxResultado.Text = "No hay nada que analizar";

            }
            else
            {
                textboxResultado.Text = "Respuestas del analizador";
            }
        }
    }
}
