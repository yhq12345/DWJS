using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CommonClass.StringHander;

namespace DWKS.ASK
{
    public partial class MyAsk : PageBase
    {
        public string TitleNo = "";
        public string Answer_A = "";
        public string Answer_B = "";
        public string Answer_C = "";
        public string Answer_D = "";
        public string Answer_E = "";

        public string Title_ASK = "";
        public string handleType = "Save";

        public string id = "";
        public string FK_YDKHNR = "";
        public int nextid = 0;
        public int preid = 0;
        public int undoneid = 0;
        public string OtherOption = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.InitRight();
            this.id = Request.Params["id"] ?? "";
            this.handleType = Request.Params["handleType"] ?? "";
            Get考核月份();
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
            Eastcom.BLL.月度考核内容_详细 BLL_model_详细 = new Eastcom.BLL.月度考核内容_详细();
            Eastcom.BLL.月度考核内容 BLL_model_列表 = new Eastcom.BLL.月度考核内容();

            Eastcom.Model.月度考核内容_详细 model_详细 = null;
            Eastcom.Model.月度考核内容 model_列表 = null;

            StringBuilder strMsg = new StringBuilder();
            int isReload = 0;//0:不刷新父页面   1：刷新父页面
            bool IsError = false;

            switch (handleType) //this.PageType
            {
                case "Save":
                    #region 保存
                    model_详细 = BLL_model_详细.GetModelByBH_YD(CommonClass.StringHander.Common.GetInt(FK_YDKHNR), CommonClass.StringHander.Common.GetInt(id));
                    strMsg.Append(this.CommonModel(model_详细));
                    if (strMsg.Length == 0)
                    {
                        if (BLL_model_详细.Update(model_详细))
                        {
                            IsError = false;
                            strMsg.Append("");
                            Get考核月份();
                        }
                        else
                        {
                            IsError = true;
                            strMsg.Append("更新失败");
                        }
                    }
                    else
                    {
                        IsError = false;
                    }
                    #endregion
                    break;
                case "Submit":
                    #region 提交
                    List<Eastcom.Model.月度考核内容_详细> ModelList = new List<Eastcom.Model.月度考核内容_详细>();
                    ModelList = BLL_model_详细.GetModelList("FK_月度考核内容='" + FK_YDKHNR + "'");
                    model_列表 = BLL_model_列表.GetModel(Common.GetInt(FK_YDKHNR));

                    decimal 总得分 = 0;
                    if (undoneid != 0)
                    {
                        IsError = true;
                        strMsg.Append("你还有未完成的题!");
                    }
                    else
                    {
                        foreach (Eastcom.Model.月度考核内容_详细 m in ModelList)
                        {
                            string 用户答案 = m.用户答案 == "" ? ",,," : m.用户答案;
                            Eastcom.Model.考试题库 model_题库 = new Eastcom.Model.考试题库();
                            model_题库 = new Eastcom.BLL.考试题库().GetModel(Common.GetInt(m.题目编号));
                            if (model_题库 != null)
                            {
                                UserPoint c = new UserPoint();
                                c = c.Get用户得分情况(用户答案, model_题库.标准答案.Trim());
                                m.得分 = c.用户得分;
                                m.回答情况 = c.得分情况;
                                BLL_model_详细.Update(m);
                                总得分 += Common.GetDecimal(m.得分);
                            }
                        }
                    }

                    model_列表.得分 = 总得分;
                    model_列表.提交时间 = DateTime.Now;
                    model_列表.提交情况 = Eastcom.ConfigUntility.ConfigArgs.提交情况.已提交.ToString();

                    //strMsg.Append(this.CommonModel(model_详细));
                    if (strMsg.Length == 0)
                    {
                        if (BLL_model_列表.Update(model_列表))
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
                Data = new ExamId() { nextid = nextid.ToString(), preid = preid.ToString(), Undoneid = undoneid.ToString() }
            });

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private string CommonModel(Eastcom.Model.月度考核内容_详细 model)
        {
            StringBuilder str = new StringBuilder();

            string 我的选项_A = Request.Params["ck_answer_A"] ?? "";
            string 我的选项_B = Request.Params["ck_answer_B"] ?? "";
            string 我的选项_C = Request.Params["ck_answer_C"] ?? "";
            string 我的选项_D = Request.Params["ck_answer_D"] ?? "";
            string 我的选项_E = Request.Params["ck_answer_E"] ?? "";


            model.用户答案 = 我的选项_A + "," + 我的选项_B + "," + 我的选项_C + "," + 我的选项_D + "," + 我的选项_E;
            model.回答情况 = "";
            model.得分 = 0;
            model.提交时间 = DateTime.Now;

            return str.ToString();

        }
        /// <summary>
        /// 
        /// </summary>
        public void Get考核月份()
        {
            int FK_User = CurrentUserModel.UserID;
            DateTime 考核月份 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM"));
            Eastcom.Model.月度考核内容 model1 = new Eastcom.BLL.月度考核内容().GetModelByUser(FK_User, 考核月份);

            if (model1 == null)
            {
                throw new Exception("对不起,本月你未生成考题,请联系管理员!");
            }
            else
            {
                if (model1.提交情况 == Eastcom.ConfigUntility.ConfigArgs.提交情况.已提交.ToString())
                {
                    Eastcom.Common.MessageBox.ShowAndJs(this, "您已经提交了不能再次修改答案", "window.location.href='./MyIndex.aspx'");
                    
                }
                FK_YDKHNR = model1.id.ToString();
            }
            Eastcom.Model.月度考核内容_详细 model_3 = new Eastcom.BLL.月度考核内容_详细().GetUndoneId(CommonClass.StringHander.Common.GetInt(this.FK_YDKHNR));

            if (model_3 == null)
                undoneid = 0;
            else
                undoneid = Common.GetInt(model_3.考核题目编号);
        }
        /// <summary>
        /// 
        /// </summary>
        private void InitData()
        {
            Eastcom.Model.月度考核内容_详细 model2 = new Eastcom.Model.月度考核内容_详细();
            if (FK_YDKHNR != "")
            {
                model2 = new Eastcom.BLL.月度考核内容_详细().GetModelByBH_YD(CommonClass.StringHander.Common.GetInt(FK_YDKHNR), CommonClass.StringHander.Common.GetInt(id, 0));
                if (model2 == null)
                {
                    throw new Exception("对不起,本月你未生成考题或输入错误的题目序号,请刷新!");
                }
                else
                {
                    if (!string.IsNullOrEmpty(model2.用户答案))
                    {
                        string[] 用户答案 = model2.用户答案.Split(',');
                        if (用户答案 != null)
                        {
                            for (int i = 0; i < 用户答案.Length; i++)
                            {
                                switch (用户答案[i])
                                {
                                    case "A": ck_answer_A.Checked = true; break;
                                    case "B": ck_answer_B.Checked = true; break;
                                    case "C": ck_answer_C.Checked = true; break;
                                    case "D": ck_answer_D.Checked = true; break;
                                    case "E": ck_answer_E.Checked = true; break;
                                    default: ; break;
                                }
                            }
                        }
                    }
                }
            }

            string 题目编号 = model2.题目编号.ToString();
            if (题目编号 != "")
            {
                //Eastcom.Model.考试题库 model = new Eastcom.Model.考试题库();
                //model = new Eastcom.BLL.考试题库().GetModel(CommonClass.StringHander.Common.GetInt(题目编号));
                //if (model != null)
                //{
                    TitleNo = id;
                    Answer_A = model2.A选项_原;
                    Answer_B = model2.B选项_原;
                    Answer_C = model2.C选项_原;
                    Answer_D = model2.D选项_原;
                    Answer_E = model2.其他选项_原;

                    if (string.IsNullOrEmpty(Answer_A))
                    {
                        ck_answer_A.Disabled=true;
                    }
                    if (string.IsNullOrEmpty(Answer_B))
                    {
                        ck_answer_B.Disabled = true;
                    }
                    if (string.IsNullOrEmpty(Answer_C))
                    {
                        ck_answer_C.Disabled = true;
                    }
                    if (string.IsNullOrEmpty(Answer_D))
                    {
                        ck_answer_D.Disabled = true;
                    }
                    if (!string.IsNullOrEmpty(Answer_E))
                    {
                        hid_OtherOption.Value = "E";
                    }
                    Title_ASK = model2.题目内容_原;
                //}
            }
            else
            {
                throw new Exception("您这个月未生成考题.");
            }
            SetBindBtn();
        }
        /// <summary>
        /// 
        /// </summary>
        private void SetBindBtn()
        {
            nextid = CommonClass.StringHander.Common.GetInt(id, 0) + 1;
            preid = CommonClass.StringHander.Common.GetInt(id, 0) - 1;

            next_btn.Attributes.Add("onclick", "funs.Save_Next($('#next_btn'));");
            pre_btn.Attributes.Add("onclick", "funs.Save_Pre($('#pre_btn')); ");


            switch (id)
            {
                case "1": pre_btn.Disabled = true; break;
                case "20": next_btn.Disabled = true; break;
            }
        }



    }
}