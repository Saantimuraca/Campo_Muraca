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
            this.SuspendLayout();
            // 
            // CbRolesGrupos
            // 
            this.CbRolesGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbRolesGrupos.FormattingEnabled = true;
            this.CbRolesGrupos.Location = new System.Drawing.Point(12, 36);
            this.CbRolesGrupos.Name = "CbRolesGrupos";
            this.CbRolesGrupos.Size = new System.Drawing.Size(126, 21);
            this.CbRolesGrupos.TabIndex = 0;
            this.CbRolesGrupos.SelectedIndexChanged += new System.EventHandler(this.CbRolesGrupos_SelectedIndexChanged);
            // 
            // LBLE_RolesGrupos
            // 
            this.LBLE_RolesGrupos.AutoSize = true;
            this.LBLE_RolesGrupos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLE_RolesGrupos.Location = new System.Drawing.Point(12, 20);
            this.LBLE_RolesGrupos.Name = "LBLE_RolesGrupos";
            this.LBLE_RolesGrupos.Size = new System.Drawing.Size(84, 13);
            this.LBLE_RolesGrupos.TabIndex = 1;
            this.LBLE_RolesGrupos.Text = "Roles y grupos";
            // 
            // BtnEliminarPermisosSeleccionados
            // 
            this.BtnEliminarPermisosSeleccionados.BackColor = System.Drawing.Color.IndianRed;
            this.BtnEliminarPermisosSeleccionados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminarPermisosSeleccionados.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminarPermisosSeleccionados.Location = new System.Drawing.Point(15, 63);
            this.BtnEliminarPermisosSeleccionados.Name = "BtnEliminarPermisosSeleccionados";
            this.BtnEliminarPermisosSeleccionados.Size = new System.Drawing.Size(123, 37);
            this.BtnEliminarPermisosSeleccionados.TabIndex = 2;
            this.BtnEliminarPermisosSeleccionados.Text = "ELIMINAR SELECCIONADO";
            this.BtnEliminarPermisosSeleccionados.UseVisualStyleBackColor = false;
            this.BtnEliminarPermisosSeleccionados.Click += new System.EventHandler(this.BtnEliminarPermisosSeleccionados_Click);
            // 
            // BtnModificarNombre
            // 
            this.BtnModificarNombre.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnModificarNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnModificarNombre.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificarNombre.Location = new System.Drawing.Point(15, 106);
            this.BtnModificarNombre.Name = "BtnModificarNombre";
            this.BtnModificarNombre.Size = new System.Drawing.Size(123, 37);
            this.BtnModificarNombre.TabIndex = 3;
            this.BtnModificarNombre.Text = "MODIFICAR NOMBRE";
            this.BtnModificarNombre.UseVisualStyleBackColor = false;
            this.BtnModificarNombre.Click += new System.EventHandler(this.BtnModificarNombre_Click);
            // 
            // BtnCrearRol
            // 
            this.BtnCrearRol.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnCrearRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCrearRol.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCrearRol.Location = new System.Drawing.Point(15, 290);
            this.BtnCrearRol.Name = "BtnCrearRol";
            this.BtnCrearRol.Size = new System.Drawing.Size(123, 31);
            this.BtnCrearRol.TabIndex = 4;
            this.BtnCrearRol.Tag = "Crear Rol";
            this.BtnCrearRol.Text = "CREAR ROL";
            this.BtnCrearRol.UseVisualStyleBackColor = false;
            this.BtnCrearRol.Click += new System.EventHandler(this.BtnCrearRol_Click);
            // 
            // BtnCrearGrupoPermisos
            // 
            this.BtnCrearGrupoPermisos.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnCrearGrupoPermisos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCrearGrupoPermisos.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCrearGrupoPermisos.Location = new System.Drawing.Point(15, 337);
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
            this.ListaPermisos.Location = new System.Drawing.Point(177, 36);
            this.ListaPermisos.Name = "ListaPermisos";
            this.ListaPermisos.Size = new System.Drawing.Size(235, 349);
            this.ListaPermisos.TabIndex = 6;
            // 
            // LBLE_ListaPermisos
            // 
            this.LBLE_ListaPermisos.AutoSize = true;
            this.LBLE_ListaPermisos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLE_ListaPermisos.Location = new System.Drawing.Point(174, 20);
            this.LBLE_ListaPermisos.Name = "LBLE_ListaPermisos";
            this.LBLE_ListaPermisos.Size = new System.Drawing.Size(97, 13);
            this.LBLE_ListaPermisos.TabIndex = 8;
            this.LBLE_ListaPermisos.Text = "Lista de permisos";
            // 
            // GestionRolesUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(455, 409);
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
    }
}