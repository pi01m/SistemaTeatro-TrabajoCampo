namespace CuentaClara_TrabajoCampo
{
    partial class FormCrearUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCrearUsuario));
            panelPrincipal = new Panel();
            picLogo = new PictureBox();
            lblTitulo = new Label();
            lblDNI = new Label();
            txtDNI = new TextBox();
            lblRol = new Label();
            cmbRol = new ComboBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblCorreo = new Label();
            txtCorreo = new TextBox();
            chkActivo = new CheckBox();
            btnCancelar = new Button();
            btnGuardar = new Button();
            panelPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // panelPrincipal
            // 
            panelPrincipal.Anchor = AnchorStyles.None;
            panelPrincipal.BackColor = Color.White;
            panelPrincipal.BorderStyle = BorderStyle.FixedSingle;
            panelPrincipal.Controls.Add(picLogo);
            panelPrincipal.Controls.Add(lblTitulo);
            panelPrincipal.Controls.Add(lblDNI);
            panelPrincipal.Controls.Add(txtDNI);
            panelPrincipal.Controls.Add(lblRol);
            panelPrincipal.Controls.Add(cmbRol);
            panelPrincipal.Controls.Add(lblNombre);
            panelPrincipal.Controls.Add(txtNombre);
            panelPrincipal.Controls.Add(lblApellido);
            panelPrincipal.Controls.Add(txtApellido);
            panelPrincipal.Controls.Add(lblCorreo);
            panelPrincipal.Controls.Add(txtCorreo);
            panelPrincipal.Controls.Add(chkActivo);
            panelPrincipal.Controls.Add(btnCancelar);
            panelPrincipal.Controls.Add(btnGuardar);
            panelPrincipal.Location = new Point(26, 25);
            panelPrincipal.Name = "panelPrincipal";
            panelPrincipal.Size = new Size(801, 632);
            panelPrincipal.TabIndex = 0;
            panelPrincipal.Paint += panelPrincipal_Paint;
            // 
            // picLogo
            // 
            picLogo.BorderStyle = BorderStyle.FixedSingle;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(53, 14);
            picLogo.Margin = new Padding(0);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(71, 57);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picLogo.TabIndex = 18;
            picLogo.TabStop = false;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(120, 20, 40);
            lblTitulo.Location = new Point(146, 27);
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
            lblDNI.Location = new Point(53, 118);
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
            txtDNI.Location = new Point(53, 140);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(250, 52);
            txtDNI.TabIndex = 2;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRol.ForeColor = Color.FromArgb(60, 60, 60);
            lblRol.Location = new Point(478, 108);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(232, 46);
            lblRol.TabIndex = 3;
            lblRol.Tag = "lbl_RolAsignado";
            lblRol.Text = "Rol Asignado";
            // 
            // cmbRol
            // 
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.Font = new Font("Segoe UI", 10F);
            cmbRol.Items.AddRange(new object[] { "Admin", "Operador" });
            cmbRol.Location = new Point(478, 140);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(250, 53);
            cmbRol.TabIndex = 4;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(60, 60, 60);
            lblNombre.Location = new Point(53, 193);
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
            txtNombre.Location = new Point(53, 230);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(250, 52);
            txtNombre.TabIndex = 6;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblApellido.ForeColor = Color.FromArgb(60, 60, 60);
            lblApellido.Location = new Point(478, 204);
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
            txtApellido.Location = new Point(478, 230);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(250, 52);
            txtApellido.TabIndex = 8;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCorreo.ForeColor = Color.FromArgb(60, 60, 60);
            lblCorreo.Location = new Point(53, 281);
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
            txtCorreo.Location = new Point(53, 314);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(250, 52);
            txtCorreo.TabIndex = 10;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkActivo.ForeColor = Color.FromArgb(120, 20, 40);
            chkActivo.Location = new Point(53, 384);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(454, 50);
            chkActivo.TabIndex = 15;
            chkActivo.Tag = "chk_Activo";
            chkActivo.Text = "Habilitar Acceso (Activo)";
            chkActivo.CheckedChanged += chkActivo_CheckedChanged;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.White;
            btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.FromArgb(120, 20, 40);
            btnCancelar.Location = new Point(83, 520);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(204, 52);
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
            btnGuardar.Location = new Point(478, 520);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(212, 52);
            btnGuardar.TabIndex = 17;
            btnGuardar.Tag = "btn_Guardar";
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // FormCrearUsuario
            // 
            AutoScaleDimensions = new SizeF(18F, 45F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 238, 235);
            ClientSize = new Size(856, 669);
            Controls.Add(panelPrincipal);
            Font = new Font("Segoe UI", 10F);
            MaximizeBox = false;
            MinimumSize = new Size(872, 708);
            Name = "FormCrearUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "lbl_FormCrearUsuario";
            Text = "TeatroLux - Crear Usuario";
            FormClosed += FormCrearUsuario_FormClosed;
            Load += FormCrearUsuario_Load_1;
            Resize += FormCrearUsuario_Resize;
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

        private Label lblRol;
        private ComboBox cmbRol;

        private CheckBox chkActivo;

        private Button btnGuardar;
        private Button btnCancelar;
        private PictureBox picLogo;
    }
}