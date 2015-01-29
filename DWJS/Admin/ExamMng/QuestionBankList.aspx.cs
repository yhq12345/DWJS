using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace DWKS.Admin.ExamMng
{
    public partial class QuestionBankList :  PageBase
    {
        #region 列表查询参数
        protected string strWhere = "";
        protected string ExcelTableName = "题库_统一Excel导出";
        public string fileName = "题库_统一Excel导出";
        public string fieldName = "  题目内容,A选项,B选项,C选项,D选项,其他选项,标准答案";

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission = false;

            if (IsAjax)
            {
                this.AjaxMethod();
                return;
            }
            this.DDl_Bind();
            this.InitData();
        }
        /// <summary>
        /// 数据初始化
        /// </summary>
        private void InitData()
        {
            #region 搜索条件初始化
            IniSearch();

            #endregion
            #region 数据绑定及分页
            //绑定数据列表
            DataTable dt = null;
            /*
          
             */
            //if (JKZL_TYPE == "FTTB未配置到ONU")
            //{
            Eastcom.BLL.v_月度考核内容 bll = new Eastcom.BLL.v_月度考核内容();
            dt = bll.GetPageList(this.PageSize, this.PageIndex, ref this.RecordCount, strWhere, fieldName, "[ID]", "[ID] Desc");
            //}
            Session[StrWhereOutPutSessionName] = strWhere;
            this.InitPager(this.pager);
            CommonClass.Control.Control.DataGridDataBind(this.Dg_Record, dt, true);
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        public void DDl_Bind()
        {
            //Config.BaseFunc.SetDDL_Year_Month(ddl_Year_Month);
            //Config.BaseFunc.SetDDL_提交情况(ddl_TJQK);
        }
        /// <summary>
        /// 
        /// </summary>
        private void IniSearch()
        {
            strWhere = "  1=1 ";

            //if (ddl_Year_Month.SelectedIndex != 0)
            //{
            //    strWhere += "and 月份='" + ddl_Year_Month.SelectedValue + "'";
            //}
            //if (ddl_TJQK.SelectedIndex != 0)
            //{
            //    strWhere += "and 提交情况='" + ddl_TJQK.SelectedValue + "'";
            //}
        }
        /// <summary>
        /// ajax方法
        /// </summary>
        protected void AjaxMethod()
        {
            //Eastcom.BLL.家客增量用户资料核查统计 bll = new Eastcom.BLL.家客增量用户资料核查统计();
            StringBuilder strMsg = new StringBuilder();
            int isReload = 0;//0:不刷新父页面  1：刷新父页面
            switch (this.PageType)
            {
                case EnumPageType.导出:
                    #region 导出
                    if (!string.IsNullOrEmpty(Convert.ToString(Session[StrWhereOutPut])))
                    {

                        Eastcom.BLL.月度考核内容 bll = new Eastcom.BLL.月度考核内容();
                        DataSet ds = bll.GetOutPutViewList(Convert.ToString(Session[StrWhereOutPut]) ?? "", fieldName, "");
                        string TableName = "v_月度考核内容";
                        CommonClass.DataHandler.DataToExcel.OutPutExcel(new string[] { ExcelTableName }, PageBase.OutPutClassLst, ds, TableName, new string[] { TableName });
                    }
                    else
                    {
                        CommonClass.StringHander.Common.ResponseClearWrite("操作失败，请刷新页面后再导出！");
                    }
                    #endregion
                    break;
                default:
                    strMsg.Append("页面操作类型不明确，操作失败！");
                    break;
            }
            Response.Clear();
            Response.Write(string.Format(@"{{""msg"":""{0}"",""isReload"":""{1}""}}", strMsg, isReload));
            Response.End();
        }

        public void btn_query_Click(object sender, EventArgs e)
        {
            InitData();
        }
        public void btn_export_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Convert.ToString(Session[StrWhereOutPutSessionName])))
            {

                DataSet ds = new Eastcom.BLL.v_月度考核内容().GetOutPutViewList(Convert.ToString(Session[StrWhereOutPutSessionName]) ?? "", fieldName, "[ID] desc");

                CommonClass.DataHandler.DataToExcel.OutPutExcel(null, null, ds, "考试答题情况_统一Excel导出", new string[] { "考试答题情况_统一Excel导出" });

            }
            else
            {
                CommonClass.StringHander.Common.ResponseClearWrite("操作失败，请刷新页面后再导出！");
            }

        }

    }
}