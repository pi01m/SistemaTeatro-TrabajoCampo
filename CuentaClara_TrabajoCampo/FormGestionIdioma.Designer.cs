
namespace IU
{
    partial class FormGestionIdioma
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
            lblTitulo = new Label();
            lblSeccionIdioma = new Label();
            cboIdiomas = new ComboBox();
            dgvEtiquetas = new DataGridView();
            lblClave = new Label();
            txtClave = new TextBox();
            lblTexto = new Label();
            txtTexto = new TextBox();
            panelInferior = new Panel();
            lblUsuarioValor = new Label();
            lblUsuario = new Label();
            btnNuevoIdioma = new Button();
            btnAgregarEtiqueta = new Button();
            btnModificarEtiqueta = new Button();
            btnSalir = new Button();
            btnAplicar = new Button();
            listBox1 = new ListBox();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEtiquetas).BeginInit();
            panelInferior.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(120, 20, 40);
            lblTitulo.Location = new Point(124, 189);
            lblTitulo.Margin = new Padding(7, 0, 7, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(710, 99);
            lblTitulo.TabIndex = 0;
            lblTitulo.Tag = "lbl_TituloGestiondeIdiomas";
            lblTitulo.Text = "Gestión de Idiomas";
            // 
            // lblSeccionIdioma
            // 
            lblSeccionIdioma.AutoSize = true;
            lblSeccionIdioma.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSeccionIdioma.ForeColor = Color.FromArgb(60, 60, 60);
            lblSeccionIdioma.Location = new Point(131, 394);
            lblSeccionIdioma.Margin = new Padding(7, 0, 7, 0);
            lblSeccionIdioma.Name = "lblSeccionIdioma";
            lblSeccionIdioma.Size = new Size(390, 50);
            lblSeccionIdioma.TabIndex = 1;
            lblSeccionIdioma.Tag = "lbl_SeleccioneElIdioma";
            lblSeccionIdioma.Text = "Seleccione el Idioma:";
            // 
            // cboIdiomas
            // 
            cboIdiomas.DropDownStyle = ComboBoxStyle.DropDownList;
            cboIdiomas.Font = new Font("Segoe UI", 11F);
            cboIdiomas.FormattingEnabled = true;
            cboIdiomas.Location = new Point(605, 383);
            cboIdiomas.Margin = new Padding(7, 8, 7, 8);
            cboIdiomas.Name = "cboIdiomas";
            cboIdiomas.Size = new Size(616, 58);
            cboIdiomas.TabIndex = 2;
            cboIdiomas.SelectedIndexChanged += cboIdiomas_SelectedIndexChanged;
            // 
            // dgvEtiquetas
            // 
            dgvEtiquetas.AllowUserToAddRows = false;
            dgvEtiquetas.AllowUserToDeleteRows = false;
            dgvEtiquetas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEtiquetas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEtiquetas.BackgroundColor = Color.FromArgb(120, 20, 40);
            dgvEtiquetas.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(235, 230, 225);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(120, 20, 40);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(235, 230, 225);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(120, 20, 40);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvEtiquetas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvEtiquetas.ColumnHeadersHeight = 30;
            dgvEtiquetas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(120, 20, 40);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvEtiquetas.DefaultCellStyle = dataGridViewCellStyle4;
            dgvEtiquetas.EnableHeadersVisualStyles = false;
            dgvEtiquetas.Location = new Point(134, 549);
            dgvEtiquetas.Margin = new Padding(7, 8, 7, 8);
            dgvEtiquetas.MultiSelect = false;
            dgvEtiquetas.Name = "dgvEtiquetas";
            dgvEtiquetas.ReadOnly = true;
            dgvEtiquetas.RowHeadersVisible = false;
            dgvEtiquetas.RowHeadersWidth = 102;
            dgvEtiquetas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEtiquetas.Size = new Size(2125, 883);
            dgvEtiquetas.TabIndex = 3;
            // 
            // lblClave
            // 
            lblClave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblClave.ForeColor = Color.FromArgb(60, 60, 60);
            lblClave.Location = new Point(124, 1512);
            lblClave.Margin = new Padding(7, 0, 7, 0);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(114, 46);
            lblClave.TabIndex = 4;
            lblClave.Tag = "Clave";
            lblClave.Text = "Clave:";
            // 
            // txtClave
            // 
            txtClave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtClave.BorderStyle = BorderStyle.FixedSingle;
            txtClave.Font = new Font("Segoe UI", 10F);
            txtClave.Location = new Point(134, 1583);
            txtClave.Margin = new Padding(7, 8, 7, 8);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(845, 52);
            txtClave.TabIndex = 5;
            // 
            // lblTexto
            // 
            lblTexto.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTexto.AutoSize = true;
            lblTexto.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTexto.ForeColor = Color.FromArgb(60, 60, 60);
            lblTexto.Location = new Point(124, 1717);
            lblTexto.Margin = new Padding(7, 0, 7, 0);
            lblTexto.Name = "lblTexto";
            lblTexto.Size = new Size(117, 46);
            lblTexto.TabIndex = 6;
            lblTexto.Tag = "Texto";
            lblTexto.Text = "Texto:";
            // 
            // txtTexto
            // 
            txtTexto.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtTexto.BorderStyle = BorderStyle.FixedSingle;
            txtTexto.Font = new Font("Segoe UI", 10F);
            txtTexto.Location = new Point(134, 1788);
            txtTexto.Margin = new Padding(7, 8, 7, 8);
            txtTexto.Name = "txtTexto";
            txtTexto.Size = new Size(845, 52);
            txtTexto.TabIndex = 7;
            // 
            // panelInferior
            // 
            panelInferior.BackColor = Color.FromArgb(120, 20, 40);
            panelInferior.Controls.Add(lblUsuarioValor);
            panelInferior.Controls.Add(lblUsuario);
            panelInferior.Dock = DockStyle.Bottom;
            panelInferior.Location = new Point(0, 1982);
            panelInferior.Margin = new Padding(7, 8, 7, 8);
            panelInferior.Name = "panelInferior";
            panelInferior.Size = new Size(3191, 126);
            panelInferior.TabIndex = 13;
            // 
            // lblUsuarioValor
            // 
            lblUsuarioValor.AutoSize = true;
            lblUsuarioValor.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUsuarioValor.ForeColor = Color.White;
            lblUsuarioValor.Location = new Point(323, 33);
            lblUsuarioValor.Margin = new Padding(7, 0, 7, 0);
            lblUsuarioValor.Name = "lblUsuarioValor";
            lblUsuarioValor.Size = new Size(471, 46);
            lblUsuarioValor.TabIndex = 16;
            lblUsuarioValor.Text = "Maria Lopez- Administrador";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUsuario.ForeColor = Color.White;
            lblUsuario.Location = new Point(41, 33);
            lblUsuario.Margin = new Padding(7, 0, 7, 0);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(267, 46);
            lblUsuario.TabIndex = 0;
            lblUsuario.Tag = "lbl_Usuario";
            lblUsuario.Text = "Usuario activo: ";
            // 
            // btnNuevoIdioma
            // 
            btnNuevoIdioma.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevoIdioma.BackColor = Color.FromArgb(120, 20, 40);
            btnNuevoIdioma.FlatAppearance.BorderSize = 0;
            btnNuevoIdioma.FlatStyle = FlatStyle.Flat;
            btnNuevoIdioma.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNuevoIdioma.ForeColor = Color.White;
            btnNuevoIdioma.Location = new Point(2319, 536);
            btnNuevoIdioma.Margin = new Padding(7, 8, 7, 8);
            btnNuevoIdioma.Name = "btnNuevoIdioma";
            btnNuevoIdioma.Size = new Size(396, 142);
            btnNuevoIdioma.TabIndex = 8;
            btnNuevoIdioma.Tag = "btn_NuevoIdioma";
            btnNuevoIdioma.Text = "Nuevo Idioma";
            btnNuevoIdioma.UseVisualStyleBackColor = false;
            btnNuevoIdioma.Click += btnNuevoIdioma_Click;
            // 
            // btnAgregarEtiqueta
            // 
            btnAgregarEtiqueta.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregarEtiqueta.BackColor = Color.White;
            btnAgregarEtiqueta.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnAgregarEtiqueta.FlatStyle = FlatStyle.Flat;
            btnAgregarEtiqueta.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAgregarEtiqueta.ForeColor = Color.FromArgb(120, 20, 40);
            btnAgregarEtiqueta.Location = new Point(2319, 741);
            btnAgregarEtiqueta.Margin = new Padding(7, 8, 7, 8);
            btnAgregarEtiqueta.Name = "btnAgregarEtiqueta";
            btnAgregarEtiqueta.Size = new Size(396, 142);
            btnAgregarEtiqueta.TabIndex = 9;
            btnAgregarEtiqueta.Tag = "btn_AgregarEtiqueta";
            btnAgregarEtiqueta.Text = "Agregar Etiqueta";
            btnAgregarEtiqueta.UseVisualStyleBackColor = false;
            btnAgregarEtiqueta.Click += btnAgregarEtiqueta_Click;
            // 
            // btnModificarEtiqueta
            // 
            btnModificarEtiqueta.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnModificarEtiqueta.BackColor = Color.White;
            btnModificarEtiqueta.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnModificarEtiqueta.FlatStyle = FlatStyle.Flat;
            btnModificarEtiqueta.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnModificarEtiqueta.ForeColor = Color.FromArgb(120, 20, 40);
            btnModificarEtiqueta.Location = new Point(2319, 946);
            btnModificarEtiqueta.Margin = new Padding(7, 8, 7, 8);
            btnModificarEtiqueta.Name = "btnModificarEtiqueta";
            btnModificarEtiqueta.Size = new Size(396, 142);
            btnModificarEtiqueta.TabIndex = 10;
            btnModificarEtiqueta.Tag = "btn_ModificarEtiqueta";
            btnModificarEtiqueta.Text = "Modificar Etiqueta";
            btnModificarEtiqueta.UseVisualStyleBackColor = false;
            btnModificarEtiqueta.Click += btnModificarEtiqueta_Click;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.BackColor = Color.White;
            btnSalir.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalir.ForeColor = Color.FromArgb(120, 20, 40);
            btnSalir.Location = new Point(2390, 1752);
            btnSalir.Margin = new Padding(7, 8, 7, 8);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(311, 120);
            btnSalir.TabIndex = 12;
            btnSalir.Tag = "btn_Salir";
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnAplicar
            // 
            btnAplicar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAplicar.BackColor = Color.FromArgb(120, 20, 40);
            btnAplicar.FlatAppearance.BorderSize = 0;
            btnAplicar.FlatStyle = FlatStyle.Flat;
            btnAplicar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAplicar.ForeColor = Color.White;
            btnAplicar.Location = new Point(1243, 1749);
            btnAplicar.Margin = new Padding(7, 8, 7, 8);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(311, 120);
            btnAplicar.TabIndex = 11;
            btnAplicar.Tag = "btn_Aplicar";
            btnAplicar.Text = "Aplicar";
            btnAplicar.UseVisualStyleBackColor = false;
            btnAplicar.Click += btnAplicar_Click;
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            listBox1.BorderStyle = BorderStyle.FixedSingle;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 41;
            listBox1.Location = new Point(1226, 1490);
            listBox1.Margin = new Padding(2, 3, 2, 3);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(1034, 207);
            listBox1.TabIndex = 14;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancelar.BackColor = Color.White;
            btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.FromArgb(120, 20, 40);
            btnCancelar.Location = new Point(1591, 1749);
            btnCancelar.Margin = new Padding(7, 8, 7, 8);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(311, 120);
            btnCancelar.TabIndex = 15;
            btnCancelar.Tag = "btn_Cancelar";
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // FormGestionIdioma
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 238, 235);
            ClientSize = new Size(3191, 2108);
            Controls.Add(btnCancelar);
            Controls.Add(listBox1);
            Controls.Add(panelInferior);
            Controls.Add(btnSalir);
            Controls.Add(btnAplicar);
            Controls.Add(btnModificarEtiqueta);
            Controls.Add(btnAgregarEtiqueta);
            Controls.Add(btnNuevoIdioma);
            Controls.Add(txtTexto);
            Controls.Add(lblTexto);
            Controls.Add(txtClave);
            Controls.Add(lblClave);
            Controls.Add(dgvEtiquetas);
            Controls.Add(cboIdiomas);
            Controls.Add(lblSeccionIdioma);
            Controls.Add(lblTitulo);
            Margin = new Padding(7, 8, 7, 8);
            Name = "FormGestionIdioma";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "lbl_FormGestionIdioma";
            Text = "TeatroLux - Gestión de Idioma";
            FormClosed += FormGestionIdioma_FormClosed;
            Load += FormGestionIdioma_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEtiquetas).EndInit();
            panelInferior.ResumeLayout(false);
            panelInferior.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSeccionIdioma;
        private System.Windows.Forms.ComboBox cboIdiomas;
        private System.Windows.Forms.DataGridView dgvEtiquetas;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.Button btnNuevoIdioma;
        private System.Windows.Forms.Button btnAgregarEtiqueta;
        private System.Windows.Forms.Button btnModificarEtiqueta;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panelInferior;
        private System.Windows.Forms.Label lblUsuario;
        private ListBox listBox1;
        private Button btnCancelar;
        private Label lblUsuarioValor;
    }
}