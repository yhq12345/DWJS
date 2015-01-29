using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using CommonClass.StringHander;
namespace InterNetComplaint.handle
{
    /// <summary>
    /// validate 的摘要说明
    /// </summary>
    public class validate : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
                if (context.Request.Params["Action"] == "Login")
                    ValidateLogin();

            }
            catch (Exception err)
            {
                context.Response.Write("true");
            }
        }
        void ValidateLogin()
        {
            var context = System.Web.HttpContext.Current;
            bool returnvalue=false;
            string username = context.Request.Params["txt_username"];
            string password = context.Request.Params["txt_password"];
            //判断是否是 登陆成功

            password = Eastcom.Common.DeseEncode.DESEncryptMethod(password);
            Eastcom.Model.v_Sys_User_Info model = new Eastcom.BLL.Sys_User_Info().GetModel(username, password);

            if (model != null)  //登陆成功
            {
                //User_Manage.BLL.SessionConfig.SetUserInfo(model);
                //System.Web.HttpContext.Current.Session.Timeout = 60;

                if (Common.SetCookies(PageBase.CookieName, model.UserID.ToString(), 30))
                {
                    //success = 1;
                    CommonClass.Cache.CacheClass.Clear(string.Format("RightCacheName_{0}", model.UserID.ToString()));
                    returnvalue = true;

                }

                //returnvalue=true;
                //if (Common.SetCookies(BasePage.BasePage.CookieName, model.UserID.ToString(), 30))
                //{
                //    success = 1;
                //}
            }
            context.Response.Write(returnvalue ? "true" : "false");
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