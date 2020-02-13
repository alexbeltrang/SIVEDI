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
    public partial class frmUsuarios : Form
    {
        clsValidar objValidar = new clsValidar();
        int intUsuario = 0;
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Activated(object sender, EventArgs e)
        {
            txtLogin.Focus();
        }

        private void frmUsuarios_DragEnter(object sender, DragEventArgs e)
        {
            txtLogin.Focus();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            // pnlDatosUsuario.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings("color"))
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            llenaGrilla();
            cargaCombo();
        }

        private void cargaCombo()
        {
            {
                ServiceClient servicioGeneral = new ServiceClient();
                var withBlock = cboPerfil;
                withBlock.DataSource = servicioGeneral.getPerfiles(1, 0);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedValue = 0;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            int I;
            txtEmail.Text = txtEmail.Text.ToLower();
            I = txtEmail.Text.Length;
            txtEmail.SelectionStart = I;
        }
        private void llenaGrilla()
        {
            ServiceClient servicioGeneral = new ServiceClient();
            var withBlock = dtgUsuarios;
            withBlock.DataSource = servicioGeneral.getUsuarios(3, string.Empty);
        }

        private bool validaDatos()
        {
            if (txtLogin.Text == "" | txtLogin.Text == null )
            {
                MessageBox.Show("Digite el login del usuario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtLogin.Focus();
                return false;
            }
            else if ((txtPassword.Text == "" | txtPassword.Text == null) & intUsuario == 0)
            {
                MessageBox.Show("Digite password del usuario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtPassword.Focus();
                return false;
            }
            else if (txtNombres.Text == "" | txtNombres.Text == null )
            {
                MessageBox.Show("Digite los nombres del usuario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtNombres.Focus();
                return false;
            }
            else if (txtApellidos.Text == "" | txtApellidos.Text == null )
            {
                MessageBox.Show("Digite los apellidos del usuario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtApellidos.Focus();
                return false;
            }
            else if (txtEmail.Text == "" | txtEmail.Text == null )
            {
                MessageBox.Show("Digite el Email del usuario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtEmail.Focus();
                return false;
            }
            else if (!objValidar.ValidarEmail(txtEmail.Text))
            {
                MessageBox.Show("El Email digitado ne corresponde una dirección de correo eletrónica valida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtEmail.Focus();
                return false;
            }
            else if (cboPerfil.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione un perfil para el usuario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                cboPerfil.Focus();
                return false;
            }
            else if (!rbnActivo.Checked & !rbnInactivo.Checked)
            {
                MessageBox.Show("Seleccione un estado para el usuario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                rbnActivo.Focus();
                return false;
            }
            else
                return true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiaCampos();
        }
        private void limpiaCampos()
        {
            txtApellidos.Text = null;
            txtNombres.Text = null;
            txtEmail.Text = null;
            txtLogin.Text = null;
            txtPassword.Text = null;
            cboPerfil.SelectedIndex = 0;
            rbnActivo.Checked = false;
            rbnInactivo.Checked = false;
            intUsuario = 0;
            btnGrabar.Enabled = true;
            txtPassword.Enabled = true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validaDatos())
            {
                usuarios UsuarioModel = new usuarios();
                ServiceClient servicioGeneral = new ServiceClient();
                string strResultado;
                if (rbnActivo.Checked)
                {
                    UsuarioModel.ESTADO = true;
                }
                else
                {
                    UsuarioModel.ESTADO = false;
                }
                UsuarioModel.CODIGO = intUsuario;
                UsuarioModel.APELLIDOS = txtApellidos.Text.ToUpperInvariant();
                UsuarioModel.COD_PERFIL = Convert.ToInt32(cboPerfil.SelectedValue);
                UsuarioModel.EMAIL = txtEmail.Text;
                UsuarioModel.LOGIN = txtLogin.Text;
                UsuarioModel.NOMBRES = txtNombres.Text.ToUpperInvariant();
                UsuarioModel.PASSWORD = txtPassword.Text;
                strResultado = Convert.ToString(servicioGeneral.insUsuarios(UsuarioModel));
                if (Information.IsNumeric(strResultado))
                {
                    if (Convert.ToInt32(strResultado) < 0)
                    {
                        MessageBox.Show("Información del usuario actualizada exitosamente", "Actualización Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else if (Convert.ToInt32(strResultado) > 0)
                    {
                        MessageBox.Show("Creación de Usuario realizada exitosamente", "Creación Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    llenaGrilla();
                    limpiaCampos();
                }
                else
                {
                    MessageBox.Show(strResultado, "Error al grabar en BD", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void dtgUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                intUsuario = Convert.ToInt32(dtgUsuarios.Rows[e.RowIndex].Cells["CODIGO"].Value);
                txtApellidos.Text = Convert.ToString(dtgUsuarios.Rows[e.RowIndex].Cells["APELLIDOS"].Value);
                txtNombres.Text = Convert.ToString(dtgUsuarios.Rows[e.RowIndex].Cells["NOMBRES"].Value);
                txtLogin.Text = Convert.ToString(dtgUsuarios.Rows[e.RowIndex].Cells["LOGIN"].Value);
                txtEmail.Text = Convert.ToString(dtgUsuarios.Rows[e.RowIndex].Cells["EMAIL"].Value);
                txtPassword.Enabled = false;
                cboPerfil.SelectedValue = Convert.ToInt32(dtgUsuarios.Rows[e.RowIndex].Cells["COD_PERFIL"].Value);

                if (Convert.ToString(dtgUsuarios.Rows[e.RowIndex].Cells["ESTADODESC"].Value) == "ACTIVO")
                {
                    rbnActivo.Checked = true;
                    rbnInactivo.Checked = false;
                }
                else if (Convert.ToString(dtgUsuarios.Rows[e.RowIndex].Cells["ESTADODESC"].Value) == "INACTIVO")
                {
                    rbnInactivo.Checked = true;
                    rbnActivo.Checked = false;
                }
                else
                {
                    rbnActivo.Checked = false;
                    rbnInactivo.Checked = false;
                }

            }

        }
        private void txtLogin_Leave(object sender, EventArgs e)
        {
            usuarios UsuarioModel = new usuarios();
            ServiceClient servicioGeneral = new ServiceClient();
            var ListUsuarios = servicioGeneral.getUsuarios(2, txtLogin.Text);
            if (ListUsuarios.Count() > 0)
            {
                MessageBox.Show("El login que trata de ingresar ya se encuentra registrado en el sistema", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                btnGrabar.Enabled = false;
                txtLogin.Focus();
            }
            else
            {
                btnGrabar.Enabled = true;
            }
        }
    }
}
