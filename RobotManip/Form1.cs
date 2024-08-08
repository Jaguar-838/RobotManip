using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RobotManip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SerialPort port;
        bool isConnected = false;
        private int z=0, x=0, y= 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            labelZ.Text = "0";
            labelX.Text = "0";
            labelY.Text = "0";
            comboBox1.Items.Clear();
            // Получаем список COM портов доступных в системе
            string[] portnames = SerialPort.GetPortNames();
            // Проверяем есть ли доступные
            if (portnames.Length == 0)
            {
                MessageBox.Show("COM PORT not found");
            }
            foreach (string portName in portnames)
            {
                //добавляем доступные COM порты в список           
                comboBox1.Items.Add(portName);
                Console.WriteLine(portnames.Length);
                if (portnames[0] != null)
                {
                    comboBox1.SelectedItem = portnames[0];
                }
            }
        }
        private void connectToArduino()
        {
            isConnected = true;
            string selectedPort = comboBox1.GetItemText(comboBox1.SelectedItem);
            if (selectedPort != null)
            {
                port = new SerialPort(selectedPort, 9600);
                port.Open();
                connectButton.Text = "Отключить";
            }
            else
            {
                MessageBox.Show("Выбранный порт не подходит");
            }
            
        }

        private void disconnectFromArduino()
        {
            isConnected = false;
            port.Close();
            connectButton.Text = "Подключить";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            z += 10;
            labelZ.Text = z.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            z -= 10;
            labelZ.Text = z.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            x += 10;
            labelX.Text = x.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            x -= 10;
            labelX.Text = x.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            y += 10;
            labelY.Text = y.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            y -= 10;
            labelY.Text = 
                ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                connectToArduino();
            }
            else
            {
                disconnectFromArduino();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // При закрытии программы, закрываем порт
            if (port.IsOpen) port.Close();
        }
    }
}
