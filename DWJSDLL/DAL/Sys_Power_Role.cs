using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Eastcom.DBUtility;
using DAL;//Please add references
namespace Eastcom.DAL
{
	/// <summary>
	/// 数据访问类:Sys_Power_Role
	/// </summary>
	public partial class Sys_Power_Role
	{
		public Sys_Power_Role()
		{}
        #region  BasicMethod
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("RoleID", "Sys_Power_Role");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Power_Role");
            strSql.Append(" where RoleID=@RoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)
			};
            parameters[0].Value = RoleID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Eastcom.Model.Sys_Power_Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Power_Role(");
            strSql.Append("RoleName,RoleWeight,Remark,FK_EditID,EditTime,FK_CreateID,CreateTime,Sort)");
            strSql.Append(" values (");
            strSql.Append("@RoleName,@RoleWeight,@Remark,@FK_EditID,@EditTime,@FK_CreateID,@CreateTime,@Sort)");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.VarChar,50),
					new SqlParameter("@RoleWeight", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,1000),
					new SqlParameter("@FK_EditID", SqlDbType.Int,4),
					new SqlParameter("@EditTime", SqlDbType.DateTime),
					new SqlParameter("@FK_CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Sort", SqlDbType.Int,4)};
            parameters[0].Value = model.RoleName;
            parameters[1].Value = model.RoleWeight;
            parameters[2].Value = model.Remark;
            parameters[3].Value = model.FK_EditID;
            parameters[4].Value = model.EditTime;
            parameters[5].Value = model.FK_CreateID;
            parameters[6].Value = model.CreateTime;
            parameters[7].Value = model.Sort;

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
        public bool Update(Eastcom.Model.Sys_Power_Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Power_Role set ");
            strSql.Append("RoleName=@RoleName,");
            strSql.Append("RoleWeight=@RoleWeight,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("FK_EditID=@FK_EditID,");
            strSql.Append("EditTime=@EditTime,");
            strSql.Append("FK_CreateID=@FK_CreateID,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("Sort=@Sort");
            strSql.Append(" where RoleID=@RoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.VarChar,50),
					new SqlParameter("@RoleWeight", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,1000),
					new SqlParameter("@FK_EditID", SqlDbType.Int,4),
					new SqlParameter("@EditTime", SqlDbType.DateTime),
					new SqlParameter("@FK_CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = model.RoleName;
            parameters[1].Value = model.RoleWeight;
            parameters[2].Value = model.Remark;
            parameters[3].Value = model.FK_EditID;
            parameters[4].Value = model.EditTime;
            parameters[5].Value = model.FK_CreateID;
            parameters[6].Value = model.CreateTime;
            parameters[7].Value = model.Sort;
            parameters[8].Value = model.RoleID;

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
            strSql.Append("delete from Sys_Power_Role ");
            strSql.Append(" where RoleID=@RoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)
			};
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
            strSql.Append("delete from Sys_Power_Role ");
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
        public Eastcom.Model.Sys_Power_Role GetModel(int RoleID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 RoleID,RoleName,RoleWeight,Remark,FK_EditID,EditTime,FK_CreateID,CreateTime,Sort from Sys_Power_Role ");
            strSql.Append(" where RoleID=@RoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)
			};
            parameters[0].Value = RoleID;

            Eastcom.Model.Sys_Power_Role model = new Eastcom.Model.Sys_Power_Role();
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
        public Eastcom.Model.Sys_Power_Role DataRowToModel(DataRow row)
        {
            Eastcom.Model.Sys_Power_Role model = new Eastcom.Model.Sys_Power_Role();
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
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RoleID,RoleName,RoleWeight,Remark,FK_EditID,EditTime,FK_CreateID,CreateTime,Sort ");
            strSql.Append(" FROM Sys_Power_Role ");
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
            strSql.Append(" RoleID,RoleName,RoleWeight,Remark,FK_EditID,EditTime,FK_CreateID,CreateTime,Sort ");
            strSql.Append(" FROM Sys_Power_Role ");
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
            strSql.Append("select count(1) FROM Sys_Power_Role ");
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
            strSql.Append(")AS Row, T.*  from Sys_Power_Role T ");
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
            parameters[0].Value = "Sys_Power_Role";
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
        /// <summary>
        /// 分页(可按非主键排序)
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetPageList(int PageSize, int PageIndex, ref int recordCount, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            return CommonDAL.GetPageList("v_Sys_Power_Role", PageSize, PageIndex, ref recordCount, strWhere, fieldName, fieldKey, fieldOrder);
        }
		#endregion  ExtensionMethod
	}
}

