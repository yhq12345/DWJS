using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Eastcom.DBUtility;
using DAL;//Please add references
namespace Eastcom.DAL
{
	/// <summary>
	/// 数据访问类:Sys_User_Info
	/// </summary>
	public partial class Sys_User_Info
	{
		public Sys_User_Info()
		{}
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_User_Info");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
            parameters[0].Value = UserID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Eastcom.Model.Sys_User_Info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_User_Info(");
            strSql.Append("UserName,RealName,NickName,Pwd,FK_UnitID,UserArea,Sex,Age,Email,Tel,QQ,Address,Birth,Contact,Remark,FK_CreateID,CreateTime,FK_EditID,EditTime,State,IsDel,UserMangerArea)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@RealName,@NickName,@Pwd,@FK_UnitID,@UserArea,@Sex,@Age,@Email,@Tel,@QQ,@Address,@Birth,@Contact,@Remark,@FK_CreateID,@CreateTime,@FK_EditID,@EditTime,@State,@IsDel,@UserMangerArea)");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@RealName", SqlDbType.VarChar,50),
					new SqlParameter("@NickName", SqlDbType.VarChar,50),
					new SqlParameter("@Pwd", SqlDbType.VarChar,100),
					new SqlParameter("@FK_UnitID", SqlDbType.Int,4),
					new SqlParameter("@UserArea", SqlDbType.Int,4),
					new SqlParameter("@Sex", SqlDbType.TinyInt,1),
					new SqlParameter("@Age", SqlDbType.TinyInt,1),
					new SqlParameter("@Email", SqlDbType.VarChar,100),
					new SqlParameter("@Tel", SqlDbType.VarChar,50),
					new SqlParameter("@QQ", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,100),
					new SqlParameter("@Birth", SqlDbType.SmallDateTime),
					new SqlParameter("@Contact", SqlDbType.VarChar,100),
					new SqlParameter("@Remark", SqlDbType.VarChar,1000),
					new SqlParameter("@FK_CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@FK_EditID", SqlDbType.Int,4),
					new SqlParameter("@EditTime", SqlDbType.DateTime),
					new SqlParameter("@State", SqlDbType.TinyInt,1),
					new SqlParameter("@IsDel", SqlDbType.TinyInt,1),
                    new SqlParameter("@UserMangerArea",SqlDbType.VarChar,50)
                                        };
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.RealName;
            parameters[2].Value = model.NickName;
            parameters[3].Value = model.Pwd;
            parameters[4].Value = model.FK_UnitID;
            parameters[5].Value = model.UserArea;
            parameters[6].Value = model.Sex;
            parameters[7].Value = model.Age;
            parameters[8].Value = model.Email;
            parameters[9].Value = model.Tel;
            parameters[10].Value = model.QQ;
            parameters[11].Value = model.Address;
            parameters[12].Value = model.Birth;
            parameters[13].Value = model.Contact;
            parameters[14].Value = model.Remark;
            parameters[15].Value = model.FK_CreateID;
            parameters[16].Value = model.CreateTime;
            parameters[17].Value = model.FK_EditID;
            parameters[18].Value = model.EditTime;
            parameters[19].Value = model.State;
            parameters[20].Value = model.IsDel;
            parameters[21].Value = model.UserMangerArea;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
                return 0;
            else
                return Convert.ToInt32(obj);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Eastcom.Model.Sys_User_Info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_User_Info set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("RealName=@RealName,");
            strSql.Append("NickName=@NickName,");
            strSql.Append("Pwd=@Pwd,");
            strSql.Append("FK_UnitID=@FK_UnitID,");
            strSql.Append("UserArea=@UserArea,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Age=@Age,");
            strSql.Append("Email=@Email,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("QQ=@QQ,");
            strSql.Append("Address=@Address,");
            strSql.Append("Birth=@Birth,");
            strSql.Append("Contact=@Contact,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("FK_CreateID=@FK_CreateID,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("FK_EditID=@FK_EditID,");
            strSql.Append("EditTime=@EditTime,");
            strSql.Append("State=@State,");
            strSql.Append("IsDel=@IsDel,");
            strSql.Append("UserMangerArea=@UserMangerArea ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@RealName", SqlDbType.VarChar,50),
					new SqlParameter("@NickName", SqlDbType.VarChar,50),
					new SqlParameter("@Pwd", SqlDbType.VarChar,100),
					new SqlParameter("@FK_UnitID", SqlDbType.Int,4),
					new SqlParameter("@UserArea", SqlDbType.Int,4),
					new SqlParameter("@Sex", SqlDbType.TinyInt,1),
					new SqlParameter("@Age", SqlDbType.TinyInt,1),
					new SqlParameter("@Email", SqlDbType.VarChar,100),
					new SqlParameter("@Tel", SqlDbType.VarChar,50),
					new SqlParameter("@QQ", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,100),
					new SqlParameter("@Birth", SqlDbType.SmallDateTime),
					new SqlParameter("@Contact", SqlDbType.VarChar,100),
					new SqlParameter("@Remark", SqlDbType.VarChar,1000),
					new SqlParameter("@FK_CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@FK_EditID", SqlDbType.Int,4),
					new SqlParameter("@EditTime", SqlDbType.DateTime),
					new SqlParameter("@State", SqlDbType.TinyInt,1),
					new SqlParameter("@IsDel", SqlDbType.TinyInt,1),
                    new SqlParameter("@UserMangerArea",SqlDbType.VarChar,50),
					new SqlParameter("@UserID", SqlDbType.Int,4)
                   };
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.RealName;
            parameters[2].Value = model.NickName;
            parameters[3].Value = model.Pwd;
            parameters[4].Value = model.FK_UnitID;
            parameters[5].Value = model.UserArea;
            parameters[6].Value = model.Sex;
            parameters[7].Value = model.Age;
            parameters[8].Value = model.Email;
            parameters[9].Value = model.Tel;
            parameters[10].Value = model.QQ;
            parameters[11].Value = model.Address;
            parameters[12].Value = model.Birth;
            parameters[13].Value = model.Contact;
            parameters[14].Value = model.Remark;
            parameters[15].Value = model.FK_CreateID;
            parameters[16].Value = model.CreateTime;
            parameters[17].Value = model.FK_EditID;
            parameters[18].Value = model.EditTime;
            parameters[19].Value = model.State;
            parameters[20].Value = model.IsDel;
            parameters[21].Value = model.UserMangerArea;
            parameters[22].Value = model.UserID;

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
        public bool Delete(int UserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_User_Info ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
            parameters[0].Value = UserID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string UserIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_User_Info ");
            strSql.Append(" where UserID in (" + UserIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Eastcom.Model.Sys_User_Info GetModel(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserID,UserName,RealName,NickName,Pwd,FK_UnitID,UserArea,Sex,Age,Email,Tel,QQ,Address,Birth,Contact,Remark,FK_CreateID,CreateTime,FK_EditID,EditTime,State,IsDel,UserMangerArea from Sys_User_Info ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
            parameters[0].Value = UserID;

            Eastcom.Model.Sys_User_Info model = new Eastcom.Model.Sys_User_Info();
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
        public Eastcom.Model.Sys_User_Info DataRowToModel(DataRow row)
        {
            Eastcom.Model.Sys_User_Info model = new Eastcom.Model.Sys_User_Info();
            if (row != null)
            {
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["RealName"] != null)
                {
                    model.RealName = row["RealName"].ToString();
                }
                if (row["NickName"] != null)
                {
                    model.NickName = row["NickName"].ToString();
                }
                if (row["Pwd"] != null)
                {
                    model.Pwd = row["Pwd"].ToString();
                }
                if (row["FK_UnitID"] != null && row["FK_UnitID"].ToString() != "")
                {
                    model.FK_UnitID = int.Parse(row["FK_UnitID"].ToString());
                }
                if (row["UserArea"] != null && row["UserArea"].ToString() != "")
                {
                    model.UserArea = int.Parse(row["UserArea"].ToString());
                }
                if (row["Sex"] != null && row["Sex"].ToString() != "")
                {
                    model.Sex = int.Parse(row["Sex"].ToString());
                }
                if (row["Age"] != null && row["Age"].ToString() != "")
                {
                    model.Age = int.Parse(row["Age"].ToString());
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["Tel"] != null)
                {
                    model.Tel = row["Tel"].ToString();
                }
                if (row["QQ"] != null)
                {
                    model.QQ = row["QQ"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["Birth"] != null && row["Birth"].ToString() != "")
                {
                    model.Birth = DateTime.Parse(row["Birth"].ToString());
                }
                if (row["Contact"] != null)
                {
                    model.Contact = row["Contact"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["FK_CreateID"] != null && row["FK_CreateID"].ToString() != "")
                {
                    model.FK_CreateID = int.Parse(row["FK_CreateID"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["FK_EditID"] != null && row["FK_EditID"].ToString() != "")
                {
                    model.FK_EditID = int.Parse(row["FK_EditID"].ToString());
                }
                if (row["EditTime"] != null && row["EditTime"].ToString() != "")
                {
                    model.EditTime = DateTime.Parse(row["EditTime"].ToString());
                }
                if (row["State"] != null && row["State"].ToString() != "")
                {
                    model.State = int.Parse(row["State"].ToString());
                }
                if (row["IsDel"] != null && row["IsDel"].ToString() != "")
                {
                    model.IsDel = int.Parse(row["IsDel"].ToString());
                }
                if (row["UserMangerArea"] != null && row["UserMangerArea"].ToString() != "")
                    model.UserMangerArea = row["UserMangerArea"].ToString();
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID,UserName,RealName,NickName,Pwd,FK_UnitID,UserArea,Sex,Age,Email,Tel,QQ,Address,Birth,Contact,Remark,FK_CreateID,CreateTime,FK_EditID,EditTime,State,IsDel,UserMangerArea ");
            strSql.Append(" FROM Sys_User_Info ");
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
            strSql.Append(" UserID,UserName,RealName,NickName,Pwd,FK_UnitID,UserArea,Sex,Age,Email,Tel,QQ,Address,Birth,Contact,Remark,FK_CreateID,CreateTime,FK_EditID,EditTime,State,IsDel,UserMangerArea ");
            strSql.Append(" FROM Sys_User_Info ");
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
            strSql.Append("select count(1) FROM Sys_User_Info ");
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
                strSql.Append("order by T.UserID desc");
            }
            strSql.Append(")AS Row, T.*  from Sys_User_Info T ");
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
            parameters[0].Value = "Sys_User_Info";
            parameters[1].Value = "UserID";
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
            return CommonDAL.GetPageList("v_Sys_User_Info", PageSize, PageIndex, ref recordCount, strWhere, fieldName, fieldKey, fieldOrder);
        }

        public bool UpdatePassword(string pwd, string userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_User_Info set ");
            strSql.Append(" Pwd=@Pwd ");
            strSql.Append(" where UserID=@UserID");//UserName

            SqlParameter[] parameters = {
					new SqlParameter("@Pwd", SqlDbType.VarChar,50),
                    new SqlParameter("@UserID",SqlDbType.VarChar,50)};
            parameters[0].Value = pwd;
            parameters[1].Value = userID;

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
        /// 是否存在该记录
        /// </summary>
        public bool IsExistUserName(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_User_Info");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50)
			};
            parameters[0].Value = UserName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        #endregion  ExtensionMethod
	}
}

