namespace SIVEDI.Maestras
{
    partial class frmCiudades
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
            this.pnlDatosCiudad = new System.Windows.Forms.Panel();
            this.cboDepto = new System.Windows.Forms.ComboBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.cboPais = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtCodigoDaneCiudad = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.rbnInactivo = new System.Windows.Forms.RadioButton();
            this.rbnActivo = new System.Windows.Forms.RadioButton();
            this.txtNombreCiudad = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.dtgCiudades = new System.Windows.Forms.DataGridView();
            this.totCampos = new System.Windows.Forms.ToolTip(this.components);
            this.pnlDatosCiudad.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCiudades)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDatosCiudad
            // 
            this.pnlDatosCiudad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatosCiudad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDatosCiudad.Controls.Add(this.cboDepto);
            this.pnlDatosCiudad.Controls.Add(this.Label5);
            this.pnlDatosCiudad.Controls.Add(this.cboPais);
            this.pnlDatosCiudad.Controls.Add(this.Label4);
            this.pnlDatosCiudad.Controls.Add(this.txtCodigoDaneCiudad);
            this.pnlDatosCiudad.Controls.Add(this.Label3);
            this.pnlDatosCiudad.Controls.Add(this.btnNuevo);
            this.pnlDatosCiudad.Controls.Add(this.btnGrabar);
            this.pnlDatosCiudad.Controls.Add(this.Label2);
            this.pnlDatosCiudad.Controls.Add(this.GroupBox1);
            this.pnlDatosCiudad.Controls.Add(this.txtNombreCiudad);
            this.pnlDatosCiudad.Controls.Add(this.Label1);
            this.pnlDatosCiudad.Location = new System.Drawing.Point(7, 5);
            this.pnlDatosCiudad.Name = "pnlDatosCiudad";
            this.pnlDatosCiudad.Size = new System.Drawing.Size(623, 131);
            this.pnlDatosCiudad.TabIndex = 56;
            // 
            // cboDepto
            // 
            this.cboDepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepto.FormattingEnabled = true;
            this.cboDepto.Location = new System.Drawing.Point(105, 42);
            this.cboDepto.Name = "cboDepto";
            this.cboDepto.Size = new System.Drawing.Size(213, 21);
            this.cboDepto.TabIndex = 63;
            this.totCampos.SetToolTip(this.cboDepto, "Seleccione el Departamento");
            this.cboDepto.SelectedIndexChanged += new System.EventHandler(this.cboDepto_SelectedIndexChanged);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(22, 45);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(77, 13);
            this.Label5.TabIndex = 64;
            this.Label5.Text = "Departamento:";
            // 
            // cboPais
            // 
            this.cboPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPais.FormattingEnabled = true;
            this.cboPais.Location = new System.Drawing.Point(105, 15);
            this.cboPais.Name = "cboPais";
            this.cboPais.Size = new System.Drawing.Size(213, 21);
            this.cboPais.TabIndex = 1;
            this.totCampos.SetToolTip(this.cboPais, "Seleccione el País");
            this.cboPais.SelectedIndexChanged += new System.EventHandler(this.cboPais_SelectedIndexChanged);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(67, 15);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(32, 13);
            this.Label4.TabIndex = 62;
            this.Label4.Text = "País:";
            // 
            // txtCodigoDaneCiudad
            // 
            this.txtCodigoDaneCiudad.Location = new System.Drawing.Point(523, 68);
            this.txtCodigoDaneCiudad.MaxLength = 3;
            this.txtCodigoDaneCiudad.Name = "txtCodigoDaneCiudad";
            this.txtCodigoDaneCiudad.Size = new System.Drawing.Size(62, 20);
            this.txtCodigoDaneCiudad.TabIndex = 6;
            this.totCampos.SetToolTip(this.txtCodigoDaneCiudad, "Código DANE asignado a la Ciudad por el Estado.");
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(441, 72);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(76, 13);
            this.Label3.TabIndex = 60;
            this.Label3.Text = "Código DANE:";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(370, 100);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 7;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(289, 100);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 6;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(56, 104);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(43, 13);
            this.Label2.TabIndex = 57;
            this.Label2.Text = "Estado:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.rbnInactivo);
            this.GroupBox1.Controls.Add(this.rbnActivo);
            this.GroupBox1.Location = new System.Drawing.Point(106, 92);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(136, 32);
            this.GroupBox1.TabIndex = 56;
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
            this.totCampos.SetToolTip(this.rbnActivo, "Permite seleccionarlo o usarlo dentro del sistema");
            this.rbnActivo.UseVisualStyleBackColor = true;
            // 
            // txtNombreCiudad
            // 
            this.txtNombreCiudad.Location = new System.Drawing.Point(105, 69);
            this.txtNombreCiudad.MaxLength = 50;
            this.txtNombreCiudad.Name = "txtNombreCiudad";
            this.txtNombreCiudad.Size = new System.Drawing.Size(330, 20);
            this.txtNombreCiudad.TabIndex = 2;
            this.totCampos.SetToolTip(this.txtNombreCiudad, "Nombre de la ciudad, la cual será asignado a los clientes");
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(16, 71);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(83, 13);
            this.Label1.TabIndex = 54;
            this.Label1.Text = "Nombre Ciudad:";
            // 
            // dtgCiudades
            // 
            this.dtgCiudades.AllowUserToAddRows = false;
            this.dtgCiudades.AllowUserToDeleteRows = false;
            this.dtgCiudades.AllowUserToOrderColumns = true;
            this.dtgCiudades.AllowUserToResizeRows = false;
            this.dtgCiudades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgCiudades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgCiudades.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgCiudades.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCiudades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgCiudades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCiudades.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgCiudades.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgCiudades.Location = new System.Drawing.Point(7, 142);
            this.dtgCiudades.MultiSelect = false;
            this.dtgCiudades.Name = "dtgCiudades";
            this.dtgCiudades.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCiudades.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgCiudades.RowHeadersVisible = false;
            this.dtgCiudades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCiudades.ShowEditingIcon = false;
            this.dtgCiudades.Size = new System.Drawing.Size(623, 313);
            this.dtgCiudades.TabIndex = 55;
            this.dtgCiudades.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCiudades_CellDoubleClick);
            // 
            // totCampos
            // 
            this.totCampos.AutoPopDelay = 3000;
            this.totCampos.InitialDelay = 20;
            this.totCampos.IsBalloon = true;
            this.totCampos.ReshowDelay = 100;
            this.totCampos.ShowAlways = true;
            // 
            // frmCiudades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 463);
            this.Controls.Add(this.pnlDatosCiudad);
            this.Controls.Add(this.dtgCiudades);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCiudades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento Ciudades";
            this.Load += new System.EventHandler(this.frmCiudades_Load);
            this.pnlDatosCiudad.ResumeLayout(false);
            this.pnlDatosCiudad.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCiudades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDatosCiudad;
        private System.Windows.Forms.ComboBox cboPais;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.TextBox txtCodigoDaneCiudad;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.RadioButton rbnInactivo;
        private System.Windows.Forms.RadioButton rbnActivo;
        private System.Windows.Forms.TextBox txtNombreCiudad;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.DataGridView dtgCiudades;
        private System.Windows.Forms.ComboBox cboDepto;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.ToolTip totCampos;
    }
}