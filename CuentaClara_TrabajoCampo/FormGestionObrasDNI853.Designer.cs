namespace IU
{
    partial class FormGestionObrasDNI853
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
            dgvObras_DNI853 = new DataGridView();
            lblNombreObra_DNI853 = new Label();
            txtNombreObra_DNI853 = new TextBox();
            lblDescripcionObra_DNI853 = new Label();
            txtDescripcionObra_DNI853 = new TextBox();
            btnNuevaObra_DNI853 = new Button();
            btnModificarObra_DNI853 = new Button();
            btnEliminarObra_DNI853 = new Button();
            panelInferior_DNI853 = new Panel();
            lblUsuarioValor_DNI853 = new Label();
            lblUsuarioActivo_DNI853 = new Label();
            lblEstadoObra_DNI853 = new Label();
            cmb_EstadoObra_DNI853 = new ComboBox();
            panelContenedor_DNI853.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvObras_DNI853).BeginInit();
            panelInferior_DNI853.SuspendLayout();
            SuspendLayout();
            // 
            // panelContenedor_DNI853
            // 
            panelContenedor_DNI853.Anchor = AnchorStyles.None;
            panelContenedor_DNI853.BackColor = Color.White;
            panelContenedor_DNI853.Controls.Add(cmb_EstadoObra_DNI853);
            panelContenedor_DNI853.Controls.Add(lblEstadoObra_DNI853);
            panelContenedor_DNI853.Controls.Add(btnSalir_DNI853);
            panelContenedor_DNI853.Controls.Add(lblTitulo_DNI853);
            panelContenedor_DNI853.Controls.Add(dgvObras_DNI853);
            panelContenedor_DNI853.Controls.Add(lblNombreObra_DNI853);
            panelContenedor_DNI853.Controls.Add(txtNombreObra_DNI853);
            panelContenedor_DNI853.Controls.Add(lblDescripcionObra_DNI853);
            panelContenedor_DNI853.Controls.Add(txtDescripcionObra_DNI853);
            panelContenedor_DNI853.Controls.Add(btnNuevaObra_DNI853);
            panelContenedor_DNI853.Controls.Add(btnModificarObra_DNI853);
            panelContenedor_DNI853.Controls.Add(btnEliminarObra_DNI853);
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
            btnSalir_DNI853.TabIndex = 9;
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
            lblTitulo_DNI853.Size = new Size(463, 72);
            lblTitulo_DNI853.TabIndex = 0;
            lblTitulo_DNI853.Text = "Gestión de Obras";
            // 
            // dgvObras_DNI853
            // 
            dgvObras_DNI853.AllowUserToAddRows = false;
            dgvObras_DNI853.AllowUserToDeleteRows = false;
            dgvObras_DNI853.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvObras_DNI853.BackgroundColor = Color.FromArgb(120, 20, 40);
            dgvObras_DNI853.ColumnHeadersHeight = 30;
            dgvObras_DNI853.Location = new Point(53, 164);
            dgvObras_DNI853.Margin = new Padding(6);
            dgvObras_DNI853.Name = "dgvObras_DNI853";
            dgvObras_DNI853.ReadOnly = true;
            dgvObras_DNI853.RowHeadersVisible = false;
            dgvObras_DNI853.RowHeadersWidth = 102;
            dgvObras_DNI853.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvObras_DNI853.Size = new Size(2433, 615);
            dgvObras_DNI853.TabIndex = 1;
            dgvObras_DNI853.SelectionChanged += dgvObras_DNI853_SelectionChanged;
            // 
            // lblNombreObra_DNI853
            // 
            lblNombreObra_DNI853.AutoSize = true;
            lblNombreObra_DNI853.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNombreObra_DNI853.Location = new Point(53, 840);
            lblNombreObra_DNI853.Margin = new Padding(6, 0, 6, 0);
            lblNombreObra_DNI853.Name = "lblNombreObra_DNI853";
            lblNombreObra_DNI853.Size = new Size(212, 41);
            lblNombreObra_DNI853.TabIndex = 2;
            lblNombreObra_DNI853.Text = "Nombre Obra";
            // 
            // txtNombreObra_DNI853
            // 
            txtNombreObra_DNI853.Location = new Point(53, 892);
            txtNombreObra_DNI853.Margin = new Padding(6);
            txtNombreObra_DNI853.Name = "txtNombreObra_DNI853";
            txtNombreObra_DNI853.Size = new Size(739, 47);
            txtNombreObra_DNI853.TabIndex = 3;
            // 
            // lblDescripcionObra_DNI853
            // 
            lblDescripcionObra_DNI853.AutoSize = true;
            lblDescripcionObra_DNI853.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDescripcionObra_DNI853.Location = new Point(53, 984);
            lblDescripcionObra_DNI853.Margin = new Padding(6, 0, 6, 0);
            lblDescripcionObra_DNI853.Name = "lblDescripcionObra_DNI853";
            lblDescripcionObra_DNI853.Size = new Size(182, 41);
            lblDescripcionObra_DNI853.TabIndex = 4;
            lblDescripcionObra_DNI853.Text = "Descripción";
            // 
            // txtDescripcionObra_DNI853
            // 
            txtDescripcionObra_DNI853.Location = new Point(53, 1035);
            txtDescripcionObra_DNI853.Margin = new Padding(6);
            txtDescripcionObra_DNI853.Multiline = true;
            txtDescripcionObra_DNI853.Name = "txtDescripcionObra_DNI853";
            txtDescripcionObra_DNI853.Size = new Size(1204, 141);
            txtDescripcionObra_DNI853.TabIndex = 5;
            // 
            // btnNuevaObra_DNI853
            // 
            btnNuevaObra_DNI853.BackColor = Color.FromArgb(120, 20, 40);
            btnNuevaObra_DNI853.FlatStyle = FlatStyle.Flat;
            btnNuevaObra_DNI853.ForeColor = Color.White;
            btnNuevaObra_DNI853.Location = new Point(1753, 1168);
            btnNuevaObra_DNI853.Margin = new Padding(6);
            btnNuevaObra_DNI853.Name = "btnNuevaObra_DNI853";
            btnNuevaObra_DNI853.Size = new Size(212, 72);
            btnNuevaObra_DNI853.TabIndex = 6;
            btnNuevaObra_DNI853.Text = "Nueva";
            btnNuevaObra_DNI853.UseVisualStyleBackColor = false;
            btnNuevaObra_DNI853.Click += btnNuevaObra_DNI853_Click;
            // 
            // btnModificarObra_DNI853
            // 
            btnModificarObra_DNI853.BackColor = Color.White;
            btnModificarObra_DNI853.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnModificarObra_DNI853.FlatStyle = FlatStyle.Flat;
            btnModificarObra_DNI853.ForeColor = Color.FromArgb(120, 20, 40);
            btnModificarObra_DNI853.Location = new Point(1987, 1168);
            btnModificarObra_DNI853.Margin = new Padding(6);
            btnModificarObra_DNI853.Name = "btnModificarObra_DNI853";
            btnModificarObra_DNI853.Size = new Size(212, 72);
            btnModificarObra_DNI853.TabIndex = 7;
            btnModificarObra_DNI853.Text = "Modificar";
            btnModificarObra_DNI853.UseVisualStyleBackColor = false;
            btnModificarObra_DNI853.Click += btnModificarObra_DNI853_Click;
            // 
            // btnEliminarObra_DNI853
            // 
            btnEliminarObra_DNI853.BackColor = Color.White;
            btnEliminarObra_DNI853.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnEliminarObra_DNI853.FlatStyle = FlatStyle.Flat;
            btnEliminarObra_DNI853.ForeColor = Color.FromArgb(120, 20, 40);
            btnEliminarObra_DNI853.Location = new Point(2221, 1168);
            btnEliminarObra_DNI853.Margin = new Padding(6);
            btnEliminarObra_DNI853.Name = "btnEliminarObra_DNI853";
            btnEliminarObra_DNI853.Size = new Size(212, 72);
            btnEliminarObra_DNI853.TabIndex = 8;
            btnEliminarObra_DNI853.Text = "Eliminar";
            btnEliminarObra_DNI853.UseVisualStyleBackColor = false;
            btnEliminarObra_DNI853.Click += btnEliminarObra_DNI853_Click;
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
            // lblEstadoObra_DNI853
            // 
            lblEstadoObra_DNI853.AutoSize = true;
            lblEstadoObra_DNI853.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEstadoObra_DNI853.Location = new Point(53, 1226);
            lblEstadoObra_DNI853.Margin = new Padding(6, 0, 6, 0);
            lblEstadoObra_DNI853.Name = "lblEstadoObra_DNI853";
            lblEstadoObra_DNI853.Size = new Size(190, 41);
            lblEstadoObra_DNI853.TabIndex = 10;
            lblEstadoObra_DNI853.Text = "Estado Obra";
            // 
            // cmb_EstadoObra_DNI853
            // 
            cmb_EstadoObra_DNI853.FormattingEnabled = true;
            cmb_EstadoObra_DNI853.Location = new Point(53, 1270);
            cmb_EstadoObra_DNI853.Name = "cmb_EstadoObra_DNI853";
            cmb_EstadoObra_DNI853.Size = new Size(302, 49);
            cmb_EstadoObra_DNI853.TabIndex = 11;
            // 
            // FormGestionObrasDNI853
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 238, 235);
            ClientSize = new Size(2682, 1548);
            Controls.Add(panelInferior_DNI853);
            Controls.Add(panelContenedor_DNI853);
            Margin = new Padding(6);
            Name = "FormGestionObrasDNI853";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormGestionObrasDNI853";
            FormClosed += FormGestionObrasDNI853_FormClosed;
            Load += FormGestionObrasDNI853_Load;
            Resize += FormGestionObrasDNI853_Resize;
            panelContenedor_DNI853.ResumeLayout(false);
            panelContenedor_DNI853.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvObras_DNI853).EndInit();
            panelInferior_DNI853.ResumeLayout(false);
            panelInferior_DNI853.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panelContenedor_DNI853;
        private System.Windows.Forms.Label lblTitulo_DNI853;
        private System.Windows.Forms.Button btnSalir_DNI853;
        private System.Windows.Forms.DataGridView dgvObras_DNI853;
        private System.Windows.Forms.Label lblNombreObra_DNI853;
        private System.Windows.Forms.TextBox txtNombreObra_DNI853;
        private System.Windows.Forms.Label lblDescripcionObra_DNI853;
        private System.Windows.Forms.TextBox txtDescripcionObra_DNI853;
        private System.Windows.Forms.Button btnNuevaObra_DNI853;
        private System.Windows.Forms.Button btnModificarObra_DNI853;
        private System.Windows.Forms.Button btnEliminarObra_DNI853;
        private System.Windows.Forms.Panel panelInferior_DNI853;
        private System.Windows.Forms.Label lblUsuarioActivo_DNI853;
        private System.Windows.Forms.Label lblUsuarioValor_DNI853;
        private Label lblEstadoObra_DNI853;
        private TextBox txtEstadoObra_DNI853;
        private ComboBox cmb_EstadoObra_DNI853;
    }
}