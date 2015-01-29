using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections.Specialized;

namespace CommonClass.StringHander
{
    /// <summary>
    /// form表单相关
    /// </summary>
    public class FormHelper
    {
        #region 表单参数获取相关
        /// <summary>
        /// 根据表单控件的name前缀，获取它的value数组
        /// 注意：请保证已存在的name值之间没有包含关系（如：txtName和txtNameFirst），否则数据会紊乱！
        /// </summary>
        /// <param name="preName">name值的前缀</param>
        public static string[] GetFromParamsValudByPre(string preName)
        {
            HttpContext context = HttpContext.Current;
            IList<string> str = new List<string>();
            if (!string.IsNullOrEmpty(preName))
            {
                NameValueCollection ps = context.Request.Params;
                foreach (var m in ps.AllKeys)
                {
                    if (m.IndexOf(preName) >= 0)
                    {
                        str.Add(ps[m]);
                    }
                }
            }
            return str.ToArray();
        }
        #endregion
    }
}
