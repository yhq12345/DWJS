using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using LitJson;

namespace CommonClass.Message.Error
{
    /// <summary>
    /// 异常处理
    /// </summary>
    public class ErrorHttpModule:IHttpModule
    {
        private HttpApplication app = null;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            context.Error += new EventHandler(Application_Error);
            this.app = context;
        }

        /// <summary>
        /// 错误
        /// </summary>
        private void Application_Error(object sender, EventArgs e)
        {
            HttpContext con = HttpContext.Current;
            string msg = string.Format("错误页：{0}\r\n来源URL：{1}\r\n", con.Request.Url, con.Request.UrlReferrer);
            Exception exp = con.Error.GetBaseException();

            //1：使用Log4Net来记录错误信息
            if ((Log.LogType & Log.LogTypeEnum.Log4Net) == Log.LogTypeEnum.Log4Net)
            {
                Log.LogInfo.Error(msg, exp);
            }
            //2：以json方式输出错误信息
            if ((Log.LogType & Log.LogTypeEnum.Json) == Log.LogTypeEnum.Json)
            {
                MessageModel errModel = new MessageModel();
                errModel.Title = "系统提示";
                errModel.Date = DateTime.Now;
                errModel.Message = exp.Message;
                errModel.Url = Convert.ToString(con.Request.Url);
                errModel.FromUrl = Convert.ToString(con.Request.UrlReferrer);
                errModel.IsSuccess = false;
                errModel.Remark = "所捕捉的Exception异常信息";

                if (!Log.IsSimple)
                {
                    errModel.MessageMore = exp.StackTrace;
                }

                con.Server.ClearError();
                Log.WriteMessage(errModel);
            }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            if (null != this.app)
            {
                this.app.Error -= new EventHandler(Application_Error);
                this.app = null;
            }
        }
    }
}
