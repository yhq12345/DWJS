using System;
using System.Data;
using System.Collections.Generic;
using Eastcom.Common;
using Eastcom.Model;
namespace Eastcom.BLL
{
    /// <summary>
    /// 考试题库
    /// </summary>
    public partial class 考试题库
    {
        private readonly Eastcom.DAL.考试题库 dal = new Eastcom.DAL.考试题库();
        public 考试题库()
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
        public int Add(Eastcom.Model.考试题库 model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Eastcom.Model.考试题库 model)
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
        public Eastcom.Model.考试题库 GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Eastcom.Model.考试题库 GetModelByCache(int id)
        {

            string CacheKey = "考试题库Model-" + id;
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
            return (Eastcom.Model.考试题库)objModel;
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
        public List<Eastcom.Model.考试题库> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Eastcom.Model.考试题库> DataTableToList(DataTable dt)
        {
            List<Eastcom.Model.考试题库> modelList = new List<Eastcom.Model.考试题库>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Eastcom.Model.考试题库 model;
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

        public bool ExecuteTrunCate()
        {
            return dal.ExecuteTrunCate();
        }
        public bool AddHisBak(DateTime 备份时间, string 操作人)
        {
            //return dal.AddHisBak(备份时间,操作人);
         List<Eastcom.Model.考试题库> modelList =  GetModelList("");
         foreach (Eastcom.Model.考试题库 x in modelList)
         {
             Eastcom.Model.考试题库_His model = new Model.考试题库_His();
             model.题目内容 = x.题目内容;
             model.A选项 = x.A选项;
             model.B选项 = x.B选项;
             model.C选项 = x.C选项;
             model.D选项 = x.D选项;
             model.其他选项 = x.其他选项;
             model.标准答案 = x.标准答案;
             model.标准答案2 = x.标准答案2;

             model.备份时间 = 备份时间;
             model.操作人 = 操作人;

             new Eastcom.BLL.考试题库_His().Add(model);
         }
          return true;
        }
        public bool Update标准答案()
        {
            List<Eastcom.Model.考试题库> modlelist = new List<Eastcom.Model.考试题库>();
            modlelist = new Eastcom.BLL.考试题库().GetModelList("");
            foreach (Eastcom.Model.考试题库 m in modlelist)
            {
                string 标准答案 = "";
                标准答案 = m.标准答案2.ToUpper();
                标准答案 = 标准答案.Replace("A", "A,");
                标准答案 = 标准答案.Replace("B", "B,");
                标准答案 = 标准答案.Replace("C", "C,");
                标准答案 = 标准答案.Replace("D", "D,");
                标准答案 = 标准答案.Replace("E", "E,");

                m.标准答案 = 标准答案;

                if (!new Eastcom.BLL.考试题库().Update(m))
                {
                    return false;
                }

            }
            return true;
            
        }



        #endregion  ExtensionMethod
    }
}

