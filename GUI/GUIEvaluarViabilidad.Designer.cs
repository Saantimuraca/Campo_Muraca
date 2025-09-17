namespace GUI
{
    partial class GUIEvaluarViabilidad
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.LblPagos = new System.Windows.Forms.Label();
            this.BtnRechazar = new System.Windows.Forms.Button();
            this.BtnAprobar = new System.Windows.Forms.Button();
            this.LblDetalle = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(419, 355);
            this.dataGridView1.TabIndex = 0;
            // 
            // LblPagos
            // 
            this.LblPagos.AutoSize = true;
            this.LblPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPagos.ForeColor = System.Drawing.Color.White;
            this.LblPagos.Location = new System.Drawing.Point(203, 11);
            this.LblPagos.Name = "LblPagos";
            this.LblPagos.Size = new System.Drawing.Size(42, 13);
            this.LblPagos.TabIndex = 1;
            this.LblPagos.Text = "Pagos";
            // 
            // BtnRechazar
            // 
            this.BtnRechazar.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnRechazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRechazar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnRechazar.Location = new System.Drawing.Point(228, 388);
            this.BtnRechazar.Name = "BtnRechazar";
            this.BtnRechazar.Size = new System.Drawing.Size(85, 37);
            this.BtnRechazar.TabIndex = 3;
            this.BtnRechazar.Text = "Rechazar";
            this.BtnRechazar.UseVisualStyleBackColor = false;
            // 
            // BtnAprobar
            // 
            this.BtnAprobar.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnAprobar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAprobar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnAprobar.Location = new System.Drawing.Point(125, 388);
            this.BtnAprobar.Name = "BtnAprobar";
            this.BtnAprobar.Size = new System.Drawing.Size(85, 37);
            this.BtnAprobar.TabIndex = 4;
            this.BtnAprobar.Text = "Aprobar";
            this.BtnAprobar.UseVisualStyleBackColor = false;
            // 
            // LblDetalle
            // 
            this.LblDetalle.AutoSize = true;
            this.LblDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDetalle.ForeColor = System.Drawing.Color.White;
            this.LblDetalle.Location = new System.Drawing.Point(557, 11);
            this.LblDetalle.Name = "LblDetalle";
            this.LblDetalle.Size = new System.Drawing.Size(47, 13);
            this.LblDetalle.TabIndex = 5;
            this.LblDetalle.Text = "Detalle";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(440, 27);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(270, 355);
            this.textBox1.TabIndex = 6;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // GUIEvaluarViabilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(742, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.LblDetalle);
            this.Controls.Add(this.BtnAprobar);
            this.Controls.Add(this.BtnRechazar);
            this.Controls.Add(this.LblPagos);
            this.Controls.Add(this.dataGridView1);
            this.Name = "GUIEvaluarViabilidad";
            this.Text = "GUIEvaluarViabilidad";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label LblPagos;
        private System.Windows.Forms.Button BtnRechazar;
        private System.Windows.Forms.Button BtnAprobar;
        private System.Windows.Forms.Label LblDetalle;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}