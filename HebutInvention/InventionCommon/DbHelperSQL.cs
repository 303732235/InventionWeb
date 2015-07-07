using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Web;

/* ***********************************************
 * author :  Tyanjun
 * email  :  Tyanjun@126.com        qq:497529628
 * file   :  Class1
 * history:  created by Tyanjun 2011-7-23 11:29:10 
 * ***********************************************/

namespace InventionCommon
{
    /// <summary>
    /// 数据访问抽象基础类 
    /// </summary>
    public abstract class DbHelperSQL
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString = PubConstant.ConnectionString;
        public DbHelperSQL()
        {
        }

        /// <summary>
        /// 配置SqlCommand
        /// </summary>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {


                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    if (parameter != null)
                    {
                        // 检查未分配值的输出参数,将其分配以DBNull.Value.
                        if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                            (parameter.Value == null))
                        {
                            parameter.Value = DBNull.Value;
                        }
                        command.Parameters.Add(parameter);
                    }
                }
            }
            return command;
        }

        /// <summary>
        /// 创建 SqlCommand 对象实例(用来返回一个整数值)	
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand 对象实例</returns>
        private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue",
                SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }


        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <param name="Times">设置在终止执行命令的尝试并生成错误之前的等待时间</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.SelectCommand.CommandTimeout = Times;
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }


        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.CommandTimeout = Times;
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString)
        {

                using (SqlCommand cmd = new SqlCommand(SQLString, conn))
                {
                    try
                    {
                        ConOpen();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        ConClose();
                        throw e;
                    }
                }
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.CommandTimeout = Times;
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, string content)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, connection);
                System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@content", SqlDbType.NText);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    throw e;
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(strSQL, connection);
                System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@fs", SqlDbType.Image);
                myParameter.Value = fs;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    throw e;
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public static object ExecuteSqlGet(string SQLString, string content)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, connection);
                System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@content", SqlDbType.NText);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    throw e;
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string strSQL)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSQL, connection);
            try
            {
                connection.Open();
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string SQLString, params SqlParameter[] cmdParms)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public static int ExecuteSqlTran(List<String> SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(ConStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    int count = 0;
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n];
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            count += cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                    return count;
                }
                catch
                {
                    tx.Rollback();
                    return 0;
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public static void ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        //循环
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }



        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public static void ExecuteSqlTranWithIndentity(Hashtable SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        int indentity = 0;
                        //循环
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                            foreach (SqlParameter q in cmdParms)
                            {
                                if (q.Direction == ParameterDirection.InputOutput)
                                {
                                    q.Value = indentity;
                                }
                            }
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            foreach (SqlParameter q in cmdParms)
                            {
                                if (q.Direction == ParameterDirection.Output)
                                {
                                    indentity = Convert.ToInt32(q.Value);
                                }
                            }
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }



        /// <summary>
        /// 执行存储过程，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataReader returnReader;
            connection.Open();
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;
            returnReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return returnReader;

        }

        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int result;
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
                rowsAffected = command.ExecuteNonQuery();
                result = (int)command.Parameters["ReturnValue"].Value;
                //Connection.Close();
                return result;
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection conn = new SqlConnection(ConStr))
            {
                DataSet dataSet = new DataSet();
                conn.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(conn, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                conn.Close();
                return dataSet;
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedureNoTablename(string storedProcName, IDataParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet);
                connection.Close();
                return dataSet;
            }
        }

        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.SelectCommand.CommandTimeout = Times;
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }

        public static bool Exists(string strSql)
        {
            object obj = GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            object obj = GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 表是否存在
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static bool TabExists(string TableName)
        {
            string strsql = "select count(*) from sysobjects where id = object_id(N'[" + TableName + "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1";
            //string strsql = "SELECT count(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" + TableName + "]') AND type in (N'U')";
            object obj = GetSingle(strsql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 判断是否存在某表的某个字段
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <param name="columnName">列名称</param>
        /// <returns>是否存在</returns>
        public static bool ColumnExists(string tableName, string columnName)
        {
            string sql = "select count(1) from syscolumns where [id]=object_id('" + tableName + "') and [name]='" + columnName + "'";
            object res = GetSingle(sql);
            if (res == null)
            {
                return false;
            }
            return Convert.ToInt32(res) > 0;
        }


        ///////////////////////////////////////进行增删查改操作////////////////////////////////////////////
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="obj">表名称对象</param>
        /// <param name="AutoID">自增列</param>
        /// <returns>是否插入成功</returns>
        public static bool Insert(object obj)
        {
            string[] ModelInfo = Common<object>.GetModelInfo(obj);
            StringBuilder Columns = new StringBuilder("");
            StringBuilder Values = new StringBuilder("");
            Type t = obj.GetType();
            string sql = "insert into " + ModelInfo[0] + " ({0}) values ({1})";
            PropertyInfo[] pis = t.GetProperties();
            for (int i = 0; i < pis.Length; i++)
            {
                if (pis[i].Name.ToString().ToLower() != ModelInfo[1].ToLower())
                {
                    Columns.Append(pis[i].Name.ToString());
                    if (pis[i].GetValue(obj, null) == null)
                    {
                        Values.Append("''");
                    }
                    else
                    {
                        if (pis[i].PropertyType.Name.ToString().ToLower() == "datetime" || pis[i].PropertyType.Name.ToString().ToLower() == "string")
                            Values.Append("'" + pis[i].GetValue(obj, null).ToString().Replace("'", "’") + "'");
                        else
                            Values.Append(pis[i].GetValue(obj, null).ToString().Replace("'", "’"));
                    }
                    Columns.Append(",");
                    Values.Append(",");
                }
            }
            if (ExecuteSql(string.Format(sql, Columns.ToString().TrimEnd(','), Values.ToString().TrimEnd(','))) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据表名删除记录
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="AutoID">自动增长id</param>
        /// <param name="value">id值</param>
        /// <returns>是否删除</returns>
        public static bool Delete(object obj)
        {
            string[] ModelInfo = Common<object>.GetModelInfo(obj);
            string sql = "Delete from " + ModelInfo[0] + " where " + ModelInfo[1] + "=";
            Type t = obj.GetType();
            PropertyInfo[] pis = t.GetProperties();
            for (int i = 0; i < pis.Length; i++)
            {
                if (pis[i].Name.ToString().ToLower() == ModelInfo[1].ToLower())
                { sql += pis[i].GetValue(obj, null).ToString(); break; }
            }
            if (ExecuteSql(sql) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="obj">对象名</param>
        /// <param name="condition">条件</param>
        /// <returns>返回是否成功</returns>
        public static bool Delete(object obj, string conditions)
        {
            string[] ModelInfo = Common<object>.GetModelInfo(obj);
            string sql = "Delete from " + ModelInfo[0] + (conditions.Trim().Length > 0 ? " where " + conditions : "");
            if (ExecuteSql(sql) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据条件返回查询到的DataTable
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="conditions">条件</param>
        /// <returns></returns>
        public static DataTable FindByConditions(object obj, string conditions)
        {

            string sql = "select * from " + Common<object>.GetModelInfo(obj)[0] + (conditions.Trim().Length <= 0 ? "" : " where " + conditions);
            return Query(sql).Tables[0];
        }

        /// <summary>
        /// 返回符合记录的数据条数
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="conditions">条件</param>
        /// <returns></returns>
        public static string GetCountByConditions(object obj, string conditions)
        {
            string sql = "select count(*) from " + Common<object>.GetModelInfo(obj)[0];
            if (conditions.Trim().Length > 0)
                sql += " where " + conditions;
            try
            {
                return Query(sql).Tables[0].Rows[0][0].ToString();
            }
            catch
            {
                return "0";
            }
        }

        public static int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }


        /// <summary>
        /// 分页查询，返回当前页的DataTable
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="AutoID">自动增长列</param>
        /// <param name="start">起始记录号</param>
        /// <param name="limit">分页大小</param>
        /// <param name="conditions">附加条件</param>
        /// <returns></returns>
        public static DataTable FindByPage(object obj, string start, string limit, string conditions)
        {
            string[] ModelInfo = Common<object>.GetModelInfo(obj);
            SqlParameter par1 = new SqlParameter("@TableName", SqlDbType.Char, 30);
            par1.Value = ModelInfo[0];
            SqlParameter par2 = new SqlParameter("@OrderBy", SqlDbType.Char, 20);
            par2.Value = ModelInfo[1];
            SqlParameter par3 = new SqlParameter("@PageNum", SqlDbType.Int);
            par3.Value = Int32.Parse(start) / Int32.Parse(limit) + 1;
            SqlParameter par4 = new SqlParameter("@PageSize", SqlDbType.Int);
            par4.Value = Int32.Parse(limit);

            SqlParameter par6 = new SqlParameter("@PageCount", SqlDbType.Int);
            SqlParameter par7 = new SqlParameter("@RecordCount", SqlDbType.BigInt);

            DataSet dsClass = null;
            if (conditions.Trim().Length > 0)
            {
                string storeProcName = "proc_GetModelByPageWithCondition";
                SqlParameter par5 = new SqlParameter("@Condition", SqlDbType.Char, 50);
                par5.Value = conditions;
                SqlParameter[] cmdParms = { par1, par2, par3, par4, par5, par6, par7 };
                dsClass = DbHelperSQL.RunProcedure(storeProcName, cmdParms, "Paging");
            }
            else
            {
                string storeProcName = "proc_GetModelByPage";
                SqlParameter[] cmdParms = { par1, par2, par3, par4, par6, par7 };
                dsClass = DbHelperSQL.RunProcedure(storeProcName, cmdParms, "Paging");
            }

            return dsClass.Tables[0];
        }


        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="obj">表实体</param>
        /// <returns>是否更新成功</returns>
        public static bool Update(object obj)
        {
            string[] ModelInfo = Common<object>.GetModelInfo(obj);
            StringBuilder Values = new StringBuilder("");
            string conditions = ModelInfo[1] + "=";
            Type t = obj.GetType();
            string sql = "update " + ModelInfo[0] + " set ";
            PropertyInfo[] pis = t.GetProperties();
            for (int i = 0; i < pis.Length; i++)
            {
                if (pis[i].Name.ToString().ToLower() != ModelInfo[1].ToLower())
                {
                    Values.Append(pis[i].Name.ToString());
                    Values.Append("=");
                    if (pis[i].GetValue(obj, null) == null)
                    {
                        Values.Append("''");
                    }
                    else
                    {
                        if (pis[i].PropertyType.Name.ToString().ToLower() == "datetime" || pis[i].PropertyType.Name.ToString().ToLower() == "string")
                            Values.Append("'" + pis[i].GetValue(obj, null).ToString().Replace("'", "’") + "'");
                        else
                            Values.Append(pis[i].GetValue(obj, null).ToString().Replace("'", "’"));
                    }
                    Values.Append(",");
                }
                else
                    conditions += pis[i].GetValue(obj, null).ToString();
            }
            if (ExecuteSql(sql + Values.ToString().TrimEnd(',') + " where " + conditions) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="obj">表实体</param>
        /// <returns>是否更新成功</returns>
        public static bool Update(object obj, string sets, string conditions)
        {
            string[] ModelInfo = Common<object>.GetModelInfo(obj);
            string sql = "update " + ModelInfo[0] + " set " + sets + (conditions.Trim().Length > 0 ? " where " + conditions : "");
            if (ExecuteSql(sql) > 0)
                return true;
            else
                return false;
        }
        private static string ConStr = System.Configuration.ConfigurationSettings.AppSettings["ConStr"];
        private static SqlConnection conn = new SqlConnection(ConStr);
        private static void ConOpen()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        private static void ConClose()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 执行SQL语句，返回bool
        /// </summary>
        /// <param name="sql">insert、update、delete</param>
        /// <returns></returns>
        public static bool ExecSqlCommand(string sql)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            try
            {
                ConOpen();
                int i = cmd.ExecuteNonQuery();
                return i > 0 ? true : false;
            }
            catch
            {
                return false;
            }
            finally
            {
                ConClose();
            }


        }
        public static bool Detect(string sql)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            try
            {
                ConOpen();
                SqlDataReader result = cmd.ExecuteReader();
                return result.Read();
            }
            catch
            {
                return false;
            }
            finally
            {
                ConClose();
            }


        }
        public static DataRow GetDateRow(string sql)
        {
            DataSet ds = new DataSet();
            try
            {
                ConOpen();
                SqlDataAdapter dpt = new SqlDataAdapter(sql, conn);
                dpt.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                return i > 0 ? ds.Tables[0].Rows[0] : null;
            }
            catch
            {
                return null;
            }
            finally
            {
                ConClose();
            }

        }

        public static DataSet GetDataSet(string sql)
        {
            DataSet ds = new DataSet();
            try
            {
                ConOpen();
                SqlDataAdapter dpt = new SqlDataAdapter(sql, conn);
                dpt.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                return i > 0 ? ds : null;
            }
            catch
            {
                return null;
            }
            finally
            {
                ConClose();
            }
        }
        public static int GetCount()//统计访问流量
        {

            try
            {
                ConOpen();
                SqlCommand cmd = new SqlCommand("select * from tongji", conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count;
            }
            catch
            {
                return 0;
            }
            finally
            {
                ConClose();
            }
        }
        public static void UpdateCount(int count)//更新统计的访问流量
        {

            try
            {
                ConOpen();
                SqlCommand cmd = new SqlCommand("update tongji set Number=" + count, conn);
                cmd.ExecuteNonQuery();

            }
            catch
            {

            }
            finally
            {
                ConClose();
            }
        }
    }
}
    


