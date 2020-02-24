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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIVEDI.ListaPrecios
{
    public partial class frmAsignaVariableProdLP : Form
    {
        ServicePedidosClient ServicePedidos = new ServicePedidosClient();
        ServicioGeneralClient ServicioGeneral = new ServicioGeneralClient();
        string SeparadorDecimal = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
        public frmAsignaVariableProdLP()
        {
            InitializeComponent();
        }

        private void frmAsignaVariableProdLP_Load(object sender, EventArgs e)
        {
            txtCodVta.Text = clsConnection.strCodigoVentaProducto;
            txtNomProdLta.Text = clsConnection.strNombreProducto;
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            cargatipoProducto();

            List<ListaPreciosProducto> ListaProductos = new List<ListaPreciosProducto>((IEnumerable<ListaPreciosProducto>)ServicePedidos.getlistaPreciosProdExporta(2, clsConnection.intCodigoProducto, 0));

            if (ListaProductos.Count > 0)
            {
                txtPrecioVenta.Text = ListaProductos.FirstOrDefault().PRECIO.ToString();
                txtLimiteVenta.Text = ListaProductos.FirstOrDefault().LIMITE.ToString();
                txtIvaProducto.Text = Convert.ToInt32(ListaProductos.FirstOrDefault().IVA * 100).ToString();
                txtCostoProd.Text = ListaProductos.FirstOrDefault().COSTO.ToString();
                cboTipoProducto.SelectedValue = ListaProductos.FirstOrDefault().TIPO_PRODUCTO;
                txtPuntosOtorga.Text = ListaProductos.FirstOrDefault().PUNTOS.ToString();
                if (ListaProductos.FirstOrDefault().ES_PRINCIPAL)
                {
                    rdbSiPrincipal.Checked = true;
                    rdbNoPrincipal.Checked = false;
                }
                else
                {
                    rdbSiPrincipal.Checked = false;
                    rdbNoPrincipal.Checked = true;
                }
                if (ListaProductos.FirstOrDefault().PERMITE_DIGITAR)
                {
                    rdbSidigita.Checked = true;
                    rdbNoDigita.Checked = false;
                }
                else
                {
                    rdbSidigita.Checked = false;
                    rdbNoDigita.Checked = true;
                }
                if (ListaProductos.FirstOrDefault().SUMA_VALOR_PUBLICO)
                {
                    rdbSiValorPublico.Checked = true;
                    rdbNoValorPublico.Checked = false;
                }
                else
                {
                    rdbSiValorPublico.Checked = false;
                    rdbNoValorPublico.Checked = true;
                }
                if (ListaProductos.FirstOrDefault().SUMA_LLEGAR_ESCALA)
                {
                    rdbSiLlegaEscala.Checked = true;
                    rdbNoLlegaEscala.Checked = false;
                }
                else
                {
                    rdbSiLlegaEscala.Checked = false;
                    rdbNoLlegaEscala.Checked = true;
                }
                if (ListaProductos.FirstOrDefault().SE_APLICA_ESCALA)
                {
                    rdbSiAplicaEscala.Checked = true;
                    rdbNoAplicaEscala.Checked = false;
                }
                else
                {
                    rdbSiAplicaEscala.Checked = false;
                    rdbNoAplicaEscala.Checked = true;
                }
                if (ListaProductos.FirstOrDefault().APLICA_SUPERA_MONTO_MIN)
                {
                    rdbSiMontoMinimo.Checked = true;
                    rdbNoMontoMinimo.Checked = false;
                }
                else
                {
                    rdbSiMontoMinimo.Checked = false;
                    rdbNoMontoMinimo.Checked = true;
                }
                if (ListaProductos.FirstOrDefault().OES_ACCESORIO)
                {
                    rdbSiAccesorio.Checked = true;
                    rdbNoAccesorio.Checked = false;
                }
                else
                {
                    rdbSiAccesorio.Checked = false;
                    rdbNoAccesorio.Checked = true;
                }
                if (ListaProductos.FirstOrDefault().ESFALTANTE_ANUNCIADO)
                {
                    rdbSiFaltante.Checked = true;
                    rdbNoFaltante.Checked = false;
                }
                else
                {
                    rdbSiFaltante.Checked = false;
                    rdbNoFaltante.Checked = true;
                }
                if (ListaProductos.FirstOrDefault().SUMA_VALOR_NETO)
                {
                    rdbSiNeto.Checked = true;
                    rdbNoNeto.Checked = false;
                }
                else
                {
                    rdbSiNeto.Checked = false;
                    rdbNoNeto.Checked = true;
                }
            }
        }

        private void cargatipoProducto()
        {
            {
                var withBlock = cboTipoProducto;
                withBlock.DataSource = ServicioGeneral.getTiposProducto(1, string.Empty);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedIndex = 0;
            }
        }


        private bool validaCampos()
        {
            if (txtPrecioVenta.Text == "" | txtPrecioVenta.Text == null )
            {
                MessageBox.Show("Ingrese el precio de venta del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (txtIvaProducto.Text == "" | txtIvaProducto.Text == null )
            {
                MessageBox.Show("Ingrese el porcentaje de iva del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (txtLimiteVenta.Text == "" | txtLimiteVenta.Text == null )
            {
                MessageBox.Show("Ingrese el máximo de unidades a vender del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (txtCostoProd.Text == "" | txtCostoProd.Text == null )
            {
                MessageBox.Show("Ingrese el costo del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (txtPuntosOtorga.Text == "" | txtPuntosOtorga.Text == null )
            {
                MessageBox.Show("Ingrese el total de puntos para premios otorga el producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (cboTipoProducto.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione el tipo de producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
                return true;
        }

        private void txtPuntosOtorga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                try
                {
                    string strResult;
                    double iva = Convert.ToInt32(txtIvaProducto.Text);
                    ProductoListaPrecio productoListaPrecio = new ProductoListaPrecio();
                    productoListaPrecio.CODIGO_PRODUCTO_LISTA = clsConnection.intCodigoProducto;
                    productoListaPrecio.PRECIO_LISTA = Convert.ToDecimal(txtPrecioVenta.Text);
                    productoListaPrecio.PRECIO_CATALOGO= Convert.ToDecimal(txtPrecioVenta.Text);
                    productoListaPrecio.LIMITE_VENTA = Convert.ToInt32(txtLimiteVenta.Text);
                    productoListaPrecio.COSTO_PRODUCTO = Convert.ToDecimal(txtCostoProd.Text);
                    productoListaPrecio.PORCENTAJE_IVA = Convert.ToDecimal(iva / 100);
                    productoListaPrecio.TIPO_PRODUCTO = Convert.ToString(cboTipoProducto.SelectedValue);
                    productoListaPrecio.PUNTOS = Convert.ToInt32(txtPuntosOtorga.Text);
                    if (rdbSiPrincipal.Checked)
                        productoListaPrecio.ES_PRINCIPAL = true;
                    else if (rdbNoPrincipal.Checked)
                        productoListaPrecio.ES_PRINCIPAL = false;

                    if (rdbSidigita.Checked)
                        productoListaPrecio.PERMITE_DIGITAR = true;
                    else if (rdbNoDigita.Checked)
                        productoListaPrecio.PERMITE_DIGITAR = false;

                    if (rdbSiValorPublico.Checked)
                        productoListaPrecio.SUMA_VALOR_PUBLICO = true;
                    else if (rdbNoValorPublico.Checked)
                        productoListaPrecio.SUMA_VALOR_PUBLICO = false;

                    if (rdbSiLlegaEscala.Checked)
                        productoListaPrecio.SUMA_LLEGAR_ESCALA = true;
                    else if (rdbNoLlegaEscala.Checked)
                        productoListaPrecio.SUMA_LLEGAR_ESCALA = false;

                    if (rdbSiNeto.Checked)
                        productoListaPrecio.SUMA_NETO = true;
                    else if (rdbNoNeto.Checked)
                        productoListaPrecio.SUMA_NETO = false;

                    if (rdbSiAplicaEscala.Checked)
                        productoListaPrecio.SE_APLICA_ESCALA = true;
                    else if (rdbNoAplicaEscala.Checked)
                        productoListaPrecio.SE_APLICA_ESCALA = false;

                    if (rdbSiMontoMinimo.Checked)
                        productoListaPrecio.APLICA_SUPERA_MONTO_MIN = true;
                    else if (rdbNoMontoMinimo.Checked)
                        productoListaPrecio.APLICA_SUPERA_MONTO_MIN = false;

                    if (rdbSiAccesorio.Checked)
                        productoListaPrecio.ES_ACCESORIO = true;
                    else if (rdbNoAccesorio.Checked)
                        productoListaPrecio.ES_ACCESORIO = false;

                    if (rdbSiFaltante.Checked)
                        productoListaPrecio.ESFALTANTE_ANUNCIADO = true;
                    else if (rdbNoFaltante.Checked)
                        productoListaPrecio.ESFALTANTE_ANUNCIADO = false;
                    strResult = Convert.ToString(ServicePedidos.updPreciosProdcuto(productoListaPrecio));

                    if (Information.IsNumeric(strResult))
                    {
                        if (Convert.ToInt32(strResult) == 1)
                        {
                            MessageBox.Show("Registro Actualizado exitosamente", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al grabar en la Base de Datos, contacte al Administrador del Sistema", "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al generar archivo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCostoProd_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtIvaProducto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtLimiteVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
