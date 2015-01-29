using System;
using System.Data;
using System.Collections.Generic;
using Eastcom.Common;
using Eastcom.Model;
namespace Eastcom.BLL
{
    /// <summary>
    /// Sys_ddl_Config
    /// </summary>
    public partial class Sys_ddl_Config
    {
        private readonly Eastcom.DAL.Sys_ddl_Config dal = new Eastcom.DAL.Sys_ddl_Config();
        public Sys_ddl_Config()
        { }
     

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(Eastcom.Model.Sys_ddl_Config model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Eastcom.Model.Sys_ddl_Config model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Eastcom.Model.Sys_ddl_Config GetModel(long ID)
        {

            return dal.GetModel(ID);
        }

      

        public DataTable GetDataName(string DataType)
        {
            return dal.GetDataName(DataType);
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
        public List<Eastcom.Model.Sys_ddl_Config> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Eastcom.Model.Sys_ddl_Config> DataTableToList(DataTable dt)
        {
            List<Eastcom.Model.Sys_ddl_Config> modelList = new List<Eastcom.Model.Sys_ddl_Config>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Eastcom.Model.Sys_ddl_Config model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Eastcom.Model.Sys_ddl_Config();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = long.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["DDl_Value"] != null && dt.Rows[n]["DDl_Value"].ToString() != "")
                    {
                        model.DDl_Value = dt.Rows[n]["DDl_Value"].ToString();
                    }
                    if (dt.Rows[n]["DDl_Type"] != null && dt.Rows[n]["DDl_Type"].ToString() != "")
                    {
                        model.DDl_Type = dt.Rows[n]["DDl_Type"].ToString();
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

    }
}

