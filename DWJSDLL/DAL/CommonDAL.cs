using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Eastcom.DBUtility;

namespace DAL
{
    public class CommonDAL
    {
        #region 分页
        /// <summary>
        /// 分页(可按非主键排序)
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetPageList(Eastcom.DBUtility.DbHelperSQLP con, string tableName, int PageSize, int PageIndex, ref int recordCount, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            DataTable dt = null;
            SqlParameter[] parameters = {
											new SqlParameter("@RecordCount", SqlDbType.Int),//总记录数
											new SqlParameter("@PageCount", SqlDbType.Int),//总页数
											new SqlParameter("@PageSize", SqlDbType.Int),//每页最多显示多少条
											new SqlParameter("@PageCurrent", SqlDbType.Int),	//当前页码  1为第一页
											new SqlParameter("@tbname", SqlDbType.NVarChar),//表名
											new SqlParameter("@FieldShow", SqlDbType.NVarChar),
											new SqlParameter("@Where", SqlDbType.NVarChar),
											new SqlParameter("@FieldOrder", SqlDbType.NVarChar),
                                            new SqlParameter("@FieldKey", SqlDbType.NVarChar)
											};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Direction = ParameterDirection.Output;
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;//存储过程中1为第一页。
            parameters[4].Value = tableName;
            parameters[5].Value = fieldName;
            parameters[6].Value = strWhere;
            parameters[7].Value = fieldOrder;
            parameters[8].Value = fieldKey;
            DataSet ds = con.RunProcedure("proc_pager", parameters, "ds",600);
            int.TryParse(parameters[0].Value.ToString(), out recordCount);
            if (null != ds.Tables[0])
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 分页(可按非主键排序)
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetPageList(string tableName, int PageSize, int PageIndex, ref int recordCount, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            DataTable dt = null;
            SqlParameter[] parameters = {
											new SqlParameter("@RecordCount", SqlDbType.Int),//总记录数
											new SqlParameter("@PageCount", SqlDbType.Int),//总页数
											new SqlParameter("@PageSize", SqlDbType.Int),//每页最多显示多少条
											new SqlParameter("@PageCurrent", SqlDbType.Int),	//当前页码  1为第一页
											new SqlParameter("@tbname", SqlDbType.NVarChar),//表名
											new SqlParameter("@FieldShow", SqlDbType.NVarChar),
											new SqlParameter("@Where", SqlDbType.NVarChar),
											new SqlParameter("@FieldOrder", SqlDbType.NVarChar),
                                            new SqlParameter("@FieldKey", SqlDbType.NVarChar)
											};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Direction = ParameterDirection.Output;
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;//存储过程中1为第一页。
            parameters[4].Value = tableName;
            parameters[5].Value = fieldName;
            parameters[6].Value = strWhere;
            parameters[7].Value = fieldOrder;
            parameters[8].Value = fieldKey;
            DataSet ds = DbHelperSQL.RunProcedure("proc_pager", parameters, "ds");
            int.TryParse(parameters[0].Value.ToString(), out recordCount);
            if (null != ds.Tables[0])
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        
        
        #endregion
    }
}
