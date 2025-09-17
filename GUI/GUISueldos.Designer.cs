namespace GUI
{
    partial class GUISueldos
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
            this.LblPuesto = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.LblSueldo = new System.Windows.Forms.Label();
            this.TxtSueldo = new System.Windows.Forms.TextBox();
            this.ErrorRol = new System.Windows.Forms.Label();
            this.ErrorNombre = new System.Windows.Forms.Label();
            this.LblComisión = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.ErrorIdioma = new System.Windows.Forms.Label();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnSolicitarPago = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // LblPuesto
            // 
            this.LblPuesto.AutoSize = true;
            this.LblPuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPuesto.ForeColor = System.Drawing.Color.White;
            this.LblPuesto.Location = new System.Drawing.Point(12, 15);
            this.LblPuesto.Name = "LblPuesto";
            this.LblPuesto.Size = new System.Drawing.Size(46, 13);
            this.LblPuesto.TabIndex = 0;
            this.LblPuesto.Text = "Puesto";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(88, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // LblSueldo
            // 
            this.LblSueldo.AutoSize = true;
            this.LblSueldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSueldo.ForeColor = System.Drawing.Color.White;
            this.LblSueldo.Location = new System.Drawing.Point(12, 61);
            this.LblSueldo.Name = "LblSueldo";
            this.LblSueldo.Size = new System.Drawing.Size(57, 13);
            this.LblSueldo.TabIndex = 2;
            this.LblSueldo.Text = "Sueldo $";
            // 
            // TxtSueldo
            // 
            this.TxtSueldo.Location = new System.Drawing.Point(88, 58);
            this.TxtSueldo.Name = "TxtSueldo";
            this.TxtSueldo.Size = new System.Drawing.Size(121, 20);
            this.TxtSueldo.TabIndex = 3;
            // 
            // ErrorRol
            // 
            this.ErrorRol.AutoSize = true;
            this.ErrorRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorRol.ForeColor = System.Drawing.Color.Red;
            this.ErrorRol.Location = new System.Drawing.Point(85, 36);
            this.ErrorRol.Name = "ErrorRol";
            this.ErrorRol.Size = new System.Drawing.Size(126, 13);
            this.ErrorRol.TabIndex = 28;
            this.ErrorRol.Text = "Seleccion obligatoria";
            // 
            // ErrorNombre
            // 
            this.ErrorNombre.AutoSize = true;
            this.ErrorNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorNombre.ForeColor = System.Drawing.Color.Red;
            this.ErrorNombre.Location = new System.Drawing.Point(85, 81);
            this.ErrorNombre.Name = "ErrorNombre";
            this.ErrorNombre.Size = new System.Drawing.Size(108, 13);
            this.ErrorNombre.TabIndex = 29;
            this.ErrorNombre.Text = "Campo obligatorio";
            // 
            // LblComisión
            // 
            this.LblComisión.AutoSize = true;
            this.LblComisión.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblComisión.ForeColor = System.Drawing.Color.White;
            this.LblComisión.Location = new System.Drawing.Point(12, 113);
            this.LblComisión.Name = "LblComisión";
            this.LblComisión.Size = new System.Drawing.Size(70, 13);
            this.LblComisión.TabIndex = 30;
            this.LblComisión.Text = "Comisión %";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(88, 111);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 31;
            // 
            // ErrorIdioma
            // 
            this.ErrorIdioma.AutoSize = true;
            this.ErrorIdioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorIdioma.ForeColor = System.Drawing.Color.Red;
            this.ErrorIdioma.Location = new System.Drawing.Point(85, 134);
            this.ErrorIdioma.Name = "ErrorIdioma";
            this.ErrorIdioma.Size = new System.Drawing.Size(108, 13);
            this.ErrorIdioma.TabIndex = 32;
            this.ErrorIdioma.Text = "Campo obligatorio";
            // 
            // BtnModificar
            // 
            this.BtnModificar.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificar.Location = new System.Drawing.Point(72, 165);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(90, 30);
            this.BtnModificar.TabIndex = 33;
            this.BtnModificar.Tag = "";
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = false;
            // 
            // BtnSolicitarPago
            // 
            this.BtnSolicitarPago.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnSolicitarPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSolicitarPago.Location = new System.Drawing.Point(72, 212);
            this.BtnSolicitarPago.Name = "BtnSolicitarPago";
            this.BtnSolicitarPago.Size = new System.Drawing.Size(90, 45);
            this.BtnSolicitarPago.TabIndex = 34;
            this.BtnSolicitarPago.Tag = "";
            this.BtnSolicitarPago.Text = "Solicitar pago";
            this.BtnSolicitarPago.UseVisualStyleBackColor = false;
            // 
            // GUISueldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(240, 279);
            this.Controls.Add(this.BtnSolicitarPago);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.ErrorIdioma);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.LblComisión);
            this.Controls.Add(this.ErrorNombre);
            this.Controls.Add(this.ErrorRol);
            this.Controls.Add(this.TxtSueldo);
            this.Controls.Add(this.LblSueldo);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.LblPuesto);
            this.Name = "GUISueldos";
            this.Text = "GUISueldos";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblPuesto;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label LblSueldo;
        private System.Windows.Forms.TextBox TxtSueldo;
        private System.Windows.Forms.Label ErrorRol;
        private System.Windows.Forms.Label ErrorNombre;
        private System.Windows.Forms.Label LblComisión;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label ErrorIdioma;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnSolicitarPago;
    }
}