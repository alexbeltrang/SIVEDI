using SIVEDI.Clases;
using SIVEDI.Clases.TABLAS;
using SIVEDI.ServicePedidos;
using SIVEDI.ServicioLiquidacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SIVEDI.Operaciones
{
    public partial class frmDigitaPedidos : Form
    {
        DataTable dttClienteCampana = new DataTable(), dttPedidoDigitado = new DataTable();
        List<CombosTabla> ListcombosTabla = new List<CombosTabla>();
        List<ProductoPredidoTablas> ListProducto = new List<ProductoPredidoTablas>();
        List<ProductosCombo> productosCombos = new List<ProductosCombo>();
        bool blnEsIngreso, blnAsesorBloqueado, blnASesorSinGeo, blnAserBloqCartera;
        bool blnCargacombo = false;
        bool blnEliminaItems = false;
        string strCedulaCliente;
        string strMensaje;
        bool blnCobraFleteCliente;
        int intcodigoEncabezadoPedido;
        int intcodigoCliente;
        int intCodigoListaPrecios = 0;
        int intcodigoActividadcliente;
        int intcodigoTipoCliente;
        int intCodigoCiudadCliente;
        int intCampanaCliente;
        string strZonaAsesor;
        ServicePedidosClient ServicePedidos = new ServicePedidosClient();
        ServiceLiquidacionClient ServiceLiquidacion = new ServiceLiquidacionClient();
        public frmDigitaPedidos()
        {
            InitializeComponent();
        }

        private void txtCodigoProducto_Enter(object sender, EventArgs e)
        {
            TextBox sdr = (TextBox)sender;
            sdr.SelectAll();
        }

        private void txtCodigoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                cargaProductoDigitado();
            }
        }

        private void frmDigitaPedidos_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            dtgPedidosOriginal.ReadOnly = true;
            {
                var withBlock = dttPedidoDigitado;
                withBlock.Columns.Add(new DataColumn("CODIGO", typeof(string)));
                withBlock.Columns.Add(new DataColumn("NOMBRE", typeof(string)));
                withBlock.Columns.Add(new DataColumn("CANTIDAD", typeof(int)));
                withBlock.Columns.Add(new DataColumn("PRECIO_UNI", typeof(int)));
                withBlock.Columns.Add(new DataColumn("PRECIO_PUB", typeof(int)));
                withBlock.Columns.Add(new DataColumn("PRECIO_NET", typeof(int)));
                withBlock.Columns.Add(new DataColumn("PRECIO_TOTAL", typeof(int)));
                withBlock.Columns.Add(new DataColumn("TIENE_IVA", typeof(string)));
                withBlock.Columns.Add(new DataColumn("TIPO_REG", typeof(string)));
                withBlock.Columns.Add(new DataColumn("ELIMINA", typeof(bool)));
                withBlock.Columns.Add(new DataColumn("TIPO_PRODUCTO", typeof(string)));
                withBlock.Columns.Add(new DataColumn("ESCALA_DESCUENTOS", typeof(string)));
                withBlock.Columns.Add(new DataColumn("SE_LE_APLICA_ESCALA_DCTOS", typeof(string)));
                withBlock.Columns.Add(new DataColumn("ES_ACCESORIO", typeof(string)));
                withBlock.Columns.Add(new DataColumn("MONTO_PEDIDO", typeof(string)));
                withBlock.Columns.Add(new DataColumn("ES_PRODUCTO_CRP", typeof(string)));
                withBlock.Columns.Add(new DataColumn("PORC_IVA", typeof(decimal)));
                withBlock.Columns.Add(new DataColumn("VALOR_IVA", typeof(int)));
                withBlock.Columns.Add(new DataColumn("PORC_DESCUENTO_ESPECIAL", typeof(decimal)));
                withBlock.Columns.Add(new DataColumn("VALOR_DESCUENTO_ESPECIAL", typeof(int)));
                withBlock.Columns.Add(new DataColumn("LISTA_PRECIOS", typeof(string)));
                withBlock.Columns.Add(new DataColumn("SAV_LISTA_PRECIOS_PROD", typeof(string)));
                withBlock.Columns.Add(new DataColumn("MOTIVO_VENTA", typeof(string)));
                withBlock.Columns.Add(new DataColumn("CENTRO_GASTO", typeof(string)));
                withBlock.Columns.Add(new DataColumn("GRUPO_PRODUCTO", typeof(string)));
                withBlock.Columns.Add(new DataColumn("BODEGA", typeof(string)));
                withBlock.Columns.Add(new DataColumn("OFERTA_APLICADA", typeof(bool)));
                withBlock.Columns.Add(new DataColumn("ES_SALIDA", typeof(string)));
                withBlock.Columns.Add(new DataColumn("TIENE_FALTANTE", typeof(string)));
                withBlock.Columns.Add(new DataColumn("CODIGO_CONCURSO", typeof(string)));
                withBlock.Columns.Add(new DataColumn("SUMA_VALOR_PUBLICO", typeof(string)));
                withBlock.Columns.Add(new DataColumn("MOTIVO_OBSEQUIO", typeof(string)));
                withBlock.Columns.Add(new DataColumn("CENTRO_GASTO_OBSEQUIO", typeof(string)));
                withBlock.Columns.Add(new DataColumn("PRECIO_LISTA", typeof(int)));
                withBlock.Columns.Add(new DataColumn("PORC_ESCALA_DESCUENTO", typeof(decimal)));
                withBlock.Columns.Add(new DataColumn("VALOR_ESCALA_UNITARIO", typeof(int)));
                withBlock.Columns.Add(new DataColumn("VALOR_ESCALA_TOTAL", typeof(int)));
                withBlock.Columns.Add(new DataColumn("SUMA_NETO", typeof(bool)));
                withBlock.Columns.Add(new DataColumn("PUNTOS_PRODUCTO", typeof(int)));
            }
            {
                var withBlock = dtgPedidosOriginal;
                withBlock.DataSource = dttPedidoDigitado;
            }
            ocultaCampos(false);
            blnEsIngreso = false;
            blnAsesorBloqueado = false;
            blnASesorSinGeo = false;
            blnAserBloqCartera = false;
            txtIdentificacionAS.Focus();
        }

        private void ocultaCampos(bool blnEstado)
        {
            {
                var withBlock = dtgPedidosOriginal;
                withBlock.Columns["PRECIO_UNI"].Visible = blnEstado;
                withBlock.Columns["PRECIO_PUB"].Visible = blnEstado;
                withBlock.Columns["PRECIO_NET"].Visible = blnEstado;
                withBlock.Columns["PRECIO_TOTAL"].Visible = blnEstado;
                withBlock.Columns["TIENE_IVA"].Visible = blnEstado;
                withBlock.Columns["TIPO_REG"].Visible = blnEstado;
                withBlock.Columns["TIPO_PRODUCTO"].Visible = blnEstado;
                withBlock.Columns["ESCALA_DESCUENTOS"].Visible = blnEstado;
                withBlock.Columns["SE_LE_APLICA_ESCALA_DCTOS"].Visible = blnEstado;
                withBlock.Columns["ES_ACCESORIO"].Visible = blnEstado;
                withBlock.Columns["MONTO_PEDIDO"].Visible = blnEstado;
                withBlock.Columns["ES_PRODUCTO_CRP"].Visible = blnEstado;
                withBlock.Columns["PORC_IVA"].Visible = blnEstado;
                withBlock.Columns["VALOR_IVA"].Visible = blnEstado;
                withBlock.Columns["PORC_DESCUENTO_ESPECIAL"].Visible = blnEstado;
                withBlock.Columns["VALOR_DESCUENTO_ESPECIAL"].Visible = blnEstado;
                withBlock.Columns["LISTA_PRECIOS"].Visible = blnEstado;
                withBlock.Columns["SAV_LISTA_PRECIOS_PROD"].Visible = blnEstado;
                withBlock.Columns["MOTIVO_VENTA"].Visible = blnEstado;
                withBlock.Columns["CENTRO_GASTO"].Visible = blnEstado;
                withBlock.Columns["GRUPO_PRODUCTO"].Visible = blnEstado;
                withBlock.Columns["BODEGA"].Visible = blnEstado;
                withBlock.Columns["OFERTA_APLICADA"].Visible = blnEstado;
                withBlock.Columns["ES_SALIDA"].Visible = blnEstado;
                withBlock.Columns["TIENE_FALTANTE"].Visible = blnEstado;
                withBlock.Columns["CODIGO_CONCURSO"].Visible = blnEstado;
                withBlock.Columns["SUMA_VALOR_PUBLICO"].Visible = blnEstado;
                withBlock.Columns["MOTIVO_OBSEQUIO"].Visible = blnEstado;
                withBlock.Columns["CENTRO_GASTO_OBSEQUIO"].Visible = blnEstado;
                withBlock.Columns["PRECIO_LISTA"].Visible = blnEstado;
                withBlock.Columns["PORC_ESCALA_DESCUENTO"].Visible = blnEstado;
                withBlock.Columns["VALOR_ESCALA_UNITARIO"].Visible = blnEstado;
                withBlock.Columns["VALOR_ESCALA_TOTAL"].Visible = blnEstado;
                withBlock.Columns["ELIMINA"].Visible = blnEstado;
                withBlock.Columns["SUMA_NETO"].Visible = blnEstado;
                withBlock.Columns["PUNTOS_PRODUCTO"].Visible = blnEstado;
            }
        }

        private void txtIdentificacionAS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((!char.IsDigit(e.KeyChar)) & (!char.IsControl(e.KeyChar))))
            {
                // de igual forma se podra comprobar si es caracter: e.KeyChar.IsLetter
                // si es un caracter minusculas: e.KeyChar.IsLower ...etc
                if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
                {
                    e.Handled = true; // esto invalida la tecla pulsada
                    return;
                }
            }
            else if (e.KeyChar == (char)Keys.Enter)
                buscaAsesor();
        }

        private void buscaAsesor()
        {
            if (txtIdentificacionAS.Text != "" | txtIdentificacionAS.Text != null)
            {
                try
                {
                    var dttDatosCliente = ServicePedidos.getClientePedido(txtIdentificacionAS.Text);
                    if (dttDatosCliente.Count() > 0)
                    {
                        if (dttDatosCliente.FirstOrDefault().CUENTA_BLOQUEADA)
                        {
                            MessageBox.Show("Cliente bloqueado, no puede registrar pedido", "Cuenta Bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            limpiaCampos();
                            txtIdentificacionAS.Focus();
                        }
                        else
                        {
                            intcodigoCliente = Convert.ToInt32(dttDatosCliente.FirstOrDefault().CODIGO);
                            strCedulaCliente = dttDatosCliente.FirstOrDefault().IDENTIFICACION;
                            txtNombreAsesor.Text = dttDatosCliente.FirstOrDefault().NOMBRE_CLIENTE;
                            txtDireccion.Text = dttDatosCliente.FirstOrDefault().DIRECCION_ENTREGA;
                            txtEmail.Text = dttDatosCliente.FirstOrDefault().EMAIL;
                            txtTelCelular.Text = dttDatosCliente.FirstOrDefault().TELEFONO_CELULAR;
                            txtTelFijo.Text = dttDatosCliente.FirstOrDefault().TELEFONO_FIJO;
                            txtCupo.Text = dttDatosCliente.FirstOrDefault().CUPO_CREDITO.ToString();
                            var dttClienteCampana = ServicePedidos.getClienteListaPrecios(1, txtIdentificacionAS.Text);
                            strZonaAsesor = dttDatosCliente.FirstOrDefault().CODIGO_ZONA.ToString();
                            intcodigoActividadcliente = dttDatosCliente.FirstOrDefault().ESTADO_ACTIVIDAD_ANTERIOR;
                            intcodigoTipoCliente = Convert.ToInt32(dttDatosCliente.FirstOrDefault().CODIGO_TIPO_CLIENTE);
                            intCodigoCiudadCliente = dttDatosCliente.FirstOrDefault().CODIGO_CIUDAD;
                            blnEsIngreso = dttDatosCliente.FirstOrDefault().ES_INGRESO;
                            blnAsesorBloqueado = dttDatosCliente.FirstOrDefault().CUENTA_BLOQUEADA;
                            blnASesorSinGeo = dttDatosCliente.FirstOrDefault().ES_GEOREFERENCIADO;
                            blnCobraFleteCliente = dttDatosCliente.FirstOrDefault().COBRA_FLETE;
                            if (dttClienteCampana.Count() > 0)
                            {
                                txtCampanaAsignada.Text = dttClienteCampana.FirstOrDefault().NIVEL_CAMPANA.ToString();
                                intCodigoListaPrecios = dttClienteCampana.FirstOrDefault().CODIGO_LISTA_PRECIOS;
                                intCampanaCliente = Convert.ToInt32(dttClienteCampana.FirstOrDefault().CODIGO);
                                txtCodigoProducto.Focus();
                            }
                            else
                            {
                                limpiaCampos();
                                MessageBox.Show("El cliente no tiene una campaña asignada para facturación", "Asignación Campaña", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                txtIdentificacionAS.Focus();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existen registros con el número de Identificación digitado", "Cuenta no Existe", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        txtIdentificacionAS.Focus();
                        txtIdentificacionAS.Text = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }


        private void txtUnidades_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar)) & (!char.IsControl(e.KeyChar)))
            {
                if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
                {
                    e.Handled = true;
                    return;
                }
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                adicionaProducto();
            }
        }

        private void txtUnidades_Enter(object sender, EventArgs e)
        {
            TextBox sdr = (TextBox)sender;
            sdr.SelectAll();
        }

        private void cargaProductoDigitado()
        {
            if (txtCodigoProducto.Text != string.Empty)
            {
                var dttEquivalencia = ServicePedidos.getEquivalencias(4, 0, txtCodigoProducto.Text);
                if (dttEquivalencia.Count() > 0)
                {
                    txtCodigoProducto.Text = dttEquivalencia.FirstOrDefault().CODIGO_ENTREGA;
                    var dttDatosCombo = ServicePedidos.getCombos(3, 0, dttEquivalencia.FirstOrDefault().CODIGO_ENTREGA, intCodigoListaPrecios);
                    if (dttDatosCombo.Count() > 0)
                    {
                        foreach (CombosTabla item in dttDatosCombo)
                        {
                            CombosTabla combo = new CombosTabla();
                            combo.CODIGO = item.CODIGO;
                            combo.CODIGO_LISTA_PRECIOS = item.CODIGO_LISTA_PRECIOS;
                            combo.CODIGO_VENTA = item.CODIGO_VENTA;
                            combo.ESTADO = item.ESTADO;
                            combo.NOMBRE = item.NOMBRE;
                            combo.PORC_DESCUENTO = item.PORC_DESCUENTO;
                            combo.PRECIO_VENTA = item.PRECIO_VENTA;
                            ListcombosTabla.Add(combo);
                        }
                    }
                }
                else
                {
                    var dttDatosCombo = ServicePedidos.getCombos(3, 0, txtCodigoProducto.Text, intCodigoListaPrecios);
                    if (dttDatosCombo.Count() > 0)
                    {
                        foreach (CombosTabla item in dttDatosCombo)
                        {
                            CombosTabla combo = new CombosTabla();
                            combo.CODIGO = item.CODIGO;
                            combo.CODIGO_LISTA_PRECIOS = item.CODIGO_LISTA_PRECIOS;
                            combo.CODIGO_VENTA = item.CODIGO_VENTA;
                            combo.ESTADO = item.ESTADO;
                            combo.NOMBRE = item.NOMBRE;
                            combo.PORC_DESCUENTO = item.PORC_DESCUENTO;
                            combo.PRECIO_VENTA = item.PRECIO_VENTA;
                            ListcombosTabla.Add(combo);
                        }
                    }
                }

                if (ListcombosTabla.Count() > 0)
                {
                    txtNombreProducto.Text = ListcombosTabla.FirstOrDefault().NOMBRE;
                    txtUnidades.Focus();
                    blnCargacombo = true;
                }
                else
                {
                    try
                    {
                        blnCargacombo = false;
                        var dttProducto = ServicePedidos.getProductoPedidos(txtCodigoProducto.Text, intCodigoListaPrecios);
                        foreach (ProductoPredidoTablas Productopedido in dttProducto)
                        {
                            ProductoPredidoTablas producto = new ProductoPredidoTablas();
                            producto.APLICA_ESCALA = Productopedido.APLICA_ESCALA;
                            producto.APLICA_SUPERA_MONTO_MINIMO = Productopedido.APLICA_SUPERA_MONTO_MINIMO;
                            producto.CENTRO_GASTO_OBSEQUIO = Productopedido.CENTRO_GASTO_OBSEQUIO;
                            producto.CENTRO_GASTO_VENTA = Productopedido.CENTRO_GASTO_VENTA;
                            producto.CODIGO = Productopedido.CODIGO;
                            producto.CODIGO_TIPO_PRODUCTO = Productopedido.CODIGO_TIPO_PRODUCTO;
                            producto.CODIGO_VENTA = Productopedido.CODIGO_VENTA;
                            producto.COSTO_PRODUCTO = Productopedido.COSTO_PRODUCTO;
                            producto.ES_ACCESORIO = Productopedido.ES_ACCESORIO;
                            producto.ES_CODIGO_PRINCIPAL = Productopedido.ES_CODIGO_PRINCIPAL;
                            producto.ES_FALTANTE_ANUNCIADO = Productopedido.ES_FALTANTE_ANUNCIADO;
                            producto.IVA = Productopedido.IVA;
                            producto.LIMITE_VENTA = Productopedido.LIMITE_VENTA;
                            producto.MOTIVO_OBSEQUIO = Productopedido.MOTIVO_OBSEQUIO;
                            producto.MOTIVO_VENTA = Productopedido.MOTIVO_VENTA;
                            producto.NOMBRE_PRODUCTO = Productopedido.NOMBRE_PRODUCTO;
                            producto.PERMITE_DIGITAR = Productopedido.PERMITE_DIGITAR;
                            producto.PRECIO_CATALOGO = Productopedido.PRECIO_CATALOGO;
                            producto.PRECIO_LISTA = Productopedido.PRECIO_LISTA;
                            producto.PUNTOS_PREMIO = Productopedido.PUNTOS_PREMIO;
                            producto.REFERENCIA = Productopedido.REFERENCIA;
                            producto.SUMA_PARA_LLEGAR_ESCALA = Productopedido.SUMA_PARA_LLEGAR_ESCALA;
                            producto.SUMA_PARA_VALOR_NETO = Productopedido.SUMA_PARA_VALOR_NETO;
                            producto.SUMA_VALOR_PUBLICO = Productopedido.SUMA_VALOR_PUBLICO;
                            ListProducto.Add(producto);
                        }
                        if (dttProducto.Count() > 0)
                        {
                            if (!dttProducto.FirstOrDefault().PERMITE_DIGITAR)
                            {
                                MessageBox.Show("El producto no está habilitado para registro en pedidos", "No habilitado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                txtCodigoProducto.Focus();
                            }
                            else if (dttProducto.FirstOrDefault().ES_FALTANTE_ANUNCIADO)
                            {
                                MessageBox.Show("El producto digitado es un faltante anunciado", "No habilitado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                txtCodigoProducto.Focus();
                            }
                            else
                            {
                                txtNombreProducto.Text = dttProducto.FirstOrDefault().NOMBRE_PRODUCTO;
                                txtUnidades.Focus();
                            }
                        }
                        else
                        {
                            txtCodigoProducto.Focus();
                            txtCodigoProducto.Text = null;
                            MessageBox.Show("Código de producto no existe", "Producto no Existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }
        private void adicionaProducto()
        {
            if (txtUnidades.Text != "" | txtUnidades.Text != null)
            {
                for (var i = 0; i <= dttPedidoDigitado.Rows.Count - 1; i++)
                {
                    DataRow row = dttPedidoDigitado.Rows[0];

                    if (dttPedidoDigitado.Rows[i]["CODIGO"].ToString() == txtCodigoProducto.Text.ToUpper().Trim())
                    {
                        txtUnidades.Text = dttPedidoDigitado.Rows[i]["CANTIDAD"].ToString() + txtUnidades.Text;
                        dttPedidoDigitado.Rows[i]["ELIMINA"] = true;
                        blnEliminaItems = true;
                        break;
                    }
                }
                if (blnEliminaItems)
                {
                    dttPedidoDigitado = eliminaItems(dttPedidoDigitado);
                    blnEliminaItems = false;
                }

                if (blnCargacombo)
                {
                    foreach (CombosTabla DetalleCombo in ListcombosTabla)
                    {
                        var dttDetalleCombo = ServicePedidos.getProductoCombos(DetalleCombo.CODIGO);
                        foreach (ProductosCombo detallecombo in dttDetalleCombo)
                        {
                            var dttProducto = ServicePedidos.getProductoPedidos(detallecombo.CODIGO_VENTA, intCodigoListaPrecios);

                            foreach (ProductoPredidoTablas predidoTablas in dttProducto)
                            {
                                ProductoPredidoTablas productoPredido = new ProductoPredidoTablas();
                                productoPredido.APLICA_ESCALA = predidoTablas.APLICA_ESCALA;
                                productoPredido.APLICA_SUPERA_MONTO_MINIMO = predidoTablas.APLICA_SUPERA_MONTO_MINIMO;
                                productoPredido.CENTRO_GASTO_OBSEQUIO = predidoTablas.CENTRO_GASTO_OBSEQUIO;
                                productoPredido.CENTRO_GASTO_VENTA = predidoTablas.CENTRO_GASTO_VENTA;
                                productoPredido.CODIGO = predidoTablas.CODIGO;
                                productoPredido.CODIGO_TIPO_PRODUCTO = predidoTablas.CODIGO_TIPO_PRODUCTO;
                                productoPredido.CODIGO_VENTA = predidoTablas.CODIGO_VENTA;
                                productoPredido.COSTO_PRODUCTO = predidoTablas.COSTO_PRODUCTO;
                                productoPredido.ES_ACCESORIO = predidoTablas.ES_ACCESORIO;
                                productoPredido.ES_CODIGO_PRINCIPAL = predidoTablas.ES_CODIGO_PRINCIPAL;
                                productoPredido.ES_FALTANTE_ANUNCIADO = predidoTablas.ES_FALTANTE_ANUNCIADO;
                                productoPredido.IVA = predidoTablas.IVA;
                                productoPredido.LIMITE_VENTA = predidoTablas.LIMITE_VENTA;
                                productoPredido.MOTIVO_OBSEQUIO = predidoTablas.MOTIVO_OBSEQUIO;
                                productoPredido.MOTIVO_VENTA = predidoTablas.MOTIVO_VENTA;
                                productoPredido.NOMBRE_PRODUCTO = predidoTablas.NOMBRE_PRODUCTO;
                                productoPredido.PERMITE_DIGITAR = predidoTablas.PERMITE_DIGITAR;
                                productoPredido.PRECIO_CATALOGO = predidoTablas.PRECIO_CATALOGO;
                                productoPredido.PRECIO_LISTA = predidoTablas.PRECIO_LISTA;
                                productoPredido.PUNTOS_PREMIO = predidoTablas.PUNTOS_PREMIO;
                                productoPredido.REFERENCIA = predidoTablas.REFERENCIA;
                                productoPredido.SUMA_PARA_LLEGAR_ESCALA = predidoTablas.SUMA_PARA_LLEGAR_ESCALA;
                                productoPredido.SUMA_PARA_VALOR_NETO = predidoTablas.SUMA_PARA_VALOR_NETO;
                                productoPredido.SUMA_VALOR_PUBLICO = predidoTablas.SUMA_VALOR_PUBLICO;
                                cargaProductosalPedido(productoPredido, detallecombo.UNIDADES);
                            }
                        }
                    }
                }
                else
                {
                    var dttProducto = ServicePedidos.getProductoPedidos(txtCodigoProducto.Text, intCodigoListaPrecios);

                    foreach (ProductoPredidoTablas predidoTablas in dttProducto)
                    {
                        ProductoPredidoTablas productoPredido = new ProductoPredidoTablas();
                        productoPredido.APLICA_ESCALA = predidoTablas.APLICA_ESCALA;
                        productoPredido.APLICA_SUPERA_MONTO_MINIMO = predidoTablas.APLICA_SUPERA_MONTO_MINIMO;
                        productoPredido.CENTRO_GASTO_OBSEQUIO = predidoTablas.CENTRO_GASTO_OBSEQUIO;
                        productoPredido.CENTRO_GASTO_VENTA = predidoTablas.CENTRO_GASTO_VENTA;
                        productoPredido.CODIGO = predidoTablas.CODIGO;
                        productoPredido.CODIGO_TIPO_PRODUCTO = predidoTablas.CODIGO_TIPO_PRODUCTO;
                        productoPredido.CODIGO_VENTA = predidoTablas.CODIGO_VENTA;
                        productoPredido.COSTO_PRODUCTO = predidoTablas.COSTO_PRODUCTO;
                        productoPredido.ES_ACCESORIO = predidoTablas.ES_ACCESORIO;
                        productoPredido.ES_CODIGO_PRINCIPAL = predidoTablas.ES_CODIGO_PRINCIPAL;
                        productoPredido.ES_FALTANTE_ANUNCIADO = predidoTablas.ES_FALTANTE_ANUNCIADO;
                        productoPredido.IVA = predidoTablas.IVA;
                        productoPredido.LIMITE_VENTA = predidoTablas.LIMITE_VENTA;
                        productoPredido.MOTIVO_OBSEQUIO = predidoTablas.MOTIVO_OBSEQUIO;
                        productoPredido.MOTIVO_VENTA = predidoTablas.MOTIVO_VENTA;
                        productoPredido.NOMBRE_PRODUCTO = predidoTablas.NOMBRE_PRODUCTO;
                        productoPredido.PERMITE_DIGITAR = predidoTablas.PERMITE_DIGITAR;
                        productoPredido.PRECIO_CATALOGO = predidoTablas.PRECIO_CATALOGO;
                        productoPredido.PRECIO_LISTA = predidoTablas.PRECIO_LISTA;
                        productoPredido.PUNTOS_PREMIO = predidoTablas.PUNTOS_PREMIO;
                        productoPredido.REFERENCIA = predidoTablas.REFERENCIA;
                        productoPredido.SUMA_PARA_LLEGAR_ESCALA = predidoTablas.SUMA_PARA_LLEGAR_ESCALA;
                        productoPredido.SUMA_PARA_VALOR_NETO = predidoTablas.SUMA_PARA_VALOR_NETO;
                        productoPredido.SUMA_VALOR_PUBLICO = predidoTablas.SUMA_VALOR_PUBLICO;
                        cargaProductosalPedido(productoPredido, 1);
                        llenaGrilla(dttPedidoDigitado);
                        limpiaCamposdigitacion();
                    }
                }
            }
        }

        private DataTable eliminaItems(DataTable dttTemp)
        {
            DataTable dttDefinitivo = new DataTable();
            DataRow rowDef;
            {
                var withBlock = dttDefinitivo;
                withBlock.Columns.Add(new DataColumn("CODIGO", typeof(string)));
                withBlock.Columns.Add(new DataColumn("NOMBRE", typeof(string)));
                withBlock.Columns.Add(new DataColumn("CANTIDAD", typeof(int)));
                withBlock.Columns.Add(new DataColumn("PRECIO_UNI", typeof(int)));
                withBlock.Columns.Add(new DataColumn("PRECIO_PUB", typeof(int)));
                withBlock.Columns.Add(new DataColumn("PRECIO_NET", typeof(int)));
                withBlock.Columns.Add(new DataColumn("PRECIO_TOTAL", typeof(int)));
                withBlock.Columns.Add(new DataColumn("TIENE_IVA", typeof(string)));
                withBlock.Columns.Add(new DataColumn("TIPO_REG", typeof(string)));
                withBlock.Columns.Add(new DataColumn("ELIMINA", typeof(bool)));
                withBlock.Columns.Add(new DataColumn("TIPO_PRODUCTO", typeof(string)));
                withBlock.Columns.Add(new DataColumn("ESCALA_DESCUENTOS", typeof(string)));
                withBlock.Columns.Add(new DataColumn("SE_LE_APLICA_ESCALA_DCTOS", typeof(string)));
                withBlock.Columns.Add(new DataColumn("ES_ACCESORIO", typeof(string)));
                withBlock.Columns.Add(new DataColumn("MONTO_PEDIDO", typeof(string)));
                withBlock.Columns.Add(new DataColumn("ES_PRODUCTO_CRP", typeof(string)));
                withBlock.Columns.Add(new DataColumn("PORC_IVA", typeof(decimal)));
                withBlock.Columns.Add(new DataColumn("VALOR_IVA", typeof(int)));
                withBlock.Columns.Add(new DataColumn("PORC_DESCUENTO_ESPECIAL", typeof(decimal)));
                withBlock.Columns.Add(new DataColumn("VALOR_DESCUENTO_ESPECIAL", typeof(int)));
                withBlock.Columns.Add(new DataColumn("LISTA_PRECIOS", typeof(string)));
                withBlock.Columns.Add(new DataColumn("SAV_LISTA_PRECIOS_PROD", typeof(string)));
                withBlock.Columns.Add(new DataColumn("MOTIVO_VENTA", typeof(string)));
                withBlock.Columns.Add(new DataColumn("CENTRO_GASTO", typeof(string)));
                withBlock.Columns.Add(new DataColumn("GRUPO_PRODUCTO", typeof(string)));
                withBlock.Columns.Add(new DataColumn("BODEGA", typeof(string)));
                withBlock.Columns.Add(new DataColumn("OFERTA_APLICADA", typeof(bool)));
                withBlock.Columns.Add(new DataColumn("ES_SALIDA", typeof(string)));
                withBlock.Columns.Add(new DataColumn("TIENE_FALTANTE", typeof(string)));
                withBlock.Columns.Add(new DataColumn("CODIGO_CONCURSO", typeof(string)));
                withBlock.Columns.Add(new DataColumn("SUMA_VALOR_PUBLICO", typeof(string)));
                withBlock.Columns.Add(new DataColumn("MOTIVO_OBSEQUIO", typeof(string)));
                withBlock.Columns.Add(new DataColumn("CENTRO_GASTO_OBSEQUIO", typeof(string)));
                withBlock.Columns.Add(new DataColumn("PRECIO_LISTA", typeof(int)));
                withBlock.Columns.Add(new DataColumn("PORC_ESCALA_DESCUENTO", typeof(decimal)));
                withBlock.Columns.Add(new DataColumn("VALOR_ESCALA_UNITARIO", typeof(int)));
                withBlock.Columns.Add(new DataColumn("VALOR_ESCALA_TOTAL", typeof(int)));
                withBlock.Columns.Add(new DataColumn("SUMA_NETO", typeof(bool)));
                withBlock.Columns.Add(new DataColumn("PUNTOS_PRODUCTO", typeof(int)));
            }
            int intLinea = 0;
            for (var i = 0; i <= dttTemp.Rows.Count - 1; i++)
            {
                if (!Convert.ToBoolean(dttTemp.Rows[i]["ELIMINA"]))
                {
                    rowDef = dttDefinitivo.NewRow();
                    rowDef["CODIGO"] = dttTemp.Rows[i]["CODIGO"];
                    rowDef["NOMBRE"] = dttTemp.Rows[i]["NOMBRE"];
                    rowDef["CANTIDAD"] = dttTemp.Rows[i]["CANTIDAD"];
                    rowDef["PRECIO_UNI"] = dttTemp.Rows[i]["PRECIO_UNI"];
                    rowDef["PRECIO_PUB"] = dttTemp.Rows[i]["PRECIO_PUB"];
                    rowDef["PRECIO_NET"] = dttTemp.Rows[i]["PRECIO_NET"];
                    rowDef["PRECIO_TOTAL"] = dttTemp.Rows[i]["PRECIO_TOTAL"];
                    rowDef["TIENE_IVA"] = dttTemp.Rows[i]["TIENE_IVA"];
                    rowDef["TIPO_REG"] = dttTemp.Rows[i]["TIPO_REG"];
                    rowDef["ELIMINA"] = dttTemp.Rows[i]["ELIMINA"];
                    rowDef["TIPO_PRODUCTO"] = dttTemp.Rows[i]["TIPO_PRODUCTO"];
                    rowDef["ESCALA_DESCUENTOS"] = dttTemp.Rows[i]["ESCALA_DESCUENTOS"];
                    rowDef["SE_LE_APLICA_ESCALA_DCTOS"] = dttTemp.Rows[i]["SE_LE_APLICA_ESCALA_DCTOS"];
                    rowDef["ES_ACCESORIO"] = dttTemp.Rows[i]["ES_ACCESORIO"];
                    rowDef["MONTO_PEDIDO"] = dttTemp.Rows[i]["MONTO_PEDIDO"];
                    rowDef["ES_PRODUCTO_CRP"] = dttTemp.Rows[i]["ES_PRODUCTO_CRP"];
                    rowDef["PORC_IVA"] = dttTemp.Rows[i]["PORC_IVA"];
                    rowDef["VALOR_IVA"] = dttTemp.Rows[i]["VALOR_IVA"];
                    rowDef["PORC_DESCUENTO_ESPECIAL"] = dttTemp.Rows[i]["PORC_DESCUENTO_ESPECIAL"];
                    rowDef["VALOR_DESCUENTO_ESPECIAL"] = dttTemp.Rows[i]["VALOR_DESCUENTO_ESPECIAL"];
                    rowDef["LISTA_PRECIOS"] = dttTemp.Rows[i]["LISTA_PRECIOS"];
                    rowDef["SAV_LISTA_PRECIOS_PROD"] = dttTemp.Rows[i]["SAV_LISTA_PRECIOS_PROD"];
                    rowDef["MOTIVO_VENTA"] = dttTemp.Rows[i]["MOTIVO_VENTA"];
                    rowDef["CENTRO_GASTO"] = dttTemp.Rows[i]["CENTRO_GASTO"];
                    rowDef["GRUPO_PRODUCTO"] = dttTemp.Rows[i]["GRUPO_PRODUCTO"];
                    rowDef["BODEGA"] = dttTemp.Rows[i]["BODEGA"];
                    rowDef["OFERTA_APLICADA"] = dttTemp.Rows[i]["OFERTA_APLICADA"];
                    rowDef["ES_SALIDA"] = dttTemp.Rows[i]["ES_SALIDA"];
                    rowDef["TIENE_FALTANTE"] = dttTemp.Rows[i]["TIENE_FALTANTE"];
                    rowDef["CODIGO_CONCURSO"] = dttTemp.Rows[i]["CODIGO_CONCURSO"];
                    rowDef["SUMA_VALOR_PUBLICO"] = dttTemp.Rows[i]["SUMA_VALOR_PUBLICO"];
                    rowDef["MOTIVO_OBSEQUIO"] = dttTemp.Rows[i]["MOTIVO_OBSEQUIO"];
                    rowDef["CENTRO_GASTO_OBSEQUIO"] = dttTemp.Rows[i]["CENTRO_GASTO_OBSEQUIO"];
                    rowDef["PRECIO_LISTA"] = dttTemp.Rows[i]["PRECIO_LISTA"];
                    rowDef["PORC_ESCALA_DESCUENTO"] = "0";
                    rowDef["VALOR_ESCALA_UNITARIO"] = "0";
                    rowDef["VALOR_ESCALA_TOTAL"] = "0";
                    rowDef["SUMA_NETO"] = dttTemp.Rows[i]["SUMA_NETO"];
                    rowDef["PUNTOS_PRODUCTO"] = dttTemp.Rows[i]["PUNTOS_PRODUCTO"];
                    dttDefinitivo.Rows.Add(rowDef);
                }
            }
            return dttDefinitivo;
        }

        private void txtIdentificacionAS_Leave(object sender, EventArgs e)
        {
            buscaAsesor();
        }

        private void txtCodigoProducto_Leave(object sender, EventArgs e)
        {
            cargaProductoDigitado();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            adicionaProducto();
        }

        private void dtgPedidosOriginal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (e.RowIndex > -1)
                    MessageBox.Show(Convert.ToString(dtgPedidosOriginal.Rows[e.RowIndex].Cells[2].Value));
            }
            else if (e.ColumnIndex == 1)
            {
                strMensaje = "Eliminado el codigo de venta Nro." + dtgPedidosOriginal.Rows[e.RowIndex].Cells[2].Value + " - " + dtgPedidosOriginal.Rows[e.RowIndex].Cells[3].Value;
                dttPedidoDigitado.Rows[e.RowIndex].Delete();
                llenaGrilla(dttPedidoDigitado);
                MessageBox.Show(strMensaje);
            }
        }

        private void btnLiquidar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dttPedidoPreliquidado = new DataTable();
                dttPedidoDigitado.TableName = "digitado";
                dttPedidoDigitado.Namespace = "digitado";
                dttPedidoPreliquidado = ServiceLiquidacion.preliquidaPedido(dttPedidoDigitado, intCodigoListaPrecios, clsConnection.strCadenaConexionBaseDatos, intcodigoActividadcliente, strZonaAsesor, intcodigoTipoCliente, blnEsIngreso, strCedulaCliente.Trim(), intCodigoCiudadCliente, blnCobraFleteCliente, intcodigoTipoCliente);
                llenaGrilla(dttPedidoPreliquidado);
                ocultaCampos(true);
                //calculaValoresFinales(dttPedidoPreliquidado);
                //{
                //    var withBlock = dtgPedidosOriginal;
                //    withBlock.Columns(0).Visible = false;
                //    withBlock.Columns(1).Visible = false;
                //}
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void llenaGrilla(DataTable dttPedido)
        {
            {
                var withBlock = dtgPedidosOriginal;
                withBlock.DataSource = dttPedido;
            }
        }

        private void limpiaCamposdigitacion()
        {
            txtCodigoProducto.Text = null;
            txtUnidades.Text = null;
            txtNombreProducto.Text = null;
            txtCodigoProducto.Focus();
        }


        private void cargaProductosalPedido(ProductoPredidoTablas dttDatosProducto, int intTotalUnidadesCombo)
        {
            DataRow row;
            row = dttPedidoDigitado.NewRow();
            row["CODIGO"] = dttDatosProducto.CODIGO_VENTA;
            row["NOMBRE"] = dttDatosProducto.NOMBRE_PRODUCTO;
            row["CANTIDAD"] = Convert.ToInt32(txtUnidades.Text) * intTotalUnidadesCombo;
            row["PRECIO_UNI"] = dttDatosProducto.PRECIO_LISTA;
            row["PRECIO_PUB"] = dttDatosProducto.PRECIO_LISTA;
            row["SUMA_VALOR_PUBLICO"] = dttDatosProducto.SUMA_VALOR_PUBLICO;
            row["ESCALA_DESCUENTOS"] = dttDatosProducto.SUMA_PARA_LLEGAR_ESCALA;
            row["SE_LE_APLICA_ESCALA_DCTOS"] = dttDatosProducto.APLICA_ESCALA;
            row["MONTO_PEDIDO"] = dttDatosProducto.APLICA_SUPERA_MONTO_MINIMO;
            row["ES_ACCESORIO"] = dttDatosProducto.ES_ACCESORIO;
            row["PORC_IVA"] = dttDatosProducto.IVA;
            row["MOTIVO_VENTA"] = dttDatosProducto.MOTIVO_VENTA;
            row["CENTRO_GASTO"] = dttDatosProducto.CENTRO_GASTO_VENTA;
            row["MOTIVO_OBSEQUIO"] = dttDatosProducto.MOTIVO_OBSEQUIO;
            row["CENTRO_GASTO_OBSEQUIO"] = dttDatosProducto.CENTRO_GASTO_OBSEQUIO;
            row["SAV_LISTA_PRECIOS_PROD"] = dttDatosProducto.CODIGO;
            row["TIPO_PRODUCTO"] = dttDatosProducto.CODIGO_TIPO_PRODUCTO;
            row["OFERTA_APLICADA"] = false;
            row["ELIMINA"] = false;
            if (Convert.ToInt32(dttDatosProducto.IVA) > 0)
            {
                row["TIENE_IVA"] = "S";
                row["VALOR_IVA"] = Convert.ToDouble(dttDatosProducto.PRECIO_LISTA) - (Convert.ToDouble(dttDatosProducto.PRECIO_LISTA) / (1 + Convert.ToDouble(dttDatosProducto.IVA)));
                row["PRECIO_NET"] = Convert.ToDouble(dttDatosProducto.PRECIO_LISTA) / (1 + Convert.ToDouble(dttDatosProducto.IVA));
                row["PRECIO_TOTAL"] = (Convert.ToDouble(dttDatosProducto.PRECIO_LISTA) - (Convert.ToDouble(dttDatosProducto.PRECIO_LISTA) * Convert.ToDouble(dttDatosProducto.IVA))) * Convert.ToDouble(row["CANTIDAD"]);
            }
            else
            {
                row["TIENE_IVA"] = "N";
                row["VALOR_IVA"] = 0;
                row["PRECIO_NET"] = Convert.ToDouble(dttDatosProducto.PRECIO_LISTA) / (1 + Convert.ToDouble(dttDatosProducto.IVA));
                row["PRECIO_TOTAL"] = Convert.ToDouble(dttDatosProducto.PRECIO_LISTA) * Convert.ToDouble(row["CANTIDAD"]);
            }
            row["PORC_DESCUENTO_ESPECIAL"] = "0";
            row["PRECIO_LISTA"] = Convert.ToDouble(dttDatosProducto.PRECIO_LISTA);
            row["PORC_ESCALA_DESCUENTO"] = "0";
            row["VALOR_ESCALA_UNITARIO"] = "0";
            row["VALOR_ESCALA_TOTAL"] = "0";
            row["VALOR_DESCUENTO_ESPECIAL"] = "0";
            row["SUMA_NETO"] = dttDatosProducto.SUMA_PARA_VALOR_NETO;
            row["PUNTOS_PRODUCTO"] = (Convert.ToInt32(dttDatosProducto.PUNTOS_PREMIO) * ((Convert.ToInt32(txtUnidades.Text) * intTotalUnidadesCombo)));
            // intTotalValorPublico = intTotalValorPublico + (dttDatosProducto.Rows(0).Item("LPP_NPRECIO_LISTA") * (1 + (dttDatosProducto.Rows(0).Item("LPP_NPORC_IVA")) / 100))
            // txtValorPublico.Text = intTotalValorPublico * CInt(row("CANTIDAD"))
            dttPedidoDigitado.Rows.Add(row);
        }


        private void limpiaCampos()
        {
            txtCampanaAsignada.Text = null;
            txtCodigoProducto.Text = null;
            txtCupo.Text = null;
            txtDescEscala.Text = null;
            txtDireccion.Text = null;
            txtEmail.Text = null;
            txtNombreAsesor.Text = null;
            txtNombreProducto.Text = null;
            txtTelCelular.Text = null;
            txtTelFijo.Text = null;
            txtUnidades.Text = null;
            txtValorPublico.Text = null;
            txtTotalaPagar.Text = null;
            intcodigoActividadcliente = 0;
            {
                var withBlock = dtgPedidosOriginal;
                withBlock.DataSource = null;
            }
            intCodigoListaPrecios = 0;
            blnCobraFleteCliente = false;
            blnEsIngreso = false;
            blnAsesorBloqueado = false;
            blnASesorSinGeo = false;
            blnAserBloqCartera = false;
            intcodigoEncabezadoPedido = 0;
            intcodigoCliente = 0;
            dttPedidoDigitado.Rows.Clear();
        }

    }
}
