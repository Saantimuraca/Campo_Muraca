namespace GUI
{
    partial class GUIConfirmarPedido
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
            this.BtnConfirmarPedido = new System.Windows.Forms.Button();
            this.BtnRechazar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.LblDetalle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvPedidos
            // 
            this.DgvPedidos.AllowUserToAddRows = false;
            this.DgvPedidos.AllowUserToDeleteRows = false;
            this.DgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPedidos.Location = new System.Drawing.Point(12, 55);
            this.DgvPedidos.Name = "DgvPedidos";
            this.DgvPedidos.ReadOnly = true;
            this.DgvPedidos.Size = new System.Drawing.Size(351, 383);
            this.DgvPedidos.TabIndex = 0;
            // 
            // BtnConfirmarPedido
            // 
            this.BtnConfirmarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConfirmarPedido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnConfirmarPedido.Location = new System.Drawing.Point(86, 26);
            this.BtnConfirmarPedido.Name = "BtnConfirmarPedido";
            this.BtnConfirmarPedido.Size = new System.Drawing.Size(75, 23);
            this.BtnConfirmarPedido.TabIndex = 1;
            this.BtnConfirmarPedido.Text = "Aceptar";
            this.BtnConfirmarPedido.UseVisualStyleBackColor = true;
            // 
            // BtnRechazar
            // 
            this.BtnRechazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRechazar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnRechazar.Location = new System.Drawing.Point(192, 26);
            this.BtnRechazar.Name = "BtnRechazar";
            this.BtnRechazar.Size = new System.Drawing.Size(75, 23);
            this.BtnRechazar.TabIndex = 2;
            this.BtnRechazar.Text = "Rechazar";
            this.BtnRechazar.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(408, 55);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(213, 383);
            this.textBox1.TabIndex = 3;
            // 
            // LblDetalle
            // 
            this.LblDetalle.AutoSize = true;
            this.LblDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDetalle.ForeColor = System.Drawing.Color.White;
            this.LblDetalle.Location = new System.Drawing.Point(485, 39);
            this.LblDetalle.Name = "LblDetalle";
            this.LblDetalle.Size = new System.Drawing.Size(47, 13);
            this.LblDetalle.TabIndex = 4;
            this.LblDetalle.Text = "Detalle";
            // 
            // GUIConfirmarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(641, 450);
            this.Controls.Add(this.LblDetalle);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BtnRechazar);
            this.Controls.Add(this.BtnConfirmarPedido);
            this.Controls.Add(this.DgvPedidos);
            this.Name = "GUIConfirmarPedido";
            this.Text = "GUIConfirmarPedido";
            this.Load += new System.EventHandler(this.GUIConfirmarPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvPedidos;
        private System.Windows.Forms.Button BtnConfirmarPedido;
        private System.Windows.Forms.Button BtnRechazar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label LblDetalle;
    }
}