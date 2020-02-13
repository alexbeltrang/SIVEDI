namespace SIVEDI.Mantenimiento
{
    partial class frmZonas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlDatosZona = new System.Windows.Forms.Panel();
            this.txtGrupoFacturacion = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.cboRegional = new System.Windows.Forms.ComboBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.cboPais = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtCodigoZona = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtResponsableZona = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.rbnInactivo = new System.Windows.Forms.RadioButton();
            this.rbnActivo = new System.Windows.Forms.RadioButton();
            this.txtNombreZona = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.dtgZonas = new System.Windows.Forms.DataGridView();
            this.totCampos = new System.Windows.Forms.ToolTip(this.components);
            this.tmrUpdResponsable = new System.Windows.Forms.Timer(this.components);
            this.pnlDatosZona.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgZonas)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDatosZona
            // 
            this.pnlDatosZona.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatosZona.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDatosZona.Controls.Add(this.txtGrupoFacturacion);
            this.pnlDatosZona.Controls.Add(this.Label5);
            this.pnlDatosZona.Controls.Add(this.cboRegional);
            this.pnlDatosZona.Controls.Add(this.Label7);
            this.pnlDatosZona.Controls.Add(this.cboPais);
            this.pnlDatosZona.Controls.Add(this.Label4);
            this.pnlDatosZona.Controls.Add(this.txtCodigoZona);
            this.pnlDatosZona.Controls.Add(this.Label6);
            this.pnlDatosZona.Controls.Add(this.txtResponsableZona);
            this.pnlDatosZona.Controls.Add(this.Label3);
            this.pnlDatosZona.Controls.Add(this.btnNuevo);
            this.pnlDatosZona.Controls.Add(this.btnGrabar);
            this.pnlDatosZona.Controls.Add(this.Label2);
            this.pnlDatosZona.Controls.Add(this.GroupBox1);
            this.pnlDatosZona.Controls.Add(this.txtNombreZona);
            this.pnlDatosZona.Controls.Add(this.Label1);
            this.pnlDatosZona.Location = new System.Drawing.Point(6, 2);
            this.pnlDatosZona.Name = "pnlDatosZona";
            this.pnlDatosZona.Size = new System.Drawing.Size(627, 162);
            this.pnlDatosZona.TabIndex = 60;
            // 
            // txtGrupoFacturacion
            // 
            this.txtGrupoFacturacion.Location = new System.Drawing.Point(92, 87);
            this.txtGrupoFacturacion.MaxLength = 50;
            this.txtGrupoFacturacion.Name = "txtGrupoFacturacion";
            this.txtGrupoFacturacion.Size = new System.Drawing.Size(39, 20);
            this.txtGrupoFacturacion.TabIndex = 4;
            this.totCampos.SetToolTip(this.txtGrupoFacturacion, "Digite el número de grupo de facturación al que pertenece la Zona");
            this.txtGrupoFacturacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGrupoFacturacion_KeyPress);
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(11, 82);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(75, 32);
            this.Label5.TabIndex = 74;
            this.Label5.Text = "Grupo Facturación:";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboRegional
            // 
            this.cboRegional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRegional.FormattingEnabled = true;
            this.cboRegional.Location = new System.Drawing.Point(375, 8);
            this.cboRegional.Name = "cboRegional";
            this.cboRegional.Size = new System.Drawing.Size(213, 21);
            this.cboRegional.TabIndex = 1;
            this.totCampos.SetToolTip(this.cboRegional, "Seleccione la Regional");
            this.cboRegional.SelectedIndexChanged += new System.EventHandler(this.cboRegional_SelectedIndexChanged);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(317, 11);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(52, 13);
            this.Label7.TabIndex = 72;
            this.Label7.Text = "Regional:";
            // 
            // cboPais
            // 
            this.cboPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPais.FormattingEnabled = true;
            this.cboPais.Location = new System.Drawing.Point(92, 8);
            this.cboPais.Name = "cboPais";
            this.cboPais.Size = new System.Drawing.Size(213, 21);
            this.cboPais.TabIndex = 0;
            this.totCampos.SetToolTip(this.cboPais, "Seleccione el País");
            this.cboPais.SelectedIndexChanged += new System.EventHandler(this.cboPais_SelectedIndexChanged);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(54, 11);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(32, 13);
            this.Label4.TabIndex = 70;
            this.Label4.Text = "País:";
            // 
            // txtCodigoZona
            // 
            this.txtCodigoZona.Location = new System.Drawing.Point(92, 35);
            this.txtCodigoZona.MaxLength = 10;
            this.txtCodigoZona.Name = "txtCodigoZona";
            this.txtCodigoZona.Size = new System.Drawing.Size(82, 20);
            this.txtCodigoZona.TabIndex = 2;
            this.totCampos.SetToolTip(this.txtCodigoZona, "Digite el código de la zona");
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(15, 38);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(71, 13);
            this.Label6.TabIndex = 68;
            this.Label6.Text = "Código Zona:";
            // 
            // txtResponsableZona
            // 
            this.txtResponsableZona.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtResponsableZona.Location = new System.Drawing.Point(92, 125);
            this.txtResponsableZona.MaxLength = 50;
            this.txtResponsableZona.Name = "txtResponsableZona";
            this.txtResponsableZona.ReadOnly = true;
            this.txtResponsableZona.Size = new System.Drawing.Size(330, 20);
            this.txtResponsableZona.TabIndex = 8;
            this.totCampos.SetToolTip(this.txtResponsableZona, "Click sobre el campo para realizar busqueda del responsable de la Zona.");
            this.txtResponsableZona.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtResponsableZona_MouseClick);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(14, 128);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(72, 13);
            this.Label3.TabIndex = 64;
            this.Label3.Text = "Responsable:";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(459, 99);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 9;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(459, 70);
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
            this.Label2.Location = new System.Drawing.Point(236, 94);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(43, 13);
            this.Label2.TabIndex = 57;
            this.Label2.Text = "Estado:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.rbnInactivo);
            this.GroupBox1.Controls.Add(this.rbnActivo);
            this.GroupBox1.Location = new System.Drawing.Point(286, 82);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(136, 32);
            this.GroupBox1.TabIndex = 5;
            this.GroupBox1.TabStop = false;
            // 
            // rbnInactivo
            // 
            this.rbnInactivo.AutoSize = true;
            this.rbnInactivo.Location = new System.Drawing.Point(68, 10);
            this.rbnInactivo.Name = "rbnInactivo";
            this.rbnInactivo.Size = new System.Drawing.Size(63, 17);
            this.rbnInactivo.TabIndex = 7;
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
            this.rbnActivo.TabIndex = 6;
            this.rbnActivo.TabStop = true;
            this.rbnActivo.Text = "&Activo";
            this.totCampos.SetToolTip(this.rbnActivo, "Permite seleccionarlo o usarlo dentro del sistema");
            this.rbnActivo.UseVisualStyleBackColor = true;
            // 
            // txtNombreZona
            // 
            this.txtNombreZona.Location = new System.Drawing.Point(92, 61);
            this.txtNombreZona.MaxLength = 50;
            this.txtNombreZona.Name = "txtNombreZona";
            this.txtNombreZona.Size = new System.Drawing.Size(330, 20);
            this.txtNombreZona.TabIndex = 3;
            this.totCampos.SetToolTip(this.txtNombreZona, "Digite el nombre de la zona");
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(11, 64);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(75, 13);
            this.Label1.TabIndex = 54;
            this.Label1.Text = "Nombre Zona:";
            // 
            // dtgZonas
            // 
            this.dtgZonas.AllowUserToAddRows = false;
            this.dtgZonas.AllowUserToDeleteRows = false;
            this.dtgZonas.AllowUserToOrderColumns = true;
            this.dtgZonas.AllowUserToResizeRows = false;
            this.dtgZonas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgZonas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgZonas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgZonas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgZonas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dtgZonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgZonas.DefaultCellStyle = dataGridViewCellStyle14;
            this.dtgZonas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgZonas.Location = new System.Drawing.Point(6, 168);
            this.dtgZonas.MultiSelect = false;
            this.dtgZonas.Name = "dtgZonas";
            this.dtgZonas.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgZonas.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dtgZonas.RowHeadersVisible = false;
            this.dtgZonas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgZonas.ShowEditingIcon = false;
            this.dtgZonas.Size = new System.Drawing.Size(627, 282);
            this.dtgZonas.TabIndex = 10;
            this.dtgZonas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgZonas_CellDoubleClick);
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
            // frmZonas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 451);
            this.Controls.Add(this.pnlDatosZona);
            this.Controls.Add(this.dtgZonas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmZonas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Zonas del Sistema";
            this.Load += new System.EventHandler(this.frmZonas_Load);
            this.pnlDatosZona.ResumeLayout(false);
            this.pnlDatosZona.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgZonas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDatosZona;
        private System.Windows.Forms.TextBox txtCodigoZona;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.TextBox txtResponsableZona;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.TextBox txtNombreZona;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.DataGridView dtgZonas;
        private System.Windows.Forms.ComboBox cboPais;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.ComboBox cboRegional;
        private System.Windows.Forms.Label Label7;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.RadioButton rbnInactivo;
        private System.Windows.Forms.RadioButton rbnActivo;
        private System.Windows.Forms.ToolTip totCampos;
        private System.Windows.Forms.TextBox txtGrupoFacturacion;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.Timer tmrUpdResponsable;
    }
}