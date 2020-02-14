using SIVEDI.Clases;
using SIVEDI.ServicePedidos;
using SIVEDI.ServicioGeneral;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIVEDI.Cuentas
{
    public partial class frmClientes : Form
    {
        int intCodigoCliente = 0;
        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            txtIdentificacion.Focus();
        }

        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
                return;
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                cargaDatosCliente();
            }
        }

        private void txtIdentificacion_Leave(object sender, EventArgs e)
        {
            cargaDatosCliente();
        }

        private void cargaDatosCliente()
        {
            if (txtIdentificacion.Text != "" | txtIdentificacion.Text != null)
            {
                ServicioGeneralClient serviceClient = new ServicioGeneralClient();
                var datosCliente = serviceClient.getConsultaCliente(txtIdentificacion.Text);

                if (datosCliente.CODIGO > 0)
                {

                    intCodigoCliente = Convert.ToInt32(datosCliente.CODIGO);
                    txtAntepenUltimaCampPedido.Text = datosCliente.ANTERIOR_CAMPANA_PEDIDO;
                    txtCampanaVinculacion.Text = datosCliente.CAMPANA_VINCULACION;
                    txtCedulaReferente.Text = datosCliente.IDENTIFICACION_REFERENTE;
                    txtCiudad.Text = datosCliente.CIUDAD;
                    txtCodigoTerritorio.Text = datosCliente.TER_CID;
                    txtCodigoZona.Text = datosCliente.ZONA;
                    txtCupoAsignado.Text = string.Format(new CultureInfo("es-CO"), "{0:C}", datosCliente.CUPO_CREDITO);
                    txtDepto.Text = datosCliente.DEPARTAMENTO;
                    txtDireccionDomicilio.Text = datosCliente.DIRECCION_DOMICILIO;
                    txtDireccionEntrega.Text = datosCliente.DIRECCION_ENTREGA;
                    txtEmailcliente.Text = datosCliente.EMAIL;
                    txtEstadoActividadActual.Text = datosCliente.ESTADO_ACTIVIDAD_ACTUAL;
                    txtEstadoCivil.Text = datosCliente.ESTADO_CIVIL;
                    txtFechaNacimiento.Text = datosCliente.FECHA_NACIMIENTO;
                    txtFechaVinculacion.Text = datosCliente.FECHA_VINCULACION;
                    txtMotivoBloqueo.Text = datosCliente.MOTIVO_BLOQUEO;
                    txtNombreCliente.Text = datosCliente.NOMBRE;
                    txtNombreReferente.Text = datosCliente.NOMBRE_REFERENTE;
                    txtPais.Text = datosCliente.PAIS;
                    txtPenUltimaCampPedido.Text = datosCliente.PENULTIMA_CAMPANA_PEDIDO;
                    txtRazonBloqueo.Text = datosCliente.RAZON_BLOQUEO;
                    txtRegion.Text = datosCliente.REGIONAL;
                    txtSeccion.Text = datosCliente.SECCION;
                    txtTelefonoCelular.Text = datosCliente.TELEFONO_CELULAR;
                    txtTelefonoFijo.Text = datosCliente.TELEFONO_FIJO;
                    txtTelefonoOficina.Text = datosCliente.TELEFONO_OFICINA;
                    txtTipoCliente.Text = datosCliente.TIPO_CLIENTE;
                    txtTipoDocumento.Text = datosCliente.TIPO_DOCUMENTO;
                    txtUltimaCampPedido.Text = datosCliente.ULTIMA_CAMPANA_PEDIDO;
                    txtUltimoEstadoActividad.Text = datosCliente.ESTADO_ACTIVIDAD_ANTERIOR;
                    txtZona.Text = datosCliente.ZONA;

                    if (datosCliente.ES_LIDER)
                    {
                        rbnEsLider.Checked = true;
                        rbnNoesLider.Checked = false;
                    }
                    else
                    {
                        rbnEsLider.Checked = false;
                        rbnNoesLider.Checked = true;
                    }
                    if (datosCliente.ES_CABEZA_GRUPO)
                    {
                        rbnSiCabezaGrupo.Checked = true;
                        rbnNoCabezaGrupo.Checked = false;
                    }
                    else
                    {
                        rbnSiCabezaGrupo.Checked = false;
                        rbnNoCabezaGrupo.Checked = true;
                    }
                    if (datosCliente.COBRA_FLETE)
                    {
                        rbnSiCobraflete.Checked = true;
                        rbnNoCobraFlete.Checked = false;
                    }
                    else
                    {
                        rbnSiCobraflete.Checked = false;
                        rbnNoCobraFlete.Checked = true;
                    }
                    if (datosCliente.GEOREFERENCIADO)
                    {
                        rbnSiZonificada.Checked = true;
                        rbnNoZonificada.Checked = false;
                    }
                    else
                    {
                        rbnSiZonificada.Checked = false;
                        rbnNoZonificada.Checked = true;
                    }
                    if (datosCliente.CUENTA_BLOQUEADA)
                    {
                        rbnCtaSiBloqueada.Checked = true;
                        rbnCtaNoBloqueada.Checked = false;
                    }
                    else
                    {
                        rbnCtaSiBloqueada.Checked = false;
                        rbnCtaNoBloqueada.Checked = true;
                    }
                    if (datosCliente.ESINGRESO)
                    {
                        rdbEsIngreso.Checked = true;
                        rdbNoEsIngreso.Checked = false;
                    }
                    else
                    {
                        rdbEsIngreso.Checked = false;
                        rdbNoEsIngreso.Checked = true;
                    }
                    llenaGrillaPedidos();
                    llenaGrillaReferencias();
                }
                else
                {
                    MessageBox.Show("No existen registros con el número de Identificación digitado", "Cuenta no Existe", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    txtIdentificacion.Focus();
                }
            }
        }


        private void llenaGrillaPedidos()
        {
            {
                ServicePedidosClient servicioPedido = new ServicePedidosClient();
                var withBlock = dtgPedidoAS;
                withBlock.DataSource = servicioPedido.getConsultaPedidosCliente(intCodigoCliente);
            }
        }
        private void llenaGrillaReferencias()
        {
            {
                ServicioGeneralClient servicioGeneral = new ServicioGeneralClient();
                var withBlock = dtgReferencias;
                withBlock.DataSource = servicioGeneral.getReferenciaCliente(intCodigoCliente);
            }
        }
    }
}
