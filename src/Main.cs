using RJCP.IO.Ports;
using System;
using System.Windows.Forms;
using WindowsInput; // Instale via NuGet: InputSimulator
using WindowsInput.Native;

namespace ComPortReader
{
    public partial class Main : Form
    {
        private SerialPortStream serialPort;
        private InputSimulator sim;
        private System.Threading.Thread readThread;
        private volatile bool keepReading = false; 
        private bool isConnected = false;
        public Main()
        {
            InitializeComponent();

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            sim = new InputSimulator();
            qco.Items.Clear();
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                qco.Items.Add(s);
            }
            if (qco.Items.Count > 0)
                qco.SelectedIndex = 0;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (isConnected)
                DiconnectFromSerialPort();
            else
                ConnectToSerialPort();
            
        }

        private void DiconnectFromSerialPort()
        {
            keepReading = false;
            if (serialPort != null)
            {
                if (serialPort.IsOpen)
                    serialPort.Close();
                serialPort.Dispose();
                serialPort = null;
            }
            if (readThread != null && readThread.IsAlive)
            {
                readThread.Join(500); // espera até 500ms
                readThread = null;
            }
            btnConnect.Text = "Conectar";
            btnConnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            btnConnect.BackColor = System.Drawing.Color.LightGray;
            isConnected = false;
        }

        private void ConnectToSerialPort()
        {
            string portName = qco.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(portName))
            {
                MessageBox.Show("Selecione uma porta serial.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int attempts = 0;

            while (!isConnected && attempts < 3) 
            {
                try
                {
                    
                    if (serialPort != null && serialPort.IsOpen)
                    {
                        keepReading = false;
                        readThread?.Join(500);
                        serialPort.Close();
                        serialPort.Dispose();
                        serialPort = null;
                    }

                    serialPort = new SerialPortStream(portName, 9600, 8, Parity.None, StopBits.One);
                    serialPort.ReadTimeout = 1000; 
                    serialPort.WriteTimeout = 1000; 
                    serialPort.Open();

                    ShowAutoCloseMessageBox(portName);
                    keepReading = true;
                    readThread = new System.Threading.Thread(ReadData);
                    readThread.IsBackground = true;
                    readThread.Start();

                    btnConnect.Text = "Conectado";
                    btnConnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    btnConnect.BackColor = System.Drawing.Color.LightGreen;
                    isConnected = true;

                    this.Hide();
                    trayIcon.Visible = true;
                    
                    

                }
                catch (Exception ex)
                {
                    attempts++;
                    if (attempts >= 3)
                    {
                        isConnected = false;
                        MessageBox.Show($"Erro ao conectar após {attempts} tentativas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(1000); 
                    }
                }
            }
        }


        private void ReadData()
        {
            var encoding = System.Text.Encoding.GetEncoding("ISO-8859-1");



            byte[] buffer = new byte[1024];

            while (serialPort != null && serialPort.IsOpen)
            {
                try
                {
                    int bytesRead = serialPort.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        string data = encoding.GetString(buffer, 0, bytesRead)
                                  .Replace("\0", "")
                                  .Trim();
                        data = data.Trim();

                        if (!string.IsNullOrEmpty(data))
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                sim.Keyboard.TextEntry(data);
                                sim.Keyboard.KeyPress(VirtualKeyCode.RETURN); // simula ENTER
                            });
                        }
                    }
                }
                catch (TimeoutException)
                {
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro na leitura: " + ex.Message);
                }
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnFormClosing(e);
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
           
            keepReading = false;

            if (serialPort != null)
            {
                if (serialPort.IsOpen)
                    serialPort.Close();
                serialPort.Dispose();
                serialPort = null;
            }

            if (readThread != null && readThread.IsAlive)
            {
                readThread.Join(500); 
                readThread = null;
            }

        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                trayIcon.Visible = true;
            }
        }



        private void OnTrayOpen(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void OnTrayExit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }

        private void TrayIcon_MouseMove(object sender, EventArgs e)
        {
            trayIcon.Text = isConnected ? "Conectado à " + qco.SelectedItem?.ToString() : "Desconectado";
        }

        private void ShowAutoCloseMessageBox(string portName)
        {
            
            Task.Run(async () =>
            {
                await Task.Delay(1000);
                SendKeys.SendWait("{ENTER}"); 
            });

            MessageBox.Show($"Conectado à {portName}", "Sucesso");
        }


    }
}
