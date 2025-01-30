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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnEliminarPermisosSeleccionados = new System.Windows.Forms.Button();
            this.BtnModificarNombre = new System.Windows.Forms.Button();
            this.BtnCrearRol = new System.Windows.Forms.Button();
            this.BtnCrearGrupoPermisos = new System.Windows.Forms.Button();
            this.ListaPermisos = new System.Windows.Forms.CheckedListBox();
            this.BtnGuardarCambios = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(126, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Roles y grupos";
            // 
            // BtnEliminarPermisosSeleccionados
            // 
            this.BtnEliminarPermisosSeleccionados.BackColor = System.Drawing.Color.IndianRed;
            this.BtnEliminarPermisosSeleccionados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminarPermisosSeleccionados.Location = new System.Drawing.Point(15, 63);
            this.BtnEliminarPermisosSeleccionados.Name = "BtnEliminarPermisosSeleccionados";
            this.BtnEliminarPermisosSeleccionados.Size = new System.Drawing.Size(123, 37);
            this.BtnEliminarPermisosSeleccionados.TabIndex = 2;
            this.BtnEliminarPermisosSeleccionados.Text = "ELIMINAR SELECCIONADOS";
            this.BtnEliminarPermisosSeleccionados.UseVisualStyleBackColor = false;
            // 
            // BtnModificarNombre
            // 
            this.BtnModificarNombre.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnModificarNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificarNombre.Location = new System.Drawing.Point(15, 106);
            this.BtnModificarNombre.Name = "BtnModificarNombre";
            this.BtnModificarNombre.Size = new System.Drawing.Size(123, 37);
            this.BtnModificarNombre.TabIndex = 3;
            this.BtnModificarNombre.Text = "MODIFICAR NOMBRE";
            this.BtnModificarNombre.UseVisualStyleBackColor = false;
            // 
            // BtnCrearRol
            // 
            this.BtnCrearRol.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnCrearRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCrearRol.Location = new System.Drawing.Point(15, 252);
            this.BtnCrearRol.Name = "BtnCrearRol";
            this.BtnCrearRol.Size = new System.Drawing.Size(123, 31);
            this.BtnCrearRol.TabIndex = 4;
            this.BtnCrearRol.Tag = "Crear Rol";
            this.BtnCrearRol.Text = "CREAR ROL";
            this.BtnCrearRol.UseVisualStyleBackColor = false;
            // 
            // BtnCrearGrupoPermisos
            // 
            this.BtnCrearGrupoPermisos.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnCrearGrupoPermisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCrearGrupoPermisos.Location = new System.Drawing.Point(15, 299);
            this.BtnCrearGrupoPermisos.Name = "BtnCrearGrupoPermisos";
            this.BtnCrearGrupoPermisos.Size = new System.Drawing.Size(123, 36);
            this.BtnCrearGrupoPermisos.TabIndex = 5;
            this.BtnCrearGrupoPermisos.Text = "CREAR GRUPO DE PERMISOS";
            this.BtnCrearGrupoPermisos.UseVisualStyleBackColor = false;
            // 
            // ListaPermisos
            // 
            this.ListaPermisos.FormattingEnabled = true;
            this.ListaPermisos.Location = new System.Drawing.Point(177, 36);
            this.ListaPermisos.Name = "ListaPermisos";
            this.ListaPermisos.Size = new System.Drawing.Size(235, 349);
            this.ListaPermisos.TabIndex = 6;
            // 
            // BtnGuardarCambios
            // 
            this.BtnGuardarCambios.BackColor = System.Drawing.Color.Gold;
            this.BtnGuardarCambios.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardarCambios.Location = new System.Drawing.Point(239, 403);
            this.BtnGuardarCambios.Name = "BtnGuardarCambios";
            this.BtnGuardarCambios.Size = new System.Drawing.Size(104, 36);
            this.BtnGuardarCambios.TabIndex = 7;
            this.BtnGuardarCambios.Text = "GUARDAR CAMBIOS";
            this.BtnGuardarCambios.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(174, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Lista de permisos";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(468, 36);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(271, 349);
            this.treeView1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(465, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Vista";
            // 
            // GestionRolesUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnGuardarCambios);
            this.Controls.Add(this.ListaPermisos);
            this.Controls.Add(this.BtnCrearGrupoPermisos);
            this.Controls.Add(this.BtnCrearRol);
            this.Controls.Add(this.BtnModificarNombre);
            this.Controls.Add(this.BtnEliminarPermisosSeleccionados);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "GestionRolesUsuarios";
            this.Text = "GestionRolesUsuarios";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnEliminarPermisosSeleccionados;
        private System.Windows.Forms.Button BtnModificarNombre;
        private System.Windows.Forms.Button BtnCrearRol;
        private System.Windows.Forms.Button BtnCrearGrupoPermisos;
        private System.Windows.Forms.CheckedListBox ListaPermisos;
        private System.Windows.Forms.Button BtnGuardarCambios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label3;
    }
}