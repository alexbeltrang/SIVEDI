namespace SIVEDI.ListaPrecios
{
    partial class frmListaPrecioProducto
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
            this.cboListaPrecios = new System.Windows.Forms.ComboBox();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.btnBuscaAsignado = new System.Windows.Forms.Button();
            this.txtNombreProdAsignado = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.dtgProductos = new System.Windows.Forms.DataGridView();
            this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.lblPercent = new System.Windows.Forms.Label();
            this.prbPorcentajeCalculo = new System.Windows.Forms.ProgressBar();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.txtNombreProdDisponible = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.chkListaProductos = new System.Windows.Forms.CheckedListBox();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnCargaInformacion = new System.Windows.Forms.Button();
            this.lblPorcentajeCarga = new System.Windows.Forms.Label();
            this.pbrCarga = new System.Windows.Forms.ProgressBar();
            this.Panel2.SuspendLayout();
            this.Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProductos)).BeginInit();
            this.ContextMenuStrip1.SuspendLayout();
            this.Panel1.SuspendLayout();
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
            // cboListaPrecios
            // 
            this.cboListaPrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListaPrecios.FormattingEnabled = true;
            this.cboListaPrecios.Location = new System.Drawing.Point(85, 6);
            this.cboListaPrecios.Name = "cboListaPrecios";
            this.cboListaPrecios.Size = new System.Drawing.Size(274, 21);
            this.cboListaPrecios.TabIndex = 1;
            this.totCampos.SetToolTip(this.cboListaPrecios, "Campaña a la que pertenece la Lista de precios");
            this.cboListaPrecios.SelectedIndexChanged += new System.EventHandler(this.cboListaPrecios_SelectedIndexChanged);
            // 
            // Panel2
            // 
            this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel2.Controls.Add(this.cboListaPrecios);
            this.Panel2.Controls.Add(this.Label1);
            this.Panel2.Location = new System.Drawing.Point(12, 8);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(451, 35);
            this.Panel2.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(9, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(70, 13);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Lista Precios:";
            // 
            // Panel3
            // 
            this.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel3.Controls.Add(this.btnBuscaAsignado);
            this.Panel3.Controls.Add(this.txtNombreProdAsignado);
            this.Panel3.Controls.Add(this.Label3);
            this.Panel3.Controls.Add(this.dtgProductos);
            this.Panel3.Location = new System.Drawing.Point(12, 88);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(451, 530);
            this.Panel3.TabIndex = 2;
            // 
            // btnBuscaAsignado
            // 
            this.btnBuscaAsignado.Location = new System.Drawing.Point(366, 5);
            this.btnBuscaAsignado.Name = "btnBuscaAsignado";
            this.btnBuscaAsignado.Size = new System.Drawing.Size(75, 20);
            this.btnBuscaAsignado.TabIndex = 16;
            this.btnBuscaAsignado.Text = "Buscar";
            this.btnBuscaAsignado.UseVisualStyleBackColor = true;
            this.btnBuscaAsignado.Click += new System.EventHandler(this.btnBuscaAsignado_Click);
            // 
            // txtNombreProdAsignado
            // 
            this.txtNombreProdAsignado.Location = new System.Drawing.Point(101, 5);
            this.txtNombreProdAsignado.MaxLength = 70;
            this.txtNombreProdAsignado.Name = "txtNombreProdAsignado";
            this.txtNombreProdAsignado.Size = new System.Drawing.Size(255, 20);
            this.txtNombreProdAsignado.TabIndex = 15;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(4, 10);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(93, 13);
            this.Label3.TabIndex = 14;
            this.Label3.Text = "Nombre Producto:";
            // 
            // dtgProductos
            // 
            this.dtgProductos.AllowUserToAddRows = false;
            this.dtgProductos.AllowUserToDeleteRows = false;
            this.dtgProductos.AllowUserToOrderColumns = true;
            this.dtgProductos.AllowUserToResizeRows = false;
            this.dtgProductos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dtgProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgProductos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProductos.ContextMenuStrip = this.ContextMenuStrip1;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgProductos.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgProductos.Location = new System.Drawing.Point(3, 31);
            this.dtgProductos.MultiSelect = false;
            this.dtgProductos.Name = "dtgProductos";
            this.dtgProductos.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgProductos.RowHeadersVisible = false;
            this.dtgProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProductos.ShowEditingIcon = false;
            this.dtgProductos.Size = new System.Drawing.Size(441, 484);
            this.dtgProductos.TabIndex = 13;
            this.dtgProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgProductos_CellDoubleClick);
            // 
            // ContextMenuStrip1
            // 
            this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EliminarToolStripMenuItem});
            this.ContextMenuStrip1.Name = "ContextMenuStrip1";
            this.ContextMenuStrip1.Size = new System.Drawing.Size(118, 26);
            // 
            // EliminarToolStripMenuItem
            // 
            this.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem";
            this.EliminarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.EliminarToolStripMenuItem.Text = "&Eliminar";
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(469, 201);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(68, 35);
            this.btnAsignar.TabIndex = 3;
            this.btnAsignar.Text = "<---Asignar";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(225, 46);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(0, 13);
            this.lblPercent.TabIndex = 53;
            // 
            // prbPorcentajeCalculo
            // 
            this.prbPorcentajeCalculo.Location = new System.Drawing.Point(11, 62);
            this.prbPorcentajeCalculo.Name = "prbPorcentajeCalculo";
            this.prbPorcentajeCalculo.Size = new System.Drawing.Size(452, 10);
            this.prbPorcentajeCalculo.TabIndex = 52;
            // 
            // Panel1
            // 
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel1.Controls.Add(this.btnBuscarProducto);
            this.Panel1.Controls.Add(this.txtNombreProdDisponible);
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Controls.Add(this.chkListaProductos);
            this.Panel1.Location = new System.Drawing.Point(543, 8);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(451, 610);
            this.Panel1.TabIndex = 54;
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.Location = new System.Drawing.Point(369, 3);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(75, 20);
            this.btnBuscarProducto.TabIndex = 3;
            this.btnBuscarProducto.Text = "Buscar";
            this.btnBuscarProducto.UseVisualStyleBackColor = true;
            // 
            // txtNombreProdDisponible
            // 
            this.txtNombreProdDisponible.Location = new System.Drawing.Point(104, 3);
            this.txtNombreProdDisponible.MaxLength = 70;
            this.txtNombreProdDisponible.Name = "txtNombreProdDisponible";
            this.txtNombreProdDisponible.Size = new System.Drawing.Size(255, 20);
            this.txtNombreProdDisponible.TabIndex = 2;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(7, 8);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(93, 13);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Nombre Producto:";
            // 
            // chkListaProductos
            // 
            this.chkListaProductos.CheckOnClick = true;
            this.chkListaProductos.FormattingEnabled = true;
            this.chkListaProductos.Location = new System.Drawing.Point(3, 31);
            this.chkListaProductos.Name = "chkListaProductos";
            this.chkListaProductos.Size = new System.Drawing.Size(441, 574);
            this.chkListaProductos.TabIndex = 0;
            this.chkListaProductos.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkListaProductos_ItemCheck);
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(469, 242);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(68, 52);
            this.btnExportar.TabIndex = 55;
            this.btnExportar.Text = "Exportar Base Cargable";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnCargaInformacion
            // 
            this.btnCargaInformacion.Location = new System.Drawing.Point(469, 300);
            this.btnCargaInformacion.Name = "btnCargaInformacion";
            this.btnCargaInformacion.Size = new System.Drawing.Size(68, 52);
            this.btnCargaInformacion.TabIndex = 56;
            this.btnCargaInformacion.Text = "Cargar Archivo";
            this.btnCargaInformacion.UseVisualStyleBackColor = true;
            // 
            // lblPorcentajeCarga
            // 
            this.lblPorcentajeCarga.AutoSize = true;
            this.lblPorcentajeCarga.Location = new System.Drawing.Point(473, 605);
            this.lblPorcentajeCarga.Name = "lblPorcentajeCarga";
            this.lblPorcentajeCarga.Size = new System.Drawing.Size(64, 13);
            this.lblPorcentajeCarga.TabIndex = 60;
            this.lblPorcentajeCarga.Text = "lblAvanPorc";
            // 
            // pbrCarga
            // 
            this.pbrCarga.Location = new System.Drawing.Point(12, 623);
            this.pbrCarga.Name = "pbrCarga";
            this.pbrCarga.Size = new System.Drawing.Size(977, 18);
            this.pbrCarga.TabIndex = 59;
            // 
            // frmListaPrecioProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 644);
            this.Controls.Add(this.lblPorcentajeCarga);
            this.Controls.Add(this.pbrCarga);
            this.Controls.Add(this.btnCargaInformacion);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.prbPorcentajeCalculo);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.Panel3);
            this.Controls.Add(this.Panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmListaPrecioProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración Productos Lista precios";
            this.Load += new System.EventHandler(this.frmListaPrecioProducto_Load);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProductos)).EndInit();
            this.ContextMenuStrip1.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip totCampos;
        private System.Windows.Forms.Panel Panel2;
        private System.Windows.Forms.ComboBox cboListaPrecios;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Panel Panel3;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.ProgressBar prbPorcentajeCalculo;
        private System.Windows.Forms.DataGridView dtgProductos;
        private System.Windows.Forms.Button btnBuscaAsignado;
        private System.Windows.Forms.TextBox txtNombreProdAsignado;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.TextBox txtNombreProdDisponible;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.CheckedListBox chkListaProductos;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnCargaInformacion;
        private System.Windows.Forms.Label lblPorcentajeCarga;
        private System.Windows.Forms.ProgressBar pbrCarga;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem EliminarToolStripMenuItem;

    }
}