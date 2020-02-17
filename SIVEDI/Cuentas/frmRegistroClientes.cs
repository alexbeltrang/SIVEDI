using Microsoft.VisualBasic;
using SIVEDI.Clases;
using SIVEDI.Clases.TABLAS;
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

namespace SIVEDI.Cuentas
{
    public partial class frmRegistroClientes : Form
    {
        clsValidar objValidar = new clsValidar();
        List<ReferenciaCliente> ListreferenciaClienteTablas = new List<ReferenciaCliente>();
        decimal intCodigoCliente = 0;
        decimal intCodigoReferente = 0;
        public frmRegistroClientes()
        {
            InitializeComponent();
        }

        private void frmRegistroClientes_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            cargaCombos();
            cargaCupocrditoMinimo();
        }

        private void cargaCombos()
        {
            ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
            {
                var withBlock = cboPais;
                withBlock.DataSource = servicioGeneral.getPaises(1, 0);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedIndex = 0;
            }
            {
                var withBlock = cboTipoDocumento;
                withBlock.DataSource = servicioGeneral.getTiposDocumento(1, 0);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedIndex = 0;
            }
            {
                var withBlock = cboEstadoCivil;
                withBlock.DataSource = servicioGeneral.getEstadoCivil(1, 0);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedIndex = 0;
            }
            {
                var withBlock = cboTipoCliente;
                withBlock.DataSource = servicioGeneral.getTipoCliente(1, 0);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedIndex = 0;
            }
            {
                var withBlock = cboFormaPago;
                withBlock.DataSource = servicioGeneral.getFormaPago(1, 0);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedIndex = 0;
            }
            {
                var withBlock = cboCampanavinculacion;
                withBlock.DataSource = servicioGeneral.getCampanas(1, 0);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedIndex = 0;
            }
            {
                var withBlock = cboFormaIngreso;
                withBlock.DataSource = servicioGeneral.getformasIngreso(1, 0);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedIndex = 0;
            }
            {
                var withBlock = cboTipoReferencia;
                withBlock.DataSource = servicioGeneral.getTipoReferencia(1, 0);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedIndex = 0;
            }
            {
                var withBlock = cboGenero;
                withBlock.DataSource = servicioGeneral.GetGeneros(1, 0);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedIndex = 0;
            }
        }

