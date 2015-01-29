using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace DWKS
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(Server.MapPath("~/Config/Log4NetConfig.xml"));
            log4net.Config.XmlConfigurator.ConfigureAndWatch(fileInfo);
            CommonClass.Message.Log.LogInfo = log4net.LogManager.GetLogger("LoggerConfig");
            PageBase.log.Info("应用程序启动开始！");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            string msg = string.Format("Url:{0}\r\nReferUrl:{1}\r\n", Request.Url, Request.UrlReferrer);
            PageBase.log.Error(msg, HttpContext.Current.Error); 
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            PageBase.log.Info("应用池正在准备重启...");
            //解决应用池回收问题
            System.Threading.Thread.Sleep(1000);
            //string strUrl = CommonClass.XML.ConfigClass.GetConfigString("webDomain");
            //System.Net.HttpWebRequest _HttpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(strUrl);
            //System.Net.HttpWebResponse _HttpWebResponse = (System.Net.HttpWebResponse)_HttpWebRequest.GetResponse();
            //System.IO.Stream _Stream = _HttpWebResponse.GetResponseStream();//得到回写的字节流

            PageBase.log.Info("应用程序启动结束！");
        }
    }
}