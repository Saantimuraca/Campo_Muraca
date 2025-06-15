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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.LblEstadoPedido = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvPedidos
            // 
            this.DgvPedidos.AllowUserToAddRows = false;
            this.DgvPedidos.AllowUserToDeleteRows = false;
            this.DgvPedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPedidos.Location = new System.Drawing.Point(12, 55);
            this.DgvPedidos.Name = "DgvPedidos";
            this.DgvPedidos.ReadOnly = true;
            this.DgvPedidos.Size = new System.Drawing.Size(1035, 383);
            this.DgvPedidos.TabIndex = 0;
            // 
            // BtnConfirmarPedido
            // 
            this.BtnConfirmarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConfirmarPedido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnConfirmarPedido.Location = new System.Drawing.Point(462, 29);
            this.BtnConfirmarPedido.Name = "BtnConfirmarPedido";
            this.BtnConfirmarPedido.Size = new System.Drawing.Size(75, 23);
            this.BtnConfirmarPedido.TabIndex = 1;
            this.BtnConfirmarPedido.Text = "Aceptar";
            this.BtnConfirmarPedido.UseVisualStyleBackColor = true;
            this.BtnConfirmarPedido.Click += new System.EventHandler(this.BtnConfirmarPedido_Click);
            // 
            // BtnRechazar
            // 
            this.BtnRechazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRechazar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnRechazar.Location = new System.Drawing.Point(557, 29);
            this.BtnRechazar.Name = "BtnRechazar";
            this.BtnRechazar.Size = new System.Drawing.Size(75, 23);
            this.BtnRechazar.TabIndex = 2;
            this.BtnRechazar.Text = "Rechazar";
            this.BtnRechazar.UseVisualStyleBackColor = true;
            this.BtnRechazar.Click += new System.EventHandler(this.BtnRechazar_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Aprobado",
            "En evaluación",
            "Rechazado",
            "Cobrado",
            "Facturado",
            "Todos"});
            this.comboBox1.Location = new System.Drawing.Point(1053, 55);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(186, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // LblEstadoPedido
            // 
            this.LblEstadoPedido.AutoSize = true;
            this.LblEstadoPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstadoPedido.ForeColor = System.Drawing.Color.White;
            this.LblEstadoPedido.Location = new System.Drawing.Point(1050, 39);
            this.LblEstadoPedido.Name = "LblEstadoPedido";
            this.LblEstadoPedido.Size = new System.Drawing.Size(189, 13);
            this.LblEstadoPedido.TabIndex = 4;
            this.LblEstadoPedido.Text = "Seleccione el estado del pedido";
            // 
            // GUIConfirmarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1251, 450);
            this.Controls.Add(this.LblEstadoPedido);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.BtnRechazar);
            this.Controls.Add(this.BtnConfirmarPedido);
            this.Controls.Add(this.DgvPedidos);
            this.Name = "GUIConfirmarPedido";
            this.Text = "GUIConfirmarPedido";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GUIConfirmarPedido_FormClosed);
            this.Load += new System.EventHandler(this.GUIConfirmarPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvPedidos;
        private System.Windows.Forms.Button BtnConfirmarPedido;
        private System.Windows.Forms.Button BtnRechazar;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label LblEstadoPedido;
    }
}