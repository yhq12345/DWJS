using System;
using System.Data;
using System.Collections.Generic;
using Eastcom.Common;
using Eastcom.Model;
namespace Eastcom.BLL
{
    /// <summary>
    /// 系统表--字典库表
    /// </summary>
    public partial class Sys_Common_Dic
    {
        private readonly Eastcom.DAL.Sys_Common_Dic dal = new Eastcom.DAL.Sys_Common_Dic();
        public Sys_Common_Dic()
        { }
        #region  BasicMethod
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
        public int Add(Eastcom.Model.Sys_Common_Dic model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Eastcom.Model.Sys_Common_Dic model)
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
        public Eastcom.Model.Sys_Common_Dic GetModel(int DicID)
        {

            return dal.GetModel(DicID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Eastcom.Model.Sys_Common_Dic GetModelByCache(int DicID)
        {

            string CacheKey = "Sys_Common_DicModel-" + DicID;
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
            return (Eastcom.Model.Sys_Common_Dic)objModel;
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
        public List<Eastcom.Model.Sys_Common_Dic> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Eastcom.Model.Sys_Common_Dic> DataTableToList(DataTable dt)
        {
            return dal.DataTableToList(dt);
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
        /// 根据字典名和父类id返回model
        /// </summary>
        /// <param name="dicName">字典名</param>
        /// <param name="parentID">父类ID</param>
        public Eastcom.Model.Sys_Common_Dic GetModel(string dicName, int parentID)
        {
            Eastcom.Model.Sys_Common_Dic model = null;
            List<Eastcom.Model.Sys_Common_Dic> lst = this.GetModelList(string.Format("dicName='{0}' and parentID={1}", dicName, parentID));
            if (null != lst && lst.Count > 0)
            {
                model = lst[0];
            }
            return model;
        }
        /// <summary>
        /// 根据父类ID，返回list
        /// </summary>
        public List<Model.Sys_Common_Dic> GetModelListByParentID(int parentID)
        {
            return this.GetModelList(string.Format("ParentID={0}", parentID));
        }

        #region 根据指定model，返回它下面的所有子孙list
        /// <summary>
        /// 根据字典ID，返回该字典的所有子孙类list（不包含此字典本身）,递归
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="lst">存放最终获得的List</param>
        public List<Eastcom.Model.Sys_Common_Dic> GetDicChildList(int id, List<Eastcom.Model.Sys_Common_Dic> lst)
        {
            if (null == lst)
            {
                lst = new List<Model.Sys_Common_Dic>();
            }
            List<Eastcom.Model.Sys_Common_Dic> lstNew = this.GetModelListByParentID(id);
            if (null != lstNew && lstNew.Count > 0)
            {
                lst.AddRange(lstNew);
                for (int i = 0; i < lstNew.Count; i++)
                {
                    this.GetDicChildList(lstNew[i].DicID, lst);
                }
            }
            return lst;
        }

        /// <summary>
        /// 根据字典名和父ID，返回该字典的所有子孙类list（不包含此字典本身）
        /// </summary>
        public List<Eastcom.Model.Sys_Common_Dic> GetDicChildList(string dicName, int parentID)
        {
            List<Eastcom.Model.Sys_Common_Dic> lst = null;
            Eastcom.Model.Sys_Common_Dic model = this.GetModel(dicName, parentID);
            if (null != model)
            {
                lst = this.GetDicChildList(model.DicID, null);
            }
            return lst;
        }
        #endregion

        #region 菜单相关
        /// <summary>
        /// 返回菜单
        /// </summary>
        public List<Model.Sys_Common_Dic> GetMenuModelList()
        {
            return this.GetDicChildList("菜单", 0);
        }
        #endregion

        /// <summary>
        /// 检查该字典是否已经存在
        /// </summary>
        /// <param name="parentID">父类ID，一般为0</param>
        /// <param name="dicName">字典名</param>
        /// <returns></returns>
        public bool ExistDicName(int parentID, string dicName)
        {
            bool flag = false;
            List<Eastcom.Model.Sys_Common_Dic> lst = this.GetModelList(string.Format("ParentID={0} and dicName='{1}'", parentID, dicName));
            if (null != lst && lst.Count > 0)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 返回指定父类名和指定字典名记录下的所有子类list
        /// </summary>
        /// <param name="parentName">parentId=0</param>
        public List<Model.Sys_Common_Dic> GetModelList(string parentName, string childName)
        {
            List<Model.Sys_Common_Dic> lst = null;
            Model.Sys_Common_Dic model = this.GetModel(parentName, 0);
            if (null != model)
            {
                Model.Sys_Common_Dic newModel = this.GetModel(childName, model.DicID);
                if (null != newModel)
                {
                    lst = this.GetModelListByParentID(newModel.DicID);
                }
            }
            return lst;
        }

        /// <summary>
        /// 根据父、子、孙的名称（三层），返回孙的model
        /// </summary>
        /// <param name="parentName">父类名</param>
        /// <param name="childName">子类名</param>
        /// <param name="grandsonName">孙类名</param>
        /// <returns></returns>
        public Model.Sys_Common_Dic GetModel(string parentName, string childName, string grandsonName)
        {
            return dal.GetModel(parentName, childName, grandsonName);
        }

        /// <summary>
        /// 根据父、子、孙的名称（三层），返回孙的model的ID(若不存在，则返回-1)
        /// </summary>
        public int GetModelID(string parentName, string childName, string grandsonName)
        {
            int id = -1;
            Model.Sys_Common_Dic model = this.GetModel(parentName, childName, grandsonName);
            if (null != model)
            {
                id = model.DicID;
            }
            return id;
        }

        public List<Model.Sys_Common_Dic> GetModelListByParentName(string parentName)
        {
            return dal.GetModelListByParentName(parentName);
         }



        public bool 是否在移动隐患库内(string _HiddenDangerType)
        {
            List<Eastcom.Model.Sys_Common_Dic> dicList = new BLL.Sys_Common_Dic().GetModelListByParentName("隐患类型");
           bool returnValue=false;
            if(dicList!=null)
           {
               foreach (Eastcom.Model.Sys_Common_Dic x in dicList)
               {
                   if (x.DicValue == _HiddenDangerType)
                   {
                       returnValue = true;
                       break;
                   }
               }
           }
            return returnValue;
        }
        #endregion  ExtensionMethod
    }
}

