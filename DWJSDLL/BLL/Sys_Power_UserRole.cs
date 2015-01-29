using System;
using System.Data;
using System.Collections.Generic;
using Eastcom.Common;
using Eastcom.Model;
using CommonClass;

namespace Eastcom.BLL
{
    /// <summary>
    /// 用户角色表
    /// </summary>
    public partial class Sys_Power_UserRole
    {
        private readonly Eastcom.DAL.Sys_Power_UserRole dal = new Eastcom.DAL.Sys_Power_UserRole();
        public Sys_Power_UserRole()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            return dal.Exists(Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Eastcom.Model.Sys_Power_UserRole model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Eastcom.Model.Sys_Power_UserRole model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            return dal.Delete(Id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            return dal.DeleteList(Idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Eastcom.Model.Sys_Power_UserRole GetModel(int Id)
        {
            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Eastcom.Model.Sys_Power_UserRole GetModelByCache(int Id)
        {

            string CacheKey = "Sys_Power_UserRoleModel-" + Id;
            object objModel = Eastcom.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = Eastcom.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Eastcom.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Eastcom.Model.Sys_Power_UserRole)objModel;
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
        public List<Eastcom.Model.Sys_Power_UserRole> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Eastcom.Model.Sys_Power_UserRole> DataTableToList(DataTable dt)
        {
            List<Eastcom.Model.Sys_Power_UserRole> modelList = new List<Eastcom.Model.Sys_Power_UserRole>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Eastcom.Model.Sys_Power_UserRole model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
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
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 根据指定条件删除
        /// </summary>
        public bool DelWhere(string where)
        {
            return dal.DelWhere(where);
        }

        /// <summary>
        /// 添加用户角色
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="roleIds">用,分隔的角色ID</param>
        /// <returns></returns>
        public int Add(int userId, string[] roleIds, Eastcom.Model.v_Sys_User_Info uModel)
        {
            //先删除该用户的所有角色
            this.DelWhere(string.Format("FK_UserID={0}", userId));

            int result = 0;
            int[] ids = CommonClass.StringHander.Common.GetIntArrayByStringArray(roleIds);
            if (ids.Length > 0)
            {
                Eastcom.Model.Sys_Power_UserRole model = null;

                for (int i = 0; i < ids.Length; i++)
                {
                    if (ids[i] == 0)
                    {
                        continue;
                    }
                    model = new Model.Sys_Power_UserRole();
                    model.CreateTime = DateTime.Now;
                    model.FK_CreateID = uModel.UserID;
                    model.FK_RoleId = ids[i];
                    model.FK_UserId = userId;
                    if (this.Add(model) > 0)
                    {
                        result++;
                    }
                }
            }
            return result;
        }
        #endregion  ExtensionMethod
    }
}

