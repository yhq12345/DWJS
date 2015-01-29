using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonClass.Javascript
{
    /// <summary>
    /// artDialog类
    /// </summary>
    public class Dialog
    {
        /// <summary>
        /// 向父窗体弹出
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        /// <param name="isParent">true:在父窗体打开 false:在本窗体</param>
        public static void Alert(System.Web.UI.Page page,string msg,bool isParent)
        {
            Jscript.AddBodyEnd(page,string.Format("{{0}}art.dialog({{content:'{1}'}})",isParent?"parent.":"",msg));
        }
        /// <summary>
        /// 向窗体tips
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        public static void Tips(System.Web.UI.Page page, string msg)
        {
            Jscript.AddBodyEnd(page, string.Format("art.Dialog.tips('{0}');",msg));
        }
        /// <summary>
        /// 向窗体tips并刷新来源窗体
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        public static void TipsAndRefresh(System.Web.UI.Page page, string msg,int time)
        {
            Jscript.AddBodyEnd(page, string.Format(@"art.dialog.tips('{0}');setTimeout(function () {{ art.dialog.open.origin.location.reload(); }}, {1});", msg,time));
        }
        /// <summary>
        /// 刷新弹窗来源页面
        /// </summary>
        public static void Refresh(System.Web.UI.Page page)
        {
            Jscript.AddBodyEnd(page, string.Format("art.dialog.open.origin.location.reload();"));
        }
    }
}
