namespace GUI
{
    partial class RevisarSolicitudes
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
            this.BtnRechazar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.LblSolicitudes = new System.Windows.Forms.Label();
            this.LblSeleccionarEstado = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.BtnCrearOrdenCompra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
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
            this.Dgv.Size = new System.Drawing.Size(485, 420);
            this.Dgv.TabIndex = 0;
            this.Dgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Dgv_CellMouseClick);
            // 
            // BtnRechazar
            // 
            this.BtnRechazar.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnRechazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRechazar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnRechazar.Location = new System.Drawing.Point(262, 453);
            this.BtnRechazar.Name = "BtnRechazar";
            this.BtnRechazar.Size = new System.Drawing.Size(85, 37);
            this.BtnRechazar.TabIndex = 4;
            this.BtnRechazar.Text = "Rechazar";
            this.BtnRechazar.UseVisualStyleBackColor = false;
            this.BtnRechazar.Click += new System.EventHandler(this.BtnRechazar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnAceptar.Location = new System.Drawing.Point(158, 453);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(85, 37);
            this.BtnAceptar.TabIndex = 3;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = false;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // LblSolicitudes
            // 
            this.LblSolicitudes.AutoSize = true;
            this.LblSolicitudes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSolicitudes.ForeColor = System.Drawing.Color.White;
            this.LblSolicitudes.Location = new System.Drawing.Point(221, 11);
            this.LblSolicitudes.Name = "LblSolicitudes";
            this.LblSolicitudes.Size = new System.Drawing.Size(69, 13);
            this.LblSolicitudes.TabIndex = 5;
            this.LblSolicitudes.Text = "Solicitudes";
            // 
            // LblSeleccionarEstado
            // 
            this.LblSeleccionarEstado.AutoSize = true;
            this.LblSeleccionarEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSeleccionarEstado.ForeColor = System.Drawing.Color.White;
            this.LblSeleccionarEstado.Location = new System.Drawing.Point(503, 28);
            this.LblSeleccionarEstado.Name = "LblSeleccionarEstado";
            this.LblSeleccionarEstado.Size = new System.Drawing.Size(112, 13);
            this.LblSeleccionarEstado.TabIndex = 6;
            this.LblSeleccionarEstado.Text = "Seleccione estado";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Pendiente",
            "Aprobada",
            "Rechazada",
            "En revisión",
            "Todas"});
            this.comboBox1.Location = new System.Drawing.Point(506, 44);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(127, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // BtnCrearOrdenCompra
            // 
            this.BtnCrearOrdenCompra.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnCrearOrdenCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCrearOrdenCompra.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnCrearOrdenCompra.Location = new System.Drawing.Point(506, 202);
            this.BtnCrearOrdenCompra.Name = "BtnCrearOrdenCompra";
            this.BtnCrearOrdenCompra.Size = new System.Drawing.Size(94, 51);
            this.BtnCrearOrdenCompra.TabIndex = 8;
            this.BtnCrearOrdenCompra.Text = "Crear orden de compra";
            this.BtnCrearOrdenCompra.UseVisualStyleBackColor = false;
            // 
            // RevisarSolicitudes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(653, 512);
            this.Controls.Add(this.BtnCrearOrdenCompra);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.LblSeleccionarEstado);
            this.Controls.Add(this.LblSolicitudes);
            this.Controls.Add(this.BtnRechazar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.Dgv);
            this.Name = "RevisarSolicitudes";
            this.Text = "RevisarSolicitudes";
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Dgv;
        private System.Windows.Forms.Button BtnRechazar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Label LblSolicitudes;
        private System.Windows.Forms.Label LblSeleccionarEstado;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button BtnCrearOrdenCompra;
    }
}