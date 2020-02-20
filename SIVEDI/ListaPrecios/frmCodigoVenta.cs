using SIVEDI.Clases;
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

        }
    }
}
