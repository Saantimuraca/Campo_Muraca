namespace GUI
{
    partial class HistoriaUsuarios
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
            this.BtnRollBack = new System.Windows.Forms.Button();
            this.LblHistorial = new System.Windows.Forms.Label();
            this.Dgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnRollBack
            // 
            this.BtnRollBack.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnRollBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRollBack.Location = new System.Drawing.Point(573, 400);
            this.BtnRollBack.Name = "BtnRollBack";
            this.BtnRollBack.Size = new System.Drawing.Size(87, 39);
            this.BtnRollBack.TabIndex = 10;
            this.BtnRollBack.Text = "Devolver estado";
            this.BtnRollBack.UseVisualStyleBackColor = false;
            this.BtnRollBack.Click += new System.EventHandler(this.BtnRollBack_Click);
            // 
            // LblHistorial
            // 
            this.LblHistorial.AutoSize = true;
            this.LblHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LblHistorial.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHistorial.ForeColor = System.Drawing.Color.White;
            this.LblHistorial.Location = new System.Drawing.Point(530, 11);
            this.LblHistorial.Name = "LblHistorial";
            this.LblHistorial.Size = new System.Drawing.Size(165, 40);
            this.LblHistorial.TabIndex = 9;
            this.LblHistorial.Text = "HISTORIAL";
            // 
            // Dgv
            // 
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Location = new System.Drawing.Point(12, 54);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            this.Dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(1200, 340);
            this.Dgv.TabIndex = 8;
            // 
            // HistoriaUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1227, 450);
            this.Controls.Add(this.BtnRollBack);
            this.Controls.Add(this.LblHistorial);
            this.Controls.Add(this.Dgv);
            this.Name = "HistoriaUsuarios";
            this.Text = "HistoriaUsuarios";
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnRollBack;
        private System.Windows.Forms.Label LblHistorial;
        private System.Windows.Forms.DataGridView Dgv;
    }
}