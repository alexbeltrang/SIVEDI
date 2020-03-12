using Microsoft.VisualBasic;
using SIVEDI.Clases;
using SIVEDI.Clases.TABLAS;
using SIVEDI.ServicePedidos;
using SIVEDI.ServicioGeneral;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SIVEDI.Mantenimiento
{
    public partial class frmAdminOfertaSimple : Form
    {
        int intCodigoProductoEntrega = 0;
        int intCodigoListaPreciosEntrega;
        bool blnEditaOferta = false;
        DataTable dt = new DataTable();
        DataTable dttProducto = new DataTable();

        OperacionesExcel operacionesExcel = new OperacionesExcel();

        ServicioGeneralClient ServicioGeneral = new ServicioGeneralClient();
        ServicePedidosClient ServicePedidos = new ServicePedidosClient();
        public frmAdminOfertaSimple()
        {
            InitializeComponent();
        }

        private void frmOfertaSimple_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            dtgEstadosActividad.ReadOnly = true;
            dtgProductoAplica.ReadOnly = true;
            dtgProductoImpulsa.ReadOnly = true;
            dtgZonasAsignadas.ReadOnly = true;
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            cbolistaPrecios.Focus();
            CheckForIllegalCrossThreadCalls = false;
            CargaCombo();
            if (clsConnection.intCodigoOfertaSimle == 0)
            {
                cbolistaPrecios.Focus();
                this.Size = new System.Drawing.Size(688, 250);
                TabControl1.Visible = false;
                pnlEncabezado.Enabled = true;
                blnEditaOferta = false;
            }
            else
            {
                this.Size = new System.Drawing.Size(688, 661);
                TabControl1.Visible = true;
                pnlEncabezado.Enabled = true;
                cargaDatosOferta();
                blnEditaOferta = true;
            }
            llenaZonas();
            llenaGrillaProductosAplica();
            llenaGrillaZonasAsignadas();
            llenaEstadosActividad();
        }

        private void CargaCombo()
        {
            var withBlock = cbolistaPrecios;
            withBlock.DataSource = ServicePedidos.getListaPreciosTabla(4, 0);
            withBlock.ValueMember = "CODIGO";
            withBlock.DisplayMember = "CODIGO_LISTA";
            withBlock.SelectedValue = 0;

        }

        private void EditarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filaSeleccionada = dtgProductoImpulsa.SelectedRows[0].Index;
        }

        private void txtCodigoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
                cargaProductoDigitado();
        }

        private void txtCodigoProducto_Leave(object sender, EventArgs e)
        {
            cargaProductoDigitado();
        }

        private void cargaProductoDigitado()
        {
            if (txtCodigoProducto.Text != "" | txtCodigoProducto.Text != null/* TODO Change to default(_) if this is not a reference type */ )
            {
                var dttProducto = ServicePedidos.getProductoPedidos(txtCodigoProducto.Text, Convert.ToInt32(cbolistaPrecios.SelectedValue));

                if (dttProducto.Count() > 0)
                {
                    txtNombreProducto.Text = dttProducto.FirstOrDefault().NOMBRE_PRODUCTO;
                    intCodigoListaPreciosEntrega = Convert.ToInt32(dttProducto.FirstOrDefault().CODIGO);
                    txtPorcentajeAplica.Focus();
                }
                else
                {
                    txtCodigoProducto.Focus();
                    txtCodigoProducto.Text = null;
                    MessageBox.Show("Código de producto no existe", "Producto no Existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private bool validaCamposOfertaEncabezado()
        {
            if (cbolistaPrecios.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione la lista de precios a la cual aplica la oferta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                cbolistaPrecios.Focus();
                return false;
            }
            else if (txtNombreOferta.Text == "" | txtNombreOferta.Text == null/* TODO Change to default(_) if this is not a reference type */ )
            {
                MessageBox.Show("Ingrese el Nombre de la oferta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txtNombreOferta.Focus();
                return false;
            }
            else if (txtFactorConversion.Text == "" | txtFactorConversion.Text == null/* TODO Change to default(_) if this is not a reference type */ )
            {
                MessageBox.Show("Ingrese el Factor de conversión", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txtFactorConversion.Focus();
                return false;
            }
            else if (!rdbActivo.Checked & !rdbInactivo.Checked)
            {
                MessageBox.Show("Seleccione un estado para la oferta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (!rdbSiCantidad.Checked & !rdbNoCantidad.Checked)
            {
                MessageBox.Show("Seleccione si la oferta es por Cantidad o Monto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (!rdbSimonto.Checked & (txtMontoOferta.Text == "" | txtMontoOferta.Text == null/* TODO Change to default(_) if this is not a reference type */))
            {
                MessageBox.Show("Ingrese el valor del monto´.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (!rdbSiObsequio.Checked & !rdbNoObsequio.Checked)
            {
                MessageBox.Show("Seleccione si la oferta es de tipo Obsequio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (!rdbSiDescuento.Checked & !rdbNoDescuento.Checked)
            {
                MessageBox.Show("Seleccione si la oferta es de tipo Descuento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (!rdbSiPromocion.Checked & !rdbNoPromocion.Checked)
            {
                MessageBox.Show("Seleccione si la oferta es de tipo Promoción", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
                return true;
        }

        private void txtMontoOferta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 46 && e.KeyChar != 44)
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
        }

        private void rdbSiCantidad_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSiCantidad.Checked)
            {
                rdbSimonto.Checked = false;
                rdbNomonto.Checked = true;
                if (blnEditaOferta)
                    txtMontoOferta.Text = "0";
            }
            else if (rdbNoCantidad.Checked)
            {
                rdbSimonto.Checked = true;
                rdbNomonto.Checked = false;
                if (blnEditaOferta)
                    txtMontoOferta.Text = "";
            }
        }

        private void rdbSimonto_CheckedChanged(object sender, EventArgs e)
        {
            if (blnEditaOferta)
            {
                if (rdbSimonto.Checked)
                {
                    rdbSiCantidad.Checked = false;
                    rdbNoCantidad.Checked = true;
                    if (blnEditaOferta)
                        txtMontoOferta.Text = "";
                }
                else if (rdbNomonto.Checked)
                {
                    rdbSiCantidad.Checked = true;
                    rdbNoCantidad.Checked = false;
                    if (blnEditaOferta)
                        txtMontoOferta.Text = "0";
                }
            }
        }

        private void rdbSiObsequio_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSiObsequio.Checked)
            {
                rdbNoObsequio.Checked = false;
                rdbNoDescuento.Checked = true;
                rdbNoPromocion.Checked = true;
                rdbSiObsequio.Checked = true;
            }
            else if (rdbNoObsequio.Checked)
            {
                rdbSiObsequio.Checked = false;
                rdbNoDescuento.Checked = false;
                rdbNoPromocion.Checked = false;
                rdbSiDescuento.Checked = false;
                rdbSiPromocion.Checked = false;
            }
        }

        private void rdbSiDescuento_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSiDescuento.Checked)
            {
                rdbNoObsequio.Checked = true;
                rdbNoPromocion.Checked = true;
                rdbSiDescuento.Checked = true;
                rdbNoDescuento.Checked = false;
                rdbSiObsequio.Checked = false;
                rdbSiPromocion.Checked = false;
            }
            else if (rdbNoDescuento.Checked)
            {
                rdbSiObsequio.Checked = false;
                rdbNoDescuento.Checked = true;
                rdbNoPromocion.Checked = false;
                rdbSiDescuento.Checked = false;
                rdbSiPromocion.Checked = false;
            }
        }

        private void limpiaCamposPorductoEntrega()
        {
            intCodigoProductoEntrega = 0;
            intCodigoListaPreciosEntrega = 0;
            txtCodigoProducto.Text = null;
            txtNombreProducto.Text = null;
            txtPorcentajeAplica.Text = null;
            txtUnidadesAplicia.Text = null;
            txtValorVenta.Text = null;
        }
        private bool validaCamposProdEntrega()
        {
            if (txtCodigoProducto.Text == "" | txtCodigoProducto.Text == null/* TODO Change to default(_) if this is not a reference type */ )
            {
                txtCodigoProducto.Focus();
                MessageBox.Show("Digite el código del producto al que aplica la oferta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (txtPorcentajeAplica.Text == "" | txtPorcentajeAplica.Text == null/* TODO Change to default(_) if this is not a reference type */ )
            {
                txtPorcentajeAplica.Focus();
                MessageBox.Show("Digite el porcentaje de descuento, si no aplica digite cero(0)", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (txtUnidadesAplicia.Text == "" | txtUnidadesAplicia.Text == null/* TODO Change to default(_) if this is not a reference type */ )
            {
                txtUnidadesAplicia.Focus();
                MessageBox.Show("Digite el número de unidades al cual aplica la oferta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (System.Convert.ToInt32(txtFactorConversion.Text) < System.Convert.ToInt32(txtUnidadesAplicia.Text))
            {
                txtUnidadesAplicia.Focus();
                MessageBox.Show("Digite el número de unidades al cual aplica la oferta no puede ser mayor que el factor de conversión", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (txtValorVenta.Text == "" | txtValorVenta.Text == null/* TODO Change to default(_) if this is not a reference type */ )
            {
                txtValorVenta.Focus();
                MessageBox.Show("Digite el valor al cual se venderá el prodcuto, si no aplica digite cero(0)", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
                return true;
        }
        private void llenaGrillaProductosAplica()
        {
            {
                var withBlock = dtgProductoAplica;
                withBlock.DataSource = ServicioGeneral.getlistaProductosAplicaOferta(clsConnection.intCodigoOfertaSimle);
            }
        }
        private void llenaZonas()
        {
            {
                var withBlock = chlZonas;
                withBlock.DataSource = ServicioGeneral.getZonasOferta(clsConnection.intCodigoOfertaSimle);
                withBlock.DisplayMember = "NOMBRE";
                withBlock.ValueMember = "CODIGO";
            }
        }

        private void llenaEstadosActividad()
        {
            {
                var withBlock = chkEstadosActividad;
                withBlock.DataSource = ServicioGeneral.getEstadoActividadOfertas(1, clsConnection.intCodigoOfertaSimle);
                withBlock.DisplayMember = "NOMBRE";
                withBlock.ValueMember = "CODIGO";
            }
            for (int idx = 1; idx <= this.chkEstadosActividad.Items.Count - 1; idx++)
                this.chkEstadosActividad.SetItemCheckState(idx, CheckState.Unchecked);
            {
                var withBlock = dtgEstadosActividad;
                withBlock.DataSource = ServicioGeneral.getEstadoActividadOfertas(2, clsConnection.intCodigoOfertaSimle);
            }
        }

        private void chlZonas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    for (int idx = 1; idx <= this.chlZonas.Items.Count - 1; idx++)
                        this.chlZonas.SetItemCheckState(idx, CheckState.Checked);
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    for (int idx = 1; idx <= this.chlZonas.Items.Count - 1; idx++)
                        this.chlZonas.SetItemCheckState(idx, CheckState.Unchecked);
                }
            }
        }

        private void llenaGrillaZonasAsignadas()
        {
            {
                var withBlock = dtgZonasAsignadas;
                withBlock.DataSource = ServicioGeneral.getZonasAsignadasOferta(clsConnection.intCodigoOfertaSimle);
            }
        }
        private void llenaProductoImpulsa()
        {
            {
                var withBlock = dtgProductoImpulsa;
                withBlock.DataSource = ServicioGeneral.getDatosProdImpulsa(clsConnection.intCodigoOfertaSimle);
            }
        }

        private void cargaDatosOferta()
        {
            var dttDatosOfertaEdit = ServicioGeneral.getlistaOfertas(clsConnection.intCodigoOfertaSimle, 2, 0, 0, "");
            if (dttDatosOfertaEdit.Count() > 0)
            {
                cbolistaPrecios.SelectedValue = dttDatosOfertaEdit.FirstOrDefault().CODIGO_LISTA_PRECIOS;
                txtNombreOferta.Text = dttDatosOfertaEdit.FirstOrDefault().NOMBRE;
                txtFactorConversion.Text = dttDatosOfertaEdit.FirstOrDefault().FACTOR_CONVERSION.ToString();
                txtMontoOferta.Text = dttDatosOfertaEdit.FirstOrDefault().VALOR_MONTO.ToString();
                if (dttDatosOfertaEdit.FirstOrDefault().ES_POR_CANTIDAD)
                {
                    rdbSiCantidad.Checked = true;
                    rdbNoCantidad.Checked = false;
                }
                else
                {
                    rdbSiCantidad.Checked = false;
                    rdbNoCantidad.Checked = true;
                }
                if (dttDatosOfertaEdit.FirstOrDefault().ES_POR_MONTO)
                {
                    rdbSimonto.Checked = true;
                    rdbNomonto.Checked = false;
                }
                else
                {
                    rdbSimonto.Checked = false;
                    rdbNomonto.Checked = true;
                }
                if (dttDatosOfertaEdit.FirstOrDefault().ES_OBSEQUIO)
                {
                    rdbSiObsequio.Checked = true;
                    rdbNoObsequio.Checked = false;
                }
                else
                {
                    rdbSiObsequio.Checked = false;
                    rdbNoObsequio.Checked = true;
                }
                if (dttDatosOfertaEdit.FirstOrDefault().ES_DESCUENTO)
                {
                    rdbSiDescuento.Checked = true;
                    rdbNoDescuento.Checked = false;
                }
                else
                {
                    rdbSiDescuento.Checked = false;
                    rdbNoDescuento.Checked = true;
                }
                if (dttDatosOfertaEdit.FirstOrDefault().ES_PROMOCION)
                {
                    rdbSiPromocion.Checked = true;
                    rdbNoPromocion.Checked = false;
                }
                else
                {
                    rdbSiPromocion.Checked = false;
                    rdbNoPromocion.Checked = true;
                }
                if (dttDatosOfertaEdit.FirstOrDefault().ESTADO)
                {
                    rdbActivo.Checked = true;
                    rdbInactivo.Checked = false;
                }
                else
                {
                    rdbActivo.Checked = false;
                    rdbInactivo.Checked = false;
                }
            }
            llenaGrillaProductosAplica();
            llenaGrillaZonasAsignadas();
            llenaProductoImpulsa();
        }

        private void chkEstadosActividad_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    for (int idx = 1; idx <= this.chkEstadosActividad.Items.Count - 1; idx++)
                        this.chkEstadosActividad.SetItemCheckState(idx, CheckState.Checked);
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    for (int idx = 1; idx <= this.chkEstadosActividad.Items.Count - 1; idx++)
                        this.chkEstadosActividad.SetItemCheckState(idx, CheckState.Unchecked);
                }
            }
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string strResultado = string.Empty;
            try
            {
                int filaSeleccionada = dtgEstadosActividad.SelectedRows[0].Index;
                strResultado = ServicioGeneral.delEstadoActividadPromocion(Convert.ToInt32(dtgEstadosActividad.Rows[filaSeleccionada].Cells[0].Value)).ToString();
                llenaEstadosActividad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(strResultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void frmOfertaSimple_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsConnection.blnActualizaOfertasSimples = true;
        }

        private void dtgProductoAplica_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int filaSeleccionada = dtgProductoAplica.SelectedRows[0].Index;
            intCodigoProductoEntrega = Convert.ToInt32(dtgProductoAplica.Rows[filaSeleccionada].Cells[0].Value);
            intCodigoListaPreciosEntrega = Convert.ToInt32(dtgProductoAplica.Rows[filaSeleccionada].Cells[1].Value);
            txtCodigoProducto.Text = dtgProductoAplica.Rows[filaSeleccionada].Cells[2].Value.ToString();
            txtNombreProducto.Text = dtgProductoAplica.Rows[filaSeleccionada].Cells[3].Value.ToString();
            txtPorcentajeAplica.Text = dtgProductoAplica.Rows[filaSeleccionada].Cells[4].Value.ToString();
            txtUnidadesAplicia.Text = dtgProductoAplica.Rows[filaSeleccionada].Cells[5].Value.ToString();
            txtValorVenta.Text = dtgProductoAplica.Rows[filaSeleccionada].Cells[6].Value.ToString();
        }

        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                CheckForIllegalCrossThreadCalls = false;

                // Instanciamos nuestro cuadro de dialogo
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                // Directorio Predeterminado
                // openFileDialog1.InitialDirectory = "C:\"
                // Filtramos solo archivos con extension *.xls
                openFileDialog1.Filter = "Todos los archivos| *.*|Archivo Excel | *.xlsx|Archivo Excel |*.xls";
                // Si se presiona abrir entonces...
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Asignamos la ruta donde se almacena el fichero excel que se va a importar
                    string RutaArchivo;
                    RutaArchivo = openFileDialog1.FileName;
                    dt = operacionesExcel.Excel_To_DataTable(RutaArchivo, 0);
                    var withBlock = dt;
                    withBlock.Columns.Add(new DataColumn("NOMBRE PRODUCTO", typeof(string)));
                    withBlock.Columns.Add(new DataColumn("CODIGO LISTA", typeof(int)));

                    for (var i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        var dttProducto = ServicePedidos.getProductoPedidos(dt.Rows[i][0].ToString(), Convert.ToInt32(cbolistaPrecios.SelectedValue));

                        if (dttProducto.Count() > 0)
                        {
                            dt.Rows[i]["NOMBRE PRODUCTO"] = dttProducto.FirstOrDefault().NOMBRE_PRODUCTO;
                            dt.Rows[i]["CODIGO LISTA"] = dttProducto.FirstOrDefault().CODIGO;
                        }
                    }


                    // Llenamos el Datagridview
                    dtgProductoImpulsa.DataSource = dt;
                    // Ajustamos las columnas del DataGridView
                    dtgProductoImpulsa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnGrabarOferta_Click(object sender, EventArgs e)
        {
            if (validaCamposOfertaEncabezado())
            {
                string strResult;
                OfertasSimples ofertasSimples = new OfertasSimples();

                if (rdbSiCantidad.Checked)
                    ofertasSimples.ES_POR_CANTIDAD = true;
                else
                    ofertasSimples.ES_POR_CANTIDAD = false;
                if (rdbSimonto.Checked)
                    ofertasSimples.ES_POR_MONTO = true;
                else
                    ofertasSimples.ES_POR_MONTO = false;
                if (rdbSiObsequio.Checked)
                    ofertasSimples.ES_OBSEQUIO = true;
                else
                    ofertasSimples.ES_OBSEQUIO = false;
                if (rdbSiDescuento.Checked)
                    ofertasSimples.ES_DESCUENTO = true;
                else
                    ofertasSimples.ES_DESCUENTO = false;
                if (rdbSiPromocion.Checked)
                    ofertasSimples.ES_PROMOCION = true;
                else
                    ofertasSimples.ES_PROMOCION = false;
                if (rdbActivo.Checked)
                    ofertasSimples.ESTADO = true;
                else
                    ofertasSimples.ESTADO = false;
                ofertasSimples.CODIGO = clsConnection.intCodigoOfertaSimle;
                ofertasSimples.NOMBRE = txtNombreOferta.Text;
                ofertasSimples.FACTOR_CONVERSION = Convert.ToDecimal(txtFactorConversion.Text);
                ofertasSimples.CODIGO_LISTA_PRECIOS = Convert.ToInt32(cbolistaPrecios.SelectedValue);
                ofertasSimples.VALOR_MONTO = Convert.ToDecimal(txtMontoOferta.Text);
                strResult = ServicioGeneral.iuOfertaSimple(ofertasSimples).ToString();
                if (Information.IsNumeric(strResult))
                {
                    if (System.Convert.ToInt32(strResult) > 0)
                    {
                        pnlEncabezado.Enabled = false;
                        clsConnection.intCodigoOfertaSimle = System.Convert.ToInt32(strResult);
                        llenaZonas();
                        MessageBox.Show("Registro creado exitosamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                    else if (System.Convert.ToInt32(strResult) < 0)
                    {
                        pnlEncabezado.Enabled = false;
                        llenaZonas();
                        MessageBox.Show("Registro Actualizado exitosamente", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    MessageBox.Show(strResult, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                TabControl1.Visible = true;
                this.Size = new System.Drawing.Size(688, 661);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            for (var z = 0; z <= dtgProductoImpulsa.Rows.Count - 1; z++)
            {
                ProductoOfertaSimple productoOfertaSimple = new ProductoOfertaSimple();
                productoOfertaSimple.CodigoProducto = Convert.ToInt32(dtgProductoImpulsa.Rows[z].Cells[2].Value);
                productoOfertaSimple.CodigoOfetra = clsConnection.intCodigoOfertaSimle;
                ServicioGeneral.iuProdImpOfertaSimple(productoOfertaSimple);
            }
            txtRutaArchivo.Text = null;
            MessageBox.Show("Registros grabados exitosamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        private void btGrabaProdAplica_Click(object sender, EventArgs e)
        {
            if (validaCamposProdEntrega())
            {
                string strMensaje = null;
                try
                {
                    ProductoAplicaOfertaSimple productoAplicaOfertaSimple = new ProductoAplicaOfertaSimple();
                    productoAplicaOfertaSimple.CodigoEntrega = intCodigoProductoEntrega;
                    productoAplicaOfertaSimple.CodigoProducto = intCodigoListaPreciosEntrega;
                    productoAplicaOfertaSimple.CodigoOferta = clsConnection.intCodigoOfertaSimle;
                    productoAplicaOfertaSimple.Porcentaje = Convert.ToDecimal(txtPorcentajeAplica.Text);
                    productoAplicaOfertaSimple.UnidadesAplica = Convert.ToInt32(txtUnidadesAplicia.Text);
                    productoAplicaOfertaSimple.ValorEntrega = Convert.ToDecimal(txtValorVenta.Text);
                    strMensaje = ServicioGeneral.iuProdAplicaOfertaSimple(productoAplicaOfertaSimple).ToString();
                    limpiaCamposPorductoEntrega();
                    llenaGrillaProductosAplica();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(strMensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void btnAsignaZonas_Click(object sender, EventArgs e)
        {
            foreach (ZonasTabla Zona in chlZonas.CheckedItems)
            {
                if (Zona.NOMBRE != "ZZZZ")
                    objZonas.insZonaOferta(clsConnection.intCodigoOfertaSimle, Zona.CODIGO);
            }
            llenaZonas();
            llenaGrillaZonasAsignadas();
        }
    }
}
