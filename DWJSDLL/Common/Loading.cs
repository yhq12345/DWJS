using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Eastcom.Common
{
    public  class Loading
    {
        private Loading()
        { }


        #region "页面加载中效果"
/// <summary>
  /// 页面加载中效果 <body onload="remove_loading();"
/// </summary>
public static void initJavascript()
{
    HttpContext.Current.Response.Write(" <script language=\"JavaScript\" type=\"text/javascript\">");
HttpContext.Current.Response.Write("var t_id = setInterval(animate,20);\n");
HttpContext.Current.Response.Write("var pos=0;var dir=2;var len=0;\n");
HttpContext.Current.Response.Write("function animate(){");
HttpContext.Current.Response.Write("var elem = document.getElementById('progress');\n");
HttpContext.Current.Response.Write("if(elem != null) {\n");
HttpContext.Current.Response.Write("if (pos==0) len += dir;");
HttpContext.Current.Response.Write("if (len>32 || pos>79) pos += dir;\n");
HttpContext.Current.Response.Write("if (pos>79) len -= dir;\n");
HttpContext.Current.Response.Write(" if (pos>79 && len==0) pos=0;\n");
HttpContext.Current.Response.Write("elem.style.left = pos;\n");
HttpContext.Current.Response.Write("elem.style.width = len;\n");
HttpContext.Current.Response.Write("}}\n");
HttpContext.Current.Response.Write("function remove_loading() {\n");
HttpContext.Current.Response.Write(" this.clearInterval(t_id);");
HttpContext.Current.Response.Write("var targelem = document.getElementById('loader_container');\n");
HttpContext.Current.Response.Write("targelem.style.display='none';\n");
HttpContext.Current.Response.Write("targelem.style.visibility='hidden';\n");
HttpContext.Current.Response.Write("}\n");
HttpContext.Current.Response.Write("</script>\n");
HttpContext.Current.Response.Write("<style>");
HttpContext.Current.Response.Write("#loader_container {text-align:center; position:absolute; top:40%; width:100%; left: 0;}");
HttpContext.Current.Response.Write("#loader {font-family:Tahoma, Helvetica, sans; font-size:11.5px; color:#000000; background-color:#FFFFFF; padding:10px 0 16px 0; margin:0 auto; display:block; width:130px; border:1px solid #5a667b; text-align:left; z-index:2;}");
HttpContext.Current.Response.Write("#progress {height:5px; font-size:1px; width:1px; position:relative; top:1px; left:0px; background-color:#8894a8;}");
HttpContext.Current.Response.Write("#loader_bg {background-color:#e4e7eb; position:relative; top:8px; left:8px; height:7px; width:113px; font-size:1px;}");
HttpContext.Current.Response.Write("</style>\n");
HttpContext.Current.Response.Write("<div id=loader_container>\n");
HttpContext.Current.Response.Write("<div id=loader>\n");
HttpContext.Current.Response.Write("<div align=center>页面正在加载中 ...</div>\n");
HttpContext.Current.Response.Write("<div id=loader_bg><div id=progress> </div></div>\n");
HttpContext.Current.Response.Write("</div></div>\n");
//HttpContext.Current.Response.Flush();
}
#endregion
    }
}