        private void cargaCupocrditoMinimo()
        {
            ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
            CupoMinimo cupoMinimo = servicioGeneral.getCupoMinimoCredito();
            txtCupoAsignado.Text = cupoMinimo.CUPO_MINIMO.ToString();
        }

        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
                return;
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                validaExistecliente();
            }
        }



        private void validaExistecliente()
        {
            ServicioGeneralClient serviceClient = new ServicioGeneralClient();
            var datosCliente = serviceClient.getConsultaCliente(txtIdentificacion.Text);
            if (datosCliente != null)
            {
                MessageBox.Show("El número de identificación que está ingresando ya existe en el sistema", "Cuenta Existente", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtIdentificacion.Focus();
                foreach (Control control in this.Controls)
                {
                    if (control.Name != "Panel1")
                    {
                        control.Enabled = false;
                    }
                    foreach (Control Control in control.Controls)
                    {
                        if (Control.Name == "txtIdentificacion")
                        {
                            Control.Enabled = true;
                        }
                        else if (Control.Name == "txtNombreReferente")
                        {
                            Control.Enabled = false;
                        }
                        else
                        {
                            Control.Enabled = false;
                        }
                    }
                }
            }
            else
            {
                foreach (Control control in this.Controls)
                {
                    control.Enabled = true;
                    foreach (Control Control in control.Controls)
                    {
                        if (Control.Name == "txtNombreReferente")
                        {
                            Control.Enabled = false;
                        }
                        else
                        {
                            Control.Enabled = true;
                        }
                    }
                }
                cboTipoDocumento.Focus();
            }
        }

        private void txtEstrato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtTelefonoFijo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtTelefonoCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtTelefonoOficina_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCupoAsignado_KeyPress(object sender, KeyPressEventArgs e)
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
                CargaRegional();
                cargaDepto();
            }

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

        private void cargaDepto()
        {
            ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
            var withBlock = cboDepto;
            withBlock.DataSource = servicioGeneral.getDepartamentos(1, Convert.ToInt32(cboPais.SelectedValue), 0);
            withBlock.ValueMember = "CODIGO";
            withBlock.DisplayMember = "NOMBRE";
            withBlock.SelectedValue = 0;

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

        private void cboDepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepto.SelectedIndex > 0)
            {
                cargaCiudad();
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

        private void cboRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargaZona();
        }

        private void cboZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargaSecciones();
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

        private void btnAdicionareferencia_Click(object sender, EventArgs e)
        {

            ReferenciaCliente referenciaCliente = new ReferenciaCliente();
            referenciaCliente.CODIGO_TIPO_REFERENCIA = Convert.ToInt32(cboTipoReferencia.SelectedValue);
            referenciaCliente.TIPO_REFERENCIA = cboTipoReferencia.Text;
            referenciaCliente.NOMBRE = txtNombreReferencia.Text.ToUpper();
            referenciaCliente.DIRECCION = txtDireccionreferencia.Text.ToUpper();
            referenciaCliente.TEL_FIJO = txtTelefonoFijoRef.Text;
            referenciaCliente.TEL_CELULAR = txtTelefonoCelularRef.Text;
            referenciaCliente.CIUDAD = txtCiudadReferencia.Text.ToUpper();
            referenciaCliente.PARENTESCO = txtParentesco.Text.ToUpper();
            ListreferenciaClienteTablas.Add(referenciaCliente);
            llenarGrillaReferencias();
            limpiaCamposReferencias();
        }

        private void llenarGrillaReferencias()
        {
            dtgReferencias.DataSource = null;
            dtgReferencias.DataSource = ListreferenciaClienteTablas;
        }
        private void limpiaCamposReferencias()
        {
            cboTipoReferencia.SelectedIndex = 0;
            txtNombreReferencia.Text = null;
            txtDireccionreferencia.Text = null;
            txtTelefonoFijoRef.Text = null;
            txtTelefonoCelularRef.Text = null;
            txtCiudadReferencia.Text = null;
            txtParentesco.Text = null;
        }

        private void dtgReferencias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                cboTipoReferencia.SelectedValue = Convert.ToInt32(dtgReferencias.Rows[e.RowIndex].Cells["CODIGO_TIPO_REFERENCIA"].Value);
                txtNombreReferencia.Text = Convert.ToString(dtgReferencias.Rows[e.RowIndex].Cells["NOMBRE"].Value);
                txtDireccionreferencia.Text = Convert.ToString(dtgReferencias.Rows[e.RowIndex].Cells["DIRECCION"].Value);
                txtTelefonoFijoRef.Text = Convert.ToString(dtgReferencias.Rows[e.RowIndex].Cells["TEL_FIJO"].Value);
                txtTelefonoCelularRef.Text = Convert.ToString(dtgReferencias.Rows[e.RowIndex].Cells["TEL_CELULAR"].Value);
                txtCiudadReferencia.Text = Convert.ToString(dtgReferencias.Rows[e.RowIndex].Cells["CIUDAD"].Value);
                txtParentesco.Text = Convert.ToString(dtgReferencias.Rows[e.RowIndex].Cells["PARENTESCO"].Value);
                dtgReferencias.DataSource = null;
                ListreferenciaClienteTablas.RemoveAt(e.RowIndex);
                llenarGrillaReferencias();
            }
        }

        private bool validaCamposreferencia()
        {
            if (cboTipoReferencia.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione el tipo de Referencia", "Tipo Referencia", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboTipoReferencia.Focus();
                return false;
            }
            else if (txtNombreReferencia.Text == "" | txtNombreReferencia.Text == null)
            {
                MessageBox.Show("Ingrese el Nombre de la Referencia", "Nombre Referencia", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtNombreReferencia.Focus();
                return false;
            }
            else if (txtDireccionreferencia.Text == "" | txtDireccionreferencia.Text == null)
            {
                MessageBox.Show("Ingrese la dirección de la Referencia, si no registra digite NO REGISTRA", "Dirección Referencia", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtDireccionreferencia.Focus();
                return false;
            }
            else if (txtTelefonoFijoRef.Text == "" | txtTelefonoFijoRef.Text == null)
            {
                MessageBox.Show("Ingrese el teléfono fijo de la Referencia, si no registra digite 0 (cero)", "Teléfono Fijo Referencia", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtTelefonoFijoRef.Focus();
                return false;
            }
            else if (txtTelefonoCelularRef.Text == "" | txtTelefonoCelularRef.Text == null)
            {
                MessageBox.Show("Ingrese el teléfono celular de la Referencia, si no registra digite 0 (cero)", "Teléfono Celular Referencia", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtTelefonoCelularRef.Focus();
                return false;
            }
            else if ((txtTelefonoCelularRef.Text == "" | txtTelefonoCelularRef.Text == null | txtTelefonoCelularRef.Text == "0") & (txtTelefonoFijoRef.Text == "" | txtTelefonoFijoRef.Text == null | txtTelefonoFijoRef.Text == "0"))
            {
                MessageBox.Show("Ingrese uno de los dos número telefónicos de la Referencia (Fijo o Celular)", "Número Telefónicos Referencia", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtTelefonoFijoRef.Focus();
                return false;
            }
            else if (txtCiudadReferencia.Text == "" | txtCiudadReferencia.Text == null)
            {
                MessageBox.Show("Ingrese el nombre de la ciudad de residencia de la Referencia", "Ciudad Residencia Referencia", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtCiudadReferencia.Focus();
                return false;
            }
            else if (txtParentesco.Text == "" | txtParentesco.Text == null)
            {
                MessageBox.Show("Ingrese el parentesco de la Referencia", "Parentesco Referencia", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtParentesco.Focus();
                return false;
            }
            else
                return true;
        }

        private void txtTelefonoFijoRef_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtTelefonoCelularRef_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private bool validaCamposCliente()
        {
            if (txtIdentificacion.Text == "" | txtIdentificacion.Text == null)
            {
                MessageBox.Show("Ingrese el Número de identificación de la cuenta", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtIdentificacion.Focus();
                return false;
            }
            else if (cboTipoDocumento.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione tipo de documento", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboTipoDocumento.Focus();
                return false;
            }
            else if (txtPrimerNombreCliente.Text == "" | txtPrimerNombreCliente.Text == null)
            {
                MessageBox.Show("Ingrese el primer nombre de la cuenta", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtPrimerNombreCliente.Focus();
                return false;
            }
            else if (txtPrimerApellido.Text == "" | txtPrimerApellido.Text == null)
            {
                MessageBox.Show("Ingrese el primer Apellido de la cuenta", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtPrimerApellido.Focus();
                return false;
            }
            else if (dtpFechaNacimiento.Value.Date.Year == 1900)
            {
                MessageBox.Show("Seleccione la fecha de nacimiento, o ingresela manualmente en formato DD/MM/YYYY", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                dtpFechaNacimiento.Focus();
                return false;
            }
            else if (cboEstadoCivil.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione el estado Civil", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboEstadoCivil.Focus();
                return false;
            }
            else if (cboTipoCliente.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione el tipo de cliente", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboEstadoCivil.Focus();
                return false;
            }
            else if (cboGenero.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione el Genero de la cuenta", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboGenero.Focus();
                return false;
            }
            else if (txtEmailcliente.Text != null & !objValidar.ValidarEmail(txtEmailcliente.Text))
            {
                MessageBox.Show("Ingrese una cuenta de correo electrónico válida", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtEmailcliente.Focus();
                return false;
            }
            else if (txtDireccionDomicilio.Text == "" | txtDireccionDomicilio.Text == null)
            {
                MessageBox.Show("Ingrese la dirección de domicilio", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtDireccionDomicilio.Focus();
                return false;
            }
            else if (txtDireccionEntrega.Text == "" | txtDireccionEntrega.Text == null)
            {
                MessageBox.Show("Ingrese la dirección de entrega", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtDireccionEntrega.Focus();
                return false;
            }
            else if (txtEstrato.Text == "" | txtEstrato.Text == null)
            {
                MessageBox.Show("Ingrese el estrato socioeconómico", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtEstrato.Focus();
                return false;
            }
            else if (txtTelefonoFijo.Text == "" | txtTelefonoFijo.Text == null)
            {
                MessageBox.Show("Ingrese el Número telefónico fijo de la cuenta", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtTelefonoFijo.Focus();
                return false;
            }
            else if (txtTelefonoCelular.Text == "" | txtTelefonoCelular.Text == null)
            {
                MessageBox.Show("Ingrese el Número telefónico celular de la cuenta", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtTelefonoCelular.Focus();
                return false;
            }
            else if (txtCupoAsignado.Text == "" | txtCupoAsignado.Text == null)
            {
                MessageBox.Show("Ingrese el cupo asignado", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtTelefonoCelular.Focus();
                return false;
            }
            else if (cboFormaPago.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione la forma de pago que la cuenta va a tener asignada", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboFormaPago.Focus();
                return false;
            }
            else if (!rbnEsLider.Checked & !rbnNoesLider.Checked)
            {
                MessageBox.Show("Seleccione si la cuenta es Lider", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (!rbnNoCabezaGrupo.Checked & !rbnSiCabezaGrupo.Checked)
            {
                MessageBox.Show("Seleccione si la cuenta es cabeza de grupo", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (dtpFechaVinculacion.Value.Date.Year == 1900)
            {
                MessageBox.Show("Seleccione la fecha de vinculación, o ingresela manuelamente en formato DD/MM/YYYY", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (cboCampanavinculacion.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione la campaña de vinculación", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboCampanavinculacion.Focus();
                return false;
            }
            else if (cboFormaIngreso.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione la forma de ingreso de la cuenta", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboFormaIngreso.Focus();
                return false;
            }
            else if (cboPais.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione País", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboPais.Focus();
                return false;
            }
            else if (cboDepto.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione Departamento", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboDepto.Focus();
                return false;
            }
            else if (cboCiudad.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione Ciudad", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboCiudad.Focus();
                return false;
            }
            else if (cboRegional.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione la regional a la cual pertenece la cuenta", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboRegional.Focus();
                return false;
            }
            else if (cboZona.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione la zona a la cual pertenece la cuenta", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboZona.Focus();
                return false;
            }
            else if (cboSeccion.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione la seccion a la cual pertenece la cuenta", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboSeccion.Focus();
                return false;
            }
            else if (dtgReferencias.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar las referencias de la Cuenta", "Validación Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboTipoReferencia.Focus();
                return false;
            }
            else
                return true;
        }

        private void txtIdentificacion_Leave(object sender, EventArgs e)
        {
            validaExistecliente();
        }

        private void txtDireccionDomicilio_Leave(object sender, EventArgs e)
        {
            txtDireccionEntrega.Text = txtDireccionDomicilio.Text;
        }

        private void limpiacampos()
        {
            intCodigoCliente = 0;
            intCodigoReferente = 0;
            txtCiudadReferencia.Text = null;
            txtCupoAsignado.Text = null;
            txtDireccionDomicilio.Text = null;
            txtDireccionEntrega.Text = null;
            txtDireccionreferencia.Text = null;
            txtEmailcliente.Text = null;
            txtEstrato.Text = null;
            txtIdentificacion.Text = null;
            txtNombreReferencia.Text = null;
            txtNombreReferente.Text = null;
            txtParentesco.Text = null;
            txtPrimerApellido.Text = null;
            txtPrimerNombreCliente.Text = null;
            txtProfesion.Text = null;
            txtReferidoPor.Text = null;
            txtSegundoApellido.Text = null;
            txtSegundoNombre.Text = null;
            txtTelefonoCelular.Text = null;
            txtTelefonoCelularRef.Text = null;
            txtTelefonoFijo.Text = null;
            txtTelefonoFijoRef.Text = null;
            txtTelefonoOficina.Text = null;
            cboCampanavinculacion.SelectedIndex = 0;
            cboCiudad.SelectedIndex = 0;
            cboDepto.SelectedIndex = 0;
            cboEstadoCivil.SelectedIndex = 0;
            cboFormaIngreso.SelectedIndex = 0;
            cboFormaPago.SelectedIndex = 0;
            cboGenero.SelectedIndex = 0;
            cboPais.SelectedIndex = 0;
            cboRegional.SelectedIndex = 0;
            cboTipoCliente.SelectedIndex = 0;
            cboTipoDocumento.SelectedIndex = 0;
            cboTipoReferencia.SelectedIndex = 0;
            {
                var withBlock = dtgReferencias;
                withBlock.DataSource = null;
            }
        }

        private void txtReferidoPor_Leave(object sender, EventArgs e)
        {
            if (txtReferidoPor.Text != string.Empty || txtReferidoPor.Text != null)
            {

                ServicioGeneralClient serviceClient = new ServicioGeneralClient();
                var datosCliente = serviceClient.getConsultaCliente(txtReferidoPor.Text);
                if (datosCliente != null)
                {
                    txtNombreReferente.Text = Convert.ToString(datosCliente.NOMBRE);
                    intCodigoReferente = datosCliente.CODIGO;
                }
                else
                {
                    MessageBox.Show("Identificación del referente no existe en la base de datos, digite nuevamente", "Referente no existe", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    txtReferidoPor.Text = string.Empty;
                    txtNombreReferente.Text = string.Empty;
                }
            }
            else
            {
                txtReferidoPor.Text = string.Empty;
                txtNombreReferente.Text = string.Empty;
            }
        }

        private void cboTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoCliente.SelectedIndex > 0)
            {
                ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
                var tipoCliente = servicioGeneral.getTipoClienteTabla(4, Convert.ToInt32(cboTipoCliente.SelectedValue));
                if (tipoCliente.COBRA_FLETE)
                {
                    rbnNoCobraFlete.Checked = false;
                    rbnSiCobraflete.Checked = true;
                }
                else
                {
                    rbnNoCobraFlete.Checked = true;
                    rbnSiCobraflete.Checked = false;
                }
            }
        }

        private void btnGrabarcliente_Click(object sender, EventArgs e)
        {
            if (validaCamposCliente())
            {
                int intCodigoEstadoActividad = 0;
                ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
                string strResultado;
                Cliente cliente = new Cliente();
                if (rbnEsLider.Checked)
                {
                    cliente.LIDER = true;
                }
                else
                {
                    cliente.LIDER = false;
                }

                if (rbnSiCabezaGrupo.Checked)
                {
                    cliente.CABEZA_GRUPO = true;
                }
                else
                {
                    cliente.CABEZA_GRUPO = false;
                }
                if (rbnSiCobraflete.Checked)
                {
                    cliente.COBRA_FLETE = true;
                }
                else
                {
                    cliente.COBRA_FLETE = false;
                }
                if (rdbEsIngreso.Checked)
                {
                    cliente.ESINGRESO = true;
                }
                else
                {
                    cliente.ESINGRESO = false;
                }
                var estadoActividad = servicioGeneral.getEstadoActividad(5, 0);
                intCodigoEstadoActividad = estadoActividad.FirstOrDefault().CODIGO;

                cliente.CODIGO = intCodigoCliente;
                cliente.CAM_NID_INGRESO = Convert.ToInt32(cboCampanavinculacion.SelectedValue);
                cliente.CIU_NID = Convert.ToInt32(cboCiudad.SelectedValue);
                cliente.CUPO_CREDITO = Convert.ToInt32(txtCupoAsignado.Text);
                cliente.DEP_NID = Convert.ToInt32(cboDepto.SelectedValue);
                cliente.DIRECCION_DOMICILIO = txtDireccionDomicilio.Text.ToUpper();
                cliente.DIRECCION_ENTREGA = txtDireccionEntrega.Text.ToUpper();
                cliente.ECV_NID = Convert.ToInt32(cboEstadoCivil.SelectedValue);
                cliente.EMAIL = txtEmailcliente.Text.ToLower();
                cliente.ESA_NID = intCodigoEstadoActividad;
                cliente.ESTRATO = txtEstrato.Text;
                cliente.FECHA_NACIMIENTO = Convert.ToDateTime(dtpFechaNacimiento.Value);
                cliente.FECHA_VINCULACION = Convert.ToDateTime(dtpFechaVinculacion.Value);
                cliente.FIN_NID = Convert.ToInt32(cboFormaIngreso.SelectedValue);
                cliente.FORMA_PAGO = Convert.ToString(cboFormaPago.SelectedText).ToUpper();
                cliente.FPG_NID = Convert.ToInt32(cboFormaPago.SelectedValue);
                cliente.GEN_NID = Convert.ToInt32(cboGenero.SelectedValue);
                cliente.ID_REFERIDO_POR = intCodigoReferente;
                cliente.NUMERO_IDENTIFICACION = txtIdentificacion.Text;
                cliente.PAI_NID = Convert.ToInt32(cboPais.SelectedValue);
                cliente.PRIMER_APELLIDO = txtPrimerApellido.Text.ToUpper();
                cliente.PRIMER_NOMBRE = txtPrimerNombreCliente.Text.ToUpper();
                cliente.PROFESION = txtProfesion.Text.ToUpper();
                cliente.REG_CID = Convert.ToString(cboRegional.SelectedValue);
                cliente.SEC_CID = Convert.ToString(cboSeccion.SelectedValue);
                cliente.SEGUNDO_APELLIDO = txtSegundoApellido.Text.ToUpper();
                cliente.SEGUNDO_NOMBRE = txtSegundoNombre.Text.ToUpper();
                cliente.TDO_NID = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                cliente.TELEFONO_CELULAR = txtTelefonoCelular.Text;
                cliente.TELEFONO_FIJO = txtTelefonoFijo.Text;
                cliente.TELEFONO_OFICINA = txtTelefonoOficina.Text;
                cliente.ZON_CID = Convert.ToString(cboZona.SelectedValue);
                cliente.RAZON_BLOQUEO = string.Empty;
                cliente.TER_CID = "0";
                cliente.TIC_NID = Convert.ToInt32(cboTipoCliente.SelectedValue);
                strResultado = Convert.ToString(servicioGeneral.insCliente(cliente));
                if (Information.IsNumeric(strResultado))
                {
                    foreach (ReferenciaCliente referencia in ListreferenciaClienteTablas)
                    {
                        referencia.CODIGO_CLIENTE = Convert.ToInt32(strResultado);
                        servicioGeneral.insReferenciasCliente(referencia);
                    }
                    limpiacampos();
                    if (Convert.ToInt32(strResultado) > 0)
                    {
                        MessageBox.Show("Registro creado exitosamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else if (Convert.ToInt32(strResultado) == -1)
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
