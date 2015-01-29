using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;

namespace DWKS_Auto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime Now = DateTime.Now;
            string CheckYear = Now.Year.ToString();
            string CheckMonth = Now.Month.ToString();
            /*每月1号执行*/
            if (Now.Day == 1)
            {
                List<Eastcom.Model.Sys_User_Info> modelList = new Eastcom.BLL.Sys_User_Info().GetModelList("");

                foreach (Eastcom.Model.Sys_User_Info m in modelList)
                {
                  new DWKS.StartExam.StartExam().GetHTMLValue(CheckYear, CheckMonth, m.UserID.ToString(), m.RealName.ToString());
                }
            }

            Application.Exit();

        }


        public bool IsSubmit()
        {
            return false;
            //List<Eastcom.Model.月度考核内容_详细> ModelList = new List<Eastcom.Model.月度考核内容_详细>();
            //ModelList = BLL_model_详细.GetModelList("FK_月度考核内容='" + FK_YDKHNR + "'");
            //model_列表 = BLL_model_列表.GetModel(Common.GetInt(FK_YDKHNR));

            //decimal 总得分 = 0;
            //if (undoneid != 0)
            //{
            //    IsError = true;
            //    strMsg.Append("你还有未完成的题!");
            //}
            //else
            //{
            //    foreach (Eastcom.Model.月度考核内容_详细 m in ModelList)
            //    {
            //        string 用户答案 = m.用户答案 == "" ? ",,," : m.用户答案;
            //        Eastcom.Model.考试题库 model_题库 = new Eastcom.Model.考试题库();
            //        model_题库 = new Eastcom.BLL.考试题库().GetModel(Common.GetInt(m.题目编号));
            //        if (model_题库 != null)
            //        {
            //            UserPoint c = new UserPoint();
            //            c = c.Get用户得分情况(用户答案, model_题库.标准答案.Trim());
            //            m.得分 = c.用户得分;
            //            m.回答情况 = c.得分情况;
            //            BLL_model_详细.Update(m);
            //            总得分 += Common.GetDecimal(m.得分);
            //        }
            //    }
            //}

            //model_列表.得分 = 总得分;
            //model_列表.提交时间 = DateTime.Now;
            //model_列表.提交情况 = Eastcom.ConfigUntility.ConfigArgs.提交情况.已提交.ToString();

            ////strMsg.Append(this.CommonModel(model_详细));
            //if (strMsg.Length == 0)
            //{
            //    if (BLL_model_列表.Update(model_列表))
            //    {
            //        IsError = false;
            //        strMsg.Append("提交成功");
            //    }
            //    else
            //    {
            //        IsError = true;
            //        strMsg.Append("更新失败");
            //    }
            //}
            //else
            //{
            //    IsError = true;
            //}
        }
    }
}
