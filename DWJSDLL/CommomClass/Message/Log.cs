using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using LitJson;

namespace CommonClass.Message
{
    /// <summary>
    /// 消息日志
    /// </summary>
    public class Log
    {
        /// <summary>
        /// 信息输出处理类型枚举
        /// </summary>
        [FlagsAttribute]
        public enum LogTypeEnum
        {
            /// <summary>
            /// 需要log4Net来记录错误信息
            /// </summary>
            Log4Net = 1,
            /// <summary>
            /// 输出为json形式的信息(用于ajax请求)
            /// </summary>
            Json = 2
        }

        /// <summary>
        /// 消息记录类型
        /// </summary>
        public static LogTypeEnum LogType = LogTypeEnum.Log4Net | LogTypeEnum.Json;

        /// <summary>
        /// 是否为简易版消息
        /// 在异常处理消息提示中，若为true，则不显示堆栈异常详情
        /// </summary>
        public static bool IsSimple = true;

        /// <summary>
        /// 以json方式提示的属性名,它的下面有多个成员
        /// <remarks>
        /// 如：data.XCLXXXXX.Message
        /// </remarks>
        /// </summary>
        public static readonly string JsonMessageName =string.Format("XCL{0}", Guid.NewGuid().ToString("N"));

        /// <summary>
        /// log4net实例，需要初始化其配置信息
        /// </summary>
        public static log4net.ILog LogInfo { get; set; }

        /// <summary>
        /// 输出消息（json）
        /// </summary>
        public  static void WriteMessage(MessageModel model)
        {
            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            string msg = CommonClass.StringHander.StringUtil.UnicodeDecode(JsonMapper.ToJson(model));
            context.Response.Write(string.Format(@"{{ ""{0}"":{1} }}", Log.JsonMessageName, msg));
            context.Response.End();
        }

        /// <summary>
        /// 输出消息（json）
        /// </summary>
        public static void WriteMessage(string message)
        {
            WriteMessage(new MessageModel() { 
                Date=DateTime.Now,
                IsSuccess=false,
                Message=message,
                Title="系统提示",
                Remark="自定义输出信息（直接输出）"
            });
        }

        public static void WriteMessage<T>(T model) where T:class
        {
            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            string msg = JsonMapper.ToJson(model);//CommonClass.StringHander.StringUtil.UnicodeDecode(JsonMapper.ToJson(model));
            //context.Response.Write(string.Format(@"{{ ""{0}"":{1} }}", Log.JsonMessageName, msg));
            context.Response.Write(string.Format(@"{0}" ,msg));
            
            context.Response.End();
        }

    }
}
