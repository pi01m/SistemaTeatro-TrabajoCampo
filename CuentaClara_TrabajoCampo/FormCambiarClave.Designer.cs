namespace CuentaClara_TrabajoCampo
{
    partial class FormCambiarClave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCambiarClave));
            panelContenedor = new Panel();
            lblTitulo = new Label();
            lblClaveActual = new Label();
            txtClaveActual = new TextBox();
            lblNuevaClave = new Label();
            txtNuevaClave = new TextBox();
            btnGuardar = new Button();
            panelInferior = new Panel();
            lblUsuarioValor = new Label();
            lblUsuarioActivo = new Label();
            panelContenedor.SuspendLayout();
            panelInferior.SuspendLayout();
            SuspendLayout();
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.White;
            panelContenedor.Controls.Add(lblTitulo);
            panelContenedor.Controls.Add(lblClaveActual);
            panelContenedor.Controls.Add(txtClaveActual);
            panelContenedor.Controls.Add(lblNuevaClave);
            panelContenedor.Controls.Add(txtNuevaClave);
            panelContenedor.Controls.Add(btnGuardar);
            panelContenedor.Location = new Point(97, 82);
            panelContenedor.Margin = new Padding(7, 8, 7, 8);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(1263, 875);
            panelContenedor.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(120, 20, 40);
            lblTitulo.Location = new Point(85, 68);
            lblTitulo.Margin = new Padding(7, 0, 7, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(601, 81);
            lblTitulo.TabIndex = 0;
            lblTitulo.Tag = "lbl_TituloCambiarContraseña";
            lblTitulo.Text = "Cambiar Contraseña";
            // 
            // lblClaveActual
            // 
            lblClaveActual.AutoSize = true;
            lblClaveActual.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblClaveActual.ForeColor = Color.FromArgb(60, 60, 60);
            lblClaveActual.Location = new Point(97, 260);
            lblClaveActual.Margin = new Padding(7, 0, 7, 0);
            lblClaveActual.Name = "lblClaveActual";
            lblClaveActual.Size = new Size(249, 46);
            lblClaveActual.TabIndex = 1;
            lblClaveActual.Tag = "lbl_ClaveAnterior";
            lblClaveActual.Text = "Clave Anterior";
            // 
            // txtClaveActual
            // 
            txtClaveActual.BorderStyle = BorderStyle.FixedSingle;
            txtClaveActual.Font = new Font("Segoe UI", 10F);
            txtClaveActual.Location = new Point(107, 328);
            txtClaveActual.Margin = new Padding(7, 8, 7, 8);
            txtClaveActual.Name = "txtClaveActual";
            txtClaveActual.PasswordChar = '●';
            txtClaveActual.Size = new Size(1017, 52);
            txtClaveActual.TabIndex = 2;
            // 
            // lblNuevaClave
            // 
            lblNuevaClave.AutoSize = true;
            lblNuevaClave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNuevaClave.ForeColor = Color.FromArgb(60, 60, 60);
            lblNuevaClave.Location = new Point(97, 465);
            lblNuevaClave.Margin = new Padding(7, 0, 7, 0);
            lblNuevaClave.Name = "lblNuevaClave";
            lblNuevaClave.Size = new Size(215, 46);
            lblNuevaClave.TabIndex = 3;
            lblNuevaClave.Tag = "lbl_NuevaClave";
            lblNuevaClave.Text = "Nueva Clave";
            // 
            // txtNuevaClave
            // 
            txtNuevaClave.BorderStyle = BorderStyle.FixedSingle;
            txtNuevaClave.Font = new Font("Segoe UI", 10F);
            txtNuevaClave.Location = new Point(107, 533);
            txtNuevaClave.Margin = new Padding(7, 8, 7, 8);
            txtNuevaClave.Name = "txtNuevaClave";
            txtNuevaClave.PasswordChar = '●';
            txtNuevaClave.Size = new Size(1017, 52);
            txtNuevaClave.TabIndex = 4;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(120, 20, 40);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(784, 689);
            btnGuardar.Margin = new Padding(7, 8, 7, 8);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(340, 109);
            btnGuardar.TabIndex = 5;
            btnGuardar.Tag = "btn_Guardar";
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // panelInferior
            // 
            panelInferior.BackColor = Color.FromArgb(120, 20, 40);
            panelInferior.Controls.Add(lblUsuarioValor);
            panelInferior.Controls.Add(lblUsuarioActivo);
            panelInferior.Dock = DockStyle.Bottom;
            panelInferior.Location = new Point(0, 952);
            panelInferior.Margin = new Padding(7, 8, 7, 8);
            panelInferior.Name = "panelInferior";
            panelInferior.Size = new Size(1549, 109);
            panelInferior.TabIndex = 1;
            // 
            // lblUsuarioValor
            // 
            lblUsuarioValor.AutoSize = true;
            lblUsuarioValor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsuarioValor.ForeColor = Color.White;
            lblUsuarioValor.Location = new Point(299, 33);
            lblUsuarioValor.Margin = new Padding(7, 0, 7, 0);
            lblUsuarioValor.Name = "lblUsuarioValor";
            lblUsuarioValor.Size = new Size(459, 41);
            lblUsuarioValor.TabIndex = 2;
            lblUsuarioValor.Tag = "";
            lblUsuarioValor.Text = "Maria Lopez-Usuario Operativo";
            // 
            // lblUsuarioActivo
            // 
            lblUsuarioActivo.AutoSize = true;
            lblUsuarioActivo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsuarioActivo.ForeColor = Color.White;
            lblUsuarioActivo.Location = new Point(49, 33);
            lblUsuarioActivo.Margin = new Padding(7, 0, 7, 0);
            lblUsuarioActivo.Name = "lblUsuarioActivo";
            lblUsuarioActivo.Size = new Size(235, 41);
            lblUsuarioActivo.TabIndex = 0;
            lblUsuarioActivo.Tag = "lbl_Usuario";
            lblUsuarioActivo.Text = "Usuario activo: ";
            // 
            // FormCambiarClave
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 238, 235);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1549, 1061);
            Controls.Add(panelInferior);
            Controls.Add(panelContenedor);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(7, 8, 7, 8);
            MaximizeBox = false;
            Name = "FormCambiarClave";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "lbl_FormCambiarClave";
            Text = "TeatroLux - Cambiar Contraseña";
            FormClosed += FormCambiarClave_FormClosed;
            Load += FormCambiarClave_Load_1;
            panelContenedor.ResumeLayout(false);
            panelContenedor.PerformLayout();
            panelInferior.ResumeLayout(false);
            panelInferior.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblClaveActual;
        private System.Windows.Forms.TextBox txtClaveActual;
        private System.Windows.Forms.Label lblNuevaClave;
        private System.Windows.Forms.TextBox txtNuevaClave;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel panelInferior;
        private System.Windows.Forms.Label lblUsuarioActivo;
        private Label lblUsuarioValor;
    }
}