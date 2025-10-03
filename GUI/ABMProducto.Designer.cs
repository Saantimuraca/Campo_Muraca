namespace GUI
{
    partial class ABMProducto
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
            this.Dgv = new System.Windows.Forms.DataGridView();
            this.LblNombreProducto = new System.Windows.Forms.Label();
            this.TxtProducto = new System.Windows.Forms.TextBox();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.LblDescripcion = new System.Windows.Forms.Label();
            this.ErrorNombre = new System.Windows.Forms.Label();
            this.ErrorIdioma = new System.Windows.Forms.Label();
            this.ErrorPrecio = new System.Windows.Forms.Label();
            this.TxtPrecio = new System.Windows.Forms.TextBox();
            this.LblPrecio = new System.Windows.Forms.Label();
            this.LblStock = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.LblCategoria = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ErrorRol = new System.Windows.Forms.Label();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnCambiarEstadoProducto = new System.Windows.Forms.Button();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnActualizarStock = new System.Windows.Forms.Button();
            this.BtnEliminarSeleccion = new System.Windows.Forms.Button();
            this.RbInactivos = new System.Windows.Forms.RadioButton();
            this.RbActivos = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.BtnSolicitarReposición = new System.Windows.Forms.Button();
            this.TxtStockActualizado = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LblStockActualizado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // Dgv
            // 
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Location = new System.Drawing.Point(301, 58);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            this.Dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(846, 540);
            this.Dgv.TabIndex = 0;
            this.Dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_CellContentClick);
            this.Dgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Dgv_CellMouseClick);
            this.Dgv.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Dgv_CellMouseDoubleClick);
            this.Dgv.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Dgv_DataBindingComplete);
            // 
            // LblNombreProducto
            // 
            this.LblNombreProducto.AutoSize = true;
            this.LblNombreProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LblNombreProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombreProducto.ForeColor = System.Drawing.Color.White;
            this.LblNombreProducto.Location = new System.Drawing.Point(1153, 68);
            this.LblNombreProducto.Name = "LblNombreProducto";
            this.LblNombreProducto.Size = new System.Drawing.Size(58, 13);
            this.LblNombreProducto.TabIndex = 1;
            this.LblNombreProducto.Text = "Producto";
            // 
            // TxtProducto
            // 
            this.TxtProducto.Location = new System.Drawing.Point(1153, 84);
            this.TxtProducto.Name = "TxtProducto";
            this.TxtProducto.Size = new System.Drawing.Size(177, 20);
            this.TxtProducto.TabIndex = 2;
            this.TxtProducto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtProducto_KeyUp);
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Location = new System.Drawing.Point(1156, 160);
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(319, 192);
            this.TxtDescripcion.TabIndex = 4;
            this.TxtDescripcion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtDescripcion_KeyUp);
            // 
            // LblDescripcion
            // 
            this.LblDescripcion.AutoSize = true;
            this.LblDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDescripcion.ForeColor = System.Drawing.Color.White;
            this.LblDescripcion.Location = new System.Drawing.Point(1153, 142);
            this.LblDescripcion.Name = "LblDescripcion";
            this.LblDescripcion.Size = new System.Drawing.Size(74, 13);
            this.LblDescripcion.TabIndex = 3;
            this.LblDescripcion.Text = "Descripción";
            // 
            // ErrorNombre
            // 
            this.ErrorNombre.AutoSize = true;
            this.ErrorNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorNombre.ForeColor = System.Drawing.Color.Red;
            this.ErrorNombre.Location = new System.Drawing.Point(1153, 107);
            this.ErrorNombre.Name = "ErrorNombre";
            this.ErrorNombre.Size = new System.Drawing.Size(110, 13);
            this.ErrorNombre.TabIndex = 5;
            this.ErrorNombre.Text = "Campo Obligatorio";
            // 
            // ErrorIdioma
            // 
            this.ErrorIdioma.AutoSize = true;
            this.ErrorIdioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorIdioma.ForeColor = System.Drawing.Color.Red;
            this.ErrorIdioma.Location = new System.Drawing.Point(1153, 355);
            this.ErrorIdioma.Name = "ErrorIdioma";
            this.ErrorIdioma.Size = new System.Drawing.Size(110, 13);
            this.ErrorIdioma.TabIndex = 6;
            this.ErrorIdioma.Text = "Campo Obligatorio";
            this.ErrorIdioma.Click += new System.EventHandler(this.ErrorIdioma_Click);
            // 
            // ErrorPrecio
            // 
            this.ErrorPrecio.AutoSize = true;
            this.ErrorPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorPrecio.ForeColor = System.Drawing.Color.Red;
            this.ErrorPrecio.Location = new System.Drawing.Point(1153, 431);
            this.ErrorPrecio.Name = "ErrorPrecio";
            this.ErrorPrecio.Size = new System.Drawing.Size(91, 13);
            this.ErrorPrecio.TabIndex = 9;
            this.ErrorPrecio.Text = "Precio inválido";
            // 
            // TxtPrecio
            // 
            this.TxtPrecio.Location = new System.Drawing.Point(1153, 408);
            this.TxtPrecio.Name = "TxtPrecio";
            this.TxtPrecio.Size = new System.Drawing.Size(140, 20);
            this.TxtPrecio.TabIndex = 8;
            this.TxtPrecio.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtPrecio_KeyUp);
            // 
            // LblPrecio
            // 
            this.LblPrecio.AutoSize = true;
            this.LblPrecio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPrecio.ForeColor = System.Drawing.Color.White;
            this.LblPrecio.Location = new System.Drawing.Point(1153, 392);
            this.LblPrecio.Name = "LblPrecio";
            this.LblPrecio.Size = new System.Drawing.Size(43, 13);
            this.LblPrecio.TabIndex = 7;
            this.LblPrecio.Text = "Precio";
            // 
            // LblStock
            // 
            this.LblStock.AutoSize = true;
            this.LblStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LblStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStock.ForeColor = System.Drawing.Color.White;
            this.LblStock.Location = new System.Drawing.Point(1153, 472);
            this.LblStock.Name = "LblStock";
            this.LblStock.Size = new System.Drawing.Size(40, 13);
            this.LblStock.TabIndex = 10;
            this.LblStock.Text = "Stock";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(1156, 488);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            300000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(110, 20);
            this.numericUpDown1.TabIndex = 11;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // LblCategoria
            // 
            this.LblCategoria.AutoSize = true;
            this.LblCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LblCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCategoria.ForeColor = System.Drawing.Color.White;
            this.LblCategoria.Location = new System.Drawing.Point(1153, 547);
            this.LblCategoria.Name = "LblCategoria";
            this.LblCategoria.Size = new System.Drawing.Size(61, 13);
            this.LblCategoria.TabIndex = 13;
            this.LblCategoria.Text = "Categoria";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1153, 563);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(140, 21);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ErrorRol
            // 
            this.ErrorRol.AutoSize = true;
            this.ErrorRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorRol.ForeColor = System.Drawing.Color.Red;
            this.ErrorRol.Location = new System.Drawing.Point(1153, 587);
            this.ErrorRol.Name = "ErrorRol";
            this.ErrorRol.Size = new System.Drawing.Size(128, 13);
            this.ErrorRol.TabIndex = 15;
            this.ErrorRol.Text = "Selección Obligatoria";
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.Location = new System.Drawing.Point(301, 22);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(90, 30);
            this.BtnAgregar.TabIndex = 16;
            this.BtnAgregar.Tag = "";
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = false;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnCambiarEstadoProducto
            // 
            this.BtnCambiarEstadoProducto.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnCambiarEstadoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCambiarEstadoProducto.Location = new System.Drawing.Point(682, 22);
            this.BtnCambiarEstadoProducto.Name = "BtnCambiarEstadoProducto";
            this.BtnCambiarEstadoProducto.Size = new System.Drawing.Size(90, 30);
            this.BtnCambiarEstadoProducto.TabIndex = 17;
            this.BtnCambiarEstadoProducto.Tag = "";
            this.BtnCambiarEstadoProducto.Text = "Deshabilitar";
            this.BtnCambiarEstadoProducto.UseVisualStyleBackColor = false;
            this.BtnCambiarEstadoProducto.Click += new System.EventHandler(this.BtnCambiarEstadoCliente_Click);
            // 
            // BtnModificar
            // 
            this.BtnModificar.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificar.Location = new System.Drawing.Point(1057, 22);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(90, 30);
            this.BtnModificar.TabIndex = 18;
            this.BtnModificar.Tag = "";
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = false;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // BtnActualizarStock
            // 
            this.BtnActualizarStock.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnActualizarStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualizarStock.Location = new System.Drawing.Point(593, 604);
            this.BtnActualizarStock.Name = "BtnActualizarStock";
            this.BtnActualizarStock.Size = new System.Drawing.Size(103, 40);
            this.BtnActualizarStock.TabIndex = 19;
            this.BtnActualizarStock.Tag = "";
            this.BtnActualizarStock.Text = "Actualizar stock";
            this.BtnActualizarStock.UseVisualStyleBackColor = false;
            this.BtnActualizarStock.Click += new System.EventHandler(this.BtnActualizarStock_Click);
            // 
            // BtnEliminarSeleccion
            // 
            this.BtnEliminarSeleccion.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnEliminarSeleccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminarSeleccion.Location = new System.Drawing.Point(1401, 17);
            this.BtnEliminarSeleccion.Name = "BtnEliminarSeleccion";
            this.BtnEliminarSeleccion.Size = new System.Drawing.Size(103, 40);
            this.BtnEliminarSeleccion.TabIndex = 20;
            this.BtnEliminarSeleccion.Tag = "";
            this.BtnEliminarSeleccion.Text = "Eliminar selección";
            this.BtnEliminarSeleccion.UseVisualStyleBackColor = false;
            this.BtnEliminarSeleccion.Click += new System.EventHandler(this.BtnEliminarSeleccion_Click);
            // 
            // RbInactivos
            // 
            this.RbInactivos.AutoSize = true;
            this.RbInactivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RbInactivos.ForeColor = System.Drawing.Color.White;
            this.RbInactivos.Location = new System.Drawing.Point(1273, 35);
            this.RbInactivos.Name = "RbInactivos";
            this.RbInactivos.Size = new System.Drawing.Size(77, 17);
            this.RbInactivos.TabIndex = 22;
            this.RbInactivos.TabStop = true;
            this.RbInactivos.Text = "Inactivos";
            this.RbInactivos.UseVisualStyleBackColor = true;
            this.RbInactivos.CheckedChanged += new System.EventHandler(this.RbInactivos_CheckedChanged);
            // 
            // RbActivos
            // 
            this.RbActivos.AutoSize = true;
            this.RbActivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RbActivos.ForeColor = System.Drawing.Color.White;
            this.RbActivos.Location = new System.Drawing.Point(1200, 35);
            this.RbActivos.Name = "RbActivos";
            this.RbActivos.Size = new System.Drawing.Size(67, 17);
            this.RbActivos.TabIndex = 21;
            this.RbActivos.TabStop = true;
            this.RbActivos.Text = "Activos";
            this.RbActivos.UseVisualStyleBackColor = true;
            this.RbActivos.CheckedChanged += new System.EventHandler(this.RbActivos_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(148, 58);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(147, 17);
            this.checkBox1.TabIndex = 23;
            this.checkBox1.Text = "Reposicion Aprobada";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // BtnSolicitarReposición
            // 
            this.BtnSolicitarReposición.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnSolicitarReposición.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSolicitarReposición.Location = new System.Drawing.Point(767, 604);
            this.BtnSolicitarReposición.Name = "BtnSolicitarReposición";
            this.BtnSolicitarReposición.Size = new System.Drawing.Size(103, 40);
            this.BtnSolicitarReposición.TabIndex = 24;
            this.BtnSolicitarReposición.Tag = "";
            this.BtnSolicitarReposición.Text = "Solicitar reposición";
            this.BtnSolicitarReposición.UseVisualStyleBackColor = false;
            this.BtnSolicitarReposición.Click += new System.EventHandler(this.BtnSolicitarReposición_Click);
            // 
            // TxtStockActualizado
            // 
            this.TxtStockActualizado.Location = new System.Drawing.Point(18, 189);
            this.TxtStockActualizado.Multiline = true;
            this.TxtStockActualizado.Name = "TxtStockActualizado";
            this.TxtStockActualizado.Size = new System.Drawing.Size(247, 261);
            this.TxtStockActualizado.TabIndex = 25;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // LblStockActualizado
            // 
            this.LblStockActualizado.AutoSize = true;
            this.LblStockActualizado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LblStockActualizado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStockActualizado.ForeColor = System.Drawing.Color.White;
            this.LblStockActualizado.Location = new System.Drawing.Point(15, 173);
            this.LblStockActualizado.Name = "LblStockActualizado";
            this.LblStockActualizado.Size = new System.Drawing.Size(144, 13);
            this.LblStockActualizado.TabIndex = 27;
            this.LblStockActualizado.Text = "Se actualizó el stock de";
            // 
            // ABMProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1518, 649);
            this.Controls.Add(this.LblStockActualizado);
            this.Controls.Add(this.TxtStockActualizado);
            this.Controls.Add(this.BtnSolicitarReposición);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.RbInactivos);
            this.Controls.Add(this.RbActivos);
            this.Controls.Add(this.BtnEliminarSeleccion);
            this.Controls.Add(this.BtnActualizarStock);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.BtnCambiarEstadoProducto);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.ErrorRol);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.LblCategoria);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.LblStock);
            this.Controls.Add(this.ErrorPrecio);
            this.Controls.Add(this.TxtPrecio);
            this.Controls.Add(this.LblPrecio);
            this.Controls.Add(this.ErrorIdioma);
            this.Controls.Add(this.ErrorNombre);
            this.Controls.Add(this.TxtDescripcion);
            this.Controls.Add(this.LblDescripcion);
            this.Controls.Add(this.TxtProducto);
            this.Controls.Add(this.LblNombreProducto);
            this.Controls.Add(this.Dgv);
            this.Name = "ABMProducto";
            this.Text = "ABMProducto";
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Dgv;
        private System.Windows.Forms.Label LblNombreProducto;
        private System.Windows.Forms.TextBox TxtProducto;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Label LblDescripcion;
        private System.Windows.Forms.Label ErrorNombre;
        private System.Windows.Forms.Label ErrorIdioma;
        private System.Windows.Forms.Label ErrorPrecio;
        private System.Windows.Forms.TextBox TxtPrecio;
        private System.Windows.Forms.Label LblPrecio;
        private System.Windows.Forms.Label LblStock;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label LblCategoria;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label ErrorRol;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Button BtnCambiarEstadoProducto;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnActualizarStock;
        private System.Windows.Forms.Button BtnEliminarSeleccion;
        private System.Windows.Forms.RadioButton RbInactivos;
        private System.Windows.Forms.RadioButton RbActivos;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button BtnSolicitarReposición;
        private System.Windows.Forms.TextBox TxtStockActualizado;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label LblStockActualizado;
    }
}