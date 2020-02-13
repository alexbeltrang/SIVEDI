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
    public partial class frmCampanas : Form
    {
        int intCodigoCampana = 0;
        public frmCampanas()
        {
            InitializeComponent();
        }

        private void frmCampanas_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            dtgCampanas.ReadOnly = true;
            llenaGrilla();
        }

        private void llenaGrilla()
        {
            ServiceClient servicioGeneral = new ServiceClient();
            var withBlock = dtgCampanas;
            withBlock.DataSource = servicioGeneral.getCampanas(3, 0);
        }

        private bool validaCampos()
        {
            if (txtCampana.Text == "" | txtCampana.Text == null )
            {
                MessageBox.Show("Digite el nombre largo de la campaña", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (txtNivel.Text == "" | txtNivel.Text == null )
            {
                MessageBox.Show("Digite el nombre corto de la campaña, recuerde que el campo es numérico", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (!rbnActivo.Checked & !rbnInactivo.Checked)
            {
                MessageBox.Show("Seleccione el estado para la Campaña", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
                return true;
        }
        private void limpiaCampos()
        {
            txtCampana.Text = null;
            txtNivel.Text = null;
            dtpFechaFinal.Value = DateTime.Now;
            dtpFechaInicio.Value = DateTime.Now;
            rbnActivo.Checked = false;
            rbnInactivo.Checked = false;
            intCodigoCampana = 0;
        }

        private void txtNivel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void dtgCampanas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                intCodigoCampana = Convert.ToInt32(dtgCampanas.Rows[e.RowIndex].Cells["CODIGO"].Value);
                txtCampana.Text = Convert.ToString(dtgCampanas.Rows[e.RowIndex].Cells["NOMBRE"].Value);
                txtNivel.Text = Convert.ToString(dtgCampanas.Rows[e.RowIndex].Cells["NIVEL"].Value);
                dtpFechaInicio.Value = Convert.ToDateTime(dtgCampanas.Rows[e.RowIndex].Cells["FECHA_INICIAL"].Value);
                dtpFechaFinal.Value = Convert.ToDateTime(dtgCampanas.Rows[e.RowIndex].Cells["FECHA_FINAL"].Value);

                if (Convert.ToString(dtgCampanas.Rows[e.RowIndex].Cells["ESTADO"].Value) == "ACTIVO")
                {
                    rbnActivo.Checked = true;
                    rbnInactivo.Checked = false;
                }
                else if (Convert.ToString(dtgCampanas.Rows[e.RowIndex].Cells["ESTADO"].Value) == "INACTIVO")
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiaCampos();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                string strResultado;
                campanas Campanas = new campanas();
                ServiceClient servicioGeneral = new ServiceClient();

                if (rbnActivo.Checked)
                {
                    Campanas.ESTADO = true;
                }
                else if (rbnInactivo.Checked)
                {
                    Campanas.ESTADO = false;
                }
                Campanas.NOMBRE = txtCampana.Text.ToUpper();
                Campanas.FECHA_INICIAL = dtpFechaInicio.Value.Date;
                Campanas.FECHA_FINAL = dtpFechaFinal.Value.Date;
                Campanas.NIVEL = Convert.ToInt32(txtNivel.Text);
                Campanas.CODIGO = intCodigoCampana;
                strResultado = Convert.ToString(servicioGeneral.insCampanas(Campanas));

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
