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
    public partial class frmRegiones : Form
    {
        public static string intCodigoResponsable;
        public static string strNombreResponsable;
        public frmRegiones()
        {
            InitializeComponent();
        }

        private void frmRegiones_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            dtgRegionales.ReadOnly = true;
            cargaCombos();
        }
        private void cargaCombos()
        {
            ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
            var withBlock = cboPais;
            withBlock.DataSource = servicioGeneral.getPaises(1, 0);
            withBlock.ValueMember = "CODIGO";
            withBlock.DisplayMember = "NOMBRE";
            withBlock.SelectedValue = 0;
        }
        private void llenaGrilla(int intCodigoPais)
        {
            ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
            var withBlock = dtgRegionales;
            withBlock.DataSource = servicioGeneral.getRegionales(3, 0, intCodigoPais);
        }
        private void txtResponsableRegion_MouseClick(object sender, MouseEventArgs e)
        {
            tmrUpdResponsable.Start();
            clsConnection.blnbuscaRespDesdeReg = true;
            frmBusquedaResponsable frmBusquedaResponsable = new frmBusquedaResponsable();
            frmBusquedaResponsable.Show();
        }
        private void limpiaCampos()
        {
            intCodigoResponsable = null;
            txtCodigoRegional.Text = null;
            txtGrupoFacturacion.Text = null;
            txtNombreRegional.Text = null;
            txtResponsableRegion.Text = null;
            rbnActivo.Checked = false;
            rbnInactivo.Checked = false;
        }
        private bool validaCampos()
        {
            if (txtNombreRegional.Text == "" | txtNombreRegional.Text == null )
            {
                MessageBox.Show("Digite el nombre de la Regional", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtNombreRegional.Focus();
                return false;
            }
            else if (txtGrupoFacturacion.Text == "" | txtGrupoFacturacion.Text == null )
            {
                MessageBox.Show("Digite el número  del Grupo de facturación al que pertenece la Regional", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtGrupoFacturacion.Focus();
                return false;
            }
            else if (!rbnActivo.Checked & !rbnInactivo.Checked)
            {
                MessageBox.Show("Seleccione el estado de la Regional", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (cboPais.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione el país al que pertenece la Regional", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboPais.Focus();
                return false;
            }
            else if (intCodigoResponsable == null )
            {
                MessageBox.Show("Seleccione el responsable de la Regional", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtNombreRegional.Focus();
                return false;
            }
            else
                return true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiaCampos();
        }

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPais.SelectedIndex > 0)
            {
                llenaGrilla(Convert.ToInt32(cboPais.SelectedValue));
            }
            else
            {
                dtgRegionales.DataSource = null;
            }
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

        private void tmrUpdResponsable_Tick(object sender, EventArgs e)
        {
            if (strNombreResponsable != null && strNombreResponsable != string.Empty)
            {
                txtResponsableRegion.Text = strNombreResponsable;
                strNombreResponsable = string.Empty;
                tmrUpdResponsable.Stop();
            }
        }

        private void dtgRegionales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCodigoRegional.Text = Convert.ToString(dtgRegionales.Rows[e.RowIndex].Cells["CODIGO"].Value);
                txtGrupoFacturacion.Text = Convert.ToString(dtgRegionales.Rows[e.RowIndex].Cells["GRUPO_FACTURACION"].Value);
                txtNombreRegional.Text = Convert.ToString(dtgRegionales.Rows[e.RowIndex].Cells["NOMBRE"].Value);
                txtResponsableRegion.Text = Convert.ToString(dtgRegionales.Rows[e.RowIndex].Cells["RESPONSABLE"].Value);
                intCodigoResponsable = Convert.ToString(dtgRegionales.Rows[e.RowIndex].Cells["CODIGO_RESPONSABLE"].Value);
                cboPais.SelectedValue = Convert.ToInt32(dtgRegionales.Rows[e.RowIndex].Cells["CODIGO_PAIS"].Value);
                if (Convert.ToString(dtgRegionales.Rows[e.RowIndex].Cells["ESTADO"].Value) == "ACTIVO")
                {
                    rbnActivo.Checked = true;
                    rbnInactivo.Checked = false;
                }
                else if (Convert.ToString(dtgRegionales.Rows[e.RowIndex].Cells["ESTADO"].Value) == "INACTIVO")
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

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                string strResultado;
                Regionales regionales = new Regionales();
                ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
                if (rbnActivo.Checked)
                {
                    regionales.ESTADO = true;
                }
                else if (rbnInactivo.Checked)
                {
                    regionales.ESTADO = false;
                }
                regionales.CODIGO = txtCodigoRegional.Text;
                regionales.NOMBRE = txtNombreRegional.Text.ToUpper();
                regionales.CODIGO_PAIS = Convert.ToInt32(cboPais.SelectedValue);
                regionales.CODIGO_RESPONSABLE = Convert.ToInt32(intCodigoResponsable);
                regionales.GRUPO_FACTURACION =Convert.ToInt32(txtGrupoFacturacion.Text);
                
                strResultado = Convert.ToString(servicioGeneral.insRegionales(regionales));
                if (Information.IsNumeric(strResultado))
                {
                    llenaGrilla(Convert.ToInt32(cboPais.SelectedValue));
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
