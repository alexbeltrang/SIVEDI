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

namespace SIVEDI.Cuentas
{
    public partial class frmRegistroClientes : Form
    {
        public frmRegistroClientes()
        {
            InitializeComponent();
        }

        private void frmRegistroClientes_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            cargaCombos();
            //cargaCupocrditoMinimo();
        }

        private void cargaCombos()
        {
            ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
            {
                var withBlock = cboPais;
                withBlock.DataSource = servicioGeneral.getPaises(1, 0);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedIndex = 0;
            }
            {
                var withBlock = cboTipoDocumento;
                withBlock.DataSource = servicioGeneral.getTiposDocumento(1, 0);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedIndex = 0;
            }
            {
                var withBlock = cboEstadoCivil;
                withBlock.DataSource = servicioGeneral.getEstadoCivil(1, 0);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedIndex = 0;
            }
            {
                var withBlock = cboTipoCliente;
                withBlock.DataSource = servicioGeneral.getTipoCliente(1,0);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedIndex = 0;
            }
            {
                var withBlock = cboFormaPago;
                withBlock.DataSource = servicioGeneral.getFormaPago(1, 0);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedIndex = 0;
            }
            {
                var withBlock = cboCampanavinculacion;
                withBlock.DataSource = servicioGeneral.getCampanas(1, 0);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedIndex = 0;
            }
            {
                var withBlock = cboFormaIngreso;
                withBlock.DataSource = servicioGeneral.getformasIngreso(1, 0);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedIndex = 0;
            }
            {
                var withBlock = cboTipoReferencia;
                withBlock.DataSource = servicioGeneral.getTipoReferencia(1, 0);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedIndex = 0;
            }
            {
                var withBlock = cboGenero;
                withBlock.DataSource = servicioGeneral.GetGeneros(1,0);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedIndex = 0;
            }
        }

    }
}
