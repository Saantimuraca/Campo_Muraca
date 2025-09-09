namespace GUI
{
    partial class GUICaja
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
            this.Dgv = new System.Windows.Forms.DataGridView();
            this.LblMovimientos = new System.Windows.Forms.Label();
            this.LblDescripcion = new System.Windows.Forms.Label();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.ErrorNombre = new System.Windows.Forms.Label();
            this.ErrorImporte = new System.Windows.Forms.Label();
            this.TxtImporte = new System.Windows.Forms.TextBox();
            this.LblImporte = new System.Windows.Forms.Label();
            this.LBLMetodoPago = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ErrorRol = new System.Windows.Forms.Label();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnModificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Dgv
            // 
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Location = new System.Drawing.Point(12, 26);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            this.Dgv.Size = new System.Drawing.Size(456, 369);
            this.Dgv.TabIndex = 0;
            // 
            // LblMovimientos
            // 
            this.LblMovimientos.AutoSize = true;
            this.LblMovimientos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMovimientos.ForeColor = System.Drawing.Color.White;
            this.LblMovimientos.Location = new System.Drawing.Point(202, 10);
            this.LblMovimientos.Name = "LblMovimientos";
            this.LblMovimientos.Size = new System.Drawing.Size(77, 13);
            this.LblMovimientos.TabIndex = 1;
            this.LblMovimientos.Text = "Movimientos";
            // 
            // LblDescripcion
            // 
            this.LblDescripcion.AutoSize = true;
            this.LblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDescripcion.ForeColor = System.Drawing.Color.White;
            this.LblDescripcion.Location = new System.Drawing.Point(471, 37);
            this.LblDescripcion.Name = "LblDescripcion";
            this.LblDescripcion.Size = new System.Drawing.Size(74, 13);
            this.LblDescripcion.TabIndex = 2;
            this.LblDescripcion.Text = "Descripción";
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Location = new System.Drawing.Point(474, 53);
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(172, 20);
            this.TxtDescripcion.TabIndex = 3;
            // 
            // ErrorNombre
            // 
            this.ErrorNombre.AutoSize = true;
            this.ErrorNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorNombre.ForeColor = System.Drawing.Color.Red;
            this.ErrorNombre.Location = new System.Drawing.Point(471, 76);
            this.ErrorNombre.Name = "ErrorNombre";
            this.ErrorNombre.Size = new System.Drawing.Size(110, 13);
            this.ErrorNombre.TabIndex = 6;
            this.ErrorNombre.Text = "Campo Obligatorio";
            // 
            // ErrorImporte
            // 
            this.ErrorImporte.AutoSize = true;
            this.ErrorImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorImporte.ForeColor = System.Drawing.Color.Red;
            this.ErrorImporte.Location = new System.Drawing.Point(471, 137);
            this.ErrorImporte.Name = "ErrorImporte";
            this.ErrorImporte.Size = new System.Drawing.Size(97, 13);
            this.ErrorImporte.TabIndex = 9;
            this.ErrorImporte.Text = "Importe inválido";
            // 
            // TxtImporte
            // 
            this.TxtImporte.Location = new System.Drawing.Point(474, 114);
            this.TxtImporte.Name = "TxtImporte";
            this.TxtImporte.Size = new System.Drawing.Size(172, 20);
            this.TxtImporte.TabIndex = 8;
            // 
            // LblImporte
            // 
            this.LblImporte.AutoSize = true;
            this.LblImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblImporte.ForeColor = System.Drawing.Color.White;
            this.LblImporte.Location = new System.Drawing.Point(471, 98);
            this.LblImporte.Name = "LblImporte";
            this.LblImporte.Size = new System.Drawing.Size(78, 13);
            this.LblImporte.TabIndex = 7;
            this.LblImporte.Text = "Importe total";
            // 
            // LBLMetodoPago
            // 
            this.LBLMetodoPago.AutoSize = true;
            this.LBLMetodoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLMetodoPago.ForeColor = System.Drawing.Color.White;
            this.LBLMetodoPago.Location = new System.Drawing.Point(471, 157);
            this.LBLMetodoPago.Name = "LBLMetodoPago";
            this.LBLMetodoPago.Size = new System.Drawing.Size(99, 13);
            this.LBLMetodoPago.TabIndex = 11;
            this.LBLMetodoPago.Text = "Método de pago";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Tarjeta de crédito",
            "Tarjeta de débito",
            "Efectivo",
            "Transferencia",
            "Mercado Pago",
            "Otro"});
            this.comboBox1.Location = new System.Drawing.Point(474, 173);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // ErrorRol
            // 
            this.ErrorRol.AutoSize = true;
            this.ErrorRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorRol.ForeColor = System.Drawing.Color.Red;
            this.ErrorRol.Location = new System.Drawing.Point(474, 197);
            this.ErrorRol.Name = "ErrorRol";
            this.ErrorRol.Size = new System.Drawing.Size(126, 13);
            this.ErrorRol.TabIndex = 28;
            this.ErrorRol.Text = "Seleccion obligatoria";
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.Location = new System.Drawing.Point(138, 401);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(90, 30);
            this.BtnAgregar.TabIndex = 29;
            this.BtnAgregar.Tag = "";
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = false;
            // 
            // BtnModificar
            // 
            this.BtnModificar.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificar.Location = new System.Drawing.Point(251, 401);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(90, 30);
            this.BtnModificar.TabIndex = 30;
            this.BtnModificar.Tag = "";
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = false;
            // 
            // GUICaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(680, 450);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.ErrorRol);
            this.Controls.Add(this.LBLMetodoPago);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.ErrorImporte);
            this.Controls.Add(this.TxtImporte);
            this.Controls.Add(this.LblImporte);
            this.Controls.Add(this.ErrorNombre);
            this.Controls.Add(this.TxtDescripcion);
            this.Controls.Add(this.LblDescripcion);
            this.Controls.Add(this.LblMovimientos);
            this.Controls.Add(this.Dgv);
            this.Name = "GUICaja";
            this.Text = "GUICaja";
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Dgv;
        private System.Windows.Forms.Label LblMovimientos;
        private System.Windows.Forms.Label LblDescripcion;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Label ErrorNombre;
        private System.Windows.Forms.Label ErrorImporte;
        private System.Windows.Forms.TextBox TxtImporte;
        private System.Windows.Forms.Label LblImporte;
        private System.Windows.Forms.Label LBLMetodoPago;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label ErrorRol;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Button BtnModificar;
    }
}