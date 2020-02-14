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

namespace SIVEDI.Indicadores
{
    public partial class frmMaestraEsatdosActividad : Form
    {
        bool blnActualiza;
        string strMensaje;
        int intCodigoEstado = 0;
        public frmMaestraEsatdosActividad()
        {
            InitializeComponent();
        }

        private void frmMaestraEsatdosActividad_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            dtgEstadosActividad.ReadOnly = true;
            CargaCombos();
            txtNroPedidoInac.Text = "0";
            txtNroCampanasInac.Text = "0";
            blnActualiza = false;
            rbnSiInactiva.Checked = false;
            rbnNoInactiva.Checked = true;
            rdbEsVinculacion.Checked = false;
            rdbNoVinculacion.Checked = true;
        }

        private void CargaCombos()
        {
            ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();


            var withBlock = cboEstadoNoPasaPedido;
            withBlock.DataSource = servicioGeneral.getEstadoActividad(1, 0);
            withBlock.ValueMember = "CODIGO";
            withBlock.DisplayMember = "NOMBRE";
            withBlock.SelectedIndex = 0;

            var withBlockSupera = cboEstadoSuperaCampana;
            withBlockSupera.DataSource = servicioGeneral.getEstadoActividad(1, 0);
            withBlockSupera.ValueMember = "CODIGO";
            withBlockSupera.DisplayMember = "NOMBRE";
            withBlockSupera.SelectedIndex = 0;


            var withBlockSuperaPedido = cboEstadoSuperaPedido;
            withBlockSuperaPedido.DataSource = servicioGeneral.getEstadoActividad(1, 0);
            withBlockSuperaPedido.ValueMember = "CODIGO";
            withBlockSuperaPedido.DisplayMember = "NOMBRE";
            withBlockSuperaPedido.SelectedIndex = 0;

            var withBlockPasaPedido = cboEstadoPasaPedido;
            withBlockPasaPedido.DataSource = servicioGeneral.getEstadoActividad(1, 0);
            withBlockPasaPedido.ValueMember = "CODIGO";
            withBlockPasaPedido.DisplayMember = "NOMBRE";
            withBlockPasaPedido.SelectedIndex = 0;

            var withBlockDtg = dtgEstadosActividad;
            withBlockDtg.DataSource = servicioGeneral.getEstadoActividad(3, 0);

        }

