namespace CuentaClara_TrabajoCampo
{
    partial class frmLogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogIn));
            panelLogin = new Panel();
            ojo = new Button();
            picLogo = new PictureBox();
            label1 = new Label();
            comboBox1 = new ComboBox();
            lblTitulo = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblClave = new Label();
            txtContrasena = new TextBox();
            btnIngresar = new Button();
            btnSalir = new Button();
            panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // panelLogin
            // 
            panelLogin.Anchor = AnchorStyles.None;
            panelLogin.BackColor = Color.White;
            panelLogin.BorderStyle = BorderStyle.FixedSingle;
            panelLogin.Controls.Add(ojo);
            panelLogin.Controls.Add(picLogo);
            panelLogin.Controls.Add(label1);
            panelLogin.Controls.Add(comboBox1);
            panelLogin.Controls.Add(lblTitulo);
            panelLogin.Controls.Add(lblUsuario);
            panelLogin.Controls.Add(txtUsuario);
            panelLogin.Controls.Add(lblClave);
            panelLogin.Controls.Add(txtContrasena);
            panelLogin.Controls.Add(btnIngresar);
            panelLogin.Controls.Add(btnSalir);
            panelLogin.Location = new Point(152, 81);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(706, 685);
            panelLogin.TabIndex = 0;
            // 
            // ojo
            // 
            ojo.BackColor = Color.White;
            ojo.FlatAppearance.BorderSize = 0;
            ojo.FlatStyle = FlatStyle.Flat;
            ojo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            ojo.ForeColor = Color.White;
            ojo.Location = new Point(625, 384);
            ojo.Name = "ojo";
            ojo.Size = new Size(46, 52);
            ojo.TabIndex = 11;
            ojo.Tag = "";
            ojo.UseVisualStyleBackColor = false;
            ojo.Click += button1_Click;
            // 
            // picLogo
            // 
            picLogo.BorderStyle = BorderStyle.FixedSingle;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(35, 25);
            picLogo.Margin = new Padding(0);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(70, 70);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picLogo.TabIndex = 10;
            picLogo.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(60, 60, 60);
            label1.Location = new Point(35, 454);
            label1.Name = "label1";
            label1.Size = new Size(127, 45);
            label1.TabIndex = 9;
            label1.Tag = "lbl_LogInClave";
            label1.Text = "Idioma";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(29, 506);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(642, 53);
            comboBox1.TabIndex = 8;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(120, 20, 40);
            lblTitulo.Location = new Point(120, 31);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(349, 89);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "TeatroLux";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblUsuario.ForeColor = Color.FromArgb(60, 60, 60);
            lblUsuario.Location = new Point(28, 205);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(322, 45);
            lblUsuario.TabIndex = 2;
            lblUsuario.Tag = "lbl_LogInNombreUsuario";
            lblUsuario.Text = "Nombre de Usuario";
            // 
            // txtUsuario
            // 
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Location = new Point(30, 265);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(641, 52);
            txtUsuario.TabIndex = 3;
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblClave.ForeColor = Color.FromArgb(60, 60, 60);
            lblClave.Location = new Point(29, 336);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(196, 45);
            lblClave.TabIndex = 4;
            lblClave.Tag = "lbl_LogInClave";
            lblClave.Text = "Contraseña";
            // 
            // txtContrasena
            // 
            txtContrasena.BorderStyle = BorderStyle.FixedSingle;
            txtContrasena.Location = new Point(29, 384);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(580, 52);
            txtContrasena.TabIndex = 5;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(120, 20, 40);
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(473, 583);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(198, 77);
            btnIngresar.TabIndex = 6;
            btnIngresar.Tag = "btn_Ingresar";
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.White;
            btnSalir.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalir.ForeColor = Color.FromArgb(120, 20, 40);
            btnSalir.Location = new Point(29, 583);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(220, 77);
            btnSalir.TabIndex = 7;
            btnSalir.Tag = "btn_Salir";
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmLogIn
            // 
            AutoScaleDimensions = new SizeF(18F, 45F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 238, 235);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1010, 847);
            Controls.Add(panelLogin);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(750, 750);
            Name = "frmLogIn";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "lbl_FormLogin";
            Text = "TeatroLux- Inicio de Sesión";
            FormClosed += frmLogIn_FormClosed;
            Load += frmLogIn_Load_1;
            Resize += frmLogIn_Resize;
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelLogin;

        private Label lblTitulo;

        private Label lblUsuario;
        private TextBox txtUsuario;

        private Label lblClave;
        private TextBox txtContrasena;

        private Button btnIngresar;
        private Button btnSalir;
        private ComboBox comboBox1;
        private Label label1;
        private PictureBox picLogo;
        private Button ojo;
    }
}