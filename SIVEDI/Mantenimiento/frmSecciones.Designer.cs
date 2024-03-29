﻿namespace SIVEDI.Mantenimiento
{
    partial class frmSecciones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlDatosZona = new System.Windows.Forms.Panel();
            this.cboZona = new System.Windows.Forms.ComboBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.cboRegional = new System.Windows.Forms.ComboBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.cboPais = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtCodigoSeccion = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtResponsableSeccion = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.rbnInactivo = new System.Windows.Forms.RadioButton();
            this.rbnActivo = new System.Windows.Forms.RadioButton();
            this.txtNombreSeccion = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.dtgSecciones = new System.Windows.Forms.DataGridView();
            this.totCampos = new System.Windows.Forms.ToolTip(this.components);
            this.tmrUpdResponsable = new System.Windows.Forms.Timer(this.components);
            this.pnlDatosZona.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSecciones)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDatosZona
            // 
            this.pnlDatosZona.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatosZona.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDatosZona.Controls.Add(this.cboZona);
            this.pnlDatosZona.Controls.Add(this.Label8);
            this.pnlDatosZona.Controls.Add(this.cboRegional);
            this.pnlDatosZona.Controls.Add(this.Label7);
            this.pnlDatosZona.Controls.Add(this.cboPais);
            this.pnlDatosZona.Controls.Add(this.Label4);
            this.pnlDatosZona.Controls.Add(this.txtCodigoSeccion);
            this.pnlDatosZona.Controls.Add(this.Label6);
            this.pnlDatosZona.Controls.Add(this.txtResponsableSeccion);
            this.pnlDatosZona.Controls.Add(this.Label3);
            this.pnlDatosZona.Controls.Add(this.btnNuevo);
            this.pnlDatosZona.Controls.Add(this.btnGrabar);
            this.pnlDatosZona.Controls.Add(this.Label2);
            this.pnlDatosZona.Controls.Add(this.GroupBox1);
            this.pnlDatosZona.Controls.Add(this.txtNombreSeccion);
            this.pnlDatosZona.Controls.Add(this.Label1);
            this.pnlDatosZona.Location = new System.Drawing.Point(3, 5);
            this.pnlDatosZona.Name = "pnlDatosZona";
            this.pnlDatosZona.Size = new System.Drawing.Size(627, 162);
            this.pnlDatosZona.TabIndex = 61;
            // 
            // cboZona
            // 
            this.cboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona.FormattingEnabled = true;
            this.cboZona.Location = new System.Drawing.Point(109, 34);
            this.cboZona.Name = "cboZona";
            this.cboZona.Size = new System.Drawing.Size(213, 21);
            this.cboZona.TabIndex = 2;
            this.totCampos.SetToolTip(this.cboZona, "Seleccione la Zona");
            this.cboZona.SelectedIndexChanged += new System.EventHandler(this.cboZona_SelectedIndexChanged);
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(68, 37);
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
            // txtCodigoSeccion
            // 
            this.txtCodigoSeccion.Location = new System.Drawing.Point(392, 35);
            this.txtCodigoSeccion.MaxLength = 10;
            this.txtCodigoSeccion.Name = "txtCodigoSeccion";
            this.txtCodigoSeccion.Size = new System.Drawing.Size(82, 20);
            this.txtCodigoSeccion.TabIndex = 3;
            this.totCampos.SetToolTip(this.txtCodigoSeccion, "Digite el código de la Sección");
            // 
            // Label6
            // 
            this.Label6.Location = new System.Drawing.Point(330, 32);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(56, 26);
            this.Label6.TabIndex = 68;
            this.Label6.Text = "Código Sección:";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtResponsableSeccion
            // 
            this.txtResponsableSeccion.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtResponsableSeccion.Location = new System.Drawing.Point(109, 125);
            this.txtResponsableSeccion.MaxLength = 50;
            this.txtResponsableSeccion.Name = "txtResponsableSeccion";
            this.txtResponsableSeccion.ReadOnly = true;
            this.txtResponsableSeccion.Size = new System.Drawing.Size(330, 20);
            this.txtResponsableSeccion.TabIndex = 8;
            this.totCampos.SetToolTip(this.txtResponsableSeccion, "Click sobre el campo para realizar busqueda del responsable de la Sección");
            this.txtResponsableSeccion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtResponsableSeccion_MouseClick);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(31, 128);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(72, 13);
            this.Label3.TabIndex = 64;
            this.Label3.Text = "Responsable:";
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
            this.Label2.Location = new System.Drawing.Point(60, 99);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(43, 13);
            this.Label2.TabIndex = 57;
            this.Label2.Text = "Estado:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.rbnInactivo);
            this.GroupBox1.Controls.Add(this.rbnActivo);
            this.GroupBox1.Location = new System.Drawing.Point(109, 87);
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
            // txtNombreSeccion
            // 
            this.txtNombreSeccion.Location = new System.Drawing.Point(109, 61);
            this.txtNombreSeccion.MaxLength = 50;
            this.txtNombreSeccion.Name = "txtNombreSeccion";
            this.txtNombreSeccion.Size = new System.Drawing.Size(330, 20);
            this.txtNombreSeccion.TabIndex = 4;
            this.totCampos.SetToolTip(this.txtNombreSeccion, "Digite el nombre de la Sección");
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(14, 64);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(89, 13);
            this.Label1.TabIndex = 54;
            this.Label1.Text = "Nombre Sección:";
            // 
            // dtgSecciones
            // 
            this.dtgSecciones.AllowUserToAddRows = false;
            this.dtgSecciones.AllowUserToDeleteRows = false;
            this.dtgSecciones.AllowUserToOrderColumns = true;
            this.dtgSecciones.AllowUserToResizeRows = false;
            this.dtgSecciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgSecciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgSecciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgSecciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgSecciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dtgSecciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgSecciones.DefaultCellStyle = dataGridViewCellStyle11;
            this.dtgSecciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgSecciones.Location = new System.Drawing.Point(3, 173);
            this.dtgSecciones.MultiSelect = false;
            this.dtgSecciones.Name = "dtgSecciones";
            this.dtgSecciones.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgSecciones.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dtgSecciones.RowHeadersVisible = false;
            this.dtgSecciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSecciones.ShowEditingIcon = false;
            this.dtgSecciones.Size = new System.Drawing.Size(627, 267);
            this.dtgSecciones.TabIndex = 11;
            this.dtgSecciones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSecciones_CellDoubleClick);
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
            this.tmrUpdResponsable.Tick += new System.EventHandler(this.tmrUpdResponsable_Tick);
            // 
            // frmSecciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 445);
            this.Controls.Add(this.dtgSecciones);
            this.Controls.Add(this.pnlDatosZona);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSecciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Secciones";
            this.Load += new System.EventHandler(this.frmSecciones_Load);
            this.pnlDatosZona.ResumeLayout(false);
            this.pnlDatosZona.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSecciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDatosZona;
        private System.Windows.Forms.ComboBox cboRegional;
        private System.Windows.Forms.Label Label7;
        private System.Windows.Forms.ComboBox cboPais;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.TextBox txtCodigoSeccion;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.TextBox txtResponsableSeccion;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.RadioButton rbnInactivo;
        private System.Windows.Forms.RadioButton rbnActivo;
        private System.Windows.Forms.TextBox txtNombreSeccion;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.DataGridView dtgSecciones;
        private System.Windows.Forms.ComboBox cboZona;
        private System.Windows.Forms.Label Label8;
        private System.Windows.Forms.ToolTip totCampos;
        private System.Windows.Forms.Timer tmrUpdResponsable;
    }
}