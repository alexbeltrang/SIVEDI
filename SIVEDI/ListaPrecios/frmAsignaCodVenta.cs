using Microsoft.VisualBasic;
using SIVEDI.Clases;
using SIVEDI.ServicePedidos;
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
    public partial class frmAsignaCodVenta : Form
    {
        int intCodigoVenta;
        int intCodigoProducto;
        ServicePedidosClient ServicePedidos = new ServicePedidosClient();
        public frmAsignaCodVenta()
        {
            InitializeComponent();
        }

        private void frmAsignaCodVenta_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            dtgCodigoVenta.ReadOnly = true;
            intCodigoProducto = clsConnection.intCodigoProducto;
            txtCodigoProducto.Text = clsConnection.strReferenciaProducto;
            txtNombreProducto.Text = clsConnection.strNombreProducto;
            llenaGrilla();
            txtCodigoVenta.Focus();
        }

        private void frmAsignaCodVenta_Activated(object sender, EventArgs e)
        {
            txtCodigoVenta.Focus();
        }

        private void llenaGrilla()
        {
            {
                try
                {
                    var withBlock = dtgCodigoVenta;
                    withBlock.DataSource = ServicePedidos.getCodigoVenta(3, intCodigoProducto);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }
        private bool validaCampos()
        {
            if (txtCodigoVenta.Text == "" | txtCodigoVenta.Text == null )
            {
                MessageBox.Show("Digite el código de venta para el producto " + txtNombreProducto.Text, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (!rdbEsPrincipal.Checked & !rdbNoPrincipal.Checked)
            {
                MessageBox.Show("Seleccione si el código es Principal", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
                return true;
        }

        private void limpiaCampos()
        {
            txtCodigoVenta.Text = null;
            rdbEsPrincipal.Checked = false;
            rdbNoPrincipal.Checked = false;
            rdbActivo.Checked = false;
            rdbInactivo.Checked = false;
            intCodigoVenta = 0;
            txtCodigoVenta.Enabled = true;
        }

        private void dtgCodigoVenta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                intCodigoVenta = Convert.ToInt32(dtgCodigoVenta.Rows[e.RowIndex].Cells["CODIGO"].Value);
                txtCodigoVenta.Text = Convert.ToString(dtgCodigoVenta.Rows[e.RowIndex].Cells["CODIGO_VENTA"].Value);
                if (Convert.ToString(dtgCodigoVenta.Rows[e.RowIndex].Cells["ES_PRINCIPAL"].Value) == "SI")
                {
                    rdbEsPrincipal.Checked = true;
                    rdbNoPrincipal.Checked = false;
                }
                else
                {
                    rdbEsPrincipal.Checked = false;
                    rdbNoPrincipal.Checked = true;
                }
                if (Convert.ToString(dtgCodigoVenta.Rows[e.RowIndex].Cells["ESTADO"].Value) == "ACTIVO")
                {
                    rdbActivo.Checked = true;
                    rdbInactivo.Checked = false;
                }
                else
                {
                    rdbActivo.Checked = false;
                    rdbInactivo.Checked = true;
                }
                txtCodigoVenta.Enabled = false;
            }
        }

        private void EliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strResult;
            int filaSeleccionada = dtgCodigoVenta.SelectedRows[0].Index;
            strResult = ServicePedidos.DelCodigoVenta(Convert.ToInt32(dtgCodigoVenta.Rows[filaSeleccionada].Cells[0].Value)).ToString();
            llenaGrilla();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                CodigoVenta codigoVenta = new CodigoVenta();
                bool blnEstado, blnEsprincipal;
                string strResultado;
                if (rdbActivo.Checked)
                    codigoVenta.ESTADO = true;
                else
                    codigoVenta.ESTADO = false;

                if (rdbEsPrincipal.Checked)
                    codigoVenta.ES_PRINCIPAL = true;
                else
                    codigoVenta.ES_PRINCIPAL = false;
                codigoVenta.CODIGO_PRODUCTO = intCodigoProducto;
                codigoVenta.CODIGO_VENTA = txtCodigoVenta.Text.ToUpper();


                strResultado = Convert.ToString(ServicePedidos.iuCodigoVenta(codigoVenta));
                if (Information.IsNumeric(strResultado))
                {
                    llenaGrilla();
                    limpiaCampos();
                    txtCodigoVenta.Focus();
                }
                else
                {
                    MessageBox.Show(strResultado, "Error al grabar en BD", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }
    }
}
