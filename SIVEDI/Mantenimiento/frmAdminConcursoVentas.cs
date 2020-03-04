using Microsoft.VisualBasic;
using SIVEDI.Clases;
using SIVEDI.Clases.TABLAS;
using SIVEDI.ServicePedidos;
using SIVEDI.ServicioGeneral;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIVEDI.Mantenimiento
{
    public partial class frmAdminConcursoVentas : Form
    {
        int intCodigoCampanaZona = 0;
        string strNombrezona;
        int intCodigoDetallezona;
        int intCodigoEstadoActividadAsignado;
        int intListaPrecios, intCodigoProducto, intListaPreciosProd;
        bool blnEditaConcurso;
        string SeparadorDecimal = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
        ServicioGeneralClient ServicioGeneral = new ServicioGeneralClient();
        ServicePedidosClient ServicePedidos = new ServicePedidosClient();
        DataTable dttCampanas = new DataTable();
        List<TipoClienteTabla> ListTipoCliente = new List<TipoClienteTabla>();
        public frmAdminConcursoVentas()
        {
            InitializeComponent();
        }

        private void frmAdminConcursoVentas_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            dtgEstadosActividad.ReadOnly = true;
            dtgEstadosActividad.ReadOnly = true;
            dtgZonasAsignadas.ReadOnly = true;
            dtgZonaCampanaAsignada.ReadOnly = true;
            dtgZonasAsignadas.ReadOnly = true;
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            cargaCombos();
            llenaTipoCliente();
            if (clsConnection.intCodigoConcursoVentas == 0)
            {
                cboCampanaEntrega.Focus();
                this.Size = new System.Drawing.Size(861, 250);
                tbcDatosConcurso.Visible = false;
                pnlDatosConcurso.Enabled = true;
                blnEditaConcurso = false;
                llenaZonas();
                llenaCampanasDisponibles();
                llenaEstadosActividadDisponibles();
            }
            else
            {
                this.Size = new System.Drawing.Size(861, 673);
                cargaDatos(clsConnection.intCodigoConcursoVentas.ToString());
                tbcDatosConcurso.Visible = true;
                pnlDatosConcurso.Enabled = true;
                blnEditaConcurso = true;
                llenaProductoConcurso();
                llenaCampanasConcurso();
                llenaCampanasDisponibles();
                llenaZonasCampanas();
                llenaZonas();
                llenaZonasAsignadas();
                llenaEstadosActividad();
                llenaEstadosActividadDisponibles();
            }
        }

        private void cargaCombos()
        {
            {
                var withBlock = cboCampanaEntrega;
                withBlock.DataSource = ServicioGeneral.getCampanas(1, 0);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedValue = 0;
            }
        }
        private void llenaTipoCliente()
        {
            {
                var withBlock = chlTipoCliente;
                var GettipoCliente = ServicioGeneral.getTipoCliente(5, 0);
                ListTipoCliente.Clear();
                foreach (TipoClienteTabla tipo in GettipoCliente)
                {
                    TipoClienteTabla tipoClienteNew = new TipoClienteTabla();
                    tipoClienteNew.COBRA_FLETE = tipo.COBRA_FLETE;
                    tipoClienteNew.CODIGO = tipo.CODIGO;
                    tipoClienteNew.ESTADO = tipo.ESTADO;
                    tipoClienteNew.NOMBRE = tipo.NOMBRE;
                    ListTipoCliente.Add(tipoClienteNew);
                }


                withBlock.DataSource = ListTipoCliente;
                withBlock.DisplayMember = "NOMBRE";
                withBlock.ValueMember = "CODIGO";
            }
        }
        private void llenaZonas()
        {
            {
                var withBlock = chlZonas;
                withBlock.DataSource = ServicioGeneral.getZonasConcursoVentas(clsConnection.intCodigoConcursoVentas);
                withBlock.DisplayMember = "NOMBRE";
                withBlock.ValueMember = "CODIGO";
            }
        }
        private void llenaEstadosActividad()
        {
            {
                var withBlock = dtgEstadosActividad;
                withBlock.DataSource = ServicioGeneral.getEstadoActividadConcursoVenta(clsConnection.intCodigoConcursoVentas);
            }
        }
        private void llenaEstadosActividadDisponibles()
        {
            {
                var withBlock = chkEstadosActividad;
                withBlock.DataSource = ServicioGeneral.getListaEstadosActiDisponiblesConcursoVentas(clsConnection.intCodigoConcursoVentas);
                withBlock.DisplayMember = "NOMBRE";
                withBlock.ValueMember = "CODIGO";
            }
            for (int idx = 1; idx <= this.chkEstadosActividad.Items.Count - 1; idx++)
                this.chkEstadosActividad.SetItemCheckState(idx, CheckState.Unchecked);
        }

        private bool validaCamposEncabezado()
        {
            int intTotalTipoCliente = 0;
            foreach (var DataRowView in chlTipoCliente.CheckedItems)
                intTotalTipoCliente = intTotalTipoCliente + 1;
            if (txtNombreConcurso.Text == "" | txtNombreConcurso.Text == null)
            {
                MessageBox.Show("Ingrese el nombre del concurso", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtNombreConcurso.Focus();
                return false;
            }
            else if (cboCampanaEntrega.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione la campaña de Entrega del pedido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboCampanaEntrega.Focus();
                return false;
            }
            else if (!rdbNoEntregaMismaCampana.Checked & !rdbSiEntregaMismaCampana.Checked)
            {
                MessageBox.Show("Seleccione si se valida la campaña actual para la entrega del premio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (!rdbActivo.Checked & !rdbInactivo.Checked)
            {
                MessageBox.Show("Seleccione el estado del concurso", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (intTotalTipoCliente == 0)
            {
                MessageBox.Show("El councurso debe tener seleccionado al menos una opción de Aplica para", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (!rdbNoIngresos.Checked & !rdbSiIngresos.Checked)
            {
                MessageBox.Show("Seleccione si el premio se entrega a los asesores nuevos o ingresos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (!rdbSientregaAcumPremio.Checked & !rdbNoentregaAcumPremio.Checked)
            {
                MessageBox.Show("Seleccione si los premios se entregan con valores acumulados o solamente el premio que cae en nivel", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
                return true;
        }

        private void llenaZonasAsignadas()
        {
            {
                var withBlock = dtgZonasAsignadas;
                withBlock.DataSource = ServicioGeneral.getZonasAsignadasConcuusoVentas(1, clsConnection.intCodigoConcursoVentas, 0);
            }
        }
        private void limpiaCamposZona()
        {
            rdbNoAcumulado.Checked = false;
            rdbSiAcumulado.Checked = false;
            intCodigoDetallezona = 0;
            strNombrezona = null;
            txtProcentajeColchon.Text = null;
        }
        private bool validaCamposZonasAsigna()
        {
            if (!rdbSiAcumulado.Checked & !rdbNoAcumulado.Checked)
            {
                MessageBox.Show("Seleccione si la validación de la condición es Acumulado o no es acumulado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (txtProcentajeColchon.Text == "" | txtProcentajeColchon.Text == null)
            {
                MessageBox.Show("digite el porcentaje de colchon para los pedidos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtProcentajeColchon.Focus();
                return false;
            }
            else
                return true;
        }

        private void chlCampanas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (chlCampanas.SelectedIndex > 0)
            {
                DataRow row;
                int intTotalEncontrado = 0;
                if (dttCampanas.Columns.Count == 0)
                {
                    {
                        var withBlock = dttCampanas;
                        withBlock.Columns.Add(new DataColumn("CODIGO", typeof(string)));
                        withBlock.Columns.Add(new DataColumn("NOMBRE", typeof(string)));
                        withBlock.Columns.Add(new DataColumn("MONTO", typeof(int)));
                    }
                }
                for (var i = 0; i <= dttCampanas.Rows.Count - 1; i++)
                {
                    if (dtgCampanaAsinada.Rows[i].Cells["CODIGO"].Value.ToString() == this.chlCampanas.SelectedValue.ToString())
                    {
                        intTotalEncontrado = intTotalEncontrado + 1;
                        dtgCampanaAsinada.Rows[i].Cells["CODIGO"].ReadOnly = true;
                        dtgCampanaAsinada.Rows[i].Cells["NOMBRE"].ReadOnly = true;
                    }
                }
                if (intTotalEncontrado == 0)
                {
                    row = dttCampanas.NewRow();
                    row["CODIGO"] = this.chlCampanas.SelectedValue.ToString();
                    row["NOMBRE"] = this.chlCampanas.Text;
                    row["MONTO"] = 0;
                    dttCampanas.Rows.Add(row);
                    {
                        var withBlock = dtgCampanaAsinada;
                        withBlock.DataSource = dttCampanas;
                    }
                }
            }
        }

        private void llenaCampanasDisponibles()
        {
            var withBlock = chlCampanas;
            withBlock.DataSource = ServicioGeneral.getCampanasConcursoVentas(clsConnection.intCodigoConcursoVentas);
            withBlock.DisplayMember = "NOMBRE";
            withBlock.ValueMember = "CODIGO";
        }

        private void txtcodigoProducto_Leave(object sender, EventArgs e)
        {
            if (txtcodigoProducto.Text != "")
                cargaProductoDigitado();
        }

        private void cboCampanaEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCampanaEntrega.SelectedIndex > 0)
            {
                var listaPreciosProductos = ServicePedidos.getListaPreciosXcampana(Convert.ToInt32(cboCampanaEntrega.SelectedValue));
                intListaPrecios = listaPreciosProductos.FirstOrDefault().CODIGO;
            }
            else
            {
                intListaPrecios = 0;
            }
        }

        private void txtcodigoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                if (txtcodigoProducto.Text != "")
                    cargaProductoDigitado();
            }
        }

        private void llenaCampanasConcurso()
        {
            dttCampanas = ConvertToDataTable(ServicioGeneral.getCampanasAsignadasConcursoVentas(clsConnection.intCodigoConcursoVentas));
            {
                var withBlock = dtgCampanaAsinada;
                withBlock.DataSource = dttCampanas;
            }
            for (var t = 0; t <= dtgCampanaAsinada.Rows.Count - 1; t++)
            {
                dtgCampanaAsinada.Rows[t].Cells["CODIGO"].ReadOnly = true;
                dtgCampanaAsinada.Rows[t].Cells["NOMBRE"].ReadOnly = true;
            }
        }
        private void llenaZonasCampanas()
        {
            var dttCampanasZonas = ServicioGeneral.getDatosZonaCampanaConcursoVentas(Convert.ToInt32(clsConnection.intCodigoConcursoVentas));
            {
                var withBlock = dtgZonaCampanaAsignada;
                withBlock.DataSource = dttCampanasZonas;
            }
        }

        private void cargaProductoDigitado()
        {
            if (intListaPrecios != 0)
            {
                var dttProducto = ServicePedidos.getProductoPedidos(txtcodigoProducto.Text, intListaPrecios);
                if (dttProducto.Count() > 0)
                {
                    intListaPreciosProd = Convert.ToInt32(dttProducto.FirstOrDefault().CODIGO);
                    txtNombreProducto.Text = dttProducto.FirstOrDefault().NOMBRE_PRODUCTO;
                    txtValorCondMinima.Focus();
                }
                else
                {
                    MessageBox.Show("Código de producto no existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    txtcodigoProducto.Focus();
                }
            }
            else
                MessageBox.Show("Seleccione la campaña de entrega del premio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }


        private bool validaCamposProducto()
        {
            if (txtcodigoProducto.Text == "" | txtcodigoProducto.Text == null)
            {
                MessageBox.Show("Digite el codigo de venta del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtcodigoProducto.Focus();
                return false;
            }
            else if (txtNombreProducto.Text == "" | txtNombreProducto.Text == null)
            {
                MessageBox.Show("Digite el codigo de venta del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtNombreProducto.Focus();
                return false;
            }
            else if (txtValorCondMinima.Text == "" | txtValorCondMinima.Text == null)
            {
                MessageBox.Show("Ingrese valor mínimo del pedido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtValorCondMinima.Focus();
                return false;
            }
            else if (txtValorConMaxima.Text == "" | txtValorConMaxima.Text == null)
            {
                MessageBox.Show("Ingrese valor máximo del pedido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtValorConMaxima.Focus();
                return false;
            }
            else if (txtUnidadesEntrega.Text == "" | txtUnidadesEntrega.Text == null)
            {
                MessageBox.Show("Ingrese las unidades a entregar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtUnidadesEntrega.Focus();
                return false;
            }
            else if (System.Convert.ToInt32(txtUnidadesEntrega.Text) <= 0)
            {
                MessageBox.Show("Las unidades deben ser mayor a Cero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtUnidadesEntrega.Focus();
                return false;
            }
            else
                return true;
        }

        private void dtgZonaCampanaAsignada_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1)
            {
                intCodigoCampanaZona = Convert.ToInt32(dtgZonaCampanaAsignada.Rows[e.RowIndex].Cells["CODIGO"].Value);
                txtCampanaZona.Text = Convert.ToString(dtgZonaCampanaAsignada.Rows[e.RowIndex].Cells["CAMPANA"].Value);
                txtZonaCampana.Text = Convert.ToString(dtgZonaCampanaAsignada.Rows[e.RowIndex].Cells["NOMBRE"].Value);
                txtMonto.Text = Convert.ToString(dtgZonaCampanaAsignada.Rows[e.RowIndex].Cells["MONTO"].Value);
            }
        }

        private void limpiaCamposProducto()
        {
            txtcodigoProducto.Text = null;
            txtNombreProducto.Text = null;
            txtValorCondMinima.Text = null;
            txtValorConMaxima.Text = null;
            txtUnidadesEntrega.Text = null;
            rdbSientregaAcumPremio.Checked = false;
            rdbNoentregaAcumPremio.Checked = false;
            intCodigoProducto = 0;
            intListaPreciosProd = 0;
        }

        private void dtgProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                intCodigoProducto = Convert.ToInt32(dtgProductos.Rows[e.RowIndex].Cells["CODIGO"].Value);
                txtcodigoProducto.Text = Convert.ToString(dtgProductos.Rows[e.RowIndex].Cells["PRODUCTO"].Value);
                txtNombreProducto.Text = Convert.ToString(dtgProductos.Rows[e.RowIndex].Cells["NOMBRE"].Value);
                txtValorCondMinima.Text = Convert.ToString(dtgProductos.Rows[e.RowIndex].Cells["VLR MINIMO"].Value);
                txtValorConMaxima.Text = Convert.ToString(dtgProductos.Rows[e.RowIndex].Cells["VLR MAXIMO"].Value);
                txtUnidadesEntrega.Text = Convert.ToString(dtgProductos.Rows[e.RowIndex].Cells["UNIDADES"].Value);
                intListaPreciosProd = Convert.ToInt32(dtgProductos.Rows[e.RowIndex].Cells["CODIGO LISTA"].Value);
            }
        }

        private void frmAdminConcursoVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            clsConnection.blnActualizaListaconcursosNvo = true;
        }

        private void llenaProductoConcurso()
        {
            {
                var withBlock = dtgProductos;
                withBlock.DataSource = ServicioGeneral.getPremiosConcursoVentas(clsConnection.intCodigoConcursoVentas);
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

        private bool validaCamposUpsznaCampanas()
        {
            if (txtMonto.Text == "" | txtMonto.Text == null)
            {
                MessageBox.Show("Ingrese el Monto a actualizar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtMonto.Focus();
                return false;
            }
            else
                return true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validaCamposEncabezado())
            {
                string strResultado;
                ConcursoVentas concursoVentas = new ConcursoVentas();

                if (rdbActivo.Checked)
                    concursoVentas.ESTADO = true;
                else
                    concursoVentas.ESTADO = false;

                if (rdbSiEntregaMismaCampana.Checked)
                    concursoVentas.VALIDA_CAMPANA_ACTUAL = true;
                else
                    concursoVentas.VALIDA_CAMPANA_ACTUAL = false;
                if (rdbSiIngresos.Checked)
                    concursoVentas.ES_PARA_INGRESO = true;
                else
                    concursoVentas.ES_PARA_INGRESO = false;

                if (rdbSientregaAcumPremio.Checked)
                    concursoVentas.ENTREGA_PREMIO_ACUMULADO = true;
                else
                    concursoVentas.ENTREGA_PREMIO_ACUMULADO = false;
                concursoVentas.CODIGO = clsConnection.intCodigoConcursoVentas;
                concursoVentas.NOMBRE = txtNombreConcurso.Text.ToUpper();
                concursoVentas.CAMPANA_ENTREGA = Convert.ToInt32(cboCampanaEntrega.SelectedValue);

                strResultado = Convert.ToString(ServicioGeneral.insConcursoVentas(concursoVentas));


                if (Information.IsNumeric(strResultado))
                {
                    clsConnection.intCodigoConcursoVentas = System.Convert.ToInt32(strResultado);
                    ServicioGeneral.delTipoClienteConcurso(clsConnection.intCodigoConcursoVentas);

                    foreach (TipoClienteTabla itemchecked in chlTipoCliente.CheckedItems)
                    {
                        TipoClienteConcurso tipoClienteConcurso = new TipoClienteConcurso();
                        tipoClienteConcurso.CODIGO_CONCURSO = clsConnection.intCodigoConcursoVentas;
                        tipoClienteConcurso.CODIGO_TIPO_CLIENTE = itemchecked.CODIGO;

                        ServicioGeneral.insTipoClienteConcursoVentas(tipoClienteConcurso);
                    }
                    tbcDatosConcurso.Visible = true;
                    pnlDatosConcurso.Enabled = false;
                    this.Size = new System.Drawing.Size(861, 673);
                }
                else
                    MessageBox.Show(strResultado, "Error grabar BD", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnAsignaZonas_Click(object sender, EventArgs e)
        {
            if (validaCamposZonasAsigna())
            {
                ZonaConcursoVentasIns zonaConcursoVentasIns = new ZonaConcursoVentasIns();
                int strResultado;

                if (rdbSiAcumulado.Checked)
                    zonaConcursoVentasIns.ES_ACUMULADO = true;
                else
                    zonaConcursoVentasIns.ES_ACUMULADO = false;

                zonaConcursoVentasIns.PORCENTAJE_COLCHON = Convert.ToDecimal(txtProcentajeColchon.Text);
                zonaConcursoVentasIns.CODIGO_CONCURSO = clsConnection.intCodigoConcursoVentas;

                if (intCodigoDetallezona != 0)
                {
                    zonaConcursoVentasIns.CODIGO_ZONA = strNombrezona.Trim().ToUpper();
                    zonaConcursoVentasIns.CODIGO_ZONA_CONCURSO_VENTA = intCodigoDetallezona;
                    strResultado = ServicioGeneral.insZonasConcursoVentas(zonaConcursoVentasIns);


                    if (Information.IsNumeric(strResultado))
                    {
                        limpiaCamposZona();
                        llenaZonas();
                        llenaZonasAsignadas();
                    }
                    else
                        MessageBox.Show(strResultado.ToString(), "Error grabar BD", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    zonaConcursoVentasIns.CODIGO_ZONA_CONCURSO_VENTA = 0;
                    foreach (ZonaConcursoVentas zonaConcurso in chlZonas.CheckedItems)
                    {
                        if (zonaConcurso.CODIGO != "ZZZZ")
                        {
                            zonaConcursoVentasIns.CODIGO_ZONA = zonaConcurso.CODIGO;
                            ServicioGeneral.insZonasConcursoVentas(zonaConcursoVentasIns);
                        }
                    }

                    limpiaCamposZona();
                    {
                        var withBlock = chlZonas;
                        withBlock.DataSource = null;
                    }
                    llenaZonas();
                    llenaZonasAsignadas();
                    llenaZonasCampanas();
                }
            }
        }

        private void dtgZonasAsignadas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                intCodigoDetallezona = Convert.ToInt32(dtgZonasAsignadas.Rows[e.RowIndex].Cells["CODIGO"].Value);
                strNombrezona = Convert.ToString(dtgZonasAsignadas.Rows[e.RowIndex].Cells["CODIGO_ZONA"].Value);
                if (Convert.ToString(dtgZonasAsignadas.Rows[e.RowIndex].Cells["ES_ACUM"].Value) == "SI")
                {
                    rdbSiAcumulado.Checked = true;
                    rdbNoAcumulado.Checked = false;
                }
                else
                {
                    rdbSiAcumulado.Checked = false;
                    rdbNoAcumulado.Checked = true;
                }
                txtProcentajeColchon.Text = string.Format(new CultureInfo("es-CO"), "{0:0.00}", Convert.ToDecimal(dtgZonasAsignadas.Rows[e.RowIndex].Cells["PORCENTAJE"].Value)); ;
            }
        }

        private void txtProcentajeColchon_KeyPress(object sender, KeyPressEventArgs e)
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
            else
            {
                if (e.KeyChar == 46 && e.KeyChar != Convert.ToChar(SeparadorDecimal))
                {
                    e.KeyChar = (char)44;
                    e.Handled = false;
                    return;
                }
                else if (e.KeyChar == 44 && e.KeyChar != Convert.ToChar(SeparadorDecimal))
                {
                    e.KeyChar = (char)46;
                    e.Handled = false;
                    return;
                }
            }
        }

        private void eliminaTerritorio_Click(object sender, EventArgs e)
        {
            int filaSeleccionada = dtgZonasAsignadas.SelectedRows[0].Index;
            string strResultado;
            int intCodigoTerritorioElimina;
            intCodigoTerritorioElimina = Convert.ToInt32(dtgZonasAsignadas.Rows[filaSeleccionada].Cells[0].Value);

            strResultado = ServicioGeneral.delTerritorioConcurso(intCodigoTerritorioElimina).ToString();

            if (!Information.IsNumeric(strResultado))
                MessageBox.Show(strResultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            else
            {
                intCodigoTerritorioElimina = 0;
                limpiaCamposZona();
                {
                    var withBlock = chlZonas;
                    withBlock.DataSource = null;
                }
                llenaZonas();
                llenaZonasAsignadas();
                llenaZonasCampanas();
            }
        }

        private void btnGrabaCampanas_Click(object sender, EventArgs e)
        {
            grabaCampanas();
        }


        private void grabaCampanas()
        {
            for (var z = 0; z <= dtgCampanaAsinada.Rows.Count - 1; z++)
            {
                CampanasConcursoVentasIns campanasConcursoVentasIns = new CampanasConcursoVentasIns();
                campanasConcursoVentasIns.CODIGO_CAMPANA = Convert.ToInt32(dtgCampanaAsinada.Rows[z].Cells["CODIGO"].Value.ToString());
                campanasConcursoVentasIns.CODIGO_CONCURSO = clsConnection.intCodigoConcursoVentas;
                campanasConcursoVentasIns.VALOR = Convert.ToDecimal(dtgCampanaAsinada.Rows[z].Cells["MONTO"].Value.ToString());

                if (!Information.IsNumeric(Convert.ToInt32(dtgCampanaAsinada.Rows[z].Cells["CODIGO"].Value.ToString())))
                {
                    campanasConcursoVentasIns.CODIGO_CAMPANA_ZONA = intCodigoCampanaZona;
                    ServicioGeneral.iuCampanasConcursoVentas(campanasConcursoVentasIns);
                }
                else
                {
                    intCodigoCampanaZona = Convert.ToInt32(dtgCampanaAsinada.Rows[z].Cells["CODIGO"].Value.ToString());
                    campanasConcursoVentasIns.CODIGO_CAMPANA_ZONA = intCodigoCampanaZona;
                    ServicioGeneral.iuCampanasConcursoVentas(campanasConcursoVentasIns);
                }
            }
            llenaCampanasConcurso();
            llenaCampanasDisponibles();
            llenaZonasCampanas();
        }

        private void EliminaCampana_Click(object sender, EventArgs e)
        {
            int filaSeleccionada = dtgCampanaAsinada.SelectedRows[0].Index;
            string strResultado;
            int intCodigoCampanaElimina;
            intCodigoCampanaElimina = Convert.ToInt32(dtgCampanaAsinada.Rows[filaSeleccionada].Cells[0].Value);
            strResultado = ServicioGeneral.delCampanaConcursoVenta(intCodigoCampanaElimina, clsConnection.intCodigoConcursoVentas).ToString();
            if (!Information.IsNumeric(strResultado))
                MessageBox.Show(strResultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            else
            {
                intCodigoCampanaElimina = 0;
                llenaCampanasConcurso();
                llenaCampanasDisponibles();
                llenaEstadosActividadDisponibles();
                llenaZonasCampanas();
            }
        }

        private void btnGrabaEstados_Click(object sender, EventArgs e)
        {
            int strResultado;

            foreach (EstadoActividadConcursoVentas estadoActividad in chkEstadosActividad.CheckedItems)
            {
                EstadoActividadIns estadoActividadIns = new EstadoActividadIns();
                estadoActividadIns.CODIGO_ASIGNADO = intCodigoEstadoActividadAsignado;
                estadoActividadIns.CODIGO_CONCURSO = clsConnection.intCodigoConcursoVentas;

                if (System.Convert.ToInt32(estadoActividad.CODIGO) != 0)
                {
                    estadoActividadIns.CODIGO_ESTADO_ACTIVIDAD = estadoActividad.CODIGO;
                    strResultado = ServicioGeneral.iuEstadoActividadConcursoVentas(estadoActividadIns);
                }
            }
            llenaEstadosActividad();
            llenaEstadosActividadDisponibles();
        }

        private void EliminaProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filaSeleccionada = dtgEstadosActividad.SelectedRows[0].Index;
            string strResultado;
            int intCodigoEstadoElimina;
            intCodigoEstadoElimina = Convert.ToInt32(dtgEstadosActividad.Rows[filaSeleccionada].Cells[0].Value);
            strResultado = ServicioGeneral.delEstadoActividadConcursoVentas(intCodigoEstadoElimina).ToString();
            if (!Information.IsNumeric(strResultado))
                MessageBox.Show(strResultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            else
            {
                intCodigoEstadoElimina = 0;
                llenaEstadosActividad();
                llenaEstadosActividadDisponibles();
            }
        }

        private void btnAdicionaProducto_Click(object sender, EventArgs e)
        {
            if (validaCamposProducto())
            {
                string strResultado;
                ObsequioConcursoVentaIns obsequioConcursoVentaIns = new ObsequioConcursoVentaIns();
                obsequioConcursoVentaIns.CODIGO_OBSEQUIO = intCodigoProducto;
                obsequioConcursoVentaIns.CODIGO_LISTA_PRECIOS = intListaPreciosProd;
                obsequioConcursoVentaIns.VALOR_MINIMO = Convert.ToDecimal(txtValorCondMinima.Text);
                obsequioConcursoVentaIns.VALOR_MAXIMO = Convert.ToDecimal(txtValorConMaxima.Text);
                obsequioConcursoVentaIns.UNIDADES = Convert.ToInt32(txtUnidadesEntrega.Text);
                obsequioConcursoVentaIns.CODIGO_CONCURSO = clsConnection.intCodigoConcursoVentas;
                strResultado = ServicioGeneral.insProductoConcursoVentas(obsequioConcursoVentaIns).ToString();

                if (Information.IsNumeric(strResultado))
                {
                    if (Convert.ToInt32(strResultado) < 0)
                        MessageBox.Show("Producto Actualizado exitosamente", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    else
                        MessageBox.Show("Regitro de producto realizado exitosamente", "Creación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    intCodigoProducto = 0;
                    limpiaCamposProducto();
                    llenaProductoConcurso();
                }
                else
                    MessageBox.Show(strResultado, "Error grbar BD", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtValorCondMinima_KeyPress(object sender, KeyPressEventArgs e)
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
            else
            {
                if (e.KeyChar == 46 && e.KeyChar != Convert.ToChar(SeparadorDecimal))
                {
                    e.KeyChar = (char)44;
                    e.Handled = false;
                    return;
                }
                else if (e.KeyChar == 44 && e.KeyChar != Convert.ToChar(SeparadorDecimal))
                {
                    e.KeyChar = (char)46;
                    e.Handled = false;
                    return;
                }
            }
        }

        private void txtValorConMaxima_KeyPress(object sender, KeyPressEventArgs e)
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
            else
            {
                if (e.KeyChar == 46 && e.KeyChar != Convert.ToChar(SeparadorDecimal))
                {
                    e.KeyChar = (char)44;
                    e.Handled = false;
                    return;
                }
                else if (e.KeyChar == 44 && e.KeyChar != Convert.ToChar(SeparadorDecimal))
                {
                    e.KeyChar = (char)46;
                    e.Handled = false;
                    return;
                }
            }
        }

        private void btnActualizaZona_Click(object sender, EventArgs e)
        {
            string strResultado;
            if (validaCamposUpsznaCampanas())
            {
                strResultado = ServicioGeneral.updCampanaZona(intCodigoCampanaZona, Convert.ToDecimal(txtMonto.Text)).ToString();
                if (Information.IsNumeric(strResultado))
                {
                    intCodigoCampanaZona = 0;
                    txtMonto.Text = null;
                    txtCampanaZona.Text = null;
                    txtZonaCampana.Text = null;
                    llenaZonasCampanas();
                    MessageBox.Show("Registro actualizado exitosamente", "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                    MessageBox.Show(strResultado, "Error grabar BD", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
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
            else
            {
                if (e.KeyChar == 46 && e.KeyChar != Convert.ToChar(SeparadorDecimal))
                {
                    e.KeyChar = (char)44;
                    e.Handled = false;
                    return;
                }
                else if (e.KeyChar == 44 && e.KeyChar != Convert.ToChar(SeparadorDecimal))
                {
                    e.KeyChar = (char)46;
                    e.Handled = false;
                    return;
                }
            }
        }

        private void cargaDatos(string strCodigoConcurso)
        {
            var dttDatosConcurso = ServicioGeneral.getConcursosVentas(3, clsConnection.intCodigoConcursoVentas);
            if (dttDatosConcurso.Count() > 0)
            {
                txtNombreConcurso.Text = dttDatosConcurso.FirstOrDefault().NOMBRE;
                cboCampanaEntrega.SelectedValue = dttDatosConcurso.FirstOrDefault().CAMPANA_ENTREGA;
                if (dttDatosConcurso.FirstOrDefault().ESTADO)
                {
                    rdbActivo.Checked = true;
                    rdbInactivo.Checked = false;
                }
                else
                {
                    rdbActivo.Checked = false;
                    rdbInactivo.Checked = true;
                }
                if (dttDatosConcurso.FirstOrDefault().VALIDA_CAMPANA_ACTUAL)
                {
                    rdbSiEntregaMismaCampana.Checked = true;
                    rdbNoEntregaMismaCampana.Checked = false;
                }
                else
                {
                    rdbSiEntregaMismaCampana.Checked = false;
                    rdbNoEntregaMismaCampana.Checked = true;
                }
                if (dttDatosConcurso.FirstOrDefault().ES_PARA_INGRESO)
                {
                    rdbSiIngresos.Checked = true;
                    rdbNoIngresos.Checked = false;
                }
                else
                {
                    rdbSiIngresos.Checked = false;
                    rdbNoIngresos.Checked = true;
                }
                if (dttDatosConcurso.FirstOrDefault().ENTREGA_PREMIO_ACUMULADO)
                {
                    rdbSientregaAcumPremio.Checked = true;
                    rdbNoentregaAcumPremio.Checked = false;
                }
                else
                {
                    rdbSientregaAcumPremio.Checked = false;
                    rdbNoentregaAcumPremio.Checked = true;
                }
                var dttTipoClienteconc = ServicioGeneral.getTipoClienteConcursosVentas(clsConnection.intCodigoConcursoVentas);
                DataTable table = ConvertToDataTable(ListTipoCliente);
                if (dttTipoClienteconc.Count() > 0)
                {
                    foreach (TipoClienteConcursoVenta tipoCliente in dttTipoClienteconc)
                    {
                        for (var m = 0; m <= table.Rows.Count - 1; m++)
                        {
                            if (Convert.ToInt32(table.Rows[m]["CODIGO"].ToString()) == tipoCliente.CODIGO)
                                chlTipoCliente.SetItemChecked(m, true);
                        }
                    }
                }
            }
        }


        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }
    }
}
