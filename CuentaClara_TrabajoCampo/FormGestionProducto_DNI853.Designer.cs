namespace IU
{
    partial class FormGestionProducto_DNI853
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
            dgvProductos_DNI853 = new DataGridView();
            lblNombreProducto_DNI853 = new Label();
            txtNombreProducto_DNI853 = new TextBox();
            lblCategoria_DNI853 = new Label();
            cmbCategoria_DNI853 = new ComboBox();
            lblPrecio_DNI853 = new Label();
            txtPrecio_DNI853 = new TextBox();
            lblStock_DNI853 = new Label();
            txtStock_DNI853 = new TextBox();
            btnNuevoProducto_DNI853 = new Button();
            btnModificarProducto_DNI853 = new Button();
            btnEliminarProducto_DNI853 = new Button();
            panelInferior_DNI853 = new Panel();
            lblUsuarioValor_DNI853 = new Label();
            lblUsuarioActivo_DNI853 = new Label();
            panelContenedor_DNI853.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos_DNI853).BeginInit();
            panelInferior_DNI853.SuspendLayout();
            SuspendLayout();
            // 
            // panelContenedor_DNI853
            // 
            panelContenedor_DNI853.Anchor = AnchorStyles.None;
            panelContenedor_DNI853.BackColor = Color.White;
            panelContenedor_DNI853.Controls.Add(btnSalir_DNI853);
            panelContenedor_DNI853.Controls.Add(lblTitulo_DNI853);
            panelContenedor_DNI853.Controls.Add(dgvProductos_DNI853);
            panelContenedor_DNI853.Controls.Add(lblNombreProducto_DNI853);
            panelContenedor_DNI853.Controls.Add(txtNombreProducto_DNI853);
            panelContenedor_DNI853.Controls.Add(lblCategoria_DNI853);
            panelContenedor_DNI853.Controls.Add(cmbCategoria_DNI853);
            panelContenedor_DNI853.Controls.Add(lblPrecio_DNI853);
            panelContenedor_DNI853.Controls.Add(txtPrecio_DNI853);
            panelContenedor_DNI853.Controls.Add(lblStock_DNI853);
            panelContenedor_DNI853.Controls.Add(txtStock_DNI853);
            panelContenedor_DNI853.Controls.Add(btnNuevoProducto_DNI853);
            panelContenedor_DNI853.Controls.Add(btnModificarProducto_DNI853);
            panelContenedor_DNI853.Controls.Add(btnEliminarProducto_DNI853);
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
            btnSalir_DNI853.TabIndex = 12;
            btnSalir_DNI853.Tag = "btnSalir";
            btnSalir_DNI853.Text = "Salir";
            btnSalir_DNI853.UseVisualStyleBackColor = false;
            // 
            // lblTitulo_DNI853
            // 
            lblTitulo_DNI853.AutoSize = true;
            lblTitulo_DNI853.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo_DNI853.ForeColor = Color.FromArgb(120, 20, 40);
            lblTitulo_DNI853.Location = new Point(53, 41);
            lblTitulo_DNI853.Margin = new Padding(6, 0, 6, 0);
            lblTitulo_DNI853.Name = "lblTitulo_DNI853";
            lblTitulo_DNI853.Size = new Size(858, 72);
            lblTitulo_DNI853.TabIndex = 0;
            lblTitulo_DNI853.Tag = "lblGestionProductosTitulo";
            lblTitulo_DNI853.Text = "Gestión de Productos de Cantina";
            // 
            // dgvProductos_DNI853
            // 
            dgvProductos_DNI853.AllowUserToAddRows = false;
            dgvProductos_DNI853.AllowUserToDeleteRows = false;
            dgvProductos_DNI853.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos_DNI853.BackgroundColor = Color.FromArgb(120, 20, 40);
            dgvProductos_DNI853.ColumnHeadersHeight = 35;
            dgvProductos_DNI853.Location = new Point(53, 164);
            dgvProductos_DNI853.Margin = new Padding(6);
            dgvProductos_DNI853.Name = "dgvProductos_DNI853";
            dgvProductos_DNI853.ReadOnly = true;
            dgvProductos_DNI853.RowHeadersVisible = false;
            dgvProductos_DNI853.RowHeadersWidth = 102;
            dgvProductos_DNI853.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos_DNI853.Size = new Size(2433, 580);
            dgvProductos_DNI853.TabIndex = 1;
            dgvProductos_DNI853.SelectionChanged += dgvProductos_DNI853_SelectionChanged;
            // 
            // lblNombreProducto_DNI853
            // 
            lblNombreProducto_DNI853.AutoSize = true;
            lblNombreProducto_DNI853.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNombreProducto_DNI853.Location = new Point(53, 791);
            lblNombreProducto_DNI853.Name = "lblNombreProducto_DNI853";
            lblNombreProducto_DNI853.Size = new Size(271, 41);
            lblNombreProducto_DNI853.TabIndex = 4;
            lblNombreProducto_DNI853.Text = "Nombre Producto";
            // 
            // txtNombreProducto_DNI853
            // 
            txtNombreProducto_DNI853.Location = new Point(53, 841);
            txtNombreProducto_DNI853.Name = "txtNombreProducto_DNI853";
            txtNombreProducto_DNI853.Size = new Size(700, 47);
            txtNombreProducto_DNI853.TabIndex = 5;
            // 
            // lblCategoria_DNI853
            // 
            lblCategoria_DNI853.AutoSize = true;
            lblCategoria_DNI853.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCategoria_DNI853.Location = new Point(803, 791);
            lblCategoria_DNI853.Name = "lblCategoria_DNI853";
            lblCategoria_DNI853.Size = new Size(155, 41);
            lblCategoria_DNI853.TabIndex = 6;
            lblCategoria_DNI853.Text = "Categoría";
            // 
            // cmbCategoria_DNI853
            // 
            cmbCategoria_DNI853.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria_DNI853.FormattingEnabled = true;
            cmbCategoria_DNI853.Location = new Point(803, 839);
            cmbCategoria_DNI853.Name = "cmbCategoria_DNI853";
            cmbCategoria_DNI853.Size = new Size(450, 49);
            cmbCategoria_DNI853.TabIndex = 7;
            // 
            // lblPrecio_DNI853
            // 
            lblPrecio_DNI853.AutoSize = true;
            lblPrecio_DNI853.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPrecio_DNI853.Location = new Point(53, 920);
            lblPrecio_DNI853.Name = "lblPrecio_DNI853";
            lblPrecio_DNI853.Size = new Size(223, 41);
            lblPrecio_DNI853.TabIndex = 8;
            lblPrecio_DNI853.Text = "Precio Vigente";
            // 
            // txtPrecio_DNI853
            // 
            txtPrecio_DNI853.Location = new Point(53, 970);
            txtPrecio_DNI853.Name = "txtPrecio_DNI853";
            txtPrecio_DNI853.Size = new Size(350, 47);
            txtPrecio_DNI853.TabIndex = 9;
            // 
            // lblStock_DNI853
            // 
            lblStock_DNI853.AutoSize = true;
            lblStock_DNI853.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStock_DNI853.Location = new Point(450, 920);
            lblStock_DNI853.Name = "lblStock_DNI853";
            lblStock_DNI853.Size = new Size(193, 41);
            lblStock_DNI853.TabIndex = 10;
            lblStock_DNI853.Text = "Stock Actual";
            // 
            // txtStock_DNI853
            // 
            txtStock_DNI853.Location = new Point(450, 970);
            txtStock_DNI853.Name = "txtStock_DNI853";
            txtStock_DNI853.Size = new Size(350, 47);
            txtStock_DNI853.TabIndex = 11;
            // 
            // btnNuevoProducto_DNI853
            // 
            btnNuevoProducto_DNI853.BackColor = Color.FromArgb(120, 20, 40);
            btnNuevoProducto_DNI853.FlatStyle = FlatStyle.Flat;
            btnNuevoProducto_DNI853.ForeColor = Color.White;
            btnNuevoProducto_DNI853.Location = new Point(1753, 1168);
            btnNuevoProducto_DNI853.Margin = new Padding(6);
            btnNuevoProducto_DNI853.Name = "btnNuevoProducto_DNI853";
            btnNuevoProducto_DNI853.Size = new Size(212, 72);
            btnNuevoProducto_DNI853.TabIndex = 13;
            btnNuevoProducto_DNI853.Tag = "btnNuevo";
            btnNuevoProducto_DNI853.Text = "Nuevo";
            btnNuevoProducto_DNI853.UseVisualStyleBackColor = false;
            btnNuevoProducto_DNI853.Click += btnNuevoProducto_DNI853_Click;
            // 
            // btnModificarProducto_DNI853
            // 
            btnModificarProducto_DNI853.BackColor = Color.White;
            btnModificarProducto_DNI853.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnModificarProducto_DNI853.FlatStyle = FlatStyle.Flat;
            btnModificarProducto_DNI853.ForeColor = Color.FromArgb(120, 20, 40);
            btnModificarProducto_DNI853.Location = new Point(1987, 1168);
            btnModificarProducto_DNI853.Margin = new Padding(6);
            btnModificarProducto_DNI853.Name = "btnModificarProducto_DNI853";
            btnModificarProducto_DNI853.Size = new Size(212, 72);
            btnModificarProducto_DNI853.TabIndex = 14;
            btnModificarProducto_DNI853.Tag = "btnModificar";
            btnModificarProducto_DNI853.Text = "Modificar";
            btnModificarProducto_DNI853.UseVisualStyleBackColor = false;
            btnModificarProducto_DNI853.Click += btnModificarProducto_DNI853_Click;
            // 
            // btnEliminarProducto_DNI853
            // 
            btnEliminarProducto_DNI853.BackColor = Color.White;
            btnEliminarProducto_DNI853.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnEliminarProducto_DNI853.FlatStyle = FlatStyle.Flat;
            btnEliminarProducto_DNI853.ForeColor = Color.FromArgb(120, 20, 40);
            btnEliminarProducto_DNI853.Location = new Point(2221, 1168);
            btnEliminarProducto_DNI853.Margin = new Padding(6);
            btnEliminarProducto_DNI853.Name = "btnEliminarProducto_DNI853";
            btnEliminarProducto_DNI853.Size = new Size(212, 72);
            btnEliminarProducto_DNI853.TabIndex = 15;
            btnEliminarProducto_DNI853.Tag = "btnEliminar";
            btnEliminarProducto_DNI853.Text = "Eliminar";
            btnEliminarProducto_DNI853.UseVisualStyleBackColor = false;
            btnEliminarProducto_DNI853.Click += btnEliminarProducto_DNI853_Click;
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
            lblUsuarioActivo_DNI853.Tag = "lblUsuarioActivo";
            lblUsuarioActivo_DNI853.Text = "Usuario activo: ";
            // 
            // FormGestionProducto_DNI853
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 238, 235);
            ClientSize = new Size(2682, 1548);
            Controls.Add(panelInferior_DNI853);
            Controls.Add(panelContenedor_DNI853);
            Margin = new Padding(6);
            Name = "FormGestionProducto_DNI853";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TeatroLux - Gestión de Productos";
            Load += FormGestionProducto_DNI853_Load_1;
            panelContenedor_DNI853.ResumeLayout(false);
            panelContenedor_DNI853.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos_DNI853).EndInit();
            panelInferior_DNI853.ResumeLayout(false);
            panelInferior_DNI853.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContenedor_DNI853;
        private Label lblTitulo_DNI853;
        private Button btnSalir_DNI853;
        private DataGridView dgvProductos_DNI853;
        private Label lblNombreProducto_DNI853;
        private TextBox txtNombreProducto_DNI853;
        private Label lblCategoria_DNI853;
        private ComboBox cmbCategoria_DNI853;
        private Label lblPrecio_DNI853;
        private TextBox txtPrecio_DNI853;
        private Label lblStock_DNI853;
        private TextBox txtStock_DNI853;

        // Botones de acción ABM
        private Button btnNuevoProducto_DNI853;
        private Button btnModificarProducto_DNI853;
        private Button btnEliminarProducto_DNI853;

        // Panel Inferior
        private Panel panelInferior_DNI853;
        private Label lblUsuarioActivo_DNI853;
        private Label lblUsuarioValor_DNI853;
    }
}