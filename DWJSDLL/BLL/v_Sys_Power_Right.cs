using System;
using System.Data;
using System.Collections.Generic;
using Eastcom.Common;
using Eastcom.Model;
namespace Eastcom.BLL
{
    /// <summary>
    /// v_Sys_Power_Right
    /// </summary>
    public partial class v_Sys_Power_Right
    {
        private readonly Eastcom.DAL.v_Sys_Power_Right dal = new Eastcom.DAL.v_Sys_Power_Right();
        public v_Sys_Power_Right()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RightID)
        {
            return dal.Exists(RightID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Eastcom.Model.v_Sys_Power_Right model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Eastcom.Model.v_Sys_Power_Right model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int RightID)
        {

            return dal.Delete(RightID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string RightIDlist)
        {
            return dal.DeleteList(RightIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Eastcom.Model.v_Sys_Power_Right GetModel(int RightID)
        {

            return dal.GetModel(RightID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Eastcom.Model.v_Sys_Power_Right GetModelByCache(int RightID)
        {

            string CacheKey = "v_Sys_Power_RightModel-" + RightID;
            object objModel = Eastcom.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(RightID);
                    if (objModel != null)
                    {
                        int ModelCache = Eastcom.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Eastcom.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Eastcom.Model.v_Sys_Power_Right)objModel;
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
        public List<Eastcom.Model.v_Sys_Power_Right> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Eastcom.Model.v_Sys_Power_Right> DataTableToList(DataTable dt)
        {
            List<Eastcom.Model.v_Sys_Power_Right> modelList = new List<Eastcom.Model.v_Sys_Power_Right>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Eastcom.Model.v_Sys_Power_Right model;
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
        /// 根据角色ID，返回此角色权限表中的权限
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <returns></returns>
        public List<Model.v_Sys_Power_Right> GetModelListByRoleID(int roleID)
        {
            List<Model.v_Sys_Power_Right> lst = null;
            string str = string.Empty;
            BLL.Sys_Power_RoleRight roleRightBLL = new BLL.Sys_Power_RoleRight();
            List<Model.Sys_Power_RoleRight> roleRightLst = roleRightBLL.GetModelList(string.Format("FK_RoleID={0}", roleID));
            if (null != roleRightLst && roleRightLst.Count > 0)
            {
                List<string> ids = new List<string>();
                foreach (Model.Sys_Power_RoleRight m in roleRightLst)
                {
                    ids.Add(Convert.ToString(m.FK_RightId));
                }
                str = string.Join(",", ids.ToArray());
                if (!string.IsNullOrEmpty(str))
                {
                    lst = this.GetModelList(string.Format("RightID in({0})", str));
                }
            }
            return lst;
        }

        /// <summary>
        /// 根据用户ID，返回此用户权限表中的权限
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public List<Model.v_Sys_Power_Right> GetModelListByUserID(int userID)
        {
            List<Model.v_Sys_Power_Right> lst = null;
            string str = string.Empty;
            BLL.Sys_Power_UserRight userRightBLL = new BLL.Sys_Power_UserRight();
            List<Model.Sys_Power_UserRight> userRightLst = userRightBLL.GetModelList(string.Format("FK_UserID={0}", userID));
            if (null != userRightLst && userRightLst.Count > 0)
            {
                List<string> ids = new List<string>();
                foreach (Model.Sys_Power_UserRight m in userRightLst)
                {
                    ids.Add(Convert.ToString(m.FK_RightID));
                }
                str = string.Join(",", ids.ToArray());
                if (!string.IsNullOrEmpty(str))
                {
                    lst = this.GetModelList(string.Format("RightID in({0})", str));
                }
            }
            return lst;
        }
        #endregion  ExtensionMethod
    }
}

