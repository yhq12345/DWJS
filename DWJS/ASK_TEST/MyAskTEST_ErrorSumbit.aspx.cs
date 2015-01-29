using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace DWKS.ASK_TEST
{
    public partial class MyAskTEST_ErrorSumbit : PageBase
    {
        public string Submiter = "";
        public string SubmitTime = "";
        public string handleType = "";
        public string FK_ID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.handleType = Request.Params["handleType"] ?? "";
            this.FK_ID = Request.Params["FK_ID"] ?? "";
            if(CurrentUserModel!=null)
            {
                Submiter = CurrentUserModel.RealName;
                SubmitTime = DateTime.Now.ToString();
            }
            if (IsAjax)
            {
                this.AjaxMethod();
                return;
            }
            if (!IsPostBack)
            {
                InitData();
            }
        }
        public void InitRight()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public void AjaxMethod()
        {
            Eastcom.BLL.错题提交信息 BLL_model = new Eastcom.BLL.错题提交信息();

            Eastcom.Model.错题提交信息 model = null;

            StringBuilder strMsg = new StringBuilder();
            int isReload = 0;//0:不刷新父页面   1：刷新父页面
            bool IsError = false;

            switch (handleType) //this.PageType
            {
                case "Submit":
                    #region 提交
                    model = new Eastcom.Model.错题提交信息();
                    strMsg.Append(this.CommonModel(model));
                    if (strMsg.Length == 0)
                    {
                        if (BLL_model.Add(model)>0)
                        {
                            IsError = false;
                            strMsg.Append("提交成功");
                        }
                        else
                        {
                            IsError = true;
                            strMsg.Append("更新失败");
                        }
                    }
                    else
                    {
                        IsError = true;
                    }
                    #endregion
                    break;
                default:
                    strMsg.Append("页面操作类型不明确，操作失败！");
                    break;
            }

            CommonClass.Message.Log.WriteMessage(new CommonClass.Message.GoAjaxPara()
            {
                msg = strMsg.ToString(),
                isReload = isReload,
                isError = IsError,
                msnLog = "",
                Data = null
            });

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private string CommonModel(Eastcom.Model.错题提交信息 model)
        {
            StringBuilder str = new StringBuilder();

            model.FK_考试题库 = FK_ID;
            model.错误提交信息 = Request.Params["area_Err"].Trim();
            model.提交人 = Submiter;
            model.提交时间 =  CommonClass.StringHander.Common.GetDateTime(SubmitTime);

            Eastcom.Model.考试题库 考题= new Eastcom.Model.考试题库();
            考题= new Eastcom.BLL.考试题库().GetModel(CommonClass.StringHander.Common.GetInt(FK_ID));

            if(考题!=null)
            {
                model.题目信息= 考题.题目内容;
                model.答案信息 = 考题.标准答案;
            }
            return str.ToString();

        }
        /// <summary>
        /// 
        /// </summary>
        private void InitData()
        {
           
        }
      
    }
}

