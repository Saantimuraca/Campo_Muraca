namespace GUI
{
    partial class GUIIdiomas
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
            this.DgvIdiomas = new System.Windows.Forms.DataGridView();
            this.LBL_Idioma = new System.Windows.Forms.Label();
            this.BtnAgregarIdioma = new System.Windows.Forms.Button();
            this.BtnEliminarIdioma = new System.Windows.Forms.Button();
            this.BtnModificarIdioma = new System.Windows.Forms.Button();
            this.LBL_Traducciones = new System.Windows.Forms.Label();
            this.BtnModificarTraduccion = new System.Windows.Forms.Button();
            this.DgvTraducciones = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DgvIdiomas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTraducciones)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvIdiomas
            // 
            this.DgvIdiomas.AllowUserToAddRows = false;
            this.DgvIdiomas.AllowUserToDeleteRows = false;
            this.DgvIdiomas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvIdiomas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvIdiomas.Location = new System.Drawing.Point(12, 23);
            this.DgvIdiomas.Name = "DgvIdiomas";
            this.DgvIdiomas.ReadOnly = true;
            this.DgvIdiomas.Size = new System.Drawing.Size(290, 197);
            this.DgvIdiomas.TabIndex = 0;
            this.DgvIdiomas.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvIdiomas_CellMouseClick);
            // 
            // LBL_Idioma
            // 
            this.LBL_Idioma.AutoSize = true;
            this.LBL_Idioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Idioma.Location = new System.Drawing.Point(115, 9);
            this.LBL_Idioma.Name = "LBL_Idioma";
            this.LBL_Idioma.Size = new System.Drawing.Size(59, 13);
            this.LBL_Idioma.TabIndex = 1;
            this.LBL_Idioma.Text = "IDIOMAS";
            // 
            // BtnAgregarIdioma
            // 
            this.BtnAgregarIdioma.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnAgregarIdioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregarIdioma.Location = new System.Drawing.Point(12, 226);
            this.BtnAgregarIdioma.Name = "BtnAgregarIdioma";
            this.BtnAgregarIdioma.Size = new System.Drawing.Size(90, 33);
            this.BtnAgregarIdioma.TabIndex = 2;
            this.BtnAgregarIdioma.Text = "AGREGAR";
            this.BtnAgregarIdioma.UseVisualStyleBackColor = false;
            this.BtnAgregarIdioma.Click += new System.EventHandler(this.BtnAgregarIdioma_Click);
            // 
            // BtnEliminarIdioma
            // 
            this.BtnEliminarIdioma.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnEliminarIdioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminarIdioma.Location = new System.Drawing.Point(108, 226);
            this.BtnEliminarIdioma.Name = "BtnEliminarIdioma";
            this.BtnEliminarIdioma.Size = new System.Drawing.Size(96, 33);
            this.BtnEliminarIdioma.TabIndex = 3;
            this.BtnEliminarIdioma.Text = "ELIMINAR";
            this.BtnEliminarIdioma.UseVisualStyleBackColor = false;
            this.BtnEliminarIdioma.Click += new System.EventHandler(this.BtnEliminarIdioma_Click);
            // 
            // BtnModificarIdioma
            // 
            this.BtnModificarIdioma.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnModificarIdioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificarIdioma.Location = new System.Drawing.Point(210, 226);
            this.BtnModificarIdioma.Name = "BtnModificarIdioma";
            this.BtnModificarIdioma.Size = new System.Drawing.Size(92, 33);
            this.BtnModificarIdioma.TabIndex = 4;
            this.BtnModificarIdioma.Text = "MODIFICAR";
            this.BtnModificarIdioma.UseVisualStyleBackColor = false;
            this.BtnModificarIdioma.Click += new System.EventHandler(this.BtnModificarIdioma_Click);
            // 
            // LBL_Traducciones
            // 
            this.LBL_Traducciones.AutoSize = true;
            this.LBL_Traducciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Traducciones.Location = new System.Drawing.Point(739, 9);
            this.LBL_Traducciones.Name = "LBL_Traducciones";
            this.LBL_Traducciones.Size = new System.Drawing.Size(104, 13);
            this.LBL_Traducciones.TabIndex = 6;
            this.LBL_Traducciones.Text = "TRADUCCIONES";
            // 
            // BtnModificarTraduccion
            // 
            this.BtnModificarTraduccion.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnModificarTraduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificarTraduccion.Location = new System.Drawing.Point(742, 431);
            this.BtnModificarTraduccion.Name = "BtnModificarTraduccion";
            this.BtnModificarTraduccion.Size = new System.Drawing.Size(101, 34);
            this.BtnModificarTraduccion.TabIndex = 16;
            this.BtnModificarTraduccion.Text = "MODIFICAR";
            this.BtnModificarTraduccion.UseVisualStyleBackColor = false;
            this.BtnModificarTraduccion.Click += new System.EventHandler(this.BtnModificarTraduccion_Click);
            // 
            // DgvTraducciones
            // 
            this.DgvTraducciones.AllowUserToAddRows = false;
            this.DgvTraducciones.AllowUserToDeleteRows = false;
            this.DgvTraducciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvTraducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTraducciones.Location = new System.Drawing.Point(355, 25);
            this.DgvTraducciones.Name = "DgvTraducciones";
            this.DgvTraducciones.Size = new System.Drawing.Size(875, 401);
            this.DgvTraducciones.TabIndex = 19;
            this.DgvTraducciones.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTraducciones_CellValueChanged);
            // 
            // GUIIdiomas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1242, 477);
            this.Controls.Add(this.DgvTraducciones);
            this.Controls.Add(this.BtnModificarTraduccion);
            this.Controls.Add(this.LBL_Traducciones);
            this.Controls.Add(this.BtnModificarIdioma);
            this.Controls.Add(this.BtnEliminarIdioma);
            this.Controls.Add(this.BtnAgregarIdioma);
            this.Controls.Add(this.LBL_Idioma);
            this.Controls.Add(this.DgvIdiomas);
            this.Name = "GUIIdiomas";
            this.Text = "GUIIdiomas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GUIIdiomas_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.DgvIdiomas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTraducciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvIdiomas;
        private System.Windows.Forms.Label LBL_Idioma;
        private System.Windows.Forms.Button BtnAgregarIdioma;
        private System.Windows.Forms.Button BtnEliminarIdioma;
        private System.Windows.Forms.Button BtnModificarIdioma;
        private System.Windows.Forms.Label LBL_Traducciones;
        private System.Windows.Forms.Button BtnModificarTraduccion;
        private System.Windows.Forms.DataGridView DgvTraducciones;
    }
}