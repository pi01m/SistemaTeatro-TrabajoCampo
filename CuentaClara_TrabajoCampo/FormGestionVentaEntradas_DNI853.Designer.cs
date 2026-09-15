using BLL;

namespace IU
{
    partial class FormGestionVentaEntradas_DNI853
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGestionVentaEntradas_DNI853));
            panelContenedor_DNI853 = new Panel();
            lblTitulo_DNI853 = new Label();
            lblObra_DNI853 = new Label();
            cboObra_DNI853 = new ComboBox();
            lblFechaFuncion_DNI853 = new Label();
            dtpFechaFuncion_DNI853 = new DateTimePicker();
            btnBuscarFunciones_DNI853 = new Button();
            dgvFunciones_DNI853 = new DataGridView();
            lblSectoresDisponibles_DNI853 = new Label();
            dgvSectores_DNI853 = new DataGridView();
            lblCantidad_DNI853 = new Label();
            txtCantidad_DNI853 = new TextBox();
            btnAgregarItem_DNI853 = new Button();
            lblCarrito_DNI853 = new Label();
            dgvCarrito_DNI853 = new DataGridView();
            btnQuitarItem_DNI853 = new Button();
            lblDniCliente_DNI853 = new Label();
            txtDniCliente_DNI853 = new TextBox();
            btnBuscarCliente_DNI853 = new Button();
            btnRegistrarCliente_DNI853 = new Button();
            lblNombreCliente_DNI853 = new Label();
            txtNombreCliente_DNI853 = new TextBox();
            lblPromocion_DNI853 = new Label();
            cboPromocion_DNI853 = new ComboBox();
            lblMedioPago_DNI853 = new Label();
            cboMedioPago_DNI853 = new ComboBox();
            lblBanco_DNI853 = new Label();
            txtBanco_DNI853 = new TextBox();
            lblNroTarjeta_DNI853 = new Label();
            txtNroTarjeta_DNI853 = new TextBox();
            lblVencimiento_DNI853 = new Label();
            txtVencimiento_DNI853 = new TextBox();
            lblImporteTotalTexto_DNI853 = new Label();
            txtImporteTotal_DNI853 = new TextBox();
            btnLimpiar_DNI853 = new Button();
            btnConfirmarVenta_DNI853 = new Button();
            btnImprimirFactura_DNI853 = new Button();
            btnImprimirEntradas_DNI853 = new Button();
            btnSalir_DNI853 = new Button();
            panelInferior_DNI853 = new Panel();
            lblUsuarioValor_DNI853 = new Label();
            lblUsuarioActivo_DNI853 = new Label();
            panelContenedor_DNI853.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFunciones_DNI853).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSectores_DNI853).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito_DNI853).BeginInit();
            panelInferior_DNI853.SuspendLayout();
            SuspendLayout();
            // 
            // panelContenedor_DNI853
            // 
            panelContenedor_DNI853.Anchor = AnchorStyles.None;
            panelContenedor_DNI853.BackColor = Color.FromArgb(240, 238, 235);
            panelContenedor_DNI853.Controls.Add(lblTitulo_DNI853);
            panelContenedor_DNI853.Controls.Add(lblObra_DNI853);
            panelContenedor_DNI853.Controls.Add(cboObra_DNI853);
            panelContenedor_DNI853.Controls.Add(lblFechaFuncion_DNI853);
            panelContenedor_DNI853.Controls.Add(dtpFechaFuncion_DNI853);
            panelContenedor_DNI853.Controls.Add(btnBuscarFunciones_DNI853);
            panelContenedor_DNI853.Controls.Add(dgvFunciones_DNI853);
            panelContenedor_DNI853.Controls.Add(lblSectoresDisponibles_DNI853);
            panelContenedor_DNI853.Controls.Add(dgvSectores_DNI853);
            panelContenedor_DNI853.Controls.Add(lblCantidad_DNI853);
            panelContenedor_DNI853.Controls.Add(txtCantidad_DNI853);
            panelContenedor_DNI853.Controls.Add(btnAgregarItem_DNI853);
            panelContenedor_DNI853.Controls.Add(lblCarrito_DNI853);
            panelContenedor_DNI853.Controls.Add(dgvCarrito_DNI853);
            panelContenedor_DNI853.Controls.Add(btnQuitarItem_DNI853);
            panelContenedor_DNI853.Controls.Add(lblDniCliente_DNI853);
            panelContenedor_DNI853.Controls.Add(txtDniCliente_DNI853);
            panelContenedor_DNI853.Controls.Add(btnBuscarCliente_DNI853);
            panelContenedor_DNI853.Controls.Add(btnRegistrarCliente_DNI853);
            panelContenedor_DNI853.Controls.Add(lblNombreCliente_DNI853);
            panelContenedor_DNI853.Controls.Add(txtNombreCliente_DNI853);
            panelContenedor_DNI853.Controls.Add(lblPromocion_DNI853);
            panelContenedor_DNI853.Controls.Add(cboPromocion_DNI853);
            panelContenedor_DNI853.Controls.Add(lblMedioPago_DNI853);
            panelContenedor_DNI853.Controls.Add(cboMedioPago_DNI853);
            panelContenedor_DNI853.Controls.Add(lblBanco_DNI853);
            panelContenedor_DNI853.Controls.Add(txtBanco_DNI853);
            panelContenedor_DNI853.Controls.Add(lblNroTarjeta_DNI853);
            panelContenedor_DNI853.Controls.Add(txtNroTarjeta_DNI853);
            panelContenedor_DNI853.Controls.Add(lblVencimiento_DNI853);
            panelContenedor_DNI853.Controls.Add(txtVencimiento_DNI853);
            panelContenedor_DNI853.Controls.Add(lblImporteTotalTexto_DNI853);
            panelContenedor_DNI853.Controls.Add(txtImporteTotal_DNI853);
            panelContenedor_DNI853.Controls.Add(btnLimpiar_DNI853);
            panelContenedor_DNI853.Controls.Add(btnConfirmarVenta_DNI853);
            panelContenedor_DNI853.Controls.Add(btnImprimirFactura_DNI853);
            panelContenedor_DNI853.Controls.Add(btnImprimirEntradas_DNI853);
            panelContenedor_DNI853.Controls.Add(btnSalir_DNI853);
            panelContenedor_DNI853.Location = new Point(29, 33);
            panelContenedor_DNI853.Margin = new Padding(7, 8, 7, 8);
            panelContenedor_DNI853.Name = "panelContenedor_DNI853";
            panelContenedor_DNI853.Size = new Size(3196, 2036);
            panelContenedor_DNI853.TabIndex = 1;
            // 
            // lblTitulo_DNI853
            // 
            lblTitulo_DNI853.AutoSize = true;
            lblTitulo_DNI853.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo_DNI853.ForeColor = Color.FromArgb(120, 20, 40);
            lblTitulo_DNI853.Location = new Point(76, 63);
            lblTitulo_DNI853.Name = "lblTitulo_DNI853";
            lblTitulo_DNI853.Size = new Size(856, 81);
            lblTitulo_DNI853.TabIndex = 0;
            lblTitulo_DNI853.Tag = "lbl_TituloVentaEntradas_DNI853";
            lblTitulo_DNI853.Text = "Gestión de Venta de Entradas";
            // 
            // lblObra_DNI853
            // 
            lblObra_DNI853.AutoSize = true;
            lblObra_DNI853.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblObra_DNI853.ForeColor = Color.FromArgb(60, 60, 60);
            lblObra_DNI853.Location = new Point(76, 312);
            lblObra_DNI853.Name = "lblObra_DNI853";
            lblObra_DNI853.Size = new Size(99, 46);
            lblObra_DNI853.TabIndex = 1;
            lblObra_DNI853.Tag = "lbl_Obra_DNI853";
            lblObra_DNI853.Text = "Obra";
            // 
            // cboObra_DNI853
            // 
            cboObra_DNI853.DropDownStyle = ComboBoxStyle.DropDownList;
            cboObra_DNI853.Font = new Font("Segoe UI", 10F);
            cboObra_DNI853.Location = new Point(76, 367);
            cboObra_DNI853.Name = "cboObra_DNI853";
            cboObra_DNI853.Size = new Size(450, 53);
            cboObra_DNI853.TabIndex = 2;
            // 
            // lblFechaFuncion_DNI853
            // 
            lblFechaFuncion_DNI853.AutoSize = true;
            lblFechaFuncion_DNI853.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFechaFuncion_DNI853.ForeColor = Color.FromArgb(60, 60, 60);
            lblFechaFuncion_DNI853.Location = new Point(563, 312);
            lblFechaFuncion_DNI853.Name = "lblFechaFuncion_DNI853";
            lblFechaFuncion_DNI853.Size = new Size(110, 46);
            lblFechaFuncion_DNI853.TabIndex = 3;
            lblFechaFuncion_DNI853.Tag = "lbl_Fecha_DNI853";
            lblFechaFuncion_DNI853.Text = "Fecha";
            // 
            // dtpFechaFuncion_DNI853
            // 
            dtpFechaFuncion_DNI853.Font = new Font("Segoe UI", 10F);
            dtpFechaFuncion_DNI853.Format = DateTimePickerFormat.Short;
            dtpFechaFuncion_DNI853.Location = new Point(563, 367);
            dtpFechaFuncion_DNI853.Name = "dtpFechaFuncion_DNI853";
            dtpFechaFuncion_DNI853.Size = new Size(300, 52);
            dtpFechaFuncion_DNI853.TabIndex = 4;
            // 
            // btnBuscarFunciones_DNI853
            // 
            btnBuscarFunciones_DNI853.BackColor = Color.White;
            btnBuscarFunciones_DNI853.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnBuscarFunciones_DNI853.FlatStyle = FlatStyle.Flat;
            btnBuscarFunciones_DNI853.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBuscarFunciones_DNI853.ForeColor = Color.FromArgb(120, 20, 40);
            btnBuscarFunciones_DNI853.Location = new Point(888, 364);
            btnBuscarFunciones_DNI853.Name = "btnBuscarFunciones_DNI853";
            btnBuscarFunciones_DNI853.Size = new Size(250, 60);
            btnBuscarFunciones_DNI853.TabIndex = 5;
            btnBuscarFunciones_DNI853.Tag = "btn_BuscarFunciones_DNI853";
            btnBuscarFunciones_DNI853.Text = "Buscar Funciones";
            btnBuscarFunciones_DNI853.UseVisualStyleBackColor = false;
            btnBuscarFunciones_DNI853.Click += btnBuscarFunciones_DNI853_Click;
            // 
            // dgvFunciones_DNI853
            // 
            dgvFunciones_DNI853.AllowUserToAddRows = false;
            dgvFunciones_DNI853.AllowUserToDeleteRows = false;
            dgvFunciones_DNI853.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFunciones_DNI853.BackgroundColor = Color.FromArgb(120, 20, 40);
            dgvFunciones_DNI853.BorderStyle = BorderStyle.None;
            dgvFunciones_DNI853.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvFunciones_DNI853.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 230, 225);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(120, 20, 40);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(235, 230, 225);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(120, 20, 40);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvFunciones_DNI853.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvFunciones_DNI853.ColumnHeadersHeight = 35;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(120, 20, 40);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvFunciones_DNI853.DefaultCellStyle = dataGridViewCellStyle2;
            dgvFunciones_DNI853.EnableHeadersVisualStyles = false;
            dgvFunciones_DNI853.GridColor = Color.FromArgb(220, 220, 220);
            dgvFunciones_DNI853.Location = new Point(76, 442);
            dgvFunciones_DNI853.MultiSelect = false;
            dgvFunciones_DNI853.Name = "dgvFunciones_DNI853";
            dgvFunciones_DNI853.ReadOnly = true;
            dgvFunciones_DNI853.RowHeadersVisible = false;
            dgvFunciones_DNI853.RowHeadersWidth = 102;
            dgvFunciones_DNI853.RowTemplate.Height = 28;
            dgvFunciones_DNI853.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFunciones_DNI853.Size = new Size(1300, 350);
            dgvFunciones_DNI853.TabIndex = 6;
            dgvFunciones_DNI853.SelectionChanged += dgvFunciones_DNI853_SelectionChanged;
            // 
            // lblSectoresDisponibles_DNI853
            // 
            lblSectoresDisponibles_DNI853.AutoSize = true;
            lblSectoresDisponibles_DNI853.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSectoresDisponibles_DNI853.ForeColor = Color.FromArgb(120, 20, 40);
            lblSectoresDisponibles_DNI853.Location = new Point(76, 984);
            lblSectoresDisponibles_DNI853.Name = "lblSectoresDisponibles_DNI853";
            lblSectoresDisponibles_DNI853.Size = new Size(412, 54);
            lblSectoresDisponibles_DNI853.TabIndex = 7;
            lblSectoresDisponibles_DNI853.Tag = "lbl_SectoresDisponibles_DNI853";
            lblSectoresDisponibles_DNI853.Text = "Sectores Disponibles";
            // 
            // dgvSectores_DNI853
            // 
            dgvSectores_DNI853.AllowUserToAddRows = false;
            dgvSectores_DNI853.AllowUserToDeleteRows = false;
            dgvSectores_DNI853.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSectores_DNI853.BackgroundColor = Color.FromArgb(120, 20, 40);
            dgvSectores_DNI853.BorderStyle = BorderStyle.None;
            dgvSectores_DNI853.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvSectores_DNI853.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(235, 230, 225);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(120, 20, 40);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(235, 230, 225);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(120, 20, 40);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvSectores_DNI853.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvSectores_DNI853.ColumnHeadersHeight = 35;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(120, 20, 40);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvSectores_DNI853.DefaultCellStyle = dataGridViewCellStyle4;
            dgvSectores_DNI853.EnableHeadersVisualStyles = false;
            dgvSectores_DNI853.GridColor = Color.FromArgb(220, 220, 220);
            dgvSectores_DNI853.Location = new Point(76, 1054);
            dgvSectores_DNI853.MultiSelect = false;
            dgvSectores_DNI853.Name = "dgvSectores_DNI853";
            dgvSectores_DNI853.ReadOnly = true;
            dgvSectores_DNI853.RowHeadersVisible = false;
            dgvSectores_DNI853.RowHeadersWidth = 102;
            dgvSectores_DNI853.RowTemplate.Height = 28;
            dgvSectores_DNI853.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSectores_DNI853.Size = new Size(1300, 350);
            dgvSectores_DNI853.TabIndex = 8;
            // 
            // lblCantidad_DNI853
            // 
            lblCantidad_DNI853.AutoSize = true;
            lblCantidad_DNI853.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCantidad_DNI853.ForeColor = Color.FromArgb(60, 60, 60);
            lblCantidad_DNI853.Location = new Point(76, 1429);
            lblCantidad_DNI853.Name = "lblCantidad_DNI853";
            lblCantidad_DNI853.Size = new Size(163, 46);
            lblCantidad_DNI853.TabIndex = 9;
            lblCantidad_DNI853.Tag = "lbl_Cantidad_DNI853";
            lblCantidad_DNI853.Text = "Cantidad";
            // 
            // txtCantidad_DNI853
            // 
            txtCantidad_DNI853.BorderStyle = BorderStyle.FixedSingle;
            txtCantidad_DNI853.Font = new Font("Segoe UI", 12F);
            txtCantidad_DNI853.Location = new Point(76, 1484);
            txtCantidad_DNI853.Name = "txtCantidad_DNI853";
            txtCantidad_DNI853.Size = new Size(200, 61);
            txtCantidad_DNI853.TabIndex = 10;
            // 
            // btnAgregarItem_DNI853
            // 
            btnAgregarItem_DNI853.BackColor = Color.White;
            btnAgregarItem_DNI853.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnAgregarItem_DNI853.FlatStyle = FlatStyle.Flat;
            btnAgregarItem_DNI853.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAgregarItem_DNI853.ForeColor = Color.FromArgb(120, 20, 40);
            btnAgregarItem_DNI853.Location = new Point(303, 1481);
            btnAgregarItem_DNI853.Name = "btnAgregarItem_DNI853";
            btnAgregarItem_DNI853.Size = new Size(300, 65);
            btnAgregarItem_DNI853.TabIndex = 11;
            btnAgregarItem_DNI853.Tag = "btn_AgregarCarrito_DNI853";
            btnAgregarItem_DNI853.Text = "Agregar al Carrito";
            btnAgregarItem_DNI853.UseVisualStyleBackColor = false;
            btnAgregarItem_DNI853.Click += btnAgregarItem_DNI853_Click;
            // 
            // lblCarrito_DNI853
            // 
            lblCarrito_DNI853.AutoSize = true;
            lblCarrito_DNI853.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCarrito_DNI853.ForeColor = Color.FromArgb(120, 20, 40);
            lblCarrito_DNI853.Location = new Point(1537, 372);
            lblCarrito_DNI853.Name = "lblCarrito_DNI853";
            lblCarrito_DNI853.Size = new Size(416, 54);
            lblCarrito_DNI853.TabIndex = 12;
            lblCarrito_DNI853.Tag = "lbl_ResumenVenta_DNI853";
            lblCarrito_DNI853.Text = "Resumen de la Venta";
            // 
            // dgvCarrito_DNI853
            // 
            dgvCarrito_DNI853.AllowUserToAddRows = false;
            dgvCarrito_DNI853.AllowUserToDeleteRows = false;
            dgvCarrito_DNI853.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCarrito_DNI853.BackgroundColor = Color.FromArgb(120, 20, 40);
            dgvCarrito_DNI853.BorderStyle = BorderStyle.None;
            dgvCarrito_DNI853.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCarrito_DNI853.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCarrito_DNI853.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCarrito_DNI853.ColumnHeadersHeight = 35;
            dgvCarrito_DNI853.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCarrito_DNI853.EnableHeadersVisualStyles = false;
            dgvCarrito_DNI853.GridColor = Color.FromArgb(220, 220, 220);
            dgvCarrito_DNI853.Location = new Point(1537, 442);
            dgvCarrito_DNI853.MultiSelect = false;
            dgvCarrito_DNI853.Name = "dgvCarrito_DNI853";
            dgvCarrito_DNI853.ReadOnly = true;
            dgvCarrito_DNI853.RowHeadersVisible = false;
            dgvCarrito_DNI853.RowHeadersWidth = 102;
            dgvCarrito_DNI853.RowTemplate.Height = 28;
            dgvCarrito_DNI853.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarrito_DNI853.Size = new Size(1600, 260);
            dgvCarrito_DNI853.TabIndex = 13;
            // 
            // btnQuitarItem_DNI853
            // 
            btnQuitarItem_DNI853.BackColor = Color.White;
            btnQuitarItem_DNI853.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnQuitarItem_DNI853.FlatStyle = FlatStyle.Flat;
            btnQuitarItem_DNI853.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnQuitarItem_DNI853.ForeColor = Color.FromArgb(120, 20, 40);
            btnQuitarItem_DNI853.Location = new Point(1537, 717);
            btnQuitarItem_DNI853.Name = "btnQuitarItem_DNI853";
            btnQuitarItem_DNI853.Size = new Size(323, 75);
            btnQuitarItem_DNI853.TabIndex = 14;
            btnQuitarItem_DNI853.Tag = "btn_QuitarCarrito_DNI853";
            btnQuitarItem_DNI853.Text = "Quitar del Carrito";
            btnQuitarItem_DNI853.UseVisualStyleBackColor = false;
            btnQuitarItem_DNI853.Click += btnQuitarItem_DNI853_Click;
            // 
            // lblDniCliente_DNI853
            // 
            lblDniCliente_DNI853.AutoSize = true;
            lblDniCliente_DNI853.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDniCliente_DNI853.ForeColor = Color.FromArgb(60, 60, 60);
            lblDniCliente_DNI853.Location = new Point(1545, 855);
            lblDniCliente_DNI853.Name = "lblDniCliente_DNI853";
            lblDniCliente_DNI853.Size = new Size(203, 46);
            lblDniCliente_DNI853.TabIndex = 15;
            lblDniCliente_DNI853.Tag = "lbl_DniCliente_DNI853";
            lblDniCliente_DNI853.Text = "DNI Cliente";
            // 
            // txtDniCliente_DNI853
            // 
            txtDniCliente_DNI853.BorderStyle = BorderStyle.FixedSingle;
            txtDniCliente_DNI853.Font = new Font("Segoe UI", 10F);
            txtDniCliente_DNI853.Location = new Point(1545, 910);
            txtDniCliente_DNI853.Name = "txtDniCliente_DNI853";
            txtDniCliente_DNI853.Size = new Size(250, 52);
            txtDniCliente_DNI853.TabIndex = 16;
            // 
            // btnBuscarCliente_DNI853
            // 
            btnBuscarCliente_DNI853.BackColor = Color.White;
            btnBuscarCliente_DNI853.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnBuscarCliente_DNI853.FlatStyle = FlatStyle.Flat;
            btnBuscarCliente_DNI853.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBuscarCliente_DNI853.ForeColor = Color.FromArgb(120, 20, 40);
            btnBuscarCliente_DNI853.Location = new Point(1847, 907);
            btnBuscarCliente_DNI853.Name = "btnBuscarCliente_DNI853";
            btnBuscarCliente_DNI853.Size = new Size(177, 74);
            btnBuscarCliente_DNI853.TabIndex = 17;
            btnBuscarCliente_DNI853.Tag = "btn_Buscar_DNI853";
            btnBuscarCliente_DNI853.Text = "Buscar";
            btnBuscarCliente_DNI853.UseVisualStyleBackColor = false;
            btnBuscarCliente_DNI853.Click += btnBuscarCliente_DNI853_Click;
            // 
            // btnRegistrarCliente_DNI853
            // 
            btnRegistrarCliente_DNI853.BackColor = Color.White;
            btnRegistrarCliente_DNI853.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnRegistrarCliente_DNI853.FlatStyle = FlatStyle.Flat;
            btnRegistrarCliente_DNI853.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRegistrarCliente_DNI853.ForeColor = Color.FromArgb(120, 20, 40);
            btnRegistrarCliente_DNI853.Location = new Point(2567, 948);
            btnRegistrarCliente_DNI853.Name = "btnRegistrarCliente_DNI853";
            btnRegistrarCliente_DNI853.Size = new Size(240, 131);
            btnRegistrarCliente_DNI853.TabIndex = 18;
            btnRegistrarCliente_DNI853.Tag = "btn_RegistrarCliente_DNI853";
            btnRegistrarCliente_DNI853.Text = "Registrar Cliente";
            btnRegistrarCliente_DNI853.UseVisualStyleBackColor = false;
            btnRegistrarCliente_DNI853.Click += btnRegistrarCliente_DNI853_Click;
            // 
            // lblNombreCliente_DNI853
            // 
            lblNombreCliente_DNI853.AutoSize = true;
            lblNombreCliente_DNI853.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNombreCliente_DNI853.ForeColor = Color.FromArgb(60, 60, 60);
            lblNombreCliente_DNI853.Location = new Point(1545, 972);
            lblNombreCliente_DNI853.Name = "lblNombreCliente_DNI853";
            lblNombreCliente_DNI853.Size = new Size(256, 46);
            lblNombreCliente_DNI853.TabIndex = 19;
            lblNombreCliente_DNI853.Tag = "lbl_Cliente_DNI853";
            lblNombreCliente_DNI853.Text = "Cliente / Datos";
            // 
            // txtNombreCliente_DNI853
            // 
            txtNombreCliente_DNI853.BorderStyle = BorderStyle.FixedSingle;
            txtNombreCliente_DNI853.Font = new Font("Segoe UI", 10F);
            txtNombreCliente_DNI853.Location = new Point(1545, 1027);
            txtNombreCliente_DNI853.Name = "txtNombreCliente_DNI853";
            txtNombreCliente_DNI853.ReadOnly = true;
            txtNombreCliente_DNI853.Size = new Size(900, 52);
            txtNombreCliente_DNI853.TabIndex = 20;
            // 
            // lblPromocion_DNI853
            // 
            lblPromocion_DNI853.AutoSize = true;
            lblPromocion_DNI853.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPromocion_DNI853.ForeColor = Color.FromArgb(60, 60, 60);
            lblPromocion_DNI853.Location = new Point(1537, 1210);
            lblPromocion_DNI853.Name = "lblPromocion_DNI853";
            lblPromocion_DNI853.Size = new Size(196, 46);
            lblPromocion_DNI853.TabIndex = 21;
            lblPromocion_DNI853.Tag = "lbl_Promocion_DNI853";
            lblPromocion_DNI853.Text = "Promoción";
            // 
            // cboPromocion_DNI853
            // 
            cboPromocion_DNI853.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPromocion_DNI853.Font = new Font("Segoe UI", 10F);
            cboPromocion_DNI853.Location = new Point(1537, 1265);
            cboPromocion_DNI853.Name = "cboPromocion_DNI853";
            cboPromocion_DNI853.Size = new Size(600, 53);
            cboPromocion_DNI853.TabIndex = 22;
            cboPromocion_DNI853.SelectedIndexChanged += cboPromocion_DNI853_SelectedIndexChanged;
            // 
            // lblMedioPago_DNI853
            // 
            lblMedioPago_DNI853.AutoSize = true;
            lblMedioPago_DNI853.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMedioPago_DNI853.ForeColor = Color.FromArgb(60, 60, 60);
            lblMedioPago_DNI853.Location = new Point(2187, 1210);
            lblMedioPago_DNI853.Name = "lblMedioPago_DNI853";
            lblMedioPago_DNI853.Size = new Size(260, 46);
            lblMedioPago_DNI853.TabIndex = 23;
            lblMedioPago_DNI853.Tag = "lbl_MedioPago_DNI853";
            lblMedioPago_DNI853.Text = "Medio de Pago";
            // 
            // cboMedioPago_DNI853
            // 
            cboMedioPago_DNI853.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMedioPago_DNI853.Font = new Font("Segoe UI", 10F);
            cboMedioPago_DNI853.Location = new Point(2187, 1265);
            cboMedioPago_DNI853.Name = "cboMedioPago_DNI853";
            cboMedioPago_DNI853.Size = new Size(600, 53);
            cboMedioPago_DNI853.TabIndex = 24;
            cboMedioPago_DNI853.SelectedIndexChanged += cboMedioPago_DNI853_SelectedIndexChanged;
            // 
            // lblBanco_DNI853
            // 
            lblBanco_DNI853.AutoSize = true;
            lblBanco_DNI853.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBanco_DNI853.ForeColor = Color.FromArgb(60, 60, 60);
            lblBanco_DNI853.Location = new Point(1537, 1340);
            lblBanco_DNI853.Name = "lblBanco_DNI853";
            lblBanco_DNI853.Size = new Size(118, 46);
            lblBanco_DNI853.TabIndex = 25;
            lblBanco_DNI853.Tag = "lbl_Banco_DNI853";
            lblBanco_DNI853.Text = "Banco";
            // 
            // txtBanco_DNI853
            // 
            txtBanco_DNI853.BorderStyle = BorderStyle.FixedSingle;
            txtBanco_DNI853.Font = new Font("Segoe UI", 10F);
            txtBanco_DNI853.Location = new Point(1537, 1395);
            txtBanco_DNI853.Name = "txtBanco_DNI853";
            txtBanco_DNI853.Size = new Size(350, 52);
            txtBanco_DNI853.TabIndex = 26;
            // 
            // lblNroTarjeta_DNI853
            // 
            lblNroTarjeta_DNI853.AutoSize = true;
            lblNroTarjeta_DNI853.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNroTarjeta_DNI853.ForeColor = Color.FromArgb(60, 60, 60);
            lblNroTarjeta_DNI853.Location = new Point(1917, 1340);
            lblNroTarjeta_DNI853.Name = "lblNroTarjeta_DNI853";
            lblNroTarjeta_DNI853.Size = new Size(269, 46);
            lblNroTarjeta_DNI853.TabIndex = 27;
            lblNroTarjeta_DNI853.Tag = "lbl_NroTarjeta_DNI853";
            lblNroTarjeta_DNI853.Text = "Número Tarjeta";
            // 
            // txtNroTarjeta_DNI853
            // 
            txtNroTarjeta_DNI853.BorderStyle = BorderStyle.FixedSingle;
            txtNroTarjeta_DNI853.Font = new Font("Segoe UI", 10F);
            txtNroTarjeta_DNI853.Location = new Point(1917, 1395);
            txtNroTarjeta_DNI853.Name = "txtNroTarjeta_DNI853";
            txtNroTarjeta_DNI853.Size = new Size(500, 52);
            txtNroTarjeta_DNI853.TabIndex = 28;
            // 
            // lblVencimiento_DNI853
            // 
            lblVencimiento_DNI853.AutoSize = true;
            lblVencimiento_DNI853.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblVencimiento_DNI853.ForeColor = Color.FromArgb(60, 60, 60);
            lblVencimiento_DNI853.Location = new Point(2447, 1340);
            lblVencimiento_DNI853.Name = "lblVencimiento_DNI853";
            lblVencimiento_DNI853.Size = new Size(384, 46);
            lblVencimiento_DNI853.TabIndex = 29;
            lblVencimiento_DNI853.Tag = "lbl_Vencimiento_DNI853";
            lblVencimiento_DNI853.Text = "Vencimiento (MM/AA)";
            // 
            // txtVencimiento_DNI853
            // 
            txtVencimiento_DNI853.BorderStyle = BorderStyle.FixedSingle;
            txtVencimiento_DNI853.Font = new Font("Segoe UI", 10F);
            txtVencimiento_DNI853.Location = new Point(2447, 1395);
            txtVencimiento_DNI853.Name = "txtVencimiento_DNI853";
            txtVencimiento_DNI853.Size = new Size(340, 52);
            txtVencimiento_DNI853.TabIndex = 30;
            // 
            // lblImporteTotalTexto_DNI853
            // 
            lblImporteTotalTexto_DNI853.AutoSize = true;
            lblImporteTotalTexto_DNI853.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblImporteTotalTexto_DNI853.ForeColor = Color.FromArgb(120, 20, 40);
            lblImporteTotalTexto_DNI853.Location = new Point(1551, 1628);
            lblImporteTotalTexto_DNI853.Name = "lblImporteTotalTexto_DNI853";
            lblImporteTotalTexto_DNI853.Size = new Size(403, 62);
            lblImporteTotalTexto_DNI853.TabIndex = 31;
            lblImporteTotalTexto_DNI853.Tag = "lbl_ImporteTotal_DNI853";
            lblImporteTotalTexto_DNI853.Text = "IMPORTE TOTAL:";
            // 
            // txtImporteTotal_DNI853
            // 
            txtImporteTotal_DNI853.BorderStyle = BorderStyle.FixedSingle;
            txtImporteTotal_DNI853.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            txtImporteTotal_DNI853.ForeColor = Color.DarkGreen;
            txtImporteTotal_DNI853.Location = new Point(2062, 1619);
            txtImporteTotal_DNI853.Name = "txtImporteTotal_DNI853";
            txtImporteTotal_DNI853.ReadOnly = true;
            txtImporteTotal_DNI853.Size = new Size(400, 78);
            txtImporteTotal_DNI853.TabIndex = 32;
            txtImporteTotal_DNI853.Text = "$ 0.00";
            // 
            // btnLimpiar_DNI853
            // 
            btnLimpiar_DNI853.BackColor = Color.White;
            btnLimpiar_DNI853.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnLimpiar_DNI853.FlatStyle = FlatStyle.Flat;
            btnLimpiar_DNI853.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLimpiar_DNI853.ForeColor = Color.FromArgb(120, 20, 40);
            btnLimpiar_DNI853.Location = new Point(1551, 1758);
            btnLimpiar_DNI853.Name = "btnLimpiar_DNI853";
            btnLimpiar_DNI853.Size = new Size(300, 119);
            btnLimpiar_DNI853.TabIndex = 33;
            btnLimpiar_DNI853.Tag = "btn_CancelarVenta_DNI853";
            btnLimpiar_DNI853.Text = "Cancelar Venta";
            btnLimpiar_DNI853.UseVisualStyleBackColor = false;
            btnLimpiar_DNI853.Click += btnLimpiar_DNI853_Click;
            // 
            // btnConfirmarVenta_DNI853
            // 
            btnConfirmarVenta_DNI853.BackColor = Color.FromArgb(120, 20, 40);
            btnConfirmarVenta_DNI853.FlatAppearance.BorderSize = 0;
            btnConfirmarVenta_DNI853.FlatStyle = FlatStyle.Flat;
            btnConfirmarVenta_DNI853.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnConfirmarVenta_DNI853.ForeColor = Color.White;
            btnConfirmarVenta_DNI853.Location = new Point(1871, 1758);
            btnConfirmarVenta_DNI853.Name = "btnConfirmarVenta_DNI853";
            btnConfirmarVenta_DNI853.Size = new Size(320, 119);
            btnConfirmarVenta_DNI853.TabIndex = 34;
            btnConfirmarVenta_DNI853.Tag = "btn_ConfirmarVenta_DNI853";
            btnConfirmarVenta_DNI853.Text = "Confirmar Venta";
            btnConfirmarVenta_DNI853.UseVisualStyleBackColor = false;
            btnConfirmarVenta_DNI853.Click += btnConfirmarVenta_DNI853_Click;
            // 
            // btnImprimirFactura_DNI853
            // 
            btnImprimirFactura_DNI853.BackColor = Color.White;
            btnImprimirFactura_DNI853.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnImprimirFactura_DNI853.FlatStyle = FlatStyle.Flat;
            btnImprimirFactura_DNI853.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnImprimirFactura_DNI853.ForeColor = Color.FromArgb(120, 20, 40);
            btnImprimirFactura_DNI853.Location = new Point(2211, 1758);
            btnImprimirFactura_DNI853.Name = "btnImprimirFactura_DNI853";
            btnImprimirFactura_DNI853.Size = new Size(280, 119);
            btnImprimirFactura_DNI853.TabIndex = 35;
            btnImprimirFactura_DNI853.Tag = "btn_ImprimirFactura_DNI853";
            btnImprimirFactura_DNI853.Text = "Imprimir Factura";
            btnImprimirFactura_DNI853.UseVisualStyleBackColor = false;
            btnImprimirFactura_DNI853.Click += btnImprimirFactura_DNI853_Click;
            // 
            // btnImprimirEntradas_DNI853
            // 
            btnImprimirEntradas_DNI853.BackColor = Color.White;
            btnImprimirEntradas_DNI853.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnImprimirEntradas_DNI853.FlatStyle = FlatStyle.Flat;
            btnImprimirEntradas_DNI853.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnImprimirEntradas_DNI853.ForeColor = Color.FromArgb(120, 20, 40);
            btnImprimirEntradas_DNI853.Location = new Point(2511, 1758);
            btnImprimirEntradas_DNI853.Name = "btnImprimirEntradas_DNI853";
            btnImprimirEntradas_DNI853.Size = new Size(300, 119);
            btnImprimirEntradas_DNI853.TabIndex = 36;
            btnImprimirEntradas_DNI853.Tag = "btn_ImprimirEntradas_DNI853";
            btnImprimirEntradas_DNI853.Text = "Imprimir Entradas";
            btnImprimirEntradas_DNI853.UseVisualStyleBackColor = false;
            btnImprimirEntradas_DNI853.Click += btnImprimirEntradas_DNI853_Click;
            // 
            // btnSalir_DNI853
            // 
            btnSalir_DNI853.BackColor = Color.White;
            btnSalir_DNI853.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnSalir_DNI853.FlatStyle = FlatStyle.Flat;
            btnSalir_DNI853.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalir_DNI853.ForeColor = Color.FromArgb(120, 20, 40);
            btnSalir_DNI853.Location = new Point(2735, 103);
            btnSalir_DNI853.Name = "btnSalir_DNI853";
            btnSalir_DNI853.Size = new Size(340, 104);
            btnSalir_DNI853.TabIndex = 37;
            btnSalir_DNI853.Tag = "btn_Salir_DNI853";
            btnSalir_DNI853.Text = "Salir";
            btnSalir_DNI853.UseVisualStyleBackColor = false;
            btnSalir_DNI853.Click += btnSalir_DNI853_Click;
            // 
            // panelInferior_DNI853
            // 
            panelInferior_DNI853.BackColor = Color.FromArgb(120, 20, 40);
            panelInferior_DNI853.Controls.Add(lblUsuarioValor_DNI853);
            panelInferior_DNI853.Controls.Add(lblUsuarioActivo_DNI853);
            panelInferior_DNI853.Dock = DockStyle.Bottom;
            panelInferior_DNI853.Location = new Point(0, 2004);
            panelInferior_DNI853.Name = "panelInferior_DNI853";
            panelInferior_DNI853.Size = new Size(3254, 104);
            panelInferior_DNI853.TabIndex = 0;
            // 
            // lblUsuarioValor_DNI853
            // 
            lblUsuarioValor_DNI853.AutoSize = true;
            lblUsuarioValor_DNI853.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsuarioValor_DNI853.ForeColor = Color.White;
            lblUsuarioValor_DNI853.Location = new Point(277, 27);
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
            lblUsuarioActivo_DNI853.Location = new Point(49, 27);
            lblUsuarioActivo_DNI853.Name = "lblUsuarioActivo_DNI853";
            lblUsuarioActivo_DNI853.Size = new Size(235, 41);
            lblUsuarioActivo_DNI853.TabIndex = 0;
            lblUsuarioActivo_DNI853.Tag = "lbl_Usuario_DNI853";
            lblUsuarioActivo_DNI853.Text = "Usuario activo: ";
            // 
            // FormGestionVentaEntradas_DNI853
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 238, 235);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(3254, 2108);
            Controls.Add(panelInferior_DNI853);
            Controls.Add(panelContenedor_DNI853);
            Font = new Font("Segoe UI", 9F);
            Name = "FormGestionVentaEntradas_DNI853";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "lbl_FormVentaEntradas_DNI853";
            Text = "TeatroLux - Gestión de Venta de Entradas";
            Load += FormGestionVentaEntradas_DNI853_Load;
            panelContenedor_DNI853.ResumeLayout(false);
            panelContenedor_DNI853.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFunciones_DNI853).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSectores_DNI853).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito_DNI853).EndInit();
            panelInferior_DNI853.ResumeLayout(false);
            panelInferior_DNI853.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContenedor_DNI853;
        private Label lblTitulo_DNI853;

        // Columna Izquierda (Funciones y Sectores)
        private Label lblObra_DNI853;
        private ComboBox cboObra_DNI853;
        private Label lblFechaFuncion_DNI853;
        private DateTimePicker dtpFechaFuncion_DNI853;
        private Button btnBuscarFunciones_DNI853;
        private DataGridView dgvFunciones_DNI853;

        private Label lblSectoresDisponibles_DNI853;
        private DataGridView dgvSectores_DNI853;
        private Label lblCantidad_DNI853;
        private TextBox txtCantidad_DNI853;
        private Button btnAgregarItem_DNI853;

        // Columna Derecha (Carrito, Cliente, Promociones, Pago, Tarjeta)
        private Label lblCarrito_DNI853;
        private DataGridView dgvCarrito_DNI853;
        private Button btnQuitarItem_DNI853;

        private Label lblDniCliente_DNI853;
        private TextBox txtDniCliente_DNI853;
        private Button btnBuscarCliente_DNI853;
        private Button btnRegistrarCliente_DNI853;
        private Label lblNombreCliente_DNI853;
        private TextBox txtNombreCliente_DNI853;

        private Label lblPromocion_DNI853;
        private ComboBox cboPromocion_DNI853;
        private Label lblMedioPago_DNI853;
        private ComboBox cboMedioPago_DNI853;

        private Label lblBanco_DNI853;
        private TextBox txtBanco_DNI853;
        private Label lblNroTarjeta_DNI853;
        private TextBox txtNroTarjeta_DNI853;
        private Label lblVencimiento_DNI853;
        private TextBox txtVencimiento_DNI853;

        private Label lblImporteTotalTexto_DNI853;
        private TextBox txtImporteTotal_DNI853;

        // Botones de Acción e Impresión
        private Button btnLimpiar_DNI853;
        private Button btnConfirmarVenta_DNI853;
        private Button btnImprimirFactura_DNI853;
        private Button btnImprimirEntradas_DNI853;
        private Button btnSalir_DNI853;

        // Panel Inferior institucional
        private Panel panelInferior_DNI853;
        private Label lblUsuarioActivo_DNI853;
        private Label lblUsuarioValor_DNI853;
    }
}