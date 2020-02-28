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
    public partial class frmConcursosVentas : Form
    {
        ServicioGeneralClient ServicioGeneral = new ServicioGeneralClient();
        public frmConcursosVentas()
        {
            InitializeComponent();
        }

        private void frmConcursosVentas_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            dtgConcursos.ReadOnly = true;
            tmrActualiza.Start();
            cargaCombos();
            llenaGrilla();
        }

        private void cargaCombos()
        {
            {
                var withBlock = cboCampanaEntrega;
                withBlock.DataSource = ServicioGeneral.getCampanas(1, 0);
                withBlock.ValueMember = "CODIGO";
                withBlock.DisplayMember = "NOMBRE";
                withBlock.SelectedValue = 0;
            }
        }
        private void llenaGrilla()
        {
            {
                var withBlock = dtgConcursos;
                withBlock.DataSource = ServicioGeneral.getConcursoFiltro(Convert.ToInt32(cboCampanaEntrega.SelectedValue), txtNombreConcurso.Text);
            }
        }

        private void btnBuscar_Click(System.Object sender, System.EventArgs e)
        {
            llenaGrilla();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            llenaGrilla();
        }

        private void AdicionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsConnection.intCodigoConcursoVentas = 0;
            frmAdminConcursoVentas frmAdminConcurso = new frmAdminConcursoVentas();
             frmAdminConcurso.Show();
        }

        private void EditarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filaSeleccionada = dtgConcursos.SelectedRows[0].Index;
            clsConnection.intCodigoConcursoVentas = Convert.ToInt32(dtgConcursos.Rows[filaSeleccionada].Cells[0].Value);
            frmAdminConcursoVentas frmAdminConcurso = new frmAdminConcursoVentas();
            frmAdminConcurso.Show();
        }

        private void tmrActualiza_Tick(object sender, EventArgs e)
        {
            if (clsConnection.blnActualizaListaconcursosNvo)
            {
                llenaGrilla();
                clsConnection.blnActualizaListaconcursosNvo = false;
            }
        }

        private void dtgConcursos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int filaSeleccionada = dtgConcursos.SelectedRows[0].Index;
            clsConnection.intCodigoConcursoVentas = Convert.ToInt32( dtgConcursos.Rows[filaSeleccionada].Cells[0].Value);
            frmAdminConcursoVentas frmAdminConcurso = new frmAdminConcursoVentas();
            frmAdminConcurso.Show();
        }
    }
}
