namespace IU
{
    partial class FormPrimeraVez
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrimeraVez));
            btnBuscar = new Button();
            listaServidores = new ListBox();
            btnGuardar = new Button();
            label1 = new Label();
            lblTitulo = new Label();
            lblNombre = new Label();
            picLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBuscar.BackColor = Color.White;
            btnBuscar.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBuscar.ForeColor = Color.FromArgb(120, 20, 40);
            btnBuscar.Location = new Point(585, 629);
            btnBuscar.Margin = new Padding(0);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(386, 118);
            btnBuscar.TabIndex = 43;
            btnBuscar.Tag = "";
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // listaServidores
            // 
            listaServidores.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listaServidores.BorderStyle = BorderStyle.FixedSingle;
            listaServidores.FormattingEnabled = true;
            listaServidores.ItemHeight = 41;
            listaServidores.Location = new Point(56, 484);
            listaServidores.Margin = new Padding(0);
            listaServidores.Name = "listaServidores";
            listaServidores.Size = new Size(427, 699);
            listaServidores.TabIndex = 42;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnGuardar.BackColor = Color.FromArgb(120, 20, 40);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(585, 815);
            btnGuardar.Margin = new Padding(0);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(386, 118);
            btnGuardar.TabIndex = 41;
            btnGuardar.Tag = "";
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(60, 60, 60);
            label1.Location = new Point(56, 312);
            label1.Margin = new Padding(7, 0, 7, 0);
            label1.Name = "label1";
            label1.Size = new Size(914, 92);
            label1.TabIndex = 44;
            label1.Tag = "lbl_Nombre";
            label1.Text = "Para comenzar, necesitamos preparar tu entorno. \r\nPor favor, selecciona el nombre de tu servidor SQL local.";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(120, 20, 40);
            lblTitulo.Location = new Point(194, 55);
            lblTitulo.Margin = new Padding(2, 0, 2, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(313, 81);
            lblTitulo.TabIndex = 45;
            lblTitulo.Text = "TeatroLux";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(60, 60, 60);
            lblNombre.Location = new Point(56, 219);
            lblNombre.Margin = new Padding(7, 0, 7, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(242, 46);
            lblNombre.TabIndex = 46;
            lblNombre.Tag = "lbl_Nombre";
            lblNombre.Text = "Bienvenida/o ";
            // 
            // picLogo
            // 
            picLogo.BorderStyle = BorderStyle.FixedSingle;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(56, 25);
            picLogo.Margin = new Padding(0);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(133, 114);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picLogo.TabIndex = 47;
            picLogo.TabStop = false;
            // 
            // FormPrimeraVez
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 238, 235);
            ClientSize = new Size(1083, 1285);
            Controls.Add(picLogo);
            Controls.Add(lblNombre);
            Controls.Add(lblTitulo);
            Controls.Add(label1);
            Controls.Add(btnBuscar);
            Controls.Add(listaServidores);
            Controls.Add(btnGuardar);
            Margin = new Padding(2, 3, 2, 3);
            MaximizeBox = false;
            Name = "FormPrimeraVez";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "";
            Text = "TeatroLux";
            Load += FormPrimeraVez_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBuscar;
        private ListBox listaServidores;
        private Button btnGuardar;
        private Label label1;
        private Label lblTitulo;
        private Label lblNombre;
        private PictureBox picLogo;
    }
}