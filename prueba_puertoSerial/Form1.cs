using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace prueba_puertoSerial
{
    public partial class Form1 : Form
    {

        SerialPort puerto = new SerialPort();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string item in SerialPort.GetPortNames())
            {
                cmbPuertos.Items.Add(item);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                puerto.BaudRate = 1;
                puerto.DataBits = 8;
                puerto.Parity = Parity.None;
                puerto.DiscardNull = true;
                puerto.StopBits = StopBits.One;
                puerto.PortName = "COM1";
                puerto.Open();
                MessageBox.Show("Puerto abierto");
            }
            catch (Exception)
            {

                MessageBox.Show(".");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            byte[] num = new byte[1];
            try
            {
                num[0] = Convert.ToByte(Convert.ToInt32(txtDato.Text));
                if (puerto.IsOpen)
                {
                    puerto.Write(num, 0, 1);
                    MessageBox.Show(txtDato.Text);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                throw;
            }
            
        }

        private void datosRecibidos(object sender, SerialDataReceivedEventArgs e)
        {
            string buffer = "";
            buffer = puerto.ReadExisting();
        }
    }
}
