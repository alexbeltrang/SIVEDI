namespace SIVEDI.ListaPrecios
{
    partial class frmAsignaVariableProdLP
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
            this.Label1 = new System.Windows.Forms.Label();
            this.txtCodVta = new System.Windows.Forms.TextBox();
            this.txtNomProdLta = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtLimiteVenta = new System.Windows.Forms.TextBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.GroupBox9 = new System.Windows.Forms.GroupBox();
            this.rdbNoNeto = new System.Windows.Forms.RadioButton();
            this.rdbSiNeto = new System.Windows.Forms.RadioButton();
            this.Label17 = new System.Windows.Forms.Label();
            this.GroupBox8 = new System.Windows.Forms.GroupBox();
            this.rdbNoFaltante = new System.Windows.Forms.RadioButton();
            this.rdbSiFaltante = new System.Windows.Forms.RadioButton();
            this.Label14 = new System.Windows.Forms.Label();
            this.GroupBox7 = new System.Windows.Forms.GroupBox();
            this.rdbNoAccesorio = new System.Windows.Forms.RadioButton();
            this.rdbSiAccesorio = new System.Windows.Forms.RadioButton();
            this.Label11 = new System.Windows.Forms.Label();
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.rdbNoMontoMinimo = new System.Windows.Forms.RadioButton();
            this.rdbSiMontoMinimo = new System.Windows.Forms.RadioButton();
            this.Label10 = new System.Windows.Forms.Label();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.rdbNoAplicaEscala = new System.Windows.Forms.RadioButton();
            this.rdbSiAplicaEscala = new System.Windows.Forms.RadioButton();
            this.Label9 = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbNoLlegaEscala = new System.Windows.Forms.RadioButton();
            this.rdbSiLlegaEscala = new System.Windows.Forms.RadioButton();
            this.Label8 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbNoValorPublico = new System.Windows.Forms.RadioButton();
            this.rdbSiValorPublico = new System.Windows.Forms.RadioButton();
            this.Label7 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbNoDigita = new System.Windows.Forms.RadioButton();
            this.rdbSidigita = new System.Windows.Forms.RadioButton();
            this.Label6 = new System.Windows.Forms.Label();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.rdbNoPrincipal = new System.Windows.Forms.RadioButton();
            this.rdbSiPrincipal = new System.Windows.Forms.RadioButton();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.txtIvaProducto = new System.Windows.Forms.TextBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.txtCostoProd = new System.Windows.Forms.TextBox();
            this.totCampos = new System.Windows.Forms.ToolTip(this.components);
            this.txtPuntosOtorga = new System.Windows.Forms.TextBox();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.Label16 = new System.Windows.Forms.Label();
            this.cboTipoProducto = new System.Windows.Forms.ComboBox();
            this.Label18 = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            this.GroupBox9.SuspendLayout();
            this.GroupBox8.SuspendLayout();
            this.GroupBox7.SuspendLayout();
            this.GroupBox6.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(32, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(74, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Código Venta:";
            // 
            // txtCodVta
            // 
            this.txtCodVta.BackColor = System.Drawing.Color.White;
            this.txtCodVta.Enabled = false;
            this.txtCodVta.Location = new System.Drawing.Point(109, 12);
            this.txtCodVta.Name = "txtCodVta";
            this.txtCodVta.ReadOnly = true;
            this.txtCodVta.Size = new System.Drawing.Size(82, 20);
            this.txtCodVta.TabIndex = 1;
            this.totCampos.SetToolTip(this.txtCodVta, "Código de Venta o Catálogo del producto");
            // 
            // txtNomProdLta
            // 
            this.txtNomProdLta.BackColor = System.Drawing.Color.White;
            this.txtNomProdLta.Enabled = false;
            this.txtNomProdLta.Location = new System.Drawing.Point(109, 65);
            this.txtNomProdLta.Name = "txtNomProdLta";
            this.txtNomProdLta.ReadOnly = true;
            this.txtNomProdLta.Size = new System.Drawing.Size(494, 20);
            this.txtNomProdLta.TabIndex = 3;
            this.totCampos.SetToolTip(this.txtNomProdLta, "Nombre del Producto");
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(13, 68);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(93, 13);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Nombre Producto:";
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Location = new System.Drawing.Point(109, 92);
            this.txtPrecioVenta.MaxLength = 10;
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioVenta.TabIndex = 4;
            this.totCampos.SetToolTip(this.txtPrecioVenta, "Precio de Venta del Catálogo sin IVA");
            this.txtPrecioVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioVenta_KeyPress);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(35, 95);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(71, 13);
            this.Label3.TabIndex = 5;
            this.Label3.Text = "Precio Venta:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(36, 121);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(70, 13);
            this.Label4.TabIndex = 7;
            this.Label4.Text = "Límite Venta:";
            // 
            // txtLimiteVenta
            // 
            this.txtLimiteVenta.Location = new System.Drawing.Point(109, 118);
            this.txtLimiteVenta.MaxLength = 5;
            this.txtLimiteVenta.Name = "txtLimiteVenta";
            this.txtLimiteVenta.Size = new System.Drawing.Size(100, 20);
            this.txtLimiteVenta.TabIndex = 7;
            this.totCampos.SetToolTip(this.txtLimiteVenta, "Límite de unidades a vender en la campaña");
            this.txtLimiteVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLimiteVenta_KeyPress);
            // 
            // Panel1
            // 
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel1.Controls.Add(this.GroupBox9);
            this.Panel1.Controls.Add(this.Label17);
            this.Panel1.Controls.Add(this.GroupBox8);
            this.Panel1.Controls.Add(this.Label14);
            this.Panel1.Controls.Add(this.GroupBox7);
            this.Panel1.Controls.Add(this.Label11);
            this.Panel1.Controls.Add(this.GroupBox6);
            this.Panel1.Controls.Add(this.Label10);
            this.Panel1.Controls.Add(this.GroupBox4);
            this.Panel1.Controls.Add(this.Label9);
            this.Panel1.Controls.Add(this.GroupBox3);
            this.Panel1.Controls.Add(this.Label8);
            this.Panel1.Controls.Add(this.GroupBox2);
            this.Panel1.Controls.Add(this.Label7);
            this.Panel1.Controls.Add(this.GroupBox1);
            this.Panel1.Controls.Add(this.Label6);
            this.Panel1.Controls.Add(this.GroupBox5);
            this.Panel1.Controls.Add(this.Label5);
            this.Panel1.Location = new System.Drawing.Point(13, 161);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(596, 148);
            this.Panel1.TabIndex = 8;
            // 
            // GroupBox9
            // 
            this.GroupBox9.Controls.Add(this.rdbNoNeto);
            this.GroupBox9.Controls.Add(this.rdbSiNeto);
            this.GroupBox9.Location = new System.Drawing.Point(139, 108);
            this.GroupBox9.Name = "GroupBox9";
            this.GroupBox9.Size = new System.Drawing.Size(87, 27);
            this.GroupBox9.TabIndex = 30;
            this.GroupBox9.TabStop = false;
            // 
            // rdbNoNeto
            // 
            this.rdbNoNeto.AutoSize = true;
            this.rdbNoNeto.Location = new System.Drawing.Point(42, 7);
            this.rdbNoNeto.Name = "rdbNoNeto";
            this.rdbNoNeto.Size = new System.Drawing.Size(39, 17);
            this.rdbNoNeto.TabIndex = 14;
            this.rdbNoNeto.TabStop = true;
            this.rdbNoNeto.Text = "&No";
            this.totCampos.SetToolTip(this.rdbNoNeto, "El producto NO suma para el valor neto del pedido");
            this.rdbNoNeto.UseVisualStyleBackColor = true;
            // 
            // rdbSiNeto
            // 
            this.rdbSiNeto.AutoSize = true;
            this.rdbSiNeto.Location = new System.Drawing.Point(7, 7);
            this.rdbSiNeto.Name = "rdbSiNeto";
            this.rdbSiNeto.Size = new System.Drawing.Size(34, 17);
            this.rdbSiNeto.TabIndex = 13;
            this.rdbSiNeto.TabStop = true;
            this.rdbSiNeto.Text = "&Si";
            this.totCampos.SetToolTip(this.rdbSiNeto, "El producto suma para el valor neto del pedido");
            this.rdbSiNeto.UseVisualStyleBackColor = true;
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(26, 117);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(114, 13);
            this.Label17.TabIndex = 29;
            this.Label17.Text = "Suma para Valor Neto:";
            // 
            // GroupBox8
            // 
            this.GroupBox8.Controls.Add(this.rdbNoFaltante);
            this.GroupBox8.Controls.Add(this.rdbSiFaltante);
            this.GroupBox8.Location = new System.Drawing.Point(429, 80);
            this.GroupBox8.Name = "GroupBox8";
            this.GroupBox8.Size = new System.Drawing.Size(87, 27);
            this.GroupBox8.TabIndex = 28;
            this.GroupBox8.TabStop = false;
            // 
            // rdbNoFaltante
            // 
            this.rdbNoFaltante.AutoSize = true;
            this.rdbNoFaltante.Location = new System.Drawing.Point(42, 7);
            this.rdbNoFaltante.Name = "rdbNoFaltante";
            this.rdbNoFaltante.Size = new System.Drawing.Size(39, 17);
            this.rdbNoFaltante.TabIndex = 22;
            this.rdbNoFaltante.TabStop = true;
            this.rdbNoFaltante.Text = "&No";
            this.totCampos.SetToolTip(this.rdbNoFaltante, "El producto NO esta como faltante anunciado para la campaña");
            this.rdbNoFaltante.UseVisualStyleBackColor = true;
            // 
            // rdbSiFaltante
            // 
            this.rdbSiFaltante.AutoSize = true;
            this.rdbSiFaltante.Location = new System.Drawing.Point(7, 7);
            this.rdbSiFaltante.Name = "rdbSiFaltante";
            this.rdbSiFaltante.Size = new System.Drawing.Size(34, 17);
            this.rdbSiFaltante.TabIndex = 21;
            this.rdbSiFaltante.TabStop = true;
            this.rdbSiFaltante.Text = "&Si";
            this.totCampos.SetToolTip(this.rdbSiFaltante, "El producto esta como faltante anunciado para la campaña");
            this.rdbSiFaltante.UseVisualStyleBackColor = true;
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(311, 89);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(117, 13);
            this.Label14.TabIndex = 27;
            this.Label14.Text = "Es Faltante Anunciado:";
            // 
            // GroupBox7
            // 
            this.GroupBox7.Controls.Add(this.rdbNoAccesorio);
            this.GroupBox7.Controls.Add(this.rdbSiAccesorio);
            this.GroupBox7.Location = new System.Drawing.Point(429, 54);
            this.GroupBox7.Name = "GroupBox7";
            this.GroupBox7.Size = new System.Drawing.Size(87, 27);
            this.GroupBox7.TabIndex = 26;
            this.GroupBox7.TabStop = false;
            // 
            // rdbNoAccesorio
            // 
            this.rdbNoAccesorio.AutoSize = true;
            this.rdbNoAccesorio.Location = new System.Drawing.Point(42, 7);
            this.rdbNoAccesorio.Name = "rdbNoAccesorio";
            this.rdbNoAccesorio.Size = new System.Drawing.Size(39, 17);
            this.rdbNoAccesorio.TabIndex = 20;
            this.rdbNoAccesorio.TabStop = true;
            this.rdbNoAccesorio.Text = "&No";
            this.totCampos.SetToolTip(this.rdbNoAccesorio, "El producto NO es de tipo accesorio");
            this.rdbNoAccesorio.UseVisualStyleBackColor = true;
            // 
            // rdbSiAccesorio
            // 
            this.rdbSiAccesorio.AutoSize = true;
            this.rdbSiAccesorio.Location = new System.Drawing.Point(7, 7);
            this.rdbSiAccesorio.Name = "rdbSiAccesorio";
            this.rdbSiAccesorio.Size = new System.Drawing.Size(34, 17);
            this.rdbSiAccesorio.TabIndex = 19;
            this.rdbSiAccesorio.TabStop = true;
            this.rdbSiAccesorio.Text = "&Si";
            this.totCampos.SetToolTip(this.rdbSiAccesorio, "El producto es de tipo accesorio");
            this.rdbSiAccesorio.UseVisualStyleBackColor = true;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(357, 63);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(72, 13);
            this.Label11.TabIndex = 25;
            this.Label11.Text = "Es Accesorio:";
            // 
            // GroupBox6
            // 
            this.GroupBox6.Controls.Add(this.rdbNoMontoMinimo);
            this.GroupBox6.Controls.Add(this.rdbSiMontoMinimo);
            this.GroupBox6.Location = new System.Drawing.Point(429, 28);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Size = new System.Drawing.Size(87, 27);
            this.GroupBox6.TabIndex = 24;
            this.GroupBox6.TabStop = false;
            // 
            // rdbNoMontoMinimo
            // 
            this.rdbNoMontoMinimo.AutoSize = true;
            this.rdbNoMontoMinimo.Location = new System.Drawing.Point(42, 7);
            this.rdbNoMontoMinimo.Name = "rdbNoMontoMinimo";
            this.rdbNoMontoMinimo.Size = new System.Drawing.Size(39, 17);
            this.rdbNoMontoMinimo.TabIndex = 18;
            this.rdbNoMontoMinimo.TabStop = true;
            this.rdbNoMontoMinimo.Text = "&No";
            this.totCampos.SetToolTip(this.rdbNoMontoMinimo, "El producto No suma para superar el monto mínimo del pedido");
            this.rdbNoMontoMinimo.UseVisualStyleBackColor = true;
            // 
            // rdbSiMontoMinimo
            // 
            this.rdbSiMontoMinimo.AutoSize = true;
            this.rdbSiMontoMinimo.Location = new System.Drawing.Point(7, 7);
            this.rdbSiMontoMinimo.Name = "rdbSiMontoMinimo";
            this.rdbSiMontoMinimo.Size = new System.Drawing.Size(34, 17);
            this.rdbSiMontoMinimo.TabIndex = 17;
            this.rdbSiMontoMinimo.TabStop = true;
            this.rdbSiMontoMinimo.Text = "&Si";
            this.totCampos.SetToolTip(this.rdbSiMontoMinimo, "El producto suma para superar el monto mínimo del pedido");
            this.rdbSiMontoMinimo.UseVisualStyleBackColor = true;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(297, 37);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(132, 13);
            this.Label10.TabIndex = 23;
            this.Label10.Text = "Suma para Monto Mínimo:";
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.rdbNoAplicaEscala);
            this.GroupBox4.Controls.Add(this.rdbSiAplicaEscala);
            this.GroupBox4.Location = new System.Drawing.Point(429, 2);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(87, 27);
            this.GroupBox4.TabIndex = 22;
            this.GroupBox4.TabStop = false;
            // 
            // rdbNoAplicaEscala
            // 
            this.rdbNoAplicaEscala.AutoSize = true;
            this.rdbNoAplicaEscala.Location = new System.Drawing.Point(42, 7);
            this.rdbNoAplicaEscala.Name = "rdbNoAplicaEscala";
            this.rdbNoAplicaEscala.Size = new System.Drawing.Size(39, 17);
            this.rdbNoAplicaEscala.TabIndex = 16;
            this.rdbNoAplicaEscala.TabStop = true;
            this.rdbNoAplicaEscala.Text = "&No";
            this.totCampos.SetToolTip(this.rdbNoAplicaEscala, "Al producto NO se le aplica el procentaje de descuento global");
            this.rdbNoAplicaEscala.UseVisualStyleBackColor = true;
            // 
            // rdbSiAplicaEscala
            // 
            this.rdbSiAplicaEscala.AutoSize = true;
            this.rdbSiAplicaEscala.Location = new System.Drawing.Point(7, 7);
            this.rdbSiAplicaEscala.Name = "rdbSiAplicaEscala";
            this.rdbSiAplicaEscala.Size = new System.Drawing.Size(34, 17);
            this.rdbSiAplicaEscala.TabIndex = 15;
            this.rdbSiAplicaEscala.TabStop = true;
            this.rdbSiAplicaEscala.Text = "&Si";
            this.totCampos.SetToolTip(this.rdbSiAplicaEscala, "Al producto se le aplica el procentaje de descuento global");
            this.rdbSiAplicaEscala.UseVisualStyleBackColor = true;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(308, 11);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(121, 13);
            this.Label9.TabIndex = 21;
            this.Label9.Text = "Se le Aplica Escala Dto:";
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.rdbNoLlegaEscala);
            this.GroupBox3.Controls.Add(this.rdbSiLlegaEscala);
            this.GroupBox3.Location = new System.Drawing.Point(140, 80);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(87, 27);
            this.GroupBox3.TabIndex = 20;
            this.GroupBox3.TabStop = false;
            // 
            // rdbNoLlegaEscala
            // 
            this.rdbNoLlegaEscala.AutoSize = true;
            this.rdbNoLlegaEscala.Location = new System.Drawing.Point(42, 7);
            this.rdbNoLlegaEscala.Name = "rdbNoLlegaEscala";
            this.rdbNoLlegaEscala.Size = new System.Drawing.Size(39, 17);
            this.rdbNoLlegaEscala.TabIndex = 14;
            this.rdbNoLlegaEscala.TabStop = true;
            this.rdbNoLlegaEscala.Text = "&No";
            this.totCampos.SetToolTip(this.rdbNoLlegaEscala, "El producto NO suma al total para llegar a una escala de descuento Global");
            this.rdbNoLlegaEscala.UseVisualStyleBackColor = true;
            // 
            // rdbSiLlegaEscala
            // 
            this.rdbSiLlegaEscala.AutoSize = true;
            this.rdbSiLlegaEscala.Location = new System.Drawing.Point(7, 7);
            this.rdbSiLlegaEscala.Name = "rdbSiLlegaEscala";
            this.rdbSiLlegaEscala.Size = new System.Drawing.Size(34, 17);
            this.rdbSiLlegaEscala.TabIndex = 13;
            this.rdbSiLlegaEscala.TabStop = true;
            this.rdbSiLlegaEscala.Text = "&Si";
            this.totCampos.SetToolTip(this.rdbSiLlegaEscala, "El producto suma al total para llegar a una escala de descuento Global");
            this.rdbSiLlegaEscala.UseVisualStyleBackColor = true;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(12, 89);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(128, 13);
            this.Label8.TabIndex = 19;
            this.Label8.Text = "Suma para Llegar Escala:";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.rdbNoValorPublico);
            this.GroupBox2.Controls.Add(this.rdbSiValorPublico);
            this.GroupBox2.Location = new System.Drawing.Point(140, 54);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(87, 27);
            this.GroupBox2.TabIndex = 18;
            this.GroupBox2.TabStop = false;
            // 
            // rdbNoValorPublico
            // 
            this.rdbNoValorPublico.AutoSize = true;
            this.rdbNoValorPublico.Location = new System.Drawing.Point(42, 7);
            this.rdbNoValorPublico.Name = "rdbNoValorPublico";
            this.rdbNoValorPublico.Size = new System.Drawing.Size(39, 17);
            this.rdbNoValorPublico.TabIndex = 12;
            this.rdbNoValorPublico.TabStop = true;
            this.rdbNoValorPublico.Text = "&No";
            this.totCampos.SetToolTip(this.rdbNoValorPublico, "El producto NO suma para el total del valor Público del pedido");
            this.rdbNoValorPublico.UseVisualStyleBackColor = true;
            // 
            // rdbSiValorPublico
            // 
            this.rdbSiValorPublico.AutoSize = true;
            this.rdbSiValorPublico.Location = new System.Drawing.Point(7, 7);
            this.rdbSiValorPublico.Name = "rdbSiValorPublico";
            this.rdbSiValorPublico.Size = new System.Drawing.Size(34, 17);
            this.rdbSiValorPublico.TabIndex = 11;
            this.rdbSiValorPublico.TabStop = true;
            this.rdbSiValorPublico.Text = "&Si";
            this.totCampos.SetToolTip(this.rdbSiValorPublico, "El producto suma para el total del valor Público del pedido");
            this.rdbSiValorPublico.UseVisualStyleBackColor = true;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(14, 63);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(126, 13);
            this.Label7.TabIndex = 17;
            this.Label7.Text = "Suma para Valor Público:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.rdbNoDigita);
            this.GroupBox1.Controls.Add(this.rdbSidigita);
            this.GroupBox1.Location = new System.Drawing.Point(140, 28);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(87, 27);
            this.GroupBox1.TabIndex = 16;
            this.GroupBox1.TabStop = false;
            // 
            // rdbNoDigita
            // 
            this.rdbNoDigita.AutoSize = true;
            this.rdbNoDigita.Location = new System.Drawing.Point(42, 7);
            this.rdbNoDigita.Name = "rdbNoDigita";
            this.rdbNoDigita.Size = new System.Drawing.Size(39, 17);
            this.rdbNoDigita.TabIndex = 10;
            this.rdbNoDigita.TabStop = true;
            this.rdbNoDigita.Text = "&No";
            this.totCampos.SetToolTip(this.rdbNoDigita, "No se permite digitar el código de venta del prodcuto en la captura o digitación " +
        "del pedido");
            this.rdbNoDigita.UseVisualStyleBackColor = true;
            // 
            // rdbSidigita
            // 
            this.rdbSidigita.AutoSize = true;
            this.rdbSidigita.Location = new System.Drawing.Point(7, 7);
            this.rdbSidigita.Name = "rdbSidigita";
            this.rdbSidigita.Size = new System.Drawing.Size(34, 17);
            this.rdbSidigita.TabIndex = 9;
            this.rdbSidigita.TabStop = true;
            this.rdbSidigita.Text = "&Si";
            this.totCampos.SetToolTip(this.rdbSidigita, "Se permite digitar el código de venta del prodcuto en la captura o digitación del" +
        " pedido");
            this.rdbSidigita.UseVisualStyleBackColor = true;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(46, 37);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(94, 13);
            this.Label6.TabIndex = 15;
            this.Label6.Text = "Se Permite Digitar:";
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.rdbNoPrincipal);
            this.GroupBox5.Controls.Add(this.rdbSiPrincipal);
            this.GroupBox5.Location = new System.Drawing.Point(140, 2);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(87, 27);
            this.GroupBox5.TabIndex = 14;
            this.GroupBox5.TabStop = false;
            // 
            // rdbNoPrincipal
            // 
            this.rdbNoPrincipal.AutoSize = true;
            this.rdbNoPrincipal.Location = new System.Drawing.Point(42, 7);
            this.rdbNoPrincipal.Name = "rdbNoPrincipal";
            this.rdbNoPrincipal.Size = new System.Drawing.Size(39, 17);
            this.rdbNoPrincipal.TabIndex = 8;
            this.rdbNoPrincipal.TabStop = true;
            this.rdbNoPrincipal.Text = "&No";
            this.totCampos.SetToolTip(this.rdbNoPrincipal, "El producto No es un código de venta principal");
            this.rdbNoPrincipal.UseVisualStyleBackColor = true;
            // 
            // rdbSiPrincipal
            // 
            this.rdbSiPrincipal.AutoSize = true;
            this.rdbSiPrincipal.Location = new System.Drawing.Point(7, 7);
            this.rdbSiPrincipal.Name = "rdbSiPrincipal";
            this.rdbSiPrincipal.Size = new System.Drawing.Size(34, 17);
            this.rdbSiPrincipal.TabIndex = 7;
            this.rdbSiPrincipal.TabStop = true;
            this.rdbSiPrincipal.Text = "&Si";
            this.totCampos.SetToolTip(this.rdbSiPrincipal, "El producto es un código de venta principal");
            this.rdbSiPrincipal.UseVisualStyleBackColor = true;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(39, 11);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(101, 13);
            this.Label5.TabIndex = 13;
            this.Label5.Text = "Es Código Principal:";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(419, 94);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(81, 13);
            this.Label12.TabIndex = 10;
            this.Label12.Text = "Porcentaje IVA:";
            // 
            // txtIvaProducto
            // 
            this.txtIvaProducto.Location = new System.Drawing.Point(503, 92);
            this.txtIvaProducto.MaxLength = 2;
            this.txtIvaProducto.Name = "txtIvaProducto";
            this.txtIvaProducto.Size = new System.Drawing.Size(100, 20);
            this.txtIvaProducto.TabIndex = 6;
            this.totCampos.SetToolTip(this.txtIvaProducto, "Porcentaje de IVA en valores enteros");
            this.txtIvaProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIvaProducto_KeyPress);
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(215, 94);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(83, 13);
            this.Label13.TabIndex = 12;
            this.Label13.Text = "Costo Producto:";
            // 
            // txtCostoProd
            // 
            this.txtCostoProd.Location = new System.Drawing.Point(302, 92);
            this.txtCostoProd.MaxLength = 10;
            this.txtCostoProd.Name = "txtCostoProd";
            this.txtCostoProd.Size = new System.Drawing.Size(100, 20);
            this.txtCostoProd.TabIndex = 8;
            this.totCampos.SetToolTip(this.txtCostoProd, "Costo del producto");
            this.txtCostoProd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCostoProd_KeyPress);
            // 
            // totCampos
            // 
            this.totCampos.AutoPopDelay = 3000;
            this.totCampos.InitialDelay = 20;
            this.totCampos.IsBalloon = true;
            this.totCampos.ReshowDelay = 100;
            this.totCampos.ShowAlways = true;
            // 
            // txtPuntosOtorga
            // 
            this.txtPuntosOtorga.Location = new System.Drawing.Point(302, 118);
            this.txtPuntosOtorga.MaxLength = 10;
            this.txtPuntosOtorga.Name = "txtPuntosOtorga";
            this.txtPuntosOtorga.Size = new System.Drawing.Size(100, 20);
            this.txtPuntosOtorga.TabIndex = 9;
            this.totCampos.SetToolTip(this.txtPuntosOtorga, "Costo del producto");
            this.txtPuntosOtorga.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPuntosOtorga_KeyPress);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(263, 315);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 13;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(29, 39);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(77, 13);
            this.Label16.TabIndex = 16;
            this.Label16.Text = "Tipo Producto:";
            // 
            // cboTipoProducto
            // 
            this.cboTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoProducto.FormattingEnabled = true;
            this.cboTipoProducto.Location = new System.Drawing.Point(109, 39);
            this.cboTipoProducto.Name = "cboTipoProducto";
            this.cboTipoProducto.Size = new System.Drawing.Size(293, 21);
            this.cboTipoProducto.TabIndex = 2;
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Location = new System.Drawing.Point(221, 121);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(78, 13);
            this.Label18.TabIndex = 18;
            this.Label18.Text = "Puntos Otorga:";
            // 
            // frmAsignaVariableProdLP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 342);
            this.Controls.Add(this.Label18);
            this.Controls.Add(this.txtPuntosOtorga);
            this.Controls.Add(this.cboTipoProducto);
            this.Controls.Add(this.Label16);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.Label13);
            this.Controls.Add(this.txtCostoProd);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.txtIvaProducto);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.txtLimiteVenta);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtPrecioVenta);
            this.Controls.Add(this.txtNomProdLta);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtCodVta);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAsignaVariableProdLP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comportamiento Items en Campaña";
            this.Load += new System.EventHandler(this.frmAsignaVariableProdLP_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.GroupBox9.ResumeLayout(false);
            this.GroupBox9.PerformLayout();
            this.GroupBox8.ResumeLayout(false);
            this.GroupBox8.PerformLayout();
            this.GroupBox7.ResumeLayout(false);
            this.GroupBox7.PerformLayout();
            this.GroupBox6.ResumeLayout(false);
            this.GroupBox6.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox txtCodVta;
        private System.Windows.Forms.TextBox txtNomProdLta;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.TextBox txtLimiteVenta;
        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.RadioButton rdbNoDigita;
        private System.Windows.Forms.RadioButton rdbSidigita;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.GroupBox GroupBox5;
        private System.Windows.Forms.RadioButton rdbNoPrincipal;
        private System.Windows.Forms.RadioButton rdbSiPrincipal;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.RadioButton rdbNoValorPublico;
        private System.Windows.Forms.RadioButton rdbSiValorPublico;
        private System.Windows.Forms.Label Label7;
        private System.Windows.Forms.GroupBox GroupBox4;
        private System.Windows.Forms.RadioButton rdbNoAplicaEscala;
        private System.Windows.Forms.RadioButton rdbSiAplicaEscala;
        private System.Windows.Forms.Label Label9;
        private System.Windows.Forms.GroupBox GroupBox3;
        private System.Windows.Forms.RadioButton rdbNoLlegaEscala;
        private System.Windows.Forms.RadioButton rdbSiLlegaEscala;
        private System.Windows.Forms.Label Label8;
        private System.Windows.Forms.GroupBox GroupBox7;
        private System.Windows.Forms.RadioButton rdbNoAccesorio;
        private System.Windows.Forms.RadioButton rdbSiAccesorio;
        private System.Windows.Forms.Label Label11;
        private System.Windows.Forms.GroupBox GroupBox6;
        private System.Windows.Forms.RadioButton rdbNoMontoMinimo;
        private System.Windows.Forms.RadioButton rdbSiMontoMinimo;
        private System.Windows.Forms.Label Label10;
        private System.Windows.Forms.Label Label12;
        private System.Windows.Forms.TextBox txtIvaProducto;
        private System.Windows.Forms.Label Label13;
        private System.Windows.Forms.TextBox txtCostoProd;
        private System.Windows.Forms.ToolTip totCampos;
        private System.Windows.Forms.GroupBox GroupBox8;
        private System.Windows.Forms.RadioButton rdbNoFaltante;
        private System.Windows.Forms.RadioButton rdbSiFaltante;
        private System.Windows.Forms.Label Label14;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Label Label16;
        private System.Windows.Forms.ComboBox cboTipoProducto;
        private System.Windows.Forms.GroupBox GroupBox9;
        private System.Windows.Forms.RadioButton rdbNoNeto;
        private System.Windows.Forms.RadioButton rdbSiNeto;
        private System.Windows.Forms.Label Label17;
        private System.Windows.Forms.Label Label18;
        private System.Windows.Forms.TextBox txtPuntosOtorga;

    }
}