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
    public partial class frmClaseResponsable : Form
    {
        int intCodigoClase = 0;
        public frmClaseResponsable()
        {
            InitializeComponent();
        }

        private void frmClaseResponsable_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            dtgClases.ReadOnly = true;
            llenaGrilla();
        }

        private void llenaGrilla()
        {
            ServiceClient servicioGeneral = new ServiceClient();
            var withBlock = dtgClases;
            withBlock.DataSource = servicioGeneral.getClaseResponsable(3, 0);
        }

        private bool validaCampos()
        {
            if (txtNombreClaseResponsable.Text == "" | txtNombreClaseResponsable.Text == null )
            {
                MessageBox.Show("Digite el nombre de la Clase de Responsable", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (!rbnActivo.Checked & !rbnInactivo.Checked)
            {
                MessageBox.Show("Seleccione el estado para la Clase de Responsable", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
                return true;
        }
        private void limpiaCampos()
        {
            txtNombreClaseResponsable.Text = null;
            rbnActivo.Checked = false;
            rbnInactivo.Checked = false;
            intCodigoClase = 0;
        }

        private void dtgClases_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                intCodigoClase = Convert.ToInt32(dtgClases.Rows[e.RowIndex].Cells["CODIGO"].Value);
                txtNombreClaseResponsable.Text = Convert.ToString(dtgClases.Rows[e.RowIndex].Cells["NOMBRE"].Value);
                if (Convert.ToString(dtgClases.Rows[e.RowIndex].Cells["ESTADO"].Value) == "ACTIVO")
                {
                    rbnActivo.Checked = true;
                    rbnInactivo.Checked = false;
                }
                else if (Convert.ToString(dtgClases.Rows[e.RowIndex].Cells["ESTADO"].Value) == "INACTIVO")
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
                ClaseResponsable claseResponsable = new ClaseResponsable();
                ServiceClient servicioGeneral = new ServiceClient();
                if (rbnActivo.Checked)
                {
                    claseResponsable.ESTADO = true;
                }
                else if (rbnInactivo.Checked)
                {
                    claseResponsable.ESTADO = false;
                }
                claseResponsable.CODIGO = intCodigoClase;
                claseResponsable.NOMBRE = txtNombreClaseResponsable.Text.ToUpper();

                strResultado = Convert.ToString(servicioGeneral.insClaseResponsable(claseResponsable));
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
