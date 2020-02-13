using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SIVEDI.Datos
{
    public class DataDB : DbContext
    {
        #region Global Variables 

        private string SqlParameters;


        private SqlParameter IdEntity { get; set; }

        #endregion

        #region Constructor

        public DataDB(string Contexto) : base("name=" + Contexto)
        { }

        #endregion

        #region Public Methods

        /// <summary>
        /// Método genérico para consultas que devuelven una lista de Entidades
        /// </summary>
        /// <typeparam name="T">Entidad en la que se almacena el resultado y que será retornada</typeparam>
        /// <param name="SP">Entidad StoreProcedure, que contiene el nombre del procedimiento almacenado y los parámetros a usar</param>
        /// <returns></returns>
        public List<T> ExecuteQueryList<T>(StoreProcedure SP)
        {
            List<T> Result = new List<T>();

            try
            {
                if (SP.Parametros != null)
                {
                    var sql = GenerateCommandText(SP.Nombre, SP.Parametros.ToArray());
                    Result = Database.SqlQuery<T>(sql, SP.Parametros.ToArray()).ToList();
                }
                else
                {
                    Result = Database.SqlQuery<T>("EXEC " + SP.Nombre).ToList();
                }

            }
            catch (SqlException exSqL)
            {
                throw exSqL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Result;
        }

        /// <summary>
        /// Método genérico para consultas que devuelven un solo registro
        /// </summary>
        /// <typeparam name="T">Entidad en la que se almacena el resultado y que será retornada</typeparam>
        /// <param name="SP">Entidad StoreProcedure, que contiene el nombre del procedimiento almacenado y los parámetros a usar</param>
        /// <returns></returns>
        public T ExecuteQuery<T>(StoreProcedure SP)
        {
            T Result;
            try
            {
                if (SP.Parametros != null)
                {
                    string strprueba = SP.Nombre + Sql(SP.Parametros);
                    Result = Database.SqlQuery<T>(SP.Nombre + Sql(SP.Parametros), SP.Parametros.ToArray()).FirstOrDefault();
                }
                else
                {
                    Result = Database.SqlQuery<T>("EXEC " + SP.Nombre).FirstOrDefault();
                }

                return Result;
            }
            catch (SqlException exSqL)
            {
                throw exSqL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método genérico para ejecución de acciones Insert, Update y/o Delete 
        /// </summary>
        /// <param name="SP">Entidad StoreProcedure, que contiene el nombre del procedimiento almacenado y los parámetros a usar</param>
        /// <returns></returns>
        public int ExecuteUD(StoreProcedure SP)
        {
            var Result = 0;
            try
            {
                var sql = GenerateCommandText(SP.Nombre, SP.Parametros.ToArray());
                Result = Database.ExecuteSqlCommand(sql, SP.Parametros.ToArray());

                return Result;
            }
            catch (SqlException exSqL)
            {
                throw exSqL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método genérico para ejecución de acciones Insert, Update y/o Delete de modo asyncrono
        /// </summary>
        /// <param name="SP">Entidad StoreProcedure, que contiene el nombre del procedimiento almacenado y los parámetros a usar</param>
        /// <returns></returns>
        public async Task<int> ExecuteUDAsync(StoreProcedure SP)
        {
            var Result = 0;
            try
            {
                var sql = GenerateCommandText(SP.Nombre, SP.Parametros.ToArray());
                Result = await Database.ExecuteSqlCommandAsync(sql, SP.Parametros.ToArray());

                return Result;
            }
            catch (SqlException exSqL)
            {
                throw exSqL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método genérico para ejecución de acciones Insert con parametros Output
        /// </summary>
        /// <param name="SP">Entidad StoreProcedure, que contiene el nombre del procedimiento almacenado y los parámetros a usar</param>
        /// <param name="IdEntityName">Nombre del Parametro en el que se realiza el retorno</param>
        /// <returns></returns>
        public int ExecuteInsert(StoreProcedure SP, string IdEntityName)
        {
            int Result = 0;

            try
            {
                Result = Database.ExecuteSqlCommand(SP.Nombre + Sql(SP.Parametros), SP.Parametros.ToArray());
                if (Result > 0)
                    IdEntity = SP.Parametros.FirstOrDefault(x => x.ParameterName == "@" + IdEntityName);
                else
                    IdEntity.Value = 0;

                return Convert.ToInt32(IdEntity.Value);
            }
            catch (SqlException exSqL)
            {
                throw exSqL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Genera string de los parametros para el SP
        /// </summary>
        /// <param name="Items"></param>
        /// <returns></returns>
        private string Sql(List<SqlParameter> Items)
        {
            this.SqlParameters = string.Empty;
            foreach (var Item in Items)
            {

                string nameParameter = (Item.Direction.Equals(System.Data.ParameterDirection.Output))
                ? Item.ParameterName + " OUT"
                : Item.ParameterName;


                this.SqlParameters = (!Item.Equals(Items.Last()))
                    ? this.SqlParameters + " " + nameParameter + ", "
                    : this.SqlParameters + " " + nameParameter;
            }

            return SqlParameters;

        }


        private static string GenerateCommandText(string storedProcedure, SqlParameter[] parameters)
        {
            string CommandText = "EXEC {0} {1}";
            string[] ParameterNames = new string[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                ParameterNames[i] = parameters[i].ParameterName;
            }

            return string.Format(CommandText, storedProcedure, string.Join(",", ParameterNames));
        }
        #endregion
    }
}