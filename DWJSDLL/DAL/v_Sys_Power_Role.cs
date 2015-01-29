using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Eastcom.DBUtility;//Please add references
namespace Eastcom.DAL
{
    /// <summary>
    /// 数据访问类:v_Sys_Power_Role
    /// </summary>
    public partial class v_Sys_Power_Role
    {
        public v_Sys_Power_Role()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from v_Sys_Power_Role");
            strSql.Append(" where RoleID=@RoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)			};
            parameters[0].Value = RoleID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Eastcom.Model.v_Sys_Power_Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into v_Sys_Power_Role(");
            strSql.Append("RoleID,RoleName,RoleWeight,Remark,FK_EditID,EditTime,FK_CreateID,CreateTime,Sort,创建者名,修改者名)");
            strSql.Append(" values (");
            strSql.Append("@RoleID,@RoleName,@RoleWeight,@Remark,@FK_EditID,@EditTime,@FK_CreateID,@CreateTime,@Sort,@创建者名,@修改者名)");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@RoleName", SqlDbType.VarChar,50),
					new SqlParameter("@RoleWeight", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,1000),
					new SqlParameter("@FK_EditID", SqlDbType.Int,4),
					new SqlParameter("@EditTime", SqlDbType.DateTime),
					new SqlParameter("@FK_CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@创建者名", SqlDbType.VarChar,50),
					new SqlParameter("@修改者名", SqlDbType.VarChar,50)};
            parameters[0].Value = model.RoleID;
            parameters[1].Value = model.RoleName;
            parameters[2].Value = model.RoleWeight;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.FK_EditID;
            parameters[5].Value = model.EditTime;
            parameters[6].Value = model.FK_CreateID;
            parameters[7].Value = model.CreateTime;
            parameters[8].Value = model.Sort;
            parameters[9].Value = model.创建者名;
            parameters[10].Value = model.修改者名;

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
        public bool Update(Eastcom.Model.v_Sys_Power_Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update v_Sys_Power_Role set ");
            strSql.Append("RoleID=@RoleID,");
            strSql.Append("RoleName=@RoleName,");
            strSql.Append("RoleWeight=@RoleWeight,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("FK_EditID=@FK_EditID,");
            strSql.Append("EditTime=@EditTime,");
            strSql.Append("FK_CreateID=@FK_CreateID,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("创建者名=@创建者名,");
            strSql.Append("修改者名=@修改者名");
            strSql.Append(" where RoleID=@RoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@RoleName", SqlDbType.VarChar,50),
					new SqlParameter("@RoleWeight", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,1000),
					new SqlParameter("@FK_EditID", SqlDbType.Int,4),
					new SqlParameter("@EditTime", SqlDbType.DateTime),
					new SqlParameter("@FK_CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@创建者名", SqlDbType.VarChar,50),
					new SqlParameter("@修改者名", SqlDbType.VarChar,50)};
            parameters[0].Value = model.RoleID;
            parameters[1].Value = model.RoleName;
            parameters[2].Value = model.RoleWeight;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.FK_EditID;
            parameters[5].Value = model.EditTime;
            parameters[6].Value = model.FK_CreateID;
            parameters[7].Value = model.CreateTime;
            parameters[8].Value = model.Sort;
            parameters[9].Value = model.创建者名;
            parameters[10].Value = model.修改者名;

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
        public bool Delete(int RoleID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from v_Sys_Power_Role ");
            strSql.Append(" where RoleID=@RoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)			};
            parameters[0].Value = RoleID;

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
        public bool DeleteList(string RoleIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from v_Sys_Power_Role ");
            strSql.Append(" where RoleID in (" + RoleIDlist + ")  ");
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
        public Eastcom.Model.v_Sys_Power_Role GetModel(int RoleID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 RoleID,RoleName,RoleWeight,Remark,FK_EditID,EditTime,FK_CreateID,CreateTime,Sort,创建者名,修改者名 from v_Sys_Power_Role ");
            strSql.Append(" where RoleID=@RoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)			};
            parameters[0].Value = RoleID;

            Eastcom.Model.v_Sys_Power_Role model = new Eastcom.Model.v_Sys_Power_Role();
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
        public Eastcom.Model.v_Sys_Power_Role DataRowToModel(DataRow row)
        {
            Eastcom.Model.v_Sys_Power_Role model = new Eastcom.Model.v_Sys_Power_Role();
            if (row != null)
            {
                if (row["RoleID"] != null && row["RoleID"].ToString() != "")
                {
                    model.RoleID = int.Parse(row["RoleID"].ToString());
                }
                if (row["RoleName"] != null)
                {
                    model.RoleName = row["RoleName"].ToString();
                }
                if (row["RoleWeight"] != null && row["RoleWeight"].ToString() != "")
                {
                    model.RoleWeight = int.Parse(row["RoleWeight"].ToString());
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
            strSql.Append("select RoleID,RoleName,RoleWeight,Remark,FK_EditID,EditTime,FK_CreateID,CreateTime,Sort,创建者名,修改者名 ");
            strSql.Append(" FROM v_Sys_Power_Role ");
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
            strSql.Append(" RoleID,RoleName,RoleWeight,Remark,FK_EditID,EditTime,FK_CreateID,CreateTime,Sort,创建者名,修改者名 ");
            strSql.Append(" FROM v_Sys_Power_Role ");
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
            strSql.Append("select count(1) FROM v_Sys_Power_Role ");
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
                strSql.Append("order by T.RoleID desc");
            }
            strSql.Append(")AS Row, T.*  from v_Sys_Power_Role T ");
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
            parameters[0].Value = "v_Sys_Power_Role";
            parameters[1].Value = "RoleID";
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

