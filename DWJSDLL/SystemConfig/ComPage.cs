using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonClass.Enum;
using CommonClass.StringHander;

namespace SystemConfig
{
    /// <summary>
    /// 本项目公共操作类
    /// </summary>
    public  class ComPage
    {
        /// <summary>
        /// 返回百分比进度
        /// </summary>
        /// <param name="isSimple"></param>
        /// <param name="percent">小数</param>
        public static string GetProcess(int isSimple,decimal percent)
        {
            string str=string.Empty;
            if(isSimple==(int)SystemConfig.CommonState.IsSimple.简易版)
            {
                str=((int)(percent*100))+"%";
            }
            return str;
        }
        /// <summary>
        ///生成tabs
        /// </summary>
        /// <param name="tabId">ID的前缀</param>
        /// <param name="removeLst">不包含的项</param>
        /// <returns></returns>
        public static string GetTabsTitle(string tabId,string url,string paramName,List<SystemConfig.CommonState.TabsDate> removeLst)
        {
            StringBuilder con = new StringBuilder();
            //绑定tabs标题
            StringBuilder str = new StringBuilder();
            List<EnumObj> lstTabs = EnumObj.GetList(typeof(SystemConfig.CommonState.TabsDate));
            if (null != lstTabs && lstTabs.Count > 0)
            {
                for(int i=0;i<lstTabs.Count;i++)
                {
                    if (null!=removeLst&&removeLst.Count>0&&removeLst.Contains((SystemConfig.CommonState.TabsDate)Common.GetInt(lstTabs[i].Value)))
                    {
                        continue;
                    }
                    str.AppendFormat("<li rel='{2}'><a href='{0}' rel='{2}'>{1}</a></li>", url.Length == 0 ? ("#" + tabId + (i + 1)) : UrlOper.AddParam(url, paramName, lstTabs[i].Value), lstTabs[i].Text, lstTabs[i].Value);
                    con.AppendFormat("<div id='{0}{1}' rel='{2}'></div>", tabId, i + 1,lstTabs[i].Value);
                }
            }
            return "<ul>"+str.ToString()+"</ul>"+con.ToString();
        }
    }
}
