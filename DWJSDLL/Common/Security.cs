using System.Web;

namespace Eastcom.Common
{
    /// <summary>
    /// Web安全类
    /// </summary>
    public class Security
    {
        ///// <summary>
        ///// 截获页面带参Request里的SQL插入注入信息
        ///// </summary>
        ///// <param name="error">返回错误值</param>
        ///// <returns></returns>
        //public static bool Clear_ApplicationRequest(out string error)
        //{
        //    bool flag = true;
        //    error = string.Empty;
        //    if (HttpContext.Current.Request.QueryString != null)
        //    {
        //        foreach (string str in get_sql_a())
        //        {
        //            if (HttpContext.Current.Request.QueryString.ToString().ToLower().IndexOf(str.Trim()) >= 0)
        //            {
        //                flag = false;
        //                error = ClientInfo.getPageInfo("系统裁获注入操作，提供以下信息！");
        //            }
        //        }
        //    }
        //    if (HttpContext.Current.Request.Form.Count > 0)
        //    {
        //        string str2 = HttpContext.Current.Request.ServerVariables["SERVER_NAME"].Trim();
        //        if (HttpContext.Current.Request.ServerVariables["HTTP_REFERER"] == null)
        //        {
        //            return flag;
        //        }
        //        string str3 = HttpContext.Current.Request.ServerVariables["HTTP_REFERER"].Trim();
        //        string str4 = "";
        //        if (str2.Length > (str3.Length - 7))
        //        {
        //            str4 = str3.Substring(7);
        //        }
        //        else
        //        {
        //            str4 = str3.Substring(7, str2.Length);
        //        }
        //        if (str4 != str2)
        //        {
        //            flag = false;
        //            error = ClientInfo.getPageInfo("系统裁获注入操作，提供以下信息！");
        //        }
        //    }
        //    return flag;
        //}

        private static string[] get_sql_a()
        {
            string str = "exec|insert+|select+|delete|update|count|master+|truncate|char|declare|drop+|drop+table|creat+|creat+table";
            return str.Split(new char[] { char.Parse("|") });
        }

        private static string[] get_sql_b()
        {
            string str = "exec+|insert+|delete+|update+|count(|count+|chr+|+mid(|+|+master+|truncate+|char+|+char(|declare+|drop+|creat+|drop+table|creat+table";
            return str.Split(new char[] { char.Parse("|") });
        }

        /// <summary>
        /// 过滤所带的参数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Filter_Sql(string str)
        {
            string SQL_injdata = "'|exec+|insert+|delete+|update+|chr+|+mid(|+master+|truncate+|char+|+char(|declare+|drop+|creat+|drop+table|creat+table";
            string[] str_temp = SQL_injdata.Split('|');
            for (int i = 0; i < str_temp.Length; i++)
            {
                str = str.Replace(str_temp[i], "");
            }
            return str;
        }

        /// <summary>
        /// 过滤查询信息里的参数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Filter_Feild(string str)
        {
            string SQL_injdata = ":|;|>|<|--|sp_|xp_|\\|dir|cmd|^|(|)|+|$|'|copy|format|exec|insert|select|delete|update|count|*|%|chr|mid|master|truncate|char|declare";
            string[] str_temp = SQL_injdata.Split('|');
            for (int i = 0; i < str_temp.Length; i++)
            {
                str = str.Replace(str_temp[i], "");
            }
            return str;
        }
    }
}
