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
    public partial class frmFormasIngreso : Form
    {
        int intCodigoForma;
        public frmFormasIngreso()
        {
            InitializeComponent();
        }

        private void frmFormasIngreso_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            dtgFormaIngreso.ReadOnly = true;
            llenaGrilla();
        }

        private void llenaGrilla()
        {
            ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
            var withBlock = dtgFormaIngreso;
            withBlock.DataSource = servicioGeneral.getformasIngreso(3, 0);
        }

        private bool validaCampos()
        {
            if (txtFormaIngreso.Text == "" | txtFormaIngreso.Text == null )
            {
                MessageBox.Show("Digite el nombre de la Forma de Ingreso", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (!rbnActivo.Checked & !rbnInactivo.Checked)
            {
                MessageBox.Show("Seleccione el estado para la Forma de Ingreso", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
                return true;
        }
        private void limpiaCampos()
        {
            txtFormaIngreso.Text = null;
            rbnActivo.Checked = false;
            rbnInactivo.Checked = false;
            intCodigoForma = 0;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiaCampos();
        }

        private void dtgFormaIngreso_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                intCodigoForma = Convert.ToInt32(dtgFormaIngreso.Rows[e.RowIndex].Cells["CODIGO"].Value);
                txtFormaIngreso.Text = Convert.ToString(dtgFormaIngreso.Rows[e.RowIndex].Cells["NOMBRE"].Value);
                if (Convert.ToString(dtgFormaIngreso.Rows[e.RowIndex].Cells["ESTADO"].Value) == "ACTIVO")
                {
                    rbnActivo.Checked = true;
                    rbnInactivo.Checked = false;
                }
                else if (Convert.ToString(dtgFormaIngreso.Rows[e.RowIndex].Cells["ESTADO"].Value) == "INACTIVO")
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
                formasIngreso formasIngreso = new formasIngreso();
                ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
                if (rbnActivo.Checked)
                {
                    formasIngreso.ESTADO = true;
                }
                else if (rbnInactivo.Checked)
                {
                    formasIngreso.ESTADO = false;
                }
                formasIngreso.CODIGO = intCodigoForma;
                formasIngreso.NOMBRE = txtFormaIngreso.Text.ToUpper();

                strResultado = Convert.ToString(servicioGeneral.insFormasIngreso(formasIngreso));
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
