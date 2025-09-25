﻿namespace GUI
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
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.LblTipo = new System.Windows.Forms.Label();
            this.ErrorTipo = new System.Windows.Forms.Label();
            this.LblTotalCaja = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Dgv
            // 
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Location = new System.Drawing.Point(12, 26);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            this.Dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(664, 369);
            this.Dgv.TabIndex = 0;
            this.Dgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Dgv_CellMouseClick);
            // 
            // LblMovimientos
            // 
            this.LblMovimientos.AutoSize = true;
            this.LblMovimientos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMovimientos.ForeColor = System.Drawing.Color.White;
            this.LblMovimientos.Location = new System.Drawing.Point(305, 10);
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
            this.LblDescripcion.Location = new System.Drawing.Point(679, 37);
            this.LblDescripcion.Name = "LblDescripcion";
            this.LblDescripcion.Size = new System.Drawing.Size(74, 13);
            this.LblDescripcion.TabIndex = 2;
            this.LblDescripcion.Text = "Descripción";
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Location = new System.Drawing.Point(682, 53);
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(172, 20);
            this.TxtDescripcion.TabIndex = 3;
            this.TxtDescripcion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtDescripcion_KeyUp);
            // 
            // ErrorNombre
            // 
            this.ErrorNombre.AutoSize = true;
            this.ErrorNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorNombre.ForeColor = System.Drawing.Color.Red;
            this.ErrorNombre.Location = new System.Drawing.Point(679, 76);
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
            this.ErrorImporte.Location = new System.Drawing.Point(679, 137);
            this.ErrorImporte.Name = "ErrorImporte";
            this.ErrorImporte.Size = new System.Drawing.Size(97, 13);
            this.ErrorImporte.TabIndex = 9;
            this.ErrorImporte.Text = "Importe inválido";
            // 
            // TxtImporte
            // 
            this.TxtImporte.Location = new System.Drawing.Point(682, 114);
            this.TxtImporte.Name = "TxtImporte";
            this.TxtImporte.Size = new System.Drawing.Size(172, 20);
            this.TxtImporte.TabIndex = 8;
            this.TxtImporte.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtImporte_KeyUp);
            // 
            // LblImporte
            // 
            this.LblImporte.AutoSize = true;
            this.LblImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblImporte.ForeColor = System.Drawing.Color.White;
            this.LblImporte.Location = new System.Drawing.Point(679, 98);
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
            this.LBLMetodoPago.Location = new System.Drawing.Point(679, 157);
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
            this.comboBox1.Location = new System.Drawing.Point(682, 173);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ErrorRol
            // 
            this.ErrorRol.AutoSize = true;
            this.ErrorRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorRol.ForeColor = System.Drawing.Color.Red;
            this.ErrorRol.Location = new System.Drawing.Point(682, 197);
            this.ErrorRol.Name = "ErrorRol";
            this.ErrorRol.Size = new System.Drawing.Size(126, 13);
            this.ErrorRol.TabIndex = 28;
            this.ErrorRol.Text = "Seleccion obligatoria";
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.Location = new System.Drawing.Point(241, 401);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(90, 30);
            this.BtnAgregar.TabIndex = 29;
            this.BtnAgregar.Tag = "";
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = false;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnModificar
            // 
            this.BtnModificar.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificar.Location = new System.Drawing.Point(354, 401);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(90, 30);
            this.BtnModificar.TabIndex = 30;
            this.BtnModificar.Tag = "";
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = false;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Ingreso",
            "Egreso"});
            this.comboBox2.Location = new System.Drawing.Point(682, 239);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 31;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // LblTipo
            // 
            this.LblTipo.AutoSize = true;
            this.LblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTipo.ForeColor = System.Drawing.Color.White;
            this.LblTipo.Location = new System.Drawing.Point(682, 223);
            this.LblTipo.Name = "LblTipo";
            this.LblTipo.Size = new System.Drawing.Size(32, 13);
            this.LblTipo.TabIndex = 32;
            this.LblTipo.Text = "Tipo";
            // 
            // ErrorTipo
            // 
            this.ErrorTipo.AutoSize = true;
            this.ErrorTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorTipo.ForeColor = System.Drawing.Color.Red;
            this.ErrorTipo.Location = new System.Drawing.Point(682, 263);
            this.ErrorTipo.Name = "ErrorTipo";
            this.ErrorTipo.Size = new System.Drawing.Size(126, 13);
            this.ErrorTipo.TabIndex = 33;
            this.ErrorTipo.Text = "Seleccion obligatoria";
            // 
            // LblTotalCaja
            // 
            this.LblTotalCaja.AutoSize = true;
            this.LblTotalCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalCaja.ForeColor = System.Drawing.Color.White;
            this.LblTotalCaja.Location = new System.Drawing.Point(682, 428);
            this.LblTotalCaja.Name = "LblTotalCaja";
            this.LblTotalCaja.Size = new System.Drawing.Size(47, 13);
            this.LblTotalCaja.TabIndex = 34;
            this.LblTotalCaja.Text = "Caja: $";
            // 
            // GUICaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(865, 450);
            this.Controls.Add(this.LblTotalCaja);
            this.Controls.Add(this.ErrorTipo);
            this.Controls.Add(this.LblTipo);
            this.Controls.Add(this.comboBox2);
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
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label LblTipo;
        private System.Windows.Forms.Label ErrorTipo;
        private System.Windows.Forms.Label LblTotalCaja;
    }
}