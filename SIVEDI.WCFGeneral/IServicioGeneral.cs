﻿using SIVEDI.Clases;
using SIVEDI.Clases.TABLAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SIVEDI.WCFGeneral
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioGeneral" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioGeneral
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
        TipoCliente getTipoClienteTabla(int intOpcion, int intCodigoTipoCliente);
        [OperationContract]
        int insCliente(Cliente cliente);
        [OperationContract]
        int insReferenciasCliente(ReferenciaCliente referenciaCliente);
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
        [OperationContract]
        List<ReferenciaClienteTabla> getReferenciaCliente(int intCodigoCliente);
        [OperationContract]
        List<TipoReferencia> getTipoReferencia(int intOpcion, int intCodigoTipoReferencia);
        [OperationContract]
        List<FormasPago> getFormaPago(int intOpcion, int intCodigoformaPago);
        [OperationContract]
        CupoMinimo getCupoMinimoCredito();
        [OperationContract]
        List<ProductoTabla> getProductos(int intOpcion, int intCodigoProducto, string Referencia, int intCodigoVenta);
        [OperationContract]
        List<ProductoCodigoVenta> getProductosCodigoVenta(int intOpcion, string strCodigoVenta, int CodigoLista);
        [OperationContract]
        int insProducto(Productos productos);
        [OperationContract]
        List<TipoProductoTabla> getTiposProducto(int intOpcion, string strTipoProducto);
        [OperationContract]
        List<ConcursoVentaTabla> getConcursoFiltro(int intCampanaEntrega, string strNombreConcruso);
        [OperationContract]
        List<ZonaConcursoVentas> getZonasConcursoVentas(int intCodigoConcurso);
        [OperationContract]
        List<EstadoActividadConcursoVentas> getEstadoActividadConcursoVenta(int intCodigoConcurso);
        [OperationContract]
        List<EstadoActividadConcursoVentas> getListaEstadosActiDisponiblesConcursoVentas(int intCodigoConcurso);
        [OperationContract]
        List<ZonasAsignadasConcursoVentasTabla> getZonasAsignadasConcuusoVentas(int intOpcion, int intCodigoConcurso, int intCodigoDetalle);
        [OperationContract]
        List<CampanasConcursoVentas> getCampanasConcursoVentas(int intCodigoConcurso);
        [OperationContract]
        List<ZonasConcursoVentas> getDatosZonaCampanaConcursoVentas(int intCodigoConcurso);
        [OperationContract]
        List<PremiosConcursoVentas> getPremiosConcursoVentas(int intCodigoConcurso);
        [OperationContract]
        List<ConcursoVentas> getConcursosVentas(int intOpcion, int intCodigoConcurso);
        [OperationContract]
        List<TipoClienteConcursoVenta> getTipoClienteConcursosVentas(int intCodigoConcurso);
        [OperationContract]
        List<CampanasConcursoVentas> getCampanasAsignadasConcursoVentas(int intCodigoConcurso);
        [OperationContract]
        int insConcursoVentas(ConcursoVentas concursoVentas);
        [OperationContract]
        int delTipoClienteConcurso(int intCodigoConcurso);
        [OperationContract]
        int insTipoClienteConcursoVentas(TipoClienteConcurso tipoClienteConcurso);
        [OperationContract]
        int insZonasConcursoVentas(ZonaConcursoVentasIns zonaConcursoVentasIns);
        [OperationContract]
        int delTerritorioConcurso(int intCodigoTerritorio);
        [OperationContract]
        int iuCampanasConcursoVentas(CampanasConcursoVentasIns campanasConcursoVentasIns);
        [OperationContract]
        int delCampanaConcursoVenta(int intCodigoCampana, int intCodigoconcurso);
        [OperationContract]
        int iuEstadoActividadConcursoVentas(EstadoActividadIns estadoActividadIns);
        [OperationContract]
        int delEstadoActividadConcursoVentas(int intCodigoActividadAsignado);
        [OperationContract]
        int insProductoConcursoVentas(ObsequioConcursoVentaIns obsequioConcursoVentaIns);
        [OperationContract]
        int updCampanaZona(int intCodigoAsignado, decimal intValorValidaCampana);
        [OperationContract]
        List<ZonasTabla> getZonasEscalaDescuento(int intOpcion, int intTipoCliente);
        [OperationContract]
        List<EscalaDescuentoTabla> getEscala(int intOpcion, int intCodigoEscala, int intTipoCliente, int intValorPedido, string strZonaAsesor);
        [OperationContract]
        int insEscalaDescuento(EscalaDescuento escalaDescuento);
        [OperationContract]
        List<ProductosAplicaOferta> getlistaProductosAplicaOferta(int intCodigoOferta);
        [OperationContract]
        List<ZonasTabla> getZonasOferta(int intCodigoOferta);
        [OperationContract]
        List<EstadoActividadOfertas> getEstadoActividadOfertas(int intOpcion, int intCodigoOferta);
        [OperationContract]
        List<ZonasOfertaSimpleTabla> getZonasAsignadasOferta(int intCodigoOferta);
        [OperationContract]
        List<OfertaImpulsa> getDatosProdImpulsa(int intCodigoOferta);
        [OperationContract]
        List<OfertasSimples> getlistaOfertas(int intCodigoOferta, int intOpcion, int intCodigoListaPrecios, int intCodigoEstadoActicliente, string strCodigoZona);
        [OperationContract]
        int delEstadoActividadPromocion(int intCodigoAsignado);
        [OperationContract]
        int iuOfertaSimple(OfertasSimples ofertasSimples);
        [OperationContract]
        List<OfertaSimpleNombre> getlistaOfertaFiltro(int intCodigoLista, string strNombre);
        [OperationContract]
        int iuProdImpOfertaSimple(ProductoOfertaSimple productoOfertaSimple);
        [OperationContract]
        int iuProdAplicaOfertaSimple(ProductoAplicaOfertaSimple productoAplicaOfertaSimple);
    }
}
