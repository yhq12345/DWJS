using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace Eastcom
{
    public class DataGridViewBind
    {
        private static string EmptyText = "没有记录";
        public void Bind(string tbname, string FieldKey, int PageCurrent, int PageSize, string FieldShow, string FieldOrder, string Where, out int PageCount, System.Web.UI.WebControls.GridView grid, Label lbpagecount, Label lbcurpage)
        {

            string strconn = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

            SqlConnection cn = new SqlConnection(strconn);
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter("sp_PageView", cn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@tbname", SqlDbType.NVarChar);
            da.SelectCommand.Parameters.Add("@FieldKey", SqlDbType.NVarChar);
            da.SelectCommand.Parameters.Add("@PageCurrent", SqlDbType.Int);
            da.SelectCommand.Parameters.Add("@PageSize", SqlDbType.Int);
            da.SelectCommand.Parameters.Add("@FieldShow", SqlDbType.NVarChar);
            da.SelectCommand.Parameters.Add("@FieldOrder", SqlDbType.NVarChar);
            da.SelectCommand.Parameters.Add("@Where", SqlDbType.NVarChar);
            da.SelectCommand.Parameters.Add("@PageCount", SqlDbType.Int);

            da.SelectCommand.Parameters["@tbname"].Value = tbname;
            da.SelectCommand.Parameters["@FieldKey"].Value = FieldKey;
            da.SelectCommand.Parameters["@PageCurrent"].Value = PageCurrent;
            da.SelectCommand.Parameters["@PageSize"].Value = PageSize;
            da.SelectCommand.Parameters["@FieldShow"].Value = FieldShow;
            da.SelectCommand.Parameters["@FieldOrder"].Value = FieldOrder;
            da.SelectCommand.Parameters["@Where"].Value = Where;
            da.SelectCommand.Parameters["@PageCount"].Direction = ParameterDirection.Output;

            DataSet ds = new DataSet();

            da.Fill(ds);

            PageCount = (int)da.SelectCommand.Parameters["@PageCount"].Value;

            lbpagecount.Text = PageCount.ToString();
            lbcurpage.Text = PageCurrent.ToString();
            grid.DataSource = ds;

            grid.DataBind();
            cn.Close();
        }

        ///<summary>
        ///防止PostBack后Gridview不能显示
        ///</summary>
        ///<param name="gridview"></param>
        public static void ResetGridView(GridView gridview)
        {
            //如果数据为空则重新构造Gridview
            if (gridview.Rows.Count == 1 && gridview.Rows[0].Cells[0].Text == EmptyText)
            {
                int columnCount = gridview.Columns.Count;
                gridview.Rows[0].Cells.Clear();
                gridview.Rows[0].Cells.Add(new TableCell());
                gridview.Rows[0].Cells[0].ColumnSpan = columnCount;
                gridview.Rows[0].Cells[0].Text = EmptyText;
                gridview.Rows[0].Cells[0].Style.Add("text-align", "center");
            }
        }

        ///<summary>
        ///绑定数据到GridView，当表格数据为空时显示表头
        ///</summary>
        ///<param name="gridview"></param>
        ///<param name="table"></param>
        public static void GridViewDataBind(GridView gridview, DataTable table)
        {
            //记录为空重新构造Gridview
            if (table.Rows.Count == 0)
            {
                table = table.Clone();
                table.Rows.Add(table.NewRow());
                gridview.DataSource = table;
                gridview.DataBind();
                int columnCount = table.Columns.Count;
                gridview.Rows[0].Cells.Clear();
                gridview.Rows[0].Cells.Add(new TableCell());
                gridview.Rows[0].Cells[0].ColumnSpan = columnCount;
                gridview.Rows[0].Cells[0].Text = EmptyText;
                gridview.Rows[0].Cells[0].Style.Add("text-align", "center");
            }
            //重新绑定取消选择
            // gridview.SelectedIndex = -1;
        }


    }
}
