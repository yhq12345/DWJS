using System;
using System.Data;
using System.Collections.Generic;
using Eastcom.Common;
using Eastcom.Model;
namespace Eastcom.BLL
{
    /// <summary>
    /// Sys_Common_Log
    /// </summary>
    public partial class Sys_Common_Log
    {
        private readonly Eastcom.DAL.Sys_Common_Log dal = new Eastcom.DAL.Sys_Common_Log();
        public Sys_Common_Log()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int LogID)
        {
            return dal.Exists(LogID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Eastcom.Model.Sys_Common_Log model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Eastcom.Model.Sys_Common_Log model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int LogID)
        {

            return dal.Delete(LogID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string LogIDlist)
        {
            return dal.DeleteList(LogIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Eastcom.Model.Sys_Common_Log GetModel(int LogID)
        {

            return dal.GetModel(LogID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Eastcom.Model.Sys_Common_Log GetModelByCache(int LogID)
        {

            string CacheKey = "Sys_Common_LogModel-" + LogID;
            object objModel = Eastcom.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(LogID);
                    if (objModel != null)
                    {
                        int ModelCache = Eastcom.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Eastcom.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Eastcom.Model.Sys_Common_Log)objModel;
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
        public List<Eastcom.Model.Sys_Common_Log> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Eastcom.Model.Sys_Common_Log> DataTableToList(DataTable dt)
        {
            List<Eastcom.Model.Sys_Common_Log> modelList = new List<Eastcom.Model.Sys_Common_Log>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Eastcom.Model.Sys_Common_Log model;
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
        /// 分页(可按非主键排序)
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetPageList(int PageSize, int PageIndex, ref int recordCount, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            return dal.GetPageList(PageSize, PageIndex, ref recordCount, strWhere, fieldName, fieldKey, fieldOrder);
        }
        #endregion  ExtensionMethod
    }
}

