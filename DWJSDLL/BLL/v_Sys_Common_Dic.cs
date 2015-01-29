using System;
using System.Data;
using System.Collections.Generic;
using Eastcom.Common;
using Eastcom.Model;
namespace Eastcom.BLL
{
    /// <summary>
    /// v_Sys_Common_Dic
    /// </summary>
    public partial class v_Sys_Common_Dic
    {
        private readonly Eastcom.DAL.v_Sys_Common_Dic dal = new Eastcom.DAL.v_Sys_Common_Dic();
        public v_Sys_Common_Dic()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int DicID)
        {
            return dal.Exists(DicID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Eastcom.Model.v_Sys_Common_Dic model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Eastcom.Model.v_Sys_Common_Dic model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int DicID)
        {

            return dal.Delete(DicID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string DicIDlist)
        {
            return dal.DeleteList(DicIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Eastcom.Model.v_Sys_Common_Dic GetModel(int DicID)
        {

            return dal.GetModel(DicID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Eastcom.Model.v_Sys_Common_Dic GetModelByCache(int DicID)
        {

            string CacheKey = "v_Sys_Common_DicModel-" + DicID;
            object objModel = Eastcom.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(DicID);
                    if (objModel != null)
                    {
                        int ModelCache = Eastcom.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Eastcom.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Eastcom.Model.v_Sys_Common_Dic)objModel;
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
        public List<Eastcom.Model.v_Sys_Common_Dic> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Eastcom.Model.v_Sys_Common_Dic> DataTableToList(DataTable dt)
        {
            List<Eastcom.Model.v_Sys_Common_Dic> modelList = new List<Eastcom.Model.v_Sys_Common_Dic>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Eastcom.Model.v_Sys_Common_Dic model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Eastcom.Model.v_Sys_Common_Dic();
                    if (dt.Rows[n]["DicID"] != null && dt.Rows[n]["DicID"].ToString() != "")
                    {
                        model.DicID = int.Parse(dt.Rows[n]["DicID"].ToString());
                    }
                    if (dt.Rows[n]["ParentID"] != null && dt.Rows[n]["ParentID"].ToString() != "")
                    {
                        model.ParentID = int.Parse(dt.Rows[n]["ParentID"].ToString());
                    }
                    if (dt.Rows[n]["DicName"] != null && dt.Rows[n]["DicName"].ToString() != "")
                    {
                        model.DicName = dt.Rows[n]["DicName"].ToString();
                    }
                    if (dt.Rows[n]["DicValue"] != null && dt.Rows[n]["DicValue"].ToString() != "")
                    {
                        model.DicValue = dt.Rows[n]["DicValue"].ToString();
                    }
                    if (dt.Rows[n]["IsReadOnly"] != null && dt.Rows[n]["IsReadOnly"].ToString() != "")
                    {
                        model.IsReadOnly = int.Parse(dt.Rows[n]["IsReadOnly"].ToString());
                    }
                    if (dt.Rows[n]["IsHasChild"] != null && dt.Rows[n]["IsHasChild"].ToString() != "")
                    {
                        model.IsHasChild = int.Parse(dt.Rows[n]["IsHasChild"].ToString());
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
                    if (dt.Rows[n]["父权限名"] != null && dt.Rows[n]["父权限名"].ToString() != "")
                    {
                        model.父权限名 = dt.Rows[n]["父权限名"].ToString();
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

