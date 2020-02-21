using SIVEDI.Clases;
using SIVEDI.ServicePedidos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIVEDI.ListaPrecios
{
    public partial class frmCodigoVenta : Form
    {
        ServicePedidosClient ServicePedidos = new ServicePedidosClient();
        public frmCodigoVenta()
        {
            InitializeComponent();
        }

        private void frmCodigoVenta_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            dtgProductos.ReadOnly = true;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            cargaProductos();
        }

        private void cargaProductos()
        {
            {
                try
                {
                    var withBlock = dtgProductos;
                    withBlock.DataSource = ServicePedidos.getProductoNombre(txtReferencia.Text, txtNombreProducto.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void EditarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargaFormCodigoVenta();
        }

        private void dtgProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cargaFormCodigoVenta();
        }

        private void cargaFormCodigoVenta()
        {
            int filaSeleccionada = dtgProductos.SelectedRows[0].Index;
            clsConnection.intCodigoProducto = Convert.ToInt32(dtgProductos.Rows[filaSeleccionada].Cells[0].Value);
            clsConnection.strNombreProducto = Convert.ToString(dtgProductos.Rows[filaSeleccionada].Cells[2].Value);
            clsConnection.strReferenciaProducto = Convert.ToString(dtgProductos.Rows[filaSeleccionada].Cells[1].Value);
            frmAsignaCodVenta objAsigna = new frmAsignaCodVenta();
            objAsigna.Show();
        }

    }
}