        private void txtNroCampanasInac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNroPedidoInac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }


        private bool validaCampos()
        {
            if (txtNroCampanasInac.Text == "" | txtNroCampanasInac.Text == null)
                txtNroCampanasInac.Text = "0";
            if (txtNroPedidoInac.Text == "" | txtNroPedidoInac.Text == null)
                txtNroPedidoInac.Text = "0";
            if (txtDescripcionEstado.Text == "" | txtDescripcionEstado.Text == null)
            {
                strMensaje = "Ingrese el nombre o descripción del estado";
                txtDescripcionEstado.Focus();
                MessageBox.Show(strMensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (Convert.ToInt32(txtNroCampanasInac.Text) > 0 & (cboEstadoSuperaCampana.SelectedIndex == 0))
            {
                strMensaje = "Seleccione el estado supera número campañas";
                cboEstadoSuperaCampana.Focus();
                MessageBox.Show(strMensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (Convert.ToInt32(txtNroCampanasInac.Text) == 0 & (cboEstadoSuperaCampana.SelectedIndex > 0))
            {
                strMensaje = "Si el estado no controla campañas no debe seleccionar " + Label5.Text;
                cboEstadoSuperaCampana.Focus();
                MessageBox.Show(strMensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (Convert.ToInt32(txtNroPedidoInac.Text) > 0 & (cboEstadoSuperaPedido.SelectedIndex == 0))
            {
                strMensaje = "Seleccione el estado supera número Pedidos";
                cboEstadoSuperaCampana.Focus();
                MessageBox.Show(strMensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (Convert.ToInt32(txtNroPedidoInac.Text) == 0 & (cboEstadoSuperaPedido.SelectedIndex > 0))
            {
                strMensaje = "Si el estado no controla numero de pedidos no debe seleccionar " + Label9.Text;
                cboEstadoSuperaCampana.Focus();
                MessageBox.Show(strMensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
                return true;
        }
        private void limpiaCampos()
        {
            intCodigoEstado = 0;
            blnActualiza = false;
            txtDescripcionEstado.Text = null;
            txtNroCampanasInac.Text = "0";
            txtNroPedidoInac.Text = "0";
            cboEstadoNoPasaPedido.SelectedIndex = 0;
            cboEstadoPasaPedido.SelectedIndex = 0;
            cboEstadoSuperaCampana.SelectedIndex = 0;
            cboEstadoSuperaPedido.SelectedIndex = 0;
            rbnNoInactiva.Checked = false;
            rbnSiInactiva.Checked = false;
            rbnNoVinculacion.Checked = false;
            rbnSiVinculacion.Checked = false;
            rdbEsVinculacion.Checked = false;
            rdbNoVinculacion.Checked = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiaCampos();
        }

        private void dtgEstadosActividad_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
                blnActualiza = true;
                intCodigoEstado = Convert.ToInt32(dtgEstadosActividad.Rows[e.RowIndex].Cells["CODIGO"].Value);

                var ListaEstadosActividad = servicioGeneral.getEstadoActividadCamposTabla(4, intCodigoEstado);

                if (ListaEstadosActividad.ESA_NID != 0)
                {
                    txtDescripcionEstado.Text = Convert.ToString(ListaEstadosActividad.ESA_CDESCRIPCION);
                    if (ListaEstadosActividad.ESA_NESTADO_SIGUIENTE_CON_PED == 0)
                    {
                        cboEstadoPasaPedido.SelectedIndex = 0;
                    }
                    else
                    {
                        cboEstadoPasaPedido.SelectedValue = ListaEstadosActividad.ESA_NESTADO_SIGUIENTE_CON_PED;
                    }

                    if (ListaEstadosActividad.ESA_NESTADO_SIGUIENTE_SIN_PED == 0)
                    {
                        cboEstadoNoPasaPedido.SelectedIndex = 0;
                    }
                    else
                    {
                        cboEstadoNoPasaPedido.SelectedValue = ListaEstadosActividad.ESA_NESTADO_SIGUIENTE_SIN_PED;
                    }
                    txtNroCampanasInac.Text = Convert.ToString(ListaEstadosActividad.ESA_NCAMPANA_CONTROLA);
                    txtNroPedidoInac.Text = Convert.ToString(ListaEstadosActividad.ESA_NNUMERO_PEDIDO_CONTROLA);
                    if (ListaEstadosActividad.ESA_NESTADO_PASA_CONTROL_PEDIDO == 0)
                    {
                        cboEstadoSuperaPedido.SelectedIndex = 0;
                    }
                    else
                    {
                        cboEstadoSuperaPedido.SelectedValue = ListaEstadosActividad.ESA_NESTADO_PASA_CONTROL_PEDIDO;
                    }
                    if (ListaEstadosActividad.ESA_NESTADO_PASA_CONTROL_CAMPANA == 0)
                    {
                        cboEstadoSuperaCampana.SelectedIndex = 0;
                    }
                    else
                    {
                        cboEstadoSuperaCampana.SelectedValue = ListaEstadosActividad.ESA_NESTADO_PASA_CONTROL_CAMPANA;
                    }

                    if (!ListaEstadosActividad.ESA_OES_ESTADO_INACTIVIDAD)
                    {
                        rbnSiInactiva.Checked = false;
                        rbnNoInactiva.Checked = true;
                    }
                    else
                    {
                        rbnSiInactiva.Checked = true;
                        rbnNoInactiva.Checked = false;
                    }
                    if (!ListaEstadosActividad.ESA_OES_ESTADO_VINCULACION)
                    {
                        rdbEsVinculacion.Checked = false;
                        rdbNoVinculacion.Checked = true;
                    }
                    else
                    {
                        rdbEsVinculacion.Checked = true;
                        rdbNoVinculacion.Checked = false;
                    }
                    if (!ListaEstadosActividad.ESA_OINGRESA_VINCULACION)
                    {
                        rbnSiVinculacion.Checked = false;
                        rbnNoVinculacion.Checked = true;
                    }
                    else
                    {
                        rbnSiVinculacion.Checked = true;
                        rbnNoVinculacion.Checked = false;
                    }
                }
                else
                {
                    strMensaje = "El código seleccionado no se encuentra en la Base de Datos, Contacte al administrador del Sistema";
                    MessageBox.Show(strMensaje, "Error Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                limpiaCampos();
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                string strResulInsercion = string.Empty;
                ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
                EstadoActividad estadoActividad = new EstadoActividad();

                if (rbnSiInactiva.Checked)
                {
                    estadoActividad.ESA_OES_ESTADO_INACTIVIDAD = true;
                }
                else if (rbnNoInactiva.Checked)
                {
                    estadoActividad.ESA_OES_ESTADO_INACTIVIDAD = false;
                }

                if (rdbEsVinculacion.Checked)
                {
                    estadoActividad.ESA_OES_ESTADO_VINCULACION = true;
                }
                else
                {
                    estadoActividad.ESA_OES_ESTADO_VINCULACION = false;
                }

                if (rbnSiVinculacion.Checked)
                {
                    estadoActividad.ESA_OINGRESA_VINCULACION = true;
                }
                else
                {
                    estadoActividad.ESA_OINGRESA_VINCULACION = false;
                }
                estadoActividad.ESA_NID = intCodigoEstado;
                estadoActividad.ESA_CDESCRIPCION = txtDescripcionEstado.Text.ToUpper();
                estadoActividad.ESA_OESTADO = true;
                estadoActividad.ESA_NESTADO_SIGUIENTE_CON_PED = cboEstadoPasaPedido.SelectedIndex == 0 ? 0 : Convert.ToInt32(cboEstadoPasaPedido.SelectedValue);
                estadoActividad.ESA_NCAMPANA_CONTROLA = Convert.ToInt32(txtNroCampanasInac.Text);
                estadoActividad.ESA_NESTADO_PASA_CONTROL_CAMPANA = Convert.ToInt32(cboEstadoSuperaCampana.SelectedValue);
                estadoActividad.ESA_NNUMERO_PEDIDO_CONTROLA = Convert.ToInt32(txtNroPedidoInac.Text);
                estadoActividad.ESA_NESTADO_PASA_CONTROL_PEDIDO = Convert.ToInt32(cboEstadoSuperaPedido.SelectedValue);

                if (cboEstadoNoPasaPedido.SelectedIndex > 0)
                {
                    estadoActividad.ESA_NESTADO_SIGUIENTE_SIN_PED = Convert.ToInt32(cboEstadoNoPasaPedido.SelectedValue);
                }
                else
                {
                    estadoActividad.ESA_NESTADO_SIGUIENTE_SIN_PED = null;
                }

                if (cboEstadoNoPasaPedido.SelectedIndex > 0)
                {
                    estadoActividad.ESA_NESTADO_SIGUIENTE_SIN_PED = Convert.ToInt32(cboEstadoNoPasaPedido.SelectedValue);
                }
                else
                {
                    estadoActividad.ESA_NESTADO_SIGUIENTE_SIN_PED = null;
                }

                strResulInsercion = Convert.ToString(servicioGeneral.insEstadoActividad(estadoActividad));
                if (Information.IsNumeric(strResulInsercion))
                {
                    if (Convert.ToInt32(strResulInsercion) == 1)
                    {
                        MessageBox.Show("Registro creado exitosamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else if (Convert.ToInt32(strResulInsercion) == 2)
                    {
                        MessageBox.Show("Registro Actualizado exitosamente", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    CargaCombos();
                    limpiaCampos();
                }
                else
                {
                    MessageBox.Show("Error al grabar en la Base de Datos, contacte al Administrador del Sistema", "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }

            }
        }
    }
}
