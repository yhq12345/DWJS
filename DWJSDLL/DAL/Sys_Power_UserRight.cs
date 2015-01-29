using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Eastcom.DBUtility;//Please add references
namespace Eastcom.DAL
{
	/// <summary>
	/// 数据访问类:Sys_Power_UserRight
	/// </summary>
	public partial class Sys_Power_UserRight
	{
		public Sys_Power_UserRight()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "Sys_Power_UserRight");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Power_UserRight");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Eastcom.Model.Sys_Power_UserRight model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Power_UserRight(");
            strSql.Append("FK_UserID,FK_RightID,FK_EditID,EditTime,FK_CreateID,CreateTime)");
            strSql.Append(" values (");
            strSql.Append("@FK_UserID,@FK_RightID,@FK_EditID,@EditTime,@FK_CreateID,@CreateTime)");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
					new SqlParameter("@FK_UserID", SqlDbType.Int,4),
					new SqlParameter("@FK_RightID", SqlDbType.Int,4),
					new SqlParameter("@FK_EditID", SqlDbType.Int,4),
					new SqlParameter("@EditTime", SqlDbType.DateTime),
					new SqlParameter("@FK_CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.FK_UserID;
            parameters[1].Value = model.FK_RightID;
            parameters[2].Value = model.FK_EditID;
            parameters[3].Value = model.EditTime;
            parameters[4].Value = model.FK_CreateID;
            parameters[5].Value = model.CreateTime;

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
        public bool Update(Eastcom.Model.Sys_Power_UserRight model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Power_UserRight set ");
            strSql.Append("FK_UserID=@FK_UserID,");
            strSql.Append("FK_RightID=@FK_RightID,");
            strSql.Append("FK_EditID=@FK_EditID,");
            strSql.Append("EditTime=@EditTime,");
            strSql.Append("FK_CreateID=@FK_CreateID,");
            strSql.Append("CreateTime=@CreateTime");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@FK_UserID", SqlDbType.Int,4),
					new SqlParameter("@FK_RightID", SqlDbType.Int,4),
					new SqlParameter("@FK_EditID", SqlDbType.Int,4),
					new SqlParameter("@EditTime", SqlDbType.DateTime),
					new SqlParameter("@FK_CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.FK_UserID;
            parameters[1].Value = model.FK_RightID;
            parameters[2].Value = model.FK_EditID;
            parameters[3].Value = model.EditTime;
            parameters[4].Value = model.FK_CreateID;
            parameters[5].Value = model.CreateTime;
            parameters[6].Value = model.Id;

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
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Power_UserRight ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

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
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Power_UserRight ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
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
        public Eastcom.Model.Sys_Power_UserRight GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,FK_UserID,FK_RightID,FK_EditID,EditTime,FK_CreateID,CreateTime from Sys_Power_UserRight ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            Eastcom.Model.Sys_Power_UserRight model = new Eastcom.Model.Sys_Power_UserRight();
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
        public Eastcom.Model.Sys_Power_UserRight DataRowToModel(DataRow row)
        {
            Eastcom.Model.Sys_Power_UserRight model = new Eastcom.Model.Sys_Power_UserRight();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["FK_UserID"] != null && row["FK_UserID"].ToString() != "")
                {
                    model.FK_UserID = int.Parse(row["FK_UserID"].ToString());
                }
                if (row["FK_RightID"] != null && row["FK_RightID"].ToString() != "")
                {
                    model.FK_RightID = int.Parse(row["FK_RightID"].ToString());
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
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,FK_UserID,FK_RightID,FK_EditID,EditTime,FK_CreateID,CreateTime ");
            strSql.Append(" FROM Sys_Power_UserRight ");
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
            strSql.Append(" Id,FK_UserID,FK_RightID,FK_EditID,EditTime,FK_CreateID,CreateTime ");
            strSql.Append(" FROM Sys_Power_UserRight ");
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
            strSql.Append("select count(1) FROM Sys_Power_UserRight ");
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
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from Sys_Power_UserRight T ");
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
            parameters[0].Value = "Sys_Power_UserRight";
            parameters[1].Value = "Id";
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
        /// 根据指定条件删除
        /// </summary>
        public bool DelWhere(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Power_UserRight ");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.AppendFormat(" where {0}", where);
            }
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
		#endregion  ExtensionMethod
	}
}

