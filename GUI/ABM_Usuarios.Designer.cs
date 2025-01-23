namespace GUI
{
    partial class ABM_Usuarios
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
            this.BtnAgregarUsuario = new System.Windows.Forms.Button();
            this.BtnBajaUsuario = new System.Windows.Forms.Button();
            this.BtnModificarUsuario = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TxtNombreUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnHabilitarUsuario = new System.Windows.Forms.Button();
            this.TxtMail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtContraseña = new System.Windows.Forms.TextBox();
            this.TxtFechaNacimiento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtTelefonoUsuario = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnAgregarUsuario
            // 
            this.BtnAgregarUsuario.BackColor = System.Drawing.Color.OliveDrab;
            this.BtnAgregarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregarUsuario.Location = new System.Drawing.Point(12, 17);
            this.BtnAgregarUsuario.Name = "BtnAgregarUsuario";
            this.BtnAgregarUsuario.Size = new System.Drawing.Size(107, 38);
            this.BtnAgregarUsuario.TabIndex = 0;
            this.BtnAgregarUsuario.Text = "NUEVO";
            this.BtnAgregarUsuario.UseVisualStyleBackColor = false;
            this.BtnAgregarUsuario.Click += new System.EventHandler(this.BtnAgregarUsuario_Click);
            // 
            // BtnBajaUsuario
            // 
            this.BtnBajaUsuario.BackColor = System.Drawing.Color.IndianRed;
            this.BtnBajaUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBajaUsuario.Location = new System.Drawing.Point(265, 17);
            this.BtnBajaUsuario.Name = "BtnBajaUsuario";
            this.BtnBajaUsuario.Size = new System.Drawing.Size(107, 38);
            this.BtnBajaUsuario.TabIndex = 1;
            this.BtnBajaUsuario.Text = "DESHABILITAR";
            this.BtnBajaUsuario.UseVisualStyleBackColor = false;
            // 
            // BtnModificarUsuario
            // 
            this.BtnModificarUsuario.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnModificarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificarUsuario.Location = new System.Drawing.Point(399, 17);
            this.BtnModificarUsuario.Name = "BtnModificarUsuario";
            this.BtnModificarUsuario.Size = new System.Drawing.Size(107, 38);
            this.BtnModificarUsuario.TabIndex = 2;
            this.BtnModificarUsuario.Text = "MODIFICAR";
            this.BtnModificarUsuario.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(494, 333);
            this.dataGridView1.TabIndex = 3;
            // 
            // TxtNombreUsuario
            // 
            this.TxtNombreUsuario.Location = new System.Drawing.Point(538, 149);
            this.TxtNombreUsuario.Name = "TxtNombreUsuario";
            this.TxtNombreUsuario.Size = new System.Drawing.Size(281, 20);
            this.TxtNombreUsuario.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(535, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nombre de usuario";
            // 
            // BtnHabilitarUsuario
            // 
            this.BtnHabilitarUsuario.BackColor = System.Drawing.Color.Yellow;
            this.BtnHabilitarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHabilitarUsuario.Location = new System.Drawing.Point(138, 17);
            this.BtnHabilitarUsuario.Name = "BtnHabilitarUsuario";
            this.BtnHabilitarUsuario.Size = new System.Drawing.Size(107, 38);
            this.BtnHabilitarUsuario.TabIndex = 6;
            this.BtnHabilitarUsuario.Text = "HABILITAR";
            this.BtnHabilitarUsuario.UseVisualStyleBackColor = false;
            // 
            // TxtMail
            // 
            this.TxtMail.Location = new System.Drawing.Point(538, 193);
            this.TxtMail.Name = "TxtMail";
            this.TxtMail.Size = new System.Drawing.Size(281, 20);
            this.TxtMail.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(535, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Correo electrónico";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(535, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Contraseña";
            // 
            // TxtContraseña
            // 
            this.TxtContraseña.Location = new System.Drawing.Point(538, 232);
            this.TxtContraseña.Name = "TxtContraseña";
            this.TxtContraseña.Size = new System.Drawing.Size(281, 20);
            this.TxtContraseña.TabIndex = 10;
            // 
            // TxtFechaNacimiento
            // 
            this.TxtFechaNacimiento.Location = new System.Drawing.Point(538, 270);
            this.TxtFechaNacimiento.Name = "TxtFechaNacimiento";
            this.TxtFechaNacimiento.Size = new System.Drawing.Size(281, 20);
            this.TxtFechaNacimiento.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(535, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Fecha de nacimiento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(535, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Teléfono";
            // 
            // TxtTelefonoUsuario
            // 
            this.TxtTelefonoUsuario.Location = new System.Drawing.Point(538, 307);
            this.TxtTelefonoUsuario.Name = "TxtTelefonoUsuario";
            this.TxtTelefonoUsuario.Size = new System.Drawing.Size(281, 20);
            this.TxtTelefonoUsuario.TabIndex = 13;
            // 
            // ABM_Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(960, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtTelefonoUsuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtFechaNacimiento);
            this.Controls.Add(this.TxtContraseña);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtMail);
            this.Controls.Add(this.BtnHabilitarUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtNombreUsuario);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BtnModificarUsuario);
            this.Controls.Add(this.BtnBajaUsuario);
            this.Controls.Add(this.BtnAgregarUsuario);
            this.Name = "ABM_Usuarios";
            this.Text = "ABM_Usuarios";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnAgregarUsuario;
        private System.Windows.Forms.Button BtnBajaUsuario;
        private System.Windows.Forms.Button BtnModificarUsuario;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox TxtNombreUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnHabilitarUsuario;
        private System.Windows.Forms.TextBox TxtMail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtContraseña;
        private System.Windows.Forms.TextBox TxtFechaNacimiento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtTelefonoUsuario;
    }
}