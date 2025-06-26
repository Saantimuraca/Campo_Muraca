namespace GUI
{
    partial class GestionRolesUsuarios
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
            this.CbRolesGrupos = new System.Windows.Forms.ComboBox();
            this.LBLE_RolesGrupos = new System.Windows.Forms.Label();
            this.BtnEliminarPermisosSeleccionados = new System.Windows.Forms.Button();
            this.BtnModificarNombre = new System.Windows.Forms.Button();
            this.BtnCrearRol = new System.Windows.Forms.Button();
            this.BtnCrearGrupoPermisos = new System.Windows.Forms.Button();
            this.ListaPermisos = new System.Windows.Forms.CheckedListBox();
            this.LBLE_ListaPermisos = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.LBLJerarquia = new System.Windows.Forms.Label();
            this.BtnModificarPermisos = new System.Windows.Forms.Button();
            this.BtnEliminarSeleccion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CbRolesGrupos
            // 
            this.CbRolesGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbRolesGrupos.FormattingEnabled = true;
            this.CbRolesGrupos.Location = new System.Drawing.Point(41, 36);
            this.CbRolesGrupos.Name = "CbRolesGrupos";
            this.CbRolesGrupos.Size = new System.Drawing.Size(238, 21);
            this.CbRolesGrupos.TabIndex = 0;
            this.CbRolesGrupos.SelectedIndexChanged += new System.EventHandler(this.CbRolesGrupos_SelectedIndexChanged);
            // 
            // LBLE_RolesGrupos
            // 
            this.LBLE_RolesGrupos.AutoSize = true;
            this.LBLE_RolesGrupos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLE_RolesGrupos.ForeColor = System.Drawing.Color.White;
            this.LBLE_RolesGrupos.Location = new System.Drawing.Point(116, 20);
            this.LBLE_RolesGrupos.Name = "LBLE_RolesGrupos";
            this.LBLE_RolesGrupos.Size = new System.Drawing.Size(84, 13);
            this.LBLE_RolesGrupos.TabIndex = 1;
            this.LBLE_RolesGrupos.Text = "Roles y grupos";
            // 
            // BtnEliminarPermisosSeleccionados
            // 
            this.BtnEliminarPermisosSeleccionados.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnEliminarPermisosSeleccionados.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminarPermisosSeleccionados.Location = new System.Drawing.Point(97, 70);
            this.BtnEliminarPermisosSeleccionados.Name = "BtnEliminarPermisosSeleccionados";
            this.BtnEliminarPermisosSeleccionados.Size = new System.Drawing.Size(123, 37);
            this.BtnEliminarPermisosSeleccionados.TabIndex = 2;
            this.BtnEliminarPermisosSeleccionados.Text = "🗑️";
            this.BtnEliminarPermisosSeleccionados.UseVisualStyleBackColor = false;
            this.BtnEliminarPermisosSeleccionados.Click += new System.EventHandler(this.BtnEliminarPermisosSeleccionados_Click);
            // 
            // BtnModificarNombre
            // 
            this.BtnModificarNombre.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnModificarNombre.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificarNombre.Location = new System.Drawing.Point(97, 113);
            this.BtnModificarNombre.Name = "BtnModificarNombre";
            this.BtnModificarNombre.Size = new System.Drawing.Size(123, 37);
            this.BtnModificarNombre.TabIndex = 3;
            this.BtnModificarNombre.Text = "✏️";
            this.BtnModificarNombre.UseVisualStyleBackColor = false;
            this.BtnModificarNombre.Click += new System.EventHandler(this.BtnModificarNombre_Click);
            // 
            // BtnCrearRol
            // 
            this.BtnCrearRol.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnCrearRol.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCrearRol.Location = new System.Drawing.Point(97, 276);
            this.BtnCrearRol.Name = "BtnCrearRol";
            this.BtnCrearRol.Size = new System.Drawing.Size(123, 36);
            this.BtnCrearRol.TabIndex = 4;
            this.BtnCrearRol.Tag = "Crear Rol";
            this.BtnCrearRol.Text = "CREAR ROL";
            this.BtnCrearRol.UseVisualStyleBackColor = false;
            this.BtnCrearRol.Click += new System.EventHandler(this.BtnCrearRol_Click);
            // 
            // BtnCrearGrupoPermisos
            // 
            this.BtnCrearGrupoPermisos.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnCrearGrupoPermisos.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCrearGrupoPermisos.Location = new System.Drawing.Point(97, 344);
            this.BtnCrearGrupoPermisos.Name = "BtnCrearGrupoPermisos";
            this.BtnCrearGrupoPermisos.Size = new System.Drawing.Size(123, 36);
            this.BtnCrearGrupoPermisos.TabIndex = 5;
            this.BtnCrearGrupoPermisos.Text = "CREAR GRUPO DE PERMISOS";
            this.BtnCrearGrupoPermisos.UseVisualStyleBackColor = false;
            this.BtnCrearGrupoPermisos.Click += new System.EventHandler(this.BtnCrearGrupoPermisos_Click);
            // 
            // ListaPermisos
            // 
            this.ListaPermisos.FormattingEnabled = true;
            this.ListaPermisos.Location = new System.Drawing.Point(323, 36);
            this.ListaPermisos.Name = "ListaPermisos";
            this.ListaPermisos.Size = new System.Drawing.Size(235, 349);
            this.ListaPermisos.TabIndex = 6;
            this.ListaPermisos.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListaPermisos_ItemCheck);
            this.ListaPermisos.SelectedIndexChanged += new System.EventHandler(this.ListaPermisos_SelectedIndexChanged);
            // 
            // LBLE_ListaPermisos
            // 
            this.LBLE_ListaPermisos.AutoSize = true;
            this.LBLE_ListaPermisos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLE_ListaPermisos.ForeColor = System.Drawing.Color.White;
            this.LBLE_ListaPermisos.Location = new System.Drawing.Point(320, 20);
            this.LBLE_ListaPermisos.Name = "LBLE_ListaPermisos";
            this.LBLE_ListaPermisos.Size = new System.Drawing.Size(97, 13);
            this.LBLE_ListaPermisos.TabIndex = 8;
            this.LBLE_ListaPermisos.Text = "Lista de permisos";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(613, 36);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(221, 349);
            this.treeView1.TabIndex = 9;
            // 
            // LBLJerarquia
            // 
            this.LBLJerarquia.AutoSize = true;
            this.LBLJerarquia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLJerarquia.ForeColor = System.Drawing.Color.White;
            this.LBLJerarquia.Location = new System.Drawing.Point(610, 20);
            this.LBLJerarquia.Name = "LBLJerarquia";
            this.LBLJerarquia.Size = new System.Drawing.Size(41, 13);
            this.LBLJerarquia.TabIndex = 10;
            this.LBLJerarquia.Text = "label1";
            // 
            // BtnModificarPermisos
            // 
            this.BtnModificarPermisos.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnModificarPermisos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificarPermisos.Location = new System.Drawing.Point(97, 156);
            this.BtnModificarPermisos.Name = "BtnModificarPermisos";
            this.BtnModificarPermisos.Size = new System.Drawing.Size(123, 37);
            this.BtnModificarPermisos.TabIndex = 11;
            this.BtnModificarPermisos.Text = "Modificar Permisos";
            this.BtnModificarPermisos.UseVisualStyleBackColor = false;
            this.BtnModificarPermisos.Click += new System.EventHandler(this.BtnModificarPermisos_Click);
            // 
            // BtnEliminarSeleccion
            // 
            this.BtnEliminarSeleccion.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnEliminarSeleccion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminarSeleccion.Location = new System.Drawing.Point(376, 391);
            this.BtnEliminarSeleccion.Name = "BtnEliminarSeleccion";
            this.BtnEliminarSeleccion.Size = new System.Drawing.Size(123, 37);
            this.BtnEliminarSeleccion.TabIndex = 12;
            this.BtnEliminarSeleccion.Text = "Eliminar Selección";
            this.BtnEliminarSeleccion.UseVisualStyleBackColor = false;
            this.BtnEliminarSeleccion.Click += new System.EventHandler(this.BtnEliminarSeleccion_Click);
            // 
            // GestionRolesUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(848, 433);
            this.Controls.Add(this.BtnEliminarSeleccion);
            this.Controls.Add(this.BtnModificarPermisos);
            this.Controls.Add(this.LBLJerarquia);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.LBLE_ListaPermisos);
            this.Controls.Add(this.ListaPermisos);
            this.Controls.Add(this.BtnCrearGrupoPermisos);
            this.Controls.Add(this.BtnCrearRol);
            this.Controls.Add(this.BtnModificarNombre);
            this.Controls.Add(this.BtnEliminarPermisosSeleccionados);
            this.Controls.Add(this.LBLE_RolesGrupos);
            this.Controls.Add(this.CbRolesGrupos);
            this.Name = "GestionRolesUsuarios";
            this.Text = "GestionRolesUsuarios";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GestionRolesUsuarios_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CbRolesGrupos;
        private System.Windows.Forms.Label LBLE_RolesGrupos;
        private System.Windows.Forms.Button BtnEliminarPermisosSeleccionados;
        private System.Windows.Forms.Button BtnModificarNombre;
        private System.Windows.Forms.Button BtnCrearRol;
        private System.Windows.Forms.Button BtnCrearGrupoPermisos;
        private System.Windows.Forms.CheckedListBox ListaPermisos;
        private System.Windows.Forms.Label LBLE_ListaPermisos;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label LBLJerarquia;
        private System.Windows.Forms.Button BtnModificarPermisos;
        private System.Windows.Forms.Button BtnEliminarSeleccion;
    }
}