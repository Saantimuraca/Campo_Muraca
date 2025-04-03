namespace GUI
{
    partial class ABM_Usuarios
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
            this.BtnAgregarUsuario = new System.Windows.Forms.Button();
            this.BtnBajaUsuario = new System.Windows.Forms.Button();
            this.BtnModificarUsuario = new System.Windows.Forms.Button();
            this.DgvUsuarios = new System.Windows.Forms.DataGridView();
            this.TxtNombreUsuario = new System.Windows.Forms.TextBox();
            this.LBLE_Nombre = new System.Windows.Forms.Label();
            this.BtnHabilitarUsuario = new System.Windows.Forms.Button();
            this.TxtMail = new System.Windows.Forms.TextBox();
            this.LBLE_Correo = new System.Windows.Forms.Label();
            this.TxtFechaNacimiento = new System.Windows.Forms.TextBox();
            this.LBLE_Nacimiento = new System.Windows.Forms.Label();
            this.LBLE_Telefono = new System.Windows.Forms.Label();
            this.TxtTelefonoUsuario = new System.Windows.Forms.TextBox();
            this.TxtDNIUsuario = new System.Windows.Forms.TextBox();
            this.LBLE_DNI = new System.Windows.Forms.Label();
            this.CbRol = new System.Windows.Forms.ComboBox();
            this.LBLE_Rol = new System.Windows.Forms.Label();
            this.LBLE_Idioma = new System.Windows.Forms.Label();
            this.CbIdioma = new System.Windows.Forms.ComboBox();
            this.BtnEliminarSeleccion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnAgregarUsuario
            // 
            this.BtnAgregarUsuario.BackColor = System.Drawing.Color.OliveDrab;
            this.BtnAgregarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregarUsuario.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregarUsuario.Location = new System.Drawing.Point(12, 44);
            this.BtnAgregarUsuario.Name = "BtnAgregarUsuario";
            this.BtnAgregarUsuario.Size = new System.Drawing.Size(96, 28);
            this.BtnAgregarUsuario.TabIndex = 0;
            this.BtnAgregarUsuario.Text = "NUEVO";
            this.BtnAgregarUsuario.UseVisualStyleBackColor = false;
            this.BtnAgregarUsuario.Click += new System.EventHandler(this.BtnAgregarUsuario_Click);
            // 
            // BtnBajaUsuario
            // 
            this.BtnBajaUsuario.BackColor = System.Drawing.Color.IndianRed;
            this.BtnBajaUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBajaUsuario.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBajaUsuario.Location = new System.Drawing.Point(382, 44);
            this.BtnBajaUsuario.Name = "BtnBajaUsuario";
            this.BtnBajaUsuario.Size = new System.Drawing.Size(96, 30);
            this.BtnBajaUsuario.TabIndex = 1;
            this.BtnBajaUsuario.Text = "DESHABILITAR";
            this.BtnBajaUsuario.UseVisualStyleBackColor = false;
            this.BtnBajaUsuario.Click += new System.EventHandler(this.BtnBajaUsuario_Click);
            // 
            // BtnModificarUsuario
            // 
            this.BtnModificarUsuario.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnModificarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnModificarUsuario.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificarUsuario.Location = new System.Drawing.Point(577, 44);
            this.BtnModificarUsuario.Name = "BtnModificarUsuario";
            this.BtnModificarUsuario.Size = new System.Drawing.Size(96, 30);
            this.BtnModificarUsuario.TabIndex = 2;
            this.BtnModificarUsuario.Text = "MODIFICAR";
            this.BtnModificarUsuario.UseVisualStyleBackColor = false;
            this.BtnModificarUsuario.Click += new System.EventHandler(this.BtnModificarUsuario_Click);
            // 
            // DgvUsuarios
            // 
            this.DgvUsuarios.AllowUserToAddRows = false;
            this.DgvUsuarios.AllowUserToDeleteRows = false;
            this.DgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvUsuarios.Location = new System.Drawing.Point(12, 78);
            this.DgvUsuarios.Name = "DgvUsuarios";
            this.DgvUsuarios.ReadOnly = true;
            this.DgvUsuarios.Size = new System.Drawing.Size(661, 333);
            this.DgvUsuarios.TabIndex = 3;
            this.DgvUsuarios.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvUsuarios_RowHeaderMouseClick);
            // 
            // TxtNombreUsuario
            // 
            this.TxtNombreUsuario.Location = new System.Drawing.Point(679, 155);
            this.TxtNombreUsuario.Name = "TxtNombreUsuario";
            this.TxtNombreUsuario.Size = new System.Drawing.Size(281, 20);
            this.TxtNombreUsuario.TabIndex = 4;
            // 
            // LBLE_Nombre
            // 
            this.LBLE_Nombre.AutoSize = true;
            this.LBLE_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLE_Nombre.Location = new System.Drawing.Point(676, 139);
            this.LBLE_Nombre.Name = "LBLE_Nombre";
            this.LBLE_Nombre.Size = new System.Drawing.Size(113, 13);
            this.LBLE_Nombre.TabIndex = 5;
            this.LBLE_Nombre.Text = "Nombre de usuario";
            // 
            // BtnHabilitarUsuario
            // 
            this.BtnHabilitarUsuario.BackColor = System.Drawing.Color.Yellow;
            this.BtnHabilitarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnHabilitarUsuario.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHabilitarUsuario.Location = new System.Drawing.Point(195, 44);
            this.BtnHabilitarUsuario.Name = "BtnHabilitarUsuario";
            this.BtnHabilitarUsuario.Size = new System.Drawing.Size(96, 30);
            this.BtnHabilitarUsuario.TabIndex = 6;
            this.BtnHabilitarUsuario.Text = "HABILITAR";
            this.BtnHabilitarUsuario.UseVisualStyleBackColor = false;
            this.BtnHabilitarUsuario.Click += new System.EventHandler(this.BtnHabilitarUsuario_Click);
            // 
            // TxtMail
            // 
            this.TxtMail.Location = new System.Drawing.Point(679, 199);
            this.TxtMail.Name = "TxtMail";
            this.TxtMail.Size = new System.Drawing.Size(281, 20);
            this.TxtMail.TabIndex = 7;
            // 
            // LBLE_Correo
            // 
            this.LBLE_Correo.AutoSize = true;
            this.LBLE_Correo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLE_Correo.Location = new System.Drawing.Point(676, 183);
            this.LBLE_Correo.Name = "LBLE_Correo";
            this.LBLE_Correo.Size = new System.Drawing.Size(111, 13);
            this.LBLE_Correo.TabIndex = 8;
            this.LBLE_Correo.Text = "Correo electrónico";
            // 
            // TxtFechaNacimiento
            // 
            this.TxtFechaNacimiento.Location = new System.Drawing.Point(679, 245);
            this.TxtFechaNacimiento.Name = "TxtFechaNacimiento";
            this.TxtFechaNacimiento.Size = new System.Drawing.Size(281, 20);
            this.TxtFechaNacimiento.TabIndex = 11;
            // 
            // LBLE_Nacimiento
            // 
            this.LBLE_Nacimiento.AutoSize = true;
            this.LBLE_Nacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLE_Nacimiento.Location = new System.Drawing.Point(676, 230);
            this.LBLE_Nacimiento.Name = "LBLE_Nacimiento";
            this.LBLE_Nacimiento.Size = new System.Drawing.Size(125, 13);
            this.LBLE_Nacimiento.TabIndex = 12;
            this.LBLE_Nacimiento.Text = "Fecha de nacimiento";
            // 
            // LBLE_Telefono
            // 
            this.LBLE_Telefono.AutoSize = true;
            this.LBLE_Telefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLE_Telefono.Location = new System.Drawing.Point(676, 267);
            this.LBLE_Telefono.Name = "LBLE_Telefono";
            this.LBLE_Telefono.Size = new System.Drawing.Size(57, 13);
            this.LBLE_Telefono.TabIndex = 14;
            this.LBLE_Telefono.Text = "Teléfono";
            // 
            // TxtTelefonoUsuario
            // 
            this.TxtTelefonoUsuario.Location = new System.Drawing.Point(679, 282);
            this.TxtTelefonoUsuario.Name = "TxtTelefonoUsuario";
            this.TxtTelefonoUsuario.Size = new System.Drawing.Size(281, 20);
            this.TxtTelefonoUsuario.TabIndex = 13;
            // 
            // TxtDNIUsuario
            // 
            this.TxtDNIUsuario.Location = new System.Drawing.Point(679, 114);
            this.TxtDNIUsuario.Name = "TxtDNIUsuario";
            this.TxtDNIUsuario.Size = new System.Drawing.Size(281, 20);
            this.TxtDNIUsuario.TabIndex = 15;
            // 
            // LBLE_DNI
            // 
            this.LBLE_DNI.AutoSize = true;
            this.LBLE_DNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLE_DNI.Location = new System.Drawing.Point(676, 98);
            this.LBLE_DNI.Name = "LBLE_DNI";
            this.LBLE_DNI.Size = new System.Drawing.Size(29, 13);
            this.LBLE_DNI.TabIndex = 16;
            this.LBLE_DNI.Text = "DNI";
            // 
            // CbRol
            // 
            this.CbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbRol.FormattingEnabled = true;
            this.CbRol.Location = new System.Drawing.Point(679, 322);
            this.CbRol.Name = "CbRol";
            this.CbRol.Size = new System.Drawing.Size(281, 21);
            this.CbRol.TabIndex = 17;
            // 
            // LBLE_Rol
            // 
            this.LBLE_Rol.AutoSize = true;
            this.LBLE_Rol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLE_Rol.Location = new System.Drawing.Point(679, 306);
            this.LBLE_Rol.Name = "LBLE_Rol";
            this.LBLE_Rol.Size = new System.Drawing.Size(26, 13);
            this.LBLE_Rol.TabIndex = 18;
            this.LBLE_Rol.Text = "Rol";
            // 
            // LBLE_Idioma
            // 
            this.LBLE_Idioma.AutoSize = true;
            this.LBLE_Idioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLE_Idioma.Location = new System.Drawing.Point(679, 346);
            this.LBLE_Idioma.Name = "LBLE_Idioma";
            this.LBLE_Idioma.Size = new System.Drawing.Size(44, 13);
            this.LBLE_Idioma.TabIndex = 19;
            this.LBLE_Idioma.Text = "Idioma";
            // 
            // CbIdioma
            // 
            this.CbIdioma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbIdioma.FormattingEnabled = true;
            this.CbIdioma.Location = new System.Drawing.Point(679, 362);
            this.CbIdioma.Name = "CbIdioma";
            this.CbIdioma.Size = new System.Drawing.Size(281, 21);
            this.CbIdioma.TabIndex = 20;
            // 
            // BtnEliminarSeleccion
            // 
            this.BtnEliminarSeleccion.BackColor = System.Drawing.Color.Orange;
            this.BtnEliminarSeleccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminarSeleccion.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminarSeleccion.Location = new System.Drawing.Point(301, 417);
            this.BtnEliminarSeleccion.Name = "BtnEliminarSeleccion";
            this.BtnEliminarSeleccion.Size = new System.Drawing.Size(77, 36);
            this.BtnEliminarSeleccion.TabIndex = 21;
            this.BtnEliminarSeleccion.Text = "ELIMINAR SELECCIÓN";
            this.BtnEliminarSeleccion.UseVisualStyleBackColor = false;
            this.BtnEliminarSeleccion.Click += new System.EventHandler(this.BtnEliminarSeleccion_Click);
            // 
            // ABM_Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1089, 474);
            this.Controls.Add(this.BtnEliminarSeleccion);
            this.Controls.Add(this.CbIdioma);
            this.Controls.Add(this.LBLE_Idioma);
            this.Controls.Add(this.LBLE_Rol);
            this.Controls.Add(this.CbRol);
            this.Controls.Add(this.LBLE_DNI);
            this.Controls.Add(this.TxtDNIUsuario);
            this.Controls.Add(this.LBLE_Telefono);
            this.Controls.Add(this.TxtTelefonoUsuario);
            this.Controls.Add(this.LBLE_Nacimiento);
            this.Controls.Add(this.TxtFechaNacimiento);
            this.Controls.Add(this.LBLE_Correo);
            this.Controls.Add(this.TxtMail);
            this.Controls.Add(this.BtnHabilitarUsuario);
            this.Controls.Add(this.LBLE_Nombre);
            this.Controls.Add(this.TxtNombreUsuario);
            this.Controls.Add(this.DgvUsuarios);
            this.Controls.Add(this.BtnModificarUsuario);
            this.Controls.Add(this.BtnBajaUsuario);
            this.Controls.Add(this.BtnAgregarUsuario);
            this.Name = "ABM_Usuarios";
            this.Text = "ABM_Usuarios";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ABM_Usuarios_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.DgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnAgregarUsuario;
        private System.Windows.Forms.Button BtnBajaUsuario;
        private System.Windows.Forms.Button BtnModificarUsuario;
        private System.Windows.Forms.DataGridView DgvUsuarios;
        private System.Windows.Forms.TextBox TxtNombreUsuario;
        private System.Windows.Forms.Label LBLE_Nombre;
        private System.Windows.Forms.Button BtnHabilitarUsuario;
        private System.Windows.Forms.TextBox TxtMail;
        private System.Windows.Forms.Label LBLE_Correo;
        private System.Windows.Forms.TextBox TxtFechaNacimiento;
        private System.Windows.Forms.Label LBLE_Nacimiento;
        private System.Windows.Forms.Label LBLE_Telefono;
        private System.Windows.Forms.TextBox TxtTelefonoUsuario;
        private System.Windows.Forms.TextBox TxtDNIUsuario;
        private System.Windows.Forms.Label LBLE_DNI;
        private System.Windows.Forms.ComboBox CbRol;
        private System.Windows.Forms.Label LBLE_Rol;
        private System.Windows.Forms.Label LBLE_Idioma;
        private System.Windows.Forms.ComboBox CbIdioma;
        private System.Windows.Forms.Button BtnEliminarSeleccion;
    }
}