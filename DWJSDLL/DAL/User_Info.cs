using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Eastcom.DBUtility;//Please add references
namespace Eastcom.DAL
{
    /// <summary>
    /// 数据访问类:User
    /// </summary>
    public partial class User_Info
    {
        public User_Info()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from User_Info");
            strSql.Append(" where ");
            SqlParameter[] parameters = {};

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool Exists_UserID(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from User_Info");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = {
                              new SqlParameter("@UserName",SqlDbType.VarChar,50)};
            parameters[0].Value = ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from User_Info");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                              new SqlParameter("@ID",SqlDbType.Int,4)};
            parameters[0].Value = id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Eastcom.Model.User_Info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into User_Info(");
            strSql.Append("UserName,Password,Area,CanCheced,RealName)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@Password,@Area,@CanCheced,@RealName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,50),
					new SqlParameter("@Area", SqlDbType.VarChar,50),
					new SqlParameter("@CanCheced", SqlDbType.VarChar,50),
					new SqlParameter("@RealName", SqlDbType.VarChar,50)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.Area;
            parameters[3].Value = model.CanCheced;
            parameters[4].Value = model.RealName;

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
        public bool Update(Eastcom.Model.User_Info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update User_Info set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("Password=@Password,");
            strSql.Append("Area=@Area,");
            strSql.Append("CanCheced=@CanCheced,");
            strSql.Append("RealName=@RealName");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,50),
					new SqlParameter("@Area", SqlDbType.VarChar,50),
					new SqlParameter("@CanCheced", SqlDbType.VarChar,50),
					new SqlParameter("@RealName", SqlDbType.VarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Password;
            parameters[3].Value = model.Area;
            parameters[4].Value = model.CanCheced;
            parameters[5].Value = model.RealName;

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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from User_Info ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from User_Info ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public Eastcom.Model.User_Info GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserName,Password,Area,CanCheced,RealName from User_Info ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};

            parameters[0].Value = ID;

            Eastcom.Model.User_Info model = new Eastcom.Model.User_Info();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                model.Area = ds.Tables[0].Rows[0]["Area"].ToString();
                model.CanCheced = ds.Tables[0].Rows[0]["CanCheced"].ToString();
                model.RealName = ds.Tables[0].Rows[0]["RealName"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,UserName,Password,Area,CanCheced,RealName ");
            strSql.Append(" FROM User_Info ");
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
            strSql.Append(" ID,UserName,Password,Area,CanCheced,RealName ");
            strSql.Append(" FROM User_Info ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
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
            parameters[0].Value = "User";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/
        public Model.User_Info Login(string username, string pwd)
        {
          

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserName,Password,Area,CanCheced,RealName from User_Info ");
            strSql.Append(" where UserName=@UserName");
            strSql.Append(" and Password=@Password");

            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
                      new SqlParameter("@Password",SqlDbType.VarChar,50)};

            parameters[0].Value = username;
            parameters[1].Value = pwd;

            Eastcom.Model.User_Info model = new Eastcom.Model.User_Info();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32 (ds.Tables[0].Rows[0]["ID"].ToString());
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                model.Area = ds.Tables[0].Rows[0]["Area"].ToString();
                model.CanCheced = ds.Tables[0].Rows[0]["CanCheced"].ToString();
                model.RealName = ds.Tables[0].Rows[0]["RealName"].ToString();
                return model;
            }
            else
            {
                return null;
            }



        }


        #endregion  Method
    }
}

