using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Eastcom.DBUtility;
using DAL;

namespace Eastcom.DAL
{
    /// <summary>
    /// 数据访问类:v_月度考核内容
    /// </summary>
    public partial class v_月度考核内容
    {
        public v_月度考核内容()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from v_月度考核内容");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Eastcom.Model.v_月度考核内容 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into v_月度考核内容(");
            strSql.Append("id,FK_UserID,月份,提交时间,回答情况,得分,提交情况,RealName,考务生成时间)");
            strSql.Append(" values (");
            strSql.Append("@id,@FK_UserID,@月份,@提交时间,@回答情况,@得分,@提交情况,@RealName,@考务生成时间)");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@FK_UserID", SqlDbType.Int,4),
					new SqlParameter("@月份", SqlDbType.DateTime),
					new SqlParameter("@提交时间", SqlDbType.DateTime),
					new SqlParameter("@回答情况", SqlDbType.VarChar,50),
					new SqlParameter("@得分", SqlDbType.Decimal,9),
					new SqlParameter("@提交情况", SqlDbType.VarChar,50),
					new SqlParameter("@RealName", SqlDbType.VarChar,50),
					new SqlParameter("@考务生成时间", SqlDbType.DateTime)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.FK_UserID;
            parameters[2].Value = model.月份;
            parameters[3].Value = model.提交时间;
            parameters[4].Value = model.回答情况;
            parameters[5].Value = model.得分;
            parameters[6].Value = model.提交情况;
            parameters[7].Value = model.RealName;
            parameters[8].Value = model.考务生成时间;

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
        public bool Update(Eastcom.Model.v_月度考核内容 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update v_月度考核内容 set ");
            strSql.Append("id=@id,");
            strSql.Append("FK_UserID=@FK_UserID,");
            strSql.Append("月份=@月份,");
            strSql.Append("提交时间=@提交时间,");
            strSql.Append("回答情况=@回答情况,");
            strSql.Append("得分=@得分,");
            strSql.Append("提交情况=@提交情况,");
            strSql.Append("RealName=@RealName,");
            strSql.Append("考务生成时间=@考务生成时间");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@FK_UserID", SqlDbType.Int,4),
					new SqlParameter("@月份", SqlDbType.DateTime),
					new SqlParameter("@提交时间", SqlDbType.DateTime),
					new SqlParameter("@回答情况", SqlDbType.VarChar,50),
					new SqlParameter("@得分", SqlDbType.Decimal,9),
					new SqlParameter("@提交情况", SqlDbType.VarChar,50),
					new SqlParameter("@RealName", SqlDbType.VarChar,50),
					new SqlParameter("@考务生成时间", SqlDbType.DateTime)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.FK_UserID;
            parameters[2].Value = model.月份;
            parameters[3].Value = model.提交时间;
            parameters[4].Value = model.回答情况;
            parameters[5].Value = model.得分;
            parameters[6].Value = model.提交情况;
            parameters[7].Value = model.RealName;
            parameters[8].Value = model.考务生成时间;

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
            strSql.Append("delete from v_月度考核内容 ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
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
            strSql.Append("delete from v_月度考核内容 ");
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
        public Eastcom.Model.v_月度考核内容 GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,FK_UserID,月份,提交时间,回答情况,得分,提交情况,RealName,考务生成时间 from v_月度考核内容 ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
            parameters[0].Value = id;

            Eastcom.Model.v_月度考核内容 model = new Eastcom.Model.v_月度考核内容();
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
        public Eastcom.Model.v_月度考核内容 DataRowToModel(DataRow row)
        {
            Eastcom.Model.v_月度考核内容 model = new Eastcom.Model.v_月度考核内容();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["FK_UserID"] != null && row["FK_UserID"].ToString() != "")
                {
                    model.FK_UserID = int.Parse(row["FK_UserID"].ToString());
                }
                if (row["月份"] != null && row["月份"].ToString() != "")
                {
                    model.月份 = DateTime.Parse(row["月份"].ToString());
                }
                if (row["提交时间"] != null && row["提交时间"].ToString() != "")
                {
                    model.提交时间 = DateTime.Parse(row["提交时间"].ToString());
                }
                if (row["回答情况"] != null)
                {
                    model.回答情况 = row["回答情况"].ToString();
                }
                if (row["得分"] != null && row["得分"].ToString() != "")
                {
                    model.得分 = decimal.Parse(row["得分"].ToString());
                }
                if (row["提交情况"] != null)
                {
                    model.提交情况 = row["提交情况"].ToString();
                }
                if (row["RealName"] != null)
                {
                    model.RealName = row["RealName"].ToString();
                }
                if (row["考务生成时间"] != null && row["考务生成时间"].ToString() != "")
                {
                    model.考务生成时间 = DateTime.Parse(row["考务生成时间"].ToString());
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
            strSql.Append("select id,FK_UserID,月份,提交时间,回答情况,得分,提交情况,RealName,考务生成时间 ");
            strSql.Append(" FROM v_月度考核内容 ");
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
            strSql.Append(" id,FK_UserID,月份,提交时间,回答情况,得分,提交情况,RealName,考务生成时间 ");
            strSql.Append(" FROM v_月度考核内容 ");
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
            strSql.Append("select count(1) FROM v_月度考核内容 ");
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
            strSql.Append(")AS Row, T.*  from v_月度考核内容 T ");
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
            parameters[0].Value = "v_月度考核内容";
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
        /// 分页
        /// </summary>
        public DataTable GetPageList(int PageSize, int PageIndex, ref int recordCount, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            return CommonDAL.GetPageList("v_月度考核内容", PageSize, PageIndex, ref recordCount, strWhere, fieldName, fieldKey, fieldOrder);
        }
        /// <summary>
        /// 获得数据列表(用于导出)
        /// </summary>
        public DataSet GetOutPutViewList(string strWhere, string fields, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            fields = fields.Trim().Length == 0 ? "*" : fields;
            strSql.AppendFormat("select {0} from v_月度考核内容 ", fields);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append(" order by " + orderby);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  ExtensionMethod
    }
}

