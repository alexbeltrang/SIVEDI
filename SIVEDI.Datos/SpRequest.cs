using SIVEDI.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SIVEDI.Datos
{
    public class SpRequest
    {
        public StoreProcedure getValidaUsuarioIngresaAplciativo(string spName, string spUsuario, string spPassword)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_CLOGIN",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = spUsuario
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CPASSWORD",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = spPassword
                }
            };

            return storeProcedure;
        }

        public StoreProcedure getModuloPadre(string spName, int intCodigoUsuario)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NUSUARIO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoUsuario
                }
            };

            return storeProcedure;
        }

        public StoreProcedure getModuloHijo(string spName, int intCodigoUsuario, int CodigoPadre)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NUSUARIO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoUsuario
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_PADRE",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = CodigoPadre
                }
            };

            return storeProcedure;
        }

        public StoreProcedure getPerfiles(string spName, int intOpcion, int CodigoPerfil)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_PERFIL",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = CodigoPerfil
                }
            };

            return storeProcedure;
        }

        public StoreProcedure insPerfiles(string spName, perfiles Perfil)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_PERFIL",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = Perfil.CODIGO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE_PERFIL",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = Perfil.NOMBRE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OESTADO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = Perfil.ESTADO
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NRESULT",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = Perfil.CODIGO
                }
            };

            return storeProcedure;
        }

        public StoreProcedure getUsuarios(string spName, int intOpcion, string LoginUsuario)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_CUSUARIO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = LoginUsuario
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                }
            };

            return storeProcedure;
        }

        public StoreProcedure insUsuarios(string spName, usuarios Usuarios)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NID",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = Usuarios.CODIGO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRES",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = Usuarios.NOMBRES
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CAPELLIDOS",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = Usuarios.APELLIDOS
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CLOGIN",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = Usuarios.LOGIN
                },
                 new SqlParameter()
                {
                    ParameterName = "@PI_CPASSWORD",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = Usuarios.PASSWORD
                },
                  new SqlParameter()
                {
                    ParameterName = "@PI_OESTADO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = Usuarios.ESTADO
                },
                  new SqlParameter()
                {
                    ParameterName = "@PI_NPER_ID",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = Usuarios.COD_PERFIL
                },
                  new SqlParameter()
                {
                    ParameterName = "@PI_CUSU_EMAIL",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = Usuarios.EMAIL
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NEFECTIVO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = Usuarios.CODIGO
                }
            };

            return storeProcedure;
        }

        public StoreProcedure getTiposDocumento(string spName, int intOpcion, int intCodigoTipo)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_TIPO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoTipo
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                }
            };

            return storeProcedure;
        }

        public StoreProcedure insTiposDocumento(string spName, TipoDocumento TipoDocumento)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_TIPO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = TipoDocumento.CODIGO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE_TIPO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = TipoDocumento.NOMBRE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OESTADO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = TipoDocumento.ESTADO
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NRESULT",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = TipoDocumento.CODIGO
                }
            };
            return storeProcedure;
        }

        public StoreProcedure getTipoCliente(string spName, int intOpcion, int intCodigoTipo)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_TIPO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoTipo
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                }
            };

            return storeProcedure;
        }

        public StoreProcedure insTiposCliente(string spName, TipoCliente tipoCliente)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_TIPO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = tipoCliente.CODIGO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE_TIPO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = tipoCliente.NOMBRE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OESTADO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = tipoCliente.ESTADO
                },
                     new SqlParameter()
                {
                    ParameterName = "@PI_OCOBRA_FLETE",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = tipoCliente.COBRA_FLETE
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NRESULT",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = tipoCliente.CODIGO
                }
            };
            return storeProcedure;
        }

        public StoreProcedure getUnidadMedida(string spName, int intOpcion, int intCodigoUnidad)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_UNIDAD",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoUnidad
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                }
            };

            return storeProcedure;
        }

        public StoreProcedure insUnidadMedida(string spName, UnidadMedida unidadMedida)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_UNIDAD",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = unidadMedida.CODIGO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE_UNIDAD",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = unidadMedida.NOMBRE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE_NOMEN",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = unidadMedida.ABREVIATURA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OESTADO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = unidadMedida.ESTADO
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NRESULT",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = unidadMedida.CODIGO
                }
            };
            return storeProcedure;
        }

        public StoreProcedure getGeneros(string spName, int intOpcion, int intCodigoGenero)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_GENERO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoGenero
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                }
            };

            return storeProcedure;
        }

        public StoreProcedure insGeneros(string spName, Generos generos)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_GENERO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = generos.CODIGO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE_GENERO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = generos.NOMBRE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OESTADO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = generos.ESTADO
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NRESULT",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = generos.CODIGO
                }
            };
            return storeProcedure;
        }

        public StoreProcedure getFormasIngreso(string spName, int intOpcion, int intCodigoFormaIngreso)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_FORMA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoFormaIngreso
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                }
            };

            return storeProcedure;
        }

        public StoreProcedure insFormasIngreso(string spName, formasIngreso formasIngreso)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_FORMA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = formasIngreso.CODIGO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE_FORMA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = formasIngreso.NOMBRE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OESTADO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = formasIngreso.ESTADO
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NRESULT",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = formasIngreso.CODIGO
                }
            };
            return storeProcedure;
        }

        public StoreProcedure getEstadoCivil(string spName, int intOpcion, int intCodigoEstadoCivil)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_ESTADO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoEstadoCivil
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                }
            };

            return storeProcedure;
        }

        public StoreProcedure insEstadoCivil(string spName, EstadoCivil estadoCivil)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_ESTADO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = estadoCivil.CODIGO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE_ESTADO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = estadoCivil.NOMBRE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OESTADO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = estadoCivil.ESTADO
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NRESULT",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = estadoCivil.CODIGO
                }
            };
            return storeProcedure;
        }

        public StoreProcedure getEstadoActividad(string spName, int intOpcion, int intCodigoEstadoActividad)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_ESTADO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoEstadoActividad
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                }
            };

            return storeProcedure;
        }

        public StoreProcedure insEstadoActividad(string spName, EstadoActividad estadoActividad)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_ESTADO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = estadoActividad.ESA_NID
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE_ESTADO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = estadoActividad.ESA_CDESCRIPCION
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OESTADO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = estadoActividad.ESA_OESTADO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_ESA_NESTADO_SIGUIENTE_SIN_PED",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = estadoActividad.ESA_NESTADO_SIGUIENTE_SIN_PED
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_ESA_NESTADO_SIGUIENTE_CON_PED",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = estadoActividad.ESA_NESTADO_SIGUIENTE_CON_PED
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_ESA_NCAMPANA_CONTROLA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = estadoActividad.ESA_NCAMPANA_CONTROLA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_ESA_NESTADO_PASA_CONTROL_CAMPANA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = estadoActividad.ESA_NESTADO_PASA_CONTROL_CAMPANA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_ESA_NNUMERO_PEDIDO_CONTROLA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = estadoActividad.ESA_NNUMERO_PEDIDO_CONTROLA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_ESA_NESTADO_PASA_CONTROL_PEDIDO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = estadoActividad.ESA_NESTADO_PASA_CONTROL_PEDIDO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_ESA_OES_ESTADO_INACTIVIDAD",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = estadoActividad.ESA_OES_ESTADO_INACTIVIDAD
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_ESA_OES_ESTADO_VINCULACION",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = estadoActividad.ESA_OES_ESTADO_VINCULACION
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_ESA_OINGRESA_VINCULACION",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = estadoActividad.ESA_OINGRESA_VINCULACION
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NRESULT",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = estadoActividad.ESA_NID
                }
            };
            return storeProcedure;
        }

        public StoreProcedure getCampanas(string spName, int intOpcion, int intCodigoCampana)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CAMPANA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoCampana
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                }
            };

            return storeProcedure;
        }

        public StoreProcedure insCampanas(string spName, campanas Campanas)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CAMPANA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = Campanas.CODIGO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE_CAMPANA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = Campanas.NOMBRE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_DFECHA_INICIAL",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Value = Campanas.FECHA_INICIAL
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_DFECHA_FINAL",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Value = Campanas.FECHA_FINAL
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NNIVEL",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = Campanas.NIVEL
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OESTADO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = Campanas.ESTADO
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NRESULT",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = Campanas.CODIGO
                }
            };
            return storeProcedure;
        }

        public StoreProcedure getPaises(string spName, int intOpcion, int intCodigoPais)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_PAIS",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoPais
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                }
            };

            return storeProcedure;
        }

        public StoreProcedure insPais(string spName, Pais pais)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_PAIS",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = pais.CODIGO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE_PAIS",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = pais.NOMBRE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_UNIVERSAL",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = pais.CODIGO_UNIVERSAL
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OESTADO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = pais.ESTADO
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NRESULT",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = pais.CODIGO
                }
            };
            return storeProcedure;
        }

        public StoreProcedure getDepartamento(string spName, int intOpcion, int intCodigoPais, int intCodigoDepartamento)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_PAIS",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoPais
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_DEPARTAMENTO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoDepartamento
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                }
            };

            return storeProcedure;
        }

        public StoreProcedure insDepartamento(string spName, Departamentos departamentos)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_PAIS",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = departamentos.CODIGO_PAIS
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_DEPTO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = departamentos.CODIGO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE_DEPTO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = departamentos.NOMBRE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_DANE",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = departamentos.CODIGO_DANE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OESTADO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = departamentos.ESTADO
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NRESULT",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = departamentos.CODIGO
                }
            };
            return storeProcedure;
        }

        public StoreProcedure getCiudades(string spName, int intOpcion, int intCodigoDepartamento, int intCodigoCiudad)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_DEPARTAMENTO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoDepartamento
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CIUDAD",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoCiudad
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                }
            };

            return storeProcedure;
        }

        public StoreProcedure insCiudades(string spName, Ciudades ciudades)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_DEPTO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = ciudades.CODIGO_DEPARTAMENTO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CIUDAD",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = ciudades.CODIGO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE_CIUDAD",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = ciudades.NOMBRE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_DANE",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = ciudades.CODIGO_DANE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OESTADO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = ciudades.ESTADO
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NRESULT",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = ciudades.CODIGO
                }
            };
            return storeProcedure;
        }

        public StoreProcedure getClaseResponsable(string spName, int intOpcion, int intCodigoResponsable)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CLASE",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoResponsable
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                }
            };

            return storeProcedure;
        }

        public StoreProcedure insClaseResponsable(string spName, ClaseResponsable claseResponsable)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CLASE",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = claseResponsable.CODIGO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE_CLASE",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = claseResponsable.NOMBRE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OESTADO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = claseResponsable.ESTADO
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NRESULT",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = claseResponsable.CODIGO
                }
            };
            return storeProcedure;
        }

        public StoreProcedure getResponsableTerritorio(string spName, int intOpcion)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                }
            };

            return storeProcedure;
        }
        public StoreProcedure getResponsableFiltro(string spName, string strIdentificacion, string strNombreResponsable)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_CIDENTIFICACION",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = strIdentificacion
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = strNombreResponsable
                }
            };

            return storeProcedure;
        }

        public StoreProcedure insResponsableTerritorio(string spName, ResponsableTerritorio responsableTerritorio)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_RESPONSABLE",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = responsableTerritorio.CODIGO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE_RESPONSABLE",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = responsableTerritorio.NOMBRE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CDIRECCION",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = responsableTerritorio.DIRECCION
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CBARRIO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = responsableTerritorio.BARRIO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CTELEFONO_FIJO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = responsableTerritorio.TELEFONO_FIJO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CTELEFONO_CELULAR",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = responsableTerritorio.TELEFONO_CELULAR
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CIUDAD",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = responsableTerritorio.COD_CIU
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CEMAIL",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = responsableTerritorio.EMAIL
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OESTADO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = responsableTerritorio.ESTADO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE_PILA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = responsableTerritorio.NOMBRE_PILA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CLASE",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = responsableTerritorio.COD_CLR
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CIDENTIFICACION",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = responsableTerritorio.IDENTIFICACION
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NRESULT",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = responsableTerritorio.CODIGO
                }
            };
            return storeProcedure;
        }

        public StoreProcedure getRegionales(string spName, int intOpcion, int intCodigoRegional, int intCodigoPais)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_REGIONAL",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoRegional
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NPAIS",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoPais
                }
            };

            return storeProcedure;
        }

        public StoreProcedure insRegionales(string spName, Regionales regionales)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_REGIONAL",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = regionales.CODIGO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE_REGIONAL",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = regionales.NOMBRE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OESTADO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = regionales.ESTADO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_RESPONSABLE",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = regionales.CODIGO_RESPONSABLE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_PAIS",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = regionales.CODIGO_PAIS
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NNUMERO_GRUPO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = regionales.GRUPO_FACTURACION
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NRESULT",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = regionales.CODIGO
                }
            };
            return storeProcedure;
        }

        public StoreProcedure getZonas(string spName, int intOpcion, string strCodigoRegional, string strCodigoZona)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_REGIONAL",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = strCodigoRegional
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CZONA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = strCodigoZona
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                }
            };

            return storeProcedure;
        }
        public StoreProcedure insZonas(string spName, Zonas zonas)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_ZONA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = zonas.CODIGO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE_ZONA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = zonas.NOMBRE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OESTADO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = zonas.ESTADO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_REGIONAL",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = zonas.CODIGO_REGIONAL
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_RESPONSABLE",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = zonas.CODIGO_RESPONSABLE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NNUMERO_GRUPO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = zonas.GRUPO_FACTURACION
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NRESULT",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = zonas.CODIGO
                }
            };
            return storeProcedure;
        }

        public StoreProcedure getSecciones(string spName, int intOpcion, string strCodigoZona, string strCodigoSeccion)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_ZONA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = strCodigoZona
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CSECCION",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = strCodigoSeccion
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                }
            };

            return storeProcedure;
        }
        public StoreProcedure insSecciones(string spName, Secciones secciones)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_SECCION",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = secciones.CODIGO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE_SECCION",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = secciones.NOMBRE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OESTADO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = secciones.ESTADO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_ZONA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = secciones.CODIGO_ZONA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_RESPONSABLE",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = secciones.CODIGO_RESPONSABLE
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NRESULT",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = secciones.CODIGO
                }
            };
            return storeProcedure;
        }

        public StoreProcedure getTerritorios(string spName, int intOpcion, string strCodigoSeccion, string strCodigoTerritorio)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_SECCION",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = strCodigoSeccion
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CTERRITORIO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = strCodigoTerritorio
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                }
            };

            return storeProcedure;
        }

        public StoreProcedure insTerritorio(string spName, Territorios territorios)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_TERRITORIO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = territorios.CODIGO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE_TERRIROTIO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = territorios.NOMBRE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OESTADO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = territorios.ESTADO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_SECCION",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = territorios.CODIGO_SECCION
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NRESULT",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = territorios.CODIGO
                }
            };
            return storeProcedure;
        }

        public StoreProcedure getTipoReferencia(string spName, int intOpcion, int intCodigoReferencia)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_TIPO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoReferencia
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                }
            };

            return storeProcedure;
        }

        public StoreProcedure getFormaPago(string spName, int intOpcion, int intCodigoFormaPago)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_FORMA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoFormaPago
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                }
            };

            return storeProcedure;
        }

        public StoreProcedure getProductos(string spName, int intOpcion, int CodigoProducto, string Referencia, int CodigoVenta)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_PRODUCTO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = CodigoProducto
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CREFERENCIA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = Referencia
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_VENTA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = CodigoVenta
                }
            };

            return storeProcedure;
        }

        public StoreProcedure getProductosCodigoVenta(string spName, int intOpcion, string CodigoVenta, int intCodigoLista)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_VENTA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = CodigoVenta
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCOD_LISTA_PRECIOS",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoLista
                }
            };

            return storeProcedure;
        }

        public StoreProcedure insProductos(string spName, Productos productos)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NID",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = productos.CODIGO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CREFERENCIA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = productos.REFERENCIA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = productos.NOMBRE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NPORC_IVA",
                    SqlDbType = System.Data.SqlDbType.Decimal,
                    Value = productos.IVA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CMOTIVO_VENTA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = productos.MOTIVO_VENTA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CCENTRO_GASTO_VENTA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = productos.CENTRO_GASTO_VENTA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CMOTIVO_OBSEQUIO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = productos.MOTIVO_OBSEQUIO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CCENTRO_GASTO_OBSEQUIO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = productos.CENTRO_GASTO_OBSEQUIO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OESTADO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = productos.ESTADO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NUNIDAD_MEDIDA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = productos.CODIGO_UNIDAD_MEDIDA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NTOTAL_PUNTOS",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = productos.PUNTOS
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NEFECTIVO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = productos.CODIGO
                }
            };
            return storeProcedure;
        }

        public StoreProcedure getlistaTipoProducto(string spName, int intOpcion, string strTipoProdcuto)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_PRODUCTO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = strTipoProdcuto
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                }
            };

            return storeProcedure;
        }

        public StoreProcedure getZonasConcursoVentas(string spName, int intCodigoConcurso)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@SPR_GET_ZONAS_CONVTAS",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoConcurso
                }
            };

            return storeProcedure;
        }

        public StoreProcedure getEstadoActividadConcursoVenta(string spName, int intCodigoConcurso)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CONCURSO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoConcurso
                }
            };

            return storeProcedure;
        }

        public StoreProcedure getListaEstadosActiDisponiblesConcursoVentas(string spName, int intCodigoConcurso)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CONCURSO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoConcurso
                }
            };

            return storeProcedure;
        }

        public StoreProcedure getZonasAsignadasConcuusoVentas(string spName, int intOpcion, int intCodigoConcurso, int intCodigoDetalle)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_CONCURSO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoConcurso
                },
                 new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_DETALLE",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoDetalle
                }
            };

            return storeProcedure;
        }

        public StoreProcedure getCampanasConcursoVentas(string spName, int intCodigoConcurso)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CONCURSO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoConcurso
                }
            };

            return storeProcedure;
        }

        public StoreProcedure getDatosZonaCampanaConcursoVentas(string spName, int intCodigoConcurso)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CONCURSO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoConcurso
                }
            };

            return storeProcedure;
        }

        public StoreProcedure getPremiosConcursoVentas(string spName, int intCodigoConcurso)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CONCURSO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoConcurso
                }
            };

            return storeProcedure;
        }
        public StoreProcedure getConcursosVentas(string spName, int intOpcion, int intCodigoConcurso)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CONCURSO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoConcurso
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                }
            };

            return storeProcedure;
        }

        public StoreProcedure getTipoClienteConcursosVentas(string spName, int intCodigoConcurso)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CONCURSO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoConcurso
                }
            };

            return storeProcedure;
        }

        public StoreProcedure insConcursoVentas(string spName, ConcursoVentas concursoVentas)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CONCURSO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = concursoVentas.CODIGO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE_CONCURSO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = concursoVentas.NOMBRE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CAMPANA_ENTREGA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = concursoVentas.CAMPANA_ENTREGA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OVALIDA_CAMPANA_ACTUAL",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = concursoVentas.VALIDA_CAMPANA_ACTUAL
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OESINGRESO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = concursoVentas.ES_PARA_INGRESO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OESTADO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = concursoVentas.ESTADO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OENTREGA_PREMIO_ACUMULADO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = concursoVentas.ENTREGA_PREMIO_ACUMULADO
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_ORESULTADO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = concursoVentas.CODIGO
                }
            };
            return storeProcedure;
        }

        public StoreProcedure delTipoClienteConcurso(string spName, int intCodigoConcurso)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CONCURSO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoConcurso
                }
            };

            return storeProcedure;
        }

        public StoreProcedure insTipoClienteConcursoVentas(string spName, TipoClienteConcurso tipoClienteConcurso)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CONCURSO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = tipoClienteConcurso.CODIGO_CONCURSO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_TIPO_CLIENTE",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = tipoClienteConcurso.CODIGO_TIPO_CLIENTE
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_ORESULTADO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = tipoClienteConcurso.CODIGO_CONCURSO
                }
            };
            return storeProcedure;
        }

        public StoreProcedure insZonasConcursoVentas(string spName, ZonaConcursoVentasIns zonaConcursoVentas)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_ZONA_CONCURSO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = zonaConcursoVentas.CODIGO_ZONA_CONCURSO_VENTA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_ZONA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = zonaConcursoVentas.CODIGO_ZONA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OESACUMULADO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = zonaConcursoVentas.ES_ACUMULADO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NPORCENTAJE_COLCHON",
                    SqlDbType = System.Data.SqlDbType.Decimal,
                    Value = zonaConcursoVentas.PORCENTAJE_COLCHON
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CONCURSO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = zonaConcursoVentas.CODIGO_CONCURSO
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NRESULTADO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = zonaConcursoVentas.CODIGO_ZONA_CONCURSO_VENTA
                }

            };
            return storeProcedure;
        }

        public StoreProcedure delTerritorioConcurso(string spName, int intCodigoTerritorio)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_TERRITORIO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoTerritorio
                }
            };

            return storeProcedure;
        }

        public StoreProcedure iuCampanasConcursoVentas(string spName, CampanasConcursoVentasIns campanasConcursoVentasIns)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CAMPANA_ZONA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = campanasConcursoVentasIns.CODIGO_CAMPANA_ZONA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CAMPANA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = campanasConcursoVentasIns.CODIGO_CAMPANA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_CONCURSO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = campanasConcursoVentasIns.CODIGO_CONCURSO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NVALOR",
                    SqlDbType = System.Data.SqlDbType.Decimal,
                    Value = campanasConcursoVentasIns.VALOR
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NRESULTADO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = campanasConcursoVentasIns.CODIGO_CAMPANA_ZONA
                }

            };
            return storeProcedure;
        }

        public StoreProcedure delCampanaConcursoVenta(string spName, int intCodigoCampana, int intCodigoconcurso)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CAMPANA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoCampana
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CONCURSO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoconcurso
                }
            };

            return storeProcedure;
        }

        public StoreProcedure iuEstadoActividadConcursoVentas(string spName, EstadoActividadIns estadoActividadIns)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_ASIGNADO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = estadoActividadIns.CODIGO_ASIGNADO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CONCURSO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = estadoActividadIns.CODIGO_CONCURSO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_ESTADO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = estadoActividadIns.CODIGO_ESTADO_ACTIVIDAD
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_ORESULTADO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = estadoActividadIns.CODIGO_ASIGNADO
                }

            };
            return storeProcedure;
        }

        public StoreProcedure delEstadoActividadConcursoVentas(string spName, int intCodigoActividadAsignado)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_ASIGNADO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoActividadAsignado
                }
            };

            return storeProcedure;
        }

        public StoreProcedure insProductoConcursoVentas(string spName, ObsequioConcursoVentaIns obsequioConcursoVentaIns)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_OBSEQUIO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = obsequioConcursoVentaIns.CODIGO_OBSEQUIO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_LISTA_PRECIO_PROD",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = obsequioConcursoVentaIns.CODIGO_LISTA_PRECIOS
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NVALOR_MINIMO",
                    SqlDbType = System.Data.SqlDbType.Decimal,
                    Value = obsequioConcursoVentaIns.VALOR_MINIMO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NVALOR_MAXIMO",
                    SqlDbType = System.Data.SqlDbType.Decimal,
                    Value = obsequioConcursoVentaIns.VALOR_MAXIMO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NUNIDADES",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = obsequioConcursoVentaIns.UNIDADES
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CONCURSO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = obsequioConcursoVentaIns.CODIGO_CONCURSO
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NRESULTADO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = obsequioConcursoVentaIns.CODIGO_OBSEQUIO
                }

            };
            return storeProcedure;
        }

        public StoreProcedure updCampanaZona(string spName, int intCodigoAsignado, decimal intValorValidaCampana)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_ASIGNACION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoAsignado
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NVALOR_MONTO",
                    SqlDbType = System.Data.SqlDbType.Decimal,
                    Value = intValorValidaCampana
                }
            };

            return storeProcedure;
        }

    }
}
