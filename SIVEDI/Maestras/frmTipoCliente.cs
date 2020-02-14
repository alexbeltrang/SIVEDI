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
    public partial class frmTipoCliente : Form
    {
        int intCodigotipo = 0;
        public frmTipoCliente()
        {
            InitializeComponent();
        }

        private void frmTipoCliente_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            dtgTipoCliente.ReadOnly = true;
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            llenaGrilla();
        }

        private void llenaGrilla()
        {
            {
                ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
                var withBlock = dtgTipoCliente;
                withBlock.DataSource = servicioGeneral.getTipoCliente(3, 0);
            }
        }

        private bool validaCampos()
        {
            if (txtTipoCliente.Text == "" | txtTipoCliente.Text == null)
            {
                MessageBox.Show("Digite el nombre del tipo de Cliente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (!rbnSiCobraFlete.Checked & !rbnNoCobraFlete.Checked)
            {
                MessageBox.Show("Seleccione si tipo de Cliente se cobra o no flete", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (!rbnActivo.Checked & !rbnInactivo.Checked)
            {
                MessageBox.Show("Seleccione el estado del tipo de Cliente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
                return true;
        }
        private void limpiaCampos()
        {
            txtTipoCliente.Text = null;
            rbnActivo.Checked = false;
            rbnInactivo.Checked = false;
            rbnSiCobraFlete.Checked = false;
            rbnNoCobraFlete.Checked = false;
            intCodigotipo = 0;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiaCampos();
        }

        private void dtgTipoCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                intCodigotipo = Convert.ToInt32(dtgTipoCliente.Rows[e.RowIndex].Cells["CODIGO"].Value);
                txtTipoCliente.Text = Convert.ToString(dtgTipoCliente.Rows[e.RowIndex].Cells["NOMBRE"].Value);

                if (Convert.ToString(dtgTipoCliente.Rows[e.RowIndex].Cells["ESTADO"].Value) == "ACTIVO")
                {
                    rbnActivo.Checked = true;
                    rbnInactivo.Checked = false;
                }
                else if (Convert.ToString(dtgTipoCliente.Rows[e.RowIndex].Cells["ESTADO"].Value) == "INACTIVO")
                {
                    rbnInactivo.Checked = true;
                    rbnActivo.Checked = false;
                }
                else
                {
                    rbnActivo.Checked = false;
                    rbnInactivo.Checked = false;
                }

                if (Convert.ToString(dtgTipoCliente.Rows[e.RowIndex].Cells["COBRA_FLETE"].Value) == "SI")
                {
                    rbnSiCobraFlete.Checked = true;
                    rbnNoCobraFlete.Checked = false;
                }
                else if (Convert.ToString(dtgTipoCliente.Rows[e.RowIndex].Cells["COBRA_FLETE"].Value) == "NO")
                {
                    rbnNoCobraFlete.Checked = true;
                    rbnSiCobraFlete.Checked = false;
                }
                else
                {
                    rbnNoCobraFlete.Checked = false;
                    rbnSiCobraFlete.Checked = false;
                }
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                string strResultado;
                TipoCliente tipoCliente = new TipoCliente();
                ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
                if (rbnActivo.Checked)
                {
                    tipoCliente.ESTADO = true;
                }
                else if (rbnInactivo.Checked)
                {
                    tipoCliente.ESTADO = false;
                }

                if (rbnSiCobraFlete.Checked)
                {
                    tipoCliente.COBRA_FLETE = true;
                }
                else if (rbnNoCobraFlete.Checked)
                {
                    tipoCliente.COBRA_FLETE = false;
                }

                tipoCliente.CODIGO = intCodigotipo;
                tipoCliente.NOMBRE = txtTipoCliente.Text.ToUpper();
                strResultado = Convert.ToString(servicioGeneral.insTipoCliente(tipoCliente));
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
