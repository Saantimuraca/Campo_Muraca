﻿namespace GUI
{
    partial class GUIRegistrarPedido
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LblSeleccionCliente = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ErrorSeleccionCliente = new System.Windows.Forms.Label();
            this.BtnNuevoCliente = new System.Windows.Forms.Button();
            this.BtnVaciarCarrito = new System.Windows.Forms.Button();
            this.LBL_Carrito = new System.Windows.Forms.Label();
            this.DgvProductos = new System.Windows.Forms.DataGridView();
            this.BtnAgregarCarrito = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.DgvCarrito = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LBLTotal = new System.Windows.Forms.Label();
            this.BtnRegistrarPedido = new System.Windows.Forms.Button();
            this.BtnEliminarProductoCarrito = new System.Windows.Forms.Button();
            this.BtnNotificarBajoStock = new System.Windows.Forms.Button();
            this.BtnModificarCantidad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCarrito)).BeginInit();
            this.SuspendLayout();
            // 
            // LblSeleccionCliente
            // 
            this.LblSeleccionCliente.AutoSize = true;
            this.LblSeleccionCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSeleccionCliente.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LblSeleccionCliente.Location = new System.Drawing.Point(64, 10);
            this.LblSeleccionCliente.Name = "LblSeleccionCliente";
            this.LblSeleccionCliente.Size = new System.Drawing.Size(46, 13);
            this.LblSeleccionCliente.TabIndex = 0;
            this.LblSeleccionCliente.Text = "Cliente";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboBox1.ForeColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 25);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(166, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.TextUpdate += new System.EventHandler(this.comboBox1_TextUpdate);
            this.comboBox1.Leave += new System.EventHandler(this.comboBox1_Leave);
            // 
            // ErrorSeleccionCliente
            // 
            this.ErrorSeleccionCliente.AutoSize = true;
            this.ErrorSeleccionCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorSeleccionCliente.ForeColor = System.Drawing.Color.Red;
            this.ErrorSeleccionCliente.Location = new System.Drawing.Point(6, 48);
            this.ErrorSeleccionCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ErrorSeleccionCliente.Name = "ErrorSeleccionCliente";
            this.ErrorSeleccionCliente.Size = new System.Drawing.Size(166, 13);
            this.ErrorSeleccionCliente.TabIndex = 2;
            this.ErrorSeleccionCliente.Text = "Debe seleccionar un cliente";
            // 
            // BtnNuevoCliente
            // 
            this.BtnNuevoCliente.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnNuevoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNuevoCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnNuevoCliente.Location = new System.Drawing.Point(41, 63);
            this.BtnNuevoCliente.Margin = new System.Windows.Forms.Padding(2);
            this.BtnNuevoCliente.Name = "BtnNuevoCliente";
            this.BtnNuevoCliente.Size = new System.Drawing.Size(96, 33);
            this.BtnNuevoCliente.TabIndex = 3;
            this.BtnNuevoCliente.Text = "Nuevo cliente";
            this.BtnNuevoCliente.UseVisualStyleBackColor = false;
            this.BtnNuevoCliente.Click += new System.EventHandler(this.BtnNuevoCliente_Click);
            // 
            // BtnVaciarCarrito
            // 
            this.BtnVaciarCarrito.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnVaciarCarrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVaciarCarrito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnVaciarCarrito.Location = new System.Drawing.Point(1444, 591);
            this.BtnVaciarCarrito.Name = "BtnVaciarCarrito";
            this.BtnVaciarCarrito.Size = new System.Drawing.Size(109, 33);
            this.BtnVaciarCarrito.TabIndex = 5;
            this.BtnVaciarCarrito.Text = "Vaciar carrito";
            this.BtnVaciarCarrito.UseVisualStyleBackColor = false;
            this.BtnVaciarCarrito.Click += new System.EventHandler(this.BtnVaciarCarrito_Click);
            // 
            // LBL_Carrito
            // 
            this.LBL_Carrito.AutoSize = true;
            this.LBL_Carrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Carrito.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LBL_Carrito.Location = new System.Drawing.Point(1349, 9);
            this.LBL_Carrito.Name = "LBL_Carrito";
            this.LBL_Carrito.Size = new System.Drawing.Size(113, 13);
            this.LBL_Carrito.TabIndex = 6;
            this.LBL_Carrito.Text = "Carrito de compras";
            // 
            // DgvProductos
            // 
            this.DgvProductos.AllowUserToAddRows = false;
            this.DgvProductos.AllowUserToDeleteRows = false;
            this.DgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvProductos.DefaultCellStyle = dataGridViewCellStyle8;
            this.DgvProductos.EnableHeadersVisualStyles = false;
            this.DgvProductos.Location = new System.Drawing.Point(12, 112);
            this.DgvProductos.Name = "DgvProductos";
            this.DgvProductos.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.DgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProductos.Size = new System.Drawing.Size(1063, 551);
            this.DgvProductos.TabIndex = 7;
            this.DgvProductos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvProductos_CellMouseClick);
            this.DgvProductos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DgvProductos_DataBindingComplete);
            // 
            // BtnAgregarCarrito
            // 
            this.BtnAgregarCarrito.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnAgregarCarrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregarCarrito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnAgregarCarrito.Location = new System.Drawing.Point(1081, 156);
            this.BtnAgregarCarrito.Name = "BtnAgregarCarrito";
            this.BtnAgregarCarrito.Size = new System.Drawing.Size(126, 45);
            this.BtnAgregarCarrito.TabIndex = 8;
            this.BtnAgregarCarrito.Text = "Agregar al carrito";
            this.BtnAgregarCarrito.UseVisualStyleBackColor = false;
            this.BtnAgregarCarrito.Click += new System.EventHandler(this.BtnAgregarCarrito_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(1081, 111);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(111, 20);
            this.numericUpDown1.TabIndex = 9;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // DgvCarrito
            // 
            this.DgvCarrito.AllowUserToAddRows = false;
            this.DgvCarrito.AllowUserToDeleteRows = false;
            this.DgvCarrito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvCarrito.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.DgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCarrito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvCarrito.DefaultCellStyle = dataGridViewCellStyle11;
            this.DgvCarrito.Location = new System.Drawing.Point(1255, 25);
            this.DgvCarrito.Name = "DgvCarrito";
            this.DgvCarrito.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvCarrito.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.DgvCarrito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCarrito.Size = new System.Drawing.Size(298, 563);
            this.DgvCarrito.TabIndex = 11;
            this.DgvCarrito.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvCarrito_CellMouseClick);
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Id";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Producto";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Cantidad";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Precio unitario";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // LBLTotal
            // 
            this.LBLTotal.AutoSize = true;
            this.LBLTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLTotal.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LBLTotal.Location = new System.Drawing.Point(1252, 591);
            this.LBLTotal.Name = "LBLTotal";
            this.LBLTotal.Size = new System.Drawing.Size(51, 13);
            this.LBLTotal.TabIndex = 12;
            this.LBLTotal.Text = "Total: $";
            // 
            // BtnRegistrarPedido
            // 
            this.BtnRegistrarPedido.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnRegistrarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistrarPedido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnRegistrarPedido.Location = new System.Drawing.Point(1444, 631);
            this.BtnRegistrarPedido.Name = "BtnRegistrarPedido";
            this.BtnRegistrarPedido.Size = new System.Drawing.Size(109, 32);
            this.BtnRegistrarPedido.TabIndex = 13;
            this.BtnRegistrarPedido.Text = "Registrar pedido";
            this.BtnRegistrarPedido.UseVisualStyleBackColor = false;
            this.BtnRegistrarPedido.Click += new System.EventHandler(this.BtnRegistrarPedido_Click);
            // 
            // BtnEliminarProductoCarrito
            // 
            this.BtnEliminarProductoCarrito.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnEliminarProductoCarrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminarProductoCarrito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnEliminarProductoCarrito.Location = new System.Drawing.Point(1083, 207);
            this.BtnEliminarProductoCarrito.Name = "BtnEliminarProductoCarrito";
            this.BtnEliminarProductoCarrito.Size = new System.Drawing.Size(124, 46);
            this.BtnEliminarProductoCarrito.TabIndex = 14;
            this.BtnEliminarProductoCarrito.Text = "Eliminar producto del carrito";
            this.BtnEliminarProductoCarrito.UseVisualStyleBackColor = false;
            this.BtnEliminarProductoCarrito.Click += new System.EventHandler(this.BtnEliminarProductoCarrito_Click);
            // 
            // BtnNotificarBajoStock
            // 
            this.BtnNotificarBajoStock.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnNotificarBajoStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNotificarBajoStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnNotificarBajoStock.Location = new System.Drawing.Point(1083, 311);
            this.BtnNotificarBajoStock.Name = "BtnNotificarBajoStock";
            this.BtnNotificarBajoStock.Size = new System.Drawing.Size(124, 46);
            this.BtnNotificarBajoStock.TabIndex = 15;
            this.BtnNotificarBajoStock.Text = "Notificar bajo stock";
            this.BtnNotificarBajoStock.UseVisualStyleBackColor = false;
            this.BtnNotificarBajoStock.Click += new System.EventHandler(this.BtnNotificarBajoStock_Click);
            // 
            // BtnModificarCantidad
            // 
            this.BtnModificarCantidad.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnModificarCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificarCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnModificarCantidad.Location = new System.Drawing.Point(1083, 259);
            this.BtnModificarCantidad.Name = "BtnModificarCantidad";
            this.BtnModificarCantidad.Size = new System.Drawing.Size(124, 46);
            this.BtnModificarCantidad.TabIndex = 16;
            this.BtnModificarCantidad.Text = "Modificar cantidad";
            this.BtnModificarCantidad.UseVisualStyleBackColor = false;
            this.BtnModificarCantidad.Click += new System.EventHandler(this.BtnModificarCantidad_Click);
            // 
            // GUIRegistrarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1565, 675);
            this.Controls.Add(this.BtnModificarCantidad);
            this.Controls.Add(this.BtnNotificarBajoStock);
            this.Controls.Add(this.BtnEliminarProductoCarrito);
            this.Controls.Add(this.BtnRegistrarPedido);
            this.Controls.Add(this.LBLTotal);
            this.Controls.Add(this.DgvCarrito);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.BtnAgregarCarrito);
            this.Controls.Add(this.DgvProductos);
            this.Controls.Add(this.LBL_Carrito);
            this.Controls.Add(this.BtnVaciarCarrito);
            this.Controls.Add(this.BtnNuevoCliente);
            this.Controls.Add(this.ErrorSeleccionCliente);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.LblSeleccionCliente);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "GUIRegistrarPedido";
            this.Text = "GUIRegistrarPedido";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GUIRegistrarPedido_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.DgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCarrito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblSeleccionCliente;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label ErrorSeleccionCliente;
        private System.Windows.Forms.Button BtnNuevoCliente;
        private System.Windows.Forms.Button BtnVaciarCarrito;
        private System.Windows.Forms.Label LBL_Carrito;
        private System.Windows.Forms.DataGridView DgvProductos;
        private System.Windows.Forms.Button BtnAgregarCarrito;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.DataGridView DgvCarrito;
        private System.Windows.Forms.Label LBLTotal;
        private System.Windows.Forms.Button BtnRegistrarPedido;
        private System.Windows.Forms.Button BtnEliminarProductoCarrito;
        private System.Windows.Forms.Button BtnNotificarBajoStock;
        private System.Windows.Forms.Button BtnModificarCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}