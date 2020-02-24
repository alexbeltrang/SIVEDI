using SIVEDI.Clases;
using SIVEDI.ServicePedidos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIVEDI.ListaPrecios
{
    public partial class frmCargaCodVentaMasivo : Form
    {
        DataTable dt = new DataTable();
        OperacionesExcel operacionesExcel = new OperacionesExcel();
        ServicePedidosClient ServicePedidos = new ServicePedidosClient();
        public Thread thColor;
        public frmCargaCodVentaMasivo()
        {
            InitializeComponent();
        }

        private void frmCargaCodVentaMasivo_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            lblPorcentajeCarga.Text = null;
            dtgCodigoVenta.ReadOnly = true;
        }

        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                CheckForIllegalCrossThreadCalls = false;

                // Instanciamos nuestro cuadro de dialogo
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                // Directorio Predeterminado
                // openFileDialog1.InitialDirectory = "C:\"
                // Filtramos solo archivos con extension *.xls
                openFileDialog1.Filter = "Todos los archivos| *.*|Archivo Excel | *.xlsx|Archivo Excel |*.xls";
                // Si se presiona abrir entonces...
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Asignamos la ruta donde se almacena el fichero excel que se va a importar
                    string RutaArchivo;
                    RutaArchivo = openFileDialog1.FileName;
                    dt = operacionesExcel.Excel_To_DataTable(RutaArchivo, 0);
                    // Llenamos el Datagridview
                    dtgCodigoVenta.DataSource = dt;
                    // Ajustamos las columnas del DataGridView
                    dtgCodigoVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void limpiaCampos()
        {
            txtRutaArchivo.Text = null;
            dtgCodigoVenta.DataSource = null;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            thColor = new System.Threading.Thread(CargaInformacion);
            if (thColor.ThreadState != System.Threading.ThreadState.Running)
                thColor.Start();
        }

        private void CargaInformacion()
        {
            try
            {
                if (dtgCodigoVenta.Rows.Count > 0)
                {
                    pbrCarga.Value = 0;
                    pbrCarga.Minimum = 0;
                    this.Cursor = Cursors.Default;
                    pbrCarga.Maximum = dt.Rows.Count;
                    for (var i = 0; i <= dtgCodigoVenta.Rows.Count - 1; i++)
                    {
                        CodigoVenta codigoVenta = new CodigoVenta();
                        pbrCarga.Refresh();
                        pbrCarga.Value = pbrCarga.Value + 1;
                        lblPorcentajeCarga.Text = Convert.ToInt32(pbrCarga.Value * 100 / (double)pbrCarga.Maximum) + "%";

                        codigoVenta.REFERENCIA = dtgCodigoVenta.Rows[i].Cells[0].Value.ToString();
                        codigoVenta.CODIGO_VENTA = Convert.ToString(dtgCodigoVenta.Rows[i].Cells[1].Value);
                        codigoVenta.ESTADO = Convert.ToInt32(dtgCodigoVenta.Rows[i].Cells[3].Value) == 1 ? true : false;
                        codigoVenta.ES_PRINCIPAL = Convert.ToInt32(dtgCodigoVenta.Rows[i].Cells[2].Value) == 1 ? true : false;
                        ServicePedidos.iuCodigoVenta(codigoVenta);
                    }
                    limpiaCampos();
                    MessageBox.Show("Archivo cargado exitosamente", "Carga Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    lblPorcentajeCarga.Text = null;
                    pbrCarga.Value = 0;
                    pbrCarga.Minimum = 0;
                    pbrCarga.Refresh();
                }
                else
                    MessageBox.Show("Seleccione un arhcivo para realizar la carga", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
