using System;
using System.Data;
using System.Collections.Generic;
using Eastcom.Common;
using Eastcom.Model;
namespace Eastcom.BLL
{
    /// <summary>
    /// 角色权限表
    /// </summary>
    public partial class Sys_Power_RoleRight
    {
        private readonly Eastcom.DAL.Sys_Power_RoleRight dal = new Eastcom.DAL.Sys_Power_RoleRight();
        public Sys_Power_RoleRight()
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
        public int Add(Eastcom.Model.Sys_Power_RoleRight model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Eastcom.Model.Sys_Power_RoleRight model)
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
        public Eastcom.Model.Sys_Power_RoleRight GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Eastcom.Model.Sys_Power_RoleRight GetModelByCache(int Id)
        {

            string CacheKey = "Sys_Power_RoleRightModel-" + Id;
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
            return (Eastcom.Model.Sys_Power_RoleRight)objModel;
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
        public List<Eastcom.Model.Sys_Power_RoleRight> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Eastcom.Model.Sys_Power_RoleRight> DataTableToList(DataTable dt)
        {
            List<Eastcom.Model.Sys_Power_RoleRight> modelList = new List<Eastcom.Model.Sys_Power_RoleRight>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Eastcom.Model.Sys_Power_RoleRight model;
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
        /// 增加一条数据
        /// </summary>
        public bool Add(int roleID, int[] rightsID, Eastcom.Model.v_Sys_User_Info uModel)
        {
            Eastcom.Model.Sys_Power_RoleRight roleRightModel = null;
            bool flag = true;
            if (rightsID.Length > 0)
            {
                for (int i = 0; i < rightsID.Length; i++)
                {
                    if (rightsID[i] > 0)
                    {
                        roleRightModel = new Eastcom.Model.Sys_Power_RoleRight();
                        roleRightModel.CreateTime = DateTime.Now;
                        roleRightModel.FK_CreateID = uModel.UserID;
                        roleRightModel.FK_RightId = rightsID[i];
                        roleRightModel.FK_RoleId = roleID;
                        if (this.Add(roleRightModel) <= 0)
                        {
                            flag = false;
                        }
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        public bool DelWhere(string where)
        {
            return dal.DelWhere(where);
        }

        /// <summary>
        /// 根据角色ID，返回该角色所有权限的ID组成的字符串
        /// </summary>
        /// <returns>如："1,2,3"</returns>
        public string GetRoleRightIDsStr(int roleID)
        {
            List<string> lstStr = new List<string>();
            List<Eastcom.Model.Sys_Power_RoleRight> lst = this.GetModelList(string.Format("FK_RoleID={0}", roleID));
            if (null != lst && lst.Count > 0)
            {
                foreach (Eastcom.Model.Sys_Power_RoleRight m in lst)
                {
                    lstStr.Add(m.FK_RightId.ToString());
                }
            }
            return (null != lstStr && lstStr.Count > 0) ? string.Join(",", lstStr.ToArray()) : "";
        }
        #endregion  ExtensionMethod
    }
}

