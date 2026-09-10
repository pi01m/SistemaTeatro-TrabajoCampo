namespace IU
{
    partial class FormConfiguracion
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
            cmbIdioma = new ComboBox();
            btnGuardarr = new Button();
            button1 = new Button();
            panelLogin = new Panel();
            panelLogin.SuspendLayout();
            SuspendLayout();
            // 
            // cmbIdioma
            // 
            cmbIdioma.Font = new Font("Segoe UI", 10F);
            cmbIdioma.FormattingEnabled = true;
            cmbIdioma.Location = new Point(73, 118);
            cmbIdioma.Margin = new Padding(2, 3, 2, 3);
            cmbIdioma.Name = "cmbIdioma";
            cmbIdioma.Size = new Size(288, 53);
            cmbIdioma.TabIndex = 8;
            cmbIdioma.SelectedIndexChanged += cmbIdioma_SelectedIndexChanged;
            // 
            // btnGuardarr
            // 
            btnGuardarr.BackColor = Color.White;
            btnGuardarr.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnGuardarr.FlatStyle = FlatStyle.Flat;
            btnGuardarr.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGuardarr.ForeColor = Color.FromArgb(120, 20, 40);
            btnGuardarr.Location = new Point(437, 93);
            btnGuardarr.Margin = new Padding(2, 3, 2, 3);
            btnGuardarr.Name = "btnGuardarr";
            btnGuardarr.Size = new Size(260, 101);
            btnGuardarr.TabIndex = 9;
            btnGuardarr.Tag = "btn_Guardar";
            btnGuardarr.Text = "Guardar";
            btnGuardarr.UseVisualStyleBackColor = false;
            btnGuardarr.Click += btnGuardarr_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.ForeColor = Color.FromArgb(120, 20, 40);
            button1.Location = new Point(437, 271);
            button1.Margin = new Padding(2, 3, 2, 3);
            button1.Name = "button1";
            button1.Size = new Size(260, 101);
            button1.TabIndex = 10;
            button1.Tag = "btn_Salir";
            button1.Text = "Salir";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panelLogin
            // 
            panelLogin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelLogin.BackColor = Color.White;
            panelLogin.BorderStyle = BorderStyle.FixedSingle;
            panelLogin.Controls.Add(button1);
            panelLogin.Controls.Add(btnGuardarr);
            panelLogin.Controls.Add(cmbIdioma);
            panelLogin.Dock = DockStyle.Fill;
            panelLogin.Location = new Point(0, 0);
            panelLogin.Margin = new Padding(2, 3, 2, 3);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(792, 476);
            panelLogin.TabIndex = 1;
            panelLogin.Paint += panelLogin_Paint;
            // 
            // FormConfiguracion
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 238, 235);
            ClientSize = new Size(792, 476);
            Controls.Add(panelLogin);
            Margin = new Padding(2, 3, 2, 3);
            Name = "FormConfiguracion";
            Tag = "lbl_FormConfIdioma";
            Text = "TeatroLux - Configuración Idioma";
            FormClosed += FormConfiguracion_FormClosed;
            Load += FormConfiguracion_Load;
            panelLogin.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbIdioma;
        private Button btnGuardarr;
        private Button button1;
        private Panel panelLogin;
    }
}