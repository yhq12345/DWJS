using System;
using System.Data;
using System.Collections.Generic;
using Eastcom.Common;
using Eastcom.Model;
using System.Linq;

namespace Eastcom.BLL
{
    /// <summary>
    /// 用户权限表
    /// </summary>
    public partial class Sys_Power_UserRight
    {
        private readonly Eastcom.DAL.Sys_Power_UserRight dal = new Eastcom.DAL.Sys_Power_UserRight();
        public Sys_Power_UserRight()
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
        public int Add(Eastcom.Model.Sys_Power_UserRight model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Eastcom.Model.Sys_Power_UserRight model)
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
        public Eastcom.Model.Sys_Power_UserRight GetModel(int Id)
        {
            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Eastcom.Model.Sys_Power_UserRight GetModelByCache(int Id)
        {

            string CacheKey = "Sys_Power_UserRightModel-" + Id;
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
            return (Eastcom.Model.Sys_Power_UserRight)objModel;
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
        public List<Eastcom.Model.Sys_Power_UserRight> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Eastcom.Model.Sys_Power_UserRight> DataTableToList(DataTable dt)
        {
            List<Eastcom.Model.Sys_Power_UserRight> modelList = new List<Eastcom.Model.Sys_Power_UserRight>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Eastcom.Model.Sys_Power_UserRight model;
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
        /// 根据用户ID，返回该用户所有权限的ID组成的字符串
        /// </summary>
        /// <param name="userId">UserID</param>
        /// <returns></returns>
        public string GetUserRightIDsStr(int userId)
        {
            List<string> lstStr = new List<string>();
            List<Eastcom.Model.Sys_Power_UserRight> lst = this.GetModelList(string.Format("FK_UserID={0}", userId));
            if (null != lst && lst.Count > 0)
            {
                foreach (Eastcom.Model.Sys_Power_UserRight m in lst)
                {
                    lstStr.Add(m.FK_RightID.ToString());
                }
            }
            return (null != lstStr && lstStr.Count > 0) ? string.Join(",", lstStr.ToArray()) : "";
        }

        /// <summary>
        /// 根据用户ID，返回该用户所有权限的ID组成的字符串
        /// </summary>
        /// <param name="userId">UserID</param>
        /// <returns></returns>
        public string GetUserRightIDsStrFormUserInfo(int userId)
        {
            List<string> lstStr = new List<string>();
            //List<GXDW.Model.v_Sys_User_Info> lst = this.GetModelList(string.Format("FK_UserID={0}", userId));
            //if (null != lst && lst.Count > 0)
            //{
            //    foreach (GXDW.Model.Sys_Power_UserRight m in lst)
            //    {
            //        lstStr.Add(m.FK_RightID.ToString());
            //    }

            Eastcom.BLL.Sys_Power_Role roleBLL = new Eastcom.BLL.Sys_Power_Role();
            Eastcom.BLL.v_Sys_Power_Right rightBLL = new Eastcom.BLL.v_Sys_Power_Right();
            List<Eastcom.Model.v_Sys_Power_Right> rightList = new List<Eastcom.Model.v_Sys_Power_Right>();
            List<Eastcom.Model.v_Sys_Power_Right> rightTempList = new List<Eastcom.Model.v_Sys_Power_Right>();

            List<Eastcom.Model.Sys_Power_Role> CurrentRoleModelList = roleBLL.GetModelListByUserId(userId);

            #region 用户--权限--权限 *需要标明
            if (null != CurrentRoleModelList && CurrentRoleModelList.Count > 0)
            {
                foreach (Eastcom.Model.Sys_Power_Role m in CurrentRoleModelList)
                {
                    rightTempList = rightBLL.GetModelListByRoleID(m.RoleID);
                    if (null != rightTempList && rightTempList.Count > 0)
                    {
                        rightList.AddRange(rightTempList);/*添加角色的权限*/
                    }
                }
            }
            #endregion
            #region  用户---权限
            rightTempList = rightBLL.GetModelListByUserID(userId);/*添加用户的权限*/
            if (null != rightTempList && rightTempList.Count > 0)
            {
                rightList.AddRange(rightTempList);
            }
            if (null != rightList && rightList.Count > 0)
            {
                rightList = rightList.Distinct().ToList();
                foreach (Eastcom.Model.v_Sys_Power_Right m in rightList)
               {
                   lstStr.Add(  Convert.ToString(m.RightID));
               }
            }
            #endregion
            return (null != lstStr && lstStr.Count > 0) ? string.Join(",", lstStr.ToArray()) : "";
        }


        /// <summary>
        /// 根据条件删除
        /// </summary>
        public bool DelWhere(string where)
        {
            return dal.DelWhere(where);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(int userId, int[] rightsID, Eastcom.Model.v_Sys_User_Info uModel)
        {
            bool flag = true;
            Eastcom.Model.Sys_Power_UserRight userRightModel = null;
            if (rightsID.Length > 0)
            {
                if (this.DelWhere(string.Format("FK_UserID={0}", userId)))
                {
                    for (int i = 0; i < rightsID.Length; i++)
                    {
                        if (rightsID[i] > 0)
                        {
                            userRightModel = new Eastcom.Model.Sys_Power_UserRight();
                            userRightModel.EditTime = DateTime.Now;
                            userRightModel.FK_EditID = uModel.UserID;
                            userRightModel.FK_RightID = rightsID[i];
                            userRightModel.FK_UserID = userId;
                            if (this.Add(userRightModel) <= 0)
                            {
                                flag = false;
                            }
                        }
                    }
                }
            }
            return flag;
        }

        #endregion  ExtensionMethod
    }
}

