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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.BtnCobrarPedido = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.LBLMetodoPago = new System.Windows.Forms.Label();
            this.BtnVerFactura = new System.Windows.Forms.Button();
            this.BtnRealizarFactura = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 12);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(570, 660);
            this.dataGridView2.TabIndex = 1;
            // 
            // BtnCobrarPedido
            // 
            this.BtnCobrarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCobrarPedido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnCobrarPedido.Location = new System.Drawing.Point(588, 77);
            this.BtnCobrarPedido.Name = "BtnCobrarPedido";
            this.BtnCobrarPedido.Size = new System.Drawing.Size(79, 42);
            this.BtnCobrarPedido.TabIndex = 2;
            this.BtnCobrarPedido.Text = "Cobrar";
            this.BtnCobrarPedido.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(588, 33);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // LBLMetodoPago
            // 
            this.LBLMetodoPago.AutoSize = true;
            this.LBLMetodoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLMetodoPago.ForeColor = System.Drawing.Color.White;
            this.LBLMetodoPago.Location = new System.Drawing.Point(588, 17);
            this.LBLMetodoPago.Name = "LBLMetodoPago";
            this.LBLMetodoPago.Size = new System.Drawing.Size(81, 13);
            this.LBLMetodoPago.TabIndex = 4;
            this.LBLMetodoPago.Text = "Método pago";
            // 
            // BtnVerFactura
            // 
            this.BtnVerFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVerFactura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnVerFactura.Location = new System.Drawing.Point(588, 192);
            this.BtnVerFactura.Name = "BtnVerFactura";
            this.BtnVerFactura.Size = new System.Drawing.Size(81, 42);
            this.BtnVerFactura.TabIndex = 5;
            this.BtnVerFactura.Text = "Ver factura";
            this.BtnVerFactura.UseVisualStyleBackColor = true;
            // 
            // BtnRealizarFactura
            // 
            this.BtnRealizarFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRealizarFactura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnRealizarFactura.Location = new System.Drawing.Point(588, 132);
            this.BtnRealizarFactura.Name = "BtnRealizarFactura";
            this.BtnRealizarFactura.Size = new System.Drawing.Size(81, 42);
            this.BtnRealizarFactura.TabIndex = 6;
            this.BtnRealizarFactura.Text = "Realizar factura";
            this.BtnRealizarFactura.UseVisualStyleBackColor = true;
            // 
            // GUICobrarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(805, 684);
            this.Controls.Add(this.BtnRealizarFactura);
            this.Controls.Add(this.BtnVerFactura);
            this.Controls.Add(this.LBLMetodoPago);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.BtnCobrarPedido);
            this.Controls.Add(this.dataGridView2);
            this.Name = "GUICobrarPedido";
            this.Load += new System.EventHandler(this.GUICobrarPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button BtnCobrarPedido;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label LBLMetodoPago;
        private System.Windows.Forms.Button BtnVerFactura;
        private System.Windows.Forms.Button BtnRealizarFactura;
    }
}