using SIVEDI.Clases;
using SIVEDI.ServicePedidos;
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
    public partial class frmOfertaSimple : Form
    {
        ServicePedidosClient ServicePedidos = new ServicePedidosClient();
        ServicioGeneralClient ServicioGeneral = new ServicioGeneralClient();
        public frmOfertaSimple()
        {
            InitializeComponent();
        }

        private void frmOfertaSimple_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            CheckForIllegalCrossThreadCalls = false;
            dtgOfertaSimples.ReadOnly = true;
            tmrActualiza.Interval = 500;
            tmrActualiza.Start();
            CargaCombo();
            llenaGrilla();
        }

        private void CargaCombo()
        {
            {
                var withBlock = cbolistaPrecios;
                withBlock.DataSource = ServicePedidos.getListaPreciosTabla(4, 0);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "CODIGO_LISTA";
                withBlock.SelectedValue = 0;
            }
        }
        private void llenaGrilla()
        {
            try
            {
                var withBlock = dtgOfertaSimples;
                withBlock.DataSource = ServicioGeneral.getlistaOfertaFiltro(Convert.ToInt32(cbolistaPrecios.SelectedValue), txtNombreOferta.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error llenando tabla", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdicionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsConnection.intCodigoOfertaSimle = 0;
            frmAdminOfertaSimple adminOfertaSimple = new frmAdminOfertaSimple();
            adminOfertaSimple.Show();
        }

        private void EditarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int filaSeleccionada = dtgOfertaSimples.SelectedRows[0].Index;
                clsConnection.intCodigoOfertaSimle = Convert.ToInt32(dtgOfertaSimples.Rows[filaSeleccionada].Cells[0].Value);
                frmAdminOfertaSimple adminOfertaSimple = new frmAdminOfertaSimple();
                adminOfertaSimple.Show();
            }
            catch (Exception ex)
            {
            }
        }

        private void tmrActualiza_Tick(object sender, EventArgs e)
        {
            if (clsConnection.blnActualizaOfertasSimples)
            {
                llenaGrilla();
                clsConnection.blnActualizaOfertasSimples = false;
            }
        }

        private void dtgOfertaSimples_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int filaSeleccionada = dtgOfertaSimples.SelectedRows[0].Index;
            clsConnection.intCodigoOfertaSimle =  Convert.ToInt32(dtgOfertaSimples.Rows[filaSeleccionada].Cells[0].Value);
            frmAdminOfertaSimple adminOfertaSimple = new frmAdminOfertaSimple();
            adminOfertaSimple.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            llenaGrilla();
        }
    }
}
