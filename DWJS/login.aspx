<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Web.login" %>

<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="format-detection" content="telephone=no" />
    <link href="<%=PageBase.Url%>JqueryPlug/jquery_mobile/jquery.mobile-1.3.2.min.css"
        rel="stylesheet" type="text/css" />
    <script src="<%=PageBase.Url%>JqueryPlug/jquery_mobile/jquery-1.8.3.min.js"
        type="text/javascript"></script>
    <script src="<%=PageBase.Url%>JqueryPlug/jquery_mobile/jquery.mobile-1.3.2.min.js"
        type="text/javascript"></script>
   
    <script src="<%=PageBase.Url%>js/aridiologfile/artDialog.source.js?skin=black"
        type="text/javascript"></script>
    <script src="<%=PageBase.Url%>js/aridiologfile/plugins/iframeTools.source.js"
        type="text/javascript"></script>
    <link href="<%=PageBase.Url%>css/admin.css" type="text/css" rel="stylesheet" />
    <link href="<%=PageBase.Url%>css/admin2.css" type="text/css" rel="stylesheet" />
    <script src="<%=PageBase.Url%>js/Common.js" type="text/javascript"
        language="javascript"></script>
    <script src="<%=PageBase.Url%>js/highchart/highcharts.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url%>js/GoAjax.js" type="text/javascript"></script>
</head>
<body>
    <form runat="server" id="form1">
    <div data-role="page" id="pageone">
        <div data-role="header">
            <h1>
                代维问答系统-移动版入口</h1>
        </div>
        <div data-role="content">
            <div style="text-align: center; font-size: 15px;">
                *注意本平台推荐使用FireFox(火狐浏览器)*
                <br />
            </div>
            <br />
            <div style="width: 100%;">
                用户名:<input type="text" runat="server" id="txt_userName" /><br />
            </div>
            <div style="width: 100%;">
                口 令:<input type="password" runat="server" id="txt_pwd" />
            </div>
            <input type="button" runat="server" id="img_login" value="登录" onclick="funs.Save(this);return false;" />
        </div>
        
        <div data-role="footer">
            <h1>
                CopyRight &copy; 2013-2014温州移动资管组</h1>
        </div>
    </div>
    </form>
    <script type="text/javascript">
        var funs = {
            Save: function (obj) {
                var that = this;
                if (pagequeryValid()) { /*修改*/
                    $.XCLGoAjax({ data: $(obj).closest("form").serialize() + "&method=ajax", obj: obj, isLockBtn: false, isChangeBtnVal: false, successFunction: this.sFunction, beforeSendMsg: "正在登录中,请稍候..." });
                }
            },
            sFunction: function (str) {/*str.Data返回的结果保存*/
                art.dialog.tips("登录成功，正在跳转中......", 500000);
                location.href = './ASK/MyIndex.aspx';
            }
        }
        function pagequeryValid() {
            var alertmsg = '';
            if ($.trim($('#txt_userName').val()) == '') {
                alertmsg = '账号必须填写！\n';
            }
            if ($.trim($('#txt_pwd').val()) == '') {
                alertmsg = '密码必须填写！\n';
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
