using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DWKS.CodeTest
{
    public partial class KTZH : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void btn_Save_Click(object sender, EventArgs e)
        {
            List<Eastcom.Model.考试题库> modlelist = new List<Eastcom.Model.考试题库>();
            modlelist = new Eastcom.BLL.考试题库().GetModelList("");

            foreach (Eastcom.Model.考试题库 m in modlelist)
            {
                string 标准答案 = "";
                标准答案 = m.标准答案2.ToUpper();
                标准答案 = 标准答案.Replace("A", "A,");
                标准答案 = 标准答案.Replace("B", "B,");
                标准答案 = 标准答案.Replace("C", "C,");
                标准答案 = 标准答案.Replace("D", "D,");
                标准答案 = 标准答案.Replace("E", "E,");

                m.标准答案 = 标准答案;
                new Eastcom.BLL.考试题库().Update(m);
            }




        }
    }
}