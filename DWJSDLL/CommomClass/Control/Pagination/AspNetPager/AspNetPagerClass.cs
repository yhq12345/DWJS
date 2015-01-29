using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonClass.Control.Pagination.IPaginations;

namespace CommonClass.Control.Pagination.AspNetPager
{
    /// <summary>
    /// AspNetPager分页
    /// </summary>
    public class AspNetPagerClass : PaginationBase, IPagination
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pager">当前分页控件</param>
        public AspNetPagerClass(Wuqi.Webdiyer.AspNetPager pager)
        {
            this.Pager = pager;
        }

        /// <summary>
        /// 当前分页控件
        /// </summary>
        public Wuqi.Webdiyer.AspNetPager Pager { get; set; }

        /// <summary>
        /// 分页控件初始化
        /// </summary>
        public void InitPager()
        {
            this.Pager.PageSize = this.PageSize;
            this.Pager.RecordCount = this.RecordCount;
            this.Pager.CurrentPageIndex = this.PageIndex;
            this.Pager.CustomInfoHTML = @"第<font style=""color:#f00;font-weight:bolder;"">%CurrentPageIndex%</font>/%PageCount%页 每页最多%PageSize%条，共<font style=""font-weight:bolder;"">%RecordCount%</font>条";
            this.Pager.CustomInfoClass = "pagerInfoClass";
            this.Pager.NumericButtonCount = 3;
            this.Pager.SubmitButtonClass = "pagerSubmitBtnClass";
            this.Pager.ShowCustomInfoSection = Wuqi.Webdiyer.ShowCustomInfoSection.Left;
            this.Pager.FirstPageText = "首页";
            this.Pager.PrevPageText = "上一页";
            this.Pager.NextPageText = "下一页";
            this.Pager.LastPageText = "尾页";
            this.Pager.UrlPaging = true;
            this.Pager.SubmitButtonText = "跳转>>";
            this.Pager.AlwaysShow = true;
            this.Pager.ShowPageIndexBox = Wuqi.Webdiyer.ShowPageIndexBox.Always;
            this.Pager.LayoutType = Wuqi.Webdiyer.LayoutType.Div;
            this.Pager.PagingButtonsClass = "pagerBtn";
            this.Pager.CurrentPageButtonClass = "pagerCurrentBtn";
            this.Pager.PageIndexBoxClass = "pagerInputBox";
        }
    }
}
