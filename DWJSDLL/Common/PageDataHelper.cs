using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Reflection;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Eastcom.Common
{
    public class PageDataHelper
    {
        #region 反射页面控件获取Model

        /// <summary>
        /// 通过搜索页面对应控件来构造Model对象(要求控件必须以“_Model的属性名”来命名(如：_Name)，并大小写一致)
        /// </summary>
        /// <param name="model">要构造的Model对象()</param>
        /// <param name="parentControl">控件的容器(比如Page或者Master的站位控件)</param>
        /// <returns>返回参数里model</returns>
        public static object GetModel(object model, Control parentControl)
        {
            Type t = model.GetType();
            PropertyInfo[] pi = t.GetProperties();
            foreach (PropertyInfo p in pi)
            {
                SetControlValueToModel(model, p, parentControl);
            }
            return model;
        }


        /// <summary>
        /// 把页面控件上的值赋值给Model对象(要求控件必须以“_Model的属性名”来命名(如：_Name)，并大小写一致)
        /// </summary>
        /// <param name="model">要赋值的Model对象</param>
        /// <param name="p">某个属性</param>
        /// <param name="parentControl">控件的容器(比如Page或者Master的站位控件)</param>
        private static void SetControlValueToModel(object model, PropertyInfo p, Control parentControl)
        {
            Control control = parentControl.FindControl("_" + p.Name);
            if (control != null)
            {
                Type t_c = control.GetType();
                switch (t_c.FullName)
                {
                    case "System.Web.UI.WebControls.TextBox": SetValue(model, p, ((TextBox)control).Text); break;
                    case "System.Web.UI.WebControls.Label": SetValue(model, p, ((Label)control).Text); break;
                    case "System.Web.UI.WebControls.CheckBox": SetValue(model, p, ((CheckBox)control).Checked); break;
                    case "System.Web.UI.WebControls.Image": SetValue(model, p, ((Image)control).ImageUrl); break;
                    case "System.Web.UI.WebControls.DropDownList": SetValue(model, p, ((DropDownList)control).SelectedValue); break;
                    case "System.Web.UI.WebControls.RadioButtonList": SetValue(model, p, ((RadioButtonList)control).SelectedValue); break;
                    case "System.Web.UI.WebControls.HiddenField": SetValue(model, p, ((HiddenField)control).Value); break;
                    case "System.Web.UI.HtmlControls.HtmlInputHidden": SetValue(model, p, ((HtmlInputHidden)control).Value); break;
                    default: break;
                }
            }
        }


        /// <summary>
        /// 把值赋给指定Model对象指定属性上
        /// </summary>
        /// <param name="model">需要赋值的Model对象</param>
        /// <param name="p">某个属性</param>
        /// <param name="value">要赋给Model的属性的值</param>
        private static void SetValue(object model, PropertyInfo p, object value)
        {
            p.SetValue(model, Convert.ChangeType(value, p.PropertyType), null);
        }


        #endregion

        #region 反射Model绑定页面控件


        /// <summary>
        /// 比较两个实例的成员的改动 
        /// </summary>
        /// <param name="oldModel"></param>
        /// <param name="newModel"></param>
        /// <returns></returns>
        public static bool Complare(object oldModel, object newModel)
        {
            Type oldt = oldModel.GetType();//oldModel.GetType();
            Type newt = newModel.GetType();

            if (oldt == newt)
            {
                PropertyInfo[] pi = oldt.GetProperties();

                foreach (PropertyInfo p in pi)
                {
                    object oldobj = p.GetValue(oldModel, null);
                    object newobj = p.GetValue(newModel, null);
                    if (oldobj == null)
                    {
                        oldobj = "";
                    }
                    if (newobj == null)
                    {
                        newobj = "";
                    }
                    if (oldobj.ToString() != newobj.ToString())
                    {
                        return false;
                    }
                }
                return true;
            }
            else
                return false;
        }


        /// <summary>
        /// 绑定Model的值到页面上对应控件(要求控件必须以“_Model的属性名”来命名(如：_Name)，并大小写一致)
        /// </summary>
        /// <param name="model">赋好值的Model</param>
        /// <param name="parentControl">控件的容器(比如Page或者Master的站位控件)</param>
        public static void BindControls(object model, Control parentControl)
        {
            if (model != null)
            {
                Type t = model.GetType();
                PropertyInfo[] pi = t.GetProperties();
                foreach (PropertyInfo p in pi)
                {
                    SetModelValueToControl(model, p, parentControl);
                }
            }
        }


        /// <summary>
        /// 把Model的值赋给页面上的控件(目前只针对Web)
        /// </summary>
        /// <param name="model">赋好值的Model</param>
        /// <param name="p">Model的某个属性</param>
        /// <param name="parentControl">控件的容器(比如Page或者Master的站位控件)</param>
        private static void SetModelValueToControl(object model, PropertyInfo p, Control parentControl)
        {
            Control control = parentControl.FindControl("_" + p.Name);
            if (control != null)
            {
                Type t_c = control.GetType();
                switch (t_c.FullName)
                {
                    case "System.Web.UI.WebControls.Label": ((Label)control).Text = Convert.ToString(p.GetValue(model, null)); break;
                    case "System.Web.UI.WebControls.Literal": ((Literal)control).Text = Convert.ToString(p.GetValue(model, null)); break;
                    case "System.Web.UI.WebControls.TextBox": ((TextBox)control).Text = Convert.ToString(p.GetValue(model, null)); break;
                    case "System.Web.UI.WebControls.Image": ((Image)control).ImageUrl = Convert.ToString(p.GetValue(model, null)); break;
                    case "System.Web.UI.WebControls.DropDownList": ((DropDownList)control).SelectedValue = Convert.ToString(p.GetValue(model, null)); break;
                    case "System.Web.UI.WebControls.RadioButtonList": ((RadioButtonList)control).SelectedValue = Convert.ToString(p.GetValue(model, null)); break;
                    case "System.Web.UI.WebControls.CheckBox": ((CheckBox)control).Checked = (bool)p.GetValue(model, null); break;
                    case "System.Web.UI.WebControls.HiddenField": ((HiddenField)control).Value = Convert.ToString(p.GetValue(model, null)); break;
                    case "System.Web.UI.HtmlControls.HtmlInputHidden": ((HtmlInputHidden)control).Value = Convert.ToString(p.GetValue(model, null)); break;
                    default: break;
                }
            }
        }

        #endregion

        #region 使用说明
        /*
        注释写的很详细了，页面上的控件得以  "_" 开头，
        再加上Model对应属性的名称，然后后台只需要调用方法就行了。
        在修改信息的页面使用比较频繁。
         
        比如修改新闻的步骤
        1.获取指定新闻
        2.把指定新闻赋值给页面上要呈现数据的控件
        3.用户修改好后点保存
        4.把页面上控件的数据赋值给Model
        5.调用Update修改数据库数据
         
        2步骤用反射可以减少这样的代码：
         
        News news=bll.GetNews(10);
        txbTitle.Text=news.Title;
        txbContent.Text=news.Content;
        ...
         
        现在就直接这样：
         
        News news=bll.GetNews(10); 
        BindControls(news,this);
         
        就可以把news里的数据呈现在页面上了，而不用反复的通过控件名.Text来赋值了。
         
        4步骤也类似：
         
        News news=bll.GetNews(10); 
        news.Title=txbTitle.Text;
        news.Content=txbContent.Text;
        ...
         
        现在就直接这样：
         
        News news=bll.GetNews(10);
        news=(News)GetModel(news,this);
         
        就可以把页面上的数据呈赋值给Model了，而不用反复的通过控件名.Text来赋值了。
         

        相对性能而言肯定会低点..但的确好用多了，也不容易出现忘记赋值的情况了。

        */
        #endregion
    }
}
