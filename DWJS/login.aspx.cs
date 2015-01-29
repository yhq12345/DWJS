using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Config = Eastcom.ConfigUntility;
using Model = Eastcom.Model;
using BLL = Eastcom.BLL;
using System.Text;


namespace Web
{
    public partial class login : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            CheckPermission = false;
            this.PageType = EnumPageType.其它;/*查询*/
            if (IsAjax)
            {
                this.AjaxMethod();
                return;
            }
            if (!IsPostBack)
            {
                BLL.SessionConfig.ClearUserInfo();
            }
        }
        private void AjaxMethod()
        {
            StringBuilder strMsg = new StringBuilder();//WarnMsg
            StringBuilder strMsgLog = new StringBuilder();//LogMsg

            int isReload = 0;//0:不刷新父页面   1：刷新父页面
            bool IsError = false;

            string str="";
            switch (this.PageType)
            {
                #region 查询
                case EnumPageType.其它:
                    IsError = !Logining(ref  str);
                    bool ISCanOp = false;
                    /*权限的控制*/
                    //if (CheckRight("手机端使用权限", "手机端登录"))

                    {
                        ISCanOp = true;
                    }
                    if (IsError)
                    {
                        strMsg.Append(str==""?"登录失败!":str);
                    }
                    break;
                #endregion
                default:
                    strMsg.Append("页面操作类型不明确，操作失败！");
                    break;
            }
            CommonClass.Message.Log.WriteMessage(new Eastcom.Model.GoAjaxPara()
            {
                msg = strMsg.ToString(),
                isReload = isReload,
                isError = IsError,
                msnLog = strMsgLog.ToString(),
                Data = null
            });
        }
        protected void img_login_Click(object sender, EventArgs e)
        {


        }
        protected bool Logining(ref string _strMsg)
        {
            string userName = Request.Params["txt_userName"] ?? ""; //txt_userName.Value;
            string Password = Request.Params["txt_pwd"] ?? "";
            //登陆系统
            Password = Eastcom.Common.DeseEncode.DESEncryptMethod(Password);
            Model.v_Sys_User_Info model = new BLL.Sys_User_Info().GetModel(userName, Password);

            if (!new BLL.Sys_User_Info().IsExistUserName(userName))
            {
                _strMsg = "无此账号！";
                return false;
            }


            if (model != null)  //登陆成功
            {
                BLL.SessionConfig.SetUserInfo(model);
                base.BaseInitData();

                //XCLNetTools.Message.Log.WriteMessage(Respons);
                //Response.Redirect("index.htm",);
                //Eastcom.Common.MessageBox.ResponseScript(this, "window.location.href='./RedisData/RedisData_Query.aspx'");
                return true;
            }
            else               //登陆失败    
            {
                return false;
                //Eastcom.Common.MessageBox.Show(this, "登录失败");
            }

        }



    }
}
