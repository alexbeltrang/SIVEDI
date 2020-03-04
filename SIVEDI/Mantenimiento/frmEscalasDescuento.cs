using Microsoft.VisualBasic;
using SIVEDI.Clases;
using SIVEDI.Clases.TABLAS;
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
    public partial class frmEscalasDescuento : Form
    {
        int intcodiEscalaEdita = 0;
        ServicioGeneralClient ServicioGeneral = new ServicioGeneralClient();
        public frmEscalasDescuento()
        {
            InitializeComponent();
        }

        private void frmEscalasDescuento_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            CheckForIllegalCrossThreadCalls = false;
            dtgZonasAsignadas.ReadOnly = true;
            CargaCombo();
            llenaZonas();
        }
        private void CargaCombo()
        {
            {
                var withBlock = cboTipoCliente;
                withBlock.DataSource = ServicioGeneral.getTipoCliente(1, 0);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedValue = 0;
            }
        }
        private void llenaZonas()
        {
            if (cboTipoCliente.SelectedIndex > 0)
            {
                {
                    var withBlock = chlZonas;
                    withBlock.DataSource = ServicioGeneral.getZonasEscalaDescuento(1, Convert.ToInt32(cboTipoCliente.SelectedValue));
                    withBlock.DisplayMember = "NOMBRE";
                    withBlock.ValueMember = "CODIGO";
                }
            }
        }

        private bool validaCampos()
        {
            if (cboTipoCliente.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione el tipo de cliente para el cual se va a asignar la escala de descuento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (txtValorInicial.Text == "" | txtValorInicial.Text == null)
            {
                MessageBox.Show("Ingrese el valor inicial de la escala de descuento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (txtValorFinal.Text == "" | txtValorFinal.Text == null)
            {
                MessageBox.Show("Ingrese el valor final de la escala de descuento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (txtPorcentaje.Text == "" | txtPorcentaje.Text == null)
            {
                MessageBox.Show("Ingrese el porcentaje de descuento que se asignará a la escala de descuento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (!rbnSiNuevo.Checked & !rbnNoNuevo.Checked)
            {
                MessageBox.Show("Seleccione si la escala de descuento es par asesores nuevos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
                return true;
        }

        private void chlZonas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    for (int idx = 1; idx <= this.chlZonas.Items.Count - 1; idx++)
                        this.chlZonas.SetItemCheckState(idx, CheckState.Checked);
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    for (int idx = 1; idx <= this.chlZonas.Items.Count - 1; idx++)
                        this.chlZonas.SetItemCheckState(idx, CheckState.Unchecked);
                }
            }
        }

        private void llenaGrilla()
        {
            try
            {
                var withBlock = dtgZonasAsignadas;
                withBlock.DataSource = ServicioGeneral.getEscala(1, 0, Convert.ToInt32(cboTipoCliente.SelectedValue), 0, "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void limpiaGrilla()
        {
            {
                var withBlock = dtgZonasAsignadas;
                withBlock.DataSource = null;
            }
        }
        private void limpiaCampos()
        {
            txtPorcentaje.Text = null;
            txtValorFinal.Text = null;
            txtValorInicial.Text = null;
            // cboTipoCliente.SelectedIndex = 0
            intcodiEscalaEdita = 0;
            rbnNoNuevo.Checked = false;
            rbnSiNuevo.Checked = false;
        }

        private void cboTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoCliente.SelectedIndex > 0)
            {
                llenaZonas();
                llenaGrilla();
            }
        }

        private void dtgZonasAsignadas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int filaSeleccionada = dtgZonasAsignadas.SelectedRows[0].Index;
            intcodiEscalaEdita = Convert.ToInt32(dtgZonasAsignadas.Rows[filaSeleccionada].Cells["CODIGO"].Value);
            txtPorcentaje.Text = dtgZonasAsignadas.Rows[filaSeleccionada].Cells["PORCENTAJE"].Value.ToString();
            txtValorFinal.Text = dtgZonasAsignadas.Rows[filaSeleccionada].Cells["RANGO_SUPERIOR"].Value.ToString();
            txtValorInicial.Text = dtgZonasAsignadas.Rows[filaSeleccionada].Cells["RANGO_INFERIOR"].Value.ToString();
            if (dtgZonasAsignadas.Rows[filaSeleccionada].Cells["CLIENTE_NUEVO"].Value.ToString() == "SI")
            {
                rbnSiNuevo.Checked = true;
                rbnNoNuevo.Checked = false;
            }
            else
            {
                rbnSiNuevo.Checked = false;
                rbnNoNuevo.Checked = true;
            }
        }

        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 46 && e.KeyChar != 44)
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
        }

        private void btnAsignaZonas_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                try
                {
                    string strResult = string.Empty;
                    EscalaDescuento escalaDescuento = new EscalaDescuento();

                    escalaDescuento.CODIGO = intcodiEscalaEdita;
                    escalaDescuento.PRECIO = Convert.ToDecimal(txtValorInicial.Text);
                    escalaDescuento.PRECIO_FINAL = Convert.ToDecimal(txtValorFinal.Text);
                    escalaDescuento.DESCUENTO_INICIAL = Convert.ToInt32(txtPorcentaje.Text);
                    escalaDescuento.TIPO_CLIENTE = Convert.ToInt32(cboTipoCliente.SelectedValue);


                    if (rbnSiNuevo.Checked)
                        escalaDescuento.ES_PARA_CLIENTE_NUEVO = true;
                    else if (rbnNoNuevo.Checked)
                        escalaDescuento.ES_PARA_CLIENTE_NUEVO = false;

                    if (chlZonas.CheckedItems.Count > 0)
                    {
                        foreach (ZonasTabla zonasTabla in chlZonas.CheckedItems)
                        {
                            if (zonasTabla.CODIGO != "0")
                                escalaDescuento.ZONA = zonasTabla.CODIGO;
                            strResult = ServicioGeneral.insEscalaDescuento(escalaDescuento).ToString();
                        }
                    }
                    else
                    {
                        escalaDescuento.ZONA = "";
                        strResult = ServicioGeneral.insEscalaDescuento(escalaDescuento).ToString();
                    }
                    if (Information.IsNumeric(strResult))
                    {
                        limpiaCampos();
                        llenaGrilla();
                    }
                    else
                    {
                        MessageBox.Show(strResult, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }
    }
}