namespace SIVEDI.Mantenimiento
{
    partial class frmOfertaSimple
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
            this.Panel1 = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtNombreOferta = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.cbolistaPrecios = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.totCampos = new System.Windows.Forms.ToolTip(this.components);
            this.dtgOfertaSimples = new System.Windows.Forms.DataGridView();
            this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AdicionarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrActualiza = new System.Windows.Forms.Timer(this.components);
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOfertaSimples)).BeginInit();
            this.ContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel1.Controls.Add(this.btnBuscar);
            this.Panel1.Controls.Add(this.txtNombreOferta);
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Controls.Add(this.cbolistaPrecios);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Location = new System.Drawing.Point(12, 12);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(798, 109);
            this.Panel1.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(336, 72);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtNombreOferta
            // 
            this.txtNombreOferta.Location = new System.Drawing.Point(96, 46);
            this.txtNombreOferta.MaxLength = 50;
            this.txtNombreOferta.Name = "txtNombreOferta";
            this.txtNombreOferta.Size = new System.Drawing.Size(460, 20);
            this.txtNombreOferta.TabIndex = 3;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(13, 46);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(76, 13);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Nombre Oferta";
            // 
            // cbolistaPrecios
            // 
            this.cbolistaPrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbolistaPrecios.FormattingEnabled = true;
            this.cbolistaPrecios.Location = new System.Drawing.Point(95, 11);
            this.cbolistaPrecios.Name = "cbolistaPrecios";
            this.cbolistaPrecios.Size = new System.Drawing.Size(229, 21);
            this.cbolistaPrecios.TabIndex = 1;
            this.totCampos.SetToolTip(this.cbolistaPrecios, "Seleccione la lista de precios para filtrar información");
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(22, 14);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(67, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Lista Precios";
            // 
            // totCampos
            // 
            this.totCampos.AutoPopDelay = 3000;
            this.totCampos.InitialDelay = 20;
            this.totCampos.IsBalloon = true;
            this.totCampos.ReshowDelay = 100;
            this.totCampos.ShowAlways = true;
            // 
            // dtgOfertaSimples
            // 
            this.dtgOfertaSimples.AllowUserToAddRows = false;
            this.dtgOfertaSimples.AllowUserToDeleteRows = false;
            this.dtgOfertaSimples.AllowUserToResizeRows = false;
            this.dtgOfertaSimples.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgOfertaSimples.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgOfertaSimples.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgOfertaSimples.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgOfertaSimples.ContextMenuStrip = this.ContextMenuStrip1;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgOfertaSimples.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgOfertaSimples.Location = new System.Drawing.Point(12, 128);
            this.dtgOfertaSimples.MultiSelect = false;
            this.dtgOfertaSimples.Name = "dtgOfertaSimples";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgOfertaSimples.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgOfertaSimples.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgOfertaSimples.ShowCellErrors = false;
            this.dtgOfertaSimples.ShowEditingIcon = false;
            this.dtgOfertaSimples.ShowRowErrors = false;
            this.dtgOfertaSimples.Size = new System.Drawing.Size(798, 297);
            this.dtgOfertaSimples.TabIndex = 1;
            this.totCampos.SetToolTip(this.dtgOfertaSimples, "Listado de ofertas registradas en el sistema");
            this.dtgOfertaSimples.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgOfertaSimples_CellDoubleClick);
            // 
            // ContextMenuStrip1
            // 
            this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AdicionarToolStripMenuItem,
            this.EditarToolStripMenuItem});
            this.ContextMenuStrip1.Name = "ContextMenuStrip1";
            this.ContextMenuStrip1.Size = new System.Drawing.Size(126, 48);
            // 
            // AdicionarToolStripMenuItem
            // 
            this.AdicionarToolStripMenuItem.Name = "AdicionarToolStripMenuItem";
            this.AdicionarToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.AdicionarToolStripMenuItem.Text = "&Adicionar";
            this.AdicionarToolStripMenuItem.Click += new System.EventHandler(this.AdicionarToolStripMenuItem_Click);
            // 
            // EditarToolStripMenuItem
            // 
            this.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem";
            this.EditarToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.EditarToolStripMenuItem.Text = "&Editar";
            this.EditarToolStripMenuItem.Click += new System.EventHandler(this.EditarToolStripMenuItem_Click);
            // 
            // tmrActualiza
            // 
            this.tmrActualiza.Interval = 1000;
            this.tmrActualiza.Tick += new System.EventHandler(this.tmrActualiza_Tick);
            // 
            // frmOfertaSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 472);
            this.Controls.Add(this.dtgOfertaSimples);
            this.Controls.Add(this.Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOfertaSimple";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parametrización Ofertas Simples";
            this.Load += new System.EventHandler(this.frmOfertaSimple_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOfertaSimples)).EndInit();
            this.ContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.ComboBox cbolistaPrecios;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.ToolTip totCampos;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtNombreOferta;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.DataGridView dtgOfertaSimples;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AdicionarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditarToolStripMenuItem;
        private System.Windows.Forms.Timer tmrActualiza;

    }
}