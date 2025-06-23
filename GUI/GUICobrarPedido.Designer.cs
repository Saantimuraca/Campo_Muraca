namespace GUI
{
    partial class GUICobrarPedido
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
            this.DgvPedidos = new System.Windows.Forms.DataGridView();
            this.BtnCobrarPedido = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.LBLMetodoPago = new System.Windows.Forms.Label();
            this.BtnVerFactura = new System.Windows.Forms.Button();
            this.BtnRealizarFactura = new System.Windows.Forms.Button();
            this.LblSeleccionEstadoPedido = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.LBLPedidos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvPedidos
            // 
            this.DgvPedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPedidos.Location = new System.Drawing.Point(12, 28);
            this.DgvPedidos.Name = "DgvPedidos";
            this.DgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPedidos.Size = new System.Drawing.Size(982, 644);
            this.DgvPedidos.TabIndex = 1;
            this.DgvPedidos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvPedidos_CellMouseClick);
            // 
            // BtnCobrarPedido
            // 
            this.BtnCobrarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCobrarPedido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnCobrarPedido.Location = new System.Drawing.Point(1000, 208);
            this.BtnCobrarPedido.Name = "BtnCobrarPedido";
            this.BtnCobrarPedido.Size = new System.Drawing.Size(79, 42);
            this.BtnCobrarPedido.TabIndex = 2;
            this.BtnCobrarPedido.Text = "Cobrar";
            this.BtnCobrarPedido.UseVisualStyleBackColor = true;
            this.BtnCobrarPedido.Click += new System.EventHandler(this.BtnCobrarPedido_Click);
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
            this.comboBox1.Location = new System.Drawing.Point(1000, 76);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // LBLMetodoPago
            // 
            this.LBLMetodoPago.AutoSize = true;
            this.LBLMetodoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLMetodoPago.ForeColor = System.Drawing.Color.White;
            this.LBLMetodoPago.Location = new System.Drawing.Point(997, 60);
            this.LBLMetodoPago.Name = "LBLMetodoPago";
            this.LBLMetodoPago.Size = new System.Drawing.Size(99, 13);
            this.LBLMetodoPago.TabIndex = 4;
            this.LBLMetodoPago.Text = "Método de pago";
            // 
            // BtnVerFactura
            // 
            this.BtnVerFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVerFactura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnVerFactura.Location = new System.Drawing.Point(1000, 160);
            this.BtnVerFactura.Name = "BtnVerFactura";
            this.BtnVerFactura.Size = new System.Drawing.Size(79, 42);
            this.BtnVerFactura.TabIndex = 5;
            this.BtnVerFactura.Text = "Ver factura";
            this.BtnVerFactura.UseVisualStyleBackColor = true;
            this.BtnVerFactura.Click += new System.EventHandler(this.BtnVerFactura_Click);
            // 
            // BtnRealizarFactura
            // 
            this.BtnRealizarFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRealizarFactura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnRealizarFactura.Location = new System.Drawing.Point(1000, 112);
            this.BtnRealizarFactura.Name = "BtnRealizarFactura";
            this.BtnRealizarFactura.Size = new System.Drawing.Size(79, 42);
            this.BtnRealizarFactura.TabIndex = 6;
            this.BtnRealizarFactura.Text = "Realizar factura";
            this.BtnRealizarFactura.UseVisualStyleBackColor = true;
            this.BtnRealizarFactura.Click += new System.EventHandler(this.BtnRealizarFactura_Click);
            // 
            // LblSeleccionEstadoPedido
            // 
            this.LblSeleccionEstadoPedido.AutoSize = true;
            this.LblSeleccionEstadoPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSeleccionEstadoPedido.ForeColor = System.Drawing.Color.White;
            this.LblSeleccionEstadoPedido.Location = new System.Drawing.Point(997, 12);
            this.LblSeleccionEstadoPedido.Name = "LblSeleccionEstadoPedido";
            this.LblSeleccionEstadoPedido.Size = new System.Drawing.Size(189, 13);
            this.LblSeleccionEstadoPedido.TabIndex = 8;
            this.LblSeleccionEstadoPedido.Text = "Seleccione el estado del pedido";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Aprobado",
            "En evaluación",
            "Rechazado",
            "Cobrado",
            "Facturado",
            "Todos"});
            this.comboBox2.Location = new System.Drawing.Point(1000, 28);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(186, 21);
            this.comboBox2.TabIndex = 7;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // LBLPedidos
            // 
            this.LBLPedidos.AutoSize = true;
            this.LBLPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLPedidos.ForeColor = System.Drawing.Color.White;
            this.LBLPedidos.Location = new System.Drawing.Point(476, 12);
            this.LBLPedidos.Name = "LBLPedidos";
            this.LBLPedidos.Size = new System.Drawing.Size(41, 13);
            this.LBLPedidos.TabIndex = 9;
            this.LBLPedidos.Text = "label1";
            // 
            // GUICobrarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1191, 684);
            this.Controls.Add(this.LBLPedidos);
            this.Controls.Add(this.LblSeleccionEstadoPedido);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.BtnRealizarFactura);
            this.Controls.Add(this.BtnVerFactura);
            this.Controls.Add(this.LBLMetodoPago);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.BtnCobrarPedido);
            this.Controls.Add(this.DgvPedidos);
            this.Name = "GUICobrarPedido";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GUICobrarPedido_FormClosed);
            this.Load += new System.EventHandler(this.GUICobrarPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvPedidos;
        private System.Windows.Forms.Button BtnCobrarPedido;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label LBLMetodoPago;
        private System.Windows.Forms.Button BtnVerFactura;
        private System.Windows.Forms.Button BtnRealizarFactura;
        private System.Windows.Forms.Label LblSeleccionEstadoPedido;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label LBLPedidos;
    }
}