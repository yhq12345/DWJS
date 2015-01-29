using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Config = Eastcom.ConfigUntility;
using System.Data;
using System.Text;

namespace DWKS.StartExam
{
    public partial class StartExam : PageBase
    {
        public string id = "";
        public string FK_YDKHNR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.InitRight();
            this.id = Request.QueryString["id"] ?? "";
            this.FK_YDKHNR = Request.QueryString["FK_YDKHNR"] ?? "";
            this.PageType = EnumPageType.修改;
            if (IsAjax)
            {
                this.AjaxMethod();
                return;
            }
            if (!IsPostBack)
            {
                DLL_Bind();
                InitData();
            }
        }
        public void DLL_Bind()
        {
            Config.BaseFunc.SetDDL_Year(ddl_year);
            Config.BaseFunc.SetDDL_Month(ddl_month);

        }
        public void InitRight()
        {

        }
        public void AjaxMethod()
        {
            StringBuilder strMsg = new StringBuilder();
            int isReload = 0;//0:不刷新父页面   1：刷新父页面
            bool IsError = false;
            string HTMLWriter = "";

            switch (this.PageType) //this.PageType
            {

                case EnumPageType.修改:
                    string CheckYear = ddl_year.SelectedValue;
                    string CheckMonth = ddl_month.SelectedValue;

                   

                    DataTable dt = new DataTable();

                    #region
                    // 写遍历
                    List<Eastcom.Model.Sys_User_Info> modelList = new Eastcom.BLL.Sys_User_Info().GetModelList("");

                    foreach (Eastcom.Model.Sys_User_Info m in modelList)
                    {
                        HTMLWriter += GetHTMLValue(CheckYear, CheckMonth, m.UserID.ToString(), m.RealName.ToString());
                    }

                    //Eastcom.Common.MessageBox.ResponseScript(this, "getresult(\"" + HTMLWriter + "\");");
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
                msnLog = HTMLWriter,
                Data = null
            });
        }

        private void InitData()
        {

        }
        public void btn_add_Click(object sender, EventArgs e)
        {
            string CheckYear = ddl_year.SelectedValue;
            string CheckMonth = ddl_month.SelectedValue;

            string HTMLWriter = "";

            DataTable dt = new DataTable();

            #region
            // 写遍历
            List<Eastcom.Model.Sys_User_Info> modelList = new Eastcom.BLL.Sys_User_Info().GetModelList("");

            foreach (Eastcom.Model.Sys_User_Info m in modelList)
            {
                HTMLWriter += GetHTMLValue(CheckYear, CheckMonth, m.UserID.ToString(), m.RealName.ToString());
            }

            Eastcom.Common.MessageBox.ResponseScript(this, "getresult(\"" + HTMLWriter + "\");");
            #endregion
        }

        #region Base基本判断方法
        public string GetHTMLValue(string CheckYear, string CheckMonth, string BeChecked_FK_ID, string User_RealName)
        {
            string returnValue = "";

            string[] GetIsExistCheckedValue = new string[2];

            GetIsExistCheckedValue = IsExistChecked(CheckYear, CheckMonth, BeChecked_FK_ID, User_RealName);

            if (GetIsExistCheckedValue[0] == "error")
            {
                returnValue += "<li class='ColorRed'>" + GetIsExistCheckedValue[1] + "</li>";
            }
            else
            {
                Eastcom.Model.月度考核内容 model = new Eastcom.Model.月度考核内容();

                model.FK_UserID = int.Parse(BeChecked_FK_ID);/*被考核人员的ID*/
                model.月份 = Convert.ToDateTime(CheckYear + "-" + CheckMonth);
                model.得分 = 0;
                model.考务生成时间 = DateTime.Now;
                model.提交情况 = Config.ConfigArgs.提交情况.未提交.ToString();
                
                /*提交月度考核内容 也要生成模板 */
                if (new Eastcom.BLL.月度考核内容().Add_Tran(model) > 0)//添加方法 ZQTS.BLL.MaintianManage_Month_Main_Info()
                {
                    returnValue += "<li class='ColorGreen'>" + GetIsExistCheckedValue[1] + "</li>";
                }
            }
            return returnValue;
        }
        /// <summary>
        /// 是否存在空组的公司
        /// </summary>
        public string[] IsExistChecked(string year, string month, string Fk_userID, string user_Name)
        {
            string[] returnValue = new string[2];
            if (new Eastcom.BLL.月度考核内容().Exists_Checked(year, month, Fk_userID))
            {
                returnValue[0] = "error";
                returnValue[1] = "【" + user_Name + "】" + year + "-" + month + "月的考核模板已存在!";
            }
            else
            {
                returnValue[0] = "add";
                returnValue[1] = "【" + user_Name + "】" + year + "-" + month + "月的考核模板添加成功!";
            }

            return returnValue;
        }
        #endregion


    }
}