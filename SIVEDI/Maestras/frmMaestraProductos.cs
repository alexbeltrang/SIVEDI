using Microsoft.VisualBasic;
using SIVEDI.Clases;
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

namespace SIVEDI.Maestras
{
    public partial class frmMaestraProductos : Form
    {
        ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
        int intCodigoProducto = 0;
        public frmMaestraProductos()
        {
            InitializeComponent();
        }

        private void frmMaestraProductos_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CO");
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ",";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ",";
            dtgProducto.ReadOnly = true;
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            CargaCombo();
            llenaGrilla();
            txtReferencia.Focus();
        }

        private void llenaGrilla()
        {
            {
                var withBlock = dtgProducto;
                withBlock.DataSource = servicioGeneral.getProductos(1, 0, string.Empty, 0);
            }
        }
        private void CargaCombo()
        {
            {
                var withBlock = cboUnidadMedida;
                withBlock.DataSource = servicioGeneral.getUnidadMedida(1, 0);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedValue = 0;
            }
        }

        private bool validaCampos()
        {
            int intTotalPuntos = 0;
            for (var i = 0; i <= txtIva.Text.Length - 1; i++)
            {
                int ascii = Encoding.ASCII.GetBytes(txtIva.Text.Substring(i, 1))[0];
                if (ascii == 46)
                    intTotalPuntos = intTotalPuntos + 1;
            }
            if (txtReferencia.Text == null | txtReferencia.Text == string.Empty)
            {
                MessageBox.Show("Digite el código de Referencia del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtReferencia.Focus();
                return false;
            }
            else if (txtNombreProducto.Text == null | txtNombreProducto.Text == "")
            {
                MessageBox.Show("Digite el nombre del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtNombreProducto.Focus();
                return false;
            }
            else if (!Information.IsNumeric(txtIva.Text))
            {
                MessageBox.Show("Ingrese el valor del IVA en formato decimal", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtIva.Focus();
                return false;
            }
            else if (intTotalPuntos > 1)
            {
                MessageBox.Show("El campo IVA no es un número Decimal", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtIva.Focus();
                return false;
            }
            else if (txtPuntoPremios.Text == "" | txtPuntoPremios.Text == null)
            {
                MessageBox.Show("Debe ingresar el total de puntos que el producto entrega para concursos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtPuntoPremios.Focus();
                return false;
            }
            else if (cboUnidadMedida.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione la unidad de medida del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboUnidadMedida.Focus();
                return false;
            }
            else if (!rbnActivo.Checked & !rbnInactivo.Checked)
            {
                MessageBox.Show("Seleccione un estado para el Producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                rbnActivo.Focus();
                return false;
            }
            else
                return true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                string strResultado;
                Productos productos = new Productos();
                if (rbnActivo.Checked)
                {
                    productos.ESTADO = true;
                }
                else
                {
                    productos.ESTADO = false;
                }
                productos.CENTRO_GASTO_OBSEQUIO = txtCGObsequio.Text.ToUpper();
                productos.CENTRO_GASTO_VENTA = txtCGVenta.Text.ToUpper();
                productos.CODIGO = intCodigoProducto;
                productos.CODIGO_UNIDAD_MEDIDA = Convert.ToInt32(cboUnidadMedida.SelectedValue);
                productos.IVA = Convert.ToDecimal(txtIva.Text);
                productos.MOTIVO_OBSEQUIO = txtMotivoObsequio.Text.ToUpper();
                productos.MOTIVO_VENTA = txtMotivoVenta.Text.ToUpper();
                productos.NOMBRE = txtNombreProducto.Text.ToUpper();
                productos.PUNTOS = Convert.ToInt32(txtPuntoPremios.Text);
                productos.REFERENCIA = txtReferencia.Text.ToUpper();
                strResultado = Convert.ToString(servicioGeneral.insProducto(productos));

                if (Information.IsNumeric(strResultado))
                {
                    llenaGrilla();
                    limpiaCampos();
                    txtReferencia.Focus();
                    if (Convert.ToInt32(strResultado) > 0)
                    {
                        MessageBox.Show("Registro creado exitosamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else if (Convert.ToInt32(strResultado) < 0)
                    {
                        MessageBox.Show("Registro Actualizado exitosamente", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }

                }
                else
                {
                    MessageBox.Show("Error al grabar en la Base de Datos, contacte al Administrador del Sistema", "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void txtIva_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch8;
            ch8 = e.KeyChar;
            if (ch8 != '.')
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
        }

        private void dtgProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                intCodigoProducto = Convert.ToInt32(dtgProducto.Rows[e.RowIndex].Cells["CODIGO"].Value);
                txtCGObsequio.Text = Convert.ToString(dtgProducto.Rows[e.RowIndex].Cells["CENTRO_GASTO_OBSEQUIO"].Value);
                txtCGVenta.Text = Convert.ToString(dtgProducto.Rows[e.RowIndex].Cells["CENTRO_GASTO_VENTA"].Value);
                txtReferencia.Text = Convert.ToString(dtgProducto.Rows[e.RowIndex].Cells["REFERENCIA"].Value);
                txtIva.Text = Convert.ToString(dtgProducto.Rows[e.RowIndex].Cells["IVA"].Value);
                txtMotivoObsequio.Text = Convert.ToString(dtgProducto.Rows[e.RowIndex].Cells["MOTIVO_OBSEQUIO"].Value);
                txtMotivoVenta.Text = Convert.ToString(dtgProducto.Rows[e.RowIndex].Cells["MOTIVO_VENTA"].Value);
                txtNombreProducto.Text = Convert.ToString(dtgProducto.Rows[e.RowIndex].Cells["NOMBRE"].Value);
                txtPuntoPremios.Text = Convert.ToString(dtgProducto.Rows[e.RowIndex].Cells["PUNTOS"].Value);
                if (Convert.ToString(dtgProducto.Rows[e.RowIndex].Cells["ESTADO"].Value) == "ACTIVO")
                {
                    rbnActivo.Checked = true;
                    rbnInactivo.Checked = false;
                }
                else if (Convert.ToString(dtgProducto.Rows[e.RowIndex].Cells["ESTADO"].Value) == "INACTIVO")
                {
                    rbnActivo.Checked = false;
                    rbnInactivo.Checked = true;
                }
                else
                {
                    rbnActivo.Checked = false;
                    rbnInactivo.Checked = false;
                }
                cboUnidadMedida.SelectedValue = Convert.ToInt32(dtgProducto.Rows[e.RowIndex].Cells["CODIGO_UNIDAD_MEDIDA"].Value);
            }
        }

        private void limpiaCampos()
        {
            txtCGObsequio.Text = null;
            txtCGVenta.Text = null;
            txtIva.Text = null;
            txtMotivoObsequio.Text = null;
            txtMotivoVenta.Text = null;
            txtNombreProducto.Text = null;
            txtReferencia.Text = null;
            intCodigoProducto = 0;
            cboUnidadMedida.SelectedIndex = 0;
            txtPuntoPremios.Text = null;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiaCampos();
        }

        private void txtPuntoPremios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void frmMaestraProductos_Activated(object sender, EventArgs e)
        {
            txtReferencia.Focus();
        }
    }
}
