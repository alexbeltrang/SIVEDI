using Microsoft.VisualBasic;
using SIVEDI.Administracion;
using SIVEDI.Clases;
using SIVEDI.Cuentas;
using SIVEDI.Indicadores;
using SIVEDI.Maestras;
using SIVEDI.Mantenimiento;
using SIVEDI.ServicioGeneral;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SIVEDI
{
    public partial class frmPrincipal : Form
    {
        static string[] paths = { System.IO.Directory.GetCurrentDirectory(), "Resources\\" };
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            treeMenu.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            ToolFecha.Text = "Fecha y Hora:     " + Strings.Format(DateTime.Now, "G");
            Timer1.Start();
            SqlConnectionStringBuilder strCnn = new SqlConnectionStringBuilder();
            //strCnn.ConnectionString = clsConnection.strCadenaConexionBaseDatos;
            toolServidor.Text = toolServidor.Text + " " + strCnn.DataSource;
            toolBD.Text = toolBD.Text + " " + strCnn.InitialCatalog;
            ToolUser.Text = ToolUser.Text + " " + clsConnection.strNombreUsuario;
            this.MaximizeBox = true;
            cargaModulopadre();
        }
        private void cargaModulopadre()
        {

            treeMenu.Nodes.Clear();
            List<moduloPadre> moduloPadre = new List<moduloPadre>();
            ServiceClient ServicioGeneral = new ServiceClient();
            var modulo = ServicioGeneral.getModuloPadre(clsConnection.intIdUsuario);
            foreach (moduloPadre padre in modulo)
            {
                treeMenu.Nodes.Add(padre.MOD_NID.ToString(), padre.MOD_CDESCRIPCION.ToString());
                ImageList myImageList = new ImageList();
                myImageList.Images.Add(Properties.Resources.resultset_next);
                myImageList.Images.Add(Properties.Resources.basedatos1);
                treeMenu.ImageIndex = 0;
                treeMenu.SelectedImageIndex = 0;
                treeMenu.ImageList = myImageList;
                var modulohijo = ServicioGeneral.getModuloHijo(clsConnection.intIdUsuario, Convert.ToInt32(padre.MOD_NID));
                foreach (moduloHijo hijo in modulohijo)
                {
                    TreeNode[] MyNode;
                    MyNode = treeMenu.Nodes.Find(padre.MOD_NID.ToString(), true);
                    TreeNode nodo1 = new TreeNode();
                    nodo1.Text = hijo.MOD_CDESCRIPCION;
                    nodo1.Name = hijo.MOD_NID.ToString();
                    MyNode[0].Nodes.Add(nodo1);
                    treeMenu.ImageIndex = 0;
                    treeMenu.SelectedImageIndex = 0;
                    var moduloNieto = ServicioGeneral.getModuloHijo(clsConnection.intIdUsuario, Convert.ToInt32(hijo.MOD_NID));
                    foreach (moduloHijo nieto in moduloNieto)
                    {
                        TreeNode[] MyNode1;
                        MyNode1 = treeMenu.Nodes.Find(hijo.MOD_NID.ToString(), true);
                        TreeNode nodo2 = new TreeNode();
                        nodo2.Text = nieto.MOD_CDESCRIPCION;
                        nodo2.Name = nieto.MOD_NID.ToString();
                        MyNode1[0].Nodes.Add(nodo2);
                        treeMenu.ImageIndex = 0;
                        treeMenu.SelectedImageIndex = 0;
                    }
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            ToolFecha.Text = "Fecha y Hora:     " + Strings.Format(DateTime.Now, "G");
        }

        private void muestraFormularios(string strNombreNodo)
        {
            switch (strNombreNodo)
            {
                case "PERFILES":
                    {
                        if (clsConnection.blnVentanasEnbebidas)
                        {
                            frmPerfiles objFormulario = new frmPerfiles();
                            cargaFormulario(objFormulario);
                        }
                        else
                        {
                            frmPerfiles objPerfiles = new frmPerfiles();
                            objPerfiles.Show();
                        }

                        break;
                    }

                case "USUARIOS":
                    {
                        if (clsConnection.blnVentanasEnbebidas)
                        {
                            frmUsuarios objFormulario = new frmUsuarios();
                            cargaFormulario(objFormulario);
                        }
                        else
                        {
                            frmUsuarios objUsuarios = new frmUsuarios();
                            objUsuarios.Show();
                        }

                        break;
                    }

                case "TIPO DOCUMENTO":
                    {
                        if (clsConnection.blnVentanasEnbebidas)
                        {
                            frmTipoDocumento objFormulario = new frmTipoDocumento();
                            cargaFormulario(objFormulario);
                        }
                        else
                        {
                            frmUsuarios objFormulario = new frmUsuarios();
                            objFormulario.Show();
                        }

                        break;
                    }

                case "TIPO CLIENTE":
                    {
                        if (clsConnection.blnVentanasEnbebidas)
                        {
                            frmTipoCliente objFormulario = new frmTipoCliente();
                            cargaFormulario(objFormulario);
                        }
                        else
                        {
                            frmTipoCliente objFormulario = new frmTipoCliente();
                            objFormulario.Show();
                        }

                        break;
                    }

                case "UNIDAD MEDIDA":
                    {
                        if (clsConnection.blnVentanasEnbebidas)
                        {
                            frmUnidadMedida objFormulario = new frmUnidadMedida();
                            cargaFormulario(objFormulario);
                        }
                        else
                        {
                            frmUnidadMedida objFormulario = new frmUnidadMedida();
                            objFormulario.Show();
                        }

                        break;
                    }

                case "GENEROS":
                    {
                        if (clsConnection.blnVentanasEnbebidas)
                        {
                            frmGeneros objFormulario = new frmGeneros();
                            cargaFormulario(objFormulario);
                        }
                        else
                        {
                            frmGeneros objFormulario = new frmGeneros();
                            objFormulario.Show();
                        }

                        break;
                    }

                case "FORMA INGRESO":
                    {
                        if (clsConnection.blnVentanasEnbebidas)
                        {
                            frmFormasIngreso objFormulario = new frmFormasIngreso();
                            cargaFormulario(objFormulario);
                        }
                        else
                        {
                            frmFormasIngreso objFormulario = new frmFormasIngreso();
                            objFormulario.Show();
                        }

                        break;
                    }

                case "ESTADO CIVIL":
                    {
                        if (clsConnection.blnVentanasEnbebidas)
                        {
                            frmEstadoCivil objFormulario = new frmEstadoCivil();
                            cargaFormulario(objFormulario);
                        }
                        else
                        {
                            frmEstadoCivil objFormulario = new frmEstadoCivil();
                            objFormulario.Show();
                        }

                        break;
                    }

                case "MAESTRA ESTADOS ACTIVIDAD":
                    {
                        if (clsConnection.blnVentanasEnbebidas)
                        {
                            frmMaestraEsatdosActividad objFormulario = new frmMaestraEsatdosActividad();
                            cargaFormulario(objFormulario);
                        }
                        else
                        {
                            frmMaestraEsatdosActividad objFormulario = new frmMaestraEsatdosActividad();
                            objFormulario.Show();
                        }

                        break;
                    }

                case "CAMPAÑAS":
                    {
                        if (clsConnection.blnVentanasEnbebidas)
                        {
                            frmCampanas objFormulario = new frmCampanas();
                            cargaFormulario(objFormulario);
                        }
                        else
                        {
                            frmCampanas objFormulario = new frmCampanas();
                            objFormulario.Show();
                        }

                        break;
                    }

                case "PAISES":
                    {
                        if (clsConnection.blnVentanasEnbebidas)
                        {
                            frmPaises objFormulario = new frmPaises();
                            cargaFormulario(objFormulario);
                        }
                        else
                        {
                            frmPaises objFormulario = new frmPaises();
                            objFormulario.Show();
                        }

                        break;
                    }

                case "DEPARTAMENTOS":
                    {
                        if (clsConnection.blnVentanasEnbebidas)
                        {
                            frmDepartamentos objFormulario = new frmDepartamentos();
                            cargaFormulario(objFormulario);
                        }
                        else
                        {
                            frmDepartamentos objFormulario = new frmDepartamentos();
                            objFormulario.Show();
                        }

                        break;
                    }

                case "CIUDADES":
                    {
                        if (clsConnection.blnVentanasEnbebidas)
                        {
                            frmCiudades objFormulario = new frmCiudades();
                            cargaFormulario(objFormulario);
                        }
                        else
                        {
                            frmCiudades objFormulario = new frmCiudades();
                            objFormulario.Show();
                        }

                        break;
                    }

                case "CLASE RESPONSABLE":
                    {
                        if (clsConnection.blnVentanasEnbebidas)
                        {
                            frmClaseResponsable objFormulario = new frmClaseResponsable();
                            cargaFormulario(objFormulario);
                        }
                        else
                        {
                            frmClaseResponsable objFormulario = new frmClaseResponsable();
                            objFormulario.Show();
                        }

                        break;
                    }

                case "RESPONSABLES":
                    {
                        if (clsConnection.blnVentanasEnbebidas)
                        {
                            frmRespTerritorio objFormulario = new frmRespTerritorio();
                            cargaFormulario(objFormulario);
                        }
                        else
                        {
                            frmRespTerritorio objFormulario = new frmRespTerritorio();
                            objFormulario.Show();
                        }

                        break;
                    }

                case "REGIONES":
                    {
                        if (clsConnection.blnVentanasEnbebidas)
                        {
                            frmRegiones objFormulario = new frmRegiones();
                            cargaFormulario(objFormulario);
                        }
                        else
                        {
                            frmRegiones objFormulario = new frmRegiones();
                            objFormulario.Show();
                        }

                        break;
                    }

                case "ZONAS":
                    {
                        if (clsConnection.blnVentanasEnbebidas)
                        {
                            frmZonas objFormulario = new frmZonas();
                            cargaFormulario(objFormulario);
                        }
                        else
                        {
                            frmZonas objFormulario = new frmZonas();
                            objFormulario.Show();
                        }

                        break;
                    }

                case "SECCIONES":
                    {
                        if (clsConnection.blnVentanasEnbebidas)
                        {
                            frmSecciones objFormulario = new frmSecciones();
                            cargaFormulario(objFormulario);
                        }
                        else
                        {
                            frmSecciones objFormulario = new frmSecciones();
                            objFormulario.Show();
                        }

                        break;
                    }

                case "TERRITORIOS":
                    {
                        if (clsConnection.blnVentanasEnbebidas)
                        {
                            frmTerritorios objFormulario = new frmTerritorios();
                            cargaFormulario(objFormulario);
                        }
                        else
                        {
                            frmTerritorios objFormulario = new frmTerritorios();
                            objFormulario.Show();
                        }

                        break;
                    }

                case "CONSULTA CLIENTES":
                    {
                        if (clsConnection.blnVentanasEnbebidas)
                        {
                            frmClientes objFormulario = new frmClientes();
                            cargaFormulario(objFormulario);
                        }
                        else
                        {
                            frmClientes objFormulario = new frmClientes();
                            objFormulario.Show();
                        }

                        break;
                    }

                    //case "REGISTRO CLIENTES":
                    //    {
                    //        if (clsConnection.blnVentanasEnbebidas)
                    //        {
                    //            frmRegistroClientes objClientes = new frmRegistroClientes();
                    //            cargaFormulario(objClientes);
                    //        }
                    //        else
                    //        {
                    //            frmRegistroClientes objFormulario = new frmRegistroClientes();
                    //            objFormulario.Show();
                    //        }

                    //        break;
                    //    }

                    //case "PRODUCTOS":
                    //    {
                    //        if (clsConnection.blnVentanasEnbebidas)
                    //        {
                    //            frmMaestraProductos objClientes = new frmMaestraProductos();
                    //            cargaFormulario(objClientes);
                    //        }
                    //        else
                    //        {
                    //            frmMaestraProductos objFormulario = new frmMaestraProductos();
                    //            objFormulario.Show();
                    //        }

                    //        break;
                    //    }

                    //case "ADMIN LISTAS":
                    //    {
                    //        if (clsConnection.blnVentanasEnbebidas)
                    //        {
                    //            frmListaPrecios objClientes = new frmListaPrecios();
                    //            cargaFormulario(objClientes);
                    //        }
                    //        else
                    //        {
                    //            frmListaPrecios objFormulario = new frmListaPrecios();
                    //            objFormulario.Show();
                    //        }

                    //        break;
                    //    }

                    //case "LISTA PRECIOS PROD":
                    //    {
                    //        if (clsConnection.blnVentanasEnbebidas)
                    //        {
                    //            frmListaPrecioProducto objFormulario = new frmListaPrecioProducto();
                    //            cargaFormulario(objFormulario);
                    //        }
                    //        else
                    //        {
                    //            frmListaPrecioProducto objFormulario = new frmListaPrecioProducto();
                    //            objFormulario.Show();
                    //        }

                    //        break;
                    //    }

                    //case "ASIGNA MANUAL":
                    //    {
                    //        if (clsConnection.blnVentanasEnbebidas)
                    //        {
                    //            frmCodigoVenta objFormulario = new frmCodigoVenta();
                    //            cargaFormulario(objFormulario);
                    //        }
                    //        else
                    //        {
                    //            frmCodigoVenta objFormulario = new frmCodigoVenta();
                    //            objFormulario.Show();
                    //        }

                    //        break;
                    //    }

                    //case "CARGA MASIVA":
                    //    {
                    //        if (clsConnection.blnVentanasEnbebidas)
                    //        {
                    //            frmCargaCodVentaMasivo objFormulario = new frmCargaCodVentaMasivo();
                    //            cargaFormulario(objFormulario);
                    //        }
                    //        else
                    //        {
                    //            frmCargaCodVentaMasivo objFormulario = new frmCargaCodVentaMasivo();
                    //            objFormulario.Show();
                    //        }

                    //        break;
                    //    }

                    //case "PEDIDOS":
                    //    {
                    //        if (clsConnection.blnVentanasEnbebidas)
                    //        {
                    //            frmDigitaPedidos objFormulario = new frmDigitaPedidos();
                    //            cargaFormulario(objFormulario);
                    //        }
                    //        else
                    //        {
                    //            frmDigitaPedidos objFormulario = new frmDigitaPedidos();
                    //            objFormulario.Show();
                    //        }

                    //        break;
                    //    }

                    //case "ESCALAS DESCUENTO":
                    //    {
                    //        if (clsConnection.blnVentanasEnbebidas)
                    //        {
                    //            frmEscalasDescuento objFormulario = new frmEscalasDescuento();
                    //            cargaFormulario(objFormulario);
                    //        }
                    //        else
                    //        {
                    //            frmEscalasDescuento objFormulario = new frmEscalasDescuento();
                    //            objFormulario.Show();
                    //        }

                    //        break;
                    //    }

                    //case "OFERTAS SIMPLES":
                    //    {
                    //        if (clsConnection.blnVentanasEnbebidas)
                    //        {
                    //            frmOfertaSimple objFormulario = new frmOfertaSimple();
                    //            cargaFormulario(objFormulario);
                    //        }
                    //        else
                    //        {
                    //            frmOfertaSimple objFormulario = new frmOfertaSimple();
                    //            objFormulario.Show();
                    //        }

                    //        break;
                    //    }

                    //case "COMBOS":
                    //    {
                    //        if (clsConnection.blnVentanasEnbebidas)
                    //        {
                    //            frmCargaCombos objFormulario = new frmCargaCombos();
                    //            cargaFormulario(objFormulario);
                    //        }
                    //        else
                    //        {
                    //            frmCargaCombos objFormulario = new frmCargaCombos();
                    //            objFormulario.Show();
                    //        }

                    //        break;
                    //    }

                    //case "EQUIVALENCIAS":
                    //    {
                    //        if (clsConnection.blnVentanasEnbebidas)
                    //        {
                    //            frmEquivalencias objFormulario = new frmEquivalencias();
                    //            cargaFormulario(objFormulario);
                    //        }
                    //        else
                    //        {
                    //            frmEquivalencias objFormulario = new frmEquivalencias();
                    //            objFormulario.Show();
                    //        }

                    //        break;
                    //    }

                    //case "VENTAS":
                    //    {
                    //        if (clsConnection.blnVentanasEnbebidas)
                    //        {
                    //            frmConcursosVentas objFormulario = new frmConcursosVentas();
                    //            cargaFormulario(objFormulario);
                    //        }
                    //        else
                    //        {
                    //            frmConcursosVentas objFormulario = new frmConcursosVentas();
                    //            objFormulario.Show();
                    //        }

                    //        break;
                    //    }

                    //case "FLETE X CIUDAD":
                    //    {
                    //        if (clsConnection.blnVentanasEnbebidas)
                    //        {
                    //            frmFleteCiudad objFormulario = new frmFleteCiudad();
                    //            cargaFormulario(objFormulario);
                    //        }
                    //        else
                    //        {
                    //            frmFleteCiudad objFormulario = new frmFleteCiudad();
                    //            objFormulario.Show();
                    //        }

                    //        break;
                    //    }

                    //case "CARGA FLETES":
                    //    {
                    //        if (clsConnection.blnVentanasEnbebidas)
                    //        {
                    //            frmCargaFletesCiudad objFormulario = new frmCargaFletesCiudad();
                    //            cargaFormulario(objFormulario);
                    //        }
                    //        else
                    //        {
                    //            frmCargaFletesCiudad objFormulario = new frmCargaFletesCiudad();
                    //            objFormulario.Show();
                    //        }

                    //        break;
                    //    }

                    //case "VARIABLES ENTORNO":
                    //    {
                    //        if (clsConnection.blnVentanasEnbebidas)
                    //        {
                    //            frmVariablesEntorno objFormulario = new frmVariablesEntorno();
                    //            cargaFormulario(objFormulario);
                    //        }
                    //        else
                    //        {
                    //            frmVariablesEntorno objFormulario = new frmVariablesEntorno();
                    //            objFormulario.Show();
                    //        }

                    //        break;
                    //    }
            }
        }


        private void cargaFormulario(Form fh)
        {
            pnlFormulario.Controls.Clear();
            fh.TopLevel = false;
            fh.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            pnlFormulario.Controls.Add(fh);
            pnlFormulario.Tag = fh;
            fh.Show();
        }

        private void frmPrincipal_Activated(object sender, EventArgs e)
        {
            treeMenu.Enabled = true;
        }


        private void treeMenu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                e.Handled = true;
                muestraFormularios(treeMenu.SelectedNode.Text);
            }
        }

        private void treeMenu_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            muestraFormularios(e.Node.Text);
        }

        private void PerfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsConnection.blnVentanasEnbebidas)
            {
                frmPerfiles objFormulario = new frmPerfiles();
                cargaFormulario(objFormulario);
            }
            else
            {
                frmPerfiles objFormulario = new frmPerfiles();
                objFormulario.Show();
            }
        }

        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (clsConnection.blnVentanasEnbebidas)
            {
                frmUsuarios objFormulario = new frmUsuarios();
                cargaFormulario(objFormulario);
            }
            else
            {
                frmUsuarios objFormulario = new frmUsuarios();
                objFormulario.Show();
            }

        }

        private void TipoDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsConnection.blnVentanasEnbebidas)
            {
                frmTipoDocumento objFormulario = new frmTipoDocumento();
                cargaFormulario(objFormulario);
            }
            else
            {
                frmTipoDocumento objFormulario = new frmTipoDocumento();
                objFormulario.Show();
            }
        }

        private void TipoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsConnection.blnVentanasEnbebidas)
            {
                frmTipoCliente objFormulario = new frmTipoCliente();
                cargaFormulario(objFormulario);
            }
            else
            {
                frmTipoCliente objFormulario = new frmTipoCliente();
                objFormulario.Show();
            }
        }

        private void UnidadesMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsConnection.blnVentanasEnbebidas)
            {
                frmUnidadMedida objFormulario = new frmUnidadMedida();
                cargaFormulario(objFormulario);
            }
            else
            {
                frmUnidadMedida objFormulario = new frmUnidadMedida();
                objFormulario.Show();
            }
        }

        private void GenerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsConnection.blnVentanasEnbebidas)
            {
                frmGeneros objFormulario = new frmGeneros();
                cargaFormulario(objFormulario);
            }
            else
            {
                frmGeneros objFormulario = new frmGeneros();
                objFormulario.Show();
            }
        }

        private void FormaDeIngresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsConnection.blnVentanasEnbebidas)
            {
                frmFormasIngreso objFormulario = new frmFormasIngreso();
                cargaFormulario(objFormulario);
            }
            else
            {
                frmFormasIngreso objFormulario = new frmFormasIngreso();
                objFormulario.Show();
            }
        }

        private void EstadoCivilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsConnection.blnVentanasEnbebidas)
            {
                frmEstadoCivil objFormulario = new frmEstadoCivil();
                cargaFormulario(objFormulario);
            }
            else
            {
                frmEstadoCivil objFormulario = new frmEstadoCivil();
                objFormulario.Show();
            }
        }

        private void MaestraEstadosDeActividadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsConnection.blnVentanasEnbebidas)
            {
                frmMaestraEsatdosActividad objFormulario = new frmMaestraEsatdosActividad();
                cargaFormulario(objFormulario);
            }
            else
            {
                frmMaestraEsatdosActividad objFormulario = new frmMaestraEsatdosActividad();
                objFormulario.Show();
            }
        }

        private void CampañasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsConnection.blnVentanasEnbebidas)
            {
                frmCampanas objFormulario = new frmCampanas();
                cargaFormulario(objFormulario);
            }
            else
            {
                frmCampanas objFormulario = new frmCampanas();
                objFormulario.Show();
            }
        }

        private void PaisesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsConnection.blnVentanasEnbebidas)
            {
                frmPaises objFormulario = new frmPaises();
                cargaFormulario(objFormulario);
            }
            else
            {
                frmPaises objFormulario = new frmPaises();
                objFormulario.Show();
            }
        }

        private void DepartamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsConnection.blnVentanasEnbebidas)
            {
                frmDepartamentos objFormulario = new frmDepartamentos();
                cargaFormulario(objFormulario);
            }
            else
            {
                frmDepartamentos objFormulario = new frmDepartamentos();
                objFormulario.Show();
            }
        }

        private void MunicipiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsConnection.blnVentanasEnbebidas)
            {
                frmCiudades objFormulario = new frmCiudades();
                cargaFormulario(objFormulario);
            }
            else
            {
                frmCiudades objFormulario = new frmCiudades();
                objFormulario.Show();
            }
        }

        private void ClaseResponsablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsConnection.blnVentanasEnbebidas)
            {
                frmClaseResponsable objFormulario = new frmClaseResponsable();
                cargaFormulario(objFormulario);
            }
            else
            {
                frmClaseResponsable objFormulario = new frmClaseResponsable();
                objFormulario.Show();
            }
        }

        private void ResponsablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsConnection.blnVentanasEnbebidas)
            {
                frmRespTerritorio objFormulario = new frmRespTerritorio();
                cargaFormulario(objFormulario);
            }
            else
            {
                frmRespTerritorio objFormulario = new frmRespTerritorio();
                objFormulario.Show();
            }
        }

        private void RegionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsConnection.blnVentanasEnbebidas)
            {
                frmRegiones objFormulario = new frmRegiones();
                cargaFormulario(objFormulario);
            }
            else
            {
                frmRegiones objFormulario = new frmRegiones();
                objFormulario.Show();
            }
        }

        private void ZonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsConnection.blnVentanasEnbebidas)
            {
                frmZonas objFormulario = new frmZonas();
                cargaFormulario(objFormulario);
            }
            else
            {
                frmZonas objFormulario = new frmZonas();
                objFormulario.Show();
            }
        }

        private void SeccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsConnection.blnVentanasEnbebidas)
            {
                frmSecciones objFormulario = new frmSecciones();
                cargaFormulario(objFormulario);
            }
            else
            {
                frmSecciones objFormulario = new frmSecciones();
                objFormulario.Show();
            }
        }

        private void TerritoriosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (clsConnection.blnVentanasEnbebidas)
            {
                frmTerritorios objFormulario = new frmTerritorios();
                cargaFormulario(objFormulario);
            }
            else
            {
                frmTerritorios objFormulario = new frmTerritorios();
                objFormulario.Show();
            }
        }

        private void ClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsConnection.blnVentanasEnbebidas)
            {
                frmClientes objFormulario = new frmClientes();
                cargaFormulario(objFormulario);
            }
            else
            {
                frmClientes objFormulario = new frmClientes();
                objFormulario.Show();
            }
        }
    }
}