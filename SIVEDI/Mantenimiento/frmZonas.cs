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

namespace SIVEDI.Mantenimiento
{
    public partial class frmZonas : Form
    {
        public static int? intCodigoResponsableZona;
        public static string strNombreResponsableZona;
        public frmZonas()
        {
            InitializeComponent();
        }

        private void frmZonas_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            dtgZonas.ReadOnly = true;
            cargaCombos();
        }

        private void cargaCombos()
        {
            ServiceClient servicioGeneral = new ServiceClient();
            var withBlock = cboPais;
            withBlock.DataSource = servicioGeneral.getPaises(1, 0);
            withBlock.ValueMember = "CODIGO";
            withBlock.DisplayMember = "NOMBRE";
            withBlock.SelectedValue = 0;
        }

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPais.SelectedIndex > 0)
            {
                ServiceClient servicioGeneral = new ServiceClient();
                var withBlock = cboRegional;
                withBlock.DataSource = servicioGeneral.getRegionales(1, 0, Convert.ToInt32(cboPais.SelectedValue));
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedIndex = 0;
            }
            else
            {
                var withBlock = cboRegional;
                withBlock.DataSource = null;
            }
        }

        private void cboRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRegional.SelectedIndex > 0)
            {
                llenaGrilla(Convert.ToString(cboRegional.SelectedValue));
            }
            else
            {
                var withBlock = dtgZonas;
                withBlock.DataSource = null;
            }
        }

        private void llenaGrilla(string strCodigoRegional)
        {
            ServiceClient servicioGeneral = new ServiceClient();
            var withBlock = dtgZonas;
            withBlock.DataSource = servicioGeneral.getZonas(3, strCodigoRegional, string.Empty);
        }
        private bool validaCampos()
        {
            if (cboPais.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione el País", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboPais.Focus();
                return false;
            }
            else if (cboRegional.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione la Regional", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboRegional.Focus();
                return false;
            }
            else if (txtCodigoZona.Text == "" | txtCodigoZona.Text == null)
            {
                MessageBox.Show("Digite el código de la Zona", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtCodigoZona.Focus();
                return false;
            }
            else if (txtNombreZona.Text == "" | txtNombreZona.Text == null)
            {
                MessageBox.Show("Digite el nombre de la Zona", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtNombreZona.Focus();
                return false;
            }
            else if (txtGrupoFacturacion.Text == "" | txtGrupoFacturacion.Text == null)
            {
                MessageBox.Show("Digite el número de grupo de Facturación al que pertenece la Zona", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtGrupoFacturacion.Focus();
                return false;
            }
            else if (!rbnActivo.Checked & !rbnInactivo.Checked)
            {
                MessageBox.Show("Seleccione el estado de la Zona", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (intCodigoResponsableZona == null)
            {
                MessageBox.Show("Seleccione el responsable de la Zona", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtResponsableZona.Focus();
                return false;
            }
            else
                return true;
        }
        private void limpiaCampos()
        {
            intCodigoResponsableZona = null;
            txtCodigoZona.Text = null;
            txtGrupoFacturacion.Text = null;
            txtNombreZona.Text = null;
            txtResponsableZona.Text = null;
            rbnActivo.Checked = false;
            rbnInactivo.Checked = false;
        }

        private void txtGrupoFacturacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void dtgZonas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCodigoZona.Text = Convert.ToString(dtgZonas.Rows[e.RowIndex].Cells["CODIGO"].Value);
                txtGrupoFacturacion.Text = Convert.ToString(dtgZonas.Rows[e.RowIndex].Cells["GRUPO_FACTURACION"].Value);
                txtNombreZona.Text = Convert.ToString(dtgZonas.Rows[e.RowIndex].Cells["NOMBRE"].Value);
                txtResponsableZona.Text = Convert.ToString(dtgZonas.Rows[e.RowIndex].Cells["RESPONSABLE"].Value);
                intCodigoResponsableZona = Convert.ToInt32(dtgZonas.Rows[e.RowIndex].Cells["CODIGO_RESPONSABLE"].Value);
                cboRegional.SelectedValue = Convert.ToString(dtgZonas.Rows[e.RowIndex].Cells["CODIGO_REGIONAL"].Value);
                if (Convert.ToString(dtgZonas.Rows[e.RowIndex].Cells["ESTADO"].Value) == "ACTIVO")
                {
                    rbnActivo.Checked = true;
                    rbnInactivo.Checked = false;
                }
                else if (Convert.ToString(dtgZonas.Rows[e.RowIndex].Cells["ESTADO"].Value) == "INACTIVO")
                {
                    rbnInactivo.Checked = true;
                    rbnActivo.Checked = false;
                }
                else
                {
                    rbnActivo.Checked = true;
                    rbnInactivo.Checked = true;
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiaCampos();
            cboRegional.SelectedIndex = 0;
        }

        private void tmrUpdResponsable_Tick(object sender, EventArgs e)
        {
            if (strNombreResponsableZona != null && strNombreResponsableZona != string.Empty)
            {
                txtResponsableZona.Text = strNombreResponsableZona;
                strNombreResponsableZona = string.Empty;
                tmrUpdResponsable.Stop();
            }
        }

        private void txtResponsableZona_MouseClick(object sender, MouseEventArgs e)
        {
            tmrUpdResponsable.Start();
            clsConnection.blnbuscaRespDesdeZon = true;
            frmBusquedaResponsable frmBusquedaResponsable = new frmBusquedaResponsable();
            frmBusquedaResponsable.Show();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                string strResultado;
                Zonas zonas = new Zonas();
                ServiceClient servicioGeneral = new ServiceClient();
                if (rbnActivo.Checked)
                {
                    zonas.ESTADO = true;
                }
                else if (rbnInactivo.Checked)
                {
                    zonas.ESTADO = false;
                }
                zonas.CODIGO = txtCodigoZona.Text;
                zonas.NOMBRE = txtNombreZona.Text.ToUpper();
                zonas.CODIGO_REGIONAL = Convert.ToString(cboRegional.SelectedValue);
                zonas.CODIGO_RESPONSABLE = Convert.ToInt32(intCodigoResponsableZona);
                zonas.GRUPO_FACTURACION = Convert.ToInt32(txtGrupoFacturacion.Text);

                strResultado = Convert.ToString(servicioGeneral.insZonas(zonas));
                if (Information.IsNumeric(strResultado))
                {
                    llenaGrilla(Convert.ToString(cboRegional.SelectedValue));
                    limpiaCampos();
                    if (Convert.ToInt32(strResultado) == 1)
                    {
                        MessageBox.Show("Registro creado exitosamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else if (Convert.ToInt32(strResultado) == 2)
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
