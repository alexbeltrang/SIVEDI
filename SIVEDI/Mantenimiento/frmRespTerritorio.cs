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
    public partial class frmRespTerritorio : Form
    {
        int intCodigoResponsable = 0;
        clsValidar objValidar = new clsValidar();
        public frmRespTerritorio()
        {
            InitializeComponent();
        }

        private void frmRespTerritorio_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            dtgResponsables.ReadOnly = true;
            cargaCombos();
            llenaGrilla();
        }
        private void cargaCombos()
        {
            ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
            var withBlock = cboPais;
            withBlock.DataSource = servicioGeneral.getPaises(1, 0);
            withBlock.ValueMember = "CODIGO";
            withBlock.DisplayMember = "NOMBRE";
            withBlock.SelectedValue = 0;


            var withBlockClaseResponsable = cboClaseResponsable;
            withBlockClaseResponsable.DataSource = servicioGeneral.getClaseResponsable(1, 0);
            withBlockClaseResponsable.ValueMember = "CODIGO";
            withBlockClaseResponsable.DisplayMember = "NOMBRE";
            withBlockClaseResponsable.SelectedValue = 0;


        }
        private void llenaGrilla()
        {
            ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
            var withBlock = dtgResponsables;
            withBlock.DataSource = servicioGeneral.getResponsableTerritorio(2);
        }

        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPais.SelectedIndex > 0)
            {
                cargaDepto();
            }
        }

        private void cargaDepto()
        {
            ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
            var withBlock = cboDepto;
            withBlock.DataSource = servicioGeneral.getDepartamentos(1, Convert.ToInt32(cboPais.SelectedValue), 0);
            withBlock.ValueMember = "CODIGO";
            withBlock.DisplayMember = "NOMBRE";
            withBlock.SelectedValue = 0;
        }

        private void cboDepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepto.SelectedIndex > 0)
            {
                cargaCiudad();
            }
        }

        private void cargaCiudad()
        {
            ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
            var withBlock = cboCiudad;
            withBlock.DataSource = servicioGeneral.getCiudades(1, Convert.ToInt32(cboDepto.SelectedValue), 0);
            withBlock.ValueMember = "CODIGO";
            withBlock.DisplayMember = "NOMBRE";
            withBlock.SelectedValue = 0;
        }


        private bool validaCampos()
        {
            if (txtIdentificacion.Text == "" | txtIdentificacion.Text == null)
            {
                MessageBox.Show("Digite el número de identificación del Responsable", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtIdentificacion.Focus();
                return false;
            }
            else if (txtNombreResponsable.Text == "" | txtNombreResponsable.Text == null)
            {
                MessageBox.Show("Digite nombres y apellidos del Responsable", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtNombreResponsable.Focus();
                return false;
            }
            else if (txtNombrePila.Text == "" | txtNombrePila.Text == null)
            {
                MessageBox.Show("Digite nombres de pila del Responsable", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtNombrePila.Focus();
                return false;
            }
            else if ((txtEmail.Text != "" | txtEmail.Text != null) & !objValidar.ValidarEmail(txtEmail.Text))
            {
                MessageBox.Show("Digite una direccion de correo electrónico valida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtEmail.Focus();
                return false;
            }
            else if (cboClaseResponsable.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione la clase de Responsable", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboClaseResponsable.Focus();
                return false;
            }
            else if (cboPais.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione país", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboPais.Focus();
                return false;
            }
            else if (cboDepto.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione departamento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboDepto.Focus();
                return false;
            }
            else if (cboCiudad.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione ciudad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboDepto.Focus();
                return false;
            }
            else if (!rbnActivo.Checked & !rbnInactivo.Checked)
            {
                MessageBox.Show("Seleccione el estado del Responsable", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
                return true;
        }

        private void limpiaCampos()
        {
            txtBarrio.Text = null;
            txtDireccion.Text = null;
            txtEmail.Text = null;
            txtIdentificacion.Text = null;
            txtNombrePila.Text = null;
            txtNombreResponsable.Text = null;
            txtTelefonoCelular.Text = null;
            txtTelefonoFijo.Text = null;
            cboCiudad.SelectedIndex = 0;
            cboDepto.SelectedIndex = 0;
            cboPais.SelectedIndex = 0;
            cboClaseResponsable.SelectedIndex = 0;
            intCodigoResponsable = 0;
            rbnActivo.Checked = false;
            rbnInactivo.Checked = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiaCampos();
        }

        private void dtgResponsables_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();

                intCodigoResponsable = Convert.ToInt32(dtgResponsables.Rows[e.RowIndex].Cells["CODIGO"].Value);
                txtBarrio.Text = Convert.ToString(dtgResponsables.Rows[e.RowIndex].Cells["BARRIO"].Value);
                txtDireccion.Text = Convert.ToString(dtgResponsables.Rows[e.RowIndex].Cells["DIRECCION"].Value);
                txtEmail.Text = Convert.ToString(dtgResponsables.Rows[e.RowIndex].Cells["EMAIL"].Value);
                txtIdentificacion.Text = Convert.ToString(dtgResponsables.Rows[e.RowIndex].Cells["IDENTIFICACION"].Value);
                txtNombrePila.Text = Convert.ToString(dtgResponsables.Rows[e.RowIndex].Cells["NOMBRE_PILA"].Value);
                txtNombreResponsable.Text = Convert.ToString(dtgResponsables.Rows[e.RowIndex].Cells["NOMBRE"].Value);
                txtTelefonoCelular.Text = Convert.ToString(dtgResponsables.Rows[e.RowIndex].Cells["TELEFONO_CELULAR"].Value);
                txtTelefonoFijo.Text = Convert.ToString(dtgResponsables.Rows[e.RowIndex].Cells["TELEFONO_FIJO"].Value);
                cboClaseResponsable.SelectedValue = Convert.ToInt32(dtgResponsables.Rows[e.RowIndex].Cells["COD_CLR"].Value);
                var ciudad = servicioGeneral.getCiudadesTabla(5, 0, Convert.ToInt32(dtgResponsables.Rows[e.RowIndex].Cells["COD_CIU"].Value));
                if (ciudad.CODIGO > 0)
                {
                    cboPais.SelectedValue = ciudad.CODIGO_PAIS;
                    cargaDepto();
                    cboDepto.SelectedValue = ciudad.CODIGO_DEPARTAMENTO;
                    cargaCiudad();
                    cboCiudad.SelectedValue = Convert.ToInt32(dtgResponsables.Rows[e.RowIndex].Cells["COD_CIU"].Value);
                }

                if (Convert.ToString(dtgResponsables.Rows[e.RowIndex].Cells["ESTADO"].Value) == "ACTIVO")
                {
                    rbnActivo.Checked = true;
                    rbnInactivo.Checked = false;
                }
                else if (Convert.ToString(dtgResponsables.Rows[e.RowIndex].Cells["ESTADO"].Value) == "INACTIVO")
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
                ResponsableTerritorio responsableTerritorio = new ResponsableTerritorio();
                ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
                if (rbnActivo.Checked)
                {
                    responsableTerritorio.ESTADO = true;
                }
                else if (rbnInactivo.Checked)
                {
                    responsableTerritorio.ESTADO = false;
                }
                responsableTerritorio.BARRIO = txtBarrio.Text.ToUpper();
                responsableTerritorio.COD_CIU = Convert.ToInt32(cboCiudad.SelectedValue);
                responsableTerritorio.COD_CLR = Convert.ToInt32(cboClaseResponsable.SelectedValue);
                responsableTerritorio.DIRECCION = txtDireccion.Text.ToUpper();
                responsableTerritorio.EMAIL = txtEmail.Text.ToLower();
                responsableTerritorio.IDENTIFICACION = txtIdentificacion.Text.ToUpper();
                responsableTerritorio.NOMBRE_PILA = txtNombrePila.Text.ToUpper();
                responsableTerritorio.CODIGO = intCodigoResponsable;
                responsableTerritorio.NOMBRE = txtNombreResponsable.Text.ToUpper();
                responsableTerritorio.TELEFONO_CELULAR = txtTelefonoCelular.Text.ToUpper();
                responsableTerritorio.TELEFONO_FIJO = txtTelefonoFijo.Text.ToUpper();
                strResultado = Convert.ToString(servicioGeneral.insResponsableTerritorio(responsableTerritorio));
                
                if (Information.IsNumeric(strResultado))
                {
                    llenaGrilla();
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
