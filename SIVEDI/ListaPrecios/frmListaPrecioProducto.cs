using SIVEDI.Clases;
using SIVEDI.ServicePedidos;
using SIVEDI.ServicioGeneral;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Data.OleDb;
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.SS.UserModel;

namespace SIVEDI.ListaPrecios
{
    public partial class frmListaPrecioProducto : Form
    {
        ServicePedidosClient ServicePedidos = new ServicePedidosClient();
        ServicioGeneralClient ServicioGeneral = new ServicioGeneralClient();
        private string strFileName;
        public Thread thColor;
        DataTable dt = new DataTable();
        OperacionesExcel operacionesExcel = new OperacionesExcel();
        public frmListaPrecioProducto()
        {
            InitializeComponent();
        }

        private void frmListaPrecioProducto_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;

            lblPorcentajeCarga.Text = null;
            dtgProductos.ReadOnly = true;
            CargaCombo();
        }

        private void CargaCombo()
        {
            {
                var withBlock = cboListaPrecios;
                withBlock.DataSource = ServicePedidos.getListaPreciosTabla(4, 0);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "CODIGO_LISTA";
                withBlock.SelectedValue = 0;
            }
        }
        private void cargaProductos()
        {
            {
                var withBlock = chkListaProductos;
                withBlock.DataSource = ServicioGeneral.getProductosCodigoVenta(2, string.Empty, Convert.ToInt32(cboListaPrecios.SelectedValue));
                withBlock.DisplayMember = "NOMBRE";
                withBlock.ValueMember = "CODIGO_VENTA";
            }
        }
        private void llenarGrillaProdLista()
        {
            {
                var withBlock = dtgProductos;
                withBlock.DataSource = ServicePedidos.getlistaPreciosProd(1, 0, Convert.ToInt32(cboListaPrecios.SelectedValue));
            }
        }

