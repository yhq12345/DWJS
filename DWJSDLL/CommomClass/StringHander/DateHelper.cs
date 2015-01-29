using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CommonClass.StringHander
{
    /// <summary>
    /// DateHelper
    /// </summary>
    public static class DateHelper
    {
        #region 剩余天数相关
        /// <summary>
        /// 返回指定日期到该日期所在月结束的剩余天数
        /// </summary>
        public static int DaysLeftInMonth(this DateTime Date)
        {
            return Thread.CurrentThread.CurrentCulture.Calendar.GetDaysInMonth(Date.Year, Date.Month) - Date.Day;
        }

        /// <summary>
        /// 返回指定日期到该日期所在年结束的剩余天数
        /// </summary>
        public static int DaysLeftInYear(this DateTime Date)
        {
            return Thread.CurrentThread.CurrentCulture.Calendar.GetDaysInYear(Date.Year) - Date.DayOfYear;
        }

        /// <summary>
        /// 返回指定日期到所在周结束的剩余天数
        /// </summary>
        public static int DaysLeftInWeek(this DateTime Date)
        {
            return 7 - ((int)Date.DayOfWeek + 1);
        }
        #endregion

        #region Unix与DateTime转换
        /// <summary>
        /// 将Unix（int）转为DateTime
        /// </summary>
        /// <param name="Date">Unix</param>
        /// <returns>DateTime</returns>
        public static DateTime FromUnixTime(int Date)
        {
            return new DateTime((Date * TimeSpan.TicksPerSecond) + new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks, DateTimeKind.Utc);
        }

        /// <summary>
        ///  将Unix（long）转为DateTime
        /// </summary>
        public static DateTime FromUnixTime(long Date)
        {
            return new DateTime((Date * TimeSpan.TicksPerSecond) + new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks, DateTimeKind.Utc);
        }

        /// <summary>
        /// 将DateTime转为Unix
        /// </summary>
        public static int ToUnix(DateTime Date)
        {
            return (int)((Date.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Ticks / TimeSpan.TicksPerSecond);
        }
        #endregion

        #region 时间间隔相关
        /// <summary>
        /// 获取两个时间的时间间隔，如：“小时:分钟:秒”
        /// </summary>
        /// <returns></returns>
        public static string GetTimeString(DateTime dtStart,DateTime dtEnd)
        {
            int h, m, s;
            double sec= dtEnd.Subtract(dtStart).TotalSeconds;
            h = (int)(sec / 3600);
            m=(int)((sec%3600)/60);
            s=(int)((sec%3600)%60);
            return string.Format("{0}：{1}：{2}",h,m,s); ;
        }

        /// <summary>
        /// 计算日期间隔
        /// </summary>
        /// <param name="d1">要参与计算的其中一个日期字符串</param>
        /// <param name="d2">要参与计算的另一个日期字符串</param>
        /// <returns>一个表示日期间隔的TimeSpan类型</returns>
        public static TimeSpan GetTimeInterval(string d1, string d2)
        {
            try
            {
                DateTime date1 = DateTime.Parse(d1);
                DateTime date2 = DateTime.Parse(d2);
                return GetTimeInterval(date1, date2);
            }
            catch
            {
                throw new Exception("字符串参数不正确!");
            }
        }
        /// <summary>
        /// 计算日期间隔
        /// </summary>
        /// <param name="d1">要参与计算的其中一个日期</param>
        /// <param name="d2">要参与计算的另一个日期</param>
        /// <returns>一个表示日期间隔的TimeSpan类型</returns>
        public static TimeSpan GetTimeInterval(DateTime d1, DateTime d2)
        {
            TimeSpan ts;
            if (d1 > d2)
            {
                ts = d1 - d2;
            }
            else
            {
                ts = d2 - d1;
            }
            return ts;
        }

        /// <summary>
        /// 计算日期间隔
        /// </summary>
        /// <param name="d1">要参与计算的其中一个日期字符串</param>
        /// <param name="d2">要参与计算的另一个日期字符串</param>
        /// <param name="drf">决定返回值形式的枚举</param>
        /// <returns>一个代表年月日的int数组，具体数组长度与枚举参数drf有关</returns>
        public static int[] GetTimeInterval(string d1, string d2, diffResultFormat drf)
        {
            try
            {
                DateTime date1 = DateTime.Parse(d1);
                DateTime date2 = DateTime.Parse(d2);
                return GetTimeInterval(date1, date2, drf);
            }
            catch
            {
                throw new Exception("字符串参数不正确!");
            }
        }
        /// <summary>
        /// 计算日期间隔
        /// </summary>
        /// <param name="d1">要参与计算的其中一个日期</param>
        /// <param name="d2">要参与计算的另一个日期</param>
        /// <param name="drf">决定返回值形式的枚举</param>
        /// <returns>一个代表年月日的int数组，具体数组长度与枚举参数drf有关</returns>
        public static int[] GetTimeInterval(DateTime d1, DateTime d2, diffResultFormat drf)
        {
            #region 数据初始化
            DateTime max;
            DateTime min;
            int year;
            int month;
            int tempYear, tempMonth;
            if (d1 > d2)
            {
                max = d1;
                min = d2;
            }
            else
            {
                max = d2;
                min = d1;
            }
            tempYear = max.Year;
            tempMonth = max.Month;
            if (max.Month < min.Month)
            {
                tempYear--;
                tempMonth = tempMonth + 12;
            }
            year = tempYear - min.Year;
            month = tempMonth - min.Month;
            #endregion
            #region 按条件计算
            if (drf == diffResultFormat.dd)
            {
                TimeSpan ts = max - min;
                return new int[] { ts.Days };
            }
            if (drf == diffResultFormat.mm)
            {
                return new int[] { month + year * 12 };
            }
            if (drf == diffResultFormat.yy)
            {
                return new int[] { year };
            }
            return new int[] { year, month };
            #endregion
        }

        /// <summary>
        /// 关于返回值形式的枚举
        /// </summary>
        public enum diffResultFormat
        {
            /// <summary>
            /// 年数和月数
            /// </summary>
            yymm,
            /// <summary>
            /// 年数
            /// </summary>
            yy,
            /// <summary>
            /// 月数
            /// </summary>
            mm,
            /// <summary>
            /// 天数
            /// </summary>
            dd,
        }
        #endregion

        #region 其它
        /// <summary>
        /// 返回指定日期所在月的第一天
        /// </summary>
        public static DateTime FirstDayOfMonth(this DateTime Date)
        {
            return new DateTime(Date.Year, Date.Month, 1);
        }

        /// <summary>
        /// 返回指定日期所在月的最后一天(包含时间部分)（如：2012-01-02 23:59:59）
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(this DateTime dt)
        {
            return dt.AddMonths(1).FirstDayOfMonth().AddMilliseconds(-1);
        }

        /// <summary>
        /// 根据指定年月和向前推移的月数，返回起始时间
        /// 如：传入("2012-09",2)，则返回{2012-08-01,2012-09-01}
        /// </summary>
        /// <param name="yearMonth">如：2012-09</param>
        /// <param name="monthCount">如：2</param>
        /// <returns>如：{2012-08-01,2012-09-01}</returns>
        public static DateTime[] GetStartTimeEndTimeByYearMonth(string yearMonth,int monthCount)
        {
            DateTime[] dt =null;
            DateTime? dtEndTime = Common.GetDateTimeNullable(string.Format("{0}-01", yearMonth));
            if (null != dtEndTime)
            {
                DateTime dtStartTime = Convert.ToDateTime(dtEndTime).AddMonths(-1 * monthCount + 1);
                dt=new DateTime[]{dtStartTime,Common.GetDateTime(Convert.ToString(dtEndTime))};
            }
            return dt;
        }

        /// <summary>
        /// 返回指定条件名和起止时间的最终条件字符串（包含等号）
        /// 如：("aaa",'2012-01-01 00:10:00',null)="aaa>='2012-01-01 00:10:00'"(无小于等于，若end不为null，则有小于等于)
        /// </summary>
        /// <param name="fieldName">条件名</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <returns></returns>
        public static string GetDateTimeWhereByStartEndTime(string fieldName, DateTime? start, DateTime? end)
        {
            string str = string.Empty;
            if (!string.IsNullOrEmpty(fieldName))
            {
                if (start == null&&end!=null)
                {
                    str = string.Format("{0}<='{1}'",fieldName,end);
                }
                else if (start != null && end == null)
                {
                    str = string.Format("{0}>='{1}'",fieldName,start);
                }
                else if (start != null && end != null)
                {
                    str = string.Format("{0}>='{1}' and {0}<='{2}'",fieldName,start,end);
                }
            }
            return str;
        }
        #endregion

        #region 周相关
        /// <summary>
        /// 周枚举
        /// </summary>
        public enum Weeks
        { 
            周一=1,
            周二=2,
            周三=3,
            周四=4,
            周五=5,
            周六=6,
            周日=0
        }
        #endregion

        #region 转中文日期
        /// <summary>
        /// 将数字日期格式转为中文日期格式
        /// 如：2013-01-01=》二〇一三年一月一日
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToCNString(this DateTime dt)
        {
            string CNdate = dt.ToLongDateString();//转成年月日格式
            CNdate = Regex.Replace(CNdate, @"\d+[^\d]", rep_date);
            return CNdate;
        }
        private static string rep_date(Match mc)
        {
            const string cnd = "〇一二三四五六七八九";
            string val = mc.Value;
            string digit = val.Substring(0, val.Length - 1);
            char c = val[val.Length - 1];
            val = "";
            switch (c)
            {
                case '年':
                    foreach (char s in digit) val += cnd[int.Parse(s.ToString())];
                    break;
                case '月':
                case '日':
                    if (digit.Length == 1)
                        val += cnd[int.Parse(digit)];
                    else
                    {
                        val += cnd[int.Parse(digit[0].ToString())] + "十";
                        val = val.TrimStart('一');
                        val += cnd[int.Parse(digit[1].ToString())].ToString().Trim('〇');
                    }
                    break;
                default:
                    return "格式错误";
            }
            return val + c.ToString();
        }

        #endregion
    }
}
