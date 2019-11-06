using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace time_pictureBox
{
    public partial class Form1 : Form
    {
        
        int hora, minuto;
        int hora_ingresada = 0, minuto_ingresado = 0;
        int hora_ingresada1 = 0, minuto_ingresado1 = 0;
        int hora_evaluacion = 0, minuto_evaluacion = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Inicializar el timer para que la hora empiece a correr 
            timer1.Start();

            TimeSpan horas = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            
            //Seprar el tiempo en horas y minutos
            String str_horas = horas.ToString().Remove(2);
            String str_minutos = horas.ToString().Remove(0, 3);
            String str_min_sin_segundos = str_minutos.ToString().Remove(2);

            //Convertir horas y minutos a enteros para evaluarlos
            hora = int.Parse(str_horas);
            minuto = int.Parse(str_min_sin_segundos);
            
            //Establecer en el extBox el horario actual
            txt_horario_programada.Text = str_horas + ":" + str_min_sin_segundos;
            
            //Obetener imagen del textbox
            Image imagen = Image.FromFile("img.png");
            pictureBox1.Image = imagen;
            pictureBox1.Visible = false;

        }
        
        //Declarar timer para obtener la hora y poderla ejecutar en tiempo real
        private void timer1_Tick(object sender, EventArgs e)
        {

            TimeSpan tiempo_actual = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            this.hora_actual.Text = tiempo_actual.ToString();

            TimeSpan timepo_de_activacion = new TimeSpan(hora_ingresada, minuto_ingresado, 0);
            Console.WriteLine(timepo_de_activacion.ToString());

            if (tiempo_actual == timepo_de_activacion)
            {
                pictureBox1.Visible = true;
            }
        }

        private void programar_horario_Click(object sender, EventArgs e)
        {
            //Obtener datos el textbox para evaluarlos con la hora actual
            String str_horario_programado = txt_horario_programada.Text;
            String str_hora_programada = str_horario_programado.Remove(2);
            String str_minuto_programado = str_horario_programado.Remove(0, 3);
            
            hora_ingresada1 = int.Parse(str_hora_programada);
            minuto_ingresado1 = int.Parse(str_minuto_programado);

            if(hora_ingresada1 > 23 || hora_ingresada1 < 0 || minuto_ingresado1 > 59 || minuto_ingresado1 < 0)
            {
                MessageBox.Show("Ingresa la hora o minutos correctos.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                hora_ingresada = hora_ingresada1;
                minuto_ingresado = minuto_ingresado1;
                MessageBox.Show("Hora programada, en un momento aparecera su imagen.");
            }
        }
    }
}
