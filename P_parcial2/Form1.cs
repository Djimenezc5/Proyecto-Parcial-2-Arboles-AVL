using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using P_parcial2.Contenido_Arboles.Arbol_AVL;
using P_parcial2.ContenidoEstudiantes;
using System.IO;


namespace P_parcial2
{
    public partial class Form1 : Form
    {
        ArbolAVL arbolEstudiantes = new ArbolAVL();
        public Form1()

        {
            InitializeComponent();
        }

        private void btnObtenerArchivo_Click(object sender, EventArgs e)
        {
            string rArchivo = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                rArchivo = openFileDialog.FileName;
            }

            txtRutaArchivo.Text = rArchivo;

            int contador = 0;
            string linea;

            //Metodo para leer el archivo
            System.IO.StreamReader file = 
                new System.IO.StreamReader(txtRutaArchivo.Text);
            char delimitador = ',';

            while ((linea = file.ReadLine())!=null)
            {
                String[] substring = linea.Split(delimitador);

                if (substring[0] == "Apellidos")
                {
                    continue;
                }
                Estudiantes objEstudiantes = new Estudiantes(substring [0], substring[1], substring[2], Convert.ToInt32(substring[3].Replace("-","")), Convert.ToInt32(substring[4]), 
                    Convert.ToInt32(substring[5]), Convert.ToInt32(substring[6]), Convert.ToInt32(substring[7]));
                arbolEstudiantes.insertar(objEstudiantes);

                contador++;
            }
            file.Close();

            MessageBox.Show("Asignación Realizada");
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            textBox1.Text = " ";
            textBox1.Text = ArbolAVL.preorden(arbolEstudiantes.raizArbol());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox1.Text = ArbolAVL.postorden(arbolEstudiantes.raizArbol());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox1.Text = ArbolAVL.inorden(arbolEstudiantes.raizArbol());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Estudiantes Objestudiantes = new Estudiantes("", "", emailtxt.Text , 0, 0, 0, 0, 0);

            Estudiantes ObjestudiantesEncontrado = (Estudiantes)arbolEstudiantes.buscar(Objestudiantes).valorNodo();
            Idtxt.Text = ObjestudiantesEncontrado.IdEst.ToString();
            Lab1txt.Text = ObjestudiantesEncontrado.Lab1.ToString();
            Lab2txt.Text = ObjestudiantesEncontrado.Lab2.ToString();
            Lab3txt.Text = ObjestudiantesEncontrado.Lab3.ToString();
            Lab4txt.Text = ObjestudiantesEncontrado.Lab4.ToString();
            int lab1 = Convert.ToInt32(Lab1txt.Text);
            int lab2 = Convert.ToInt32(Lab2txt.Text);
            int lab3 = Convert.ToInt32(Lab3txt.Text);
            int lab4 = Convert.ToInt32(Lab4txt.Text);

            int promedio = (lab1 + lab2 + lab3 + lab4)/4;
            promediotxt.Text = Convert.ToString(promedio);

            if (promedio >= 6)
            {
                label9.Visible = true;
                label9.Text = "APROBADO";
                label9.ForeColor = Color.Green;
            }
            else
            {
                label9.Visible = true;
                label9.Text = "REPROBADO";
                label9.ForeColor = Color.Red;
            }

            MessageBox.Show("Estudiante Encontrado, Numero de nodos recorridos " + ObjestudiantesEncontrado.repeticion);
            ObjestudiantesEncontrado.repeticion = 0;
        }
    }
}
