namespace SIVEDI
{
    partial class LoginForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.chkVentanas = new System.Windows.Forms.CheckBox();
            this.chkAyudaEnLinea = new System.Windows.Forms.CheckBox();
            this.trmActualizaConexiones = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.Location = new System.Drawing.Point(92, 4);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(220, 23);
            this.UsernameLabel.TabIndex = 0;
            this.UsernameLabel.Text = "&Nombre de usuario";
            this.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Location = new System.Drawing.Point(92, 47);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(220, 23);
            this.PasswordLabel.TabIndex = 2;
            this.PasswordLabel.Text = "&Contraseña";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(94, 26);
            this.UsernameTextBox.MaxLength = 20;
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(220, 20);
            this.UsernameTextBox.TabIndex = 1;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(94, 68);
            this.PasswordTextBox.MaxLength = 15;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(220, 20);
            this.PasswordTextBox.TabIndex = 3;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(117, 135);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(94, 23);
            this.OK.TabIndex = 8;
            this.OK.Text = "&Aceptar";
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(220, 135);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(94, 23);
            this.Cancel.TabIndex = 9;
            this.Cancel.Text = "&Cancelar";
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // chkVentanas
            // 
            this.chkVentanas.AutoSize = true;
            this.chkVentanas.Checked = true;
            this.chkVentanas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVentanas.Location = new System.Drawing.Point(95, 117);
            this.chkVentanas.Name = "chkVentanas";
            this.chkVentanas.Size = new System.Drawing.Size(126, 17);
            this.chkVentanas.TabIndex = 7;
            this.chkVentanas.Text = "&Ventanas Embebidas";
            this.chkVentanas.UseVisualStyleBackColor = true;
            // 
            // chkAyudaEnLinea
            // 
            this.chkAyudaEnLinea.AutoSize = true;
            this.chkAyudaEnLinea.Checked = true;
            this.chkAyudaEnLinea.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAyudaEnLinea.Location = new System.Drawing.Point(95, 98);
            this.chkAyudaEnLinea.Name = "chkAyudaEnLinea";
            this.chkAyudaEnLinea.Size = new System.Drawing.Size(102, 17);
            this.chkAyudaEnLinea.TabIndex = 6;
            this.chkAyudaEnLinea.Text = "A&yuda en Línea";
            this.chkAyudaEnLinea.UseVisualStyleBackColor = true;
            // 
            // trmActualizaConexiones
            // 
            this.trmActualizaConexiones.Interval = 5000;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(440, 179);
            this.Controls.Add(this.chkVentanas);
            this.Controls.Add(this.chkAyudaEnLinea);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".:. SIVEDI CRM .:.";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.CheckBox chkVentanas;
        private System.Windows.Forms.CheckBox chkAyudaEnLinea;
        private System.Windows.Forms.Timer trmActualizaConexiones;
    }
}

