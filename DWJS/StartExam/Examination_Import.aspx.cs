using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DWKS.StartExam
{
    public partial class Examination_Import : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Upload1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                Lbl_Messaage.Text = "";
                Label_1.Text = "";

                #region

                string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
                if (fileExt == ".xls" || fileExt == ".xlsx")    
                {
                    #region

                    try
                    {
                        string newname = System.DateTime.Now.ToString("yyyyMMddHHmmssffff");//重命名
                        newname += ".xls";
                        FileUpload1.SaveAs(Server.MapPath("excel") + "\\" + newname);
                        string filename = (Server.MapPath("excel") + "\\" + newname).ToString();


                        if (filename != "")
                        {
                            try
                            {
                                DataTable dt = CommonClass.DataHandler.ExcelToData.ReadExcelToTable(filename,0);
                                #region 插入
                                Eastcom.BLL.考试题库 bll = new Eastcom.BLL.考试题库();
                                int success = 0, error = 0;
                                string ErrorMsg = "";

                                DateTime now =DateTime.Now;
                                /*添加备份*/

                                string RealName = "";
                                if (CurrentUserModel != null)
                                    RealName = CurrentUserModel.RealName;

                                bll.AddHisBak(now, RealName.ToString());
                             
                                bll.ExecuteTrunCate();


                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    try
                                    {
                                        string 题目内容 = dt.Rows[i]["题目内容"].ToString().Trim();
                                        string 选项A = dt.Rows[i]["选项A"].ToString().Trim();
                                        string 选项B = dt.Rows[i]["选项B"].ToString().Trim();
                                        string 选项C = dt.Rows[i]["选项C"].ToString().Trim();
                                        string 选项D = dt.Rows[i]["选项D"].ToString().Trim();
                                        string 选项E = dt.Rows[i]["选项E"].ToString().Trim();
                                        string 标准答案 = dt.Rows[i]["答案"].ToString().Trim();
                                        //string 标准答案2 = dt.Rows[i]["标准答案2"].ToString().Trim();
                                            
                                        Eastcom.Model.考试题库 model = new Eastcom.Model.考试题库();

                                        model.题目内容 = 题目内容;
                                        model.A选项 = 选项A;
                                        model.B选项 = 选项B;
                                        model.C选项 = 选项C;
                                        model.D选项 = 选项D;
                                        model.其他选项 = 选项E;
                                        //model.标准答案 = 标准答案;
                                        model.标准答案2 = 标准答案;

                                        bll.Add(model);
                                        success++;
                                    }
                                    catch
                                    {
                                        ErrorMsg += "第" + (i + 1) + "行数据录入出错<br>";
                                        error++;
                                    }
                                }
                                bll.Update标准答案();

                                if (error == 0)
                                {
                                    Lbl_Messaage.Text = success.ToString() + "条导入成功";
                                    Lbl_Messaage.ForeColor = System.Drawing.Color.Green;
                                }
                                else
                                {
                                    Lbl_Messaage.Text = success.ToString() + "条导入成功," + error.ToString()
                                       + "条导入失败.失败数据请修改后重新导入！<BR>" + ErrorMsg;
                                    Lbl_Messaage.ForeColor = System.Drawing.Color.Red;
                                }

                                #endregion
                            }
                            catch (Exception ex)
                            {
                                Eastcom.Common.MessageBox.Show(this, "导入失败");
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Label_1.Text = "ERROR: " + ex.Message.ToString();
                        Label_1.ForeColor = System.Drawing.Color.Red;
                    }
                    #endregion
                }
                else
                {
                    Label_1.Text = "只能上传Excel文件！";
                    Label_1.ForeColor = System.Drawing.Color.Red;
                }
                #endregion
            }
            else
            {
                Label_1.Text = "请选择一个Excel文件。";
                Label_1.ForeColor = System.Drawing.Color.Red;  //字体为 红色 System.Drawing.Color.Red
            }
        }
    }
}