        private void btnAsignar_Click(System.Object sender, System.EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            thColor = new System.Threading.Thread(asignaProductos);
            if (thColor.ThreadState != System.Threading.ThreadState.Running)
                thColor.Start();
        }
        private void asignaProductos()
        {
            if (validaCampos())
            {
                prbPorcentajeCalculo.Value = 0;
                prbPorcentajeCalculo.Minimum = 0;
                string strResultado;

                foreach (var item in chkListaProductos.CheckedItems)
                {
                    this.Refresh();
                    ProductoListaPrecio productoListaPrecio = new ProductoListaPrecio();
                    prbPorcentajeCalculo.Maximum = chkListaProductos.CheckedItems.Count;
                    prbPorcentajeCalculo.Value = prbPorcentajeCalculo.Value + 1;
                    lblPercent.Text = Convert.ToInt32(prbPorcentajeCalculo.Value * 100 / (double)prbPorcentajeCalculo.Maximum) + "%";
                    var DatosProducto = ServicioGeneral.getProductos(5, 0, string.Empty, Convert.ToInt32(((ProductoCodigoVenta)item).CODIGO_VENTA));

                    productoListaPrecio.APLICA_SUPERA_MONTO_MIN = false;
                    productoListaPrecio.CODIGO_LISTA_PRECIOS = Convert.ToInt32(cboListaPrecios.SelectedValue);
                    productoListaPrecio.CODIGO_PRODUCTO_LISTA = 0;
                    productoListaPrecio.COSTO_PRODUCTO = 0;
                    productoListaPrecio.ESFALTANTE_ANUNCIADO = false;
                    productoListaPrecio.ES_ACCESORIO = false;
                    productoListaPrecio.LIMITE_VENTA = 999;
                    productoListaPrecio.CODIGO_VENTA = Convert.ToInt32(((ProductoCodigoVenta)item).CODIGO_VENTA);
                    productoListaPrecio.PERMITE_DIGITAR = false;
                    productoListaPrecio.PRECIO_LISTA = 1;
                    productoListaPrecio.PUNTOS = DatosProducto.FirstOrDefault().PUNTOS;
                    productoListaPrecio.SE_APLICA_ESCALA = false;
                    productoListaPrecio.SUMA_LLEGAR_ESCALA = false;
                    productoListaPrecio.SUMA_NETO = true;
                    productoListaPrecio.SUMA_VALOR_PUBLICO = false;

                    strResultado = Convert.ToString(ServicePedidos.iuListaPreciosProducto(productoListaPrecio));
                }

                for (int idx = 1; idx <= this.chkListaProductos.Items.Count - 1; idx++)
                {
                    this.chkListaProductos.SetItemCheckState(idx, CheckState.Unchecked);
                }

                MessageBox.Show("Productos asignados a la Lista de precios exitosamente", "Asignación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                prbPorcentajeCalculo.Value = 0;
                prbPorcentajeCalculo.Minimum = 0;
                lblPercent.Text = null;
                llenarGrillaProdLista();
                cargaProductos();
            }
        }

        private bool validaCampos()
        {
            if (cboListaPrecios.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione una lista de precios", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
                return true;
        }

        private void cboListaPrecios_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (cboListaPrecios.SelectedIndex > 0)
            {
                llenarGrillaProdLista();
                cargaProductos();
            }
            else
            {
                var withBlock = dtgProductos;
                withBlock.DataSource = null;
            }
        }

        private void btnBuscaAsignado_Click(object sender, EventArgs e)
        {
            if (cboListaPrecios.SelectedIndex > 0)
                cargaProductos(txtNombreProdAsignado.Text.Trim(), 1);
            else
                MessageBox.Show("Seleccione una lista de precios", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }
        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            if (cboListaPrecios.SelectedIndex > 0)
                cargaProductos(txtNombreProdDisponible.Text, 2);
            else
                MessageBox.Show("Seleccione una lista de precios", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private void cargaProductos(string strNombreProducto, int intOpcion)
        {
            if (intOpcion == 1)
            {
                {
                    var withBlock = dtgProductos;
                    withBlock.DataSource = ServicePedidos.getProductoNombreLista(strNombreProducto, Convert.ToInt32(cboListaPrecios.SelectedValue));
                }
            }
            else if (intOpcion == 2)
            {
                {
                    var withBlock = chkListaProductos;
                    withBlock.DataSource = ServicePedidos.getProductoNombreListaProd(strNombreProducto, Convert.ToInt32(cboListaPrecios.SelectedValue));
                    withBlock.DisplayMember = "NOMBRE";
                    withBlock.ValueMember = "CODIGO";
                }
            }
        }

        private void chkListaProductos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    for (int idx = 1; idx <= this.chkListaProductos.Items.Count - 1; idx++)
                        this.chkListaProductos.SetItemCheckState(idx, CheckState.Checked);
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    for (int idx = 1; idx <= this.chkListaProductos.Items.Count - 1; idx++)
                        this.chkListaProductos.SetItemCheckState(idx, CheckState.Unchecked);
                }
            }
        }

