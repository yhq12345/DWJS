using System;
using System.Data;
using System.Collections.Generic;
using Eastcom.Common;
using Eastcom.Model;
namespace Eastcom.BLL
{
    /// <summary>
    /// v_Sys_Power_Role
    /// </summary>
    public partial class v_Sys_Power_Role
    {
        private readonly Eastcom.DAL.v_Sys_Power_Role dal = new Eastcom.DAL.v_Sys_Power_Role();
        public v_Sys_Power_Role()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RoleID)
        {
            return dal.Exists(RoleID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Eastcom.Model.v_Sys_Power_Role model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Eastcom.Model.v_Sys_Power_Role model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int RoleID)
        {

            return dal.Delete(RoleID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string RoleIDlist)
        {
            return dal.DeleteList(RoleIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Eastcom.Model.v_Sys_Power_Role GetModel(int RoleID)
        {

            return dal.GetModel(RoleID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Eastcom.Model.v_Sys_Power_Role GetModelByCache(int RoleID)
        {

            string CacheKey = "v_Sys_Power_RoleModel-" + RoleID;
            object objModel = Eastcom.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(RoleID);
                    if (objModel != null)
                    {
                        int ModelCache = Eastcom.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Eastcom.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Eastcom.Model.v_Sys_Power_Role)objModel;
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
        public List<Eastcom.Model.v_Sys_Power_Role> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Eastcom.Model.v_Sys_Power_Role> DataTableToList(DataTable dt)
        {
            List<Eastcom.Model.v_Sys_Power_Role> modelList = new List<Eastcom.Model.v_Sys_Power_Role>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Eastcom.Model.v_Sys_Power_Role model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Eastcom.Model.v_Sys_Power_Role();
                    if (dt.Rows[n]["RoleID"] != null && dt.Rows[n]["RoleID"].ToString() != "")
                    {
                        model.RoleID = int.Parse(dt.Rows[n]["RoleID"].ToString());
                    }
                    if (dt.Rows[n]["RoleName"] != null && dt.Rows[n]["RoleName"].ToString() != "")
                    {
                        model.RoleName = dt.Rows[n]["RoleName"].ToString();
                    }
                    if (dt.Rows[n]["RoleWeight"] != null && dt.Rows[n]["RoleWeight"].ToString() != "")
                    {
                        model.RoleWeight = int.Parse(dt.Rows[n]["RoleWeight"].ToString());
                    }
                    if (dt.Rows[n]["Remark"] != null && dt.Rows[n]["Remark"].ToString() != "")
                    {
                        model.Remark = dt.Rows[n]["Remark"].ToString();
                    }
                    if (dt.Rows[n]["FK_EditID"] != null && dt.Rows[n]["FK_EditID"].ToString() != "")
                    {
                        model.FK_EditID = int.Parse(dt.Rows[n]["FK_EditID"].ToString());
                    }
                    if (dt.Rows[n]["EditTime"] != null && dt.Rows[n]["EditTime"].ToString() != "")
                    {
                        model.EditTime = DateTime.Parse(dt.Rows[n]["EditTime"].ToString());
                    }
                    if (dt.Rows[n]["FK_CreateID"] != null && dt.Rows[n]["FK_CreateID"].ToString() != "")
                    {
                        model.FK_CreateID = int.Parse(dt.Rows[n]["FK_CreateID"].ToString());
                    }
                    if (dt.Rows[n]["CreateTime"] != null && dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }
                    if (dt.Rows[n]["Sort"] != null && dt.Rows[n]["Sort"].ToString() != "")
                    {
                        model.Sort = int.Parse(dt.Rows[n]["Sort"].ToString());
                    }
                    if (dt.Rows[n]["创建者名"] != null && dt.Rows[n]["创建者名"].ToString() != "")
                    {
                        model.创建者名 = dt.Rows[n]["创建者名"].ToString();
                    }
                    if (dt.Rows[n]["修改者名"] != null && dt.Rows[n]["修改者名"].ToString() != "")
                    {
                        model.修改者名 = dt.Rows[n]["修改者名"].ToString();
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

        #endregion  Method
    }
}

