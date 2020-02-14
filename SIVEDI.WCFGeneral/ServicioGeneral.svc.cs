﻿using SIVEDI.Cifrado;
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
    }
}
