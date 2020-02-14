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

namespace SIVEDI.Administracion
{
    public partial class frmPerfiles : Form
    {
        int intCodigoPerfil;
        bool blnEstado;

        public frmPerfiles()
        {
            InitializeComponent();
        }

        private void frmPerfiles_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            llenaGrilla();
        }

        private void llenaGrilla()
        {
            ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
            dtgPerfiles.DataSource = servicioGeneral.getPerfiles(2, 0);
        }

        private bool validaCampos()
        {
            if (txtNombrePerfil.Text == "" | txtNombrePerfil.Text == null )
            {
                MessageBox.Show("Digite el nombre del perfil", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (!rbnActivo.Checked & !rbnInactivo.Checked)
            {
                MessageBox.Show("Seleccione el estado del perfil", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
                return true;
        }
        private void limpiaCampos()
        {
            txtNombrePerfil.Text = null;
            rbnActivo.Checked = false;
            rbnInactivo.Checked = false;
            intCodigoPerfil = 0;
        }

        private void dtgPerfiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                intCodigoPerfil = Convert.ToInt32(dtgPerfiles.Rows[e.RowIndex].Cells["CODIGO"].Value);
                txtNombrePerfil.Text = Convert.ToString(dtgPerfiles.Rows[e.RowIndex].Cells["NOMBRE"].Value);
                if (Convert.ToString(dtgPerfiles.Rows[e.RowIndex].Cells["ESTADODESC"].Value) == "ACTIVO")
                {
                    rbnActivo.Checked = true;
                    rbnInactivo.Checked = false;
                }
                else if (Convert.ToString(dtgPerfiles.Rows[e.RowIndex].Cells["ESTADODESC"].Value) == "INACTIVO")
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
                ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
                int strResultado;
                int intOpcion = 0;
                if (rbnActivo.Checked)
                {
                    blnEstado = true;
                }
                else if (rbnInactivo.Checked)
                {
                    blnEstado = false;
                }
                perfiles perfil = new perfiles();
                perfil.CODIGO = intCodigoPerfil;
                perfil.ESTADO = blnEstado;
                perfil.NOMBRE = txtNombrePerfil.Text.ToUpper();
                intOpcion = intCodigoPerfil > 0 ? 2 : 1;

                strResultado = servicioGeneral.insPerfiles(intOpcion, perfil);

                if (Information.IsNumeric(strResultado))
                {
                    if (Convert.ToInt32(strResultado) == 1)
                    {
                        MessageBox.Show("Registro creado exitosamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        limpiaCampos();
                        llenaGrilla();
                    }
                    else if (Convert.ToInt32(strResultado) == 2)
                    {
                        MessageBox.Show("Registro Actualizado exitosamente", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        limpiaCampos();
                        llenaGrilla();
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