        private void dtgProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cargaFormAsignacion();
        }

        private void cargaFormAsignacion()
        {
            int filaSeleccionada = Convert.ToInt32(dtgProductos.SelectedRows[0].Index);
            clsConnection.intCodigoProducto = Convert.ToInt32(dtgProductos.Rows[filaSeleccionada].Cells[0].Value);
            clsConnection.strCodigoVentaProducto = Convert.ToString(dtgProductos.Rows[filaSeleccionada].Cells[1].Value);
            clsConnection.strReferenciaProducto = Convert.ToString(dtgProductos.Rows[filaSeleccionada].Cells[2].Value);
            clsConnection.strNombreProducto = Convert.ToString(dtgProductos.Rows[filaSeleccionada].Cells[3].Value);
            frmAsignaVariableProdLP objAsignaVariables = new frmAsignaVariableProdLP();
            objAsignaVariables.Show();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Archivo Excel | *.xlsx|Archivo Excel |*.xls";
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                strFileName = save.FileName;
                thColor = new System.Threading.Thread(ExcelNPOI);
                if (thColor.ThreadState != System.Threading.ThreadState.Running)
                    thColor.Start();
            }
        }


        private void ExcelNPOI()
        {
            GeneraExcel generaExcel = new GeneraExcel();
            var ListaPreciosPructo = ServicePedidos.getlistaPreciosProdExporta(3, 0, Convert.ToInt32(cboListaPrecios.SelectedValue));
            try
            {
                generaExcel.generaArchivo(ListaPreciosPructo, strFileName);
                MessageBox.Show("El archivo fue generado en la ruta: " + strFileName, "Archivo Generado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al generar archivo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnCargaInformacion_Click(object sender, EventArgs e)
        {
            try
            {
                CheckForIllegalCrossThreadCalls = false;

                // Instanciamos nuestro cuadro de dialogo
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                // Directorio Predeterminado
                // openFileDialog1.InitialDirectory = "C:\"
                // Filtramos solo archivos con extension *.xls
                openFileDialog1.Filter = "Archivo Excel | *.xlsx|Archivo Excel |*.xls";
                // Si se presiona abrir entonces...
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Asignamos la ruta donde se almacena el fichero excel que se va a importar
                    string RutaArchivo;
                    RutaArchivo = openFileDialog1.FileName;
                    dt = operacionesExcel.Excel_To_DataTable(RutaArchivo, 0);
                    // Llenamos el Datagridview
                    thColor = new System.Threading.Thread(CargaInformacion);
                    if (thColor.ThreadState != System.Threading.ThreadState.Running)
                        thColor.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }


        private void CargaInformacion()
        {
            try
            {
                pbrCarga.Value = 0;
                pbrCarga.Minimum = 0;
                this.Cursor = Cursors.Default;
                pbrCarga.Maximum = dt.Rows.Count;

                for (var i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    ProductoListaPrecio productoListaPrecio = new ProductoListaPrecio();
                    pbrCarga.Refresh();
                    pbrCarga.Value = pbrCarga.Value + 1;
                    lblPorcentajeCarga.Text = Convert.ToInt32(pbrCarga.Value * 100 / (double)pbrCarga.Maximum) + "%";

                    DataRow row = dt.Rows[i];

                    productoListaPrecio.CODIGO_PRODUCTO_LISTA = Convert.ToInt32(row[0]);
                    productoListaPrecio.PRECIO_LISTA = Convert.ToDecimal(row[4]);
                    productoListaPrecio.LIMITE_VENTA = Convert.ToInt32(row[5]);
                    productoListaPrecio.ES_PRINCIPAL = row[6].ToString() == "1" ? true : false;
                    productoListaPrecio.PERMITE_DIGITAR = row[7].ToString() == "1" ? true : false; 
                    productoListaPrecio.SUMA_VALOR_PUBLICO = row[8].ToString() == "1" ? true : false; 
                    productoListaPrecio.SUMA_LLEGAR_ESCALA = row[9].ToString() == "1" ? true : false; 
                    productoListaPrecio.SE_APLICA_ESCALA = row[10].ToString() == "1" ? true : false;
                    productoListaPrecio.APLICA_SUPERA_MONTO_MIN = row[11].ToString() == "1" ? true : false; 
                    productoListaPrecio.SUMA_NETO = row[12].ToString() == "1" ? true : false;  
                    productoListaPrecio.ES_ACCESORIO = row[13].ToString() == "1" ? true : false; 
                    productoListaPrecio.PORCENTAJE_IVA = Convert.ToDecimal(row[14]);
                    productoListaPrecio.COSTO_PRODUCTO = Convert.ToDecimal(row[15]);
                    productoListaPrecio.PUNTOS = Convert.ToInt32(row[16]);
                    productoListaPrecio.ESFALTANTE_ANUNCIADO = row[17].ToString() == "1" ? true : false; 
                    productoListaPrecio.TIPO_PRODUCTO = "STANDARD";
                    productoListaPrecio.PRECIO_CATALOGO = Convert.ToDecimal(row[18]);
                    ServicePedidos.updPreciosProdcuto(productoListaPrecio);
                }
                MessageBox.Show("Archivo cargado exitosamente", "Carga de Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                lblPorcentajeCarga.Text = null;
                pbrCarga.Value = 0;
                pbrCarga.Minimum = 0;
                pbrCarga.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void EliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int strResult;
                int filaSeleccionada = dtgProductos.SelectedRows[0].Index;
                strResult = ServicePedidos.DelCodigoListaPreciosProd(Convert.ToInt32(dtgProductos.Rows[filaSeleccionada].Cells["CODIGO"].Value));
                llenarGrillaProdLista();
                cargaProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }


    }
}
