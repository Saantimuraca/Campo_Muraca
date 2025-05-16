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
            this.LBLE_Nombre = new System.Windows.Forms.Label();
            this.ErrorNombre = new System.Windows.Forms.Label();
            this.ErrorCorreo = new System.Windows.Forms.Label();
            this.LBLE_Correo = new System.Windows.Forms.Label();
            this.TxtCorreo = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.LblCondicionIVA = new System.Windows.Forms.Label();
            this.ErrorIVA = new System.Windows.Forms.Label();
            this.DgvClientes = new System.Windows.Forms.DataGridView();
            this.RbActivos = new System.Windows.Forms.RadioButton();
            this.RbInactivos = new System.Windows.Forms.RadioButton();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnCambiarEstadoCliente = new System.Windows.Forms.Button();
            this.BtnModificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtNombre
            // 
            this.TxtNombre.BackColor = System.Drawing.Color.White;
            this.TxtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.Location = new System.Drawing.Point(14, 25);
            this.TxtNombre.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(172, 20);
            this.TxtNombre.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // LBLE_Nombre
            // 
            this.LBLE_Nombre.AutoSize = true;
            this.LBLE_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLE_Nombre.ForeColor = System.Drawing.Color.White;
            this.LBLE_Nombre.Location = new System.Drawing.Point(14, 9);
            this.LBLE_Nombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLE_Nombre.Name = "LBLE_Nombre";
            this.LBLE_Nombre.Size = new System.Drawing.Size(50, 13);
            this.LBLE_Nombre.TabIndex = 2;
            this.LBLE_Nombre.Text = "Nombre";
            // 
            // ErrorNombre
            // 
            this.ErrorNombre.AutoSize = true;
            this.ErrorNombre.ForeColor = System.Drawing.Color.Red;
            this.ErrorNombre.Location = new System.Drawing.Point(14, 48);
            this.ErrorNombre.Name = "ErrorNombre";
            this.ErrorNombre.Size = new System.Drawing.Size(108, 13);
            this.ErrorNombre.TabIndex = 3;
            this.ErrorNombre.Text = "Campo obligatorio";
            // 
            // ErrorCorreo
            // 
            this.ErrorCorreo.AutoSize = true;
            this.ErrorCorreo.ForeColor = System.Drawing.Color.Red;
            this.ErrorCorreo.Location = new System.Drawing.Point(217, 48);
            this.ErrorCorreo.Name = "ErrorCorreo";
            this.ErrorCorreo.Size = new System.Drawing.Size(92, 13);
            this.ErrorCorreo.TabIndex = 6;
            this.ErrorCorreo.Text = "Correo inválido";
            // 
            // LBLE_Correo
            // 
            this.LBLE_Correo.AutoSize = true;
            this.LBLE_Correo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLE_Correo.ForeColor = System.Drawing.Color.White;
            this.LBLE_Correo.Location = new System.Drawing.Point(217, 9);
            this.LBLE_Correo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLE_Correo.Name = "LBLE_Correo";
            this.LBLE_Correo.Size = new System.Drawing.Size(111, 13);
            this.LBLE_Correo.TabIndex = 5;
            this.LBLE_Correo.Text = "Correo electrónico";
            // 
            // TxtCorreo
            // 
            this.TxtCorreo.BackColor = System.Drawing.Color.White;
            this.TxtCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCorreo.Location = new System.Drawing.Point(217, 25);
            this.TxtCorreo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtCorreo.Name = "TxtCorreo";
            this.TxtCorreo.Size = new System.Drawing.Size(172, 20);
            this.TxtCorreo.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(411, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(187, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // LblCondicionIVA
            // 
            this.LblCondicionIVA.AutoSize = true;
            this.LblCondicionIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCondicionIVA.ForeColor = System.Drawing.Color.White;
            this.LblCondicionIVA.Location = new System.Drawing.Point(408, 8);
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
            this.ErrorIVA.Location = new System.Drawing.Point(408, 48);
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
            this.DgvClientes.Size = new System.Drawing.Size(586, 362);
            this.DgvClientes.TabIndex = 10;
            // 
            // RbActivos
            // 
            this.RbActivos.AutoSize = true;
            this.RbActivos.ForeColor = System.Drawing.Color.White;
            this.RbActivos.Location = new System.Drawing.Point(692, 28);
            this.RbActivos.Name = "RbActivos";
            this.RbActivos.Size = new System.Drawing.Size(67, 17);
            this.RbActivos.TabIndex = 11;
            this.RbActivos.TabStop = true;
            this.RbActivos.Text = "Activos";
            this.RbActivos.UseVisualStyleBackColor = true;
            // 
            // RbInactivos
            // 
            this.RbInactivos.AutoSize = true;
            this.RbInactivos.ForeColor = System.Drawing.Color.White;
            this.RbInactivos.Location = new System.Drawing.Point(765, 28);
            this.RbInactivos.Name = "RbInactivos";
            this.RbInactivos.Size = new System.Drawing.Size(77, 17);
            this.RbInactivos.TabIndex = 12;
            this.RbInactivos.TabStop = true;
            this.RbInactivos.Text = "Inactivos";
            this.RbInactivos.UseVisualStyleBackColor = true;
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(604, 76);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(90, 23);
            this.BtnAgregar.TabIndex = 13;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            // 
            // BtnCambiarEstadoCliente
            // 
            this.BtnCambiarEstadoCliente.Location = new System.Drawing.Point(604, 232);
            this.BtnCambiarEstadoCliente.Name = "BtnCambiarEstadoCliente";
            this.BtnCambiarEstadoCliente.Size = new System.Drawing.Size(90, 27);
            this.BtnCambiarEstadoCliente.TabIndex = 14;
            this.BtnCambiarEstadoCliente.Text = "Deshabilitar";
            this.BtnCambiarEstadoCliente.UseVisualStyleBackColor = true;
            // 
            // BtnModificar
            // 
            this.BtnModificar.Location = new System.Drawing.Point(604, 415);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(90, 23);
            this.BtnModificar.TabIndex = 15;
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = true;
            // 
            // GUIRegistrarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(933, 450);
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
            this.Controls.Add(this.LBLE_Nombre);
            this.Controls.Add(this.TxtNombre);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "GUIRegistrarCliente";
            this.Text = "GUIRegistrarCliente";
            ((System.ComponentModel.ISupportInitialize)(this.DgvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label LBLE_Nombre;
        private System.Windows.Forms.Label ErrorNombre;
        private System.Windows.Forms.Label ErrorCorreo;
        private System.Windows.Forms.Label LBLE_Correo;
        private System.Windows.Forms.TextBox TxtCorreo;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label LblCondicionIVA;
        private System.Windows.Forms.Label ErrorIVA;
        private System.Windows.Forms.DataGridView DgvClientes;
        private System.Windows.Forms.RadioButton RbActivos;
        private System.Windows.Forms.RadioButton RbInactivos;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Button BtnCambiarEstadoCliente;
        private System.Windows.Forms.Button BtnModificar;
    }
}