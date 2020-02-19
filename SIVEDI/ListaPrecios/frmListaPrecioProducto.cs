using SIVEDI.Clases;
using SIVEDI.Clases.TABLAS;
using SIVEDI.ServicePedidos;
using SIVEDI.ServicioGeneral;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIVEDI.ListaPrecios
{
    public partial class frmListaPrecioProducto : Form
    {
        ServicePedidosClient ServicePedidos = new ServicePedidosClient();
        ServicioGeneralClient ServicioGeneral = new ServicioGeneralClient();
        private string strFileName;
        public Thread thColor;
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
                    //strResultado = objListaPrecios.iuListaPreciosProdcuto(0, cboListaPrecios.SelectedValue, 15.2, 999, false, false, false, false, false, false, 0, false, DataRowView("CDV_NID").ToString(), true, dttDatosProducto.Rows(0).Item("PRD_PUNTO_PREMIO"));
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

        private void btnBuscaAsignado_Click(System.Object sender, System.EventArgs e)
        {
            if (cboListaPrecios.SelectedIndex > 0)
                cargaProductos(txtNombreProdAsignado.Text.Trim(), 1);
            else
                MessageBox.Show("Seleccione una lista de precios", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private void cargaProductos(string strNombreProducto, int intOpcion)
        {
            if (intOpcion == 1)
            {
                {
                    var withBlock = dtgProductos;
                    //withBlock.DataSource = objProductos.getProductoNombreLista(strNombreProducto, cboListaPrecios.SelectedValue);
                }
            }
            else if (intOpcion == 2)
            {
                {
                    var withBlock = chkListaProductos;
                    //withBlock.DataSource = objProductos.getProductoNombreListaProd(strNombreProducto, cboListaPrecios.SelectedValue);
                    withBlock.DisplayMember = "PRD_CNOMBRE";
                    withBlock.ValueMember = "CDV_NID";
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
            save.Filter = "Archivo Excel | *.xlsx";
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                strFileName = save.FileName;
                //thColor = new System.Threading.Thread(ExcelNPOI(strFileName));
                //if (thColor.ThreadState != System.Threading.ThreadState.Running)
                //    thColor.Start();
                ExcelNPOI(strFileName);
            }
        }


        private void ExcelNPOI(string ruta)
        {
            GeneraExcel generaExcel = new GeneraExcel();
            var ListaPreciosPructo = ServicePedidos.getlistaPreciosProdExporta(3, 0, Convert.ToInt32(cboListaPrecios.SelectedValue));
            generaExcel.generaArchivo(ListaPreciosPructo, ruta);
        }


    }
}
