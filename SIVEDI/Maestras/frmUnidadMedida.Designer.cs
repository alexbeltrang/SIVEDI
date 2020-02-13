namespace SIVEDI.Maestras
{
    partial class frmUnidadMedida
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
            this.pnlDatosPerfil = new System.Windows.Forms.Panel();
            this.txtNomenclatura = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.rbnInactivo = new System.Windows.Forms.RadioButton();
            this.rbnActivo = new System.Windows.Forms.RadioButton();
            this.txtUnidadMedida = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.dtgTipoUnidadMedida = new System.Windows.Forms.DataGridView();
            this.totCampos = new System.Windows.Forms.ToolTip(this.components);
            this.pnlDatosPerfil.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTipoUnidadMedida)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDatosPerfil
            // 
            this.pnlDatosPerfil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatosPerfil.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDatosPerfil.Controls.Add(this.txtNomenclatura);
            this.pnlDatosPerfil.Controls.Add(this.Label3);
            this.pnlDatosPerfil.Controls.Add(this.btnNuevo);
            this.pnlDatosPerfil.Controls.Add(this.btnGrabar);
            this.pnlDatosPerfil.Controls.Add(this.Label2);
            this.pnlDatosPerfil.Controls.Add(this.GroupBox1);
            this.pnlDatosPerfil.Controls.Add(this.txtUnidadMedida);
            this.pnlDatosPerfil.Controls.Add(this.Label1);
            this.pnlDatosPerfil.Location = new System.Drawing.Point(13, 5);
            this.pnlDatosPerfil.Name = "pnlDatosPerfil";
            this.pnlDatosPerfil.Size = new System.Drawing.Size(623, 98);
            this.pnlDatosPerfil.TabIndex = 52;
            // 
            // txtNomenclatura
            // 
            this.txtNomenclatura.Location = new System.Drawing.Point(144, 34);
            this.txtNomenclatura.MaxLength = 15;
            this.txtNomenclatura.Name = "txtNomenclatura";
            this.txtNomenclatura.Size = new System.Drawing.Size(104, 20);
            this.txtNomenclatura.TabIndex = 2;
            this.totCampos.SetToolTip(this.txtNomenclatura, "Abreviatura o Nomenclatura ejp UNI  =Unidad");
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(77, 37);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(61, 13);
            this.Label3.TabIndex = 60;
            this.Label3.Text = "Abreviatura";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(383, 60);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 7;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(302, 60);
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
            this.Label2.Location = new System.Drawing.Point(93, 65);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(43, 13);
            this.Label2.TabIndex = 57;
            this.Label2.Text = "Estado:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.rbnInactivo);
            this.GroupBox1.Controls.Add(this.rbnActivo);
            this.GroupBox1.Location = new System.Drawing.Point(143, 53);
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
            this.totCampos.SetToolTip(this.rbnActivo, "Permite seleccionarlo o usarlo dentro del sistema");
            this.rbnActivo.UseVisualStyleBackColor = true;
            // 
            // txtUnidadMedida
            // 
            this.txtUnidadMedida.Location = new System.Drawing.Point(144, 8);
            this.txtUnidadMedida.MaxLength = 50;
            this.txtUnidadMedida.Name = "txtUnidadMedida";
            this.txtUnidadMedida.Size = new System.Drawing.Size(330, 20);
            this.txtUnidadMedida.TabIndex = 1;
            this.totCampos.SetToolTip(this.txtUnidadMedida, "Nombre o Descripción de la Unidad de Medida para productos");
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(44, 11);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(94, 13);
            this.Label1.TabIndex = 54;
            this.Label1.Text = "Unidad de Medida";
            // 
            // dtgTipoUnidadMedida
            // 
            this.dtgTipoUnidadMedida.AllowUserToAddRows = false;
            this.dtgTipoUnidadMedida.AllowUserToDeleteRows = false;
            this.dtgTipoUnidadMedida.AllowUserToOrderColumns = true;
            this.dtgTipoUnidadMedida.AllowUserToResizeRows = false;
            this.dtgTipoUnidadMedida.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgTipoUnidadMedida.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgTipoUnidadMedida.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgTipoUnidadMedida.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTipoUnidadMedida.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgTipoUnidadMedida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgTipoUnidadMedida.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgTipoUnidadMedida.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgTipoUnidadMedida.Location = new System.Drawing.Point(9, 109);
            this.dtgTipoUnidadMedida.MultiSelect = false;
            this.dtgTipoUnidadMedida.Name = "dtgTipoUnidadMedida";
            this.dtgTipoUnidadMedida.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTipoUnidadMedida.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgTipoUnidadMedida.RowHeadersVisible = false;
            this.dtgTipoUnidadMedida.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTipoUnidadMedida.ShowEditingIcon = false;
            this.dtgTipoUnidadMedida.Size = new System.Drawing.Size(630, 214);
            this.dtgTipoUnidadMedida.TabIndex = 51;
            this.dtgTipoUnidadMedida.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgTipoUnidadMedida_CellDoubleClick);
            // 
            // totCampos
            // 
            this.totCampos.AutoPopDelay = 3000;
            this.totCampos.InitialDelay = 20;
            this.totCampos.IsBalloon = true;
            this.totCampos.ReshowDelay = 100;
            this.totCampos.ShowAlways = true;
            // 
            // frmUnidadMedida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 329);
            this.Controls.Add(this.pnlDatosPerfil);
            this.Controls.Add(this.dtgTipoUnidadMedida);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmUnidadMedida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unidades de Medida";
            this.Load += new System.EventHandler(this.frmUnidadMedida_Load);
            this.pnlDatosPerfil.ResumeLayout(false);
            this.pnlDatosPerfil.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTipoUnidadMedida)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.Panel pnlDatosPerfil;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.RadioButton rbnInactivo;
        private System.Windows.Forms.RadioButton rbnActivo;
        private System.Windows.Forms.TextBox txtUnidadMedida;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.DataGridView dtgTipoUnidadMedida;
        private System.Windows.Forms.TextBox txtNomenclatura;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.ToolTip totCampos;
    }
}