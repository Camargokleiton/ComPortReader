namespace ComPortReader
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            qco = new ComboBox();
            btnConnect = new Button();
            SuspendLayout();
            // 
            // qco
            // 
            qco.DropDownStyle = ComboBoxStyle.DropDownList;
            qco.FlatStyle = FlatStyle.System;
            qco.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            qco.ForeColor = SystemColors.MenuHighlight;
            qco.FormattingEnabled = true;
            qco.ItemHeight = 33;
            qco.Location = new Point(24, 55);
            qco.Name = "qco";
            qco.Size = new Size(168, 41);
            qco.TabIndex = 0;
            // 
            // btnConnect
            // 
            btnConnect.BackColor = Color.LightGray;
            btnConnect.FlatStyle = FlatStyle.Popup;
            btnConnect.Font = new Font("Roboto", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConnect.ForeColor = Color.White;
            btnConnect.Location = new Point(198, 53);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(168, 43);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "Conectar";
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Click += btnConnect_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(378, 125);
            Controls.Add(btnConnect);
            Controls.Add(qco);
            Name = "Main";
            ShowIcon = false;
            FormClosing += Main_FormClosing;
            this.Resize += Main_Resize;
            ResumeLayout(false);


            //trayIcon

            // Cria o menu da bandeja
            trayMenu = new ContextMenuStrip();
            trayMenu.Items.Add("Abrir", null, OnTrayOpen);
            trayMenu.Items.Add("Sair", null, OnTrayExit);
            trayIcon = new NotifyIcon();
            trayIcon.Icon = SystemIcons.Application; 
            trayIcon.ContextMenuStrip = trayMenu;    
            trayIcon.DoubleClick += OnTrayOpen; 
            trayIcon.Text = isConnected ? "Conectado" : "Desconectado";
            trayIcon.Visible = true;
            trayIcon.MouseMove += TrayIcon_MouseMove;

        }

        #endregion

        private ComboBox qco;
        private Button btnConnect;
        private NotifyIcon trayIcon;
        private ContextMenuStrip trayMenu;


    }
}
