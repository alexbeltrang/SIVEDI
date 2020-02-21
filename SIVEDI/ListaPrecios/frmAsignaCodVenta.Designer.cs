namespace SIVEDI.ListaPrecios
{
    partial class frmAsignaCodVenta
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
            this.dtgCodigoVenta = new System.Windows.Forms.DataGridView();
            this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label5 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbInactivo = new System.Windows.Forms.RadioButton();
            this.rdbActivo = new System.Windows.Forms.RadioButton();
            this.Label4 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbNoPrincipal = new System.Windows.Forms.RadioButton();
            this.rdbEsPrincipal = new System.Windows.Forms.RadioButton();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.txtCodigoVenta = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtCodigoProducto = new System.Windows.Forms.TextBox();
            this.totCampos = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCodigoVenta)).BeginInit();
            this.ContextMenuStrip1.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgCodigoVenta
            // 
            this.dtgCodigoVenta.AllowUserToAddRows = false;
            this.dtgCodigoVenta.AllowUserToDeleteRows = false;
            this.dtgCodigoVenta.AllowUserToOrderColumns = true;
            this.dtgCodigoVenta.AllowUserToResizeRows = false;
            this.dtgCodigoVenta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dtgCodigoVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgCodigoVenta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgCodigoVenta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCodigoVenta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgCodigoVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCodigoVenta.ContextMenuStrip = this.ContextMenuStrip1;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCodigoVenta.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgCodigoVenta.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgCodigoVenta.Location = new System.Drawing.Point(12, 118);
            this.dtgCodigoVenta.MultiSelect = false;
            this.dtgCodigoVenta.Name = "dtgCodigoVenta";
            this.dtgCodigoVenta.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCodigoVenta.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgCodigoVenta.RowHeadersVisible = false;
            this.dtgCodigoVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCodigoVenta.ShowEditingIcon = false;
            this.dtgCodigoVenta.Size = new System.Drawing.Size(680, 236);
            this.dtgCodigoVenta.TabIndex = 11;
            this.dtgCodigoVenta.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCodigoVenta_CellDoubleClick);
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
            this.EliminarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.EliminarToolStripMenuItem.Text = "&Eliminar";
            this.EliminarToolStripMenuItem.Click += new System.EventHandler(this.EliminarToolStripMenuItem_Click);
            // 
            // Panel1
            // 
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel1.Controls.Add(this.Label5);
            this.Panel1.Controls.Add(this.GroupBox2);
            this.Panel1.Controls.Add(this.Label4);
            this.Panel1.Controls.Add(this.GroupBox1);
            this.Panel1.Controls.Add(this.btnAsignar);
            this.Panel1.Controls.Add(this.txtCodigoVenta);
            this.Panel1.Controls.Add(this.Label3);
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Controls.Add(this.txtNombreProducto);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this.txtCodigoProducto);
            this.Panel1.Location = new System.Drawing.Point(13, 13);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(679, 99);
            this.Panel1.TabIndex = 0;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(211, 48);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(43, 13);
            this.Label5.TabIndex = 68;
            this.Label5.Text = "Estado:";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.rdbInactivo);
            this.GroupBox2.Controls.Add(this.rdbActivo);
            this.GroupBox2.Location = new System.Drawing.Point(214, 57);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(142, 32);
            this.GroupBox2.TabIndex = 7;
            this.GroupBox2.TabStop = false;
            // 
            // rdbInactivo
            // 
            this.rdbInactivo.AutoSize = true;
            this.rdbInactivo.Location = new System.Drawing.Point(71, 10);
            this.rdbInactivo.Name = "rdbInactivo";
            this.rdbInactivo.Size = new System.Drawing.Size(63, 17);
            this.rdbInactivo.TabIndex = 9;
            this.rdbInactivo.TabStop = true;
            this.rdbInactivo.Text = "&Inactivo";
            this.totCampos.SetToolTip(this.rdbInactivo, "Bloquea la  utilización  el producto en en sistema");
            this.rdbInactivo.UseVisualStyleBackColor = true;
            // 
            // rdbActivo
            // 
            this.rdbActivo.AutoSize = true;
            this.rdbActivo.Location = new System.Drawing.Point(7, 10);
            this.rdbActivo.Name = "rdbActivo";
            this.rdbActivo.Size = new System.Drawing.Size(55, 17);
            this.rdbActivo.TabIndex = 8;
            this.rdbActivo.TabStop = true;
            this.rdbActivo.Text = "&Activo";
            this.totCampos.SetToolTip(this.rdbActivo, "Permite el utilizar el producto en en sistema");
            this.rdbActivo.UseVisualStyleBackColor = true;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(115, 48);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(65, 13);
            this.Label4.TabIndex = 66;
            this.Label4.Text = "Es Principal:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.rdbNoPrincipal);
            this.GroupBox1.Controls.Add(this.rdbEsPrincipal);
            this.GroupBox1.Location = new System.Drawing.Point(118, 57);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(90, 32);
            this.GroupBox1.TabIndex = 4;
            this.GroupBox1.TabStop = false;
            // 
            // rdbNoPrincipal
            // 
            this.rdbNoPrincipal.AutoSize = true;
            this.rdbNoPrincipal.Location = new System.Drawing.Point(45, 10);
            this.rdbNoPrincipal.Name = "rdbNoPrincipal";
            this.rdbNoPrincipal.Size = new System.Drawing.Size(39, 17);
            this.rdbNoPrincipal.TabIndex = 6;
            this.rdbNoPrincipal.TabStop = true;
            this.rdbNoPrincipal.Text = "&No";
            this.totCampos.SetToolTip(this.rdbNoPrincipal, "Registra el codigo de venta como No principal");
            this.rdbNoPrincipal.UseVisualStyleBackColor = true;
            // 
            // rdbEsPrincipal
            // 
            this.rdbEsPrincipal.AutoSize = true;
            this.rdbEsPrincipal.Location = new System.Drawing.Point(7, 10);
            this.rdbEsPrincipal.Name = "rdbEsPrincipal";
            this.rdbEsPrincipal.Size = new System.Drawing.Size(34, 17);
            this.rdbEsPrincipal.TabIndex = 5;
            this.rdbEsPrincipal.TabStop = true;
            this.rdbEsPrincipal.Text = "&Si";
            this.totCampos.SetToolTip(this.rdbEsPrincipal, "Registra el codigo de venta como principal");
            this.rdbEsPrincipal.UseVisualStyleBackColor = true;
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(384, 52);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(86, 37);
            this.btnAsignar.TabIndex = 10;
            this.btnAsignar.Text = "&Asignar Código Venta";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // txtCodigoVenta
            // 
            this.txtCodigoVenta.Location = new System.Drawing.Point(9, 65);
            this.txtCodigoVenta.MaxLength = 15;
            this.txtCodigoVenta.Name = "txtCodigoVenta";
            this.txtCodigoVenta.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoVenta.TabIndex = 3;
            this.totCampos.SetToolTip(this.txtCodigoVenta, "Digite código de venta a asignarle al producto");
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(12, 48);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(71, 13);
            this.Label3.TabIndex = 4;
            this.Label3.Text = "Código Venta";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(115, 4);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(93, 13);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Nombre Producto:";
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.BackColor = System.Drawing.Color.White;
            this.txtNombreProducto.Enabled = false;
            this.txtNombreProducto.Location = new System.Drawing.Point(115, 21);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.ReadOnly = true;
            this.txtNombreProducto.Size = new System.Drawing.Size(416, 20);
            this.txtNombreProducto.TabIndex = 2;
            this.totCampos.SetToolTip(this.txtNombreProducto, "Nombre del producto al cual se le asignará el código de venta");
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(9, 4);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(89, 13);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Código Producto:";
            // 
            // txtCodigoProducto
            // 
            this.txtCodigoProducto.BackColor = System.Drawing.Color.White;
            this.txtCodigoProducto.Enabled = false;
            this.txtCodigoProducto.Location = new System.Drawing.Point(9, 21);
            this.txtCodigoProducto.Name = "txtCodigoProducto";
            this.txtCodigoProducto.ReadOnly = true;
            this.txtCodigoProducto.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoProducto.TabIndex = 1;
            this.txtCodigoProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.totCampos.SetToolTip(this.txtCodigoProducto, "Código de producto al cual se le asignará el código de venta");
            // 
            // totCampos
            // 
            this.totCampos.AutoPopDelay = 3000;
            this.totCampos.InitialDelay = 20;
            this.totCampos.IsBalloon = true;
            this.totCampos.ReshowDelay = 100;
            this.totCampos.ShowAlways = true;
            // 
            // frmAsignaCodVenta
            // 
            this.AcceptButton = this.btnAsignar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 366);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.dtgCodigoVenta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmAsignaCodVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración de Códigos de Venta";
            this.Activated += new System.EventHandler(this.frmAsignaCodVenta_Activated);
            this.Load += new System.EventHandler(this.frmAsignaCodVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCodigoVenta)).EndInit();
            this.ContextMenuStrip1.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dtgCodigoVenta;
        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.TextBox txtCodigoVenta;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox txtCodigoProducto;
        private System.Windows.Forms.ToolTip totCampos;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.RadioButton rdbNoPrincipal;
        private System.Windows.Forms.RadioButton rdbEsPrincipal;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.RadioButton rdbInactivo;
        private System.Windows.Forms.RadioButton rdbActivo;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem EliminarToolStripMenuItem;

    }
}