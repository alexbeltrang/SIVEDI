namespace SIVEDI.Mantenimiento
{
    partial class frmRegiones
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
            this.pnlDatosRegional = new System.Windows.Forms.Panel();
            this.cboPais = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtCodigoRegional = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtGrupoFacturacion = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtResponsableRegion = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.rbnInactivo = new System.Windows.Forms.RadioButton();
            this.rbnActivo = new System.Windows.Forms.RadioButton();
            this.txtNombreRegional = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.dtgRegionales = new System.Windows.Forms.DataGridView();
            this.totCampos = new System.Windows.Forms.ToolTip(this.components);
            this.tmrUpdResponsable = new System.Windows.Forms.Timer(this.components);
            this.pnlDatosRegional.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRegionales)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDatosRegional
            // 
            this.pnlDatosRegional.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatosRegional.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDatosRegional.Controls.Add(this.cboPais);
            this.pnlDatosRegional.Controls.Add(this.Label4);
            this.pnlDatosRegional.Controls.Add(this.txtCodigoRegional);
            this.pnlDatosRegional.Controls.Add(this.Label6);
            this.pnlDatosRegional.Controls.Add(this.txtGrupoFacturacion);
            this.pnlDatosRegional.Controls.Add(this.Label5);
            this.pnlDatosRegional.Controls.Add(this.txtResponsableRegion);
            this.pnlDatosRegional.Controls.Add(this.Label3);
            this.pnlDatosRegional.Controls.Add(this.btnNuevo);
            this.pnlDatosRegional.Controls.Add(this.btnGrabar);
            this.pnlDatosRegional.Controls.Add(this.Label2);
            this.pnlDatosRegional.Controls.Add(this.GroupBox1);
            this.pnlDatosRegional.Controls.Add(this.txtNombreRegional);
            this.pnlDatosRegional.Controls.Add(this.Label1);
            this.pnlDatosRegional.Location = new System.Drawing.Point(4, 5);
            this.pnlDatosRegional.Name = "pnlDatosRegional";
            this.pnlDatosRegional.Size = new System.Drawing.Size(623, 162);
            this.pnlDatosRegional.TabIndex = 58;
            // 
            // cboPais
            // 
            this.cboPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPais.FormattingEnabled = true;
            this.cboPais.Location = new System.Drawing.Point(111, 13);
            this.cboPais.Name = "cboPais";
            this.cboPais.Size = new System.Drawing.Size(213, 21);
            this.cboPais.TabIndex = 69;
            this.totCampos.SetToolTip(this.cboPais, "Seleccione el país al que pertenece la Regional");
            this.cboPais.SelectedIndexChanged += new System.EventHandler(this.cboPais_SelectedIndexChanged);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(73, 13);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(32, 13);
            this.Label4.TabIndex = 70;
            this.Label4.Text = "País:";
            // 
            // txtCodigoRegional
            // 
            this.txtCodigoRegional.Location = new System.Drawing.Point(111, 40);
            this.txtCodigoRegional.MaxLength = 10;
            this.txtCodigoRegional.Name = "txtCodigoRegional";
            this.txtCodigoRegional.Size = new System.Drawing.Size(82, 20);
            this.txtCodigoRegional.TabIndex = 67;
            this.totCampos.SetToolTip(this.txtCodigoRegional, "Digite el código asignado a la regional");
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(17, 43);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(88, 13);
            this.Label6.TabIndex = 68;
            this.Label6.Text = "Código Regional:";
            // 
            // txtGrupoFacturacion
            // 
            this.txtGrupoFacturacion.Location = new System.Drawing.Point(111, 97);
            this.txtGrupoFacturacion.MaxLength = 50;
            this.txtGrupoFacturacion.Name = "txtGrupoFacturacion";
            this.txtGrupoFacturacion.Size = new System.Drawing.Size(39, 20);
            this.txtGrupoFacturacion.TabIndex = 2;
            this.totCampos.SetToolTip(this.txtGrupoFacturacion, "Digite el numero de grupo de facturación al que pertenece la Regional");
            this.txtGrupoFacturacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGrupoFacturacion_KeyPress);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(7, 100);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(98, 13);
            this.Label5.TabIndex = 66;
            this.Label5.Text = "Grupo Facturación:";
            // 
            // txtResponsableRegion
            // 
            this.txtResponsableRegion.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtResponsableRegion.Location = new System.Drawing.Point(111, 126);
            this.txtResponsableRegion.MaxLength = 50;
            this.txtResponsableRegion.Name = "txtResponsableRegion";
            this.txtResponsableRegion.ReadOnly = true;
            this.txtResponsableRegion.Size = new System.Drawing.Size(330, 20);
            this.txtResponsableRegion.TabIndex = 7;
            this.totCampos.SetToolTip(this.txtResponsableRegion, "Click sobre el campo para realizar busqueda del responsable de la regional.");
            this.txtResponsableRegion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtResponsableRegion_MouseClick);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(33, 129);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(72, 13);
            this.Label3.TabIndex = 64;
            this.Label3.Text = "Responsable:";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(513, 99);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 9;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(513, 70);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 8;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(163, 99);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(43, 13);
            this.Label2.TabIndex = 57;
            this.Label2.Text = "Estado:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.rbnInactivo);
            this.GroupBox1.Controls.Add(this.rbnActivo);
            this.GroupBox1.Location = new System.Drawing.Point(213, 87);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(136, 32);
            this.GroupBox1.TabIndex = 3;
            this.GroupBox1.TabStop = false;
            // 
            // rbnInactivo
            // 
            this.rbnInactivo.AutoSize = true;
            this.rbnInactivo.Location = new System.Drawing.Point(68, 10);
            this.rbnInactivo.Name = "rbnInactivo";
            this.rbnInactivo.Size = new System.Drawing.Size(63, 17);
            this.rbnInactivo.TabIndex = 5;
            this.rbnInactivo.TabStop = true;
            this.rbnInactivo.Text = "&Inactivo";
            this.totCampos.SetToolTip(this.rbnInactivo, "Desactiva el seleccionarlo o usarlo dentro del sistema");
            this.rbnInactivo.UseVisualStyleBackColor = true;
            // 
            // rbnActivo
            // 
            this.rbnActivo.AutoSize = true;
            this.rbnActivo.Location = new System.Drawing.Point(7, 10);
            this.rbnActivo.Name = "rbnActivo";
            this.rbnActivo.Size = new System.Drawing.Size(55, 17);
            this.rbnActivo.TabIndex = 4;
            this.rbnActivo.TabStop = true;
            this.rbnActivo.Text = "&Activo";
            this.totCampos.SetToolTip(this.rbnActivo, "Permite seleccionarlo o usarlo dentro del istema");
            this.rbnActivo.UseVisualStyleBackColor = true;
            // 
            // txtNombreRegional
            // 
            this.txtNombreRegional.Location = new System.Drawing.Point(111, 66);
            this.txtNombreRegional.MaxLength = 50;
            this.txtNombreRegional.Name = "txtNombreRegional";
            this.txtNombreRegional.Size = new System.Drawing.Size(330, 20);
            this.txtNombreRegional.TabIndex = 1;
            this.totCampos.SetToolTip(this.txtNombreRegional, "Digite el nombre de la regional");
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(13, 69);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(92, 13);
            this.Label1.TabIndex = 54;
            this.Label1.Text = "Nombre Regional:";
            // 
            // dtgRegionales
            // 
            this.dtgRegionales.AllowUserToAddRows = false;
            this.dtgRegionales.AllowUserToDeleteRows = false;
            this.dtgRegionales.AllowUserToOrderColumns = true;
            this.dtgRegionales.AllowUserToResizeRows = false;
            this.dtgRegionales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgRegionales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgRegionales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgRegionales.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgRegionales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgRegionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgRegionales.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgRegionales.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgRegionales.Location = new System.Drawing.Point(4, 173);
            this.dtgRegionales.MultiSelect = false;
            this.dtgRegionales.Name = "dtgRegionales";
            this.dtgRegionales.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgRegionales.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgRegionales.RowHeadersVisible = false;
            this.dtgRegionales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgRegionales.ShowEditingIcon = false;
            this.dtgRegionales.Size = new System.Drawing.Size(623, 282);
            this.dtgRegionales.TabIndex = 57;
            this.dtgRegionales.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgRegionales_CellDoubleClick);
            // 
            // totCampos
            // 
            this.totCampos.AutoPopDelay = 3000;
            this.totCampos.InitialDelay = 20;
            this.totCampos.IsBalloon = true;
            this.totCampos.ReshowDelay = 100;
            this.totCampos.ShowAlways = true;
            // 
            // tmrUpdResponsable
            // 
            this.tmrUpdResponsable.Interval = 1000;
            this.tmrUpdResponsable.Tick += new System.EventHandler(this.tmrUpdResponsable_Tick);
            // 
            // frmRegiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 457);
            this.Controls.Add(this.pnlDatosRegional);
            this.Controls.Add(this.dtgRegionales);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegiones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento Regionales";
            this.Load += new System.EventHandler(this.frmRegiones_Load);
            this.pnlDatosRegional.ResumeLayout(false);
            this.pnlDatosRegional.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRegionales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.Panel pnlDatosRegional;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.RadioButton rbnInactivo;
        private System.Windows.Forms.RadioButton rbnActivo;
        private System.Windows.Forms.TextBox txtNombreRegional;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.DataGridView dtgRegionales;
        private System.Windows.Forms.TextBox txtResponsableRegion;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.TextBox txtGrupoFacturacion;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.ToolTip totCampos;
        private System.Windows.Forms.TextBox txtCodigoRegional;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.ComboBox cboPais;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Timer tmrUpdResponsable;
    }
}