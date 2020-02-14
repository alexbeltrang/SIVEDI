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
    public partial class frmTerritorios : Form
    {
        public frmTerritorios()
        {
            InitializeComponent();
        }

        private void frmTerritorios_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            dtgTerritorio.ReadOnly = true;
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

        private void cargaSecciones()
        {
            if (cboZona.SelectedIndex > 0)
            {
                ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
                var withBlock = cboSeccion;
                withBlock.DataSource = servicioGeneral.getSecciones(1, Convert.ToString(cboZona.SelectedValue), String.Empty);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedIndex = 0;
            }
            else
            {
                var withBlock = cboSeccion;
                withBlock.DataSource = null;
            }
        }

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaRegional();
        }

        private void cboRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargaZona();
        }

        private void cboZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargaSecciones();
        }

        private void llenaGrilla(string strCodigoSeccion)
        {
            ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
            var withBlock = dtgTerritorio;
            withBlock.DataSource = servicioGeneral.getTerritorio(3, strCodigoSeccion, string.Empty);
        }

        private void cboSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboZona.SelectedIndex > 0)
            {
                llenaGrilla(Convert.ToString(cboSeccion.SelectedValue));
            }
            else
            {
                var withBlock = dtgTerritorio;
                withBlock.DataSource = null;
            }
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
            else if (cboSeccion.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione la Sección", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboZona.Focus();
                return false;
            }
            else if (txtCodigoTerritorio.Text == "" | txtCodigoTerritorio.Text == null )
            {
                MessageBox.Show("Digite el código del Territorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtCodigoTerritorio.Focus();
                return false;
            }
            else if (txtNombreTerritorio.Text == "" | txtNombreTerritorio.Text == null )
            {
                MessageBox.Show("Digite el nombre del Territorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtNombreTerritorio.Focus();
                return false;
            }
            else if (!rbnActivo.Checked & !rbnInactivo.Checked)
            {
                MessageBox.Show("Seleccione el estado del Territorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
                return true;
        }

        private void limpiaCampos()
        {
            txtCodigoTerritorio.Text = null;
            txtNombreTerritorio.Text = null;
            rbnActivo.Checked = false;
            rbnInactivo.Checked = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiaCampos();
            cboRegional.SelectedIndex = 0;
        }

        private void dtgTerritorio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCodigoTerritorio.Text = Convert.ToString(dtgTerritorio.Rows[e.RowIndex].Cells["CODIGO"].Value);
                txtNombreTerritorio.Text = Convert.ToString(dtgTerritorio.Rows[e.RowIndex].Cells["NOMBRE"].Value);
                if (Convert.ToString(dtgTerritorio.Rows[e.RowIndex].Cells["ESTADO"].Value) == "ACTIVO")
                {
                    rbnActivo.Checked = true;
                    rbnInactivo.Checked = false;
                }
                else if (Convert.ToString(dtgTerritorio.Rows[e.RowIndex].Cells["ESTADO"].Value) == "INACTIVO")
                {
                    rbnInactivo.Checked = true;
                    rbnActivo.Checked = false;
                }
                else
                {
                    rbnActivo.Checked = true;
                    rbnInactivo.Checked = true;
                }

                ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
                var territorio = servicioGeneral.getTerritorioFiltro(4, Convert.ToString(dtgTerritorio.Rows[e.RowIndex].Cells["CODIGO"].Value));

                //cboPais.SelectedValue = territorio.CODIGO_PAIS;
                //CargaRegional();
                //cboRegional.SelectedValue = territorio.CODIGO_REGIONAL;
                //cargaZona();
                //cboZona.SelectedValue = territorio.CODIGO_ZONA;
                //cargaSecciones();

                //cboSeccion.SelectedValue = territorio.CODIGO;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                string strResultado;
                Territorios territorios = new Territorios();
                ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
                if (rbnActivo.Checked)
                {
                    territorios.ESTADO = true;
                }
                else if (rbnInactivo.Checked)
                {
                    territorios.ESTADO = false;
                }
                territorios.CODIGO = txtCodigoTerritorio.Text;
                territorios.NOMBRE = txtNombreTerritorio.Text.ToUpper();
                territorios.CODIGO_SECCION= Convert.ToString(cboSeccion.SelectedValue);

                strResultado = Convert.ToString(servicioGeneral.insTerritorio(territorios));
                if (Information.IsNumeric(strResultado))
                {
                    llenaGrilla(Convert.ToString(cboSeccion.SelectedValue));
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
