namespace SIVEDI.Mantenimiento
{
    partial class frmTerritorios
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
            this.pnlDatosZona = new System.Windows.Forms.Panel();
            this.cboSeccion = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.cboZona = new System.Windows.Forms.ComboBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.cboRegional = new System.Windows.Forms.ComboBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.cboPais = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtCodigoTerritorio = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.rbnInactivo = new System.Windows.Forms.RadioButton();
            this.rbnActivo = new System.Windows.Forms.RadioButton();
            this.txtNombreTerritorio = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.dtgTerritorio = new System.Windows.Forms.DataGridView();
            this.totCampos = new System.Windows.Forms.ToolTip(this.components);
            this.pnlDatosZona.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTerritorio)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDatosZona
            // 
            this.pnlDatosZona.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatosZona.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDatosZona.Controls.Add(this.cboSeccion);
            this.pnlDatosZona.Controls.Add(this.Label3);
            this.pnlDatosZona.Controls.Add(this.cboZona);
            this.pnlDatosZona.Controls.Add(this.Label8);
            this.pnlDatosZona.Controls.Add(this.cboRegional);
            this.pnlDatosZona.Controls.Add(this.Label7);
            this.pnlDatosZona.Controls.Add(this.cboPais);
            this.pnlDatosZona.Controls.Add(this.Label4);
            this.pnlDatosZona.Controls.Add(this.txtCodigoTerritorio);
            this.pnlDatosZona.Controls.Add(this.Label6);
            this.pnlDatosZona.Controls.Add(this.btnNuevo);
            this.pnlDatosZona.Controls.Add(this.btnGrabar);
            this.pnlDatosZona.Controls.Add(this.Label2);
            this.pnlDatosZona.Controls.Add(this.GroupBox1);
            this.pnlDatosZona.Controls.Add(this.txtNombreTerritorio);
            this.pnlDatosZona.Controls.Add(this.Label1);
            this.pnlDatosZona.Location = new System.Drawing.Point(2, 6);
            this.pnlDatosZona.Name = "pnlDatosZona";
            this.pnlDatosZona.Size = new System.Drawing.Size(627, 162);
            this.pnlDatosZona.TabIndex = 62;
            // 
            // cboSeccion
            // 
            this.cboSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSeccion.FormattingEnabled = true;
            this.cboSeccion.Location = new System.Drawing.Point(392, 35);
            this.cboSeccion.Name = "cboSeccion";
            this.cboSeccion.Size = new System.Drawing.Size(213, 21);
            this.cboSeccion.TabIndex = 3;
            this.totCampos.SetToolTip(this.cboSeccion, "Seleccione la Sección");
            this.cboSeccion.SelectedIndexChanged += new System.EventHandler(this.cboSeccion_SelectedIndexChanged);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(337, 38);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(49, 13);
            this.Label3.TabIndex = 78;
            this.Label3.Text = "Sección:";
            // 
            // cboZona
            // 
            this.cboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona.FormattingEnabled = true;
            this.cboZona.Location = new System.Drawing.Point(109, 35);
            this.cboZona.Name = "cboZona";
            this.cboZona.Size = new System.Drawing.Size(213, 21);
            this.cboZona.TabIndex = 2;
            this.totCampos.SetToolTip(this.cboZona, "Seleccione la Zona");
            this.cboZona.SelectedIndexChanged += new System.EventHandler(this.cboZona_SelectedIndexChanged);
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(68, 38);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(35, 13);
            this.Label8.TabIndex = 76;
            this.Label8.Text = "Zona:";
            // 
            // cboRegional
            // 
            this.cboRegional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRegional.FormattingEnabled = true;
            this.cboRegional.Location = new System.Drawing.Point(392, 8);
            this.cboRegional.Name = "cboRegional";
            this.cboRegional.Size = new System.Drawing.Size(213, 21);
            this.cboRegional.TabIndex = 1;
            this.totCampos.SetToolTip(this.cboRegional, "Seleccione la Regional");
            this.cboRegional.SelectedIndexChanged += new System.EventHandler(this.cboRegional_SelectedIndexChanged);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(334, 11);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(52, 13);
            this.Label7.TabIndex = 72;
            this.Label7.Text = "Regional:";
            // 
            // cboPais
            // 
            this.cboPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPais.FormattingEnabled = true;
            this.cboPais.Location = new System.Drawing.Point(109, 8);
            this.cboPais.Name = "cboPais";
            this.cboPais.Size = new System.Drawing.Size(213, 21);
            this.cboPais.TabIndex = 0;
            this.totCampos.SetToolTip(this.cboPais, "Seleccione el País");
            this.cboPais.SelectedIndexChanged += new System.EventHandler(this.cboPais_SelectedIndexChanged);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(71, 11);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(32, 13);
            this.Label4.TabIndex = 70;
            this.Label4.Text = "País:";
            // 
            // txtCodigoTerritorio
            // 
            this.txtCodigoTerritorio.Location = new System.Drawing.Point(109, 67);
            this.txtCodigoTerritorio.MaxLength = 10;
            this.txtCodigoTerritorio.Name = "txtCodigoTerritorio";
            this.txtCodigoTerritorio.Size = new System.Drawing.Size(82, 20);
            this.txtCodigoTerritorio.TabIndex = 4;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(16, 70);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(87, 13);
            this.Label6.TabIndex = 68;
            this.Label6.Text = "Código Territorio:";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(476, 99);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 10;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(476, 70);
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
            this.Label2.Location = new System.Drawing.Point(60, 131);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(43, 13);
            this.Label2.TabIndex = 57;
            this.Label2.Text = "Estado:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.rbnInactivo);
            this.GroupBox1.Controls.Add(this.rbnActivo);
            this.GroupBox1.Location = new System.Drawing.Point(109, 119);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(136, 32);
            this.GroupBox1.TabIndex = 6;
            this.GroupBox1.TabStop = false;
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
            // txtNombreTerritorio
            // 
            this.txtNombreTerritorio.Location = new System.Drawing.Point(109, 93);
            this.txtNombreTerritorio.MaxLength = 50;
            this.txtNombreTerritorio.Name = "txtNombreTerritorio";
            this.txtNombreTerritorio.Size = new System.Drawing.Size(330, 20);
            this.txtNombreTerritorio.TabIndex = 5;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(14, 96);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(91, 13);
            this.Label1.TabIndex = 54;
            this.Label1.Text = "Nombre Territorio:";
            // 
            // dtgTerritorio
            // 
            this.dtgTerritorio.AllowUserToAddRows = false;
            this.dtgTerritorio.AllowUserToDeleteRows = false;
            this.dtgTerritorio.AllowUserToOrderColumns = true;
            this.dtgTerritorio.AllowUserToResizeRows = false;
            this.dtgTerritorio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgTerritorio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgTerritorio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgTerritorio.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTerritorio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgTerritorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgTerritorio.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgTerritorio.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgTerritorio.Location = new System.Drawing.Point(2, 174);
            this.dtgTerritorio.MultiSelect = false;
            this.dtgTerritorio.Name = "dtgTerritorio";
            this.dtgTerritorio.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTerritorio.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgTerritorio.RowHeadersVisible = false;
            this.dtgTerritorio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTerritorio.ShowEditingIcon = false;
            this.dtgTerritorio.Size = new System.Drawing.Size(627, 267);
            this.dtgTerritorio.TabIndex = 11;
            this.dtgTerritorio.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgTerritorio_CellDoubleClick);
            // 
            // totCampos
            // 
            this.totCampos.AutoPopDelay = 3000;
            this.totCampos.InitialDelay = 20;
            this.totCampos.IsBalloon = true;
            this.totCampos.ReshowDelay = 100;
            this.totCampos.ShowAlways = true;
            // 
            // frmTerritorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 439);
            this.Controls.Add(this.dtgTerritorio);
            this.Controls.Add(this.pnlDatosZona);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTerritorios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Territorios";
            this.Load += new System.EventHandler(this.frmTerritorios_Load);
            this.pnlDatosZona.ResumeLayout(false);
            this.pnlDatosZona.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTerritorio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDatosZona;
        private System.Windows.Forms.ComboBox cboZona;
        private System.Windows.Forms.Label Label8;
        private System.Windows.Forms.ComboBox cboRegional;
        private System.Windows.Forms.Label Label7;
        private System.Windows.Forms.ComboBox cboPais;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.TextBox txtCodigoTerritorio;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.RadioButton rbnInactivo;
        private System.Windows.Forms.RadioButton rbnActivo;
        private System.Windows.Forms.TextBox txtNombreTerritorio;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.DataGridView dtgTerritorio;
        private System.Windows.Forms.ComboBox cboSeccion;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.ToolTip totCampos;
    }
}