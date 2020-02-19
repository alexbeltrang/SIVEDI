namespace SIVEDI.ListaPrecios
{
    partial class frmListaPrecios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.totCampos = new System.Windows.Forms.ToolTip(this.components);
            this.txtNombreLista = new System.Windows.Forms.TextBox();
            this.rbnActivo = new System.Windows.Forms.RadioButton();
            this.txtCodigoLista = new System.Windows.Forms.TextBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.rbnInactivo = new System.Windows.Forms.RadioButton();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbNoEstandar = new System.Windows.Forms.RadioButton();
            this.rdbSiEstandar = new System.Windows.Forms.RadioButton();
            this.cboCampaña = new System.Windows.Forms.ComboBox();
            this.pnlDatosPerfil = new System.Windows.Forms.Panel();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.dtgListaPrecios = new System.Windows.Forms.DataGridView();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.pnlDatosPerfil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaPrecios)).BeginInit();
            this.SuspendLayout();
            // 
            // totCampos
            // 
            this.totCampos.AutoPopDelay = 3000;
            this.totCampos.InitialDelay = 20;
            this.totCampos.IsBalloon = true;
            this.totCampos.ReshowDelay = 100;
            this.totCampos.ShowAlways = true;
            // 
            // txtNombreLista
            // 
            this.txtNombreLista.Location = new System.Drawing.Point(95, 34);
            this.txtNombreLista.MaxLength = 150;
            this.txtNombreLista.Name = "txtNombreLista";
            this.txtNombreLista.Size = new System.Drawing.Size(484, 20);
            this.txtNombreLista.TabIndex = 1;
            this.totCampos.SetToolTip(this.txtNombreLista, "Nombre de la Lista de Precios");
            // 
            // rbnActivo
            // 
            this.rbnActivo.AutoSize = true;
            this.rbnActivo.Location = new System.Drawing.Point(7, 10);
            this.rbnActivo.Name = "rbnActivo";
            this.rbnActivo.Size = new System.Drawing.Size(55, 17);
            this.rbnActivo.TabIndex = 7;
            this.rbnActivo.TabStop = true;
            this.rbnActivo.Text = "&Activo";
            this.totCampos.SetToolTip(this.rbnActivo, "Permite seleccionarlo o usarlo dentro del sistema");
            this.rbnActivo.UseVisualStyleBackColor = true;
            // 
            // txtCodigoLista
            // 
            this.txtCodigoLista.Location = new System.Drawing.Point(95, 8);
            this.txtCodigoLista.MaxLength = 20;
            this.txtCodigoLista.Name = "txtCodigoLista";
            this.txtCodigoLista.Size = new System.Drawing.Size(137, 20);
            this.txtCodigoLista.TabIndex = 0;
            this.totCampos.SetToolTip(this.txtCodigoLista, "Código que asigna el usuario a la Lista de Precios");
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.rbnInactivo);
            this.GroupBox1.Controls.Add(this.rbnActivo);
            this.GroupBox1.Location = new System.Drawing.Point(253, 86);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(136, 32);
            this.GroupBox1.TabIndex = 6;
            this.GroupBox1.TabStop = false;
            this.totCampos.SetToolTip(this.GroupBox1, "Estado de la lista d eprecios en  el sistema");
            // 
            // rbnInactivo
            // 
            this.rbnInactivo.AutoSize = true;
            this.rbnInactivo.Location = new System.Drawing.Point(68, 10);
            this.rbnInactivo.Name = "rbnInactivo";
            this.rbnInactivo.Size = new System.Drawing.Size(63, 17);
            this.rbnInactivo.TabIndex = 8;
            this.rbnInactivo.TabStop = true;
            this.rbnInactivo.Text = "&Inactivo";
            this.totCampos.SetToolTip(this.rbnInactivo, "Desactiva el seleccionarlo o usarlo dentro del sistema");
            this.rbnInactivo.UseVisualStyleBackColor = true;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.rdbNoEstandar);
            this.GroupBox2.Controls.Add(this.rdbSiEstandar);
            this.GroupBox2.Location = new System.Drawing.Point(95, 86);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(96, 32);
            this.GroupBox2.TabIndex = 3;
            this.GroupBox2.TabStop = false;
            this.totCampos.SetToolTip(this.GroupBox2, "Es una lista de precios estandar");
            // 
            // rdbNoEstandar
            // 
            this.rdbNoEstandar.AutoSize = true;
            this.rdbNoEstandar.Location = new System.Drawing.Point(47, 10);
            this.rdbNoEstandar.Name = "rdbNoEstandar";
            this.rdbNoEstandar.Size = new System.Drawing.Size(39, 17);
            this.rdbNoEstandar.TabIndex = 5;
            this.rdbNoEstandar.TabStop = true;
            this.rdbNoEstandar.Text = "&No";
            this.totCampos.SetToolTip(this.rdbNoEstandar, "Desactiva el seleccionarlo o usarlo dentro del sistema");
            this.rdbNoEstandar.UseVisualStyleBackColor = true;
            // 
            // rdbSiEstandar
            // 
            this.rdbSiEstandar.AutoSize = true;
            this.rdbSiEstandar.Location = new System.Drawing.Point(7, 10);
            this.rdbSiEstandar.Name = "rdbSiEstandar";
            this.rdbSiEstandar.Size = new System.Drawing.Size(34, 17);
            this.rdbSiEstandar.TabIndex = 4;
            this.rdbSiEstandar.TabStop = true;
            this.rdbSiEstandar.Text = "&Si";
            this.totCampos.SetToolTip(this.rdbSiEstandar, "Permite seleccionarlo o usarlo dentro del sistema");
            this.rdbSiEstandar.UseVisualStyleBackColor = true;
            // 
            // cboCampaña
            // 
            this.cboCampaña.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCampaña.FormattingEnabled = true;
            this.cboCampaña.Location = new System.Drawing.Point(95, 60);
            this.cboCampaña.Name = "cboCampaña";
            this.cboCampaña.Size = new System.Drawing.Size(203, 21);
            this.cboCampaña.TabIndex = 2;
            this.totCampos.SetToolTip(this.cboCampaña, "Campaña a la que pertenece la Lista de precios");
            // 
            // pnlDatosPerfil
            // 
            this.pnlDatosPerfil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatosPerfil.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDatosPerfil.Controls.Add(this.Label9);
            this.pnlDatosPerfil.Controls.Add(this.cboCampaña);
            this.pnlDatosPerfil.Controls.Add(this.Label5);
            this.pnlDatosPerfil.Controls.Add(this.GroupBox2);
            this.pnlDatosPerfil.Controls.Add(this.txtNombreLista);
            this.pnlDatosPerfil.Controls.Add(this.Label3);
            this.pnlDatosPerfil.Controls.Add(this.btnNuevo);
            this.pnlDatosPerfil.Controls.Add(this.btnGrabar);
            this.pnlDatosPerfil.Controls.Add(this.Label2);
            this.pnlDatosPerfil.Controls.Add(this.GroupBox1);
            this.pnlDatosPerfil.Controls.Add(this.txtCodigoLista);
            this.pnlDatosPerfil.Controls.Add(this.Label1);
            this.pnlDatosPerfil.Location = new System.Drawing.Point(8, 8);
            this.pnlDatosPerfil.Name = "pnlDatosPerfil";
            this.pnlDatosPerfil.Size = new System.Drawing.Size(617, 192);
            this.pnlDatosPerfil.TabIndex = 62;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(37, 63);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(52, 13);
            this.Label9.TabIndex = 74;
            this.Label9.Text = "Campaña";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(22, 98);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(67, 13);
            this.Label5.TabIndex = 64;
            this.Label5.Text = "Es Estandar:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(45, 37);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(44, 13);
            this.Label3.TabIndex = 60;
            this.Label3.Text = "Nombre";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(411, 144);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 10;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(330, 144);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 9;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(204, 99);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(43, 13);
            this.Label2.TabIndex = 57;
            this.Label2.Text = "Estado:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(24, 11);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(65, 13);
            this.Label1.TabIndex = 54;
            this.Label1.Text = "Código Lista";
            // 
            // dtgListaPrecios
            // 
            this.dtgListaPrecios.AllowUserToAddRows = false;
            this.dtgListaPrecios.AllowUserToDeleteRows = false;
            this.dtgListaPrecios.AllowUserToOrderColumns = true;
            this.dtgListaPrecios.AllowUserToResizeRows = false;
            this.dtgListaPrecios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgListaPrecios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgListaPrecios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgListaPrecios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgListaPrecios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgListaPrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgListaPrecios.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgListaPrecios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgListaPrecios.Location = new System.Drawing.Point(7, 206);
            this.dtgListaPrecios.MultiSelect = false;
            this.dtgListaPrecios.Name = "dtgListaPrecios";
            this.dtgListaPrecios.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgListaPrecios.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgListaPrecios.RowHeadersVisible = false;
            this.dtgListaPrecios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaPrecios.ShowEditingIcon = false;
            this.dtgListaPrecios.Size = new System.Drawing.Size(618, 274);
            this.dtgListaPrecios.TabIndex = 11;
            this.dtgListaPrecios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaPrecios_CellDoubleClick);
            // 
            // frmListaPrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 492);
            this.Controls.Add(this.pnlDatosPerfil);
            this.Controls.Add(this.dtgListaPrecios);
            this.Name = "frmListaPrecios";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración Lista Precios";
            this.Load += new System.EventHandler(this.frmListaPrecios_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.pnlDatosPerfil.ResumeLayout(false);
            this.pnlDatosPerfil.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaPrecios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip totCampos;
        private System.Windows.Forms.TextBox txtNombreLista;
        private System.Windows.Forms.RadioButton rbnActivo;
        private System.Windows.Forms.TextBox txtCodigoLista;
        private System.Windows.Forms.Panel pnlDatosPerfil;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.DataGridView dtgListaPrecios;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.RadioButton rdbNoEstandar;
        private System.Windows.Forms.RadioButton rdbSiEstandar;
        private System.Windows.Forms.RadioButton rbnInactivo;
        private System.Windows.Forms.Label Label9;
        private System.Windows.Forms.ComboBox cboCampaña;

    }
}