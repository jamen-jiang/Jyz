using Jyz.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Jyz.Infrastructure.Data.Extensions
{
    public static class DbContextExtension
    {
        /// <summary>
        /// 执行sql返回受影响的行数
        /// </summary>
        public static async Task<int> ExecSqlNoQuery(this JyzContext db, string sql, params SqlParameter[] sqlParams) 
        {
            return await ExecuteNoQuery(db, sql, sqlParams);
        }
        /// <summary>
        /// 执行存储过程返回IEnumerable数据集
        /// </summary>
        public static async Task<IEnumerable<T>> ExecProcReader<T>(this JyzContext db, string sql, params SqlParameter[] sqlParams) where T : new()
        {
            return await Execute<T>(db, sql, CommandType.StoredProcedure, sqlParams);
        }
        /// <summary>
        /// 执行sql返回IEnumerable数据集
        /// </summary>
        public static async Task<IEnumerable<T>> ExecSqlReader<T>(this JyzContext db, string sql, params SqlParameter[] sqlParams) where T : new()
        {
            return await Execute<T>(db, sql, CommandType.Text, sqlParams);
        }
        /// <summary>
        /// 执行sql返回受影响行数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <param name="sql"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        private static async Task<int> ExecuteNoQuery(this JyzContext db, string sql,params SqlParameter[] sqlParams)
        {
            DbConnection connection = db.Database.GetDbConnection();
            DbCommand cmd = connection.CreateCommand();
            db.Database.OpenConnection();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            if (sqlParams != null)
            {
                cmd.Parameters.AddRange(sqlParams);
            }
            int result = await cmd.ExecuteNonQueryAsync();
            db.Database.CloseConnection();
            return result;
        }
        /// <summary>
        /// 执行sql返回列表数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        private static async Task<IEnumerable<T>> Execute<T>(this JyzContext db, string sql, CommandType type, SqlParameter[] sqlParams) where T : new()
        {
            DbConnection connection = db.Database.GetDbConnection();
            DbCommand cmd = connection.CreateCommand();
            db.Database.OpenConnection();
            cmd.CommandText = sql;
            cmd.CommandType = type;
            if (sqlParams != null)
            {
                cmd.Parameters.AddRange(sqlParams);
            }
            DataTable dt = new DataTable();
            using (DbDataReader reader = await cmd.ExecuteReaderAsync())
            {
                dt.Load(reader);
            }
            db.Database.CloseConnection();
            return dt.ToCollection<T>();
        }
    }
}
