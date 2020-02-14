using SIVEDI.Clases;
using SIVEDI.ServicioGeneral;
using System;
using System.Windows.Forms;

namespace SIVEDI
{
    public partial class LoginForm : Form
    {
        string strMensaje = string.Empty;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                LoginUsuario loginUsuario = new LoginUsuario();
                ServicioGeneralClient ServicioGeneral = new ServicioGeneralClient();
                loginUsuario = ServicioGeneral.ingresaAplicativo(UsernameTextBox.Text, PasswordTextBox.Text);
                if (loginUsuario != null)
                {
                    if (chkAyudaEnLinea.Checked)
                    {
                        clsConnection.blnAyudaEnlinea = true;
                    }
                    else
                    {
                        clsConnection.blnAyudaEnlinea = false;
                    }
                    if (chkVentanas.Checked)
                    {
                        clsConnection.blnVentanasEnbebidas = true;
                    }
                    else
                    {
                        clsConnection.blnVentanasEnbebidas = false;
                    }
                    if (loginUsuario.intIdUsuario != 0 && loginUsuario.blnEstado)
                    {
                        clsConnection.intIdUsuario = loginUsuario.intIdUsuario;
                        clsConnection.intCodigoPerfil = loginUsuario.intCodigoPerfil;
                        clsConnection.strNombreUsuario = loginUsuario.strNombreUsuario;
                        clsConnection.strEmailUsuario = loginUsuario.strEmailUsuario.ToLower();
                        clsConnection.blnActualizaConexiones = false;
                        trmActualizaConexiones.Stop();
                        this.Visible = false;
                        frmPrincipal frmPrincipal = new frmPrincipal();
                        frmPrincipal.Show();
                    }
                    else if (!loginUsuario.blnEstado)
                    {
                        strMensaje = "El usuario " + UsernameTextBox.Text + " está INACTIVO, contacte al administrador del Sistema";
                        MessageBox.Show(strMensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    strMensaje = "Usuario o Password inválidos";
                    MessageBox.Show(strMensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private bool validaCampos()
        {
            if (UsernameTextBox.Text == "" | UsernameTextBox.Text == null )
            {
                strMensaje = "Digite el " + UsernameLabel.Text;
                MessageBox.Show(strMensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (PasswordTextBox.Text == "" | PasswordTextBox.Text == null )
            {
                strMensaje = "Digite la " + PasswordLabel.Text;
                MessageBox.Show(strMensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
                return true;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
