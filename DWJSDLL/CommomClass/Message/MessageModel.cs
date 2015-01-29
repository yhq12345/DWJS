using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonClass.Message
{
    /// <summary>
    /// 消息提示实体类(用于json属性)
    /// </summary>
    public class MessageModel
    {
        /// <summary>
        /// 提示标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 消息提示时间
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// 消息提示内容
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 消息详细信息
        /// </summary>
        public string MessageMore { get; set; }

        /// <summary>
        /// 消息发生页地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 消息页来源地址(reffer)
        /// </summary>
        public string FromUrl { get; set; }

        /// <summary>
        /// 是否成功与失败的标识
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark { get; set; }


    }
}
