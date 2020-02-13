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
    public partial class frmBusquedaResponsable : Form
    {
        public frmBusquedaResponsable()
        {
            InitializeComponent();
        }

        private void frmBusquedaResponsable_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            txtNombre.Focus();
            dtgResponsables.ReadOnly = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ServiceClient servicioGeneral = new ServiceClient();
            var withBlock = dtgResponsables;
            withBlock.DataSource = servicioGeneral.getResponsableFiltro(txtIdentificacion.Text, txtNombre.Text);
        }

        private void dtgResponsables_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (clsConnection.blnbuscaRespDesdeReg)
                {
                    frmRegiones.intCodigoResponsable = Convert.ToString(dtgResponsables.Rows[e.RowIndex].Cells["CODIGO"].Value);
                    frmRegiones.strNombreResponsable = Convert.ToString(dtgResponsables.Rows[e.RowIndex].Cells["NOMBRE"].Value);
                    clsConnection.blnbuscaRespDesdeReg = false;
                }
                else if (clsConnection.blnbuscaRespDesdeZon)
                {
                    frmZonas.intCodigoResponsableZona = Convert.ToInt32(dtgResponsables.Rows[e.RowIndex].Cells["CODIGO"].Value);
                    frmZonas.strNombreResponsableZona = Convert.ToString(dtgResponsables.Rows[e.RowIndex].Cells["NOMBRE"].Value);
                    clsConnection.blnbuscaRespDesdeZon = false;
                }
                else if (clsConnection.blnbuscaRespDesdeSec)
                {
                    frmSecciones.intCodigoResponsableSeccion = Convert.ToInt32(dtgResponsables.Rows[e.RowIndex].Cells["CODIGO"].Value);
                    frmSecciones.strNombreResponsableSeccion = Convert.ToString(dtgResponsables.Rows[e.RowIndex].Cells["NOMBRE"].Value);
                    clsConnection.blnbuscaRespDesdeSec = false;
                }

            }
            this.Close();

        }

        private void frmBusquedaResponsable_Activated(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }
    }
}
