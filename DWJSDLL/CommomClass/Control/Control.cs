using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;
using CommonClass.Enum;

namespace CommonClass.Control
{
    /// <summary>
    /// 服务器控件操作相关
    /// </summary>
    public  class Control
    {
        private static string EmptyText = "没有记录";
        #region Repeater操作
        /// <summary>
        /// Repeater绑定数据
        /// </summary>
        /// <param name="rep">Repeater控件</param>
        /// <param name="dataSource">数据源</param>
        /// <param name="isShowNoDataMsg">true:没有数据时，显示“暂无数据”</param>
        /// <param name="noDataMsg">没有数据时非默认提示</param>
        public static void RepDataBind<T>(Repeater rep, List<T> dataSource, bool isShowNoDataMsg, params string[] noDataMsg)
        {
            if (null != dataSource&&dataSource.Count>0)
            {
                rep.DataSource = dataSource;
                rep.DataBind();
            }
            else
            {
                if (isShowNoDataMsg)
                {
                    rep.Controls.Clear();
                    rep.Controls.Add(new Literal() { Text = (null != noDataMsg && noDataMsg.Length > 0 && !string.IsNullOrEmpty(noDataMsg[0])) ? noDataMsg[0] : "<tr><td colspan='100' align='center'>对不起，暂无数据！</td></tr>" });
                }
            }
        }

        /// <summary>
        /// Repeater绑定数据
        /// </summary>
        /// <param name="rep">Repeater控件</param>
        /// <param name="dataSource">数据源</param>
        /// <param name="isShowNoDataMsg">true:没有数据时，显示“暂无数据”</param>
        /// <param name="noDataMsg">没有数据时非默认提示</param>
        public static void RepDataBind(Repeater rep, DataTable dataSource, bool isShowNoDataMsg,params string[] noDataMsg)
        {
            if (null != dataSource && dataSource.Rows.Count>0)
            {
                rep.DataSource = dataSource;
                rep.DataBind();
            }
            else
            {
                if (isShowNoDataMsg)
                {
                    rep.Controls.Clear();
                    rep.Controls.Add(new Literal() { Text =(null!=noDataMsg&&noDataMsg.Length>0&&!string.IsNullOrEmpty(noDataMsg[0])) ?noDataMsg[0]:"<tr><td colspan='100' align='center'>对不起，暂无数据！</td></tr>"});
                }
            }
        }
        #endregion

        #region  DropDownList操作
        /// <summary>
        /// 绑定DDL，value为初始选中值
        /// </summary>
        /// <param name="ddl">DropDownList</param>
        /// <param name="ds">dataset</param>
        /// <param name="textField">文本字段</param>
        /// <param name="valueField">值字段</param>
        /// <param name="value">默认选中项的值</param>
        /// <param name="flag">true:有"--全部--" false:无</param>
        public static void BindDDL(System.Web.UI.WebControls.DropDownList ddl, DataSet ds, string textField, string valueField, string value, bool flag)
        {
            if (null != ds && ds.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = ds;
                ddl.DataTextField = textField;
                ddl.DataValueField = valueField;
                ddl.DataBind();
            }
            if (!string.IsNullOrEmpty(value))
            {
                ddl.SelectedValue = value;
            }
            if (flag)
            {
                ddl.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--请选择--", "-1"));
            }
        }
        #endregion

