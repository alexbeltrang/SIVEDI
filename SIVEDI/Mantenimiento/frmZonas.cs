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
    public partial class frmZonas : Form
    {
        public static int intCodigoResponsableZona;
        public static string strNombreResponsableZona;
        public frmZonas()
        {
            InitializeComponent();
        }

        private void frmZonas_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            dtgZonas.ReadOnly = true;
            cargaCombos();
        }

        private void cargaCombos()
        {
            ServiceClient servicioGeneral = new ServiceClient();
            var withBlock = cboPais;
            withBlock.DataSource = servicioGeneral.getPaises(1, 0);
            withBlock.ValueMember = "CODIGO";
            withBlock.DisplayMember = "NOMBRE";
            withBlock.SelectedValue = 0;
        }

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPais.SelectedIndex > 0)
            {
                ServiceClient servicioGeneral = new ServiceClient();
                var withBlock = cboRegional;
                withBlock.DataSource = servicioGeneral.getRegionales(1, 0, Convert.ToInt32(cboPais.SelectedValue));
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedIndex = 0;
            }
        }

        private void cboRegional_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
