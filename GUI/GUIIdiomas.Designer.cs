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
            this.TxtBusqueda = new System.Windows.Forms.TextBox();
            this.LBL_Buscar = new System.Windows.Forms.Label();
            this.TxtTraduccion = new System.Windows.Forms.TextBox();
            this.LBL_Traduccion = new System.Windows.Forms.Label();
            this.DgvIdiomaActual = new System.Windows.Forms.DataGridView();
            this.DgvIdiomaSeleccionado = new System.Windows.Forms.DataGridView();
            this.LBL_IdiomaActual = new System.Windows.Forms.Label();
            this.LBL_IdiomaSeleccionado = new System.Windows.Forms.Label();
            this.LBL_Seleccion = new System.Windows.Forms.Label();
            this.BtnModificarTraduccion = new System.Windows.Forms.Button();
            this.CbIdiomas = new System.Windows.Forms.ComboBox();
            this.LBL_CB = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvIdiomas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvIdiomaActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvIdiomaSeleccionado)).BeginInit();
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
            this.DgvIdiomas.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvIdiomas_RowHeaderMouseClick);
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
            this.BtnAgregarIdioma.BackColor = System.Drawing.Color.OliveDrab;
            this.BtnAgregarIdioma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.BtnEliminarIdioma.BackColor = System.Drawing.Color.IndianRed;
            this.BtnEliminarIdioma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.BtnModificarIdioma.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnModificarIdioma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.LBL_Traducciones.Location = new System.Drawing.Point(523, 9);
            this.LBL_Traducciones.Name = "LBL_Traducciones";
            this.LBL_Traducciones.Size = new System.Drawing.Size(104, 13);
            this.LBL_Traducciones.TabIndex = 6;
            this.LBL_Traducciones.Text = "TRADUCCIONES";
            // 
            // TxtBusqueda
            // 
            this.TxtBusqueda.Location = new System.Drawing.Point(473, 445);
            this.TxtBusqueda.Name = "TxtBusqueda";
            this.TxtBusqueda.Size = new System.Drawing.Size(198, 20);
            this.TxtBusqueda.TabIndex = 7;
            this.TxtBusqueda.TextChanged += new System.EventHandler(this.TxtBusqueda_TextChanged);
            // 
            // LBL_Buscar
            // 
            this.LBL_Buscar.AutoSize = true;
            this.LBL_Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Buscar.Location = new System.Drawing.Point(541, 429);
            this.LBL_Buscar.Name = "LBL_Buscar";
            this.LBL_Buscar.Size = new System.Drawing.Size(57, 13);
            this.LBL_Buscar.TabIndex = 8;
            this.LBL_Buscar.Text = "BUSCAR";
            // 
            // TxtTraduccion
            // 
            this.TxtTraduccion.Location = new System.Drawing.Point(839, 25);
            this.TxtTraduccion.Multiline = true;
            this.TxtTraduccion.Name = "TxtTraduccion";
            this.TxtTraduccion.Size = new System.Drawing.Size(222, 322);
            this.TxtTraduccion.TabIndex = 9;
            this.TxtTraduccion.TextChanged += new System.EventHandler(this.TxtTraduccion_TextChanged);
            // 
            // LBL_Traduccion
            // 
            this.LBL_Traduccion.AutoSize = true;
            this.LBL_Traduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Traduccion.Location = new System.Drawing.Point(895, 9);
            this.LBL_Traduccion.Name = "LBL_Traduccion";
            this.LBL_Traduccion.Size = new System.Drawing.Size(88, 13);
            this.LBL_Traduccion.TabIndex = 10;
            this.LBL_Traduccion.Text = "TRADUCCIÓN";
            // 
            // DgvIdiomaActual
            // 
            this.DgvIdiomaActual.AllowUserToAddRows = false;
            this.DgvIdiomaActual.AllowUserToDeleteRows = false;
            this.DgvIdiomaActual.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvIdiomaActual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvIdiomaActual.Location = new System.Drawing.Point(326, 38);
            this.DgvIdiomaActual.Name = "DgvIdiomaActual";
            this.DgvIdiomaActual.ReadOnly = true;
            this.DgvIdiomaActual.Size = new System.Drawing.Size(240, 349);
            this.DgvIdiomaActual.TabIndex = 11;
            this.DgvIdiomaActual.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvIdiomaActual_RowHeaderMouseClick);
            // 
            // DgvIdiomaSeleccionado
            // 
            this.DgvIdiomaSeleccionado.AllowUserToAddRows = false;
            this.DgvIdiomaSeleccionado.AllowUserToDeleteRows = false;
            this.DgvIdiomaSeleccionado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvIdiomaSeleccionado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvIdiomaSeleccionado.Location = new System.Drawing.Point(572, 38);
            this.DgvIdiomaSeleccionado.Name = "DgvIdiomaSeleccionado";
            this.DgvIdiomaSeleccionado.ReadOnly = true;
            this.DgvIdiomaSeleccionado.Size = new System.Drawing.Size(240, 349);
            this.DgvIdiomaSeleccionado.TabIndex = 12;
            // 
            // LBL_IdiomaActual
            // 
            this.LBL_IdiomaActual.AutoSize = true;
            this.LBL_IdiomaActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_IdiomaActual.Location = new System.Drawing.Point(432, 22);
            this.LBL_IdiomaActual.Name = "LBL_IdiomaActual";
            this.LBL_IdiomaActual.Size = new System.Drawing.Size(41, 13);
            this.LBL_IdiomaActual.TabIndex = 13;
            this.LBL_IdiomaActual.Text = "label1";
            // 
            // LBL_IdiomaSeleccionado
            // 
            this.LBL_IdiomaSeleccionado.AutoSize = true;
            this.LBL_IdiomaSeleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_IdiomaSeleccionado.Location = new System.Drawing.Point(667, 22);
            this.LBL_IdiomaSeleccionado.Name = "LBL_IdiomaSeleccionado";
            this.LBL_IdiomaSeleccionado.Size = new System.Drawing.Size(41, 13);
            this.LBL_IdiomaSeleccionado.TabIndex = 14;
            this.LBL_IdiomaSeleccionado.Text = "label1";
            // 
            // LBL_Seleccion
            // 
            this.LBL_Seleccion.AutoSize = true;
            this.LBL_Seleccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Seleccion.Location = new System.Drawing.Point(323, 390);
            this.LBL_Seleccion.Name = "LBL_Seleccion";
            this.LBL_Seleccion.Size = new System.Drawing.Size(41, 13);
            this.LBL_Seleccion.TabIndex = 15;
            this.LBL_Seleccion.Text = "label1";
            // 
            // BtnModificarTraduccion
            // 
            this.BtnModificarTraduccion.BackColor = System.Drawing.Color.Yellow;
            this.BtnModificarTraduccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnModificarTraduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificarTraduccion.Location = new System.Drawing.Point(917, 353);
            this.BtnModificarTraduccion.Name = "BtnModificarTraduccion";
            this.BtnModificarTraduccion.Size = new System.Drawing.Size(85, 34);
            this.BtnModificarTraduccion.TabIndex = 16;
            this.BtnModificarTraduccion.Text = "MODIFICAR";
            this.BtnModificarTraduccion.UseVisualStyleBackColor = false;
            this.BtnModificarTraduccion.Click += new System.EventHandler(this.BtnModificarTraduccion_Click);
            // 
            // CbIdiomas
            // 
            this.CbIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbIdiomas.FormattingEnabled = true;
            this.CbIdiomas.Location = new System.Drawing.Point(1067, 25);
            this.CbIdiomas.Name = "CbIdiomas";
            this.CbIdiomas.Size = new System.Drawing.Size(121, 21);
            this.CbIdiomas.TabIndex = 17;
            // 
            // LBL_CB
            // 
            this.LBL_CB.AutoSize = true;
            this.LBL_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_CB.Location = new System.Drawing.Point(1067, 9);
            this.LBL_CB.Name = "LBL_CB";
            this.LBL_CB.Size = new System.Drawing.Size(41, 13);
            this.LBL_CB.TabIndex = 18;
            this.LBL_CB.Text = "label1";
            // 
            // GUIIdiomas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 477);
            this.Controls.Add(this.LBL_CB);
            this.Controls.Add(this.CbIdiomas);
            this.Controls.Add(this.BtnModificarTraduccion);
            this.Controls.Add(this.LBL_Seleccion);
            this.Controls.Add(this.LBL_IdiomaSeleccionado);
            this.Controls.Add(this.LBL_IdiomaActual);
            this.Controls.Add(this.DgvIdiomaSeleccionado);
            this.Controls.Add(this.DgvIdiomaActual);
            this.Controls.Add(this.LBL_Traduccion);
            this.Controls.Add(this.TxtTraduccion);
            this.Controls.Add(this.LBL_Buscar);
            this.Controls.Add(this.TxtBusqueda);
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
            ((System.ComponentModel.ISupportInitialize)(this.DgvIdiomaActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvIdiomaSeleccionado)).EndInit();
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
        private System.Windows.Forms.TextBox TxtBusqueda;
        private System.Windows.Forms.Label LBL_Buscar;
        private System.Windows.Forms.TextBox TxtTraduccion;
        private System.Windows.Forms.Label LBL_Traduccion;
        private System.Windows.Forms.DataGridView DgvIdiomaActual;
        private System.Windows.Forms.DataGridView DgvIdiomaSeleccionado;
        private System.Windows.Forms.Label LBL_IdiomaActual;
        private System.Windows.Forms.Label LBL_IdiomaSeleccionado;
        private System.Windows.Forms.Label LBL_Seleccion;
        private System.Windows.Forms.Button BtnModificarTraduccion;
        private System.Windows.Forms.ComboBox CbIdiomas;
        private System.Windows.Forms.Label LBL_CB;
    }
}