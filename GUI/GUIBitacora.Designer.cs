namespace GUI
{
    partial class GUIBitacroa_
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
            this.BITÁCORA = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.LblDesde = new System.Windows.Forms.Label();
            this.LblHasta = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.BtnFiltrarFecha = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.LblCriticidad = new System.Windows.Forms.Label();
            this.BtnFiltrarCriticidad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Dgv
            // 
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Location = new System.Drawing.Point(12, 49);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            this.Dgv.Size = new System.Drawing.Size(966, 389);
            this.Dgv.TabIndex = 0;
            this.Dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_CellContentClick);
            this.Dgv.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Dgv_DataBindingComplete);
            // 
            // BITÁCORA
            // 
            this.BITÁCORA.AutoSize = true;
            this.BITÁCORA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BITÁCORA.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BITÁCORA.ForeColor = System.Drawing.Color.White;
            this.BITÁCORA.Location = new System.Drawing.Point(421, 6);
            this.BITÁCORA.Name = "BITÁCORA";
            this.BITÁCORA.Size = new System.Drawing.Size(159, 40);
            this.BITÁCORA.TabIndex = 1;
            this.BITÁCORA.Text = "BITÁCORA";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(984, 67);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(197, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // LblDesde
            // 
            this.LblDesde.AutoSize = true;
            this.LblDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDesde.ForeColor = System.Drawing.Color.White;
            this.LblDesde.Location = new System.Drawing.Point(984, 51);
            this.LblDesde.Name = "LblDesde";
            this.LblDesde.Size = new System.Drawing.Size(43, 13);
            this.LblDesde.TabIndex = 3;
            this.LblDesde.Text = "Desde";
            // 
            // LblHasta
            // 
            this.LblHasta.AutoSize = true;
            this.LblHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHasta.ForeColor = System.Drawing.Color.White;
            this.LblHasta.Location = new System.Drawing.Point(984, 95);
            this.LblHasta.Name = "LblHasta";
            this.LblHasta.Size = new System.Drawing.Size(40, 13);
            this.LblHasta.TabIndex = 5;
            this.LblHasta.Text = "Hasta";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(984, 111);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(197, 20);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // BtnFiltrarFecha
            // 
            this.BtnFiltrarFecha.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnFiltrarFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFiltrarFecha.Location = new System.Drawing.Point(1042, 137);
            this.BtnFiltrarFecha.Name = "BtnFiltrarFecha";
            this.BtnFiltrarFecha.Size = new System.Drawing.Size(87, 39);
            this.BtnFiltrarFecha.TabIndex = 6;
            this.BtnFiltrarFecha.Text = "Filtrar por fecha";
            this.BtnFiltrarFecha.UseVisualStyleBackColor = false;
            this.BtnFiltrarFecha.Click += new System.EventHandler(this.BtnFiltrarFecha_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox1.Location = new System.Drawing.Point(987, 202);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // LblCriticidad
            // 
            this.LblCriticidad.AutoSize = true;
            this.LblCriticidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCriticidad.ForeColor = System.Drawing.Color.White;
            this.LblCriticidad.Location = new System.Drawing.Point(987, 186);
            this.LblCriticidad.Name = "LblCriticidad";
            this.LblCriticidad.Size = new System.Drawing.Size(60, 13);
            this.LblCriticidad.TabIndex = 8;
            this.LblCriticidad.Text = "Criticidad";
            // 
            // BtnFiltrarCriticidad
            // 
            this.BtnFiltrarCriticidad.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnFiltrarCriticidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFiltrarCriticidad.Location = new System.Drawing.Point(1005, 229);
            this.BtnFiltrarCriticidad.Name = "BtnFiltrarCriticidad";
            this.BtnFiltrarCriticidad.Size = new System.Drawing.Size(87, 39);
            this.BtnFiltrarCriticidad.TabIndex = 9;
            this.BtnFiltrarCriticidad.Text = "Filtrar por criticidad";
            this.BtnFiltrarCriticidad.UseVisualStyleBackColor = false;
            this.BtnFiltrarCriticidad.Click += new System.EventHandler(this.BtnFiltrarCriticidad_Click);
            // 
            // GUIBitacroa_
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1196, 450);
            this.Controls.Add(this.BtnFiltrarCriticidad);
            this.Controls.Add(this.LblCriticidad);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.BtnFiltrarFecha);
            this.Controls.Add(this.LblHasta);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.LblDesde);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.BITÁCORA);
            this.Controls.Add(this.Dgv);
            this.Name = "GUIBitacroa_";
            this.Text = "GUIBitacroa_";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GUIBitacroa__FormClosed);
            this.Load += new System.EventHandler(this.GUIBitacroa__Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Dgv;
        private System.Windows.Forms.Label BITÁCORA;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label LblDesde;
        private System.Windows.Forms.Label LblHasta;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button BtnFiltrarFecha;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label LblCriticidad;
        private System.Windows.Forms.Button BtnFiltrarCriticidad;
    }
}