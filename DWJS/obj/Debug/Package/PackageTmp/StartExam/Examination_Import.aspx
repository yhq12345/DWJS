<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Examination_Import.aspx.cs"
    Inherits="DWKS.StartExam.Examination_Import" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
   <%-- <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="format-detection" content="telephone=no" />--%>
   <%-- <link href="<%=PageBase.Url%>JqueryPlug/jquery_mobile/jquery.mobile-1.3.2.min.css"
        rel="stylesheet" type="text/css" />
    <script src="<%=PageBase.Url%>JqueryPlug/jquery_mobile/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url%>JqueryPlug/jquery_mobile/jquery.mobile-1.3.2.min.js"
        type="text/javascript"></script>--%>
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
                考题导入</h1>
        </div>
        <div data-role="content">
            <form id="Form1" method="post" runat="server">
            <div>
                <h3>
                    生成结果：
                </h3>
                <div>
                    <table id="Table1" align="center" border="1px" style="border-collapse: collapse;
                        border: 1px;" width="70%">
                        <tr style="font-size: 13px; font-family: 宋体">
                            <td colspan="3" style="height: 16px">
                                <asp:FileUpload ID="FileUpload1" runat="server" Width="342px" CssClass="FileUpload" />
                            </td>
                        </tr>
                        <tr style="font-size: 13px; font-family: 宋体">
                            <td colspan="3">
                                <asp:Label ID="Lbl_Messaage" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr style="font-size: 13px; font-family: 宋体">
                            <td colspan="3" style="height: 19px">
                                <asp:Label ID="Label_1" runat="server" />
                            </td>
                        </tr>
                        <tr style="font-size: 13px; font-family: 宋体">
                            <td colspan="3" style="height: 19px">
                                <img align="absMiddle" src="../../images/ts.gif" />
                                请下载模板导入考题模板
                            </td>
                        </tr>
                        <tr style="font-size: 13px; font-family: 宋体">
                            <td colspan="3" style="height: 19px">
                                <img align="absMiddle" src="../../images/ts.gif" />
                                请严格按照模板上的字段填写数据不得出现非法字符
                            </td>
                        </tr>
                        <tr style="font-size: 13px; font-family: 宋体">
                            <td colspan="3" style="height: 19px">
                                <img align="absMiddle" src="../../images/ts.gif" />
                                如果是选择的字段请选择对应的项
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="5">
                                <asp:Button ID="ImageButton1" runat="server" ImageAlign="Top" Text="导入" OnClick="Upload1_Click" />
                                <a href="./temp/装维知识问答题库_模板.xls" ><img src="<%=PageBase.Url%>images/anniu_xxfl1.gif"></a>
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                          <tr>
                            <td align="center" colspan="5">
                                <input type="button" src="../images/img_query.gif" value="返回" onclick="location.href='<%=PageBase.Url%>ASK/MyIndex.aspx';" />&nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
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
        $(function () {

        });


        var funs = {
            Save: function (obj) {
                var that = this;
                if (pagequeryValid()) { /*修改*/
                    $.XCLGoAjax({ data: $(obj).closest("form").serialize() + "&method=ajax", obj: obj, isLockBtn: false, isChangeBtnVal: false, successFunction: this.sFunction, beforeSendMsg: "正在执行中,请稍候..." });
                }
            },
            sFunction: function (str) {/*str.Data返回的结果保存*/
                ClearLabelContent();

                if (str.Data.macmodelList == null || str.Data.macmodelList.length < 2) {
                    SingleMacBind(str.Data);
                    $('#a_accout_Show').css('display', 'none');
                }
                else {
                    ListMacBind(str.Data);
                }
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
