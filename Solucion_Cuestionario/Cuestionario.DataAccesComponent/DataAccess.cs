using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Cuestionario.DataAccesComponent
{
        public class DataAccess
    {
        private string _connectionString;
        private string _errorMessage;
        private int _timeOut;

        public DataAccess()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["pagosProvisionalesConnectionString"].ConnectionString;
            _timeOut = int.Parse(ConfigurationManager.AppSettings["CommandTimeOut"]);
        }


        public DataSet ExecuteDataSet(string procedureName)
        {
            _errorMessage = "";
            SqlConnection conn = null;
            DataSet ds = new DataSet();
            try
            {
                conn = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand(procedureName, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = _timeOut;

                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                conn.Open();
                da.Fill(ds);
            }
            catch (Exception e)
            {
                _errorMessage = e.Message;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return ds;
        }
        public DataSet ExecuteDataSet(string procedureName, string tableName)
        {
            _errorMessage = "";
            SqlConnection conn = null;
            DataSet ds = new DataSet();
            try
            {
                conn = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand(procedureName, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = _timeOut;

                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                conn.Open();
                da.Fill(ds, tableName);
            }
            catch (Exception e)
            {
                _errorMessage = e.Message;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return ds;
        }
        public DataSet ExecuteDataSet(string procedureName, SqlParameter[] parameterArray)
        {
            _errorMessage = "";
            SqlConnection conn = null;
            DataSet ds = new DataSet();
            try
            {
                conn = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand(procedureName, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = _timeOut;

                SqlParameter sqlParameter;

                for (int i = 0; i < parameterArray.Length; i++)
                {
                    sqlParameter = sqlCommand.Parameters.Add(parameterArray[i].ParameterName.ToString(), parameterArray[i].Value.GetType());
                    sqlParameter.Value = parameterArray[i].Value;

                }

                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                da.Fill(ds);
            }
            catch (Exception e)
            {
                _errorMessage = e.Message;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return ds;
        }
        public DataSet ExecuteSQLQuery(string sqlQuery)
        {
            _errorMessage = "";
            SqlConnection conn = null;
            DataSet ds = new DataSet();
            try
            {
                conn = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandTimeout = _timeOut;

                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                conn.Open();
                da.Fill(ds);
            }
            catch (Exception e)
            {
                _errorMessage = e.Message;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return ds;
        }
        public int ExecuteScalar(string procedureName)
        {
            _errorMessage = "";
            SqlConnection conn = null;
            int result = -1;
            try
            {
                conn = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand(procedureName, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = _timeOut;

                conn.Open();
                result = (int)sqlCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                _errorMessage = e.Message;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return result;
        }
        public int ExecuteScalar(string procedureName, SqlParameter[] parameterArray)
        {
            _errorMessage = "";
            SqlConnection conn = null;
            int result = -1;
            try
            {
                conn = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand(procedureName, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = _timeOut;

                SqlParameter sqlParameter;

                for (int i = 0; i < parameterArray.Length; i++)
                {
                    sqlParameter = sqlCommand.Parameters.Add(parameterArray[i].ParameterName.ToString(), parameterArray[i].Value.GetType());
                    sqlParameter.Value = parameterArray[i].Value;

                }

                conn.Open();
                result = (int)sqlCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                _errorMessage = e.Message;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return result;
        }
        public int ExecuteNonQuery(string procedureName, SqlParameter[] parameterArray, SqlParameter returnParameter)
        {
            _errorMessage = "";
            SqlConnection conn = null;
            int result = -1;
            try
            {
                conn = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand(procedureName, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = _timeOut;

                SqlParameter sqlParameter;

                for (int i = 0; i < parameterArray.Length; i++)
                {
                    sqlParameter = sqlCommand.Parameters.Add(parameterArray[i].ParameterName.ToString(), parameterArray[i].Value.GetType());
                    sqlParameter.Value = parameterArray[i].Value;

                }
                sqlCommand.Parameters.Add(returnParameter);
                conn.Open();
                result = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                _errorMessage = e.Message;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return result;
        }
        public int ExecuteNonQuery(string procedureName, SqlParameter[] parameterArray)
        {
            _errorMessage = "";
            SqlConnection conn = null;
            int result = -1;
            try
            {
                conn = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand(procedureName, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = _timeOut;

                SqlParameter sqlParameter;

                for (int i = 0; i < parameterArray.Length; i++)
                {
                    sqlParameter = sqlCommand.Parameters.Add(parameterArray[i].ParameterName.ToString(), parameterArray[i].Value.GetType());
                    sqlParameter.Value = parameterArray[i].Value;
                }
                conn.Open();
                result = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                _errorMessage = e.Message;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return result;
        }
        public SqlDataReader ExecuteReader(string procedureName)
        {
            _errorMessage = "";
            SqlConnection conn = null;
            SqlDataReader reader = null;
            try
            {
                conn = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand(procedureName, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = _timeOut;

                conn.Open();
                reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception e)
            {
                _errorMessage = e.Message;
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return reader;
        }
        public SqlDataReader ExecuteReader(string procedureName, SqlParameter[] parameterArray)
        {
            _errorMessage = "";
            SqlConnection conn = null;
            SqlDataReader reader = null;
            try
            {
                conn = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand(procedureName, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = _timeOut;

                SqlParameter sqlParameter;

                for (int i = 0; i < parameterArray.Length; i++)
                {
                    sqlParameter = sqlCommand.Parameters.Add(parameterArray[i].ParameterName.ToString(), parameterArray[i].Value.GetType());
                    sqlParameter.Value = parameterArray[i].Value;
                }

                conn.Open();
                reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception e)
            {
                _errorMessage = e.Message;
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return reader;
        }
        public SqlDataReader ExecuteSqlQueryReader(string sqlQuery)
        {
            _errorMessage = "";
            SqlConnection conn = null;
            SqlDataReader reader = null;
            try
            {
                conn = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.Connection = conn;
                sqlCommand.CommandTimeout = _timeOut;

                conn.Open();
                reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception e)
            {
                _errorMessage = e.Message;
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return reader;
        }
        public int ExecuteBulkCopy(DataTable dtSource, string tableDestination)
        {
            _errorMessage = "";
            SqlBulkCopy bulkCopy = null;
            try
            {
                bulkCopy = new SqlBulkCopy(_connectionString, SqlBulkCopyOptions.TableLock);
                bulkCopy.DestinationTableName = tableDestination;
                bulkCopy.WriteToServer(dtSource);
            }
            catch (Exception e)
            {
                _errorMessage = e.Message;
            }

            return 0;
        }
    }
}
