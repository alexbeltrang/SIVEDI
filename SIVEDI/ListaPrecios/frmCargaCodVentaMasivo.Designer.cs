namespace SIVEDI.ListaPrecios
{
    partial class frmCargaCodVentaMasivo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnCargarArchivo = new System.Windows.Forms.Button();
            this.txtRutaArchivo = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.dtgCodigoVenta = new System.Windows.Forms.DataGridView();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.totCampos = new System.Windows.Forms.ToolTip(this.components);
            this.lblPorcentajeCarga = new System.Windows.Forms.Label();
            this.pbrCarga = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCodigoVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.FileName = "OpenFileDialog1";
            // 
            // btnCargarArchivo
            // 
            this.btnCargarArchivo.Location = new System.Drawing.Point(755, 29);
            this.btnCargarArchivo.Name = "btnCargarArchivo";
            this.btnCargarArchivo.Size = new System.Drawing.Size(35, 23);
            this.btnCargarArchivo.TabIndex = 0;
            this.btnCargarArchivo.Text = "...";
            this.btnCargarArchivo.UseVisualStyleBackColor = true;
            this.btnCargarArchivo.Click += new System.EventHandler(this.btnCargarArchivo_Click);
            // 
            // txtRutaArchivo
            // 
            this.txtRutaArchivo.Location = new System.Drawing.Point(15, 30);
            this.txtRutaArchivo.Name = "txtRutaArchivo";
            this.txtRutaArchivo.Size = new System.Drawing.Size(741, 20);
            this.txtRutaArchivo.TabIndex = 1;
            this.totCampos.SetToolTip(this.txtRutaArchivo, "Ruta y nombre del archivo a cargar");
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 14);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(117, 13);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Ruta Archivo de carga:";
            // 
            // dtgCodigoVenta
            // 
            this.dtgCodigoVenta.AllowUserToAddRows = false;
            this.dtgCodigoVenta.AllowUserToDeleteRows = false;
            this.dtgCodigoVenta.AllowUserToOrderColumns = true;
            this.dtgCodigoVenta.AllowUserToResizeRows = false;
            this.dtgCodigoVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgCodigoVenta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgCodigoVenta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCodigoVenta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgCodigoVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCodigoVenta.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgCodigoVenta.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgCodigoVenta.Location = new System.Drawing.Point(12, 85);
            this.dtgCodigoVenta.MultiSelect = false;
            this.dtgCodigoVenta.Name = "dtgCodigoVenta";
            this.dtgCodigoVenta.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCodigoVenta.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgCodigoVenta.RowHeadersVisible = false;
            this.dtgCodigoVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCodigoVenta.ShowEditingIcon = false;
            this.dtgCodigoVenta.Size = new System.Drawing.Size(775, 503);
            this.dtgCodigoVenta.TabIndex = 12;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(12, 56);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 14;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // totCampos
            // 
            this.totCampos.AutoPopDelay = 3000;
            this.totCampos.InitialDelay = 20;
            this.totCampos.IsBalloon = true;
            this.totCampos.ReshowDelay = 100;
            this.totCampos.ShowAlways = true;
            // 
            // lblPorcentajeCarga
            // 
            this.lblPorcentajeCarga.AutoSize = true;
            this.lblPorcentajeCarga.Location = new System.Drawing.Point(360, 591);
            this.lblPorcentajeCarga.Name = "lblPorcentajeCarga";
            this.lblPorcentajeCarga.Size = new System.Drawing.Size(64, 13);
            this.lblPorcentajeCarga.TabIndex = 62;
            this.lblPorcentajeCarga.Text = "lblAvanPorc";
            // 
            // pbrCarga
            // 
            this.pbrCarga.Location = new System.Drawing.Point(12, 607);
            this.pbrCarga.Name = "pbrCarga";
            this.pbrCarga.Size = new System.Drawing.Size(775, 18);
            this.pbrCarga.TabIndex = 61;
            // 
            // frmCargaCodVentaMasivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 635);
            this.Controls.Add(this.lblPorcentajeCarga);
            this.Controls.Add(this.pbrCarga);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.dtgCodigoVenta);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtRutaArchivo);
            this.Controls.Add(this.btnCargarArchivo);
            this.Name = "frmCargaCodVentaMasivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carga Masiva códigos venta";
            this.Load += new System.EventHandler(this.frmCargaCodVentaMasivo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCodigoVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        private System.Windows.Forms.Button btnCargarArchivo;
        private System.Windows.Forms.TextBox txtRutaArchivo;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.DataGridView dtgCodigoVenta;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.ToolTip totCampos;
        private System.Windows.Forms.Label lblPorcentajeCarga;
        private System.Windows.Forms.ProgressBar pbrCarga;
    }
}