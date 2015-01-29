<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuestionBankList.aspx.cs"
    Inherits="DWKS.Admin.ExamMng.QuestionBankList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>类别</title>
    <link type="text/css" rel="stylesheet" href="<%=PageBase.Url %>lib/ligerUI/skins/Aqua/css/ligerui-all.css" />
    <link type="text/css" rel="stylesheet" href="<%=PageBase.Url %>lib/ligerUI/skins/Gray/css/all.css" />
    <script type="text/javascript" src="<%=PageBase.Url %>lib/jquery/jquery-1.7.2.min.js"></script>
    <link type="text/css" rel="stylesheet" href="<%=PageBase.Url %>lib/css/common.css" />
    <script type="text/javascript" src="<%=PageBase.Url %>lib/js/common.js"></script>
    <script type="text/javascript" src="<%=PageBase.Url %>lib/json2.js"></script>
    <script src="<%=PageBase.Url %>lib/ligerUI/js/core/base.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url %>lib/ligerUI/js/ligerui.min.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url %>lib/ligerUI/js/plugins/ligerTab.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url %>lib/ligerUI/js/plugins/ligerComboBox.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url %>lib/ligerUI/js/plugins/ligerGrid.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url %>js/DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url %>js/table.js" type="text/javascript"></script>
    <script type="text/javascript">
        var tab;
        $(function () {
            tab = $("#framecenter").ligerTab({ contextmenu: true });
        });

        var tabidcounter = 0;
        //增加tab项的函数
        function f_addTab(tabid, text, url) {
            if (!tab) { return };
            if (!tabid) {
                tabidcounter++;
                tabid = "tabid" + tabidcounter;
            }
            tab.addTabItem({ tabid: tabid, text: text, url: url });
        }
        function alertmsg() {
            var win = parent || window;
            win.f_changepassword();
        }
       

    </script>
    <style type="text/css">
        .searchbox
        {
            width: 980px;
        }
        .searchbox ul li
        {
            float: left;
        }
    </style>
