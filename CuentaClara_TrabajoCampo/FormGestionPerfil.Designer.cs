namespace IU
{
    partial class FormGestionPerfil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGestionPerfil));
            treeView1 = new TreeView();
            groupBox1 = new GroupBox();
            radioBtn_Familia = new RadioButton();
            radioBtn_Rol = new RadioButton();
            listBox1 = new ListBox();
            btnModificar = new Button();
            btnEliminar = new Button();
            lblTitulo = new Label();
            lblRol = new Label();
            cmbRol = new ComboBox();
            btnAsignarPermiso = new Button();
            btnAsignarFamilia = new Button();
            btnCrear = new Button();
            btnAplicar = new Button();
            cmbFamiliaHija = new ComboBox();
            button1 = new Button();
            label2 = new Label();
            button2 = new Button();
            panel1 = new Panel();
            treeViewVistaPrevia = new TreeView();
            cmbFamilia = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            clbFamilia = new CheckedListBox();
            clbPermiso = new CheckedListBox();
            btnSalir = new Button();
            panelInferior = new Panel();
            label5 = new Label();
            lblUsuarioActivo = new Label();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            panelInferior.SuspendLayout();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            treeView1.Location = new Point(1137, 538);
            treeView1.Margin = new Padding(0);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(985, 862);
            treeView1.TabIndex = 34;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(240, 238, 235);
            groupBox1.Controls.Add(radioBtn_Familia);
            groupBox1.Controls.Add(radioBtn_Rol);
            groupBox1.Location = new Point(1137, 219);
            groupBox1.Margin = new Padding(0);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(0);
            groupBox1.Size = new Size(612, 175);
            groupBox1.TabIndex = 32;
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // radioBtn_Familia
            // 
            radioBtn_Familia.AutoSize = true;
            radioBtn_Familia.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            radioBtn_Familia.ForeColor = Color.FromArgb(120, 20, 40);
            radioBtn_Familia.Location = new Point(219, 71);
            radioBtn_Familia.Margin = new Padding(0);
            radioBtn_Familia.Name = "radioBtn_Familia";
            radioBtn_Familia.Size = new Size(193, 50);
            radioBtn_Familia.TabIndex = 17;
            radioBtn_Familia.TabStop = true;
            radioBtn_Familia.Tag = "cmb_Familia";
            radioBtn_Familia.Text = "FAMILIA";
            radioBtn_Familia.UseVisualStyleBackColor = true;
            radioBtn_Familia.CheckedChanged += radioBtn_Familia_CheckedChanged;
            // 
            // radioBtn_Rol
            // 
            radioBtn_Rol.AutoSize = true;
            radioBtn_Rol.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            radioBtn_Rol.ForeColor = Color.FromArgb(120, 20, 40);
            radioBtn_Rol.Location = new Point(39, 71);
            radioBtn_Rol.Margin = new Padding(0);
            radioBtn_Rol.Name = "radioBtn_Rol";
            radioBtn_Rol.Size = new Size(122, 50);
            radioBtn_Rol.TabIndex = 0;
            radioBtn_Rol.TabStop = true;
            radioBtn_Rol.Tag = "cmb_Rol";
            radioBtn_Rol.Text = "ROL";
            radioBtn_Rol.UseVisualStyleBackColor = true;
            radioBtn_Rol.CheckedChanged += radioBtn_Rol_CheckedChanged_1;
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox1.BorderStyle = BorderStyle.FixedSingle;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 41;
            listBox1.Location = new Point(104, 1487);
            listBox1.Margin = new Padding(0);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(3273, 207);
            listBox1.TabIndex = 31;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.White;
            btnModificar.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnModificar.ForeColor = Color.FromArgb(120, 20, 40);
            btnModificar.Location = new Point(1809, 276);
            btnModificar.Margin = new Padding(0);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(318, 118);
            btnModificar.TabIndex = 30;
            btnModificar.Tag = "btn_Modificar";
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click_1;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.White;
            btnEliminar.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.FromArgb(120, 20, 40);
            btnEliminar.Location = new Point(2249, 276);
            btnEliminar.Margin = new Padding(0);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(311, 118);
            btnEliminar.TabIndex = 29;
            btnEliminar.Tag = "btn_Eliminar";
            btnEliminar.Text = "Eliminar ";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.FromArgb(240, 238, 235);
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(120, 20, 40);
            lblTitulo.Location = new Point(104, 66);
            lblTitulo.Margin = new Padding(0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(559, 81);
            lblTitulo.TabIndex = 19;
            lblTitulo.Tag = "lbl_GestionDePerfiles";
            lblTitulo.Text = "Gestión de Perfiles";
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.BackColor = Color.FromArgb(240, 238, 235);
            lblRol.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRol.ForeColor = Color.FromArgb(60, 60, 60);
            lblRol.Location = new Point(119, 260);
            lblRol.Margin = new Padding(0);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(72, 46);
            lblRol.TabIndex = 21;
            lblRol.Tag = "lbl_Rol";
            lblRol.Text = "Rol";
            // 
            // cmbRol
            // 
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.Font = new Font("Segoe UI", 10F);
            cmbRol.Location = new Point(109, 336);
            cmbRol.Margin = new Padding(0);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(249, 53);
            cmbRol.TabIndex = 22;
            // 
            // btnAsignarPermiso
            // 
            btnAsignarPermiso.BackColor = Color.White;
            btnAsignarPermiso.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnAsignarPermiso.FlatStyle = FlatStyle.Flat;
            btnAsignarPermiso.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAsignarPermiso.ForeColor = Color.FromArgb(120, 20, 40);
            btnAsignarPermiso.Location = new Point(2691, 101);
            btnAsignarPermiso.Margin = new Padding(0);
            btnAsignarPermiso.Name = "btnAsignarPermiso";
            btnAsignarPermiso.Size = new Size(335, 120);
            btnAsignarPermiso.TabIndex = 25;
            btnAsignarPermiso.Tag = "btn_AsignarPermiso";
            btnAsignarPermiso.Text = "Asignar Permiso";
            btnAsignarPermiso.UseVisualStyleBackColor = false;
            btnAsignarPermiso.Click += btnAsignarPermiso_Click_1;
            // 
            // btnAsignarFamilia
            // 
            btnAsignarFamilia.BackColor = Color.White;
            btnAsignarFamilia.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnAsignarFamilia.FlatStyle = FlatStyle.Flat;
            btnAsignarFamilia.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAsignarFamilia.ForeColor = Color.FromArgb(120, 20, 40);
            btnAsignarFamilia.Location = new Point(2249, 101);
            btnAsignarFamilia.Margin = new Padding(0);
            btnAsignarFamilia.Name = "btnAsignarFamilia";
            btnAsignarFamilia.Size = new Size(311, 120);
            btnAsignarFamilia.TabIndex = 26;
            btnAsignarFamilia.Tag = "btn_AsignarFamilia";
            btnAsignarFamilia.Text = "Asignar Familia";
            btnAsignarFamilia.UseVisualStyleBackColor = false;
            btnAsignarFamilia.Click += btnAsignarFamilia_Click;
            // 
            // btnCrear
            // 
            btnCrear.BackColor = Color.FromArgb(120, 20, 40);
            btnCrear.FlatAppearance.BorderSize = 0;
            btnCrear.FlatStyle = FlatStyle.Flat;
            btnCrear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCrear.ForeColor = Color.White;
            btnCrear.Location = new Point(1809, 101);
            btnCrear.Margin = new Padding(0);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(318, 118);
            btnCrear.TabIndex = 27;
            btnCrear.Tag = "btn_Crear";
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = false;
            btnCrear.Click += btnCrear_Click_1;
            // 
            // btnAplicar
            // 
            btnAplicar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAplicar.BackColor = Color.FromArgb(120, 20, 40);
            btnAplicar.FlatAppearance.BorderSize = 0;
            btnAplicar.FlatStyle = FlatStyle.Flat;
            btnAplicar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAplicar.ForeColor = Color.White;
            btnAplicar.Location = new Point(104, 1782);
            btnAplicar.Margin = new Padding(0);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(260, 118);
            btnAplicar.TabIndex = 28;
            btnAplicar.Tag = "btn_Aplicar";
            btnAplicar.Text = "Aplicar";
            btnAplicar.UseVisualStyleBackColor = false;
            btnAplicar.Click += btnAplicar_Click;
            // 
            // cmbFamiliaHija
            // 
            cmbFamiliaHija.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFamiliaHija.Font = new Font("Segoe UI", 10F);
            cmbFamiliaHija.Location = new Point(760, 336);
            cmbFamiliaHija.Margin = new Padding(0);
            cmbFamiliaHija.Name = "cmbFamiliaHija";
            cmbFamiliaHija.Size = new Size(249, 53);
            cmbFamiliaHija.TabIndex = 36;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.ForeColor = Color.FromArgb(120, 20, 40);
            button1.Location = new Point(2691, 276);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(335, 118);
            button1.TabIndex = 37;
            button1.Tag = "btn_Desasignar";
            button1.Text = "Desasignar ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(240, 238, 235);
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(60, 60, 60);
            label2.Location = new Point(760, 265);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(212, 46);
            label2.TabIndex = 39;
            label2.Tag = "lbl_FamiliaHija";
            label2.Text = "Familia-Hija";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.BackColor = Color.White;
            button2.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button2.ForeColor = Color.FromArgb(120, 20, 40);
            button2.Location = new Point(449, 1782);
            button2.Margin = new Padding(0);
            button2.Name = "button2";
            button2.Size = new Size(260, 118);
            button2.TabIndex = 40;
            button2.Tag = "btn_Cancelar";
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(240, 238, 235);
            panel1.Controls.Add(treeViewVistaPrevia);
            panel1.Controls.Add(cmbFamilia);
            panel1.Controls.Add(lblTitulo);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(clbFamilia);
            panel1.Controls.Add(clbPermiso);
            panel1.Controls.Add(btnModificar);
            panel1.Controls.Add(cmbFamiliaHija);
            panel1.Controls.Add(btnCrear);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(cmbRol);
            panel1.Controls.Add(lblRol);
            panel1.Controls.Add(btnSalir);
            panel1.Controls.Add(treeView1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnAsignarFamilia);
            panel1.Controls.Add(btnAsignarPermiso);
            panel1.Controls.Add(listBox1);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(btnEliminar);
            panel1.Controls.Add(btnAplicar);
            panel1.Location = new Point(53, 74);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(3478, 1930);
            panel1.TabIndex = 41;
            panel1.Paint += panel1_Paint;
            // 
            // treeViewVistaPrevia
            // 
            treeViewVistaPrevia.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            treeViewVistaPrevia.Location = new Point(2249, 538);
            treeViewVistaPrevia.Margin = new Padding(0);
            treeViewVistaPrevia.Name = "treeViewVistaPrevia";
            treeViewVistaPrevia.Size = new Size(1128, 862);
            treeViewVistaPrevia.TabIndex = 48;
            // 
            // cmbFamilia
            // 
            cmbFamilia.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFamilia.Font = new Font("Segoe UI", 10F);
            cmbFamilia.Location = new Point(449, 336);
            cmbFamilia.Margin = new Padding(0);
            cmbFamilia.Name = "cmbFamilia";
            cmbFamilia.Size = new Size(249, 53);
            cmbFamilia.TabIndex = 46;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(240, 238, 235);
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(60, 60, 60);
            label4.Location = new Point(449, 265);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(134, 46);
            label4.TabIndex = 47;
            label4.Tag = "lbl_Familia";
            label4.Text = "Familia";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(240, 238, 235);
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(60, 60, 60);
            label3.Location = new Point(629, 459);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(134, 46);
            label3.TabIndex = 45;
            label3.Tag = "lbl_Familia";
            label3.Text = "Familia";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(240, 238, 235);
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(60, 60, 60);
            label1.Location = new Point(104, 459);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(149, 46);
            label1.TabIndex = 44;
            label1.Tag = "lbl_Permiso";
            label1.Text = "Permiso";
            // 
            // clbFamilia
            // 
            clbFamilia.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            clbFamilia.FormattingEnabled = true;
            clbFamilia.Location = new Point(629, 538);
            clbFamilia.Margin = new Padding(0);
            clbFamilia.Name = "clbFamilia";
            clbFamilia.Size = new Size(380, 796);
            clbFamilia.TabIndex = 43;
            clbFamilia.SelectedIndexChanged += clbFamilia_SelectedIndexChanged;
            // 
            // clbPermiso
            // 
            clbPermiso.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            clbPermiso.FormattingEnabled = true;
            clbPermiso.Location = new Point(104, 538);
            clbPermiso.Margin = new Padding(0);
            clbPermiso.Name = "clbPermiso";
            clbPermiso.Size = new Size(337, 796);
            clbPermiso.TabIndex = 42;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSalir.BackColor = Color.White;
            btnSalir.FlatAppearance.BorderColor = Color.FromArgb(120, 20, 40);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalir.ForeColor = Color.FromArgb(120, 20, 40);
            btnSalir.Location = new Point(3150, 104);
            btnSalir.Margin = new Padding(0);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(260, 118);
            btnSalir.TabIndex = 23;
            btnSalir.Tag = "btn_Salir";
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // panelInferior
            // 
            panelInferior.BackColor = Color.FromArgb(120, 20, 40);
            panelInferior.Controls.Add(label5);
            panelInferior.Controls.Add(lblUsuarioActivo);
            panelInferior.Dock = DockStyle.Bottom;
            panelInferior.Location = new Point(0, 2004);
            panelInferior.Margin = new Padding(0);
            panelInferior.Name = "panelInferior";
            panelInferior.Size = new Size(3589, 104);
            panelInferior.TabIndex = 42;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(240, 38);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(407, 41);
            label5.TabIndex = 1;
            label5.Tag = "";
            label5.Text = "Maria Lopez-Administrador";
            // 
            // lblUsuarioActivo
            // 
            lblUsuarioActivo.AutoSize = true;
            lblUsuarioActivo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsuarioActivo.ForeColor = Color.White;
            lblUsuarioActivo.Location = new Point(19, 38);
            lblUsuarioActivo.Margin = new Padding(2, 0, 2, 0);
            lblUsuarioActivo.Name = "lblUsuarioActivo";
            lblUsuarioActivo.Size = new Size(227, 41);
            lblUsuarioActivo.TabIndex = 0;
            lblUsuarioActivo.Tag = "lbl_Usuario";
            lblUsuarioActivo.Text = "Usuario activo:";
            // 
            // FormGestionPerfil
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(3589, 2108);
            Controls.Add(panelInferior);
            Controls.Add(panel1);
            Margin = new Padding(0);
            MinimumSize = new Size(294, 88);
            Name = "FormGestionPerfil";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "lbl_FormPerfiles";
            Text = "TeatroLux - Gestión de Perfiles";
            FormClosed += FormGestionPerfil_FormClosed;
            Load += FormGestionPerfil_Load;
            Resize += FormGestionPerfil_Resize;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelInferior.ResumeLayout(false);
            panelInferior.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeView1;
        private GroupBox groupBox1;
        private RadioButton radioBtn_Familia;
        private RadioButton radioBtn_Rol;
        private ListBox listBox1;
        private Button btnModificar;
        private Button btnEliminar;
        private Label lblTitulo;
        private Label lblRol;
        private ComboBox cmbRol;
        private Button btnAsignarPermiso;
        private Button btnAsignarFamilia;
        private Button btnCrear;
        private Button btnAplicar;
        private ComboBox cmbFamiliaHija;
        private Button button1;
        private Label label2;
        private Button button2;
        private Panel panel1;
        private Button btnSalir;
        private CheckedListBox clbFamilia;
        private CheckedListBox clbPermiso;
        private Label label3;
        private Label label1;
        private ComboBox cmbFamilia;
        private Label label4;
        private TreeView treeViewVistaPrevia;
        private Panel panelInferior;
        private Label lblUsuarioActivo;
        private Label label5;
    }
}