using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eastcom.Common
{
     public class DateTimeDiff
    {
         public DateTimeDiff()
         { }
        // object[] arrTimes = {
         //           new string[] { "8:00", "12:00" },
          //          new string[] { "14:00", "20:00"}
          //      };//工作时间  可以重数据库 或是xml中读出
         /// <summary>
         /// Data2-Data1 减去工作时间 Data2>Data1
         /// </summary>
         /// <param name="WorkTimes"></param>
         /// <param name="Date1"></param>
         /// <param name="Date2"></param>
         /// <returns></returns>
         /// double a = WorkDateTime(arrTimes, Convert.ToDateTime("2011-8-8 12:30:22"),DateTime.Now); //(10 +3)*60+30 810 
         public static  double WorkDateTime(object[] WorkTimes, DateTime Date1, DateTime Date2)
         {
             //TimeSpan ts = (TimeSpan)(Date2.Date - Date1.Date);//日期的差值
             //double DateMin1 = 0;
             //double DateMin2 = 0;

             //int DateDiff = ts.Days;

             //if (DateDiff == 1) //超过一天
             //{
             //    return DateMin1 + DateMin2;
             //}
             //else if (DateDiff > 1)
             //{
             //    DateMin1 = GetFirstMinutes(Date1);  //后续算法
             //    DateMin2 = GetLastMinutes(Date2);   //正序

             //    return Math.Abs(DateMin1) + Math.Abs(DateMin2) + 600 * (DateDiff - 1);//
             //}
             //else //没超过一天
             //{
             //    return GetTodayMinutes(Date1, Date2);
             //}
             TimeSpan ts = (TimeSpan)(Date2.Date - Date1.Date);

             double DateMin1 = 0;
             double DateMin2 = 0;

             int DateDiff = ts.Days;

             if (DateDiff >= 1) //一天以上
             {
                 DateMin1 = GetFirstMinutes(Date1);  //后续算法
                 DateMin2 = GetLastMinutes(Date2);   //正序

                 return Math.Abs(DateMin1) + Math.Abs(DateMin2) + 600 * (DateDiff - 1);//
             }
             else //没超过一天
             {
                 return GetTodayMinutes(Date1, Date2);
             }
         }
         //当天的算法
         private static double GetTodayMinutes(DateTime Date1, DateTime Date2)
         {
             double d = 0;
             double FirstMinutes = Date1.Hour * 60 + Date1.Minute;
             double LastMiniutes = Date2.Hour * 60 + Date2.Minute;
             int[] Min = { 480, 720, 840, 1200 };

             if (Min[0] >= FirstMinutes)//修改
             {
                 if (Min[0] > LastMiniutes)
                     d = 0;
                 if (Min[1] >= LastMiniutes && LastMiniutes > Min[0])
                     d = LastMiniutes - Min[0];
                 if (Min[2] >= LastMiniutes && LastMiniutes > Min[1])
                     d = 240;
                 if (Min[3] >= LastMiniutes && LastMiniutes > Min[2])
                     d = LastMiniutes - Min[0] - 120;// 减去早上8小时 中间休息的几分钟  
                 if (LastMiniutes > Min[3]) //
                     d = 600; //全天
             }

             if (Min[1] >= FirstMinutes && FirstMinutes > Min[0])
             {
                 if (Min[0] > LastMiniutes)
                     d = 0;  //
                 if (Min[1] >= LastMiniutes && LastMiniutes > Min[0])
                     d = LastMiniutes - FirstMinutes;
                 if (Min[2] >= LastMiniutes && LastMiniutes > Min[1])
                     d = 720 - FirstMinutes;
                 if (Min[3] >= LastMiniutes && LastMiniutes > Min[2])
                     d = LastMiniutes - FirstMinutes - 120;
                 if (LastMiniutes > Min[3])
                     d = Min[3] - FirstMinutes - (Min[2] - Min[1]);
             }
             if (Min[2] >= FirstMinutes && FirstMinutes > Min[1])
             {
                 if (Min[0] > LastMiniutes)
                     d = 0;
                 if (Min[1] >= LastMiniutes && LastMiniutes > Min[0])
                     d = 0; //
                 if (Min[2] >= LastMiniutes && LastMiniutes > Min[1])
                     d = 0;
                 if (Min[3] >= LastMiniutes && LastMiniutes > Min[2])
                     d = LastMiniutes - Min[2];
                 if (LastMiniutes > Min[3])
                     d = Min[3] - Min[2];
             }
             if (Min[3] >= FirstMinutes && FirstMinutes > Min[2])
             {
                 if (Min[0] > LastMiniutes)
                     d = 0;
                 if (Min[1] >= LastMiniutes && LastMiniutes > Min[0])
                     d = 0;
                 if (Min[2] >= LastMiniutes && LastMiniutes > Min[1])
                     d = 0;
                 if (Min[3] >= LastMiniutes && LastMiniutes > Min[2])
                     d = LastMiniutes - FirstMinutes;
                 if (LastMiniutes > Min[3])
                     d = Min[3] - FirstMinutes;
             }
             if (FirstMinutes > Min[3])
             {
                 d = 0;
                 //if (Min[0] > LastMiniutes)
                 //    d = 0;
                 //if (Min[1] >= LastMiniutes > Min[0])
                 //    d = 0;
                 //if (Min[2] >= LastMiniutes > Min[1])
                 //    d = 0;
                 //if (Min[3] >= LastMiniutes > Min[2])
                 //    d = 0;
                 //if (LastMiniutes > Min[3])
                 //    d = 0;
             }
             return d;
         }

         private static double GetFirstMinutes(DateTime Date1)
         {
             double d_minite = 0;
             double TodayMinutes = Date1.Hour * 60 + Date1.Minute;

             if (TodayMinutes >= 480 && TodayMinutes <= 720) // 8:00-12:00
             {

                 d_minite = 720 - TodayMinutes + 360; //600 - (TodayMinutes - 480); //晚上 20点结束   
             }
             else
                 if (TodayMinutes > 720 && TodayMinutes <= 840) //12:00-14:00
                 {
                     d_minite = 1200 - 840; //12:00后都是 经历360分钟-14:00
                 }
                 else if (TodayMinutes > 840 && TodayMinutes <= 1200)//14:00-20:00
                 {
                     d_minite = 1200 - TodayMinutes;//TodayMinutes-840+4*60; //减去早上8小时 和 中午2小时
                 }
                 else if (TodayMinutes > 1200)
                 {
                     d_minite = 0;
                 }
                 else
                 {
                     d_minite = 600; //
                 }
             return d_minite;

         }

         private static double GetLastMinutes(DateTime Date1)
         {
             double d_minite = 0;

             double TodayMinutes = Date1.Hour * 60 + Date1.Minute;

             if (TodayMinutes >= 480 && TodayMinutes <= 720) //480 是 t[0] //早上 
             {
                 d_minite = TodayMinutes - 480; //早上8点 前的时间
             }
             else
                 if (TodayMinutes > 720 && TodayMinutes <= 840)//中午 
                 {
                     d_minite = 240; //4*60早上的耗时 4小时
                 }
                 else if (TodayMinutes > 840 && TodayMinutes <= 1200)
                 {
                     d_minite = TodayMinutes - 600; //到的耗时20:00
                 }
                 else if (TodayMinutes > 1200)
                 {
                     d_minite = 600;
                 }
                 else
                 {
                     d_minite = 0; //凌晨
                 }
             return d_minite;

         }
    }
}
