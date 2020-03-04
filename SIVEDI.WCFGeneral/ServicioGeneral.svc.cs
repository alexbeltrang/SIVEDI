using SIVEDI.Cifrado;
using SIVEDI.Clases;
using SIVEDI.Clases.TABLAS;
using SIVEDI.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SIVEDI.WCFGeneral
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioGeneral" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioGeneral.svc o ServicioGeneral.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioGeneral : IServicioGeneral
    {
        public LoginUsuario ingresaAplicativo(string strUser, string strPassword)
        {
            LoginUsuario loginUsuario = new LoginUsuario();
            FunctionsEncrip Encripta = new FunctionsEncrip();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.getValidaUsuarioIngresaAplciativo("SPR_GET_USUARIO_ID", Encripta.Cifrado(1, strUser), Encripta.Cifrado(1, strPassword));
            loginUsuario = data.ExecuteQuery<LoginUsuario>(SP);
            return loginUsuario;
        }

        public List<moduloPadre> getModuloPadre(int intCodigoUsuario)
        {
            List<moduloPadre> moduloPadre = new List<moduloPadre>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.getModuloPadre("SPR_GET_MODULO_PADRE", intCodigoUsuario);
            moduloPadre = data.ExecuteQueryList<moduloPadre>(SP);
            return moduloPadre;
        }

        public List<moduloHijo> getModuloHijo(int intCodigoUsuario, int intCodigoPadre)
        {
            List<moduloHijo> moduloHijo = new List<moduloHijo>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.getModuloHijo("SPR_GET_MODULO_HIJO", intCodigoUsuario, intCodigoPadre);
            moduloHijo = data.ExecuteQueryList<moduloHijo>(SP);
            return moduloHijo;
        }

        public List<perfiles> getPerfiles(int intOpcion, int intCodigoPerfil)
        {
            List<perfiles> perfiles = new List<perfiles>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.getPerfiles("SPR_GET_PERFIL", intOpcion, intCodigoPerfil);
            perfiles = data.ExecuteQueryList<perfiles>(SP);
            return perfiles;
        }

        public int insPerfiles(int intOpcion, perfiles perfil)
        {
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.insPerfiles("SPR_IU_PERFIL", perfil);
            int Perfil = data.ExecuteInsert(SP, "PO_NRESULT");
            return Perfil;
        }

        #region Manejo Usuarios
        public List<usuariosTabla> getUsuarios(int intOpcion, string LoginUsuario)
        {
            List<usuariosTabla> ListUsuarios = new List<usuariosTabla>();
            FunctionsEncrip Encripta = new FunctionsEncrip();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.getUsuarios("SPR_GET_USUARIO", intOpcion, LoginUsuario != null ? Encripta.Cifrado(1, LoginUsuario) : LoginUsuario);
            ListUsuarios = data.ExecuteQueryList<usuariosTabla>(SP);

            foreach (usuariosTabla user in ListUsuarios)
            {
                if (user.LOGIN != null)
                {
                    user.LOGIN = Encripta.Cifrado(2, user.LOGIN);
                }
            }
            return ListUsuarios;
        }

        public int insUsuarios(usuarios usuarioModel)
        {
            FunctionsEncrip Cifrado = new FunctionsEncrip();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            usuarioModel.LOGIN = Cifrado.Cifrado(1, usuarioModel.LOGIN);
            usuarioModel.PASSWORD = Cifrado.Cifrado(1, usuarioModel.PASSWORD);

            StoreProcedure SP = spRequestUsuario.insUsuarios("SPR_IU_USUARIO", usuarioModel);
            int Perfil = data.ExecuteInsert(SP, "PO_NEFECTIVO");
            return Perfil;
        }
        #endregion

        #region Tipos de Documento
        public List<tipoDocumentoTabla> getTiposDocumento(int intOpcion, int intCodigoTipoDocumento)
        {
            List<tipoDocumentoTabla> ListTiposDocumento = new List<tipoDocumentoTabla>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.getTiposDocumento("SPR_GET_TIPO_DOCUMENTO", intOpcion, intCodigoTipoDocumento);
            ListTiposDocumento = data.ExecuteQueryList<tipoDocumentoTabla>(SP);

            return ListTiposDocumento;
        }

        public int insTipoDocumento(TipoDocumento TipoDocumento)
        {
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.insTiposDocumento("SPR_IU_TIPO_DOCUMENTO", TipoDocumento);
            int tipoDocumento = data.ExecuteInsert(SP, "PO_NRESULT");
            return tipoDocumento;
        }
        #endregion

        #region Tipo Cliente

        public List<TipoClienteTabla> getTipoCliente(int intOpcion, int intCodigoTipoCliente)
        {
            List<TipoClienteTabla> ListTipoCliente = new List<TipoClienteTabla>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.getTipoCliente("SPR_GET_TIPO_CLIENTE", intOpcion, intCodigoTipoCliente);
            ListTipoCliente = data.ExecuteQueryList<TipoClienteTabla>(SP);

            return ListTipoCliente;
        }

        public TipoCliente getTipoClienteTabla(int intOpcion, int intCodigoTipoCliente)
        {
            TipoCliente ListTipoCliente = new TipoCliente();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.getTipoCliente("SPR_GET_TIPO_CLIENTE", intOpcion, intCodigoTipoCliente);
            ListTipoCliente = data.ExecuteQuery<TipoCliente>(SP);

            return ListTipoCliente;
        }

        public int insTipoCliente(TipoCliente tipoCliente)
        {
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.insTiposCliente("SPR_IU_TIPO_CLIENTE", tipoCliente);
            int tipoDocumento = data.ExecuteInsert(SP, "PO_NRESULT");
            return tipoDocumento;
        }
        #endregion

        #region Unidad Medida

        public List<UnidadesMedidaTabla> getUnidadMedida(int intOpcion, int intCodigoUnidadMedida)
        {
            List<UnidadesMedidaTabla> ListUnidadMedida = new List<UnidadesMedidaTabla>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getUnidadMedida("SPR_GET_UNIDAD_MEDIDA", intOpcion, intCodigoUnidadMedida);
            ListUnidadMedida = data.ExecuteQueryList<UnidadesMedidaTabla>(SP);
            return ListUnidadMedida;
        }

        public int insUnidadMedida(UnidadMedida unidadMedida)
        {
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.insUnidadMedida("SPR_IU_UNIDAD_MEDIDA", unidadMedida);
            int CodigounidadMedida = data.ExecuteInsert(SP, "PO_NRESULT");
            return CodigounidadMedida;
        }
        #endregion

        #region Generos

        public List<GenerosTabla> GetGeneros(int intOpcion, int intCodigoGenero)
        {
            List<GenerosTabla> ListGeneros = new List<GenerosTabla>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getGeneros("SPR_GET_GENERO", intOpcion, intCodigoGenero);
            ListGeneros = data.ExecuteQueryList<GenerosTabla>(SP);
            return ListGeneros;
        }

        public int insGeneros(Generos generos)
        {
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.insGeneros("SPR_IU_GENERO", generos);
            int CodigoGenero = data.ExecuteInsert(SP, "PO_NRESULT");
            return CodigoGenero;
        }
        #endregion

        #region Formas de Ingreso

        public List<FormasIngresoTabla> getformasIngreso(int intOpcion, int intCodigoFormaIngreso)
        {
            List<FormasIngresoTabla> ListFormasIngreso = new List<FormasIngresoTabla>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getFormasIngreso("SPR_GET_FORMA_INGRESO", intOpcion, intCodigoFormaIngreso);
            ListFormasIngreso = data.ExecuteQueryList<FormasIngresoTabla>(SP);
            return ListFormasIngreso;
        }

        public int insFormasIngreso(formasIngreso formasIngreso)
        {
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.insFormasIngreso("SPR_IU_FORMA_INGRESO", formasIngreso);
            int CodigoForma = data.ExecuteInsert(SP, "PO_NRESULT");
            return CodigoForma;
        }
        #endregion

        #region Estado Civil

        public List<EstadoCivilTabla> getEstadoCivil(int intOpcion, int intCodigoEstadoCivil)
        {
            List<EstadoCivilTabla> ListEstadoCivilTabla = new List<EstadoCivilTabla>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getEstadoCivil("SPR_GET_ESTADO_CIVIL", intOpcion, intCodigoEstadoCivil);
            ListEstadoCivilTabla = data.ExecuteQueryList<EstadoCivilTabla>(SP);
            return ListEstadoCivilTabla;
        }

        public int insEstadoCivil(EstadoCivil estadoCivil)
        {
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.insEstadoCivil("SPR_IU_ESTADO_CIVIL", estadoCivil);
            int codigoEstado = data.ExecuteInsert(SP, "PO_NRESULT");
            return codigoEstado;
        }
        #endregion

        #region Estado Actividad

        public List<EstadoActividadTabla> getEstadoActividad(int intOpcion, int intCodigoEstadoActividad)
        {
            List<EstadoActividadTabla> ListEstadoActividadTabla = new List<EstadoActividadTabla>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getEstadoActividad("SPR_GET_ESTADO_ACTIVIDAD", intOpcion, intCodigoEstadoActividad);
            ListEstadoActividadTabla = data.ExecuteQueryList<EstadoActividadTabla>(SP);
            return ListEstadoActividadTabla;
        }

        public List<EstadoActividadOfertas> getEstadoActividadOfertas(int intOpcion, int intCodigoOferta)
        {
            List<EstadoActividadOfertas> ListEstadoActividadOfertas = new List<EstadoActividadOfertas>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getEstadoActividadOfertas("SPR_GET_ESTADO_ACTI_OFERTA", intOpcion, intCodigoOferta);
            ListEstadoActividadOfertas = data.ExecuteQueryList<EstadoActividadOfertas>(SP);
            return ListEstadoActividadOfertas;
        }
        public EstadoActividad getEstadoActividadCamposTabla(int intOpcion, int intCodigoEstadoActividad)
        {
            EstadoActividad ListEstadoActividadCamposTabla = new EstadoActividad();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getEstadoActividad("SPR_GET_ESTADO_ACTIVIDAD", intOpcion, intCodigoEstadoActividad);
            ListEstadoActividadCamposTabla = data.ExecuteQuery<EstadoActividad>(SP);
            return ListEstadoActividadCamposTabla;
        }

        public int insEstadoActividad(EstadoActividad estadoActividad)
        {
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.insEstadoActividad("SPR_IU_ESTADO_ACTIVIDAD", estadoActividad);
            int codigoEstadoActividad = data.ExecuteInsert(SP, "PO_NRESULT");
            return codigoEstadoActividad;
        }


        #endregion

        #region Campañas
        public List<CampanasTabla> getCampanas(int intOpcion, int intCodigoCampana)
        {
            List<CampanasTabla> ListcampanasTabla = new List<CampanasTabla>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getCampanas("SPR_GET_CAMPANA", intOpcion, intCodigoCampana);
            ListcampanasTabla = data.ExecuteQueryList<CampanasTabla>(SP);
            return ListcampanasTabla;
        }

        public int insCampanas(campanas Campanas)
        {
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.insCampanas("SPR_IU_CAMPANA", Campanas);
            int codigoCampana = data.ExecuteInsert(SP, "PO_NRESULT");
            return codigoCampana;
        }
        #endregion

        #region Paises
        public List<PaisTabla> getPaises(int intOpcion, int intCodigoPais)
        {
            List<PaisTabla> ListPaisTabla = new List<PaisTabla>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getPaises("SPR_GET_PAIS", intOpcion, intCodigoPais);
            ListPaisTabla = data.ExecuteQueryList<PaisTabla>(SP);
            return ListPaisTabla;
        }

        public int insPaises(Pais pais)
        {
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.insPais("SPR_IU_PAIS", pais);
            int codigoPais = data.ExecuteInsert(SP, "PO_NRESULT");
            return codigoPais;
        }
        #endregion

        #region Departamentos
        public List<DepartamentoTabla> getDepartamentos(int intOpcion, int intCodigoPais, int intCodigoDepartamento)
        {
            List<DepartamentoTabla> ListDepartamentoTabla = new List<DepartamentoTabla>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getDepartamento("SPR_GET_DEPARTAMENTO", intOpcion, intCodigoPais, intCodigoDepartamento);
            ListDepartamentoTabla = data.ExecuteQueryList<DepartamentoTabla>(SP);
            return ListDepartamentoTabla;
        }

        public Departamentos getDepartamentoTabla(int intOpcion, int intCodigoPais, int intCodigoDepartamento)
        {
            Departamentos ListDepartamentosCamposTabla = new Departamentos();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getDepartamento("SPR_GET_DEPARTAMENTO", intOpcion, intCodigoPais, intCodigoDepartamento);
            ListDepartamentosCamposTabla = data.ExecuteQuery<Departamentos>(SP);
            return ListDepartamentosCamposTabla;
        }


        public int insDepartamento(Departamentos departamentos)
        {
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.insDepartamento("SPR_IU_DEPARTAMENTO", departamentos);
            int codigoDepto = data.ExecuteInsert(SP, "PO_NRESULT");
            return codigoDepto;
        }
        #endregion

        #region Ciudades
        public List<CiudadesTabla> getCiudades(int intOpcion, int intCodigoDepartamento, int intCodigoCiudad)
        {
            List<CiudadesTabla> ListCiudadesTabla = new List<CiudadesTabla>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getCiudades("SPR_GET_CIUDADES", intOpcion, intCodigoDepartamento, intCodigoCiudad);
            ListCiudadesTabla = data.ExecuteQueryList<CiudadesTabla>(SP);
            return ListCiudadesTabla;
        }

        public Ciudades getCiudadesTabla(int intOpcion, int intCodigoDepartamento, int intCodigoCiudad)
        {
            Ciudades LisCiudadesCamposTabla = new Ciudades();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getCiudades("SPR_GET_CIUDADES", intOpcion, intCodigoDepartamento, intCodigoCiudad);
            LisCiudadesCamposTabla = data.ExecuteQuery<Ciudades>(SP);
            return LisCiudadesCamposTabla;
        }


        public int insCiudades(Ciudades ciudades)
        {
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.insCiudades("SPR_IU_CIUDAD", ciudades);
            int codigoCiudad = data.ExecuteInsert(SP, "PO_NRESULT");
            return codigoCiudad;
        }
        #endregion

        #region Clase Responsable

        public List<ClaseResponsableTabla> getClaseResponsable(int intOpcion, int intCodigoClaseResponsable)
        {
            List<ClaseResponsableTabla> ListClaseResponsableTabla = new List<ClaseResponsableTabla>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getClaseResponsable("SPR_GET_CLASE_RESPONSABLE", intOpcion, intCodigoClaseResponsable);
            ListClaseResponsableTabla = data.ExecuteQueryList<ClaseResponsableTabla>(SP);
            return ListClaseResponsableTabla;
        }

        public int insClaseResponsable(ClaseResponsable claseResponsable)
        {
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.insClaseResponsable("SPR_IU_CLASE_RESPONSABLE", claseResponsable);
            int CodigoClase = data.ExecuteInsert(SP, "PO_NRESULT");
            return CodigoClase;
        }
        #endregion

        #region Responsable Territorio
        public List<ResponsableTerritorioTabla> getResponsableTerritorio(int intOpcion)
        {
            List<ResponsableTerritorioTabla> ListResponsableTerritorioTabla = new List<ResponsableTerritorioTabla>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getResponsableTerritorio("SPR_GET_RESPONSABLE", intOpcion);
            ListResponsableTerritorioTabla = data.ExecuteQueryList<ResponsableTerritorioTabla>(SP);
            return ListResponsableTerritorioTabla;
        }
        public List<ResponsableTerritorioFiltro> getResponsableFiltro(string strIdentificacion, string strNombreResponsable)
        {
            List<ResponsableTerritorioFiltro> ListResponsableTerritorioFiltro = new List<ResponsableTerritorioFiltro>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getResponsableFiltro("SPR_GET_RESPONSABLE_FILTRO", strIdentificacion, strNombreResponsable);
            ListResponsableTerritorioFiltro = data.ExecuteQueryList<ResponsableTerritorioFiltro>(SP);
            return ListResponsableTerritorioFiltro;
        }
        public int insResponsableTerritorio(ResponsableTerritorio responsableTerritorio)
        {
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.insResponsableTerritorio("SPR_IU_RESPONSABLE", responsableTerritorio);
            int CodigoResponsable = data.ExecuteInsert(SP, "PO_NRESULT");
            return CodigoResponsable;
        }

        #endregion

        #region Regionales
        public List<RegionalesTabla> getRegionales(int intOpcion, int intCodigoRegional, int intCodigoPais)
        {
            List<RegionalesTabla> ListRegionalesTabla = new List<RegionalesTabla>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getRegionales("SPR_GET_REGIONAL", intOpcion, intCodigoRegional, intCodigoPais);
            ListRegionalesTabla = data.ExecuteQueryList<RegionalesTabla>(SP);
            return ListRegionalesTabla;
        }
        public int insRegionales(Regionales regionales)
        {
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.insRegionales("SPR_IU_REGIONAL", regionales);
            int codigoRegional = data.ExecuteInsert(SP, "PO_NRESULT");
            return codigoRegional;
        }
        #endregion

        #region Zonas
        public List<ZonasTabla> getZonas(int intOpcion, string strCodigoRegional, string strCodigoZona)
        {
            List<ZonasTabla> ListZonasTabla = new List<ZonasTabla>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getZonas("SPR_GET_ZONA", intOpcion, strCodigoRegional, strCodigoZona);
            ListZonasTabla = data.ExecuteQueryList<ZonasTabla>(SP);
            return ListZonasTabla;
        }

        public List<ZonasTabla> getZonasEscalaDescuento(int intOpcion, int intTipoCliente)
        {
            List<ZonasTabla> ListZonasTabla = new List<ZonasTabla>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getZonasEscalaDescuento("SPR_GET_ZONA_ESCALA_DESCUENTO", intOpcion, intTipoCliente);
            ListZonasTabla = data.ExecuteQueryList<ZonasTabla>(SP);
            return ListZonasTabla;
        }

        public List<ZonasTabla> getZonasOferta(int intCodigoOferta)
        {
            List<ZonasTabla> PedidosZonasTabla = new List<ZonasTabla>();
            SpRequest spRequest = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequest.getZonasOferta("SPR_GET_ZONAS_OFERTA", intCodigoOferta);
            PedidosZonasTabla = data.ExecuteQueryList<ZonasTabla>(SP);
            return PedidosZonasTabla;
        }

        public List<ZonasTabla> getZonasAsignadasOferta(int intCodigoOferta)
        {
            List<ZonasTabla> PedidosZonasTabla = new List<ZonasTabla>();
            SpRequest spRequest = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequest.getZonasAsignadasOferta("SPR_GET_ZONAS_ASIGNADAS_OFERTA", intCodigoOferta);
            PedidosZonasTabla = data.ExecuteQueryList<ZonasTabla>(SP);
            return PedidosZonasTabla;
        }
        public int insZonas(Zonas zonas)
        {
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.insZonas("SPR_IU_ZONA", zonas);
            int codigoZona = data.ExecuteInsert(SP, "PO_NRESULT");
            return codigoZona;
        }
        #endregion

        #region Secciones
        public List<SeccionesTabla> getSecciones(int intOpcion, string strCodigoZona, string strCodigoSeccion)
        {
            List<SeccionesTabla> ListSeccionesTabla = new List<SeccionesTabla>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getSecciones("SPR_GET_SECCION", intOpcion, strCodigoZona, strCodigoSeccion);
            ListSeccionesTabla = data.ExecuteQueryList<SeccionesTabla>(SP);
            return ListSeccionesTabla;
        }
        public SeccionFiltro getSeccionFiltro(int intOpcion, string strCodigoSeccion)
        {
            SeccionFiltro ListSeccionFiltro = new SeccionFiltro();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getSecciones("SPR_GET_SECCION", intOpcion, string.Empty, strCodigoSeccion);
            ListSeccionFiltro = data.ExecuteQuery<SeccionFiltro>(SP);
            return ListSeccionFiltro;
        }
        public int insSecciones(Secciones secciones)
        {
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.insSecciones("SPR_IU_SECCION", secciones);
            int codigoSeccion = data.ExecuteInsert(SP, "PO_NRESULT");
            return codigoSeccion;
        }
        #endregion

        #region Territorios
        public List<TerritorioTabla> getTerritorio(int intOpcion, string strCodigoSeccion, string strCodigoTerritorio)
        {
            List<TerritorioTabla> ListTerritorioTabla = new List<TerritorioTabla>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getTerritorios("SPR_GET_TERRITORIO", intOpcion, strCodigoSeccion, strCodigoTerritorio);
            ListTerritorioTabla = data.ExecuteQueryList<TerritorioTabla>(SP);
            return ListTerritorioTabla;
        }
        public TerritorioFiltro getTerritorioFiltro(int intOpcion, string strCodigoTerrirorio)
        {
            TerritorioFiltro ListTerritorioFiltro = new TerritorioFiltro();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getTerritorios("SPR_GET_TERRITORIO", intOpcion, string.Empty, strCodigoTerrirorio);
            ListTerritorioFiltro = data.ExecuteQuery<TerritorioFiltro>(SP);
            return ListTerritorioFiltro;
        }
        public int insTerritorio(Territorios territorios)
        {
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.insTerritorio("SPR_IU_TERRIRORIO", territorios);
            int codigoTerritorio = data.ExecuteInsert(SP, "PO_NRESULT");
            return codigoTerritorio;
        }
        #endregion

        #region Cuentas
        public ClienteConsultaTabla getConsultaCliente(string strIdentificacion)
        {
            ClienteConsultaTabla clienteConsultaTabla = new ClienteConsultaTabla();
            sp_Cuentas spRequestCuentas = new sp_Cuentas();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestCuentas.getConsultaClientes("SPR_GET_CONSULTA_CLIENTE", strIdentificacion);
            clienteConsultaTabla = data.ExecuteQuery<ClienteConsultaTabla>(SP);
            return clienteConsultaTabla;
        }

        public int insCliente(Cliente cliente)
        {
            sp_Cuentas SpCuentas = new sp_Cuentas();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = SpCuentas.insClientes("SPR_IU_CUENTA", cliente);
            int codigoSeccion = data.ExecuteInsert(SP, "PO_NRESULTADO");
            return codigoSeccion;
        }
        public int insReferenciasCliente(ReferenciaCliente referenciaCliente)
        {
            sp_Cuentas SpCuentas = new sp_Cuentas();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = SpCuentas.insReferenciasCliente("SPR_INS_REFERENCIA", referenciaCliente);
            int codigoSeccion = data.ExecuteInsert(SP, "PO_NRESULTADO");
            return codigoSeccion;
        }

        public List<ReferenciaClienteTabla> getReferenciaCliente(int intCodigoCliente)
        {
            List<ReferenciaClienteTabla> referenciaClienteTabla = new List<ReferenciaClienteTabla>();
            sp_Cuentas spRequestCuentas = new sp_Cuentas();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestCuentas.getReferenciaCliente("SPR_GET_REFERENCIA_CLIENTE", intCodigoCliente);
            referenciaClienteTabla = data.ExecuteQueryList<ReferenciaClienteTabla>(SP);
            return referenciaClienteTabla;
        }
        #endregion

        #region Clase Tipo Referencia

        public List<TipoReferencia> getTipoReferencia(int intOpcion, int intCodigoTipoReferencia)
        {
            List<TipoReferencia> ListTipoReferenciaTabla = new List<TipoReferencia>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getTipoReferencia("SPR_GET_TIPO_REFERENCIA", intOpcion, intCodigoTipoReferencia);
            ListTipoReferenciaTabla = data.ExecuteQueryList<TipoReferencia>(SP);
            return ListTipoReferenciaTabla;
        }


        #endregion

        #region Clase Formas de PAgo

        public List<FormasPago> getFormaPago(int intOpcion, int intCodigoformaPago)
        {
            List<FormasPago> ListFormasPago = new List<FormasPago>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getFormaPago("SPR_GET_FORMA_PAGO", intOpcion, intCodigoformaPago);
            ListFormasPago = data.ExecuteQueryList<FormasPago>(SP);
            return ListFormasPago;
        }


        #endregion

        #region Cupo Mínimo

        public CupoMinimo getCupoMinimoCredito()
        {
            CupoMinimo cupoMinimo = new CupoMinimo();
            sp_Cuentas spCuentas = new sp_Cuentas();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spCuentas.getCupoMinimoCredito("SPR_GET_CUPO_CREDITO");
            cupoMinimo = data.ExecuteQuery<CupoMinimo>(SP);
            return cupoMinimo;
        }


        #endregion

        #region Productos

        public List<ProductoTabla> getProductos(int intOpcion, int intCodigoProducto, string Referencia, int intCodigoVenta)
        {
            List<ProductoTabla> ListProductoTabla = new List<ProductoTabla>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getProductos("SPR_GET_MAESTRA_PRODUCTO", intOpcion, intCodigoProducto, Referencia, intCodigoVenta);
            ListProductoTabla = data.ExecuteQueryList<ProductoTabla>(SP);
            return ListProductoTabla;
        }

        public List<ProductoCodigoVenta> getProductosCodigoVenta(int intOpcion, string strCodigoVenta, int CodigoLista)
        {
            List<ProductoCodigoVenta> ListProductoCodigoVenta = new List<ProductoCodigoVenta>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestUsuario.getProductosCodigoVenta("SPR_GET_PRODUCTO_CODIGO_VENTA", intOpcion, strCodigoVenta, CodigoLista);
            ListProductoCodigoVenta = data.ExecuteQueryList<ProductoCodigoVenta>(SP);
            return ListProductoCodigoVenta;
        }

        public List<OfertaImpulsa> getDatosProdImpulsa(int intCodigoOferta)
        {
            List<OfertaImpulsa> PedidosOfertaImpulsa = new List<OfertaImpulsa>();
            sp_Liquidacion spRequestPedidos = new sp_Liquidacion();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestPedidos.getDatosProdImpulsa("SPR_GET_PROD_OFERTA_IMPULSA", intCodigoOferta);
            PedidosOfertaImpulsa = data.ExecuteQueryList<OfertaImpulsa>(SP);
            return PedidosOfertaImpulsa;
        }

        public int insProducto(Productos productos)
        {
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.insProductos("SPR_IU_PRODUCTO", productos);
            int codigoProducto = data.ExecuteInsert(SP, "PO_NEFECTIVO");
            return codigoProducto;
        }
        #endregion

        #region Tipos Producto
        public List<TipoProductoTabla> getTiposProducto(int intOpcion, string strTipoProducto)
        {
            List<TipoProductoTabla> ListTipoProducto = new List<TipoProductoTabla>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.getlistaTipoProducto("SPR_GET_TIPO_PRODUCTO", intOpcion, strTipoProducto);
            ListTipoProducto = data.ExecuteQueryList<TipoProductoTabla>(SP);

            return ListTipoProducto;
        }

        #endregion


        #region Consursos Ventas
        public List<ConcursoVentaTabla> getConcursoFiltro(int intCampanaEntrega, string strNombreConcruso)
        {
            List<ConcursoVentaTabla> ListTipoProducto = new List<ConcursoVentaTabla>();
            sp_Pedidos spRequestUsuario = new sp_Pedidos();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.getConcursoFiltro("SPR_GET_FILTRO_CONCURSOS_VENTA", intCampanaEntrega, strNombreConcruso);
            ListTipoProducto = data.ExecuteQueryList<ConcursoVentaTabla>(SP);

            return ListTipoProducto;
        }

        public List<ZonaConcursoVentas> getZonasConcursoVentas(int intCodigoConcurso)
        {
            List<ZonaConcursoVentas> ListTipoCliente = new List<ZonaConcursoVentas>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.getZonasConcursoVentas("SPR_GET_ZONAS_CONVTAS", intCodigoConcurso);
            ListTipoCliente = data.ExecuteQueryList<ZonaConcursoVentas>(SP);

            return ListTipoCliente;
        }

        public List<EstadoActividadConcursoVentas> getEstadoActividadConcursoVenta(int intCodigoConcurso)
        {
            List<EstadoActividadConcursoVentas> ListTipoCliente = new List<EstadoActividadConcursoVentas>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.getEstadoActividadConcursoVenta("SPR_GET_ESTADO_ACTIVIDAD_CONC_VENTA", intCodigoConcurso);
            ListTipoCliente = data.ExecuteQueryList<EstadoActividadConcursoVentas>(SP);

            return ListTipoCliente;
        }
        public List<EstadoActividadConcursoVentas> getListaEstadosActiDisponiblesConcursoVentas(int intCodigoConcurso)
        {
            List<EstadoActividadConcursoVentas> ListTipoCliente = new List<EstadoActividadConcursoVentas>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.getListaEstadosActiDisponiblesConcursoVentas("SPR_GET_ESTADOS_DISPONIBLE_CONC_VENTA", intCodigoConcurso);
            ListTipoCliente = data.ExecuteQueryList<EstadoActividadConcursoVentas>(SP);

            return ListTipoCliente;
        }

        public List<ZonasAsignadasConcursoVentasTabla> getZonasAsignadasConcuusoVentas(int intOpcion, int intCodigoConcurso, int intCodigoDetalle)
        {
            List<ZonasAsignadasConcursoVentasTabla> ListTipoProducto = new List<ZonasAsignadasConcursoVentasTabla>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.getZonasAsignadasConcuusoVentas("SPR_GET_DATOS_ZONAS_CONCURSO_VENTAS", intOpcion, intCodigoConcurso, intCodigoDetalle);
            ListTipoProducto = data.ExecuteQueryList<ZonasAsignadasConcursoVentasTabla>(SP);

            return ListTipoProducto;
        }
        public List<CampanasConcursoVentas> getCampanasConcursoVentas(int intCodigoConcurso)
        {
            List<CampanasConcursoVentas> ListTipoCliente = new List<CampanasConcursoVentas>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.getCampanasConcursoVentas("SPR_GET_CAMPANA_DISPONIBLE_CONCURSO_VENTAS", intCodigoConcurso);
            ListTipoCliente = data.ExecuteQueryList<CampanasConcursoVentas>(SP);

            return ListTipoCliente;
        }

        public List<CampanasConcursoVentas> getCampanasAsignadasConcursoVentas(int intCodigoConcurso)
        {
            List<CampanasConcursoVentas> ListTipoCliente = new List<CampanasConcursoVentas>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.getCampanasConcursoVentas("SPR_GET_CAMPANA_CONCURSO_VENTAS", intCodigoConcurso);
            ListTipoCliente = data.ExecuteQueryList<CampanasConcursoVentas>(SP);

            return ListTipoCliente;
        }
        public List<ZonasConcursoVentas> getDatosZonaCampanaConcursoVentas(int intCodigoConcurso)
        {
            List<ZonasConcursoVentas> ListTipoCliente = new List<ZonasConcursoVentas>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.getDatosZonaCampanaConcursoVentas("SPR_GET_ZONA_CAMPANA_CONCURSO_VENTA", intCodigoConcurso);
            ListTipoCliente = data.ExecuteQueryList<ZonasConcursoVentas>(SP);

            return ListTipoCliente;
        }

        public List<PremiosConcursoVentas> getPremiosConcursoVentas(int intCodigoConcurso)
        {
            List<PremiosConcursoVentas> ListTipoCliente = new List<PremiosConcursoVentas>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.getDatosZonaCampanaConcursoVentas("SPR_GET_PREMIOS_CONC_VENTAS", intCodigoConcurso);
            ListTipoCliente = data.ExecuteQueryList<PremiosConcursoVentas>(SP);

            return ListTipoCliente;
        }

        public List<ConcursoVentas> getConcursosVentas(int intOpcion, int intCodigoConcurso)
        {
            List<ConcursoVentas> ListConcursoVentas = new List<ConcursoVentas>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.getConcursosVentas("SPR_GET_CONCURSOS_VENTA", intOpcion, intCodigoConcurso);
            ListConcursoVentas = data.ExecuteQueryList<ConcursoVentas>(SP);

            return ListConcursoVentas;
        }

        public List<TipoClienteConcursoVenta> getTipoClienteConcursosVentas(int intCodigoConcurso)
        {
            List<TipoClienteConcursoVenta> ListTipoCliente = new List<TipoClienteConcursoVenta>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.getDatosZonaCampanaConcursoVentas("SPR_GET_TIPO_CLIENTE_CONCURSO_VENTA", intCodigoConcurso);
            ListTipoCliente = data.ExecuteQueryList<TipoClienteConcursoVenta>(SP);

            return ListTipoCliente;
        }

        public int insConcursoVentas(ConcursoVentas concursoVentas)
        {
            SpRequest spRequest = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequest.insConcursoVentas("SPR_IU_CONCURSO_VENTA", concursoVentas);
            int codigoConcurso = data.ExecuteInsert(SP, "PO_ORESULTADO");
            return codigoConcurso;
        }

        public int delTipoClienteConcurso(int intCodigoConcurso)
        {
            SpRequest spRequest = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequest.delTipoClienteConcurso("SPR_DEL_TIPO_CLIENTE_CONCURSO", intCodigoConcurso);
            int codigoProductoLista = data.ExecuteUD(SP);
            return codigoProductoLista;
        }

        public int insTipoClienteConcursoVentas(TipoClienteConcurso tipoClienteConcurso)
        {
            SpRequest spRequest = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequest.insTipoClienteConcursoVentas("SPR_INS_TIPO_CLIENTE_CONCURSO", tipoClienteConcurso);
            int codigoConcurso = data.ExecuteInsert(SP, "PO_ORESULTADO");
            return codigoConcurso;
        }

        public int insZonasConcursoVentas(ZonaConcursoVentasIns zonaConcursoVentasIns)
        {
            SpRequest spRequest = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequest.insZonasConcursoVentas("SPR_IU_ZONA_CONCURSO_VENTA", zonaConcursoVentasIns);
            int codigo = data.ExecuteInsert(SP, "PO_NRESULTADO");
            return codigo;
        }

        public int delTerritorioConcurso(int intCodigoTerritorio)
        {
            SpRequest spRequest = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequest.delTerritorioConcurso("SPR_DEL_TERRITORIO_CONCURSO", intCodigoTerritorio);
            int codigoProductoLista = data.ExecuteUD(SP);
            return codigoProductoLista;
        }

        public int iuCampanasConcursoVentas(CampanasConcursoVentasIns campanasConcursoVentasIns)
        {
            SpRequest spRequest = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequest.iuCampanasConcursoVentas("SPR_IU_CAMPANAS_CONCURSO_VENTAS", campanasConcursoVentasIns);
            int codigo = data.ExecuteInsert(SP, "PO_NRESULTADO");
            return codigo;
        }

        public int delCampanaConcursoVenta(int intCodigoCampana, int intCodigoconcurso)
        {
            SpRequest spRequest = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequest.delCampanaConcursoVenta("SPR_DEL_CAMPANA_ASIGNADA_CONCURSO_VENTA", intCodigoCampana, intCodigoconcurso);
            int codigoProductoLista = data.ExecuteUD(SP);
            return codigoProductoLista;
        }
        public int iuEstadoActividadConcursoVentas(EstadoActividadIns estadoActividadIns)
        {
            SpRequest spRequest = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequest.iuEstadoActividadConcursoVentas("SPR_IU_ESTADO_ACTIVIDAD_CONC_VENTAS", estadoActividadIns);
            int codigo = data.ExecuteInsert(SP, "PO_ORESULTADO");
            return codigo;
        }

        public int delEstadoActividadConcursoVentas(int intCodigoActividadAsignado)
        {
            SpRequest spRequest = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequest.delEstadoActividadConcursoVentas("SPR_DEL_ESTADO_ACTIVIDAD_CONC_VENTAS", intCodigoActividadAsignado);
            int codigoProductoLista = data.ExecuteUD(SP);
            return codigoProductoLista;
        }

        public int insProductoConcursoVentas(ObsequioConcursoVentaIns obsequioConcursoVentaIns)
        {
            SpRequest spRequest = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequest.insProductoConcursoVentas("SPR_UI_OBSEQUIO_CONCURSO_VENTA", obsequioConcursoVentaIns);
            int codigo = data.ExecuteInsert(SP, "PO_NRESULTADO");
            return codigo;
        }

        public int updCampanaZona(int intCodigoAsignado, decimal intValorValidaCampana)
        {
            SpRequest spRequest = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequest.updCampanaZona("SPR_UPD_ZONA_CAMPANA_CONCURSO_VENTA", intCodigoAsignado, intValorValidaCampana);
            int codigoProductoLista = data.ExecuteUD(SP);
            return codigoProductoLista;
        }

        public List<EscalaDescuentoTabla> getEscala(int intOpcion, int intCodigoEscala, int intTipoCliente, int intValorPedido, string strZonaAsesor)
        {
            List<EscalaDescuentoTabla> ListEscalaDescuento= new List<EscalaDescuentoTabla>();
            SpRequest spRequestUsuario = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestUsuario.getEscala("SPR_GET_ESCALA_DESCUENTO", intOpcion, intCodigoEscala, intTipoCliente, intValorPedido, strZonaAsesor);
            ListEscalaDescuento = data.ExecuteQueryList<EscalaDescuentoTabla>(SP);

            return ListEscalaDescuento;
        }

        public int insEscalaDescuento(EscalaDescuento escalaDescuento)
        {
            SpRequest spRequest = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequest.insEscalaDescuento("SPR_IU_ESCALA_DESCUENTO", escalaDescuento);
            int codigo = data.ExecuteInsert(SP, "PO_NRESULT");
            return codigo;
        }
        #endregion
        public List<ProductosAplicaOferta> getlistaProductosAplicaOferta(int intCodigoOferta)
        {
            List<ProductosAplicaOferta> PedidosProductosAplicaOferta = new List<ProductosAplicaOferta>();
            sp_Liquidacion spRequestPedidos = new sp_Liquidacion();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestPedidos.getDatosProdImpulsa("SPR_GET_PRODUCTO_APLICA_OFERTA", intCodigoOferta);
            PedidosProductosAplicaOferta = data.ExecuteQueryList<ProductosAplicaOferta>(SP);
            return PedidosProductosAplicaOferta;
        }

        public List<OfertasSimples> getlistaOfertas(int intCodigoOferta, int intOpcion, int intCodigoListaPrecios, int intCodigoEstadoActicliente, string strCodigoZona)
        {
            List<OfertasSimples> PedidosOfertasSimples = new List<OfertasSimples>();
            sp_Liquidacion spRequestPedidos = new sp_Liquidacion();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestPedidos.getlistaOfertas("SPR_GET_OFERTA_SIMPLE", intCodigoOferta, intOpcion, intCodigoListaPrecios, intCodigoEstadoActicliente, strCodigoZona);
            PedidosOfertasSimples = data.ExecuteQueryList<OfertasSimples>(SP);
            return PedidosOfertasSimples;
        }

        public int delEstadoActividadPromocion(int intCodigoAsignado)
        {
            SpRequest spRequest = new SpRequest();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequest.delEstadoActividadPromocion("SPR_DEL_ESTADO_ACTI_OFERTA", intCodigoAsignado);
            int codigoProductoLista = data.ExecuteUD(SP);
            return codigoProductoLista;
        }
    }

}
