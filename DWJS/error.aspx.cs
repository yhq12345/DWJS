﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Web
{
    public partial class error : System.Web.UI.Page
    {
        public string errorMsg = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["errorMsg"] != null)
            {
                errorMsg =System.Web.HttpContext.Current.Server.UrlDecode( Request["errorMsg"].ToString());
            }
        }
        
    }
}
