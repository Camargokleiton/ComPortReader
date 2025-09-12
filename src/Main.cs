using RJCP.IO.Ports;
using System;
using System.Windows.Forms;

namespace ComPortReader
{
    public partial class Main : Form
    {
        private SerialPortStream serialPort;

        public Main()
        {
            InitializeComponent();

            qco.Items.Clear();
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                qco.Items.Add(s);
            }
            if (qco.Items.Count > 0)
                qco.SelectedIndex = 0;
        }

        private void ConnectToSerialPort()
        {
            string portName = qco.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(portName))
            {
                MessageBox.Show("Selecione uma porta serial.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.Close();
                }

                serialPort = new SerialPortStream(portName, 9600, 8, Parity.None, StopBits.One);
                serialPort.Open();

                MessageBox.Show($"Conectado à porta {portName}.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Começa a ler dados em outra thread para não travar a UI
                System.Threading.Thread readThread = new System.Threading.Thread(ReadData);
                readThread.IsBackground = true;
                readThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReadData()
        {
            byte[] buffer = new byte[1024];
            while (serialPort != null && serialPort.IsOpen)
            {
                try
                {
                    int bytesRead = serialPort.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        string data = System.Text.Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        this.Invoke((MethodInvoker)delegate
                        {
                            foreach (char c in data)
                                SendKeys.SendWait(c.ToString());
                        });
                    }
                }
                catch
                {
                    // Ignora erros de leitura temporários
                }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectToSerialPort();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
            base.OnFormClosing(e);
        }
    }
}
