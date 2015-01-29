using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTSmanagementInfo
{
    public partial class Index : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission = false;
            if (!IsPostBack)
            {
                Ini_Data();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected void Ini_Data()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="GetValue"></param>
        /// <returns></returns>
        public bool GetBoolArray(bool[] GetValue)
        {
            bool ReturnValue = false;
            if (GetValue != null)
            {
                for (int i = 0; i < GetValue.Length; i++)
                {
                    ReturnValue = ReturnValue || GetValue[i];
                }
            }
            return ReturnValue;
        }

    }
}