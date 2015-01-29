﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonClass.DataHandler
{
    /// <summary>
    /// 要导出的字段类
    /// </summary>
    public class OutPutField
    {
        /// <summary>
        /// 该字段的原始名
        /// </summary>
        public string oldName { get; set; }
        /// <summary>
        /// 导出后，该字段在EXCEL中的显示名
        /// </summary>
        public string newName { get; set; }
    }
}
