namespace GUI
{
    partial class GUIPagos
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
            this.ErrorRol = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.LblEstado = new System.Windows.Forms.Label();
            this.LblPagos = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.ErrorFechaPago = new System.Windows.Forms.Label();
            this.BtnAsentarPago = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Dgv
            // 
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Location = new System.Drawing.Point(12, 30);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            this.Dgv.Size = new System.Drawing.Size(420, 408);
            this.Dgv.TabIndex = 1;
            // 
            // ErrorRol
            // 
            this.ErrorRol.AutoSize = true;
            this.ErrorRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorRol.ForeColor = System.Drawing.Color.Red;
            this.ErrorRol.Location = new System.Drawing.Point(435, 71);
            this.ErrorRol.Name = "ErrorRol";
            this.ErrorRol.Size = new System.Drawing.Size(126, 13);
            this.ErrorRol.TabIndex = 31;
            this.ErrorRol.Text = "Seleccion obligatoria";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(438, 47);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(197, 21);
            this.comboBox1.TabIndex = 30;
            // 
            // LblEstado
            // 
            this.LblEstado.AutoSize = true;
            this.LblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstado.ForeColor = System.Drawing.Color.White;
            this.LblEstado.Location = new System.Drawing.Point(435, 31);
            this.LblEstado.Name = "LblEstado";
            this.LblEstado.Size = new System.Drawing.Size(130, 13);
            this.LblEstado.TabIndex = 29;
            this.LblEstado.Text = "Seleccione un estado";
            // 
            // LblPagos
            // 
            this.LblPagos.AutoSize = true;
            this.LblPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPagos.ForeColor = System.Drawing.Color.White;
            this.LblPagos.Location = new System.Drawing.Point(202, 14);
            this.LblPagos.Name = "LblPagos";
            this.LblPagos.Size = new System.Drawing.Size(42, 13);
            this.LblPagos.TabIndex = 32;
            this.LblPagos.Text = "Pagos";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(438, 102);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(197, 20);
            this.dateTimePicker1.TabIndex = 33;
            // 
            // ErrorFechaPago
            // 
            this.ErrorFechaPago.AutoSize = true;
            this.ErrorFechaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorFechaPago.ForeColor = System.Drawing.Color.Red;
            this.ErrorFechaPago.Location = new System.Drawing.Point(439, 125);
            this.ErrorFechaPago.Name = "ErrorFechaPago";
            this.ErrorFechaPago.Size = new System.Drawing.Size(167, 13);
            this.ErrorFechaPago.TabIndex = 34;
            this.ErrorFechaPago.Text = "Debe seleccionar una fecha";
            // 
            // BtnAsentarPago
            // 
            this.BtnAsentarPago.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnAsentarPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAsentarPago.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnAsentarPago.Location = new System.Drawing.Point(480, 150);
            this.BtnAsentarPago.Name = "BtnAsentarPago";
            this.BtnAsentarPago.Size = new System.Drawing.Size(85, 37);
            this.BtnAsentarPago.TabIndex = 35;
            this.BtnAsentarPago.Text = "Asentar pago";
            this.BtnAsentarPago.UseVisualStyleBackColor = false;
            // 
            // GUIPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(649, 450);
            this.Controls.Add(this.BtnAsentarPago);
            this.Controls.Add(this.ErrorFechaPago);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.LblPagos);
            this.Controls.Add(this.ErrorRol);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.LblEstado);
            this.Controls.Add(this.Dgv);
            this.Name = "GUIPagos";
            this.Text = "GUIPagos";
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Dgv;
        private System.Windows.Forms.Label ErrorRol;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label LblEstado;
        private System.Windows.Forms.Label LblPagos;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label ErrorFechaPago;
        private System.Windows.Forms.Button BtnAsentarPago;
    }
}