using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Eastcom.DBUtility;
using System.Collections.Generic;
using DAL;//Please add references
namespace Eastcom.DAL
{
    /// <summary>
    /// 数据访问类:日度练习考核内容
    /// </summary>
    public partial class 日度练习考核内容
    {
        public 日度练习考核内容()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from 日度练习考核内容");
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
        public int Add(Eastcom.Model.日度练习考核内容 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into 日度练习考核内容(");
            strSql.Append("FK_UserID,日期,考务生成时间,提交情况,生成的题目数)");
            strSql.Append(" values (");
            strSql.Append("@FK_UserID,@日期,@考务生成时间,@提交情况,@生成的题目数)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@FK_UserID", SqlDbType.Int,4),
					new SqlParameter("@日期", SqlDbType.DateTime),
					new SqlParameter("@考务生成时间", SqlDbType.DateTime),
					new SqlParameter("@提交情况", SqlDbType.VarChar,50),
					new SqlParameter("@生成的题目数", SqlDbType.Int,4)};
            parameters[0].Value = model.FK_UserID;
            parameters[1].Value = model.日期;
            parameters[2].Value = model.考务生成时间;
            parameters[3].Value = model.提交情况;
            parameters[4].Value = model.生成的题目数;

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
        public bool Update(Eastcom.Model.日度练习考核内容 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 日度练习考核内容 set ");
            strSql.Append("FK_UserID=@FK_UserID,");
            strSql.Append("日期=@日期,");
            strSql.Append("考务生成时间=@考务生成时间,");
            strSql.Append("提交情况=@提交情况,");
            strSql.Append("生成的题目数=@生成的题目数");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@FK_UserID", SqlDbType.Int,4),
					new SqlParameter("@日期", SqlDbType.DateTime),
					new SqlParameter("@考务生成时间", SqlDbType.DateTime),
					new SqlParameter("@提交情况", SqlDbType.VarChar,50),
					new SqlParameter("@生成的题目数", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.FK_UserID;
            parameters[1].Value = model.日期;
            parameters[2].Value = model.考务生成时间;
            parameters[3].Value = model.提交情况;
            parameters[4].Value = model.生成的题目数;
            parameters[5].Value = model.id;

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
            strSql.Append("delete from 日度练习考核内容 ");
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
            strSql.Append("delete from 日度练习考核内容 ");
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
        public Eastcom.Model.日度练习考核内容 GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,FK_UserID,日期,考务生成时间,提交情况,生成的题目数 from 日度练习考核内容 ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Eastcom.Model.日度练习考核内容 model = new Eastcom.Model.日度练习考核内容();
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
        public Eastcom.Model.日度练习考核内容 DataRowToModel(DataRow row)
        {
            Eastcom.Model.日度练习考核内容 model = new Eastcom.Model.日度练习考核内容();
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
                if (row["日期"] != null && row["日期"].ToString() != "")
                {
                    model.日期 = DateTime.Parse(row["日期"].ToString());
                }
                if (row["考务生成时间"] != null && row["考务生成时间"].ToString() != "")
                {
                    model.考务生成时间 = DateTime.Parse(row["考务生成时间"].ToString());
                }
                if (row["提交情况"] != null)
                {
                    model.提交情况 = row["提交情况"].ToString();
                }
                if (row["生成的题目数"] != null && row["生成的题目数"].ToString() != "")
                {
                    model.生成的题目数 = int.Parse(row["生成的题目数"].ToString());
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
            strSql.Append("select id,FK_UserID,日期,考务生成时间,提交情况,生成的题目数 ");
            strSql.Append(" FROM 日度练习考核内容 ");
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
            strSql.Append(" id,FK_UserID,日期,考务生成时间,提交情况,生成的题目数 ");
            strSql.Append(" FROM 日度练习考核内容 ");
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
            strSql.Append("select count(1) FROM 日度练习考核内容 ");
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
            strSql.Append(")AS Row, T.*  from 日度练习考核内容 T ");
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
            parameters[0].Value = "日度练习考核内容";
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
        public bool Exists_Checked(string DateString, string FK_User_ID)
        {
            DateTime Checked_Year_month = Convert.ToDateTime(DateString);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from 日度练习考核内容 ");
            strSql.Append(" where FK_UserID=@FK_UserID");
            strSql.Append(" and 日期=@日期");


            SqlParameter[] parameters = {
					new SqlParameter("@FK_UserID", SqlDbType.VarChar,20),
                    new SqlParameter("@日期", SqlDbType.DateTime)
                                        };
            parameters[0].Value = FK_User_ID;
            parameters[1].Value = Checked_Year_month;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据,及其子表数据
        /// </summary>
        public int Add_Tran(Eastcom.Model.日度练习考核内容 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into 日度练习考核内容(");
            strSql.Append("FK_UserID,日期,考务生成时间,提交情况,生成的题目数)");
            strSql.Append(" values (");
            strSql.Append("@FK_UserID,@日期,@考务生成时间,@提交情况,@生成的题目数)");
            strSql.Append(";set @ReturnValue= @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@FK_UserID", SqlDbType.Int,4),
					new SqlParameter("@日期", SqlDbType.DateTime),
                    new SqlParameter("@考务生成时间",SqlDbType.DateTime),
                    new SqlParameter("@提交情况",SqlDbType.VarChar,50),
                    new SqlParameter("@生成的题目数",SqlDbType.Int,4),
					new SqlParameter("@ReturnValue",SqlDbType.Int)
                                        };

            parameters[0].Value = model.FK_UserID;
            parameters[1].Value = model.日期;
            if (model.考务生成时间 != DateTime.MinValue)
                parameters[2].Value = model.考务生成时间;
            else
                parameters[2].Value = DBNull.Value;
            parameters[3].Value = model.提交情况;
            parameters[4].Value = 100;
            parameters[5].Direction = ParameterDirection.Output;

            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);

            sqllist.Add(cmd);
            DbHelperSQL.ExecuteSqlTranWithIndentity(sqllist);

            StringBuilder strSql2;

            sqllist = new List<CommandInfo>();

            List<Eastcom.Model.日度练习考核内容_详细> 日度练习考核内容_详细s = new List<Model.日度练习考核内容_详细>();
            List<int> 考试题目 = Get题目编号((int)parameters[5].Value);

            for (int i = 0; i < 100; i++)
            {
                Eastcom.Model.考试题库 考题model = new Eastcom.DAL.考试题库().GetModel(考试题目[i]);

                日度练习考核内容_详细s.Add(new Eastcom.Model.日度练习考核内容_详细()
                {
                    FK_日度联系考核内容 = (int)parameters[5].Value,
                    考核题目编号 = i + 1,
                    题目编号 = 考试题目[i],  //随机获取,
                    得分 = 0,
                    题目内容_原 = 考题model.题目内容,
                    A选项_原 = 考题model.A选项,
                    B选项_原 = 考题model.B选项,
                    C选项_原 = 考题model.C选项,
                    D选项_原 = 考题model.D选项,
                    其他选项_原 = 考题model.其他选项,
                    标准答案_原 = 考题model.标准答案
                });
            }
            foreach (Eastcom.Model.日度练习考核内容_详细 models in 日度练习考核内容_详细s)
            {
                strSql2 = new StringBuilder();
                strSql2.Append("insert into 日度练习考核内容_详细(");
                strSql2.Append("FK_日度联系考核内容,考核题目编号,题目编号,用户答案,回答情况,得分,提交时间,题目内容_原,A选项_原,B选项_原,C选项_原,D选项_原,其他选项_原,标准答案_原)");
                strSql2.Append(" values (");
                strSql2.Append("@FK_日度联系考核内容,@考核题目编号,@题目编号,@用户答案,@回答情况,@得分,@提交时间,@题目内容_原,@A选项_原,@B选项_原,@C选项_原,@D选项_原,@其他选项_原,@标准答案_原)");
                SqlParameter[] parameters2 = {
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
                        new SqlParameter("@标准答案_原", SqlDbType.VarChar,50)    
                                             };
                parameters2[0].Value = models.FK_日度联系考核内容;
                parameters2[1].Value = models.考核题目编号;
                parameters2[2].Value = models.题目编号;
                parameters2[3].Value = models.用户答案;
                parameters2[4].Value = models.回答情况;
                parameters2[5].Value = models.得分;
                parameters2[6].Value = models.提交时间;
                parameters2[7].Value = models.题目内容_原;
                parameters2[8].Value = models.A选项_原;
                parameters2[9].Value = models.B选项_原;
                parameters2[10].Value = models.C选项_原;
                parameters2[11].Value = models.D选项_原;
                parameters2[12].Value = models.其他选项_原;
                parameters2[13].Value = models.标准答案_原;

                cmd = new CommandInfo(strSql2.ToString(), parameters2);
                sqllist.Add(cmd);
            }
            DbHelperSQL.ExecuteSqlTranWithIndentity(sqllist);
            return (int)parameters[5].Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<int> Get题目编号(int FK_日度联系考核内容)
        {
            DataSet ds = new Eastcom.DAL.考试题库().GetList("");
            List<int> intList = new List<int>();
            List<int> ReturnList = new List<int>();

            if (ds.Tables[0] != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    intList.Add(int.Parse(ds.Tables[0].Rows[i]["id"].ToString()));
                }
            }
            int j = 0;
            //j = 100< ds.Tables[0].Rows.Count?100:ds.Tables[0].Rows.Count;
            if (ds.Tables[0].Rows.Count < 100)
            {
                /*题目过少*/
                while (j < 100)
                {
                    Random rd = new Random();
                    int rd_int = rd.Next(0, intList.Count);
                    int a = intList[rd_int];
                    ReturnList.Add(a);
                    j++;
                }
            }
            else
            {
                while (j < 100)
                {
                    Random rd = new Random();
                    int rd_int = rd.Next(0, intList.Count);
                    int a = intList[rd_int];

                    if (ReturnList.Contains(a))
                    {
                        continue;
                    }
                    else
                    {
                        ReturnList.Add(a);
                        j++;
                    }
                }
            }
            return ReturnList;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Eastcom.Model.日度练习考核内容 GetModelByUser(int FK_User, DateTime 练习日期)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,FK_UserID,日期,考务生成时间,提交情况,生成的题目数 from 日度练习考核内容 ");
            strSql.Append(" where FK_UserID=@FK_UserID and 日期=@日期");
            SqlParameter[] parameters = {
					new SqlParameter("@FK_UserID", SqlDbType.Int,4),
                    new SqlParameter("@日期", SqlDbType.DateTime)
			};
            parameters[0].Value = FK_User;
            parameters[1].Value = 练习日期;

            Eastcom.Model.日度练习考核内容 model = new Eastcom.Model.日度练习考核内容();
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
        /// 分页
        /// </summary>
        public DataTable GetPageList(int PageSize, int PageIndex, ref int recordCount, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            return CommonDAL.GetPageList("日度练习考核内容", PageSize, PageIndex, ref recordCount, strWhere, fieldName, fieldKey, fieldOrder);
        }
        /// <summary>
        /// 获得数据列表(用于导出)
        /// </summary>
        public DataSet GetOutPutViewList(string strWhere, string fields, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            fields = fields.Trim().Length == 0 ? "*" : fields;
            strSql.AppendFormat("select {0} from 日度练习考核内容 ", fields);
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

