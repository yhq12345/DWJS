<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExaminationList.aspx.cs"
    Inherits="DWKS.Admin_mobile.ExaminationList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="format-detection" content="telephone=no" />
    <link href="<%=PageBase.Url%>JqueryPlug/jquery_mobile/jquery.mobile-1.3.2.min.css"
        rel="stylesheet" type="text/css" />
    <script src="<%=PageBase.Url%>JqueryPlug/jquery_mobile/jquery-1.8.3.min.js" type="text/javascript"></script>
    
    <script src="<%=PageBase.Url%>JqueryPlug/jquery_mobile/jquery.mobile-1.3.2.min.js"
        type="text/javascript"></script>
    <script src="<%=PageBase.Url%>js/aridiologfile/artDialog.source.js?skin=black" type="text/javascript"></script>
    <script src="<%=PageBase.Url%>js/aridiologfile/plugins/iframeTools.source.js" type="text/javascript"></script>
    <link href="<%=PageBase.Url%>css/admin.css" type="text/css" rel="stylesheet" />
    <link href="<%=PageBase.Url%>css/admin2.css" type="text/css" rel="stylesheet" />
    <script src="<%=PageBase.Url%>js/Common.js" type="text/javascript" language="javascript"></script>
    <script src="<%=PageBase.Url%>js/highchart/highcharts.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url%>js/GoAjax.js" type="text/javascript"></script>
    <style type="text/css">
      
        .titletd
        {
            font-size: 12px;
            font-weight: bold;
            width: 23%;
        }
        table tr td
        {
            font-size: 16px;
        }
        .td2_content
        {
            font-size: 16x;
            width:120px;
        }
        .tdColWidth
        {
           width:120px; 
        }
        
    </style>
    <script type="text/javascript">
        $(function () {
            $('#a_MyAsk').bind('click', function () {
                window.location.href = './MyAsk.aspx?id=1';
            });
        });
    </script>
</head>
<body>
    <div data-role="page">
        <div data-role="header">
            <h1>
                [答题情况列表]</h1>
        </div>
        <div data-role="content">
            <form id="Form1" method="post"  runat="server">
            <div>
                <h3>
                    欢迎你使用本系统,:</h3>
                <div id="div_content">
                <table >
                <tr>
                <td>查询月份：</td><td><asp:DropDownList ID="ddl_Year_Month" runat="server" /></td> 
                <td>提交情况:</td><td><asp:DropDownList ID="ddl_TJQK" runat="server" /></td>
                <td><input id="btn_query" type="button" runat="server"  value="查询" onserverclick="btn_query_Click"/>
                </td><td><input id="btn_export" runat="server" type="button" value="导出" onserverclick="btn_export_Click"/></td>
                <td>
                <input id="Button1" runat="server" type="button" value="返回首页" 
                onclick="location.href='../ASK/MyIndex.aspx'"/></td>
                </tr>
                  <tr>
                <td></td>  <td></td>  <td></td>  <td></td>  <td></td>  <td></td>  <td></td>
                </tr>
                </table>
                   
                  
                </div>
            </div>
            <div>
                <h3>
                </h3>
                <div>
                    <table style="border:1px solid #000">
                        <tr>
                            <td >
                                序列号
                            </td>
                            <td>
                                用户名
                            </td>
                            <td>
                                月份
                            </td>
                             <td>
                                考务生成时间
                            </td>
                            <td>
                                提交时间
                            </td>
                            <td>回答情况</td>
                            <td>得分</td>
                            <td>提交情况</td>
                        </tr>
                        <asp:Repeater ID="RepList" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%#this.pager.PageSize*(this.pager.CurrentPageIndex-1)+Container.ItemIndex+1%>
                                    </td>
                                    <td class="td2_content">
                                        <%#Convert.ToString(Eval("代维人员姓名"))%>
                                    </td>
                                    <td class="td2_content">
                                        <%#Eval("月份","{0:yyyy-MM}")%>
                                    </td>
                                        <td class="td2_content">
                                        <%#Eval("考务生成时间","{0:yyyy-MM}")%>
                                    </td>
                                    <td class="td2_content">
                                        <%#Eval("提交时间","{0:d}")%>
                                    </td>
                                    <td class="td2_content">
                                        <%#Eval("回答情况")%>
                                    </td>
                                    <td class="td2_content">
                                        <%#Eval("得分")%>
                                    </td>
                                    <td class="td2_content">
                                        <%#Eval("提交情况")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
                <div class="divPager">
                    <webdiyer:AspNetPager ID="pager" runat="server" OnPageChanged="AspNetPager1_PageChanged" >
                    </webdiyer:AspNetPager>
                </div>
            </div>
            </form>
        </div>
        <div data-role="footer">
            <h1>
            </h1>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            funs.Save_Change($('#ddl_Year_Month'));
        });


        var funs = {
            Save: function (obj) {
                $.XCLGoAjax({ data: $(obj).closest("form").serialize() + "&method=ajax&handleType=See", obj: obj, isLockBtn: false, isChangeBtnVal: false, successFunction: this.sFunction_Save, beforeSendMsg: "跳转中..." });
            },
            sFunction_Save: function (str) {
                window.location.href = './MyAskHis.aspx?id=1&YearMonth=' + str.msg;
            },
            Save_Change: function (obj) {
                $.XCLGoAjax({ data: $(obj).closest("form").serialize() + "&method=ajax&handleType=Change", obj: obj, isLockBtn: false, isChangeBtnVal: false, successFunction: this.sFunction_Chage, beforeSendMsg: "查询中..." });
            },
            sFunction_Chage: function (str) {
                $('#lab_Point').text(str.msg);
            }
        };
        function pagequeryValid() {
            var alertmsg = '';

            if (alertmsg != '') {
                alert(alertmsg);
                return false;
            }
            return true;
        }

    </script>
</body>
</html>
