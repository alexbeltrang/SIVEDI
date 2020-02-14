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
    public partial class frmGeneros : Form
    {
        int intCodigoGenero = 0;
        public frmGeneros()
        {
            InitializeComponent();
        }

        private void frmGeneros_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            llenaGrilla();
            dtgGenero.ReadOnly = true;
        }

        private void llenaGrilla()
        {
            ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
            var withBlock = dtgGenero;
            withBlock.DataSource = servicioGeneral.GetGeneros(3, 0);
        }

        private bool validaCampos()
        {
            if (txtGenero.Text == "" | txtGenero.Text == null)
            {
                MessageBox.Show("Digite el nombre género", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (!rbnActivo.Checked & !rbnInactivo.Checked)
            {
                MessageBox.Show("Seleccione el estado para el género", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
                return true;
        }

        private void limpiaCampos()
        {
            txtGenero.Text = null;
            rbnActivo.Checked = false;
            rbnInactivo.Checked = false;
            intCodigoGenero = 0;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiaCampos();
        }

        private void dtgGenero_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                intCodigoGenero = Convert.ToInt32(dtgGenero.Rows[e.RowIndex].Cells["CODIGO"].Value);
                txtGenero.Text = Convert.ToString(dtgGenero.Rows[e.RowIndex].Cells["NOMBRE"].Value);

                if (Convert.ToString(dtgGenero.Rows[e.RowIndex].Cells["ESTADO"].Value) == "ACTIVO")
                {
                    rbnActivo.Checked = true;
                    rbnInactivo.Checked = false;
                }

                else if (Convert.ToString(dtgGenero.Rows[e.RowIndex].Cells["ESTADO"].Value) == "INACTIVO")
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
                Generos generos = new Generos();
                ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
                if (rbnActivo.Checked)
                {
                    generos.ESTADO = true;
                }
                else if (rbnInactivo.Checked)
                {
                    generos.ESTADO = false;
                }
                generos.CODIGO = intCodigoGenero;
                generos.NOMBRE = txtGenero.Text.ToUpper();

                strResultado = Convert.ToString(servicioGeneral.insGeneros(generos));
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
