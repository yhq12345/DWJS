using System;
using System.Net;
using System.Text;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;

namespace Eastcom
{
    public class SMSRequisition
    {
        public SMSRequisition()
        {

        }

        public CookieCollection Cookies = new CookieCollection();

        public string ip { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string mobile { get; set; }
        public string content { get; set; }
        public CookieContainer cookieContainer = new CookieContainer();
        public string Cookiesstr { get; set; }

      
        /// <summary>
        /// 初始化函数
        /// </summary>
        /// <param name="ip">10.70.85.70(内网) 211.140.1.195(外网暂时不能用)</param>
        /// <param name="username">IMEP登录账号</param>
        /// <param name="password">IMEP登录密码</param>
        /// <param name="mobile">接收手机号</param>
        /// <param name="content">发送内容</param>
        public SMSRequisition(string ip, string username, string password, string mobile, string content)
        {
            this.ip = "http://" + ip;
            this.username = username;
            this.password = password;
            this.mobile = mobile;
            this.content = content;
        }
        /// <summary>
        /// SendToImep
        /// </summary>
        /// <returns></returns>
        public string BuildDataUrl()
        {
            return string.Concat(new object[] { "accountname=&account=&mobile=", mobile, "&content=", HttpUtility.UrlEncode(content, Encoding.Default), "&send=%B7%A2+%CB%CD" });
        }
        /// <summary>
        /// 发送短信的方法（主要的）
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public string SubmitData(out string msg)
        {
            msg = string.Empty;
            try
            {
                //if (!NewLoginIn())
                //{
                //    return "fail login";
                //}
                if (!NewLoginIn())
                {
                    return "fail login";
                };

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ip + "/frameweb/publish/sms/sms.jsp");
                request.CookieContainer = new CookieContainer(1);
                request.CookieContainer.Add(this.Cookies[0]); //request.CookieContainer.Add(new CookieCollection());

                request.Method = "POST";
                request.AllowAutoRedirect = true;
                request.Referer = ip + "/frameweb/publish/sms/sms.jsp";
                request.ContentType = "application/x-www-form-urlencoded";
                string s = this.BuildDataUrl();
                byte[] bytes = Encoding.GetEncoding("gbk").GetBytes(s);
                request.ContentLength = bytes.Length;

                request.GetRequestStream().Write(bytes, 0, bytes.Length);
                WebResponse response = (HttpWebResponse)request.GetResponse();
                msg = HttpUtility.HtmlDecode(new StreamReader(response.GetResponseStream()).ReadToEnd());
                response.Close();
                return "success";
            }
            catch (Exception ex)
            {
                return "fail" + ex.Message;
            }
        }
        //public bool NewLoginIn()
        //{
        //    try
        //    {
        //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ip);
        //        request.AllowAutoRedirect = false;
        //        request.CookieContainer = new CookieContainer(1);
        //        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //        if (response.Cookies.Count != 0)
        //        {
        //            this.Cookies.Add(response.Cookies[0]);
        //        }

        //        string result = HttpUtility.HtmlDecode(new StreamReader(response.GetResponseStream()).ReadToEnd());
        //        response.Close();

        //        string newurl = Regex.Match(result, "href=\"(.*?)\"").Groups[1].Value;
        //        newurl = newurl.Replace("&#59;", "?");

        //        request = (HttpWebRequest)WebRequest.Create(newurl);
        //        response = (HttpWebResponse)request.GetResponse();
        //        result = HttpUtility.HtmlDecode(new StreamReader(response.GetResponseStream()).ReadToEnd());
        //        response.Close();

        //        request = (HttpWebRequest)WebRequest.Create(ip + "/frameweb/j_security_check");
        //        request.CookieContainer = new CookieContainer(1);
        //        request.Method = "POST";
        //        request.AllowAutoRedirect = true;
        //        request.CookieContainer.Add(this.Cookies[0]);

