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
    public partial class frmSecciones : Form
    {
        public static int? intCodigoResponsableSeccion;
        public static string strNombreResponsableSeccion;
        public frmSecciones()
        {
            InitializeComponent();
        }

        private void frmSecciones_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            dtgSecciones.ReadOnly = true;
            cargaCombos();
        }

        private void txtResponsableSeccion_MouseClick(object sender, MouseEventArgs e)
        {
            tmrUpdResponsable.Start();
            clsConnection.blnbuscaRespDesdeSec = true;
            frmBusquedaResponsable frmBusquedaResponsable = new frmBusquedaResponsable();
            frmBusquedaResponsable.Show();
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

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaRegional();
        }

        private void CargaRegional()
        {
            if (cboPais.SelectedIndex > 0)
            {
                ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
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
            cargaZona();
        }

        private void cargaZona()
        {
            if (cboRegional.SelectedIndex > 0)
            {
                ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
                var withBlock = cboZona;
                withBlock.DataSource = servicioGeneral.getZonas(1, Convert.ToString(cboRegional.SelectedValue), String.Empty);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedIndex = 0;
            }
            else
            {
                var withBlock = cboZona;
                withBlock.DataSource = null;
            }
        }

        private void cboZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboZona.SelectedIndex > 0)
            {
                llenaGrilla(Convert.ToString(cboZona.SelectedValue));
            }
            else
            {
                var withBlock = dtgSecciones;
                withBlock.DataSource = null;
            }
        }

        private void llenaGrilla(string strCodigoZona)
        {
            ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
            var withBlock = dtgSecciones;
            withBlock.DataSource = servicioGeneral.getSecciones(3, strCodigoZona, string.Empty);
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
            else if (cboZona.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione la Zona", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboZona.Focus();
                return false;
            }
            else if (txtCodigoSeccion.Text == "" | txtCodigoSeccion.Text == null)
            {
                MessageBox.Show("Digite el código de la Sección", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtCodigoSeccion.Focus();
                return false;
            }
            else if (txtNombreSeccion.Text == "" | txtNombreSeccion.Text == null)
            {
                MessageBox.Show("Digite el nombre de la Sección", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtNombreSeccion.Focus();
                return false;
            }
            else if (!rbnActivo.Checked & !rbnInactivo.Checked)
            {
                MessageBox.Show("Seleccione el estado de la Sección", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (intCodigoResponsableSeccion == null)
            {
                MessageBox.Show("Seleccione el responsable de la Sección", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtResponsableSeccion.Focus();
                return false;
            }
            else
                return true;
        }

        private void limpiaCampos()
        {
            intCodigoResponsableSeccion = null;
            txtCodigoSeccion.Text = null;
            txtNombreSeccion.Text = null;
            txtResponsableSeccion.Text = null;
            rbnActivo.Checked = false;
            rbnInactivo.Checked = false;
        }

        private void dtgSecciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
                txtCodigoSeccion.Text = Convert.ToString(dtgSecciones.Rows[e.RowIndex].Cells["CODIGO"].Value);
                txtNombreSeccion.Text = Convert.ToString(dtgSecciones.Rows[e.RowIndex].Cells["NOMBRE"].Value);
                txtResponsableSeccion.Text = Convert.ToString(dtgSecciones.Rows[e.RowIndex].Cells["RESPONSABLE"].Value);
                intCodigoResponsableSeccion = Convert.ToInt32(dtgSecciones.Rows[e.RowIndex].Cells["CODIGO_RESPONSABLE"].Value);
                //var seccion = servicioGeneral.getSeccionFiltro(4, Convert.ToString(dtgSecciones.Rows[e.RowIndex].Cells["CODIGO"].Value));
                //cboPais.SelectedValue = seccion.CODIGO_PAIS;
                //CargaRegional();
                //cboRegional.SelectedValue = seccion.CODIGO_REGIONAL;
                //cargaZona();
                //cboZona.SelectedValue = seccion.CODIGO;
                if (Convert.ToString(dtgSecciones.Rows[e.RowIndex].Cells["ESTADO"].Value) == "ACTIVO")
                {
                    rbnActivo.Checked = true;
                    rbnInactivo.Checked = false;
                }
                else if (Convert.ToString(dtgSecciones.Rows[e.RowIndex].Cells["ESTADO"].Value) == "INACTIVO")
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
            cboZona.DataSource = null;

        }

        private void tmrUpdResponsable_Tick(object sender, EventArgs e)
        {
            if (strNombreResponsableSeccion != null && strNombreResponsableSeccion != string.Empty)
            {
                txtResponsableSeccion.Text = strNombreResponsableSeccion;
                strNombreResponsableSeccion = string.Empty;
                tmrUpdResponsable.Stop();
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                string strResultado;
                Secciones secciones = new Secciones();
                ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
                if (rbnActivo.Checked)
                {
                    secciones.ESTADO = true;
                }
                else if (rbnInactivo.Checked)
                {
                    secciones.ESTADO = false;
                }
                secciones.CODIGO = txtCodigoSeccion.Text;
                secciones.NOMBRE = txtNombreSeccion.Text.ToUpper();
                secciones.CODIGO_ZONA= Convert.ToString(cboZona.SelectedValue);
                secciones.CODIGO_RESPONSABLE = Convert.ToInt32(intCodigoResponsableSeccion);

                strResultado = Convert.ToString(servicioGeneral.insSecciones(secciones));
                if (Information.IsNumeric(strResultado))
                {
                    llenaGrilla(Convert.ToString(cboZona.SelectedValue));
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
