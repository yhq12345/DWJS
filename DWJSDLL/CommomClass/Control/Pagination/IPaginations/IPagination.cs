using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonClass.Control.Pagination.IPaginations
{
    /// <summary>
    /// 分页接口
    /// </summary>
    public interface IPagination
    {
        /// <summary>
        /// 分页初始化
        /// </summary>
        void InitPager();
    }
}
