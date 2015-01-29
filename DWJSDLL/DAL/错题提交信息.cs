using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Eastcom.DBUtility;//Please add references

namespace Eastcom.DAL
{
    /// <summary>
    /// 数据访问类:错题提交信息
    /// </summary>
    public partial class 错题提交信息
    {
        public 错题提交信息()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from 错题提交信息");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Eastcom.Model.错题提交信息 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into 错题提交信息(");
            strSql.Append("FK_考试题库,题目信息,答案信息,错误提交信息,提交人,提交时间)");
            strSql.Append(" values (");
            strSql.Append("@FK_考试题库,@题目信息,@答案信息,@错误提交信息,@提交人,@提交时间)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@FK_考试题库", SqlDbType.NChar,10),
					new SqlParameter("@题目信息", SqlDbType.NText),
					new SqlParameter("@答案信息", SqlDbType.VarChar,50),
					new SqlParameter("@错误提交信息", SqlDbType.NText),
					new SqlParameter("@提交人", SqlDbType.VarChar,50),
					new SqlParameter("@提交时间", SqlDbType.DateTime)};
            parameters[0].Value = model.FK_考试题库;
            parameters[1].Value = model.题目信息;
            parameters[2].Value = model.答案信息;
            parameters[3].Value = model.错误提交信息;
            parameters[4].Value = model.提交人;
            parameters[5].Value = model.提交时间;

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
        public bool Update(Eastcom.Model.错题提交信息 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 错题提交信息 set ");
            strSql.Append("FK_考试题库=@FK_考试题库,");
            strSql.Append("题目信息=@题目信息,");
            strSql.Append("答案信息=@答案信息,");
            strSql.Append("错误提交信息=@错误提交信息,");
            strSql.Append("提交人=@提交人,");
            strSql.Append("提交时间=@提交时间");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@FK_考试题库", SqlDbType.NChar,10),
					new SqlParameter("@题目信息", SqlDbType.NText),
					new SqlParameter("@答案信息", SqlDbType.VarChar,50),
					new SqlParameter("@错误提交信息", SqlDbType.NText),
					new SqlParameter("@提交人", SqlDbType.VarChar,50),
					new SqlParameter("@提交时间", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.FK_考试题库;
            parameters[1].Value = model.题目信息;
            parameters[2].Value = model.答案信息;
            parameters[3].Value = model.错误提交信息;
            parameters[4].Value = model.提交人;
            parameters[5].Value = model.提交时间;
            parameters[6].Value = model.id;

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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 错题提交信息 ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 错题提交信息 ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public Eastcom.Model.错题提交信息 GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,FK_考试题库,题目信息,答案信息,错误提交信息,提交人,提交时间 from 错题提交信息 ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Eastcom.Model.错题提交信息 model = new Eastcom.Model.错题提交信息();
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
        public Eastcom.Model.错题提交信息 DataRowToModel(DataRow row)
        {
            Eastcom.Model.错题提交信息 model = new Eastcom.Model.错题提交信息();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["FK_考试题库"] != null)
                {
                    model.FK_考试题库 = row["FK_考试题库"].ToString();
                }
                if (row["题目信息"] != null)
                {
                    model.题目信息 = row["题目信息"].ToString();
                }
                if (row["答案信息"] != null)
                {
                    model.答案信息 = row["答案信息"].ToString();
                }
                if (row["错误提交信息"] != null)
                {
                    model.错误提交信息 = row["错误提交信息"].ToString();
                }
                if (row["提交人"] != null)
                {
                    model.提交人 = row["提交人"].ToString();
                }
                if (row["提交时间"] != null && row["提交时间"].ToString() != "")
                {
                    model.提交时间 = DateTime.Parse(row["提交时间"].ToString());
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
            strSql.Append("select id,FK_考试题库,题目信息,答案信息,错误提交信息,提交人,提交时间 ");
            strSql.Append(" FROM 错题提交信息 ");
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
            strSql.Append(" id,FK_考试题库,题目信息,答案信息,错误提交信息,提交人,提交时间 ");
            strSql.Append(" FROM 错题提交信息 ");
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
            strSql.Append("select count(1) FROM 错题提交信息 ");
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
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from 错题提交信息 T ");
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
            parameters[0].Value = "错题提交信息";
            parameters[1].Value = "id";
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