        #region CheckBoxList操作
        /// <summary>
        /// 绑定CheckBoxList，value为初始选中值
        /// </summary>
        /// <param name="ck">CheckBoxList</param>
        /// <param name="ds">dataset</param>
        /// <param name="textField">文本字段</param>
        /// <param name="valueField">值字段</param>
        /// <param name="value">以,隔开的字符串，默认选中值</param>
        public static void BindCheckBoxList(System.Web.UI.WebControls.CheckBoxList ck, DataSet ds, string textField, string valueField, string value)
        {
            if (null != ds && ds.Tables[0].Rows.Count > 0)
            {
                ck.DataSource = ds;
                ck.DataTextField = textField;
                ck.DataValueField = valueField;
                ck.DataBind();
            }
            if (!string.IsNullOrEmpty(value))
            {
                string[] v = value.Split(',');
                for (int i = 0; i < v.Length; i++)
                {
                    for (int j = 0; j < ck.Items.Count; j++)
                    {
                        if (v[i] == ck.Items[j].Value)
                        {
                            ck.Items[j].Selected = true;
                            break;
                        }
                    }
                }
            }
        }
        #endregion
        /// <summary>
        /// Repeater绑定数据
        /// </summary>
        /// <param name="rep">Repeater控件</param>
        /// <param name="dataSource">数据源</param>
        /// <param name="isShowNoDataMsg">true:没有数据时，显示“暂无数据”</param>
        /// <param name="noDataMsg">没有数据时非默认提示</param>
        public static void DataGridDataBind(DataGrid rep, DataTable dataSource, bool isShowNoDataMsg, params string[] noDataMsg)
        {
            if (null != dataSource && dataSource.Rows.Count > 0)
            {
                rep.DataSource = dataSource;
                rep.DataBind();
            }
            else
            {
                if (isShowNoDataMsg)
                {
                    dataSource = dataSource.Clone();
                    dataSource.Rows.Add(dataSource.NewRow());
                    rep.DataSource = dataSource;
                    rep.DataBind();

                    int columnCount = dataSource.Columns.Count;
                    rep.Items[0].Cells.Clear();
                    rep.Items[0].Cells.Add(new TableCell());
                    rep.Items[0].Cells[0].ColumnSpan = columnCount;
                    rep.Items[0].Cells[0].Text = EmptyText;
                    rep.Items[0].Cells[0].Style.Add("text-align", "center");

                }
            }
        }

        #region 其它
        /// <summary>
        /// 绑定枚举
        /// </summary>
        /// <param name="c">控件</param>
        /// <param name="lst">EnumObj list</param>
        /// <param name="defaultValue">默认选中值</param>
        public static void BindEnum(System.Web.UI.WebControls.WebControl c, List<EnumObj> lst, string defaultValue)
        {
            if (null != lst && lst.Count > 0)
            {
                if (c is RadioButtonList)
                {
                    RadioButtonList rb = ((RadioButtonList)c);
                    rb.DataSource = lst;
                    rb.DataTextField = "text";
                    rb.DataValueField = "value";
                    rb.DataBind();
                    if (!string.IsNullOrEmpty(defaultValue))
                    {
                        rb.SelectedValue = defaultValue;
                    }
                }
            }
        }

        /// <summary>
        /// 将list绑定到控件上
        /// </summary>
        /// <param name="defaultValue">默认选中值</param>
        public static void BindLst<T>(System.Web.UI.WebControls.WebControl c, List<T> lst, string textField, string valueField, string value, bool flag)
        {
            if (null != lst && lst.Count > 0)
            {
                if (c is DropDownList)
                {
                    DropDownList ddl = ((DropDownList)c);
                    ddl.DataSource = lst;
                    ddl.DataTextField = textField;
                    ddl.DataValueField = valueField;
                    ddl.DataBind();
                    if (!string.IsNullOrEmpty(value))
                    {
                        ddl.SelectedValue = value;
                    }
                    if (flag)
                    {
                        ddl.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--请选择--", "-1"));
                    }
                }
                else if (c is RadioButtonList)
                {
                    RadioButtonList rb = ((RadioButtonList)c);
                    rb.DataSource = lst;
                    rb.DataTextField = textField;
                    rb.DataValueField = valueField;
                    rb.DataBind();
                    if (!string.IsNullOrEmpty(value))
                    {
                        rb.SelectedValue = value;
                    }
                }
            }
        }
        #endregion
    }
}
