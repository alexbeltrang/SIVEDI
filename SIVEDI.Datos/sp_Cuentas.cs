using SIVEDI.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace SIVEDI.Datos
{
    public class sp_Cuentas
    {
        public StoreProcedure getConsultaClientes(string spName, string strIdentificacionCliente)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_CNUMERO_IDENTIFICACION",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = strIdentificacionCliente
                },
            };

            return storeProcedure;
        }

        public StoreProcedure insClientes(string spName, Cliente cliente)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CLIENTE",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = cliente.CODIGO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNUMERO_IDENTIFICACION",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = cliente.NUMERO_IDENTIFICACION
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CPRIMER_APELLIDO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = cliente.PRIMER_APELLIDO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CSEGUNDO_APELLIDO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = cliente.SEGUNDO_APELLIDO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CPRIMER_NOMBRE",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = cliente.PRIMER_NOMBRE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CSEGUNDO_NOMBRE",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = cliente.SEGUNDO_NOMBRE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CEMAIL",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = cliente.EMAIL
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_DIRECCION_DOMICILIO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = cliente.DIRECCION_DOMICILIO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CDIRECCION_ENTREGA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = cliente.DIRECCION_ENTREGA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CPROFESION",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = cliente.PROFESION
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CESTRATO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = cliente.ESTRATO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CTELEFONO_FIJO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = cliente.TELEFONO_FIJO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CTELEFONO_CELULAR",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = cliente.TELEFONO_CELULAR
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CTELEFONO_OFICINA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = cliente.TELEFONO_OFICINA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NID_REFERIDO_POR",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = cliente.ID_REFERIDO_POR
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_DFECHA_NACIMIENTO",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Value = cliente.FECHA_NACIMIENTO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCUPO_CREDITO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = cliente.CUPO_CREDITO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OLIDER",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = cliente.LIDER
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OCABEZA_GRUPO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = cliente.CABEZA_GRUPO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OCUENTA_BLOQUEADA",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = cliente.CUENTA_BLOQUEADA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CRAZON_BLOQUEO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = cliente.RAZON_BLOQUEO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OGEOREFERENCIADO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = cliente.GEOREFERENCIADO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CFORMA_PAGO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = cliente.FORMA_PAGO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OCOBRA_FLETE",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = cliente.COBRA_FLETE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_PAIS",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = cliente.PAI_NID
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_REGIONAL",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = cliente.REG_CID
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_ZONA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = cliente.ZON_CID
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_SECCION",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = cliente.SEC_CID
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_TERRITORIO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = cliente.TER_CID
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_GENERO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = cliente.GEN_NID
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CIUDAD",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = cliente.CIU_NID
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_DEPTO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = cliente.DEP_NID
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_RIPO_DOCUMENTO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = cliente.TDO_NID
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_ESTADO_CIVIL",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = cliente.ECV_NID
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CAMPANA_INGRESO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = cliente.CAM_NID_INGRESO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_TIPO_CLIENTE",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = cliente.TIC_NID
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_FORMA_INGRESO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = cliente.FIN_NID
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_ESTADO_ACTIVIDAD",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = cliente.ESA_NID
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_DFECHA_VINCULACION",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Value = cliente.FECHA_VINCULACION
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_FORMA_PAGO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = cliente.FPG_NID
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OESINGRESO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = cliente.ESINGRESO
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NRESULTADO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = cliente.CODIGO
                },
            };

            return storeProcedure;
        }


        public StoreProcedure insReferenciasCliente(string spName, ReferenciaCliente referenciaCliente)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = referenciaCliente.NOMBRE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CDIRECCION",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = referenciaCliente.DIRECCION
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CCIUDAD",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = referenciaCliente.CIUDAD
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CTELEFONO_FIJO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = referenciaCliente.TEL_FIJO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CTELEFONO_CELULAR",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = referenciaCliente.TEL_CELULAR
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CPARENTESCO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = referenciaCliente.PARENTESCO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CLIENTE",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = referenciaCliente.CODIGO_CLIENTE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_TIPO_REFERENCIA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = referenciaCliente.CODIGO_TIPO_REFERENCIA
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NRESULTADO",
                    SqlDbType = System.Data.SqlDbType.Decimal,
                    Direction=System.Data.ParameterDirection.Output,
                    Value = referenciaCliente.CODIGO
                },
            };

            return storeProcedure;
        }


        public StoreProcedure getReferenciaCliente(string spName, int intCodigoCliente)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CLIENTE",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = intCodigoCliente
                },
            };

            return storeProcedure;
        }

        public StoreProcedure getCupoMinimoCredito(string spName)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            return storeProcedure;
        }

        public StoreProcedure getValidaExisteCliente(string spName, string strIdentificacionCliente)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_CIDENTIFICACION",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = strIdentificacionCliente
                },
            };

            return storeProcedure;
        }

        public StoreProcedure getValidaCobrOFlete(string spName, int intcodigoTipo)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_TIPO_CLIENTE",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = intcodigoTipo
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_OCOBRA_FLETE",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = 0
                },
            };

            return storeProcedure;
        }
    }
}
