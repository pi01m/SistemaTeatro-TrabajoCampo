namespace IU
{
    partial class FormGestionFunciones_DNI853
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
            dgvFunciones_DNI853 = new DataGridView();
            lblObra_DNI853 = new Label();
            cboObra_DNI853 = new ComboBox();
            lblSala_DNI853 = new Label();
            cboSala_DNI853 = new ComboBox();
            lblFecha_DNI853 = new Label();
            dtpFecha_DNI853 = new DateTimePicker();
            lblHoraInicio_DNI853 = new Label();
            txtHoraInicio_DNI853 = new TextBox();
            lblHoraFinalizacion_DNI853 = new Label();
            txtHoraFinalizacion_DNI853 = new TextBox();
            lblEstado_DNI853 = new Label();
            cboEstado_DNI853 = new ComboBox();
            btnNuevaFuncion_DNI853 = new Button();
            btnModificarFuncion_DNI853 = new Button();
            btnEliminarFuncion_DNI853 = new Button();
            panelInferior_DNI853 = new Panel();
            lblUsuarioValor_DNI853 = new Label();
            lblUsuarioActivo_DNI853 = new Label();
            panelContenedor_DNI853.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFunciones_DNI853).BeginInit();
            panelInferior_DNI853.SuspendLayout();
            SuspendLayout();
            // 
            // panelContenedor_DNI853
            // 
            panelContenedor_DNI853.Anchor = AnchorStyles.None;
            panelContenedor_DNI853.BackColor = Color.White;
            panelContenedor_DNI853.Controls.Add(btnSalir_DNI853);
            panelContenedor_DNI853.Controls.Add(lblTitulo_DNI853);
            panelContenedor_DNI853.Controls.Add(dgvFunciones_DNI853);
            panelContenedor_DNI853.Controls.Add(lblObra_DNI853);
            panelContenedor_DNI853.Controls.Add(cboObra_DNI853);
            panelContenedor_DNI853.Controls.Add(lblSala_DNI853);
            panelContenedor_DNI853.Controls.Add(cboSala_DNI853);
            panelContenedor_DNI853.Controls.Add(lblFecha_DNI853);
            panelContenedor_DNI853.Controls.Add(dtpFecha_DNI853);
            panelContenedor_DNI853.Controls.Add(lblHoraInicio_DNI853);
            panelContenedor_DNI853.Controls.Add(txtHoraInicio_DNI853);
            panelContenedor_DNI853.Controls.Add(lblHoraFinalizacion_DNI853);
            panelContenedor_DNI853.Controls.Add(txtHoraFinalizacion_DNI853);
            panelContenedor_DNI853.Controls.Add(lblEstado_DNI853);
            panelContenedor_DNI853.Controls.Add(cboEstado_DNI853);
            panelContenedor_DNI853.Controls.Add(btnNuevaFuncion_DNI853);
            panelContenedor_DNI853.Controls.Add(btnModificarFuncion_DNI853);
            panelContenedor_DNI853.Controls.Add(btnEliminarFuncion_DNI853);
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
            lblTitulo_DNI853.Size = new Size(569, 72);
            lblTitulo_DNI853.TabIndex = 0;
            lblTitulo_DNI853.Text = "Gestión de Funciones";
            // 
            // dgvFunciones_DNI853
            // 
            dgvFunciones_DNI853.AllowUserToAddRows = false;
            dgvFunciones_DNI853.AllowUserToDeleteRows = false;
            dgvFunciones_DNI853.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFunciones_DNI853.BackgroundColor = Color.FromArgb(120, 20, 40);
            dgvFunciones_DNI853.ColumnHeadersHeight = 30;
            dgvFunciones_DNI853.Location = new Point(53, 164);
            dgvFunciones_DNI853.Margin = new Padding(6);
            dgvFunciones_DNI853.Name = "dgvFunciones_DNI853";
            dgvFunciones_DNI853.ReadOnly = true;
            dgvFunciones_DNI853.RowHeadersVisible = false;
            dgvFunciones_DNI853.RowHeadersWidth = 102;
            dgvFunciones_DNI853.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFunciones_DNI853.Size = new Size(2433, 533);
            dgvFunciones_DNI853.TabIndex = 1;
            dgvFunciones_DNI853.SelectionChanged += dgvFunciones_DNI853_SelectionChanged;
            // 
            // lblObra_DNI853
            // 
            lblObra_DNI853.AutoSize = true;
            lblObra_DNI853.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblObra_DNI853.Location = new Point(53, 738);
            lblObra_DNI853.Margin = new Padding(6, 0, 6, 0);
            lblObra_DNI853.Name = "lblObra_DNI853";
            lblObra_DNI853.Size = new Size(88, 41);
            lblObra_DNI853.TabIndex = 2;
            lblObra_DNI853.Text = "Obra";
            // 
            // cboObra_DNI853
            // 
            cboObra_DNI853.DropDownStyle = ComboBoxStyle.DropDownList;
            cboObra_DNI853.FormattingEnabled = true;
            cboObra_DNI853.Location = new Point(53, 789);
            cboObra_DNI853.Margin = new Padding(6);
            cboObra_DNI853.Name = "cboObra_DNI853";
            cboObra_DNI853.Size = new Size(633, 49);
            cboObra_DNI853.TabIndex = 3;
            // 
            // lblSala_DNI853
            // 
            lblSala_DNI853.AutoSize = true;
            lblSala_DNI853.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSala_DNI853.Location = new Point(733, 738);
            lblSala_DNI853.Margin = new Padding(6, 0, 6, 0);
            lblSala_DNI853.Name = "lblSala_DNI853";
            lblSala_DNI853.Size = new Size(76, 41);
            lblSala_DNI853.TabIndex = 4;
            lblSala_DNI853.Text = "Sala";
            // 
            // cboSala_DNI853
            // 
            cboSala_DNI853.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSala_DNI853.FormattingEnabled = true;
            cboSala_DNI853.Location = new Point(733, 789);
            cboSala_DNI853.Margin = new Padding(6);
            cboSala_DNI853.Name = "cboSala_DNI853";
            cboSala_DNI853.Size = new Size(633, 49);
            cboSala_DNI853.TabIndex = 5;
            // 
            // lblFecha_DNI853
            // 
            lblFecha_DNI853.AutoSize = true;
            lblFecha_DNI853.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFecha_DNI853.Location = new Point(1413, 738);
            lblFecha_DNI853.Margin = new Padding(6, 0, 6, 0);
            lblFecha_DNI853.Name = "lblFecha_DNI853";
            lblFecha_DNI853.Size = new Size(98, 41);
            lblFecha_DNI853.TabIndex = 6;
            lblFecha_DNI853.Text = "Fecha";
            // 
            // dtpFecha_DNI853
            // 
            dtpFecha_DNI853.Format = DateTimePickerFormat.Short;
            dtpFecha_DNI853.Location = new Point(1413, 789);
            dtpFecha_DNI853.Margin = new Padding(6);
            dtpFecha_DNI853.Name = "dtpFecha_DNI853";
            dtpFecha_DNI853.Size = new Size(420, 47);
            dtpFecha_DNI853.TabIndex = 7;
            // 
            // lblHoraInicio_DNI853
            // 
            lblHoraInicio_DNI853.AutoSize = true;
            lblHoraInicio_DNI853.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHoraInicio_DNI853.Location = new Point(53, 892);
            lblHoraInicio_DNI853.Margin = new Padding(6, 0, 6, 0);
            lblHoraInicio_DNI853.Name = "lblHoraInicio_DNI853";
            lblHoraInicio_DNI853.Size = new Size(173, 41);
            lblHoraInicio_DNI853.TabIndex = 8;
            lblHoraInicio_DNI853.Text = "Hora Inicio";
            // 
            // txtHoraInicio_DNI853
            // 
            txtHoraInicio_DNI853.Location = new Point(53, 943);
            txtHoraInicio_DNI853.Margin = new Padding(6);
            txtHoraInicio_DNI853.Name = "txtHoraInicio_DNI853";
            txtHoraInicio_DNI853.Size = new Size(314, 47);
            txtHoraInicio_DNI853.TabIndex = 9;
            // 
            // lblHoraFinalizacion_DNI853
            // 
            lblHoraFinalizacion_DNI853.AutoSize = true;
            lblHoraFinalizacion_DNI853.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHoraFinalizacion_DNI853.Location = new Point(414, 892);
            lblHoraFinalizacion_DNI853.Margin = new Padding(6, 0, 6, 0);
            lblHoraFinalizacion_DNI853.Name = "lblHoraFinalizacion_DNI853";
            lblHoraFinalizacion_DNI853.Size = new Size(261, 41);
            lblHoraFinalizacion_DNI853.TabIndex = 10;
            lblHoraFinalizacion_DNI853.Text = "Hora Finalización";
            // 
            // txtHoraFinalizacion_DNI853
            // 
            txtHoraFinalizacion_DNI853.Location = new Point(414, 943);
            txtHoraFinalizacion_DNI853.Margin = new Padding(6);
            txtHoraFinalizacion_DNI853.Name = "txtHoraFinalizacion_DNI853";
            txtHoraFinalizacion_DNI853.Size = new Size(314, 47);
            txtHoraFinalizacion_DNI853.TabIndex = 11;
            // 
            // lblEstado_DNI853
            // 
            lblEstado_DNI853.AutoSize = true;
            lblEstado_DNI853.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEstado_DNI853.Location = new Point(776, 892);
            lblEstado_DNI853.Margin = new Padding(6, 0, 6, 0);
            lblEstado_DNI853.Name = "lblEstado_DNI853";
            lblEstado_DNI853.Size = new Size(256, 41);
            lblEstado_DNI853.TabIndex = 12;
            lblEstado_DNI853.Text = "Estado Funcional";
            // 
            // cboEstado_DNI853
            // 
            cboEstado_DNI853.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstado_DNI853.FormattingEnabled = true;
            cboEstado_DNI853.Items.AddRange(new object[] { "Programada", "Confirmada", "Cancelada", "Finalizada" });
            cboEstado_DNI853.Location = new Point(776, 943);
            cboEstado_DNI853.Margin = new Padding(6);
            cboEstado_DNI853.Name = "cboEstado_DNI853";
            cboEstado_DNI853.Size = new Size(420, 49);
            cboEstado_DNI853.TabIndex = 13;
            // 
            // btnNuevaFuncion_DNI853
            // 
            btnNuevaFuncion_DNI853.BackColor = Color.FromArgb(120, 20, 40);
            btnNuevaFuncion_DNI853.FlatStyle = FlatStyle.Flat;
            btnNuevaFuncion_DNI853.ForeColor = Color.White;
            btnNuevaFuncion_DNI853.Location = new Point(1753, 1168);
            btnNuevaFuncion_DNI853.Margin = new Padding(6);
            btnNuevaFuncion_DNI853.Name = "btnNuevaFuncion_DNI853";
            btnNuevaFuncion_DNI853.Size = new Size(212, 72);
            btnNuevaFuncion_DNI853.TabIndex = 14;
            btnNuevaFuncion_DNI853.Text = "Nueva";
            btnNuevaFuncion_DNI853.UseVisualStyleBackColor = false;
            btnNuevaFuncion_DNI853.Click += btnNuevaFuncion_DNI853_Click;
            // 
            // btnModificarFuncion_DNI853
            // 
            btnModificarFuncion_DNI853.BackColor = Color.White;
            btnModificarFuncion_DNI853.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnModificarFuncion_DNI853.FlatStyle = FlatStyle.Flat;
            btnModificarFuncion_DNI853.ForeColor = Color.FromArgb(120, 20, 40);
            btnModificarFuncion_DNI853.Location = new Point(1987, 1168);
            btnModificarFuncion_DNI853.Margin = new Padding(6);
            btnModificarFuncion_DNI853.Name = "btnModificarFuncion_DNI853";
            btnModificarFuncion_DNI853.Size = new Size(212, 72);
            btnModificarFuncion_DNI853.TabIndex = 15;
            btnModificarFuncion_DNI853.Text = "Modificar";
            btnModificarFuncion_DNI853.UseVisualStyleBackColor = false;
            btnModificarFuncion_DNI853.Click += btnModificarFuncion_DNI853_Click;
            // 
            // btnEliminarFuncion_DNI853
            // 
            btnEliminarFuncion_DNI853.BackColor = Color.White;
            btnEliminarFuncion_DNI853.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnEliminarFuncion_DNI853.FlatStyle = FlatStyle.Flat;
            btnEliminarFuncion_DNI853.ForeColor = Color.FromArgb(120, 20, 40);
            btnEliminarFuncion_DNI853.Location = new Point(2221, 1168);
            btnEliminarFuncion_DNI853.Margin = new Padding(6);
            btnEliminarFuncion_DNI853.Name = "btnEliminarFuncion_DNI853";
            btnEliminarFuncion_DNI853.Size = new Size(212, 72);
            btnEliminarFuncion_DNI853.TabIndex = 16;
            btnEliminarFuncion_DNI853.Text = "Eliminar";
            btnEliminarFuncion_DNI853.UseVisualStyleBackColor = false;
            btnEliminarFuncion_DNI853.Click += btnEliminarFuncion_DNI853_Click;
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
            // FormGestionFunciones_DNI853
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 238, 235);
            ClientSize = new Size(2682, 1548);
            Controls.Add(panelInferior_DNI853);
            Controls.Add(panelContenedor_DNI853);
            Margin = new Padding(6);
            Name = "FormGestionFunciones_DNI853";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormGestionFunciones_DNI853";
            FormClosed += FormGestionFunciones_DNI853_FormClosed;
            Load += FormGestionFunciones_DNI853_Load;
            Resize += FormGestionFunciones_DNI853_Resize;
            panelContenedor_DNI853.ResumeLayout(false);
            panelContenedor_DNI853.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFunciones_DNI853).EndInit();
            panelInferior_DNI853.ResumeLayout(false);
            panelInferior_DNI853.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor_DNI853;
        private System.Windows.Forms.Label lblTitulo_DNI853;
        private System.Windows.Forms.Button btnSalir_DNI853;
        private System.Windows.Forms.DataGridView dgvFunciones_DNI853;

        private System.Windows.Forms.Label lblObra_DNI853;
        private System.Windows.Forms.ComboBox cboObra_DNI853;
        private System.Windows.Forms.Label lblSala_DNI853;
        private System.Windows.Forms.ComboBox cboSala_DNI853;
        private System.Windows.Forms.Label lblFecha_DNI853;
        private System.Windows.Forms.DateTimePicker dtpFecha_DNI853;
        private System.Windows.Forms.Label lblHoraInicio_DNI853;
        private System.Windows.Forms.TextBox txtHoraInicio_DNI853;
        private System.Windows.Forms.Label lblHoraFinalizacion_DNI853;
        private System.Windows.Forms.TextBox txtHoraFinalizacion_DNI853;
        private System.Windows.Forms.Label lblEstado_DNI853;
        private System.Windows.Forms.ComboBox cboEstado_DNI853;

        private System.Windows.Forms.Button btnNuevaFuncion_DNI853;
        private System.Windows.Forms.Button btnModificarFuncion_DNI853;
        private System.Windows.Forms.Button btnEliminarFuncion_DNI853;

        private System.Windows.Forms.Panel panelInferior_DNI853;
        private System.Windows.Forms.Label lblUsuarioActivo_DNI853;
        private System.Windows.Forms.Label lblUsuarioValor_DNI853;
    }
}