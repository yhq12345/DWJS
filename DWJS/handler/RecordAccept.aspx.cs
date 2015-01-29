using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterNetComplaint.handler
{
    public partial class RecordAccept : PageBase
    {
        private HttpContext context;
        /// <summary>
        /// 类名
        /// </summary>
        protected string TypeName
        {
            get { return this.context.Request["type"]??""; }
        }
        /// <summary>
        /// 方法名
        /// </summary>
        protected string MethodName
        {
            get { return this.context.Request["method"]??""; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //ProcessRequest(context);
        }
        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "text/plain";
            this.context = context;
            try
            {
                Run(context);
            }
            catch
            {

            }
        }
        void Run(HttpContext context)
        {
            string GetType = this.TypeName;
            string GetMethod = this.MethodName;

            Eastcom.Model.v_Sys_User_Info model = Eastcom.BLL.SessionConfig.GetUserInfo();
            Eastcom.Model.Sys_User_Info UserModel = new Eastcom.BLL.Sys_User_Info().GetModel(model.UserID);
            
            if (model == null)
            {
                throw new Exception("操作超时");

            }
            
            string returnValue = "";

            /*受理*/
            if (GetMethod == "Accept")//受理操作
            {
                if (UserModel == null)
                {
                    returnValue = @"{""Data"":"""",""Message"":""操作超时"",""IsError"":true}";
                }
                else
                {

                }
              
                returnValue = @"{""Data"":"""",""Message"":""密码修改失败"",""IsError"":true}";
             
                context.Response.Write(returnValue);
                context.ApplicationInstance.CompleteRequest();
                return;
            }
        }
    }
}