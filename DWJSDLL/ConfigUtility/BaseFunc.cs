using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.Web;
using System.Web.UI;

namespace Eastcom.ConfigUntility
{
    public abstract class BaseFunc
    {
        /// <summary>
        /// 是有地区填报的权限 
        /// </summary>
        /// <param name="RecordArea"></param>
        /// <returns></returns>
        public static bool IsAreaRole(string RecordArea)
        {
            try
            {
                string Userarea = Eastcom.BLL.SessionConfig.GetUserArea();
                if (Userarea == "#全地区")
                { return true; }
                else
                {
                    string[] newArea = Userarea.Split('#');
                    foreach (string i in newArea)
                    {
                        if (i == RecordArea)
                            return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 地区的复选
        /// </summary>
        /// <param name="Area"></param>
        /// <returns></returns>
        public static string ConvertToSQLArea(string Area)
        {
            try
            {
                string[] AreaArray;
                string returnValue = "";
                if (Area == "")
                    return "";
                else
                {
                    if (Area.IndexOf('+') == -1)
                    {
                        Area = "'" + Area + "'";
                        return Area;
                    }
                    else
                    {
                        AreaArray = Area.Split('+');

                        for (int i = 0; i < AreaArray.Length; i++)
                        {
                            returnValue += "'" + AreaArray[i] + "',";
                        }
                        return returnValue.Substring(0, returnValue.Length - 1);
                    }
                }
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 地区的json格式
        /// </summary>
        /// <param name="Area"></param>
        /// <returns></returns>
        public static string ConvertToAreaArray(string Area)
        {
            try
            {
                string[] AreaArray;
                string returnValue = "";
                if (Area == "")
                    return "''";
                else
                {
                    if (Area.IndexOf(',') == -1)
                        return "'" + Area + "'";
                    else
                    {
                        AreaArray = Area.Split(',');

                        for (int i = 0; i < AreaArray.Length; i++)
                        {
                            returnValue += "'" + AreaArray[i] + "',";
                        }
                        return returnValue.Substring(0, returnValue.Length - 1);
                    }
                }
            }
            catch
            {
                return "";
            }
        }
        #region	常用方法

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="dt"></param>
        /// <param name="fileName"></param>
        public static void ExportExcel(Page page, DataTable dt, string fileName)
        {
            HttpResponse resp;
            resp = page.Response;
            resp.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            resp.Clear();
            resp.Buffer = true;
            resp.Charset = "GB2312";
            resp.AppendHeader("Content-Disposition", "attachment;filename=" + fileName.Trim());
            resp.ContentType = "application/ms-excel";
            string colHeaders = "", ls_item = "";

            ////定义表对象与行对象，同时用DataSet对其值进行初始化 
            // DataTable dt = ds.Tables[0]; 
            DataRow[] myRow = dt.Select();//可以类似dt.Select("id>10")之形式达到数据筛选目的 
            int i = 0;
            int cl = dt.Columns.Count;

            //取得数据表各列标题，各标题之间以t分割，最后一个列标题后加回车符 
            for (i = 0; i < cl; i++)
            {
                if (i == (cl - 1))//最后一列，加n 
                {
                    colHeaders += dt.Columns[i].Caption.ToString() + "\n";
                }
                else
                {
                    colHeaders += dt.Columns[i].Caption.ToString() + "\t";
                }

            }
            resp.Write(colHeaders);
            //向HTTP输出流中写入取得的数据信息 

            //逐行处理数据 
            foreach (DataRow row in myRow)
            {
                //当前行数据写入HTTP输出流，并且置空ls_item以便下行数据 
                for (i = 0; i < cl; i++)
                {
                    if (i == (cl - 1))//最后一列，加n 
                    {
                        ls_item += row[i].ToString().Replace('\n', ' ') + "\n";
                    }
                    else
                    {
                        ls_item += row[i].ToString().Replace('\n', ' ') + "\t";
                    }

                }
                resp.Write(ls_item);
                ls_item = "";

            }
            resp.End();
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="page"></param>
        /// <param name="path"></param>
        public static void DownLoad(System.Web.UI.Page page, string path)
        {
            if (path != null && System.IO.File.Exists(path))
            {
                System.IO.FileInfo file = new System.IO.FileInfo(path);
                //清除缓冲区流中的所有内容输出

                page.Response.Clear();

                //将下载保存对话框指定默认的文件名添加到HTTP头中
                //Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);

                page.Response.AddHeader("Content-Disposition", "attachment;   filename=" + System.Web.HttpUtility.UrlEncode(file.Name, System.Text.Encoding.UTF8));//避免中文出现乱码现象   

                //在header中指定文件的大小，使浏览器能显示下载过程
                page.Response.AddHeader("Content-Length", file.Length.ToString());

                //设置输出流的 HTTP MIME 类型
                page.Response.ContentType = "application/octet-stream";

                // 发送文件流到客户端
                page.Response.WriteFile(file.FullName);
                // 停止该页的执行

                page.Response.End();

            }
        }
        /// <summary>
        /// 设置下拉框初始值；
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="ds"></param>
        /// <param name="textField"></param>
        /// <param name="valueField"></param>
        public static void SetCheckBoxListValue(CheckBoxList chk, DataSet ds)
        {
            chk.Items.Clear();
            chk.DataSource = ds;
            chk.DataTextField = "text";
            chk.DataValueField = "value";
            chk.DataBind();
        }

        /// <summary>
        /// Excel检查地区
        /// </summary>
        /// <param name="Area"></param>
        /// <returns></returns>
        public static bool ExcelCheck_Area(string Area)
        {
            try
            {
                switch (Area)
                {

                    case Eastcom.ConfigUntility.ConfigArgs.memArea_LC: return true;
                    case Eastcom.ConfigUntility.ConfigArgs.memArea_LW: return true;
                    case Eastcom.ConfigUntility.ConfigArgs.memArea_OH: return true;
                    case Eastcom.ConfigUntility.ConfigArgs.memArea_PY: return true;
                    case Eastcom.ConfigUntility.ConfigArgs.memArea_RA: return true;
                    case Eastcom.ConfigUntility.ConfigArgs.memArea_TS: return true;
                    case Eastcom.ConfigUntility.ConfigArgs.memArea_CN: return true;
                    case Eastcom.ConfigUntility.ConfigArgs.memArea_WC: return true;
                    case Eastcom.ConfigUntility.ConfigArgs.memArea_YJ: return true;
                    case Eastcom.ConfigUntility.ConfigArgs.memArea_YQ: return true;
                    case Eastcom.ConfigUntility.ConfigArgs.memArea_DT: return true;
                    default: return false;

                }
            }
            catch
            {

                return false;
            }

        }
        /// <summary>
        /// Excel检查是否已经交接
        /// </summary>
        /// <param name="IsToManaged"></param>
        /// <returns></returns>
        public static bool ExcelCheck_IsToManaged(string IsToManaged)
        {
            try
            {
                switch (IsToManaged)
                {

                    case "是": return true;
                    case "否": return true;
                    default: return false;
                }
            }
            catch
            { return false; }
        }

        public static bool ExcelCheck_CableProperty(string CableProperty)
        {
            try
            {
                switch (CableProperty)
                {

                    case "主配": return true;
                    case "辅配": return true;
                    case "普通": return true;
                    default: return false;

                }
            }
            catch
            {

                return false;
            }
        }
        public static bool ExcelCheck_CableState(string CableState)
        {
            try
            {
                switch (CableState)
                {
                    case "规划中": return true;
                    case "建设中": return true;
                    case "维护中": return true;
                    default: return false;
                }
            }
            catch
            {

                return false;
            }
        }
        public static bool ExcelCheck_Longitude_Latitude(string Longitude)
        {
            try
            {
                string Longitude1 = Longitude.Trim();
                if (Longitude1.IndexOf('.') == -1)
                {
                    return false;
                }
                else
                {
                    string[] Longitude_Spile = Longitude1.Split('.');
                    if (Longitude_Spile[1].Length != 5)
                    {
                        return false;
                    }
                    else
                    {
                        Convert.ToInt32(Longitude_Spile[0].ToString());
                        Convert.ToInt32(Longitude_Spile[1].ToString());
                        return true;
                    }
                }

            }
            catch
            {
                return false;
            }

        }


        public static bool Excel_Check_Manufacuturer(string Manufacuturer)
        {
            try
            {
                switch (Manufacuturer)
                {
                    case "宁波余大": return true;
                    case "杭州更新": return true;
                    default: return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool Excel_Check_DesignCapacity(string DesignCapacity)
        {
            try
            {
                switch (DesignCapacity)
                {
                    case "72": return true;
                    case "144": return true;
                    case "288": return true;
                    case "576": return true;
                    default: return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool Excel_Check_InstallCapacity(string InstallCapacity)
        {
            try
            {
                switch (InstallCapacity)
                {
                    case "72": return true;
                    case "144": return true;
                    case "288": return true;
                    case "576": return true;
                    default: return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool Excel_Check_EquityProperty(string EquityProperty)
        {
            try
            {
                switch (EquityProperty.Trim())
                {
                    case "自建": return true;
                    case "共建": return true;
                    case "": return true;
                    default: return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool Excel_Check_EquityUnit(string EquityUnit)
        {
            try
            {
                switch (EquityUnit.Trim())
                {
                    case "移动": return true;
                    case "电信": return true;
                    case "联通": return true;
                    case "": return true;
                    default: return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool Excel_Check_UsedUnit(string UsedUnit)
        {
            try
            {
                switch (UsedUnit.Trim())
                {
                    case "移动": return true;
                    case "电信": return true;
                    case "联通": return true;
                    case "": return true;
                    default: return false;
                }
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 设置下拉框初始值；
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="ds"></param>
        /// <param name="textField"></param>
        /// <param name="valueField"></param>
        public static void SetDropDownListValue(DropDownList ddl, DataSet ds, string textField, string valueField)
        {
            ddl.Items.Clear();
            ddl.DataSource = ds;
            ddl.DataTextField = textField;
            ddl.DataValueField = valueField;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("请选择", "-1"));
        }

        /// <summary>
        /// 设置下拉框初始值；
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="ds"></param>
        /// <param name="textField"></param>
        /// <param name="valueField"></param>
        public static void SetDropDownListValue(DropDownList ddl, DataSet ds)
        {
            ddl.Items.Clear();
            ddl.DataSource = ds;
            ddl.DataTextField = "text";
            ddl.DataValueField = "value";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("请选择", "-1"));
        }

        /// <summary>
        /// 是否是光交编号的格式
        /// </summary>
        /// <param name="CableNo"></param>
        /// <returns></returns>
        public static bool IsCableNoStyle(string CableNo)//LW0001  LW24d2
        {
            string area = "";
            string No = "";
            int i = 0;

            if (CableNo.Length != 8)
            {
                return false;
            }
            else
            {
                try
                {
                    area = CableNo.Substring(0, 4);
                    No = CableNo.Substring(4, 4);
                    if (!IsAreaString(area))
                    {
                        return false;
                    }
                    i = Convert.ToInt32(No);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsNum(string StringValue)
        {
            try
            {
                if (StringValue.Trim() != "")
                {
                    int a = int.Parse(StringValue);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }
        protected static bool IsAreaString(string areaGJ)
        {
            switch (areaGJ)
            {
                case ConfigArgs.GJ_LC: return true;
                case ConfigArgs.GJ_LW: return true;
                case ConfigArgs.GJ_OH: return true;
                case ConfigArgs.GJ_PY: return true;
                case ConfigArgs.GJ_RA: return true;
                case ConfigArgs.GJ_TS: return true;
                case ConfigArgs.GJ_WC: return true;
                case ConfigArgs.GJ_YJ: return true;
                case ConfigArgs.GJ_YQ: return true;
                case ConfigArgs.GJ_DT: return true;
                case ConfigArgs.GJ_CN: return true;

                default: return false;
            }

        }
        /// <summary>
        /// 设置下拉框初始值；
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="ds"></param>
        /// <param name="textField"></param>
        /// <param name="valueField"></param>
        public static void SetDropDownListValue(DropDownList ddl, DataTable dt, string textField, string valueField)
        {
            ddl.Items.Clear();
            ddl.DataSource = dt;
            ddl.DataTextField = textField;
            ddl.DataValueField = valueField;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        /// <summary>
        /// 设置下拉框初始值；
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="ds"></param>
        /// <param name="textField"></param>
        /// <param name="valueField"></param>
        public static void SetDropDownListValue(DropDownList ddl, DataTable dt)
        {
            ddl.Items.Clear();
            ddl.DataSource = dt;
            ddl.DataTextField = "text";
            ddl.DataValueField = "value";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddl"></param>
        public static void SetDropDownListAreaValue(DropDownList ddl)
        {
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem(ConfigArgs.memArea_ALL, ConfigArgs.memArea_ALL));
            ddl.Items.Add(new ListItem(ConfigArgs.memArea_LC, ConfigArgs.memArea_LC));
            ddl.Items.Add(new ListItem(ConfigArgs.memArea_LW, ConfigArgs.memArea_LW));
            ddl.Items.Add(new ListItem(ConfigArgs.memArea_OH, ConfigArgs.memArea_OH));
            ddl.Items.Add(new ListItem(ConfigArgs.memArea_RA, ConfigArgs.memArea_RA));
            ddl.Items.Add(new ListItem(ConfigArgs.memArea_PY, ConfigArgs.memArea_PY));
            ddl.Items.Add(new ListItem(ConfigArgs.memArea_CN, ConfigArgs.memArea_CN));
            ddl.Items.Add(new ListItem(ConfigArgs.memArea_YQ, ConfigArgs.memArea_YQ));
            ddl.Items.Add(new ListItem(ConfigArgs.memArea_WC, ConfigArgs.memArea_WC));
            ddl.Items.Add(new ListItem(ConfigArgs.memArea_DT, ConfigArgs.memArea_DT));
            ddl.Items.Add(new ListItem(ConfigArgs.memArea_YJ, ConfigArgs.memArea_YJ));
            ddl.Items.Add(new ListItem(ConfigArgs.memArea_TS, ConfigArgs.memArea_TS));
            ddl.Items.Insert(0, new ListItem("请选择", "-1"));
        }

        //设置下拉框选择项
        public static bool SelectDropDownListValue(DropDownList ddl, string strvalue)
        {
            bool hasExist = false;
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Value == strvalue)
                {
                    ddl.SelectedIndex = i;
                    hasExist = true;
                    break;
                }
            }
            if (!hasExist)
            {
                if (strvalue.Trim() != string.Empty)
                {
                    ddl.Items.Insert(0, new ListItem(strvalue, strvalue));
                    ddl.SelectedIndex = ddl.Items.Count - 1;
                }
                //else
                //{
                //    ddl.SelectedIndex = 0;
                //}
            }
            return hasExist;
        }

        /// <summary>
        /// 过长截取长度
        /// </summary>
        /// <param name="TableCell">Cell的实体</param>
        /// <param name="SubLength">要截取的长度</param>
        public static void SetBindCellTextLengh(TableCell TableCell, int SubLength)
        {
            if (TableCell.Text.Length > SubLength)
            {
                TableCell.ToolTip = TableCell.Text;
                TableCell.Text = TableCell.Text.Substring(0, SubLength) + "...";
            }
        }



        /// <summary>
        /// Linux时间转为 yyyy-MM-dd 格式
        /// </summary>
        /// <param name="TimeSpanValue"></param>
        /// <returns></returns>
        public static string GetDateTimeFromMinDate(double TimeSpanValue)
        {
            //string a=TimeZone.CurrentTimeZone.StandardName;
            //DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1900, 1, 1,1,0,0));
            //long lTime = long.Parse(TimeSpanValue.ToString() + "0000000");
            //TimeSpan toNow = new TimeSpan(lTime); 
            //return dtStart.Add(toNow).ToString("yyyy-MM-dd HH:mm:ss");

            return TimeZone.CurrentTimeZone.ToLocalTime(Convert.ToDateTime("1970-01-01 00:00:00").AddSeconds(TimeSpanValue)).ToString("MM-dd-yyyy HH:mm:ss");

        }
        /// <summary>
        /// yyyy-MM-dd 转为js 时间
        /// </summary>
        /// <param name="TimeSpanValue"></param>
        /// <returns></returns>
        public static decimal? GetMinDateFromDateTime(string DateTimeString)
        {
            //string a=TimeZone.CurrentTimeZone.StandardName;
            //DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1900, 1, 1,1,0,0));
            //long lTime = long.Parse(TimeSpanValue.ToString() + "0000000");
            //TimeSpan toNow = new TimeSpan(lTime); 
            //return dtStart.Add(toNow).ToString("yyyy-MM-dd HH:mm:ss");

            DateTime x = DateTime.MinValue;
            try
            {
             //TimeZone.CurrentTimeZone.get(Convert.ToDateTime(DateTimeString));
                 TimeZoneInfo timeZoneDestination = TimeZoneInfo.FindSystemTimeZoneById("UTC");
                 x = TimeZoneInfo.ConvertTime((Convert.ToDateTime(DateTimeString)), timeZoneDestination); // (Convert.ToDateTime(DateTimeString));//TimeZone.CurrentTimeZone.ToLocalTime
            }
            catch
            {

            }
            TimeSpan ts = x - new DateTime(1970, 1, 1, 0, 0,0);
            return Convert.ToDecimal(ts.TotalMilliseconds);

        }



        public static int GetPonSort(string Pon)
        {
            try
            {
                string[] Pon_list = Pon.Split('/');
                int Pon_int1 = Convert.ToInt32(Pon_list[0]) * 100;
                int Pon_int2 = Convert.ToInt32(Pon_list[1]);
                return Pon_int1 + Pon_int2;
            }
            catch
            {
                return 9999;
            }
        }


        #endregion 常用方法
        #region 绑定控件
        /// <summary>
        /// 得到2011年到今年的年份数
        /// </summary>
        /// <param name="ddl"></param>
        public static void SetDDL_Year(DropDownList ddl)
        {
            ddl.Items.Clear();
            int YearDis = DateTime.Now.Year - 2011;
            if (YearDis >= 0)
            {
                for (int i = 0; i <= YearDis; i++)
                {
                    //if (DateTime.Now.Month != 1)
                        ddl.Items.Add(new ListItem((2011 + i).ToString(), (2011 + i).ToString()));
                    //else
                    //ddl.Items.Add(new ListItem((2011 + i - 1).ToString(), (2011 + i - 1).ToString()));
                }

                //if (DateTime.Now.Month != 1)
                    ddl.SelectedValue = DateTime.Now.Year.ToString();
                //else
                //    ddl.SelectedValue = (DateTime.Now.Year - 1).ToString();
            }
        }
        /// <summary>
        /// 绑定月份
        /// </summary>
        /// <param name="ddl"></param>
        public static void SetDDL_Month(DropDownList ddl)
        {
            ddl.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                ddl.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        public static void SetDDL_Year_Month(DropDownList ddl)
        {
            DateTime 开始时间 =  Convert.ToDateTime(DateTime.Now.AddYears(-1).ToString("yyyy-MM")); //new DateTime()
            ddl.Items.Clear();
            for (int i = 0; i < 12; i++)
            {
                string 测试时间 = DateTime.Now.AddMonths(-i).ToString("yyyy-MM");
                ddl.Items.Add(new ListItem(测试时间, 测试时间));
            }
        }


        public static void SetDDL_提交情况(DropDownList ddl)
        {
           ddl.Items.Clear();

           foreach (string x in Enum.GetNames(typeof(ConfigArgs.提交情况)))
           {
               ddl.Items.Add(new ListItem(x.ToString(), x.ToString()));
           }
        }

        #endregion 


    }
}
