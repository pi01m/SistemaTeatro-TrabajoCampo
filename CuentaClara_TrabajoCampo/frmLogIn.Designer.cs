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
            panelLogin.Location = new Point(62, 34);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(346, 457);
            panelLogin.TabIndex = 0;
            panelLogin.Paint += panelLogin_Paint;
            // 
            // ojo
            // 
            ojo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ojo.BackColor = Color.FromArgb(120, 20, 40);
            ojo.FlatAppearance.BorderSize = 0;
            ojo.FlatStyle = FlatStyle.Flat;
            ojo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            ojo.ForeColor = Color.White;
            ojo.Location = new Point(284, 241);
            ojo.Name = "ojo";
            ojo.Size = new Size(36, 30);
            ojo.TabIndex = 11;
            ojo.Tag = "";
            ojo.UseVisualStyleBackColor = false;
            ojo.Click += button1_Click;
            // 
            // picLogo
            // 
            picLogo.BorderStyle = BorderStyle.FixedSingle;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(46, 25);
            picLogo.Margin = new Padding(0);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(54, 54);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picLogo.TabIndex = 10;
            picLogo.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(60, 60, 60);
            label1.Location = new Point(47, 301);
            label1.Name = "label1";
            label1.Size = new Size(127, 45);
            label1.TabIndex = 9;
            label1.Tag = "lbl_LogInClave";
            label1.Text = "Idioma";
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(47, 333);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(211, 53);
            comboBox1.TabIndex = 8;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(120, 20, 40);
            lblTitulo.Location = new Point(115, 25);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(349, 89);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "TeatroLux";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuario.ForeColor = Color.FromArgb(60, 60, 60);
            lblUsuario.Location = new Point(46, 136);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(322, 45);
            lblUsuario.TabIndex = 2;
            lblUsuario.Tag = "lbl_LogInNombreUsuario";
            lblUsuario.Text = "Nombre de Usuario";
            // 
            // txtUsuario
            // 
            txtUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Location = new Point(47, 165);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(211, 52);
            txtUsuario.TabIndex = 3;
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClave.ForeColor = Color.FromArgb(60, 60, 60);
            lblClave.Location = new Point(47, 216);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(196, 45);
            lblClave.TabIndex = 4;
            lblClave.Tag = "lbl_LogInClave";
            lblClave.Text = "Contraseña";
            // 
            // txtContrasena
            // 
            txtContrasena.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtContrasena.BorderStyle = BorderStyle.FixedSingle;
            txtContrasena.Location = new Point(46, 245);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(212, 52);
            txtContrasena.TabIndex = 5;
            txtContrasena.TextChanged += txtContrasena_TextChanged;
            // 
            // btnIngresar
            // 
            btnIngresar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnIngresar.BackColor = Color.FromArgb(120, 20, 40);
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(206, 390);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(114, 42);
            btnIngresar.TabIndex = 6;
            btnIngresar.Tag = "btn_Ingresar";
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSalir.BackColor = Color.White;
            btnSalir.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalir.ForeColor = Color.FromArgb(120, 20, 40);
            btnSalir.Location = new Point(28, 390);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(122, 42);
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
            ClientSize = new Size(481, 523);
            Controls.Add(panelLogin);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimumSize = new Size(497, 562);
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