using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Eastcom.DBUtility;
using DAL;//Please add references

namespace Eastcom.DAL
{
    /// <summary>
    /// 数据访问类:Sys_Common_Log
    /// </summary>
    public partial class Sys_Common_Log
    {
        public Sys_Common_Log()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int LogID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Common_Log");
            strSql.Append(" where LogID=@LogID");
            SqlParameter[] parameters = {
					new SqlParameter("@LogID", SqlDbType.Int,4)
			};
            parameters[0].Value = LogID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Eastcom.Model.Sys_Common_Log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Common_Log(");
            strSql.Append("DtDate,SThread,SLevel,SLogger,SMessage,SException)");
            strSql.Append(" values (");
            strSql.Append("@DtDate,@SThread,@SLevel,@SLogger,@SMessage,@SException)");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
					new SqlParameter("@DtDate", SqlDbType.DateTime),
					new SqlParameter("@SThread", SqlDbType.VarChar,500),
					new SqlParameter("@SLevel", SqlDbType.VarChar,500),
					new SqlParameter("@SLogger", SqlDbType.VarChar,500),
					new SqlParameter("@SMessage", SqlDbType.VarChar),
					new SqlParameter("@SException", SqlDbType.VarChar)};
            parameters[0].Value = model.DtDate;
            parameters[1].Value = model.SThread;
            parameters[2].Value = model.SLevel;
            parameters[3].Value = model.SLogger;
            parameters[4].Value = model.SMessage;
            parameters[5].Value = model.SException;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Eastcom.Model.Sys_Common_Log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Common_Log set ");
            strSql.Append("DtDate=@DtDate,");
            strSql.Append("SThread=@SThread,");
            strSql.Append("SLevel=@SLevel,");
            strSql.Append("SLogger=@SLogger,");
            strSql.Append("SMessage=@SMessage,");
            strSql.Append("SException=@SException");
            strSql.Append(" where LogID=@LogID");
            SqlParameter[] parameters = {
					new SqlParameter("@DtDate", SqlDbType.DateTime),
					new SqlParameter("@SThread", SqlDbType.VarChar,500),
					new SqlParameter("@SLevel", SqlDbType.VarChar,500),
					new SqlParameter("@SLogger", SqlDbType.VarChar,500),
					new SqlParameter("@SMessage", SqlDbType.VarChar),
					new SqlParameter("@SException", SqlDbType.VarChar),
					new SqlParameter("@LogID", SqlDbType.Int,4)};
            parameters[0].Value = model.DtDate;
            parameters[1].Value = model.SThread;
            parameters[2].Value = model.SLevel;
            parameters[3].Value = model.SLogger;
            parameters[4].Value = model.SMessage;
            parameters[5].Value = model.SException;
            parameters[6].Value = model.LogID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int LogID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Common_Log ");
            strSql.Append(" where LogID=@LogID");
            SqlParameter[] parameters = {
					new SqlParameter("@LogID", SqlDbType.Int,4)
			};
            parameters[0].Value = LogID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string LogIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Common_Log ");
            strSql.Append(" where LogID in (" + LogIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Eastcom.Model.Sys_Common_Log GetModel(int LogID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 LogID,DtDate,SThread,SLevel,SLogger,SMessage,SException from Sys_Common_Log ");
            strSql.Append(" where LogID=@LogID");
            SqlParameter[] parameters = {
					new SqlParameter("@LogID", SqlDbType.Int,4)
			};
            parameters[0].Value = LogID;

            Eastcom.Model.Sys_Common_Log model = new Eastcom.Model.Sys_Common_Log();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Eastcom.Model.Sys_Common_Log DataRowToModel(DataRow row)
        {
            Eastcom.Model.Sys_Common_Log model = new Eastcom.Model.Sys_Common_Log();
            if (row != null)
            {
                if (row["LogID"] != null && row["LogID"].ToString() != "")
                {
                    model.LogID = int.Parse(row["LogID"].ToString());
                }
                if (row["DtDate"] != null && row["DtDate"].ToString() != "")
                {
                    model.DtDate = DateTime.Parse(row["DtDate"].ToString());
                }
                if (row["SThread"] != null)
                {
                    model.SThread = row["SThread"].ToString();
                }
                if (row["SLevel"] != null)
                {
                    model.SLevel = row["SLevel"].ToString();
                }
                if (row["SLogger"] != null)
                {
                    model.SLogger = row["SLogger"].ToString();
                }
                if (row["SMessage"] != null)
                {
                    model.SMessage = row["SMessage"].ToString();
                }
                if (row["SException"] != null)
                {
                    model.SException = row["SException"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select LogID,DtDate,SThread,SLevel,SLogger,SMessage,SException ");
            strSql.Append(" FROM Sys_Common_Log ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" LogID,DtDate,SThread,SLevel,SLogger,SMessage,SException ");
            strSql.Append(" FROM Sys_Common_Log ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Sys_Common_Log ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.LogID desc");
            }
            strSql.Append(")AS Row, T.*  from Sys_Common_Log T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Sys_Common_Log";
            parameters[1].Value = "LogID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 分页(可按非主键排序)
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetPageList(int PageSize, int PageIndex, ref int recordCount, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            return CommonDAL.GetPageList("Sys_Common_Log", PageSize, PageIndex, ref recordCount, strWhere, fieldName, fieldKey, fieldOrder);
        }
        #endregion  ExtensionMethod
    }
}

