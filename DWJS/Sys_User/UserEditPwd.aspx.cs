using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace DWKS.Sys_User
{
    public partial class UserEditPwd :PageBase
    {
        public string Current_UserName = "";
        public string Current_UserID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.InitRight();

            Current_UserName = CurrentUserModel.RealName;
            Current_UserID = CurrentUserModel.UserName;
            this.PageType = EnumPageType.修改;

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
        }
        public void AjaxMethod()
        {
            Eastcom.BLL.Sys_User_Info BLL_model_列表 = new Eastcom.BLL.Sys_User_Info();
            Eastcom.Model.Sys_User_Info model_列表 = null;

            StringBuilder strMsg = new StringBuilder();
            int isReload = 0;//0:不刷新父页面   1：刷新父页面
            bool IsError = false;

            switch (this.PageType) //this.PageType
            {
                case EnumPageType.修改:
                    #region 查看
                    model_列表 = BLL_model_列表.GetModel(CommonClass.StringHander.Common.GetInt(CurrentUserModel.UserID));
                    model_列表.Pwd = Eastcom.Common.DeseEncode.DESEncryptMethod(txt_password.Text);

                    if (BLL_model_列表.Update(model_列表))
                    {
                        IsError = false;
                        strMsg.Append("修改成功！");
                       
                    }
                    else
                    {
                        IsError = true;
                        strMsg.Append(strMsg);
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
            
        }



    }
}