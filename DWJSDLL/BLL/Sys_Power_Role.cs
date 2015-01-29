using System;
using System.Data;
using System.Collections.Generic;
using Eastcom.Common;
using Eastcom.Model;
using System.Text;
namespace Eastcom.BLL
{
	/// <summary>
	/// 角色表
	/// </summary>
	public partial class Sys_Power_Role
	{
        private readonly Eastcom.DAL.Sys_Power_Role dal = new Eastcom.DAL.Sys_Power_Role();
		public Sys_Power_Role()
		{}
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
		public bool Exists(int RoleID)
		{
			return dal.Exists(RoleID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(Eastcom.Model.Sys_Power_Role model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(Eastcom.Model.Sys_Power_Role model)
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
		public bool DeleteList(string RoleIDlist )
		{
			return dal.DeleteList(RoleIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Eastcom.Model.Sys_Power_Role GetModel(int RoleID)
		{
			
			return dal.GetModel(RoleID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public Eastcom.Model.Sys_Power_Role GetModelByCache(int RoleID)
		{
			
			string CacheKey = "Sys_Power_RoleModel-" + RoleID;
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
				catch{}
			}
            return (Eastcom.Model.Sys_Power_Role)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Eastcom.Model.Sys_Power_Role> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Eastcom.Model.Sys_Power_Role> DataTableToList(DataTable dt)
		{
            List<Eastcom.Model.Sys_Power_Role> modelList = new List<Eastcom.Model.Sys_Power_Role>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                Eastcom.Model.Sys_Power_Role model;
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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
        /// <param name="model">model</param>
        /// <param name="rightIDs">权限ID数组</param>
        public int Add(Eastcom.Model.Sys_Power_Role model, int[] rightIDs, Eastcom.Model.v_Sys_User_Info uModel)
        {
            int result = dal.Add(model);
            if (result > 0)
            {
                Eastcom.BLL.Sys_Power_RoleRight roleRightBLL = new Sys_Power_RoleRight();
                roleRightBLL.Add(result, rightIDs, uModel);
            }
            return result;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">model</param>
        /// <param name="rightIDs">权限ID数组</param> 
        public bool Update(Eastcom.Model.Sys_Power_Role model, int[] rightIDs, Eastcom.Model.v_Sys_User_Info uModel)
        {
            bool flag = dal.Update(model);
            if (flag)
            {
                Eastcom.BLL.Sys_Power_RoleRight roleRightBLL = new Sys_Power_RoleRight();
                //删除角色的所有权限再添加
                if (roleRightBLL.DelWhere(string.Format("FK_RoleID={0}", model.RoleID)))
                {
                    roleRightBLL.Add(model.RoleID, rightIDs, uModel);
                }
            }
            return flag;
        }

        /// <summary>
        /// 返回指定用户所拥有的角色
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public List<Model.Sys_Power_Role> GetModelListByUserId(int userId)
        {
            List<Model.Sys_Power_Role> lst = null;
            string str = string.Empty;
            BLL.Sys_Power_UserRole userRoleBLL = new BLL.Sys_Power_UserRole();
            List<Model.Sys_Power_UserRole> userRoleLst = userRoleBLL.GetModelList(string.Format("FK_UserID={0}", userId));
            if (null != userRoleLst && userRoleLst.Count > 0)
            {
                List<string> ids = new List<string>();
                foreach (Model.Sys_Power_UserRole m in userRoleLst)
                {
                    ids.Add(Convert.ToString(m.FK_RoleId));
                }
                str = string.Join(",", ids.ToArray());
                if (!string.IsNullOrEmpty(str))
                {
                    lst = this.GetModelList(string.Format("RoleID in({0})", str));
                }
            }
            return lst;
        }

        /// <summary>
        /// 分页(可按非主键排序)
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetPageList(int PageSize, int PageIndex, ref int recordCount, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            return dal.GetPageList(PageSize, PageIndex, ref recordCount, strWhere, fieldName, fieldKey, fieldOrder);
        }

        /// <summary>
        /// true:指定角色名已经存在
        /// </summary>
        /// <param name="roleName">角色名</param>
        public bool ExistRoleName(string roleName)
        {
            bool flag = false;
            List<Eastcom.Model.Sys_Power_Role> lst = this.GetModelList(string.Format("RoleName='{0}'", roleName));
            if (null != lst && lst.Count > 0)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 检查指定角色是否有未删除的用户
        /// </summary>
        public bool HasUsers(int roleID)
        {
            bool flag = false;
            Eastcom.BLL.Sys_Power_UserRole urBLL = new Sys_Power_UserRole();
            List<Eastcom.Model.Sys_Power_UserRole> lst = urBLL.GetModelList(string.Format("FK_RoleID={0} and FK_UserID in(select UserID from v_Sys_User_Info)", roleID));
            if (null != lst && lst.Count > 0)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">逗号分隔的字符串</param>
        public string Del(string ids)
        {
            StringBuilder str = new StringBuilder();
            int[] roleIds = CommonClass.StringHander.Common.GetIntArrayByStringArray(ids.Split(','));
            if (roleIds.Length > 0)
            {
                for (int i = 0; i < roleIds.Length; i++)
                {
                    if (roleIds[i] <= 0)
                    {
                        continue;
                    }
                    if (!this.HasUsers(roleIds[i]))
                    {
                        this.Delete(roleIds[i]);
                    }
                    else
                    {
                        Eastcom.Model.Sys_Power_Role roleModel = this.GetModel(roleIds[i]);
                        if (null != roleModel)
                        {
                            str.AppendFormat("角色【{0}】正在使用中！", roleModel.RoleName);
                        }
                    }
                }
            }
            return str.ToString();
        }
		#endregion  ExtensionMethod
	}
}

