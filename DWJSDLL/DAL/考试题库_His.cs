using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Eastcom.DBUtility;//Please add references
namespace Eastcom.DAL
{
    /// <summary>
    /// 数据访问类:考试题库_His
    /// </summary>
    public partial class 考试题库_His
    {
        public 考试题库_His()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from 考试题库_His");
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
        public int Add(Eastcom.Model.考试题库_His model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into 考试题库_His(");
            strSql.Append("题目内容,A选项,B选项,C选项,D选项,其他选项,标准答案,标准答案2,备份时间,操作人)");
            strSql.Append(" values (");
            strSql.Append("@题目内容,@A选项,@B选项,@C选项,@D选项,@其他选项,@标准答案,@标准答案2,@备份时间,@操作人)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@题目内容", SqlDbType.NText),
					new SqlParameter("@A选项", SqlDbType.VarChar,5000),
					new SqlParameter("@B选项", SqlDbType.VarChar,5000),
					new SqlParameter("@C选项", SqlDbType.VarChar,5000),
					new SqlParameter("@D选项", SqlDbType.VarChar,5000),
					new SqlParameter("@其他选项", SqlDbType.NText),
					new SqlParameter("@标准答案", SqlDbType.VarChar,50),
					new SqlParameter("@标准答案2", SqlDbType.VarChar,50),
					new SqlParameter("@备份时间", SqlDbType.DateTime),
					new SqlParameter("@操作人", SqlDbType.VarChar,50)};
            parameters[0].Value = model.题目内容;
            parameters[1].Value = model.A选项;
            parameters[2].Value = model.B选项;
            parameters[3].Value = model.C选项;
            parameters[4].Value = model.D选项;
            parameters[5].Value = model.其他选项;
            parameters[6].Value = model.标准答案;
            parameters[7].Value = model.标准答案2;
            parameters[8].Value = model.备份时间;
            parameters[9].Value = model.操作人;

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
        public bool Update(Eastcom.Model.考试题库_His model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 考试题库_His set ");
            strSql.Append("题目内容=@题目内容,");
            strSql.Append("A选项=@A选项,");
            strSql.Append("B选项=@B选项,");
            strSql.Append("C选项=@C选项,");
            strSql.Append("D选项=@D选项,");
            strSql.Append("其他选项=@其他选项,");
            strSql.Append("标准答案=@标准答案,");
            strSql.Append("标准答案2=@标准答案2,");
            strSql.Append("备份时间=@备份时间,");
            strSql.Append("操作人=@操作人");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@题目内容", SqlDbType.NText),
					new SqlParameter("@A选项", SqlDbType.VarChar,5000),
					new SqlParameter("@B选项", SqlDbType.VarChar,5000),
					new SqlParameter("@C选项", SqlDbType.VarChar,5000),
					new SqlParameter("@D选项", SqlDbType.VarChar,5000),
					new SqlParameter("@其他选项", SqlDbType.NText),
					new SqlParameter("@标准答案", SqlDbType.VarChar,50),
					new SqlParameter("@标准答案2", SqlDbType.VarChar,50),
					new SqlParameter("@备份时间", SqlDbType.DateTime),
					new SqlParameter("@操作人", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.题目内容;
            parameters[1].Value = model.A选项;
            parameters[2].Value = model.B选项;
            parameters[3].Value = model.C选项;
            parameters[4].Value = model.D选项;
            parameters[5].Value = model.其他选项;
            parameters[6].Value = model.标准答案;
            parameters[7].Value = model.标准答案2;
            parameters[8].Value = model.备份时间;
            parameters[9].Value = model.操作人;
            parameters[10].Value = model.id;

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
            strSql.Append("delete from 考试题库_His ");
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
            strSql.Append("delete from 考试题库_His ");
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
        public Eastcom.Model.考试题库_His GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,题目内容,A选项,B选项,C选项,D选项,其他选项,标准答案,标准答案2,备份时间,操作人 from 考试题库_His ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Eastcom.Model.考试题库_His model = new Eastcom.Model.考试题库_His();
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
        public Eastcom.Model.考试题库_His DataRowToModel(DataRow row)
        {
            Eastcom.Model.考试题库_His model = new Eastcom.Model.考试题库_His();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["题目内容"] != null)
                {
                    model.题目内容 = row["题目内容"].ToString();
                }
                if (row["A选项"] != null)
                {
                    model.A选项 = row["A选项"].ToString();
                }
                if (row["B选项"] != null)
                {
                    model.B选项 = row["B选项"].ToString();
                }
                if (row["C选项"] != null)
                {
                    model.C选项 = row["C选项"].ToString();
                }
                if (row["D选项"] != null)
                {
                    model.D选项 = row["D选项"].ToString();
                }
                if (row["其他选项"] != null)
                {
                    model.其他选项 = row["其他选项"].ToString();
                }
                if (row["标准答案"] != null)
                {
                    model.标准答案 = row["标准答案"].ToString();
                }
                if (row["标准答案2"] != null)
                {
                    model.标准答案2 = row["标准答案2"].ToString();
                }
                if (row["备份时间"] != null && row["备份时间"].ToString() != "")
                {
                    model.备份时间 = DateTime.Parse(row["备份时间"].ToString());
                }
                if (row["操作人"] != null)
                {
                    model.操作人 = row["操作人"].ToString();
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
            strSql.Append("select id,题目内容,A选项,B选项,C选项,D选项,其他选项,标准答案,标准答案2,备份时间,操作人 ");
            strSql.Append(" FROM 考试题库_His ");
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
            strSql.Append(" id,题目内容,A选项,B选项,C选项,D选项,其他选项,标准答案,标准答案2,备份时间,操作人 ");
            strSql.Append(" FROM 考试题库_His ");
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
            strSql.Append("select count(1) FROM 考试题库_His ");
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
            strSql.Append(")AS Row, T.*  from 考试题库_His T ");
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
            parameters[0].Value = "考试题库_His";
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

