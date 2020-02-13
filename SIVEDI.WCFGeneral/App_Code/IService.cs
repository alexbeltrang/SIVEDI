using SIVEDI.Clases;
using SIVEDI.Clases.TABLAS;
using System.Collections.Generic;
using System.ServiceModel;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IService
{

    [OperationContract]
    LoginUsuario ingresaAplicativo(string strUser, string strPassword);

    [OperationContract]
    List<moduloPadre> getModuloPadre(int intOpcion);
    [OperationContract]
    List<moduloHijo> getModuloHijo(int intCodigoUsuario, int intCodigoPadre);
    [OperationContract]
    List<perfiles> getPerfiles(int intOpcion, int intCodigoPerfil);
    [OperationContract]
    int insPerfiles(int intOpcion, perfiles perfil);
    [OperationContract]
    List<usuariosTabla> getUsuarios(int intOpcion, string LoginUsuario);
    [OperationContract]
    int insUsuarios(usuarios usuarioModel);
    [OperationContract]
    List<tipoDocumentoTabla> getTiposDocumento(int intOpcion, int intCodigoTipoDocumento);
    [OperationContract]
    int insTipoDocumento(TipoDocumento TipoDocumento);
    [OperationContract]
    List<TipoClienteTabla> getTipoCliente(int intOpcion, int intCodigoTipoCliente);
    [OperationContract]
    int insTipoCliente(TipoCliente tipoCliente);
    [OperationContract]
    List<UnidadesMedidaTabla> getUnidadMedida(int intOpcion, int intCodigoUnidadMedida);
    [OperationContract]
    int insUnidadMedida(UnidadMedida unidadMedida);
    [OperationContract]
    List<GenerosTabla> GetGeneros(int intOpcion, int intCodigoGenero);
    [OperationContract]
    int insGeneros(Generos generos);
    [OperationContract]
    List<FormasIngresoTabla> getformasIngreso(int intOpcion, int intCodigoFormaIngreso);
    [OperationContract]
    int insFormasIngreso(formasIngreso formasIngreso);
    [OperationContract]
    List<EstadoCivilTabla> getEstadoCivil(int intOpcion, int intCodigoEstadoCivil);
    [OperationContract]
    int insEstadoCivil(EstadoCivil estadoCivil);
    [OperationContract]
    List<EstadoActividadTabla> getEstadoActividad(int intOpcion, int intCodigoEstadoActividad);
    [OperationContract]
    EstadoActividad getEstadoActividadCamposTabla(int intOpcion, int intCodigoEstadoActividad);
    [OperationContract]
    int insEstadoActividad(EstadoActividad estadoActividad);
    [OperationContract]
    List<CampanasTabla> getCampanas(int intOpcion, int intCodigoCampana);
    [OperationContract]
    int insCampanas(campanas Campanas);
    [OperationContract]
    List<PaisTabla> getPaises(int intOpcion, int intCodigoPais);
    [OperationContract]
    int insPaises(Pais pais);
    [OperationContract]
    List<DepartamentoTabla> getDepartamentos(int intOpcion, int intCodigoPais, int intCodigoDepartamento);
    [OperationContract]
    Departamentos getDepartamentoTabla(int intOpcion, int intCodigoPais, int intCodigoDepartamento);
    [OperationContract]
    int insDepartamento(Departamentos departamentos);
    [OperationContract]
    List<CiudadesTabla> getCiudades(int intOpcion, int intCodigoDepartamento, int intCodigoCiudad);
    [OperationContract]
    Ciudades getCiudadesTabla(int intOpcion, int intCodigoDepartamento, int intCodigoCiudad);
    [OperationContract]
    int insCiudades(Ciudades ciudades);
    [OperationContract]
    List<ClaseResponsableTabla> getClaseResponsable(int intOpcion, int intCodigoClaseResponsable);
    [OperationContract]
    int insClaseResponsable(ClaseResponsable claseResponsable);
    [OperationContract]
    List<ResponsableTerritorioTabla> getResponsableTerritorio(int intOpcion);
    [OperationContract]
    int insResponsableTerritorio(ResponsableTerritorio responsableTerritorio);
    [OperationContract]
    List<ResponsableTerritorioFiltro> getResponsableFiltro(string strIdentificacion, string strNombreResponsable);
    [OperationContract]
    List<RegionalesTabla> getRegionales(int intOpcion, int intCodigoRegional, int intCodigoPais);
    [OperationContract]
    int insRegionales(Regionales regionales);
    [OperationContract]
    List<ZonasTabla> getZonas(int intOpcion, string strCodigoRegional, string strCodigoZona);
    [OperationContract]
    int insZonas(Zonas zonas);
    [OperationContract]
    List<SeccionesTabla> getSecciones(int intOpcion, string strCodigoZona, string strCodigoSeccion);
    [OperationContract]
    SeccionFiltro getSeccionFiltro(int intOpcion, string strCodigoSeccion);
    [OperationContract]
    int insSecciones(Secciones secciones);
    [OperationContract]
    List<TerritorioTabla> getTerritorio(int intOpcion, string strCodigoSeccion, string strCodigoTerritorio);
    [OperationContract]
    TerritorioFiltro getTerritorioFiltro(int intOpcion, string strCodigoTerrirorio);
    [OperationContract]
    int insTerritorio(Territorios territorios);
    [OperationContract]
    ClienteConsultaTabla getConsultaCliente(string strIdentificacion);
}


