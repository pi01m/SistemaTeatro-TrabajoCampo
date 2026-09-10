namespace IU
{
    partial class FormCrearPrimerUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCrearPrimerUsuario));
            panelPrincipal = new Panel();
            label1 = new Label();
            txt_Login = new TextBox();
            picLogo = new PictureBox();
            lblTitulo = new Label();
            lblDNI = new Label();
            txtDNI = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblCorreo = new Label();
            txtCorreo = new TextBox();
            btnCancelar = new Button();
            btnGuardar = new Button();
            panelPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // panelPrincipal
            // 
            panelPrincipal.BackColor = Color.White;
            panelPrincipal.BorderStyle = BorderStyle.FixedSingle;
            panelPrincipal.Controls.Add(label1);
            panelPrincipal.Controls.Add(txt_Login);
            panelPrincipal.Controls.Add(picLogo);
            panelPrincipal.Controls.Add(lblTitulo);
            panelPrincipal.Controls.Add(lblDNI);
            panelPrincipal.Controls.Add(txtDNI);
            panelPrincipal.Controls.Add(lblNombre);
            panelPrincipal.Controls.Add(txtNombre);
            panelPrincipal.Controls.Add(lblApellido);
            panelPrincipal.Controls.Add(txtApellido);
            panelPrincipal.Controls.Add(lblCorreo);
            panelPrincipal.Controls.Add(txtCorreo);
            panelPrincipal.Controls.Add(btnCancelar);
            panelPrincipal.Controls.Add(btnGuardar);
            panelPrincipal.Location = new Point(29, 79);
            panelPrincipal.Margin = new Padding(7, 8, 7, 8);
            panelPrincipal.Name = "panelPrincipal";
            panelPrincipal.Size = new Size(1561, 1164);
            panelPrincipal.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(60, 60, 60);
            label1.Location = new Point(882, 451);
            label1.Margin = new Padding(7, 0, 7, 0);
            label1.Name = "label1";
            label1.Size = new Size(110, 46);
            label1.TabIndex = 18;
            label1.Tag = "lbl_Nombre";
            label1.Text = "Login";
            // 
            // txt_Login
            // 
            txt_Login.BorderStyle = BorderStyle.FixedSingle;
            txt_Login.Enabled = false;
            txt_Login.Font = new Font("Segoe UI", 10F);
            txt_Login.Location = new Point(882, 552);
            txt_Login.Margin = new Padding(7, 8, 7, 8);
            txt_Login.Name = "txt_Login";
            txt_Login.Size = new Size(604, 52);
            txt_Login.TabIndex = 19;
            // 
            // picLogo
            // 
            picLogo.BorderStyle = BorderStyle.FixedSingle;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(85, 44);
            picLogo.Margin = new Padding(0);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(170, 150);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picLogo.TabIndex = 2;
            picLogo.TabStop = false;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(120, 20, 40);
            lblTitulo.Location = new Point(265, 82);
            lblTitulo.Margin = new Padding(7, 0, 7, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(617, 81);
            lblTitulo.TabIndex = 0;
            lblTitulo.Tag = "lbl_TituloCrearNuevoUsuario";
            lblTitulo.Text = "Crear Nuevo Usuario";
            // 
            // lblDNI
            // 
            lblDNI.AutoSize = true;
            lblDNI.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDNI.ForeColor = Color.FromArgb(60, 60, 60);
            lblDNI.Location = new Point(85, 246);
            lblDNI.Margin = new Padding(7, 0, 7, 0);
            lblDNI.Name = "lblDNI";
            lblDNI.Size = new Size(83, 46);
            lblDNI.TabIndex = 1;
            lblDNI.Tag = "lbl_DNI";
            lblDNI.Text = "DNI";
            // 
            // txtDNI
            // 
            txtDNI.BorderStyle = BorderStyle.FixedSingle;
            txtDNI.Font = new Font("Segoe UI", 10F);
            txtDNI.Location = new Point(85, 306);
            txtDNI.Margin = new Padding(7, 8, 7, 8);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(604, 52);
            txtDNI.TabIndex = 2;
            txtDNI.TextChanged += txtDNI_TextChanged;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(60, 60, 60);
            lblNombre.Location = new Point(85, 451);
            lblNombre.Margin = new Padding(7, 0, 7, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(167, 46);
            lblNombre.TabIndex = 5;
            lblNombre.Tag = "lbl_Nombre";
            lblNombre.Text = "Nombres";
            // 
            // txtNombre
            // 
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 10F);
            txtNombre.Location = new Point(85, 552);
            txtNombre.Margin = new Padding(7, 8, 7, 8);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(604, 52);
            txtNombre.TabIndex = 6;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblApellido.ForeColor = Color.FromArgb(60, 60, 60);
            lblApellido.Location = new Point(882, 246);
            lblApellido.Margin = new Padding(7, 0, 7, 0);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(170, 46);
            lblApellido.TabIndex = 7;
            lblApellido.Tag = "lbl_Apellido";
            lblApellido.Text = "Apellidos";
            // 
            // txtApellido
            // 
            txtApellido.BorderStyle = BorderStyle.FixedSingle;
            txtApellido.Font = new Font("Segoe UI", 10F);
            txtApellido.Location = new Point(882, 306);
            txtApellido.Margin = new Padding(7, 8, 7, 8);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(604, 52);
            txtApellido.TabIndex = 8;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCorreo.ForeColor = Color.FromArgb(60, 60, 60);
            lblCorreo.Location = new Point(85, 692);
            lblCorreo.Margin = new Padding(7, 0, 7, 0);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(316, 46);
            lblCorreo.TabIndex = 9;
            lblCorreo.Tag = "lbl_Correo";
            lblCorreo.Text = "Correo Electrónico";
            // 
            // txtCorreo
            // 
            txtCorreo.BorderStyle = BorderStyle.FixedSingle;
            txtCorreo.Font = new Font("Segoe UI", 10F);
            txtCorreo.Location = new Point(85, 782);
            txtCorreo.Margin = new Padding(7, 8, 7, 8);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(604, 52);
            txtCorreo.TabIndex = 10;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.White;
            btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.FromArgb(120, 20, 40);
            btnCancelar.Location = new Point(85, 940);
            btnCancelar.Margin = new Padding(7, 8, 7, 8);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(495, 142);
            btnCancelar.TabIndex = 16;
            btnCancelar.Tag = "btn_Cancelar";
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(120, 20, 40);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(882, 940);
            btnGuardar.Margin = new Padding(7, 8, 7, 8);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(515, 142);
            btnGuardar.TabIndex = 17;
            btnGuardar.Tag = "btn_Guardar";
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // FormCrearPrimerUsuario
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 238, 235);
            ClientSize = new Size(1627, 1320);
            Controls.Add(panelPrincipal);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(7, 8, 7, 8);
            MaximizeBox = false;
            Name = "FormCrearPrimerUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "lbl_Form_CrearPrimerUsuario";
            Text = "TeatroLux - Crear Primer Usuario";
            Load += FormCrearPrimerUsuario_Load;
            panelPrincipal.ResumeLayout(false);
            panelPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelPrincipal;
        private Label lblTitulo;
        private Label lblDNI;
        private TextBox txtDNI;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblCorreo;
        private TextBox txtCorreo;
        private Button btnCancelar;
        private Button btnGuardar;
        private PictureBox picLogo;
        private Label label1;
        private TextBox txt_Login;
    }
}