        //        string s = "j_username=" + username + "&j_password=" + password + "&ip=10.74.21.86&force=on&imageField.x=23&imageField.y=10";

        //        byte[] bytes = Encoding.Default.GetBytes(s);
        //        request.ContentLength = bytes.Length;
        //        request.ContentType = "application/x-www-form-urlencoded";
        //        request.GetRequestStream().Write(bytes, 0, bytes.Length);
        //        response = (HttpWebResponse)request.GetResponse();
        //        string input = HttpUtility.HtmlDecode(new StreamReader(response.GetResponseStream()).ReadToEnd());
        //        response.Close();
        //        request = (HttpWebRequest)WebRequest.Create(ip + "/frameweb/proxyLogin.jsp");
        //        response = (HttpWebResponse)request.GetResponse();
        //        result = HttpUtility.HtmlDecode(new StreamReader(response.GetResponseStream()).ReadToEnd());
        //        response.Close();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
        /// <summary>
        /// 登录Imep
        /// </summary>
        protected bool NewLoginIn()
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            string gethost = string.Empty;
            CookieContainer cc = new CookieContainer();//cookieContainer
            //string Cookiesstr = string.Empty;
            try
            {
                //第一次POST请求
                string postdata = "j_username=" + username + "&j_password=" + password + "&ip=10.74.21.86&&force=on&imageField.x=13&imageField.y=12";
                string LoginUrl = "http://10.70.85.70/frameweb/j_security_check";//BaseUrl + "/frameweb/j_security_check";
                request = (HttpWebRequest)WebRequest.Create(LoginUrl);//实例化web访问类
                request.Method = "POST";//数据提交方式为POST
                //模拟头
                request.ContentType = "application/x-www-form-urlencoded";
                byte[] postdatabytes = Encoding.UTF8.GetBytes(postdata);
                request.ContentLength = postdatabytes.Length;
                request.AllowAutoRedirect = false;
                request.CookieContainer = cookieContainer;
                request.KeepAlive = true;
                //提交请求
                Stream stream;
                stream = request.GetRequestStream();
                stream.Write(postdatabytes, 0, postdatabytes.Length);
                stream.Close();
                //接收响应
                response = (HttpWebResponse)request.GetResponse();
                //保存返回cookie
                response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);
                Cookies = response.Cookies;//cook
                string strcrook = request.CookieContainer.GetCookieHeader(request.RequestUri);
                Cookiesstr = strcrook;
                //取第一次GET跳转地址
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string content = sr.ReadToEnd();
                response.Close();
                string[] substr = content.Split(new char[] { '"' });
                gethost = substr[1];
            }
            catch (Exception)
            {
                return false;
                //第一次POST出错；
             
            }
            try
            {
                request = (HttpWebRequest)WebRequest.Create("http://10.70.85.70/frameweb");
                request.Method = "GET";
                request.KeepAlive = true;
                request.Headers.Add("Cookie:" + Cookiesstr);
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = false; 
                response = (HttpWebResponse)request.GetResponse();
                //设置cookie
                Cookiesstr = request.CookieContainer.GetCookieHeader(request.RequestUri);
                //取再次跳转链接
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string ss = sr.ReadToEnd();
                string[] substr = ss.Split(new char[] { '"' });
                gethost = substr[1];
                request.Abort();
                sr.Close();
                response.Close();   
            }
            catch (Exception)
            {
                //第一次GET出错
            }
            try
            {
                //第二次GET请求
                request = (HttpWebRequest)WebRequest.Create("http://10.70.85.70/frameweb/");
                request.Method = "GET";
                request.KeepAlive = true;
                request.Headers.Add("Cookie:" + Cookiesstr);
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = false;
                response = (HttpWebResponse)request.GetResponse();
                //设置cookie
                Cookiesstr = request.CookieContainer.GetCookieHeader(request.RequestUri);
                request.Abort();
                response.Close();
            }
            catch (Exception)
            {
                //第二次GET出错
            }
            return true;
        }
    }
}
