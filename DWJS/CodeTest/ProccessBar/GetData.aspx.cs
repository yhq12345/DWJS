using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Web.SessionState;

namespace DWKS.CodeTest.ProccessBar
{
    public partial class GetData : System.Web.UI.Page 
    {
        public object SessionDataALL = null;

        [Serializable]
        public class MyProcessData
        {
            public string Content;
            public int Num;
            /// <summary>
            /// 0-100
            /// </summary>
            public decimal ProcessNum;
        }
        public MyProcessData x = new MyProcessData();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["Pro"] == "ALL")
            {
                Thread t = new Thread(new ThreadStart(GetTestJosn));
                t.Start();
                
                Response.Write(x.Content);

            }
            if (Request.Params["Pro"] == "Watch")
            {
                x = (MyProcessData)Session["ProNum"];

                Response.Write("{\"content\":\"" + x.Num.ToString() + "\",\"ProcessNum\":\"" + x.ProcessNum + "\" }");
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void GetTestJosn()
        {

            string _content = "[";
            for (int i = 0; i < 10000; i++)
            {
                _content += @"{""Pro"":100,""Pro1"":50,""Pro2"":51}";
                if (i < 10000 - 1)
                {
                    _content += ",";
                }
                x.Content = _content;
                x.Num = i;
                x.ProcessNum = Math.Round((decimal)i / 10000 , 2)*100;
                Session["ProNum"] = x;
            }
            _content += "]";
        }
    }
}