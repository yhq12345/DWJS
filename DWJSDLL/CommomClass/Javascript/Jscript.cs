﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
namespace CommonClass.Javascript
{
    ///<summary>
    /// 一些常用的Js调用
    /// </summary>
    public class Jscript
    {
        #region 输出JS代码
        /// <summary>
        /// 输出JS代码
        /// </summary>
        /// <param name="js"></param>
        public static void WriteJS(string code)
        {
            string js = @"<script type='text/javascript'>" + code + "</script>";
            HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region  弹出Javascript小窗口
        /// <summary>
        /// 弹出Javascript小窗口
        /// </summary>
        /// <param name="js">窗口信息</param>
        public static void Alert(string message)
        {
            string js = @"<script type='text/javascript'>alert('" + message.Replace("'", "\"") + "');</script>";
            HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 弹出消息框并且转向到新的URL
        /// <summary>
        /// 弹出消息框并且转向到新的URL
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="toURL">连接地址</param>
        public static void AlertAndRedirect(string message, string toURL)
        {
            string js = "<script language=javascript>alert('{0}');window.location.replace('{1}')</script>";
            HttpContext.Current.Response.Write(string.Format(js, message, toURL));
        }
        #endregion

        #region 回到历史页面
        /// <summary>
        /// 回到历史页面
        /// </summary>
        /// <param name="value">-1/1</param>
        public static void GoHistory(int value)
        {
            string js = @"<script type='text/javascript'>history.go({0});</script>";
            HttpContext.Current.Response.Write(string.Format(js, value));
        }
        #endregion

        #region 关闭当前窗口
        /// <summary>
        /// 关闭当前窗口
        /// </summary>
        public static void CloseWindow()
        {
            string js = @"<script type='text/javascript'>parent.opener=null;window.close();</script>";
            HttpContext.Current.Response.Write(js);
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 刷新父窗口
        /// <summary>
        /// 刷新父窗口
        /// </summary>
        public static void RefreshParent(string url)
        {
            string js = @"<script type='text/javascript'>window.opener.location.href='" + url + "';window.close();</script>";
            HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 刷新打开窗口
        /// <summary>
        /// 刷新打开窗口
        /// </summary>
        public static void RefreshOpener()
        {
            string js = @"<script type='text/javascript'>opener.location.reload();</script>";
            HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 打开指定大小的新窗体
        /// <summary>
        /// 打开指定大小的新窗体
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="width">宽</param>
        /// <param name="heigth">高</param>
        /// <param name="top">头位置</param>
        /// <param name="left">左位置</param>
        public static void OpenWebFormSize(string url, int width, int heigth, int top, int left)
        {
            string js = @"<script type='text/javascript'>window.open('" + url + @"','','height=" + heigth + ",width=" + width + ",top=" + top + ",left=" + left + ",location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');</script>";
            HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 打开指定大小的新窗体
        /// <summary>
        /// 打开指定大小的新窗体
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="width">宽</param>
        /// <param name="heigth">高</param>
        /// <param name="top">头位置</param>
        /// <param name="left">左位置</param>
        public static void OpenWebFormSize(string url)
        {
            string js = @"<script type='text/javascript'>window.open('" + url + @"');</script>";
            HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 转向Url制定的页面
        /// <summary>
        /// 转向Url制定的页面
        /// </summary>
        /// <param name="url">连接地址</param>
        public static void JavascriptLocationHref(string url)
        {
            string js = @"<script type='text/javascript'>window.location.replace('{0}');</script>";
            js = string.Format(js, url);
            HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 打开指定大小位置的模式对话框
        /// <summary>
        /// 打开指定大小位置的模式对话框
        /// </summary>
        /// <param name="webFormUrl">连接地址</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <param name="top">距离上位置</param>
        /// <param name="left">距离左位置</param>
        public static void ShowModalDialogWindow(string webFormUrl, int width, int height, int top, int left)
        {
            string features = "dialogWidth:" + width.ToString() + "px"
                + ";dialogHeight:" + height.ToString() + "px"
                + ";dialogLeft:" + left.ToString() + "px"
                + ";dialogTop:" + top.ToString() + "px"
                + ";center:yes;help=no;resizable:no;status:no;scroll=yes";
            ShowModalDialogWindow(webFormUrl, features);
        }
        #endregion

        #region 打开指定大小位置的模式对话框
        /// <summary>
        /// 打开指定大小位置的模式对话框
        /// </summary>
        /// <param name="webFormUrl"></param>
        /// <param name="features"></param>
        public static void ShowModalDialogWindow(string webFormUrl, string features)
        {
            string js = ShowModalDialogJavascript(webFormUrl, features);
            HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 打开指定大小位置的模式对话框
        /// <summary>
        /// 打开指定大小位置的模式对话框
        /// </summary>
        /// <param name="webFormUrl">连接地址</param>
        /// <param name="features">用来描述对话框的外观等信息，可以使用以下的一个或几个，用分号“;”隔开
        /// 1.   dialogHeight:   对话框高度，不小于100px
        /// 2.   dialogWidth:   对话框宽度。
        /// 3.   dialogLeft:    离屏幕左的距离。
        /// 4.   dialogTop:    离屏幕上的距离。
        /// 5.   center:         { yes | no | 1 | 0 } ：             是否居中，默认yes，但仍可以指定高度和宽度。
        /// 6.   help:            {yes | no | 1 | 0 }：               是否显示帮助按钮，默认yes。
        /// 7.   resizable:      {yes | no | 1 | 0 } [IE5+]：    是否可被改变大小。默认no。
        /// 8.   status:         {yes | no | 1 | 0 } [IE5+]：     是否显示状态栏。默认为yes[ Modeless]或no[Modal]。
        /// 9.   scroll:           { yes | no | 1 | 0 | on | off }：是否显示滚动条。默认为yes。
        ///    下面几个属性是用在HTA中的，在一般的网页中一般不使用。
        /// 10.  dialogHide:{ yes | no | 1 | 0 | on | off }：在打印或者打印预览时对话框是否隐藏。默认为no。
        /// 11.   edge:{ sunken | raised }：指明对话框的边框样式。默认为raised。
        /// 12.   unadorned:{ yes | no | 1 | 0 | on | off }：默认为no。
        /// </param>
        /// <returns></returns>
        public static string ShowModalDialogJavascript(string webFormUrl, string features)
        {
            string js = @"<script type='text/javascript'>showModalDialog('" + webFormUrl + "','','" + features + "');</script>";
            return js;
        }
        #endregion

        #region  在body结尾输出js
        /// <summary>
        /// 在body结尾输出js(嵌入到ASP.NET页面的底部,恰好位于关闭元素 /form的前面)
        /// </summary>
        public static void AddBodyEnd(System.Web.UI.Page page, String js)
        {
            //方法所呈现的脚本块会在页面完成加载之时、但页面的客户端 onload 事件引发之前执行。启动脚本块位于呈现的 ASP.NET 页面底部的 </form> 标记之前。
            page.ClientScript.RegisterStartupScript(page.GetType(), Guid.NewGuid().ToString(), @"<script type='text/javascript' >" + js + "</script>");
        }
        #endregion

        #region  在body开始处输出js
        /// <summary>
        /// 在body开始处输出js(将 JavaScript 嵌入到页面中开始元素 form 的紧后面)
        /// </summary>
        public static void AddBodyStart(System.Web.UI.Page page, String js)
        {
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), Guid.NewGuid().ToString(), @"<script type='text/javascript' >" + js + "</script>");
        }
        #endregion

        #region 控件点击 消息确认提示框
        /// <summary>
        /// 控件点击 消息确认提示框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void ShowConfirm(System.Web.UI.WebControls.WebControl Control, string msg)
        {
            Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
        }
        #endregion

        #region 显示消息提示对话框，并进行页面跳转
        /// <summary>
        /// 显示消息提示对话框，并进行页面跳转
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标URL</param>
        public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script type='text/javascript' defer>");
            Builder.AppendFormat("alert('{0}');", msg);
            Builder.AppendFormat("top.location.href='{0}'", url);
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), Guid.NewGuid().ToString(), Builder.ToString());
        }
        #endregion
    }
}