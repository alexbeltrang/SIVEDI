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
    public partial class frmCiudades : Form
    {
        int intCodigoCiudad = 0;
        public frmCiudades()
        {
            InitializeComponent();
        }

        private void frmCiudades_Load(object sender, EventArgs e)
        {
            ServiceClient servicioGeneral = new ServiceClient();
            dtgCiudades.ReadOnly = true;
            cargaCombos();
            if (clsConnection.blnCiudadesdesdeDepto)
            {
                llenaGrilla(clsConnection.intCodigoDepto);
                cboPais.Enabled = false;
                cboDepto.Enabled = false;

                var depto = servicioGeneral.getDepartamentoTabla(5, 0, clsConnection.intCodigoDepto);
                if (Convert.ToInt32(depto.CODIGO_PAIS) > 0)
                {
                    cboPais.SelectedValue = Convert.ToInt32(depto.CODIGO_PAIS);
                }
                cargaDepto();
                cboDepto.SelectedValue = clsConnection.intCodigoDepto;
            }
            else
            {
                cboPais.Enabled = true;
                cboDepto.Enabled = true;
            }
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

        private void cargaDepto()
        {
            ServiceClient servicioGeneral = new ServiceClient();
            var withBlock = cboDepto;
            withBlock.DataSource = servicioGeneral.getDepartamentos(1, Convert.ToInt32(cboPais.SelectedValue), 0);
            withBlock.ValueMember = "CODIGO";
            withBlock.DisplayMember = "NOMBRE";
            withBlock.SelectedValue = 0;

        }

        private void llenaGrilla(int intCodigoDepartamento)
        {
            ServiceClient servicioGeneral = new ServiceClient();
            var withBlock = dtgCiudades;
            withBlock.DataSource = servicioGeneral.getCiudades(3, intCodigoDepartamento, 0);
        }

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPais.SelectedIndex > 0)
            {
                cargaDepto();
            }
        }

        private void cboDepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepto.SelectedIndex > 0)
            {
                llenaGrilla(Convert.ToInt32(cboDepto.SelectedValue));
            }
        }

        private bool validaCampos()
        {
            if (cboPais.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione un país", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (cboDepto.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione un Departamento para asignar a la Ciudad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (txtNombreCiudad.Text == "" | txtNombreCiudad.Text == null )
            {
                MessageBox.Show("Digite el nombre de la Ciudad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (txtCodigoDaneCiudad.Text == "" | txtCodigoDaneCiudad.Text == null )
            {
                MessageBox.Show("Digite el código DANE de la Ciudad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (!rbnActivo.Checked & !rbnInactivo.Checked)
            {
                MessageBox.Show("Seleccione el estado de la Ciudad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
                return true;
        }
        private void limpiaCampos()
        {
            txtCodigoDaneCiudad.Text = null;
            txtNombreCiudad.Text = null;
            rbnActivo.Checked = false;
            rbnInactivo.Checked = false;
            intCodigoCiudad = 0;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiaCampos();
        }

        private void dtgCiudades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                intCodigoCiudad = Convert.ToInt32(dtgCiudades.Rows[e.RowIndex].Cells["CODIGO"].Value);
                txtNombreCiudad.Text = Convert.ToString(dtgCiudades.Rows[e.RowIndex].Cells["NOMBRE"].Value);
                txtCodigoDaneCiudad.Text = Convert.ToString(dtgCiudades.Rows[e.RowIndex].Cells["CODIGO_DANE"].Value);
                if (Convert.ToString(dtgCiudades.Rows[e.RowIndex].Cells["ESTADO"].Value) == "ACTIVO")
                {
                    rbnActivo.Checked = true;
                    rbnInactivo.Checked = false;
                }
                else if (Convert.ToString(dtgCiudades.Rows[e.RowIndex].Cells["ESTADO"].Value) == "INACTIVO")
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
                Ciudades ciudades = new Ciudades();
                ServiceClient servicioGeneral = new ServiceClient();
                if (rbnActivo.Checked)
                {
                    ciudades.ESTADO = true;
                }
                else if (rbnInactivo.Checked)
                {
                    ciudades.ESTADO = false;
                }
                ciudades.CODIGO = intCodigoCiudad;
                ciudades.NOMBRE = txtNombreCiudad.Text.ToUpper();
                ciudades.CODIGO_DANE = txtCodigoDaneCiudad.Text.ToUpper();
                ciudades.CODIGO_DEPARTAMENTO= Convert.ToInt32(cboDepto.SelectedValue);
                strResultado = Convert.ToString(servicioGeneral.insCiudades(ciudades));
                if (Information.IsNumeric(strResultado))
                {
                    llenaGrilla(Convert.ToInt32(cboDepto.SelectedValue));
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
