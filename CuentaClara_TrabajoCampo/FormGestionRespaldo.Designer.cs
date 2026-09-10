namespace IU
{
    partial class FormGestionRespaldo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGestionRespaldo));
            btnAplicar = new Button();
            button1 = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            textBox1 = new TextBox();
            progresoBackup = new ProgressBar();
            btnSeleccionar = new Button();
            btn_RecalcularDv = new Button();
            picLogo = new PictureBox();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // btnAplicar
            // 
            btnAplicar.BackColor = Color.FromArgb(120, 20, 40);
            btnAplicar.FlatAppearance.BorderSize = 0;
            btnAplicar.FlatStyle = FlatStyle.Flat;
            btnAplicar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAplicar.ForeColor = Color.White;
            btnAplicar.Location = new Point(97, 558);
            btnAplicar.Margin = new Padding(7, 8, 7, 8);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(340, 115);
            btnAplicar.TabIndex = 7;
            btnAplicar.Tag = "btn_Restaurar";
            btnAplicar.Text = "Restaurar\r\n";
            btnAplicar.UseVisualStyleBackColor = false;
            btnAplicar.Click += btnAplicar_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(120, 20, 40);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(602, 558);
            button1.Margin = new Padding(7, 8, 7, 8);
            button1.Name = "button1";
            button1.Size = new Size(340, 115);
            button1.TabIndex = 8;
            button1.Tag = "btn_BackUp";
            button1.Text = "BackUp\r\n";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(97, 265);
            textBox1.Margin = new Padding(7, 8, 7, 8);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(842, 47);
            textBox1.TabIndex = 9;
            // 
            // progresoBackup
            // 
            progresoBackup.Location = new Point(97, 383);
            progresoBackup.Margin = new Padding(7, 8, 7, 8);
            progresoBackup.Name = "progresoBackup";
            progresoBackup.Size = new Size(845, 63);
            progresoBackup.TabIndex = 10;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.BackColor = Color.White;
            btnSeleccionar.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnSeleccionar.FlatStyle = FlatStyle.Flat;
            btnSeleccionar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSeleccionar.ForeColor = Color.FromArgb(120, 20, 40);
            btnSeleccionar.Location = new Point(97, 735);
            btnSeleccionar.Margin = new Padding(7, 8, 7, 8);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(340, 142);
            btnSeleccionar.TabIndex = 11;
            btnSeleccionar.Tag = "btn_Seleccionar";
            btnSeleccionar.Text = "Seleccionar\r\n";
            btnSeleccionar.UseVisualStyleBackColor = false;
            btnSeleccionar.Click += btnSeleccionar_Click;
            // 
            // btn_RecalcularDv
            // 
            btn_RecalcularDv.BackColor = Color.FromArgb(120, 20, 40);
            btn_RecalcularDv.FlatAppearance.BorderSize = 0;
            btn_RecalcularDv.FlatStyle = FlatStyle.Flat;
            btn_RecalcularDv.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_RecalcularDv.ForeColor = Color.White;
            btn_RecalcularDv.Location = new Point(602, 735);
            btn_RecalcularDv.Margin = new Padding(7, 8, 7, 8);
            btn_RecalcularDv.Name = "btn_RecalcularDv";
            btn_RecalcularDv.Size = new Size(340, 142);
            btn_RecalcularDv.TabIndex = 12;
            btn_RecalcularDv.Tag = "btn_RecalcularDigitosVerificadores";
            btn_RecalcularDv.Text = "Recalcular Digitos Verificadores";
            btn_RecalcularDv.UseVisualStyleBackColor = false;
            btn_RecalcularDv.Click += btn_RecalcularDv_Click;
            // 
            // picLogo
            // 
            picLogo.BorderStyle = BorderStyle.FixedSingle;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(97, 25);
            picLogo.Margin = new Padding(0);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(170, 152);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picLogo.TabIndex = 13;
            picLogo.TabStop = false;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(120, 20, 40);
            lblTitulo.Location = new Point(277, 55);
            lblTitulo.Margin = new Padding(7, 0, 7, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(676, 89);
            lblTitulo.TabIndex = 14;
            lblTitulo.Tag = "lbl_GestionDeRespaldo";
            lblTitulo.Text = "Gestión de Respaldo";
            // 
            // FormGestionRespaldo
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 238, 235);
            ClientSize = new Size(1054, 1020);
            Controls.Add(lblTitulo);
            Controls.Add(picLogo);
            Controls.Add(btn_RecalcularDv);
            Controls.Add(btnSeleccionar);
            Controls.Add(progresoBackup);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(btnAplicar);
            Margin = new Padding(7, 8, 7, 8);
            MaximizeBox = false;
            Name = "FormGestionRespaldo";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "lbl_FormRespaldo";
            Text = "Form Gestion Respaldo";
            FormClosed += FormGestionRespaldo_FormClosed;
            Load += FormGestionRespaldo_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAplicar;
        private Button button1;
        private FolderBrowserDialog folderBrowserDialog1;
        private TextBox textBox1;
        private ProgressBar progresoBackup;
        private Button btnSeleccionar;
        private Button btn_RecalcularDv;
        private PictureBox picLogo;
        private Label lblTitulo;
    }
}