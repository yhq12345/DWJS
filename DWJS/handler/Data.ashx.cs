using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTSmanagementInfo.handler
{
    /// <summary>
    /// Data 的摘要说明
    /// </summary>
    public class Data : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string Rtstr = string.Empty;//ajax输出字段
            switch (context.Request["fac"])
            {

                case "getMajorList"://获取合同列表
                    Rtstr = getMajorList();
                    break;
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write(Rtstr);
        }
        private string getMajorList()
        {
            System.Text.StringBuilder sb_str = new System.Text.StringBuilder();
            #region
            #endregion

           //sb_str.Append(new BTSMng.BLL.ALARMSM_Person().getQueryTableString());

            return sb_str.ToString();
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}