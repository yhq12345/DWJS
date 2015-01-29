using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Config = Eastcom.ConfigUntility;
using System.Text;

namespace DWKS.Admin_mobile
{
    public partial class AdminIndex : PageBase
    {
        public string Current_User = "";
        public string Current_Year_Month = "";
        public string FK_YDKHNR = "";
        public string IsnullHint = "";
        public string handleType = "";
        public string IsSubmit = "";


        
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission = false;
            this.InitRight();
            this.handleType = Request.Params["handleType"] ?? "";
            Current_User = CurrentUserModel.RealName;
            Current_Year_Month = DateTime.Now.ToString("yyyy-MM");
            if (IsAjax)
            {
                this.AjaxMethod();
                return;
            }
            if (!IsPostBack)
            {
                DDl_Bind();
                InitData();
            }

        }
        protected void InitRight()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        public void DDl_Bind()
        {
            Config.BaseFunc.SetDDL_Year_Month(ddl_Year_Month);
           // Config.BaseFunc.SetDDL_Year_Month(ddl_Year_Month2);
        }
        public void AjaxMethod()
        {
            Eastcom.BLL.月度考核内容 BLL_model_列表 = new Eastcom.BLL.月度考核内容();
            Eastcom.Model.月度考核内容 model_列表 = null;

            StringBuilder strMsg = new StringBuilder();
            int isReload = 0;//0:不刷新父页面   1：刷新父页面
            bool IsError = false;

            switch (handleType) //this.PageType
            {
                case "See":
                    #region 查看

                    //model_详细 = BLL_model_详细.GetModelByBH_YD(CommonClass.StringHander.Common.GetInt(FK_YDKHNR), CommonClass.StringHander.Common.GetInt(id));
                    model_列表 = BLL_model_列表.GetModelByUser(CurrentUserModel.UserID, CommonClass.StringHander.Common.GetDateTime(Request.Params["ddl_Year_Month"] ?? ""));
                    if (model_列表 == null)
                    {
                        IsError = true;
                        strMsg.Append(Request.Params["ddl_Year_Month"] + ",您没有考核模板");
                    }
                    //strMsg.Append(this.CommonModel(model_详细));
                    if (strMsg.Length == 0)
                    {
                        strMsg.Append(Request.Params["ddl_Year_Month"]);
                        //if (BLL_model_详细.Update(model_详细))
                        //{
                        //    IsError = false;
                        //    strMsg.Append("");
                        //    Get考核月份();
                        //}
                        //else
                        //{
                        //    IsError = true;
                        //    strMsg.Append("更新失败");
                        //}
                    }

                    #endregion
                    break;
                case "Change":
                    #region 查看
                    model_列表 = BLL_model_列表.GetModelByUser(CurrentUserModel.UserID, CommonClass.StringHander.Common.GetDateTime(Request.Params["ddl_Year_Month"] ?? ""));
                    if (model_列表 == null)
                    {
                        IsError = true;
                        strMsg.Append(Request.Params["ddl_Year_Month"] + ",您没有考核模板");
                    }
                    if (strMsg.Length == 0)
                    {
                        if (model_列表.提交情况 == Config.ConfigArgs.提交情况.已提交.ToString())
                        {
                            strMsg.Append(model_列表.得分);
                        }
                        else
                        {
                            strMsg.Append(model_列表.提交情况);
                        }
                    }
                    else
                    {
                        IsError = false;
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
        private void InitData()
        {
            int FK_User = CurrentUserModel.UserID;
            DateTime 考核月份 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM"));
            Eastcom.Model.月度考核内容 model1 = new Eastcom.BLL.月度考核内容().GetModelByUser(FK_User, 考核月份);
            if (model1 != null)
            {
                if (model1.提交情况 == Config.ConfigArgs.提交情况.已提交.ToString())
                {
                    a_MyAsk.Visible = false;
                    IsSubmit = Config.ConfigArgs.提交情况.已提交.ToString();
                }
                else
                {
                    FK_YDKHNR = model1.id.ToString();
                    a_MyAsk.Visible = true;
                }
            }
            else
            {
                IsnullHint = "您未生成当月考核模板";
            }
        }
    }
}