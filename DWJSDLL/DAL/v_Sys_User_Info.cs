using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Eastcom.DBUtility;//Please add references

namespace Eastcom.DAL
{
    /// <summary>
    /// 数据访问类:v_Sys_User_Info
    /// </summary>
    public partial class v_Sys_User_Info
    {
        public v_Sys_User_Info()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from v_Sys_User_Info");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)			};
            parameters[0].Value = UserID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Eastcom.Model.v_Sys_User_Info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into v_Sys_User_Info(");
            strSql.Append("UserID,UserName,RealName,NickName,Pwd,FK_UnitID,UserArea,Sex,Age,Email,Tel,QQ,Address,Birth,Contact,Remark,FK_CreateID,CreateTime,FK_EditID,EditTime,State,IsDel,UserMangerArea,角色名,角色ID,最大角色权重,性别,创建者名,修改者名,账户状态,所在地区)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@UserName,@RealName,@NickName,@Pwd,@FK_UnitID,@UserArea,@Sex,@Age,@Email,@Tel,@QQ,@Address,@Birth,@Contact,@Remark,@FK_CreateID,@CreateTime,@FK_EditID,@EditTime,@State,@IsDel,@UserMangerArea,@角色名,@角色ID,@最大角色权重,@性别,@创建者名,@修改者名,@账户状态,@所在地区)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
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
					new SqlParameter("@角色名", SqlDbType.VarChar,4000),
					new SqlParameter("@角色ID", SqlDbType.VarChar,4000),
					new SqlParameter("@最大角色权重", SqlDbType.Int,4),
					new SqlParameter("@性别", SqlDbType.VarChar,500),
					new SqlParameter("@创建者名", SqlDbType.VarChar,50),
					new SqlParameter("@修改者名", SqlDbType.VarChar,50),
					new SqlParameter("@账户状态", SqlDbType.VarChar,500),
					new SqlParameter("@所在地区", SqlDbType.VarChar,500)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.RealName;
            parameters[3].Value = model.NickName;
            parameters[4].Value = model.Pwd;
            parameters[5].Value = model.FK_UnitID;
            parameters[6].Value = model.UserArea;
            parameters[7].Value = model.Sex;
            parameters[8].Value = model.Age;
            parameters[9].Value = model.Email;
            parameters[10].Value = model.Tel;
            parameters[11].Value = model.QQ;
            parameters[12].Value = model.Address;
            parameters[13].Value = model.Birth;
            parameters[14].Value = model.Contact;
            parameters[15].Value = model.Remark;
            parameters[16].Value = model.FK_CreateID;
            parameters[17].Value = model.CreateTime;
            parameters[18].Value = model.FK_EditID;
            parameters[19].Value = model.EditTime;
            parameters[20].Value = model.State;
            parameters[21].Value = model.IsDel;
            parameters[22].Value = model.UserMangerArea;
            parameters[23].Value = model.角色名;
            parameters[24].Value = model.角色ID;
            parameters[25].Value = model.最大角色权重;
            parameters[26].Value = model.性别;
            parameters[27].Value = model.创建者名;
            parameters[28].Value = model.修改者名;
            parameters[29].Value = model.账户状态;
            parameters[30].Value = model.所在地区;

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
        public bool Update(Eastcom.Model.v_Sys_User_Info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update v_Sys_User_Info set ");
            strSql.Append("UserID=@UserID,");
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
            strSql.Append("UserMangerArea=@UserMangerArea,");
            strSql.Append("角色名=@角色名,");
            strSql.Append("角色ID=@角色ID,");
            strSql.Append("最大角色权重=@最大角色权重,");
            strSql.Append("性别=@性别,");
            strSql.Append("创建者名=@创建者名,");
            strSql.Append("修改者名=@修改者名,");
            strSql.Append("账户状态=@账户状态,");
            strSql.Append("所在地区=@所在地区");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
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
					new SqlParameter("@角色名", SqlDbType.VarChar,4000),
					new SqlParameter("@角色ID", SqlDbType.VarChar,4000),
					new SqlParameter("@最大角色权重", SqlDbType.Int,4),
					new SqlParameter("@性别", SqlDbType.VarChar,500),
					new SqlParameter("@创建者名", SqlDbType.VarChar,50),
					new SqlParameter("@修改者名", SqlDbType.VarChar,50),
					new SqlParameter("@账户状态", SqlDbType.VarChar,500),
					new SqlParameter("@所在地区", SqlDbType.VarChar,500)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.RealName;
            parameters[3].Value = model.NickName;
            parameters[4].Value = model.Pwd;
            parameters[5].Value = model.FK_UnitID;
            parameters[6].Value = model.UserArea;
            parameters[7].Value = model.Sex;
            parameters[8].Value = model.Age;
            parameters[9].Value = model.Email;
            parameters[10].Value = model.Tel;
            parameters[11].Value = model.QQ;
            parameters[12].Value = model.Address;
            parameters[13].Value = model.Birth;
            parameters[14].Value = model.Contact;
            parameters[15].Value = model.Remark;
            parameters[16].Value = model.FK_CreateID;
            parameters[17].Value = model.CreateTime;
            parameters[18].Value = model.FK_EditID;
            parameters[19].Value = model.EditTime;
            parameters[20].Value = model.State;
            parameters[21].Value = model.IsDel;
            parameters[22].Value = model.UserMangerArea;
            parameters[23].Value = model.角色名;
            parameters[24].Value = model.角色ID;
            parameters[25].Value = model.最大角色权重;
            parameters[26].Value = model.性别;
            parameters[27].Value = model.创建者名;
            parameters[28].Value = model.修改者名;
            parameters[29].Value = model.账户状态;
            parameters[30].Value = model.所在地区;

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
            strSql.Append("delete from v_Sys_User_Info ");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)			};
            parameters[0].Value = UserID;

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
        public bool DeleteList(string UserIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from v_Sys_User_Info ");
            strSql.Append(" where UserID in (" + UserIDlist + ")  ");
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
        public Eastcom.Model.v_Sys_User_Info GetModel(int UserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserID,UserName,RealName,NickName,Pwd,FK_UnitID,UserArea,Sex,Age,Email,Tel,QQ,Address,Birth,Contact,Remark,FK_CreateID,CreateTime,FK_EditID,EditTime,State,IsDel,UserMangerArea,角色名,角色ID,最大角色权重,性别,创建者名,修改者名,账户状态,所在地区 from v_Sys_User_Info ");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)			};
            parameters[0].Value = UserID;

            Eastcom.Model.v_Sys_User_Info model = new Eastcom.Model.v_Sys_User_Info();
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
        public Eastcom.Model.v_Sys_User_Info DataRowToModel(DataRow row)
        {
            Eastcom.Model.v_Sys_User_Info model = new Eastcom.Model.v_Sys_User_Info();
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
                {
                    model.UserMangerArea = row["UserMangerArea"].ToString();
                }
                if (row["角色名"] != null)
                {
                    model.角色名 = row["角色名"].ToString();
                }
                if (row["角色ID"] != null)
                {
                    model.角色ID = row["角色ID"].ToString();
                }
                if (row["最大角色权重"] != null && row["最大角色权重"].ToString() != "")
                {
                    model.最大角色权重 = int.Parse(row["最大角色权重"].ToString());
                }
                if (row["性别"] != null)
                {
                    model.性别 = row["性别"].ToString();
                }
                if (row["创建者名"] != null)
                {
                    model.创建者名 = row["创建者名"].ToString();
                }
                if (row["修改者名"] != null)
                {
                    model.修改者名 = row["修改者名"].ToString();
                }
                if (row["账户状态"] != null)
                {
                    model.账户状态 = row["账户状态"].ToString();
                }
                if (row["所在地区"] != null)
                {
                    model.所在地区 = row["所在地区"].ToString();
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
            strSql.Append("select UserID,UserName,RealName,NickName,Pwd,FK_UnitID,UserArea,Sex,Age,Email,Tel,QQ,Address,Birth,Contact,Remark,FK_CreateID,CreateTime,FK_EditID,EditTime,State,IsDel,UserMangerArea,角色名,角色ID,最大角色权重,性别,创建者名,修改者名,账户状态,所在地区 ");
            strSql.Append(" FROM v_Sys_User_Info ");
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
            strSql.Append(" UserID,UserName,RealName,NickName,Pwd,FK_UnitID,UserArea,Sex,Age,Email,Tel,QQ,Address,Birth,Contact,Remark,FK_CreateID,CreateTime,FK_EditID,EditTime,State,IsDel,UserMangerArea,角色名,角色ID,最大角色权重,性别,创建者名,修改者名,账户状态,所在地区 ");
            strSql.Append(" FROM v_Sys_User_Info ");
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
            strSql.Append("select count(1) FROM v_Sys_User_Info ");
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
            strSql.Append(")AS Row, T.*  from v_Sys_User_Info T ");
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
            parameters[0].Value = "v_Sys_User_Info";
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

        #endregion  ExtensionMethod
    }
}

