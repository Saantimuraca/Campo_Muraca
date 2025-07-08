namespace GUI
{
    partial class GUIRegistrarCliente
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
            this.components = new System.ComponentModel.Container();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.labelNombre = new System.Windows.Forms.Label();
            this.ErrorNombre = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.LblCondicionIVA = new System.Windows.Forms.Label();
            this.ErrorIVA = new System.Windows.Forms.Label();
            this.DgvClientes = new System.Windows.Forms.DataGridView();
            this.RbActivos = new System.Windows.Forms.RadioButton();
            this.RbInactivos = new System.Windows.Forms.RadioButton();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnCambiarEstadoCliente = new System.Windows.Forms.Button();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TxtCorreo = new System.Windows.Forms.TextBox();
            this.LBLE_Correo = new System.Windows.Forms.Label();
            this.ErrorCorreo = new System.Windows.Forms.Label();
            this.ErrorTelefono = new System.Windows.Forms.Label();
            this.LBLE_Telefono = new System.Windows.Forms.Label();
            this.TxtTelefono = new System.Windows.Forms.TextBox();
            this.ErrorDNI = new System.Windows.Forms.Label();
            this.LBLE_DNI = new System.Windows.Forms.Label();
            this.TxtDNI = new System.Windows.Forms.TextBox();
            this.BtnEliminarSeleccion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtNombre
            // 
            this.TxtNombre.BackColor = System.Drawing.Color.White;
            this.TxtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.Location = new System.Drawing.Point(205, 29);
            this.TxtNombre.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(172, 20);
            this.TxtNombre.TabIndex = 10;
            this.TxtNombre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtNombre_KeyUp);
            this.TxtNombre.Leave += new System.EventHandler(this.TxtNombre_Leave);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre.ForeColor = System.Drawing.Color.White;
            this.labelNombre.Location = new System.Drawing.Point(205, 13);
            this.labelNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(105, 13);
            this.labelNombre.TabIndex = 2;
            this.labelNombre.Text = "Nombre completo";
            // 
            // ErrorNombre
            // 
            this.ErrorNombre.AutoSize = true;
            this.ErrorNombre.ForeColor = System.Drawing.Color.Red;
            this.ErrorNombre.Location = new System.Drawing.Point(205, 52);
            this.ErrorNombre.Name = "ErrorNombre";
            this.ErrorNombre.Size = new System.Drawing.Size(108, 13);
            this.ErrorNombre.TabIndex = 3;
            this.ErrorNombre.Text = "Campo obligatorio";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(844, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(187, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.Leave += new System.EventHandler(this.comboBox1_Leave);
            // 
            // LblCondicionIVA
            // 
            this.LblCondicionIVA.AutoSize = true;
            this.LblCondicionIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCondicionIVA.ForeColor = System.Drawing.Color.White;
            this.LblCondicionIVA.Location = new System.Drawing.Point(841, 12);
            this.LblCondicionIVA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblCondicionIVA.Name = "LblCondicionIVA";
            this.LblCondicionIVA.Size = new System.Drawing.Size(105, 13);
            this.LblCondicionIVA.TabIndex = 8;
            this.LblCondicionIVA.Text = "Condición de IVA";
            // 
            // ErrorIVA
            // 
            this.ErrorIVA.AutoSize = true;
            this.ErrorIVA.ForeColor = System.Drawing.Color.Red;
            this.ErrorIVA.Location = new System.Drawing.Point(841, 52);
            this.ErrorIVA.Name = "ErrorIVA";
            this.ErrorIVA.Size = new System.Drawing.Size(190, 13);
            this.ErrorIVA.TabIndex = 9;
            this.ErrorIVA.Text = "Debe seleccionar una condición";
            // 
            // DgvClientes
            // 
            this.DgvClientes.AllowUserToAddRows = false;
            this.DgvClientes.AllowUserToDeleteRows = false;
            this.DgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvClientes.Location = new System.Drawing.Point(12, 76);
            this.DgvClientes.Name = "DgvClientes";
            this.DgvClientes.ReadOnly = true;
            this.DgvClientes.Size = new System.Drawing.Size(1019, 362);
            this.DgvClientes.TabIndex = 0;
            this.DgvClientes.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvClientes_CellMouseClick);
            // 
            // RbActivos
            // 
            this.RbActivos.AutoSize = true;
            this.RbActivos.ForeColor = System.Drawing.Color.White;
            this.RbActivos.Location = new System.Drawing.Point(1126, 28);
            this.RbActivos.Name = "RbActivos";
            this.RbActivos.Size = new System.Drawing.Size(67, 17);
            this.RbActivos.TabIndex = 11;
            this.RbActivos.TabStop = true;
            this.RbActivos.Text = "Activos";
            this.RbActivos.UseVisualStyleBackColor = true;
            this.RbActivos.CheckedChanged += new System.EventHandler(this.RbActivos_CheckedChanged);
            // 
            // RbInactivos
            // 
            this.RbInactivos.AutoSize = true;
            this.RbInactivos.ForeColor = System.Drawing.Color.White;
            this.RbInactivos.Location = new System.Drawing.Point(1199, 28);
            this.RbInactivos.Name = "RbInactivos";
            this.RbInactivos.Size = new System.Drawing.Size(77, 17);
            this.RbInactivos.TabIndex = 12;
            this.RbInactivos.TabStop = true;
            this.RbInactivos.Text = "Inactivos";
            this.RbInactivos.UseVisualStyleBackColor = true;
            this.RbInactivos.CheckedChanged += new System.EventHandler(this.RbInactivos_CheckedChanged);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnAgregar.Location = new System.Drawing.Point(1037, 76);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(90, 30);
            this.BtnAgregar.TabIndex = 13;
            this.BtnAgregar.Tag = "Agregar Cliente";
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = false;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnCambiarEstadoCliente
            // 
            this.BtnCambiarEstadoCliente.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnCambiarEstadoCliente.Location = new System.Drawing.Point(1037, 228);
            this.BtnCambiarEstadoCliente.Name = "BtnCambiarEstadoCliente";
            this.BtnCambiarEstadoCliente.Size = new System.Drawing.Size(90, 30);
            this.BtnCambiarEstadoCliente.TabIndex = 14;
            this.BtnCambiarEstadoCliente.Tag = "Deshabilitar Cliente";
            this.BtnCambiarEstadoCliente.Text = "Deshabilitar";
            this.BtnCambiarEstadoCliente.UseVisualStyleBackColor = false;
            this.BtnCambiarEstadoCliente.Click += new System.EventHandler(this.BtnCambiarEstadoCliente_Click);
            // 
            // BtnModificar
            // 
            this.BtnModificar.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnModificar.Location = new System.Drawing.Point(1037, 411);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(90, 27);
            this.BtnModificar.TabIndex = 15;
            this.BtnModificar.Tag = "Modificar Cliente";
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = false;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // TxtCorreo
            // 
            this.TxtCorreo.BackColor = System.Drawing.Color.White;
            this.TxtCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCorreo.Location = new System.Drawing.Point(408, 29);
            this.TxtCorreo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtCorreo.Name = "TxtCorreo";
            this.TxtCorreo.Size = new System.Drawing.Size(172, 20);
            this.TxtCorreo.TabIndex = 4;
            this.TxtCorreo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtCorreo_KeyUp);
            this.TxtCorreo.Leave += new System.EventHandler(this.TxtCorreo_Leave);
            // 
            // LBLE_Correo
            // 
            this.LBLE_Correo.AutoSize = true;
            this.LBLE_Correo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLE_Correo.ForeColor = System.Drawing.Color.White;
            this.LBLE_Correo.Location = new System.Drawing.Point(408, 13);
            this.LBLE_Correo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLE_Correo.Name = "LBLE_Correo";
            this.LBLE_Correo.Size = new System.Drawing.Size(111, 13);
            this.LBLE_Correo.TabIndex = 5;
            this.LBLE_Correo.Text = "Correo electrónico";
            // 
            // ErrorCorreo
            // 
            this.ErrorCorreo.AutoSize = true;
            this.ErrorCorreo.ForeColor = System.Drawing.Color.Red;
            this.ErrorCorreo.Location = new System.Drawing.Point(408, 52);
            this.ErrorCorreo.Name = "ErrorCorreo";
            this.ErrorCorreo.Size = new System.Drawing.Size(92, 13);
            this.ErrorCorreo.TabIndex = 6;
            this.ErrorCorreo.Text = "Correo inválido";
            // 
            // ErrorTelefono
            // 
            this.ErrorTelefono.AutoSize = true;
            this.ErrorTelefono.ForeColor = System.Drawing.Color.Red;
            this.ErrorTelefono.Location = new System.Drawing.Point(625, 51);
            this.ErrorTelefono.Name = "ErrorTelefono";
            this.ErrorTelefono.Size = new System.Drawing.Size(105, 13);
            this.ErrorTelefono.TabIndex = 19;
            this.ErrorTelefono.Text = "Teléfono inválido";
            // 
            // LBLE_Telefono
            // 
            this.LBLE_Telefono.AutoSize = true;
            this.LBLE_Telefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLE_Telefono.ForeColor = System.Drawing.Color.White;
            this.LBLE_Telefono.Location = new System.Drawing.Point(625, 13);
            this.LBLE_Telefono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLE_Telefono.Name = "LBLE_Telefono";
            this.LBLE_Telefono.Size = new System.Drawing.Size(57, 13);
            this.LBLE_Telefono.TabIndex = 18;
            this.LBLE_Telefono.Text = "Teléfono";
            // 
            // TxtTelefono
            // 
            this.TxtTelefono.BackColor = System.Drawing.Color.White;
            this.TxtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTelefono.Location = new System.Drawing.Point(628, 28);
            this.TxtTelefono.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtTelefono.Name = "TxtTelefono";
            this.TxtTelefono.Size = new System.Drawing.Size(172, 20);
            this.TxtTelefono.TabIndex = 17;
            this.TxtTelefono.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtTelefono_KeyUp);
            this.TxtTelefono.Leave += new System.EventHandler(this.TxtTelefono_Leave);
            // 
            // ErrorDNI
            // 
            this.ErrorDNI.AutoSize = true;
            this.ErrorDNI.ForeColor = System.Drawing.Color.Red;
            this.ErrorDNI.Location = new System.Drawing.Point(13, 50);
            this.ErrorDNI.Name = "ErrorDNI";
            this.ErrorDNI.Size = new System.Drawing.Size(77, 13);
            this.ErrorDNI.TabIndex = 22;
            this.ErrorDNI.Text = "DNI inválido";
            // 
            // LBLE_DNI
            // 
            this.LBLE_DNI.AutoSize = true;
            this.LBLE_DNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLE_DNI.ForeColor = System.Drawing.Color.White;
            this.LBLE_DNI.Location = new System.Drawing.Point(13, 11);
            this.LBLE_DNI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLE_DNI.Name = "LBLE_DNI";
            this.LBLE_DNI.Size = new System.Drawing.Size(29, 13);
            this.LBLE_DNI.TabIndex = 21;
            this.LBLE_DNI.Text = "DNI";
            // 
            // TxtDNI
            // 
            this.TxtDNI.BackColor = System.Drawing.Color.White;
            this.TxtDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDNI.Location = new System.Drawing.Point(13, 27);
            this.TxtDNI.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtDNI.Name = "TxtDNI";
            this.TxtDNI.Size = new System.Drawing.Size(172, 20);
            this.TxtDNI.TabIndex = 20;
            this.TxtDNI.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtDNI_KeyUp);
            this.TxtDNI.Leave += new System.EventHandler(this.TxtDNI_Leave);
            // 
            // BtnEliminarSeleccion
            // 
            this.BtnEliminarSeleccion.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnEliminarSeleccion.Location = new System.Drawing.Point(428, 444);
            this.BtnEliminarSeleccion.Name = "BtnEliminarSeleccion";
            this.BtnEliminarSeleccion.Size = new System.Drawing.Size(121, 36);
            this.BtnEliminarSeleccion.TabIndex = 23;
            this.BtnEliminarSeleccion.Text = "Eliminar seleccion";
            this.BtnEliminarSeleccion.UseVisualStyleBackColor = false;
            this.BtnEliminarSeleccion.Click += new System.EventHandler(this.BtnEliminarSeleccion_Click);
            // 
            // GUIRegistrarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1279, 487);
            this.Controls.Add(this.BtnEliminarSeleccion);
            this.Controls.Add(this.ErrorDNI);
            this.Controls.Add(this.LBLE_DNI);
            this.Controls.Add(this.TxtDNI);
            this.Controls.Add(this.ErrorTelefono);
            this.Controls.Add(this.LBLE_Telefono);
            this.Controls.Add(this.TxtTelefono);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.BtnCambiarEstadoCliente);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.RbInactivos);
            this.Controls.Add(this.RbActivos);
            this.Controls.Add(this.DgvClientes);
            this.Controls.Add(this.ErrorIVA);
            this.Controls.Add(this.LblCondicionIVA);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.ErrorCorreo);
            this.Controls.Add(this.LBLE_Correo);
            this.Controls.Add(this.TxtCorreo);
            this.Controls.Add(this.ErrorNombre);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.TxtNombre);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "GUIRegistrarCliente";
            this.Text = "GUIRegistrarCliente";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GUIRegistrarCliente_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.DgvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label ErrorNombre;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label LblCondicionIVA;
        private System.Windows.Forms.Label ErrorIVA;
        private System.Windows.Forms.DataGridView DgvClientes;
        private System.Windows.Forms.RadioButton RbActivos;
        private System.Windows.Forms.RadioButton RbInactivos;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Button BtnCambiarEstadoCliente;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.TextBox TxtCorreo;
        private System.Windows.Forms.Label LBLE_Correo;
        private System.Windows.Forms.Label ErrorCorreo;
        private System.Windows.Forms.Label ErrorTelefono;
        private System.Windows.Forms.Label LBLE_Telefono;
        private System.Windows.Forms.TextBox TxtTelefono;
        private System.Windows.Forms.Label ErrorDNI;
        private System.Windows.Forms.Label LBLE_DNI;
        private System.Windows.Forms.TextBox TxtDNI;
        private System.Windows.Forms.Button BtnEliminarSeleccion;
    }
}