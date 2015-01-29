using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonClass.Control.Pagination
{
    /// <summary>
    /// 分页基类
    /// </summary>
    public class PaginationBase
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public PaginationBase() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="recordCount">记录总数</param>
        /// <param name="pageSize">每页最多显示的数量</param>
        /// <param name="pageIndex">当前为第几页</param>
        public PaginationBase(int recordCount, int pageSize, int pageIndex)
        {
            this._recordCount = recordCount;
            this._pageSize = pageSize;
            this._pageIndex = pageIndex;
        }

        private int _recordCount = 0;
        /// <summary>
        /// 记录总数
        /// </summary>
        public int RecordCount
        {
            get { return this._recordCount; }
            set { this._recordCount = value; }
        }

        private int _pageSize = 15;
        /// <summary>
        /// 每页最多显示的数量
        /// </summary>
        public int PageSize
        {
            get { return this._pageSize; }
            set { this._pageSize = value; }
        }

        private int _pageIndex = 1;
        /// <summary>
        /// 当前为第几页
        /// </summary>
        public int PageIndex
        {
            get { return this._pageIndex; }
            set { this._pageIndex = value; }
        }
    }
}
