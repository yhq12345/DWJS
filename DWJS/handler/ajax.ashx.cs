using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using CommonClass.StringHander;

namespace InterNetComplaint.handler
{
    /// <summary>
    /// ajax 的摘要说明
    /// </summary>
    public class ajax : IHttpHandler, IRequiresSessionState
    {
        private HttpContext context;
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
            string GetLoginPasswordName = this.LoginPasswordName;
            string GetOldPasswordName = this.OldPasswordName;

            Eastcom.Model.v_Sys_User_Info model = Eastcom.BLL.SessionConfig.GetUserInfo();
            Eastcom.Model.Sys_User_Info UserModel = new Eastcom.BLL.Sys_User_Info().GetModel(model.UserID);


            string returnValue = "";
            if (GetMethod == "GetMyFavorite")
            {
                return;
            }
            if (GetMethod == "ChangePassword")
            {

                if (model == null)
                {
                    returnValue = @"{""Data"":"""",""Message"":""操作超时"",""IsError"":true}";
                }
                else
                {
                    if (Eastcom.Common.DeseEncode.DESEncryptMethod(GetOldPasswordName) != UserModel.Pwd)
                    {
                        returnValue = @"{""Data"":"""",""Message"":""密码错误"",""IsError"":true}";
                    }
                    else
                    {
                        UserModel.Pwd = Eastcom.Common.DeseEncode.DESEncryptMethod(GetLoginPasswordName);
                        if (new Eastcom.BLL.Sys_User_Info().Update(UserModel))
                        {
                            returnValue = @"{""Data"":"""",""Message"":""密码修改成功""}";
                        }
                        else
                        {
                            returnValue = @"{""Data"":"""",""Message"":""密码修改失败"",""IsError"":true}";
                        }
                    }
                }
                context.Response.Write(returnValue);
                context.ApplicationInstance.CompleteRequest();
                return;
            }
            /*受理*/
            if (GetMethod == "Accept")//受理操作
            {
                //if (UserModel == null)
                //{
                //    returnValue = @"{""Data"":"""",""Message"":""操作超时"",""IsError"":true}";
                //}
                //else
                //{
                //    if (TypeName == "Public") //Public
                //    {
                //        BTSMng.Model.Public_Complaint_Info Model = new Model.Public_Complaint_Info();
                //        Model = new BLL.Public_Complaint_Info().GetModel(CommonClass.StringHander.Common.GetInt(GetID));

                //        Model.预处理受理人 = UserModel.RealName;
                //        Model.预处理受理时间 = DateTime.Now;


                //        if (new BLL.Public_Complaint_Info().Update(Model))
                //            returnValue = string.Format(@"{{""Data"":{{""userName"":""{0}"",""OperDataTime"":""{1}""}},""Message"":""受理成功"",""IsError"":false}}", UserModel.RealName, Model.预处理受理时间.ToString());
                //        else
                //            returnValue = @"{""Data"":"""",""Message"":""受理失败"",""IsError"":true}";
                //    }
                //    else if (TypeName == "InSite") //Public
                //    {
                //        BTSMng.Model.InSite_Complaint_Info Model = new Model.InSite_Complaint_Info();                      
                //        Model = new BLL.InSite_Complaint_Info().GetModelBy_FK(Common.GetInt(this.GetID), false);
                //        // Model = new BLL.InSite_Complaint_Info().GetModel(CommonClass.StringHander.Common.GetInt(GetID));
                //        //InterNetComplaint.Model.InSite_Complaint_Info model = new Model.InSite_Complaint_Info();
                //        //model = bll.GetModelBy_FK(Common.GetInt(this.id), false);//Fk_Id

                //        Model.现场处理受理人 = UserModel.RealName;
                //        Model.现场处理受理时间 = DateTime.Now;

                //        if (new BLL.InSite_Complaint_Info().Update(Model))
                //            returnValue = string.Format(@"{{""Data"":{{""userName"":""{0}"",""OperDataTime"":""{1}""}},""Message"":""受理成功"",""IsError"":false}}", UserModel.RealName, Model.现场处理受理时间.ToString());
                //        else
                //            returnValue = @"{""Data"":"""",""Message"":""受理失败"",""IsError"":true}";
                //    }
                //    else if (TypeName == "Optimization") //Public
                //    {
                //        InterNetComplaint.Model.Optimization_Info Model = new Model.Optimization_Info();
                //        //Model = new BLL.Optimization_Info().GetModel(CommonClass.StringHander.Common.GetInt(GetID));
                //        Model = new BLL.Optimization_Info().GetModelBy_FK(Common.GetInt(this.GetID), false);

                //        Model.优化处理受理人 = UserModel.RealName;
                //        Model.优化处理受理时间 = DateTime.Now;

                //        if (new BLL.Optimization_Info().Update(Model))
                //            returnValue = string.Format(@"{{""Data"":{{""userName"":""{0}"",""OperDataTime"":""{1}""}},""Message"":""受理成功"",""IsError"":false}}", UserModel.RealName, Model.优化处理受理人.ToString());
                //        else
                //            returnValue = @"{""Data"":"""",""Message"":""受理失败"",""IsError"":true}";
                //    }
                //    else
                //        returnValue = @"{""Data"":"""",""Message"":""受理失败"",""IsError"":true}";
                //}
                

                context.Response.Write(returnValue);
                context.ApplicationInstance.CompleteRequest();
                return;
            }
        }

        /// <summary>
        /// 类名
        /// </summary>
        protected string TypeName
        {
            get { return this.context.Request["type"] ?? ""; }
        }
        /// <summary>
        /// 方法名
        /// </summary>
        protected string MethodName
        {
            get { return this.context.Request["method"] ?? ""; }
        }
        /// </summary>
        protected string LoginPasswordName
        {
            get { return this.context.Request["LoginPassword"] ?? ""; }
        }
        /// </summary>
        protected string OldPasswordName
        {
            get { return this.context.Request["OldPassword"] ?? ""; }
        }
        protected string GetID
        {
            get { return this.context.Request["id"] ?? ""; }
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