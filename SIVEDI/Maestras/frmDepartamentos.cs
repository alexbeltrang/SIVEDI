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
    public partial class frmDepartamentos : Form
    {
        int intCodigoDepto;
        public frmDepartamentos()
        {
            InitializeComponent();
        }

        private void frmDepartamentos_Load(object sender, EventArgs e)
        {
            dtgDepartamentos.ReadOnly = true;
            cargaCombos();
            if (clsConnection.blnDepartamentosdesdePais)
            {
                llenaGrilla(clsConnection.intCodigoPais);
                cboPais.Enabled = false;
                cboPais.SelectedValue = clsConnection.intCodigoPais;
            }
            else
            {
                cboPais.Enabled = true;
            }
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
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
            var withBlock = dtgDepartamentos;
            withBlock.DataSource = servicioGeneral.getDepartamentos(3, intCodigoPais, 0);
        }

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPais.SelectedIndex > 0)
            {
                llenaGrilla(Convert.ToInt32(cboPais.SelectedValue));
            }
        }

        private bool validaCampos()
        {
            if (cboPais.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione un país para asignar el Departamento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (txtNombreDepto.Text == "" | txtNombreDepto.Text == null )
            {
                MessageBox.Show("Digite el nombre del Departamento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (txtCodigoDaneDepto.Text == "" | txtCodigoDaneDepto.Text == null )
            {
                MessageBox.Show("Digite el código DANE del Departamento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (!rbnActivo.Checked & !rbnInactivo.Checked)
            {
                MessageBox.Show("Seleccione el estado del Departamento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
                return true;
        }
        private void limpiaCampos()
        {
            txtCodigoDaneDepto.Text = null;
            txtNombreDepto.Text = null;
            rbnActivo.Checked = false;
            rbnInactivo.Checked = false;
            intCodigoDepto = 0;
        }

        private void dtgDepartamentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                intCodigoDepto = Convert.ToInt32(dtgDepartamentos.Rows[e.RowIndex].Cells["CODIGO"].Value);
                txtNombreDepto.Text = Convert.ToString(dtgDepartamentos.Rows[e.RowIndex].Cells["NOMBRE"].Value);
                txtCodigoDaneDepto.Text = Convert.ToString(dtgDepartamentos.Rows[e.RowIndex].Cells["CODIGO_DANE"].Value);
                if (Convert.ToString(dtgDepartamentos.Rows[e.RowIndex].Cells["ESTADO"].Value) == "ACTIVO")
                {
                    rbnActivo.Checked = true;
                    rbnInactivo.Checked = false;
                }
                else if (Convert.ToString(dtgDepartamentos.Rows[e.RowIndex].Cells["ESTADO"].Value) == "INACTIVO")
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

        private void CiudadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection lSeleccionados = this.dtgDepartamentos.SelectedRows;
            switch (lSeleccionados.Count)
            {
                case 0:
                    MessageBox.Show("Debe seleccionar alguna fila", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                case int n when (n > 1):
                    MessageBox.Show("Demasiadas filas seleccionadas", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }
            DataGridViewRow loFila = this.dtgDepartamentos.CurrentRow;
            clsConnection.intCodigoDepto = Convert.ToInt32(loFila.Cells["CODIGO"].Value.ToString());
            clsConnection.blnCiudadesdesdeDepto = true;
            frmCiudades objFormulario = new frmCiudades();
            objFormulario.Show();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                string strResultado;
                Departamentos departamentos = new Departamentos();
                ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
                if (rbnActivo.Checked)
                {
                    departamentos.ESTADO = true;
                }
                else if (rbnInactivo.Checked)
                {
                    departamentos.ESTADO = false;
                }
                departamentos.CODIGO = intCodigoDepto;
                departamentos.NOMBRE = txtNombreDepto.Text.ToUpper();
                departamentos.CODIGO_DANE = txtCodigoDaneDepto.Text.ToUpper();
                departamentos.CODIGO_PAIS = Convert.ToInt32(cboPais.SelectedValue);
                strResultado = Convert.ToString(servicioGeneral.insDepartamento(departamentos));
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
