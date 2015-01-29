using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Eastcom.DBUtility;//Please add references
namespace Eastcom.DAL
{
    /// <summary>
    /// 数据访问类:日度练习考核内容_详细
    /// </summary>
    public partial class 日度练习考核内容_详细
    {
        public 日度练习考核内容_详细()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from 日度练习考核内容_详细");
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
        public int Add(Eastcom.Model.日度练习考核内容_详细 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into 日度练习考核内容_详细(");
            strSql.Append("FK_日度联系考核内容,考核题目编号,题目编号,用户答案,回答情况,得分,提交时间,题目内容_原,A选项_原,B选项_原,C选项_原,D选项_原,其他选项_原,标准答案_原)");
            strSql.Append(" values (");
            strSql.Append("@FK_日度联系考核内容,@考核题目编号,@题目编号,@用户答案,@回答情况,@得分,@提交时间,@题目内容_原,@A选项_原,@B选项_原,@C选项_原,@D选项_原,@其他选项_原,@标准答案_原)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@FK_日度联系考核内容", SqlDbType.Int,4),
					new SqlParameter("@考核题目编号", SqlDbType.Int,4),
					new SqlParameter("@题目编号", SqlDbType.Int,4),
					new SqlParameter("@用户答案", SqlDbType.VarChar,50),
					new SqlParameter("@回答情况", SqlDbType.VarChar,50),
					new SqlParameter("@得分", SqlDbType.Decimal,9),
					new SqlParameter("@提交时间", SqlDbType.DateTime),
					new SqlParameter("@题目内容_原", SqlDbType.NText),
					new SqlParameter("@A选项_原", SqlDbType.VarChar,5000),
					new SqlParameter("@B选项_原", SqlDbType.VarChar,5000),
					new SqlParameter("@C选项_原", SqlDbType.VarChar,5000),
					new SqlParameter("@D选项_原", SqlDbType.VarChar,5000),
					new SqlParameter("@其他选项_原", SqlDbType.NText),
					new SqlParameter("@标准答案_原", SqlDbType.VarChar,50)};
            parameters[0].Value = model.FK_日度联系考核内容;
            parameters[1].Value = model.考核题目编号;
            parameters[2].Value = model.题目编号;
            parameters[3].Value = model.用户答案;
            parameters[4].Value = model.回答情况;
            parameters[5].Value = model.得分;
            parameters[6].Value = model.提交时间;
            parameters[7].Value = model.题目内容_原;
            parameters[8].Value = model.A选项_原;
            parameters[9].Value = model.B选项_原;
            parameters[10].Value = model.C选项_原;
            parameters[11].Value = model.D选项_原;
            parameters[12].Value = model.其他选项_原;
            parameters[13].Value = model.标准答案_原;

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
        public bool Update(Eastcom.Model.日度练习考核内容_详细 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 日度练习考核内容_详细 set ");
            strSql.Append("FK_日度联系考核内容=@FK_日度联系考核内容,");
            strSql.Append("考核题目编号=@考核题目编号,");
            strSql.Append("题目编号=@题目编号,");
            strSql.Append("用户答案=@用户答案,");
            strSql.Append("回答情况=@回答情况,");
            strSql.Append("得分=@得分,");
            strSql.Append("提交时间=@提交时间,");
            strSql.Append("题目内容_原=@题目内容_原,");
            strSql.Append("A选项_原=@A选项_原,");
            strSql.Append("B选项_原=@B选项_原,");
            strSql.Append("C选项_原=@C选项_原,");
            strSql.Append("D选项_原=@D选项_原,");
            strSql.Append("其他选项_原=@其他选项_原,");
            strSql.Append("标准答案_原=@标准答案_原");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@FK_日度联系考核内容", SqlDbType.Int,4),
					new SqlParameter("@考核题目编号", SqlDbType.Int,4),
					new SqlParameter("@题目编号", SqlDbType.Int,4),
					new SqlParameter("@用户答案", SqlDbType.VarChar,50),
					new SqlParameter("@回答情况", SqlDbType.VarChar,50),
					new SqlParameter("@得分", SqlDbType.Decimal,9),
					new SqlParameter("@提交时间", SqlDbType.DateTime),
					new SqlParameter("@题目内容_原", SqlDbType.NText),
					new SqlParameter("@A选项_原", SqlDbType.VarChar,5000),
					new SqlParameter("@B选项_原", SqlDbType.VarChar,5000),
					new SqlParameter("@C选项_原", SqlDbType.VarChar,5000),
					new SqlParameter("@D选项_原", SqlDbType.VarChar,5000),
					new SqlParameter("@其他选项_原", SqlDbType.NText),
					new SqlParameter("@标准答案_原", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.FK_日度联系考核内容;
            parameters[1].Value = model.考核题目编号;
            parameters[2].Value = model.题目编号;
            parameters[3].Value = model.用户答案;
            parameters[4].Value = model.回答情况;
            parameters[5].Value = model.得分;
            parameters[6].Value = model.提交时间;
            parameters[7].Value = model.题目内容_原;
            parameters[8].Value = model.A选项_原;
            parameters[9].Value = model.B选项_原;
            parameters[10].Value = model.C选项_原;
            parameters[11].Value = model.D选项_原;
            parameters[12].Value = model.其他选项_原;
            parameters[13].Value = model.标准答案_原;
            parameters[14].Value = model.id;

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
            strSql.Append("delete from 日度练习考核内容_详细 ");
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
            strSql.Append("delete from 日度练习考核内容_详细 ");
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
        public Eastcom.Model.日度练习考核内容_详细 GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,FK_日度联系考核内容,考核题目编号,题目编号,用户答案,回答情况,得分,提交时间,题目内容_原,A选项_原,B选项_原,C选项_原,D选项_原,其他选项_原,标准答案_原 from 日度练习考核内容_详细 ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Eastcom.Model.日度练习考核内容_详细 model = new Eastcom.Model.日度练习考核内容_详细();
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
        public Eastcom.Model.日度练习考核内容_详细 DataRowToModel(DataRow row)
        {
            Eastcom.Model.日度练习考核内容_详细 model = new Eastcom.Model.日度练习考核内容_详细();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["FK_日度联系考核内容"] != null && row["FK_日度联系考核内容"].ToString() != "")
                {
                    model.FK_日度联系考核内容 = int.Parse(row["FK_日度联系考核内容"].ToString());
                }
                if (row["考核题目编号"] != null && row["考核题目编号"].ToString() != "")
                {
                    model.考核题目编号 = int.Parse(row["考核题目编号"].ToString());
                }
                if (row["题目编号"] != null && row["题目编号"].ToString() != "")
                {
                    model.题目编号 = int.Parse(row["题目编号"].ToString());
                }
                if (row["用户答案"] != null)
                {
                    model.用户答案 = row["用户答案"].ToString();
                }
                if (row["回答情况"] != null)
                {
                    model.回答情况 = row["回答情况"].ToString();
                }
                if (row["得分"] != null && row["得分"].ToString() != "")
                {
                    model.得分 = decimal.Parse(row["得分"].ToString());
                }
                if (row["提交时间"] != null && row["提交时间"].ToString() != "")
                {
                    model.提交时间 = DateTime.Parse(row["提交时间"].ToString());
                }
                if (row["题目内容_原"] != null)
                {
                    model.题目内容_原 = row["题目内容_原"].ToString();
                }
                if (row["A选项_原"] != null)
                {
                    model.A选项_原 = row["A选项_原"].ToString();
                }
                if (row["B选项_原"] != null)
                {
                    model.B选项_原 = row["B选项_原"].ToString();
                }
                if (row["C选项_原"] != null)
                {
                    model.C选项_原 = row["C选项_原"].ToString();
                }
                if (row["D选项_原"] != null)
                {
                    model.D选项_原 = row["D选项_原"].ToString();
                }
                if (row["其他选项_原"] != null)
                {
                    model.其他选项_原 = row["其他选项_原"].ToString();
                }
                if (row["标准答案_原"] != null)
                {
                    model.标准答案_原 = row["标准答案_原"].ToString();
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
            strSql.Append("select id,FK_日度联系考核内容,考核题目编号,题目编号,用户答案,回答情况,得分,提交时间,题目内容_原,A选项_原,B选项_原,C选项_原,D选项_原,其他选项_原,标准答案_原 ");
            strSql.Append(" FROM 日度练习考核内容_详细 ");
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
            strSql.Append(" id,FK_日度联系考核内容,考核题目编号,题目编号,用户答案,回答情况,得分,提交时间,题目内容_原,A选项_原,B选项_原,C选项_原,D选项_原,其他选项_原,标准答案_原 ");
            strSql.Append(" FROM 日度练习考核内容_详细 ");
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
            strSql.Append("select count(1) FROM 日度练习考核内容_详细 ");
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
            strSql.Append(")AS Row, T.*  from 日度练习考核内容_详细 T ");
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
            parameters[0].Value = "日度练习考核内容_详细";
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FK_月度考核"></param>
        /// <param name="考核题目编号"></param>
        /// <returns></returns>
        public Eastcom.Model.日度练习考核内容_详细 GetModelByBH_YD(int FK_日度练习, int 考核题目编号)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,FK_日度联系考核内容,考核题目编号,题目编号,用户答案,回答情况,得分,提交时间,题目内容_原,A选项_原,B选项_原,C选项_原,D选项_原,其他选项_原,标准答案_原  from 日度练习考核内容_详细");
            strSql.Append(" where FK_日度联系考核内容=@FK_日度联系考核内容 and 考核题目编号=@考核题目编号 ");

            SqlParameter[] parameters = {
					new SqlParameter("@FK_日度联系考核内容", SqlDbType.Int,4),
                    new SqlParameter("@考核题目编号", SqlDbType.Int,4)
			};
            parameters[0].Value = FK_日度练习;
            parameters[1].Value = 考核题目编号;

            Eastcom.Model.日度练习考核内容_详细 model = new Eastcom.Model.日度练习考核内容_详细();
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




        #endregion  ExtensionMethod
    }
}

