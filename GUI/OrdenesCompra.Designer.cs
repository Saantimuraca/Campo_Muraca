namespace GUI
{
    partial class OrdenesCompra
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
            this.DgvOrdenes = new System.Windows.Forms.DataGridView();
            this.LblEstado = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.BtnFinalizar = new System.Windows.Forms.Button();
            this.LblOrdenesCompra = new System.Windows.Forms.Label();
            this.DgvDetalle = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvOrdenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvOrdenes
            // 
            this.DgvOrdenes.AllowUserToAddRows = false;
            this.DgvOrdenes.AllowUserToDeleteRows = false;
            this.DgvOrdenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvOrdenes.Location = new System.Drawing.Point(12, 22);
            this.DgvOrdenes.Name = "DgvOrdenes";
            this.DgvOrdenes.ReadOnly = true;
            this.DgvOrdenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvOrdenes.Size = new System.Drawing.Size(493, 416);
            this.DgvOrdenes.TabIndex = 0;
            this.DgvOrdenes.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvOrdenes_CellMouseClick);
            // 
            // LblEstado
            // 
            this.LblEstado.AutoSize = true;
            this.LblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstado.ForeColor = System.Drawing.Color.White;
            this.LblEstado.Location = new System.Drawing.Point(511, 23);
            this.LblEstado.Name = "LblEstado";
            this.LblEstado.Size = new System.Drawing.Size(130, 13);
            this.LblEstado.TabIndex = 2;
            this.LblEstado.Text = "Seleccione un estado";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Generada",
            "Finalizada"});
            this.comboBox1.Location = new System.Drawing.Point(514, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(123, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // BtnFinalizar
            // 
            this.BtnFinalizar.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnFinalizar.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFinalizar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnFinalizar.Location = new System.Drawing.Point(514, 66);
            this.BtnFinalizar.Name = "BtnFinalizar";
            this.BtnFinalizar.Size = new System.Drawing.Size(123, 36);
            this.BtnFinalizar.TabIndex = 29;
            this.BtnFinalizar.Tag = "";
            this.BtnFinalizar.Text = "FINALIZAR";
            this.BtnFinalizar.UseVisualStyleBackColor = false;
            this.BtnFinalizar.Click += new System.EventHandler(this.BtnFinalizar_Click);
            // 
            // LblOrdenesCompra
            // 
            this.LblOrdenesCompra.AutoSize = true;
            this.LblOrdenesCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblOrdenesCompra.ForeColor = System.Drawing.Color.White;
            this.LblOrdenesCompra.Location = new System.Drawing.Point(196, 6);
            this.LblOrdenesCompra.Name = "LblOrdenesCompra";
            this.LblOrdenesCompra.Size = new System.Drawing.Size(117, 13);
            this.LblOrdenesCompra.TabIndex = 1;
            this.LblOrdenesCompra.Text = "Ordenes de compra";
            // 
            // DgvDetalle
            // 
            this.DgvDetalle.AllowUserToAddRows = false;
            this.DgvDetalle.AllowUserToDeleteRows = false;
            this.DgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDetalle.Location = new System.Drawing.Point(711, 22);
            this.DgvDetalle.Name = "DgvDetalle";
            this.DgvDetalle.ReadOnly = true;
            this.DgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvDetalle.Size = new System.Drawing.Size(326, 416);
            this.DgvDetalle.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(852, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Detalle";
            // 
            // OrdenesCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1049, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgvDetalle);
            this.Controls.Add(this.BtnFinalizar);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.LblEstado);
            this.Controls.Add(this.LblOrdenesCompra);
            this.Controls.Add(this.DgvOrdenes);
            this.Name = "OrdenesCompra";
            this.Text = "OrdenesCompra";
            ((System.ComponentModel.ISupportInitialize)(this.DgvOrdenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvOrdenes;
        private System.Windows.Forms.Label LblEstado;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button BtnFinalizar;
        private System.Windows.Forms.Label LblOrdenesCompra;
        private System.Windows.Forms.DataGridView DgvDetalle;
        private System.Windows.Forms.Label label1;
    }
}