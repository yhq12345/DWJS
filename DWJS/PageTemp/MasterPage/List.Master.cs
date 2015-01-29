using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WZGJGL.PageTemp.MasterPage
{
    public partial class List : System.Web.UI.MasterPage
    {
        protected PageBase basePage = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.basePage = this.Page as PageBase;
        }
    }
}