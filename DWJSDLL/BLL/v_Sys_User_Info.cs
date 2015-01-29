using System;
using System.Data;
using System.Collections.Generic;
using Eastcom.Common;
using Eastcom.Model;
namespace Eastcom.BLL
{
    /// <summary>
    /// v_Sys_User_Info
    /// </summary>
    public partial class v_Sys_User_Info
    {
        private readonly Eastcom.DAL.v_Sys_User_Info dal = new Eastcom.DAL.v_Sys_User_Info();
        public v_Sys_User_Info()
        { }
        
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserID)
        {
            return dal.Exists(UserID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Eastcom.Model.v_Sys_User_Info model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Eastcom.Model.v_Sys_User_Info model)
        {
            return dal.Update(model);
        }

     
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserID)
        {

            return dal.Delete(UserID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string UserIDlist)
        {
            return dal.DeleteList(UserIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Eastcom.Model.v_Sys_User_Info GetModel(int UserID)
        {
            return dal.GetModel(UserID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Eastcom.Model.v_Sys_User_Info GetModelByCache(int UserID)
        {

            string CacheKey = "v_Sys_User_InfoModel-" + UserID;
            object objModel = Eastcom.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(UserID);
                    if (objModel != null)
                    {
                        int ModelCache = Eastcom.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Eastcom.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Eastcom.Model.v_Sys_User_Info)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Eastcom.Model.v_Sys_User_Info> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Eastcom.Model.v_Sys_User_Info> DataTableToList(DataTable dt)
        {
            List<Eastcom.Model.v_Sys_User_Info> modelList = new List<Eastcom.Model.v_Sys_User_Info>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Eastcom.Model.v_Sys_User_Info model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Eastcom.Model.v_Sys_User_Info();
                    if (dt.Rows[n]["UserID"] != null && dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = int.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    if (dt.Rows[n]["UserName"] != null && dt.Rows[n]["UserName"].ToString() != "")
                    {
                        model.UserName = dt.Rows[n]["UserName"].ToString();
                    }
                    if (dt.Rows[n]["RealName"] != null && dt.Rows[n]["RealName"].ToString() != "")
                    {
                        model.RealName = dt.Rows[n]["RealName"].ToString();
                    }
                    if (dt.Rows[n]["NickName"] != null && dt.Rows[n]["NickName"].ToString() != "")
                    {
                        model.NickName = dt.Rows[n]["NickName"].ToString();
                    }
                    if (dt.Rows[n]["Pwd"] != null && dt.Rows[n]["Pwd"].ToString() != "")
                    {
                        model.Pwd = dt.Rows[n]["Pwd"].ToString();
                    }
                    if (dt.Rows[n]["FK_UnitID"] != null && dt.Rows[n]["FK_UnitID"].ToString() != "")
                    {
                        model.FK_UnitID = int.Parse(dt.Rows[n]["FK_UnitID"].ToString());
                    }
                    if (dt.Rows[n]["Sex"] != null && dt.Rows[n]["Sex"].ToString() != "")
                    {
                        model.Sex = int.Parse(dt.Rows[n]["Sex"].ToString());
                    }
                    if (dt.Rows[n]["Age"] != null && dt.Rows[n]["Age"].ToString() != "")
                    {
                        model.Age = int.Parse(dt.Rows[n]["Age"].ToString());
                    }
                    if (dt.Rows[n]["Email"] != null && dt.Rows[n]["Email"].ToString() != "")
                    {
                        model.Email = dt.Rows[n]["Email"].ToString();
                    }
                    if (dt.Rows[n]["Tel"] != null && dt.Rows[n]["Tel"].ToString() != "")
                    {
                        model.Tel = dt.Rows[n]["Tel"].ToString();
                    }
                    if (dt.Rows[n]["QQ"] != null && dt.Rows[n]["QQ"].ToString() != "")
                    {
                        model.QQ = dt.Rows[n]["QQ"].ToString();
                    }
                    if (dt.Rows[n]["Address"] != null && dt.Rows[n]["Address"].ToString() != "")
                    {
                        model.Address = dt.Rows[n]["Address"].ToString();
                    }
                    if (dt.Rows[n]["Birth"] != null && dt.Rows[n]["Birth"].ToString() != "")
                    {
                        model.Birth = DateTime.Parse(dt.Rows[n]["Birth"].ToString());
                    }
                    if (dt.Rows[n]["Contact"] != null && dt.Rows[n]["Contact"].ToString() != "")
                    {
                        model.Contact = dt.Rows[n]["Contact"].ToString();
                    }
                    if (dt.Rows[n]["Remark"] != null && dt.Rows[n]["Remark"].ToString() != "")
                    {
                        model.Remark = dt.Rows[n]["Remark"].ToString();
                    }
                    if (dt.Rows[n]["FK_CreateID"] != null && dt.Rows[n]["FK_CreateID"].ToString() != "")
                    {
                        model.FK_CreateID = int.Parse(dt.Rows[n]["FK_CreateID"].ToString());
                    }
                    if (dt.Rows[n]["CreateTime"] != null && dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }
                    if (dt.Rows[n]["FK_EditID"] != null && dt.Rows[n]["FK_EditID"].ToString() != "")
                    {
                        model.FK_EditID = int.Parse(dt.Rows[n]["FK_EditID"].ToString());
                    }
                    if (dt.Rows[n]["EditTime"] != null && dt.Rows[n]["EditTime"].ToString() != "")
                    {
                        model.EditTime = DateTime.Parse(dt.Rows[n]["EditTime"].ToString());
                    }
                    if (dt.Rows[n]["State"] != null && dt.Rows[n]["State"].ToString() != "")
                    {
                        model.State = int.Parse(dt.Rows[n]["State"].ToString());
                    }
                    if (dt.Rows[n]["IsDel"] != null && dt.Rows[n]["IsDel"].ToString() != "")
                    {
                        model.IsDel = int.Parse(dt.Rows[n]["IsDel"].ToString());
                    }
                    if (dt.Rows[n]["UserMangerArea"] != null && dt.Rows[n]["UserMangerArea"].ToString() != "")
                    {
                        model.UserMangerArea = dt.Rows[n]["UserMangerArea"].ToString();
                    }
                    else
                        model.UserMangerArea = "";

                    if (dt.Rows[n]["角色名"] != null && dt.Rows[n]["角色名"].ToString() != "")
                    {
                        model.角色名 = dt.Rows[n]["角色名"].ToString();
                    }
                    if (dt.Rows[n]["角色ID"] != null && dt.Rows[n]["角色ID"].ToString() != "")
                    {
                        model.角色ID = dt.Rows[n]["角色ID"].ToString();
                    }
                    if (dt.Rows[n]["最大角色权重"] != null && dt.Rows[n]["最大角色权重"].ToString() != "")
                    {
                        model.最大角色权重 = int.Parse(dt.Rows[n]["最大角色权重"].ToString());
                    }
                    if (dt.Rows[n]["性别"] != null && dt.Rows[n]["性别"].ToString() != "")
                    {
                        model.性别 = dt.Rows[n]["性别"].ToString();
                    }
                    if (dt.Rows[n]["创建者名"] != null && dt.Rows[n]["创建者名"].ToString() != "")
                    {
                        model.创建者名 = dt.Rows[n]["创建者名"].ToString();
                    }
                    if (dt.Rows[n]["修改者名"] != null && dt.Rows[n]["修改者名"].ToString() != "")
                    {
                        model.修改者名 = dt.Rows[n]["修改者名"].ToString();
                    }
                    if (dt.Rows[n]["账户状态"] != null && dt.Rows[n]["账户状态"].ToString() != "")
                    {
                        model.账户状态 = dt.Rows[n]["账户状态"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

    }
}

