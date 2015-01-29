﻿using System;
using System.Data;
using System.Collections.Generic;
using Eastcom.Common;
using Eastcom.Model;
namespace Eastcom.BLL
{
    /// <summary>
    /// 日度练习考核内容
    /// </summary>
    public partial class 日度练习考核内容
    {
        private readonly Eastcom.DAL.日度练习考核内容 dal = new Eastcom.DAL.日度练习考核内容();
        public 日度练习考核内容()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Eastcom.Model.日度练习考核内容 model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Eastcom.Model.日度练习考核内容 model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Eastcom.Model.日度练习考核内容 GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Eastcom.Model.日度练习考核内容 GetModelByCache(int id)
        {

            string CacheKey = "日度练习考核内容Model-" + id;
            object objModel = Eastcom.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(id);
                    if (objModel != null)
                    {
                        int ModelCache = Eastcom.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Eastcom.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Eastcom.Model.日度练习考核内容)objModel;
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
        public List<Eastcom.Model.日度练习考核内容> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Eastcom.Model.日度练习考核内容> DataTableToList(DataTable dt)
        {
            List<Eastcom.Model.日度练习考核内容> modelList = new List<Eastcom.Model.日度练习考核内容>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Eastcom.Model.日度练习考核内容 model;
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

        public bool Exists_Checked(string 练习日期, string FK_ID)
        {
            return dal.Exists_Checked(练习日期, FK_ID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add_Tran(Eastcom.Model.日度练习考核内容 model)
        {
            return dal.Add_Tran(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FK_User"></param>
        /// <param name="考核月份"></param>
        /// <returns></returns>
        public Eastcom.Model.日度练习考核内容 GetModelByUser(int FK_User, DateTime 练习日期)
        {
            return dal.GetModelByUser(FK_User, 练习日期);
        }

        /// <summary>
        /// 分页
        /// </summary>
        public DataTable GetPageList(int PageSize, int PageIndex, ref int recordCount, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            return dal.GetPageList(PageSize, PageIndex, ref  recordCount, strWhere, fieldName, fieldKey, fieldOrder);
        }
        /// <summary>
        /// 获得数据列表(用于导出)
        /// </summary>
        public DataSet GetOutPutViewList(string strWhere, string fields, string orderby)
        {
            return dal.GetOutPutViewList(strWhere, fields, orderby);
        }



        #endregion  ExtensionMethod
    }
}

