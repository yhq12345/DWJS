<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminIndex.aspx.cs" Inherits="DWKS.Admin_mobile.AdminIndex" %>

<!DOCTYPE html>
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
                [欢迎使用----后台管理页面]</h1>
        </div>
        <div data-role="content">
            <form id="Form1" method="post" runat="server">
            <div>
                <h3>
                    欢迎你使用本系统,:<%=Current_User %><a href='<%=PageBase.Url%>Sys_User/UserEditPwd.aspx'>修改密码</a></h3>
                <div id="div_content">
                </div>
            </div>
            <div>
                <h3>
                    <%=Current_Year_Month %>
                    本月答题情况:
                    <%if (IsSubmit != "")
                      { %>
                    <a style="color: #0f0">[已提交]</a>
                    <%}
                      else
                      { %>
                    <a style="color: #f00;">[未提交]</a>
                    <%} %>
                    <a style="color: #0f0">
                        <%=IsnullHint %></a>
                    <br />
                </h3>
                <div>
                    <table>
                        <tr>
                            <td class="td2_content">
                                我的操作：<a id="a_MyAsk" runat="server">[我要答题]</a>
                            </td>
                            <td class="td2_content">
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <table>
                        <tr>
                            <td>
                                我的历史：
                            </td>
                            <td class="td2_content">
                                <asp:DropDownList ID="ddl_Year_Month" runat="server" onchange="funs.Save_Change(this);return false;" />
                            </td>
                            <td>
                                得分：<label id="lab_Point" runat="server"></label><a onclick="funs.Save(this); return false;">[查看]</a>
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <table>
                        <tr>
                            <td>
                                考试监控：
                            </td>
                            <td>
                               
                            </td>
                            <td>
                                <a>答题情况查看</a>
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <table>
                        <tr>
                            <td>
                                系统操作：
                            </td>
                            <td class="td2_content">
                            </td>
                            <td>
                                <a>用户管理</a> <a>考题管理</a>
                                <%if (CurrentUserModel.UserName == "admin")
                                  {%>
                                <a id="a1" runat="server" onclick="window.location.href='../StartExam/StartExam.aspx'">
                                    [生成考务]</a> <a id="a2" runat="server" onclick="window.location.href='../StartExam/Examination_Import.aspx'">
                                        [导入考题]</a>
                                <%} %>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div>
                <table cellspacing="0" cellpadding="0" width="100%" align="center" class="ShowTable">
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                    </tr>
                </table>
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
