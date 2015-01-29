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
                ��ά�ʴ�ϵͳ-�ƶ������</h1>
        </div>
        <div data-role="content">
            <div style="text-align: center; font-size: 15px;">
                *ע�Ȿƽ̨�Ƽ�ʹ��FireFox(��������)*
                <br />
            </div>
            <br />
            <div style="width: 100%;">
                �û���:<input type="text" runat="server" id="txt_userName" /><br />
            </div>
            <div style="width: 100%;">
                �� ��:<input type="password" runat="server" id="txt_pwd" />
            </div>
            <input type="button" runat="server" id="img_login" value="��¼" onclick="funs.Save(this);return false;" />
        </div>
        
        <div data-role="footer">
            <h1>
                CopyRight &copy; 2013-2014�����ƶ��ʹ���</h1>
        </div>
    </div>
    </form>
    <script type="text/javascript">
        var funs = {
            Save: function (obj) {
                var that = this;
                if (pagequeryValid()) { /*�޸�*/
                    $.XCLGoAjax({ data: $(obj).closest("form").serialize() + "&method=ajax", obj: obj, isLockBtn: false, isChangeBtnVal: false, successFunction: this.sFunction, beforeSendMsg: "���ڵ�¼��,���Ժ�..." });
                }
            },
            sFunction: function (str) {/*str.Data���صĽ������*/
                art.dialog.tips("��¼�ɹ���������ת��......", 500000);
                location.href = './ASK/MyIndex.aspx';
            }
        }
        function pagequeryValid() {
            var alertmsg = '';
            if ($.trim($('#txt_userName').val()) == '') {
                alertmsg = '�˺ű�����д��\n';
            }
            if ($.trim($('#txt_pwd').val()) == '') {
                alertmsg = '���������д��\n';
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
