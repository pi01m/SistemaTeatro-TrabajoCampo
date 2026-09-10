namespace CuentaClara_TrabajoCampo
{
    partial class FormGestionBitacora
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panelContenedor = new Panel();
            label2 = new Label();
            label1 = new Label();
            lblTitulo = new Label();
            dgvBitacora = new DataGridView();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblLogin = new Label();
            cboLogin = new ComboBox();
            lblFechaInicio = new Label();
            dtpFechaInicio = new DateTimePicker();
            lblFechaFin = new Label();
            dtpFechaFin = new DateTimePicker();
            lblModulo = new Label();
            cboModulo = new ComboBox();
            lblEvento = new Label();
            cboEvento = new ComboBox();
            lblCriticidad = new Label();
            cboCriticidad = new ComboBox();
            lstMensajes = new ListBox();
            btnLimpiar = new Button();
            btnAplicar = new Button();
            btnImprimir = new Button();
            btnSalir = new Button();
            panelInferior = new Panel();
            lblUsuarioValor = new Label();
            lblUsuarioActivo = new Label();
            panelContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBitacora).BeginInit();
            panelInferior.SuspendLayout();
            SuspendLayout();
            // 
            // panelContenedor
            // 
            panelContenedor.Anchor = AnchorStyles.None;
            panelContenedor.BackColor = Color.White;
            panelContenedor.Controls.Add(label2);
            panelContenedor.Controls.Add(label1);
            panelContenedor.Controls.Add(lblTitulo);
            panelContenedor.Controls.Add(dgvBitacora);
            panelContenedor.Controls.Add(lblNombre);
            panelContenedor.Controls.Add(txtNombre);
            panelContenedor.Controls.Add(lblApellido);
            panelContenedor.Controls.Add(txtApellido);
            panelContenedor.Controls.Add(lblLogin);
            panelContenedor.Controls.Add(cboLogin);
            panelContenedor.Controls.Add(lblFechaInicio);
            panelContenedor.Controls.Add(dtpFechaInicio);
            panelContenedor.Controls.Add(lblFechaFin);
            panelContenedor.Controls.Add(dtpFechaFin);
            panelContenedor.Controls.Add(lblModulo);
            panelContenedor.Controls.Add(cboModulo);
            panelContenedor.Controls.Add(lblEvento);
            panelContenedor.Controls.Add(cboEvento);
            panelContenedor.Controls.Add(lblCriticidad);
            panelContenedor.Controls.Add(cboCriticidad);
            panelContenedor.Controls.Add(lstMensajes);
            panelContenedor.Controls.Add(btnLimpiar);
            panelContenedor.Controls.Add(btnAplicar);
            panelContenedor.Controls.Add(btnImprimir);
            panelContenedor.Controls.Add(btnSalir);
            panelContenedor.Location = new Point(29, 33);
            panelContenedor.Margin = new Padding(7, 8, 7, 8);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(3196, 2036);
            panelContenedor.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(60, 60, 60);
            label2.Location = new Point(1872, 1197);
            label2.Margin = new Padding(7, 0, 7, 0);
            label2.Name = "label2";
            label2.Size = new Size(40, 46);
            label2.TabIndex = 24;
            label2.Tag = "";
            label2.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(60, 60, 60);
            label1.Location = new Point(1452, 1197);
            label1.Margin = new Padding(7, 0, 7, 0);
            label1.Name = "label1";
            label1.Size = new Size(344, 46);
            label1.TabIndex = 23;
            label1.Tag = "lbl_CantEventos";
            label1.Text = "Cantidad de Eventos";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(120, 20, 40);
            lblTitulo.Location = new Point(73, 55);
            lblTitulo.Margin = new Padding(7, 0, 7, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(588, 81);
            lblTitulo.TabIndex = 0;
            lblTitulo.Tag = "lbl_TituloBitacoradeEventos";
            lblTitulo.Text = "Bitácora de Eventos";
            // 
            // dgvBitacora
            // 
            dgvBitacora.AllowUserToAddRows = false;
            dgvBitacora.AllowUserToDeleteRows = false;
            dgvBitacora.AllowUserToResizeRows = false;
            dgvBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBitacora.BackgroundColor = Color.FromArgb(120, 20, 40);
            dgvBitacora.BorderStyle = BorderStyle.None;
            dgvBitacora.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvBitacora.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(235, 230, 225);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(120, 20, 40);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(235, 230, 225);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(120, 20, 40);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvBitacora.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvBitacora.ColumnHeadersHeight = 35;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(120, 20, 40);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvBitacora.DefaultCellStyle = dataGridViewCellStyle4;
            dgvBitacora.EnableHeadersVisualStyles = false;
            dgvBitacora.GridColor = Color.FromArgb(220, 220, 220);
            dgvBitacora.Location = new Point(73, 191);
            dgvBitacora.Margin = new Padding(7, 8, 7, 8);
            dgvBitacora.MultiSelect = false;
            dgvBitacora.Name = "dgvBitacora";
            dgvBitacora.ReadOnly = true;
            dgvBitacora.RowHeadersVisible = false;
            dgvBitacora.RowHeadersWidth = 102;
            dgvBitacora.RowTemplate.Height = 28;
            dgvBitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBitacora.Size = new Size(3009, 921);
            dgvBitacora.TabIndex = 1;
            dgvBitacora.SelectionChanged += dgvBitacora_SelectionChanged;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(60, 60, 60);
            lblNombre.Location = new Point(83, 1197);
            lblNombre.Margin = new Padding(7, 0, 7, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(152, 46);
            lblNombre.TabIndex = 2;
            lblNombre.Tag = "lbl_Nombre";
            lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 10F);
            txtNombre.Location = new Point(83, 1266);
            txtNombre.Margin = new Padding(7, 8, 7, 8);
            txtNombre.Name = "txtNombre";
            txtNombre.ReadOnly = true;
            txtNombre.Size = new Size(434, 52);
            txtNombre.TabIndex = 3;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblApellido.ForeColor = Color.FromArgb(60, 60, 60);
            lblApellido.Location = new Point(617, 1197);
            lblApellido.Margin = new Padding(7, 0, 7, 0);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(155, 46);
            lblApellido.TabIndex = 4;
            lblApellido.Tag = "lbl_Apellido";
            lblApellido.Text = "Apellido";
            // 
            // txtApellido
            // 
            txtApellido.BorderStyle = BorderStyle.FixedSingle;
            txtApellido.Font = new Font("Segoe UI", 10F);
            txtApellido.Location = new Point(617, 1266);
            txtApellido.Margin = new Padding(7, 8, 7, 8);
            txtApellido.Name = "txtApellido";
            txtApellido.ReadOnly = true;
            txtApellido.Size = new Size(434, 52);
            txtApellido.TabIndex = 5;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLogin.ForeColor = Color.FromArgb(60, 60, 60);
            lblLogin.Location = new Point(73, 1391);
            lblLogin.Margin = new Padding(7, 0, 7, 0);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(110, 46);
            lblLogin.TabIndex = 6;
            lblLogin.Tag = "lbl_NomdeLogin";
            lblLogin.Text = "Login";
            // 
            // cboLogin
            // 
            cboLogin.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLogin.Font = new Font("Segoe UI", 10F);
            cboLogin.Location = new Point(73, 1460);
            cboLogin.Margin = new Padding(7, 8, 7, 8);
            cboLogin.Name = "cboLogin";
            cboLogin.Size = new Size(359, 53);
            cboLogin.TabIndex = 7;
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFechaInicio.ForeColor = Color.FromArgb(60, 60, 60);
            lblFechaInicio.Location = new Point(614, 1391);
            lblFechaInicio.Margin = new Padding(7, 0, 7, 0);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(208, 46);
            lblFechaInicio.TabIndex = 8;
            lblFechaInicio.Tag = "lbl_FechaInicio";
            lblFechaInicio.Text = "Fecha Inicio";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Font = new Font("Segoe UI", 10F);
            dtpFechaInicio.Location = new Point(614, 1460);
            dtpFechaInicio.Margin = new Padding(7, 8, 7, 8);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(431, 52);
            dtpFechaInicio.TabIndex = 9;
            // 
            // lblFechaFin
            // 
            lblFechaFin.AutoSize = true;
            lblFechaFin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFechaFin.ForeColor = Color.FromArgb(60, 60, 60);
            lblFechaFin.Location = new Point(1124, 1391);
            lblFechaFin.Margin = new Padding(7, 0, 7, 0);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(168, 46);
            lblFechaFin.TabIndex = 10;
            lblFechaFin.Tag = "lbl_FechaFin";
            lblFechaFin.Text = "Fecha Fin";
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Font = new Font("Segoe UI", 10F);
            dtpFechaFin.Location = new Point(1124, 1460);
            dtpFechaFin.Margin = new Padding(7, 8, 7, 8);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(431, 52);
            dtpFechaFin.TabIndex = 11;
            // 
            // lblModulo
            // 
            lblModulo.AutoSize = true;
            lblModulo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblModulo.ForeColor = Color.FromArgb(60, 60, 60);
            lblModulo.Location = new Point(1634, 1391);
            lblModulo.Margin = new Padding(7, 0, 7, 0);
            lblModulo.Name = "lblModulo";
            lblModulo.Size = new Size(147, 46);
            lblModulo.TabIndex = 12;
            lblModulo.Tag = "lbl_Modulo";
            lblModulo.Text = "Módulo";
            // 
            // cboModulo
            // 
            cboModulo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboModulo.Font = new Font("Segoe UI", 10F);
            cboModulo.Items.AddRange(new object[] { "Administración", "Seguridad", "Gestión de Perfiles y Autorización" });
            cboModulo.Location = new Point(1634, 1460);
            cboModulo.Margin = new Padding(7, 8, 7, 8);
            cboModulo.Name = "cboModulo";
            cboModulo.Size = new Size(286, 53);
            cboModulo.TabIndex = 13;
            // 
            // lblEvento
            // 
            lblEvento.AutoSize = true;
            lblEvento.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEvento.ForeColor = Color.FromArgb(60, 60, 60);
            lblEvento.Location = new Point(1999, 1391);
            lblEvento.Margin = new Padding(7, 0, 7, 0);
            lblEvento.Name = "lblEvento";
            lblEvento.Size = new Size(129, 46);
            lblEvento.TabIndex = 14;
            lblEvento.Tag = "lbl_Evento";
            lblEvento.Text = "Evento";
            // 
            // cboEvento
            // 
            cboEvento.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEvento.Font = new Font("Segoe UI", 10F);
            cboEvento.Items.AddRange(new object[] { "Login Correcto", "Login Incorrecto", "Logout", "Usuario Desbloqueado", "Intento de login bloqueado", "Usuario Bloqueado o Inactivo", "Usuario Modificado", "Usuario Creado", "Modificar Usuario", "Activar Usuario", "Desactivar Usuario", "Impresión/Exportación de Bitácora", "Cambio Clave", "Asignación familia a rol", "Asignación familia a familia", "Asignación permiso a rol", "Asignación permiso a familia", "Permiso asignado a Familia", "Permiso desasignado de Familia", "Subfamilia desasignada de Familia", "Modificación Familia", "Baja Familia", "Alta Familia", "Desasignación en Perfiles", "Cambio de Idioma en Sesión", "Actualización de Idioma", "Violación de integridad detectada", "Recalculo de Dígitos Verificadores de Usuario", "Acceso de emergencia por violación de integridad", "Violación de integridad en la tabla", "Violación de integridad crítica" });
            cboEvento.Location = new Point(1999, 1460);
            cboEvento.Margin = new Padding(7, 8, 7, 8);
            cboEvento.Name = "cboEvento";
            cboEvento.Size = new Size(609, 53);
            cboEvento.TabIndex = 15;
            cboEvento.SelectedIndexChanged += cboEvento_SelectedIndexChanged;
            // 
            // lblCriticidad
            // 
            lblCriticidad.AutoSize = true;
            lblCriticidad.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCriticidad.ForeColor = Color.FromArgb(60, 60, 60);
            lblCriticidad.Location = new Point(2681, 1399);
            lblCriticidad.Margin = new Padding(7, 0, 7, 0);
            lblCriticidad.Name = "lblCriticidad";
            lblCriticidad.Size = new Size(174, 46);
            lblCriticidad.TabIndex = 16;
            lblCriticidad.Tag = "lbl_Criticidad";
            lblCriticidad.Text = "Criticidad";
            // 
            // cboCriticidad
            // 
            cboCriticidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCriticidad.Font = new Font("Segoe UI", 10F);
            cboCriticidad.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            cboCriticidad.Location = new Point(2681, 1468);
            cboCriticidad.Margin = new Padding(7, 8, 7, 8);
            cboCriticidad.Name = "cboCriticidad";
            cboCriticidad.Size = new Size(286, 53);
            cboCriticidad.TabIndex = 17;
            // 
            // lstMensajes
            // 
            lstMensajes.BorderStyle = BorderStyle.FixedSingle;
            lstMensajes.Font = new Font("Segoe UI", 9F);
            lstMensajes.ItemHeight = 41;
            lstMensajes.Location = new Point(73, 1544);
            lstMensajes.Margin = new Padding(7, 8, 7, 8);
            lstMensajes.Name = "lstMensajes";
            lstMensajes.Size = new Size(2897, 125);
            lstMensajes.TabIndex = 18;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.White;
            btnLimpiar.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.FromArgb(120, 20, 40);
            btnLimpiar.Location = new Point(954, 1785);
            btnLimpiar.Margin = new Padding(7, 8, 7, 8);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(291, 104);
            btnLimpiar.TabIndex = 19;
            btnLimpiar.Tag = "btn_Limpiar";
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnAplicar
            // 
            btnAplicar.BackColor = Color.FromArgb(120, 20, 40);
            btnAplicar.FlatAppearance.BorderSize = 0;
            btnAplicar.FlatStyle = FlatStyle.Flat;
            btnAplicar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAplicar.ForeColor = Color.White;
            btnAplicar.Location = new Point(1294, 1785);
            btnAplicar.Margin = new Padding(7, 8, 7, 8);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(291, 104);
            btnAplicar.TabIndex = 20;
            btnAplicar.Tag = "btn_Aplicar";
            btnAplicar.Text = "Aplicar";
            btnAplicar.UseVisualStyleBackColor = false;
            btnAplicar.Click += btnAplicar_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.White;
            btnImprimir.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnImprimir.ForeColor = Color.FromArgb(120, 20, 40);
            btnImprimir.Location = new Point(1634, 1785);
            btnImprimir.Margin = new Padding(7, 8, 7, 8);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(291, 104);
            btnImprimir.TabIndex = 21;
            btnImprimir.Tag = "btn_Imprimir";
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.White;
            btnSalir.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalir.ForeColor = Color.FromArgb(120, 20, 40);
            btnSalir.Location = new Point(2742, 57);
            btnSalir.Margin = new Padding(7, 8, 7, 8);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(340, 104);
            btnSalir.TabIndex = 22;
            btnSalir.Tag = "btn_Salir";
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // panelInferior
            // 
            panelInferior.BackColor = Color.FromArgb(120, 20, 40);
            panelInferior.Controls.Add(lblUsuarioValor);
            panelInferior.Controls.Add(lblUsuarioActivo);
            panelInferior.Dock = DockStyle.Bottom;
            panelInferior.Location = new Point(0, 2004);
            panelInferior.Margin = new Padding(7, 8, 7, 8);
            panelInferior.Name = "panelInferior";
            panelInferior.Size = new Size(3254, 104);
            panelInferior.TabIndex = 0;
            // 
            // lblUsuarioValor
            // 
            lblUsuarioValor.AutoSize = true;
            lblUsuarioValor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsuarioValor.ForeColor = Color.White;
            lblUsuarioValor.Location = new Point(277, 27);
            lblUsuarioValor.Margin = new Padding(7, 0, 7, 0);
            lblUsuarioValor.Name = "lblUsuarioValor";
            lblUsuarioValor.Size = new Size(415, 41);
            lblUsuarioValor.TabIndex = 1;
            lblUsuarioValor.Text = "Maria Lopez -Administrador";
            lblUsuarioValor.Click += lblUsuarioValor_Click;
            // 
            // lblUsuarioActivo
            // 
            lblUsuarioActivo.AutoSize = true;
            lblUsuarioActivo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsuarioActivo.ForeColor = Color.White;
            lblUsuarioActivo.Location = new Point(49, 27);
            lblUsuarioActivo.Margin = new Padding(7, 0, 7, 0);
            lblUsuarioActivo.Name = "lblUsuarioActivo";
            lblUsuarioActivo.Size = new Size(235, 41);
            lblUsuarioActivo.TabIndex = 0;
            lblUsuarioActivo.Tag = "lbl_Usuario";
            lblUsuarioActivo.Text = "Usuario activo: ";
            // 
            // FormGestionBitacora
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 238, 235);
            ClientSize = new Size(3254, 2108);
            Controls.Add(panelInferior);
            Controls.Add(panelContenedor);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(7, 8, 7, 8);
            Name = "FormGestionBitacora";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "lbl_FormBitacora";
            Text = "TeatroLux - Gestión de Bitácora";
            FormClosed += FormGestionBitacora_FormClosed;
            Load += FormGestionBitacora_Load_1;
            Resize += FormGestionBitacora_Resize;
            panelContenedor.ResumeLayout(false);
            panelContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBitacora).EndInit();
            panelInferior.ResumeLayout(false);
            panelInferior.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor;

        private System.Windows.Forms.Label lblTitulo;

        private System.Windows.Forms.DataGridView dgvBitacora;

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;

        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;

        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.ComboBox cboLogin;

        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;

        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;

        private System.Windows.Forms.Label lblModulo;
        private System.Windows.Forms.ComboBox cboModulo;

        private System.Windows.Forms.Label lblEvento;
        private System.Windows.Forms.ComboBox cboEvento;

        private System.Windows.Forms.Label lblCriticidad;
        private System.Windows.Forms.ComboBox cboCriticidad;

        private System.Windows.Forms.ListBox lstMensajes;

        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnSalir;

        private System.Windows.Forms.Panel panelInferior;
        private System.Windows.Forms.Label lblUsuarioActivo;
        private Label lblUsuarioValor;
        private Label label2;
        private Label label1;
    }
}