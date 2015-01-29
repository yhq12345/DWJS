using System;
using System.Data;
using System.Collections.Generic;
using Eastcom.Common;
using Eastcom.Model;

using System.Text;
namespace Eastcom.BLL
{
	/// <summary>
	/// 权限表（功能）
	/// </summary>
	public partial class Sys_Power_Right
	{
        private readonly Eastcom.DAL.Sys_Power_Right dal = new Eastcom.DAL.Sys_Power_Right();
		public Sys_Power_Right()
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
		public bool Exists(int RightID)
		{
			return dal.Exists(RightID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(Eastcom.Model.Sys_Power_Right model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(Eastcom.Model.Sys_Power_Right model)
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
		public bool DeleteList(string RightIDlist )
		{
			return dal.DeleteList(RightIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Eastcom.Model.Sys_Power_Right GetModel(int RightID)
		{
			return dal.GetModel(RightID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public Eastcom.Model.Sys_Power_Right GetModelByCache(int RightID)
		{
			
			string CacheKey = "Sys_Power_RightModel-" + RightID;
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
				catch{}
			}
            return (Eastcom.Model.Sys_Power_Right)objModel;
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
        public List<Eastcom.Model.Sys_Power_Right> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Eastcom.Model.Sys_Power_Right> DataTableToList(DataTable dt)
		{
            List<Eastcom.Model.Sys_Power_Right> modelList = new List<Eastcom.Model.Sys_Power_Right>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                Eastcom.Model.Sys_Power_Right model;
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
        /// 分页(可按非主键排序)
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetPageList(int PageSize, int PageIndex, ref int recordCount, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            return dal.GetPageList(PageSize, PageIndex, ref recordCount, strWhere, fieldName, fieldKey, fieldOrder);
        }

        /// <summary>
        /// 根据权限类别和权限名返回model
        /// </summary>
        /// <param name="parentName">父类权限，如“用户管理”</param>
        /// <param name="rightName">子类权限，如“新增用户”</param>
        /// <returns></returns>
        public Eastcom.Model.Sys_Power_Right GetModel(string parentName, string rightName)
        {
            Eastcom.Model.Sys_Power_Right model = null;
            if (parentName=="0")
            {
                model = this.GetModel(0, rightName.Trim());
            }
            if (!string.IsNullOrEmpty(parentName) && !string.IsNullOrEmpty(rightName))
            {
                Eastcom.Model.Sys_Power_Right parentModel = this.GetModel(0, parentName.Trim());
                if (null != parentModel) 
                {
                    model = this.GetModel(parentModel.RightID, rightName);
                }
            }
            return model;
        }

        /// <summary>
        /// 根据父类ID和权限名，返回model
        /// </summary>
        /// <param name="parentId">父类ID</param>
        /// <param name="rightName">权限名</param>
        /// <returns></returns>
        public Eastcom.Model.Sys_Power_Right GetModel(int parentId, string rightName)
        {
            Eastcom.Model.Sys_Power_Right model = null;
            if (!string.IsNullOrEmpty(rightName))
            {
                List<Eastcom.Model.Sys_Power_Right> lst = this.GetModelList(string.Format("ParentID={0} and RightName='{1}'", parentId, rightName.Trim()));
                if (null != lst && lst.Count > 0)
                {
                    model = lst[0];
                }
            }
            return model;
        }

        /// <summary>
        /// 根据角色ID，返回此角色权限表中的权限
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <returns></returns>
        public List<Eastcom.Model.Sys_Power_Right> GetModelListByRoleID(int roleID)
        {
            List<Eastcom.Model.Sys_Power_Right> lst = null;
            string str = string.Empty;
            Eastcom.BLL.Sys_Power_RoleRight roleRightBLL = new Eastcom.BLL.Sys_Power_RoleRight();
            List<Eastcom.Model.Sys_Power_RoleRight> roleRightLst = roleRightBLL.GetModelList(string.Format("FK_RoleID={0}", roleID));
            if (null != roleRightLst && roleRightLst.Count > 0)
            {
                List<string> ids = new List<string>();
                foreach (Eastcom.Model.Sys_Power_RoleRight m in roleRightLst)
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
        public List<Eastcom.Model.Sys_Power_Right> GetModelListByUserID(int userID)
        {
            List<Eastcom.Model.Sys_Power_Right> lst = null;
            string str = string.Empty;
            Eastcom.BLL.Sys_Power_UserRight userRightBLL = new Eastcom.BLL.Sys_Power_UserRight();
            List<Eastcom.Model.Sys_Power_UserRight> userRightLst = userRightBLL.GetModelList(string.Format("FK_UserID={0}", userID));
            if (null != userRightLst && userRightLst.Count > 0)
            {
                List<string> ids = new List<string>();
                foreach (Eastcom.Model.Sys_Power_UserRight m in userRightLst)
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

        /// <summary>
        /// 检查该权限是否已经存在
        /// </summary>
        /// <param name="parentID">父类ID，一般为0</param>
        /// <param name="rightName">权限名</param>
        /// <returns></returns>
        public bool ExistRightName(int parentID, string rightName)
        {
            bool flag = false;
            List<Eastcom.Model.Sys_Power_Right> lst = this.GetModelList(string.Format("ParentID={0} and RightName='{1}'", parentID, rightName));
            if (null != lst && lst.Count > 0)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 批量删除(parentid=0不能删)
        /// </summary>
        /// <param name="ids">逗号分隔的字符串</param>
        public string Del(string ids)
        {
            StringBuilder str = new StringBuilder();
            int[] rightIds = CommonClass.StringHander.Common.GetIntArrayByStringArray(ids.Split(','));
            if (rightIds.Length > 0)
            {
                for (int i = 0; i < rightIds.Length; i++)
                {
                    if (rightIds[i] <= 0)
                    {
                        continue;
                    }
                    else
                    {
                        Eastcom.Model.Sys_Power_Right rightModel = this.GetModel(rightIds[i]);
                        if (null != rightModel && rightModel.ParentId == 0)
                        {
                            continue;
                        }
                    }
                    this.Delete(rightIds[i]);
                }
            }
            return str.ToString();
        }

        /// <summary>
        /// 返回权限视图
        /// </summary>
        public DataTable GetRightViewList(string where, string orderby)
        {
            return dal.GetRightViewList(where, orderby);
        }
		#endregion  ExtensionMethod
	}
}

