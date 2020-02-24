namespace SIVEDI.Operaciones
{
    partial class frmDigitaPedidos
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
            this.txtIdentificacionAS = new System.Windows.Forms.TextBox();
            this.txtCampanaAsignada = new System.Windows.Forms.TextBox();
            this.txtCupo = new System.Windows.Forms.TextBox();
            this.txtTelCelular = new System.Windows.Forms.TextBox();
            this.txtTelFijo = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtNombreAsesor = new System.Windows.Forms.TextBox();
            this.txtTotalaPagar = new System.Windows.Forms.TextBox();
            this.txtDescEscala = new System.Windows.Forms.TextBox();
            this.txtValorPublico = new System.Windows.Forms.TextBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnLiquidar = new System.Windows.Forms.Button();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.txtUnidades = new System.Windows.Forms.TextBox();
            this.txtCodigoProducto = new System.Windows.Forms.TextBox();
            this.dtgPedidosOriginal = new System.Windows.Forms.DataGridView();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtPorcEscala = new System.Windows.Forms.TextBox();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPedidosOriginal)).BeginInit();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.Panel3.SuspendLayout();
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
            // txtIdentificacionAS
            // 
            this.txtIdentificacionAS.Location = new System.Drawing.Point(81, 6);
            this.txtIdentificacionAS.MaxLength = 15;
            this.txtIdentificacionAS.Name = "txtIdentificacionAS";
            this.txtIdentificacionAS.Size = new System.Drawing.Size(145, 20);
            this.txtIdentificacionAS.TabIndex = 2;
            this.totCampos.SetToolTip(this.txtIdentificacionAS, "Número de Identificación del Asesor");
            this.txtIdentificacionAS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdentificacionAS_KeyPress);
            this.txtIdentificacionAS.Leave += new System.EventHandler(this.txtIdentificacionAS_Leave);
            // 
            // txtCampanaAsignada
            // 
            this.txtCampanaAsignada.BackColor = System.Drawing.Color.White;
            this.txtCampanaAsignada.Enabled = false;
            this.txtCampanaAsignada.Location = new System.Drawing.Point(759, 58);
            this.txtCampanaAsignada.Name = "txtCampanaAsignada";
            this.txtCampanaAsignada.ReadOnly = true;
            this.txtCampanaAsignada.Size = new System.Drawing.Size(145, 20);
            this.txtCampanaAsignada.TabIndex = 17;
            this.totCampos.SetToolTip(this.txtCampanaAsignada, "Campaña autorizada para facturar");
            // 
            // txtCupo
            // 
            this.txtCupo.BackColor = System.Drawing.Color.White;
            this.txtCupo.Enabled = false;
            this.txtCupo.Location = new System.Drawing.Point(510, 58);
            this.txtCupo.Name = "txtCupo";
            this.txtCupo.ReadOnly = true;
            this.txtCupo.Size = new System.Drawing.Size(158, 20);
            this.txtCupo.TabIndex = 15;
            this.totCampos.SetToolTip(this.txtCupo, "Cupo de Crédito aprobado");
            // 
            // txtTelCelular
            // 
            this.txtTelCelular.BackColor = System.Drawing.Color.White;
            this.txtTelCelular.Enabled = false;
            this.txtTelCelular.Location = new System.Drawing.Point(284, 58);
            this.txtTelCelular.Name = "txtTelCelular";
            this.txtTelCelular.ReadOnly = true;
            this.txtTelCelular.Size = new System.Drawing.Size(145, 20);
            this.txtTelCelular.TabIndex = 13;
            this.totCampos.SetToolTip(this.txtTelCelular, "Número Telefóno Celular");
            // 
            // txtTelFijo
            // 
            this.txtTelFijo.BackColor = System.Drawing.Color.White;
            this.txtTelFijo.Enabled = false;
            this.txtTelFijo.Location = new System.Drawing.Point(81, 58);
            this.txtTelFijo.Name = "txtTelFijo";
            this.txtTelFijo.ReadOnly = true;
            this.txtTelFijo.Size = new System.Drawing.Size(145, 20);
            this.txtTelFijo.TabIndex = 11;
            this.totCampos.SetToolTip(this.txtTelFijo, "Número Teléfono Fijo");
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(480, 32);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(424, 20);
            this.txtEmail.TabIndex = 9;
            this.totCampos.SetToolTip(this.txtEmail, "Correo Electrónico");
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.White;
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(81, 32);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(334, 20);
            this.txtDireccion.TabIndex = 7;
            this.totCampos.SetToolTip(this.txtDireccion, "Dirección de Entrega");
            // 
            // txtNombreAsesor
            // 
            this.txtNombreAsesor.BackColor = System.Drawing.Color.White;
            this.txtNombreAsesor.Enabled = false;
            this.txtNombreAsesor.Location = new System.Drawing.Point(283, 6);
            this.txtNombreAsesor.Name = "txtNombreAsesor";
            this.txtNombreAsesor.ReadOnly = true;
            this.txtNombreAsesor.Size = new System.Drawing.Size(621, 20);
            this.txtNombreAsesor.TabIndex = 5;
            this.totCampos.SetToolTip(this.txtNombreAsesor, "Nombre del Asesor");
            // 
            // txtTotalaPagar
            // 
            this.txtTotalaPagar.BackColor = System.Drawing.Color.White;
            this.txtTotalaPagar.Enabled = false;
            this.txtTotalaPagar.Location = new System.Drawing.Point(655, 24);
            this.txtTotalaPagar.Name = "txtTotalaPagar";
            this.txtTotalaPagar.ReadOnly = true;
            this.txtTotalaPagar.Size = new System.Drawing.Size(85, 20);
            this.txtTotalaPagar.TabIndex = 17;
            this.totCampos.SetToolTip(this.txtTotalaPagar, "Total a Pagar del pedido");
            // 
            // txtDescEscala
            // 
            this.txtDescEscala.BackColor = System.Drawing.Color.White;
            this.txtDescEscala.Enabled = false;
            this.txtDescEscala.Location = new System.Drawing.Point(329, 24);
            this.txtDescEscala.Name = "txtDescEscala";
            this.txtDescEscala.ReadOnly = true;
            this.txtDescEscala.Size = new System.Drawing.Size(69, 20);
            this.txtDescEscala.TabIndex = 15;
            this.totCampos.SetToolTip(this.txtDescEscala, "Porcentaje de descuento por escalas");
            // 
            // txtValorPublico
            // 
            this.txtValorPublico.BackColor = System.Drawing.Color.White;
            this.txtValorPublico.Enabled = false;
            this.txtValorPublico.Location = new System.Drawing.Point(93, 24);
            this.txtValorPublico.Name = "txtValorPublico";
            this.txtValorPublico.ReadOnly = true;
            this.txtValorPublico.Size = new System.Drawing.Size(145, 20);
            this.txtValorPublico.TabIndex = 13;
            this.totCampos.SetToolTip(this.txtValorPublico, "Valor total Público del Pedido");
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(348, 36);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar.TabIndex = 7;
            this.btnAdicionar.Text = "&Adicionar";
            this.totCampos.SetToolTip(this.btnAdicionar, "Adiciona el producto al pedido");
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnLiquidar
            // 
            this.btnLiquidar.Location = new System.Drawing.Point(429, 36);
            this.btnLiquidar.Name = "btnLiquidar";
            this.btnLiquidar.Size = new System.Drawing.Size(75, 23);
            this.btnLiquidar.TabIndex = 6;
            this.btnLiquidar.Text = "Preliquidar";
            this.totCampos.SetToolTip(this.btnLiquidar, "Preliquida el pedido aplicando todas las ofertas comerciales y concursos.");
            this.btnLiquidar.UseVisualStyleBackColor = true;
            this.btnLiquidar.Click += new System.EventHandler(this.btnLiquidar_Click);
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreProducto.Enabled = false;
            this.txtNombreProducto.Location = new System.Drawing.Point(330, 5);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.ReadOnly = true;
            this.txtNombreProducto.Size = new System.Drawing.Size(569, 20);
            this.txtNombreProducto.TabIndex = 4;
            this.totCampos.SetToolTip(this.txtNombreProducto, "Nombre del producto");
            // 
            // txtUnidades
            // 
            this.txtUnidades.Location = new System.Drawing.Point(270, 5);
            this.txtUnidades.MaxLength = 5;
            this.txtUnidades.Name = "txtUnidades";
            this.txtUnidades.Size = new System.Drawing.Size(53, 20);
            this.txtUnidades.TabIndex = 2;
            this.totCampos.SetToolTip(this.txtUnidades, "Unidades Solicitadas");
            this.txtUnidades.Enter += new System.EventHandler(this.txtUnidades_Enter);
            this.txtUnidades.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnidades_KeyPress);
            // 
            // txtCodigoProducto
            // 
            this.txtCodigoProducto.Location = new System.Drawing.Point(102, 4);
            this.txtCodigoProducto.MaxLength = 50;
            this.txtCodigoProducto.Name = "txtCodigoProducto";
            this.txtCodigoProducto.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoProducto.TabIndex = 0;
            this.totCampos.SetToolTip(this.txtCodigoProducto, "Código de Venta del producto");
            this.txtCodigoProducto.Enter += new System.EventHandler(this.txtCodigoProducto_Enter);
            this.txtCodigoProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProducto_KeyPress);
            this.txtCodigoProducto.Leave += new System.EventHandler(this.txtCodigoProducto_Leave);
            // 
            // dtgPedidosOriginal
            // 
            this.dtgPedidosOriginal.AllowUserToAddRows = false;
            this.dtgPedidosOriginal.AllowUserToDeleteRows = false;
            this.dtgPedidosOriginal.AllowUserToResizeRows = false;
            this.dtgPedidosOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgPedidosOriginal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgPedidosOriginal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPedidosOriginal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgPedidosOriginal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPedidosOriginal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar,
            this.Eliminar});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgPedidosOriginal.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgPedidosOriginal.Location = new System.Drawing.Point(12, 247);
            this.dtgPedidosOriginal.Name = "dtgPedidosOriginal";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPedidosOriginal.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgPedidosOriginal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPedidosOriginal.ShowCellErrors = false;
            this.dtgPedidosOriginal.ShowRowErrors = false;
            this.dtgPedidosOriginal.Size = new System.Drawing.Size(911, 409);
            this.dtgPedidosOriginal.TabIndex = 2;
            this.totCampos.SetToolTip(this.dtgPedidosOriginal, "Items del pedido");
            this.dtgPedidosOriginal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPedidosOriginal_CellContentClick);
            // 
            // Editar
            // 
            this.Editar.HeaderText = "";
            this.Editar.Name = "Editar";
            this.Editar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Editar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Editar.Text = "Editar";
            this.Editar.ToolTipText = "Edita Registro";
            this.Editar.UseColumnTextForButtonValue = true;
            this.Editar.Width = 19;
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Eliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.ToolTipText = "Elimina Regitro";
            this.Eliminar.UseColumnTextForButtonValue = true;
            this.Eliminar.Width = 19;
            // 
            // txtPorcEscala
            // 
            this.txtPorcEscala.BackColor = System.Drawing.Color.White;
            this.txtPorcEscala.Enabled = false;
            this.txtPorcEscala.Location = new System.Drawing.Point(494, 24);
            this.txtPorcEscala.Name = "txtPorcEscala";
            this.txtPorcEscala.ReadOnly = true;
            this.txtPorcEscala.Size = new System.Drawing.Size(61, 20);
            this.txtPorcEscala.TabIndex = 19;
            this.totCampos.SetToolTip(this.txtPorcEscala, "Total a Pagar del pedido");
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(511, 36);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 8;
            this.btnGrabar.Text = "&Grabar";
            this.totCampos.SetToolTip(this.btnGrabar, "Graba el pedido en el Sistema");
            this.btnGrabar.UseVisualStyleBackColor = true;
            // 
            // Panel1
            // 
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel1.Controls.Add(this.txtCampanaAsignada);
            this.Panel1.Controls.Add(this.Label8);
            this.Panel1.Controls.Add(this.txtCupo);
            this.Panel1.Controls.Add(this.Label7);
            this.Panel1.Controls.Add(this.txtTelCelular);
            this.Panel1.Controls.Add(this.Label6);
            this.Panel1.Controls.Add(this.txtTelFijo);
            this.Panel1.Controls.Add(this.Label5);
            this.Panel1.Controls.Add(this.txtEmail);
            this.Panel1.Controls.Add(this.Label4);
            this.Panel1.Controls.Add(this.txtDireccion);
            this.Panel1.Controls.Add(this.Label3);
            this.Panel1.Controls.Add(this.txtNombreAsesor);
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this.txtIdentificacionAS);
            this.Panel1.Location = new System.Drawing.Point(12, 12);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(911, 89);
            this.Panel1.TabIndex = 0;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(701, 61);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(52, 13);
            this.Label8.TabIndex = 16;
            this.Label8.Text = "Campaña";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(472, 61);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(32, 13);
            this.Label7.TabIndex = 14;
            this.Label7.Text = "Cupo";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(239, 61);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(39, 13);
            this.Label6.TabIndex = 12;
            this.Label6.Text = "Celular";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(23, 61);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(49, 13);
            this.Label5.TabIndex = 10;
            this.Label5.Text = "Teléfono";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(442, 35);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(32, 13);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "Email";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(23, 35);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(52, 13);
            this.Label3.TabIndex = 6;
            this.Label3.Text = "Dirección";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(232, 9);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(44, 13);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Nombre";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(5, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(70, 13);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "Identificación";
            // 
            // Panel2
            // 
            this.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel2.Controls.Add(this.txtPorcEscala);
            this.Panel2.Controls.Add(this.Label15);
            this.Panel2.Controls.Add(this.txtTotalaPagar);
            this.Panel2.Controls.Add(this.Label12);
            this.Panel2.Controls.Add(this.txtDescEscala);
            this.Panel2.Controls.Add(this.Label11);
            this.Panel2.Controls.Add(this.txtValorPublico);
            this.Panel2.Controls.Add(this.Label10);
            this.Panel2.Controls.Add(this.Label9);
            this.Panel2.Location = new System.Drawing.Point(12, 104);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(911, 58);
            this.Panel2.TabIndex = 1;
            // 
            // Label15
            // 
            this.Label15.Location = new System.Drawing.Point(409, 18);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(79, 30);
            this.Label15.TabIndex = 18;
            this.Label15.Text = "% Escala Dcto";
            this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label12
            // 
            this.Label12.Location = new System.Drawing.Point(570, 18);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(79, 30);
            this.Label12.TabIndex = 16;
            this.Label12.Text = "Total a Pagar";
            this.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label11
            // 
            this.Label11.Location = new System.Drawing.Point(244, 18);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(79, 30);
            this.Label11.TabIndex = 14;
            this.Label11.Text = "Descuento x Escalas";
            this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label10
            // 
            this.Label10.Location = new System.Drawing.Point(8, 18);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(79, 30);
            this.Label10.TabIndex = 12;
            this.Label10.Text = "Total Valor Público";
            this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(3, 3);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(98, 13);
            this.Label9.TabIndex = 0;
            this.Label9.Text = "Información Pedido";
            // 
            // Panel3
            // 
            this.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel3.Controls.Add(this.btnGrabar);
            this.Panel3.Controls.Add(this.btnAdicionar);
            this.Panel3.Controls.Add(this.btnLiquidar);
            this.Panel3.Controls.Add(this.txtNombreProducto);
            this.Panel3.Controls.Add(this.Label14);
            this.Panel3.Controls.Add(this.txtUnidades);
            this.Panel3.Controls.Add(this.Label13);
            this.Panel3.Controls.Add(this.txtCodigoProducto);
            this.Panel3.Location = new System.Drawing.Point(12, 167);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(911, 74);
            this.Panel3.TabIndex = 3;
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(212, 8);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(52, 13);
            this.Label14.TabIndex = 3;
            this.Label14.Text = "Unidades";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(10, 7);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(86, 13);
            this.Label13.TabIndex = 1;
            this.Label13.Text = "Código Producto";
            // 
            // frmDigitaPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 668);
            this.Controls.Add(this.Panel3);
            this.Controls.Add(this.dtgPedidosOriginal);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmDigitaPedidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro Pedidos";
            this.Load += new System.EventHandler(this.frmDigitaPedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPedidosOriginal)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip totCampos;
        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox txtIdentificacionAS;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.TextBox txtNombreAsesor;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.TextBox txtCupo;
        private System.Windows.Forms.Label Label7;
        private System.Windows.Forms.TextBox txtTelCelular;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.TextBox txtTelFijo;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TextBox txtCampanaAsignada;
        private System.Windows.Forms.Label Label8;
        private System.Windows.Forms.Panel Panel2;
        private System.Windows.Forms.TextBox txtValorPublico;
        private System.Windows.Forms.Label Label10;
        private System.Windows.Forms.Label Label9;
        private System.Windows.Forms.TextBox txtTotalaPagar;
        private System.Windows.Forms.Label Label12;
        private System.Windows.Forms.TextBox txtDescEscala;
        private System.Windows.Forms.Label Label11;
        private System.Windows.Forms.DataGridView dtgPedidosOriginal;
        private System.Windows.Forms.Panel Panel3;
        private System.Windows.Forms.Label Label13;
        private System.Windows.Forms.TextBox txtCodigoProducto;
        private System.Windows.Forms.Label Label14;
        private System.Windows.Forms.TextBox txtUnidades;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnLiquidar;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
        private System.Windows.Forms.TextBox txtPorcEscala;
        private System.Windows.Forms.Label Label15;
        private System.Windows.Forms.Button btnGrabar;

    }
}