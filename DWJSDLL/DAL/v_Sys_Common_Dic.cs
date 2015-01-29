﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Eastcom.DBUtility;//Please add references

namespace Eastcom.DAL
{
    /// <summary>
    /// 数据访问类:v_Sys_Common_Dic
    /// </summary>
    public partial class v_Sys_Common_Dic
    {
        public v_Sys_Common_Dic()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int DicID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from v_Sys_Common_Dic");
            strSql.Append(" where DicID=@DicID ");
            SqlParameter[] parameters = {
					new SqlParameter("@DicID", SqlDbType.Int,4)			};
            parameters[0].Value = DicID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Eastcom.Model.v_Sys_Common_Dic model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into v_Sys_Common_Dic(");
            strSql.Append("DicID,ParentID,DicName,DicValue,IsReadOnly,IsHasChild,Remark,FK_EditID,EditTime,FK_CreateID,CreateTime,Sort,父权限名,创建者名,修改者名)");
            strSql.Append(" values (");
            strSql.Append("@DicID,@ParentID,@DicName,@DicValue,@IsReadOnly,@IsHasChild,@Remark,@FK_EditID,@EditTime,@FK_CreateID,@CreateTime,@Sort,@父权限名,@创建者名,@修改者名)");
            SqlParameter[] parameters = {
					new SqlParameter("@DicID", SqlDbType.Int,4),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@DicName", SqlDbType.VarChar,500),
					new SqlParameter("@DicValue", SqlDbType.VarChar,500),
					new SqlParameter("@IsReadOnly", SqlDbType.TinyInt,1),
					new SqlParameter("@IsHasChild", SqlDbType.TinyInt,1),
					new SqlParameter("@Remark", SqlDbType.VarChar,1000),
					new SqlParameter("@FK_EditID", SqlDbType.Int,4),
					new SqlParameter("@EditTime", SqlDbType.DateTime),
					new SqlParameter("@FK_CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@父权限名", SqlDbType.VarChar,500),
					new SqlParameter("@创建者名", SqlDbType.VarChar,50),
					new SqlParameter("@修改者名", SqlDbType.VarChar,50)};
            parameters[0].Value = model.DicID;
            parameters[1].Value = model.ParentID;
            parameters[2].Value = model.DicName;
            parameters[3].Value = model.DicValue;
            parameters[4].Value = model.IsReadOnly;
            parameters[5].Value = model.IsHasChild;
            parameters[6].Value = model.Remark;
            parameters[7].Value = model.FK_EditID;
            parameters[8].Value = model.EditTime;
            parameters[9].Value = model.FK_CreateID;
            parameters[10].Value = model.CreateTime;
            parameters[11].Value = model.Sort;
            parameters[12].Value = model.父权限名;
            parameters[13].Value = model.创建者名;
            parameters[14].Value = model.修改者名;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(Eastcom.Model.v_Sys_Common_Dic model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update v_Sys_Common_Dic set ");
            strSql.Append("DicID=@DicID,");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("DicName=@DicName,");
            strSql.Append("DicValue=@DicValue,");
            strSql.Append("IsReadOnly=@IsReadOnly,");
            strSql.Append("IsHasChild=@IsHasChild,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("FK_EditID=@FK_EditID,");
            strSql.Append("EditTime=@EditTime,");
            strSql.Append("FK_CreateID=@FK_CreateID,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("父权限名=@父权限名,");
            strSql.Append("创建者名=@创建者名,");
            strSql.Append("修改者名=@修改者名");
            strSql.Append(" where DicID=@DicID ");
            SqlParameter[] parameters = {
					new SqlParameter("@DicID", SqlDbType.Int,4),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@DicName", SqlDbType.VarChar,500),
					new SqlParameter("@DicValue", SqlDbType.VarChar,500),
					new SqlParameter("@IsReadOnly", SqlDbType.TinyInt,1),
					new SqlParameter("@IsHasChild", SqlDbType.TinyInt,1),
					new SqlParameter("@Remark", SqlDbType.VarChar,1000),
					new SqlParameter("@FK_EditID", SqlDbType.Int,4),
					new SqlParameter("@EditTime", SqlDbType.DateTime),
					new SqlParameter("@FK_CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@父权限名", SqlDbType.VarChar,500),
					new SqlParameter("@创建者名", SqlDbType.VarChar,50),
					new SqlParameter("@修改者名", SqlDbType.VarChar,50)};
            parameters[0].Value = model.DicID;
            parameters[1].Value = model.ParentID;
            parameters[2].Value = model.DicName;
            parameters[3].Value = model.DicValue;
            parameters[4].Value = model.IsReadOnly;
            parameters[5].Value = model.IsHasChild;
            parameters[6].Value = model.Remark;
            parameters[7].Value = model.FK_EditID;
            parameters[8].Value = model.EditTime;
            parameters[9].Value = model.FK_CreateID;
            parameters[10].Value = model.CreateTime;
            parameters[11].Value = model.Sort;
            parameters[12].Value = model.父权限名;
            parameters[13].Value = model.创建者名;
            parameters[14].Value = model.修改者名;

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
        public bool Delete(int DicID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from v_Sys_Common_Dic ");
            strSql.Append(" where DicID=@DicID ");
            SqlParameter[] parameters = {
					new SqlParameter("@DicID", SqlDbType.Int,4)			};
            parameters[0].Value = DicID;

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
        public bool DeleteList(string DicIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from v_Sys_Common_Dic ");
            strSql.Append(" where DicID in (" + DicIDlist + ")  ");
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
        public Eastcom.Model.v_Sys_Common_Dic GetModel(int DicID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 DicID,ParentID,DicName,DicValue,IsReadOnly,IsHasChild,Remark,FK_EditID,EditTime,FK_CreateID,CreateTime,Sort,父权限名,创建者名,修改者名 from v_Sys_Common_Dic ");
            strSql.Append(" where DicID=@DicID ");
            SqlParameter[] parameters = {
					new SqlParameter("@DicID", SqlDbType.Int,4)			};
            parameters[0].Value = DicID;

            Eastcom.Model.v_Sys_Common_Dic model = new Eastcom.Model.v_Sys_Common_Dic();
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
        public Eastcom.Model.v_Sys_Common_Dic DataRowToModel(DataRow row)
        {
            Eastcom.Model.v_Sys_Common_Dic model = new Eastcom.Model.v_Sys_Common_Dic();
            if (row != null)
            {
                if (row["DicID"] != null && row["DicID"].ToString() != "")
                {
                    model.DicID = int.Parse(row["DicID"].ToString());
                }
                if (row["ParentID"] != null && row["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(row["ParentID"].ToString());
                }
                if (row["DicName"] != null)
                {
                    model.DicName = row["DicName"].ToString();
                }
                if (row["DicValue"] != null)
                {
                    model.DicValue = row["DicValue"].ToString();
                }
                if (row["IsReadOnly"] != null && row["IsReadOnly"].ToString() != "")
                {
                    model.IsReadOnly = int.Parse(row["IsReadOnly"].ToString());
                }
                if (row["IsHasChild"] != null && row["IsHasChild"].ToString() != "")
                {
                    model.IsHasChild = int.Parse(row["IsHasChild"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["FK_EditID"] != null && row["FK_EditID"].ToString() != "")
                {
                    model.FK_EditID = int.Parse(row["FK_EditID"].ToString());
                }
                if (row["EditTime"] != null && row["EditTime"].ToString() != "")
                {
                    model.EditTime = DateTime.Parse(row["EditTime"].ToString());
                }
                if (row["FK_CreateID"] != null && row["FK_CreateID"].ToString() != "")
                {
                    model.FK_CreateID = int.Parse(row["FK_CreateID"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["Sort"] != null && row["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(row["Sort"].ToString());
                }
                if (row["父权限名"] != null)
                {
                    model.父权限名 = row["父权限名"].ToString();
                }
                if (row["创建者名"] != null)
                {
                    model.创建者名 = row["创建者名"].ToString();
                }
                if (row["修改者名"] != null)
                {
                    model.修改者名 = row["修改者名"].ToString();
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
            strSql.Append("select DicID,ParentID,DicName,DicValue,IsReadOnly,IsHasChild,Remark,FK_EditID,EditTime,FK_CreateID,CreateTime,Sort,父权限名,创建者名,修改者名 ");
            strSql.Append(" FROM v_Sys_Common_Dic ");
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
            strSql.Append(" DicID,ParentID,DicName,DicValue,IsReadOnly,IsHasChild,Remark,FK_EditID,EditTime,FK_CreateID,CreateTime,Sort,父权限名,创建者名,修改者名 ");
            strSql.Append(" FROM v_Sys_Common_Dic ");
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
            strSql.Append("select count(1) FROM v_Sys_Common_Dic ");
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
                strSql.Append("order by T.DicID desc");
            }
            strSql.Append(")AS Row, T.*  from v_Sys_Common_Dic T ");
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
            parameters[0].Value = "v_Sys_Common_Dic";
            parameters[1].Value = "DicID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

