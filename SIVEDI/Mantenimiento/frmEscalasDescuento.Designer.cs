namespace SIVEDI.Mantenimiento
{
    partial class frmEscalasDescuento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.totCampos = new System.Windows.Forms.ToolTip(this.components);
            this.cboTipoCliente = new System.Windows.Forms.ComboBox();
            this.rbnNoNuevo = new System.Windows.Forms.RadioButton();
            this.rbnSiNuevo = new System.Windows.Forms.RadioButton();
            this.txtPorcentaje = new System.Windows.Forms.TextBox();
            this.txtValorFinal = new System.Windows.Forms.TextBox();
            this.txtValorInicial = new System.Windows.Forms.TextBox();
            this.dtgZonasAsignadas = new System.Windows.Forms.DataGridView();
            this.chlZonas = new System.Windows.Forms.CheckedListBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label5 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.btnAsignaZonas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgZonasAsignadas)).BeginInit();
            this.Panel1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
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
            // cboTipoCliente
            // 
            this.cboTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCliente.FormattingEnabled = true;
            this.cboTipoCliente.Location = new System.Drawing.Point(119, 10);
            this.cboTipoCliente.Name = "cboTipoCliente";
            this.cboTipoCliente.Size = new System.Drawing.Size(170, 21);
            this.cboTipoCliente.TabIndex = 1;
            this.totCampos.SetToolTip(this.cboTipoCliente, "Tipo de cliente al cual va dirigida la escala de descuento");
            this.cboTipoCliente.SelectedIndexChanged += new System.EventHandler(this.cboTipoCliente_SelectedIndexChanged);
            // 
            // rbnNoNuevo
            // 
            this.rbnNoNuevo.AutoSize = true;
            this.rbnNoNuevo.Location = new System.Drawing.Point(43, 10);
            this.rbnNoNuevo.Name = "rbnNoNuevo";
            this.rbnNoNuevo.Size = new System.Drawing.Size(39, 17);
            this.rbnNoNuevo.TabIndex = 6;
            this.rbnNoNuevo.TabStop = true;
            this.rbnNoNuevo.Text = "&No";
            this.totCampos.SetToolTip(this.rbnNoNuevo, "La escala de descuento NO aplica para los asesores nuevos");
            this.rbnNoNuevo.UseVisualStyleBackColor = true;
            // 
            // rbnSiNuevo
            // 
            this.rbnSiNuevo.AutoSize = true;
            this.rbnSiNuevo.Location = new System.Drawing.Point(7, 10);
            this.rbnSiNuevo.Name = "rbnSiNuevo";
            this.rbnSiNuevo.Size = new System.Drawing.Size(34, 17);
            this.rbnSiNuevo.TabIndex = 5;
            this.rbnSiNuevo.TabStop = true;
            this.rbnSiNuevo.Text = "&Si";
            this.totCampos.SetToolTip(this.rbnSiNuevo, "La escala de descuento aplica para los asesores nuevos");
            this.rbnSiNuevo.UseVisualStyleBackColor = true;
            // 
            // txtPorcentaje
            // 
            this.txtPorcentaje.Location = new System.Drawing.Point(119, 63);
            this.txtPorcentaje.MaxLength = 3;
            this.txtPorcentaje.Name = "txtPorcentaje";
            this.txtPorcentaje.Size = new System.Drawing.Size(53, 20);
            this.txtPorcentaje.TabIndex = 7;
            this.totCampos.SetToolTip(this.txtPorcentaje, "Porcentaje de descuento, debe ser decimal ej: 25% = 0.25");
            this.txtPorcentaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcentaje_KeyPress);
            // 
            // txtValorFinal
            // 
            this.txtValorFinal.Location = new System.Drawing.Point(405, 37);
            this.txtValorFinal.MaxLength = 9;
            this.txtValorFinal.Name = "txtValorFinal";
            this.txtValorFinal.Size = new System.Drawing.Size(170, 20);
            this.txtValorFinal.TabIndex = 5;
            this.totCampos.SetToolTip(this.txtValorFinal, "Valor en pesos del rango Superior");
            // 
            // txtValorInicial
            // 
            this.txtValorInicial.Location = new System.Drawing.Point(119, 37);
            this.txtValorInicial.MaxLength = 9;
            this.txtValorInicial.Name = "txtValorInicial";
            this.txtValorInicial.Size = new System.Drawing.Size(170, 20);
            this.txtValorInicial.TabIndex = 3;
            this.totCampos.SetToolTip(this.txtValorInicial, "Valor en pesos del rango inferior");
            // 
            // dtgZonasAsignadas
            // 
            this.dtgZonasAsignadas.AllowUserToAddRows = false;
            this.dtgZonasAsignadas.AllowUserToDeleteRows = false;
            this.dtgZonasAsignadas.AllowUserToOrderColumns = true;
            this.dtgZonasAsignadas.AllowUserToResizeRows = false;
            this.dtgZonasAsignadas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgZonasAsignadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgZonasAsignadas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgZonasAsignadas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgZonasAsignadas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgZonasAsignadas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgZonasAsignadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgZonasAsignadas.DefaultCellStyle = dataGridViewCellStyle8;
            this.dtgZonasAsignadas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgZonasAsignadas.Location = new System.Drawing.Point(185, 34);
            this.dtgZonasAsignadas.MultiSelect = false;
            this.dtgZonasAsignadas.Name = "dtgZonasAsignadas";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgZonasAsignadas.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dtgZonasAsignadas.RowHeadersVisible = false;
            this.dtgZonasAsignadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgZonasAsignadas.ShowEditingIcon = false;
            this.dtgZonasAsignadas.Size = new System.Drawing.Size(611, 439);
            this.dtgZonasAsignadas.TabIndex = 13;
            this.totCampos.SetToolTip(this.dtgZonasAsignadas, "Registros que se les ha asignado escala de descuento por tipo de cliente.");
            this.dtgZonasAsignadas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgZonasAsignadas_CellDoubleClick);
            // 
            // chlZonas
            // 
            this.chlZonas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chlZonas.CheckOnClick = true;
            this.chlZonas.FormattingEnabled = true;
            this.chlZonas.Location = new System.Drawing.Point(6, 32);
            this.chlZonas.Name = "chlZonas";
            this.chlZonas.Size = new System.Drawing.Size(173, 439);
            this.chlZonas.TabIndex = 1;
            this.totCampos.SetToolTip(this.chlZonas, "Seleccione las zonas a las cuales les va a asignar la escala de descuento");
            this.chlZonas.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chlZonas_ItemCheck);
            // 
            // Panel1
            // 
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel1.Controls.Add(this.Label5);
            this.Panel1.Controls.Add(this.GroupBox1);
            this.Panel1.Controls.Add(this.txtPorcentaje);
            this.Panel1.Controls.Add(this.Label4);
            this.Panel1.Controls.Add(this.txtValorFinal);
            this.Panel1.Controls.Add(this.Label3);
            this.Panel1.Controls.Add(this.txtValorInicial);
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Controls.Add(this.cboTipoCliente);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Location = new System.Drawing.Point(13, 13);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(811, 110);
            this.Panel1.TabIndex = 0;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(289, 70);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(110, 13);
            this.Label5.TabIndex = 58;
            this.Label5.Text = "Es para cliente nuevo";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.rbnNoNuevo);
            this.GroupBox1.Controls.Add(this.rbnSiNuevo);
            this.GroupBox1.Location = new System.Drawing.Point(405, 58);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(85, 32);
            this.GroupBox1.TabIndex = 57;
            this.GroupBox1.TabStop = false;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(55, 65);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(58, 13);
            this.Label4.TabIndex = 6;
            this.Label4.Text = "Porcentaje";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(302, 41);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(92, 13);
            this.Label3.TabIndex = 4;
            this.Label3.Text = "Valor Pedido Final";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(16, 39);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(97, 13);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Valor Pedido Inicial";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(50, 13);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(63, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Tipo Cliente";
            // 
            // TabControl1
            // 
            this.TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Location = new System.Drawing.Point(13, 130);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(811, 506);
            this.TabControl1.TabIndex = 1;
            // 
            // TabPage1
            // 
            this.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TabPage1.Controls.Add(this.btnAsignaZonas);
            this.TabPage1.Controls.Add(this.dtgZonasAsignadas);
            this.TabPage1.Controls.Add(this.chlZonas);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(803, 480);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Territorios";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAsignaZonas
            // 
            this.btnAsignaZonas.Location = new System.Drawing.Point(347, 5);
            this.btnAsignaZonas.Name = "btnAsignaZonas";
            this.btnAsignaZonas.Size = new System.Drawing.Size(93, 23);
            this.btnAsignaZonas.TabIndex = 14;
            this.btnAsignaZonas.Text = "Grabar";
            this.btnAsignaZonas.UseVisualStyleBackColor = true;
            this.btnAsignaZonas.Click += new System.EventHandler(this.btnAsignaZonas_Click);
            // 
            // frmEscalasDescuento
            // 
            this.AcceptButton = this.btnAsignaZonas;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 637);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(846, 680);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(846, 680);
            this.Name = "frmEscalasDescuento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración Escalas de Descuento";
            this.Load += new System.EventHandler(this.frmEscalasDescuento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgZonasAsignadas)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip totCampos;
        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.ComboBox cboTipoCliente;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox txtPorcentaje;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.TextBox txtValorFinal;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.TextBox txtValorInicial;
        private System.Windows.Forms.TabControl TabControl1;
        private System.Windows.Forms.TabPage TabPage1;
        private System.Windows.Forms.DataGridView dtgZonasAsignadas;
        private System.Windows.Forms.CheckedListBox chlZonas;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.RadioButton rbnNoNuevo;
        private System.Windows.Forms.RadioButton rbnSiNuevo;
        private System.Windows.Forms.Button btnAsignaZonas;

    }
}