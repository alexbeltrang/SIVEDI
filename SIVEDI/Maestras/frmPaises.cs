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
    public partial class frmPaises : Form
    {
        int intCodigoPais = 0;
        public frmPaises()
        {
            InitializeComponent();
        }

        private void frmPaises_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            dtgPaises.ReadOnly = true;
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            llenaGrilla();
        }
        private void llenaGrilla()
        {
            ServiceClient servicioGeneral = new ServiceClient();
            var withBlock = dtgPaises;
            withBlock.DataSource = servicioGeneral.getPaises(3, 0);
        }

        private bool validaCampos()
        {
            if (txtNombrePais.Text == "" | txtNombrePais.Text == null )
            {
                MessageBox.Show("Digite el nombre del País", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (!rbnActivo.Checked & !rbnInactivo.Checked)
            {
                MessageBox.Show("Seleccione el estado del País", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
                return true;
        }
        private void limpiaCampos()
        {
            txtNombrePais.Text = null;
            txtCodigoUniversal.Text = null;
            rbnActivo.Checked = false;
            rbnInactivo.Checked = false;
            intCodigoPais = 0;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiaCampos();
        }

        private void EditarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection lSeleccionados = this.dtgPaises.SelectedRows;
            switch (lSeleccionados.Count)
            {
                case 0:
                    MessageBox.Show("Debe seleccionar alguna fila", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                case int n when (n > 1):
                    MessageBox.Show("Demasiadas filas seleccionadas", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }
            DataGridViewRow loFila = this.dtgPaises.CurrentRow;
            clsConnection.intCodigoPais = Convert.ToInt32(loFila.Cells["CODIGO"].Value.ToString());
            clsConnection.blnDepartamentosdesdePais = true;
            frmDepartamentos departamentos = new frmDepartamentos();
            departamentos.Show();
        }

        private void dtgPaises_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                intCodigoPais = Convert.ToInt32(dtgPaises.Rows[e.RowIndex].Cells["CODIGO"].Value);
                txtNombrePais.Text = Convert.ToString(dtgPaises.Rows[e.RowIndex].Cells["NOMBRE"].Value);
                txtCodigoUniversal.Text = Convert.ToString(dtgPaises.Rows[e.RowIndex].Cells["CODIGO_UNIVERSAL"].Value);
                if (Convert.ToString(dtgPaises.Rows[e.RowIndex].Cells["ESTADO"].Value) == "ACTIVO")
                {
                    rbnActivo.Checked = true;
                    rbnInactivo.Checked = false;
                }
                else if (Convert.ToString(dtgPaises.Rows[e.RowIndex].Cells["ESTADO"].Value) == "INACTIVO")
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
                Pais pais = new Pais();
                ServiceClient servicioGeneral = new ServiceClient();
                if (rbnActivo.Checked)
                {
                    pais.ESTADO = true;
                }
                else if (rbnInactivo.Checked)
                {
                    pais.ESTADO = false;
                }
                pais.CODIGO = intCodigoPais;
                pais.NOMBRE = txtNombrePais.Text.ToUpper();
                pais.CODIGO_UNIVERSAL = txtCodigoUniversal.Text.ToUpper();
                strResultado = Convert.ToString(servicioGeneral.insPaises(pais));
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
