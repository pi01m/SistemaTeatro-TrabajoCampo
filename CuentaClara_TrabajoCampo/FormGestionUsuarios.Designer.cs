namespace CuentaClara_TrabajoCampo
{
    partial class FormGestionUsuarios
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
            cmbRol = new ComboBox();
            radioBtnTodosUser = new RadioButton();
            radioBtnUserActivos = new RadioButton();
            lblDNI = new Label();
            txtDNI = new TextBox();
            lblRol = new Label();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblCorreo = new Label();
            txtCorreo = new TextBox();
            lblLogin = new Label();
            txtLogin = new TextBox();
            chkActivo = new CheckBox();
            lblTitulo = new Label();
            dgvUsuarios = new DataGridView();
            btnCrear = new Button();
            btnDesbloquear = new Button();
            btnModificar = new Button();
            btnActivarDesactivar = new Button();
            btnAplicar = new Button();
            btnCancelar = new Button();
            btnSalir = new Button();
            lblCantidadUsuarios = new Label();
            lblTotalUsuarios = new Label();
            lstMensajes = new ListBox();
            panelInferior = new Panel();
            label1 = new Label();
            lblUsuarioActivo = new Label();
            panelContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            panelInferior.SuspendLayout();
            SuspendLayout();
            // 
            // panelContenedor
            // 
            panelContenedor.Anchor = AnchorStyles.None;
            panelContenedor.BackColor = Color.FromArgb(240, 238, 235);
            panelContenedor.Controls.Add(cmbRol);
            panelContenedor.Controls.Add(radioBtnTodosUser);
            panelContenedor.Controls.Add(radioBtnUserActivos);
            panelContenedor.Controls.Add(lblDNI);
            panelContenedor.Controls.Add(txtDNI);
            panelContenedor.Controls.Add(lblRol);
            panelContenedor.Controls.Add(lblNombre);
            panelContenedor.Controls.Add(txtNombre);
            panelContenedor.Controls.Add(lblApellido);
            panelContenedor.Controls.Add(txtApellido);
            panelContenedor.Controls.Add(lblCorreo);
            panelContenedor.Controls.Add(txtCorreo);
            panelContenedor.Controls.Add(lblLogin);
            panelContenedor.Controls.Add(txtLogin);
            panelContenedor.Controls.Add(chkActivo);
            panelContenedor.Controls.Add(lblTitulo);
            panelContenedor.Controls.Add(dgvUsuarios);
            panelContenedor.Controls.Add(btnCrear);
            panelContenedor.Controls.Add(btnDesbloquear);
            panelContenedor.Controls.Add(btnModificar);
            panelContenedor.Controls.Add(btnActivarDesactivar);
            panelContenedor.Controls.Add(btnAplicar);
            panelContenedor.Controls.Add(btnCancelar);
            panelContenedor.Controls.Add(btnSalir);
            panelContenedor.Controls.Add(lblCantidadUsuarios);
            panelContenedor.Controls.Add(lblTotalUsuarios);
            panelContenedor.Controls.Add(lstMensajes);
            panelContenedor.Location = new Point(0, 0);
            panelContenedor.Margin = new Padding(7, 8, 7, 8);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(3055, 2012);
            panelContenedor.TabIndex = 0;
            // 
            // cmbRol
            // 
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(449, 1807);
            cmbRol.Margin = new Padding(7, 8, 7, 8);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(502, 49);
            cmbRol.TabIndex = 34;
            // 
            // radioBtnTodosUser
            // 
            radioBtnTodosUser.AutoSize = true;
            radioBtnTodosUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            radioBtnTodosUser.ForeColor = Color.FromArgb(120, 20, 40);
            radioBtnTodosUser.Location = new Point(525, 186);
            radioBtnTodosUser.Margin = new Padding(7, 8, 7, 8);
            radioBtnTodosUser.Name = "radioBtnTodosUser";
            radioBtnTodosUser.Size = new Size(300, 50);
            radioBtnTodosUser.TabIndex = 33;
            radioBtnTodosUser.TabStop = true;
            radioBtnTodosUser.Tag = "btn_TodosUsuarios";
            radioBtnTodosUser.Text = "Todos Usuarios";
            radioBtnTodosUser.UseVisualStyleBackColor = true;
            radioBtnTodosUser.CheckedChanged += radioBtnTodosUser_CheckedChanged;
            // 
            // radioBtnUserActivos
            // 
            radioBtnUserActivos.AutoSize = true;
            radioBtnUserActivos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            radioBtnUserActivos.ForeColor = Color.FromArgb(120, 20, 40);
            radioBtnUserActivos.Location = new Point(95, 186);
            radioBtnUserActivos.Margin = new Padding(7, 8, 7, 8);
            radioBtnUserActivos.Name = "radioBtnUserActivos";
            radioBtnUserActivos.Size = new Size(322, 50);
            radioBtnUserActivos.TabIndex = 32;
            radioBtnUserActivos.TabStop = true;
            radioBtnUserActivos.Tag = "btn_UsuarioActivos";
            radioBtnUserActivos.Text = "Usuarios Activos";
            radioBtnUserActivos.UseVisualStyleBackColor = true;
            radioBtnUserActivos.CheckedChanged += radioBtnUserActivos_CheckedChanged;
            // 
            // lblDNI
            // 
            lblDNI.AutoSize = true;
            lblDNI.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDNI.ForeColor = Color.FromArgb(60, 60, 60);
            lblDNI.Location = new Point(85, 1222);
            lblDNI.Margin = new Padding(7, 0, 7, 0);
            lblDNI.Name = "lblDNI";
            lblDNI.Size = new Size(83, 46);
            lblDNI.TabIndex = 16;
            lblDNI.Tag = "lbl_DNI";
            lblDNI.Text = "DNI";
            // 
            // txtDNI
            // 
            txtDNI.BorderStyle = BorderStyle.FixedSingle;
            txtDNI.Location = new Point(449, 1222);
            txtDNI.Margin = new Padding(7, 8, 7, 8);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(505, 47);
            txtDNI.TabIndex = 17;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRol.ForeColor = Color.FromArgb(60, 60, 60);
            lblRol.Location = new Point(97, 1818);
            lblRol.Margin = new Padding(7, 0, 7, 0);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(232, 46);
            lblRol.TabIndex = 18;
            lblRol.Tag = "lbl_RolAsignado";
            lblRol.Text = "Rol Asignado";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(60, 60, 60);
            lblNombre.Location = new Point(85, 1328);
            lblNombre.Margin = new Padding(7, 0, 7, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(167, 46);
            lblNombre.TabIndex = 20;
            lblNombre.Tag = "lbl_Nombre";
            lblNombre.Text = "Nombres";
            // 
            // txtNombre
            // 
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Location = new Point(449, 1328);
            txtNombre.Margin = new Padding(7, 8, 7, 8);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(505, 47);
            txtNombre.TabIndex = 21;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblApellido.ForeColor = Color.FromArgb(60, 60, 60);
            lblApellido.Location = new Point(85, 1435);
            lblApellido.Margin = new Padding(7, 0, 7, 0);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(170, 46);
            lblApellido.TabIndex = 22;
            lblApellido.Tag = "lbl_Apellido";
            lblApellido.Text = "Apellidos";
            // 
            // txtApellido
            // 
            txtApellido.BorderStyle = BorderStyle.FixedSingle;
            txtApellido.Location = new Point(449, 1435);
            txtApellido.Margin = new Padding(7, 8, 7, 8);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(505, 47);
            txtApellido.TabIndex = 23;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCorreo.ForeColor = Color.FromArgb(60, 60, 60);
            lblCorreo.Location = new Point(90, 1561);
            lblCorreo.Margin = new Padding(7, 0, 7, 0);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(316, 46);
            lblCorreo.TabIndex = 24;
            lblCorreo.Tag = "lbl_Correo";
            lblCorreo.Text = "Correo Electrónico";
            // 
            // txtCorreo
            // 
            txtCorreo.BorderStyle = BorderStyle.FixedSingle;
            txtCorreo.Location = new Point(449, 1550);
            txtCorreo.Margin = new Padding(7, 8, 7, 8);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(505, 47);
            txtCorreo.TabIndex = 25;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLogin.ForeColor = Color.FromArgb(60, 60, 60);
            lblLogin.Location = new Point(97, 1670);
            lblLogin.Margin = new Padding(7, 0, 7, 0);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(299, 46);
            lblLogin.TabIndex = 26;
            lblLogin.Tag = "lbl_NomdeLogin";
            lblLogin.Text = "Nombre de Login";
            // 
            // txtLogin
            // 
            txtLogin.BorderStyle = BorderStyle.FixedSingle;
            txtLogin.Location = new Point(449, 1684);
            txtLogin.Margin = new Padding(7, 8, 7, 8);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(505, 47);
            txtLogin.TabIndex = 27;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkActivo.ForeColor = Color.FromArgb(120, 20, 40);
            chkActivo.Location = new Point(449, 1897);
            chkActivo.Margin = new Padding(7, 8, 7, 8);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(454, 50);
            chkActivo.TabIndex = 30;
            chkActivo.Tag = "chk_Activo";
            chkActivo.Text = "Habilitar Acceso (Activo)";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(120, 20, 40);
            lblTitulo.Location = new Point(73, 55);
            lblTitulo.Margin = new Padding(7, 0, 7, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(661, 89);
            lblTitulo.TabIndex = 0;
            lblTitulo.Tag = "lbl_GestionDeUsuarios";
            lblTitulo.Text = "Gestión de Usuarios";
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AllowUserToResizeRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.BackgroundColor = Color.FromArgb(120, 20, 40);
            dgvUsuarios.BorderStyle = BorderStyle.None;
            dgvUsuarios.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsuarios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(235, 230, 225);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(120, 20, 40);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(235, 230, 225);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(120, 20, 40);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvUsuarios.ColumnHeadersHeight = 35;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(120, 20, 40);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvUsuarios.DefaultCellStyle = dataGridViewCellStyle4;
            dgvUsuarios.EnableHeadersVisualStyles = false;
            dgvUsuarios.GridColor = Color.FromArgb(220, 220, 220);
            dgvUsuarios.Location = new Point(85, 287);
            dgvUsuarios.Margin = new Padding(7, 8, 7, 8);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.RowHeadersWidth = 102;
            dgvUsuarios.RowTemplate.Height = 32;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(2365, 875);
            dgvUsuarios.TabIndex = 1;
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;
            // 
            // btnCrear
            // 
            btnCrear.BackColor = Color.FromArgb(120, 20, 40);
            btnCrear.FlatAppearance.BorderSize = 0;
            btnCrear.FlatStyle = FlatStyle.Flat;
            btnCrear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCrear.ForeColor = Color.White;
            btnCrear.Location = new Point(2594, 364);
            btnCrear.Margin = new Padding(7, 8, 7, 8);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(340, 115);
            btnCrear.TabIndex = 2;
            btnCrear.Tag = "btn_Crear";
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = false;
            btnCrear.Click += btnCrear_Click;
            // 
            // btnDesbloquear
            // 
            btnDesbloquear.BackColor = Color.White;
            btnDesbloquear.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnDesbloquear.FlatStyle = FlatStyle.Flat;
            btnDesbloquear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDesbloquear.ForeColor = Color.FromArgb(120, 20, 40);
            btnDesbloquear.Location = new Point(2594, 558);
            btnDesbloquear.Margin = new Padding(7, 8, 7, 8);
            btnDesbloquear.Name = "btnDesbloquear";
            btnDesbloquear.Size = new Size(340, 115);
            btnDesbloquear.TabIndex = 3;
            btnDesbloquear.Tag = "btn_Desbloquear";
            btnDesbloquear.Text = "Desbloquear";
            btnDesbloquear.UseVisualStyleBackColor = false;
            btnDesbloquear.Click += btnDesbloquear_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.White;
            btnModificar.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnModificar.ForeColor = Color.FromArgb(120, 20, 40);
            btnModificar.Location = new Point(2594, 749);
            btnModificar.Margin = new Padding(7, 8, 7, 8);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(340, 115);
            btnModificar.TabIndex = 4;
            btnModificar.Tag = "btn_Modificar";
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnActivarDesactivar
            // 
            btnActivarDesactivar.BackColor = Color.White;
            btnActivarDesactivar.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnActivarDesactivar.FlatStyle = FlatStyle.Flat;
            btnActivarDesactivar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnActivarDesactivar.ForeColor = Color.FromArgb(120, 20, 40);
            btnActivarDesactivar.Location = new Point(2594, 924);
            btnActivarDesactivar.Margin = new Padding(7, 8, 7, 8);
            btnActivarDesactivar.Name = "btnActivarDesactivar";
            btnActivarDesactivar.Size = new Size(340, 139);
            btnActivarDesactivar.TabIndex = 5;
            btnActivarDesactivar.Tag = "btn_Activar/Desactivar";
            btnActivarDesactivar.Text = "Activar / Desactivar";
            btnActivarDesactivar.UseVisualStyleBackColor = false;
            btnActivarDesactivar.Click += btnActivarDesactivar_Click;
            // 
            // btnAplicar
            // 
            btnAplicar.BackColor = Color.FromArgb(120, 20, 40);
            btnAplicar.FlatAppearance.BorderSize = 0;
            btnAplicar.FlatStyle = FlatStyle.Flat;
            btnAplicar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAplicar.ForeColor = Color.White;
            btnAplicar.Location = new Point(1365, 1818);
            btnAplicar.Margin = new Padding(7, 8, 7, 8);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(340, 115);
            btnAplicar.TabIndex = 6;
            btnAplicar.Tag = "btn_Aplicar";
            btnAplicar.Text = "Aplicar";
            btnAplicar.UseVisualStyleBackColor = false;
            btnAplicar.Click += btnAplicar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.White;
            btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.FromArgb(120, 20, 40);
            btnCancelar.Location = new Point(2004, 1818);
            btnCancelar.Margin = new Padding(7, 8, 7, 8);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(340, 115);
            btnCancelar.TabIndex = 7;
            btnCancelar.Tag = "btn_Cancelar";
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.White;
            btnSalir.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalir.ForeColor = Color.FromArgb(120, 20, 40);
            btnSalir.Location = new Point(2618, 1818);
            btnSalir.Margin = new Padding(7, 8, 7, 8);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(340, 115);
            btnSalir.TabIndex = 8;
            btnSalir.Tag = "btn_Salir";
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblCantidadUsuarios
            // 
            lblCantidadUsuarios.AutoSize = true;
            lblCantidadUsuarios.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCantidadUsuarios.ForeColor = Color.FromArgb(60, 60, 60);
            lblCantidadUsuarios.Location = new Point(1897, 202);
            lblCantidadUsuarios.Margin = new Padding(7, 0, 7, 0);
            lblCantidadUsuarios.Name = "lblCantidadUsuarios";
            lblCantidadUsuarios.Size = new Size(304, 46);
            lblCantidadUsuarios.TabIndex = 4;
            lblCantidadUsuarios.Tag = "lbl_TotalDeUsuarios";
            lblCantidadUsuarios.Text = "Total de Usuarios:";
            // 
            // lblTotalUsuarios
            // 
            lblTotalUsuarios.AutoSize = true;
            lblTotalUsuarios.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalUsuarios.ForeColor = Color.FromArgb(120, 20, 40);
            lblTotalUsuarios.Location = new Point(2283, 202);
            lblTotalUsuarios.Margin = new Padding(7, 0, 7, 0);
            lblTotalUsuarios.Name = "lblTotalUsuarios";
            lblTotalUsuarios.Size = new Size(60, 46);
            lblTotalUsuarios.TabIndex = 5;
            lblTotalUsuarios.Text = "15";
            // 
            // lstMensajes
            // 
            lstMensajes.BorderStyle = BorderStyle.FixedSingle;
            lstMensajes.Font = new Font("Segoe UI", 9F);
            lstMensajes.FormattingEnabled = true;
            lstMensajes.ItemHeight = 41;
            lstMensajes.Location = new Point(1343, 1249);
            lstMensajes.Margin = new Padding(7, 8, 7, 8);
            lstMensajes.Name = "lstMensajes";
            lstMensajes.Size = new Size(1612, 494);
            lstMensajes.TabIndex = 6;
            // 
            // panelInferior
            // 
            panelInferior.BackColor = Color.FromArgb(120, 20, 40);
            panelInferior.Controls.Add(label1);
            panelInferior.Controls.Add(lblUsuarioActivo);
            panelInferior.Dock = DockStyle.Bottom;
            panelInferior.Location = new Point(0, 1999);
            panelInferior.Margin = new Padding(7, 8, 7, 8);
            panelInferior.Name = "panelInferior";
            panelInferior.Size = new Size(3169, 109);
            panelInferior.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(279, 33);
            label1.Margin = new Padding(7, 0, 7, 0);
            label1.Name = "label1";
            label1.Size = new Size(407, 41);
            label1.TabIndex = 1;
            label1.Tag = "";
            label1.Text = "Maria Lopez-Administrador";
            // 
            // lblUsuarioActivo
            // 
            lblUsuarioActivo.AutoSize = true;
            lblUsuarioActivo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsuarioActivo.ForeColor = Color.White;
            lblUsuarioActivo.Location = new Point(49, 33);
            lblUsuarioActivo.Margin = new Padding(7, 0, 7, 0);
            lblUsuarioActivo.Name = "lblUsuarioActivo";
            lblUsuarioActivo.Size = new Size(227, 41);
            lblUsuarioActivo.TabIndex = 0;
            lblUsuarioActivo.Tag = "lbl_Usuario";
            lblUsuarioActivo.Text = "Usuario activo:";
            // 
            // FormGestionUsuarios
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = Color.FromArgb(240, 238, 235);
            ClientSize = new Size(3169, 2108);
            Controls.Add(panelInferior);
            Controls.Add(panelContenedor);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(7, 8, 7, 8);
            Name = "FormGestionUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TeatroLux - Gestión de Usuarios";
            FormClosed += FormGestionUsuarios_FormClosed;
            Load += FormGestionUsuarios_Load_1;
            Resize += FormGestionUsuarios_Resize;
            panelContenedor.ResumeLayout(false);
            panelContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            panelInferior.ResumeLayout(false);
            panelInferior.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvUsuarios;

        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnDesbloquear;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnActivarDesactivar;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalir;

        private System.Windows.Forms.Label lblCantidadUsuarios;
        private System.Windows.Forms.Label lblTotalUsuarios;

        private System.Windows.Forms.ListBox lstMensajes;

        private System.Windows.Forms.Panel panelInferior;
        private System.Windows.Forms.Label lblUsuarioActivo;
        private Label lblDNI;
        private TextBox txtDNI;
        private Label lblRol;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblCorreo;
        private TextBox txtCorreo;
        private Label lblLogin;
        private TextBox txtLogin;
        private CheckBox chkActivo;
        private RadioButton radioBtnUserActivos;
        private RadioButton radioBtnTodosUser;
        private ComboBox cmbRol;
        private Label label1;
    }
}