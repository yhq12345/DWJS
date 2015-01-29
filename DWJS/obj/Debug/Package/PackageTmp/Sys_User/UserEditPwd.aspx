<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation ="false" ViewStateEncryptionMode ="Never"
 CodeBehind="UserEditPwd.aspx.cs" Inherits="DWKS.Sys_User.UserEditPwd" %>

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
    <script src="<%=PageBase.Url%>PageTemp/Style/Js/jquery-1.8.2.min.js" type="text/javascript"></script>
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

        function getresult(htmlvalue) {
            $('#Ul1').html(htmlvalue);
        }
    </script>
</head>
<body>
    <div data-role="page">
        <div data-role="header">
            <h1>
                修改密码
                </h1>
        </div>
        <div data-role="content">
            <form id="Form1" method="post" runat="server">
            <div>
                <h3>
                    个人信息:<br />姓名：<%= Current_UserName%><br />
                    账号ID：<%=Current_UserID%></h3>
                <div id="div_content">
                    密码:
                    <asp:TextBox ID="txt_password" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                </div>
            </div>
            <div>
                <h3>
                    密码重复:
                </h3>
                <div>
                    <asp:TextBox ID="txt_password2" runat="server" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <div>
                <table cellspacing="0" cellpadding="0" width="100%" align="center" class="ShowTable">
                    <tr>
                        <td colspan="3">
                            <input id="Button1" type="button" runat="server" src="../images/img_query.gif" value="修改密码"
                               onclick="funs.Save(this);"/>&nbsp;
                        </td>
                    </tr>
                     <tr>
                        <td colspan="3">
                            <input id="Button2" type="button" runat="server" src="../images/img_query.gif" value="返回"
                               onclick="location.href='../ASK/MyIndex.aspx'"/>&nbsp;
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <ul id="Ul1">
                </ul>
            </div>
            </form>
        </div>
        <div data-role="footer">
            <h1>
            </h1>
        </div>
    </div>
    <script type="text/javascript">

        var funs = {
            Save: function (obj) {
                var that = this;
                if (pagequeryValid()) { /*修改*/
                    $.XCLGoAjax({ data: $(obj).closest("form").serialize() + "&method=ajax", obj: obj, isLockBtn: false, isChangeBtnVal: false,  beforeSendMsg: "正在执行中,请稍候..." });
                }
            },
            sFunction: function (str) {/*str.Data返回的结果保存*/
            }
        };
        function pagequeryValid() {
            var alertmsg = '';
            if ($.trim($('#txt_password').val()) == '') {
                alertmsg += "请输入密码！";
            }
            if ($.trim($('#txt_password').val()) != $.trim($('#txt_password2').val())) {
                alertmsg += "两次密码不相等！";
            }
            if (alertmsg != '') {
                alert(alertmsg);
                return false;
            }
            return true;
        }

        

    </script>
</body>
</html>
