using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonClass.Message.Error
{
    /// <summary>
    /// 自定义Exception类
    /// </summary>
    [Serializable]
    public class BaseException : Exception
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public BaseException() : base() { }

        /// <summary>
        /// 构造函数，参考Exception的构造函数
        /// </summary>
        public BaseException(string message) : base(message) { }

        /// <summary>
        /// 构造函数，参考Exception的构造函数
        /// </summary>
        public BaseException(string message, Exception innerException) : base(message, innerException) { }
    }
}
