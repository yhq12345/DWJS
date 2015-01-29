using System;
using System.Data;
using System.Collections.Generic;
using Eastcom.Common;
using Eastcom.Model;
using System.Text;
using CommonClass.StringHander;

namespace Eastcom.BLL
{
	/// <summary>
	/// 用户表
	/// </summary>
	public partial class Sys_User_Info
	{
        private readonly Eastcom.DAL.Sys_User_Info dal = new Eastcom.DAL.Sys_User_Info();
		public Sys_User_Info()
		{}
		#region  BasicMethod

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
        public int Add(Eastcom.Model.Sys_User_Info model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(Eastcom.Model.Sys_User_Info model)
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
		public bool DeleteList(string UserIDlist )
		{
			return dal.DeleteList(UserIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Eastcom.Model.Sys_User_Info GetModel(int UserID)
		{
			return dal.GetModel(UserID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public Eastcom.Model.Sys_User_Info GetModelByCache(int UserID)
		{
			
			string CacheKey = "Sys_User_InfoModel-" + UserID;
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
				catch{}
			}
            return (Eastcom.Model.Sys_User_Info)objModel;
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
        public List<Eastcom.Model.Sys_User_Info> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Eastcom.Model.Sys_User_Info> DataTableToList(DataTable dt)
		{
            List<Eastcom.Model.Sys_User_Info> modelList = new List<Eastcom.Model.Sys_User_Info>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                Eastcom.Model.Sys_User_Info model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]  ); //
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
        /// 用户登录检测
        /// </summary>
        /// <param name="pwd">md5</param>
        /// <returns>true:匹配成功</returns>
        public Eastcom.Model.v_Sys_User_Info GetModel(string userName, string pwd)
        {
            Eastcom.Model.v_Sys_User_Info model = null;
            List<Eastcom.Model.v_Sys_User_Info> lst = new Eastcom.BLL.v_Sys_User_Info().GetModelList(string.Format("UserName='{0}' and Pwd='{1}'", CommonClass.StringHander.Common.No_SqlHack(userName).ToLower(), CommonClass.StringHander.Common.No_SqlHack(pwd).ToLower()));
            if (null != lst && lst.Count > 0)
            {
                model = lst[0];
            }
            return model;
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
        /// 批量删除
        /// </summary>
        /// <param name="ids">逗号分隔的字符串</param>
        public string Del(string ids)
        {
            StringBuilder str = new StringBuilder();
            int[] userIds = CommonClass.StringHander.Common.GetIntArrayByStringArray(ids.Split(','));
            if (userIds.Length > 0)
            {
                for (int i = 0; i < userIds.Length; i++)
                {
                    if (userIds[i] <= 0)
                    {
                        continue;
                    }
                    else
                    {
                        Eastcom.Model.Sys_User_Info model = this.GetModel(userIds[i]);
                        if (null != model)
                        {
                            model.IsDel = 1;
                            if (!this.Update(model))
                            {
                                str.AppendFormat("用户【{0}】删除失败！", model.RealName);
                            }
                        }
                    }
                }
            }
            return str.ToString();
        }

        /// <summary>
        /// 检查where条件是否存在
        /// </summary>
        public bool ExistWhere(string where)
        {
            bool flag = false;
            if (!string.IsNullOrEmpty(where))
            {
                List<Eastcom.Model.Sys_User_Info> lst = this.GetModelList(where);
                if (null != lst && lst.Count > 0)
                {
                    flag = true;
                }
            }
            return flag;
          
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="psw"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool UpdatePassword(string psw, string userID)
        {
            return dal.UpdatePassword(psw, userID);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsExistUserName(string UserName)
        {
            return dal.IsExistUserName(UserName);
        }

		#endregion  ExtensionMethod
	}
}

