namespace GUI
{
    partial class Menu
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
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcion1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDeRolesYPermisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idiomasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Datos = new System.Windows.Forms.ToolStripMenuItem();
            this.Backup = new System.Windows.Forms.ToolStripMenuItem();
            this.respaldoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarPedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supervisarPedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cobrarPedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solicitudesDeReposiciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordenesDeCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnCerrarSesion = new System.Windows.Forms.Button();
            this.BtnCambiarContrasena = new System.Windows.Forms.Button();
            this.BtnCambiarIdioma = new System.Windows.Forms.Button();
            this.CbIdioma = new System.Windows.Forms.ComboBox();
            this.sueldosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(148, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "BIENVENIDO";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SlateBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcion1ToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.pedidosToolStripMenuItem,
            this.productosToolStripMenuItem,
            this.cajaToolStripMenuItem,
            this.sueldosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(687, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcion1ToolStripMenuItem
            // 
            this.opcion1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionDeUsuariosToolStripMenuItem,
            this.gestionDeRolesYPermisosToolStripMenuItem,
            this.bitacoraToolStripMenuItem,
            this.idiomasToolStripMenuItem,
            this.Datos});
            this.opcion1ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opcion1ToolStripMenuItem.Name = "opcion1ToolStripMenuItem";
            this.opcion1ToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.opcion1ToolStripMenuItem.Tag = "";
            this.opcion1ToolStripMenuItem.Text = "Administración";
            // 
            // gestionDeUsuariosToolStripMenuItem
            // 
            this.gestionDeUsuariosToolStripMenuItem.Name = "gestionDeUsuariosToolStripMenuItem";
            this.gestionDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.gestionDeUsuariosToolStripMenuItem.Tag = "ABM Usuario";
            this.gestionDeUsuariosToolStripMenuItem.Text = "Gestionar Usuarios";
            this.gestionDeUsuariosToolStripMenuItem.Click += new System.EventHandler(this.gestiónDeUsuariosToolStripMenuItem_Click);
            // 
            // gestionDeRolesYPermisosToolStripMenuItem
            // 
            this.gestionDeRolesYPermisosToolStripMenuItem.Name = "gestionDeRolesYPermisosToolStripMenuItem";
            this.gestionDeRolesYPermisosToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.gestionDeRolesYPermisosToolStripMenuItem.Tag = "Gestión de Roles y Permisos";
            this.gestionDeRolesYPermisosToolStripMenuItem.Text = "Gestión de Roles y Permisos";
            this.gestionDeRolesYPermisosToolStripMenuItem.Click += new System.EventHandler(this.gestiónDeRolesYPermisosToolStripMenuItem_Click);
            // 
            // bitacoraToolStripMenuItem
            // 
            this.bitacoraToolStripMenuItem.Name = "bitacoraToolStripMenuItem";
            this.bitacoraToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.bitacoraToolStripMenuItem.Tag = "Ver Bitácora";
            this.bitacoraToolStripMenuItem.Text = "Bitácora";
            this.bitacoraToolStripMenuItem.Click += new System.EventHandler(this.bitácoraToolStripMenuItem_Click);
            // 
            // idiomasToolStripMenuItem
            // 
            this.idiomasToolStripMenuItem.Name = "idiomasToolStripMenuItem";
            this.idiomasToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.idiomasToolStripMenuItem.Tag = "Administrar Idiomas";
            this.idiomasToolStripMenuItem.Text = "Idiomas";
            this.idiomasToolStripMenuItem.Click += new System.EventHandler(this.idiomasToolStripMenuItem_Click);
            // 
            // Datos
            // 
            this.Datos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Backup,
            this.respaldoToolStripMenuItem});
            this.Datos.Name = "Datos";
            this.Datos.Size = new System.Drawing.Size(229, 22);
            this.Datos.Tag = "Ingresar Datos";
            this.Datos.Text = "Datos";
            this.Datos.Click += new System.EventHandler(this.backUpToolStripMenuItem_Click);
            // 
            // Backup
            // 
            this.Backup.Name = "Backup";
            this.Backup.Size = new System.Drawing.Size(124, 22);
            this.Backup.Tag = "Hacer BackUp";
            this.Backup.Text = "Backup";
            this.Backup.Click += new System.EventHandler(this.Backup_Click);
            // 
            // respaldoToolStripMenuItem
            // 
            this.respaldoToolStripMenuItem.Name = "respaldoToolStripMenuItem";
            this.respaldoToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.respaldoToolStripMenuItem.Tag = "Hacer Respaldo";
            this.respaldoToolStripMenuItem.Text = "Respaldo";
            this.respaldoToolStripMenuItem.Click += new System.EventHandler(this.respaldoToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMClientesToolStripMenuItem});
            this.clientesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.clientesToolStripMenuItem.Tag = "";
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // aBMClientesToolStripMenuItem
            // 
            this.aBMClientesToolStripMenuItem.Name = "aBMClientesToolStripMenuItem";
            this.aBMClientesToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.aBMClientesToolStripMenuItem.Tag = "ABM Cliente";
            this.aBMClientesToolStripMenuItem.Text = "ABM Clientes";
            this.aBMClientesToolStripMenuItem.Click += new System.EventHandler(this.aBMClientesToolStripMenuItem_Click);
            // 
            // pedidosToolStripMenuItem
            // 
            this.pedidosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarPedidoToolStripMenuItem,
            this.supervisarPedidosToolStripMenuItem,
            this.cobrarPedidosToolStripMenuItem});
            this.pedidosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            this.pedidosToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.pedidosToolStripMenuItem.Tag = "";
            this.pedidosToolStripMenuItem.Text = "Pedidos";
            // 
            // registrarPedidoToolStripMenuItem
            // 
            this.registrarPedidoToolStripMenuItem.Name = "registrarPedidoToolStripMenuItem";
            this.registrarPedidoToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.registrarPedidoToolStripMenuItem.Tag = "Registrar Pedido";
            this.registrarPedidoToolStripMenuItem.Text = "Registrar pedido";
            this.registrarPedidoToolStripMenuItem.Click += new System.EventHandler(this.registrarPedidoToolStripMenuItem_Click);
            // 
            // supervisarPedidosToolStripMenuItem
            // 
            this.supervisarPedidosToolStripMenuItem.Name = "supervisarPedidosToolStripMenuItem";
            this.supervisarPedidosToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.supervisarPedidosToolStripMenuItem.Tag = "Supervisar Pedido";
            this.supervisarPedidosToolStripMenuItem.Text = "Supervisar pedidos";
            this.supervisarPedidosToolStripMenuItem.Click += new System.EventHandler(this.supervisarPedidosToolStripMenuItem_Click);
            // 
            // cobrarPedidosToolStripMenuItem
            // 
            this.cobrarPedidosToolStripMenuItem.Name = "cobrarPedidosToolStripMenuItem";
            this.cobrarPedidosToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.cobrarPedidosToolStripMenuItem.Tag = "Cobrar Pedido";
            this.cobrarPedidosToolStripMenuItem.Text = "Cobrar pedidos";
            this.cobrarPedidosToolStripMenuItem.Click += new System.EventHandler(this.cobrarPedidosToolStripMenuItem_Click);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMProductosToolStripMenuItem,
            this.solicitudesDeReposiciónToolStripMenuItem,
            this.ordenesDeCompraToolStripMenuItem});
            this.productosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.productosToolStripMenuItem.Tag = "";
            this.productosToolStripMenuItem.Text = "Productos";
            // 
            // aBMProductosToolStripMenuItem
            // 
            this.aBMProductosToolStripMenuItem.Name = "aBMProductosToolStripMenuItem";
            this.aBMProductosToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.aBMProductosToolStripMenuItem.Tag = "ABM Productos";
            this.aBMProductosToolStripMenuItem.Text = "ABM Productos";
            this.aBMProductosToolStripMenuItem.Click += new System.EventHandler(this.aBMProductosToolStripMenuItem_Click);
            // 
            // solicitudesDeReposiciónToolStripMenuItem
            // 
            this.solicitudesDeReposiciónToolStripMenuItem.Name = "solicitudesDeReposiciónToolStripMenuItem";
            this.solicitudesDeReposiciónToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.solicitudesDeReposiciónToolStripMenuItem.Tag = "Revisar Solicitudes de Reposición";
            this.solicitudesDeReposiciónToolStripMenuItem.Text = "Solicitudes de Reposición";
            this.solicitudesDeReposiciónToolStripMenuItem.Click += new System.EventHandler(this.solicitudesDeReposiciónToolStripMenuItem_Click);
            // 
            // ordenesDeCompraToolStripMenuItem
            // 
            this.ordenesDeCompraToolStripMenuItem.Name = "ordenesDeCompraToolStripMenuItem";
            this.ordenesDeCompraToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.ordenesDeCompraToolStripMenuItem.Tag = "Ver Ordenes de Compra";
            this.ordenesDeCompraToolStripMenuItem.Text = "Ordenes de Compra";
            this.ordenesDeCompraToolStripMenuItem.Click += new System.EventHandler(this.ordenesDeCompraToolStripMenuItem_Click);
            // 
            // cajaToolStripMenuItem
            // 
            this.cajaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cajaToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.cajaToolStripMenuItem.Name = "cajaToolStripMenuItem";
            this.cajaToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.cajaToolStripMenuItem.Tag = "Administrar Caja";
            this.cajaToolStripMenuItem.Text = "Caja";
            this.cajaToolStripMenuItem.Click += new System.EventHandler(this.cajaToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Idioma:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rol:";
            // 
            // BtnCerrarSesion
            // 
            this.BtnCerrarSesion.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCerrarSesion.Location = new System.Drawing.Point(571, 364);
            this.BtnCerrarSesion.Name = "BtnCerrarSesion";
            this.BtnCerrarSesion.Size = new System.Drawing.Size(97, 38);
            this.BtnCerrarSesion.TabIndex = 5;
            this.BtnCerrarSesion.Text = "CERRAR SESIÓN";
            this.BtnCerrarSesion.UseVisualStyleBackColor = false;
            this.BtnCerrarSesion.Click += new System.EventHandler(this.BtnCerrarSesion_Click);
            // 
            // BtnCambiarContrasena
            // 
            this.BtnCambiarContrasena.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnCambiarContrasena.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCambiarContrasena.Location = new System.Drawing.Point(571, 318);
            this.BtnCambiarContrasena.Name = "BtnCambiarContrasena";
            this.BtnCambiarContrasena.Size = new System.Drawing.Size(97, 40);
            this.BtnCambiarContrasena.TabIndex = 6;
            this.BtnCambiarContrasena.Text = "CAMBIAR CONTRASEÑA";
            this.BtnCambiarContrasena.UseVisualStyleBackColor = false;
            this.BtnCambiarContrasena.Click += new System.EventHandler(this.BtnCambiarContraseña_Click);
            // 
            // BtnCambiarIdioma
            // 
            this.BtnCambiarIdioma.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnCambiarIdioma.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCambiarIdioma.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnCambiarIdioma.Location = new System.Drawing.Point(578, 60);
            this.BtnCambiarIdioma.Name = "BtnCambiarIdioma";
            this.BtnCambiarIdioma.Size = new System.Drawing.Size(97, 40);
            this.BtnCambiarIdioma.TabIndex = 7;
            this.BtnCambiarIdioma.Text = "CAMBIAR IDIOMA";
            this.BtnCambiarIdioma.UseVisualStyleBackColor = false;
            this.BtnCambiarIdioma.Click += new System.EventHandler(this.BtnCambiarIdioma_Click);
            // 
            // CbIdioma
            // 
            this.CbIdioma.BackColor = System.Drawing.Color.White;
            this.CbIdioma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbIdioma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CbIdioma.FormattingEnabled = true;
            this.CbIdioma.Location = new System.Drawing.Point(578, 33);
            this.CbIdioma.Name = "CbIdioma";
            this.CbIdioma.Size = new System.Drawing.Size(97, 21);
            this.CbIdioma.TabIndex = 8;
            // 
            // sueldosToolStripMenuItem
            // 
            this.sueldosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sueldosToolStripMenuItem.Name = "sueldosToolStripMenuItem";
            this.sueldosToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.sueldosToolStripMenuItem.Text = "Sueldos";
            this.sueldosToolStripMenuItem.Click += new System.EventHandler(this.sueldosToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(687, 414);
            this.Controls.Add(this.CbIdioma);
            this.Controls.Add(this.BtnCambiarIdioma);
            this.Controls.Add(this.BtnCambiarContrasena);
            this.Controls.Add(this.BtnCerrarSesion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.Text = "Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_FormClosed);
            this.Load += new System.EventHandler(this.Menu_Load);
            this.Shown += new System.EventHandler(this.Menu_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcion1ToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnCerrarSesion;
        private System.Windows.Forms.Button BtnCambiarContrasena;
        private System.Windows.Forms.ToolStripMenuItem gestionDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDeRolesYPermisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitacoraToolStripMenuItem;
        private System.Windows.Forms.Button BtnCambiarIdioma;
        private System.Windows.Forms.ComboBox CbIdioma;
        private System.Windows.Forms.ToolStripMenuItem idiomasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Datos;
        private System.Windows.Forms.ToolStripMenuItem Backup;
        private System.Windows.Forms.ToolStripMenuItem respaldoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarPedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supervisarPedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cobrarPedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solicitudesDeReposiciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordenesDeCompraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sueldosToolStripMenuItem;
    }
}