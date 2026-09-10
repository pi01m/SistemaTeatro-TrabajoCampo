namespace IU
{
    partial class FormGestionPromocion_DNI853
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
            panelContenedor_DNI853 = new Panel();
            btnSalir_DNI853 = new Button();
            lblTitulo_DNI853 = new Label();
            dgvPromociones_DNI853 = new DataGridView();
            lblNombrePromo_DNI853 = new Label();
            txtNombrePromo_DNI853 = new TextBox();
            lblTipoPromo_DNI853 = new Label();
            cboTipoPromo_DNI853 = new ComboBox();
            lblValorDescuento_DNI853 = new Label();
            txtValorDescuento_DNI853 = new TextBox();
            lblFechaInicio_DNI853 = new Label();
            dtpFechaInicio_DNI853 = new DateTimePicker();
            lblFechaFin_DNI853 = new Label();
            dtpFechaFin_DNI853 = new DateTimePicker();
            lblEstadoPromo_DNI853 = new Label();
            cboEstadoPromo_DNI853 = new ComboBox();
            btnNuevaPromo_DNI853 = new Button();
            btnModificarPromo_DNI853 = new Button();
            btnEliminarPromo_DNI853 = new Button();
            panelInferior_DNI853 = new Panel();
            lblUsuarioValor_DNI853 = new Label();
            lblUsuarioActivo_DNI853 = new Label();
            panelContenedor_DNI853.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPromociones_DNI853).BeginInit();
            panelInferior_DNI853.SuspendLayout();
            SuspendLayout();
            // 
            // panelContenedor_DNI853
            // 
            panelContenedor_DNI853.Anchor = AnchorStyles.None;
            panelContenedor_DNI853.BackColor = Color.White;
            panelContenedor_DNI853.Controls.Add(btnSalir_DNI853);
            panelContenedor_DNI853.Controls.Add(lblTitulo_DNI853);
            panelContenedor_DNI853.Controls.Add(dgvPromociones_DNI853);
            panelContenedor_DNI853.Controls.Add(lblNombrePromo_DNI853);
            panelContenedor_DNI853.Controls.Add(txtNombrePromo_DNI853);
            panelContenedor_DNI853.Controls.Add(lblTipoPromo_DNI853);
            panelContenedor_DNI853.Controls.Add(cboTipoPromo_DNI853);
            panelContenedor_DNI853.Controls.Add(lblValorDescuento_DNI853);
            panelContenedor_DNI853.Controls.Add(txtValorDescuento_DNI853);
            panelContenedor_DNI853.Controls.Add(lblFechaInicio_DNI853);
            panelContenedor_DNI853.Controls.Add(dtpFechaInicio_DNI853);
            panelContenedor_DNI853.Controls.Add(lblFechaFin_DNI853);
            panelContenedor_DNI853.Controls.Add(dtpFechaFin_DNI853);
            panelContenedor_DNI853.Controls.Add(lblEstadoPromo_DNI853);
            panelContenedor_DNI853.Controls.Add(cboEstadoPromo_DNI853);
            panelContenedor_DNI853.Controls.Add(btnNuevaPromo_DNI853);
            panelContenedor_DNI853.Controls.Add(btnModificarPromo_DNI853);
            panelContenedor_DNI853.Controls.Add(btnEliminarPromo_DNI853);
            panelContenedor_DNI853.Location = new Point(62, 68);
            panelContenedor_DNI853.Margin = new Padding(6);
            panelContenedor_DNI853.Name = "panelContenedor_DNI853";
            panelContenedor_DNI853.Size = new Size(2550, 1435);
            panelContenedor_DNI853.TabIndex = 1;
            // 
            // btnSalir_DNI853
            // 
            btnSalir_DNI853.BackColor = Color.White;
            btnSalir_DNI853.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnSalir_DNI853.FlatStyle = FlatStyle.Flat;
            btnSalir_DNI853.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalir_DNI853.ForeColor = Color.FromArgb(120, 20, 40);
            btnSalir_DNI853.Location = new Point(2231, 41);
            btnSalir_DNI853.Margin = new Padding(6);
            btnSalir_DNI853.Name = "btnSalir_DNI853";
            btnSalir_DNI853.Size = new Size(255, 82);
            btnSalir_DNI853.TabIndex = 17;
            btnSalir_DNI853.Text = "Salir";
            btnSalir_DNI853.UseVisualStyleBackColor = false;
            btnSalir_DNI853.Click += btnSalir_DNI853_Click;
            // 
            // lblTitulo_DNI853
            // 
            lblTitulo_DNI853.AutoSize = true;
            lblTitulo_DNI853.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo_DNI853.ForeColor = Color.FromArgb(120, 20, 40);
            lblTitulo_DNI853.Location = new Point(53, 41);
            lblTitulo_DNI853.Margin = new Padding(6, 0, 6, 0);
            lblTitulo_DNI853.Name = "lblTitulo_DNI853";
            lblTitulo_DNI853.Size = new Size(644, 72);
            lblTitulo_DNI853.TabIndex = 0;
            lblTitulo_DNI853.Text = "Gestión de Promociones";
            // 
            // dgvPromociones_DNI853
            // 
            dgvPromociones_DNI853.AllowUserToAddRows = false;
            dgvPromociones_DNI853.AllowUserToDeleteRows = false;
            dgvPromociones_DNI853.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPromociones_DNI853.BackgroundColor = Color.FromArgb(120, 20, 40);
            dgvPromociones_DNI853.ColumnHeadersHeight = 30;
            dgvPromociones_DNI853.Location = new Point(53, 164);
            dgvPromociones_DNI853.Margin = new Padding(6);
            dgvPromociones_DNI853.Name = "dgvPromociones_DNI853";
            dgvPromociones_DNI853.ReadOnly = true;
            dgvPromociones_DNI853.RowHeadersVisible = false;
            dgvPromociones_DNI853.RowHeadersWidth = 102;
            dgvPromociones_DNI853.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPromociones_DNI853.Size = new Size(2433, 533);
            dgvPromociones_DNI853.TabIndex = 1;
            dgvPromociones_DNI853.SelectionChanged += dgvPromociones_DNI853_SelectionChanged;
            // 
            // lblNombrePromo_DNI853
            // 
            lblNombrePromo_DNI853.AutoSize = true;
            lblNombrePromo_DNI853.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNombrePromo_DNI853.Location = new Point(53, 738);
            lblNombrePromo_DNI853.Margin = new Padding(6, 0, 6, 0);
            lblNombrePromo_DNI853.Name = "lblNombrePromo_DNI853";
            lblNombrePromo_DNI853.Size = new Size(294, 41);
            lblNombrePromo_DNI853.TabIndex = 2;
            lblNombrePromo_DNI853.Text = "Nombre Promoción";
            // 
            // txtNombrePromo_DNI853
            // 
            txtNombrePromo_DNI853.Location = new Point(53, 789);
            txtNombrePromo_DNI853.Margin = new Padding(6);
            txtNombrePromo_DNI853.Name = "txtNombrePromo_DNI853";
            txtNombrePromo_DNI853.Size = new Size(527, 47);
            txtNombrePromo_DNI853.TabIndex = 3;
            // 
            // lblTipoPromo_DNI853
            // 
            lblTipoPromo_DNI853.AutoSize = true;
            lblTipoPromo_DNI853.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTipoPromo_DNI853.Location = new Point(627, 738);
            lblTipoPromo_DNI853.Margin = new Padding(6, 0, 6, 0);
            lblTipoPromo_DNI853.Name = "lblTipoPromo_DNI853";
            lblTipoPromo_DNI853.Size = new Size(242, 41);
            lblTipoPromo_DNI853.TabIndex = 4;
            lblTipoPromo_DNI853.Text = "Tipo Promoción";
            // 
            // cboTipoPromo_DNI853
            // 
            cboTipoPromo_DNI853.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoPromo_DNI853.FormattingEnabled = true;
            cboTipoPromo_DNI853.Items.AddRange(new object[] { "Porcentaje (%)", "Monto Fijo ($)" });
            cboTipoPromo_DNI853.Location = new Point(627, 789);
            cboTipoPromo_DNI853.Margin = new Padding(6);
            cboTipoPromo_DNI853.Name = "cboTipoPromo_DNI853";
            cboTipoPromo_DNI853.Size = new Size(420, 49);
            cboTipoPromo_DNI853.TabIndex = 5;
            // 
            // lblValorDescuento_DNI853
            // 
            lblValorDescuento_DNI853.AutoSize = true;
            lblValorDescuento_DNI853.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblValorDescuento_DNI853.Location = new Point(1094, 738);
            lblValorDescuento_DNI853.Margin = new Padding(6, 0, 6, 0);
            lblValorDescuento_DNI853.Name = "lblValorDescuento_DNI853";
            lblValorDescuento_DNI853.Size = new Size(246, 41);
            lblValorDescuento_DNI853.TabIndex = 6;
            lblValorDescuento_DNI853.Text = "Valor Descuento";
            // 
            // txtValorDescuento_DNI853
            // 
            txtValorDescuento_DNI853.Location = new Point(1094, 789);
            txtValorDescuento_DNI853.Margin = new Padding(6);
            txtValorDescuento_DNI853.Name = "txtValorDescuento_DNI853";
            txtValorDescuento_DNI853.Size = new Size(314, 47);
            txtValorDescuento_DNI853.TabIndex = 7;
            // 
            // lblFechaInicio_DNI853
            // 
            lblFechaInicio_DNI853.AutoSize = true;
            lblFechaInicio_DNI853.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFechaInicio_DNI853.Location = new Point(53, 892);
            lblFechaInicio_DNI853.Margin = new Padding(6, 0, 6, 0);
            lblFechaInicio_DNI853.Name = "lblFechaInicio_DNI853";
            lblFechaInicio_DNI853.Size = new Size(184, 41);
            lblFechaInicio_DNI853.TabIndex = 8;
            lblFechaInicio_DNI853.Text = "Fecha Inicio";
            // 
            // dtpFechaInicio_DNI853
            // 
            dtpFechaInicio_DNI853.Format = DateTimePickerFormat.Short;
            dtpFechaInicio_DNI853.Location = new Point(53, 943);
            dtpFechaInicio_DNI853.Margin = new Padding(6);
            dtpFechaInicio_DNI853.Name = "dtpFechaInicio_DNI853";
            dtpFechaInicio_DNI853.Size = new Size(420, 47);
            dtpFechaInicio_DNI853.TabIndex = 9;
            // 
            // lblFechaFin_DNI853
            // 
            lblFechaFin_DNI853.AutoSize = true;
            lblFechaFin_DNI853.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFechaFin_DNI853.Location = new Point(521, 892);
            lblFechaFin_DNI853.Margin = new Padding(6, 0, 6, 0);
            lblFechaFin_DNI853.Name = "lblFechaFin_DNI853";
            lblFechaFin_DNI853.Size = new Size(149, 41);
            lblFechaFin_DNI853.TabIndex = 10;
            lblFechaFin_DNI853.Text = "Fecha Fin";
            // 
            // dtpFechaFin_DNI853
            // 
            dtpFechaFin_DNI853.Format = DateTimePickerFormat.Short;
            dtpFechaFin_DNI853.Location = new Point(521, 943);
            dtpFechaFin_DNI853.Margin = new Padding(6);
            dtpFechaFin_DNI853.Name = "dtpFechaFin_DNI853";
            dtpFechaFin_DNI853.Size = new Size(420, 47);
            dtpFechaFin_DNI853.TabIndex = 11;
            // 
            // lblEstadoPromo_DNI853
            // 
            lblEstadoPromo_DNI853.AutoSize = true;
            lblEstadoPromo_DNI853.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEstadoPromo_DNI853.Location = new Point(988, 892);
            lblEstadoPromo_DNI853.Margin = new Padding(6, 0, 6, 0);
            lblEstadoPromo_DNI853.Name = "lblEstadoPromo_DNI853";
            lblEstadoPromo_DNI853.Size = new Size(272, 41);
            lblEstadoPromo_DNI853.TabIndex = 12;
            lblEstadoPromo_DNI853.Text = "Estado Promoción";
            // 
            // cboEstadoPromo_DNI853
            // 
            cboEstadoPromo_DNI853.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstadoPromo_DNI853.FormattingEnabled = true;
            cboEstadoPromo_DNI853.Items.AddRange(new object[] { "Activa", "Inactiva", "Vencida" });
            cboEstadoPromo_DNI853.Location = new Point(988, 943);
            cboEstadoPromo_DNI853.Margin = new Padding(6);
            cboEstadoPromo_DNI853.Name = "cboEstadoPromo_DNI853";
            cboEstadoPromo_DNI853.Size = new Size(420, 49);
            cboEstadoPromo_DNI853.TabIndex = 13;
            // 
            // btnNuevaPromo_DNI853
            // 
            btnNuevaPromo_DNI853.BackColor = Color.FromArgb(120, 20, 40);
            btnNuevaPromo_DNI853.FlatStyle = FlatStyle.Flat;
            btnNuevaPromo_DNI853.ForeColor = Color.White;
            btnNuevaPromo_DNI853.Location = new Point(1753, 1168);
            btnNuevaPromo_DNI853.Margin = new Padding(6);
            btnNuevaPromo_DNI853.Name = "btnNuevaPromo_DNI853";
            btnNuevaPromo_DNI853.Size = new Size(212, 72);
            btnNuevaPromo_DNI853.TabIndex = 14;
            btnNuevaPromo_DNI853.Text = "Nueva";
            btnNuevaPromo_DNI853.UseVisualStyleBackColor = false;
            btnNuevaPromo_DNI853.Click += btnNuevaPromo_DNI853_Click;
            // 
            // btnModificarPromo_DNI853
            // 
            btnModificarPromo_DNI853.BackColor = Color.White;
            btnModificarPromo_DNI853.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnModificarPromo_DNI853.FlatStyle = FlatStyle.Flat;
            btnModificarPromo_DNI853.ForeColor = Color.FromArgb(120, 20, 40);
            btnModificarPromo_DNI853.Location = new Point(1987, 1168);
            btnModificarPromo_DNI853.Margin = new Padding(6);
            btnModificarPromo_DNI853.Name = "btnModificarPromo_DNI853";
            btnModificarPromo_DNI853.Size = new Size(212, 72);
            btnModificarPromo_DNI853.TabIndex = 15;
            btnModificarPromo_DNI853.Text = "Modificar";
            btnModificarPromo_DNI853.UseVisualStyleBackColor = false;
            btnModificarPromo_DNI853.Click += btnModificarPromo_DNI853_Click;
            // 
            // btnEliminarPromo_DNI853
            // 
            btnEliminarPromo_DNI853.BackColor = Color.White;
            btnEliminarPromo_DNI853.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnEliminarPromo_DNI853.FlatStyle = FlatStyle.Flat;
            btnEliminarPromo_DNI853.ForeColor = Color.FromArgb(120, 20, 40);
            btnEliminarPromo_DNI853.Location = new Point(2221, 1168);
            btnEliminarPromo_DNI853.Margin = new Padding(6);
            btnEliminarPromo_DNI853.Name = "btnEliminarPromo_DNI853";
            btnEliminarPromo_DNI853.Size = new Size(212, 72);
            btnEliminarPromo_DNI853.TabIndex = 16;
            btnEliminarPromo_DNI853.Text = "Eliminar";
            btnEliminarPromo_DNI853.UseVisualStyleBackColor = false;
            btnEliminarPromo_DNI853.Click += btnEliminarPromo_DNI853_Click;
            // 
            // panelInferior_DNI853
            // 
            panelInferior_DNI853.BackColor = Color.FromArgb(120, 20, 40);
            panelInferior_DNI853.Controls.Add(lblUsuarioValor_DNI853);
            panelInferior_DNI853.Controls.Add(lblUsuarioActivo_DNI853);
            panelInferior_DNI853.Dock = DockStyle.Bottom;
            panelInferior_DNI853.Location = new Point(0, 1476);
            panelInferior_DNI853.Margin = new Padding(6);
            panelInferior_DNI853.Name = "panelInferior_DNI853";
            panelInferior_DNI853.Size = new Size(2682, 72);
            panelInferior_DNI853.TabIndex = 0;
            // 
            // lblUsuarioValor_DNI853
            // 
            lblUsuarioValor_DNI853.AutoSize = true;
            lblUsuarioValor_DNI853.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsuarioValor_DNI853.ForeColor = Color.White;
            lblUsuarioValor_DNI853.Location = new Point(298, 16);
            lblUsuarioValor_DNI853.Margin = new Padding(6, 0, 6, 0);
            lblUsuarioValor_DNI853.Name = "lblUsuarioValor_DNI853";
            lblUsuarioValor_DNI853.Size = new Size(423, 41);
            lblUsuarioValor_DNI853.TabIndex = 1;
            lblUsuarioValor_DNI853.Text = "Maria Lopez - Administrador";
            // 
            // lblUsuarioActivo_DNI853
            // 
            lblUsuarioActivo_DNI853.AutoSize = true;
            lblUsuarioActivo_DNI853.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsuarioActivo_DNI853.ForeColor = Color.White;
            lblUsuarioActivo_DNI853.Location = new Point(53, 16);
            lblUsuarioActivo_DNI853.Margin = new Padding(6, 0, 6, 0);
            lblUsuarioActivo_DNI853.Name = "lblUsuarioActivo_DNI853";
            lblUsuarioActivo_DNI853.Size = new Size(235, 41);
            lblUsuarioActivo_DNI853.TabIndex = 0;
            lblUsuarioActivo_DNI853.Text = "Usuario activo: ";
            // 
            // FormGestionPromocion_DNI853
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 238, 235);
            ClientSize = new Size(2682, 1548);
            Controls.Add(panelInferior_DNI853);
            Controls.Add(panelContenedor_DNI853);
            Margin = new Padding(6);
            Name = "FormGestionPromocion_DNI853";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormGestionPromocion_DNI853";
            FormClosed += FormGestionPromocion_DNI853_FormClosed;
            Load += FormGestionPromocion_DNI853_Load;
            Resize += FormGestionPromocion_DNI853_Resize;
            panelContenedor_DNI853.ResumeLayout(false);
            panelContenedor_DNI853.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPromociones_DNI853).EndInit();
            panelInferior_DNI853.ResumeLayout(false);
            panelInferior_DNI853.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor_DNI853;
        private System.Windows.Forms.Label lblTitulo_DNI853;
        private System.Windows.Forms.Button btnSalir_DNI853;
        private System.Windows.Forms.DataGridView dgvPromociones_DNI853;

        private System.Windows.Forms.Label lblNombrePromo_DNI853;
        private System.Windows.Forms.TextBox txtNombrePromo_DNI853;
        private System.Windows.Forms.Label lblTipoPromo_DNI853;
        private System.Windows.Forms.ComboBox cboTipoPromo_DNI853;
        private System.Windows.Forms.Label lblValorDescuento_DNI853;
        private System.Windows.Forms.TextBox txtValorDescuento_DNI853;
        private System.Windows.Forms.Label lblFechaInicio_DNI853;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio_DNI853;
        private System.Windows.Forms.Label lblFechaFin_DNI853;
        private System.Windows.Forms.DateTimePicker dtpFechaFin_DNI853;
        private System.Windows.Forms.Label lblEstadoPromo_DNI853;
        private System.Windows.Forms.ComboBox cboEstadoPromo_DNI853;

        private System.Windows.Forms.Button btnNuevaPromo_DNI853;
        private System.Windows.Forms.Button btnModificarPromo_DNI853;
        private System.Windows.Forms.Button btnEliminarPromo_DNI853;

        private System.Windows.Forms.Panel panelInferior_DNI853;
        private System.Windows.Forms.Label lblUsuarioActivo_DNI853;
        private System.Windows.Forms.Label lblUsuarioValor_DNI853;
    }
}