</head>
<body style="padding: 0px; text-align: center;">
    <form id="Form1" runat="server" method="post">
    <%--<input  id="page" name ="page" type="hidden"  value="<%= Request.Params["page"] %>"  />--%>
    <div style="margin-left: 10px;" class="" id="mainsearch">
        <div class="searchtitle">
            <span>搜索</span><img src="<%=PageBase.Url %>lib/icons/32X32/searchtool.gif" />
            <div class="togglebtn">
            </div>
        </div>
        <div style="margin-bottom: 4px; margin-top: 4px;" class="navline">
        </div>
        <div class="searchbox">
            <ul>
                <li style="width: 90px; text-align: left;">考题内容：</li>
                <li style="width: 200px; text-align: left;">
                    <div class="l-text" style="width: 178px;">
                         <input type="text" runat="server" id="txt_KTRN" name="RNCIP" class="field l-text-field"
                            style="width: 174px;" />
                        <div class="l-text-l">
                        </div>
                        <div class="l-text-r">
                        </div>
                    </div>
                </li>
                <li style="width: 40px;"></li>
            </ul>
            <ul>
                <li style="width: 90px; text-align: left;">:</li>
                <li style="width: 200px; text-align: left;">
                    <div class="" style="width: 178px;">
                     
                        <div class="l-text-l">
                        </div>
                        <div class="l-text-r">
                        </div>
                    </div>
                </li>
                <li style="width: 40px;"></li>
            </ul>
            <ul>
                <li style="width: 90px; text-align: left;">：</li>
                <li style="width: 200px; text-align: left;">
                    <div class="l-text" style="width: 178px;">
                        
                        <div class="l-text-l">
                        </div>
                        <div class="l-text-r">
                        </div>
                    </div>
                </li>
                <li style="width: 40px;"></li>
            </ul>
        </div>
        <div class="l-clear">
        </div>
        <div class="searchbox">
            <ul>
                <li style="width: 90px; text-align: left;">：</li>
                <li style="width: 200px; text-align: left;">
                    <div class="l-text" style="width: 178px;">
                       
                        <div class="l-text-l">
                        </div>
                        <div class="l-text-r">
                        </div>
                    </div>
                </li>
                <li style="width: 40px;"></li>
            </ul>
            <ul>
                <li style="width: 90px; text-align: left;"></li>
                <li style="text-align: left; width: 200px;">
                    <div class="" style="width: 178px;">
                    </div>
                    <div class="l-text-l">
                    </div>
                    <div class="l-text-r">
                    </div>
                </li>
                <li style="width: 40px;"></li>
            </ul>
            <ul>
                <li style="width: 90px; text-align: left;"></li>
                <li style="width: 200px; text-align: left;">
                    <div class="" style="width: 178px;">
                    </div>
                </li>
                <li style="width: 40px;"></li>
            </ul>
        </div>
        <div class="l-clear">
        </div>
        <div class="l-clear">
        </div>
        <div class="searchbox">
            <ul>
                <li style="margin-right: 8px">
                    <input id="btn_query" type="button" runat="server" value="查询" onserverclick="btn_query_Click" />
                </li>
                <%--<li >
                    <div style="width: 80px;" class="button button2 buttonnoicon" onclick="alertmsg();" >
                        <div class="button-l"></div>
                        <div class="button-r"></div>
                        <span>高级搜索</span>
                    </div>
                </li>--%>
            </ul>
            <div class="l-clear">
            </div>
        </div>
    </div>
    <div id="maingrid" class="l-panel" style="width: 98%; margin-left: 10px;">
        <!--修改大小 默认100%-->
        <div class="l-panel-header" style="display: none;">
            <span class="l-panel-header-text"></span>
        </div>
        <div class="l-grid-loading" style="display: none;">
            加载中...</div>
        <div class="l-panel-topbar l-toolbar">
            <%--<a onclick="top.f_addTab('RNC_Add', 'RNC信息添加', '<%=PageBase.Url %>/RNCConfig/RNCConfigDetail.aspx?type=add');">
                <span class="l-toolbar-item l-panel-btn l-toolbar-item-hasicon">
                    <img src="<%=PageBase.Url %>lib/icons/silkicons/add.png" />新增</span></a>--%>
            <div class="l-bar-separator">
            </div>
            <%-- <a runat="server" id="a_excel_port"  onserverclick="a_excel_port_Click">
                <span class="l-toolbar-item l-panel-btn l-toolbar-item-hasicon">
                    <img src="../../lib/icons/silkicons/page_white_excel.png" />导出</span></a>--%>
        </div>
        <div class="l-panel-bwarp">
            <!--style="width:2000px;" Can Change this Content Div's Length-->
            <div class="l-panel-body">
                <div class="l-grid" id="maingridgrid" style="height: 100%;">
                    <div class="l-grid-dragging-line">
                    </div>
                    <div class="l-grid1">
                        <div class="l-grid-header l-grid-header1" style="height: 30px;">
                            <div class="l-grid-header-inner">
                                <table cellspacing="0" cellpadding="0" class="l-grid-header-table">
                                    <tbody>
                                        <tr class="l-grid-hd-row">
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div class="l-grid-body l-grid-body1" style="height: 289px;">
                        </div>
                    </div>
                    <div class="l-grid2 tableList">
                        <asp:DataGrid ID="Dg_Record" runat="server" AutoGenerateColumns="False" DataKeyField="Id"
                            CssClass="l-grid-body-table" EmptyDataText="没有记录" HorizontalAlign="Center" RowStyle-BorderWidth="1px"
                            Width="100%" OnItemDataBound="Dg_Record_ItemDataBound">
                            <HeaderStyle CssClass="l-grid-header  l-grid-header-inner l-grid-hd-cell-text" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" CssClass="l-grid-row-cell l-grid-row-cell-inner" />
                            <Columns>
                                <asp:TemplateColumn HeaderText="操作" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <a onclick="top.f_addTab('QuestionBank_See'+<%#Eval("id") %>, '题库信息查看', '/Admin/ExamMng/BSCConfigMng/ExaminationDetail.aspx?type=see&id=<%#Eval("id") %>') ;">
                                         查看</a> 
                                        <a onclick="top.f_addTab('QuestionBank_Edit'+<%#Eval("id") %>, '题库信息修改', '/Admin/ExamMng/BSCConfigMng/ExaminationDetail.aspx?type=update&id=<%#Eval("id") %>') ;">
                                        <asp:LinkButton ID="lk_del" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id") %>'
                                        CommandName="Del" ForeColor="#FF0000" OnClientClick="return confirm('确定删除？');">删除</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="序号" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <%#(this.pager.CurrentPageIndex-1)*this.pager.PageSize+Container.ItemIndex+1%>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn DataField="题目内容" HeaderText="题目内容"></asp:BoundColumn>
                                <asp:BoundColumn DataField="是否是错题" HeaderText="是否是错题" DataFormatString="{0:yyyy-MM}">
                                </asp:BoundColumn>
                                </Columns>
                        </asp:DataGrid>
                    </div>
                </div>
            </div>
        </div>
        <div class="l-panel-bar">
            <webdiyer:AspNetPager ID="pager" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </webdiyer:AspNetPager>
        </div>
    </div>
    <script type="text/javascript">
        //相对路径
        var rootPath = "../";
        //列表结构
    </script>
    <div style="display: none; height: 295px;" class="l-window-mask">
    </div>
    </form>
</body>
</html>
