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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Dgv = new System.Windows.Forms.DataGridView();
            this.LblPagos = new System.Windows.Forms.Label();
            this.BtnRechazar = new System.Windows.Forms.Button();
            this.BtnAprobar = new System.Windows.Forms.Button();
            this.LblDetalle = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chartSueldos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSueldos)).BeginInit();
            this.SuspendLayout();
            // 
            // Dgv
            // 
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Location = new System.Drawing.Point(12, 27);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            this.Dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(419, 548);
            this.Dgv.TabIndex = 0;
            this.Dgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Dgv_CellMouseClick);
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
            this.BtnRechazar.Location = new System.Drawing.Point(225, 581);
            this.BtnRechazar.Name = "BtnRechazar";
            this.BtnRechazar.Size = new System.Drawing.Size(85, 37);
            this.BtnRechazar.TabIndex = 3;
            this.BtnRechazar.Text = "Rechazar";
            this.BtnRechazar.UseVisualStyleBackColor = false;
            this.BtnRechazar.Click += new System.EventHandler(this.BtnRechazar_Click);
            // 
            // BtnAprobar
            // 
            this.BtnAprobar.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnAprobar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAprobar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnAprobar.Location = new System.Drawing.Point(122, 581);
            this.BtnAprobar.Name = "BtnAprobar";
            this.BtnAprobar.Size = new System.Drawing.Size(85, 37);
            this.BtnAprobar.TabIndex = 4;
            this.BtnAprobar.Text = "Aprobar";
            this.BtnAprobar.UseVisualStyleBackColor = false;
            this.BtnAprobar.Click += new System.EventHandler(this.BtnAprobar_Click);
            // 
            // LblDetalle
            // 
            this.LblDetalle.AutoSize = true;
            this.LblDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDetalle.ForeColor = System.Drawing.Color.White;
            this.LblDetalle.Location = new System.Drawing.Point(546, 113);
            this.LblDetalle.Name = "LblDetalle";
            this.LblDetalle.Size = new System.Drawing.Size(47, 13);
            this.LblDetalle.TabIndex = 5;
            this.LblDetalle.Text = "Detalle";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(437, 129);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(266, 403);
            this.textBox1.TabIndex = 6;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // chartSueldos
            // 
            chartArea3.Name = "ChartArea1";
            this.chartSueldos.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartSueldos.Legends.Add(legend3);
            this.chartSueldos.Location = new System.Drawing.Point(786, 63);
            this.chartSueldos.Name = "chartSueldos";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartSueldos.Series.Add(series3);
            this.chartSueldos.Size = new System.Drawing.Size(360, 521);
            this.chartSueldos.TabIndex = 7;
            this.chartSueldos.Text = "chart1";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Gráfico de sueldos por área",
            "Gráfico de balance mensual"});
            this.comboBox1.Location = new System.Drawing.Point(823, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(287, 21);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(820, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Seleccione el tipo de grafico que desea visualizar";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "En Revisión",
            "Pendiente",
            "Aprobado",
            "Rechazado",
            "Pagado"});
            this.comboBox2.Location = new System.Drawing.Point(437, 86);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(179, 21);
            this.comboBox2.TabIndex = 10;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(437, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Seleccione el estado del pago";
            // 
            // GUIEvaluarViabilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1302, 630);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.chartSueldos);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.LblDetalle);
            this.Controls.Add(this.BtnAprobar);
            this.Controls.Add(this.BtnRechazar);
            this.Controls.Add(this.LblPagos);
            this.Controls.Add(this.Dgv);
            this.Name = "GUIEvaluarViabilidad";
            this.Text = "GUIEvaluarViabilidad";
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSueldos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Dgv;
        private System.Windows.Forms.Label LblPagos;
        private System.Windows.Forms.Button BtnRechazar;
        private System.Windows.Forms.Button BtnAprobar;
        private System.Windows.Forms.Label LblDetalle;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSueldos;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
    }
}