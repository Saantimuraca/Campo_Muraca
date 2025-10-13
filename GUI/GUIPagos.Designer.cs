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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.LblEstado = new System.Windows.Forms.Label();
            this.LblPagos = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.BtnAsentarPago = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Dgv
            // 
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Location = new System.Drawing.Point(12, 30);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            this.Dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(489, 408);
            this.Dgv.TabIndex = 1;
            this.Dgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Dgv_CellMouseClick);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "En Revisión",
            "Aprobado",
            "Rechazado",
            "Pagado"});
            this.comboBox1.Location = new System.Drawing.Point(504, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(197, 21);
            this.comboBox1.TabIndex = 30;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // LblEstado
            // 
            this.LblEstado.AutoSize = true;
            this.LblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstado.ForeColor = System.Drawing.Color.White;
            this.LblEstado.Location = new System.Drawing.Point(501, 32);
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
            this.LblPagos.Location = new System.Drawing.Point(233, 14);
            this.LblPagos.Name = "LblPagos";
            this.LblPagos.Size = new System.Drawing.Size(42, 13);
            this.LblPagos.TabIndex = 32;
            this.LblPagos.Text = "Pagos";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(504, 99);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(197, 20);
            this.dateTimePicker1.TabIndex = 33;
            // 
            // BtnAsentarPago
            // 
            this.BtnAsentarPago.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnAsentarPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAsentarPago.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnAsentarPago.Location = new System.Drawing.Point(562, 170);
            this.BtnAsentarPago.Name = "BtnAsentarPago";
            this.BtnAsentarPago.Size = new System.Drawing.Size(85, 37);
            this.BtnAsentarPago.TabIndex = 35;
            this.BtnAsentarPago.Text = "Asentar pago";
            this.BtnAsentarPago.UseVisualStyleBackColor = false;
            this.BtnAsentarPago.Click += new System.EventHandler(this.BtnAsentarPago_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(504, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Seleccione la fecha de pago";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Tarjeta de crédito",
            "Tarjeta de débito",
            "Efectivo",
            "Transferencia",
            "Mercado Pago",
            "Otro"});
            this.comboBox2.Location = new System.Drawing.Point(507, 143);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(197, 21);
            this.comboBox2.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(504, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Seleccione un método de pago";
            // 
            // GUIPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(719, 450);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnAsentarPago);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.LblPagos);
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label LblEstado;
        private System.Windows.Forms.Label LblPagos;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button BtnAsentarPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
    }
}