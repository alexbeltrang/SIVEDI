using Microsoft.VisualBasic;
using SIVEDI.Clases;
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
    public partial class frmListaPrecios : Form
    {
        ServicePedidosClient ServicePedidos = new ServicePedidosClient();
        ServicioGeneralClient ServicioGeneral = new ServicioGeneralClient();
        int intCodigoLista = 0;
        public frmListaPrecios()
        {
            InitializeComponent();
        }

        private void frmListaPrecios_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            dtgListaPrecios.ReadOnly = true;
            CargaCombo();
            llenaGrilla();
            txtCodigoLista.Focus();
        }

        private void CargaCombo()
        {
            {
                var withBlock = cboCampaña;
                withBlock.DataSource = ServicioGeneral.getCampanas(1, 0);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedValue = 0;
            }
        }

        private void llenaGrilla()
        {
            {
                var withBlock = dtgListaPrecios;
                withBlock.DataSource = ServicePedidos.getListaPreciosTabla(3, 0);
            }
        }

        private bool validaCampos()
        {
            if (txtCodigoLista.Text == "" | txtCodigoLista.Text == null)
            {
                MessageBox.Show("Digite el código de la lista de precios", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtCodigoLista.Focus();
                return false;
            }
            else if (txtNombreLista.Text == "" | txtNombreLista.Text == null)
            {
                MessageBox.Show("Digite el nombre de la lista de precios", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtNombreLista.Focus();
                return false;
            }
            else if (cboCampaña.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione la campaña de la lista de precios", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboCampaña.Focus();
                return false;
            }
            else if (!rdbSiEstandar.Checked & !rdbNoEstandar.Checked)
            {
                MessageBox.Show("Seleccione si la lista de precios es estandar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                rbnActivo.Focus();
                return false;
            }
            else if (!rbnActivo.Checked & !rbnInactivo.Checked)
            {
                MessageBox.Show("Seleccione un estado para la Lista de Precios", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                rbnActivo.Focus();
                return false;
            }
            else
                return true;
        }

        private void limpiaCampos()
        {
            txtCodigoLista.Text = null;
            txtNombreLista.Text = null;
            cboCampaña.SelectedIndex = 0;
            rdbNoEstandar.Checked = false;
            rdbSiEstandar.Checked = false;
            rbnActivo.Checked = false;
            rbnInactivo.Checked = false;
            intCodigoLista = 0;
        }

        private void dtgListaPrecios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                intCodigoLista = Convert.ToInt32(dtgListaPrecios.Rows[e.RowIndex].Cells["CODIGO"].Value);
                txtCodigoLista.Text = Convert.ToString(dtgListaPrecios.Rows[e.RowIndex].Cells["CODIGO_LISTA"].Value);
                txtNombreLista.Text = Convert.ToString(dtgListaPrecios.Rows[e.RowIndex].Cells["NOMBRE"].Value);
                if (Convert.ToString(dtgListaPrecios.Rows[e.RowIndex].Cells["ES_ESTANDAR"].Value) == "SI")
                {
                    rdbSiEstandar.Checked = true;
                    rdbNoEstandar.Checked = false;
                }
                else
                {
                    rdbSiEstandar.Checked = false;
                    rdbNoEstandar.Checked = true;
                }
                if (Convert.ToString(dtgListaPrecios.Rows[e.RowIndex].Cells["ESTADO"].Value) == "ACTIVO")
                {
                    rbnActivo.Checked = true;
                    rbnInactivo.Checked = false;
                }
                else
                {
                    rbnActivo.Checked = false;
                    rbnInactivo.Checked = true;
                }
                cboCampaña.SelectedValue = Convert.ToInt32(dtgListaPrecios.Rows[e.RowIndex].Cells["CODIGO_CAMPANA"].Value);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiaCampos();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                string strResult;
                SIVEDI.Clases.ListaPrecios listaPrecios = new SIVEDI.Clases.ListaPrecios();
                if (rbnActivo.Checked)
                {
                    listaPrecios.ESTADO = true;
                }
                else
                {
                    listaPrecios.ESTADO = false;
                }

                if (rdbSiEstandar.Checked)
                {
                    listaPrecios.ES_ESTANDAR = true;
                }
                else
                {
                    listaPrecios.ES_ESTANDAR = false;
                }
                listaPrecios.CODIGO = intCodigoLista;
                listaPrecios.CODIGO_CAMPANA = Convert.ToInt32(cboCampaña.SelectedValue);
                listaPrecios.CODIGO_LISTA = txtCodigoLista.Text.ToUpper();
                listaPrecios.NOMBRE = txtNombreLista.Text.ToUpper();
                strResult =  Convert.ToString(ServicePedidos.insListaPrecios(listaPrecios));

                if (Information.IsNumeric(strResult))
                {
                    llenaGrilla();
                    limpiaCampos();
                    txtCodigoLista.Focus();
                    if (Convert.ToInt32(strResult) > 0)
                    {
                        MessageBox.Show("Registro creado exitosamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else if (Convert.ToInt32(strResult) == 0)
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
    }
}
