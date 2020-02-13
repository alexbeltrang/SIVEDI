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
    public partial class frmTipoDocumento : Form
    {
        int intCodigotipo = 0;
        public frmTipoDocumento()
        {
            InitializeComponent();
        }

        private void frmTipoDocumento_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            dtgTipoDocumento.ReadOnly = true;
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            llenaGrilla();
        }
        private void llenaGrilla()
        {
            ServiceClient servicioGeneral = new ServiceClient();
            var withBlock = dtgTipoDocumento;
            withBlock.DataSource = servicioGeneral.getTiposDocumento(3, 0);
        }
        private bool validaCampos()
        {
            if (txtTipoDocumento.Text == "" | txtTipoDocumento.Text == null)
            {
                MessageBox.Show("Digite el nombre del tipo de documento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (!rbnActivo.Checked & !rbnInactivo.Checked)
            {
                MessageBox.Show("Seleccione el estado del tipo de Documento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
                return true;
        }

        private void limpiaCampos()
        {
            txtTipoDocumento.Text = null;
            rbnActivo.Checked = false;
            rbnInactivo.Checked = false;
            intCodigotipo = 0;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiaCampos();
        }

        private void dtgTipoDocumento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                intCodigotipo = Convert.ToInt32(dtgTipoDocumento.Rows[e.RowIndex].Cells["CODIGO"].Value);
                txtTipoDocumento.Text = Convert.ToString(dtgTipoDocumento.Rows[e.RowIndex].Cells["NOMBRE"].Value);

                if (Convert.ToString(dtgTipoDocumento.Rows[e.RowIndex].Cells["ESTADODESC"].Value) == "ACTIVO")
                {
                    rbnActivo.Checked = true;
                    rbnInactivo.Checked = false;
                }
                else if (Convert.ToString(dtgTipoDocumento.Rows[e.RowIndex].Cells["ESTADODESC"].Value) == "INACTIVO")
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
                TipoDocumento tipoDocumento = new TipoDocumento();
                ServiceClient servicioGeneral = new ServiceClient();
                if (rbnActivo.Checked)
                {
                    tipoDocumento.ESTADO = true;
                }
                else if (rbnInactivo.Checked)
                {
                    tipoDocumento.ESTADO = false;
                }
                tipoDocumento.CODIGO = intCodigotipo;
                tipoDocumento.NOMBRE = txtTipoDocumento.Text.ToUpper();
                strResultado = Convert.ToString(servicioGeneral.insTipoDocumento(tipoDocumento));
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
                    MessageBox.Show(strResultado, "Error al grabar en BD", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }
    }
}
