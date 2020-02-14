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
    public partial class frmUnidadMedida : Form
    {
        int intCodigoUnidad = 0;
        public frmUnidadMedida()
        {
            InitializeComponent();
        }

        private void frmUnidadMedida_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            dtgTipoUnidadMedida.ReadOnly = true;
            llenaGrilla();
        }
        private void llenaGrilla()
        {
            ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
            var withBlock = dtgTipoUnidadMedida;
            withBlock.DataSource = servicioGeneral.getUnidadMedida(3, 0);
        }

        private bool validaCampos()
        {
            if (txtUnidadMedida.Text == "" | txtUnidadMedida.Text == null)
            {
                MessageBox.Show("Digite el nombre dea Unidad de Medida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (txtNomenclatura.Text == "" | txtNomenclatura.Text == null)
            {
                MessageBox.Show("Digite la abreviatura de la Unidad de Medida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (!rbnActivo.Checked & !rbnInactivo.Checked)
            {
                MessageBox.Show("Seleccione el estado de la Unidad de Medida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
                return true;
        }

        private void limpiaCampos()
        {
            txtNomenclatura.Text = null;
            txtUnidadMedida.Text = null;
            rbnActivo.Checked = false;
            rbnInactivo.Checked = false;
            intCodigoUnidad = 0;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiaCampos();
        }

        private void dtgTipoUnidadMedida_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                intCodigoUnidad = Convert.ToInt32(dtgTipoUnidadMedida.Rows[e.RowIndex].Cells["CODIGO"].Value);
                txtUnidadMedida.Text = Convert.ToString(dtgTipoUnidadMedida.Rows[e.RowIndex].Cells["NOMBRE"].Value);
                txtNomenclatura.Text = Convert.ToString(dtgTipoUnidadMedida.Rows[e.RowIndex].Cells["ABREVIATURA"].Value);
                if (Convert.ToString(dtgTipoUnidadMedida.Rows[e.RowIndex].Cells["ESTADO"].Value) == "ACTIVO")
                {
                    rbnActivo.Checked = true;
                    rbnInactivo.Checked = false;
                }
                else if (Convert.ToString(dtgTipoUnidadMedida.Rows[e.RowIndex].Cells["ESTADO"].Value) == "INACTIVO")
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
                UnidadMedida UnidadMedida = new UnidadMedida();
                ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
                if (rbnActivo.Checked)
                {
                    UnidadMedida.ESTADO = true;
                }
                else if (rbnInactivo.Checked)
                {
                    UnidadMedida.ESTADO = false;
                }
                UnidadMedida.CODIGO = intCodigoUnidad;
                UnidadMedida.NOMBRE = txtUnidadMedida.Text.ToUpper();
                UnidadMedida.ABREVIATURA = txtNomenclatura.Text.ToUpper();

                strResultado = Convert.ToString(servicioGeneral.insUnidadMedida(UnidadMedida));
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
