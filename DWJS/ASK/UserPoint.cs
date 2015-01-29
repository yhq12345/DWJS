using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DWKS.ASK
{
    public class UserPoint
    {
        public decimal 用户得分
        {
            get;
            set;
        }
        public string 得分情况
        {
            get;
            set;
        }
     

        public UserPoint Get用户得分情况(string 用户答案, string 题库答案)
        {
           
            UserPoint a = new UserPoint();
            if (用户答案.Trim() == string.Empty)
            {
                用户答案 = ",,,";
            }
            if (题库答案.Trim() == string.Empty)
            {
                题库答案 = ",,,";
            }
            string[] 用户答案_Arr = 用户答案.Split(',');
            string[] 题库答案案_Arr = 题库答案.Split(',');

            int k = 0;

            for (int i = 0; i < 题库答案案_Arr.Length; i++)
            {
                if (题库答案案_Arr[i].Trim() != "")
                {
                    for (int j = 0; j < 用户答案_Arr.Length; j++)
                    {
                        if (用户答案_Arr[j].Trim() != string.Empty && 题库答案案_Arr[i] == 用户答案_Arr[j])
                        {
                            k++;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            if (k == 题库答案案_Arr.Length)
            {
                a.得分情况="完全正确";
                a.用户得分 = ((decimal)100 / 20); //总分 除以 考试总提数
               
            }
            if (k < 题库答案案_Arr.Length && k > 0)
            {
                a.得分情况 = "部分正确 ";
                a.用户得分 = ((decimal)100 / 20 / 2);  //半分
            
            }
            if (k > 0 && 用户答案_Arr.Length > 题库答案案_Arr.Length) //用户答多的情况
            {
                a.得分情况 = "部分正确 ";
                a.用户得分 = ((decimal)100 / 20 / 2);  //半分
               
            }
            if (k ==0)
            {
                a.得分情况 = "完全错误 ";
                a.用户得分 = 0;  //半分
             
            }
            return a;
        }
    }
}