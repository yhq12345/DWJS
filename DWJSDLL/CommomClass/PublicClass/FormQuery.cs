using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonClass.PublicClass
{
    /// <summary>
    /// 表单查询类
    /// </summary>
    public class FormQuery
    {
        public FormQuery(string Name, bool IsNumber, string Symbol, string Value)
        {
            this.Name = Name;
            this.IsNumber = IsNumber;
            this.Symbol = Symbol;
            this.Value = Value;
        }

        /// <summary>
        /// 字段名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// true:为数值型（即无需加引号）
        /// </summary>
        public bool IsNumber { get; set; }

        /// <summary>
        /// 条件符号
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// 查询输入的值
        /// </summary>
        public string Value { get; set; }
    }
}
