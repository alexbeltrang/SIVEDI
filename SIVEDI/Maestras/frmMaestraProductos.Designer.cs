namespace SIVEDI.Maestras
{
    partial class frmMaestraProductos
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
            this.totCampos = new System.Windows.Forms.ToolTip(this.components);
            this.rbnInactivo = new System.Windows.Forms.RadioButton();
            this.rbnActivo = new System.Windows.Forms.RadioButton();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.txtMotivoVenta = new System.Windows.Forms.TextBox();
            this.txtCGVenta = new System.Windows.Forms.TextBox();
            this.txtCGObsequio = new System.Windows.Forms.TextBox();
            this.txtMotivoObsequio = new System.Windows.Forms.TextBox();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.txtPuntoPremios = new System.Windows.Forms.TextBox();
            this.pnlDatosPerfil = new System.Windows.Forms.Panel();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.cboUnidadMedida = new System.Windows.Forms.ComboBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.dtgProducto = new System.Windows.Forms.DataGridView();
            this.pnlDatosPerfil.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProducto)).BeginInit();
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
            // rbnInactivo
            // 
            this.rbnInactivo.AutoSize = true;
            this.rbnInactivo.Location = new System.Drawing.Point(68, 10);
            this.rbnInactivo.Name = "rbnInactivo";
            this.rbnInactivo.Size = new System.Drawing.Size(63, 17);
            this.rbnInactivo.TabIndex = 12;
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
            this.rbnActivo.TabIndex = 11;
            this.rbnActivo.TabStop = true;
            this.rbnActivo.Text = "&Activo";
            this.totCampos.SetToolTip(this.rbnActivo, "Permite seleccionarlo o usarlo dentro del sistema");
            this.rbnActivo.UseVisualStyleBackColor = true;
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(89, 8);
            this.txtReferencia.MaxLength = 20;
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(137, 20);
            this.txtReferencia.TabIndex = 1;
            this.totCampos.SetToolTip(this.txtReferencia, "Código de Referencia normalmente se registra el codigo del ERP");
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Location = new System.Drawing.Point(89, 34);
            this.txtNombreProducto.MaxLength = 150;
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(496, 20);
            this.txtNombreProducto.TabIndex = 2;
            this.totCampos.SetToolTip(this.txtNombreProducto, "Nombre del Producto");
            // 
            // txtMotivoVenta
            // 
            this.txtMotivoVenta.Location = new System.Drawing.Point(300, 60);
            this.txtMotivoVenta.MaxLength = 5;
            this.txtMotivoVenta.Name = "txtMotivoVenta";
            this.txtMotivoVenta.Size = new System.Drawing.Size(87, 20);
            this.txtMotivoVenta.TabIndex = 4;
            this.totCampos.SetToolTip(this.txtMotivoVenta, "Código Motivo de Venta SU");
            // 
            // txtCGVenta
            // 
            this.txtCGVenta.Location = new System.Drawing.Point(492, 60);
            this.txtCGVenta.MaxLength = 10;
            this.txtCGVenta.Name = "txtCGVenta";
            this.txtCGVenta.Size = new System.Drawing.Size(93, 20);
            this.txtCGVenta.TabIndex = 5;
            this.totCampos.SetToolTip(this.txtCGVenta, "Código Centro de Gasto de Venta SU");
            // 
            // txtCGObsequio
            // 
            this.txtCGObsequio.Location = new System.Drawing.Point(492, 86);
            this.txtCGObsequio.MaxLength = 10;
            this.txtCGObsequio.Name = "txtCGObsequio";
            this.txtCGObsequio.Size = new System.Drawing.Size(93, 20);
            this.txtCGObsequio.TabIndex = 8;
            this.totCampos.SetToolTip(this.txtCGObsequio, "Código Centro de Gasto de Obsequio SU");
            // 
            // txtMotivoObsequio
            // 
            this.txtMotivoObsequio.Location = new System.Drawing.Point(300, 86);
            this.txtMotivoObsequio.MaxLength = 5;
            this.txtMotivoObsequio.Name = "txtMotivoObsequio";
            this.txtMotivoObsequio.Size = new System.Drawing.Size(87, 20);
            this.txtMotivoObsequio.TabIndex = 7;
            this.totCampos.SetToolTip(this.txtMotivoObsequio, "Código Motivo de Obsequio SU ");
            // 
            // txtIva
            // 
            this.txtIva.Location = new System.Drawing.Point(89, 60);
            this.txtIva.MaxLength = 5;
            this.txtIva.Name = "txtIva";
            this.txtIva.Size = new System.Drawing.Size(50, 20);
            this.txtIva.TabIndex = 3;
            this.totCampos.SetToolTip(this.txtIva, "Porcentaje del IVA");
            this.txtIva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIva_KeyPress);
            // 
            // txtPuntoPremios
            // 
            this.txtPuntoPremios.Location = new System.Drawing.Point(89, 86);
            this.txtPuntoPremios.MaxLength = 6;
            this.txtPuntoPremios.Name = "txtPuntoPremios";
            this.txtPuntoPremios.Size = new System.Drawing.Size(50, 20);
            this.txtPuntoPremios.TabIndex = 6;
            this.totCampos.SetToolTip(this.txtPuntoPremios, "Totsl puntos que entrega el productos para concursos");
            this.txtPuntoPremios.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPuntoPremios_KeyPress);
            // 
            // pnlDatosPerfil
            // 
            this.pnlDatosPerfil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatosPerfil.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDatosPerfil.Controls.Add(this.Label10);
            this.pnlDatosPerfil.Controls.Add(this.txtPuntoPremios);
            this.pnlDatosPerfil.Controls.Add(this.Label9);
            this.pnlDatosPerfil.Controls.Add(this.cboUnidadMedida);
            this.pnlDatosPerfil.Controls.Add(this.txtCGObsequio);
            this.pnlDatosPerfil.Controls.Add(this.Label7);
            this.pnlDatosPerfil.Controls.Add(this.txtMotivoObsequio);
            this.pnlDatosPerfil.Controls.Add(this.Label8);
            this.pnlDatosPerfil.Controls.Add(this.txtCGVenta);
            this.pnlDatosPerfil.Controls.Add(this.Label6);
            this.pnlDatosPerfil.Controls.Add(this.txtMotivoVenta);
            this.pnlDatosPerfil.Controls.Add(this.Label5);
            this.pnlDatosPerfil.Controls.Add(this.txtIva);
            this.pnlDatosPerfil.Controls.Add(this.Label4);
            this.pnlDatosPerfil.Controls.Add(this.txtNombreProducto);
            this.pnlDatosPerfil.Controls.Add(this.Label3);
            this.pnlDatosPerfil.Controls.Add(this.btnNuevo);
            this.pnlDatosPerfil.Controls.Add(this.btnGrabar);
            this.pnlDatosPerfil.Controls.Add(this.Label2);
            this.pnlDatosPerfil.Controls.Add(this.GroupBox1);
            this.pnlDatosPerfil.Controls.Add(this.txtReferencia);
            this.pnlDatosPerfil.Controls.Add(this.Label1);
            this.pnlDatosPerfil.Location = new System.Drawing.Point(6, 1);
            this.pnlDatosPerfil.Name = "pnlDatosPerfil";
            this.pnlDatosPerfil.Size = new System.Drawing.Size(623, 192);
            this.pnlDatosPerfil.TabIndex = 60;
            // 
            // Label10
            // 
            this.Label10.Location = new System.Drawing.Point(27, 84);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(56, 35);
            this.Label10.TabIndex = 73;
            this.Label10.Text = "Puntos Calificables";
            this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(4, 119);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(79, 13);
            this.Label9.TabIndex = 72;
            this.Label9.Text = "Unidad Medida";
            // 
            // cboUnidadMedida
            // 
            this.cboUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnidadMedida.FormattingEnabled = true;
            this.cboUnidadMedida.Location = new System.Drawing.Point(89, 116);
            this.cboUnidadMedida.Name = "cboUnidadMedida";
            this.cboUnidadMedida.Size = new System.Drawing.Size(203, 21);
            this.cboUnidadMedida.TabIndex = 9;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(416, 91);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(70, 13);
            this.Label7.TabIndex = 70;
            this.Label7.Text = "CG Obsequio";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(205, 87);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(87, 13);
            this.Label8.TabIndex = 69;
            this.Label8.Text = "Motivo Obsequio";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(433, 63);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(53, 13);
            this.Label6.TabIndex = 66;
            this.Label6.Text = "CG Venta";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(222, 63);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(70, 13);
            this.Label5.TabIndex = 64;
            this.Label5.Text = "Motivo Venta";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(48, 63);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(35, 13);
            this.Label4.TabIndex = 62;
            this.Label4.Text = "% IVA";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(39, 37);
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
            this.btnNuevo.TabIndex = 14;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(330, 144);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 13;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(40, 148);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(43, 13);
            this.Label2.TabIndex = 57;
            this.Label2.Text = "Estado:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.rbnInactivo);
            this.GroupBox1.Controls.Add(this.rbnActivo);
            this.GroupBox1.Location = new System.Drawing.Point(89, 135);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(136, 32);
            this.GroupBox1.TabIndex = 10;
            this.GroupBox1.TabStop = false;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(24, 11);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(59, 13);
            this.Label1.TabIndex = 54;
            this.Label1.Text = "Referencia";
            // 
            // dtgProducto
            // 
            this.dtgProducto.AllowUserToAddRows = false;
            this.dtgProducto.AllowUserToDeleteRows = false;
            this.dtgProducto.AllowUserToOrderColumns = true;
            this.dtgProducto.AllowUserToResizeRows = false;
            this.dtgProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgProducto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgProducto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgProducto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgProducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dtgProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgProducto.DefaultCellStyle = dataGridViewCellStyle11;
            this.dtgProducto.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgProducto.Location = new System.Drawing.Point(5, 199);
            this.dtgProducto.MultiSelect = false;
            this.dtgProducto.Name = "dtgProducto";
            this.dtgProducto.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgProducto.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dtgProducto.RowHeadersVisible = false;
            this.dtgProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProducto.ShowEditingIcon = false;
            this.dtgProducto.Size = new System.Drawing.Size(626, 281);
            this.dtgProducto.TabIndex = 15;
            this.dtgProducto.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgProducto_CellDoubleClick);
            // 
            // frmMaestraProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 492);
            this.Controls.Add(this.pnlDatosPerfil);
            this.Controls.Add(this.dtgProducto);
            this.Name = "frmMaestraProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maestra de Productos";
            this.Activated += new System.EventHandler(this.frmMaestraProductos_Activated);
            this.Load += new System.EventHandler(this.frmMaestraProductos_Load);
            this.pnlDatosPerfil.ResumeLayout(false);
            this.pnlDatosPerfil.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProducto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip totCampos;
        private System.Windows.Forms.Panel pnlDatosPerfil;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.RadioButton rbnInactivo;
        private System.Windows.Forms.RadioButton rbnActivo;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.DataGridView dtgProducto;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label Label9;
        private System.Windows.Forms.ComboBox cboUnidadMedida;
        private System.Windows.Forms.TextBox txtCGObsequio;
        private System.Windows.Forms.Label Label7;
        private System.Windows.Forms.TextBox txtMotivoObsequio;
        private System.Windows.Forms.Label Label8;
        private System.Windows.Forms.TextBox txtCGVenta;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.TextBox txtMotivoVenta;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.Label Label10;
        private System.Windows.Forms.TextBox txtPuntoPremios;

    }
}