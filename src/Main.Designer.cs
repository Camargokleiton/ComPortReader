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
            lb1 = new Label();
            btnConnect = new Button();
            SuspendLayout();
            // 
            // qco
            // 
            qco.Font = new Font("Segoe UI", 30F);
            qco.FormattingEnabled = true;
            qco.Location = new Point(192, 136);
            qco.Name = "qco";
            qco.Size = new Size(219, 62);
            qco.TabIndex = 0;
            // 
            // lb1
            // 
            lb1.AutoSize = true;
            lb1.Font = new Font("Segoe UI", 30F);
            lb1.Location = new Point(164, 69);
            lb1.Name = "lb1";
            lb1.Size = new Size(288, 54);
            lb1.TabIndex = 1;
            lb1.Text = "Escolha a Porta";
            // 
            // btnConnect
            // 
            btnConnect.Font = new Font("Segoe UI", 20F);
            btnConnect.Location = new Point(207, 208);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(188, 59);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "Conectar";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(597, 309);
            Controls.Add(btnConnect);
            Controls.Add(lb1);
            Controls.Add(qco);
            Name = "Main";
            Text = "Escolha a Porta";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox qco;
        private Label lb1;
        private Button btnConnect;
    }
}
