﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Web;
using System.Configuration;

namespace CommonClass.DataBase.Access
{
    /// <summary>
    /// Access数据库操作类
    /// </summary>
    public class AccessHelper
    {
        protected static OleDbConnection conn = new OleDbConnection();
        protected static OleDbCommand comm = new OleDbCommand();

        /// <summary>
        /// 构造函数
        /// </summary>
        public AccessHelper()
        {

        }

        /// <summary>
        /// 打开数据库
        /// </summary>
        private static void OpenConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.ConnectionString = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["AccessConectionString"]);
                comm.Connection = conn;
                try
                {
                    conn.Open();
                }
                catch (Exception e)
                { throw new Exception(e.Message); }

            }

        }
        /// <summary>
        /// 关闭数据库
        /// </summary>
        private static void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
                comm.Dispose();
            }
        }
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sqlstr"></param>
        public static void ExcuteSql(string sqlstr)
        {
            try
            {
                OpenConnection();
                comm.CommandType = CommandType.Text;
                comm.CommandText = sqlstr;
                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            { CloseConnection(); }
        }
        /// <summary>
        /// 返回指定sql语句的OleDbDataReader对象，使用时请注意关闭这个对象。
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public static OleDbDataReader DataReader(string sqlstr)
        {
            OleDbDataReader dr = null;
            try
            {
                OpenConnection();
                comm.CommandText = sqlstr;
                comm.CommandType = CommandType.Text;

                dr = comm.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                try
                {
                    dr.Close();
                    CloseConnection();
                }
                catch { }
            }
            return dr;
        }
        /// <summary>
        /// 返回指定sql语句的OleDbDataReader对象,使用时请注意关闭
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <param name="dr"></param>
        public static void DataReader(string sqlstr, ref OleDbDataReader dr)
        {
            try
            {
                OpenConnection();
                comm.CommandText = sqlstr;
                comm.CommandType = CommandType.Text;
                dr = comm.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                try
                {
                    if (dr != null && !dr.IsClosed)
                        dr.Close();
                }
                catch
                {
                }
                finally
                {
                    CloseConnection();
                }
            }
        }
        /// <summary>
        /// 返回指定sql语句的dataset
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public static DataSet DataSet(string sqlstr)
        {
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter();
            try
            {
                OpenConnection();
                comm.CommandType = CommandType.Text;
                comm.CommandText = sqlstr;
                da.SelectCommand = comm;
                da.Fill(ds);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                CloseConnection();
            }
            return ds;
        }
        /// <summary>
        /// 返回指定sql语句的dataset
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <param name="ds"></param>
        public static void DataSet(string sqlstr, ref DataSet ds)
        {
            OleDbDataAdapter da = new OleDbDataAdapter();
            try
            {
                OpenConnection();
                comm.CommandType = CommandType.Text;
                comm.CommandText = sqlstr;
                da.SelectCommand = comm;
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        /// <summary>
        /// 返回指定sql语句的datatable
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public static DataTable DataTable(string sqlstr)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter();
            try
            {
                OpenConnection();
                comm.CommandType = CommandType.Text;
                comm.CommandText = sqlstr;
                da.SelectCommand = comm;
                da.Fill(dt);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }
        /// <summary>
        /// 返回指定sql语句的datatable
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <param name="dt"></param>
        public static void DataTable(string sqlstr, ref DataTable dt)
        {
            OleDbDataAdapter da = new OleDbDataAdapter();
            try
            {
                OpenConnection();
                comm.CommandType = CommandType.Text;
                comm.CommandText = sqlstr;
                da.SelectCommand = comm;
                da.Fill(dt);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        /// <summary>
        /// 返回指定sql语句的dataview
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public static DataView DataView(string sqlstr)
        {
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataView dv = new DataView();
            DataSet ds = new DataSet();
            try
            {
                OpenConnection();
                comm.CommandType = CommandType.Text;
                comm.CommandText = sqlstr;
                da.SelectCommand = comm;
                da.Fill(ds);
                dv = ds.Tables[0].DefaultView;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dv;
        }
    }
}
